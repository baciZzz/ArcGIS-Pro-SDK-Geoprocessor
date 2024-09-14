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
	/// <para>导入消息</para>
	/// <para>将增量文件中的变更导入复本地理数据库或将确认消息导入复本地理数据库。</para>
	/// </summary>
	public class ImportMessage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Import To Replica Geodatabase</para>
		/// <para>将接收导入消息的复本地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </param>
		/// <param name="SourceDeltaFile">
		/// <para>Import from Delta file</para>
		/// <para>将从中导入消息的文件。</para>
		/// </param>
		public ImportMessage(object InGeodatabase, object SourceDeltaFile)
		{
			this.InGeodatabase = InGeodatabase;
			this.SourceDeltaFile = SourceDeltaFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入消息</para>
		/// </summary>
		public override string DisplayName() => "导入消息";

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
		/// <para>将接收导入消息的复本地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Import from Delta file</para>
		/// <para>将从中导入消息的文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object SourceDeltaFile { get; set; }

		/// <summary>
		/// <para>Output Acknowledgement File</para>
		/// <para>将包含确认消息的文件。 导入数据变更时，还可以导出消息以确认数据变更消息的导入。 仅数据变更消息支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object? OutputAcknowledgementFile { get; set; }

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// <para>指定在导入数据变更消息时遇到冲突的情况下将如何解决冲突。</para>
		/// <para>手动解决冲突—必须在版本协调环境中手动解决冲突。</para>
		/// <para>数据库优先—冲突将自动解决，以便于数据库接收变更。</para>
		/// <para>导入变更优先—冲突将自动解决，以便于导入变更。</para>
		/// <para><see cref="ConflictPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConflictPolicy { get; set; } = "MANUAL";

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para>指定是按对象（行）还是按属性（列）检测发生冲突所需的条件。</para>
		/// <para>按对象—将按行检测冲突。</para>
		/// <para>按属性—将按列检测冲突。</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Reconcile with the Parent Version (Check-out replicas)</para>
		/// <para>指定在不存在冲突的情况下，是否在将数据变更发送到父复本后自动协调。 此参数仅对检出/检入复本有效。</para>
		/// <para>未选中 - 变更将不会与父版本协调。 这是默认设置。</para>
		/// <para>选中 - 变更将与父版本协调。</para>
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
			/// <para>手动解决冲突—必须在版本协调环境中手动解决冲突。</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("手动解决冲突")]
			Manually_resolve_conflicts,

			/// <summary>
			/// <para>导入变更优先—冲突将自动解决，以便于导入变更。</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_IMPORTED_CHANGES")]
			[Description("导入变更优先")]
			In_favor_of_imported_changes,

			/// <summary>
			/// <para>数据库优先—冲突将自动解决，以便于数据库接收变更。</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_DATABASE")]
			[Description("数据库优先")]
			In_favor_of_the_database,

		}

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para>按对象—将按行检测冲突。</para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("按对象")]
			By_object,

			/// <summary>
			/// <para>按属性—将按列检测冲突。</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("按属性")]
			By_attribute,

		}

		/// <summary>
		/// <para>Reconcile with the Parent Version (Check-out replicas)</para>
		/// </summary>
		public enum ReconcileWithParentVersionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECONCILE ")]
			RECONCILE_,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RECONCILE")]
			DO_NOT_RECONCILE,

		}

#endregion
	}
}
