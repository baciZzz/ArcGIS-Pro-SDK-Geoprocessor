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
	/// <para>删除 Reviewer 会话</para>
	/// <para>从 Reviewer 工作空间中永久删除一个或多个会话以及所有相关记录。</para>
	/// </summary>
	public class DeleteReviewerSession : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>将从中删除 Reviewer 会话的工作空间。</para>
		/// </param>
		/// <param name="Session">
		/// <para>Session</para>
		/// <para>Reviewer 会话标识符和名称。会话必须存在于 Reviewer 工作空间中，例如 Session 1 : data_qc。</para>
		/// </param>
		public DeleteReviewerSession(object ReviewerWorkspace, object Session)
		{
			this.ReviewerWorkspace = ReviewerWorkspace;
			this.Session = Session;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除 Reviewer 会话</para>
		/// </summary>
		public override string DisplayName() => "删除 Reviewer 会话";

		/// <summary>
		/// <para>Tool Name : DeleteReviewerSession</para>
		/// </summary>
		public override string ToolName() => "DeleteReviewerSession";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.DeleteReviewerSession</para>
		/// </summary>
		public override string ExcuteName() => "Reviewer.DeleteReviewerSession";

		/// <summary>
		/// <para>Toolbox Display Name : Data Reviewer Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Reviewer Tools";

		/// <summary>
		/// <para>Toolbox Alise : Reviewer</para>
		/// </summary>
		public override string ToolboxAlise() => "Reviewer";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ReviewerWorkspace, Session, Result! };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>将从中删除 Reviewer 会话的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object ReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session</para>
		/// <para>Reviewer 会话标识符和名称。会话必须存在于 Reviewer 工作空间中，例如 Session 1 : data_qc。</para>
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
		public object? Result { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteReviewerSession SetEnviroment(object? workspace = null)
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
