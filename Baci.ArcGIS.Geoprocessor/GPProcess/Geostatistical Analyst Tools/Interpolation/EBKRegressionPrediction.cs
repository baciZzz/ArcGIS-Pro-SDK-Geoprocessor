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
	/// <para>EBK Regression Prediction</para>
	/// <para>EBK 回归预测</para>
	/// <para>EBK 回归预测是一种地统计插值法，用到了经验贝叶斯克里金法及解释变量栅格，其中的解释变量栅格会影响正在内插的数据的值。这种方法整合了克里金法和回归分析，使得预测的结果比单独使用任何一种方法都更准确。</para>
	/// </summary>
	public class EBKRegressionPrediction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input dependent variable features</para>
		/// <para>包含要内插的字段的输入点要素。</para>
		/// </param>
		/// <param name="DependentField">
		/// <para>Dependent variable field</para>
		/// <para>包含因变量值的输入因变量要素的字段。这是将要内插的字段。</para>
		/// </param>
		/// <param name="InExplanatoryRasters">
		/// <para>Input explanatory variable rasters</para>
		/// <para>表示用于构建回归模型的解释变量的输入栅格。这些栅格将表示会影响因变量值的变量。例如，内插温度数据时应该将高程栅格用作解释变量，这是因为温度会受到高程的影响。最多可以使用 62 个解释栅格。</para>
		/// </param>
		/// <param name="OutGaLayer">
		/// <para>Output geostatistical layer</para>
		/// <para>显示插值结果的输出地统计图层。</para>
		/// </param>
		public EBKRegressionPrediction(object InFeatures, object DependentField, object InExplanatoryRasters, object OutGaLayer)
		{
			this.InFeatures = InFeatures;
			this.DependentField = DependentField;
			this.InExplanatoryRasters = InExplanatoryRasters;
			this.OutGaLayer = OutGaLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : EBK 回归预测</para>
		/// </summary>
		public override string DisplayName() => "EBK 回归预测";

		/// <summary>
		/// <para>Tool Name : EBKRegressionPrediction</para>
		/// </summary>
		public override string ToolName() => "EBKRegressionPrediction";

		/// <summary>
		/// <para>Tool Excute Name : ga.EBKRegressionPrediction</para>
		/// </summary>
		public override string ExcuteName() => "ga.EBKRegressionPrediction";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentField, InExplanatoryRasters, OutGaLayer, OutRaster, OutDiagnosticFeatureClass, MeasurementErrorField, MinCumulativeVariance, InSubsetFeatures, TransformationType, SemivariogramModelType, MaxLocalPoints, OverlapFactor, NumberSimulations, SearchNeighborhood };

		/// <summary>
		/// <para>Input dependent variable features</para>
		/// <para>包含要内插的字段的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent variable field</para>
		/// <para>包含因变量值的输入因变量要素的字段。这是将要内插的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentField { get; set; }

		/// <summary>
		/// <para>Input explanatory variable rasters</para>
		/// <para>表示用于构建回归模型的解释变量的输入栅格。这些栅格将表示会影响因变量值的变量。例如，内插温度数据时应该将高程栅格用作解释变量，这是因为温度会受到高程的影响。最多可以使用 62 个解释栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>显示插值结果的输出地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output prediction raster</para>
		/// <para>显示插值结果的输出栅格。默认像元大小为输入解释变量栅格中像元尺寸的最大值。要应用其他像元大小，可使用像元大小环境设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output diagnostic feature class</para>
		/// <para>输出可显示每个本地模型区域及包含具有本地模型诊断信息字段的面要素类 对于每一个子集，都将围绕该子集中的点创建面，这样就可以很容易地识别出每个子集中所使用的点。例如，如果有 10 个本地模型，则此输出中将有 10 个面。要素类将包含以下字段：</para>
		/// <para>主成分数目 (PrincComps) - 是指用作解释变量的主成分数目。该值将始终小于或等于解释变量栅格的数量。</para>
		/// <para>方差百分比 (PercVar) - 是指由主成分捕获的方差百分比。该值将大于或等于下面的最小累积方差百分比参数中指定的值。</para>
		/// <para>均方根误差 (RMSE) - 是指各个交叉验证误差的平方平均数的平方根。该值越小，模型的拟合状况越好。</para>
		/// <para>90% 区间 (Perc90) - 是指落入 90% 交叉验证置信区间的数据点的百分比。理想情况下，该值应接近于 90。若该值远小于 90，则说明对标准误差的估计过低。若该值远大于 90，则说明对标准误差的估计过高。</para>
		/// <para>95% 区间 (Perc95) - 是指落入 95% 交叉验证置信区间的数据点的百分比。理想情况下，该值应接近于 95。若该值远小于 95，则说明对标准误差的估计过低。若该值远大于 95，则说明对标准误差的估计过高。</para>
		/// <para>平均绝对误差 (MeanAbsErr) - 是指交叉验证误差绝对值的平均数。该值应尽可能小。这与均方根误差相似，但它受极值的影响较小。</para>
		/// <para>平均误差 (MeanError) - 交叉验证误差的平均数。该值应接近于 0。若该值显著异于零，则表示预测有偏倚。</para>
		/// <para>连续分级概率评分 (CRPS) - 这是一种诊断方法，用于测量预测的累积分布函数与每个已观测数据值之间的偏差。该值应尽可能小。该诊断方法优于交叉验证诊断方法，因为它将数据与整个分布进行比较而不是与单点预测进行比较。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutDiagnosticFeatureClass { get; set; }

		/// <summary>
		/// <para>Dependent variable measurement error field</para>
		/// <para>用于指定因变量要素中每个点的测量误差的字段。对于每个点，此字段的值都应对应于该点测量值的标准差。如果每个点的测量误差值不同，请使用此字段。</para>
		/// <para>产生不稳定测量误差的常见原因是测量数据时所用的设备不同。一个设备可能比另一个精确，即其测量误差更小。例如，一个温度计舍入到最接近的度，而另一个温度计舍到最接近的度的十分之一。通常，测量误差范围由测量设备的制造商会提供，或通过实践经验获得。</para>
		/// <para>如果没有测量误差值或测量误差值未知，请将此参数留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object MeasurementErrorField { get; set; }

		/// <summary>
		/// <para>Minimum cumulative percent of variance</para>
		/// <para>通过解释变量栅格的主成分定义方差的最小累积百分比。在构建回归模型之前，将事先计算解释变量的主成分，并会在回归中将这些主成分用作解释变量。每一个主成分将捕获解释变量方差的某一特定百分比，且此参数将控制每个本地模型主成分必须捕获的方差的最小百分比。例如，如果所提供的值为 75，那么软件将使用至少捕获 75% 的解释变量方差所必须的最小主成分数。</para>
		/// <para>各个主成分之间互不相关，因此将使用主成分解决多重共线性（相互关联的解释变量）问题。所有解释变量中包含的大部分信息通常只能在少数的几个主成分中捕获。因此，放弃最不实用的主成分，可使模型计算在不明显损失精度的情况下更稳定且更高效。</para>
		/// <para>为计算主成分，解释变量必须具有变化性，因此，如果任意输入解释变量栅格包含子集内的常量值，这些常量栅格将不会用于计算该子集的主成分。如果子集中的所有解释变量栅格均包含常量值，则输出诊断要素类将报告：使用的主成分为零，捕获的变量百分比为零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 99.989999999999995)]
		[Category("Additional Model Parameters")]
		public object MinCumulativeVariance { get; set; } = "95";

		/// <summary>
		/// <para>Subset polygon features</para>
		/// <para>用于定义计算本地模型位置的面要素。每个面内的点都将用于本地模型。此参数在因变量值需根据已知区域进行变化的情况下十分有用。例如，这些面可代表卫生政策会因区域不同而有所变化的行政卫生区。</para>
		/// <para>还可以使用生成子集面工具来创建子集面。由此工具创建的面将紧凑而不重叠。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Additional Model Parameters")]
		public object InSubsetFeatures { get; set; }

		/// <summary>
		/// <para>Dependent variable transformation type</para>
		/// <para>将应用到输入数据的变换类型。</para>
		/// <para>无—不应用任何变换。这是默认设置。</para>
		/// <para>经验法—使用“经验”基本函数进行“乘偏斜”变换。</para>
		/// <para>对数经验—使用“对数经验”基本函数进行“乘偏斜”变换。所有数据值必须为正。如果选择此选项，则所有预测均为正。</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Model Parameters")]
		public object TransformationType { get; set; } = "NONE";

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// <para>用于插值的半变异函数模型。</para>
		/// <para>指数—指数半变异函数</para>
		/// <para>块金值—块金半变异函数</para>
		/// <para>消减函数—消减半变异函数</para>
		/// <para>K-Bessel—K-Bessel 半变异函数</para>
		/// <para><see cref="SemivariogramModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Model Parameters")]
		public object SemivariogramModelType { get; set; } = "EXPONENTIAL";

		/// <summary>
		/// <para>Maximum number of points in each local model</para>
		/// <para>输入数据将自动分成子集，每个子集的点数不大于这一数目。如果提供子集面要素，将会忽略此参数的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 20, Max = 1000)]
		[Category("Additional Model Parameters")]
		public object MaxLocalPoints { get; set; } = "100";

		/// <summary>
		/// <para>Local model area overlap factor</para>
		/// <para>表示本地模型（也称子集）之间重叠程度的系数。每个输入点均可落入多个子集中，重叠系数指定了各点将落入的子集的平均数。重叠系数值越高，输出表面就越平滑，但处理时间也越长。值必须介于 1 和 5 之间。如果提供子集面要素，将会忽略此参数的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 5)]
		[Category("Additional Model Parameters")]
		public object OverlapFactor { get; set; } = "1";

		/// <summary>
		/// <para>Number of simulations</para>
		/// <para>每个本地模型模拟的半变异函数的数量。使用的模拟越多，则模型计算越稳定，但模型所用的计算时间也会越长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 10000)]
		[Category("Additional Model Parameters")]
		public object NumberSimulations { get; set; } = "100";

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>定义用于控制输出的周围点。“标准”为默认选项。</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EBKRegressionPrediction SetEnviroment(object cellSize = null , object coincidentPoints = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dependent variable transformation type</para>
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
		/// <para>Semivariogram model type</para>
		/// </summary>
		public enum SemivariogramModelTypeEnum 
		{
			/// <summary>
			/// <para>指数—指数半变异函数</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数")]
			Exponential,

			/// <summary>
			/// <para>块金值—块金半变异函数</para>
			/// </summary>
			[GPValue("NUGGET")]
			[Description("块金值")]
			Nugget,

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

#endregion
	}
}
