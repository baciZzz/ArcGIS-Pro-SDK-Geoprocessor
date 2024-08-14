using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataReviewerTools
{
	/// <summary>
	/// <para>Delete Reviewer Session</para>
	/// <para>Permanently deletes one or more sessions and all related records from a Reviewer workspace.</para>
	/// </summary>
	public class DeleteReviewerSession : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>The workspace from which the Reviewer session will be deleted.</para>
		/// </param>
		/// <param name="Session">
		/// <para>Session</para>
		/// <para>The Reviewer session identifier and name. The session must exist in the Reviewer workspace, for example, Session 1 : data_qc.</para>
		/// </param>
		public DeleteReviewerSession(object ReviewerWorkspace, object Session)
		{
			this.ReviewerWorkspace = ReviewerWorkspace;
			this.Session = Session;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Reviewer Session</para>
		/// </summary>
		public override string DisplayName => "Delete Reviewer Session";

		/// <summary>
		/// <para>Tool Name : DeleteReviewerSession</para>
		/// </summary>
		public override string ToolName => "DeleteReviewerSession";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.DeleteReviewerSession</para>
		/// </summary>
		public override string ExcuteName => "Reviewer.DeleteReviewerSession";

		/// <summary>
		/// <para>Toolbox Display Name : Data Reviewer Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Reviewer Tools";

		/// <summary>
		/// <para>Toolbox Alise : Reviewer</para>
		/// </summary>
		public override string ToolboxAlise => "Reviewer";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { ReviewerWorkspace, Session, Result };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>The workspace from which the Reviewer session will be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object ReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session</para>
		/// <para>The Reviewer session identifier and name. The session must exist in the Reviewer workspace, for example, Session 1 : data_qc.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Session { get; set; }

		/// <summary>
		/// <para>Delete Reviewer Session Succeeded</para>
		/// <para><see cref="ResultEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Result { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteReviewerSession SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete Reviewer Session Succeeded</para>
		/// </summary>
		public enum ResultEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ERROR")]
			ERROR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SUCCESS")]
			SUCCESS,

		}

#endregion
	}
}
