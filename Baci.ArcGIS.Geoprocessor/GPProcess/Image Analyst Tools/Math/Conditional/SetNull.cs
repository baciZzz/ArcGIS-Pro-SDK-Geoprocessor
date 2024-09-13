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
	/// <para>Set Null</para>
	/// <para>Set Null</para>
	/// <para>Set Null sets identified cell locations to NoData based on a specified criteria. It returns NoData if a conditional evaluation is true, and returns the value specified by another raster if it is false.</para>
	/// </summary>
	public class SetNull : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InConditionalRaster">
		/// <para>Input conditional raster</para>
		/// <para>Input raster representing the true or false result of the desired condition.</para>
		/// <para>It can be of integer or floating point type.</para>
		/// </param>
		/// <param name="InFalseRasterOrConstant">
		/// <para>Input false raster or constant value</para>
		/// <para>The input whose values will be used as the output cell values if the condition is false.</para>
		/// <para>It can be an integer or a floating point raster, or a constant value.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>If the conditional evaluation is true, NoData is returned. If false, the value of the second input raster is returned.</para>
		/// </param>
		public SetNull(object InConditionalRaster, object InFalseRasterOrConstant, object OutRaster)
		{
			this.InConditionalRaster = InConditionalRaster;
			this.InFalseRasterOrConstant = InFalseRasterOrConstant;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Null</para>
		/// </summary>
		public override string DisplayName() => "Set Null";

		/// <summary>
		/// <para>Tool Name : SetNull</para>
		/// </summary>
		public override string ToolName() => "SetNull";

		/// <summary>
		/// <para>Tool Excute Name : ia.SetNull</para>
		/// </summary>
		public override string ExcuteName() => "ia.SetNull";

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
		public override object[] Parameters() => new object[] { InConditionalRaster, InFalseRasterOrConstant, OutRaster, WhereClause! };

		/// <summary>
		/// <para>Input conditional raster</para>
		/// <para>Input raster representing the true or false result of the desired condition.</para>
		/// <para>It can be of integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InConditionalRaster { get; set; }

		/// <summary>
		/// <para>Input false raster or constant value</para>
		/// <para>The input whose values will be used as the output cell values if the condition is false.</para>
		/// <para>It can be an integer or a floating point raster, or a constant value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFalseRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>If the conditional evaluation is true, NoData is returned. If false, the value of the second input raster is returned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>A logical expression that determines which of the input cells are to be true or false.</para>
		/// <para>The Where clause follows the general form of an SQL expression. It can be entered directly, for example, VALUE &gt; 100, if you click the Edit SQL mode button . If in the Edit Clause Mode , you can begin constructing the expression by clicking on the Add Clause Mode button.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetNull SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
