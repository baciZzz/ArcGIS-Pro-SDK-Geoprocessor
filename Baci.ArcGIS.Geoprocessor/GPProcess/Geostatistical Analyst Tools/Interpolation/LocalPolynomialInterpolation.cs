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
	/// <para>Local Polynomial Interpolation</para>
	/// <para>局部多项式插值法</para>
	/// <para>拟合处于指定重叠邻域内的指定阶（零阶、一阶、二阶、三阶等）多项式以生成输出表面。</para>
	/// </summary>
	public class LocalPolynomialInterpolation : AbstractGPProcess
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
		public LocalPolynomialInterpolation(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : 局部多项式插值法</para>
		/// </summary>
		public override string DisplayName() => "局部多项式插值法";

		/// <summary>
		/// <para>Tool Name : LocalPolynomialInterpolation</para>
		/// </summary>
		public override string ToolName() => "LocalPolynomialInterpolation";

		/// <summary>
		/// <para>Tool Excute Name : ga.LocalPolynomialInterpolation</para>
		/// </summary>
		public override string ExcuteName() => "ga.LocalPolynomialInterpolation";

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
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, Power, SearchNeighborhood, KernelFunction, Bandwidth, UseConditionNumber, ConditionNumber, WeightField, OutputType };

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
		/// <para>Order of polynomial</para>
		/// <para>多项式的阶。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10)]
		public object Power { get; set; } = "1";

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>定义用于控制输出的周围点。“标准”为默认选项。</para>
		/// <para>标准</para>
		/// <para>长半轴 - 搜索邻域的长半轴值。</para>
		/// <para>短半轴 - 搜索邻域的短半轴值。</para>
		/// <para>角度 - 移动窗口的轴（圆）或长半轴（椭圆）的旋转角度。</para>
		/// <para>最大邻点数 - 用于估计未知位置值的最大相邻数。</para>
		/// <para>最小邻点数 - 用于估计未知位置值的最小相邻数。</para>
		/// <para>分区类型 - 邻域的几何。</para>
		/// <para>单扇区 - 单个椭圆。</para>
		/// <para>四扇区 - 分为四个扇区的椭圆。</para>
		/// <para>偏移四扇区 - 分为四个扇区且偏移 45 度的椭圆。</para>
		/// <para>八扇区 - 分为八个扇区的椭圆。</para>
		/// <para>平滑</para>
		/// <para>长半轴 - 搜索邻域的长半轴值。</para>
		/// <para>短半轴 - 搜索邻域的短半轴值。</para>
		/// <para>角度 - 移动窗口的轴（圆）或长半轴（椭圆）的旋转角度。</para>
		/// <para>平滑系数 -“平滑插值”选项可在“长半轴”与“平滑系数”相乘所得的距离处创建一个外椭圆和一个内椭圆。使用反曲线函数可对位于最小椭圆外、最大椭圆内的点加权，加权值介于 0 和 1 之间。</para>
		/// <para>标准圆</para>
		/// <para>半径 - 搜索圆的半径长度。</para>
		/// <para>角度 - 移动窗口的轴（圆）或长半轴（椭圆）的旋转角度。</para>
		/// <para>最大邻点数 - 用于估计未知位置值的最大相邻数。</para>
		/// <para>最小邻点数 - 用于估计未知位置值的最小相邻数。</para>
		/// <para>分区类型 - 邻域的几何。</para>
		/// <para>单扇区 - 单个椭圆。</para>
		/// <para>四扇区 - 分为四个扇区的椭圆。</para>
		/// <para>偏移四扇区 - 分为四个扇区且偏移 45 度的椭圆。</para>
		/// <para>八扇区 - 分为八个扇区的椭圆。</para>
		/// <para>平滑圆形</para>
		/// <para>半径 - 搜索圆的半径长度。</para>
		/// <para>平滑系数 -“平滑插值”选项可在“长半轴”与“平滑系数”相乘所得的距离处创建一个外椭圆和一个内椭圆。使用反曲线函数可对位于最小椭圆外、最大椭圆内的点加权，加权值介于 0 和 1 之间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		[NeighbourType("Standard", "Smooth", "StandardCircular", "SmoothCircular")]
		public object SearchNeighborhood { get; set; } = "NBRTYPE=Standard S_MAJOR=nan S_MINOR=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

		/// <summary>
		/// <para>Kernel function</para>
		/// <para>模拟中所使用的核函数。</para>
		/// <para>指数函数—函数按比例增长或衰减。</para>
		/// <para>高斯函数—朝正或负无穷方向快速跌落的钟形函数。</para>
		/// <para>四次式—四阶多项式函数。</para>
		/// <para>Epanechnikov—不连续的抛物线函数。</para>
		/// <para>五阶多项式—五阶多项式函数。</para>
		/// <para>常量—指示函数。</para>
		/// <para><see cref="KernelFunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelFunction { get; set; } = "EXPONENTIAL";

		/// <summary>
		/// <para>Bandwidth</para>
		/// <para>用于指定预测所用数据点之间的最大距离。随着带宽的增加，预测偏差将增加，而预测方差会减少。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976931348623157e+308)]
		public object Bandwidth { get; set; }

		/// <summary>
		/// <para>Use spatial condition number threshold</para>
		/// <para>对预测不稳定位置的预测和预测标准误差的创建进行控制的选项。此选项只可用于 1 阶、2 阶和 3 阶多项式。</para>
		/// <para>未选中 - 预测值将在各处创建，包括预测值不稳定的位置。这是默认设置。</para>
		/// <para>选中 - 不会在预测不稳定位置创建预测和预测标准误差。</para>
		/// <para><see cref="UseConditionNumberEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseConditionNumber { get; set; } = "false";

		/// <summary>
		/// <para>Spatial condition number threshold</para>
		/// <para>每个可逆方阵都具有一个条件数，用来表示矩阵系数发生微小变化时（可能是由非精确数据导致），线性方程组解的错误程度。如果条件数较大，则很小的矩阵系数变化便会导致解向量的较大变化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.01, Max = 10000)]
		public object ConditionNumber { get; set; }

		/// <summary>
		/// <para>Weight field</para>
		/// <para>用于强调某个观测。权重越大，对预测的影响就越大。对于重合的观测，为最可靠的测量值分配最大权重。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Output surface type</para>
		/// <para>用于存储插值结果的表面类型。</para>
		/// <para>预测—可通过内插值生成的预测表面。</para>
		/// <para>预测的标准误差— 标准误差表面可通过内插值的标准误差生成。</para>
		/// <para>条件数—空间条件数表面表示在特定位置计算的稳定性。条件数越大，预测越不稳定，所以条件数较大的位置更容易出现伪影和不稳定的预测值。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocalPolynomialInterpolation SetEnviroment(object cellSize = null , object coincidentPoints = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Kernel function</para>
		/// </summary>
		public enum KernelFunctionEnum 
		{
			/// <summary>
			/// <para>指数函数—函数按比例增长或衰减。</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数函数")]
			Exponential,

			/// <summary>
			/// <para>高斯函数—朝正或负无穷方向快速跌落的钟形函数。</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("高斯函数")]
			Gaussian,

			/// <summary>
			/// <para>四次式—四阶多项式函数。</para>
			/// </summary>
			[GPValue("QUARTIC")]
			[Description("四次式")]
			Quartic,

			/// <summary>
			/// <para>Epanechnikov—不连续的抛物线函数。</para>
			/// </summary>
			[GPValue("EPANECHNIKOV")]
			[Description("Epanechnikov")]
			Epanechnikov,

			/// <summary>
			/// <para>五阶多项式—五阶多项式函数。</para>
			/// </summary>
			[GPValue("POLYNOMIAL5")]
			[Description("五阶多项式")]
			POLYNOMIAL5,

			/// <summary>
			/// <para>常量—指示函数。</para>
			/// </summary>
			[GPValue("CONSTANT")]
			[Description("常量")]
			Constant,

		}

		/// <summary>
		/// <para>Use spatial condition number threshold</para>
		/// </summary>
		public enum UseConditionNumberEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CONDITION_NUMBER")]
			USE_CONDITION_NUMBER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_USE_CONDITION_NUMBER")]
			NO_USE_CONDITION_NUMBER,

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
			/// <para>条件数—空间条件数表面表示在特定位置计算的稳定性。条件数越大，预测越不稳定，所以条件数较大的位置更容易出现伪影和不稳定的预测值。</para>
			/// </summary>
			[GPValue("CONDITION_NUMBER")]
			[Description("条件数")]
			Condition_number,

		}

#endregion
	}
}
