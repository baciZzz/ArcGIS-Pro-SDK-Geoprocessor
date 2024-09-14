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
	/// <para>Diffusion Interpolation With Barriers</para>
	/// <para>含障碍的扩散插值</para>
	/// <para>使用基于热方程的核插值表面，并且允许使用栅格和要素障碍重新定义输入点间的距离。</para>
	/// </summary>
	public class DiffusionInterpolationWithBarriers : AbstractGPProcess
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
		public DiffusionInterpolationWithBarriers(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : 含障碍的扩散插值</para>
		/// </summary>
		public override string DisplayName() => "含障碍的扩散插值";

		/// <summary>
		/// <para>Tool Name : DiffusionInterpolationWithBarriers</para>
		/// </summary>
		public override string ToolName() => "DiffusionInterpolationWithBarriers";

		/// <summary>
		/// <para>Tool Excute Name : ga.DiffusionInterpolationWithBarriers</para>
		/// </summary>
		public override string ExcuteName() => "ga.DiffusionInterpolationWithBarriers";

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
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer!, OutRaster!, CellSize!, InBarrierFeatures!, Bandwidth!, NumberIterations!, WeightField!, InAdditiveBarrierRaster!, InCumulativeBarrierRaster!, InFlowBarrierRaster! };

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
		/// <para>Bandwidth</para>
		/// <para>用于指定预测所用数据点之间的最大距离。随着带宽的增加，预测偏差将增加，而预测方差会减少。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976931348623157e+308)]
		public object? Bandwidth { get; set; }

		/// <summary>
		/// <para>Number of iterations</para>
		/// <para>由于模型在数值上求解扩散方程，迭代计数将控制数值解的精度。迭代计数越大，预测越精确，但处理时间也将越长。障碍几何越复杂且带宽越大，精确预测所需的迭代也越多。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 10, Max = 10000)]
		public object? NumberIterations { get; set; } = "100";

		/// <summary>
		/// <para>Weight field</para>
		/// <para>用于强调某个观测。权重越大，对预测的影响就越大。对于重合的观测，为最可靠的测量值分配最大权重。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Input additive barrier raster</para>
		/// <para>基于以下公式计算出的两个相邻栅格像元之间的行程距离：</para>
		/// <para>（相邻像元的平均成本值）x（像元中心间的距离）</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Additional raster barriers")]
		public object? InAdditiveBarrierRaster { get; set; }

		/// <summary>
		/// <para>Input cumulative barrier raster</para>
		/// <para>基于以下公式计算出的两个相邻栅格像元之间的行程距离：</para>
		/// <para>（相邻像元的成本值之差）+（像元中心间的距离）</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Additional raster barriers")]
		public object? InCumulativeBarrierRaster { get; set; }

		/// <summary>
		/// <para>Input flow barrier raster</para>
		/// <para>如果想在插入数据时指明数据变化的主方向，可基于以下公式使用流动障碍：</para>
		/// <para>指示符（相邻像元的成本值 &gt;相邻像元的成本值）*（相邻像元的成本值 -相邻像元的成本值）+（像元中心间的距离），&lt;italics&gt;至&lt;/italics&gt;&lt;italics&gt;自&lt;/italics&gt;&lt;italics&gt;至&lt;/italics&gt;&lt;italics&gt;自&lt;/italics&gt;</para>
		/// <para>其中，指示符（真）= 1，指示符（假）= 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Additional raster barriers")]
		public object? InFlowBarrierRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DiffusionInterpolationWithBarriers SetEnviroment(object? cellSize = null, object? coincidentPoints = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
