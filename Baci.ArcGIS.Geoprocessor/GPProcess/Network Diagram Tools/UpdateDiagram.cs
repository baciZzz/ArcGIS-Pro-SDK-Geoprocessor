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
	/// <para>Update Diagram</para>
	/// <para>更新逻辑示意图</para>
	/// <para>用于更新与给定 utility network or trace network 相关的一个或多个网络逻辑示意图。</para>
	/// </summary>
	public class UpdateDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>要更新的输入网络逻辑示意图图层或在更新指定输入逻辑示意图名称集时基于的公共设施网络或追踪网络。</para>
		/// </param>
		public UpdateDiagram(object InDiagrams)
		{
			this.InDiagrams = InDiagrams;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新逻辑示意图</para>
		/// </summary>
		public override string DisplayName() => "更新逻辑示意图";

		/// <summary>
		/// <para>Tool Name : UpdateDiagram</para>
		/// </summary>
		public override string ToolName() => "UpdateDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.UpdateDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.UpdateDiagram";

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
		public override object[] Parameters() => new object[] { InDiagrams, TemplateNames!, DiagramNames!, UpdateOption!, AutolayoutOption!, OutDiagrams! };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>要更新的输入网络逻辑示意图图层或在更新指定输入逻辑示意图名称集时基于的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Template Names</para>
		/// <para>要处理的相关逻辑示意图的模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TemplateNames { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// <para>要处理的逻辑示意图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? DiagramNames { get; set; }

		/// <summary>
		/// <para>Update inconsistent diagrams only</para>
		/// <para>用于指定是仅更新不一致的逻辑示意图（默认）还是更新所有逻辑示意图（无论其一致性状态如何）。</para>
		/// <para>选中 - 将仅更新不一致的逻辑示意图。这是默认设置。</para>
		/// <para>未选中 - 一致和不一致的逻辑示意图均将进行更新。</para>
		/// <para><see cref="UpdateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? UpdateOption { get; set; } = "true";

		/// <summary>
		/// <para>Re-apply automatic layouts on the updated diagrams</para>
		/// <para>指定在更新过程中是否将重新应用可在逻辑示意图所基于的模板上配置的自动布局。默认情况下，在模板上指定自动布局时，进行更新过程期间不会重新应用这些布局。</para>
		/// <para>选中 - 在模板上配置的自动布局将在更新过程结束时重新应用于逻辑示意图。</para>
		/// <para>未选中 - 在模板上配置的自动布局均不会在更新过程中重新应用于逻辑示意图。这是默认设置。</para>
		/// <para><see cref="AutolayoutOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? AutolayoutOption { get; set; } = "false";

		/// <summary>
		/// <para>Output Network or Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDiagrams { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Update inconsistent diagrams only</para>
		/// </summary>
		public enum UpdateOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCONSISTENT_DIAGRAMS_ONLY")]
			INCONSISTENT_DIAGRAMS_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL_SELECTED_DIAGRAMS")]
			ALL_SELECTED_DIAGRAMS,

		}

		/// <summary>
		/// <para>Re-apply automatic layouts on the updated diagrams</para>
		/// </summary>
		public enum AutolayoutOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REAPPLY_AUTOLAYOUT")]
			REAPPLY_AUTOLAYOUT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REAPPLY_AUTOLAYOUT")]
			DO_NOT_REAPPLY_AUTOLAYOUT,

		}

#endregion
	}
}
