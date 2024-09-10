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
	/// <para>Reconcile Version</para>
	/// <para>Reconciles a version against another version in its lineage.</para>
	/// </summary>
	[Obsolete()]
	public class ReconcileVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The ArcSDE geodatabase containing the reconcilable version.</para>
		/// </param>
		/// <param name="VersionName">
		/// <para>Version Name</para>
		/// <para>Name of the Edit Version to be reconciled with the Target Version.</para>
		/// </param>
		/// <param name="TargetName">
		/// <para>Target Version</para>
		/// <para>Name of any version in the direct ancestry of the Edit version, such as the parent version or the default version.</para>
		/// </param>
		public ReconcileVersion(object InWorkspace, object VersionName, object TargetName)
		{
			this.InWorkspace = InWorkspace;
			this.VersionName = VersionName;
			this.TargetName = TargetName;
		}

		/// <summary>
		/// <para>Tool Display Name : Reconcile Version</para>
		/// </summary>
		public override string DisplayName() => "Reconcile Version";

		/// <summary>
		/// <para>Tool Name : ReconcileVersion</para>
		/// </summary>
		public override string ToolName() => "ReconcileVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.ReconcileVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.ReconcileVersion";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, VersionName, TargetName, ConflictDefinition, ConflictResolution, AquiredLocks, AbortIfConflicts, Post, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The ArcSDE geodatabase containing the reconcilable version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>Name of the Edit Version to be reconciled with the Target Version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object VersionName { get; set; }

		/// <summary>
		/// <para>Target Version</para>
		/// <para>Name of any version in the direct ancestry of the Edit version, such as the parent version or the default version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TargetName { get; set; }

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para>Describes the conditions required for a conflict to occur:</para>
		/// <para>Checked—Any changes to the same row or feature in the parent and child versions will conflict during reconcile. This is the default.</para>
		/// <para>Unchecked—Only changes to the same attribute of the same row or feature in the parent and child versions will be flagged as a conflict during reconcile. Changes to different attributes will not be considered a conflict during reconcile.</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Conflict Resolution</para>
		/// <para>Describes the behavior if a conflict is detected:</para>
		/// <para>Checked—For all conflicts, resolves in favor of the target version. This is the default.</para>
		/// <para>Unchecked—For all conflicts, resolves in favor of the edit version.</para>
		/// <para><see cref="ConflictResolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictResolution { get; set; } = "FAVOR_TARGET_VERSION";

		/// <summary>
		/// <para>Acquire locks during reconcile</para>
		/// <para>Determines whether feature locks will be acquired.</para>
		/// <para>Checked—Acquires locks when there is no intention of posting the edit session. This is the default.</para>
		/// <para>Unchecked—No locks are acquired and the edit session will be posted to the target version.</para>
		/// <para><see cref="AquiredLocksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AquiredLocks { get; set; } = "true";

		/// <summary>
		/// <para>Abort if conflicts</para>
		/// <para>Determines if the reconcile process should be aborted if conflicts are found between the target version and the edit version.</para>
		/// <para>Checked—Aborts the reconcile if conflicts are found.</para>
		/// <para>Unchecked—Does not abort the reconcile if conflicts are found. This is the default.</para>
		/// <para><see cref="AbortIfConflictsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AbortIfConflicts { get; set; } = "false";

		/// <summary>
		/// <para>Post version after reconcile</para>
		/// <para>Posts the current edit session to the reconciled target version.</para>
		/// <para>Checked—Current edits will be posted to the target version after the reconcile.</para>
		/// <para>Unchecked—Current edits will not be posted to the target version after the reconcile. This is the default.</para>
		/// <para><see cref="PostEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Post { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReconcileVersion SetEnviroment(object configKeyword = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("BY_OBJECT")]
			BY_OBJECT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("BY_ATTRIBUTE")]
			BY_ATTRIBUTE,

		}

		/// <summary>
		/// <para>Conflict Resolution</para>
		/// </summary>
		public enum ConflictResolutionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FAVOR_TARGET_VERSION")]
			[Description("FAVOR_TARGET_VERSION")]
			FAVOR_TARGET_VERSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FAVOR_EDIT_VERSION")]
			[Description("FAVOR_EDIT_VERSION")]
			FAVOR_EDIT_VERSION,

		}

		/// <summary>
		/// <para>Acquire locks during reconcile</para>
		/// </summary>
		public enum AquiredLocksEnum 
		{
			/// <summary>
			/// <para>Checked—Acquires locks when there is no intention of posting the edit session. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCK_ACQUIRED")]
			LOCK_ACQUIRED,

			/// <summary>
			/// <para>Unchecked—No locks are acquired and the edit session will be posted to the target version.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCK_ACQUIRED")]
			NO_LOCK_ACQUIRED,

		}

		/// <summary>
		/// <para>Abort if conflicts</para>
		/// </summary>
		public enum AbortIfConflictsEnum 
		{
			/// <summary>
			/// <para>Checked—Aborts the reconcile if conflicts are found.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ABORT_CONFLICTS")]
			ABORT_CONFLICTS,

			/// <summary>
			/// <para>Unchecked—Does not abort the reconcile if conflicts are found. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ABORT")]
			NO_ABORT,

		}

		/// <summary>
		/// <para>Post version after reconcile</para>
		/// </summary>
		public enum PostEnum 
		{
			/// <summary>
			/// <para>Checked—Current edits will be posted to the target version after the reconcile.</para>
			/// </summary>
			[GPValue("true")]
			[Description("POST")]
			POST,

			/// <summary>
			/// <para>Unchecked—Current edits will not be posted to the target version after the reconcile. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POST")]
			NO_POST,

		}

#endregion
	}
}
