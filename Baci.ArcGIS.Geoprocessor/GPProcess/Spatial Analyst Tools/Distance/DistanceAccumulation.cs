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
	/// <para>Distance Accumulation</para>
	/// <para>距离累积</para>
	/// <para>计算每个像元到源的累积距离，允许直线距离、成本距离、真实表面距离以及垂直和水平成本系数。</para>
	/// </summary>
	public class DistanceAccumulation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceData">
		/// <para>Input raster or feature source data</para>
		/// <para>输入源位置。</para>
		/// <para>此为栅格或要素数据集，用于标识计算每个输出像元位置的最小积累成本距离所依据的像元或位置。</para>
		/// <para>对于栅格，输入类型可以为整型或浮点型。</para>
		/// </param>
		/// <param name="OutDistanceAccumulationRaster">
		/// <para>Output distance accumulation raster</para>
		/// <para>输出距离栅格。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </param>
		public DistanceAccumulation(object InSourceData, object OutDistanceAccumulationRaster)
		{
			this.InSourceData = InSourceData;
			this.OutDistanceAccumulationRaster = OutDistanceAccumulationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 距离累积</para>
		/// </summary>
		public override string DisplayName() => "距离累积";

		/// <summary>
		/// <para>Tool Name : DistanceAccumulation</para>
		/// </summary>
		public override string ToolName() => "DistanceAccumulation";

		/// <summary>
		/// <para>Tool Excute Name : sa.DistanceAccumulation</para>
		/// </summary>
		public override string ExcuteName() => "sa.DistanceAccumulation";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSourceData, OutDistanceAccumulationRaster, InBarrierData, InSurfaceRaster, InCostRaster, InVerticalRaster, VerticalFactor, InHorizontalRaster, HorizontalFactor, OutBackDirectionRaster, OutSourceDirectionRaster, OutSourceLocationRaster, SourceInitialAccumulation, SourceMaximumAccumulation, SourceCostMultiplier, SourceDirection, DistanceMethod };

		/// <summary>
		/// <para>Input raster or feature source data</para>
		/// <para>输入源位置。</para>
		/// <para>此为栅格或要素数据集，用于标识计算每个输出像元位置的最小积累成本距离所依据的像元或位置。</para>
		/// <para>对于栅格，输入类型可以为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSourceData { get; set; }

		/// <summary>
		/// <para>Output distance accumulation raster</para>
		/// <para>输出距离栅格。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutDistanceAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Input barrier raster or feature data</para>
		/// <para>定义障碍的数据集。</para>
		/// <para>可通过整型栅格、浮点型栅格或要素图层来定义障碍。</para>
		/// <para>对于栅格障碍，该障碍必须具有有效值（包括零），并且非障碍区域必须为 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InBarrierData { get; set; }

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>定义每个像元位置的高程值的栅格。</para>
		/// <para>这些值用于计算经过两个像元时所涉及的实际表面距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Input cost raster</para>
		/// <para>定义以平面测量的经过每个像元所需的阻抗或成本。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostRaster { get; set; }

		/// <summary>
		/// <para>Input vertical raster</para>
		/// <para>定义每个像元位置的 z 值的栅格。</para>
		/// <para>这些 z 值用于计算坡度，而坡度用于标识在不同的像元之间移动时产生的垂直系数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		[Category("Costs relative to vertical movement (optional)")]
		public object InVerticalRaster { get; set; }

		/// <summary>
		/// <para>Vertical factor</para>
		/// <para>指定垂直成本系数和垂直相对移动角度 (VRMA) 之间的关系。</para>
		/// <para>有若干个带有修饰属性的系数可供选择，用于标识定义的垂直系数图。此外，可使用表格来创建自定义图表。这些图表用于标识在计算移动到相邻像元的总成本时的垂直系数。</para>
		/// <para>在下面的描述中，将使用两个英文首字母缩写词：VF 表示垂直系数，用于定义从一个像元移至下一像元时所遇到的垂直阻力；VRMA 表示垂直相对移动角度，用于定义“起始”像元或处理像元与“终止”像元之间的坡度角度。</para>
		/// <para>垂直系数选项如下：</para>
		/// <para>二元 - 如果 VRMA 大于交角的下限且小于交角的上限，则将 VF 设置为与零系数相关联的值；否则为无穷大。</para>
		/// <para>线性 - VF 是 VRMA 的线性函数。</para>
		/// <para>对称线性 - 无论在 VRMA 正侧还是负侧，VF 均为 VRMA 的线性函数，并且这两个线性函数关于 VF (y) 轴对称。</para>
		/// <para>逆线性 - VF 是 VRMA 的逆线性函数。</para>
		/// <para>对称逆线性 - 无论在 VRMA 正侧还是负侧，VF 均为 VRMA 的逆线性函数，并且这两个线性函数关于 VF (y) 轴对称。</para>
		/// <para>Cos - VF 为 VRMA 的余弦函数。</para>
		/// <para>Sec - VF 为 VRMA 的正割函数。</para>
		/// <para>Cos-Sec - 当 VRMA 为负时，VF 为 VRMA 的余弦函数；当 VRMA 为非负时，VF 为 VRMA 的正割函数。</para>
		/// <para>Sec-Cos - 当 VRMA 为负时，VF 为 VRMA 的正割函数；当 VRMA 为非负时，VF 为 VRMA 的余弦函数。</para>
		/// <para>表 - 将用于定义垂直系数图（确定 VF）的表文件。</para>
		/// <para>垂直关键字的修饰属性如下：</para>
		/// <para>零系数 - VRMA 为零时要使用的垂直系数。该系数可确定指定函数的 y 截距。按照定义，零系数对于任意三角垂直函数（COS、SEC、COS-SEC 或 SEC-COS）都不适用。y 截距由以上函数定义。</para>
		/// <para>交角下限 - 一个 VRMA 角度，小于该角度时 VF 将被设置为无穷大。</para>
		/// <para>交角上限 - 一个 VRMA 角度，大于该角度时 VF 将被设置为无穷大。</para>
		/// <para>坡度 - 与线性和逆线性垂直系数关键字相结合使用的直线坡度。坡度被指定为垂直增量与水平增量的比值(例如，45 百分比坡度是 1/45，以 0.02222 的方式输入)。</para>
		/// <para>表名 - 定义 VF 的表名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAVerticalFactor()]
		[Category("Costs relative to vertical movement (optional)")]
		public object VerticalFactor { get; set; } = "BINARY 1 -30 30";

		/// <summary>
		/// <para>Input horizontal raster</para>
		/// <para>定义每个像元的水平方向的栅格。</para>
		/// <para>在栅格上的这些值必须是整数，以北纬 0 度(或朝向屏幕顶部)为起始值，范围为 0 至 360，顺时针增加。平坦区域应赋值为 -1。每个位置上的值与水平系数结合使用，用来确定在相邻像元之间移动时产生的水平成本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		[Category("Costs relative to horizontal movement (optional)")]
		public object InHorizontalRaster { get; set; }

		/// <summary>
		/// <para>Horizontal factor</para>
		/// <para>指定水平成本系数和水平相对移动角度 (HRMA) 之间的关系。</para>
		/// <para>有若干个带有修饰属性的系数可供选择，用于标识定义的水平系数图。此外，可使用表格来创建自定义图表。这些图表用于标识在计算移动到相邻像元的总成本时的水平系数。</para>
		/// <para>在下面的描述中，将使用两个英文首字母缩写词：HF 表示水平系数，用于定义从一个像元移动到下一像元时所遇到的水平阻力；HRMA 表示水平相对移动角度，用于定义像元的水平方向与移动方向之间的角度。</para>
		/// <para>水平系数选项如下：</para>
		/// <para>二元 - 如果 HRMA 小于交角，则将 HF 设置为与零系数相关联的值；否则为无穷大。</para>
		/// <para>前向 - 只允许向前的移动。HRMA 必须大于等于 0 度且小于 90 度 (0 &lt;= HRMA &lt; 90)。如果 HRMA 大于 0 度且小于 45 度，则将像元的 HF 设置为与零系数相关联的值。如果 HRMA 大于等于 45 度，则使用边值修饰属性值。对于 HRMA 等于或大于 90 度的任何情况，均将 HF 设置为无穷大。</para>
		/// <para>线性 - HF 是 HRMA 的线性函数。</para>
		/// <para>逆线性 - HF 是 HRMA 的逆线性函数。</para>
		/// <para>表 - 将用于定义水平系数图（以确定 HF）的表文件。</para>
		/// <para>水平系数的修饰属性如下：</para>
		/// <para>零系数 - HRMA 为零时要使用的水平系数。该系数可确定任意水平系数函数的 y 截距。</para>
		/// <para>交角 - 一个 HRMA 角度，大于该角度时 HF 将被设置为无穷大。</para>
		/// <para>坡度 - 与线性和逆线性水平系数关键字相结合使用的直线坡度。坡度被指定为垂直增量与水平增量的比值(例如，45 百分比坡度是 1/45，以 0.02222 的方式输入)。</para>
		/// <para>边值 - 在指定了前向水平系数关键字的情况下，HRMA 大于或等于 45 度且小于 90 度时的 HF。</para>
		/// <para>表名 - 定义 HF 的表名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAHorizontalFactor()]
		[Category("Costs relative to horizontal movement (optional)")]
		public object HorizontalFactor { get; set; } = "BINARY 1 45";

		/// <summary>
		/// <para>Out back direction raster</para>
		/// <para>反向栅格中包含以度为单位的计算方向。该方向可用于识别沿最短路径返回最近源同时避开障碍的下一像元。</para>
		/// <para>值的范围是 0 度到 360 度，并为源像元保留 0 度。正东（右侧）是 90 度，且值以顺时针方向增加（180 是南方、270 是西方、360 是北方）。</para>
		/// <para>输出栅格为浮点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutBackDirectionRaster { get; set; }

		/// <summary>
		/// <para>Out source direction raster</para>
		/// <para>源方向栅格将最小积累成本源像元的方向标识为方位角（以度为单位）。</para>
		/// <para>值的范围是 0 度到 360 度，并为源像元保留 0 度。正东（右侧）是 90 度，且值以顺时针方向增加（180 是南方、270 是西方、360 是北方）。</para>
		/// <para>输出栅格为浮点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Additional output rasters (optional)")]
		public object OutSourceDirectionRaster { get; set; }

		/// <summary>
		/// <para>Out source location raster</para>
		/// <para>源位置栅格为多波段输出。 第一个波段包含行索引，第二个波段包含列索引。 这些索引用于标识相距最小积累成本距离的源像元的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Additional output rasters (optional)")]
		public object OutSourceLocationRaster { get; set; }

		/// <summary>
		/// <para>Initial accumulation</para>
		/// <para>开始进行成本计算的初始累积成本。</para>
		/// <para>适用于与源相关的固定成本规范。成本算法将从通过初始累积设置的值开始，而非从零成本开始。</para>
		/// <para>值必须大于等于零。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object SourceInitialAccumulation { get; set; }

		/// <summary>
		/// <para>Maximum accumulation</para>
		/// <para>源的旅行者的最大累积。</para>
		/// <para>每个源的成本计算将在达到指定累积后停止。</para>
		/// <para>值必须大于零。默认累积为到输出栅格边的边。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object SourceMaximumAccumulation { get; set; }

		/// <summary>
		/// <para>Multiplier to apply to costs</para>
		/// <para>要应用于成本值的乘数。</para>
		/// <para>可将其用于控制源的出行或放大模式。乘数越大，在每个像元间移动的成本将越大。</para>
		/// <para>值必须大于零。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object SourceCostMultiplier { get; set; }

		/// <summary>
		/// <para>Travel direction</para>
		/// <para>当应用水平和垂直系数时，指定旅行者的方向。</para>
		/// <para>行驶来自源—水平系数和垂直系数将应用于从输入源开始并行驶至非源像元的情况。这是默认设置。</para>
		/// <para>行驶到源—水平系数和垂直系数将应用于从每个非源像元开始并行驶回输入源的情况。</para>
		/// <para>如果选择字符串选项，您可以选择将应用于所有源的“自”和“至”选项。</para>
		/// <para>如果您选择字段选项，您可以选择可确定各个源使用方向的来自源数据的字段。字段必须包含文本字符串 FROM_SOURCE 或 TO_SOURCE。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object SourceDirection { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定是否使用平面（平地）或测地线（椭球）方法计算距离。</para>
		/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行距离计算。这是默认设置。</para>
		/// <para>测地线—距离计算将在椭圆体上执行。因此，结果不会改变，不考虑输入或输出投影。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DistanceAccumulation SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行距离计算。这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—距离计算将在椭圆体上执行。因此，结果不会改变，不考虑输入或输出投影。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

#endregion
	}
}
