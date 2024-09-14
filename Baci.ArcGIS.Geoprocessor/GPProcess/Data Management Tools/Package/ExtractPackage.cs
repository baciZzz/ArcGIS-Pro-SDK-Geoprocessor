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
	/// <para>Extract Package</para>
	/// <para>提取包</para>
	/// <para>将包中的内容提取到指定文件夹。 将使用输入包中所提取的内容更新输出文件夹。</para>
	/// </summary>
	public class ExtractPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPackage">
		/// <para>Input Package</para>
		/// <para>要执行提取操作的输入包。</para>
		/// </param>
		public ExtractPackage(object InPackage)
		{
			this.InPackage = InPackage;
		}

		/// <summary>
		/// <para>Tool Display Name : 提取包</para>
		/// </summary>
		public override string DisplayName() => "提取包";

		/// <summary>
		/// <para>Tool Name : ExtractPackage</para>
		/// </summary>
		public override string ToolName() => "ExtractPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.ExtractPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.ExtractPackage";

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
		public override object[] Parameters() => new object[] { InPackage, OutputFolder, CachePackage, StorageFormatType, CreateReadyToServeFormat, TargetCloudConnection };

		/// <summary>
		/// <para>Input Package</para>
		/// <para>要执行提取操作的输入包。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("lpk", "mpk", "gpk", "lpkx", "mpkx", "mmpk", "mspk", "gpkx", "gcpk", "ppkx", "aptx", "tpk", "tpkx", "vtpk", "slpk")]
		public object InPackage { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>用于存放包中内容的输出文件夹。</para>
		/// <para>如果指定的文件夹不存在，将创建一个文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Cache Package</para>
		/// <para>指定是否将包的副本缓存到您的配置文件。</para>
		/// <para>提取包时，首先将输出提取到用户配置文件，并在复制到输出文件夹参数中指定目录前，附加唯一 ID。 下载和提取同一包的后续版本仅更新此位置。 在使用此参数时，您无需在用户配置文件中手动创建包的缓存版本。 如果输入包为矢量切片包 (.vtpk) 或切片包（.tpk 和 .tpkx），则此参数将处于非活动状态。</para>
		/// <para>选中 - 将包的副本提取并缓存到您的配置文件。 这是默认设置。</para>
		/// <para>未选中 - 仅将包的副本提取到指定的输出参数；并不会对其进行缓存。</para>
		/// <para><see cref="CachePackageEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CachePackage { get; set; } = "true";

		/// <summary>
		/// <para>Storage Format Type</para>
		/// <para>指定将用于提取的缓存的存储格式。 仅当输入包为矢量切片包 (.vtpk) 时，此参数才适应。</para>
		/// <para>数据库碎片整理—将使用 Compact V2 存储格式对包文件中的切片进行分组。 这种格式使得网络共享和云存储目录拥有了更好的性能。 这是默认设置。</para>
		/// <para>松散型—每个切片都将存储为单个文件。</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StorageFormatType { get; set; } = "COMPACT";

		/// <summary>
		/// <para>Create Ready To Serve Cache Dataset</para>
		/// <para>指定是否将针对 ArcGIS Enterprise 创建即用型格式。 仅当输入包为矢量切片包 (.vtpk) 或切片包 (.tpkx) 时，此参数才会处于活动状态。</para>
		/// <para>选中 - 将创建包含提取的缓存的文件夹结构，可使用该结构在 ArcGIS Enterprise 中创建切片图层。 文件夹的文件扩展名将表示其存储的内容：.tiles（缓存数据集）用于切片图层包或 .vtiles（矢量缓存数据集）用于矢量切片包。</para>
		/// <para>未选中 - 将创建包含包的提取内容的文件夹结构。 这是默认设置。</para>
		/// <para><see cref="CreateReadyToServeFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateReadyToServeFormat { get; set; } = "false";

		/// <summary>
		/// <para>Target Cloud Connection</para>
		/// <para>包内容将提取到的目标 .acs 文件。 仅当输入包为场景图层包 (.slpk)、矢量切片包 (.vtpk) 或切片包 (.tpkx) 时，才会启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object TargetCloudConnection { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractPackage SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cache Package</para>
		/// </summary>
		public enum CachePackageEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CACHE")]
			CACHE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CACHE")]
			NO_CACHE,

		}

		/// <summary>
		/// <para>Storage Format Type</para>
		/// </summary>
		public enum StorageFormatTypeEnum 
		{
			/// <summary>
			/// <para>数据库碎片整理—将使用 Compact V2 存储格式对包文件中的切片进行分组。 这种格式使得网络共享和云存储目录拥有了更好的性能。 这是默认设置。</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("数据库碎片整理")]
			Compact,

			/// <summary>
			/// <para>松散型—每个切片都将存储为单个文件。</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("松散型")]
			Exploded,

		}

		/// <summary>
		/// <para>Create Ready To Serve Cache Dataset</para>
		/// </summary>
		public enum CreateReadyToServeFormatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("READY_TO_SERVE_CACHE_DATASET")]
			READY_TO_SERVE_CACHE_DATASET,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXTRACTED_PACKAGE")]
			EXTRACTED_PACKAGE,

		}

#endregion
	}
}
