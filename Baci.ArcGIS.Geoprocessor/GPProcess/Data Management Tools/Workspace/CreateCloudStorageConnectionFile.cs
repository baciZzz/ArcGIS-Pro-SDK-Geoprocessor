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
		/// <para>Specifies the cloud storage service provider.</para>
		/// <para>Azure—The service provider will be Microsoft Azure.</para>
		/// <para>Amazon—The service provider will be Amazon S3.</para>
		/// <para>Google—The service provider will be Google Cloud Storage.</para>
		/// <para>Alibaba—The service provider will be Alibaba Cloud Storage.</para>
		/// <para>WebHDFS—The service provider will be WebHDFS.</para>
		/// <para>MinIO—The service provider will be MinIO.</para>
		/// <para>Azure Data Lake—The service provider will be Azure Data Lake.</para>
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
		public override string DisplayName() => "Create Cloud Storage Connection File";

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
		public override object[] Parameters() => new object[] { OutFolderPath, OutName, ServiceProvider, BucketName, AccessKeyId, SecretAccessKey, Region, EndPoint, ConfigOptions, OutConnection, Folder };

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
		/// <para>Specifies the cloud storage service provider.</para>
		/// <para>Azure—The service provider will be Microsoft Azure.</para>
		/// <para>Amazon—The service provider will be Amazon S3.</para>
		/// <para>Google—The service provider will be Google Cloud Storage.</para>
		/// <para>Alibaba—The service provider will be Alibaba Cloud Storage.</para>
		/// <para>WebHDFS—The service provider will be WebHDFS.</para>
		/// <para>MinIO—The service provider will be MinIO.</para>
		/// <para>Azure Data Lake—The service provider will be Azure Data Lake.</para>
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
		public object AccessKeyId { get; set; }

		/// <summary>
		/// <para>Secret Access Key (Account Key)</para>
		/// <para>The secret access key string to authenticate the connection to cloud storage.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object SecretAccessKey { get; set; }

		/// <summary>
		/// <para>Region (Environment)</para>
		/// <para>The region string for the cloud storage. If provided, the value must use the format defined by the cloud storage choice. The default is the selected cloud provider's default account.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Region { get; set; }

		/// <summary>
		/// <para>Service End Point</para>
		/// <para>The service endpoint (uris) of the cloud storage, such as oss-us-west-1.aliyuncs.com. If a value is not provided, the default endpoint for the selected cloud storage type will be used. The CNAME redirected endpoint can also be used if needed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object EndPoint { get; set; }

		/// <summary>
		/// <para>Provider Options</para>
		/// <para>The configuration options pertaining to the specific type of cloud service. Some services offer options, some do not. You only need to set the option if you want to turn them on.</para>
		/// <para>Role-based access control (RBAC) is available for both Amazon and Azure cloud providers. Keeping all authentication parameters empty while using an EC2 or Azure virtual machine will enable ArcGIS Pro to access Blob storage using IAM roles or Azure RBAC. For Amazon, IMDSv1 and IMDSv2 are supported.</para>
		/// <para>Microsoft Azure Data Lake Storage Gen2 follows the same options as Azure but provides true directory support and atomic operations using a DFS endpoint. Some network errors during cloud operations are retried following exponential backoff.</para>
		/// <para>For performance considerations and additional information, see the GDAL virtual file systems documentation.</para>
		/// <para>Azure / Microsoft Azure Data Lake</para>
		/// <para>AZURE_SAS—Specify an shared access signature. Ensure that its value is URL encoded and does not contain leading &apos;?&apos; or &apos;&amp;&apos; characters. When using this option, the Secret Access Key (Account Key) parameter must be empty.</para>
		/// <para>AZURE_NO_SIGN_REQUEST (default: FALSE)—Anonymously connect to buckets (containers) that don&apos;t require authenticated access. When using this option, the Secret Access Key (Account Key) parameter must be empty.</para>
		/// <para>AZURE_STORAGE_CONNECTION_STRING—Specify an Azure Storage connection string. This string embeds the account name, key, and endpoint. When using this option, the Access Key ID (Account Name) and Secret Access Key (Account Key) parameter must be empty.</para>
		/// <para>CPL_AZURE_USE_HTTPS (default: TRUE): Set FALSE to use http requests. Note that some servers might be configured to only support https requests.</para>
		/// <para>Amazon / MinIO</para>
		/// <para>AWS_NO_SIGN_REQUEST (default: FALSE)—Anonymously connect to buckets (containers) that don&apos;t require authenticated access.</para>
		/// <para>AWS_SESSION_TOKEN—Specify temporary credentials.</para>
		/// <para>AWS_DEFAULT_PROFILE—AWS credential profiles are automatically used when Access Key/ID is missing. This option can be used to specify the profile to use.</para>
		/// <para>AWS_REQUEST_PAYER—Requester Pays buckets can be accessed by setting this option to requester.</para>
		/// <para>AWS_Virtual_Hosting (default: TRUE)—Amazon S3 and S3 compatible cloud providers supporting only path-style requests must set this option to TRUE. It is recommended that you use virtual hosting if it&apos;s supported</para>
		/// <para>CPL_VSIS3_USE_BASE_RMDIR_RECURSIVE (default: TRUE)— Some older S3 compatible implementations do not support the Bulk Delete operation. Set this option to FALSE for these providers.</para>
		/// <para>AWS_HTTPS (default: TRUE)—Set FALSE to use http requests. Note that some servers might be configured to only support https requests</para>
		/// <para>Alibaba</para>
		/// <para>OSS_Virtual_Hosting (default: TRUE)—Alibaba and S3 compatible cloud providers supporting only path-style requests must set this option to TRUE. It is recommended that you use virtual hosting if it&apos;s supported.</para>
		/// <para>OSS_HTTPS (default: TRUE)—Set FALSE to use http requests. Note that some servers might be configured to only support https requests.</para>
		/// <para>WebHDFS</para>
		/// <para>WEBHDFS_REPLICATION (integer)—The replication value is used when creating a file</para>
		/// <para>WEBHDFS_PERMISSION (decimal)—A permission mask is used when creating a file.</para>
		/// <para>If multiple authentication parameters are provided, precedence is as follows:</para>
		/// <para>Azure—AZURE_STORAGE_CONNECTION_STRING, account name / key, AZURE_SAS, AZURE_NO_SIGN_REQUEST, RBAC.</para>
		/// <para>Amazon—AWS_NO_SIGN_REQUEST, access id / key and/or AWS_SESSION_TOKEN, AWS Credential Profile, IAM Role.</para>
		/// <para>Other than the provider options listed above, this option ARC_DEEP_CRAWL (default:TRUE), can be used with all the service providers. If True, this option is used to identify CRFs with no extension in the cloud; this is an expensive operation and it is highly recommended to set this option to FALSE for faster catalog browsing experience and crawling.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ConfigOptions { get; set; }

		/// <summary>
		/// <para>Output Connection File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutConnection { get; set; }

		/// <summary>
		/// <para>Folder</para>
		/// <para>The folder in the Bucket (Container) Name parameter where the raster dataset will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Folder { get; set; }

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

		}

#endregion
	}
}
