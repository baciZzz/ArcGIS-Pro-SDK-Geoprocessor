using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Dimensional Moving Statistics</para>
	/// <para>维度移动统计数据</para>
	/// <para>在沿指定维度的多维数据的移动窗口上计算统计数据。</para>
	/// </summary>
	public class DimensionalMovingStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入栅格只能是云栅格格式（.crf 文件）的多维栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出栅格只能是云栅格格式（.crf 文件）的多维栅格。</para>
		/// </param>
		public DimensionalMovingStatistics(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 维度移动统计数据</para>
		/// </summary>
		public override string DisplayName() => "维度移动统计数据";

		/// <summary>
		/// <para>Tool Name : DimensionalMovingStatistics</para>
		/// </summary>
		public override string ToolName() => "DimensionalMovingStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.DimensionalMovingStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.DimensionalMovingStatistics";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Dimension!, BackwardWindow!, ForwardWindow!, NodataHandling!, StatisticsType!, PercentileValue!, PercentileInterpolationType!, CircularWrapValue!, RasterFunctionArgumentsJson! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入栅格只能是云栅格格式（.crf 文件）的多维栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出栅格只能是云栅格格式（.crf 文件）的多维栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>窗口将沿其移动的维度名称。</para>
		/// <para>默认值是输入多维栅格中除 x,y 之外的第一个维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Dimension { get; set; }

		/// <summary>
		/// <para>Backward Window</para>
		/// <para>定义窗口中将包含的之前或上方切片数量的值。 该值必须是 1 到 100 之间的正整数。 默认值为 1。</para>
		/// <para>参数单位为切片。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000)]
		public object? BackwardWindow { get; set; } = "1";

		/// <summary>
		/// <para>Forward Window</para>
		/// <para>定义窗口中将包含的之后或下方切片数量的值。 该值必须是 1 到 100 之间的正整数。 默认值为 1。</para>
		/// <para>参数单位为切片。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000)]
		public object? ForwardWindow { get; set; } = "1";

		/// <summary>
		/// <para>NoData Handling</para>
		/// <para>指定进行统计计算时将如何处理 NoData 值。</para>
		/// <para>数据—值输入中的 NoData 值将在其所落入定义窗口的结果中被忽略。 这是默认设置。</para>
		/// <para>NoData—如果在定义窗口的输入中找到任何 NoData 值，则输出值将为 NoData。</para>
		/// <para>填充 NoData—NoData 像元值将使用定义窗口内的值的所选统计数据替换。</para>
		/// <para><see cref="NodataHandlingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NodataHandling { get; set; } = "DATA";

		/// <summary>
		/// <para>Statistics Type</para>
		/// <para>指定要计算的统计数据类型。</para>
		/// <para>平均值—将计算定义窗口内像元的平均值。 这是默认设置。</para>
		/// <para>圆平均值—将计算角度或其他循环量（例如以度为单位的罗盘方向、日间或实数的小数部分）的平均值。 选择此统计类型后，圆换行值参数将处于可用状态。 使用此参数指定换行值。</para>
		/// <para>众数—将识别定义窗口内像元的众数（出现次数最多的值）。</para>
		/// <para>最大值—将识别定义窗口内像元的最大值。</para>
		/// <para>中值—将识别定义窗口内像元的中值。</para>
		/// <para>最小值—将识别定义窗口内像元的最小值。</para>
		/// <para>百分比数—将计算定义窗口内像元的百分比数。 默认情况下将计算 90% 百分比数。 选择此统计类型后，百分比值和百分比插值类型参数处于可用状态。 分别使用这些新参数指定要计算的百分比数和选择要使用的插值类型。</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Percentile Value</para>
		/// <para>将计算百分数值。 对于 90%，其默认值为 90。</para>
		/// <para>值范围可以介于 0 到 100 之间。 0% 基本上等同于“最小值”统计数据，而 100% 则等同于“最大值”统计数据。 值 50 所生成的结果基本等同于“中值”统计数据的结果。</para>
		/// <para>仅当统计类型参数设置为百分比数时，系统才支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// <para>指定当百分比值介于两个像元值之间时要使用的插值方法。</para>
		/// <para>仅当统计类型参数设置为中值或百分比数时，系统才支持此参数。</para>
		/// <para>自动检测—如果输入栅格的像素类型为整型，则将使用最近方法。 如果输入栅格的像素类型为浮点型，则将使用线性方法。</para>
		/// <para>最邻近—使用最接近的百分位数的可用值。 在这种情况下，输出像素类型与输入栅格的像素类型相同。</para>
		/// <para>线性—将使用接近百分位数的两个值的加权平均值。 在这种情况下，输出像素类型为浮点型。</para>
		/// <para><see cref="PercentileInterpolationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PercentileInterpolationType { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Circular Wrap Value</para>
		/// <para>将用于将线性值转换为给定圆平均值范围的值。 其值必须为正值。 默认值为 360 度。</para>
		/// <para>仅当统计类型参数设置为圆平均值时，系统才支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1e-10, Max = 10000000000)]
		public object? CircularWrapValue { get; set; } = "360";

		/// <summary>
		/// <para>Raster Function Arguments JSON</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? RasterFunctionArgumentsJson { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DimensionalMovingStatistics SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>NoData Handling</para>
		/// </summary>
		public enum NodataHandlingEnum 
		{
			/// <summary>
			/// <para>数据—值输入中的 NoData 值将在其所落入定义窗口的结果中被忽略。 这是默认设置。</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("数据")]
			Data,

			/// <summary>
			/// <para>NoData Handling</para>
			/// </summary>
			[GPValue("NODATA")]
			[Description("NoData")]
			NoData,

			/// <summary>
			/// <para>填充 NoData—NoData 像元值将使用定义窗口内的值的所选统计数据替换。</para>
			/// </summary>
			[GPValue("FILL_NODATA")]
			[Description("填充 NoData")]
			Fill_NoData,

		}

		/// <summary>
		/// <para>Statistics Type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>平均值—将计算定义窗口内像元的平均值。 这是默认设置。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>圆平均值—将计算角度或其他循环量（例如以度为单位的罗盘方向、日间或实数的小数部分）的平均值。 选择此统计类型后，圆换行值参数将处于可用状态。 使用此参数指定换行值。</para>
			/// </summary>
			[GPValue("CIRCULAR_MEAN")]
			[Description("圆平均值")]
			Circular_Mean,

			/// <summary>
			/// <para>众数—将识别定义窗口内像元的众数（出现次数最多的值）。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

			/// <summary>
			/// <para>最大值—将识别定义窗口内像元的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>中值—将识别定义窗口内像元的中值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>最小值—将识别定义窗口内像元的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>百分比数—将计算定义窗口内像元的百分比数。 默认情况下将计算 90% 百分比数。 选择此统计类型后，百分比值和百分比插值类型参数处于可用状态。 分别使用这些新参数指定要计算的百分比数和选择要使用的插值类型。</para>
			/// </summary>
			[GPValue("PERCENTILE")]
			[Description("百分比数")]
			Percentile,

		}

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// </summary>
		public enum PercentileInterpolationTypeEnum 
		{
			/// <summary>
			/// <para>自动检测—如果输入栅格的像素类型为整型，则将使用最近方法。 如果输入栅格的像素类型为浮点型，则将使用线性方法。</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("自动检测")]
			AUTO_DETECT,

			/// <summary>
			/// <para>最邻近—使用最接近的百分位数的可用值。 在这种情况下，输出像素类型与输入栅格的像素类型相同。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>线性—将使用接近百分位数的两个值的加权平均值。 在这种情况下，输出像素类型为浮点型。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

		}

#endregion
	}
}
