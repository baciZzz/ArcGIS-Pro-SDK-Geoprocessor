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
	/// <para>Add Compression Layout</para>
	/// <para>添加压缩布局</para>
	/// <para>将压缩布局算法添加到输入示意图模板的布局列表中，以便在逻辑示意图构建完毕后自动执行。此工具还会针对基于该模板的任意逻辑示意图预设“压缩布局”算法参数。</para>
	/// </summary>
	public class AddCompressionLayout : AbstractGPProcess
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
		/// <para>要修改的逻辑示意图模板的名称。</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动执行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数生成任何逻辑示意图的过程中自动运行。这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
		/// <para>未选中 - 如果要对基于输入模板的任何逻辑示意图运行此算法，则还将默认加载当前为添加的布局逻辑示意图指定的所有参数值。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		public AddCompressionLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加压缩布局</para>
		/// </summary>
		public override string DisplayName() => "添加压缩布局";

		/// <summary>
		/// <para>Tool Name : AddCompressionLayout</para>
		/// </summary>
		public override string ToolName() => "AddCompressionLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddCompressionLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddCompressionLayout";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved, GroupingDistanceAbsolute, VerticesRemovalRule, OutUtilityNetwork, OutTemplateName };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动执行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数生成任何逻辑示意图的过程中自动运行。这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
		/// <para>未选中 - 如果要对基于输入模板的任何逻辑示意图运行此算法，则还将默认加载当前为添加的布局逻辑示意图指定的所有参数值。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>指定压缩布局算法将如何处理容器。</para>
		/// <para>选中 - 将对逻辑示意图的上方图执行压缩布局算法，以保留容器。这是默认设置。</para>
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行压缩布局算法。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Distance for Grouping</para>
		/// <para>分组距离用于确定两个连接的交汇点是否足够近，可将其视为相同交汇点组的一部分。交汇点组表示执行期间可作为组进行移动的多个交汇点。组可包含交汇点和容器。要将两个交汇点分为一组，则必须在逻辑示意图中通过边将其相连。默认值为 20（采用逻辑示意图坐标系的单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object GroupingDistanceAbsolute { get; set; } = "20 Unknown";

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// <para>指定逻辑示意图中要移除的沿边的折点。</para>
		/// <para>所有折点—将从逻辑示意图中移除所有边上的所有折点。</para>
		/// <para>所有外部折点—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将在边与容器面的交叉点处添加折点。这是默认设置。</para>
		/// <para>所有外部折点（第一个除外）—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将保留边上与容器面相交的第一个（或最后一个）外部折点。将在边与容器面的交叉点处自动插入折点。</para>
		/// <para><see cref="VerticesRemovalRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object VerticesRemovalRule { get; set; } = "OUTER";

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutTemplateName { get; set; }

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
		/// <para>Preserve container layout</para>
		/// </summary>
		public enum AreContainersPreservedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_CONTAINERS")]
			IGNORE_CONTAINERS,

		}

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// </summary>
		public enum VerticesRemovalRuleEnum 
		{
			/// <summary>
			/// <para>所有折点—将从逻辑示意图中移除所有边上的所有折点。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有折点")]
			All_vertices,

			/// <summary>
			/// <para>所有外部折点—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将在边与容器面的交叉点处添加折点。这是默认设置。</para>
			/// </summary>
			[GPValue("OUTER")]
			[Description("所有外部折点")]
			All_outer_vertices,

			/// <summary>
			/// <para>所有外部折点（第一个除外）—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将保留边上与容器面相交的第一个（或最后一个）外部折点。将在边与容器面的交叉点处自动插入折点。</para>
			/// </summary>
			[GPValue("OUTER_EXCEPT_FIRST")]
			[Description("所有外部折点（第一个除外）")]
			All_outer_vertices_except_the_first_one,

		}

#endregion
	}
}
