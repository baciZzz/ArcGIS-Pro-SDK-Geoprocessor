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
	/// <para>Add Partial Overlapping Edges Layout</para>
	/// <para>添加部分重叠边布局</para>
	/// <para>用于将“部分重叠边布局”算法添加到基于给定模板构建逻辑示意图结束时自动进行链接的布局列表。此工具还会针对基于该模板的任意逻辑示意图预设“部分重叠边布局”算法参数。</para>
	/// </summary>
	public class AddPartialOverlappingEdgesLayout : AbstractGPProcess
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
		/// <param name="BufferWidthAbsolute">
		/// <para>Buffer Width</para>
		/// <para>在其中搜索共线边段的缓冲区的宽度。</para>
		/// </param>
		/// <param name="OffsetAbsolute">
		/// <para>Offset</para>
		/// <para>将分隔检测到的边段的距离。</para>
		/// </param>
		public AddPartialOverlappingEdgesLayout(object InUtilityNetwork, object TemplateName, object IsActive, object BufferWidthAbsolute, object OffsetAbsolute)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.BufferWidthAbsolute = BufferWidthAbsolute;
			this.OffsetAbsolute = OffsetAbsolute;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加部分重叠边布局</para>
		/// </summary>
		public override string DisplayName() => "添加部分重叠边布局";

		/// <summary>
		/// <para>Tool Name : AddPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ToolName() => "AddPartialOverlappingEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddPartialOverlappingEdgesLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, BufferWidthAbsolute, OffsetAbsolute, OptimizeEdges, OutUtilityNetwork, OutTemplateName };

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
		/// <para>Buffer Width</para>
		/// <para>在其中搜索共线边段的缓冲区的宽度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BufferWidthAbsolute { get; set; } = "1 Unknown";

		/// <summary>
		/// <para>Offset</para>
		/// <para>将分隔检测到的边段的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object OffsetAbsolute { get; set; } = "0.5 Unknown";

		/// <summary>
		/// <para>Optimize edges</para>
		/// <para>指定将如何沿边放置线段：</para>
		/// <para>选中 - 将在每组共线段中优化线段的放置。可通过重点关注其连接而非其位置来实现上述操作。可以重新放置彼此交叉的线段，以使其处于不交叉的状态。</para>
		/// <para>未选中 - 每个线段的初始位置将保留在共线段集中，并且将保留交叉。这是默认设置。</para>
		/// <para><see cref="OptimizeEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OptimizeEdges { get; set; } = "false";

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
		/// <para>Optimize edges</para>
		/// </summary>
		public enum OptimizeEdgesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OPTIMIZE_EDGES")]
			OPTIMIZE_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_OPTIMIZE_EDGES")]
			DO_NOT_OPTIMIZE_EDGES,

		}

#endregion
	}
}
