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
	/// <para>Export Map Server Cache</para>
	/// <para>导出地图服务器缓存</para>
	/// <para>用于将地图图像图层缓存的切片作为缓存数据集或切片包导出至磁盘上的文件夹中。 切片可导入至其他缓存中，也可以以独立于其父服务的方式，作为一个栅格数据集从 ArcGIS Desktop 或移动设备中进行访问。</para>
	/// </summary>
	public class ExportMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>带有要导出的缓存切片的地图图像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </param>
		/// <param name="TargetCachePath">
		/// <para>Target Cache Path</para>
		/// <para>缓存将被导出到的目标文件夹。 此文件夹不必是一个已注册的服务器缓存目录。 ArcGIS Server 帐户必须拥有对目标缓存文件夹的写入权限。 如果无法对服务器帐户授予目标文件夹的写入权限，但 ArcGIS Desktop 或 ArcGIS Pro 客户端拥有目标文件夹的写入权限，请选择从服务器复制数据参数。</para>
		/// </param>
		/// <param name="ExportCacheType">
		/// <para>Export cache type</para>
		/// <para>将缓存作为缓存数据集或切片包导出。 切片包适用于 ArcGIS Runtime 和 ArcGIS Mobile 部署。</para>
		/// <para>缓存数据集—使用 ArcGIS Server 生成的地图或影像服务缓存。 其可用于 ArcGIS Desktop 并通过 ArcGIS Server 地图或影像服务对其进行使用。 这是默认设置。</para>
		/// <para>切片包—将缓存数据集作为图层添加并合并以便实现共享的单个压缩文件。 其可用于 ArcGIS Desktop、ArcGIS Runtime 和移动应用程序。</para>
		/// <para><see cref="ExportCacheTypeEnum"/></para>
		/// </param>
		/// <param name="CopyDataFromServer">
		/// <para>Copy data from server</para>
		/// <para>只在以下情况下选中此参数：无法向 ArcGIS Server 帐户授予目标文件夹的写入权限，但 ArcGIS Desktop 或 ArcGIS Pro 客户端拥有目标文件夹的写入权限。 软件会在将服务器输出目录中的切片移至目标文件夹前将其导出。</para>
		/// <para>选中 - 将切片放入服务器输出目录中，随后将其移至目标文件夹。 ArcGIS Desktop 客户端必须具有对目标文件夹的写入权限。</para>
		/// <para>未选中 - 切片被直接导出到目标文件夹。 ArcGIS Server 帐户必须具有对目标文件夹的写入权限。</para>
		/// <para><see cref="CopyDataFromServerEnum"/></para>
		/// </param>
		/// <param name="StorageFormatType">
		/// <para>Storage Format Type</para>
		/// <para>导出的缓存的存储格式。</para>
		/// <para>紧凑型—切片被组织到包和 bundlex 文件中以节省磁盘空间并允许以较快的速度复制缓存。 如果将导出缓存类型参数设置为切片包，则此为默认设置。</para>
		/// <para>紧凑型 V2—仅能将切片组织到包文件中。 这种格式使得网络共享和云存储目录拥有了更好的性能。 如果将导出缓存类型参数设置为切片包，则切片包的扩展名为较新版本的 ArcGIS 平台，如 ArcGIS Online、ArcGIS Enterprise 10.9 和 ArcGIS Runtime 100.5 均支持的 (.tpkx)。</para>
		/// <para>松散型—每个文件都将作为单个文件进行存储（在 ArcGIS Server 之前的版本中，均以这种方式存储缓存）。</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>导出切片时使用的比例级别列表。</para>
		/// </param>
		public ExportMapServerCache(object InputService, object TargetCachePath, object ExportCacheType, object CopyDataFromServer, object StorageFormatType, object Scales)
		{
			this.InputService = InputService;
			this.TargetCachePath = TargetCachePath;
			this.ExportCacheType = ExportCacheType;
			this.CopyDataFromServer = CopyDataFromServer;
			this.StorageFormatType = StorageFormatType;
			this.Scales = Scales;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出地图服务器缓存</para>
		/// </summary>
		public override string DisplayName() => "导出地图服务器缓存";

		/// <summary>
		/// <para>Tool Name : ExportMapServerCache</para>
		/// </summary>
		public override string ToolName() => "ExportMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.ExportMapServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.ExportMapServerCache";

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
		public override object[] Parameters() => new object[] { InputService, TargetCachePath, ExportCacheType, CopyDataFromServer, StorageFormatType, Scales, NumOfCachingServiceInstances, AreaOfInterest, ExportExtent, Overwrite, OutputCachePath };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>带有要导出的缓存切片的地图图像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Target Cache Path</para>
		/// <para>缓存将被导出到的目标文件夹。 此文件夹不必是一个已注册的服务器缓存目录。 ArcGIS Server 帐户必须拥有对目标缓存文件夹的写入权限。 如果无法对服务器帐户授予目标文件夹的写入权限，但 ArcGIS Desktop 或 ArcGIS Pro 客户端拥有目标文件夹的写入权限，请选择从服务器复制数据参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetCachePath { get; set; }

		/// <summary>
		/// <para>Export cache type</para>
		/// <para>将缓存作为缓存数据集或切片包导出。 切片包适用于 ArcGIS Runtime 和 ArcGIS Mobile 部署。</para>
		/// <para>缓存数据集—使用 ArcGIS Server 生成的地图或影像服务缓存。 其可用于 ArcGIS Desktop 并通过 ArcGIS Server 地图或影像服务对其进行使用。 这是默认设置。</para>
		/// <para>切片包—将缓存数据集作为图层添加并合并以便实现共享的单个压缩文件。 其可用于 ArcGIS Desktop、ArcGIS Runtime 和移动应用程序。</para>
		/// <para><see cref="ExportCacheTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportCacheType { get; set; } = "CACHE_DATASET";

		/// <summary>
		/// <para>Copy data from server</para>
		/// <para>只在以下情况下选中此参数：无法向 ArcGIS Server 帐户授予目标文件夹的写入权限，但 ArcGIS Desktop 或 ArcGIS Pro 客户端拥有目标文件夹的写入权限。 软件会在将服务器输出目录中的切片移至目标文件夹前将其导出。</para>
		/// <para>选中 - 将切片放入服务器输出目录中，随后将其移至目标文件夹。 ArcGIS Desktop 客户端必须具有对目标文件夹的写入权限。</para>
		/// <para>未选中 - 切片被直接导出到目标文件夹。 ArcGIS Server 帐户必须具有对目标文件夹的写入权限。</para>
		/// <para><see cref="CopyDataFromServerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CopyDataFromServer { get; set; } = "false";

		/// <summary>
		/// <para>Storage Format Type</para>
		/// <para>导出的缓存的存储格式。</para>
		/// <para>紧凑型—切片被组织到包和 bundlex 文件中以节省磁盘空间并允许以较快的速度复制缓存。 如果将导出缓存类型参数设置为切片包，则此为默认设置。</para>
		/// <para>紧凑型 V2—仅能将切片组织到包文件中。 这种格式使得网络共享和云存储目录拥有了更好的性能。 如果将导出缓存类型参数设置为切片包，则切片包的扩展名为较新版本的 ArcGIS 平台，如 ArcGIS Online、ArcGIS Enterprise 10.9 和 ArcGIS Runtime 100.5 均支持的 (.tpkx)。</para>
		/// <para>松散型—每个文件都将作为单个文件进行存储（在 ArcGIS Server 之前的版本中，均以这种方式存储缓存）。</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StorageFormatType { get; set; } = "COMPACT";

		/// <summary>
		/// <para>Scales</para>
		/// <para>导出切片时使用的比例级别列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>指定用于更新或生成切片的实例数。 该参数的值将设置为无限 (-1)，且无法进行修改。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>对从缓存中导出切片的位置进行空间约束的感兴趣区。 由于该工具在像素级别上裁剪缓存数据集，所以此参数在您想要导出形状不规则的区域时非常有用。</para>
		/// <para>若未指定感兴趣区，则会导出地图的全图范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Export Extent</para>
		/// <para>定义要导出的切片的矩形范围。 默认情况下，此范围将设置为要导入切片所属的地图服务的全图范围。 请注意此感兴趣区工具中的可选参数，它允许您使用面要素进行导入操作。 建议不要为一个作业的两个参数都提供值。 如果为两个参数都提供了值，则感兴趣区参数的优先级高于导入范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of interest (Envelope)")]
		public object ExportExtent { get; set; }

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// <para>指定接收缓存中的图像是与原始缓存中的切片合并，还是被其覆盖。</para>
		/// <para>选中 - 导出过程会替换感兴趣区域的所有像素，并用原始缓存中的切片有效覆盖目标缓存中的切片。</para>
		/// <para>未选中 - 导出切片后，默认情况下将忽略原始缓存中的透明像素。 将导致目标缓存中的图像合并或混合。 这是默认设置。</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Output Cache Path</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputCachePath { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Export cache type</para>
		/// </summary>
		public enum ExportCacheTypeEnum 
		{
			/// <summary>
			/// <para>切片包—将缓存数据集作为图层添加并合并以便实现共享的单个压缩文件。 其可用于 ArcGIS Desktop、ArcGIS Runtime 和移动应用程序。</para>
			/// </summary>
			[GPValue("TILE_PACKAGE")]
			[Description("切片包")]
			Tile_package,

			/// <summary>
			/// <para>缓存数据集—使用 ArcGIS Server 生成的地图或影像服务缓存。 其可用于 ArcGIS Desktop 并通过 ArcGIS Server 地图或影像服务对其进行使用。 这是默认设置。</para>
			/// </summary>
			[GPValue("CACHE_DATASET")]
			[Description("缓存数据集")]
			Cache_dataset,

		}

		/// <summary>
		/// <para>Copy data from server</para>
		/// </summary>
		public enum CopyDataFromServerEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COPY_DATA")]
			COPY_DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_COPY")]
			DO_NOT_COPY,

		}

		/// <summary>
		/// <para>Storage Format Type</para>
		/// </summary>
		public enum StorageFormatTypeEnum 
		{
			/// <summary>
			/// <para>紧凑型 V2—仅能将切片组织到包文件中。 这种格式使得网络共享和云存储目录拥有了更好的性能。 如果将导出缓存类型参数设置为切片包，则切片包的扩展名为较新版本的 ArcGIS 平台，如 ArcGIS Online、ArcGIS Enterprise 10.9 和 ArcGIS Runtime 100.5 均支持的 (.tpkx)。</para>
			/// </summary>
			[GPValue("COMPACT_V2")]
			[Description("紧凑型 V2")]
			Compact_V2,

			/// <summary>
			/// <para>紧凑型—切片被组织到包和 bundlex 文件中以节省磁盘空间并允许以较快的速度复制缓存。 如果将导出缓存类型参数设置为切片包，则此为默认设置。</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("紧凑型")]
			Compact,

			/// <summary>
			/// <para>松散型—每个文件都将作为单个文件进行存储（在 ArcGIS Server 之前的版本中，均以这种方式存储缓存）。</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("松散型")]
			Exploded,

		}

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
