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
	/// <para>Export Tile Cache</para>
	/// <para>导出切片缓存</para>
	/// <para>将切片从现有切片缓存导出到新切片缓存或切片包中。切片可独立导入至其他缓存，也可以从 、ArcGIS Pro 或移动设备进行访问。</para>
	/// </summary>
	public class ExportTileCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCacheSource">
		/// <para>Input Tile Cache</para>
		/// <para>要导出的现有切片缓存。</para>
		/// </param>
		/// <param name="InTargetCacheFolder">
		/// <para>Output Tile Cache Location</para>
		/// <para>要将切片缓存或切片包导出到其中的输出文件夹。</para>
		/// </param>
		/// <param name="InTargetCacheName">
		/// <para>Output Tile Cache Name</para>
		/// <para>已导出的切片缓存或切片包的名称。</para>
		/// </param>
		public ExportTileCache(object InCacheSource, object InTargetCacheFolder, object InTargetCacheName)
		{
			this.InCacheSource = InCacheSource;
			this.InTargetCacheFolder = InTargetCacheFolder;
			this.InTargetCacheName = InTargetCacheName;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出切片缓存</para>
		/// </summary>
		public override string DisplayName() => "导出切片缓存";

		/// <summary>
		/// <para>Tool Name : ExportTileCache</para>
		/// </summary>
		public override string ToolName() => "ExportTileCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportTileCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportTileCache";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCacheSource, InTargetCacheFolder, InTargetCacheName, ExportCacheType!, StorageFormatType!, Scales!, AreaOfInterest!, OutCache! };

		/// <summary>
		/// <para>Input Tile Cache</para>
		/// <para>要导出的现有切片缓存。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InCacheSource { get; set; }

		/// <summary>
		/// <para>Output Tile Cache Location</para>
		/// <para>要将切片缓存或切片包导出到其中的输出文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InTargetCacheFolder { get; set; }

		/// <summary>
		/// <para>Output Tile Cache Name</para>
		/// <para>已导出的切片缓存或切片包的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InTargetCacheName { get; set; }

		/// <summary>
		/// <para>Export Cache As</para>
		/// <para>指定是将缓存导出为切片缓存还是切片包。切片包适用于 ArcGIS Runtime 和 ArcGIS Mobile 部署。</para>
		/// <para>切片缓存—缓存将作为独立的缓存栅格数据集导出。这是默认设置。</para>
		/// <para>切片包 (tpk)—缓存将被导出为将缓存数据集作为图层添加并合并以便实现轻松共享的单个压缩文件 (.tpk)。此类型在 ArcMap 以及 ArcGIS Runtime 和 ArcGIS Mobile 应用程序中均可用。</para>
		/// <para>切片包 (tpkx)—缓存将使用 Compact_v2 存储格式 (.tpkx) 进行导出，该格式可提供更好的网络共享和云存储目录性能。ArcGIS 平台的较新版本（例如 ArcGIS Online、ArcGIS Pro 2.3、ArcGIS Enterprise 10.7 和 ArcGIS Runtime 100.5）均支持这种改进并简化的包结构类型。</para>
		/// <para><see cref="ExportCacheTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExportCacheType { get; set; } = "TILE_CACHE";

		/// <summary>
		/// <para>Storage Format</para>
		/// <para>确定切片的存储格式。</para>
		/// <para>紧凑型—将切片分组到较大的包文件中。此存储格式在存储和移动性方面更高效。</para>
		/// <para>紧凑型 v2— 仅能将切片组织到包文件中。这种格式使得网络共享和云存储目录拥有了更好的性能。如果将导出缓存类型参数设置为切片包 (tpkx)，则切片包的扩展名为较新版本的 ArcGIS 平台，如 ArcGIS Online、ArcGIS Enterprise 11 和 ArcGIS Runtime 100.5 均支持的 (.tpkx)。这是默认设置。</para>
		/// <para>松散型—每个切片都以单个文件的形式存储。 请注意，此格式无法用于切片包。</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StorageFormatType { get; set; } = "COMPACT_V2";

		/// <summary>
		/// <para>Scales [Pixel Size] (Estimated Disk Space)</para>
		/// <para>导出切片时使用的比例级别列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Scales { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>对将从缓存中导出切片的位置进行空间约束的感兴趣区。</para>
		/// <para>感兴趣区域可以为要素类或绘制在地图上的要素。</para>
		/// <para>由于该工具在像素级别上裁剪缓存数据集，所以此参数在您想要导出形状不规则的区域时非常有用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Output Tile Cache</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutCache { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportTileCache SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export Cache As</para>
		/// </summary>
		public enum ExportCacheTypeEnum 
		{
			/// <summary>
			/// <para>切片缓存—缓存将作为独立的缓存栅格数据集导出。这是默认设置。</para>
			/// </summary>
			[GPValue("TILE_CACHE")]
			[Description("切片缓存")]
			Tile_cache,

			/// <summary>
			/// <para>切片包 (tpk)—缓存将被导出为将缓存数据集作为图层添加并合并以便实现轻松共享的单个压缩文件 (.tpk)。此类型在 ArcMap 以及 ArcGIS Runtime 和 ArcGIS Mobile 应用程序中均可用。</para>
			/// </summary>
			[GPValue("TILE_PACKAGE")]
			[Description("切片包 (tpk)")]
			TILE_PACKAGE,

			/// <summary>
			/// <para>切片包 (tpkx)—缓存将使用 Compact_v2 存储格式 (.tpkx) 进行导出，该格式可提供更好的网络共享和云存储目录性能。ArcGIS 平台的较新版本（例如 ArcGIS Online、ArcGIS Pro 2.3、ArcGIS Enterprise 10.7 和 ArcGIS Runtime 100.5）均支持这种改进并简化的包结构类型。</para>
			/// </summary>
			[GPValue("TILE_PACKAGE_TPKX")]
			[Description("切片包 (tpkx)")]
			TILE_PACKAGE_TPKX,

		}

		/// <summary>
		/// <para>Storage Format</para>
		/// </summary>
		public enum StorageFormatTypeEnum 
		{
			/// <summary>
			/// <para>紧凑型—将切片分组到较大的包文件中。此存储格式在存储和移动性方面更高效。</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("紧凑型")]
			Compact,

			/// <summary>
			/// <para>松散型—每个切片都以单个文件的形式存储。 请注意，此格式无法用于切片包。</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("松散型")]
			Exploded,

			/// <summary>
			/// <para>紧凑型 v2— 仅能将切片组织到包文件中。这种格式使得网络共享和云存储目录拥有了更好的性能。如果将导出缓存类型参数设置为切片包 (tpkx)，则切片包的扩展名为较新版本的 ArcGIS 平台，如 ArcGIS Online、ArcGIS Enterprise 11 和 ArcGIS Runtime 100.5 均支持的 (.tpkx)。这是默认设置。</para>
			/// </summary>
			[GPValue("COMPACT_V2")]
			[Description("紧凑型 v2")]
			Compact_v2,

		}

#endregion
	}
}
