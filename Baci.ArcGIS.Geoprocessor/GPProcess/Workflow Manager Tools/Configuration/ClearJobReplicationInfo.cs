using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Clear Job Replication Information</para>
	/// <para>清除作业复制信息</para>
	/// <para>删除父资料档案库中的复制信息并在群集中向所有子资料档案库发送一个 web 服务调用。因此，从参与群集的所有资料档案库中清除复制信息。</para>
	/// </summary>
	public class ClearJobReplicationInfo : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRepositoryURL">
		/// <para>Repository URL</para>
		/// <para>在服务器上定义的 Workflow Manager (Classic) Server 对象的 URL。</para>
		/// <para>例如，http://ServerName/arcgis/rest/services/ServerObjectName/WMServer。</para>
		/// </param>
		public ClearJobReplicationInfo(object InputRepositoryURL)
		{
			this.InputRepositoryURL = InputRepositoryURL;
		}

		/// <summary>
		/// <para>Tool Display Name : 清除作业复制信息</para>
		/// </summary>
		public override string DisplayName() => "清除作业复制信息";

		/// <summary>
		/// <para>Tool Name : ClearJobReplicationInfo</para>
		/// </summary>
		public override string ToolName() => "ClearJobReplicationInfo";

		/// <summary>
		/// <para>Tool Excute Name : wmx.ClearJobReplicationInfo</para>
		/// </summary>
		public override string ExcuteName() => "wmx.ClearJobReplicationInfo";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise() => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRepositoryURL, InputDatabasepath!, OutputStatus! };

		/// <summary>
		/// <para>Repository URL</para>
		/// <para>在服务器上定义的 Workflow Manager (Classic) Server 对象的 URL。</para>
		/// <para>例如，http://ServerName/arcgis/rest/services/ServerObjectName/WMServer。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputRepositoryURL { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>可自其中删除复制信息的数据库的 Workflow Manager (Classic) 连接文件 (.jtc)。如果未指定连接文件，将使用当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Clear Replication Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputStatus { get; set; }

	}
}
