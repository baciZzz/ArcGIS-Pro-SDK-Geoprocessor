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
	/// <para>Update Diagram</para>
	/// <para>Update Network Diagram</para>
	/// </summary>
	[Obsolete()]
	public class UpdateDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// </param>
		public UpdateDiagram(object InDiagrams)
		{
			this.InDiagrams = InDiagrams;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Diagram</para>
		/// </summary>
		public override string DisplayName => "Update Diagram";

		/// <summary>
		/// <para>Tool Name : UpdateDiagram</para>
		/// </summary>
		public override string ToolName => "UpdateDiagram";

		/// <summary>
		/// <para>Tool Excute Name : un.UpdateDiagram</para>
		/// </summary>
		public override string ExcuteName => "un.UpdateDiagram";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDiagrams, TemplateNames!, DiagramNames!, UpdateOption!, AutolayoutOption!, OutDiagrams! };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Template Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TemplateNames { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? DiagramNames { get; set; }

		/// <summary>
		/// <para>Update inconsistent diagrams only</para>
		/// <para><see cref="UpdateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? UpdateOption { get; set; } = "true";

		/// <summary>
		/// <para>Re-apply automatic layouts on the updated diagrams</para>
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
