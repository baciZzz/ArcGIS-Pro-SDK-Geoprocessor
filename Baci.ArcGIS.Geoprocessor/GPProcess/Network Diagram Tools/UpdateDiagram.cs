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
	/// <para>Update Diagram</para>
	/// <para>Updates one or more network diagrams that are related to a given utility network or trace network.</para>
	/// </summary>
	public class UpdateDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The input network diagram layer to update or the utility network or trace network on which the set of specified input diagram names are based to update.</para>
		/// </param>
		public UpdateDiagram(object InDiagrams)
		{
			this.InDiagrams = InDiagrams;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Diagram</para>
		/// </summary>
		public override string DisplayName() => "Update Diagram";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDiagrams, TemplateNames!, DiagramNames!, UpdateOption!, AutolayoutOption!, OutDiagrams! };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The input network diagram layer to update or the utility network or trace network on which the set of specified input diagram names are based to update.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Template Names</para>
		/// <para>The names of the templates for which the related diagrams will be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TemplateNames { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// <para>The names of the diagrams to be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? DiagramNames { get; set; }

		/// <summary>
		/// <para>Update inconsistent diagrams only</para>
		/// <para>Specifies whether to update only diagrams that are inconsistent (the default) or all diagrams regardless of their consistency state.</para>
		/// <para>Checked—Only diagrams that are inconsistent will be updated. This is the default.</para>
		/// <para>Unchecked—Both consistent and inconsistent diagrams will be updated.</para>
		/// <para><see cref="UpdateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? UpdateOption { get; set; } = "true";

		/// <summary>
		/// <para>Re-apply automatic layouts on the updated diagrams</para>
		/// <para>Specifies whether automatic layouts that may be configured on the template on which the diagrams are based will be reapplied during the update process. By default, when automatic layouts are specified on a template, they are not reapplied during the update process.</para>
		/// <para>Checked—The automatic layouts that are configured on the template will be reapplied to diagrams at the end of the update process.</para>
		/// <para>Unchecked—None of the automatic layouts configured on the template will be reapplied to diagrams during the update process. This is the default.</para>
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
			/// <para>Checked—Only diagrams that are inconsistent will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCONSISTENT_DIAGRAMS_ONLY")]
			INCONSISTENT_DIAGRAMS_ONLY,

			/// <summary>
			/// <para>Unchecked—Both consistent and inconsistent diagrams will be updated.</para>
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
			/// <para>Checked—The automatic layouts that are configured on the template will be reapplied to diagrams at the end of the update process.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REAPPLY_AUTOLAYOUT")]
			REAPPLY_AUTOLAYOUT,

			/// <summary>
			/// <para>Unchecked—None of the automatic layouts configured on the template will be reapplied to diagrams during the update process. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REAPPLY_AUTOLAYOUT")]
			DO_NOT_REAPPLY_AUTOLAYOUT,

		}

#endregion
	}
}
