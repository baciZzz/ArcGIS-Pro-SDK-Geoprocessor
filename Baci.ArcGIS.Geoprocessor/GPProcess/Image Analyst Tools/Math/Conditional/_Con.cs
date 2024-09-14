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
	/// <para>条件函数</para>
	/// <para>针对输入栅格的每个输入像元执行 if/else 条件评估。</para>
	/// </summary>
	public class Con : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InConditionalRaster">
		/// <para>Input conditional raster</para>
		/// <para>表示所需条件结果为真或假的输入栅格。</para>
		/// <para>可以是整型或浮点型。</para>
		/// </param>
		/// <param name="InTrueRasterOrConstant">
		/// <para>Input true raster or constant value</para>
		/// <para>条件为真时，其值作为输出像元值的输入。</para>
		/// <para>可为整型或浮点型栅格，或为常数值。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// </param>
		public Con(object InConditionalRaster, object InTrueRasterOrConstant, object OutRaster)
		{
			this.InConditionalRaster = InConditionalRaster;
			this.InTrueRasterOrConstant = InTrueRasterOrConstant;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 条件函数</para>
		/// </summary>
		public override string DisplayName() => "条件函数";

		/// <summary>
		/// <para>Tool Name : 条件函数</para>
		/// </summary>
		public override string ToolName() => "条件函数";

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
		/// <para>表示所需条件结果为真或假的输入栅格。</para>
		/// <para>可以是整型或浮点型。</para>
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
		/// <para>条件为真时，其值作为输出像元值的输入。</para>
		/// <para>可为整型或浮点型栅格，或为常数值。</para>
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
		/// <para>输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Input false raster or constant value</para>
		/// <para>条件为假时，其值作为输出像元值的输入。</para>
		/// <para>可为整型或浮点型栅格，或为常数值。</para>
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
		/// <para>决定输入像元为真或假的逻辑表达式。</para>
		/// <para>Where 子句遵循 SQL 表达式的一般格式。 如果您单击编辑 SQL 模式按钮 ，则可以直接输入，例如 VALUE &gt; 100。 如果处于编辑子句模式 中，则可以通过单击添加子句模式按钮来开始构建表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Con SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
