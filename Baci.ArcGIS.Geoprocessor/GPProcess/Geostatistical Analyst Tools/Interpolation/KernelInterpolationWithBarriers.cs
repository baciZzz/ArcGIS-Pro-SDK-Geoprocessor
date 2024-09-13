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
	/// <para>Kernel Interpolation With Barriers</para>
	/// <para>含障碍的核插值法</para>
	/// <para>一个移动窗口预测器，它使用两点之间的最短距离，这样可以将线障碍任意一侧的点都连接起来。</para>
	/// </summary>
	public class KernelInterpolationWithBarriers : AbstractGPProcess
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
		public KernelInterpolationWithBarriers(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : 含障碍的核插值法</para>
		/// </summary>
		public override string DisplayName() => "含障碍的核插值法";

		/// <summary>
		/// <para>Tool Name : KernelInterpolationWithBarriers</para>
		/// </summary>
		public override string ToolName() => "KernelInterpolationWithBarriers";

		/// <summary>
		/// <para>Tool Excute Name : ga.KernelInterpolationWithBarriers</para>
		/// </summary>
		public override string ExcuteName() => "ga.KernelInterpolationWithBarriers";

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
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer!, OutRaster!, CellSize!, InBarrierFeatures!, KernelFunction!, Bandwidth!, Power!, Ridge!, OutputType! };

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
		public object? OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。只有未请求任何输出地统计图层时才需要输出该栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

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
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Input absolute barrier features</para>
		/// <para>使用“非欧氏”距离而非“通视”距离的绝对障碍要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		public object? InBarrierFeatures { get; set; }

		/// <summary>
		/// <para>Kernel function</para>
		/// <para>模拟中所使用的核函数。</para>
		/// <para>指数函数— 函数按比例增长或衰减。</para>
		/// <para>高斯函数— 朝正/负无穷方向快速跌落的钟形函数。</para>
		/// <para>四次式— 四阶多项式函数。</para>
		/// <para>Epanechnikov— 不连续的抛物线函数。</para>
		/// <para>五阶多项式— 五阶多项式函数。</para>
		/// <para>常量—指示函数。</para>
		/// <para><see cref="KernelFunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? KernelFunction { get; set; } = "POLYNOMIAL5";

		/// <summary>
		/// <para>Bandwidth</para>
		/// <para>用于指定预测所用数据点之间的最大距离。随着带宽的增加，预测偏差将增加，而预测方差会减少。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976931348623157e+308)]
		public object? Bandwidth { get; set; }

		/// <summary>
		/// <para>Order of polynomial</para>
		/// <para>设置多项式的阶数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 1)]
		public object? Power { get; set; } = "1";

		/// <summary>
		/// <para>Ridge parameter</para>
		/// <para>用于线性方程组解的数值稳定性。对于不含障碍的规则分布数据，它不会影响预测。对于数据位于要素障碍附近或被障碍隔离的区域，预测可能不稳定，而往往需要相对较大的山脊参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 100)]
		public object? Ridge { get; set; } = "50";

		/// <summary>
		/// <para>Output surface type</para>
		/// <para>用于存储插值结果的表面类型。</para>
		/// <para>预测—可通过内插值生成的预测表面。</para>
		/// <para>预测的标准误差— 标准误差表面可通过内插值的标准误差生成。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public KernelInterpolationWithBarriers SetEnviroment(object? cellSize = null , object? coincidentPoints = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? snapRaster = null , object? workspace = null )
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
			/// <para>指数函数— 函数按比例增长或衰减。</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数函数")]
			Exponential,

			/// <summary>
			/// <para>高斯函数— 朝正/负无穷方向快速跌落的钟形函数。</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("高斯函数")]
			Gaussian,

			/// <summary>
			/// <para>四次式— 四阶多项式函数。</para>
			/// </summary>
			[GPValue("QUARTIC")]
			[Description("四次式")]
			Quartic,

			/// <summary>
			/// <para>Epanechnikov— 不连续的抛物线函数。</para>
			/// </summary>
			[GPValue("EPANECHNIKOV")]
			[Description("Epanechnikov")]
			Epanechnikov,

			/// <summary>
			/// <para>五阶多项式— 五阶多项式函数。</para>
			/// </summary>
			[GPValue("POLYNOMIAL5")]
			[Description("五阶多项式")]
			Fifth_order_polynomial,

			/// <summary>
			/// <para>常量—指示函数。</para>
			/// </summary>
			[GPValue("CONSTANT")]
			[Description("常量")]
			Constant,

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

		}

#endregion
	}
}
