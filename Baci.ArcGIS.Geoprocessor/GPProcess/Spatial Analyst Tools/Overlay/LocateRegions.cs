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
	/// <para>Locate Regions</para>
	/// <para>查找区域</para>
	/// <para>通过满足指定评估标准且满足确定形状、大小、数量和区域间距离约束的输入效用值（适宜性）栅格来标识最佳区域或连续像元组。</para>
	/// </summary>
	public class LocateRegions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>从中派生区域的输入效用值栅格。</para>
		/// <para>输入栅格中的值越大，效用越大。</para>
		/// <para>栅格可为整型或浮点型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出区域栅格。</para>
		/// <para>每个区域均以大于零的值单独进行编号。不属于任何区域的像元编号为零。输出始终为整型栅格。</para>
		/// <para>针对选定区域存储统计数据的各个区域计算其他字段。这些字段包括：</para>
		/// <para>AVERAGE—区域的平均效用值。</para>
		/// <para>TOTAL—区域内效用值总和。</para>
		/// <para>MEDIAN—区域的中值效用值。</para>
		/// <para>HIGHEST—区域内包含的最高单个像元值。</para>
		/// <para>LOWEST—区域内包含的最低单个像元值。</para>
		/// <para>COREAREA—核心面积。远于区域边缘像元的所有像元均视为核心的一部分。</para>
		/// <para>CORESUM—核心面积的效用值累计总和。</para>
		/// <para>EDGE—使用 P1 比率的边缘量，其中 P1 指形状周长与相同面积圆周长的比率。圆的 P1 比率为 1。</para>
		/// </param>
		public LocateRegions(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找区域</para>
		/// </summary>
		public override string DisplayName() => "查找区域";

		/// <summary>
		/// <para>Tool Name : LocateRegions</para>
		/// </summary>
		public override string ToolName() => "LocateRegions";

		/// <summary>
		/// <para>Tool Excute Name : sa.LocateRegions</para>
		/// </summary>
		public override string ExcuteName() => "sa.LocateRegions";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "rasterStatistics", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, TotalArea, AreaUnits, NumberOfRegions, RegionShape, RegionOrientation, ShapeTradeoff, EvaluationMethod, MinimumArea, MaximumArea, MinimumDistance, MaximumDistance, DistanceUnits, InExistingRegions, NumberOfNeighbors, NoIslands, RegionSeeds, RegionResolution, SelectionMethod };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>从中派生区域的输入效用值栅格。</para>
		/// <para>输入栅格中的值越大，效用越大。</para>
		/// <para>栅格可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出区域栅格。</para>
		/// <para>每个区域均以大于零的值单独进行编号。不属于任何区域的像元编号为零。输出始终为整型栅格。</para>
		/// <para>针对选定区域存储统计数据的各个区域计算其他字段。这些字段包括：</para>
		/// <para>AVERAGE—区域的平均效用值。</para>
		/// <para>TOTAL—区域内效用值总和。</para>
		/// <para>MEDIAN—区域的中值效用值。</para>
		/// <para>HIGHEST—区域内包含的最高单个像元值。</para>
		/// <para>LOWEST—区域内包含的最低单个像元值。</para>
		/// <para>COREAREA—核心面积。远于区域边缘像元的所有像元均视为核心的一部分。</para>
		/// <para>CORESUM—核心面积的效用值累计总和。</para>
		/// <para>EDGE—使用 P1 比率的边缘量，其中 P1 指形状周长与相同面积圆周长的比率。圆的 P1 比率为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Total area</para>
		/// <para>所有区域的总面积。</para>
		/// <para>默认为处理范围内输入像元的百分之 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object TotalArea { get; set; }

		/// <summary>
		/// <para>Area units</para>
		/// <para>定义总面积、区域最小面积和区域最大面积参数使用的面积单位。</para>
		/// <para>可用选项及相应的单位如下：</para>
		/// <para>平方地图单位—输出空间参考的线性单位的平方</para>
		/// <para>平方英里—英里</para>
		/// <para>平方千米—千米</para>
		/// <para>公顷—公顷</para>
		/// <para>英亩—英亩</para>
		/// <para>平方米—米</para>
		/// <para>平方码—码</para>
		/// <para>平方英尺—英尺</para>
		/// <para>默认单位取决于输入栅格数据集。如果输入栅格的单位为英尺、码、英里或任何其他英制单位，则将使用 Square miles。如果输入栅格的单位为米、千米或任何其他公制单位，则将使用 Square kilometers。</para>
		/// <para><see cref="AreaUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AreaUnits { get; set; } = "SQUARE_MAP_UNITS";

		/// <summary>
		/// <para>Number of regions</para>
		/// <para>确定跨总面积分配的区域数。</para>
		/// <para>可指定的区域最大数为 30。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberOfRegions { get; set; } = "1";

		/// <summary>
		/// <para>Region shape</para>
		/// <para>定义输出区域的形状特征。</para>
		/// <para>区域从种子像元位置开始向外增长，优先考虑能够保持所需形状的像元。</para>
		/// <para>可用形状选项如下：</para>
		/// <para>圆形—保持圆形区域的像元将获得较大的权重。这是默认设置。</para>
		/// <para>椭圆形—保持椭圆形区域的像元将获得较大的权重。</para>
		/// <para>等边三角形—保持等边三角形区域的像元将获得较大的权重。</para>
		/// <para>正方形—保持方形区域的像元将获得较大的权重。</para>
		/// <para>五边形—保持五角形区域的像元将获得较大的权重。</para>
		/// <para>六边形—保持六角形区域的像元将获得较大的权重。</para>
		/// <para>八边形—保持八角形区域的像元将获得较大的权重。</para>
		/// <para><see cref="RegionShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RegionShape { get; set; } = "CIRCLE";

		/// <summary>
		/// <para>Region orientation</para>
		/// <para>定义已定义形状的方向。区域从种子位置开始向外增长，优先考虑能保持所需区域形状方向的像元。</para>
		/// <para>方向值以罗盘度为单位，范围从 0 到 360，从北开始顺时针增加。默认值为 0。</para>
		/// <para>默认值 0 按照以下方式确定形状的方向：圆形 - 无影响；椭圆形 - 短轴指向南北方向；三角形和五角形 - 一点竖直向上；方形、六角形和八角形 - 一侧直边指向东西方向。</para>
		/// <para>如果区域形状设置为 Circle，则区域方向参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 360)]
		public object RegionOrientation { get; set; } = "0";

		/// <summary>
		/// <para>Shape/Utility tradeoff (%)</para>
		/// <para>确定采用参数化区域增长算法使候选区域增长时的像元权重。权重是像元在保持所需区域形状与像元属性值效用（适宜性）两方面的折衷。</para>
		/// <para>值越高，表示保持区域形状越重要于选择较高的效用值。可接受的百分比值为 0 到 100（包括 0 和 100）。默认值为 50。</para>
		/// <para>此参数用于确定可行候选区域。算法选择的候选区域由评估方法参数控制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object ShapeTradeoff { get; set; } = "50";

		/// <summary>
		/// <para>Evaluation method</para>
		/// <para>评估标准，用于确定采用参数化区域增长算法确定的候选区域中哪个优先级最高。可根据效用值的特定统计数据或区域内像元的空间排列来指定优先级。</para>
		/// <para>可用选项如下：</para>
		/// <para>最高平均值—根据最高平均值选择区域。这是默认设置。</para>
		/// <para>最高总和—根据最高总和选择区域。</para>
		/// <para>最高中值—根据最高中值选择区域。</para>
		/// <para>最高值—根据区域内包含的最高单个像元值选择区域。此选项可确保选择各个最佳像元。</para>
		/// <para>最低值—根据区域内包含的最高最低单个像元值选择区域。此选项可确保选定区域包含的像元效用值确实低。</para>
		/// <para>最大核心面积—根据最大核心面积选择区域。远于区域边缘像元的所有像元均视为核心的一部分。可通过分析像元大小控制边缘距离。设置的像元大小越小，核心面积越大。</para>
		/// <para>核心效用值最高总和—根据核心面积效用值的最高累计总和选择区域。可通过分析像元大小控制边缘距离。</para>
		/// <para>最大边缘—使用 P1 比率根据最大边缘数选择区域，其中 P1 指形状周长与相同面积圆周长的比率。圆的 P1 比率为 1。</para>
		/// <para><see cref="EvaluationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EvaluationMethod { get; set; } = "HIGHEST_AVERAGE_VALUE";

		/// <summary>
		/// <para>Region minimum area</para>
		/// <para>定义每个区域允许的最小面积。</para>
		/// <para>将使用面积单位参数指定的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MinimumArea { get; set; }

		/// <summary>
		/// <para>Region maximum area</para>
		/// <para>定义每个区域允许的最大面积。</para>
		/// <para>将使用面积单位参数指定的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaximumArea { get; set; }

		/// <summary>
		/// <para>Minimum distance between regions</para>
		/// <para>定义区域间允许的最小距离。此距离内无法存在两个区域。</para>
		/// <para>此参数影响参数化区域增长 (PRG) 算法。如果某像元可能添加到候选区域中，但其对于输入栅格或现有区域的要素参数指定的数据集中的任何单个区域而言均在此距离内，则不会将此区域考虑为候选区域。不会向排除的位置（NoData 像元）应用最小距离设置。</para>
		/// <para>将使用由距离单位参数指定的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MinimumDistance { get; set; }

		/// <summary>
		/// <para>Maximum distance between regions</para>
		/// <para>定义区域间允许的最大距离。两个区域之间的距离不可远于此距离。</para>
		/// <para>按顺序依次选择区域时，如果最佳区域与任何已选择区域的距离远于此距离，则此次不会选择该区域，但是可在稍后选择更多区域时选择该区域。</para>
		/// <para>最大距离应用于输入栅格或现有区域的要素参数指定的数据集，在这种情况下，必须至少有一个选定区域在现有区域的最大距离范围内。最大距离设置不应用于排除位置（NoData 像元），且不对 PRG 算法产生影响。</para>
		/// <para>将使用由距离单位参数指定的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MaximumDistance { get; set; }

		/// <summary>
		/// <para>Distance units</para>
		/// <para>定义用于区域间最小距离和区域间最大距离参数的距离单位。</para>
		/// <para>可用选项及相应的单位如下：</para>
		/// <para>地图单位—输出空间参考的线性单位</para>
		/// <para>英里—英里</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para>码—码</para>
		/// <para>英尺—英尺</para>
		/// <para>默认单位取决于输入栅格数据集。如果输入栅格的单位为英尺、码、英里或任何其他英制单位，则将使用 Miles。如果输入栅格的单位为米、千米或任何其他公制单位，则将使用 Kilometers。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "MAP_UNITS";

		/// <summary>
		/// <para>Input raster or feature of existing regions</para>
		/// <para>定义已存在区域之处的数据集。</para>
		/// <para>输入可以为栅格或要素数据集。如果输入为栅格，则会将栅格内所有含有效值的位置视为已分配。所有其他位置均设为 NoData。</para>
		/// <para>在参数化区域增长算法中，区域不会从标识为现有区域的任何位置增长。如以上相应参数说明所述，现有区域将用于区域间最小距离和区域间最大距离参数的增长和评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InExistingRegions { get; set; }

		/// <summary>
		/// <para>Number of neighbors to use in growth</para>
		/// <para>定义在区域增长时要使用的相邻像元。</para>
		/// <para>可用选项如下：</para>
		/// <para>四—区域增长时仅考虑区域直接（正交）相邻的四个像元。</para>
		/// <para>八—区域增长时考虑八个最近像元（正交和对角线）。这是默认设置。</para>
		/// <para><see cref="NumberOfNeighborsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object NumberOfNeighbors { get; set; } = "EIGHT";

		/// <summary>
		/// <para>Islands not allowed in regions</para>
		/// <para>定义潜在区域内是否允许岛屿。</para>
		/// <para>选中 - 参数化区域增长算法确保区域内无岛屿。这是默认设置。创建区域后但选择区域前，会将洪水字段算法实施为后处理。如果区域内存在岛屿，则将填充岛屿，且会向区域添加像元。由于填充过程发生在选择过程之前，因此会将岛屿像元的效用添加到区域中，将在区域选择过程中和输出区域的统计数据内包括效用值。填充过程完成后，分配的总面积可能会超过总面积参数指定的目标。</para>
		/// <para>未选中 - 允许岛屿。</para>
		/// <para><see cref="NoIslandsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object NoIslands { get; set; } = "true";

		/// <summary>
		/// <para>Number of seeds to grow from</para>
		/// <para>定义可用于增长潜在区域的种子数。</para>
		/// <para>可用选项如下：</para>
		/// <para>基于输入—种子数取决于输入栅格中的像元数。输入栅格的像元数少于等于 100,000 时，默认为 Maximum。输入栅格的像元数大于 100,000 时，默认为 Small。这是默认设置。</para>
		/// <para>小型—排除 NoData 像元后，种子数等于输入栅格中像元数的 10%，但不超过 1,600 个种子。</para>
		/// <para>中等—排除 NoData 像元后，种子数等于输入栅格中像元数的 20%，但不超过 2,500 个种子。</para>
		/// <para>大型—排除 NoData 像元后，种子数等于输入栅格中像元数的 30%，但不超过 3,600 个种子。</para>
		/// <para>最大值—输入栅格内的每个可用像元均会发生区域增长。可用像元指所有非 NoData 像元和所有未识别为现有区域的像元。</para>
		/// <para><see cref="RegionSeedsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object RegionSeeds { get; set; } = "AUTO";

		/// <summary>
		/// <para>Resolution of the growth</para>
		/// <para>设置区域增长的分辨率。</para>
		/// <para>输入栅格将以此参数识别的像元的数量确定的分辨率重新采样（见下文）。例如，针对 LOW，输入栅格对 147,356 个像元重新采样。参数化区域增长算法在重新采样的中间栅格基础上增长。从重新采样的中间栅格中选择区域后，选定区域将以环境像元大小重新采样。</para>
		/// <para>如果所需平均区域大小的像元数过小或过大，则会对目标分辨率进行以下调整。此调整将确保每个所需区域中均有足够的像元，且不会产生不必要的处理。因此，以下各个指定分辨率的中间重新采样栅格的总像元数可低于或高于目标像元数。</para>
		/// <para>如果输入的像元少于 147,356 个，或选择了 Maximum，则不会重新采样，而是对输入栅格内的所有像元进行区域增长。如果输入栅格的像元少于 147,356 个，则 Low、Medium 或 High 选项将没有效果。</para>
		/// <para>可用选项如下：</para>
		/// <para>基于输入—分辨率取决于输入栅格中的像元数。输入栅格的像元数少于等于 500,000 时，默认为 Maximum。输入栅格的像元数大于 500,000 时，默认为 Low。这是默认设置。</para>
		/// <para>低—将对包含 147,356 个 (384 x 384) 像元（这些像元以相同的 x 比率和 y 比率分配为输入栅格）的中间栅格执行分析。</para>
		/// <para>中等—将对包含 262,144 个 (512 x 512) 像元（这些像元以相同的 x 比率和 y 比率分配为输入栅格）的中间栅格执行分析。</para>
		/// <para>高—将对包含 589,824 个 (768 x 768) 像元（这些像元以相同的 x 比率和 y 比率分配为输入栅格）的中间栅格执行分析。</para>
		/// <para>最大值—将对输入栅格中的所有像元执行分析。</para>
		/// <para><see cref="RegionResolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object RegionResolution { get; set; } = "AUTO";

		/// <summary>
		/// <para>Region selection method</para>
		/// <para>确定如何选择区域。</para>
		/// <para>可用选项如下：</para>
		/// <para>根据区域数—选择方法取决于区域数参数。如果区域数小于等于 8，则使用 Combinatorial 选择方法。如果区域数参数大于 8，则使用 Sequential 选择方法。这是默认设置。</para>
		/// <para>组合—在考虑到空间约束的情况下，根据参数化区域增长 (PRG) 算法测试候选区域内所需区域数的所有组合，基于指定评估方法选择最佳区域。</para>
		/// <para>相继—基于评估方法依序选择满足空间约束的最佳区域，直至达到所需区域数。</para>
		/// <para><see cref="SelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object SelectionMethod { get; set; } = "AUTO";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateRegions SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object rasterStatistics = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Area units</para>
		/// </summary>
		public enum AreaUnitsEnum 
		{
			/// <summary>
			/// <para>平方地图单位—输出空间参考的线性单位的平方</para>
			/// </summary>
			[GPValue("SQUARE_MAP_UNITS")]
			[Description("平方地图单位")]
			Square_map_units,

			/// <summary>
			/// <para>平方英里—英里</para>
			/// </summary>
			[GPValue("SQUARE_MILES")]
			[Description("平方英里")]
			Square_miles,

			/// <summary>
			/// <para>平方千米—千米</para>
			/// </summary>
			[GPValue("SQUARE_KILOMETERS")]
			[Description("平方千米")]
			Square_kilometers,

			/// <summary>
			/// <para>公顷—公顷</para>
			/// </summary>
			[GPValue("HECTARES")]
			[Description("公顷")]
			Hectares,

			/// <summary>
			/// <para>英亩—英亩</para>
			/// </summary>
			[GPValue("ACRES")]
			[Description("英亩")]
			Acres,

			/// <summary>
			/// <para>平方米—米</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("平方米")]
			Square_meters,

			/// <summary>
			/// <para>平方码—码</para>
			/// </summary>
			[GPValue("SQUARE_YARDS")]
			[Description("平方码")]
			Square_yards,

			/// <summary>
			/// <para>平方英尺—英尺</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("平方英尺")]
			Square_feet,

		}

		/// <summary>
		/// <para>Region shape</para>
		/// </summary>
		public enum RegionShapeEnum 
		{
			/// <summary>
			/// <para>圆形—保持圆形区域的像元将获得较大的权重。这是默认设置。</para>
			/// </summary>
			[GPValue("CIRCLE")]
			[Description("圆形")]
			Circle,

			/// <summary>
			/// <para>椭圆形—保持椭圆形区域的像元将获得较大的权重。</para>
			/// </summary>
			[GPValue("ELLIPSE")]
			[Description("椭圆形")]
			Ellipse,

			/// <summary>
			/// <para>等边三角形—保持等边三角形区域的像元将获得较大的权重。</para>
			/// </summary>
			[GPValue("TRIANGLE")]
			[Description("等边三角形")]
			Equilateral_triangle,

			/// <summary>
			/// <para>正方形—保持方形区域的像元将获得较大的权重。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("正方形")]
			Square,

			/// <summary>
			/// <para>五边形—保持五角形区域的像元将获得较大的权重。</para>
			/// </summary>
			[GPValue("PENTAGON")]
			[Description("五边形")]
			Pentagon,

			/// <summary>
			/// <para>六边形—保持六角形区域的像元将获得较大的权重。</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("六边形")]
			Hexagon,

			/// <summary>
			/// <para>八边形—保持八角形区域的像元将获得较大的权重。</para>
			/// </summary>
			[GPValue("OCTAGON")]
			[Description("八边形")]
			Octagon,

		}

		/// <summary>
		/// <para>Evaluation method</para>
		/// </summary>
		public enum EvaluationMethodEnum 
		{
			/// <summary>
			/// <para>最高平均值—根据最高平均值选择区域。这是默认设置。</para>
			/// </summary>
			[GPValue("HIGHEST_AVERAGE_VALUE")]
			[Description("最高平均值")]
			Highest_average_value,

			/// <summary>
			/// <para>最高总和—根据最高总和选择区域。</para>
			/// </summary>
			[GPValue("HIGHEST_SUM")]
			[Description("最高总和")]
			Highest_sum,

			/// <summary>
			/// <para>最高中值—根据最高中值选择区域。</para>
			/// </summary>
			[GPValue("HIGHEST_MEDIAN_VALUE")]
			[Description("最高中值")]
			Highest_median_value,

			/// <summary>
			/// <para>最高值—根据区域内包含的最高单个像元值选择区域。此选项可确保选择各个最佳像元。</para>
			/// </summary>
			[GPValue("HIGHEST_VALUE")]
			[Description("最高值")]
			Highest_value,

			/// <summary>
			/// <para>最低值—根据区域内包含的最高最低单个像元值选择区域。此选项可确保选定区域包含的像元效用值确实低。</para>
			/// </summary>
			[GPValue("LOWEST_VALUE")]
			[Description("最低值")]
			Lowest_value,

			/// <summary>
			/// <para>最大核心面积—根据最大核心面积选择区域。远于区域边缘像元的所有像元均视为核心的一部分。可通过分析像元大小控制边缘距离。设置的像元大小越小，核心面积越大。</para>
			/// </summary>
			[GPValue("GREATEST_CORE_AREA")]
			[Description("最大核心面积")]
			Greatest_core_area,

			/// <summary>
			/// <para>核心效用值最高总和—根据核心面积效用值的最高累计总和选择区域。可通过分析像元大小控制边缘距离。</para>
			/// </summary>
			[GPValue("HIGHEST_CORE_SUM")]
			[Description("核心效用值最高总和")]
			Highest_sum_of_core_utility_values,

			/// <summary>
			/// <para>最大边缘—使用 P1 比率根据最大边缘数选择区域，其中 P1 指形状周长与相同面积圆周长的比率。圆的 P1 比率为 1。</para>
			/// </summary>
			[GPValue("GREATEST_EDGE")]
			[Description("最大边缘")]
			Greatest_edge,

		}

		/// <summary>
		/// <para>Distance units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>地图单位—输出空间参考的线性单位</para>
			/// </summary>
			[GPValue("MAP_UNITS")]
			[Description("地图单位")]
			Map_units,

			/// <summary>
			/// <para>英里—英里</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>千米—千米</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>米—米</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>码—码</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英尺—英尺</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

		}

		/// <summary>
		/// <para>Number of neighbors to use in growth</para>
		/// </summary>
		public enum NumberOfNeighborsEnum 
		{
			/// <summary>
			/// <para>八—区域增长时考虑八个最近像元（正交和对角线）。这是默认设置。</para>
			/// </summary>
			[GPValue("EIGHT")]
			[Description("八")]
			Eight,

			/// <summary>
			/// <para>四—区域增长时仅考虑区域直接（正交）相邻的四个像元。</para>
			/// </summary>
			[GPValue("FOUR")]
			[Description("四")]
			Four,

		}

		/// <summary>
		/// <para>Islands not allowed in regions</para>
		/// </summary>
		public enum NoIslandsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_ISLANDS")]
			NO_ISLANDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ISLANDS_ALLOWED")]
			ISLANDS_ALLOWED,

		}

		/// <summary>
		/// <para>Number of seeds to grow from</para>
		/// </summary>
		public enum RegionSeedsEnum 
		{
			/// <summary>
			/// <para>基于输入—种子数取决于输入栅格中的像元数。输入栅格的像元数少于等于 100,000 时，默认为 Maximum。输入栅格的像元数大于 100,000 时，默认为 Small。这是默认设置。</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("基于输入")]
			Based_on_input,

			/// <summary>
			/// <para>小型—排除 NoData 像元后，种子数等于输入栅格中像元数的 10%，但不超过 1,600 个种子。</para>
			/// </summary>
			[GPValue("SMALL")]
			[Description("小型")]
			Small,

			/// <summary>
			/// <para>中等—排除 NoData 像元后，种子数等于输入栅格中像元数的 20%，但不超过 2,500 个种子。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中等")]
			Medium,

			/// <summary>
			/// <para>大型—排除 NoData 像元后，种子数等于输入栅格中像元数的 30%，但不超过 3,600 个种子。</para>
			/// </summary>
			[GPValue("LARGE")]
			[Description("大型")]
			Large,

			/// <summary>
			/// <para>最大值—输入栅格内的每个可用像元均会发生区域增长。可用像元指所有非 NoData 像元和所有未识别为现有区域的像元。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

		}

		/// <summary>
		/// <para>Resolution of the growth</para>
		/// </summary>
		public enum RegionResolutionEnum 
		{
			/// <summary>
			/// <para>基于输入—分辨率取决于输入栅格中的像元数。输入栅格的像元数少于等于 500,000 时，默认为 Maximum。输入栅格的像元数大于 500,000 时，默认为 Low。这是默认设置。</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("基于输入")]
			Based_on_input,

			/// <summary>
			/// <para>低—将对包含 147,356 个 (384 x 384) 像元（这些像元以相同的 x 比率和 y 比率分配为输入栅格）的中间栅格执行分析。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低")]
			Low,

			/// <summary>
			/// <para>中等—将对包含 262,144 个 (512 x 512) 像元（这些像元以相同的 x 比率和 y 比率分配为输入栅格）的中间栅格执行分析。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中等")]
			Medium,

			/// <summary>
			/// <para>高—将对包含 589,824 个 (768 x 768) 像元（这些像元以相同的 x 比率和 y 比率分配为输入栅格）的中间栅格执行分析。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高")]
			High,

			/// <summary>
			/// <para>最大值—将对输入栅格中的所有像元执行分析。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

		}

		/// <summary>
		/// <para>Region selection method</para>
		/// </summary>
		public enum SelectionMethodEnum 
		{
			/// <summary>
			/// <para>根据区域数—选择方法取决于区域数参数。如果区域数小于等于 8，则使用 Combinatorial 选择方法。如果区域数参数大于 8，则使用 Sequential 选择方法。这是默认设置。</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("根据区域数")]
			Based_on_number_of_regions,

			/// <summary>
			/// <para>组合—在考虑到空间约束的情况下，根据参数化区域增长 (PRG) 算法测试候选区域内所需区域数的所有组合，基于指定评估方法选择最佳区域。</para>
			/// </summary>
			[GPValue("COMBINATORIAL")]
			[Description("组合")]
			Combinatorial,

			/// <summary>
			/// <para>相继—基于评估方法依序选择满足空间约束的最佳区域，直至达到所需区域数。</para>
			/// </summary>
			[GPValue("SEQUENTIAL")]
			[Description("相继")]
			Sequential,

		}

#endregion
	}
}
