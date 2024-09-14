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
	/// <para>Create Enterprise Geodatabase</para>
	/// <para>创建企业级地理数据库</para>
	/// <para>可创建数据库、存储位置，以及作为地理数据库管理员和地理数据库所有者的数据库用户。 其功能会根据具体使用的数据库管理系统而有所不同。 此工具授予地理数据库管理员创建地理数据库所需的权限，并可以在数据库中创建地理数据库。</para>
	/// </summary>
	public class CreateEnterpriseGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="DatabasePlatform">
		/// <para>Database Platform</para>
		/// <para>指定要建立连接以创建地理数据库的数据库管理系统类型。</para>
		/// <para>Oracle—将连接到 Oracle 实例。</para>
		/// <para>PostgreSQL—将连接到 PostgreSQL 数据库集群。</para>
		/// <para>SQL Server—将连接到 Microsoft SQL Server 实例。</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </param>
		/// <param name="InstanceName">
		/// <para>Instance</para>
		/// <para>实例名称。</para>
		/// <para>对于 SQL Server，请提供 SQL Server 实例名称。 不支持区分大小写或二进制排序规则 SQL Server 实例。</para>
		/// <para>对于 Oracle，请提供 TNS 名称或 Oracle Easy Connection 字符串。</para>
		/// <para>对于 PostgreSQL，请提供安装 PostgreSQL 的服务器的名称。</para>
		/// </param>
		/// <param name="AuthorizationFile">
		/// <para>Authorization File</para>
		/// <para>授权 ArcGIS Server 时创建的密钥代码文件的路径和文件名。 此文件位于 Linux 的 \\Program Files\ESRI\License&lt;release#&gt;\sysgen 文件夹或 Windows 的 /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen 目录中。 如果尚未执行此操作，则请授权 ArcGIS Server 来创建此文件。</para>
		/// <para>您可能需要从 ArcGIS Server 计算机将密钥代码文件拷贝到工具可以访问的位置。</para>
		/// </param>
		public CreateEnterpriseGeodatabase(object DatabasePlatform, object InstanceName, object AuthorizationFile)
		{
			this.DatabasePlatform = DatabasePlatform;
			this.InstanceName = InstanceName;
			this.AuthorizationFile = AuthorizationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建企业级地理数据库</para>
		/// </summary>
		public override string DisplayName() => "创建企业级地理数据库";

		/// <summary>
		/// <para>Tool Name : CreateEnterpriseGeodatabase</para>
		/// </summary>
		public override string ToolName() => "CreateEnterpriseGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateEnterpriseGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateEnterpriseGeodatabase";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { DatabasePlatform, InstanceName, DatabaseName!, AccountAuthentication!, DatabaseAdmin!, DatabaseAdminPassword!, SdeSchema!, GdbAdminName!, GdbAdminPassword!, TablespaceName!, AuthorizationFile, OutResult!, SpatialType! };

		/// <summary>
		/// <para>Database Platform</para>
		/// <para>指定要建立连接以创建地理数据库的数据库管理系统类型。</para>
		/// <para>Oracle—将连接到 Oracle 实例。</para>
		/// <para>PostgreSQL—将连接到 PostgreSQL 数据库集群。</para>
		/// <para>SQL Server—将连接到 Microsoft SQL Server 实例。</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatabasePlatform { get; set; } = "SQL_Server";

		/// <summary>
		/// <para>Instance</para>
		/// <para>实例名称。</para>
		/// <para>对于 SQL Server，请提供 SQL Server 实例名称。 不支持区分大小写或二进制排序规则 SQL Server 实例。</para>
		/// <para>对于 Oracle，请提供 TNS 名称或 Oracle Easy Connection 字符串。</para>
		/// <para>对于 PostgreSQL，请提供安装 PostgreSQL 的服务器的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InstanceName { get; set; }

		/// <summary>
		/// <para>Database</para>
		/// <para>数据库名称。</para>
		/// <para>此参数对 PostgreSQL 和 SQL Server 有效。 您可以提供现有的、预先配置的数据库名称，也可以输入此工具要创建的数据库名称。</para>
		/// <para>如果该工具在 SQL Server 中创建数据库，文件大小可与为 SQL Server 模型数据库定义的大小相同，或者对于 .mdf 文件为 500 MB，对于 .ldf 文件为 125 MB，取较大值。 .mdf 文件和 .ldf 文件均可在数据库服务器上的默认 SQL Server 位置上创建。 请勿命名数据库 sde。</para>
		/// <para>如果该工具在 PostgreSQL 中创建数据库，则其会使用 template1 数据库作为您数据库的模板。 如果您需要其他模板（例如，您需要对 PostGIS 可用的模板），您必须在运行此工具之前创建数据库或提供现有数据库的名称。 数据库名称请始终使用小写字符。 如果您使用了大写字母，则工具会将其转换为小写形式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DatabaseName { get; set; }

		/// <summary>
		/// <para>Operating System Authentication</para>
		/// <para>指定数据库连接将使用的身份验证类型。</para>
		/// <para>选中 - 将使用操作系统身份验证。 您向运行此工具的计算机提供的登录信息将用于验证数据库连接。 如果数据库管理系统没有配置为允许操作系统身份验证，则身份验证将失败。</para>
		/// <para>未选中 - 将使用数据库身份验证。 在数据库中验证身份时必须提供有效的数据库用户名和密码。 这是默认设置。 如果数据库管理系统没有配置为允许数据库身份验证，则身份验证将失败。</para>
		/// <para><see cref="AccountAuthenticationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AccountAuthentication { get; set; } = "false";

		/// <summary>
		/// <para>Database Administrator</para>
		/// <para>如果使用数据库身份验证，请指定数据库管理员用户。 对于 Oracle，请使用 sys 用户。 对于 PostgreSQL，请指定具有超级用户身份的用户。 对于 SQL Server，请指定具有 sysadmin 固定服务器角色的任何成员。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DatabaseAdmin { get; set; } = "sa";

		/// <summary>
		/// <para>Database Administrator Password</para>
		/// <para>如果使用数据库身份验证，请提供数据库管理员密码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? DatabaseAdminPassword { get; set; }

		/// <summary>
		/// <para>Sde Owned Schema</para>
		/// <para>该参数仅对 SQL Server 有效，并指定将在数据库的 sde 用户方案中还是在 dbo 方案中创建地理数据库。 。</para>
		/// <para>选中 - 地理数据库将在 sde 用户的方案中创建。</para>
		/// <para>未选中 - 您必须以实例中 dbo 用户的身份登录到 SQL Server 实例，之后系统会在数据库的 dbo 方案中创建地理数据库。</para>
		/// <para><see cref="SdeSchemaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SdeSchema { get; set; } = "true";

		/// <summary>
		/// <para>Geodatabase Administrator</para>
		/// <para>地理数据库管理员用户名称。</para>
		/// <para>如果使用的是 PostgreSQL，该值必须为 sde。 如果 sde 登录角色不存在，此工具将在数据库集群中创建该登录角色并授予其超级用户状态。 如果 sde 登录角色已存在，当其没有超级用户状态时，此工具将对其授予这一状态。 此工具还会在数据库中创建 sde 方案并向公共角色授予对该方案的使用权限。</para>
		/// <para>如果使用的是 Oracle，则值为 sde。 如果 Oracle 数据库中不存在 sde 用户，则此工具将创建用户并授予其创建和升级地理数据库以及断开用户与数据库之间连接所需的权限。 如果在 Oracle 12c 或更高版本的数据库中运行此工具，则此工具还将授予使用 Oracle Data Pump 导入数据所需的权限。 如果 sde 用户已存在，则该工具将向现有用户授予同样的权限。</para>
		/// <para>Oracle 中不再支持创建或升级用户方案地理数据库。</para>
		/// <para>如果使用的是 SQL Server 并指定了一个 sde 方案地理数据库，则该值必须为 sde。 此工具将创建 sde 登录、数据库用户和方案，并授予其创建地理数据库以及从 SQL Server 实例移除连接所需的权限。 如果指定了 dbo 方案，则不要为该参数提供值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? GdbAdminName { get; set; } = "sde";

		/// <summary>
		/// <para>Geodatabase Administrator Password</para>
		/// <para>地理数据库管理员用户的密码。 如果地理数据库管理员用户已存在于数据库管理系统中，则提供的密码必须与现有密码相匹配。 如果地理数据库管理员用户尚未存在，则为新用户提供一个有效的数据库密码。 该密码必须符合数据库强制的密码策略。</para>
		/// <para>密码是一个加密字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? GdbAdminPassword { get; set; }

		/// <summary>
		/// <para>Tablespace Name</para>
		/// <para>表空间名称。</para>
		/// <para>该参数只对 Oracle 和 PostgreSQL 数据库管理系统类型有效。 对于 Oracle，请执行以下某项操作：</para>
		/// <para>提供一个现有表空间的名称。 对于地理数据库管理员用户，此表空间将用作默认的表空间。</para>
		/// <para>为新表空间提供一个有效名称。 此工具将在 Oracle 的默认存储位置上创建一个 400 MB 的表空间，并将其设置为地理数据库管理员的默认表空间。</para>
		/// <para>将表空间留空。 此工具将在 Oracle 的默认存储位置上创建一个名为 SDE_TBS 的 400 MB 表空间。 SDE_TBS 表空间将被设置为地理数据库管理员的默认表空间。</para>
		/// <para>此工具不会在 PostgreSQL 中创建表空间。 必须为用作数据库默认表空间的现有表空间提供名称，或者将此参数留空。 如果将此参数留空，则工具将在 pg_default 表空间中创建一个数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TablespaceName { get; set; }

		/// <summary>
		/// <para>Authorization File</para>
		/// <para>授权 ArcGIS Server 时创建的密钥代码文件的路径和文件名。 此文件位于 Linux 的 \\Program Files\ESRI\License&lt;release#&gt;\sysgen 文件夹或 Windows 的 /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen 目录中。 如果尚未执行此操作，则请授权 ArcGIS Server 来创建此文件。</para>
		/// <para>您可能需要从 ArcGIS Server 计算机将密钥代码文件拷贝到工具可以访问的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object AuthorizationFile { get; set; }

		/// <summary>
		/// <para>Create Enterprise Geodatabase Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? OutResult { get; set; } = "false";

		/// <summary>
		/// <para>Spatial Type</para>
		/// <para>指定要使用的空间类型。 此项仅适用于 PostgreSQL 数据库。</para>
		/// <para>ST_Geometry—将使用 ST_Geometry 空间类型。 这是默认设置。</para>
		/// <para>POSTGIS—将使用 PostGIS 空间类型。</para>
		/// <para><see cref="SpatialTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialType { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Database Platform</para>
		/// </summary>
		public enum DatabasePlatformEnum 
		{
			/// <summary>
			/// <para>SQL Server—将连接到 Microsoft SQL Server 实例。</para>
			/// </summary>
			[GPValue("SQL_Server")]
			[Description("SQL Server")]
			SQL_Server,

			/// <summary>
			/// <para>PostgreSQL—将连接到 PostgreSQL 数据库集群。</para>
			/// </summary>
			[GPValue("PostgreSQL")]
			[Description("PostgreSQL")]
			PostgreSQL,

			/// <summary>
			/// <para>Oracle—将连接到 Oracle 实例。</para>
			/// </summary>
			[GPValue("Oracle")]
			[Description("Oracle")]
			Oracle,

		}

		/// <summary>
		/// <para>Operating System Authentication</para>
		/// </summary>
		public enum AccountAuthenticationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OPERATING_SYSTEM_AUTH")]
			OPERATING_SYSTEM_AUTH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DATABASE_AUTH")]
			DATABASE_AUTH,

		}

		/// <summary>
		/// <para>Sde Owned Schema</para>
		/// </summary>
		public enum SdeSchemaEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SDE_SCHEMA")]
			SDE_SCHEMA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DBO_SCHEMA")]
			DBO_SCHEMA,

		}

		/// <summary>
		/// <para>Spatial Type</para>
		/// </summary>
		public enum SpatialTypeEnum 
		{
			/// <summary>
			/// <para>ST_Geometry—将使用 ST_Geometry 空间类型。 这是默认设置。</para>
			/// </summary>
			[GPValue("ST_GEOMETRY")]
			[Description("ST_Geometry")]
			ST_Geometry,

			/// <summary>
			/// <para>POSTGIS—将使用 PostGIS 空间类型。</para>
			/// </summary>
			[GPValue("POSTGIS")]
			[Description("POSTGIS")]
			POSTGIS,

		}

#endregion
	}
}
