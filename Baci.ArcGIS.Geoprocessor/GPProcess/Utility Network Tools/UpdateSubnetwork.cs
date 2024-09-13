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
	/// <para>更新指定子网的子网表、SubnetLine 要素类和子网系统逻辑示意图中的子网信息。 同时创建或更新子网要素的某些属性。 将生成所有新子网的记录，将移除所有已删除子网的记录，并将更新所有已修改子网的形状和信息。</para>
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
		/// <para>指定是否更新层中的所有子网。 要更新层中的子网子集，请使用子网名称参数。</para>
		/// <para>选中 - 更新层中的所有子网。 此选项使用异步处理通过系统 UtilityNetworkTools 地理处理服务更新子网。 此服务为公共设施网络地理处理任务而保留，并具有较长的默认超时设置。 这是默认设置。</para>
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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Tier, AllSubnetworksInTier, SubnetworkName!, ContinueOnFailure!, ConditionBarriers!, FunctionBarriers!, IncludeBarriers!, TraversabilityScope!, Propagators!, OutUtilityNetwork! };

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
		/// <para>指定是否更新层中的所有子网。 要更新层中的子网子集，请使用子网名称参数。</para>
		/// <para>选中 - 更新层中的所有子网。 此选项使用异步处理通过系统 UtilityNetworkTools 地理处理服务更新子网。 此服务为公共设施网络地理处理任务而保留，并具有较长的默认超时设置。 这是默认设置。</para>
		/// <para>未选中 - 仅更新子网名称参数中指定的子网。</para>
		/// <para><see cref="AllSubnetworksInTierEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllSubnetworksInTier { get; set; } = "true";

		/// <summary>
		/// <para>Subnetwork Name</para>
		/// <para>要更新的子网的名称。 如果将使用层中的所有子网参数来更新所有子网，则将忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SubnetworkName { get; set; }

		/// <summary>
		/// <para>Continue on failure</para>
		/// <para>指定如果在更新多个子网时某一子网更新失败，则是否停止更新进程。</para>
		/// <para>选中 - 如果失败，则继续更新子网。</para>
		/// <para>未选中 - 如果失败，则停止更新子网。 这是默认设置。</para>
		/// <para><see cref="ContinueOnFailureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContinueOnFailure { get; set; } = "false";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>指定要强制使用的可遍历性的类型。 可遍历性范围指明是否在交汇点、边或这两处强制使用可遍历性。 例如，如果定义了用于停止追踪的条件障碍，其中 DEVICESTATUS 等于 Open 并将遍历范围仅设置为边，则即使追踪遇到开路设备，追踪也不会停止，因为 DEVICESTATUS 仅适用于交汇点。 换言之，此参数会向追踪指出是否要忽略交汇点、边或这两者。</para>
		/// <para>交汇点和边—将可遍历性同时应用于交汇点和边。 这是默认设置。</para>
		/// <para>仅交汇点—仅将可遍历性应用于交汇点。</para>
		/// <para>仅边—仅将可遍历性应用于边。</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? Propagators { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPUtilityNetworkLayer()]
		public object? OutUtilityNetwork { get; set; }

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
			/// <para>交汇点和边—将可遍历性同时应用于交汇点和边。 这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>仅交汇点—仅将可遍历性应用于交汇点。</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边—仅将可遍历性应用于边。</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("仅边")]
			Edges_only,

		}

#endregion
	}
}
