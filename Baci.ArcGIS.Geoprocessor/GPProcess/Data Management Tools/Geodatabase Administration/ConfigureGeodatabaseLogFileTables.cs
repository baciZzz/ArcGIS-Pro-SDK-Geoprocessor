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
	/// <para>Configure Geodatabase Log File Tables</para>
	/// <para>配置地理数据库日志文件表</para>
	/// <para>更改企业级地理数据库使用的日志文件表类型，以便维护 ArcGIS 所缓存的记录列表。</para>
	/// </summary>
	public class ConfigureGeodatabaseLogFileTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中日志文件表配置将更改。 必须由地理数据库管理员建立此连接。</para>
		/// </param>
		/// <param name="LogFileType">
		/// <para>Log File Type</para>
		/// <para>指定地理数据库将使用的日志文件表类型。</para>
		/// <para>会话日志文件—将使用选择集的基于会话的日志文件表。 基于会话的日志文件表专用于单个会话，并可能含有多个选择集。</para>
		/// <para>共享日志文件—将使用选择集的共享日志文件表。 共享日志文件表将由以相同用户身份连接的所有会话所共用。</para>
		/// <para><see cref="LogFileTypeEnum"/></para>
		/// </param>
		public ConfigureGeodatabaseLogFileTables(object InputDatabase, object LogFileType)
		{
			this.InputDatabase = InputDatabase;
			this.LogFileType = LogFileType;
		}

		/// <summary>
		/// <para>Tool Display Name : 配置地理数据库日志文件表</para>
		/// </summary>
		public override string DisplayName() => "配置地理数据库日志文件表";

		/// <summary>
		/// <para>Tool Name : ConfigureGeodatabaseLogFileTables</para>
		/// </summary>
		public override string ToolName() => "ConfigureGeodatabaseLogFileTables";

		/// <summary>
		/// <para>Tool Excute Name : management.ConfigureGeodatabaseLogFileTables</para>
		/// </summary>
		public override string ExcuteName() => "management.ConfigureGeodatabaseLogFileTables";

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
		public override object[] Parameters() => new object[] { InputDatabase, LogFileType, LogFilePoolSize, UseTempdb, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中日志文件表配置将更改。 必须由地理数据库管理员建立此连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Log File Type</para>
		/// <para>指定地理数据库将使用的日志文件表类型。</para>
		/// <para>会话日志文件—将使用选择集的基于会话的日志文件表。 基于会话的日志文件表专用于单个会话，并可能含有多个选择集。</para>
		/// <para>共享日志文件—将使用选择集的共享日志文件表。 共享日志文件表将由以相同用户身份连接的所有会话所共用。</para>
		/// <para><see cref="LogFileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LogFileType { get; set; } = "SESSION_LOG_FILE";

		/// <summary>
		/// <para>Number of pooled session-based log file tables to be owned by the administrator</para>
		/// <para>使用地理数据库管理员拥有的基于会话的日志文件表池时，数据库将使用的池中所含表的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object LogFilePoolSize { get; set; }

		/// <summary>
		/// <para>Create session-based log file tables in the TempDB database (Microsoft SQL Server only)</para>
		/// <para>从 ArcGIS 10.5 和 ArcGIS Pro 1.4 版本开始，此参数将不再适用。</para>
		/// <para><see cref="UseTempdbEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseTempdb { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConfigureGeodatabaseLogFileTables SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Log File Type</para>
		/// </summary>
		public enum LogFileTypeEnum 
		{
			/// <summary>
			/// <para>会话日志文件—将使用选择集的基于会话的日志文件表。 基于会话的日志文件表专用于单个会话，并可能含有多个选择集。</para>
			/// </summary>
			[GPValue("SESSION_LOG_FILE")]
			[Description("会话日志文件")]
			Session_log_file,

			/// <summary>
			/// <para>共享日志文件—将使用选择集的共享日志文件表。 共享日志文件表将由以相同用户身份连接的所有会话所共用。</para>
			/// </summary>
			[GPValue("SHARED_LOG_FILE")]
			[Description("共享日志文件")]
			Shared_log_file,

		}

		/// <summary>
		/// <para>Create session-based log file tables in the TempDB database (Microsoft SQL Server only)</para>
		/// </summary>
		public enum UseTempdbEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_TEMBDB")]
			USE_TEMBDB,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_USE_TEMBDB")]
			NOT_USE_TEMBDB,

		}

#endregion
	}
}
