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
	/// <para>Add Rule</para>
	/// <para>添加规则</para>
	/// <para>用于向公共设施网络中添加规则。</para>
	/// </summary>
	public class AddRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将添加规则的公共设施网络。</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>要创建的规则类型。</para>
		/// <para>交汇点-交汇点连通性—创建交汇点-交汇点连通性关联规则，允许两点通过连通性进行连接（要素会发生几何偏移）。</para>
		/// <para>包含—创建包含规则，其中“自”参数为容器，“至”参数为包含关联中的内容。</para>
		/// <para>结构附件—创建结构附件规则，其中“自”参数为结构要素，“至”参数为结构附件关联中的附件要素。</para>
		/// <para>交汇点-边连通性—创建边-交汇点规则，允许边和交汇点要素通过几何重叠进行连接（要素位于相同的 x,y,z 位置）。</para>
		/// <para>边-交汇点-边连通性—创建边-交汇点-边连通性规则，允许边连接到交汇点要素的任一侧。</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		/// <param name="FromClass">
		/// <para>From Table</para>
		/// <para>将包括在规则中的“自”公共设施网络要素类或表。</para>
		/// <para>结构附件和包含关联规则要求容器或结构要素在此参数中。</para>
		/// <para>交汇点-交汇点、交汇点-边和边-交汇点-边连通性规则的顺序不重要。</para>
		/// </param>
		/// <param name="FromAssetgroup">
		/// <para>From Asset Group</para>
		/// <para>要应用规则的自表的资产组。</para>
		/// </param>
		/// <param name="FromAssettype">
		/// <para>From Asset Type</para>
		/// <para>要应用规则的自表的资产类型。</para>
		/// </param>
		/// <param name="ToClass">
		/// <para>To Table</para>
		/// <para>将包括在规则中的“至”公共设施网络要素类或表。</para>
		/// <para>结构附件和包含关联规则要求内容或附件要素在此参数中。</para>
		/// <para>交汇点-交汇点、交汇点-边和边-交汇点-边连通性规则的顺序不重要。</para>
		/// </param>
		/// <param name="ToAssetgroup">
		/// <para>To Asset Group</para>
		/// <para>要应用规则的至表的资产组。</para>
		/// </param>
		/// <param name="ToAssettype">
		/// <para>To Asset Type</para>
		/// <para>要应用规则的至表的资产类型。</para>
		/// </param>
		public AddRule(object InUtilityNetwork, object RuleType, object FromClass, object FromAssetgroup, object FromAssettype, object ToClass, object ToAssetgroup, object ToAssettype)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
			this.FromClass = FromClass;
			this.FromAssetgroup = FromAssetgroup;
			this.FromAssettype = FromAssettype;
			this.ToClass = ToClass;
			this.ToAssetgroup = ToAssetgroup;
			this.ToAssettype = ToAssettype;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加规则</para>
		/// </summary>
		public override string DisplayName() => "添加规则";

		/// <summary>
		/// <para>Tool Name : AddRule</para>
		/// </summary>
		public override string ToolName() => "AddRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddRule</para>
		/// </summary>
		public override string ExcuteName() => "un.AddRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, FromClass, FromAssetgroup, FromAssettype, ToClass, ToAssetgroup, ToAssettype, FromTerminal, ToTerminal, ViaClass, ViaAssetgroup, ViaAssettype, ViaTerminal, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将添加规则的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>要创建的规则类型。</para>
		/// <para>交汇点-交汇点连通性—创建交汇点-交汇点连通性关联规则，允许两点通过连通性进行连接（要素会发生几何偏移）。</para>
		/// <para>包含—创建包含规则，其中“自”参数为容器，“至”参数为包含关联中的内容。</para>
		/// <para>结构附件—创建结构附件规则，其中“自”参数为结构要素，“至”参数为结构附件关联中的附件要素。</para>
		/// <para>交汇点-边连通性—创建边-交汇点规则，允许边和交汇点要素通过几何重叠进行连接（要素位于相同的 x,y,z 位置）。</para>
		/// <para>边-交汇点-边连通性—创建边-交汇点-边连通性规则，允许边连接到交汇点要素的任一侧。</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>From Table</para>
		/// <para>将包括在规则中的“自”公共设施网络要素类或表。</para>
		/// <para>结构附件和包含关联规则要求容器或结构要素在此参数中。</para>
		/// <para>交汇点-交汇点、交汇点-边和边-交汇点-边连通性规则的顺序不重要。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromClass { get; set; }

		/// <summary>
		/// <para>From Asset Group</para>
		/// <para>要应用规则的自表的资产组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromAssetgroup { get; set; }

		/// <summary>
		/// <para>From Asset Type</para>
		/// <para>要应用规则的自表的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromAssettype { get; set; }

		/// <summary>
		/// <para>To Table</para>
		/// <para>将包括在规则中的“至”公共设施网络要素类或表。</para>
		/// <para>结构附件和包含关联规则要求内容或附件要素在此参数中。</para>
		/// <para>交汇点-交汇点、交汇点-边和边-交汇点-边连通性规则的顺序不重要。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToClass { get; set; }

		/// <summary>
		/// <para>To Asset Group</para>
		/// <para>要应用规则的至表的资产组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToAssetgroup { get; set; }

		/// <summary>
		/// <para>To Asset Type</para>
		/// <para>要应用规则的至表的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToAssettype { get; set; }

		/// <summary>
		/// <para>From Terminal</para>
		/// <para>要应用规则的“自”终端。该终端为自表中的终端。为具有终端的要素创建连通性规则以连接到另一个要素时，必须指定连接自的终端侧，例如变压器上的高压侧终端。</para>
		/// <para>如果资产类型包括终端，则此参数为必填项。在规则类型参数中指定结构附件或包含关联规则时，它将处于禁用状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FromTerminal { get; set; }

		/// <summary>
		/// <para>To Terminal</para>
		/// <para>要应用规则的“至”终端。该终端为至表中的终端。为要素创建连通性规则以连接到另一个要素时，必须指定连接到的终端侧，例如变压器上的高压侧终端。</para>
		/// <para>如果资产类型包括终端，则此参数为必填项。如果为结构附件或包含关联规则类型，则将禁用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ToTerminal { get; set; }

		/// <summary>
		/// <para>Via Table</para>
		/// <para>要应用规则的交汇点公共设施网络要素类或表。仅在为规则类型参数选择边-交汇点-边连通性时，此参数才可用，因为需要三个要素类或表参与边-交汇点-边连通性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaClass { get; set; }

		/// <summary>
		/// <para>Via Asset Group</para>
		/// <para>要应用规则的通过表的资产组。仅在为规则类型参数选择边-交汇点-边连通性时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaAssetgroup { get; set; }

		/// <summary>
		/// <para>Via Asset Type</para>
		/// <para>要应用规则的通过表的资产类型。仅在为规则类型参数选择边-交汇点-边连通性时，此参数才可用</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaAssettype { get; set; }

		/// <summary>
		/// <para>Via Terminal</para>
		/// <para>要应用规则的通过表的终端。仅在为规则类型参数选择边-交汇点-边连通性时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaTerminal { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>交汇点-交汇点连通性—创建交汇点-交汇点连通性关联规则，允许两点通过连通性进行连接（要素会发生几何偏移）。</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("交汇点-交汇点连通性")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通性—创建边-交汇点规则，允许边和交汇点要素通过几何重叠进行连接（要素位于相同的 x,y,z 位置）。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("交汇点-边连通性")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>包含—创建包含规则，其中“自”参数为容器，“至”参数为包含关联中的内容。</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("包含")]
			Containment,

			/// <summary>
			/// <para>结构附件—创建结构附件规则，其中“自”参数为结构要素，“至”参数为结构附件关联中的附件要素。</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("结构附件")]
			Structural_attachment,

			/// <summary>
			/// <para>边-交汇点-边连通性—创建边-交汇点-边连通性规则，允许边连接到交汇点要素的任一侧。</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("边-交汇点-边连通性")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
