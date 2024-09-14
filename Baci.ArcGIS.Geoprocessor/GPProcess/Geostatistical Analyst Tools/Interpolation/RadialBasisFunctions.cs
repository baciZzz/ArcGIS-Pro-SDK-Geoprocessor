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
	/// <para>Radial Basis Functions</para>
	/// <para>径向基函数(RBF)插值法</para>
	/// <para>使用五种基函数之一对准确经过各输入点的表面进行插值。</para>
	/// </summary>
	public class RadialBasisFunctions : AbstractGPProcess
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
		public RadialBasisFunctions(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : 径向基函数(RBF)插值法</para>
		/// </summary>
		public override string DisplayName() => "径向基函数(RBF)插值法";

		/// <summary>
		/// <para>Tool Name : RadialBasisFunctions</para>
		/// </summary>
		public override string ToolName() => "RadialBasisFunctions";

		/// <summary>
		/// <para>Tool Excute Name : ga.RadialBasisFunctions</para>
		/// </summary>
		public override string ExcuteName() => "ga.RadialBasisFunctions";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, SearchNeighborhood, Radial_Basis_Functions, SmallScaleParameter };

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
		/// <para>Search neighborhood</para>
		/// <para>定义用于控制输出的周围点。“标准”为默认选项。</para>
		/// <para>标准版</para>
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
		/// <para>标准圆形</para>
		/// <para>半径 - 搜索圆的半径长度。</para>
		/// <para>角度 - 移动窗口的轴（圆）或长半轴（椭圆）的旋转角度。</para>
		/// <para>最大邻点数 - 用于估计未知位置值的最大相邻数。</para>
		/// <para>最小邻点数 - 用于估计未知位置值的最小相邻数。</para>
		/// <para>分区类型 - 邻域的几何。</para>
		/// <para>单扇区 - 单个椭圆。</para>
		/// <para>四扇区 - 分为四个扇区的椭圆。</para>
		/// <para>偏移四扇区 - 分为四个扇区且偏移 45 度的椭圆。</para>
		/// <para>八扇区 - 分为八个扇区的椭圆。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		[NeighbourType("Standard", "Smooth", "StandardCircular", "SmoothCircular")]
		public object SearchNeighborhood { get; set; } = "NBRTYPE=Standard S_MAJOR=nan S_MINOR=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

		/// <summary>
		/// <para>Radial basis function</para>
		/// <para>有以下五种可用的径向基函数：</para>
		/// <para>薄板样条函数—薄板样条函数</para>
		/// <para>张力样条函数— 张力样条函数</para>
		/// <para>规则样条函数— 完全规则样条函数</para>
		/// <para>高次曲面函数— 高次曲面样条函数</para>
		/// <para>反高次曲面样条函数—反高次曲面样条函数</para>
		/// <para><see cref="Radial_Basis_FunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Radial_Basis_Functions { get; set; } = "COMPLETELY_REGULARIZED_SPLINE";

		/// <summary>
		/// <para>Small scale parameter</para>
		/// <para>用于计算分配给移动窗口内的点的权重。每个径向基函数都有一个控制表面小规模变化程度的参数。可通过寻找使均方根预测误差 (RMSPE) 最小的值来确定（最佳）参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 1.7976931348623157e+308)]
		public object SmallScaleParameter { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RadialBasisFunctions SetEnviroment(object cellSize = null, object coincidentPoints = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Radial basis function</para>
		/// </summary>
		public enum Radial_Basis_FunctionsEnum 
		{
			/// <summary>
			/// <para>规则样条函数— 完全规则样条函数</para>
			/// </summary>
			[GPValue("COMPLETELY_REGULARIZED_SPLINE")]
			[Description("规则样条函数")]
			Completely_regularized_spline,

			/// <summary>
			/// <para>张力样条函数— 张力样条函数</para>
			/// </summary>
			[GPValue("SPLINE_WITH_TENSION")]
			[Description("张力样条函数")]
			Spline_with_tension,

			/// <summary>
			/// <para>高次曲面函数— 高次曲面样条函数</para>
			/// </summary>
			[GPValue("MULTIQUADRIC_FUNCTION")]
			[Description("高次曲面函数")]
			Multiquadric,

			/// <summary>
			/// <para>反高次曲面样条函数—反高次曲面样条函数</para>
			/// </summary>
			[GPValue("INVERSE_MULTIQUADRIC_FUNCTION")]
			[Description("反高次曲面样条函数")]
			Inverse_multiquadric,

			/// <summary>
			/// <para>薄板样条函数—薄板样条函数</para>
			/// </summary>
			[GPValue("THIN_PLATE_SPLINE")]
			[Description("薄板样条函数")]
			Thin_plate_spline,

		}

#endregion
	}
}
