using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Reconcile Versions</para>
	/// <para>Reconciles a version or multiple versions with a target version.</para>
	/// </summary>
	public class ReconcileVersions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Workspace</para>
		/// <para>The enterprise geodatabase that contains the versions to be reconciled.</para>
		/// <para>For branch versioning, this will be the feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer) or the feature layer portal item.</para>
		/// </param>
		/// <param name="ReconcileMode">
		/// <para>Reconcile Mode</para>
		/// <para>Specifies the versions that will be reconciled when the tool is executed.</para>
		/// <para>If the input is a branch workspace, the only valid option for this parameter is to reconcile all versions.</para>
		/// <para>Reconcile all versions—Reconciles edit versions with the target version. This is the default.</para>
		/// <para>Reconcile blocking versions only—Reconciles versions that are blocking the target version from compressing. This option uses the recommended reconcile order.</para>
		/// <para><see cref="ReconcileModeEnum"/></para>
		/// </param>
		public ReconcileVersions(object InputDatabase, object ReconcileMode)
		{
			this.InputDatabase = InputDatabase;
			this.ReconcileMode = ReconcileMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Reconcile Versions</para>
		/// </summary>
		public override string DisplayName() => "Reconcile Versions";

		/// <summary>
		/// <para>Tool Name : ReconcileVersions</para>
		/// </summary>
		public override string ToolName() => "ReconcileVersions";

		/// <summary>
		/// <para>Tool Excute Name : management.ReconcileVersions</para>
		/// </summary>
		public override string ExcuteName() => "management.ReconcileVersions";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabase, ReconcileMode, TargetVersion, EditVersions, AcquireLocks, AbortIfConflicts, ConflictDefinition, ConflictResolution, WithPost, WithDelete, OutLog, OutWorkspace, ProceedIfConflictsNotReviewed, ReconcileCheckoutVersions };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The enterprise geodatabase that contains the versions to be reconciled.</para>
		/// <para>For branch versioning, this will be the feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer) or the feature layer portal item.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Reconcile Mode</para>
		/// <para>Specifies the versions that will be reconciled when the tool is executed.</para>
		/// <para>If the input is a branch workspace, the only valid option for this parameter is to reconcile all versions.</para>
		/// <para>Reconcile all versions—Reconciles edit versions with the target version. This is the default.</para>
		/// <para>Reconcile blocking versions only—Reconciles versions that are blocking the target version from compressing. This option uses the recommended reconcile order.</para>
		/// <para><see cref="ReconcileModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReconcileMode { get; set; } = "ALL_VERSIONS";

		/// <summary>
		/// <para>Target Version</para>
		/// <para>The name of any version in the direct ancestry of the edit version, such as the parent version or the default version.</para>
		/// <para>It typically contains edits from other versions that you want included in the edit version.</para>
		/// <para>If the input is a branch workspace, the only valid option for this parameter is to reconcile with the default version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetVersion { get; set; }

		/// <summary>
		/// <para>Edit Versions</para>
		/// <para>The name of the edit version or versions to be reconciled with the selected target version.</para>
		/// <para>Only versions that are in the direct ancestry of the selected target version will be displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object EditVersions { get; set; }

		/// <summary>
		/// <para>Acquire Locks</para>
		/// <para>Specifies whether feature locks will be acquired.</para>
		/// <para>If the input is a branch workspace, locks are not acquired during the reconcile process.</para>
		/// <para>Checked—Locks will be acquired during the reconcile process. Use this option when the intention is to post edits. It ensures that the target version is not modified in the time between the reconcile and post operations. This is the default.</para>
		/// <para>Unchecked—Locks will not be acquired during the reconcile process. This allows multiple users to reconcile in parallel. Use this option when the edit version will not be posted to the target version because there is a possibility that the target version may be modified in the time between the reconcile and post operations.</para>
		/// <para><see cref="AcquireLocksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AcquireLocks { get; set; } = "true";

		/// <summary>
		/// <para>Abort if Conflicts Detected</para>
		/// <para>Specifies whether the reconcile process will be aborted if conflicts are found between the target version and the edit version during the reconcile process.</para>
		/// <para>Checked—The reconcile will be aborted if conflicts are found.</para>
		/// <para>Unchecked—The reconcile will not be aborted if conflicts are found. This is the default.</para>
		/// <para><see cref="AbortIfConflictsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AbortIfConflicts { get; set; } = "false";

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para>Specifies whether the conditions required for a conflict to occur are defined by object (row) or by attribute (column).</para>
		/// <para>Conflicts defined by object (by row)—Any changes to the same row or feature in the parent and child versions will conflict during reconcile. This is the default.</para>
		/// <para>Conflicts defined by attribute (by column)—Only changes to the same attribute (column) of the same row or feature in the parent and child versions will be flagged as a conflict during reconcile. Changes to different attributes will not be considered a conflict during reconcile.</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Conflict Resolution</para>
		/// <para>Specifies the resolution if a conflict is detected.</para>
		/// <para>If the input is a branch workspace, the default is to favor the edit version.</para>
		/// <para>Resolve conflicts in favor of the target version—All conflicts will be resolved in favor of the target version. This is the default for traditional versioning.</para>
		/// <para>Resolve conflicts in favor of the edit version—All conflicts will be resolved in favor of the edit version. This is the default for branch versioning.</para>
		/// <para><see cref="ConflictResolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictResolution { get; set; } = "FAVOR_TARGET_VERSION";

		/// <summary>
		/// <para>Post Versions After Reconcile</para>
		/// <para>Specifies whether the current edit session will be posted to the reconciled target version.</para>
		/// <para>Checked—The current edit version will be posted to the target version after the reconcile.</para>
		/// <para>Unchecked—The current edit version will not be posted to the target version after the reconcile. This is the default.</para>
		/// <para><see cref="WithPostEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object WithPost { get; set; } = "false";

		/// <summary>
		/// <para>Delete Versions After Post</para>
		/// <para>Specifies whether the reconciled edit version will be deleted after posting. This parameter only applies if the Post Versions After Reconcile parameter is checked.</para>
		/// <para>Checked—The current edit version that was reconciled will be deleted after being posted to the target version.</para>
		/// <para>Unchecked—The current edit version that was reconciled will not be deleted. This is the default.</para>
		/// <para><see cref="WithDeleteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object WithDelete { get; set; } = "false";

		/// <summary>
		/// <para>Reconcile Versions Log</para>
		/// <para>The name and location where the log file will be written. The log file is an ASCII file containing the contents of the geoprocessing messages.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Proceed if unreviewed conflicts are detected</para>
		/// <para>Specifies whether the reconcile will proceed if there are unreviewed conflicts that exist before starting the reconcile process. If you choose to proceed, outstanding conflicts from previous sessions will be lost upon tool execution. This parameter is only applicable to branch versioning.</para>
		/// <para>Checked—The reconcile process will proceed if outstanding conflicts have not been reviewed. This is the default.</para>
		/// <para>Unchecked—The reconcile process will not proceed if outstanding conflicts that have not been reviewed are detected.</para>
		/// <para><see cref="ProceedIfConflictsNotReviewedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProceedIfConflictsNotReviewed { get; set; } = "true";

		/// <summary>
		/// <para>Reconcile checkout replica versions</para>
		/// <para>Specifies whether the reconcile will include checkout replica versions. If you are creating a checkout replica as part of a geodatabase replication workflow, an associated version is created in the geodatabase. This option allows you to include or remove these types of versions from the list of versions to be reconciled. This parameter is not applicable for branch versioning.</para>
		/// <para>Checked—The reconcile process will include checkout replica versions. This is the default.</para>
		/// <para>Unchecked—The reconcile process will not include checkout replica versions.</para>
		/// <para><see cref="ReconcileCheckoutVersionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReconcileCheckoutVersions { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReconcileVersions SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reconcile Mode</para>
		/// </summary>
		public enum ReconcileModeEnum 
		{
			/// <summary>
			/// <para>Reconcile all versions—Reconciles edit versions with the target version. This is the default.</para>
			/// </summary>
			[GPValue("ALL_VERSIONS")]
			[Description("Reconcile all versions")]
			Reconcile_all_versions,

			/// <summary>
			/// <para>Reconcile blocking versions only—Reconciles versions that are blocking the target version from compressing. This option uses the recommended reconcile order.</para>
			/// </summary>
			[GPValue("BLOCKING_VERSIONS")]
			[Description("Reconcile blocking versions only")]
			Reconcile_blocking_versions_only,

		}

		/// <summary>
		/// <para>Acquire Locks</para>
		/// </summary>
		public enum AcquireLocksEnum 
		{
			/// <summary>
			/// <para>Checked—Locks will be acquired during the reconcile process. Use this option when the intention is to post edits. It ensures that the target version is not modified in the time between the reconcile and post operations. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCK_ACQUIRED")]
			LOCK_ACQUIRED,

			/// <summary>
			/// <para>Unchecked—Locks will not be acquired during the reconcile process. This allows multiple users to reconcile in parallel. Use this option when the edit version will not be posted to the target version because there is a possibility that the target version may be modified in the time between the reconcile and post operations.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCK_ACQUIRED")]
			NO_LOCK_ACQUIRED,

		}

		/// <summary>
		/// <para>Abort if Conflicts Detected</para>
		/// </summary>
		public enum AbortIfConflictsEnum 
		{
			/// <summary>
			/// <para>Checked—The reconcile will be aborted if conflicts are found.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ABORT_CONFLICTS")]
			ABORT_CONFLICTS,

			/// <summary>
			/// <para>Unchecked—The reconcile will not be aborted if conflicts are found. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ABORT")]
			NO_ABORT,

		}

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para>Conflicts defined by object (by row)—Any changes to the same row or feature in the parent and child versions will conflict during reconcile. This is the default.</para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("Conflicts defined by object (by row)")]
			BY_OBJECT,

			/// <summary>
			/// <para>Conflicts defined by attribute (by column)—Only changes to the same attribute (column) of the same row or feature in the parent and child versions will be flagged as a conflict during reconcile. Changes to different attributes will not be considered a conflict during reconcile.</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("Conflicts defined by attribute (by column)")]
			BY_ATTRIBUTE,

		}

		/// <summary>
		/// <para>Conflict Resolution</para>
		/// </summary>
		public enum ConflictResolutionEnum 
		{
			/// <summary>
			/// <para>Resolve conflicts in favor of the target version—All conflicts will be resolved in favor of the target version. This is the default for traditional versioning.</para>
			/// </summary>
			[GPValue("FAVOR_TARGET_VERSION")]
			[Description("Resolve conflicts in favor of the target version")]
			Resolve_conflicts_in_favor_of_the_target_version,

			/// <summary>
			/// <para>Resolve conflicts in favor of the edit version—All conflicts will be resolved in favor of the edit version. This is the default for branch versioning.</para>
			/// </summary>
			[GPValue("FAVOR_EDIT_VERSION")]
			[Description("Resolve conflicts in favor of the edit version")]
			Resolve_conflicts_in_favor_of_the_edit_version,

		}

		/// <summary>
		/// <para>Post Versions After Reconcile</para>
		/// </summary>
		public enum WithPostEnum 
		{
			/// <summary>
			/// <para>Checked—The current edit version will be posted to the target version after the reconcile.</para>
			/// </summary>
			[GPValue("true")]
			[Description("POST")]
			POST,

			/// <summary>
			/// <para>Unchecked—The current edit version will not be posted to the target version after the reconcile. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POST")]
			NO_POST,

		}

		/// <summary>
		/// <para>Delete Versions After Post</para>
		/// </summary>
		public enum WithDeleteEnum 
		{
			/// <summary>
			/// <para>Checked—The current edit version that was reconciled will be deleted after being posted to the target version.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_VERSION")]
			DELETE_VERSION,

			/// <summary>
			/// <para>Unchecked—The current edit version that was reconciled will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_VERSION")]
			KEEP_VERSION,

		}

		/// <summary>
		/// <para>Proceed if unreviewed conflicts are detected</para>
		/// </summary>
		public enum ProceedIfConflictsNotReviewedEnum 
		{
			/// <summary>
			/// <para>Checked—The reconcile process will proceed if outstanding conflicts have not been reviewed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCEED")]
			PROCEED,

			/// <summary>
			/// <para>Unchecked—The reconcile process will not proceed if outstanding conflicts that have not been reviewed are detected.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PROCEED")]
			NOT_PROCEED,

		}

		/// <summary>
		/// <para>Reconcile checkout replica versions</para>
		/// </summary>
		public enum ReconcileCheckoutVersionsEnum 
		{
			/// <summary>
			/// <para>Checked—The reconcile process will include checkout replica versions. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECONCILE")]
			RECONCILE,

			/// <summary>
			/// <para>Unchecked—The reconcile process will not include checkout replica versions.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RECONCILE")]
			DO_NOT_RECONCILE,

		}

#endregion
	}
}
