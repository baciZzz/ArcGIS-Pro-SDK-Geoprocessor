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
	/// <para>Create Pansharpened Raster Dataset</para>
	/// <para>创建全色锐化栅格数据集</para>
	/// <para>可将高分辨率全色栅格数据集与低分辨率多波段栅格数据集进行合并，以创建用于可视分析的高分辨率多波段栅格数据集。</para>
	/// </summary>
	public class CreatePansharpenedRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>将被全色锐化的栅格数据集。</para>
		/// </param>
		/// <param name="RedChannel">
		/// <para>Red Channel</para>
		/// <para>将使用红色通道显示的输入栅格波段。</para>
		/// </param>
		/// <param name="GreenChannel">
		/// <para>Green Channel</para>
		/// <para>将使用绿色通道显示的输入栅格波段。</para>
		/// </param>
		/// <param name="BlueChannel">
		/// <para>Blue Channel</para>
		/// <para>将使用蓝色通道显示的输入栅格波段。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>将创建的栅格数据集的名称、位置和格式。</para>
		/// <para>以文件格式存储栅格数据集时，请指定文件扩展名，具体如下：</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。 以文件格式存储栅格数据集时，必须指定文件扩展名，具体如下：</para>
		/// <para>Esri BIL 为 .bil</para>
		/// <para>Esri BIP 为 .bip</para>
		/// <para>BMP 为 .bmp</para>
		/// <para>Esri BSQ 为 .bsq</para>
		/// <para>ENVI DAT 为 .dat</para>
		/// <para>GIF 为 .gif</para>
		/// <para>ERDAS IMAGINE 为 .img</para>
		/// <para>JPEG 为 .jpg</para>
		/// <para>JPEG 2000 为 .jp2</para>
		/// <para>PNG 为 .png</para>
		/// <para>TIFF 为 .tif</para>
		/// <para>MRF 为 .mrf</para>
		/// <para>CRF 为 .crf</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </param>
		/// <param name="InPanchromaticImage">
		/// <para>Panchromatic Image</para>
		/// <para>较高分辨率的全色图像。</para>
		/// </param>
		/// <param name="PansharpeningType">
		/// <para>Pan-sharpening Type</para>
		/// <para>指定将用于组合全色波段和多光谱波段的算法。</para>
		/// <para>IHS—将使用强度、色调和饱和度颜色空间。</para>
		/// <para>Brovey—将使用基于光谱建模的 Brovey 算法。</para>
		/// <para>Esri—将使用基于光谱建模的 Esri 算法。</para>
		/// <para>简单均值—将使用红色、绿色、蓝色值与全色像素值之间的平均值。</para>
		/// <para>Gram-Schmidt—将使用 Gram-Schmidt 光谱锐化算法来锐化多光谱数据。</para>
		/// <para><see cref="PansharpeningTypeEnum"/></para>
		/// </param>
		public CreatePansharpenedRasterDataset(object InRaster, object RedChannel, object GreenChannel, object BlueChannel, object OutRasterDataset, object InPanchromaticImage, object PansharpeningType)
		{
			this.InRaster = InRaster;
			this.RedChannel = RedChannel;
			this.GreenChannel = GreenChannel;
			this.BlueChannel = BlueChannel;
			this.OutRasterDataset = OutRasterDataset;
			this.InPanchromaticImage = InPanchromaticImage;
			this.PansharpeningType = PansharpeningType;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建全色锐化栅格数据集</para>
		/// </summary>
		public override string DisplayName() => "创建全色锐化栅格数据集";

		/// <summary>
		/// <para>Tool Name : CreatePansharpenedRasterDataset</para>
		/// </summary>
		public override string ToolName() => "CreatePansharpenedRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreatePansharpenedRasterDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreatePansharpenedRasterDataset";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, RedChannel, GreenChannel, BlueChannel, InfraredChannel!, OutRasterDataset, InPanchromaticImage, PansharpeningType, RedWeight!, GreenWeight!, BlueWeight!, InfraredWeight!, Sensor! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>将被全色锐化的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Red Channel</para>
		/// <para>将使用红色通道显示的输入栅格波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object RedChannel { get; set; } = "3";

		/// <summary>
		/// <para>Green Channel</para>
		/// <para>将使用绿色通道显示的输入栅格波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object GreenChannel { get; set; } = "2";

		/// <summary>
		/// <para>Blue Channel</para>
		/// <para>将使用蓝色通道显示的输入栅格波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object BlueChannel { get; set; } = "1";

		/// <summary>
		/// <para>Infrared Channel</para>
		/// <para>将使用红外通道显示的输入栅格波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? InfraredChannel { get; set; } = "1";

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>将创建的栅格数据集的名称、位置和格式。</para>
		/// <para>以文件格式存储栅格数据集时，请指定文件扩展名，具体如下：</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。 以文件格式存储栅格数据集时，必须指定文件扩展名，具体如下：</para>
		/// <para>Esri BIL 为 .bil</para>
		/// <para>Esri BIP 为 .bip</para>
		/// <para>BMP 为 .bmp</para>
		/// <para>Esri BSQ 为 .bsq</para>
		/// <para>ENVI DAT 为 .dat</para>
		/// <para>GIF 为 .gif</para>
		/// <para>ERDAS IMAGINE 为 .img</para>
		/// <para>JPEG 为 .jpg</para>
		/// <para>JPEG 2000 为 .jp2</para>
		/// <para>PNG 为 .png</para>
		/// <para>TIFF 为 .tif</para>
		/// <para>MRF 为 .mrf</para>
		/// <para>CRF 为 .crf</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Panchromatic Image</para>
		/// <para>较高分辨率的全色图像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InPanchromaticImage { get; set; }

		/// <summary>
		/// <para>Pan-sharpening Type</para>
		/// <para>指定将用于组合全色波段和多光谱波段的算法。</para>
		/// <para>IHS—将使用强度、色调和饱和度颜色空间。</para>
		/// <para>Brovey—将使用基于光谱建模的 Brovey 算法。</para>
		/// <para>Esri—将使用基于光谱建模的 Esri 算法。</para>
		/// <para>简单均值—将使用红色、绿色、蓝色值与全色像素值之间的平均值。</para>
		/// <para>Gram-Schmidt—将使用 Gram-Schmidt 光谱锐化算法来锐化多光谱数据。</para>
		/// <para><see cref="PansharpeningTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PansharpeningType { get; set; } = "Esri";

		/// <summary>
		/// <para>Red Weight</para>
		/// <para>一个介于 0 和 1 之间的值，用于对红色波段进行加权。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? RedWeight { get; set; } = "0.166";

		/// <summary>
		/// <para>Green Weight</para>
		/// <para>一个介于 0 和 1 之间的值，用于对绿色波段进行加权。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? GreenWeight { get; set; } = "0.167";

		/// <summary>
		/// <para>Blue Weight</para>
		/// <para>一个介于 0 和 1 之间的值，用于对蓝色波段进行加权。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BlueWeight { get; set; } = "0.167";

		/// <summary>
		/// <para>Infrared Weight</para>
		/// <para>一个介于 0 和 1 之间的值，用于对红外波段进行加权。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? InfraredWeight { get; set; } = "0.5";

		/// <summary>
		/// <para>Sensor</para>
		/// <para>指定多波段光栅输入的传感器。</para>
		/// <para>当将全色锐化类型参数设置为 Gram-Schmidt 时，可以指定传感器。 指定传感器将设置相应的波段权重。</para>
		/// <para>未知—未知或未列出的传感器</para>
		/// <para>DubaiSat-2—DubaiSat-2 卫星传感器</para>
		/// <para>GeoEye-1—GeoEye-1 和 OrbView-3 卫星传感器</para>
		/// <para>GF-1 PMS—Gao Fen 卫星 1，全色和多光谱 CCD 照相机</para>
		/// <para>GF-2 PMS—Gao Fen 2 卫星，全色和多光谱 CCD 照相机</para>
		/// <para>IKONOS—IKONOS 卫星传感器</para>
		/// <para>Jilin-1—Jilin-1 卫星传感器</para>
		/// <para>KOMPSAT-2—KOMPSAT-2 卫星传感器</para>
		/// <para>KOMPSAT-3—KOMPSAT-3 卫星传感器</para>
		/// <para>Landsat 1-5 MSS—Landsat MSS 卫星传感器</para>
		/// <para>Landsat 7 ETM+—Landsat 7 卫星传感器</para>
		/// <para>Landsat 8—Landsat 8 卫星传感器</para>
		/// <para>Landsat 9—Landsat 9 卫星传感器</para>
		/// <para>Pléiades-1—Pléiades 卫星传感器</para>
		/// <para>Pléiades Neo—Pléiades Neo 卫星传感器</para>
		/// <para>Quickbird—QuickBird 卫星传感器</para>
		/// <para>SkySat-C—SkySat-C 卫星传感器</para>
		/// <para>SPOT 5—SPOT 5 卫星传感器</para>
		/// <para>SPOT 6—SPOT 6 卫星传感器</para>
		/// <para>SPOT 7—SPOT 7 卫星传感器</para>
		/// <para>SuperView-1—SuperView-1 卫星传感器</para>
		/// <para>Tian Hui 1—Tian Hui 1 卫星传感器</para>
		/// <para>Ultracam—UltraCam 航空传感器</para>
		/// <para>WorldView-2—WorldView-2 卫星传感器</para>
		/// <para>WorldView-3—WorldView-3 卫星传感器</para>
		/// <para>WorldView-4—WorldView-4 卫星传感器</para>
		/// <para>ZY-1 PMS—Ziyuan 高分辨率全色多光谱传感器</para>
		/// <para>ZY-3 CRESDA—Ziyuan CRESDA 卫星传感器</para>
		/// <para>ZY-3 SASMAC—Ziyuan SASMAC 卫星传感器</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Sensor { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreatePansharpenedRasterDataset SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Pan-sharpening Type</para>
		/// </summary>
		public enum PansharpeningTypeEnum 
		{
			/// <summary>
			/// <para>IHS—将使用强度、色调和饱和度颜色空间。</para>
			/// </summary>
			[GPValue("IHS")]
			[Description("IHS")]
			IHS,

			/// <summary>
			/// <para>Brovey—将使用基于光谱建模的 Brovey 算法。</para>
			/// </summary>
			[GPValue("BROVEY")]
			[Description("Brovey")]
			Brovey,

			/// <summary>
			/// <para>Esri—将使用基于光谱建模的 Esri 算法。</para>
			/// </summary>
			[GPValue("Esri")]
			[Description("Esri")]
			Esri,

			/// <summary>
			/// <para>简单均值—将使用红色、绿色、蓝色值与全色像素值之间的平均值。</para>
			/// </summary>
			[GPValue("SIMPLE_MEAN")]
			[Description("简单均值")]
			Simple_mean,

			/// <summary>
			/// <para>Gram-Schmidt—将使用 Gram-Schmidt 光谱锐化算法来锐化多光谱数据。</para>
			/// </summary>
			[GPValue("Gram-Schmidt")]
			[Description("Gram-Schmidt")]
			Gram_Schmidt,

		}

#endregion
	}
}
