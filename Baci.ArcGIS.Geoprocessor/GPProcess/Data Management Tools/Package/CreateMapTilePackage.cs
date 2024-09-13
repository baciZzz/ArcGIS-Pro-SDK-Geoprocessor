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
	/// <para>Create Map Tile Package</para>
	/// <para>创建地图切片包</para>
	/// <para>从地图或底图生成切片，并将切片进行打包从而创建单个压缩的 .tpk 文件。</para>
	/// </summary>
	public class CreateMapTilePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>用于生成切片并对其进行打包的地图。</para>
		/// </param>
		/// <param name="ServiceType">
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>指定是从现有的地图服务生成切片方案，还是根据 ArcGIS Online、Bing 地图和 Google 地图生成地图切片。</para>
		/// <para>选中 - 将使用 ArcGIS Online/Bing Maps/Google Maps 切片方案。 这是默认设置。ArcGIS Online/Bing 地图/Google 地图切片方案可用于将您的缓存切片与这些在线地图服务的切片进行叠加。加载切片方案时，ArcGIS Desktop 以内置选项形式包括此切片方案。选择此切片方案时，源地图必须使用 WGS 1984 Web Mercator (Auxiliary Sphere) 投影坐标系。</para>
		/// <para>如果要将您的包与 ArcGIS Online、Bing 地图或 Google 地图进行叠加，则需要使用 ArcGIS Online/Bing 地图/Google 地图切片方案。ArcGIS Online/Bing 地图/Google 地图切片方案的优势在于其在 Web 地图领域内的高熟识度，所以您的切片将与其他使用此切片方案的组织的切片相一致。即使您不打算叠加这些广为熟知的地图服务，仍然可以选择此切片方案以便于互操作。</para>
		/// <para>ArcGIS Online/Bing 地图/Google 地图切片方案可能包含过度放大以至于无法在地图中使用的比例。在大比例下进行打包相当耗时，且会占用大量磁盘存储空间。例如，切片方案中的最大比例约为 1:1,000。在此比例下缓存整个美国大陆可能将耗费数周时间并需要数百 GB 的存储空间。如果尚未准备好在此比例级别下进行打包，则在创建切片包时移除此比例级别。</para>
		/// <para>未选中 - 使用一个现有地图服务的切片方案。如果您的组织已在服务器上创建现有服务的切片方案并且您想要与其进行匹配，则请选择此选项。相匹配的切片方案可确保切片在 ArcGIS Runtime 应用程序中正确叠加。</para>
		/// <para>如果选择此选项，则源地图和用于导入切片方案的地图将使用相同的坐标系。</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出地图切片包。</para>
		/// </param>
		/// <param name="FormatType">
		/// <para>Tiling Format</para>
		/// <para>指定生成切片的格式。</para>
		/// <para>PNG—根据指定的细节层次，使用 PNG 自动选择正确的格式（PNG 8、PNG 24 或 PNG 32）。 这是默认设置。</para>
		/// <para>PNG（8 位）—PNG 8 用于需要具有透明背景的叠加服务，例如道路和边界。 PNG8 可在磁盘上创建非常小的切片且不损失任何信息。如果地图包含的颜色超过 256 种，请勿使用 PNG 8。 影像、山体阴影、梯度填充、透明度和抗锯齿可轻易地使地图包含的颜色超过 256 种。 符号（如高速公路盾形路牌符号）也可能在其边缘周围具有细微的抗锯齿，从而使地图包含意料之外的更多颜色。</para>
		/// <para>PNG（24 位）—可将 PNG 24 用于超过 256 种颜色的叠加服务，例如道路和边界。如果少于 256 种颜色，请使用 PNG 8。</para>
		/// <para>PNG（32 位）—PNG 32 用于超过 256 种颜色的叠加服务，例如道路和边界。 PNG 32 特别适用于对线或文本启用了抗锯齿的叠加服务。 与 PNG 24 相比，PNG 32 可磁盘上创建更大的切片。</para>
		/// <para>JPEG—此格式用于颜色变化较大但不需要透明背景的底图服务。 例如，栅格图像和非常详细的矢量底图特别适合使用 JPEG。JPEG 为有损图像格式。 在不影响图像显示效果的情况下，它会尝试有选择地删除数据。 这会在磁盘上产生很小的切片，但如果地图包含矢量线作业或标注，它可能会在线周围生成过多的噪声或模糊区域。 如果发生这种情况，可尝试将压缩值从默认的 75 增加到更大的值。 更高的值（如 90）可以生成可接受的线作业质量，同时还可保证 JPEG 格式的小切片优势。您将确定可接受的图像质量。 如果愿意接受图像中存在少量噪声，选择 JPEG 可节省大量的磁盘空间。 较小的切片大小也意味着应用程序可以更快地下载切片。</para>
		/// <para>混合—混合包在包的中心使用 JPEG，同时在包的边缘使用 PNG 32。 要在其他图层上完全叠加栅格包时，请使用混合模式。创建混合包时，在检测到透明度的任何位置（也就是地图背景可见的位置）都会创建 PNG 32 切片。 其余切片使用 JPEG 构建。 这可降低平均文件大小，同时可在其他包上进行完全叠加。 如果在这种情况下不使用混合模式包，将在图像叠加其他包的外围区域看到一个不透明的凸边。</para>
		/// <para><see cref="FormatTypeEnum"/></para>
		/// </param>
		/// <param name="LevelOfDetail">
		/// <para>Maximum Level Of Detail</para>
		/// <para>生成包切片的最高比例。 默认值为 1。 可能的值为 1 至 24。</para>
		/// <para>较大的值反映较大的比例，可以显示更多细节，但是占用更多存储空间，较小的值反映较小的比例，显示的细节较少，占用的存储空间也较少。</para>
		/// <para>此值必须大于或等于最低细节层次。</para>
		/// </param>
		public CreateMapTilePackage(object InMap, object ServiceType, object OutputFile, object FormatType, object LevelOfDetail)
		{
			this.InMap = InMap;
			this.ServiceType = ServiceType;
			this.OutputFile = OutputFile;
			this.FormatType = FormatType;
			this.LevelOfDetail = LevelOfDetail;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建地图切片包</para>
		/// </summary>
		public override string DisplayName() => "创建地图切片包";

		/// <summary>
		/// <para>Tool Name : CreateMapTilePackage</para>
		/// </summary>
		public override string ToolName() => "CreateMapTilePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMapTilePackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateMapTilePackage";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, ServiceType, OutputFile, FormatType, LevelOfDetail, ServiceFile, Summary, Tags, Extent, CompressionQuality, PackageType, MinLevelOfDetail };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>用于生成切片并对其进行打包的地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>指定是从现有的地图服务生成切片方案，还是根据 ArcGIS Online、Bing 地图和 Google 地图生成地图切片。</para>
		/// <para>选中 - 将使用 ArcGIS Online/Bing Maps/Google Maps 切片方案。 这是默认设置。ArcGIS Online/Bing 地图/Google 地图切片方案可用于将您的缓存切片与这些在线地图服务的切片进行叠加。加载切片方案时，ArcGIS Desktop 以内置选项形式包括此切片方案。选择此切片方案时，源地图必须使用 WGS 1984 Web Mercator (Auxiliary Sphere) 投影坐标系。</para>
		/// <para>如果要将您的包与 ArcGIS Online、Bing 地图或 Google 地图进行叠加，则需要使用 ArcGIS Online/Bing 地图/Google 地图切片方案。ArcGIS Online/Bing 地图/Google 地图切片方案的优势在于其在 Web 地图领域内的高熟识度，所以您的切片将与其他使用此切片方案的组织的切片相一致。即使您不打算叠加这些广为熟知的地图服务，仍然可以选择此切片方案以便于互操作。</para>
		/// <para>ArcGIS Online/Bing 地图/Google 地图切片方案可能包含过度放大以至于无法在地图中使用的比例。在大比例下进行打包相当耗时，且会占用大量磁盘存储空间。例如，切片方案中的最大比例约为 1:1,000。在此比例下缓存整个美国大陆可能将耗费数周时间并需要数百 GB 的存储空间。如果尚未准备好在此比例级别下进行打包，则在创建切片包时移除此比例级别。</para>
		/// <para>未选中 - 使用一个现有地图服务的切片方案。如果您的组织已在服务器上创建现有服务的切片方案并且您想要与其进行匹配，则请选择此选项。相匹配的切片方案可确保切片在 ArcGIS Runtime 应用程序中正确叠加。</para>
		/// <para>如果选择此选项，则源地图和用于导入切片方案的地图将使用相同的坐标系。</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ServiceType { get; set; } = "true";

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出地图切片包。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("tpk", "tpkx")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Tiling Format</para>
		/// <para>指定生成切片的格式。</para>
		/// <para>PNG—根据指定的细节层次，使用 PNG 自动选择正确的格式（PNG 8、PNG 24 或 PNG 32）。 这是默认设置。</para>
		/// <para>PNG（8 位）—PNG 8 用于需要具有透明背景的叠加服务，例如道路和边界。 PNG8 可在磁盘上创建非常小的切片且不损失任何信息。如果地图包含的颜色超过 256 种，请勿使用 PNG 8。 影像、山体阴影、梯度填充、透明度和抗锯齿可轻易地使地图包含的颜色超过 256 种。 符号（如高速公路盾形路牌符号）也可能在其边缘周围具有细微的抗锯齿，从而使地图包含意料之外的更多颜色。</para>
		/// <para>PNG（24 位）—可将 PNG 24 用于超过 256 种颜色的叠加服务，例如道路和边界。如果少于 256 种颜色，请使用 PNG 8。</para>
		/// <para>PNG（32 位）—PNG 32 用于超过 256 种颜色的叠加服务，例如道路和边界。 PNG 32 特别适用于对线或文本启用了抗锯齿的叠加服务。 与 PNG 24 相比，PNG 32 可磁盘上创建更大的切片。</para>
		/// <para>JPEG—此格式用于颜色变化较大但不需要透明背景的底图服务。 例如，栅格图像和非常详细的矢量底图特别适合使用 JPEG。JPEG 为有损图像格式。 在不影响图像显示效果的情况下，它会尝试有选择地删除数据。 这会在磁盘上产生很小的切片，但如果地图包含矢量线作业或标注，它可能会在线周围生成过多的噪声或模糊区域。 如果发生这种情况，可尝试将压缩值从默认的 75 增加到更大的值。 更高的值（如 90）可以生成可接受的线作业质量，同时还可保证 JPEG 格式的小切片优势。您将确定可接受的图像质量。 如果愿意接受图像中存在少量噪声，选择 JPEG 可节省大量的磁盘空间。 较小的切片大小也意味着应用程序可以更快地下载切片。</para>
		/// <para>混合—混合包在包的中心使用 JPEG，同时在包的边缘使用 PNG 32。 要在其他图层上完全叠加栅格包时，请使用混合模式。创建混合包时，在检测到透明度的任何位置（也就是地图背景可见的位置）都会创建 PNG 32 切片。 其余切片使用 JPEG 构建。 这可降低平均文件大小，同时可在其他包上进行完全叠加。 如果在这种情况下不使用混合模式包，将在图像叠加其他包的外围区域看到一个不透明的凸边。</para>
		/// <para><see cref="FormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FormatType { get; set; } = "PNG";

		/// <summary>
		/// <para>Maximum Level Of Detail</para>
		/// <para>生成包切片的最高比例。 默认值为 1。 可能的值为 1 至 24。</para>
		/// <para>较大的值反映较大的比例，可以显示更多细节，但是占用更多存储空间，较小的值反映较小的比例，显示的细节较少，占用的存储空间也较少。</para>
		/// <para>此值必须大于或等于最低细节层次。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 20)]
		public object LevelOfDetail { get; set; } = "1";

		/// <summary>
		/// <para>Service</para>
		/// <para>用于切片方案的地图服务或 XML 文件的名称。 仅当未选中适用于 ArcGIS Online | Bing Maps | Google Maps 的包参数时才需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object ServiceFile { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将摘要信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将标签信息添加到包的属性中。 可以添加多个标签，用逗号或分号分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定用于选择或裁剪要素的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>针对 JPEG 压缩质量的介于 1 和 100 之间的值。 对于 JPEG 切片格式，默认值为 75；对于其他切片格式，默认值为 0。</para>
		/// <para>仅 JPEG 和 MIXED 格式支持压缩。 如果选择较高的值，则生成的文件较大，但图像质量较好。 如果选择较低的值，则生成的文件较小，但图像质量较差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Package type</para>
		/// <para>指定将创建的切片包类型。</para>
		/// <para>tpk—切片使用 Compact 存储格式进行存储。 整个 ArcGIS 平台均支持。</para>
		/// <para>tpkx—切片使用 CompactV2 存储格式进行存储，该格式可提供更好的网络共享和云存储目录性能。 ArcGIS 产品的较新版本（例如 ArcGIS Online 7.1、ArcGIS Enterprise 10.7 和 ArcGIS Runtime 100.5）均支持这种改进并简化的包结构类型。 这是默认设置。</para>
		/// <para><see cref="PackageTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PackageType { get; set; } = "tpkx";

		/// <summary>
		/// <para>Minimum Level Of Detail</para>
		/// <para>生成包切片的最低比例。 默认值为 1。 可能的值为 1 至 24。</para>
		/// <para>较大的值反映较大的比例，可以显示更多细节，但是占用更多存储空间，较小的值反映较小的比例，显示的细节较少，占用的存储空间也较少。</para>
		/// <para>此值必须小于或等于最高细节层次。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 24)]
		public object MinLevelOfDetail { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateMapTilePackage SetEnviroment(object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// </summary>
		public enum ServiceTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLINE")]
			ONLINE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXISTING")]
			EXISTING,

		}

		/// <summary>
		/// <para>Tiling Format</para>
		/// </summary>
		public enum FormatTypeEnum 
		{
			/// <summary>
			/// <para>PNG—根据指定的细节层次，使用 PNG 自动选择正确的格式（PNG 8、PNG 24 或 PNG 32）。 这是默认设置。</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>PNG（8 位）—PNG 8 用于需要具有透明背景的叠加服务，例如道路和边界。 PNG8 可在磁盘上创建非常小的切片且不损失任何信息。如果地图包含的颜色超过 256 种，请勿使用 PNG 8。 影像、山体阴影、梯度填充、透明度和抗锯齿可轻易地使地图包含的颜色超过 256 种。 符号（如高速公路盾形路牌符号）也可能在其边缘周围具有细微的抗锯齿，从而使地图包含意料之外的更多颜色。</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("PNG（8 位）")]
			PNG_8_bit,

			/// <summary>
			/// <para>PNG（24 位）—可将 PNG 24 用于超过 256 种颜色的叠加服务，例如道路和边界。如果少于 256 种颜色，请使用 PNG 8。</para>
			/// </summary>
			[GPValue("PNG24")]
			[Description("PNG（24 位）")]
			PNG_24_bit,

			/// <summary>
			/// <para>PNG（32 位）—PNG 32 用于超过 256 种颜色的叠加服务，例如道路和边界。 PNG 32 特别适用于对线或文本启用了抗锯齿的叠加服务。 与 PNG 24 相比，PNG 32 可磁盘上创建更大的切片。</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("PNG（32 位）")]
			PNG_32_bit,

			/// <summary>
			/// <para>JPEG—此格式用于颜色变化较大但不需要透明背景的底图服务。 例如，栅格图像和非常详细的矢量底图特别适合使用 JPEG。JPEG 为有损图像格式。 在不影响图像显示效果的情况下，它会尝试有选择地删除数据。 这会在磁盘上产生很小的切片，但如果地图包含矢量线作业或标注，它可能会在线周围生成过多的噪声或模糊区域。 如果发生这种情况，可尝试将压缩值从默认的 75 增加到更大的值。 更高的值（如 90）可以生成可接受的线作业质量，同时还可保证 JPEG 格式的小切片优势。您将确定可接受的图像质量。 如果愿意接受图像中存在少量噪声，选择 JPEG 可节省大量的磁盘空间。 较小的切片大小也意味着应用程序可以更快地下载切片。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>混合—混合包在包的中心使用 JPEG，同时在包的边缘使用 PNG 32。 要在其他图层上完全叠加栅格包时，请使用混合模式。创建混合包时，在检测到透明度的任何位置（也就是地图背景可见的位置）都会创建 PNG 32 切片。 其余切片使用 JPEG 构建。 这可降低平均文件大小，同时可在其他包上进行完全叠加。 如果在这种情况下不使用混合模式包，将在图像叠加其他包的外围区域看到一个不透明的凸边。</para>
			/// </summary>
			[GPValue("MIXED")]
			[Description("混合")]
			Mixed,

		}

		/// <summary>
		/// <para>Package type</para>
		/// </summary>
		public enum PackageTypeEnum 
		{
			/// <summary>
			/// <para>tpk—切片使用 Compact 存储格式进行存储。 整个 ArcGIS 平台均支持。</para>
			/// </summary>
			[GPValue("tpk")]
			[Description("tpk")]
			tpk,

			/// <summary>
			/// <para>tpkx—切片使用 CompactV2 存储格式进行存储，该格式可提供更好的网络共享和云存储目录性能。 ArcGIS 产品的较新版本（例如 ArcGIS Online 7.1、ArcGIS Enterprise 10.7 和 ArcGIS Runtime 100.5）均支持这种改进并简化的包结构类型。 这是默认设置。</para>
			/// </summary>
			[GPValue("tpkx")]
			[Description("tpkx")]
			tpkx,

		}

#endregion
	}
}
