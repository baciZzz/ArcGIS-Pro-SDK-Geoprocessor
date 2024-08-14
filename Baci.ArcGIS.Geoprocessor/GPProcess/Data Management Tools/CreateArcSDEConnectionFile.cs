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
	/// <para>Create ArcSDE Connection File</para>
	/// <para>Create a connection file to an ArcSDE workspace</para>
	/// </summary>
	[Obsolete()]
	public class CreateArcSDEConnectionFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>ArcSDE Connection File Location</para>
		/// </param>
		/// <param name="OutName">
		/// <para>ArcSDE Connection File Name</para>
		/// </param>
		/// <param name="Server">
		/// <para>Server</para>
		/// </param>
		/// <param name="Service">
		/// <para>Service</para>
		/// </param>
		public CreateArcSDEConnectionFile(object OutFolderPath, object OutName, object Server, object Service)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
			this.Server = Server;
			this.Service = Service;
		}

		/// <summary>
		/// <para>Tool Display Name : Create ArcSDE Connection File</para>
		/// </summary>
		public override string DisplayName => "Create ArcSDE Connection File";

		/// <summary>
		/// <para>Tool Name : CreateArcSDEConnectionFile</para>
		/// </summary>
		public override string ToolName => "CreateArcSDEConnectionFile";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateArcSDEConnectionFile</para>
		/// </summary>
		public override string ExcuteName => "management.CreateArcSDEConnectionFile";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutFolderPath, OutName, Server, Service, Database!, AccountAuthentication!, Username!, Password!, SaveUsernamePassword!, Version!, SaveVersionInfo!, ConnectionFileName };

		/// <summary>
		/// <para>ArcSDE Connection File Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>ArcSDE Connection File Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Server</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Server { get; set; }

		/// <summary>
		/// <para>Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Service { get; set; }

		/// <summary>
		/// <para>Database</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Database { get; set; }

		/// <summary>
		/// <para>Database authentication</para>
		/// <para><see cref="AccountAuthenticationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AccountAuthentication { get; set; } = "true";

		/// <summary>
		/// <para>Username</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? Password { get; set; }

		/// <summary>
		/// <para>Save username and password</para>
		/// <para><see cref="SaveUsernamePasswordEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SaveUsernamePassword { get; set; } = "true";

		/// <summary>
		/// <para>The following transactional version will be used</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Version { get; set; }

		/// <summary>
		/// <para>Save the transactional version name with the connection file</para>
		/// <para><see cref="SaveVersionInfoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SaveVersionInfo { get; set; } = "true";

		/// <summary>
		/// <para>Connection File Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? ConnectionFileName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Database authentication</para>
		/// </summary>
		public enum AccountAuthenticationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DATABASE_AUTH")]
			DATABASE_AUTH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("OPERATING_SYSTEM_AUTH")]
			OPERATING_SYSTEM_AUTH,

		}

		/// <summary>
		/// <para>Save username and password</para>
		/// </summary>
		public enum SaveUsernamePasswordEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_USERNAME")]
			SAVE_USERNAME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SAVE_USERNAME")]
			DO_NOT_SAVE_USERNAME,

		}

		/// <summary>
		/// <para>Save the transactional version name with the connection file</para>
		/// </summary>
		public enum SaveVersionInfoEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_VERSION")]
			SAVE_VERSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SAVE_VERSION")]
			DO_NOT_SAVE_VERSION,

		}

#endregion
	}
}
