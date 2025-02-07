using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Iso Cluster</para>
	/// <para>Iso Cluster</para>
	/// <para>Uses an isodata clustering algorithm to determine the characteristics of the natural groupings of cells in multidimensional attribute space and stores the results in an output ASCII signature file.</para>
	/// </summary>
	public class IsoCluster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </param>
		/// <param name="OutSignatureFile">
		/// <para>Output signature file</para>
		/// <para>The output signature file.</para>
		/// <para>A .gsg extension must be specified.</para>
		/// </param>
		/// <param name="NumberClasses">
		/// <para>Number of classes</para>
		/// <para>Number of classes into which to group the cells.</para>
		/// </param>
		public IsoCluster(object InRasterBands, object OutSignatureFile, object NumberClasses)
		{
			this.InRasterBands = InRasterBands;
			this.OutSignatureFile = OutSignatureFile;
			this.NumberClasses = NumberClasses;
		}

		/// <summary>
		/// <para>Tool Display Name : Iso Cluster</para>
		/// </summary>
		public override string DisplayName() => "Iso Cluster";

		/// <summary>
		/// <para>Tool Name : IsoCluster</para>
		/// </summary>
		public override string ToolName() => "IsoCluster";

		/// <summary>
		/// <para>Tool Excute Name : sa.IsoCluster</para>
		/// </summary>
		public override string ExcuteName() => "sa.IsoCluster";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, OutSignatureFile, NumberClasses, NumberIterations!, MinClassSize!, SampleInterval! };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>The output signature file.</para>
		/// <para>A .gsg extension must be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object OutSignatureFile { get; set; }

		/// <summary>
		/// <para>Number of classes</para>
		/// <para>Number of classes into which to group the cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		[High(Allow = true, Value = 32767)]
		public object NumberClasses { get; set; }

		/// <summary>
		/// <para>Number of iterations</para>
		/// <para>Number of iterations of the clustering process to run.</para>
		/// <para>The default is 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? NumberIterations { get; set; } = "20";

		/// <summary>
		/// <para>Minimum class size</para>
		/// <para>Minimum number of cells in a valid class.</para>
		/// <para>The default is 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? MinClassSize { get; set; } = "20";

		/// <summary>
		/// <para>Sample interval</para>
		/// <para>The interval to be used for sampling.</para>
		/// <para>The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? SampleInterval { get; set; } = "10";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IsoCluster SetEnviroment(object? cellSize = null, object? cellSizeProjectionMethod = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
