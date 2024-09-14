using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Boolean XOr</para>
	/// <para>Boolean XOr</para>
	/// <para>Performs a Boolean eXclusive Or operation on the cell values of two input rasters.</para>
	/// </summary>
	public class BooleanXOr : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterOrConstant1">
		/// <para>Input raster or constant value 1</para>
		/// <para>The first input to use in this Boolean operation.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="InRasterOrConstant2">
		/// <para>Input raster or constant value 2</para>
		/// <para>The second input to use in this Boolean operation.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output cell values will be either 0 or 1.</para>
		/// </param>
		public BooleanXOr(object InRasterOrConstant1, object InRasterOrConstant2, object OutRaster)
		{
			this.InRasterOrConstant1 = InRasterOrConstant1;
			this.InRasterOrConstant2 = InRasterOrConstant2;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Boolean XOr</para>
		/// </summary>
		public override string DisplayName() => "Boolean XOr";

		/// <summary>
		/// <para>Tool Name : BooleanXOr</para>
		/// </summary>
		public override string ToolName() => "BooleanXOr";

		/// <summary>
		/// <para>Tool Excute Name : ia.BooleanXOr</para>
		/// </summary>
		public override string ExcuteName() => "ia.BooleanXOr";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterOrConstant1, InRasterOrConstant2, OutRaster };

		/// <summary>
		/// <para>Input raster or constant value 1</para>
		/// <para>The first input to use in this Boolean operation.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstant1 { get; set; }

		/// <summary>
		/// <para>Input raster or constant value 2</para>
		/// <para>The second input to use in this Boolean operation.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstant2 { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output cell values will be either 0 or 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BooleanXOr SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
