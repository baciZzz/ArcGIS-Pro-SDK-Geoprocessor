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
	/// <para>Cost Distance</para>
	/// <para>成本距离</para>
	/// <para>计算每个像元从成本面或到成本面上最小成本源的最小累积成本距离。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation))]
	public class CostDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceData">
		/// <para>Input raster or feature source data</para>
		/// <para>输入源位置。</para>
		/// <para>此为栅格或要素（点、线或面），用于标识在计算每个输出像元位置的最小累积成本距离时将使用的像元或位置。</para>
		/// <para>对于栅格，输入类型可以为整型或浮点型。</para>
		/// </param>
		/// <param name="InCostRaster">
		/// <para>Input cost raster</para>
		/// <para>定义以平面测量的经过每个像元所需的阻抗或成本。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。 每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </param>
		/// <param name="OutDistanceRaster">
		/// <para>Output distance raster</para>
		/// <para>输出成本距离栅格。</para>
		/// <para>此成本距离栅格用于标识每个像元到标识的源位置在成本表面上的最小累积成本距离。</para>
		/// <para>源可以是一个像元、一组像元或者一个或多个要素位置。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </param>
		public CostDistance(object InSourceData, object InCostRaster, object OutDistanceRaster)
		{
			this.InSourceData = InSourceData;
			this.InCostRaster = InCostRaster;
			this.OutDistanceRaster = OutDistanceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 成本距离</para>
		/// </summary>
		public override string DisplayName() => "成本距离";

		/// <summary>
		/// <para>Tool Name : CostDistance</para>
		/// </summary>
		public override string ToolName() => "CostDistance";

		/// <summary>
		/// <para>Tool Excute Name : sa.CostDistance</para>
		/// </summary>
		public override string ExcuteName() => "sa.CostDistance";

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
		public override object[] Parameters() => new object[] { InSourceData, InCostRaster, OutDistanceRaster, MaximumDistance!, OutBacklinkRaster!, SourceCostMultiplier!, SourceStartCost!, SourceResistanceRate!, SourceCapacity!, SourceDirection! };

		/// <summary>
		/// <para>Input raster or feature source data</para>
		/// <para>输入源位置。</para>
		/// <para>此为栅格或要素（点、线或面），用于标识在计算每个输出像元位置的最小累积成本距离时将使用的像元或位置。</para>
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
		/// <para>Input cost raster</para>
		/// <para>定义以平面测量的经过每个像元所需的阻抗或成本。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。 每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostRaster { get; set; }

		/// <summary>
		/// <para>Output distance raster</para>
		/// <para>输出成本距离栅格。</para>
		/// <para>此成本距离栅格用于标识每个像元到标识的源位置在成本表面上的最小累积成本距离。</para>
		/// <para>源可以是一个像元、一组像元或者一个或多个要素位置。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutDistanceRaster { get; set; }

		/// <summary>
		/// <para>Maximum distance</para>
		/// <para>累积成本值不能超过的阈值。</para>
		/// <para>如果累积的成本距离值超过该值，则像元位置的输出值为 NoData。 最大距离为计算累积成本距离适用的范围。</para>
		/// <para>默认距离是到输出栅格边的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? MaximumDistance { get; set; }

		/// <summary>
		/// <para>Output backlink raster</para>
		/// <para>输出成本回溯链接栅格。</para>
		/// <para>回溯链接栅格包含从 0 到 8 的值，这些值用于定义方向或从某像元开始沿最小累积成本路径标识下一个邻近像元（接续像元），以达到最小成本源。</para>
		/// <para>如果该路径穿过右侧的相邻像元，则为像元分配值 1、2 来与右下角像元相对应，并按顺时针方向依此类推。 值 0 留供源像元使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutBacklinkRaster { get; set; }

		/// <summary>
		/// <para>Multiplier to apply to costs</para>
		/// <para>要应用于成本值的乘数。</para>
		/// <para>可将其用于控制源的出行或放大模式。 乘数越大，在每个像元间移动的成本将越大。</para>
		/// <para>值必须大于零。 默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object? SourceCostMultiplier { get; set; }

		/// <summary>
		/// <para>Start cost</para>
		/// <para>用于开始计算成本的起始成本。</para>
		/// <para>适用于与源相关的固定成本规范。 成本算法将从通过开始成本设置的值开始，而非从零成本开始。</para>
		/// <para>值必须大于等于零。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object? SourceStartCost { get; set; }

		/// <summary>
		/// <para>Accumulative cost resistance rate</para>
		/// <para>此参数将模拟累积成本增加时所耗费成本的增加情况。 用于为旅行者的疲劳程度建模。 利用到达某个像元的累积成本的增长量乘以阻力比率，再加上移动至下一个像元的成本。</para>
		/// <para>这是修改后版本的用于计算移动经过像元的显性成本混合利率公式。 随着阻力比率的值增加，之后访问的像元成本也随之增加。 阻力比率越大，到达下一个像元需要加的附加成本也越多，将针对每个后续移动进行复合。 由于阻力比率与复利率相似且累积成本值通常会很大，因此建议采用较小的阻力比率，如 0.02、0.005 或更小，具体取决于累积成本值。</para>
		/// <para>值必须大于等于零。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object? SourceResistanceRate { get; set; }

		/// <summary>
		/// <para>Capacity</para>
		/// <para>源的行驶者的成本容量。</para>
		/// <para>每个源的成本计算将在达到指定容量后停止。</para>
		/// <para>值必须大于零。 默认容量是到输出栅格边的容量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object? SourceCapacity { get; set; }

		/// <summary>
		/// <para>Travel direction</para>
		/// <para>应用源阻力比率和源开始成本时指定行驶者的方向。</para>
		/// <para>行驶来自源—源阻力比率和源开始成本将应用于开始于输入源并移动至非源像元的情况。 这是默认设置。</para>
		/// <para>行驶到源—源阻力比率和源开始成本将应用于开始于每个非源像元并移动回输入源的情况。</para>
		/// <para>如果选择字符串选项，您可以选择将应用于所有源的“从”和“到”选项。</para>
		/// <para>如果您选择字段选项，您可以选择可确定各个源使用方向的来自源数据的字段。 字段必须包含文本字符串 FROM_SOURCE 或 TO_SOURCE。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object? SourceDirection { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostDistance SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
