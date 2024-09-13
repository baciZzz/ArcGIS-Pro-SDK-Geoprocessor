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
	/// <para>将公共设施网络的子网导出为 JSON 文件。如果 Is deleted 属性设置为 true，则该工具也可以用于删除子网表中的行。这表示子网控制器已从子网中移除。</para>
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
		/// <para>要导出的子网的名称。选择一个特定源可导出相应的子网信息。</para>
		/// </param>
		/// <param name="ExportAcknowledged">
		/// <para>Set export acknowledged</para>
		/// <para>指定是否更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性以及 SubnetLine 要素类中的要素。</para>
		/// <para>选中 - 更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性。如果控制器已标记为删除 (Is deleted = True)，则将从子网表中将其删除。此选项要求输入公共设施网络引用默认版本。</para>
		/// <para>未选中 - 不更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性。这是默认设置。</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output JSON</para>
		/// <para>要生成的 JSON 文件的名称和位置。</para>
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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Tier, SubnetworkName, ExportAcknowledged, OutJsonFile, ConditionBarriers, FunctionBarriers, IncludeBarriers, TraversabilityScope, Propagators, OutUtilityNetwork, IncludeGeometry, ResultTypes, ResultNetworkAttributes, ResultFields };

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
		/// <para>要导出的子网的名称。选择一个特定源可导出相应的子网信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SubnetworkName { get; set; }

		/// <summary>
		/// <para>Set export acknowledged</para>
		/// <para>指定是否更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性以及 SubnetLine 要素类中的要素。</para>
		/// <para>选中 - 更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性。如果控制器已标记为删除 (Is deleted = True)，则将从子网表中将其删除。此选项要求输入公共设施网络引用默认版本。</para>
		/// <para>未选中 - 不更新 Subnetworks 表中相应控制器的 LASTACKEXPORTSUBNETWORK 属性。这是默认设置。</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExportAcknowledged { get; set; } = "false";

		/// <summary>
		/// <para>Output JSON</para>
		/// <para>要生成的 JSON 文件的名称和位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object OutJsonFile { get; set; }

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>基于与网络属性的比较或对类别字符串的检查，对要素设置可遍历性障碍条件。条件障碍使用网络属性、运算符和类型以及属性值。例如，当要素的 Device Status 属性等于 Open 的特定值时，将停止追踪。当要素满足此条件时，追踪将停止。如果您要使用多个属性，可使用 Combine Using 参数来定义 And 或 Or 条件。</para>
		/// <para>条件障碍组件如下：</para>
		/// <para>Name - 选择按系统中定义的任何网络属性进行过滤。</para>
		/// <para>Operator - 从大量不同的运算符中进行选择。</para>
		/// <para>Type - 从 name 参数指定的值中选择特定值或网络属性。</para>
		/// <para>Value - 设置基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>Combine Using - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>条件障碍 operator 值如下：</para>
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
		/// <para>Use Local Values - 计算每个方向的值，而不是整体全局值。例如，用于计算 Shape length 总和的函数障碍，其中，如果值大于或等于 4，则追踪终止。在全局情况下，遍历两条值为 2 的边之后，形状长度总和即已达到 4，因此追踪会停止。如果使用局部值，每条路径上的局部值会变化，因此追踪会持续得更远。</para>
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
		/// <para>此参数仅可通过 Python 获得。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>指定要强制使用的可遍历性的类型。可遍历性范围指明是否在交汇点、边或这两处强制使用可遍历性。例如，如果定义了一个用于停止追踪的条件障碍，其中 DEVICESTATUS 设置为 Open 且遍历范围设置为仅边，则即使遇到开路设备，追踪也不会停止，因为 DEVICESTATUS 仅适用于交汇点。换言之，此参数会为追踪指明是否要忽略交汇点和/或边。</para>
		/// <para>BOTH_JUNCTIONS_AND_EDGES—将可遍历性同时应用于交汇点和边。</para>
		/// <para>JUNCTIONS_ONLY—将可遍历性仅应用于交汇点。</para>
		/// <para>EDGES_ONLY—将可遍历性仅应用于边。</para>
		/// <para>此参数仅可通过 Python 获得。</para>
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
		/// <para>DOES NOT INCLUDE_THE_VALUES—按位与运算，其中并非值中的所有位都存在于属性中（按位与 != 值）。</para>
		/// <para>INCLUDES_ANY—按位与运算，其中值中的至少一个位存在于属性中（按位与 == True）。</para>
		/// <para>DOES_NOT_INLCUDE_ANY—按位与运算，其中值中的所有位均不存在于属性中（按位与 == False）。</para>
		/// <para>此参数仅可通过 Python 获得。</para>
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
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Include Geometry</para>
		/// <para>指定是否在结果中包括几何。</para>
		/// <para>选中 - 在结果中包括几何。</para>
		/// <para>未选中 - 在结果中不包括几何。这是默认设置。</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Result Types</para>
		/// <para>指定要导出的结果类型。</para>
		/// <para>连通性—返回通过几何重叠或连通性关联连接的要素。这是默认设置。</para>
		/// <para>要素—返回响应中的要素级别信息。</para>
		/// <para>包含和附件关联—返回通过包含和结构附件关联关联的要素。</para>
		/// <para>对于企业级地理数据库，此参数要求 ArcGIS Enterprise 10.7 或更高版本。</para>
		/// <para>包含和附件关联选项要求 ArcGIS Enterprise 10.8.1 或更高版本。</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ResultTypes { get; set; }

		/// <summary>
		/// <para>Result Network Attributes</para>
		/// <para>将包含在结果中的网络属性。</para>
		/// <para>对于企业级地理数据库，此参数要求 ArcGIS Enterprise 10.7 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object ResultNetworkAttributes { get; set; }

		/// <summary>
		/// <para>Result Fields</para>
		/// <para>要素类中将作为结果返回的字段。字段的值将在子网中要素的结果中返回。</para>
		/// <para>对于企业级地理数据库，此参数要求 ArcGIS Enterprise 10.7 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ResultFields { get; set; }

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

		/// <summary>
		/// <para>Include Geometry</para>
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
			/// <para>要素—返回响应中的要素级别信息。</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("要素")]
			Features,

			/// <summary>
			/// <para>连通性—返回通过几何重叠或连通性关联连接的要素。这是默认设置。</para>
			/// </summary>
			[GPValue("CONNECTIVITY")]
			[Description("连通性")]
			Connectivity,

			/// <summary>
			/// <para>包含和附件关联—返回通过包含和结构附件关联关联的要素。</para>
			/// </summary>
			[GPValue("CONTAINMENT_AND_ATTACHMENT_ASSOCIATIONS")]
			[Description("包含和附件关联")]
			Containment_and_attachment_associations,

		}

#endregion
	}
}
