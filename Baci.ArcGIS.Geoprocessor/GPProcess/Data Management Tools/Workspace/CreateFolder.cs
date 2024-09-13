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
	/// <para>Create Folder</para>
	/// <para>创建文件夹</para>
	/// <para>在指定位置创建文件夹。</para>
	/// </summary>
	public class CreateFolder : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>Folder Location</para>
		/// <para>要创建文件夹的磁盘位置。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Folder Name</para>
		/// <para>要创建的文件夹。</para>
		/// </param>
		public CreateFolder(object OutFolderPath, object OutName)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建文件夹</para>
		/// </summary>
		public override string DisplayName() => "创建文件夹";

		/// <summary>
		/// <para>Tool Name : CreateFolder</para>
		/// </summary>
		public override string ToolName() => "CreateFolder";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFolder</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFolder";

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
		public override object[] Parameters() => new object[] { OutFolderPath, OutName, OutFolder };

		/// <summary>
		/// <para>Folder Location</para>
		/// <para>要创建文件夹的磁盘位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Folder Name</para>
		/// <para>要创建的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFolder SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
