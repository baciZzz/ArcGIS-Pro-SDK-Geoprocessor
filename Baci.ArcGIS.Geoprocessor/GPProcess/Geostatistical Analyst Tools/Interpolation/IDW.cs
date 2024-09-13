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
	/// <para>IDW</para>
	/// <para>反距离权重法</para>
	/// <para>使用要预测位置周围的测量值预测任意未采样位置的值，此方法基于如下假设：彼此接近的事物的相似程度高于彼此远离的事物。</para>
	/// </summary>
	public class IDW : AbstractGPProcess
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
		public IDW(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : 反距离权重法</para>
		/// </summary>
		public override string DisplayName() => "反距离权重法";

		/// <summary>
		/// <para>Tool Name : 反距离权重法</para>
		/// </summary>
		public override string ToolName() => "反距离权重法";

		/// <summary>
		/// <para>Tool Excute Name : ga.IDW</para>
		/// </summary>
		public override string ExcuteName() => "ga.IDW";

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
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, Power, SearchNeighborhood, WeightField };

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
		/// <para>Power</para>
		/// <para>控制周围点对于内插值的重要性的距离指数。幂值越高，远数据点的影响会越小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 100)]
		public object Power { get; set; } = "2";

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
		/// <para>平滑圆</para>
		/// <para>半径 - 搜索圆的半径长度。</para>
		/// <para>平滑系数 -“平滑插值”选项可在“长半轴”与“平滑系数”相乘所得的距离处创建一个外椭圆和一个内椭圆。使用反曲线函数可对位于最小椭圆外、最大椭圆内的点加权，加权值介于 0 和 1 之间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		[NeighbourType("Standard", "Smooth", "StandardCircular", "SmoothCircular")]
		public object SearchNeighborhood { get; set; } = "NBRTYPE=Standard S_MAJOR=nan S_MINOR=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IDW SetEnviroment(object cellSize = null , object coincidentPoints = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
