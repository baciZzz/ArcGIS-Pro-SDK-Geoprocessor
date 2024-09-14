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
	/// <para>Build Pyramids And Statistics</para>
	/// <para>构建金字塔和统计数据</para>
	/// <para>遍历文件夹结构，从而为其所包含的所有栅格数据集构建金字塔并计算统计数据。还可以为镶嵌数据集中的所有项构建金字塔并计算统计数据。</para>
	/// </summary>
	public class BuildPyramidsandStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Data or Workspace</para>
		/// <para>包含要处理的所有栅格数据集或镶嵌数据集的工作空间。</para>
		/// <para>如果工作空间包含镶嵌数据集，则将仅包含与镶嵌数据集相关联的统计数据。不包含与镶嵌数据集中的各项相关联的统计数据。</para>
		/// </param>
		public BuildPyramidsandStatistics(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建金字塔和统计数据</para>
		/// </summary>
		public override string DisplayName() => "构建金字塔和统计数据";

		/// <summary>
		/// <para>Tool Name : BuildPyramidsandStatistics</para>
		/// </summary>
		public override string ToolName() => "BuildPyramidsandStatistics";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildPyramidsandStatistics</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildPyramidsandStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "pyramid", "rasterStatistics" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, IncludeSubdirectories, BuildPyramids, CalculateStatistics, BUILDONSOURCE, BlockField, EstimateStatistics, XSkipFactor, YSkipFactor, IgnoreValues, PyramidLevel, SKIPFIRST, ResampleTechnique, CompressionType, CompressionQuality, SkipExisting, OutWorkspace, WhereClause, SipsMode };

		/// <summary>
		/// <para>Input Data or Workspace</para>
		/// <para>包含要处理的所有栅格数据集或镶嵌数据集的工作空间。</para>
		/// <para>如果工作空间包含镶嵌数据集，则将仅包含与镶嵌数据集相关联的统计数据。不包含与镶嵌数据集中的各项相关联的统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Include Sub-directories</para>
		/// <para>指定是否包含子目录。</para>
		/// <para>未选中 - 不包括子目录。</para>
		/// <para>选中 - 加载时包括子目录中的所有栅格数据集。这是默认设置。</para>
		/// <para>如果希望包含镶嵌数据集中的各项，则必须将镶嵌数据集指定为输入工作空间。否则，将仅使用与镶嵌数据集相关联的统计数据。</para>
		/// <para><see cref="IncludeSubdirectoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSubdirectories { get; set; } = "true";

		/// <summary>
		/// <para>Build Pyramids</para>
		/// <para>指定是否构建金字塔。</para>
		/// <para>未选中 - 不构建金字塔。</para>
		/// <para>选中 - 构建金字塔。这是默认设置。</para>
		/// <para><see cref="BuildPyramidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildPyramids { get; set; } = "true";

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// <para>指定是否计算统计数据。</para>
		/// <para>未选中 - 不计算统计数据。</para>
		/// <para>选中 - 计算统计数据。这是默认设置。</para>
		/// <para><see cref="CalculateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CalculateStatistics { get; set; } = "true";

		/// <summary>
		/// <para>Include Source Datasets</para>
		/// <para>指定是为源栅格数据集构建金字塔并计算统计数据还是为镶嵌数据集中的栅格条目构建金字塔并计算统计数据。此选项仅适用于镶嵌数据集。</para>
		/// <para>未选中 - 为镶嵌数据集中的每个栅格条目（对应于属性表中的每一行）计算统计数据。在生成统计数据前，将应用为栅格条目添加的所有函数。这是默认设置。</para>
		/// <para>选中 - 为镶嵌数据集的源数据构建金字塔并计算统计数据。</para>
		/// <para><see cref="BUILDONSOURCEEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Statistics Options")]
		public object BUILDONSOURCE { get; set; } = "false";

		/// <summary>
		/// <para>Block Field</para>
		/// <para>镶嵌数据集属性表中的字段名称，用于标识在执行某些计算和操作时应被视为单一项目的多个项目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Statistics Options")]
		public object BlockField { get; set; }

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// <para>指定是否计算镶嵌数据集（不是其中的栅格）的统计数据。这些统计数据派生自为镶嵌数据集中的每个栅格计算出的现有统计数据。</para>
		/// <para>未选中 - 不计算镶嵌数据集的统计数据。这是默认设置。</para>
		/// <para>选中 - 计算镶嵌数据集的统计数据。</para>
		/// <para><see cref="EstimateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Statistics Options")]
		public object EstimateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>X Skip Factor</para>
		/// <para>样本之间水平像素的数量。</para>
		/// <para>在计算统计值时使用的那部分栅格由跳跃因子控制。特定输入值可指示水平或垂直跳跃因子，值为 1 时使用每个像素，值为 2 时则每隔一个像素使用一个。此跳跃因子的取值范围只能从 1 至栅格中列/行的数量。</para>
		/// <para>在计算统计值时使用的那部分栅格由跳跃因子控制。特定输入值可指示水平或垂直跳跃因子，值为 1 时使用每个像素，值为 2 时则每隔一个像素使用一个。此跳跃因子的取值范围只能从 1 至栅格中列/行的数量。</para>
		/// <para>此值必须大于零并小于等于栅格中的列数。默认值为 1 或者为上次使用的跳跃因子。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Statistics Options")]
		public object XSkipFactor { get; set; }

		/// <summary>
		/// <para>Y Skip Factor</para>
		/// <para>样本之间垂直像素的数量。</para>
		/// <para>在计算统计值时使用的那部分栅格由跳跃因子控制。特定输入值可指示水平或垂直跳跃因子，值为 1 时使用每个像素，值为 2 时则每隔一个像素使用一个。此跳跃因子的取值范围只能从 1 至栅格中列/行的数量。</para>
		/// <para>在计算统计值时使用的那部分栅格由跳跃因子控制。特定输入值可指示水平或垂直跳跃因子，值为 1 时使用每个像素，值为 2 时则每隔一个像素使用一个。此跳跃因子的取值范围只能从 1 至栅格中列/行的数量。</para>
		/// <para>此值必须大于零并小于等于栅格中的行数。默认值为 1 或者为上次使用的 y 跳跃因子。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Statistics Options")]
		public object YSkipFactor { get; set; }

		/// <summary>
		/// <para>Ignore Values</para>
		/// <para>排除在统计值计算之外的像素值。</para>
		/// <para>默认情况下没有值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Statistics Options")]
		public object IgnoreValues { get; set; }

		/// <summary>
		/// <para>Pyramid levels</para>
		/// <para>选择将构建的递减分辨率数据集图层的数量。 默认值为 -1，将构建完整的金字塔。 值为 0 时，将不会获得金字塔等级。</para>
		/// <para>可以指定的最大金字塔等级数为 29。任何等于或大于 30 的值都将创建一组完整的金字塔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pyramids Options")]
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
		[Category("Pyramids Options")]
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
		[Category("Pyramids Options")]
		public object ResampleTechnique { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// <para>构建栅格金字塔时使用的压缩类型。</para>
		/// <para>默认—如果使用小波压缩方法对源数据进行压缩，则将使用 JPEG 压缩类型构建金字塔；否则，将使用 LZ77。 此方法为默认压缩方法。</para>
		/// <para>LZ77 压缩—将使用 LZ77 压缩算法来构建金字塔。 LZ77 可用于任意数据类型。</para>
		/// <para>JPEG 压缩—用于构建金字塔的 JPEG 压缩算法。 只有符合 JPEG 压缩规范的数据才能使用此压缩类型。 如果选择 JPEG，则可以设置压缩质量。</para>
		/// <para>JPEG 亮度和色度—有损压缩使用亮度 (Y) 和色度（Cb 和 Cr）颜色空间组件。</para>
		/// <para>无压缩—构建金字塔时不使用任何压缩方法。</para>
		/// <para><see cref="CompressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pyramids Options")]
		public object CompressionType { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Compression quality (1-100)</para>
		/// <para>使用 JPEG 压缩方法构建金字塔时使用的压缩质量。 该值必须介于 0 到 100 之间 值越接近 100，图像质量越高，但压缩比越低。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pyramids Options")]
		public object CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>指定在缺少统计数据的位置进行计算，还是重新计算全部统计数据（即使已经存在仍重新计算）。</para>
		/// <para>选中 - 只有当统计数据不存在时才会计算统计数据。这是默认设置。</para>
		/// <para>取消选中 - 即使统计数据已经存在仍要重新计算；现有统计数据将被覆盖。</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipExisting { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于选择要处理的栅格数据集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>SIPS Mode</para>
		/// <para>指定是否使用软拷贝图像处理标准 (SIPS) NGA.STND.0014 中定义的关键流程和算法来启用金字塔文件的构建。</para>
		/// <para>未选中 - 将使用标准的子采样方法来构建金字塔。这是默认设置。</para>
		/// <para>选中 - 将使用 SIPS 处理来构建金字塔。</para>
		/// <para><see cref="SipsModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Pyramids Options")]
		public object SipsMode { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildPyramidsandStatistics SetEnviroment(object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Sub-directories</para>
		/// </summary>
		public enum IncludeSubdirectoriesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SUBDIRECTORIES")]
			INCLUDE_SUBDIRECTORIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Build Pyramids</para>
		/// </summary>
		public enum BuildPyramidsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_PYRAMIDS")]
			BUILD_PYRAMIDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// </summary>
		public enum CalculateStatisticsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CALCULATE_STATISTICS")]
			CALCULATE_STATISTICS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Include Source Datasets</para>
		/// </summary>
		public enum BUILDONSOURCEEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_ON_SOURCE")]
			BUILD_ON_SOURCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// </summary>
		public enum EstimateStatisticsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE_STATISTICS")]
			ESTIMATE_STATISTICS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

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
			Nearest_neighbor,

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
			/// <para>默认—如果使用小波压缩方法对源数据进行压缩，则将使用 JPEG 压缩类型构建金字塔；否则，将使用 LZ77。 此方法为默认压缩方法。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("默认")]
			Default,

			/// <summary>
			/// <para>JPEG 压缩—用于构建金字塔的 JPEG 压缩算法。 只有符合 JPEG 压缩规范的数据才能使用此压缩类型。 如果选择 JPEG，则可以设置压缩质量。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG 压缩")]
			JPEG_Compression,

			/// <summary>
			/// <para>LZ77 压缩—将使用 LZ77 压缩算法来构建金字塔。 LZ77 可用于任意数据类型。</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77 压缩")]
			LZ77_Compression,

			/// <summary>
			/// <para>无压缩—构建金字塔时不使用任何压缩方法。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无压缩")]
			No_compression,

			/// <summary>
			/// <para>JPEG 亮度和色度—有损压缩使用亮度 (Y) 和色度（Cb 和 Cr）颜色空间组件。</para>
			/// </summary>
			[GPValue("JPEG_YCBCR")]
			[Description("JPEG 亮度和色度")]
			JPEG_Luma_and_Chroma,

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

		/// <summary>
		/// <para>SIPS Mode</para>
		/// </summary>
		public enum SipsModeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SIPS_MODE")]
			SIPS_MODE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
