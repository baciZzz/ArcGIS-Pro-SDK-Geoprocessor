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
	/// <para>Download Rasters</para>
	/// <para>下载栅格</para>
	/// <para>下载影像服务或镶嵌数据集中的源文件。</para>
	/// </summary>
	public class DownloadRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InImageService">
		/// <para>Input</para>
		/// <para>要下载的影像服务或镶嵌数据集。</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>影像服务或镶嵌数据集的目标。</para>
		/// </param>
		public DownloadRasters(object InImageService, object OutFolder)
		{
			this.InImageService = InImageService;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 下载栅格</para>
		/// </summary>
		public override string DisplayName() => "下载栅格";

		/// <summary>
		/// <para>Tool Name : DownloadRasters</para>
		/// </summary>
		public override string ToolName() => "DownloadRasters";

		/// <summary>
		/// <para>Tool Excute Name : management.DownloadRasters</para>
		/// </summary>
		public override string ExcuteName() => "management.DownloadRasters";

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
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InImageService, OutFolder, WhereClause!, SelectionFeature!, Clipping!, ConvertRasters!, Format!, CompressionMethod!, CompressionQuality!, MAINTAINFOLDER!, DerivedOutFolder! };

		/// <summary>
		/// <para>Input</para>
		/// <para>要下载的影像服务或镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InImageService { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>影像服务或镶嵌数据集的目标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>SQL 表达式，用于将下载限制到满足表达式的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Selection Feature</para>
		/// <para>将下载限制到要素类范围或边界框。将下载与该范围相交的所有栅格数据集。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? SelectionFeature { get; set; }

		/// <summary>
		/// <para>Clipping Using Selection Feature</para>
		/// <para>指定是否想根据要素的几何来裁剪下载的图像。这样就会裁剪与裁剪几何相交的任何栅格，然后将其下载。当感兴趣区域不是矩形时，这个选项非常有用。在裁剪已下载的影像时，需要指定裁剪影像的输出格式。</para>
		/// <para>取消选中 - 基于指定的最小外接矩形对文件进行裁剪。这是默认设置。</para>
		/// <para>选中 - 基于选择要素的几何对文件进行裁剪。</para>
		/// <para><see cref="ClippingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Clipping { get; set; } = "false";

		/// <summary>
		/// <para>Convert Rasters</para>
		/// <para>选择始终将栅格转换为指定格式，还是仅在需要时进行转换。</para>
		/// <para>取消选中 - 不会将栅格数据集转换为新的格式。</para>
		/// <para>选中 - 将下载的栅格数据集转换为其他格式。如果使用选择要素限制范围，您将需要在输出格式参数中指定格式。</para>
		/// <para><see cref="ConvertRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConvertRasters { get; set; } = "false";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>为已下载的栅格数据集选择输出格式。</para>
		/// <para>Tiff—标记图像文件格式。这是默认设置。</para>
		/// <para>Bil—Esri 波段按行交叉格式。</para>
		/// <para>Bsq—Esri 波段顺序格式。</para>
		/// <para>Bip—Esri 波段按像元交叉格式。</para>
		/// <para>Bmp—位图。</para>
		/// <para>ENVI Dat—ENVI DAT 文件。</para>
		/// <para>Imagine 图像—ERDAS IMAGINE。</para>
		/// <para>Jpeg—联合图像专家组。如果已选择，也可指定压缩质量。压缩质量的有效值范围是 0 到 100。</para>
		/// <para>Gif—图形交换格式。</para>
		/// <para>Jp2—JPEG 2000。如果已选择，也可指定压缩质量。压缩质量的有效值范围是 0 到 100。</para>
		/// <para>Png—可移植网络图形。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>选择使用指定输出格式的压缩方法。</para>
		/// <para>无—不会发生任何压缩。这是默认设置。</para>
		/// <para>Jpeg—使用公共 JPEG 压缩算法的有损压缩。如果选择 JPEG，还可以指定压缩质量。压缩质量的有效值范围是 0 到 100。这种压缩方式可用于 JPEG 文件和 TIFF 文件。</para>
		/// <para>Lzw—保留所有栅格像元值的无损压缩。</para>
		/// <para>Packbits—用于 TIFF 文件的 PackBits 压缩。</para>
		/// <para>Rle—用于 IMG 文件的游程编码。</para>
		/// <para>Ccitt Group 3—用于 1 位数据的无损压缩。</para>
		/// <para>Ccitt Group 4—用于 1 位数据的无损压缩。</para>
		/// <para>Ccitt 1D—用于 1 位数据的无损压缩。</para>
		/// <para><see cref="CompressionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CompressionMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>设置一个 1 到 100 之间的值。值越高则图像质量越好，但压缩程度也越低。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? CompressionQuality { get; set; }

		/// <summary>
		/// <para>Maintain Folder Structure</para>
		/// <para>确定所下载栅格的文件夹结构。</para>
		/// <para>选中 - 复制用于存储源栅格数据集的层次文件夹结构。</para>
		/// <para>取消选中 - 栅格数据集将下载到输出文件夹中作为平面文件夹结构</para>
		/// <para><see cref="MAINTAINFOLDEREnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MAINTAINFOLDER { get; set; } = "false";

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedOutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DownloadRasters SetEnviroment(object? extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clipping Using Selection Feature</para>
		/// </summary>
		public enum ClippingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIPPING")]
			CLIPPING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLIPPING")]
			NO_CLIPPING,

		}

		/// <summary>
		/// <para>Convert Rasters</para>
		/// </summary>
		public enum ConvertRastersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALWAYS_CONVERT")]
			ALWAYS_CONVERT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CONVERT_AS_REQUIRED")]
			CONVERT_AS_REQUIRED,

		}

		/// <summary>
		/// <para>Compression Method</para>
		/// </summary>
		public enum CompressionMethodEnum 
		{
			/// <summary>
			/// <para>无—不会发生任何压缩。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>Jpeg—使用公共 JPEG 压缩算法的有损压缩。如果选择 JPEG，还可以指定压缩质量。压缩质量的有效值范围是 0 到 100。这种压缩方式可用于 JPEG 文件和 TIFF 文件。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("Jpeg")]
			Jpeg,

			/// <summary>
			/// <para>Lzw—保留所有栅格像元值的无损压缩。</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("Lzw")]
			Lzw,

			/// <summary>
			/// <para>Packbits—用于 TIFF 文件的 PackBits 压缩。</para>
			/// </summary>
			[GPValue("PACKBITS")]
			[Description("Packbits")]
			Packbits,

			/// <summary>
			/// <para>Rle—用于 IMG 文件的游程编码。</para>
			/// </summary>
			[GPValue("RLE")]
			[Description("Rle")]
			Rle,

			/// <summary>
			/// <para>Ccitt Group 3—用于 1 位数据的无损压缩。</para>
			/// </summary>
			[GPValue("CCITT_GROUP3")]
			[Description("Ccitt Group 3")]
			Ccitt_Group_3,

			/// <summary>
			/// <para>Ccitt Group 4—用于 1 位数据的无损压缩。</para>
			/// </summary>
			[GPValue("CCITT_GROUP4")]
			[Description("Ccitt Group 4")]
			Ccitt_Group_4,

			/// <summary>
			/// <para>Ccitt 1D—用于 1 位数据的无损压缩。</para>
			/// </summary>
			[GPValue("CCITT_1D")]
			[Description("Ccitt 1D")]
			Ccitt_1D,

		}

		/// <summary>
		/// <para>Maintain Folder Structure</para>
		/// </summary>
		public enum MAINTAINFOLDEREnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_FOLDER")]
			MAINTAIN_FOLDER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAINTAIN_FOLDER")]
			NO_MAINTAIN_FOLDER,

		}

#endregion
	}
}
