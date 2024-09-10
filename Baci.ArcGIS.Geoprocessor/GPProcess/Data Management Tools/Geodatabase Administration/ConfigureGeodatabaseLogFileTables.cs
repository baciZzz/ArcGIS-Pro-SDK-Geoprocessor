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
	/// <para>Alters the type of log file tables used by an enterprise geodatabase to maintain lists of records cached by ArcGIS.</para>
	/// </summary>
	public class ConfigureGeodatabaseLogFileTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>A database connection (.sde file) to the enterprise geodatabase where the log file table configuration will be changed. The connection must be made as the geodatabase administrator.</para>
		/// </param>
		/// <param name="LogFileType">
		/// <para>Log File Type</para>
		/// <para>Specifies the type of log file tables the geodatabase will use.</para>
		/// <para>Session log file—Session-based log file tables for selection sets will be used. Session-based log file tables are dedicated to a single session and may contain multiple selection sets.</para>
		/// <para>Shared log file—Shared log file tables for selection sets will be used. Shared log file tables are shared by all sessions that connect as the same user.</para>
		/// <para><see cref="LogFileTypeEnum"/></para>
		/// </param>
		public ConfigureGeodatabaseLogFileTables(object InputDatabase, object LogFileType)
		{
			this.InputDatabase = InputDatabase;
			this.LogFileType = LogFileType;
		}

		/// <summary>
		/// <para>Tool Display Name : Configure Geodatabase Log File Tables</para>
		/// </summary>
		public override string DisplayName() => "Configure Geodatabase Log File Tables";

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
		/// <para>A database connection (.sde file) to the enterprise geodatabase where the log file table configuration will be changed. The connection must be made as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Log File Type</para>
		/// <para>Specifies the type of log file tables the geodatabase will use.</para>
		/// <para>Session log file—Session-based log file tables for selection sets will be used. Session-based log file tables are dedicated to a single session and may contain multiple selection sets.</para>
		/// <para>Shared log file—Shared log file tables for selection sets will be used. Shared log file tables are shared by all sessions that connect as the same user.</para>
		/// <para><see cref="LogFileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LogFileType { get; set; } = "SESSION_LOG_FILE";

		/// <summary>
		/// <para>Number of pooled session-based log file tables to be owned by the administrator</para>
		/// <para>The number of tables included in the pool that the geodatabase will use if a pool of session-based log file tables owned by the geodatabase administrator is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object LogFilePoolSize { get; set; }

		/// <summary>
		/// <para>Create session-based log file tables in the TempDB database (Microsoft SQL Server only)</para>
		/// <para>This parameter is no longer applicable, starting with the ArcGIS 10.5 and ArcGIS Pro 1.4 releases.</para>
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
			/// <para>Session log file—Session-based log file tables for selection sets will be used. Session-based log file tables are dedicated to a single session and may contain multiple selection sets.</para>
			/// </summary>
			[GPValue("SESSION_LOG_FILE")]
			[Description("Session log file")]
			Session_log_file,

			/// <summary>
			/// <para>Shared log file—Shared log file tables for selection sets will be used. Shared log file tables are shared by all sessions that connect as the same user.</para>
			/// </summary>
			[GPValue("SHARED_LOG_FILE")]
			[Description("Shared log file")]
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
