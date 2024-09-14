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
	/// <para>Delete Rule</para>
	/// <para>删除规则</para>
	/// <para>用于从公共设施网络中永久删除规则。</para>
	/// </summary>
	public class DeleteRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将移除规则的公共设施网络。</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>要删除的规则类型。</para>
		/// <para>全部—删除所有规则。</para>
		/// <para>交汇点-交汇点连通性—删除交汇点-交汇点连通性关联规则。</para>
		/// <para>包含—删除包含关联规则。</para>
		/// <para>结构附件—删除结构附件关联规则。</para>
		/// <para>交汇点-边连通性—删除交汇点-边连通性规则。</para>
		/// <para>边-交汇点-边连通性—删除边-交汇点-边连通性规则。</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		public DeleteRule(object InUtilityNetwork, object RuleType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除规则</para>
		/// </summary>
		public override string DisplayName() => "删除规则";

		/// <summary>
		/// <para>Tool Name : DeleteRule</para>
		/// </summary>
		public override string ToolName() => "DeleteRule";

		/// <summary>
		/// <para>Tool Excute Name : un.DeleteRule</para>
		/// </summary>
		public override string ExcuteName() => "un.DeleteRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, RuleDesc!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将移除规则的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>要删除的规则类型。</para>
		/// <para>全部—删除所有规则。</para>
		/// <para>交汇点-交汇点连通性—删除交汇点-交汇点连通性关联规则。</para>
		/// <para>包含—删除包含关联规则。</para>
		/// <para>结构附件—删除结构附件关联规则。</para>
		/// <para>交汇点-边连通性—删除交汇点-边连通性规则。</para>
		/// <para>边-交汇点-边连通性—删除边-交汇点-边连通性规则。</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>Rules</para>
		/// <para>指定要移除的规则。包括规则 ID 和规则的描述。可以通过浏览图层属性对话框中网络属性的规则部分找到规则 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RuleDesc { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>全部—删除所有规则。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>交汇点-交汇点连通性—删除交汇点-交汇点连通性关联规则。</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("交汇点-交汇点连通性")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通性—删除交汇点-边连通性规则。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("交汇点-边连通性")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>包含—删除包含关联规则。</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("包含")]
			Containment,

			/// <summary>
			/// <para>结构附件—删除结构附件关联规则。</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("结构附件")]
			Structural_attachment,

			/// <summary>
			/// <para>边-交汇点-边连通性—删除边-交汇点-边连通性规则。</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("边-交汇点-边连通性")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
