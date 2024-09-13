using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Empirical Bayesian Kriging</para>
	/// <para>经验贝叶斯克里金法</para>
	/// <para>经验贝叶斯克里金法是一种插值方法，可通过反复模拟，对基础半变异函数估算中的错误进行说明。</para>
	/// </summary>
	public class EmpiricalBayesianKriging : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>包含要插入的 z 值的输入点要素。</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>表示每个点的高度或量级值的字段。如果输入要素包含 z 值或 m 值，则该字段可以是数值字段或 Shape 字段。</para>
		/// </param>
		public EmpiricalBayesianKriging(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : 经验贝叶斯克里金法</para>
		/// </summary>
		public override string DisplayName() => "经验贝叶斯克里金法";

		/// <summary>
		/// <para>Tool Name : EmpiricalBayesianKriging</para>
		/// </summary>
		public override string ToolName() => "EmpiricalBayesianKriging";

		/// <summary>
		/// <para>Tool Excute Name : ga.EmpiricalBayesianKriging</para>
		/// </summary>
		public override string ExcuteName() => "ga.EmpiricalBayesianKriging";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, TransformationType, MaxLocalPoints, OverlapFactor, NumberSemivariograms, SearchNeighborhood, OutputType, QuantileValue, ThresholdType, ProbabilityThreshold, SemivariogramModelType };

		/// <summary>
		/// <para>Input features</para>
		/// <para>包含要插入的 z 值的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>表示每个点的高度或量级值的字段。如果输入要素包含 z 值或 m 值，则该字段可以是数值字段或 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>生成的地统计图层。只有未请求任何输出栅格时才需要输出该图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。只有未请求任何输出地统计图层时才需要输出该栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>要创建的输出栅格的像元大小。</para>
		/// <para>可以通过像元大小参数在环境中明确设置该值。</para>
		/// <para>如果未设置，则该值为输入空间参考中输入点要素范围的宽度与高度中的较小值除以 250。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Data transformation type</para>
		/// <para>将应用到输入数据的变换类型。</para>
		/// <para>无—不应用任何变换。这是默认设置。</para>
		/// <para>经验法—使用“经验”基本函数进行“乘偏斜”变换。</para>
		/// <para>对数经验—使用“对数经验”基本函数进行“乘偏斜”变换。所有数据值必须为正。如果选择此选项，则所有预测均为正。</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TransformationType { get; set; } = "NONE";

		/// <summary>
		/// <para>Maximum number of points in each local model</para>
		/// <para>输入数据将自动分组，每一组的点数不大于这一数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 20, Max = 1000)]
		[Category("Additional Model Parameters")]
		public object MaxLocalPoints { get; set; } = "100";

		/// <summary>
		/// <para>Local model area overlap factor</para>
		/// <para>表示本地模型（也称子集）之间重叠程度的系数。每个输入点均可落入多个子集中，重叠系数指定了各点将落入的子集的平均数。重叠系数值越高，输出表面就越平滑，但处理时间也越长。典型值在 0.01 到 5 范围内变化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 5)]
		[Category("Additional Model Parameters")]
		public object OverlapFactor { get; set; } = "1";

		/// <summary>
		/// <para>Number of simulated semivariograms</para>
		/// <para>每个本地模型模拟的半变异函数的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 10000)]
		[Category("Additional Model Parameters")]
		public object NumberSemivariograms { get; set; } = "100";

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>定义用于控制输出的周围点。“标准圆形”为默认选项。</para>
		/// <para>标准圆形</para>
		/// <para>最大邻点数 - 用于估计未知位置值的最大相邻数。</para>
		/// <para>最小邻点数 - 用于估计未知位置值的最小相邻数。</para>
		/// <para>分区类型 - 邻域的几何。</para>
		/// <para>单扇区 - 单个椭圆。</para>
		/// <para>四扇区 - 分为四个扇区的椭圆。</para>
		/// <para>偏移四扇区 - 分为四个扇区且偏移 45 度的椭圆。</para>
		/// <para>八扇区 - 分为八个扇区的椭圆。</para>
		/// <para>角度 - 移动窗口的轴（圆）或长半轴（椭圆）的旋转角度。</para>
		/// <para>半径 - 搜索圆的半径长度。</para>
		/// <para>平滑圆形</para>
		/// <para>平滑系数 -“平滑插值”选项可在“长半轴”与“平滑系数”相乘所得的距离处创建一个外椭圆和一个内椭圆。使用反曲线函数可对位于最小椭圆外、最大椭圆内的点加权，加权值介于 0 和 1 之间。</para>
		/// <para>半径 - 搜索圆的半径长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain(ChordalDistance = true)]
		[NeighbourType("StandardCircular", "SmoothCircular")]
		[Category("Search Neighborhood Parameters")]
		public object SearchNeighborhood { get; set; } = "NBRTYPE=StandardCircular RADIUS=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

		/// <summary>
		/// <para>Output surface type</para>
		/// <para>用于存储插值结果的表面类型。</para>
		/// <para>预测—可通过内插值生成的预测表面。</para>
		/// <para>预测的标准误差— 标准误差表面可通过内插值的标准误差生成。</para>
		/// <para>概率—值超过或未超过某一特定阈值的概率曲面。</para>
		/// <para>分位数—可对预测分布指定分位数进行预测的分位数表面。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Quantile value</para>
		/// <para>用于生成输出栅格的分位数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1e-10, Max = 0.99999999989999999)]
		[Category("Output Parameters")]
		public object QuantileValue { get; set; } = "0.5";

		/// <summary>
		/// <para>Probability threshold type</para>
		/// <para>指定是否计算超过或未超过指定阈值的概率。</para>
		/// <para>超出—概率值超过了阈值。这是默认设置。</para>
		/// <para>未超出—概率值将不会超过阈值。</para>
		/// <para><see cref="ThresholdTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object ThresholdType { get; set; } = "EXCEED";

		/// <summary>
		/// <para>Probability threshold</para>
		/// <para>概率阈值。如果留空，将使用输入数据的中值（第 50 个分位数）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Output Parameters")]
		public object ProbabilityThreshold { get; set; }

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// <para>用于插值的半变异函数模型。</para>
		/// <para>幂—幂半变异函数</para>
		/// <para>线性—线性半变异函数</para>
		/// <para>薄板样条函数—薄板样条半变异函数</para>
		/// <para>指数—指数半变异函数</para>
		/// <para>去除趋势的指数函数—应用一阶趋势移除的指数半变异函数</para>
		/// <para>消减函数—消减半变异函数</para>
		/// <para>去除趋势的消减函数—应用一阶趋势移除的消减半变异函数</para>
		/// <para>K-Bessel—K-Bessel 半变异函数</para>
		/// <para>去除趋势的 K-Bessel 函数—应用一阶趋势移除的 K-Bessel 半变异函数</para>
		/// <para>可用的选择取决于数据变换类型参数的值。</para>
		/// <para>如果将变换类型设置为 None，那么只有前三个半变异函数可用。如果类型是经验或对数经验，则最后六个半变异函数可用。</para>
		/// <para>关于为数据选择适当半变异函数的详细信息，请参阅什么是经验贝叶斯克里金法主题。</para>
		/// <para><see cref="SemivariogramModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SemivariogramModelType { get; set; } = "POWER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EmpiricalBayesianKriging SetEnviroment(object cellSize = null , object coincidentPoints = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Data transformation type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>无—不应用任何变换。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>经验法—使用“经验”基本函数进行“乘偏斜”变换。</para>
			/// </summary>
			[GPValue("EMPIRICAL")]
			[Description("经验法")]
			Empirical,

			/// <summary>
			/// <para>对数经验—使用“对数经验”基本函数进行“乘偏斜”变换。所有数据值必须为正。如果选择此选项，则所有预测均为正。</para>
			/// </summary>
			[GPValue("LOGEMPIRICAL")]
			[Description("对数经验")]
			Log_empirical,

		}

		/// <summary>
		/// <para>Output surface type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>预测—可通过内插值生成的预测表面。</para>
			/// </summary>
			[GPValue("PREDICTION")]
			[Description("预测")]
			Prediction,

			/// <summary>
			/// <para>分位数—可对预测分布指定分位数进行预测的分位数表面。</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("分位数")]
			Quantile,

			/// <summary>
			/// <para>概率—值超过或未超过某一特定阈值的概率曲面。</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("概率")]
			Probability,

			/// <summary>
			/// <para>预测的标准误差— 标准误差表面可通过内插值的标准误差生成。</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("预测的标准误差")]
			Standard_error_of_prediction,

		}

		/// <summary>
		/// <para>Probability threshold type</para>
		/// </summary>
		public enum ThresholdTypeEnum 
		{
			/// <summary>
			/// <para>超出—概率值超过了阈值。这是默认设置。</para>
			/// </summary>
			[GPValue("EXCEED")]
			[Description("超出")]
			Exceed,

			/// <summary>
			/// <para>未超出—概率值将不会超过阈值。</para>
			/// </summary>
			[GPValue("NOT_EXCEED")]
			[Description("未超出")]
			Not_exceed,

		}

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// </summary>
		public enum SemivariogramModelTypeEnum 
		{
			/// <summary>
			/// <para>幂—幂半变异函数</para>
			/// </summary>
			[GPValue("POWER")]
			[Description("幂")]
			Power,

			/// <summary>
			/// <para>线性—线性半变异函数</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>薄板样条函数—薄板样条半变异函数</para>
			/// </summary>
			[GPValue("THIN_PLATE_SPLINE")]
			[Description("薄板样条函数")]
			Thin_plate_spline,

			/// <summary>
			/// <para>指数—指数半变异函数</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数")]
			Exponential,

			/// <summary>
			/// <para>去除趋势的指数函数—应用一阶趋势移除的指数半变异函数</para>
			/// </summary>
			[GPValue("EXPONENTIAL_DETRENDED")]
			[Description("去除趋势的指数函数")]
			Exponential_detrended,

			/// <summary>
			/// <para>消减函数—消减半变异函数</para>
			/// </summary>
			[GPValue("WHITTLE")]
			[Description("消减函数")]
			Whittle,

			/// <summary>
			/// <para>去除趋势的消减函数—应用一阶趋势移除的消减半变异函数</para>
			/// </summary>
			[GPValue("WHITTLE_DETRENDED")]
			[Description("去除趋势的消减函数")]
			Whittle_detrended,

			/// <summary>
			/// <para>K-Bessel—K-Bessel 半变异函数</para>
			/// </summary>
			[GPValue("K_BESSEL")]
			[Description("K-Bessel")]
			K_BESSEL,

			/// <summary>
			/// <para>去除趋势的 K-Bessel 函数—应用一阶趋势移除的 K-Bessel 半变异函数</para>
			/// </summary>
			[GPValue("K_BESSEL_DETRENDED")]
			[Description("去除趋势的 K-Bessel 函数")]
			K_BESSEL_DETRENDED,

		}

#endregion
	}
}
