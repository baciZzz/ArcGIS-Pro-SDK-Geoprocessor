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
	/// <para>Re-export Unacknowledged Messages</para>
	/// <para>重新导出未确认的消息</para>
	/// <para>创建包含来自单向或双向复本地理数据库的未确认复本更新的输出增量文件。</para>
	/// </summary>
	public class ReExportUnacknowledgedMessages : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Export from Replica Geodatabase</para>
		/// <para>将从中重新导出未确认消息的复本地理数据库。 该地理数据库可以是本地地理数据库，也可以是地理数据服务。</para>
		/// </param>
		/// <param name="OutputDeltaFile">
		/// <para>Output Delta File</para>
		/// <para>将向其重新导出数据变更的增量文件。</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>将从中重新导出未确认消息的复本。</para>
		/// </param>
		/// <param name="InExportOption">
		/// <para>Export options</para>
		/// <para>指定将重新导出的变更。</para>
		/// <para>所有未确认—将重新导出包含未确认消息的所有变更。</para>
		/// <para>最近—仅重新导出最后一组导出变更后所做的变更。</para>
		/// <para><see cref="InExportOptionEnum"/></para>
		/// </param>
		public ReExportUnacknowledgedMessages(object InGeodatabase, object OutputDeltaFile, object InReplica, object InExportOption)
		{
			this.InGeodatabase = InGeodatabase;
			this.OutputDeltaFile = OutputDeltaFile;
			this.InReplica = InReplica;
			this.InExportOption = InExportOption;
		}

		/// <summary>
		/// <para>Tool Display Name : 重新导出未确认的消息</para>
		/// </summary>
		public override string DisplayName() => "重新导出未确认的消息";

		/// <summary>
		/// <para>Tool Name : ReExportUnacknowledgedMessages</para>
		/// </summary>
		public override string ToolName() => "ReExportUnacknowledgedMessages";

		/// <summary>
		/// <para>Tool Excute Name : management.ReExportUnacknowledgedMessages</para>
		/// </summary>
		public override string ExcuteName() => "management.ReExportUnacknowledgedMessages";

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
		public override object[] Parameters() => new object[] { InGeodatabase, OutputDeltaFile, InReplica, InExportOption };

		/// <summary>
		/// <para>Export from Replica Geodatabase</para>
		/// <para>将从中重新导出未确认消息的复本地理数据库。 该地理数据库可以是本地地理数据库，也可以是地理数据服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Delta File</para>
		/// <para>将向其重新导出数据变更的增量文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml", "gdb")]
		public object OutputDeltaFile { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>将从中重新导出未确认消息的复本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Export options</para>
		/// <para>指定将重新导出的变更。</para>
		/// <para>所有未确认—将重新导出包含未确认消息的所有变更。</para>
		/// <para>最近—仅重新导出最后一组导出变更后所做的变更。</para>
		/// <para><see cref="InExportOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InExportOption { get; set; } = "ALL_UNACKNOWLEDGED";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReExportUnacknowledgedMessages SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export options</para>
		/// </summary>
		public enum InExportOptionEnum 
		{
			/// <summary>
			/// <para>所有未确认—将重新导出包含未确认消息的所有变更。</para>
			/// </summary>
			[GPValue("ALL_UNACKNOWLEDGED")]
			[Description("所有未确认")]
			All_unacknowledged,

			/// <summary>
			/// <para>最近—仅重新导出最后一组导出变更后所做的变更。</para>
			/// </summary>
			[GPValue("MOST_RECENT")]
			[Description("最近")]
			Most_recent,

		}

#endregion
	}
}
