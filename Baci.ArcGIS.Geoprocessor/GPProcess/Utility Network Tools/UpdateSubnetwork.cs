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
	/// <para>Update Subnetwork</para>
	/// <para>更新子网</para>
	/// <para>更新指定子网的子网表、SubnetLine 要素类和子网系统逻辑示意图中的子网信息。同时创建或更新子网要素的某些属性。将生成所有新子网的记录，将移除所有已删除子网的记录，并将更新所有已修改子网的形状和信息。</para>
	/// </summary>
	public class UpdateSubnetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含子网的公共设施网络。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>包含子网的域网络。</para>
		/// </param>
		/// <param name="Tier">
		/// <para>Tier</para>
		/// <para>包含子网的层。</para>
		/// </param>
		/// <param name="AllSubnetworksInTier">
		/// <para>All subnetworks in tier</para>
		/// <para>指定是否更新层中的所有子网。要更新层中的子网子集，请使用子网名称参数。</para>
		/// <para>选中 - 更新层中的所有子网。此选项使用异步处理通过系统 UtilityNetworkTools 地理处理服务更新子网。此服务为公共设施网络地理处理任务而保留，并具有较长的默认超时设置。这是默认设置。</para>
		/// <para>未选中 - 仅更新子网名称参数中指定的子网。</para>
		/// <para><see cref="AllSubnetworksInTierEnum"/></para>
		/// </param>
		public UpdateSubnetwork(object InUtilityNetwork, object DomainNetwork, object Tier, object AllSubnetworksInTier)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Tier = Tier;
			this.AllSubnetworksInTier = AllSubnetworksInTier;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新子网</para>
		/// </summary>
		public override string DisplayName() => "更新子网";

		/// <summary>
		/// <para>Tool Name : UpdateSubnetwork</para>
		/// </summary>
		public override string ToolName() => "UpdateSubnetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.UpdateSubnetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.UpdateSubnetwork";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Tier, AllSubnetworksInTier, SubnetworkName, ContinueOnFailure, ConditionBarriers, FunctionBarriers, IncludeBarriers, TraversabilityScope, Propagators, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含子网的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>包含子网的域网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// <para>包含子网的层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Tier { get; set; }

		/// <summary>
		/// <para>All subnetworks in tier</para>
		/// <para>指定是否更新层中的所有子网。要更新层中的子网子集，请使用子网名称参数。</para>
		/// <para>选中 - 更新层中的所有子网。此选项使用异步处理通过系统 UtilityNetworkTools 地理处理服务更新子网。此服务为公共设施网络地理处理任务而保留，并具有较长的默认超时设置。这是默认设置。</para>
		/// <para>未选中 - 仅更新子网名称参数中指定的子网。</para>
		/// <para><see cref="AllSubnetworksInTierEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllSubnetworksInTier { get; set; } = "true";

		/// <summary>
		/// <para>Subnetwork Name</para>
		/// <para>要更新的子网的名称。如果使用层中的所有子网参数来更新所有子网，则将忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SubnetworkName { get; set; }

		/// <summary>
		/// <para>Continue on failure</para>
		/// <para>指定如果在更新多个子网时某一子网更新失败，是否停止更新进程。</para>
		/// <para>选中 - 如果失败，则继续更新子网。</para>
		/// <para>未选中 - 如果失败，则停止更新子网。这是默认设置。</para>
		/// <para><see cref="ContinueOnFailureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueOnFailure { get; set; } = "false";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>基于与网络属性的比较或对类别字符串的检查，对要素设置可遍历性障碍条件。条件障碍使用网络属性、运算符和类型以及属性值。例如，当要素的 Device Status 属性等于 Open 的特定值时，将停止追踪。当要素满足此条件时，追踪将停止。如果您要使用多个属性，可使用 Combine Using 参数来定义 And 或 Or 条件。</para>
		/// <para>条件障碍组件如下：</para>
		/// <para>Name - 选择按系统中定义的任何网络属性进行过滤。</para>
		/// <para>Operator - 从大量不同的运算符中进行选择。</para>
		/// <para>Type - 从 name 参数指定的值中选择特定值或网络属性。</para>
		/// <para>Value - 设置基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>Combine Using - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>条件障碍 Operator 值如下：</para>
		/// <para>IS_EQUAL_TO—该属性等于该值。</para>
		/// <para>DOES_NOT_EQUAL—该属性不等于该值。</para>
		/// <para>IS_GREATER_THAN—该属性大于该值。</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—该属性大于或等于该值。</para>
		/// <para>IS_LESS_THAN—该属性小于该值。</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—该属性小于或等于该值。</para>
		/// <para>INCLUDES_THE_VALUES—按位与运算，其中值中的所有位都存在于属性中（按位与 == 值）。</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—按位与运算，其中并非值中的所有位都存在于属性中（按位与 != 值）。</para>
		/// <para>INCLUDES_ANY—按位与运算，其中值中的至少一个位存在于属性中（按位与 == True）。</para>
		/// <para>DOES_NOT_INCLUDE_ANY—按位与运算，其中值中的所有位均不存在于属性中（按位与 == False）。</para>
		/// <para>条件障碍 type 选项如下：</para>
		/// <para>SPECIFIC_VALUE—按特定值过滤。</para>
		/// <para>NETWORK_ATTRIBUTE—按网络属性过滤。</para>
		/// <para>Combine Using 值如下：</para>
		/// <para>AND—合并条件障碍。</para>
		/// <para>OR—满足任一条件障碍时使用。</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>基于函数对要素设置可遍历性障碍。函数障碍可用于执行以下操作：限制追踪距离起点的行程或设置停止追踪的最大值。例如，所经过的每条线的长度和为目前经过的总距离。当经过的总长度达到指定值时，追踪将停止。</para>
		/// <para>函数障碍组件如下：</para>
		/// <para>Function - 从大量不同的计算函数中进行选择。</para>
		/// <para>Attribute - 选择按系统中定义的任何网络属性进行过滤。</para>
		/// <para>Operator - 从大量不同的运算符中进行选择。</para>
		/// <para>Value - 设置将导致终止的输入属性类型（若发现）的特定值。</para>
		/// <para>Use Local Values - 计算每个方向的值，而不是整体全局值，例如计算 Shape length 总和的函数障碍，其中，如果值大于或等于 4，则追踪终止。在全局情况下，遍历两条值为 2 的边之后，形状长度总和即已达到 4，因此追踪会停止。如果使用局部值，每条路径上的局部值会变化，因此追踪会持续得更远。</para>
		/// <para>TRUE—使用局部值。</para>
		/// <para>FALSE—使用全局值。这是默认设置。</para>
		/// <para>函数障碍 function 选项的可能值如下：</para>
		/// <para>AVERAGE—输入值的平均值。</para>
		/// <para>COUNT—要素数目。</para>
		/// <para>MAX—输入值的最大值。</para>
		/// <para>MIN—输入值的最小值。</para>
		/// <para>ADD—加上这些值。</para>
		/// <para>SUBTRACT—减去这些值。子网控制器和循环追踪类型不支持减法函数。</para>
		/// <para>例如，起点要素的值为 20。下一个要素的值为 30。如果使用 Minimum 函数，则结果为 20；使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>函数障碍 operator 值选项如下：</para>
		/// <para>IS_EQUAL_TO—该属性等于该值。</para>
		/// <para>DOES_NOT_EQUAL—该属性不等于该值。</para>
		/// <para>IS_GREATER_THAN—该属性大于该值。</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—该属性大于或等于该值。</para>
		/// <para>IS_LESS_THAN—该属性小于该值。</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—该属性小于或等于该值。</para>
		/// <para>INCLUDES_THE_VALUES—按位与运算，其中值中的所有位都存在于属性中（按位与 == 值）。</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—按位与运算，其中并非值中的所有位都存在于属性中（按位与 != 值）。</para>
		/// <para>INCLUDES_ANY—按位与运算，其中值中的至少一个位存在于属性中（按位与 == True）。</para>
		/// <para>DOES_NOT_INCLUDE_ANY—按位与运算，其中值中的所有位均不存在于属性中（按位与 == False）。</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>指定追踪结果中是否包含可遍历性障碍要素。即使已在子网定义中进行了预设，可遍历性障碍仍可选。</para>
		/// <para>INCLUDE_BARRIERS—追踪结果中包含可遍历性障碍。这是默认设置。</para>
		/// <para>EXCLUDE_BARRIERS—追踪结果中不包含可遍历性障碍。</para>
		/// <para>此参数仅可通过 Python 和 ModelBuilder 获得。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>指定要强制使用的可遍历性的类型。可遍历性范围指明是否在交汇点、边或这两处强制使用可遍历性。例如，如果定义了用于停止追踪的条件障碍，其中 DEVICESTATUS 等于 Open 并将遍历范围仅设置为边，则即使追踪遇到开路设备，追踪也不会停止，因为 DEVICESTATUS 仅适用于交汇点。换言之，此参数会为追踪指明是否要忽略交汇点和/或边。</para>
		/// <para>BOTH_JUNCTIONS_AND_EDGES—将可遍历性同时应用于交汇点和边。这是默认设置。</para>
		/// <para>JUNCTIONS_ONLY—将可遍历性仅应用于交汇点。</para>
		/// <para>EDGES_ONLY—将可遍历性仅应用于边。</para>
		/// <para>此参数仅可通过 Python 和 ModelBuilder 获得。</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>指定要传播的网络属性以及传播将在追踪过程中的发生方式。传播的类属性表示子网控制器上已传播至子网余下要素的关键值。例如，在配电模型中，您可传播相位值。</para>
		/// <para>传播程序组件如下：</para>
		/// <para>Attribute - 选择按系统中定义的任何网络属性进行过滤。</para>
		/// <para>Substitution Attribute - 使用替换值而不是 bitset 网络属性值。替换是基于正在传播的网络属性中的位数进行编码的。替换是指同相位的某个位到另一个位的映射。例如对于相 AC 而言，可通过一个替换将位 A 映射到 B，将位 C 映射到 null。在该示例中，1010（相 AC）的替换是 0000-0010-0000-0000 (512)。该替换将捕捉映射，以通知您相 A 被映射到 B，且相 C 被映射到 null 而非相反（即相 A 未映射到 null，且相 C 未映射到 B）。</para>
		/// <para>Function - 从大量计算函数中进行选择。</para>
		/// <para>Operator - 从大量运算符中进行选择。</para>
		/// <para>Value - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>传播程序 function 的可能值如下：</para>
		/// <para>PROPAGATED_BITWISE_AND—比较一个要素与下一个要素的值。</para>
		/// <para>PROPAGATED_MIN—获取最小值。</para>
		/// <para>PROPAGATED_MAX—获取最大值。</para>
		/// <para>传播程序 operator 值如下：</para>
		/// <para>IS_EQUAL_TO—该属性等于该值。</para>
		/// <para>DOES_NOT_EQUAL—该属性不等于该值。</para>
		/// <para>IS_GREATER_THAN—该属性大于该值。</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—该属性大于或等于该值。</para>
		/// <para>IS_LESS_THAN—该属性小于该值。</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—该属性小于或等于该值。</para>
		/// <para>INCLUDES_THE_VALUES—按位与运算，其中值中的所有位都存在于属性中（按位与 == 值）。</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—按位与运算，其中并非值中的所有位都存在于属性中（按位与 != 值）。</para>
		/// <para>INCLUDES_ANY—按位与运算，其中值中的至少一个位存在于属性中（按位与 == True）。</para>
		/// <para>DOES_NOT_INCLUDE_ANY—按位与运算，其中值中的所有位均不存在于属性中（按位与 == False）。</para>
		/// <para>此参数仅可通过 Python 和 ModelBuilder 获得。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object Propagators { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPUtilityNetworkLayer()]
		public object OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>All subnetworks in tier</para>
		/// </summary>
		public enum AllSubnetworksInTierEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SUBNETWORKS_IN_TIER")]
			ALL_SUBNETWORKS_IN_TIER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SPECIFIC_SUBNETWORK")]
			SPECIFIC_SUBNETWORK,

		}

		/// <summary>
		/// <para>Continue on failure</para>
		/// </summary>
		public enum ContinueOnFailureEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_ON_FAILURE")]
			CONTINUE_ON_FAILURE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("STOP_ON_FAILURE")]
			STOP_ON_FAILURE,

		}

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// </summary>
		public enum IncludeBarriersEnum 
		{
			/// <summary>
			/// <para>INCLUDE_BARRIERS—追踪结果中包含可遍历性障碍。这是默认设置。</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_BARRIERS")]
			INCLUDE_BARRIERS,

			/// <summary>
			/// <para>EXCLUDE_BARRIERS—追踪结果中不包含可遍历性障碍。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("仅边")]
			Edges_only,

		}

#endregion
	}
}
