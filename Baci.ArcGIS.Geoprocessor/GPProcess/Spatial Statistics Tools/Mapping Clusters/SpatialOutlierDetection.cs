using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Spatial Outlier Detection</para>
	/// <para>Spatial Outlier Detection</para>
	/// <para>Identifies spatial outliers in point features by calculating the local outlier factor (LOF) of each feature.  Spatial outliers are features in locations that are abnormally isolated, and the LOF is a measurement that describes how isolated a location is from its local neighbors. A higher LOF value indicates higher isolation. The tool can also be used to produce a raster prediction surface that can be used to estimate if new features will be classified as outliers given the spatial distribution of the data.</para>
	/// </summary>
	public class SpatialOutlierDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point features used to build the spatial outlier detection model. Each point will be classified as an outlier or inlier based on its local outlier factor.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class containing the local outlier factor for each input feature as well as an indicator of whether the point is a spatial outlier.</para>
		/// </param>
		public SpatialOutlierDetection(object InFeatures, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Spatial Outlier Detection</para>
		/// </summary>
		public override string DisplayName() => "Spatial Outlier Detection";

		/// <summary>
		/// <para>Tool Name : SpatialOutlierDetection</para>
		/// </summary>
		public override string ToolName() => "SpatialOutlierDetection";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatialOutlierDetection</para>
		/// </summary>
		public override string ExcuteName() => "stats.SpatialOutlierDetection";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, NNeighbors, PercentOutlier, OutputRaster };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point features used to build the spatial outlier detection model. Each point will be classified as an outlier or inlier based on its local outlier factor.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing the local outlier factor for each input feature as well as an indicator of whether the point is a spatial outlier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The number of neighbors to include when calculating the local outlier factor. The closest features to the input point are used as neighbors. The default is 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100000000)]
		public object NNeighbors { get; set; } = "20";

		/// <summary>
		/// <para>Percent of Locations Considered Outliers</para>
		/// <para>The percent of locations to be identified as spatial outliers by defining the threshold of the local outlier factor. If no value is specified, a value is estimated at run time and is displayed as a geoprocessing message.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 49)]
		public object PercentOutlier { get; set; }

		/// <summary>
		/// <para>Output Prediction Raster</para>
		/// <para>The output raster containing the local outlier factors at each cell, which is calculated based on the spatial distribution of the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutputRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialOutlierDetection SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

	}
}
