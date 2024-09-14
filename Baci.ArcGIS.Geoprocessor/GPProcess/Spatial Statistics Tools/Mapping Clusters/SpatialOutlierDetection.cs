using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Spatial Outlier Detection</para>
	/// <para>空间异常值检测</para>
	/// <para>识别点要素中的全局或局部空间异常值。</para>
	/// </summary>
	public class SpatialOutlierDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将用于构建空间异常值检测模型的点要素。 将根据每个点的局部异常值因子将其分类为异常值或正常值。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类，其中包含每个输入要素的局部异常值因子以及该点是否为空间异常值的指示符。</para>
		/// </param>
		public SpatialOutlierDetection(object InFeatures, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 空间异常值检测</para>
		/// </summary>
		public override string DisplayName() => "空间异常值检测";

		/// <summary>
		/// <para>Tool Name : SpatialOutlierDetection</para>
		/// </summary>
		public override string ToolName() => "SpatialOutlierDetection";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatialOutlierDetection</para>
		/// </summary>
		public override string ExcuteName() => "stats.SpatialOutlierDetection";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, NNeighbors!, PercentOutlier!, OutputRaster!, OutlierType!, Sensitivity!, KeepType! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将用于构建空间异常值检测模型的点要素。 将根据每个点的局部异常值因子将其分类为异常值或正常值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类，其中包含每个输入要素的局部异常值因子以及该点是否为空间异常值的指示符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>将用于检测每个输入点的空间异常值的相邻要素数。</para>
		/// <para>对于局部异常值检测，该值必须至少为 2，并且邻域内的所有要素都将用作相邻要素。 如果未指定任何值，则将在运行时估计一个值，并将其显示为地理处理消息。</para>
		/// <para>对于全局异常值检测，将仅使用邻域中最远的相邻要素，默认为 1（最近的相邻要素）。 例如，值为 3 表示使用到每个点的第三个最近相邻要素的距离来检测全局异常值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NNeighbors { get; set; } = "1";

		/// <summary>
		/// <para>Percent of Locations Considered Outliers</para>
		/// <para>通过定义局部异常值因子的阈值，将标识为空间异常值的位置的百分比。 如果未指定任何值，则将在运行时估计一个值，并将其显示为地理处理消息。 最多 50% 的要素可以被识别为空间异常值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-05, Max = 50)]
		public object? PercentOutlier { get; set; }

		/// <summary>
		/// <para>Output Prediction Raster</para>
		/// <para>输出栅格，其中包含每个像元处的局部异常值因子，将基于输入要素的空间分布进行计算。</para>
		/// <para>仅当具有 Desktop Advanced 许可时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutputRaster { get; set; }

		/// <summary>
		/// <para>Outlier Type</para>
		/// <para>为检测到的异常值指定类型。 全局异常值是指远离要素类中所有其他点的点。 局部异常值是指该点距离其相邻点的距离，比周围区域中预期的点密度的距离大。</para>
		/// <para>全球—将检测输入点的全局异常值。 这是默认设置。</para>
		/// <para>局部分析—将检测输入点的局部异常值。</para>
		/// <para><see cref="OutlierTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutlierType { get; set; } = "GLOBAL";

		/// <summary>
		/// <para>Detection Sensitivity</para>
		/// <para>指定用于检测全局异常值的灵敏度。 灵敏度越高，将被检测为异常值的点就越多。</para>
		/// <para>灵敏度值将决定阈值，任何相邻距离大于该阈值的点都将被识别为全局异常值。 阈值使用箱形图规则确定的，其中高灵敏度的阈值为第三个四分位数以上的 1 个四分位距。 对于中灵敏度，阈值为第三个四分位数以上的 1.5 个四分位距。 对于低灵敏度，阈值为第三个四分位数以上的 2 个四分位距。</para>
		/// <para>低—将使用低灵敏度检测异常值。 此选项将检测最少的异常值。</para>
		/// <para>中—将使用中灵敏度检测异常值。 这是默认设置。</para>
		/// <para>高—将使用高低灵敏度检测异常值。 此选项将检测最多的异常值。</para>
		/// <para><see cref="SensitivityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Sensitivity { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Keep Only Spatial Outliers</para>
		/// <para>指定输出要素是否包含所有输入要素还是仅包含标识为空间异常值的要素。</para>
		/// <para>选中 - 输出要素仅包含标识为空间异常值的要素。</para>
		/// <para>取消选中 - 输出要素将包含所有输入要素。 这是默认设置。</para>
		/// <para><see cref="KeepTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepType { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialOutlierDetection SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Outlier Type</para>
		/// </summary>
		public enum OutlierTypeEnum 
		{
			/// <summary>
			/// <para>全球—将检测输入点的全局异常值。 这是默认设置。</para>
			/// </summary>
			[GPValue("GLOBAL")]
			[Description("全球")]
			Global,

			/// <summary>
			/// <para>局部分析—将检测输入点的局部异常值。</para>
			/// </summary>
			[GPValue("LOCAL")]
			[Description("局部分析")]
			Local,

		}

		/// <summary>
		/// <para>Detection Sensitivity</para>
		/// </summary>
		public enum SensitivityEnum 
		{
			/// <summary>
			/// <para>低—将使用低灵敏度检测异常值。 此选项将检测最少的异常值。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低")]
			Low,

			/// <summary>
			/// <para>中—将使用中灵敏度检测异常值。 这是默认设置。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中")]
			Medium,

			/// <summary>
			/// <para>高—将使用高低灵敏度检测异常值。 此选项将检测最多的异常值。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高")]
			High,

		}

		/// <summary>
		/// <para>Keep Only Spatial Outliers</para>
		/// </summary>
		public enum KeepTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_OUTLIER")]
			KEEP_OUTLIER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

		}

#endregion
	}
}
