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
	/// <para>Create Reviewer Session</para>
	/// <para>Create Reviewer Session</para>
	/// <para>Creates a new Reviewer session in the specified workspace.</para>
	/// </summary>
	public class CreateReviewerSession : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>The workspace in which a new Reviewer session will be created.</para>
		/// </param>
		/// <param name="SessionName">
		/// <para>Session Name</para>
		/// <para>The name of the session that will be created in the Reviewer workspace.</para>
		/// </param>
		public CreateReviewerSession(object ReviewerWorkspace, object SessionName)
		{
			this.ReviewerWorkspace = ReviewerWorkspace;
			this.SessionName = SessionName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Reviewer Session</para>
		/// </summary>
		public override string DisplayName() => "Create Reviewer Session";

		/// <summary>
		/// <para>Tool Name : CreateReviewerSession</para>
		/// </summary>
		public override string ToolName() => "CreateReviewerSession";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.CreateReviewerSession</para>
		/// </summary>
		public override string ExcuteName() => "Reviewer.CreateReviewerSession";

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
		public override object[] Parameters() => new object[] { ReviewerWorkspace, SessionName, SessionTemplate, Session, DuplicateChecking, StoreGeometry, Username, Version };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>The workspace in which a new Reviewer session will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object ReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session Name</para>
		/// <para>The name of the session that will be created in the Reviewer workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SessionName { get; set; }

		/// <summary>
		/// <para>Session Template</para>
		/// <para>An existing Reviewer session whose properties will be copied to the new session.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SessionTemplate { get; set; }

		/// <summary>
		/// <para>Reviewer Session</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Session { get; set; }

		/// <summary>
		/// <para>Check For Duplicates</para>
		/// <para>Specifies how duplicate validation results are handled in the session.</para>
		/// <para>None—Does not search for duplicate validation results. This will improve performance when writing validation results to the database. This is the default.</para>
		/// <para>Session—Searches within the session for duplicate validation results.</para>
		/// <para>Database—Searches the entire database for duplicate validation results.</para>
		/// <para><see cref="DuplicateCheckingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DuplicateChecking { get; set; } = "NONE";

		/// <summary>
		/// <para>Do Not Store Geometry</para>
		/// <para>Specifies whether results will include an associated geometry.</para>
		/// <para>Checked—Results will include only attribute information. This can improve performance when writing validation results to the geodatabase.</para>
		/// <para>Unchecked—Results will include both geometry and attribute information. This is the default.</para>
		/// <para><see cref="StoreGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object StoreGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Session User Name</para>
		/// <para>The user name of the person creating the Reviewer session. The default is the Windows user who is currently logged in.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Username { get; set; } = "bldgis";

		/// <summary>
		/// <para>Session Version</para>
		/// <para>The enterprise geodatabase version with which the session will be associated. This parameter is only enabled when you choose a Reviewer workspace stored in an enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateReviewerSession SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Check For Duplicates</para>
		/// </summary>
		public enum DuplicateCheckingEnum 
		{
			/// <summary>
			/// <para>Database—Searches the entire database for duplicate validation results.</para>
			/// </summary>
			[GPValue("DATABASE")]
			[Description("Database")]
			Database,

			/// <summary>
			/// <para>Session—Searches within the session for duplicate validation results.</para>
			/// </summary>
			[GPValue("SESSION")]
			[Description("Session")]
			Session,

			/// <summary>
			/// <para>None—Does not search for duplicate validation results. This will improve performance when writing validation results to the database. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Do Not Store Geometry</para>
		/// </summary>
		public enum StoreGeometryEnum 
		{
			/// <summary>
			/// <para>Unchecked—Results will include both geometry and attribute information. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("STORE_GEOMETRY")]
			STORE_GEOMETRY,

			/// <summary>
			/// <para>Checked—Results will include only attribute information. This can improve performance when writing validation results to the geodatabase.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DO_NOT_STORE_GEOMETRY")]
			DO_NOT_STORE_GEOMETRY,

		}

#endregion
	}
}
