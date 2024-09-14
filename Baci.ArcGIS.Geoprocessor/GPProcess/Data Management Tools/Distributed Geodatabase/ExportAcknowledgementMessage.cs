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
	/// <para>Export Acknowledgement Message</para>
	/// <para>导出确认消息</para>
	/// <para>创建输出确认文件以便确认接收到之前收到的数据变更消息。</para>
	/// </summary>
	public class ExportAcknowledgementMessage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Export from Replica Geodatabase</para>
		/// <para>指定要导出确认消息的复本地理数据库。地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </param>
		/// <param name="OutAcknowledgementFile">
		/// <para>Output Acknowledgement File</para>
		/// <para>指定要导出到的增量文件。</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>要导出确认消息的复本。</para>
		/// </param>
		public ExportAcknowledgementMessage(object InGeodatabase, object OutAcknowledgementFile, object InReplica)
		{
			this.InGeodatabase = InGeodatabase;
			this.OutAcknowledgementFile = OutAcknowledgementFile;
			this.InReplica = InReplica;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出确认消息</para>
		/// </summary>
		public override string DisplayName() => "导出确认消息";

		/// <summary>
		/// <para>Tool Name : ExportAcknowledgementMessage</para>
		/// </summary>
		public override string ToolName() => "ExportAcknowledgementMessage";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportAcknowledgementMessage</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportAcknowledgementMessage";

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
		public override object[] Parameters() => new object[] { InGeodatabase, OutAcknowledgementFile, InReplica };

		/// <summary>
		/// <para>Export from Replica Geodatabase</para>
		/// <para>指定要导出确认消息的复本地理数据库。地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Acknowledgement File</para>
		/// <para>指定要导出到的增量文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutAcknowledgementFile { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>要导出确认消息的复本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportAcknowledgementMessage SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
