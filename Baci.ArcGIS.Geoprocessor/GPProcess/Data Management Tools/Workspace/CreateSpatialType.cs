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
	/// <para>Create Spatial Type</para>
	/// <para>创建空间类型</para>
	/// <para>用于向 Oracle 或 PostgreSQL 数据库添加 ST_Geometry SQL 类型、子类型和函数。 这将允许您使用 ST_Geometry SQL 类型将几何存储在不包含地理数据库的数据库中。 也可使用此工具更新 Oracle 或 PostgreSQL 数据库中现有的 ST_Geometry 类型、子类型与函数。</para>
	/// </summary>
	public class CreateSpatialType : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>input_database 是连接至 Oracle 或 PostgreSQL 数据库的数据库连接文件 (.sde)。 必须以数据库管理员用户的身份进行连接；在 Oracle 中，您必须以 sys 用户的身份进行连接。</para>
		/// </param>
		/// <param name="SdeUserPassword">
		/// <para>SDE User Password</para>
		/// <para>sde 数据库用户的密码。 如果数据库中不存在 sde 用户，则将创建用户并使用提供的密码。 将强制实行基础数据库的密码策略。 如果 sde 用户存在于数据库或数据库集群中，则此密码必须与现有密码匹配。</para>
		/// </param>
		public CreateSpatialType(object InputDatabase, object SdeUserPassword)
		{
			this.InputDatabase = InputDatabase;
			this.SdeUserPassword = SdeUserPassword;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建空间类型</para>
		/// </summary>
		public override string DisplayName() => "创建空间类型";

		/// <summary>
		/// <para>Tool Name : CreateSpatialType</para>
		/// </summary>
		public override string ToolName() => "CreateSpatialType";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateSpatialType</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateSpatialType";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabase, SdeUserPassword, TablespaceName!, StShapeLibraryPath!, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>input_database 是连接至 Oracle 或 PostgreSQL 数据库的数据库连接文件 (.sde)。 必须以数据库管理员用户的身份进行连接；在 Oracle 中，您必须以 sys 用户的身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>SDE User Password</para>
		/// <para>sde 数据库用户的密码。 如果数据库中不存在 sde 用户，则将创建用户并使用提供的密码。 将强制实行基础数据库的密码策略。 如果 sde 用户存在于数据库或数据库集群中，则此密码必须与现有密码匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPEncryptedString()]
		public object SdeUserPassword { get; set; }

		/// <summary>
		/// <para>Tablespace Name</para>
		/// <para>将被设置为 Oracle 中 .sde 用户的默认表空间的表空间名称。 如果表空间名称不存在，则将在 Oracle 默认存储位置创建表空间。 如果具有指定名称的表空间确实存在，它将被设置为 sde 用户的默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TablespaceName { get; set; }

		/// <summary>
		/// <para>ST_Geometry Shape Library Path</para>
		/// <para>st_shape 库所在的 Oracle 服务器上的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("dll", "so")]
		public object? StShapeLibraryPath { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

	}
}
