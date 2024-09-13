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
	/// <para>Identifies global or local spatial outliers in point features.</para>
	/// </summary>
	public class SpatialOutlierDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point features that will be used to build the spatial outlier detection model. Each point will be classified as an outlier or inlier based on its local outlier factor.</para>
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
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, NNeighbors!, PercentOutlier!, OutputRaster!, OutlierType!, Sensitivity!, KeepType! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point features that will be used to build the spatial outlier detection model. Each point will be classified as an outlier or inlier based on its local outlier factor.</para>
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
		/// <para>The number of neighbors that will be used to detect spatial outliers for each input point.</para>
		/// <para>For local outlier detection, the value must be at least 2, and all features within the neighborhood will be used as neighbors. If no value is specified, a value is estimated at run time and is displayed as a geoprocessing message.</para>
		/// <para>For global outlier detection, only the farthest neighbor in the neighborhood will be used, and the default is 1 (the closest neighbor). For example, a value of 3 indicates that global outliers are detected using distances to the third nearest neighbor of each point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NNeighbors { get; set; } = "1";

		/// <summary>
		/// <para>Percent of Locations Considered Outliers</para>
		/// <para>The percent of locations that will be identified as spatial outliers by defining the threshold of the local outlier factor. If no value is specified, a value is estimated at run time and is displayed as a geoprocessing message. A maximum of 50 percent of the features can be identified as spatial outliers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-05, Max = 50)]
		public object? PercentOutlier { get; set; }

		/// <summary>
		/// <para>Output Prediction Raster</para>
		/// <para>The output raster containing the local outlier factors at each cell, which is calculated based on the spatial distribution of the input features.</para>
		/// <para>This parameter is only available with a Desktop Advanced license.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutputRaster { get; set; }

		/// <summary>
		/// <para>Outlier Type</para>
		/// <para>Specifies the type of outlier that will be detected. A global outlier is a point that is far away from all other points in the feature class. A local outlier is a point that is farther away from its neighbors than would be expected by the density of points in the surrounding area.</para>
		/// <para>Global—Global outliers of input points will be detected. This is the default.</para>
		/// <para>Local—Local outliers of input points will be detected.</para>
		/// <para><see cref="OutlierTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutlierType { get; set; } = "GLOBAL";

		/// <summary>
		/// <para>Detection Sensitivity</para>
		/// <para>Specifies the sensitivity level that will be used to detect global outliers. The higher the sensitivity, the more points that will be detected as outliers.</para>
		/// <para>The sensitivity value will determine the threshold, and any point with a neighbor distance larger than this threshold will be identified as a global outlier. The thresholds are determined using the box plot rule, in which the threshold for high sensitivity is one interquartile range above the third quartile. For medium sensitivity, the threshold is 1.5 interquartile ranges above the third quartile. For low sensitivity, the threshold is two interquartile ranges above the third quartile.</para>
		/// <para>Low—Outliers will be detected using low sensitivity. This option will detect the fewest outliers.</para>
		/// <para>Medium—Outliers will be detected using moderate sensitivity. This is the default.</para>
		/// <para>High—Outliers will be detected using high sensitivity. This option will detect the most outliers.</para>
		/// <para><see cref="SensitivityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Sensitivity { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Keep Only Spatial Outliers</para>
		/// <para>Specifies whether the output features will contain all input features or only features identified as spatial outliers.</para>
		/// <para>Checked—The output features will only contain features identified as spatial outliers.</para>
		/// <para>Unchecked—The output features will contain all input features. This is the default.</para>
		/// <para><see cref="KeepTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepType { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialOutlierDetection SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Outlier Type</para>
		/// </summary>
		public enum OutlierTypeEnum 
		{
			/// <summary>
			/// <para>Global—Global outliers of input points will be detected. This is the default.</para>
			/// </summary>
			[GPValue("GLOBAL")]
			[Description("Global")]
			Global,

			/// <summary>
			/// <para>Local—Local outliers of input points will be detected.</para>
			/// </summary>
			[GPValue("LOCAL")]
			[Description("Local")]
			Local,

		}

		/// <summary>
		/// <para>Detection Sensitivity</para>
		/// </summary>
		public enum SensitivityEnum 
		{
			/// <summary>
			/// <para>Low—Outliers will be detected using low sensitivity. This option will detect the fewest outliers.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low")]
			Low,

			/// <summary>
			/// <para>Medium—Outliers will be detected using moderate sensitivity. This is the default.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>High—Outliers will be detected using high sensitivity. This option will detect the most outliers.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

		}

		/// <summary>
		/// <para>Keep Only Spatial Outliers</para>
		/// </summary>
		public enum KeepTypeEnum 
		{
			/// <summary>
			/// <para>Checked—The output features will only contain features identified as spatial outliers.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_OUTLIER")]
			KEEP_OUTLIER,

			/// <summary>
			/// <para>Unchecked—The output features will contain all input features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

		}

#endregion
	}
}
