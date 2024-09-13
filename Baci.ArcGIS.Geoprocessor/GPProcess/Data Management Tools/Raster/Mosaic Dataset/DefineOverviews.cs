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
	/// <para>Define Overviews</para>
	/// <para>定义概视图</para>
	/// <para>允许您设置生成镶嵌数据集概视图的方式。构建概视图工具将使用您通过此工具创建的设置。</para>
	/// </summary>
	public class DefineOverviews : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>要在其中构建概视图的镶嵌数据集。</para>
		/// </param>
		public DefineOverviews(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 定义概视图</para>
		/// </summary>
		public override string DisplayName() => "定义概视图";

		/// <summary>
		/// <para>Tool Name : DefineOverviews</para>
		/// </summary>
		public override string ToolName() => "DefineOverviews";

		/// <summary>
		/// <para>Tool Excute Name : management.DefineOverviews</para>
		/// </summary>
		public override string ExcuteName() => "management.DefineOverviews";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OverviewImageFolder, InTemplateDataset, Extent, PixelSize, NumberOfLevels, TileRows, TileCols, OverviewFactor, ForceOverviewTiles, ResamplingMethod, CompressionMethod, CompressionQuality, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>要在其中构建概视图的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>用于存储概视图的文件夹或地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
		public object OverviewImageFolder { get; set; }

		/// <summary>
		/// <para>Extent from Dataset</para>
		/// <para>一个栅格数据集或要素类，用来定义概视图的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InTemplateDataset { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>使用下列最小和最大 x 和 y 坐标手动设置范围。</para>
		/// <para>如果未定义范围，则镶嵌数据集边界将确定概视图的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Pixel Size</para>
		/// <para>如果不想使用所有栅格金字塔，可指定将生成概视图的基础像素大小。</para>
		/// <para>此参数的单位与镶嵌数据集的空间参考单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Overview Tile Parameters")]
		public object PixelSize { get; set; }

		/// <summary>
		/// <para>Number Of Levels</para>
		/// <para>指定用于生成概视图的概视图等级数。值 -1 将用于确定最佳值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Tile Parameters")]
		public object NumberOfLevels { get; set; }

		/// <summary>
		/// <para>Number Of Rows</para>
		/// <para>设置每个切片的行数（以像素为单位）。</para>
		/// <para>较大值将生成更少的较大单个概视图，同时增加需要重新生成较低等级概视图的可能性。较小值将生成更多较小的文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Tile Parameters")]
		public object TileRows { get; set; } = "5120";

		/// <summary>
		/// <para>Number Of Columns</para>
		/// <para>设置每个切片的列数（以像素为单位）。</para>
		/// <para>较大值将生成更少的较大单个概视图，同时增加需要重新生成较低等级概视图的可能性。较小值将生成更多较小的文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Tile Parameters")]
		public object TileCols { get; set; } = "5120";

		/// <summary>
		/// <para>Overview Sampling Factor</para>
		/// <para>设置用于确定下一个概视图大小的比率。例如，如果第一个等级的像元大小为 10，概视图系数为 3，则下一个概视图像素大小将为 30。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 10)]
		[Category("Overview Tile Parameters")]
		public object OverviewFactor { get; set; } = "3";

		/// <summary>
		/// <para>Force Overview Tiles</para>
		/// <para>在所有等级生成概视图，或仅在现有金字塔等级之上生成概视图。</para>
		/// <para>取消选中 - 在栅格金字塔等级之上创建概视图。这是默认设置。</para>
		/// <para>选中 - 在所有等级创建概视图。</para>
		/// <para><see cref="ForceOverviewTilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Overview Tile Parameters")]
		public object ForceOverviewTiles { get; set; } = "false";

		/// <summary>
		/// <para>Resampling Method</para>
		/// <para>在概视图中选择聚合像素值的算法。</para>
		/// <para>最邻近—这是最快的重采样方法，因为此方法可将像素值的更改内容最小化。适用于离散数据，例如土地覆被。如果栅格元数据数据类型为专题型，则最邻近法为默认方法。</para>
		/// <para>双线性—可采用平均化（距离权重）周围 4 个像素的值计算每个像素的值。适用于连续数据。除非栅格元数据数据类型为专题型，否则这是默认方法。</para>
		/// <para>三次— 通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。生成平滑影像，但可创建位于源数据中超出范围外的值。适用于连续数据。</para>
		/// <para><see cref="ResamplingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Overview Image Parameters")]
		public object ResamplingMethod { get; set; } = "BILINEAR";

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>定义存储概视图图像的数据压缩类型。</para>
		/// <para>JPEG—有损压缩。除非栅格元数据数据类型为专题型，否则这是默认方法。此压缩方法仅在镶嵌数据集符合 JPEG 规范时才有效。</para>
		/// <para>JPEG 亮度和色度—有损压缩使用亮度 (Y) 和色度（Cb 和 Cr）颜色空间组件。</para>
		/// <para>无—无数据压缩。</para>
		/// <para>LZW—无损压缩。如果栅格元数据数据类型为专题型，则最邻近法为默认方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Overview Image Parameters")]
		public object CompressionMethod { get; set; } = "JPEG";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>选择一个 1 到 100 之间的值。较高的值可生成更高质量的输出，但创建的文件也更大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Image Parameters")]
		public object CompressionQuality { get; set; } = "80";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DefineOverviews SetEnviroment(object extent = null , object parallelProcessingFactor = null , double[] tileSize = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Force Overview Tiles</para>
		/// </summary>
		public enum ForceOverviewTilesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE_OVERVIEW_TILES")]
			FORCE_OVERVIEW_TILES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FORCE_OVERVIEW_TILES")]
			NO_FORCE_OVERVIEW_TILES,

		}

		/// <summary>
		/// <para>Resampling Method</para>
		/// </summary>
		public enum ResamplingMethodEnum 
		{
			/// <summary>
			/// <para>最邻近—这是最快的重采样方法，因为此方法可将像素值的更改内容最小化。适用于离散数据，例如土地覆被。如果栅格元数据数据类型为专题型，则最邻近法为默认方法。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>双线性—可采用平均化（距离权重）周围 4 个像素的值计算每个像素的值。适用于连续数据。除非栅格元数据数据类型为专题型，否则这是默认方法。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性")]
			Bilinear,

			/// <summary>
			/// <para>三次— 通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。生成平滑影像，但可创建位于源数据中超出范围外的值。适用于连续数据。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

		}

#endregion
	}
}
