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
	/// <para>Import Message</para>
	/// <para>Import Message</para>
	/// <para>Imports changes from a delta file into a replica geodatabase or imports an acknowledgment message into a replica geodatabase.</para>
	/// </summary>
	public class ImportMessage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Import To Replica Geodatabase</para>
		/// <para>The replica geodatabase that will receive the imported message. The geodatabase can be local or remote.</para>
		/// </param>
		/// <param name="SourceDeltaFile">
		/// <para>Import from Delta file</para>
		/// <para>The file from which the message will be imported.</para>
		/// </param>
		public ImportMessage(object InGeodatabase, object SourceDeltaFile)
		{
			this.InGeodatabase = InGeodatabase;
			this.SourceDeltaFile = SourceDeltaFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Message</para>
		/// </summary>
		public override string DisplayName() => "Import Message";

		/// <summary>
		/// <para>Tool Name : ImportMessage</para>
		/// </summary>
		public override string ToolName() => "ImportMessage";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportMessage</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportMessage";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeodatabase, SourceDeltaFile, OutputAcknowledgementFile!, ConflictPolicy!, ConflictDefinition!, ReconcileWithParentVersion!, OutGeodatabase! };

		/// <summary>
		/// <para>Import To Replica Geodatabase</para>
		/// <para>The replica geodatabase that will receive the imported message. The geodatabase can be local or remote.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Import from Delta file</para>
		/// <para>The file from which the message will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object SourceDeltaFile { get; set; }

		/// <summary>
		/// <para>Output Acknowledgement File</para>
		/// <para>The file that will contain the acknowledgement message. When importing data changes, you can also export a message to acknowledge the import of a data change message. This parameter is only supported for a data change message.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object? OutputAcknowledgementFile { get; set; }

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// <para>Specifies how conflicts will be resolved when they are encountered while importing a data change message.</para>
		/// <para>Manually resolve conflicts—Conflicts must be manually resolved in the versioning reconcile environment.</para>
		/// <para>In favor of the database—Conflicts will be automatically resolved in favor of the database receiving the changes.</para>
		/// <para>In favor of imported changes—Conflicts will be automatically resolved in favor of the imported changes.</para>
		/// <para><see cref="ConflictPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConflictPolicy { get; set; } = "MANUAL";

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para>Specifies whether the conditions required for a conflict to occur will be detected by object (row) or by attribute (column).</para>
		/// <para>By object—Conflicts will be detected by row.</para>
		/// <para>By attribute—Conflicts will be detected by column.</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Reconcile with the Parent Version (Check-out replicas)</para>
		/// <para>Specifies whether data changes will be automatically reconciled once they are sent to the parent replica if no conflicts are present. This parameter is only active for check-out/check-in replicas.</para>
		/// <para>Unchecked—Changes will not be reconciled with the parent version. This is the default.</para>
		/// <para>Checked—Changes will be reconciled with the parent version.</para>
		/// <para><see cref="ReconcileWithParentVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReconcileWithParentVersion { get; set; } = "false";

		/// <summary>
		/// <para>Output Replica Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportMessage SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// </summary>
		public enum ConflictPolicyEnum 
		{
			/// <summary>
			/// <para>Manually resolve conflicts—Conflicts must be manually resolved in the versioning reconcile environment.</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("Manually resolve conflicts")]
			Manually_resolve_conflicts,

			/// <summary>
			/// <para>In favor of imported changes—Conflicts will be automatically resolved in favor of the imported changes.</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_IMPORTED_CHANGES")]
			[Description("In favor of imported changes")]
			In_favor_of_imported_changes,

			/// <summary>
			/// <para>In favor of the database—Conflicts will be automatically resolved in favor of the database receiving the changes.</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_DATABASE")]
			[Description("In favor of the database")]
			In_favor_of_the_database,

		}

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para>By object—Conflicts will be detected by row.</para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("By object")]
			By_object,

			/// <summary>
			/// <para>By attribute—Conflicts will be detected by column.</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("By attribute")]
			By_attribute,

		}

		/// <summary>
		/// <para>Reconcile with the Parent Version (Check-out replicas)</para>
		/// </summary>
		public enum ReconcileWithParentVersionEnum 
		{
			/// <summary>
			/// <para>Checked—Changes will be reconciled with the parent version.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECONCILE ")]
			RECONCILE_,

			/// <summary>
			/// <para>Unchecked—Changes will not be reconciled with the parent version. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RECONCILE")]
			DO_NOT_RECONCILE,

		}

#endregion
	}
}
