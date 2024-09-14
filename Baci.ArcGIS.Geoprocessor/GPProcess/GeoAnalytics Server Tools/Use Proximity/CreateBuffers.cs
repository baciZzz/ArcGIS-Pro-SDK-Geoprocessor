using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Create Buffers</para>
	/// <para>创建缓冲区</para>
	/// <para>在输入要素周围某一指定距离内创建缓冲区。</para>
	/// </summary>
	public class CreateBuffers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>要进行缓冲的点、折线或面要素。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>指定将用于创建缓冲区的方法。</para>
		/// <para>测地线— 无论使用哪种输入坐标系，均使用形状不变的测地线缓冲区方法创建缓冲区。这是默认设置。</para>
		/// <para>平面— 如果输入要素位于投影坐标系中，则将创建欧氏缓冲区。如果输入要素位于地理坐标系中，则将创建测地线缓冲区。“输出坐标系”的环境设置可用于指定坐标系。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="BufferType">
		/// <para>Buffer Type</para>
		/// <para>指定缓冲距离将如何定义。</para>
		/// <para>距离—为所有要素应用相同的线性距离。</para>
		/// <para>字段—选择数字或字符串字段表示缓冲距离。</para>
		/// <para>表达式—构建使用字段、常量和数学运算的方程来表示缓冲距离。</para>
		/// <para><see cref="BufferTypeEnum"/></para>
		/// </param>
		public CreateBuffers(object InputLayer, object OutputName, object Method, object BufferType)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.Method = Method;
			this.BufferType = BufferType;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建缓冲区</para>
		/// </summary>
		public override string DisplayName() => "创建缓冲区";

		/// <summary>
		/// <para>Tool Name : CreateBuffers</para>
		/// </summary>
		public override string ToolName() => "CreateBuffers";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CreateBuffers</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.CreateBuffers";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputName, Method, BufferType, BufferField, BufferDistance, BufferExpression, DissolveOption, DissolveFields, SummaryFields, Multipart, Output, DataStore };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要进行缓冲的点、折线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定将用于创建缓冲区的方法。</para>
		/// <para>测地线— 无论使用哪种输入坐标系，均使用形状不变的测地线缓冲区方法创建缓冲区。这是默认设置。</para>
		/// <para>平面— 如果输入要素位于投影坐标系中，则将创建欧氏缓冲区。如果输入要素位于地理坐标系中，则将创建测地线缓冲区。“输出坐标系”的环境设置可用于指定坐标系。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Buffer Type</para>
		/// <para>指定缓冲距离将如何定义。</para>
		/// <para>距离—为所有要素应用相同的线性距离。</para>
		/// <para>字段—选择数字或字符串字段表示缓冲距离。</para>
		/// <para>表达式—构建使用字段、常量和数学运算的方程来表示缓冲距离。</para>
		/// <para><see cref="BufferTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferType { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Buffer Field</para>
		/// <para>包含每个要素缓冲距离的字段。如果字段值为数字，则假定距离使用输入图层空间参考的线性单位，除非该输入图层使用地理坐标系，这时该值以米为单位。如果在字段值中指定的线性单位无效或无法识别，则默认情况下将使用输入要素空间参考的线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object BufferField { get; set; }

		/// <summary>
		/// <para>Buffer Distance</para>
		/// <para>与要缓冲的输入要素之间的距离。距离可以米、千米、英尺、码、英里或海里为单位表示。</para>
		/// <para><see cref="BufferDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object BufferDistance { get; set; }

		/// <summary>
		/// <para>Buffer Expression</para>
		/// <para>将用作每个要素的缓冲区的使用字段和数学运算符的方程。字段必须为数字形式，并且表达式可以包含 [+ - * / ] 运算符和多个字段。除非另行指定，否则计算后的值以米为单位。例如，应用将名为 distance 的数值字段（以千米为单位）乘以 2，然后加上 15 米所得到的缓冲区。</para>
		/// <para>ArcGIS Enterprise 10.5 和 10.5.1 的表达式将格式化为 as_kilometers(distance) * 2 + as_meters(15)。对于 ArcGIS Enterprise 10.6 或更高版本，请使用 Arcade 表达式，例如 as_kilometers($feature[&quot;distance&quot;]) * 2 + as_meters(15)。</para>
		/// <para>&lt;para/&gt;</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object BufferExpression { get; set; }

		/// <summary>
		/// <para>Dissolve Option</para>
		/// <para>指定将用于移除缓冲区重叠的融合选项。</para>
		/// <para>无—不考虑重叠，将保持每个要素的独立缓冲区。这是默认设置。</para>
		/// <para>所有—将所有缓冲区融合为单个要素，从而移除所有重叠。</para>
		/// <para>列表—将融合共享所列字段（传递自输入要素）属性值的所有缓冲区。</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DissolveOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Dissolve Fields</para>
		/// <para>融合输出缓冲区所依据的输入要素的一个或多个字段列表。将融合在所列字段中共享属性值的所有缓冲区。仅当融合选项为列表时，才需要此选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object DissolveFields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>指定可应用于数值型和字符串型字段的统计数据。如果留空，则只计算计数。仅当融合选项为列表或全部时才会应用这些统计数据。</para>
		/// <para>计数 - 非空值的数目。可用于数值字段或字符串。[null, 0, 2] 的计数为 2。</para>
		/// <para>总和 - 字段内数值的总和。[null, null, 3] 的总和为 3。</para>
		/// <para>平均值 - 数值的平均值。[0, 2, null] 的平均值为 1。</para>
		/// <para>最小值 - 数值字段的最小值。[0, 2, null] 的最小值为 0。</para>
		/// <para>最大值 - 数值字段的最大值。[0, 2, null] 的最大值为 2。</para>
		/// <para>标准差 - 数值字段的标准差。[1] 的标准差为 null。[null, 1,1,1] 的标准差为 null。</para>
		/// <para>方差 - 轨迹中数值字段内数值的方差。[1] 的方差为 null。[null, 1, 1, 1] 的方差为 null。</para>
		/// <para>范围 - 数值字段的范围。其计算方法为最大值减去最小值。[0, null, 1] 的范围为 1。[null, 4] 的范围为 0。</para>
		/// <para>任何 - 字符串型字段中的示例字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Multipart</para>
		/// <para>指定是否将创建多部件要素。</para>
		/// <para>选中 - 创建输出多部件要素（适当时）。</para>
		/// <para>未选中 - 将为各部分创建单独的要素，而不是创建多部件要素。这是默认设置。</para>
		/// <para><see cref="MultipartEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Multipart { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateBuffers SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>平面— 如果输入要素位于投影坐标系中，则将创建欧氏缓冲区。如果输入要素位于地理坐标系中，则将创建测地线缓冲区。“输出坐标系”的环境设置可用于指定坐标系。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线— 无论使用哪种输入坐标系，均使用形状不变的测地线缓冲区方法创建缓冲区。这是默认设置。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

		/// <summary>
		/// <para>Buffer Type</para>
		/// </summary>
		public enum BufferTypeEnum 
		{
			/// <summary>
			/// <para>距离—为所有要素应用相同的线性距离。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离")]
			Distance,

			/// <summary>
			/// <para>字段—选择数字或字符串字段表示缓冲距离。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

			/// <summary>
			/// <para>表达式—构建使用字段、常量和数学运算的方程来表示缓冲距离。</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("表达式")]
			Expression,

		}

		/// <summary>
		/// <para>Buffer Distance</para>
		/// </summary>
		public enum BufferDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

		/// <summary>
		/// <para>Dissolve Option</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>无—不考虑重叠，将保持每个要素的独立缓冲区。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>所有—将所有缓冲区融合为单个要素，从而移除所有重叠。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>列表—将融合共享所列字段（传递自输入要素）属性值的所有缓冲区。</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("列表")]
			List,

		}

		/// <summary>
		/// <para>Multipart</para>
		/// </summary>
		public enum MultipartEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_PART")]
			MULTI_PART,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_PART")]
			SINGLE_PART,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

#endregion
	}
}
