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
	/// <para>Con</para>
	/// <para>Performs a conditional if/else evaluation on each of the input cells of an input raster.</para>
	/// </summary>
	public class Con : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InConditionalRaster">
		/// <para>Input conditional raster</para>
		/// <para>Input raster representing the true or false result of the desired condition.</para>
		/// <para>It can be of integer or floating point type.</para>
		/// </param>
		/// <param name="InTrueRasterOrConstant">
		/// <para>Input true raster or constant value</para>
		/// <para>The input whose values will be used as the output cell values if the condition is true.</para>
		/// <para>It can be an integer or a floating point raster, or a constant value.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// </param>
		public Con(object InConditionalRaster, object InTrueRasterOrConstant, object OutRaster)
		{
			this.InConditionalRaster = InConditionalRaster;
			this.InTrueRasterOrConstant = InTrueRasterOrConstant;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Con</para>
		/// </summary>
		public override string DisplayName() => "Con";

		/// <summary>
		/// <para>Tool Name : Con</para>
		/// </summary>
		public override string ToolName() => "Con";

		/// <summary>
		/// <para>Tool Excute Name : ia.Con</para>
		/// </summary>
		public override string ExcuteName() => "ia.Con";

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
		public override object[] Parameters() => new object[] { InConditionalRaster, InTrueRasterOrConstant, OutRaster, InFalseRasterOrConstant, WhereClause };

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
		/// <para>Input true raster or constant value</para>
		/// <para>The input whose values will be used as the output cell values if the condition is true.</para>
		/// <para>It can be an integer or a floating point raster, or a constant value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InTrueRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Input false raster or constant value</para>
		/// <para>The input whose values will be used as the output cell values if the condition is false.</para>
		/// <para>It can be an integer or a floating point raster, or a constant value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFalseRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>A logical expression that determines which of the input cells are to be true or false.</para>
		/// <para>The Where clause follows the general form of an SQL expression. It can be entered directly, for example, VALUE &gt; 100, if you click the Edit SQL mode button . If in the Edit Clause Mode , you can begin constructing the expression by clicking on the Add Clause Mode button.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Con SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
