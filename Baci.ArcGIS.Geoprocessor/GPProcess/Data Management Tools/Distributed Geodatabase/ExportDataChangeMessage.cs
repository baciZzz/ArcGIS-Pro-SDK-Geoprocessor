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
	/// <para>Export Data Change Message</para>
	/// <para>Export Data Change Message</para>
	/// <para>Creates an output delta file containing updates from an input replica.</para>
	/// </summary>
	public class ExportDataChangeMessage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Export from Replica Geodatabase</para>
		/// <para>The replica geodatabase from which the data change message will be exported. The geodatabase can be local or remote.</para>
		/// </param>
		/// <param name="OutDataChangesFile">
		/// <para>Output Data Changes File</para>
		/// <para>The output delta file.</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>The replica containing the updates to be exported.</para>
		/// </param>
		/// <param name="SwitchToReceiver">
		/// <para>Switch to Receiver once the message has been exported</para>
		/// <para>Specifies whether the replica role will be changed from a sender to a receiver. The receiver may not send replica updates until updates from the relative replica sender arrive.</para>
		/// <para>Unchecked—The replica role will not be changed. This is the default.</para>
		/// <para>Checked—The replica role will be changed from a sender to a receiver.</para>
		/// <para><see cref="SwitchToReceiverEnum"/></para>
		/// </param>
		/// <param name="IncludeUnacknowledgedChanges">
		/// <para>Include unacknowledged data changes</para>
		/// <para>Specifies whether data changes that were previously exported for which no acknowledgment message was received will be included.</para>
		/// <para>Unchecked—Data changes that were previously sent will not be included.</para>
		/// <para>Checked—All data changes that were previously exported for which no acknowledgment message was received will be included. This is the default.</para>
		/// <para><see cref="IncludeUnacknowledgedChangesEnum"/></para>
		/// </param>
		/// <param name="IncludeNewChanges">
		/// <para>Include new data changes since last export</para>
		/// <para>Specifies whether all data changes made since the last exported data change message will be included.</para>
		/// <para>Unchecked—Data changes made since the last exported data change message will not be included.</para>
		/// <para>Checked—All data changes made since the last exported data change message will be included. This is the default.</para>
		/// <para>Specifies whether all data changes made since the last exported data change message will be included.</para>
		/// <para>NO_NEW_CHANGES—Data changes made since the last exported data change message will not be included.</para>
		/// <para>NEW_CHANGES—All data changes made since the last exported data change message will be included. This is the default.</para>
		/// <para><see cref="IncludeNewChangesEnum"/></para>
		/// </param>
		public ExportDataChangeMessage(object InGeodatabase, object OutDataChangesFile, object InReplica, object SwitchToReceiver, object IncludeUnacknowledgedChanges, object IncludeNewChanges)
		{
			this.InGeodatabase = InGeodatabase;
			this.OutDataChangesFile = OutDataChangesFile;
			this.InReplica = InReplica;
			this.SwitchToReceiver = SwitchToReceiver;
			this.IncludeUnacknowledgedChanges = IncludeUnacknowledgedChanges;
			this.IncludeNewChanges = IncludeNewChanges;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Data Change Message</para>
		/// </summary>
		public override string DisplayName() => "Export Data Change Message";

		/// <summary>
		/// <para>Tool Name : ExportDataChangeMessage</para>
		/// </summary>
		public override string ToolName() => "ExportDataChangeMessage";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportDataChangeMessage</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportDataChangeMessage";

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
		public override object[] Parameters() => new object[] { InGeodatabase, OutDataChangesFile, InReplica, SwitchToReceiver, IncludeUnacknowledgedChanges, IncludeNewChanges };

		/// <summary>
		/// <para>Export from Replica Geodatabase</para>
		/// <para>The replica geodatabase from which the data change message will be exported. The geodatabase can be local or remote.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Data Changes File</para>
		/// <para>The output delta file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml", "gdb")]
		public object OutDataChangesFile { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>The replica containing the updates to be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Switch to Receiver once the message has been exported</para>
		/// <para>Specifies whether the replica role will be changed from a sender to a receiver. The receiver may not send replica updates until updates from the relative replica sender arrive.</para>
		/// <para>Unchecked—The replica role will not be changed. This is the default.</para>
		/// <para>Checked—The replica role will be changed from a sender to a receiver.</para>
		/// <para><see cref="SwitchToReceiverEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SwitchToReceiver { get; set; } = "false";

		/// <summary>
		/// <para>Include unacknowledged data changes</para>
		/// <para>Specifies whether data changes that were previously exported for which no acknowledgment message was received will be included.</para>
		/// <para>Unchecked—Data changes that were previously sent will not be included.</para>
		/// <para>Checked—All data changes that were previously exported for which no acknowledgment message was received will be included. This is the default.</para>
		/// <para><see cref="IncludeUnacknowledgedChangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeUnacknowledgedChanges { get; set; } = "true";

		/// <summary>
		/// <para>Include new data changes since last export</para>
		/// <para>Specifies whether all data changes made since the last exported data change message will be included.</para>
		/// <para>Unchecked—Data changes made since the last exported data change message will not be included.</para>
		/// <para>Checked—All data changes made since the last exported data change message will be included. This is the default.</para>
		/// <para>Specifies whether all data changes made since the last exported data change message will be included.</para>
		/// <para>NO_NEW_CHANGES—Data changes made since the last exported data change message will not be included.</para>
		/// <para>NEW_CHANGES—All data changes made since the last exported data change message will be included. This is the default.</para>
		/// <para><see cref="IncludeNewChangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeNewChanges { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportDataChangeMessage SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Switch to Receiver once the message has been exported</para>
		/// </summary>
		public enum SwitchToReceiverEnum 
		{
			/// <summary>
			/// <para>Checked—The replica role will be changed from a sender to a receiver.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SWITCH")]
			SWITCH,

			/// <summary>
			/// <para>Unchecked—The replica role will not be changed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SWITCH")]
			DO_NOT_SWITCH,

		}

		/// <summary>
		/// <para>Include unacknowledged data changes</para>
		/// </summary>
		public enum IncludeUnacknowledgedChangesEnum 
		{
			/// <summary>
			/// <para>Checked—All data changes that were previously exported for which no acknowledgment message was received will be included. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UNACKNOWLEDGED")]
			UNACKNOWLEDGED,

			/// <summary>
			/// <para>Unchecked—Data changes that were previously sent will not be included.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UNACKNOWLEDGED")]
			NO_UNACKNOWLEDGED,

		}

		/// <summary>
		/// <para>Include new data changes since last export</para>
		/// </summary>
		public enum IncludeNewChangesEnum 
		{
			/// <summary>
			/// <para>NEW_CHANGES—All data changes made since the last exported data change message will be included. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NEW_CHANGES")]
			NEW_CHANGES,

			/// <summary>
			/// <para>NO_NEW_CHANGES—Data changes made since the last exported data change message will not be included.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_NEW_CHANGES")]
			NO_NEW_CHANGES,

		}

#endregion
	}
}
