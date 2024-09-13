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
	/// <para>Upgrade Workflow Database</para>
	/// <para>升级工作流数据库</para>
	/// <para>使用最新方案和配置升级现有 Workflow Manager (Classic) 数据库。Workflow Manager (Classic) 数据库用于存储工作管理系统的作业和配置信息，以及一个用于存储作业感兴趣位置 (LOI) 几何的要素类。</para>
	/// </summary>
	public class UpgradeWorkflowDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabaseConnection">
		/// <para>Input Database Connection</para>
		/// <para>Workflow Manager (Classic) 数据库企业级地理数据库连接文件的位置，其中包含 Workflow Manager (Classic) 系统表。该连接文件必须直接连接到数据库，并且应由数据库所有者建立此连接。</para>
		/// </param>
		public UpgradeWorkflowDatabase(object InputDatabaseConnection)
		{
			this.InputDatabaseConnection = InputDatabaseConnection;
		}

		/// <summary>
		/// <para>Tool Display Name : 升级工作流数据库</para>
		/// </summary>
		public override string DisplayName() => "升级工作流数据库";

		/// <summary>
		/// <para>Tool Name : UpgradeWorkflowDatabase</para>
		/// </summary>
		public override string ToolName() => "UpgradeWorkflowDatabase";

		/// <summary>
		/// <para>Tool Excute Name : wmx.UpgradeWorkflowDatabase</para>
		/// </summary>
		public override string ExcuteName() => "wmx.UpgradeWorkflowDatabase";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabaseConnection, UserStore, OutputDatabasepath };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>Workflow Manager (Classic) 数据库企业级地理数据库连接文件的位置，其中包含 Workflow Manager (Classic) 系统表。该连接文件必须直接连接到数据库，并且应由数据库所有者建立此连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabaseConnection { get; set; }

		/// <summary>
		/// <para>User Store</para>
		/// <para>指定将从中检索用户和角色的用户存储。可从门户导入用户，并将其分配至 Workflow Manager (Classic) 资料档案库中创建的角色。门户用户配置文件信息无法通过 ArcGIS Workflow Manager (Classic) Administrator 进行编辑。可使用传统选项在 Workflow Manager (Classic) 资料档案库中创建用户和角色。使用传统选项时，可从 ArcGIS Workflow Manager (Classic) Administrator 的活动目录中导入用户和角色。</para>
		/// <para>门户—从您当前登录的门户导入用户。</para>
		/// <para>传统—可使用 ArcGIS Workflow Manager (Classic) Administrator 在 Workflow Manager (Classic) 资料档案库中创建用户和角色。使用此选项时，将从活动目录导入用户和角色。这是默认设置。</para>
		/// <para><see cref="UserStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UserStore { get; set; }

		/// <summary>
		/// <para>Output Database Path (.jtc)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object OutputDatabasepath { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpgradeWorkflowDatabase SetEnviroment(object configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>User Store</para>
		/// </summary>
		public enum UserStoreEnum 
		{
			/// <summary>
			/// <para>传统—可使用 ArcGIS Workflow Manager (Classic) Administrator 在 Workflow Manager (Classic) 资料档案库中创建用户和角色。使用此选项时，将从活动目录导入用户和角色。这是默认设置。</para>
			/// </summary>
			[GPValue("TRADITIONAL")]
			[Description("传统")]
			Traditional,

			/// <summary>
			/// <para>门户—从您当前登录的门户导入用户。</para>
			/// </summary>
			[GPValue("PORTAL")]
			[Description("门户")]
			Portal,

		}

#endregion
	}
}
