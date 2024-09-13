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
	/// <para>Build Pyramids</para>
	/// <para>构建金字塔</para>
	/// <para>为栅格数据集构建栅格金字塔。</para>
	/// </summary>
	public class BuildPyramids : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterDataset">
		/// <para>Input Raster Dataset</para>
		/// <para>要构建金字塔的栅格数据集。</para>
		/// <para>输入数据集的行数和列数都应超过 1,024 个。</para>
		/// </param>
		public BuildPyramids(object InRasterDataset)
		{
			this.InRasterDataset = InRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建金字塔</para>
		/// </summary>
		public override string DisplayName() => "构建金字塔";

		/// <summary>
		/// <para>Tool Name : BuildPyramids</para>
		/// </summary>
		public override string ToolName() => "BuildPyramids";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildPyramids</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildPyramids";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "pyramid", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterDataset, PyramidLevel, SKIPFIRST, ResampleTechnique, CompressionType, CompressionQuality, SkipExisting, OutRaster };

		/// <summary>
		/// <para>Input Raster Dataset</para>
		/// <para>要构建金字塔的栅格数据集。</para>
		/// <para>输入数据集的行数和列数都应超过 1,024 个。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRasterDataset { get; set; }

		/// <summary>
		/// <para>Pyramid levels</para>
		/// <para>选择将构建的递减分辨率数据集图层的数量。 默认值为 -1，将构建完整的金字塔。 值为 0 时，将不会获得金字塔等级。</para>
		/// <para>要删除金字塔，请将等级数设为 0。</para>
		/// <para>可以指定的最大金字塔等级数为 29。任何大于或等于 30 的值都将恢复成 -1，并将创建一组完整的金字塔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object PyramidLevel { get; set; }

		/// <summary>
		/// <para>Skip first level</para>
		/// <para>选择是否跳过第一个金字塔等级。 跳过第一个等级将略微降低占用的磁盘空间大小，但将降低这些比例的性能。</para>
		/// <para>未选中 - 将构建第一个金字塔等级。 这是默认设置。</para>
		/// <para>选中 - 不构建第一个金字塔等级。</para>
		/// <para><see cref="SKIPFIRSTEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SKIPFIRST { get; set; } = "false";

		/// <summary>
		/// <para>Pyramid resampling technique</para>
		/// <para>用于构建金字塔的重采样技术。</para>
		/// <para>最邻近—重采样时，该方法使用最邻近像元的值为输出像元分配值。 这是默认设置。</para>
		/// <para>双线性法—该方法根据四个最邻近输入像元中心的加权平均距离确定像元的新值。</para>
		/// <para>三次—该方法通过拟合穿过 16 个最邻近输入像元中心的平滑曲线确定像元的新值。</para>
		/// <para><see cref="ResampleTechniqueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResampleTechnique { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// <para>构建栅格金字塔时使用的压缩类型。</para>
		/// <para>默认—如果使用小波压缩方法对源数据进行压缩，则将使用 JPEG 压缩类型构建金字塔；否则，将使用 LZ77。这是默认压缩方法。</para>
		/// <para>LZ77—将使用 LZ77 压缩算法来构建金字塔。LZ77 可用于任意数据类型。</para>
		/// <para>Jpeg—将使用 JPEG 压缩算法构建金字塔。只有符合 JPEG 压缩规范的数据才能使用此压缩类型。如果选择 JPEG，则可以设置压缩质量。</para>
		/// <para>Jpeg 亮度和色度—将通过使用亮度 (Y) 和色度（Cb 与 Cr）颜色空间组件进行的有损压缩构建金字塔。</para>
		/// <para>无压缩—构建金字塔时不使用任何压缩方法。</para>
		/// <para><see cref="CompressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CompressionType { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Compression quality (1-100)</para>
		/// <para>使用 JPEG 压缩方法构建金字塔时使用的压缩质量。 该值必须介于 0 到 100 之间 值越接近 100，图像质量越高，但压缩比越低。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>指定是在缺少金字塔的位置构建金字塔，还是重新构建全部金字塔（即使已经存在仍重新构建）。</para>
		/// <para>未选中 - 即使金字塔已经存在仍将构建金字塔；因此，现有金字塔将被覆盖。 这是默认设置。</para>
		/// <para>选中 - 仅在不存在金字塔时才构建金字塔。</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipExisting { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildPyramids SetEnviroment(object parallelProcessingFactor = null , object pyramid = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip first level</para>
		/// </summary>
		public enum SKIPFIRSTEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_FIRST")]
			SKIP_FIRST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Pyramid resampling technique</para>
		/// </summary>
		public enum ResampleTechniqueEnum 
		{
			/// <summary>
			/// <para>最邻近—重采样时，该方法使用最邻近像元的值为输出像元分配值。 这是默认设置。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>双线性法—该方法根据四个最邻近输入像元中心的加权平均距离确定像元的新值。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性法")]
			Bilinear,

			/// <summary>
			/// <para>三次—该方法通过拟合穿过 16 个最邻近输入像元中心的平滑曲线确定像元的新值。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

		}

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// </summary>
		public enum CompressionTypeEnum 
		{
			/// <summary>
			/// <para>默认—如果使用小波压缩方法对源数据进行压缩，则将使用 JPEG 压缩类型构建金字塔；否则，将使用 LZ77。这是默认压缩方法。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("默认")]
			Default,

			/// <summary>
			/// <para>Jpeg—将使用 JPEG 压缩算法构建金字塔。只有符合 JPEG 压缩规范的数据才能使用此压缩类型。如果选择 JPEG，则可以设置压缩质量。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("Jpeg")]
			Jpeg,

			/// <summary>
			/// <para>LZ77—将使用 LZ77 压缩算法来构建金字塔。LZ77 可用于任意数据类型。</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77")]
			LZ77,

			/// <summary>
			/// <para>无压缩—构建金字塔时不使用任何压缩方法。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无压缩")]
			No_compression,

			/// <summary>
			/// <para>Jpeg 亮度和色度—将通过使用亮度 (Y) 和色度（Cb 与 Cr）颜色空间组件进行的有损压缩构建金字塔。</para>
			/// </summary>
			[GPValue("JPEG_YCbCr")]
			[Description("Jpeg 亮度和色度")]
			Jpeg_Luma_and_Chroma,

		}

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum SkipExistingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING")]
			SKIP_EXISTING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE")]
			OVERWRITE,

		}

#endregion
	}
}
