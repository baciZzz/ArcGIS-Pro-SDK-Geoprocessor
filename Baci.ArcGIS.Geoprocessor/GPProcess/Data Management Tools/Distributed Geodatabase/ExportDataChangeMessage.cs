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
	/// <para>导出数据变更消息</para>
	/// <para>创建包含输入复本更新的输出增量文件。</para>
	/// </summary>
	public class ExportDataChangeMessage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Export from Replica Geodatabase</para>
		/// <para>将从中导出数据变更消息的复本地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </param>
		/// <param name="OutDataChangesFile">
		/// <para>Output Data Changes File</para>
		/// <para>输出增量文件。</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>包含要导出的更新的复本。</para>
		/// </param>
		/// <param name="SwitchToReceiver">
		/// <para>Switch to Receiver once the message has been exported</para>
		/// <para>指定复本角色是否将从发送者更改为接收者。 在来自相关复本发送者的更新到达之前，接收者可能不会发送复本更新。</para>
		/// <para>未选中 - 复本角色不会更改。 这是默认设置。</para>
		/// <para>选中 - 复本角色将从发送者更改为接收者。</para>
		/// <para><see cref="SwitchToReceiverEnum"/></para>
		/// </param>
		/// <param name="IncludeUnacknowledgedChanges">
		/// <para>Include unacknowledged data changes</para>
		/// <para>指定是否包括之前导出的未收到确认消息的数据变更。</para>
		/// <para>未选中 - 先前发送的数据变更将不包括在内。</para>
		/// <para>选中 - 将包括之前导出的未收到确认消息的数据变更。 这是默认设置。</para>
		/// <para><see cref="IncludeUnacknowledgedChangesEnum"/></para>
		/// </param>
		/// <param name="IncludeNewChanges">
		/// <para>Include new data changes since last export</para>
		/// <para>指定是否包含最后一次导出数据变更消息后所做的所有数据变更。</para>
		/// <para>未选中 - 不包含最后一次导出数据变更消息后所做的数据变更。</para>
		/// <para>选中 - 包含最后一次导出数据变更消息后所做的所有数据变更。 这是默认设置。</para>
		/// <para>指定是否包含最后一次导出数据变更消息后所做的所有数据变更。</para>
		/// <para>NO_NEW_CHANGES—不包含最后一次导出数据变更消息后所做的数据变更。</para>
		/// <para>NEW_CHANGES—包含最后一次导出数据变更消息后所做的所有数据变更。 这是默认设置。</para>
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
		/// <para>Tool Display Name : 导出数据变更消息</para>
		/// </summary>
		public override string DisplayName() => "导出数据变更消息";

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
		/// <para>将从中导出数据变更消息的复本地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Data Changes File</para>
		/// <para>输出增量文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml", "gdb")]
		public object OutDataChangesFile { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>包含要导出的更新的复本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Switch to Receiver once the message has been exported</para>
		/// <para>指定复本角色是否将从发送者更改为接收者。 在来自相关复本发送者的更新到达之前，接收者可能不会发送复本更新。</para>
		/// <para>未选中 - 复本角色不会更改。 这是默认设置。</para>
		/// <para>选中 - 复本角色将从发送者更改为接收者。</para>
		/// <para><see cref="SwitchToReceiverEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SwitchToReceiver { get; set; } = "false";

		/// <summary>
		/// <para>Include unacknowledged data changes</para>
		/// <para>指定是否包括之前导出的未收到确认消息的数据变更。</para>
		/// <para>未选中 - 先前发送的数据变更将不包括在内。</para>
		/// <para>选中 - 将包括之前导出的未收到确认消息的数据变更。 这是默认设置。</para>
		/// <para><see cref="IncludeUnacknowledgedChangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeUnacknowledgedChanges { get; set; } = "true";

		/// <summary>
		/// <para>Include new data changes since last export</para>
		/// <para>指定是否包含最后一次导出数据变更消息后所做的所有数据变更。</para>
		/// <para>未选中 - 不包含最后一次导出数据变更消息后所做的数据变更。</para>
		/// <para>选中 - 包含最后一次导出数据变更消息后所做的所有数据变更。 这是默认设置。</para>
		/// <para>指定是否包含最后一次导出数据变更消息后所做的所有数据变更。</para>
		/// <para>NO_NEW_CHANGES—不包含最后一次导出数据变更消息后所做的数据变更。</para>
		/// <para>NEW_CHANGES—包含最后一次导出数据变更消息后所做的所有数据变更。 这是默认设置。</para>
		/// <para><see cref="IncludeNewChangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeNewChanges { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportDataChangeMessage SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SWITCH")]
			SWITCH,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UNACKNOWLEDGED")]
			UNACKNOWLEDGED,

			/// <summary>
			/// <para></para>
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
			/// <para>NEW_CHANGES—包含最后一次导出数据变更消息后所做的所有数据变更。 这是默认设置。</para>
			/// </summary>
			[GPValue("true")]
			[Description("NEW_CHANGES")]
			NEW_CHANGES,

			/// <summary>
			/// <para>NO_NEW_CHANGES—不包含最后一次导出数据变更消息后所做的数据变更。</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_NEW_CHANGES")]
			NO_NEW_CHANGES,

		}

#endregion
	}
}
