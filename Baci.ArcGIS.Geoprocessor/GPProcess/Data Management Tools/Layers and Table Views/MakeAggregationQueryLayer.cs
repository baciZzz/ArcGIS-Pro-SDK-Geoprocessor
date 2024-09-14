using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Make Aggregation Query Layer</para>
	/// <para>创建聚合查询图层</para>
	/// <para>创建一个查询图层，该图层根据相关表的时间、范围和属性查询动态地汇总、聚合和过滤 DBMS 表，并将结果连接到要素图层。</para>
	/// </summary>
	public class MakeAggregationQueryLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetFeatureClass">
		/// <para>Target Feature Class</para>
		/// <para>来自企业级地理数据库的要素类或空间表。</para>
		/// </param>
		/// <param name="TargetJoinField">
		/// <para>Target Join Field</para>
		/// <para>连接所依据的目标要素类中的字段。</para>
		/// </param>
		/// <param name="RelatedTable">
		/// <para>Related Table</para>
		/// <para>包含用于计算统计数据的字段的输入表。 统计数据连接到输出图层值。</para>
		/// </param>
		/// <param name="RelatedJoinField">
		/// <para>Related Join Field</para>
		/// <para>汇总表中的字段，其中包含连接所依据的值。 还会根据此字段单独为每个唯一属性值计算聚合或汇总统计数据。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>将要创建的查询图层的输出名称。</para>
		/// </param>
		public MakeAggregationQueryLayer(object TargetFeatureClass, object TargetJoinField, object RelatedTable, object RelatedJoinField, object OutLayer)
		{
			this.TargetFeatureClass = TargetFeatureClass;
			this.TargetJoinField = TargetJoinField;
			this.RelatedTable = RelatedTable;
			this.RelatedJoinField = RelatedJoinField;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建聚合查询图层</para>
		/// </summary>
		public override string DisplayName() => "创建聚合查询图层";

		/// <summary>
		/// <para>Tool Name : MakeAggregationQueryLayer</para>
		/// </summary>
		public override string ToolName() => "MakeAggregationQueryLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeAggregationQueryLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeAggregationQueryLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetFeatureClass, TargetJoinField, RelatedTable, RelatedJoinField, OutLayer, Statistics, ParameterDefinitions, OidFields, ShapeType, Srid, SpatialReference, MValues, ZValues, Extent };

		/// <summary>
		/// <para>Target Feature Class</para>
		/// <para>来自企业级地理数据库的要素类或空间表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object TargetFeatureClass { get; set; }

		/// <summary>
		/// <para>Target Join Field</para>
		/// <para>连接所依据的目标要素类中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "OID", "Date", "GUID")]
		public object TargetJoinField { get; set; }

		/// <summary>
		/// <para>Related Table</para>
		/// <para>包含用于计算统计数据的字段的输入表。 统计数据连接到输出图层值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object RelatedTable { get; set; }

		/// <summary>
		/// <para>Related Join Field</para>
		/// <para>汇总表中的字段，其中包含连接所依据的值。 还会根据此字段单独为每个唯一属性值计算聚合或汇总统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "OID", "Date", "GUID")]
		public object RelatedJoinField { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>将要创建的查询图层的输出名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Summary Field(s)</para>
		/// <para>指定包含用于计算指定统计数据的属性值的一个或多个数值字段。 可以指定多项统计和字段组合。 空值将被排除在所有统计计算之外。</para>
		/// <para>输出图层将包括一个 ROW_COUNT 字段，显示相关连接字段值的每个唯一值的总数（或频数）。 ROW_COUNT 字段和计数统计类型的区别在于 ROW_COUNT 包括空值，而计数不包括空值。</para>
		/// <para>可用统计类型如下：</para>
		/// <para>计数 - 将查找统计计算中包括的值的数目。 计数包括除空值外的所有值。</para>
		/// <para>总和 - 将指定字段的值相加在一起。</para>
		/// <para>平均值 - 将计算指定字段的平均值。</para>
		/// <para>最小值 - 将查找指定字段所有记录的最小值。</para>
		/// <para>最大值 - 将查找指定字段所有记录的最大值。</para>
		/// <para>标准差 - 将计算指定字段中值的标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Statistics { get; set; }

		/// <summary>
		/// <para>Parameter Definitions</para>
		/// <para>为标准或条件指定一个或多个查询参数，并在计算聚合结果时使用与这些条件相匹配的记录。 查询参数类似于 SQL 语句的变量，进行查询时即会定义该变量的值。 这样，您便可以动态地更改输出图层的查询过滤器。 您可以将参数视为 SQL where 子句中的谓词或条件。 例如，Country_Name = &apos;Nigeria&apos; 在 SQL where 子句中称为谓词，其中 = 是比较运算符，Country_Name 是左侧的字段名称，&apos;Nigeria&apos; 是右侧的值。 当您定义多个参数时，必须在这些参数之间指定一个逻辑运算符（如 AND、OR 等）。</para>
		/// <para>如果未进行指定，则相关表中的所有记录都将用于计算聚合或汇总结果。</para>
		/// <para>两种参数定义类型如下所示：</para>
		/// <para>范围 - 可将数值或时态值动态连接至范围和时间滑块。</para>
		/// <para>离散 - 可在进行查询时更新具有文本值的查询。</para>
		/// <para>以下属性可用：</para>
		/// <para>参数类型 - 参数类型可以是范围或离散。</para>
		/// <para>名称 - 参数的名称，与变量名称类似。 名称不能包含空格或特殊字符。 创建输出查询图层并选中图层源 SQL 语句后，在定义输出查询图层源的 SQL 语句中，这个名称将以 ::r:（对于范围参数）或 ::（对于离散参数）为前缀。</para>
		/// <para>别名 - 参数名称的别名。 别名可以包括空格和特殊字符。</para>
		/// <para>字段或表达式 - 字段名称或有效的 SQL 表达式，可用于 where 子句中谓词或条件的左侧。</para>
		/// <para>数据类型 - 字段或表达式列中指定的字段或表达式的数据类型。 当参数类型的值为范围时，数据类型列的值不得为字符串。</para>
		/// <para>日期 - 字段或表达式的数据类型将是日期（日期时间）。</para>
		/// <para>字符串 - 字段或表达式的数据类型将是字符串（文本）。</para>
		/// <para>整型 - 字段或表达式的数据类型将是整型（整数）。</para>
		/// <para>双精度 - 字段或表达式的数据类型将是双精度（小数）。</para>
		/// <para>起始值 - 范围列的默认起始值。 未启用时间或范围滑块时将使用此值。 当忽略起始值和结束值列的值并禁用时间或范围滑块时，相关表中的记录将用于计算聚合结果。 当参数类型列设置为离散时，将忽略此值。</para>
		/// <para>结束值 - 范围参数的默认结束值。 未启用时间或范围滑块时将使用此值。 当忽略起始值和结束值列的值并禁用时间或范围滑块时，相关表中的记录将用于计算聚合结果。 当参数类型列设置为离散时，将忽略此值。</para>
		/// <para>离散参数运算符 - 将在字段或表达式列的值和 SQL 谓词或条件中的值之间使用的比较运算符。</para>
		/// <para>无 - 当参数类型设置为范围时，选择无。</para>
		/// <para>等于 - 比较字段或表达式是否与值相等。</para>
		/// <para>不等于 - 测试字段或表达式是否与值不相等。</para>
		/// <para>大于 - 测试字段或表达式是否大于值。</para>
		/// <para>小于 - 测试字段或表达式是否小于值。</para>
		/// <para>包括值 - 确定来自字段或表达式的值是否与列表中的某个值匹配。</para>
		/// <para>默认离散值 - 当参数类型值为离散时，您必须提供默认值。 当离散参数运算符为包括值时，您可以提供以逗号分隔的多个值，例如 VANDALISM,BURGLARY/THEFT。</para>
		/// <para>下一个参数的运算符 - 此运算符和下一个运算符之间的逻辑运算符。 本列仅适用于具有多个参数定义的情况。</para>
		/// <para>无 - 当没有更多参数时，选择无。</para>
		/// <para>和 - 结合两个条件，如果两个条件都为 true 则选择记录。</para>
		/// <para>或 - 结合两个条件，如果两个条件中至少有一个为 true 则选择记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ParameterDefinitions { get; set; }

		/// <summary>
		/// <para>Unique Identifier Field(s)</para>
		/// <para>唯一标识符字段将用于唯一标识表中各行的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object OidFields { get; set; }

		/// <summary>
		/// <para>Shape Type</para>
		/// <para>指定查询图层的形状类型。 在输出查询图层中只会使用查询结果集中与指定形状类型匹配的那些记录。 默认情况下，将使用结果集中第一条记录的 shape 类型。 如果查询结果集未返回几何字段，则忽略此参数。</para>
		/// <para>点—输出查询图层将使用点几何。</para>
		/// <para>多点—输出查询图层将使用多点几何。</para>
		/// <para>面—输出查询图层将使用面几何。</para>
		/// <para>折线—输出查询图层将使用折线几何。</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeType { get; set; }

		/// <summary>
		/// <para>Spatial Reference ID (SRID)</para>
		/// <para>返回几何查询的空间参考标识符 (SRID) 值。 在输出查询图层中只会使用查询结果集中与指定 SRID 值匹配的那些记录。 默认情况下，将使用结果集中第一条记录的 SRID 值。 如果查询结果集未返回几何字段，则忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Srid { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出查询图层将使用的坐标系。 默认情况下，将使用结果集中第一条记录的空间参考。 如果查询结果集未返回几何字段，则忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// <para>指定输出图层是否包括线性测量（m 值）。</para>
		/// <para>选中 - 图层将包括 m 值。</para>
		/// <para>未选中 - 图层将不包括 m 值。 这是默认设置。</para>
		/// <para><see cref="MValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MValues { get; set; } = "false";

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// <para>指定输出图层是否将包括高程值（z 值）。</para>
		/// <para>选中 - 图层将包括 z 值。</para>
		/// <para>未选中 - 图层将不包括 z 值。 这是默认设置。</para>
		/// <para><see cref="ZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ZValues { get; set; } = "false";

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定图层范围。 范围必须包括表中的所有要素。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; } = "0 0 0 0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeAggregationQueryLayer SetEnviroment(object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape Type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>点—输出查询图层将使用点几何。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>多点—输出查询图层将使用多点几何。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>面—输出查询图层将使用面几何。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>折线—输出查询图层将使用折线几何。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

		}

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// </summary>
		public enum MValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_M_VALUES")]
			INCLUDE_M_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_M_VALUES")]
			DO_NOT_INCLUDE_M_VALUES,

		}

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// </summary>
		public enum ZValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_Z_VALUES")]
			INCLUDE_Z_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_Z_VALUES")]
			DO_NOT_INCLUDE_Z_VALUES,

		}

#endregion
	}
}
