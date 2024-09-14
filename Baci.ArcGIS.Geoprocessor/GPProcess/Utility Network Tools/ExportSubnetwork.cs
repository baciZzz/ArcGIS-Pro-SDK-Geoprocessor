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
	/// <para>Export Subnetwork</para>
	/// <para>导出子网</para>
	/// <para>将公共设施网络的子网导出为 .json 文件。 如果 Is deleted 属性设置为 true，则该工具也可以用于删除子网表中的行。 这表示子网控制器已从子网中移除。</para>
	/// </summary>
	public class ExportSubnetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含要导出的子网的公共设施网络。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>包含子网的域网络。</para>
		/// </param>
		/// <param name="Tier">
		/// <para>Tier</para>
		/// <para>包含子网的层。</para>
		/// </param>
		/// <param name="SubnetworkName">
		/// <para>Subnetwork Name</para>
		/// <para>要导出的子网的名称。 选择一个特定源可导出相应的子网信息。</para>
		/// </param>
		/// <param name="ExportAcknowledged">
		/// <para>Set export acknowledged</para>
		/// <para>指定是否更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性以及 SubnetLine 要素类中的要素。</para>
		/// <para>选中 - 子网表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性将更新。 如果控制器已标记为删除 (Is deleted = True)，则将从子网表中将其删除。 此选项要求输入公共设施网络引用默认版本。</para>
		/// <para>未选中 - 子网表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性不会更新。 这是默认设置。</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output JSON</para>
		/// <para>将生成的 .json 文件的名称和位置。</para>
		/// </param>
		public ExportSubnetwork(object InUtilityNetwork, object DomainNetwork, object Tier, object SubnetworkName, object ExportAcknowledged, object OutJsonFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Tier = Tier;
			this.SubnetworkName = SubnetworkName;
			this.ExportAcknowledged = ExportAcknowledged;
			this.OutJsonFile = OutJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出子网</para>
		/// </summary>
		public override string DisplayName() => "导出子网";

		/// <summary>
		/// <para>Tool Name : ExportSubnetwork</para>
		/// </summary>
		public override string ToolName() => "ExportSubnetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportSubnetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.ExportSubnetwork";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Tier, SubnetworkName, ExportAcknowledged, OutJsonFile, ConditionBarriers!, FunctionBarriers!, IncludeBarriers!, TraversabilityScope!, Propagators!, OutUtilityNetwork!, IncludeGeometry!, ResultTypes!, ResultNetworkAttributes!, ResultFields!, IncludeDomainDescriptions! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含要导出的子网的公共设施网络。</para>
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
		/// <para>Subnetwork Name</para>
		/// <para>要导出的子网的名称。 选择一个特定源可导出相应的子网信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SubnetworkName { get; set; }

		/// <summary>
		/// <para>Set export acknowledged</para>
		/// <para>指定是否更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性以及 SubnetLine 要素类中的要素。</para>
		/// <para>选中 - 子网表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性将更新。 如果控制器已标记为删除 (Is deleted = True)，则将从子网表中将其删除。 此选项要求输入公共设施网络引用默认版本。</para>
		/// <para>未选中 - 子网表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性不会更新。 这是默认设置。</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExportAcknowledged { get; set; } = "false";

		/// <summary>
		/// <para>Output JSON</para>
		/// <para>将生成的 .json 文件的名称和位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object OutJsonFile { get; set; }

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>此参数仅可用于 Python。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>此参数仅可用于 Python。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>此参数仅可用于 Python。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>指定将应用的可遍历性类型。 可遍历性范围用于确定是否在交汇点和/或边处应用可遍历性。 例如，如果定义了一个用于停止追踪的条件障碍，其中 DEVICESTATUS 设置为 Open 且遍历范围设置为仅边，则即使遇到开路设备，追踪也不会停止，因为 DEVICESTATUS 仅适用于交汇点。 换言之，此参数会向追踪指出是否要忽略交汇点、边或这两者。</para>
		/// <para>交汇点和边—可遍历性将同时应用于交汇点和边。</para>
		/// <para>仅交汇点—可遍历性将仅应用于交汇点。</para>
		/// <para>仅边—可遍历性将仅应用于边。</para>
		/// <para>此参数仅可用于 Python。</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>此参数仅可用于 Python。</para>
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
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Include geometry</para>
		/// <para>指定是否在结果中包括几何。</para>
		/// <para>选中 - 结果中将包含几何。</para>
		/// <para>未选中 - 结果中将不包含几何。 这是默认设置。</para>
		/// <para>对于企业级地理数据库，此参数需要 ArcGIS Enterprise 10.7 或更高版本。</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Result Types</para>
		/// <para>指定将要返回的结果类型。</para>
		/// <para>连通性—将返回通过几何重叠或连通性关联连接的要素。 这是默认设置。</para>
		/// <para>要素—将返回要素级别信息。</para>
		/// <para>包含和附件关联—将返回通过包含和结构附件关联关联的要素。</para>
		/// <para>对于企业级地理数据库，此参数需要 ArcGIS Enterprise 10.7 或更高版本。</para>
		/// <para>包含和附件关联选项需要 ArcGIS Enterprise 10.8.1 或更高版本。</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ResultTypes { get; set; }

		/// <summary>
		/// <para>Result Network Attributes</para>
		/// <para>将包含在结果中的网络属性。</para>
		/// <para>对于企业级地理数据库，此参数需要 ArcGIS Enterprise 10.7 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ResultNetworkAttributes { get; set; }

		/// <summary>
		/// <para>Result Fields</para>
		/// <para>要素类中将作为结果返回的字段。 字段的值将在子网中要素的结果中返回。</para>
		/// <para>对于企业级地理数据库，此参数需要 ArcGIS Enterprise 10.7 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ResultFields { get; set; }

		/// <summary>
		/// <para>Include domain descriptions</para>
		/// <para>指定域描述是否将包含在输出 .json 文件中以传达控制器、要素元素、连通性和关联的域映射。</para>
		/// <para>选中 - 将在结果中包含域描述。</para>
		/// <para>未选中 - 不会在结果中包含域描述。 这是默认设置。</para>
		/// <para>对于企业级地理数据库，此参数需要 ArcGIS Enterprise 10.9.1 或更高版本。</para>
		/// <para><see cref="IncludeDomainDescriptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeDomainDescriptions { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Set export acknowledged</para>
		/// </summary>
		public enum ExportAcknowledgedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ACKNOWLEDGE")]
			ACKNOWLEDGE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ACKNOWLEDGE")]
			NO_ACKNOWLEDGE,

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
			/// <para>交汇点和边—可遍历性将同时应用于交汇点和边。</para>
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
		/// <para>Include geometry</para>
		/// </summary>
		public enum IncludeGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRY")]
			INCLUDE_GEOMETRY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRY")]
			EXCLUDE_GEOMETRY,

		}

		/// <summary>
		/// <para>Result Types</para>
		/// </summary>
		public enum ResultTypesEnum 
		{
			/// <summary>
			/// <para>要素—将返回要素级别信息。</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("要素")]
			Features,

			/// <summary>
			/// <para>连通性—将返回通过几何重叠或连通性关联连接的要素。 这是默认设置。</para>
			/// </summary>
			[GPValue("CONNECTIVITY")]
			[Description("连通性")]
			Connectivity,

			/// <summary>
			/// <para>包含和附件关联—将返回通过包含和结构附件关联关联的要素。</para>
			/// </summary>
			[GPValue("CONTAINMENT_AND_ATTACHMENT_ASSOCIATIONS")]
			[Description("包含和附件关联")]
			Containment_and_attachment_associations,

		}

		/// <summary>
		/// <para>Include domain descriptions</para>
		/// </summary>
		public enum IncludeDomainDescriptionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_DOMAIN_DESCRIPTIONS")]
			INCLUDE_DOMAIN_DESCRIPTIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_DOMAIN_DESCRIPTIONS")]
			EXCLUDE_DOMAIN_DESCRIPTIONS,

		}

#endregion
	}
}
