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
	/// <para>Generate Licensed File Geodatabase</para>
	/// <para>生成已许可的文件地理数据库</para>
	/// <para>生成许可定义文件 (.licdef) 用于定义和限制在文件地理数据库中显示的内容。可通过创建许可文件 (*.sdlic) 并使用 ArcGIS Administrator 对其进行安装来查看经许可的文件地理数据的内容。许可文件是使用生成文件地理数据库许可工具创建的。</para>
	/// </summary>
	public class GenerateLicensedFgdb : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFgdb">
		/// <para>Input File Geodatabase</para>
		/// <para>要进行许可的未经许可的文件地理数据库。</para>
		/// </param>
		/// <param name="OutFgdb">
		/// <para>Output Licensed File Geodatabase</para>
		/// <para>要创建经许可的文件地理数据库的名称和位置。</para>
		/// </param>
		/// <param name="OutLicDef">
		/// <para>Output License Definition File</para>
		/// <para>许可定义文件。</para>
		/// </param>
		public GenerateLicensedFgdb(object InFgdb, object OutFgdb, object OutLicDef)
		{
			this.InFgdb = InFgdb;
			this.OutFgdb = OutFgdb;
			this.OutLicDef = OutLicDef;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成已许可的文件地理数据库</para>
		/// </summary>
		public override string DisplayName() => "生成已许可的文件地理数据库";

		/// <summary>
		/// <para>Tool Name : GenerateLicensedFgdb</para>
		/// </summary>
		public override string ToolName() => "GenerateLicensedFgdb";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateLicensedFgdb</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateLicensedFgdb";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFgdb, OutFgdb, OutLicDef };

		/// <summary>
		/// <para>Input File Geodatabase</para>
		/// <para>要进行许可的未经许可的文件地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object InFgdb { get; set; }

		/// <summary>
		/// <para>Output Licensed File Geodatabase</para>
		/// <para>要创建经许可的文件地理数据库的名称和位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object OutFgdb { get; set; }

		/// <summary>
		/// <para>Output License Definition File</para>
		/// <para>许可定义文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("licdef")]
		public object OutLicDef { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateLicensedFgdb SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
