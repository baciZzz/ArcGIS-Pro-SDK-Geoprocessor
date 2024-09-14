using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Trace</para>
	/// <para>追踪</para>
	/// <para>可根据指定起点的连通性或可遍历性返回追踪网络中的所选要素。</para>
	/// </summary>
	public class Trace : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>将运行追踪的追踪网络。 在使用企业级地理数据库时，输入追踪网络必须来自要素服务；不支持来自数据库连接的追踪网络。</para>
		/// </param>
		public Trace(object InTraceNetwork)
		{
			this.InTraceNetwork = InTraceNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 追踪</para>
		/// </summary>
		public override string DisplayName() => "追踪";

		/// <summary>
		/// <para>Tool Name : 追踪</para>
		/// </summary>
		public override string ToolName() => "追踪";

		/// <summary>
		/// <para>Tool Excute Name : tn.Trace</para>
		/// </summary>
		public override string ExcuteName() => "tn.Trace";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, TraceType, StartingPoints, Barriers, PathDirection, ShortestPathNetworkAttributeName, IncludeBarriers, ValidateConsistency, IgnoreBarriersAtStartingPoints, AllowIndeterminateFlow, ConditionBarriers, FunctionBarriers, TraversabilityScope, Functions, OutputConditions, ResultTypes, SelectionType, ClearAllPreviousTraceResults, TraceName, AggregatedPoints, AggregatedLines, UpdatedTraceNetwork, OutNetworkLayer, UseTraceConfig, TraceConfigName };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>将运行追踪的追踪网络。 在使用企业级地理数据库时，输入追踪网络必须来自要素服务；不支持来自数据库连接的追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Trace Type</para>
		/// <para>指定要执行的追踪类型。</para>
		/// <para>已连接 - 将使用从一个或多个起点开始并沿着已连接要素向外跨越的已连接追踪。</para>
		/// <para>上溯追踪 - 将使用能够发现网络中某位置上游的要素的上溯追踪。 这种类型的追踪需要设置流向。</para>
		/// <para>下溯追踪 - 将使用能够发现网络中某位置下游的要素的下溯追踪。 这种类型的追踪需要设置流向。</para>
		/// <para>最短路径 - 将使用可查找网络中两个起点之间的最短路径（无论流向为何）的最短路径追踪。 遍历路径的成本取决于为最短路径网络属性名称参数设置的网络属性。</para>
		/// <para><see cref="TraceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TraceType { get; set; } = "CONNECTED";

		/// <summary>
		/// <para>Starting Points</para>
		/// <para>使用追踪位置窗格中的起点选项卡创建的要素图层，或包含一个或多个表示追踪起点的记录的表或要素类。 在使用追踪位置窗格中的起点工具创建起点时，默认情况下，将使用 TN_Temp_Starting_Points 要素类，并在工程的默认地理数据库中生成该要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object StartingPoints { get; set; } = "TN_Temp_Starting_Points";

		/// <summary>
		/// <para>Barriers</para>
		/// <para>包含一个或多个要素，表示防止追踪遍历超出此点的追踪障碍的表或要素类。 在使用追踪位置窗格中的障碍工具创建障碍时，默认情况下，将使用 TN_Temp_Barriers 要素类，并在工程的默认地理数据库中生成该要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object Barriers { get; set; } = "TN_Temp_Barriers";

		/// <summary>
		/// <para>Path Direction</para>
		/// <para>指定追踪路径的方向。 遍历路径的成本取决于最短路径网络属性名称参数值。 仅当运行最短路径追踪类型时，才会使用此参数。</para>
		/// <para>NO_DIRECTION—将使用两个起点之间的路径（无论流向为何）。 这是默认设置。</para>
		/// <para>PATH_UPSTREAM—将使用两个起点之间的上游路径。</para>
		/// <para>PATH_DOWNSTREAM—将使用两个起点之间的下游路径。</para>
		/// <para><see cref="PathDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PathDirection { get; set; } = "NO_DIRECTION";

		/// <summary>
		/// <para>Shortest Path Network Attribute Name</para>
		/// <para>用于计算路径的网络属性的名称。 运行最短路径追踪类型时，使用数字网络属性（例如形状长度）计算最短路径。 基于成本和距离的路径都可以进行计算。 运行最短路径追踪时，需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ShortestPathNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>指定追踪结果中是否包含可遍历性障碍要素。</para>
		/// <para>选中 - 追踪结果中将包含可遍历性障碍要素。 这是默认设置。</para>
		/// <para>未选中 - 追踪结果中将不包含可遍历性障碍要素。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Validate Consistency</para>
		/// <para>指定如果在任何遍历的要素中遇到脏区是否返回错误。 这是保证追踪通过网络中状态一致要素的唯一方法。 要移除脏区，请验证网络拓扑。</para>
		/// <para>选中 - 如果在任何遍历的要素中遇到脏区，追踪将返回错误。 这是默认设置。</para>
		/// <para>未选中 - 无论是否在遍历的要素中遇到脏区，追踪都将返回结果。</para>
		/// <para><see cref="ValidateConsistencyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ValidateConsistency { get; set; } = "true";

		/// <summary>
		/// <para>Ignore Barriers At Starting Points</para>
		/// <para>指定是否在追踪配置中忽略起点处的障碍。</para>
		/// <para>选中 - 追踪过程中将忽略起点处的障碍。</para>
		/// <para>未选中 - 追踪过程中不会忽略起点处的障碍。 这是默认设置。</para>
		/// <para><see cref="IgnoreBarriersAtStartingPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreBarriersAtStartingPoints { get; set; } = "false";

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// <para>指定是否追踪具有不确定或未初始化流向的要素。 此参数仅在运行上游追踪或下游追踪时使用。</para>
		/// <para>选中 - 将追踪具有不确定流向或未初始化流向的要素。</para>
		/// <para>未选中 - 不会追踪具有不确定流向或未初始化流向的要素。 这是默认设置。</para>
		/// <para><see cref="AllowIndeterminateFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllowIndeterminateFlow { get; set; } = "false";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>基于与网络属性的比较，对要素设置可遍历性障碍条件。 条件障碍使用网络属性、运算符和类型以及属性值。 例如，当要素的 Code 属性等于 ArtificialPath 的特定值时，将停止追踪。 当要素满足此条件时，追踪将停止。 如果您要使用多个属性，可使用组合使用参数来定义“和”或“或”条件。</para>
		/// <para>条件障碍组件如下：</para>
		/// <para>名称 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>类型 - 从在名称组件中指定的值中选择特定值或网络属性。</para>
		/// <para>值 - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>Combine using - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>运算符组件如下：</para>
		/// <para>等于 - 该属性等于该值。</para>
		/// <para>不等于 - 该属性不等于该值。</para>
		/// <para>大于 - 该属性大于该值。</para>
		/// <para>大于或等于 - 该属性大于或等于该值。</para>
		/// <para>小于 - 该属性小于该值。</para>
		/// <para>小于或等于 - 该属性小于或等于该值。</para>
		/// <para>类型组件如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// <para>组合使用组件如下：</para>
		/// <para>与 - 组合条件障碍。</para>
		/// <para>Or - 满足任一条件障碍时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>基于函数对要素设置可遍历性障碍。 函数障碍可用于执行以下操作：限制追踪距离起点的行程或设置停止追踪的最大值。 例如，所经过的每条线的长度和为目前经过的总距离。 当经过的总长度达到指定值时，追踪将停止。</para>
		/// <para>函数障碍组件如下：</para>
		/// <para>函数 - 从大量计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>值 - 提供将导致终止的输入属性类型（若发现）的特定值。</para>
		/// <para>使用局部值 - 计算每个方向的值，而不是整体全局值。 例如，对于计算形状长度总和的函数障碍，如果值大于或等于 4，则追踪终止。 在全局情况下，遍历两条值为 2 的边之后，形状长度总和即已达到 4，因此追踪会停止。 如果使用本地值，每条路径上的本地值会变化，且追踪将继续。</para>
		/// <para>函数组件如下：</para>
		/// <para>最小值 - 输入值的最小值。</para>
		/// <para>最大值 - 输入值的最大值。</para>
		/// <para>相加 - 输入值的总和。</para>
		/// <para>平均 - 输入值的平均值。</para>
		/// <para>计数 - 要素数。</para>
		/// <para>相减 - 输入值之间的差值。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用 Minimum 函数，则结果为 20；使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>运算符组件如下：</para>
		/// <para>等于 - 该属性等于该值。</para>
		/// <para>不等于 - 该属性不等于该值。</para>
		/// <para>大于 - 该属性大于该值。</para>
		/// <para>大于或等于 - 该属性大于或等于该值。</para>
		/// <para>小于 - 该属性小于该值。</para>
		/// <para>小于或等于 - 该属性小于或等于该值。</para>
		/// <para>使用局部值组件如下：</para>
		/// <para>选中 - 将使用局部值。</para>
		/// <para>未选中 - 将使用全局值。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>指定将应用的可遍历性类型。 可遍历性范围用于确定是否在交汇点和/或边处应用可遍历性。 例如，在游憩步道网络中，如果条件障碍定义为当 SurfaceType 属性包含值“gravel”并且可遍历性范围设置为仅交汇点时停止追踪，则即使遇到 Surfacetype 字段具有此值的边要素，追踪也不会停止，因为 Surfacetype 属性仅适用于边。</para>
		/// <para>交汇点和边—可遍历性将同时应用于交汇点和边。 这是默认设置。</para>
		/// <para>仅交汇点—可遍历性将仅应用于交汇点。</para>
		/// <para>仅边—可遍历性将仅应用于边。</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Functions</para>
		/// <para>将应用于追踪结果的计算函数。</para>
		/// <para>函数组件如下：</para>
		/// <para>函数 - 从大量计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>过滤器名称 - 按属性名称过滤函数结果。</para>
		/// <para>过滤器运算符 - 从大量运算符中进行选择。</para>
		/// <para>过滤器类型 - 从大量过滤类型中进行选择。</para>
		/// <para>过滤器值 - 提供输入过滤属性的特定值。</para>
		/// <para>函数组件选项如下：</para>
		/// <para>最小值 - 输入值的最小值</para>
		/// <para>最大值 - 输入值的最大值</para>
		/// <para>相加 - 输入值的总和。</para>
		/// <para>平均 - 输入值的平均值。</para>
		/// <para>计数 - 要素数。</para>
		/// <para>相减 - 输入值之间的差值。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用最小值函数，则结果为 20。 最大值为 30；相加为 50；平均为 25；计数为 2；相减为 -10。</para>
		/// <para>过滤器运算符组件选项如下：</para>
		/// <para>等于 - 该属性等于该值。</para>
		/// <para>不等于 - 该属性不等于该值。</para>
		/// <para>大于 - 该属性大于该值。</para>
		/// <para>大于或等于 - 该属性大于或等于该值。</para>
		/// <para>小于 - 该属性小于该值。</para>
		/// <para>小于或等于 - 该属性小于或等于该值。</para>
		/// <para>过滤器类型组件选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object Functions { get; set; }

		/// <summary>
		/// <para>Output Conditions</para>
		/// <para>根据网络属性返回的要素类型。 例如，如果将追踪配置为“过滤掉除水龙头要素外的所有要素”，那么未分配“水龙头”属性的追踪要素均不会包含在结果中。 任何追踪的要素都会返回到结果选择集中。</para>
		/// <para>输出条件组件如下：</para>
		/// <para>名称 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>类型 - 从在名称组件中指定的值中选择特定值或网络属性。</para>
		/// <para>值 - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>Combine using - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>运算符组件选项如下：</para>
		/// <para>等于 - 该属性等于该值。</para>
		/// <para>不等于 - 该属性不等于该值。</para>
		/// <para>大于 - 该属性大于该值。</para>
		/// <para>大于或等于 - 该属性大于或等于该值。</para>
		/// <para>小于 - 该属性小于该值。</para>
		/// <para>小于或等于 - 该属性小于或等于该值。</para>
		/// <para>类型组件选项包括：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object OutputConditions { get; set; }

		/// <summary>
		/// <para>Result Types</para>
		/// <para>指定追踪返回的结果的类型。</para>
		/// <para>选择—追踪结果将作为相应网络要素上的选择集返回。 这是默认设置。</para>
		/// <para>聚合几何—追踪结果按几何类型聚合，并存储在活动地图的图层中显示的要素类中。</para>
		/// <para>网络图层—追踪结果将被作为图层组内的选择集添加到要素图层。</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object ResultTypes { get; set; }

		/// <summary>
		/// <para>Selection Type</para>
		/// <para>指定如何应用所选内容以及如果已存在当前内容要执行的操作。</para>
		/// <para>新建选择内容—生成的选择内容将替换当前选择内容。 这是默认设置。</para>
		/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
		/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。 如果不存在选择内容，该选项不起作用。</para>
		/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
		/// <para>切换当前选择内容—生成的选择内容将被切换。 将所选的结果从当前选择内容中移除，同时将未选取的结果添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Clear All Previous Trace Results</para>
		/// <para>指定将内容从选定用来存储聚合几何的要素类中截断，还是追加到该要素类中。 此参数仅适用于聚合几何结果类型。</para>
		/// <para>选中 - 将截断用于存储聚合追踪几何的要素类。 将仅写入当前追踪操作的输出几何。 这是默认设置。</para>
		/// <para>未选中 - 当前追踪操作的输出几何将追加到用于存储聚合几何的要素类。</para>
		/// <para><see cref="ClearAllPreviousTraceResultsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object ClearAllPreviousTraceResults { get; set; } = "true";

		/// <summary>
		/// <para>Trace Name</para>
		/// <para>追踪操作的名称。 此值将存储在输出要素类的 TRACENAME 字段中，以协助识别追踪结果。 此参数仅适用于聚合几何结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object TraceName { get; set; }

		/// <summary>
		/// <para>Aggregated Points</para>
		/// <para>包含聚合结果几何的输出多点要素类。 默认情况下，将使用名为 Trace_Results_Aggregated_Points 的系统生成要素类填充该参数，该要素类将存储在工程的默认地理数据库中。</para>
		/// <para>如果该要素类不存在，则系统会自动创建。 也可以使用现有要素类存储聚合几何。 如果使用非默认要素类，则该要素类必须是多点要素类，并且包含名为 TRACENAME 的字符串字段。 此参数仅适用于聚合几何结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint")]
		[Category("Advanced Options")]
		public object AggregatedPoints { get; set; } = "Trace_Results_Aggregated_Points";

		/// <summary>
		/// <para>Aggregated Lines</para>
		/// <para>包含聚合结果几何的输出折线要素类。 默认情况下，将使用名为 Trace_Results_Aggregated_Lines 的系统生成要素类填充该参数，该要素类将存储在工程的默认地理数据库中。</para>
		/// <para>如果该要素类不存在，则系统会自动创建。 也可以使用现有要素类存储聚合几何。 如果使用非默认要素类，则该要素类必须是折线要素类，并且包含名为 TRACENAME 的字符串字段。 此参数仅适用于聚合几何结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Advanced Options")]
		public object AggregatedLines { get; set; } = "Trace_Results_Aggregated_Lines";

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object UpdatedTraceNetwork { get; set; }

		/// <summary>
		/// <para>Output Group Layer Name</para>
		/// <para>输出图层组的名称，其中包含具有由追踪返回的要素选择集的要素图层。 该图层将提供在 模型构建器 和 Python 中使用追踪输出的访问权限。</para>
		/// <para>此参数仅适用于网络图层结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGroupLayer()]
		[Category("Advanced Options")]
		public object OutNetworkLayer { get; set; }

		/// <summary>
		/// <para>Use Trace Configuration</para>
		/// <para>指定是否将使用现有指定追踪配置来填充追踪工具的参数。</para>
		/// <para>选中 - 将使用现有指定追踪配置来定义追踪的属性。 将忽略除追踪配置名称、起点和障碍之外的所有参数。</para>
		/// <para>未选中 - 不使用现有指定追踪配置来定义追踪的属性。 这是默认设置。</para>
		/// <para>此参数需要追踪网络版本 2 或更高版本。</para>
		/// <para><see cref="UseTraceConfigEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseTraceConfig { get; set; } = "false";

		/// <summary>
		/// <para>Trace Configuration Name</para>
		/// <para>将用于定义追踪属性的追踪配置的名称。 仅当选中使用追踪配置参数时，此参数才会处于活动状态。</para>
		/// <para>此参数需要追踪网络版本 2 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TraceConfigName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Trace Type</para>
		/// </summary>
		public enum TraceTypeEnum 
		{
			/// <summary>
			/// <para>已连接 - 将使用从一个或多个起点开始并沿着已连接要素向外跨越的已连接追踪。</para>
			/// </summary>
			[GPValue("CONNECTED")]
			[Description("已连接")]
			Connected,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("UPSTREAM")]
			[Description("上游")]
			Upstream,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DOWNSTREAM")]
			[Description("下游")]
			Downstream,

			/// <summary>
			/// <para>最短路径 - 将使用可查找网络中两个起点之间的最短路径（无论流向为何）的最短路径追踪。 遍历路径的成本取决于为最短路径网络属性名称参数设置的网络属性。</para>
			/// </summary>
			[GPValue("SHORTEST_PATH")]
			[Description("最短路径")]
			Shortest_path,

		}

		/// <summary>
		/// <para>Path Direction</para>
		/// </summary>
		public enum PathDirectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_DIRECTION")]
			[Description("无方向")]
			No_direction,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PATH_UPSTREAM")]
			[Description("上游路径")]
			Upstream_path,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PATH_DOWNSTREAM")]
			[Description("下游路径")]
			Downstream_path,

		}

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// </summary>
		public enum IncludeBarriersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_BARRIERS")]
			INCLUDE_BARRIERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_BARRIERS")]
			EXCLUDE_BARRIERS,

		}

		/// <summary>
		/// <para>Validate Consistency</para>
		/// </summary>
		public enum ValidateConsistencyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VALIDATE_CONSISTENCY")]
			VALIDATE_CONSISTENCY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_VALIDATE_CONSISTENCY")]
			DO_NOT_VALIDATE_CONSISTENCY,

		}

		/// <summary>
		/// <para>Ignore Barriers At Starting Points</para>
		/// </summary>
		public enum IgnoreBarriersAtStartingPointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_BARRIERS_AT_STARTING_POINTS")]
			IGNORE_BARRIERS_AT_STARTING_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_IGNORE_BARRIERS_AT_STARTING_POINTS")]
			DO_NOT_IGNORE_BARRIERS_AT_STARTING_POINTS,

		}

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// </summary>
		public enum AllowIndeterminateFlowEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACE_INDETERMINATE_FLOW")]
			TRACE_INDETERMINATE_FLOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_INDETERMINATE_FLOW")]
			IGNORE_INDETERMINATE_FLOW,

		}

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// </summary>
		public enum TraversabilityScopeEnum 
		{
			/// <summary>
			/// <para>交汇点和边—可遍历性将同时应用于交汇点和边。 这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>仅交汇点—可遍历性将仅应用于交汇点。</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边—可遍历性将仅应用于边。</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("仅边")]
			Edges_only,

		}

		/// <summary>
		/// <para>Result Types</para>
		/// </summary>
		public enum ResultTypesEnum 
		{
			/// <summary>
			/// <para>选择—追踪结果将作为相应网络要素上的选择集返回。 这是默认设置。</para>
			/// </summary>
			[GPValue("SELECTION")]
			[Description("选择")]
			Selection,

			/// <summary>
			/// <para>聚合几何—追踪结果按几何类型聚合，并存储在活动地图的图层中显示的要素类中。</para>
			/// </summary>
			[GPValue("AGGREGATED_GEOMETRY")]
			[Description("聚合几何")]
			Aggregated_Geometry,

			/// <summary>
			/// <para>网络图层—追踪结果将被作为图层组内的选择集添加到要素图层。</para>
			/// </summary>
			[GPValue("NETWORK_LAYERS")]
			[Description("网络图层")]
			Network_Layers,

		}

		/// <summary>
		/// <para>Selection Type</para>
		/// </summary>
		public enum SelectionTypeEnum 
		{
			/// <summary>
			/// <para>新建选择内容—生成的选择内容将替换当前选择内容。 这是默认设置。</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("新建选择内容")]
			New_selection,

			/// <summary>
			/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("添加到当前选择内容")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。 如果不存在选择内容，该选项不起作用。</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("从当前选择内容中移除")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("选择当前选择内容的子集")]
			Select_subset_from_the_current_selection,

			/// <summary>
			/// <para>切换当前选择内容—生成的选择内容将被切换。 将所选的结果从当前选择内容中移除，同时将未选取的结果添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
			/// </summary>
			[GPValue("SWITCH_SELECTION")]
			[Description("切换当前选择内容")]
			Switch_the_current_selection,

		}

		/// <summary>
		/// <para>Clear All Previous Trace Results</para>
		/// </summary>
		public enum ClearAllPreviousTraceResultsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_ALL_PREVIOUS_TRACE_RESULTS")]
			CLEAR_ALL_PREVIOUS_TRACE_RESULTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR_ALL_PREVIOUS_TRACE_RESULTS")]
			DO_NOT_CLEAR_ALL_PREVIOUS_TRACE_RESULTS,

		}

		/// <summary>
		/// <para>Use Trace Configuration</para>
		/// </summary>
		public enum UseTraceConfigEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_TRACE_CONFIGURATION")]
			USE_TRACE_CONFIGURATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_TRACE_CONFIGURATION")]
			DO_NOT_USE_TRACE_CONFIGURATION,

		}

#endregion
	}
}
