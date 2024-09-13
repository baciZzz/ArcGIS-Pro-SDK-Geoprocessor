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
	/// <para>Calculate Kernel Density Ratio</para>
	/// <para>计算核密度比</para>
	/// <para>使用两个输入要素数据集计算空间相对风险表面。 该比率中的分子代表案例，例如犯罪数量或患者人数，而分母代表对照，例如总人口。</para>
	/// </summary>
	public class CalculateKernelDensityRatio : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeaturesNumerator">
		/// <para>Input point or polyline features as numerator</para>
		/// <para>将为其计算密度的示例中的输入要素（点或线）。</para>
		/// </param>
		/// <param name="InFeaturesDenominator">
		/// <para>Input point or polyline features as denominator</para>
		/// <para>将为其计算密度的控件中的输入要素（点或线）。</para>
		/// </param>
		/// <param name="PopulationFieldNumerator">
		/// <para>Population field of numerator</para>
		/// <para>表示各要素的 population 值的字段。 总体字段表示遍布于用来创建连续表面的景观内的计数或数量。</para>
		/// <para>如果不使用任何项目或特殊值，则选择 OID 或 FID，这样每一要素就只计数一次。</para>
		/// <para>population 字段的值可以是整型或浮点型。</para>
		/// <para>如果输入要素包含 Z 值，则可以使用 Shape 字段。</para>
		/// </param>
		/// <param name="PopulationFieldDenominator">
		/// <para>Population field of denominator</para>
		/// <para>表示各要素的 population 值的字段。 总体字段表示遍布于用来创建连续表面的景观内的计数或数量。</para>
		/// <para>如果不使用任何项目或特殊值，则选择 OID 或 FID，这样每一要素就只计数一次。</para>
		/// <para>population 字段的值可以是整型或浮点型。</para>
		/// <para>如果输入要素包含 Z 值，则可以使用 Shape 字段。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出核密度栅格。</para>
		/// <para>总为浮点栅格。</para>
		/// </param>
		public CalculateKernelDensityRatio(object InFeaturesNumerator, object InFeaturesDenominator, object PopulationFieldNumerator, object PopulationFieldDenominator, object OutRaster)
		{
			this.InFeaturesNumerator = InFeaturesNumerator;
			this.InFeaturesDenominator = InFeaturesDenominator;
			this.PopulationFieldNumerator = PopulationFieldNumerator;
			this.PopulationFieldDenominator = PopulationFieldDenominator;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算核密度比</para>
		/// </summary>
		public override string DisplayName() => "计算核密度比";

		/// <summary>
		/// <para>Tool Name : CalculateKernelDensityRatio</para>
		/// </summary>
		public override string ToolName() => "CalculateKernelDensityRatio";

		/// <summary>
		/// <para>Tool Excute Name : sa.CalculateKernelDensityRatio</para>
		/// </summary>
		public override string ExcuteName() => "sa.CalculateKernelDensityRatio";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeaturesNumerator, InFeaturesDenominator, PopulationFieldNumerator, PopulationFieldDenominator, OutRaster, CellSize!, SearchRadiusNumerator!, SearchRadiusDenominator!, OutCellValues!, Method!, InBarriersNumerator!, InBarriersDenominator! };

		/// <summary>
		/// <para>Input point or polyline features as numerator</para>
		/// <para>将为其计算密度的示例中的输入要素（点或线）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object InFeaturesNumerator { get; set; }

		/// <summary>
		/// <para>Input point or polyline features as denominator</para>
		/// <para>将为其计算密度的控件中的输入要素（点或线）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object InFeaturesDenominator { get; set; }

		/// <summary>
		/// <para>Population field of numerator</para>
		/// <para>表示各要素的 population 值的字段。 总体字段表示遍布于用来创建连续表面的景观内的计数或数量。</para>
		/// <para>如果不使用任何项目或特殊值，则选择 OID 或 FID，这样每一要素就只计数一次。</para>
		/// <para>population 字段的值可以是整型或浮点型。</para>
		/// <para>如果输入要素包含 Z 值，则可以使用 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object PopulationFieldNumerator { get; set; }

		/// <summary>
		/// <para>Population field of denominator</para>
		/// <para>表示各要素的 population 值的字段。 总体字段表示遍布于用来创建连续表面的景观内的计数或数量。</para>
		/// <para>如果不使用任何项目或特殊值，则选择 OID 或 FID，这样每一要素就只计数一次。</para>
		/// <para>population 字段的值可以是整型或浮点型。</para>
		/// <para>如果输入要素包含 Z 值，则可以使用 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object PopulationFieldDenominator { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出核密度栅格。</para>
		/// <para>总为浮点栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。 如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。 有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Search radius of numerator</para>
		/// <para>在其范围内计算密度的搜索半径。 单位基于输出空间参考投影的线性单位。</para>
		/// <para>例如，如果单位为米，若要包含一英里邻域内的所有要素，可将搜索半径设置为 1609.344（1 英里 = 1609.344 米）。</para>
		/// <para>使用“Silverman 经验规则”（Silverman，1986 年版）的空间变量专为输入数据集计算默认搜索半径，该变量足够强大，可避免空间异常值（距离其余点太远的点）。 有关该算法的描述，请参阅使用提示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchRadiusNumerator { get; set; }

		/// <summary>
		/// <para>Search radius of denominator</para>
		/// <para>在其范围内计算密度的搜索半径。 单位基于输出空间参考投影的线性单位。</para>
		/// <para>例如，如果单位为米，若要包含一英里邻域内的所有要素，可将搜索半径设置为 1609.344（1 英里 = 1609.344 米）。</para>
		/// <para>使用“Silverman 经验规则”（Silverman，1986 年版）的空间变量专为输入数据集计算默认搜索半径，该变量足够强大，可避免空间异常值（距离其余点太远的点）。 有关该算法的描述，请参阅使用提示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchRadiusDenominator { get; set; }

		/// <summary>
		/// <para>Output cell values</para>
		/// <para>指定输出栅格中的值的含义。</para>
		/// <para>密度—输出值表示为每个像元计算的每单位面积的密度值。 这是默认设置。</para>
		/// <para>预期计数—输出值表示所计算的每单位面积的密度值。</para>
		/// <para>由于像元值链接到指定像元大小，因此无法将生成的栅格重新采样为不同像元大小。</para>
		/// <para><see cref="OutCellValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutCellValues { get; set; } = "DENSITIES";

		/// <summary>
		/// <para>Method</para>
		/// <para>指定将使用地平（平面）距离还是椭球体上的最短路径（测地线）距离。</para>
		/// <para>平面—将使用要素之间的平面距离。 这是默认设置。</para>
		/// <para>测地线—将使用要素之间的测地线距离。</para>
		/// <para>测地线方法仅支持作为输入要素的点。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Input barrier features for numerator</para>
		/// <para>定义障碍的数据集。</para>
		/// <para>障碍可以是折线或面要素的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object? InBarriersNumerator { get; set; }

		/// <summary>
		/// <para>Input barrier features for denominator</para>
		/// <para>定义障碍的数据集。</para>
		/// <para>障碍可以是折线或面要素的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object? InBarriersDenominator { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateKernelDensityRatio SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output cell values</para>
		/// </summary>
		public enum OutCellValuesEnum 
		{
			/// <summary>
			/// <para>密度—输出值表示为每个像元计算的每单位面积的密度值。 这是默认设置。</para>
			/// </summary>
			[GPValue("DENSITIES")]
			[Description("密度")]
			Densities,

			/// <summary>
			/// <para>预期计数—输出值表示所计算的每单位面积的密度值。</para>
			/// </summary>
			[GPValue("EXPECTED_COUNTS")]
			[Description("预期计数")]
			Expected_counts,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>平面—将使用要素之间的平面距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—将使用要素之间的测地线距离。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

#endregion
	}
}
