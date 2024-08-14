using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Upload Service Definition</para>
	/// <para>Uploads and shares a web layer, locator, web tool, or service to ArcGIS Online, ArcGIS Enterprise, or ArcGIS Server.</para>
	/// </summary>
	public class UploadServiceDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSdFile">
		/// <para>Service Definition</para>
		/// <para>The service definition file (.sd) that contains all the information needed to share a web layer, web tool, or service.</para>
		/// </param>
		/// <param name="InServer">
		/// <para>Server</para>
		/// <para>The server type. The following server types are supported:</para>
		/// <para>My Hosted Services—Use when sharing a hosted web layer to ArcGIS Online or ArcGIS Enterprise. Enter My Hosted Services for the server connection. Capitalize the first letter of each word and include a space between each word.</para>
		/// <para>HOSTING_SERVER—Use when sharing a hosted web layer to ArcGIS Online or ArcGIS Enterprise.</para>
		/// <para>URL to the ArcGIS Enterprise portal federated server—Use when sharing a web tool or map image layer to an ArcGIS Enterprise portal federated server.</para>
		/// <para>ArcGIS Server connection—Use when sharing a map or geoprocessing service to ArcGIS Server. You can use ArcGIS Server connections listed under the Servers node in the Project window, or you can browse to a folder where server connection files are stored.</para>
		/// <para>URL to ArcGIS Server—Use when sharing a map or geoprocessing service to ArcGIS Server. You can specify the URL to ArcGIS Server provided a publisher connection to ArcGIS Server has been added to the ArcGIS Pro project, and you&apos;re opening the project in the script or you&apos;re running the tool in ArcGIS Pro.</para>
		/// </param>
		public UploadServiceDefinition(object InSdFile, object InServer)
		{
			this.InSdFile = InSdFile;
			this.InServer = InServer;
		}

		/// <summary>
		/// <para>Tool Display Name : Upload Service Definition</para>
		/// </summary>
		public override string DisplayName => "Upload Service Definition";

		/// <summary>
		/// <para>Tool Name : UploadServiceDefinition</para>
		/// </summary>
		public override string ToolName => "UploadServiceDefinition";

		/// <summary>
		/// <para>Tool Excute Name : server.UploadServiceDefinition</para>
		/// </summary>
		public override string ExcuteName => "server.UploadServiceDefinition";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSdFile, InServer, InServiceName!, InCluster!, InFolderType!, InFolder!, InStartuptype!, InOverride!, InMyContents!, InPublic!, InOrganization!, InGroups!, OutSoapSvcUrl!, OutRestSvcUrl!, OutMapserviceitemid!, OutFeatserviceitemid!, OutCachedService!, OutFeatureserviceurl!, OutMapserviceurl!, OutLayeridmap!, OutStandalonetableidmap!, OutVectortileserviceid!, OutVectortileserviceurl! };

		/// <summary>
		/// <para>Service Definition</para>
		/// <para>The service definition file (.sd) that contains all the information needed to share a web layer, web tool, or service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InSdFile { get; set; }

		/// <summary>
		/// <para>Server</para>
		/// <para>The server type. The following server types are supported:</para>
		/// <para>My Hosted Services—Use when sharing a hosted web layer to ArcGIS Online or ArcGIS Enterprise. Enter My Hosted Services for the server connection. Capitalize the first letter of each word and include a space between each word.</para>
		/// <para>HOSTING_SERVER—Use when sharing a hosted web layer to ArcGIS Online or ArcGIS Enterprise.</para>
		/// <para>URL to the ArcGIS Enterprise portal federated server—Use when sharing a web tool or map image layer to an ArcGIS Enterprise portal federated server.</para>
		/// <para>ArcGIS Server connection—Use when sharing a map or geoprocessing service to ArcGIS Server. You can use ArcGIS Server connections listed under the Servers node in the Project window, or you can browse to a folder where server connection files are stored.</para>
		/// <para>URL to ArcGIS Server—Use when sharing a map or geoprocessing service to ArcGIS Server. You can specify the URL to ArcGIS Server provided a publisher connection to ArcGIS Server has been added to the ArcGIS Pro project, and you&apos;re opening the project in the script or you&apos;re running the tool in ArcGIS Pro.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEServerConnection()]
		public object InServer { get; set; }

		/// <summary>
		/// <para>Service Name</para>
		/// <para>The service name that will override the current service name specified in the service definition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Override Service Properties")]
		public object? InServiceName { get; set; }

		/// <summary>
		/// <para>Cluster</para>
		/// <para>The cluster name that will override the current cluster to which the service has been assigned. You must choose from clusters on the specified server.</para>
		/// <para>Clusters are deprecated at ArcGIS Enterprise 10.5.1. This parameter will be ignored for servers that do not support multiple clusters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object? InCluster { get; set; }

		/// <summary>
		/// <para>Folder Type</para>
		/// <para>Specifies the folder type that will be used to determine the source for the folder. The default is to get a folder from the service definition. You can also get a list of existing folders on the specified online server, or you can specify that a new folder be created once you share the web layer or service.</para>
		/// <para>New—A new folder will be created.</para>
		/// <para>Existing—An existing folder on the server will be used.</para>
		/// <para>From Service Definition—The folder in the service definition will be used. This is the default.</para>
		/// <para><see cref="InFolderTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object? InFolderType { get; set; }

		/// <summary>
		/// <para>Folder</para>
		/// <para>The folder that will be used for the web layer or service. If no folder is provided, the folder specified in the service definition will be used. If you specified New for Folder Type, use this parameter to provide a folder name. If you specified Existing for Folder Type, you can choose from the existing folders on the server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object? InFolder { get; set; }

		/// <summary>
		/// <para>Start service immediately</para>
		/// <para>Specifies whether the service will be started after sharing.</para>
		/// <para>Checked—The service will be started after sharing. This is the default.</para>
		/// <para>Unchecked—The service will not be started after sharing.</para>
		/// <para><see cref="InStartuptypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object? InStartuptype { get; set; } = "true";

		/// <summary>
		/// <para>Override service definition sharing properties</para>
		/// <para>Specifies whether the sharing properties set in the service definition will be overridden. These properties define if, and how, you are sharing the web layer or web tool with ArcGIS Online or ArcGIS Enterprise. Sharing the web layer exposes it for others to use.</para>
		/// <para>Checked—The sharing properties set in the service definition will be overridden.</para>
		/// <para>Unchecked—The sharing properties set in the service definition will not be overridden; they will be used. This is the default.</para>
		/// <para>You must be signed in to ArcGIS Online or ArcGIS Enterprise to override sharing properties.</para>
		/// <para>This parameter is not honored when sharing to ArcGIS Server.</para>
		/// <para><see cref="InOverrideEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object? InOverride { get; set; } = "false";

		/// <summary>
		/// <para>Share on ArcGIS Online</para>
		/// <para>Specifies whether web layers and web tools will be shared.</para>
		/// <para>All shared web layers and web tools are available through My Content. Even if you only want to share with a specific group in your organization, the web layer or web tool will also be shared through My Content.</para>
		/// <para>Checked—The web layer or web tool will be shared on ArcGIS Online or ArcGIS Enterprise. The web layer or web tool will be listed under My Content.</para>
		/// <para>Unchecked—The web layer or web tool will not be shared on ArcGIS Online or ArcGIS Enterprise and will be inaccessible to other ArcGIS Online or ArcGIS Enterprise users and clients on the web. This is the default.</para>
		/// <para>You must be signed in to ArcGIS Online or ArcGIS Enterprise to override sharing properties.</para>
		/// <para>This parameter is not honored when sharing to ArcGIS Server.</para>
		/// <para><see cref="InMyContentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object? InMyContents { get; set; } = "false";

		/// <summary>
		/// <para>Share With Everyone (Public)</para>
		/// <para>Specifies whether the web layer or web tool will be available to the public.</para>
		/// <para>Checked—The web layer or web tool will be available to the public.</para>
		/// <para>Unchecked—The web layer or web tool will not be available to the public. This is the default.</para>
		/// <para>You must be signed in to a portal to override sharing properties.</para>
		/// <para>This parameter is not honored when sharing to ArcGIS Server.</para>
		/// <para><see cref="InPublicEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object? InPublic { get; set; } = "false";

		/// <summary>
		/// <para>Share With Your Organization</para>
		/// <para>Specifies whether the web layer or web tool will be shared with your organization.</para>
		/// <para>Checked—The web layer or web tool will be shared with your organization.</para>
		/// <para>Unchecked—The web layer or web tool will not be shared with your organization. This is the default.</para>
		/// <para>You must be signed in to ArcGIS Online or ArcGIS Enterprise to override sharing properties.</para>
		/// <para>This parameter is not honored when sharing a map or geoprocessing service to ArcGIS Server.</para>
		/// <para><see cref="InOrganizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object? InOrganization { get; set; } = "false";

		/// <summary>
		/// <para>Share With These Groups</para>
		/// <para>Specifies whether the web layer or web tool will be shared with specified groups in your organization.</para>
		/// <para>Checked—The web layer or web tool will be shared with specified groups.</para>
		/// <para>Unchecked—The web layer or web tool will not be shared with specified groups.</para>
		/// <para>You must be signed in to ArcGIS Online or ArcGIS Enterprise to override sharing properties.</para>
		/// <para>This parameter is not honored when sharing to ArcGIS Server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object? InGroups { get; set; }

		/// <summary>
		/// <para>SOAP Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutSoapSvcUrl { get; set; }

		/// <summary>
		/// <para>REST Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutRestSvcUrl { get; set; }

		/// <summary>
		/// <para>Hosted Map Service Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutMapserviceitemid { get; set; }

		/// <summary>
		/// <para>Hosted Feature Service Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutFeatserviceitemid { get; set; }

		/// <summary>
		/// <para>Cached Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutCachedService { get; set; }

		/// <summary>
		/// <para>Feature Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutFeatureserviceurl { get; set; }

		/// <summary>
		/// <para>Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutMapserviceurl { get; set; }

		/// <summary>
		/// <para>Layer ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutLayeridmap { get; set; }

		/// <summary>
		/// <para>Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutStandalonetableidmap { get; set; }

		/// <summary>
		/// <para>Hosted Vector Tile Service Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutVectortileserviceid { get; set; }

		/// <summary>
		/// <para>Vector Tile Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutVectortileserviceurl { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Folder Type</para>
		/// </summary>
		public enum InFolderTypeEnum 
		{
			/// <summary>
			/// <para>From Service Definition—The folder in the service definition will be used. This is the default.</para>
			/// </summary>
			[GPValue("FROM_SERVICE_DEFINITION")]
			[Description("From Service Definition")]
			From_Service_Definition,

			/// <summary>
			/// <para>Existing—An existing folder on the server will be used.</para>
			/// </summary>
			[GPValue("EXISTING")]
			[Description("Existing")]
			Existing,

			/// <summary>
			/// <para>New—A new folder will be created.</para>
			/// </summary>
			[GPValue("NEW")]
			[Description("New")]
			New,

		}

		/// <summary>
		/// <para>Start service immediately</para>
		/// </summary>
		public enum InStartuptypeEnum 
		{
			/// <summary>
			/// <para>Checked—The service will be started after sharing. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("STARTED")]
			STARTED,

			/// <summary>
			/// <para>Unchecked—The service will not be started after sharing.</para>
			/// </summary>
			[GPValue("false")]
			[Description("STOPPED")]
			STOPPED,

		}

		/// <summary>
		/// <para>Override service definition sharing properties</para>
		/// </summary>
		public enum InOverrideEnum 
		{
			/// <summary>
			/// <para>Checked—The sharing properties set in the service definition will be overridden.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERRIDE_DEFINITION")]
			OVERRIDE_DEFINITION,

			/// <summary>
			/// <para>Unchecked—The sharing properties set in the service definition will not be overridden; they will be used. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("USE_DEFINITION")]
			USE_DEFINITION,

		}

		/// <summary>
		/// <para>Share on ArcGIS Online</para>
		/// </summary>
		public enum InMyContentsEnum 
		{
			/// <summary>
			/// <para>Checked—The web layer or web tool will be shared on ArcGIS Online or ArcGIS Enterprise. The web layer or web tool will be listed under My Content.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHARE_ONLINE")]
			SHARE_ONLINE,

			/// <summary>
			/// <para>Unchecked—The web layer or web tool will not be shared on ArcGIS Online or ArcGIS Enterprise and will be inaccessible to other ArcGIS Online or ArcGIS Enterprise users and clients on the web. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHARE_ONLINE")]
			NO_SHARE_ONLINE,

		}

		/// <summary>
		/// <para>Share With Everyone (Public)</para>
		/// </summary>
		public enum InPublicEnum 
		{
			/// <summary>
			/// <para>Checked—The web layer or web tool will be available to the public.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PUBLIC")]
			PUBLIC,

			/// <summary>
			/// <para>Unchecked—The web layer or web tool will not be available to the public. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRIVATE")]
			PRIVATE,

		}

		/// <summary>
		/// <para>Share With Your Organization</para>
		/// </summary>
		public enum InOrganizationEnum 
		{
			/// <summary>
			/// <para>Checked—The web layer or web tool will be shared with your organization.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHARE_ORGANIZATION")]
			SHARE_ORGANIZATION,

			/// <summary>
			/// <para>Unchecked—The web layer or web tool will not be shared with your organization. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHARE_ORGANIZATION")]
			NO_SHARE_ORGANIZATION,

		}

#endregion
	}
}
