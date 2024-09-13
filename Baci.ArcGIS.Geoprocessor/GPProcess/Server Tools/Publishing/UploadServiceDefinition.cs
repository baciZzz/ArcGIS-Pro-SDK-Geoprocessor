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
	/// <para>上传服务定义</para>
	/// <para>将 Web 图层、Web 工具或服务上传并共享至 ArcGIS Online、ArcGIS Enterprise 或 ArcGIS Server。</para>
	/// </summary>
	public class UploadServiceDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSdFile">
		/// <para>Service Definition</para>
		/// <para>服务定义文件 (.sd) 包含共享 Web 图层、Web 工具或服务所需的所有信息。</para>
		/// </param>
		/// <param name="InServer">
		/// <para>Server</para>
		/// <para>服务器类型。 支持的服务器类型如下：</para>
		/// <para>我的托管服务 - 将托管的 Web 图层上传并共享至 ArcGIS Online 或 ArcGIS Enterprise 时使用。 针对服务器连接，输入我的托管服务。 将每个单词的第一个字母大写，并且在每个单词之间包含空格。</para>
		/// <para>HOSTING_SERVER - 将托管的 Web 图层共享至 ArcGIS Online 或 ArcGIS Enterprise 时使用。</para>
		/// <para>ArcGIS Enterprise 门户联合服务器的 URL - 将 Web 工具或地图图像图层共享到 ArcGIS Enterprise 门户联合服务器时使用。</para>
		/// <para>ArcGIS Server 连接 - 将地图或地理处理服务共享到 ArcGIS Server 时使用。 您可以使用在工程窗口中服务器节点下列出的 ArcGIS Server 连接，也可以浏览至存储服务器连接文件的文件夹。</para>
		/// <para>ArcGIS Server 的 URL - 将地图或地理处理服务共享到 ArcGIS Server 时使用。 如果您已将 ArcGIS Server 的发布者连接添加到 ArcGIS Pro 工程，且您正使用脚本打开工程或正在 ArcGIS Pro 中运行工具，则您可以指定 ArcGIS Server 的 URL。</para>
		/// </param>
		public UploadServiceDefinition(object InSdFile, object InServer)
		{
			this.InSdFile = InSdFile;
			this.InServer = InServer;
		}

		/// <summary>
		/// <para>Tool Display Name : 上传服务定义</para>
		/// </summary>
		public override string DisplayName() => "上传服务定义";

		/// <summary>
		/// <para>Tool Name : UploadServiceDefinition</para>
		/// </summary>
		public override string ToolName() => "UploadServiceDefinition";

		/// <summary>
		/// <para>Tool Excute Name : server.UploadServiceDefinition</para>
		/// </summary>
		public override string ExcuteName() => "server.UploadServiceDefinition";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSdFile, InServer, InServiceName, InCluster, InFolderType, InFolder, InStartuptype, InOverride, InMyContents, InPublic, InOrganization, InGroups, OutSoapSvcUrl, OutRestSvcUrl, OutMapserviceitemid, OutFeatserviceitemid, OutCachedService, OutFeatureserviceurl, OutMapserviceurl, OutLayeridmap, OutStandalonetableidmap, OutVectortileserviceid, OutVectortileserviceurl };

		/// <summary>
		/// <para>Service Definition</para>
		/// <para>服务定义文件 (.sd) 包含共享 Web 图层、Web 工具或服务所需的所有信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InSdFile { get; set; }

		/// <summary>
		/// <para>Server</para>
		/// <para>服务器类型。 支持的服务器类型如下：</para>
		/// <para>我的托管服务 - 将托管的 Web 图层上传并共享至 ArcGIS Online 或 ArcGIS Enterprise 时使用。 针对服务器连接，输入我的托管服务。 将每个单词的第一个字母大写，并且在每个单词之间包含空格。</para>
		/// <para>HOSTING_SERVER - 将托管的 Web 图层共享至 ArcGIS Online 或 ArcGIS Enterprise 时使用。</para>
		/// <para>ArcGIS Enterprise 门户联合服务器的 URL - 将 Web 工具或地图图像图层共享到 ArcGIS Enterprise 门户联合服务器时使用。</para>
		/// <para>ArcGIS Server 连接 - 将地图或地理处理服务共享到 ArcGIS Server 时使用。 您可以使用在工程窗口中服务器节点下列出的 ArcGIS Server 连接，也可以浏览至存储服务器连接文件的文件夹。</para>
		/// <para>ArcGIS Server 的 URL - 将地图或地理处理服务共享到 ArcGIS Server 时使用。 如果您已将 ArcGIS Server 的发布者连接添加到 ArcGIS Pro 工程，且您正使用脚本打开工程或正在 ArcGIS Pro 中运行工具，则您可以指定 ArcGIS Server 的 URL。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEServerConnection()]
		public object InServer { get; set; }

		/// <summary>
		/// <para>Service Name</para>
		/// <para>此服务名称将覆盖服务定义中指定的当前服务名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Override Service Properties")]
		public object InServiceName { get; set; }

		/// <summary>
		/// <para>Cluster</para>
		/// <para>集群名称将覆盖已为其分配服务的当前集群。 您必须从指定服务器上的集群中选择。</para>
		/// <para>ArcGIS Enterprise 10.5.1 中已弃用了集群。 对于不支持多个集群的服务器，此参数将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object InCluster { get; set; }

		/// <summary>
		/// <para>Folder Type</para>
		/// <para>指定将用于确定文件夹来源的文件夹类型。 默认设置是从服务定义中获取文件夹。 您还可以获取指定在线服务器上的现有文件夹列表，或者您可以在共享此 Web 图层或服务时指定创建新的文件夹。</para>
		/// <para>新建—将创建新文件夹。</para>
		/// <para>现有—将使用服务器上的现有文件夹。</para>
		/// <para>从服务定义—将使用服务定义中的文件夹。 这是默认设置。</para>
		/// <para><see cref="InFolderTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object InFolderType { get; set; }

		/// <summary>
		/// <para>Folder</para>
		/// <para>Web 图层或服务所对应的文件夹。 如果未提供文件夹，则将使用服务定义中指定的文件夹 如果将文件夹类型指定为 新建，则使用此参数来提供文件夹名称。 如果将文件夹类型指定为现有，则可从服务器上的现有文件夹中选择。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Start service immediately</para>
		/// <para>指定共享后是否将启动服务。</para>
		/// <para>选中 - 该服务在共享之后启动。 这是默认设置。</para>
		/// <para>未选中 - 该服务在共享之后不会启动。</para>
		/// <para><see cref="InStartuptypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Service Properties")]
		public object InStartuptype { get; set; } = "true";

		/// <summary>
		/// <para>Override service definition sharing properties</para>
		/// <para>指定是否覆盖服务定义中设置的共享属性。 这些属性定义了您是否正在与 ArcGIS Online 或 ArcGIS Enterprise 共享 Web 图层或 Web 工具以及共享的方式。 共享 Web 图层可以让其他人使用该图层。</para>
		/// <para>选中 - 将覆盖服务定义中设置的共享属性。</para>
		/// <para>未选中 - 不覆盖服务定义中设置的共享属性。 这是默认设置。</para>
		/// <para>要覆盖共享属性，您必须登录 ArcGIS Online 或 ArcGIS Enterprise。</para>
		/// <para>共享到 ArcGIS Server 时，不支持此参数。</para>
		/// <para><see cref="InOverrideEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object InOverride { get; set; } = "false";

		/// <summary>
		/// <para>Share on ArcGIS Online</para>
		/// <para>指定是否共享 web 图层和 Web 工具。</para>
		/// <para>所有共享 Web 图层和 Web 工具均可通过我的内容提供。 即使您只想与组织中的某一特定群组共享，也可通过我的内容共享该 Web 图层或 Web 工具。</para>
		/// <para>选中 - 将在 ArcGIS Online 或 ArcGIS Enterprise 上共享 Web 图层或 Web 工具。 该 Web 图层或 Web 工具将在我的内容下列出。</para>
		/// <para>未选中 - 该 Web 图层或 Web 工具不会在 ArcGIS Online 或 ArcGIS Enterprise 上共享，因此其他 ArcGIS Online 或 ArcGIS Enterprise 用户和 Web 客户端无法对其进行访问。 这是默认设置。</para>
		/// <para>要覆盖共享属性，您必须登录 ArcGIS Online 或 ArcGIS Enterprise。</para>
		/// <para>共享到 ArcGIS Server 时，不支持此参数。</para>
		/// <para><see cref="InMyContentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object InMyContents { get; set; } = "false";

		/// <summary>
		/// <para>Share With Everyone (Public)</para>
		/// <para>指定是否向公众提供 web 图层或 Web 工具。</para>
		/// <para>选中 - 将向公众提供 web 图层或 Web 工具。</para>
		/// <para>未选中 - 不向公众提供 web 图层或 Web 工具。 这是默认设置。</para>
		/// <para>要覆盖共享属性，您必须登录门户。</para>
		/// <para>共享到 ArcGIS Server 时，不支持此参数。</para>
		/// <para><see cref="InPublicEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object InPublic { get; set; } = "false";

		/// <summary>
		/// <para>Share With Your Organization</para>
		/// <para>指定是否将 web 图层或 Web 工具与您所在的组织共享。</para>
		/// <para>选中 - 将 web 图层或 Web 工具与您所在的组织共享。</para>
		/// <para>未选中 - 不会将 web 图层或 Web 工具与您所在的组织共享。 这是默认设置。</para>
		/// <para>要覆盖共享属性，您必须登录 ArcGIS Online 或 ArcGIS Enterprise。</para>
		/// <para>将地图或地理处理服务共享到 ArcGIS Server 时不支持此参数。</para>
		/// <para><see cref="InOrganizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object InOrganization { get; set; } = "false";

		/// <summary>
		/// <para>Share With These Groups</para>
		/// <para>指定是否将 web 图层或 Web 工具与您所在组织的指定群组共享。</para>
		/// <para>选中 - 将 web 图层或 Web 工具与特定群组共享。</para>
		/// <para>未选中 - 不会将 web 图层或 Web 工具与特定群组共享。</para>
		/// <para>要覆盖共享属性，您必须登录 ArcGIS Online 或 ArcGIS Enterprise。</para>
		/// <para>共享到 ArcGIS Server 时，不支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Override Sharing Properties")]
		public object InGroups { get; set; }

		/// <summary>
		/// <para>SOAP Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutSoapSvcUrl { get; set; }

		/// <summary>
		/// <para>REST Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutRestSvcUrl { get; set; }

		/// <summary>
		/// <para>Hosted Map Service Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutMapserviceitemid { get; set; }

		/// <summary>
		/// <para>Hosted Feature Service Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutFeatserviceitemid { get; set; }

		/// <summary>
		/// <para>Cached Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutCachedService { get; set; }

		/// <summary>
		/// <para>Feature Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutFeatureserviceurl { get; set; }

		/// <summary>
		/// <para>Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutMapserviceurl { get; set; }

		/// <summary>
		/// <para>Layer ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutLayeridmap { get; set; }

		/// <summary>
		/// <para>Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutStandalonetableidmap { get; set; }

		/// <summary>
		/// <para>Hosted Vector Tile Service Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutVectortileserviceid { get; set; }

		/// <summary>
		/// <para>Vector Tile Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutVectortileserviceurl { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Folder Type</para>
		/// </summary>
		public enum InFolderTypeEnum 
		{
			/// <summary>
			/// <para>从服务定义—将使用服务定义中的文件夹。 这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_SERVICE_DEFINITION")]
			[Description("从服务定义")]
			From_Service_Definition,

			/// <summary>
			/// <para>现有—将使用服务器上的现有文件夹。</para>
			/// </summary>
			[GPValue("EXISTING")]
			[Description("现有")]
			Existing,

			/// <summary>
			/// <para>新建—将创建新文件夹。</para>
			/// </summary>
			[GPValue("NEW")]
			[Description("新建")]
			New,

		}

		/// <summary>
		/// <para>Start service immediately</para>
		/// </summary>
		public enum InStartuptypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("STARTED")]
			STARTED,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERRIDE_DEFINITION")]
			OVERRIDE_DEFINITION,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHARE_ONLINE")]
			SHARE_ONLINE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PUBLIC")]
			PUBLIC,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHARE_ORGANIZATION")]
			SHARE_ORGANIZATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHARE_ORGANIZATION")]
			NO_SHARE_ORGANIZATION,

		}

#endregion
	}
}
