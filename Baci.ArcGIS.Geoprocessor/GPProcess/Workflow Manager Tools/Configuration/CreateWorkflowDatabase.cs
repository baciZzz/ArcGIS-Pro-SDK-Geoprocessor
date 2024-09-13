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
	/// <para>Create Workflow Database</para>
	/// <para>创建工作流数据库</para>
	/// <para>创建 Workflow Manager (Classic) 方案并将企业级地理数据库配置为 Workflow Manager (Classic) 数据库。</para>
	/// </summary>
	public class CreateWorkflowDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabaseConnection">
		/// <para>Input Database Connection</para>
		/// <para>将托管 Workflow Manager (Classic) 方案和配置的企业级地理数据库连接文件的位置。该连接文件必须直接连接到数据库，并且应由数据库所有者建立此连接。</para>
		/// </param>
		/// <param name="AOISpatialReference">
		/// <para>AOI Spatial Reference</para>
		/// <para>AOI 要素类的空间参考。可通过以下方式指定空间参考：</para>
		/// <para>选择空间参考</para>
		/// <para>选择包含要应用的空间参考的要素类或要素数据集</para>
		/// </param>
		/// <param name="ImportConfiguration">
		/// <para>Import Configuration</para>
		/// <para>指定要导入新 Workflow Manager (Classic) 数据库的 Workflow Manager (Classic) 元素。默认值为最低配置（在 Python 中为 Minimum Configuration）。</para>
		/// <para>最低配置—导入 Workflow Manager (Classic) 系统所需的基本元素。</para>
		/// <para>快速配置—包括最低配置元素以及多个元素的样本。</para>
		/// <para>自定义配置—在输入自定义配置参数中指定从预先存在的数据库中导出的 Workflow Manager (Classic) 配置文件。</para>
		/// <para><see cref="ImportConfigurationEnum"/></para>
		/// </param>
		public CreateWorkflowDatabase(object InputDatabaseConnection, object AOISpatialReference, object ImportConfiguration)
		{
			this.InputDatabaseConnection = InputDatabaseConnection;
			this.AOISpatialReference = AOISpatialReference;
			this.ImportConfiguration = ImportConfiguration;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建工作流数据库</para>
		/// </summary>
		public override string DisplayName() => "创建工作流数据库";

		/// <summary>
		/// <para>Tool Name : CreateWorkflowDatabase</para>
		/// </summary>
		public override string ToolName() => "CreateWorkflowDatabase";

		/// <summary>
		/// <para>Tool Excute Name : wmx.CreateWorkflowDatabase</para>
		/// </summary>
		public override string ExcuteName() => "wmx.CreateWorkflowDatabase";

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
		public override object[] Parameters() => new object[] { InputDatabaseConnection, AOISpatialReference, ImportConfiguration, InputCustomConfiguration, UserStore, OutputDatabasepath };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>将托管 Workflow Manager (Classic) 方案和配置的企业级地理数据库连接文件的位置。该连接文件必须直接连接到数据库，并且应由数据库所有者建立此连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabaseConnection { get; set; }

		/// <summary>
		/// <para>AOI Spatial Reference</para>
		/// <para>AOI 要素类的空间参考。可通过以下方式指定空间参考：</para>
		/// <para>选择空间参考</para>
		/// <para>选择包含要应用的空间参考的要素类或要素数据集</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object AOISpatialReference { get; set; }

		/// <summary>
		/// <para>Import Configuration</para>
		/// <para>指定要导入新 Workflow Manager (Classic) 数据库的 Workflow Manager (Classic) 元素。默认值为最低配置（在 Python 中为 Minimum Configuration）。</para>
		/// <para>最低配置—导入 Workflow Manager (Classic) 系统所需的基本元素。</para>
		/// <para>快速配置—包括最低配置元素以及多个元素的样本。</para>
		/// <para>自定义配置—在输入自定义配置参数中指定从预先存在的数据库中导出的 Workflow Manager (Classic) 配置文件。</para>
		/// <para><see cref="ImportConfigurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImportConfiguration { get; set; }

		/// <summary>
		/// <para>Input Custom Configuration</para>
		/// <para>从现有 Workflow Manager (Classic) 数据库中导出的自定义配置文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jxl")]
		public object InputCustomConfiguration { get; set; }

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
		public CreateWorkflowDatabase SetEnviroment(object configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Import Configuration</para>
		/// </summary>
		public enum ImportConfigurationEnum 
		{
			/// <summary>
			/// <para>最低配置—导入 Workflow Manager (Classic) 系统所需的基本元素。</para>
			/// </summary>
			[GPValue("Minimum Configuration")]
			[Description("最低配置")]
			Minimum_configuration,

			/// <summary>
			/// <para>快速配置—包括最低配置元素以及多个元素的样本。</para>
			/// </summary>
			[GPValue("Quick Configuration")]
			[Description("快速配置")]
			Quick_configuration,

			/// <summary>
			/// <para>自定义配置—在输入自定义配置参数中指定从预先存在的数据库中导出的 Workflow Manager (Classic) 配置文件。</para>
			/// </summary>
			[GPValue("Custom Configuration")]
			[Description("自定义配置")]
			Custom_configuration,

		}

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
