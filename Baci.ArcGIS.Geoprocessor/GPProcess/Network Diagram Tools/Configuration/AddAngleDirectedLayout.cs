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
	/// <para>Add Angle Directed Layout</para>
	/// <para>添加遵循角度布局</para>
	/// <para>用于将“遵循角度”布局算法添加到基于给定模板生成逻辑示意图结束时自动进行链接的布局列表。此工具还会针对基于该模板的任意逻辑示意图预设“遵循角度”布局算法参数。</para>
	/// </summary>
	public class AddAngleDirectedLayout : AbstractGPProcess
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
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动运行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数值生成任何逻辑示意图的过程中自动运行。 这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。 如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
		/// <para>未选中 - 如果要对基于输入模板的任何逻辑示意图运行此算法，则还将默认加载当前为添加的布局逻辑示意图指定的所有参数值。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		public AddAngleDirectedLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加遵循角度布局</para>
		/// </summary>
		public override string DisplayName() => "添加遵循角度布局";

		/// <summary>
		/// <para>Tool Name : AddAngleDirectedLayout</para>
		/// </summary>
		public override string ToolName() => "AddAngleDirectedLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddAngleDirectedLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddAngleDirectedLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved!, IterationsNumber!, NumberOfDirections!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动运行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数值生成任何逻辑示意图的过程中自动运行。 这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。 如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
		/// <para>未选中 - 如果要对基于输入模板的任何逻辑示意图运行此算法，则还将默认加载当前为添加的布局逻辑示意图指定的所有参数值。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>指定算法将如何处理容器。</para>
		/// <para>选中 - 将对逻辑示意图的上方图执行布局算法，以保留容器。</para>
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行布局算法。 这是默认设置。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// <para>要处理的迭代次数。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? IterationsNumber { get; set; } = "1";

		/// <summary>
		/// <para>Number of Directions</para>
		/// <para>对齐逻辑示意图边及其连接的交汇点将使用的方向数。</para>
		/// <para>12 个方向—将移动边，以使其逐渐接近 12 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 30 度、60 度、90 度、120 度、150 度、180 度、210 度、240 度、270 度、300 度、330 度或 360 度）。</para>
		/// <para>8 个方向—将移动边，以使其逐渐接近 8 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 45 度、90 度、135 度、180 度、225 度、270 度、315 度或 360 度）。这是默认设置。</para>
		/// <para>4 个方向—将移动边，以使其逐渐接近 4 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 90 度、180 度、270 度或 360 度）。</para>
		/// <para><see cref="NumberOfDirectionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NumberOfDirections { get; set; } = "EIGHT_DIRECTIONS";

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
		/// <para>Number of Directions</para>
		/// </summary>
		public enum NumberOfDirectionsEnum 
		{
			/// <summary>
			/// <para>12 个方向—将移动边，以使其逐渐接近 12 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 30 度、60 度、90 度、120 度、150 度、180 度、210 度、240 度、270 度、300 度、330 度或 360 度）。</para>
			/// </summary>
			[GPValue("TWELVE_DIRECTIONS")]
			[Description("12 个方向")]
			_12_directions,

			/// <summary>
			/// <para>8 个方向—将移动边，以使其逐渐接近 8 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 45 度、90 度、135 度、180 度、225 度、270 度、315 度或 360 度）。这是默认设置。</para>
			/// </summary>
			[GPValue("EIGHT_DIRECTIONS")]
			[Description("8 个方向")]
			_8_directions,

			/// <summary>
			/// <para>4 个方向—将移动边，以使其逐渐接近 4 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 90 度、180 度、270 度或 360 度）。</para>
			/// </summary>
			[GPValue("FOUR_DIRECTIONS")]
			[Description("4 个方向")]
			_4_directions,

		}

#endregion
	}
}
