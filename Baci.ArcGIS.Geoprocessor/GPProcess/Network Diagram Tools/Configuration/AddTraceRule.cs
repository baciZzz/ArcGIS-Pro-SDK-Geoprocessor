using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Add Trace Rule</para>
	/// <para>添加追踪规则</para>
	/// <para>添加逻辑示意图规则，以在基于现有模板构建逻辑示意图的过程中于公共设施网络或追踪网络上自动执行追踪。 由此产生的追踪网络要素和网络对象将用于构建逻辑示意图的内容。</para>
	/// </summary>
	public class AddTraceRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板名称</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。 这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="TraceType">
		/// <para>Trace Type</para>
		/// <para>请指定规则为了构建逻辑示意图内容将执行的追踪类型。</para>
		/// <para>已连接—当规则开始并沿连接元素向外跨越时，将通过逻辑示意图中当前表示的公共设施网络或追踪网络元素来执行连接追踪。 这是默认设置。</para>
		/// <para>子网—当规则开始并沿连接元素向外跨越时，将通过逻辑示意图中当前表示的公共设施网络元素来执行子网追踪，以查找沿相关子网向外跨越的源或汇。</para>
		/// <para>上游—当规则开始时，将通过逻辑示意图中当前表示的公共设施网络或追踪网络元素来执行上溯追踪以查找上游要素。</para>
		/// <para>下游—当规则开始时，将通过逻辑示意图中当前表示的公共设施网络或追踪网络元素来执行下溯追踪以查找下游元素。</para>
		/// <para>最短路径—当规则开始沿起点之间的最短路径查找要素时，系统将从逻辑示意图中当前指定为起点的公共设施网络或追踪网络要素执行最短路径追踪。 遍历路径的成本取决于为最短路径网络属性名称参数值设置的网络属性，而与流向无关。</para>
		/// </param>
		public AddTraceRule(object InUtilityNetwork, object TemplateName, object IsActive, object TraceType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.TraceType = TraceType;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加追踪规则</para>
		/// </summary>
		public override string DisplayName() => "添加追踪规则";

		/// <summary>
		/// <para>Tool Name : AddTraceRule</para>
		/// </summary>
		public override string ToolName() => "AddTraceRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddTraceRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddTraceRule";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, TraceType, DomainNetwork!, Tier!, TargetTier!, IncludeStructures!, IncludeBarriers!, ConditionBarriers!, FunctionBarriers!, TraversabilityScope!, FilterBarriers!, FilterFunctionBarriers!, FilterScope!, FilterBitsetNetworkAttributeName!, FilterNearest!, NearestCount!, NearestCostNetworkAttribute!, NearestCategories!, NearestAssets!, Propagators!, Description!, OutUtilityNetwork!, OutTemplateName!, AllowIndeterminateFlow!, PathDirection!, PathNetworkWeightName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板名称</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。 这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Trace Type</para>
		/// <para>请指定规则为了构建逻辑示意图内容将执行的追踪类型。</para>
		/// <para>已连接—当规则开始并沿连接元素向外跨越时，将通过逻辑示意图中当前表示的公共设施网络或追踪网络元素来执行连接追踪。 这是默认设置。</para>
		/// <para>子网—当规则开始并沿连接元素向外跨越时，将通过逻辑示意图中当前表示的公共设施网络元素来执行子网追踪，以查找沿相关子网向外跨越的源或汇。</para>
		/// <para>上游—当规则开始时，将通过逻辑示意图中当前表示的公共设施网络或追踪网络元素来执行上溯追踪以查找上游要素。</para>
		/// <para>下游—当规则开始时，将通过逻辑示意图中当前表示的公共设施网络或追踪网络元素来执行下溯追踪以查找下游元素。</para>
		/// <para>最短路径—当规则开始沿起点之间的最短路径查找要素时，系统将从逻辑示意图中当前指定为起点的公共设施网络或追踪网络要素执行最短路径追踪。 遍历路径的成本取决于为最短路径网络属性名称参数值设置的网络属性，而与流向无关。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TraceType { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>针对公共设施网络运行追踪的域网络名称。 运行子网、上游和下游追踪类型时，需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// <para>针对公共设施网络开始追踪的层名称。 运行已连接追踪类型时可以使用此参数；运行子网、上游和下游追踪类型时必须使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tier { get; set; }

		/// <summary>
		/// <para>Target Tier</para>
		/// <para>公共设施网络输入层流向的目标层名称。 如果上溯和下溯追踪的此参数丢失，当到达起始子网边界时，上述追踪将停止。 该参数可以使此类追踪在层级结构中继续向上或向下延伸。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TargetTier { get; set; }

		/// <summary>
		/// <para>Include Structures</para>
		/// <para>指定追踪结果中是否包含结构要素和对象。</para>
		/// <para>选中 - 追踪结果中将包含结构要素和对象。</para>
		/// <para>未选中 - 追踪结果中将不包含结构要素和对象。 这是默认设置。</para>
		/// <para><see cref="IncludeStructuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeStructures { get; set; } = "false";

		/// <summary>
		/// <para>Include Barriers Features</para>
		/// <para>指定追踪结果中是否包含可遍历性障碍要素。 即使已在子网定义中进行了预设，可遍历性障碍仍可选。 此参数不适用于具备终端的设备要素。</para>
		/// <para>选中 - 追踪结果中将包含可遍历性障碍要素。 这是默认设置。</para>
		/// <para>未选中 - 追踪结果中将不包含可遍历性障碍要素。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Traversability")]
		public object? IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>基于与网络属性的比较或对类别字符串的检查，对要素设置可遍历性障碍条件。 条件障碍使用网络属性、运算符和类型以及属性值。 例如，当要素的 Device Status 属性等于 Open 的特定值时，将停止追踪。 当要素满足此条件时，追踪将停止。 如果您要使用多个属性，可使用 Combine Using 参数来定义 And 或 Or 条件。</para>
		/// <para>条件障碍组件如下：</para>
		/// <para>名称 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>类型 - 从名称参数中指定的值中选择特定值或网络属性。</para>
		/// <para>值 - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>组合方法 - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>条件障碍运算符值选项如下：</para>
		/// <para>Is equal to - 该属性等于该值。</para>
		/// <para>Does not equal - 该属性不等于该值。</para>
		/// <para>Is greater than - 该属性大于该值。</para>
		/// <para>Is greater than or equal to - 该属性大于或等于该值。</para>
		/// <para>Is less than - 该属性小于该值。</para>
		/// <para>Is less than or equal to - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>条件障碍类型值选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object? ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>基于函数对要素设置可遍历性障碍。 函数障碍可用于执行以下操作：限制追踪距离起点的行程或设置停止追踪的最大值。 例如，所经过的每条线的长度和为目前经过的总距离。 当经过的总长度达到指定值时，追踪将停止。</para>
		/// <para>函数障碍组件如下：</para>
		/// <para>函数 - 从大量计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>值 - 提供将导致终止的输入属性类型（若发现）的特定值。</para>
		/// <para>使用局部值 - 计算每个方向的值，而不是整体全局值，例如计算 Shape length 总和的函数障碍，其中，如果值大于或等于 4，则追踪终止。 在全局情况下，遍历两条值为 2 的边之后，Shape length 总和即已达到 4，因此追踪会停止。 如果使用本地值，每条路径上的本地值会变化，且追踪将继续。</para>
		/// <para>选中 - 将使用局部值。</para>
		/// <para>未选中 - 将使用全局值。 这是默认设置。</para>
		/// <para>函数障碍函数值选项如下：</para>
		/// <para>Minimum - 输入值的最小值。</para>
		/// <para>Maximum - 输入值的最大值。</para>
		/// <para>Add - 输入值的总和。</para>
		/// <para>Average - 输入值的平均值。</para>
		/// <para>Count - 要素数目。</para>
		/// <para>Subtract - 输入值之间的差值。子网控制器和循环追踪类型不支持剪除功能。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用 Minimum 函数，则结果为 20；使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>函数障碍运算符值选项如下：</para>
		/// <para>Is equal to - 该属性等于该值。</para>
		/// <para>Does not equal - 该属性不等于该值。</para>
		/// <para>Is greater than - 该属性大于该值。</para>
		/// <para>Is greater than or equal to - 该属性大于或等于该值。</para>
		/// <para>Is less than - 该属性小于该值。</para>
		/// <para>Is less than or equal to - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>要强制使用的可遍历性的类型。 可遍历性范围指明是否在交汇点、边或这两处强制使用可遍历性。 例如，如果定义了用于停止追踪的条件障碍，其中 Device Status 等于 Open 并将遍历范围仅设置为边，则即使追踪遇到开路设备，追踪也不会停止，因为 Device Status 仅适用于交汇点。 换言之，此参数会向追踪指出是否要忽略交汇点、边或这两者。</para>
		/// <para>交汇点和边 - 可遍历性将同时应用于交汇点和边。</para>
		/// <para>仅交汇点 - 可遍历性将仅应用于交汇点。</para>
		/// <para>仅边 - 可遍历性将仅应用于边。</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Traversability")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter Barriers</para>
		/// <para>用于指定针对特定类别或网络属性的追踪停止时间。 例如，针对生命周期状态属性等于特定值的要素，追踪停止。 此参数用于根据系统中定义的网络属性值设置终止符。 如果要使用多个属性，可使用使用以下内容进行结合选项来定义 And 或 Or 条件。</para>
		/// <para>过滤器障碍组件如下：</para>
		/// <para>名称 - 按类别或系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量不同的运算符中进行选择。</para>
		/// <para>类型 - 从名称参数中指定的值中选择特定值或网络属性。</para>
		/// <para>值 - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>Combine using - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>过滤器障碍运算符值选项如下：</para>
		/// <para>Is equal to - 该属性等于该值。</para>
		/// <para>Does not equal - 该属性不等于该值。</para>
		/// <para>Is greater than - 该属性大于该值。</para>
		/// <para>Is greater than or equal to - 该属性大于或等于该值。</para>
		/// <para>Is less than - 该属性小于该值。</para>
		/// <para>Is less than or equal to - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>过滤器障碍类型值选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object? FilterBarriers { get; set; }

		/// <summary>
		/// <para>Filter Function Barriers</para>
		/// <para>用于过滤特定类别的追踪结果。</para>
		/// <para>过滤器函数障碍组件如下：</para>
		/// <para>函数 - 从大量不同的计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量不同的运算符中进行选择。</para>
		/// <para>值 - 提供将导致终止的输入属性类型（若发现）的特定值。</para>
		/// <para>使用局部值 - 计算每个方向的值，而不是整体全局值。 例如计算形状长度总和的函数障碍，其中，如果值大于或等于 4，则追踪终止。 在全局情况下，遍历两条值为 2 的边之后，形状长度总和将达到 4，因此追踪会停止。 如果使用本地值，每条路径上的本地值会变化，否则追踪将继续。</para>
		/// <para>选中 - 将使用局部值。</para>
		/// <para>未选中 - 将使用全局值。 这是默认设置。</para>
		/// <para>过滤器函数障碍函数值选项如下：</para>
		/// <para>最小值 - 将使用最小输入值。</para>
		/// <para>最大值 - 将使用最大输入值。</para>
		/// <para>加 - 将使用值的总和。</para>
		/// <para>平均值 - 将使用输入值的平均值。</para>
		/// <para>计数 - 将使用要素数。</para>
		/// <para>减 - 将使用各值之间的差值。 子网控制器和循环追踪类型不支持减函数。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用 Minimum 函数，则结果为 20。 使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>过滤器函数障碍运算符值选项如下：</para>
		/// <para>Is equal to - 该属性等于该值。</para>
		/// <para>Does not equal - 该属性不等于该值。</para>
		/// <para>Is greater than - 该属性大于该值。</para>
		/// <para>Is greater than or equal to - 该属性大于或等于该值。</para>
		/// <para>Is less than - 该属性小于该值。</para>
		/// <para>Is less than or equal to - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object? FilterFunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Filter To</para>
		/// <para>指定是否在交汇点、边或这两处应用特定类别的过滤器。 例如，如果定义了用于停止追踪的过滤器障碍，其中 Device Status 等于 Open 并将遍历范围仅设置为边，则即使追踪遇到开路设备，追踪也不会停止，因为 Device Status 仅适用于交汇点。 换言之，此参数会向追踪指出是否要忽略交汇点、边或这两者。</para>
		/// <para>交汇点和边 - 过滤器将同时应用于交汇点和边。 这是默认设置。</para>
		/// <para>仅交汇点 - 过滤器将仅应用于交汇点。</para>
		/// <para>仅边 - 过滤器将仅应用于边。</para>
		/// <para><see cref="FilterScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object? FilterScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter by bitset network attribute</para>
		/// <para>将用于按 bitset 过滤的网络属性的名称。 此参数仅适用于上溯、下溯和循环追踪类型。 此参数可用于在追踪过程中添加特殊逻辑，以便追踪能够更好地反映真实世界的场景。 例如，对于循环追踪而言，Phases current 网络属性可以确定该循环是否为实际的电气循环（相同的相在循环 A 中各处均有电流通过），并且追踪结果只返回实际的电气循环。 上溯追踪的示例如下；如果追踪配电网络时指定 Phases current 网络属性，则追踪结果将只包含在网络属性中指定的有效路径，而不是所有路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object? FilterBitsetNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Filter by nearest</para>
		/// <para>指定是否使用 k-最近邻算法在给定距离内返回一些特定类型的要素。 使用此参数时，您可以指定计数、成本以及类别和/或资产类型的集合。</para>
		/// <para>选中 - 将使用 k-最近邻算法来返回计数、成本网络属性、最近类别或最近资产组/类型参数中指定的一定数量的要素。</para>
		/// <para>未选中 - k 最近邻算法不会用于过滤结果。 这是默认设置。</para>
		/// <para><see cref="FilterNearestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object? FilterNearest { get; set; } = "false";

		/// <summary>
		/// <para>Count</para>
		/// <para>按最近过滤为选中状态时要返回的要素数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Filters")]
		public object? NearestCount { get; set; }

		/// <summary>
		/// <para>Cost Network Attribute</para>
		/// <para>当按最近过滤为选中状态时，将用于计算接近度、成本或距离的数字网络属性（例如形状长度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object? NearestCostNetworkAttribute { get; set; }

		/// <summary>
		/// <para>Nearest Categories</para>
		/// <para>当按最近过滤处于选中状态时，将返回的类别（例如保护类别）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object? NearestCategories { get; set; }

		/// <summary>
		/// <para>Nearest Asset Groups/Types</para>
		/// <para>当按最近过滤处于选中状态时，将返回的资产组和资产类型（例如，ElectricDistributionDevice/Transformer/Step Down）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object? NearestAssets { get; set; }

		/// <summary>
		/// <para>Propagators</para>
		/// <para>指定要传播的网络属性以及传播将在追踪过程中的发生方式。 传播的类属性表示子网控制器上已传播至子网余下要素的关键值。 例如，在配电模型中，您可传播相位值。</para>
		/// <para>传播程序组件如下：</para>
		/// <para>Attribute - 选择按系统中定义的任何网络属性进行过滤。</para>
		/// <para>Substitution Attribute - 使用替换值而不是 bitset 网络属性值。 替换是基于正在传递的网络属性中的位数进行编码的。 替换是指同相位的某个位到另一个位的映射。 例如对于相 AC 而言，可通过一个替换将位 A 映射到 B，将位 C 映射到 null。 在该示例中，1010（相 AC）的替换是 0000-0010-0000-0000 (512)。 该替换将捕捉映射，以通知您相 A 被映射到 B，且相 C 被映射到 null 而非相反（即相 A 未映射到 null，且相 C 未映射到 B）。</para>
		/// <para>Function - 从大量计算函数中进行选择。</para>
		/// <para>Operator - 从大量运算符中进行选择。</para>
		/// <para>Value - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>传播程序 function 值选项如下：</para>
		/// <para>PROPAGATED_BITWISE_AND—依次比较要素的值。</para>
		/// <para>PROPAGATED_MIN—将传播最小值。</para>
		/// <para>PROPAGATED_MAX—将传播最大值。</para>
		/// <para>传播程序 operator 值选项如下：</para>
		/// <para>IS_EQUAL_TO—属性与值相等。</para>
		/// <para>DOES_NOT_EQUAL—属性与值不等。</para>
		/// <para>IS_GREATER_THAN—属性大于值。</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—属性大于或等于值。</para>
		/// <para>IS_LESS_THAN—属性小于值。</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—属性小于或等于值。</para>
		/// <para>INCLUDES_THE_VALUES—值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—并非值中的所有位都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>INCLUDES_ANY—值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>DOES_NOT_INCLUDE_ANY—值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Propagators")]
		public object? Propagators { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>规则的描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutTemplateName { get; set; }

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// <para>指定是否将追踪具有不确定或未初始化流向的追踪网络要素。 此参数仅在于追踪网络上运行上游追踪或下游追踪时使用。</para>
		/// <para>选中 - 将包含追踪中具有不确定流向或未初始化流向的追踪网络要素。</para>
		/// <para>未选中 - 不包含具有不确定流向或未初始化流向的追踪网络要素。 这是默认设置。</para>
		/// <para><see cref="AllowIndeterminateFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowIndeterminateFlow { get; set; } = "false";

		/// <summary>
		/// <para>Path Direction</para>
		/// <para>指定追踪网络的路径的方向。 遍历路径的成本取决于最短路径网络属性名称参数值。 仅当运行最短路径追踪类型时，才会使用此参数。</para>
		/// <para>NO_DIRECTION—路径位于两个起点之间，无论流向如何。 这是默认设置。</para>
		/// <para>PATH_UPSTREAM—路径方向将是两个起点之间的下游方向。</para>
		/// <para>PATH_DOWNSTREAM—路径方向将是两个起点之间的上游方向。</para>
		/// <para><see cref="PathDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? PathDirection { get; set; } = "NO_DIRECTION";

		/// <summary>
		/// <para>Shortest Path Network Attribute Name</para>
		/// <para>将用于计算公共设施网络或追踪网络路径的网络属性。 运行最短路径追踪类型时，使用数字网络属性（例如形状长度）计算最短路径。 基于成本和距离的路径都可以计算得出。 运行最短路径追踪时，需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object? PathNetworkWeightName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INACTIVE")]
			INACTIVE,

		}

		/// <summary>
		/// <para>Include Structures</para>
		/// </summary>
		public enum IncludeStructuresEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_STRUCTURES")]
			INCLUDE_STRUCTURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_STRUCTURES")]
			EXCLUDE_STRUCTURES,

		}

		/// <summary>
		/// <para>Include Barriers Features</para>
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
		/// <para>Apply Traversability To</para>
		/// </summary>
		public enum TraversabilityScopeEnum 
		{
			/// <summary>
			/// <para>交汇点和边 - 可遍历性将同时应用于交汇点和边。</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>仅交汇点 - 可遍历性将仅应用于交汇点。</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边 - 可遍历性将仅应用于边。</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("仅边")]
			Edges_only,

		}

		/// <summary>
		/// <para>Apply Filter To</para>
		/// </summary>
		public enum FilterScopeEnum 
		{
			/// <summary>
			/// <para>交汇点和边 - 过滤器将同时应用于交汇点和边。 这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>仅交汇点 - 过滤器将仅应用于交汇点。</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边 - 过滤器将仅应用于边。</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("仅边")]
			Edges_only,

		}

		/// <summary>
		/// <para>Filter by nearest</para>
		/// </summary>
		public enum FilterNearestEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_NEAREST")]
			FILTER_BY_NEAREST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_FILTER")]
			DO_NOT_FILTER,

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
		/// <para>Path Direction</para>
		/// </summary>
		public enum PathDirectionEnum 
		{
			/// <summary>
			/// <para>NO_DIRECTION—路径位于两个起点之间，无论流向如何。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_DIRECTION")]
			[Description("NO_DIRECTION")]
			NO_DIRECTION,

			/// <summary>
			/// <para>PATH_UPSTREAM—路径方向将是两个起点之间的下游方向。</para>
			/// </summary>
			[GPValue("PATH_UPSTREAM")]
			[Description("PATH_UPSTREAM")]
			PATH_UPSTREAM,

			/// <summary>
			/// <para>PATH_DOWNSTREAM—路径方向将是两个起点之间的上游方向。</para>
			/// </summary>
			[GPValue("PATH_DOWNSTREAM")]
			[Description("PATH_DOWNSTREAM")]
			PATH_DOWNSTREAM,

		}

#endregion
	}
}
