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
	/// <para>IDW</para>
	/// <para>反距离权重法</para>
	/// <para>使用反距离加权法 (IDW) 将点插值成栅格表面。</para>
	/// </summary>
	public class Idw : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>包含要插值到表面栅格中的 z 值的输入点要素。</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>存放每个点的高度值或量级值的字段。</para>
		/// <para>如果输入点要素包含 z 值，则该字段可以是数值型字段或者 Shape 字段。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </param>
		public Idw(object InPointFeatures, object ZField, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.ZField = ZField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 反距离权重法</para>
		/// </summary>
		public override string DisplayName() => "反距离权重法";

		/// <summary>
		/// <para>Tool Name : Idw</para>
		/// </summary>
		public override string ToolName() => "Idw";

		/// <summary>
		/// <para>Tool Excute Name : sa.Idw</para>
		/// </summary>
		public override string ExcuteName() => "sa.Idw";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, ZField, OutRaster, CellSize!, Power!, SearchRadius!, InBarrierPolylineFeatures! };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>包含要插值到表面栅格中的 z 值的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>存放每个点的高度值或量级值的字段。</para>
		/// <para>如果输入点要素包含 z 值，则该字段可以是数值型字段或者 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
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
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Power</para>
		/// <para>距离的指数。</para>
		/// <para>用于控制内插值周围点的显著性。幂值越高，远数据点的影响会越小。它可以是任意大于 0 的实数，但使用从 0.5 到 3 的值可以获得最合理的结果。默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? Power { get; set; } = "2";

		/// <summary>
		/// <para>Search radius</para>
		/// <para>定义要用来对输出栅格中各像元值进行插值的输入点。</para>
		/// <para>有两个选项：可变和固定。“可变”是默认设置。</para>
		/// <para>可变使用可变搜索半径来查找用于插值的指定数量的输入采样点。</para>
		/// <para>点数 - 指定要用于执行插值的最邻近输入采样点数量的整数值。默认值为 12 个点。</para>
		/// <para>最大距离 - 使用地图单位指定距离，以此限制对最邻近输入采样点的搜索。默认值是范围的对角线长度。</para>
		/// <para>固定使用指定的固定距离，将利用此距离范围内的所有输入点进行插值。</para>
		/// <para>距离 - 指定用作半径的距离，在该半径范围内的输入采样点将用于执行插值。半径值使用地图单位来表示。默认半径是输出栅格像元大小的五倍。</para>
		/// <para>最小点数 - 定义用于插值的最小点数的整数。默认值为 0。如果在指定距离内没有找到所需点数，则将增加搜索距离，直至找到指定的最小点数。</para>
		/// <para>搜索半径需要增加时就会增加，直到最小点数在该半径范围内，或者半径的范围越过输出栅格的下部（南）和/或上部（北）范围为止。NoData 会分配给不满足以上条件的所有位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSARadius()]
		public object? SearchRadius { get; set; } = "VARIABLE 12";

		/// <summary>
		/// <para>Input barrier polyline features</para>
		/// <para>要在搜索输入采样点时用作中断或限制的折线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Polyline")]
		public object? InBarrierPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Idw SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
