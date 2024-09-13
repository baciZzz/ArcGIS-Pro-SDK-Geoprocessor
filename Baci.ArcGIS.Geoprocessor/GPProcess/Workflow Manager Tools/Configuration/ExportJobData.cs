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
	/// <para>Export Job Data</para>
	/// <para>导出作业数据</para>
	/// <para>该工具将 Workflow Manager (Classic) 资料档案库导出到指定文件夹位置处的 .jxl 文件。该 .jxl 文件包含此资料档案库的所有配置信息以及所有作业的信息。通过使用导入作业数据工具，可以将 .jxl 文件导入另一个 Workflow Manager (Classic) 资料档案库。</para>
	/// </summary>
	public class ExportJobData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFolder">
		/// <para>Folder To Export To</para>
		/// <para>将从工具中输出的 JXL 文件的位置。此文件夹可位于本地或网络驱动器上。</para>
		/// </param>
		public ExportJobData(object InputFolder)
		{
			this.InputFolder = InputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出作业数据</para>
		/// </summary>
		public override string DisplayName() => "导出作业数据";

		/// <summary>
		/// <para>Tool Name : ExportJobData</para>
		/// </summary>
		public override string ToolName() => "ExportJobData";

		/// <summary>
		/// <para>Tool Excute Name : wmx.ExportJobData</para>
		/// </summary>
		public override string ExcuteName() => "wmx.ExportJobData";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFolder, InputDatabasepath!, InputRepositoryName!, InputExportSince!, InputExportUntil!, OutputStatus! };

		/// <summary>
		/// <para>Folder To Export To</para>
		/// <para>将从工具中输出的 JXL 文件的位置。此文件夹可位于本地或网络驱动器上。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InputFolder { get; set; }

		/// <summary>
		/// <para>Input Database Path (.jtc)</para>
		/// <para>待导出数据库的 Workflow Manager (Classic) 连接文件。如果未指定连接文件，将使用工程中当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Repository Name</para>
		/// <para>包含要共享的配置的 Workflow Manager (Classic) 资料档案库名称。如果未指定资料档案库名称，将使用当前默认的 Workflow Manager (Classic) 资料档案库名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InputRepositoryName { get; set; }

		/// <summary>
		/// <para>Export Since</para>
		/// <para>通过指定日期，导出的 JXL 将只包含从指定时间到当前日期范围内所发生的全部更改。输入应为 UTC 时间格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? InputExportSince { get; set; }

		/// <summary>
		/// <para>Export Until</para>
		/// <para>通过指定日期，导出的 JXL 将只包含从指定时间到导出至时间范围内所发生的全部更改。输入应为 UTC 时间格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? InputExportUntil { get; set; }

		/// <summary>
		/// <para>Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputStatus { get; set; }

	}
}
