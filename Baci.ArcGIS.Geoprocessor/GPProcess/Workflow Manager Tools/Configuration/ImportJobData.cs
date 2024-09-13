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
	/// <para>Import Job Data</para>
	/// <para>导入作业数据</para>
	/// <para>从 Workflow Manager (Classic) 资料档案库中导入配置和作业信息到目标存储库。此工具对于设置与现有资料档案库相似的资料档案库、创建已断开连接的资料档案库副本和更改同步最为有用。</para>
	/// </summary>
	public class ImportJobData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFile">
		/// <para>Input JXL/Acknowledgement</para>
		/// <para>包含使用导出作业数据工具生成的作业和配置元素的 JXL 文件。</para>
		/// </param>
		/// <param name="InputMerge">
		/// <para>Merge</para>
		/// <para>指定将目标 Workflow Manager (Classic) 资料档案库的内容与输入配置文件的内容合并还是用输入配置文件的内容将其覆盖。</para>
		/// <para>选中 - 将目标 Workflow Manager (Classic) 数据库的内容与输入配置文件的内容合并。</para>
		/// <para>未选中 - 用输入配置文件的内容替换目标 Workflow Manager (Classic) 数据库的全部内容。</para>
		/// <para><see cref="InputMergeEnum"/></para>
		/// </param>
		public ImportJobData(object InputFile, object InputMerge)
		{
			this.InputFile = InputFile;
			this.InputMerge = InputMerge;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入作业数据</para>
		/// </summary>
		public override string DisplayName() => "导入作业数据";

		/// <summary>
		/// <para>Tool Name : ImportJobData</para>
		/// </summary>
		public override string ToolName() => "ImportJobData";

		/// <summary>
		/// <para>Tool Excute Name : wmx.ImportJobData</para>
		/// </summary>
		public override string ExcuteName() => "wmx.ImportJobData";

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
		public override object[] Parameters() => new object[] { InputFile, InputMerge, InputDatabasepath!, InputRepositoryName!, OutputStatus! };

		/// <summary>
		/// <para>Input JXL/Acknowledgement</para>
		/// <para>包含使用导出作业数据工具生成的作业和配置元素的 JXL 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jxl", "xml")]
		public object InputFile { get; set; }

		/// <summary>
		/// <para>Merge</para>
		/// <para>指定将目标 Workflow Manager (Classic) 资料档案库的内容与输入配置文件的内容合并还是用输入配置文件的内容将其覆盖。</para>
		/// <para>选中 - 将目标 Workflow Manager (Classic) 数据库的内容与输入配置文件的内容合并。</para>
		/// <para>未选中 - 用输入配置文件的内容替换目标 Workflow Manager (Classic) 数据库的全部内容。</para>
		/// <para><see cref="InputMergeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InputMerge { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>包含目标资料档案库连接信息的 Workflow Manager (Classic) 连接文件。如果未指定连接文件，将使用工程中当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Repository Name</para>
		/// <para>在 Workflow Manager (Classic) 系统设置中指定的资料档案库名称。此名称应与聚类中所有资料档案库名称不同。如果未指定资料档案库名称，将使用当前默认的 Workflow Manager (Classic) 资料档案库名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InputRepositoryName { get; set; }

		/// <summary>
		/// <para>Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputStatus { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Merge</para>
		/// </summary>
		public enum InputMergeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMBINE")]
			COMBINE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("REPLACE")]
			REPLACE,

		}

#endregion
	}
}
