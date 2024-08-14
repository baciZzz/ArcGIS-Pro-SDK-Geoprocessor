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
	/// <para>Creates a connection file for ArcGIS-supported cloud storage. This tool allows existing raster geoprocessing tools to write cloud raster format (CRF) datasets into the cloud storage bucket or read raster datasets (not limited to CRF) stored in the cloud storage as input.</para>
	/// </summary>
	public class CreateCloudStorageConnectionFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>Connection File Location</para>
		/// <para>The folder path where the connection file will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Connection File Name</para>
		/// <para>The name of the cloud storage connection file.</para>
		/// </param>
		/// <param name="ServiceProvider">
		/// <para>Service Provider</para>
		/// <para>Specifies the cloud storage service provider that will be used.</para>
		/// <para>Azure—The service provider will be Microsoft Azure.</para>
		/// <para>Amazon—The service provider will be Amazon S3.</para>
		/// <para>Google—The service provider will be Google Cloud Storage.</para>
		/// <para>Alibaba—The service provider will be Alibaba Cloud Storage.</para>
		/// <para>WebHDFS—The service provider will be WebHDFS.</para>
		/// <para>MinIO—The service provider will be MinIO.</para>
		/// <para>Azure Data Lake—The service provider will be Azure Data Lake.</para>
		/// <para>Ozone—The service provider will be Ozone.</para>
		/// <para><see cref="ServiceProviderEnum"/></para>
		/// </param>
		/// <param name="BucketName">
		/// <para>Bucket (Container) Name</para>
		/// <para>The name of the cloud storage container where the raster dataset will be stored. Many cloud providers also call it a bucket.</para>
		/// </param>
		public CreateCloudStorageConnectionFile(object OutFolderPath, object OutName, object ServiceProvider, object BucketName)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
			this.ServiceProvider = ServiceProvider;
			this.BucketName = BucketName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Cloud Storage Connection File</para>
		/// </summary>
		public override string DisplayName => "Create Cloud Storage Connection File";

		/// <summary>
		/// <para>Tool Name : CreateCloudStorageConnectionFile</para>
		/// </summary>
		public override string ToolName => "CreateCloudStorageConnectionFile";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateCloudStorageConnectionFile</para>
		/// </summary>
		public override string ExcuteName => "management.CreateCloudStorageConnectionFile";

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
		public override object[] Parameters => new object[] { OutFolderPath, OutName, ServiceProvider, BucketName, AccessKeyId!, SecretAccessKey!, Region!, EndPoint!, ConfigOptions!, OutConnection!, Folder! };

		/// <summary>
		/// <para>Connection File Location</para>
		/// <para>The folder path where the connection file will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Connection File Name</para>
		/// <para>The name of the cloud storage connection file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Service Provider</para>
		/// <para>Specifies the cloud storage service provider that will be used.</para>
		/// <para>Azure—The service provider will be Microsoft Azure.</para>
		/// <para>Amazon—The service provider will be Amazon S3.</para>
		/// <para>Google—The service provider will be Google Cloud Storage.</para>
		/// <para>Alibaba—The service provider will be Alibaba Cloud Storage.</para>
		/// <para>WebHDFS—The service provider will be WebHDFS.</para>
		/// <para>MinIO—The service provider will be MinIO.</para>
		/// <para>Azure Data Lake—The service provider will be Azure Data Lake.</para>
		/// <para>Ozone—The service provider will be Ozone.</para>
		/// <para><see cref="ServiceProviderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ServiceProvider { get; set; }

		/// <summary>
		/// <para>Bucket (Container) Name</para>
		/// <para>The name of the cloud storage container where the raster dataset will be stored. Many cloud providers also call it a bucket.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BucketName { get; set; }

		/// <summary>
		/// <para>Access Key ID (Account Name)</para>
		/// <para>The access key ID string for the specific cloud storage type. It can also be the account name, as is the case with Azure.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AccessKeyId { get; set; }

		/// <summary>
		/// <para>Secret Access Key (Account Key)</para>
		/// <para>The secret access key string to authenticate the connection to cloud storage.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? SecretAccessKey { get; set; }

		/// <summary>
		/// <para>Region (Environment)</para>
		/// <para>The region string for the cloud storage. If provided, the value must use the format defined by the cloud storage choice. The default is the selected cloud provider's default account.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Region { get; set; }

		/// <summary>
		/// <para>Service End Point</para>
		/// <para>The service endpoint (URI) of the cloud storage, such as oss-us-west-1.aliyuncs.com. If a value is not provided, the default endpoint for the selected cloud storage type will be used. The CNAME redirected endpoint can also be used if needed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? EndPoint { get; set; }

		/// <summary>
		/// <para>Provider Options</para>
		/// <para>The configuration options pertaining to the specific type of cloud service. Some services offer options, some do not. You only need to set this parameter if you want to turn on the options.</para>
		/// <para>Azure and Microsoft Azure Data Lake</para>
		/// <para>AZURE_SAS—Specify a shared access signature. Ensure that its value is URL encoded and does not contain leading &apos;?&apos; or &apos;&amp;&apos; characters. When using this option, the Secret Access Key (Account Key) parameter must be empty.</para>
		/// <para>AZURE_NO_SIGN_REQUEST (default: False)—Anonymously connect to buckets (containers) that don&apos;t require authenticated access. When using this option, the Secret Access Key (Account Key) parameter must be empty.</para>
		/// <para>AZURE_STORAGE_CONNECTION_STRING—Specify an Azure Storage connection string. This string embeds the account name, key, and endpoint. When using this option, the Access Key ID (Account Name) and Secret Access Key (Account Key) parameters must be empty.</para>
		/// <para>CPL_AZURE_USE_HTTPS (default: True)—Set to False to use HTTP requests. Some servers may be configured to only support HTTPS requests.</para>
		/// <para>Amazon and MinIO</para>
		/// <para>AWS_NO_SIGN_REQUEST (default: False)—Anonymously connect to buckets (containers) that don&apos;t require authenticated access.</para>
		/// <para>AWS_SESSION_TOKEN—Specify temporary credentials.</para>
		/// <para>AWS_DEFAULT_PROFILE—AWS credential profiles are automatically used when the access key or ID is missing. This option can be used to specify the profile to use.</para>
		/// <para>AWS_REQUEST_PAYER—Requester Pays buckets can be accessed by setting this option to requester.</para>
		/// <para>AWS_Virtual_Hosting (default: True)—If you use Amazon S3 or S3-compatible cloud providers that support only path-style requests, set this option to True. It is recommended that you use virtual hosting if it&apos;s supported.</para>
		/// <para>CPL_VSIS3_USE_BASE_RMDIR_RECURSIVE (default: True)—Some older S3-compatible implementations do not support the Bulk Delete operation. Set this option to False for these providers.</para>
		/// <para>AWS_HTTPS (default: True)—Set to False to use HTTP requests. Some servers may be configured to only support HTTPS requests</para>
		/// <para>Google</para>
		/// <para>GS_NO_SIGN_REQUEST (default: True)—Anonymously connect to buckets (containers) that do not require authenticated access.</para>
		/// <para>GS_USER_PROJECT—Requester Pays buckets can be accessed by setting OAuth2 keys and a project for billing. Set the project using this option and set OAuth2 keys using other options and not HMAC keys as a secret access key or ID.</para>
		/// <para>GS_OAUTH2_REFRESH_TOKEN—Specify OAuth2 Refresh Access Token. Set OAuth2 client credentials using GS_OAUTH2_CLIENT_ID and GS_OAUTH2_CLIENT_SECRET.</para>
		/// <para>GOOGLE_APPLICATION_CREDENTIALS—Specify Service Account OAuth2 credentials using a .json file containing a private key and client email address.</para>
		/// <para>GS_OAUTH2_ PRIVATE_KEY—Specify Service Account OAuth2 credentials using a private key string. GS_AUTH2_CLIENT_EMAIL must be set.</para>
		/// <para>GS_OAUTH2_ PRIVATE_KEY_FILE—Specify Service Account OAuth2 credentials using a private key from a file. GS_AUTH2_CLIENT_EMAIL must be set.</para>
		/// <para>GS_AUTH2_CLIENT_EMAIL—Specify Service Account OAuth2 credentials using a client email address.</para>
		/// <para>GS_AUTH2_SCOPE—Specify Service Account OAuth2 scope. Valid values are https://www.googleapis.com/auth/devstorage.read_write (default) and https://www.googleapis.com/auth/devstorage.read_only.</para>
		/// <para>GDAL_HTTP_HEADER_FILE—Specify bearer authentication credentials stored in an external file.</para>
		/// <para>Alibaba</para>
		/// <para>OSS_Virtual_Hosting (default: True)—If you use Alibaba or S3-compatible cloud providers that support only path-style requests, set this option to True. It is recommended that you use virtual hosting if it&apos;s supported.</para>
		/// <para>OSS_HTTPS (default: True)—Set to False to use HTTP requests. Some servers may be configured to only support HTTPS requests.</para>
		/// <para>WebHDFS</para>
		/// <para>WEBHDFS_REPLICATION (integer)—The replication value is used when creating a file</para>
		/// <para>WEBHDFS_PERMISSION (decimal)—A permission mask is used when creating a file.</para>
		/// <para>If multiple authentication parameters are provided, precedence is as follows:</para>
		/// <para>Azure—AZURE_STORAGE_CONNECTION_STRING, account name or key, AZURE_SAS, AZURE_NO_SIGN_REQUEST, RBAC.</para>
		/// <para>Amazon—AWS_NO_SIGN_REQUEST, access ID or key or AWS_SESSION_TOKEN, AWS Credential Profile, IAM Role.</para>
		/// <para>Google—GS_NO_SIGN_REQUEST, access ID or key, GDAL_HTTP_HEADER_FILE, (GS_OAUTH2_REFRESH_TOKEN or GS_OAUTH2_CLIENT_ID and GS_OAUTH2_CLIENT_SECRET), GOOGLE_APPLICATION_CREDENTIALS, (GS_OAUTH2_PRIVATE_KEY or GS_OAUTH2_CLIENT_EMAIL), (GS_OAUTH2_PRIVATE_KEY_FILE or GS_OAUTH2_CLIENT_EMAIL), or IAM Role.</para>
		/// <para>Ozone</para>
		/// <para>AWS_DEFAULT_PROFILE—AWS credential profiles are automatically used when the access key or ID is missing. This option can be used to specify the profile to use.</para>
		/// <para>AWS_Virtual_Hosting (default: True)—If you use Amazon S3 or S3-compatible cloud providers that support only path-style requests, set this option to True. It is recommended that you use virtual hosting if it&apos;s supported.</para>
		/// <para>AWS_HTTPS (default: True)—Set to False to use HTTP requests. Some servers may be configured to only support HTTPS requests</para>
		/// <para>CPL_VSIS3_USE_BASE_RMDIR_RECURSIVE (default: True)—Some older S3-compatible implementations do not support the Bulk Delete operation. Set this option to False for these providers.</para>
		/// <para>x-amz-storage-class—Specify REDUCED_REDUNDANCY for writing to a single container ozone as it has a single data node.</para>
		/// <para>In addition to the provider options listed above, the ARC_DEEP_CRAWL (default: True) option can be used with all the service providers. If True, it is used to identify CRFs with no extension and cloud-enabled raster products in the cloud. This is an expensive operation and it is recommended that you set this option to False for faster catalog browsing and crawling.</para>
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
		/// <para>The folder in the Bucket (Container) Name parameter value where the raster dataset will be stored.</para>
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
			/// <para>Azure—The service provider will be Microsoft Azure.</para>
			/// </summary>
			[GPValue("AZURE")]
			[Description("Azure")]
			Azure,

			/// <summary>
			/// <para>Amazon—The service provider will be Amazon S3.</para>
			/// </summary>
			[GPValue("AMAZON")]
			[Description("Amazon")]
			Amazon,

			/// <summary>
			/// <para>Google—The service provider will be Google Cloud Storage.</para>
			/// </summary>
			[GPValue("GOOGLE")]
			[Description("Google")]
			Google,

			/// <summary>
			/// <para>Alibaba—The service provider will be Alibaba Cloud Storage.</para>
			/// </summary>
			[GPValue("ALIBABA")]
			[Description("Alibaba")]
			Alibaba,

			/// <summary>
			/// <para>WebHDFS—The service provider will be WebHDFS.</para>
			/// </summary>
			[GPValue("WEBHDFS")]
			[Description("WebHDFS")]
			WebHDFS,

			/// <summary>
			/// <para>MinIO—The service provider will be MinIO.</para>
			/// </summary>
			[GPValue("MINIO")]
			[Description("MinIO")]
			MinIO,

			/// <summary>
			/// <para>Azure Data Lake—The service provider will be Azure Data Lake.</para>
			/// </summary>
			[GPValue("AZUREDATALAKE")]
			[Description("Azure Data Lake")]
			Azure_Data_Lake,

			/// <summary>
			/// <para>Ozone—The service provider will be Ozone.</para>
			/// </summary>
			[GPValue("OZONE")]
			[Description("Ozone")]
			Ozone,

		}

#endregion
	}
}
