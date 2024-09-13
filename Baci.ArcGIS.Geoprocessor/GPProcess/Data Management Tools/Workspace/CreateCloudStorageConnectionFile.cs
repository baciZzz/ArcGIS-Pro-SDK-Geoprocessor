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
	/// <para>Create Cloud Storage Connection File</para>
	/// <para>创建云存储连接文件</para>
	/// <para>用于为支持 ArcGIS 的云存储创建连接文件。 此工具允许现有栅格地理处理工具将云栅格格式 (CRF) 数据集写入云存储存储段，或者读取存储在云存储中的栅格数据集（不限于 CRF）作为输入。</para>
	/// </summary>
	public class CreateCloudStorageConnectionFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>Connection File Location</para>
		/// <para>将在其中创建连接文件的文件夹路径。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Connection File Name</para>
		/// <para>云存储连接文件的名称。</para>
		/// </param>
		/// <param name="ServiceProvider">
		/// <para>Service Provider</para>
		/// <para>指定将使用的云存储服务提供商。</para>
		/// <para>Azure—服务提供商将为 Microsoft Azure。</para>
		/// <para>Amazon—服务提供商将为 Amazon S3。</para>
		/// <para>Google—服务提供商将为 Google 云存储。</para>
		/// <para>Alibaba—服务提供商将为 Alibaba 云存储。</para>
		/// <para>WebHDFS—服务提供商将为 WebHDFS。</para>
		/// <para>MinIO—服务提供商将为 MinIO。</para>
		/// <para>Azure Data Lake—服务提供商将为 Azure Data Lake。</para>
		/// <para>Ozone—服务提供程序为 Ozone。</para>
		/// <para><see cref="ServiceProviderEnum"/></para>
		/// </param>
		/// <param name="BucketName">
		/// <para>Bucket (Container) Name</para>
		/// <para>将存储栅格数据集的云存储容器的名称。 许多云提供商也将其称为存储段。</para>
		/// </param>
		public CreateCloudStorageConnectionFile(object OutFolderPath, object OutName, object ServiceProvider, object BucketName)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
			this.ServiceProvider = ServiceProvider;
			this.BucketName = BucketName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建云存储连接文件</para>
		/// </summary>
		public override string DisplayName() => "创建云存储连接文件";

		/// <summary>
		/// <para>Tool Name : CreateCloudStorageConnectionFile</para>
		/// </summary>
		public override string ToolName() => "CreateCloudStorageConnectionFile";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateCloudStorageConnectionFile</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateCloudStorageConnectionFile";

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
		public override object[] Parameters() => new object[] { OutFolderPath, OutName, ServiceProvider, BucketName, AccessKeyId!, SecretAccessKey!, Region!, EndPoint!, ConfigOptions!, OutConnection!, Folder! };

		/// <summary>
		/// <para>Connection File Location</para>
		/// <para>将在其中创建连接文件的文件夹路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Connection File Name</para>
		/// <para>云存储连接文件的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Service Provider</para>
		/// <para>指定将使用的云存储服务提供商。</para>
		/// <para>Azure—服务提供商将为 Microsoft Azure。</para>
		/// <para>Amazon—服务提供商将为 Amazon S3。</para>
		/// <para>Google—服务提供商将为 Google 云存储。</para>
		/// <para>Alibaba—服务提供商将为 Alibaba 云存储。</para>
		/// <para>WebHDFS—服务提供商将为 WebHDFS。</para>
		/// <para>MinIO—服务提供商将为 MinIO。</para>
		/// <para>Azure Data Lake—服务提供商将为 Azure Data Lake。</para>
		/// <para>Ozone—服务提供程序为 Ozone。</para>
		/// <para><see cref="ServiceProviderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ServiceProvider { get; set; }

		/// <summary>
		/// <para>Bucket (Container) Name</para>
		/// <para>将存储栅格数据集的云存储容器的名称。 许多云提供商也将其称为存储段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BucketName { get; set; }

		/// <summary>
		/// <para>Access Key ID (Account Name)</para>
		/// <para>特定云存储类型的访问密钥 ID 字符串。 与 Azure 一样，也可以是帐户名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AccessKeyId { get; set; }

		/// <summary>
		/// <para>Secret Access Key (Account Key)</para>
		/// <para>用于验证与云存储的连接的保密访问密钥字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? SecretAccessKey { get; set; }

		/// <summary>
		/// <para>Region (Environment)</para>
		/// <para>云存储的区域字符串。 如果提供区域，则该值必须使用由云存储选择定义的格式。 默认值是所选云提供商的默认帐户。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Region { get; set; }

		/// <summary>
		/// <para>Service End Point</para>
		/// <para>云存储的服务端点 (URI)，例如 oss-us-west-1.aliyuncs.com。 如果未提供值，则将使用所选云存储类型的默认端点。 如有必要，也可以使用 CNAME 重定向端点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? EndPoint { get; set; }

		/// <summary>
		/// <para>Provider Options</para>
		/// <para>与特定类型的云服务有关的配置选项。 有些服务提供选项，有些服务则不提供选项。 如果需要打开选项，仅需设置此参数。</para>
		/// <para>Azure 和 Microsoft Azure Data Lake</para>
		/// <para>AZURE_SAS - 指定共享访问签名。 确保其值经过 URL 编码，并且不包含前导 &apos;?&apos; 或 &apos;&amp;&apos; 字符。 使用此选项时，保密访问密匙（帐户密钥）参数必须为空。</para>
		/// <para>AZURE_NO_SIGN_REQUEST（默认值：False）- 匿名连接到不需要身份验证访问权限的存储段（容器）。 使用此选项时，保密访问密匙（帐户密钥）参数必须为空。</para>
		/// <para>AZURE_STORAGE_CONNECTION_STRING - 指定 Azure 存储连接字符串。 此字符串将嵌入帐户名、密钥和端点。 使用此选项时，访问密钥 ID（帐户名）和保密访问密匙（帐户密钥）参数必须为空。</para>
		/// <para>CPL_AZURE_USE_HTTPS（默认值：True）- 设置为 False 以使用 HTTP 请求。 某些服务器可能配置为仅支持 HTTPS 请求。</para>
		/// <para>Amazon 和 MinIO</para>
		/// <para>AWS_NO_SIGN_REQUEST（默认值：False）- 匿名连接到不需要身份验证访问权限的存储段（容器）。</para>
		/// <para>AWS_SESSION_TOKEN - 指定临时登录凭据。</para>
		/// <para>AWS_DEFAULT_PROFILE - 当缺少访问密钥或 ID 时，将自动使用 AWS 凭据配置文件。 此选项可用于指定要使用的配置文件。</para>
		/// <para>AWS_REQUEST_PAYER - 通过将此选项设置为请求者，可以访问请求者付费存储段。</para>
		/// <para>AWS_Virtual_Hosting（默认：True）- 如果使用仅支持路径样式请求的 Amazon S3 和 S3 兼容云提供商，需将此选项设置为 True。 如果支持虚拟主机，建议您使用虚拟主机</para>
		/// <para>CPL_VSIS3_USE_BASE_RMDIR_RECURSIVE（默认：True）- 一些较早的 S3 兼容实施不支持批量删除操作。 对于这些提供商，将此选项设置为 False。</para>
		/// <para>AWS_HTTPS（默认值：True）- 设置为 False 以使用 HTTP 请求。 某些服务器可能配置为仅支持 HTTPS 请求</para>
		/// <para>Google</para>
		/// <para>GS_NO_SIGN_REQUEST（默认值：True）- 匿名连接到不需要身份验证访问权限的存储段（容器）。</para>
		/// <para>GS_USER_PROJECT - 可以通过设置 OAuth2 密钥和计费工程来访问请求者付费存储段。 使用此选项设置项目并使用其他选项设置 OAuth2 密钥，而不是 HMAC 密钥作为秘密访问密钥或 ID。</para>
		/// <para>GS_OAUTH2_REFRESH_TOKEN - 指定 OAuth2 刷新访问令牌。 使用 GS_OAUTH2_CLIENT_ID 和 GS_OAUTH2_CLIENT_SECRET 设置 OAuth2 客户端凭据。</para>
		/// <para>GOOGLE_APPLICATION_CREDENTIALS - 使用包含私钥和客户端电子邮件地址的 .json 文件指定服务帐户 OAuth2 凭据。</para>
		/// <para>GS_OAUTH2_ PRIVATE_KEY - 使用私钥字符串指定服务帐户 OAuth2 凭据。 必须设置 GS_AUTH2_CLIENT_EMAIL。</para>
		/// <para>GS_OAUTH2_ PRIVATE_KEY_FILE - 使用来自文件的私钥指定服务帐户 OAuth2 凭据。 必须设置 GS_AUTH2_CLIENT_EMAIL。</para>
		/// <para>GS_AUTH2_CLIENT_EMAIL - 使用客户端电子邮件地址指定服务帐户 OAuth2 凭据。</para>
		/// <para>GS_AUTH2_SCOPE - 指定服务帐户 OAuth2 范围。 有效值为 https://www.googleapis.com/auth/devstorage.read_write（默认）和 https://www.googleapis.com/auth/devstorage.read_only。</para>
		/// <para>GDAL_HTTP_HEADER_FILE - 指定存储在外部文件中的不记名身份验证凭据。</para>
		/// <para>Alibaba</para>
		/// <para>OSS_Virtual_Hosting（默认：True）- 如果使用仅支持路径样式请求的 Alibaba 和 S3 兼容云提供商，需将此选项设置为 True。 如果支持虚拟主机，建议您使用虚拟主机</para>
		/// <para>OSS_HTTPS（默认值：True）- 设置为 False 以使用 HTTP 请求。 某些服务器可能配置为仅支持 HTTPS 请求。</para>
		/// <para>WebHDFS</para>
		/// <para>WEBHDFS_REPLICATION（整数）- 创建文件时使用复制值</para>
		/// <para>WEBHDFS_PERMISSION（小数）- 创建文件时使用权限掩膜。</para>
		/// <para>如果提供了多个身份验证参数，则优先级如下：</para>
		/// <para>Azure - AZURE_STORAGE_CONNECTION_STRING、帐户名或密钥、AZURE_SAS、AZURE_NO_SIGN_REQUEST、RBAC。</para>
		/// <para>Amazon - AWS_NO_SIGN_REQUEST、访问 ID 或密钥，或 AWS_SESSION_TOKEN、AWS 凭据配置文件、IAM 角色。</para>
		/// <para>Google - GS_NO_SIGN_REQUEST、访问 ID 或密钥、GDAL_HTTP_HEADER_FILE、(GS_OAUTH2_REFRESH_TOKEN or GS_OAUTH2_CLIENT_ID and GS_OAUTH2_CLIENT_SECRET)、GOOGLE_APPLICATION_CREDENTIALS、(GS_OAUTH2_PRIVATE_KEY or GS_OAUTH2_CLIENT_EMAIL)、(GS_OAUTH2_PRIVATE_KEY_FILE or GS_OAUTH2_CLIENT_EMAIL) 或 IAM Role。</para>
		/// <para>Ozone</para>
		/// <para>AWS_DEFAULT_PROFILE - 当缺少访问密钥或 ID 时，将自动使用 AWS 凭据配置文件。 此选项可用于指定要使用的配置文件。</para>
		/// <para>AWS_Virtual_Hosting（默认：True）- 如果使用仅支持路径样式请求的 Amazon S3 和 S3 兼容云提供商，需将此选项设置为 True。 如果支持虚拟主机，建议您使用虚拟主机</para>
		/// <para>AWS_HTTPS（默认值：True）- 设置为 False 以使用 HTTP 请求。 某些服务器可能配置为仅支持 HTTPS 请求</para>
		/// <para>CPL_VSIS3_USE_BASE_RMDIR_RECURSIVE（默认：True）- 一些较早的 S3 兼容实施不支持批量删除操作。 对于这些提供商，将此选项设置为 False。</para>
		/// <para>x-amz-storage-class - 为写入单个容器的 Ozone 指定 REDUCED_REDUNDANCY，因为它具有单个数据节点。</para>
		/// <para>除以上列出的提供商选项，ARC_DEEP_CRAWL（默认：True）选项可以与所有服务提供商配合使用。 如果为 True，则用于识别云中没有扩展的 CRF 和启用云的栅格产品。 此操作代价较高，强烈建议将此选项设置为 False，以获得更快的目录浏览和抓取速度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ConfigOptions { get; set; }

		/// <summary>
		/// <para>Output Connection File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutConnection { get; set; }

		/// <summary>
		/// <para>Folder</para>
		/// <para>存储段（容器）名称参数值中将存储栅格数据集的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Folder { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Service Provider</para>
		/// </summary>
		public enum ServiceProviderEnum 
		{
			/// <summary>
			/// <para>Azure—服务提供商将为 Microsoft Azure。</para>
			/// </summary>
			[GPValue("AZURE")]
			[Description("Azure")]
			Azure,

			/// <summary>
			/// <para>Amazon—服务提供商将为 Amazon S3。</para>
			/// </summary>
			[GPValue("AMAZON")]
			[Description("Amazon")]
			Amazon,

			/// <summary>
			/// <para>Google—服务提供商将为 Google 云存储。</para>
			/// </summary>
			[GPValue("GOOGLE")]
			[Description("Google")]
			Google,

			/// <summary>
			/// <para>Alibaba—服务提供商将为 Alibaba 云存储。</para>
			/// </summary>
			[GPValue("ALIBABA")]
			[Description("Alibaba")]
			Alibaba,

			/// <summary>
			/// <para>WebHDFS—服务提供商将为 WebHDFS。</para>
			/// </summary>
			[GPValue("WEBHDFS")]
			[Description("WebHDFS")]
			WebHDFS,

			/// <summary>
			/// <para>MinIO—服务提供商将为 MinIO。</para>
			/// </summary>
			[GPValue("MINIO")]
			[Description("MinIO")]
			MinIO,

			/// <summary>
			/// <para>Azure Data Lake—服务提供商将为 Azure Data Lake。</para>
			/// </summary>
			[GPValue("AZUREDATALAKE")]
			[Description("Azure Data Lake")]
			Azure_Data_Lake,

			/// <summary>
			/// <para>Ozone—服务提供程序为 Ozone。</para>
			/// </summary>
			[GPValue("OZONE")]
			[Description("Ozone")]
			Ozone,

		}

#endregion
	}
}
