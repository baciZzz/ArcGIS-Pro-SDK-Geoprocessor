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
	/// <para>Batch Build Pyramids</para>
	/// <para>批量构建金字塔</para>
	/// <para>为多个栅格数据集构建金字塔。</para>
	/// </summary>
	public class BatchBuildPyramids : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasterDatasets">
		/// <para>Input Raster Datasets</para>
		/// <para>要构建栅格金字塔的栅格数据集。</para>
		/// <para>每个输入数据集的行数和列数都应超过 1024 个。</para>
		/// </param>
		public BatchBuildPyramids(object InputRasterDatasets)
		{
			this.InputRasterDatasets = InputRasterDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : 批量构建金字塔</para>
		/// </summary>
		public override string DisplayName() => "批量构建金字塔";

		/// <summary>
		/// <para>Tool Name : BatchBuildPyramids</para>
		/// </summary>
		public override string ToolName() => "BatchBuildPyramids";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchBuildPyramids</para>
		/// </summary>
		public override string ExcuteName() => "management.BatchBuildPyramids";

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
		public override string[] ValidEnvironments() => new string[] { "pyramid", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasterDatasets, PyramidLevels, SkipFirstLevel, PyramidResamplingTechnique, PyramidCompressionType, CompressionQuality, SkipExisting, BatchBuildPyramidsSucceeded };

		/// <summary>
		/// <para>Input Raster Datasets</para>
		/// <para>要构建栅格金字塔的栅格数据集。</para>
		/// <para>每个输入数据集的行数和列数都应超过 1024 个。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasterDatasets { get; set; }

		/// <summary>
		/// <para>Pyramid levels</para>
		/// <para>选择将构建的递减分辨率数据集图层的数量。 默认值为 -1，将构建完整的金字塔。 值为 0 时，将不会获得金字塔等级。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object PyramidLevels { get; set; } = "-1";

		/// <summary>
		/// <para>Skip first level</para>
		/// <para>选择是否跳过第一个金字塔等级。 跳过第一个等级将略微降低占用的磁盘空间大小，但将降低这些比例的性能。</para>
		/// <para>未选中 - 将构建第一个金字塔等级。 这是默认设置。</para>
		/// <para>选中 - 不构建第一个金字塔等级。</para>
		/// <para><see cref="SkipFirstLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipFirstLevel { get; set; } = "false";

		/// <summary>
		/// <para>Pyramid resampling technique</para>
		/// <para>用于构建金字塔的重采样技术。</para>
		/// <para>最邻近—重采样时，最邻近重采样法使用最近像元的值作为输出像元的分配值。这是默认设置。</para>
		/// <para>双线性—双线性插值重采样法基于四个最邻近的输入像元中心的加权平均距离来确定像元的新值。</para>
		/// <para>三次—三次卷积插值重采样法通过拟合穿过 16 个最邻近输入像元中心的平滑曲线来确定像元的新值。</para>
		/// <para><see cref="PyramidResamplingTechniqueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PyramidResamplingTechnique { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// <para>构建栅格金字塔时使用的压缩类型。</para>
		/// <para>默认—如果使用小波压缩方法对源数据进行压缩，则将使用 JPEG 压缩类型构建金字塔；否则，将使用 LZ77。这是默认压缩方法。</para>
		/// <para>LZ77 压缩—将使用 LZ77 压缩算法来构建金字塔。LZ77 可用于任意数据类型。</para>
		/// <para>JPEG—用于构建金字塔的 JPEG 压缩算法。只有符合 JPEG 压缩规范的数据才能使用此压缩类型。如果选择 JPEG，则可以设置压缩质量。</para>
		/// <para>无—构建金字塔时不使用任何压缩方法。</para>
		/// <para><see cref="PyramidCompressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PyramidCompressionType { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Compression quality</para>
		/// <para>使用 JPEG 压缩方法构建金字塔时使用的压缩质量。 该值必须介于 0 到 100 之间 值越接近 100，图像质量越高，但压缩比越低。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>指定是仅在缺少金字塔的地方构建金字塔，还是即使金字塔已存在仍然要重新生成金字塔。</para>
		/// <para>未选中 - 即使金字塔已存在仍构建金字塔。因此，将覆盖已有的金字塔。这是默认设置。</para>
		/// <para>选中 - 仅当金字塔不存在时才构建金字塔。</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipExisting { get; set; }

		/// <summary>
		/// <para>Batch Build Pyramids Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object BatchBuildPyramidsSucceeded { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BatchBuildPyramids SetEnviroment(object pyramid = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(pyramid: pyramid, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip first level</para>
		/// </summary>
		public enum SkipFirstLevelEnum 
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
		public enum PyramidResamplingTechniqueEnum 
		{
			/// <summary>
			/// <para>最邻近—重采样时，最邻近重采样法使用最近像元的值作为输出像元的分配值。这是默认设置。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest_neighbor,

			/// <summary>
			/// <para>双线性—双线性插值重采样法基于四个最邻近的输入像元中心的加权平均距离来确定像元的新值。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性")]
			Bilinear,

			/// <summary>
			/// <para>三次—三次卷积插值重采样法通过拟合穿过 16 个最邻近输入像元中心的平滑曲线来确定像元的新值。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

		}

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// </summary>
		public enum PyramidCompressionTypeEnum 
		{
			/// <summary>
			/// <para>默认—如果使用小波压缩方法对源数据进行压缩，则将使用 JPEG 压缩类型构建金字塔；否则，将使用 LZ77。这是默认压缩方法。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("默认")]
			Default,

			/// <summary>
			/// <para>JPEG—用于构建金字塔的 JPEG 压缩算法。只有符合 JPEG 压缩规范的数据才能使用此压缩类型。如果选择 JPEG，则可以设置压缩质量。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>LZ77 压缩—将使用 LZ77 压缩算法来构建金字塔。LZ77 可用于任意数据类型。</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77 压缩")]
			LZ77_Compression,

			/// <summary>
			/// <para>无—构建金字塔时不使用任何压缩方法。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

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
