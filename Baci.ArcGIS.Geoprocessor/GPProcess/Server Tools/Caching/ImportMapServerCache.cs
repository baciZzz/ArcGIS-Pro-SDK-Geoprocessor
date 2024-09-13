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
	/// <para>Import Map Server Cache</para>
	/// <para>导入地图服务器缓存</para>
	/// <para>将切片从磁盘上的文件夹中导入到地图图像图层缓存。</para>
	/// </summary>
	public class ImportMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>带有要导入的缓存切片的地图图像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </param>
		/// <param name="SourceCacheType">
		/// <para>Source Cache Type</para>
		/// <para>将缓存从缓存数据集或切片包导入到服务器上运行的缓存地图或影像服务。</para>
		/// <para>地图或影像服务缓存—使用 ArcGIS Server 生成的地图或影像服务缓存。 其可用于 ArcGIS Desktop 并通过 ArcGIS Server 地图或影像服务对其进行使用。</para>
		/// <para>切片包—将缓存数据集作为图层添加并合并以便实现共享的单个压缩文件。 可用于 ArcGIS Desktop、ArcGIS Runtime 和移动应用程序。</para>
		/// <para><see cref="SourceCacheTypeEnum"/></para>
		/// </param>
		public ImportMapServerCache(object InputService, object SourceCacheType)
		{
			this.InputService = InputService;
			this.SourceCacheType = SourceCacheType;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入地图服务器缓存</para>
		/// </summary>
		public override string DisplayName() => "导入地图服务器缓存";

		/// <summary>
		/// <para>Tool Name : ImportMapServerCache</para>
		/// </summary>
		public override string ToolName() => "ImportMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.ImportMapServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.ImportMapServerCache";

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
		public override object[] Parameters() => new object[] { InputService, SourceCacheType, SourceCacheDataset, SourceTilePackage, UploadDataToServer, Scales, NumOfCachingServiceInstances, AreaOfInterest, ImportExtent, Overwrite, OutJobUrl };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>带有要导入的缓存切片的地图图像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Source Cache Type</para>
		/// <para>将缓存从缓存数据集或切片包导入到服务器上运行的缓存地图或影像服务。</para>
		/// <para>地图或影像服务缓存—使用 ArcGIS Server 生成的地图或影像服务缓存。 其可用于 ArcGIS Desktop 并通过 ArcGIS Server 地图或影像服务对其进行使用。</para>
		/// <para>切片包—将缓存数据集作为图层添加并合并以便实现共享的单个压缩文件。 可用于 ArcGIS Desktop、ArcGIS Runtime 和移动应用程序。</para>
		/// <para><see cref="SourceCacheTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SourceCacheType { get; set; } = "CACHE_DATASET";

		/// <summary>
		/// <para>Source Cache Dataset</para>
		/// <para>将导入的切片所在的路径位置。 浏览时此路径由栅格数据集图标表示。 您不必指定已注册的服务器缓存目录；多数情况下，需要指定磁盘上之前已导入切片的位置。 ArcGIS Server 帐户应能访问此位置。 如果无法向 ArcGIS Server 帐户授予此位置的访问权限，则请选中将数据上传到服务器参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object SourceCacheDataset { get; set; }

		/// <summary>
		/// <para>Source Tile Package</para>
		/// <para>将导入的切片包所在的路径。 ArcGIS Server 帐户应能访问此位置。 将切片包文件导入到缓存地图或影像服务时会自动启用将数据上传到服务器参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("tpk", "tpkx")]
		public object SourceTilePackage { get; set; }

		/// <summary>
		/// <para>Upload data to server</para>
		/// <para>如果 ArcGIS Server 帐户没有源缓存的读取权限，请选中此参数。 工具会在源缓存移至 ArcGIS Server 缓存目录前将其上传到 ArcGIS Server 上传目录。</para>
		/// <para>选中 - 将切片放到服务器上传目录中，且随后将其移至服务器缓存目录。 如果源缓存类型参数设置为 TILE_PACKAGE，则此选项默认处于活动状态。</para>
		/// <para>未选中 - 将切片直接导入服务器缓存目录。 ArcGIS Server 帐户必须有源缓存的读取权限。</para>
		/// <para><see cref="UploadDataToServerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UploadDataToServer { get; set; } = "false";

		/// <summary>
		/// <para>Scales</para>
		/// <para>导入切片时使用的比例级别列表。</para>
		/// <para>默认情况下，工具对话框中所列出的比例介于该服务的最小和最大缓存比例之间。 要更新比例范围，请转至服务编辑器缓存选项卡，然后使用滑块更新最小和最大缓存比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
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
		/// <para>对将切片导入到缓存时所处的位置进行空间约束的感兴趣区。 此参数在您想要导入形状不规则区域的切片时非常有用，因为该工具会按像素分辨率裁剪与面相交的缓存数据集，然后将其导入到服务器缓存目录。</para>
		/// <para>如果未提供该参数的值，则将使用导入范围参数的值。 默认情况下将使用地图的全图范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Import Extent</para>
		/// <para>定义要导入到缓存的切片的矩形范围。 默认情况下，此范围将设置为要导入切片所属的地图服务的全图范围。 请注意此感兴趣区工具中的可选参数，此工具允许您使用不规则的形状对所导入的切片进行空间约束。 如果为两个参数都提供了值，则感兴趣区参数的优先级高于导入范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of interest (Envelope)")]
		public object ImportExtent { get; set; }

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// <para>指定目标缓存中的图像是与原始缓存中的切片合并，还是被其覆盖。</para>
		/// <para>选中 - 导入过程会替换感兴趣区域的所有像素，并用原始缓存中的切片有效覆盖目标缓存中的切片。</para>
		/// <para>未选中 - 导入切片后，默认情况下将忽略原始缓存中的透明像素。 将导致目标缓存中的图像合并或混合。 这是默认设置。</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutJobUrl { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Source Cache Type</para>
		/// </summary>
		public enum SourceCacheTypeEnum 
		{
			/// <summary>
			/// <para>地图或影像服务缓存—使用 ArcGIS Server 生成的地图或影像服务缓存。 其可用于 ArcGIS Desktop 并通过 ArcGIS Server 地图或影像服务对其进行使用。</para>
			/// </summary>
			[GPValue("CACHE_DATASET")]
			[Description("地图或影像服务缓存")]
			Map_or_image_service_cache,

			/// <summary>
			/// <para>切片包—将缓存数据集作为图层添加并合并以便实现共享的单个压缩文件。 可用于 ArcGIS Desktop、ArcGIS Runtime 和移动应用程序。</para>
			/// </summary>
			[GPValue("TILE_PACKAGE")]
			[Description("切片包")]
			Tile_package,

		}

		/// <summary>
		/// <para>Upload data to server</para>
		/// </summary>
		public enum UploadDataToServerEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPLOAD_DATA")]
			UPLOAD_DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_UPLOAD")]
			DO_NOT_UPLOAD,

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
