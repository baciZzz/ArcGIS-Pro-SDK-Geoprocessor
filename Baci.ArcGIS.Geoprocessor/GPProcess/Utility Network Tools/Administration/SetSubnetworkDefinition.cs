using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Set Subnetwork Definition</para>
	/// <para>设置子网定义</para>
	/// <para>用于为公共设施网络中的子网设置域网络层的属性。</para>
	/// </summary>
	public class SetSubnetworkDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含层的子网的输入公共设施网络。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>包含层的域网络。</para>
		/// </param>
		/// <param name="TierName">
		/// <para>Tier Name</para>
		/// <para>包含子网的层的名称。</para>
		/// </param>
		/// <param name="SupportDisjointSubnetwork">
		/// <para>Support Disjoint Subnetwork</para>
		/// <para>指定输入层是否支持不相交子网。 不相交子网是属于同一个层的两个或多个子网，具有相同的子网名称，但不可遍历。 此参数仅适用于具有分区层定义的域网络内的层。 将为具有等级层定义的域网络中的层选中此参数以支持不相交子网。</para>
		/// <para>选中 - 输入层将支持不相交子网。</para>
		/// <para>未选中 - 输入层将不支持不相交子网。 这是默认设置。</para>
		/// <para><see cref="SupportDisjointSubnetworkEnum"/></para>
		/// </param>
		public SetSubnetworkDefinition(object InUtilityNetwork, object DomainNetwork, object TierName, object SupportDisjointSubnetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.TierName = TierName;
			this.SupportDisjointSubnetwork = SupportDisjointSubnetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置子网定义</para>
		/// </summary>
		public override string DisplayName() => "设置子网定义";

		/// <summary>
		/// <para>Tool Name : SetSubnetworkDefinition</para>
		/// </summary>
		public override string ToolName() => "SetSubnetworkDefinition";

		/// <summary>
		/// <para>Tool Excute Name : un.SetSubnetworkDefinition</para>
		/// </summary>
		public override string ExcuteName() => "un.SetSubnetworkDefinition";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, TierName, SupportDisjointSubnetwork, ValidDevices!, ValidSubnetworkController!, ValidLines!, AggregatedLine!, DiagramTemplate!, Summaries!, ConditionBarriers!, FunctionBarriers!, IncludeBarriers!, TraversabilityScope!, Propagators!, OutUtilityNetwork!, UpdateStructureFeatures!, UpdateContainerFeatures!, EditModeForDefaultVersion!, EditModeForNamedVersion!, ValidJunctions!, ValidJunctionObjects!, ValidJunctionObjectSubnetworkController!, ValidEdgeObjects!, ManageSubnetworkIsdirty!, IncludeContainers!, IncludeContent!, IncludeStructures!, ValidateLocatability! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含层的子网的输入公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>包含层的域网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier Name</para>
		/// <para>包含子网的层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TierName { get; set; }

		/// <summary>
		/// <para>Support Disjoint Subnetwork</para>
		/// <para>指定输入层是否支持不相交子网。 不相交子网是属于同一个层的两个或多个子网，具有相同的子网名称，但不可遍历。 此参数仅适用于具有分区层定义的域网络内的层。 将为具有等级层定义的域网络中的层选中此参数以支持不相交子网。</para>
		/// <para>选中 - 输入层将支持不相交子网。</para>
		/// <para>未选中 - 输入层将不支持不相交子网。 这是默认设置。</para>
		/// <para><see cref="SupportDisjointSubnetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SupportDisjointSubnetwork { get; set; } = "false";

		/// <summary>
		/// <para>Valid Devices</para>
		/// <para>将被标识为子网有效设备的资产组/资产类型对。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidDevices { get; set; }

		/// <summary>
		/// <para>Valid Device Subnetwork Controllers</para>
		/// <para>在子网中标识为有效设备子网控制器的资产组/资产类型对。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidSubnetworkController { get; set; }

		/// <summary>
		/// <para>Valid Lines</para>
		/// <para>将被标识为子网有效线的资产组/资产类型对。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidLines { get; set; }

		/// <summary>
		/// <para>Aggregated Lines For SubnetLine Feature Class</para>
		/// <para>所含几何将聚合以生成 SubnetLine 要素的有效线。 此列表为有效线参数中所指定值的子集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? AggregatedLine { get; set; }

		/// <summary>
		/// <para>Subnetwork Diagram Templates</para>
		/// <para>将用于为各个子网生成子网逻辑示意图的模板。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? DiagramTemplate { get; set; }

		/// <summary>
		/// <para>Summaries</para>
		/// <para>设置汇总属性字段以在插入或更新 SubnetLine 要素时存储函数结果。</para>
		/// <para>汇总组件如下：</para>
		/// <para>函数 - 从大量计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>过滤器名称 - 按属性名称过滤函数结果。</para>
		/// <para>过滤器运算符 - 从大量运算符中进行选择。</para>
		/// <para>过滤器类型 - 从大量过滤类型中进行选择。</para>
		/// <para>过滤器值 - 提供输入过滤属性的特定值。</para>
		/// <para>汇总属性 - SubnetLine 要素类中将保留函数结果的字段。 根据所选的函数和网络属性类型，只有用户添加的适用子网属性类型才对此参数有效。 如果 SubnetLine 要素类中不存在用于存储汇总结果的字段，则可以使用添加字段工具进行创建。 一个字段仅可支持一个汇总结果；每个汇总都需要在 SubnetLine 要素类中具有自己的字段。 请参阅下列基于所选函数的汇总属性字段的有效字段类型矩阵：函数</para>
		/// <para>短整型</para>
		/// <para>长整型</para>
		/// <para>双精度</para>
		/// <para>日期</para>
		/// <para>AVG</para>
		/// <para>双精度</para>
		/// <para>双精度</para>
		/// <para>双精度</para>
		/// <para>N/A</para>
		/// <para>MIN</para>
		/// <para>短整型</para>
		/// <para>长整型</para>
		/// <para>双精度</para>
		/// <para>日期</para>
		/// <para>MAX</para>
		/// <para>短整型</para>
		/// <para>长整型</para>
		/// <para>双精度</para>
		/// <para>日期</para>
		/// <para>SUBTRACT</para>
		/// <para>长整型</para>
		/// <para>长整型</para>
		/// <para>双精度</para>
		/// <para>N/A</para>
		/// <para>COUNT</para>
		/// <para>长整型</para>
		/// <para>长整型</para>
		/// <para>长整型</para>
		/// <para>N/A</para>
		/// <para>ADD</para>
		/// <para>长整型</para>
		/// <para>长整型</para>
		/// <para>双精度</para>
		/// <para>N/A</para>
		/// <para>汇总函数值选项如下：</para>
		/// <para>Minimum - 输入值的最小值。</para>
		/// <para>Maximum - 输入值的最大值。</para>
		/// <para>Add - 输入值的总和。</para>
		/// <para>Average - 输入值的平均值。</para>
		/// <para>Count - 要素数目。</para>
		/// <para>Subtract - 输入值之间的差值。子网控制器和循环追踪类型不支持剪除功能。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用 Minimum 函数，则结果为 20；使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>汇总过滤器运算符值选项如下：</para>
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
		/// <para>汇总过滤器类型值选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? Summaries { get; set; }

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
		[Category("Subnetwork Trace Configuration")]
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
		[Category("Subnetwork Trace Configuration")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>指定追踪结果中是否包含可遍历性障碍要素。 即使已在子网定义中进行了预设，可遍历性障碍仍可选。 此参数不适用于具备终端的设备要素。</para>
		/// <para>选中 - 追踪结果中将包含可遍历性障碍要素。 这是默认设置。</para>
		/// <para>未选中 - 追踪结果中将不包含可遍历性障碍要素。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeBarriers { get; set; } = "true";

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
		[Category("Subnetwork Trace Configuration")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>指定要传播的网络属性以及传播将在追踪过程中的发生方式。 传播的类属性表示子网控制器上已传播至子网余下要素的关键值。 例如，在配电模型中，您可传播相位值。</para>
		/// <para>传播程序组件如下：</para>
		/// <para>Attribute - 选择按系统中定义的任何网络属性进行过滤。</para>
		/// <para>Substitution Attribute - 使用替换值而不是 bitset 网络属性值。 替换是基于正在传递的网络属性中的位数进行编码的。 替换是指同相位的某个位到另一个位的映射。 例如对于相 AC 而言，可通过一个替换将位 A 映射到 B，将位 C 映射到 null。 在该示例中，1010（相 AC）的替换是 0000-0010-0000-0000 (512)。 该替换将捕捉映射，以通知您相 A 被映射到 B，且相 C 被映射到 null 而非相反（即相 A 未映射到 null，且相 C 未映射到 B）。</para>
		/// <para>Function - 从大量计算函数中进行选择。</para>
		/// <para>Operator - 从大量运算符中进行选择。</para>
		/// <para>Value - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>Propagated Attribute - 网络类中用于存储所计算传播值的字段的名称。 字段类型应该与为 Attribute 值选择的网络属性的字段类型相同。</para>
		/// <para>传播程序 function 值选项如下：</para>
		/// <para>PROPAGATED_BITWISE_AND—比较一个要素与下一个要素的值。</para>
		/// <para>PROPAGATED_MIN—获取最小值。</para>
		/// <para>PROPAGATED_MAX—获取最大值。</para>
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
		[Category("Subnetwork Trace Configuration")]
		public object? Propagators { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Update Structure Network Containers</para>
		/// <para>指定更新子网进程是否将更新结构网络容器的受支持子网名称属性。</para>
		/// <para>选中 - 将对结构网络容器进行更新。 这是默认设置。</para>
		/// <para>未选中 - 不会对结构网络容器进行更新。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// <para><see cref="UpdateStructureFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? UpdateStructureFeatures { get; set; } = "true";

		/// <summary>
		/// <para>Update Domain Network Containers</para>
		/// <para>指定更新子网进程是否将更新域网络容器的受支持子网名称。</para>
		/// <para>选中 - 将更新域网络容器。 这是默认设置。</para>
		/// <para>未选中 - 不会更新域网络容器。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// <para><see cref="UpdateContainerFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? UpdateContainerFeatures { get; set; } = "true";

		/// <summary>
		/// <para>Edit Mode For Default Version</para>
		/// <para>指定默认版本上和具有文件和移动地理数据库的子网更新所使用的编辑模式。</para>
		/// <para>无事件—事件将不会用于默认版本和文件或移动地理数据库中的子网更新。 此编辑模式会将子网名称和传播值更新到位。 这是默认设置。</para>
		/// <para>具有事件—事件将用于默认版本和文件或移动地理数据库中的子网更新。 当子网更新时，此编辑模式将执行地理数据库行为（例如，属性规则、编辑者追踪等），并为所有适用的要素和对象更新子网名称和传播值。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// <para><see cref="EditModeForDefaultVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? EditModeForDefaultVersion { get; set; } = "WITHOUT_EVENTING";

		/// <summary>
		/// <para>Edit Mode For Named Version</para>
		/// <para>指定将用于指定版本上的子网更新的编辑模式。</para>
		/// <para>无事件—事件将不会用于指定版本上的子网更新。 对于在此版本中编辑的要素和对象，此编辑模式将更新其子网名称和传播值。 这是默认设置。</para>
		/// <para>具有事件—事件将用于指定版本上的子网更新。 当子网更新时，此编辑模式将执行地理数据库行为（例如，属性规则、编辑者追踪等），并为所有适用的要素和对象更新子网名称和传播值。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本，并且仅适用于企业级地理数据库。</para>
		/// <para><see cref="EditModeForNamedVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? EditModeForNamedVersion { get; set; } = "WITHOUT_EVENTING";

		/// <summary>
		/// <para>Valid Junctions</para>
		/// <para>资产组/资产类型对将被标识为该子网的有效交汇点。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidJunctions { get; set; }

		/// <summary>
		/// <para>Valid Junction Objects</para>
		/// <para>资产组/资产类型对将被标识为该子网的有效交汇点对象。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidJunctionObjects { get; set; }

		/// <summary>
		/// <para>Valid Junction Object Subnetwork Controllers</para>
		/// <para>资产组/资产类型对将被标识为该子网的有效交汇点对象子网控制器。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidJunctionObjectSubnetworkController { get; set; }

		/// <summary>
		/// <para>Valid Edge Objects</para>
		/// <para>已标识为子网的有效边对象的资产组/资产类型对。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidEdgeObjects { get; set; }

		/// <summary>
		/// <para>Manage IsDirty</para>
		/// <para>指定子网表中的 Is dirty 属性是否将由更新子网操作管理。</para>
		/// <para>选中 - Is dirty 属性将由更新子网操作管理。 这是默认设置。</para>
		/// <para>未选中 - Is dirty 属性不会由更新子网操作管理。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// <para><see cref="ManageSubnetworkIsdirtyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? ManageSubnetworkIsdirty { get; set; } = "true";

		/// <summary>
		/// <para>Include Containers</para>
		/// <para>指定是否在追踪结果中包含容器要素和对象。</para>
		/// <para>选中 - 将在追踪结果中包含容器要素和对象。</para>
		/// <para>未选中 - 不会在追踪结果中包含容器要素和对象。 这是默认设置。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// <para><see cref="IncludeContainersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeContainers { get; set; } = "true";

		/// <summary>
		/// <para>Include Content</para>
		/// <para>指定追踪是否将在结果中返回容器的内容。</para>
		/// <para>选中 - 将在追踪结果中包含容器要素的内容。</para>
		/// <para>未选中 - 不会在追踪结果中包含容器要素的内容。 这是默认设置。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// <para><see cref="IncludeContentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeContent { get; set; } = "true";

		/// <summary>
		/// <para>Include Structures</para>
		/// <para>指定追踪结果中是否包含结构要素和对象。</para>
		/// <para>选中 - 追踪结果中将包含结构要素和对象。</para>
		/// <para>未选中 - 追踪结果中将不包含结构要素和对象。 这是默认设置。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// <para><see cref="IncludeStructuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeStructures { get; set; } = "true";

		/// <summary>
		/// <para>Validate Locatability</para>
		/// <para>指定如果遇到非空间交汇点或边对象并且遍历对象的关联层次结构中没有必要的包含、附件或连通性关联，是否在追踪或更新子网操作期间返回错误。 此参数确保可以通过与要素或其他可定位对象的关联来定位追踪或更新子网操作返回的非空间对象。</para>
		/// <para>选中 - 如果遇到非空间交汇点或边对象并且遍历对象的关联层次结构中没有必要的包含、附件或连通性关联，将返回一条错误。</para>
		/// <para>未选中 - 追踪不会检查是否存在无法定位的对象并返回结果，无论遍历对象的关联层次结构中是否存在无法定位的对象。 这是默认设置。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// <para><see cref="ValidateLocatabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? ValidateLocatability { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Support Disjoint Subnetwork</para>
		/// </summary>
		public enum SupportDisjointSubnetworkEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SUPPORT_DISJOINT")]
			SUPPORT_DISJOINT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISJOINT")]
			NO_DISJOINT,

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
		/// <para>Update Structure Network Containers</para>
		/// </summary>
		public enum UpdateStructureFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_UPDATE")]
			NOT_UPDATE,

		}

		/// <summary>
		/// <para>Update Domain Network Containers</para>
		/// </summary>
		public enum UpdateContainerFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_UPDATE")]
			NOT_UPDATE,

		}

		/// <summary>
		/// <para>Edit Mode For Default Version</para>
		/// </summary>
		public enum EditModeForDefaultVersionEnum 
		{
			/// <summary>
			/// <para>无事件—事件将不会用于默认版本和文件或移动地理数据库中的子网更新。 此编辑模式会将子网名称和传播值更新到位。 这是默认设置。</para>
			/// </summary>
			[GPValue("WITHOUT_EVENTING")]
			[Description("无事件")]
			Without_eventing,

			/// <summary>
			/// <para>具有事件—事件将用于默认版本和文件或移动地理数据库中的子网更新。 当子网更新时，此编辑模式将执行地理数据库行为（例如，属性规则、编辑者追踪等），并为所有适用的要素和对象更新子网名称和传播值。</para>
			/// </summary>
			[GPValue("WITH_EVENTING")]
			[Description("具有事件")]
			With_eventing,

		}

		/// <summary>
		/// <para>Edit Mode For Named Version</para>
		/// </summary>
		public enum EditModeForNamedVersionEnum 
		{
			/// <summary>
			/// <para>无事件—事件将不会用于指定版本上的子网更新。 对于在此版本中编辑的要素和对象，此编辑模式将更新其子网名称和传播值。 这是默认设置。</para>
			/// </summary>
			[GPValue("WITHOUT_EVENTING")]
			[Description("无事件")]
			Without_eventing,

			/// <summary>
			/// <para>具有事件—事件将用于指定版本上的子网更新。 当子网更新时，此编辑模式将执行地理数据库行为（例如，属性规则、编辑者追踪等），并为所有适用的要素和对象更新子网名称和传播值。</para>
			/// </summary>
			[GPValue("WITH_EVENTING")]
			[Description("具有事件")]
			With_eventing,

		}

		/// <summary>
		/// <para>Manage IsDirty</para>
		/// </summary>
		public enum ManageSubnetworkIsdirtyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MANAGE")]
			MANAGE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_MANAGE")]
			NOT_MANAGE,

		}

		/// <summary>
		/// <para>Include Containers</para>
		/// </summary>
		public enum IncludeContainersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTAINERS")]
			INCLUDE_CONTAINERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_CONTAINERS")]
			EXCLUDE_CONTAINERS,

		}

		/// <summary>
		/// <para>Include Content</para>
		/// </summary>
		public enum IncludeContentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTENT")]
			INCLUDE_CONTENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_CONTENT")]
			EXCLUDE_CONTENT,

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
		/// <para>Validate Locatability</para>
		/// </summary>
		public enum ValidateLocatabilityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VALIDATE_LOCATABILITY")]
			VALIDATE_LOCATABILITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_VALIDATE_LOCATABILITY")]
			DO_NOT_VALIDATE_LOCATABILITY,

		}

#endregion
	}
}
