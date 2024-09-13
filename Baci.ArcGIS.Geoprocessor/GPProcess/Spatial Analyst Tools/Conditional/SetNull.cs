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
	/// <para>Set Null</para>
	/// <para>设为空函数</para>
	/// <para>“设为空函数”根据指定条件将所识别的像元位置设置为 NoData。如果条件评估为真，则返回 NoData；如果条件评估为假，则返回由另一个栅格指定的值。</para>
	/// </summary>
	public class SetNull : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InConditionalRaster">
		/// <para>Input conditional raster</para>
		/// <para>表示所需条件结果为真或假的输入栅格。</para>
		/// <para>可以是整型或浮点型。</para>
		/// </param>
		/// <param name="InFalseRasterOrConstant">
		/// <para>Input false raster or constant value</para>
		/// <para>条件为假时，其值作为输出像元值的输入。</para>
		/// <para>可为整型或浮点型栅格，或为常数值。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>如果条件评估为真，则返回 NoData。 如果为假，则将返回第二个输入栅格的值。</para>
		/// </param>
		public SetNull(object InConditionalRaster, object InFalseRasterOrConstant, object OutRaster)
		{
			this.InConditionalRaster = InConditionalRaster;
			this.InFalseRasterOrConstant = InFalseRasterOrConstant;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 设为空函数</para>
		/// </summary>
		public override string DisplayName() => "设为空函数";

		/// <summary>
		/// <para>Tool Name : SetNull</para>
		/// </summary>
		public override string ToolName() => "SetNull";

		/// <summary>
		/// <para>Tool Excute Name : sa.SetNull</para>
		/// </summary>
		public override string ExcuteName() => "sa.SetNull";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InConditionalRaster, InFalseRasterOrConstant, OutRaster, WhereClause };

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
		/// <para>Input false raster or constant value</para>
		/// <para>条件为假时，其值作为输出像元值的输入。</para>
		/// <para>可为整型或浮点型栅格，或为常数值。</para>
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
		/// <para>输出栅格。</para>
		/// <para>如果条件评估为真，则返回 NoData。 如果为假，则将返回第二个输入栅格的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

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
		public SetNull SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
