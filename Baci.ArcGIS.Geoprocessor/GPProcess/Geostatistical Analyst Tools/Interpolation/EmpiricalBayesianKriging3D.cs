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
	/// <para>Empirical Bayesian Kriging 3D</para>
	/// <para>3D 经验贝叶斯克里金法</para>
	/// <para>3D 经验贝叶斯克里金法是一种地统计插值方法，该方法使用经验贝叶斯克里金法来插值 3D 点数据。 所有点必须具有 x 坐标、y 坐标和 z 坐标以及要插值的测量值。 输出是一个 3D 地统计图层，该图层可将其自身计算并渲染为给定高程处的 2D 样带。 可以使用范围滑块更改图层的高程，并且图层将进行更新以显示新高程的插值预测。</para>
	/// </summary>
	public class EmpiricalBayesianKriging3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>包含要内插的字段的输入点要素。</para>
		/// </param>
		/// <param name="ElevationField">
		/// <para>Elevation field</para>
		/// <para>包含每个输入点的高程值的输入要素字段。</para>
		/// <para>如果高程值存储为 Shape.Z 中的几何属性，则建议您使用该字段。 如果高程值存储在属性字段中，则高程值必须表示距海平面的距离。 正值表示海平面以上的距离，负值表示海平面以下的距离。</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value field</para>
		/// <para>包含将进行插值的测量值的输入要素字段。</para>
		/// </param>
		/// <param name="OutGaLayer">
		/// <para>Output geostatistical layer</para>
		/// <para>将显示插值结果的输出地统计图层。</para>
		/// </param>
		public EmpiricalBayesianKriging3D(object InFeatures, object ElevationField, object ValueField, object OutGaLayer)
		{
			this.InFeatures = InFeatures;
			this.ElevationField = ElevationField;
			this.ValueField = ValueField;
			this.OutGaLayer = OutGaLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 经验贝叶斯克里金法</para>
		/// </summary>
		public override string DisplayName() => "3D 经验贝叶斯克里金法";

		/// <summary>
		/// <para>Tool Name : EmpiricalBayesianKriging3D</para>
		/// </summary>
		public override string ToolName() => "EmpiricalBayesianKriging3D";

		/// <summary>
		/// <para>Tool Excute Name : ga.EmpiricalBayesianKriging3D</para>
		/// </summary>
		public override string ExcuteName() => "ga.EmpiricalBayesianKriging3D";

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
		public override string[] ValidEnvironments() => new string[] { "coincidentPoints", "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ElevationField, ValueField, OutGaLayer, ElevationUnits!, MeasurementErrorField!, SemivariogramModelType!, TransformationType!, SubsetSize!, OverlapFactor!, NumberSimulations!, TrendRemoval!, ElevInflationFactor!, SearchNeighborhood!, OutputElevation!, OutputType!, QuantileValue!, ThresholdType!, ProbabilityThreshold! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>包含要内插的字段的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Elevation field</para>
		/// <para>包含每个输入点的高程值的输入要素字段。</para>
		/// <para>如果高程值存储为 Shape.Z 中的几何属性，则建议您使用该字段。 如果高程值存储在属性字段中，则高程值必须表示距海平面的距离。 正值表示海平面以上的距离，负值表示海平面以下的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ElevationField { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>包含将进行插值的测量值的输入要素字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>将显示插值结果的输出地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Elevation field units</para>
		/// <para>高程字段的单位。</para>
		/// <para>如果提供 Shape.Z 作为高程字段，则单位将自动匹配垂直坐标系的 z 单位。</para>
		/// <para>美国测量英寸—高程以美制英寸为单位。</para>
		/// <para>美国测量英尺—高程以美制英尺为单位。</para>
		/// <para>美国测量码—高程以美制码为单位。</para>
		/// <para>美国测量英里—高程以美制英里为单位。</para>
		/// <para>美国测量海里—高程以美制海里为单位。</para>
		/// <para>毫米—高程以毫米为单位。</para>
		/// <para>厘米—高程以厘米为单位。</para>
		/// <para>分米—高程以分米为单位。</para>
		/// <para>米—高程以米为单位。</para>
		/// <para>千米—高程以千米为单位。</para>
		/// <para>国际英寸—高程以国际英寸为单位。</para>
		/// <para>国际英尺—高程以国际英尺为单位。</para>
		/// <para>国际码—高程以国际码为单位。</para>
		/// <para>法定英里—高程以法定英里为单位。</para>
		/// <para>国际海里—高程以国际海里为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ElevationUnits { get; set; } = "METER";

		/// <summary>
		/// <para>Measurement error field</para>
		/// <para>指定输入要素中每个点的测量误差。 对于每个点，此字段的值都应对应于该点测量值的标准差。 如果每个点的测量误差值不同，请使用此字段。</para>
		/// <para>产生不稳定测量误差的常见原因是测量数据时所用的设备不同。 一个设备可能比另一个精确，即其测量误差更小。 例如，一个温度计舍入到最接近的度，而另一个温度计舍到最接近的度的十分之一。 通常，测量误差范围由测量设备的制造商会提供，或通过实践经验获得。</para>
		/// <para>如果没有测量误差值或测量误差值未知，请将此参数留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? MeasurementErrorField { get; set; }

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// <para>用于插值的半变异函数模型。</para>
		/// <para>幂—幂半变异函数</para>
		/// <para>线性—线性半变异函数</para>
		/// <para>薄板样条函数—薄板样条半变异函数</para>
		/// <para>指数—指数半变异函数</para>
		/// <para>消减函数—消减半变异函数</para>
		/// <para>K-Bessel—K-Bessel 半变异函数</para>
		/// <para><see cref="SemivariogramModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Parameters")]
		public object? SemivariogramModelType { get; set; } = "POWER";

		/// <summary>
		/// <para>Transformation type</para>
		/// <para>将应用于输入要素的变换类型。</para>
		/// <para>无—不应用任何变换。 这是默认设置。</para>
		/// <para>经验法—将应用具有“经验”基本函数的“乘偏斜”变换。</para>
		/// <para>对数经验—将应用具有“对数经验”基本函数的“乘偏斜”变换。 所有数据值必须为正。 如果选择此选项，则所有预测均为正。</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Parameters")]
		public object? TransformationType { get; set; } = "NONE";

		/// <summary>
		/// <para>Subset size</para>
		/// <para>子集的大小。 在进行处理前，输入数据将自动划分为子集。 此参数可以控制每个子集中的点数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 20, Max = 1000)]
		[Category("Advanced Model Parameters")]
		public object? SubsetSize { get; set; } = "100";

		/// <summary>
		/// <para>Local model area overlap factor</para>
		/// <para>表示本地模型（也称子集）之间重叠程度的系数。</para>
		/// <para>每个输入点均可落入多个子集中，重叠系数指定了各点将落入的子集的平均数。 重叠系数值越高，则输出表面就越平滑，但处理时间也越长。 值必须介于 1 和 5 之间。 将使用的实际重叠通常将大于此值，因此每个子集将包含相同数量的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 5)]
		[Category("Advanced Model Parameters")]
		public object? OverlapFactor { get; set; } = "1";

		/// <summary>
		/// <para>Number of simulated semivariograms</para>
		/// <para>每个本地模型模拟的半变异函数的数量。</para>
		/// <para>使用的模拟越多，则模型计算越稳定，但模型所用的计算时间也会越长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 10000)]
		[Category("Advanced Model Parameters")]
		public object? NumberSimulations { get; set; } = "100";

		/// <summary>
		/// <para>Order of trend removal</para>
		/// <para>垂直方向上趋势移除的顺序。</para>
		/// <para>对于大部分三维数据，点值的垂直变化快于其水平变化。 移除垂直方向的趋势将有助于缓解这一情况并稳定计算。</para>
		/// <para>无—请勿移除趋势。 这是默认设置。</para>
		/// <para>一阶—请移除一阶垂直趋势。</para>
		/// <para><see cref="TrendRemovalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Parameters")]
		public object? TrendRemoval { get; set; } = "NONE";

		/// <summary>
		/// <para>Elevation inflation factor</para>
		/// <para>这是一个常量值，在构造子集和模型评估之前，需要将其乘以高程字段值。 对于大部分三维数据，点值的垂直变化快于其水平变化，并且该因子将对点的位置进行拉伸，以使一个垂直距离单位在统计上等于一个水平距离单位。 返回插值结果之前，点的位置将移回其原始位置。 需要通过这种校正来准确评估半变异函数模型以及搜索邻域以使用正确的邻域。 高程膨胀因子没有单位，无论输入点的 x、y 或 z 坐标单位如何，都将提供相同的结果。</para>
		/// <para>如果没有为此参数提供值，则将使用最大似然估计在运行时计算一个值。 该值将打印为地理处理消息。 运行时计算的值将介于 1 至 1000 之间。 但是，您可以键入 0.01 至 1,000,000 之间的值。 如果计算的值等于 1 或 1000，则可以提供该范围之外的值，并根据交叉验证来选择值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 1000000)]
		[Category("Advanced Model Parameters")]
		public object? ElevInflationFactor { get; set; }

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>指定将用于预测新位置值的相邻要素的数量和方向。</para>
		/// <para>Standard3D</para>
		/// <para>最大相邻要素数 - 将用于估计未知位置值的最大相邻要素数/扇区。</para>
		/// <para>最小相邻要素数 - 将用于估计未知位置值的最小相邻要素数/扇区。</para>
		/// <para>扇区类型 - 3D 邻域的几何。 扇区可用于确保在预测位置周围的每个方向上使用相邻要素。 所有扇区类型均由正多面体形成。</para>
		/// <para>1 扇区（球体）- 将使用来自所有方向的最近相邻要素。</para>
		/// <para>4 扇区（四面体）- 将空间划分为 4 个区域，并且在每个区域中都将使用相邻要素。</para>
		/// <para>6 扇区（立方体）- 将空间划分为 6 个区域，并且在每个区域中都将使用相邻要素。</para>
		/// <para>8 扇区（八面体）- 将空间划分为 8 个区域，并且在每个区域中都将使用相邻要素。</para>
		/// <para>12 扇区（十二面体）- 将空间划分为 12 个区域，并且在每个区域中都将使用相邻要素。</para>
		/// <para>20 扇区（二十面体）- 将空间划分为 20 个区域，并且在每个区域中都将使用相邻要素。</para>
		/// <para>半径 - 搜索邻域的半径长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		[NeighbourType("NeighbourTypeStandard3D")]
		[Category("Search Neighborhood Parameters")]
		public object? SearchNeighborhood { get; set; } = "NBRTYPE=Standard3D RADIUS=nan NBR_MAX=2 NBR_MIN=1 SECTOR_TYPE=TWELVE_SECTORS";

		/// <summary>
		/// <para>Default output elevation</para>
		/// <para>输出地统计图层的默认高程。</para>
		/// <para>地统计图层将始终绘制为给定高程处的水平面，并且此参数将指定此高程。 创建后，可以使用范围滑块来更改地统计图层的高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		[Category("Output Parameters")]
		public object? OutputElevation { get; set; }

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
		public object? OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Quantile value</para>
		/// <para>用于生成输出图层的分位数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1e-10, Max = 0.99999999989999999)]
		[Category("Output Parameters")]
		public object? QuantileValue { get; set; } = "0.5";

		/// <summary>
		/// <para>Probability threshold type</para>
		/// <para>指定是否计算超过或未超过指定阈值的概率。</para>
		/// <para>超出—概率值超过了阈值。 这是默认设置。</para>
		/// <para>未超出—概率值将不会超过阈值。</para>
		/// <para><see cref="ThresholdTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object? ThresholdType { get; set; } = "EXCEED";

		/// <summary>
		/// <para>Probability threshold</para>
		/// <para>概率阈值。 如果留空，将使用输入数据的中值（第 50 个分位数）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Output Parameters")]
		public object? ProbabilityThreshold { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EmpiricalBayesianKriging3D SetEnviroment(object? coincidentPoints = null, object? extent = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(coincidentPoints: coincidentPoints, extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

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
			Thin_Plate_Spline,

			/// <summary>
			/// <para>指数—指数半变异函数</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数")]
			Exponential,

			/// <summary>
			/// <para>消减函数—消减半变异函数</para>
			/// </summary>
			[GPValue("WHITTLE")]
			[Description("消减函数")]
			Whittle,

			/// <summary>
			/// <para>K-Bessel—K-Bessel 半变异函数</para>
			/// </summary>
			[GPValue("K_BESSEL")]
			[Description("K-Bessel")]
			K_BESSEL,

		}

		/// <summary>
		/// <para>Transformation type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>无—不应用任何变换。 这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>经验法—将应用具有“经验”基本函数的“乘偏斜”变换。</para>
			/// </summary>
			[GPValue("EMPIRICAL")]
			[Description("经验法")]
			Empirical,

			/// <summary>
			/// <para>对数经验—将应用具有“对数经验”基本函数的“乘偏斜”变换。 所有数据值必须为正。 如果选择此选项，则所有预测均为正。</para>
			/// </summary>
			[GPValue("LOGEMPIRICAL")]
			[Description("对数经验")]
			Log_empirical,

		}

		/// <summary>
		/// <para>Order of trend removal</para>
		/// </summary>
		public enum TrendRemovalEnum 
		{
			/// <summary>
			/// <para>无—请勿移除趋势。 这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>一阶—请移除一阶垂直趋势。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("一阶")]
			First_order,

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
			/// <para>预测的标准误差— 标准误差表面可通过内插值的标准误差生成。</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("预测的标准误差")]
			Standard_error_of_prediction,

			/// <summary>
			/// <para>概率—值超过或未超过某一特定阈值的概率曲面。</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("概率")]
			Probability,

			/// <summary>
			/// <para>分位数—可对预测分布指定分位数进行预测的分位数表面。</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("分位数")]
			Quantile,

		}

		/// <summary>
		/// <para>Probability threshold type</para>
		/// </summary>
		public enum ThresholdTypeEnum 
		{
			/// <summary>
			/// <para>超出—概率值超过了阈值。 这是默认设置。</para>
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

#endregion
	}
}
