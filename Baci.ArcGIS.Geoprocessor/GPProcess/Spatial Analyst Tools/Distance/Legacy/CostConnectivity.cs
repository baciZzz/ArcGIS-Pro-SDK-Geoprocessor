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
	/// <para>Cost Connectivity</para>
	/// <para>成本连通性</para>
	/// <para>在两个或多个输入区域之间生成成本最低的连通性网络。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalRegionConnections"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalRegionConnections))]
	public class CostConnectivity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRegions">
		/// <para>Input raster or feature region data</para>
		/// <para>要通过最低成本网络连接的输入区域。</para>
		/// <para>区域可以通过栅格或要素数据集来定义。</para>
		/// <para>如果区域输入为栅格，则区域将通过值相同的连续（邻近）像元组进行定义。 每个区域必须具有唯一的编号。 不属于任何区域的像元一定是 NoData。 栅格类型必须为整型，值可正可负。</para>
		/// <para>如果区域输入为要素数据集，则它可以是面、线或点。 面要素区域不能包含多部分面。</para>
		/// </param>
		/// <param name="InCostRaster">
		/// <para>Input cost raster</para>
		/// <para>定义以平面测量的经过每个像元所需的阻抗或成本。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。 每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>优化（成本最低）路径网络的输出面要素类需要连接每个输入区域。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。 这些字段包括：</para>
		/// <para>PATHID- 路径的唯一标识符</para>
		/// <para>PATHCOST- 路径的总累计成本</para>
		/// <para>REGION1- 该路径连接的第一个区域</para>
		/// <para>REGION2- 该路径连接的另一个区域</para>
		/// <para>该信息有助于您深入分析网络内的路径。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </param>
		public CostConnectivity(object InRegions, object InCostRaster, object OutFeatureClass)
		{
			this.InRegions = InRegions;
			this.InCostRaster = InCostRaster;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 成本连通性</para>
		/// </summary>
		public override string DisplayName() => "成本连通性";

		/// <summary>
		/// <para>Tool Name : CostConnectivity</para>
		/// </summary>
		public override string ToolName() => "CostConnectivity";

		/// <summary>
		/// <para>Tool Excute Name : sa.CostConnectivity</para>
		/// </summary>
		public override string ExcuteName() => "sa.CostConnectivity";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRegions, InCostRaster, OutFeatureClass, OutNeighborPaths! };

		/// <summary>
		/// <para>Input raster or feature region data</para>
		/// <para>要通过最低成本网络连接的输入区域。</para>
		/// <para>区域可以通过栅格或要素数据集来定义。</para>
		/// <para>如果区域输入为栅格，则区域将通过值相同的连续（邻近）像元组进行定义。 每个区域必须具有唯一的编号。 不属于任何区域的像元一定是 NoData。 栅格类型必须为整型，值可正可负。</para>
		/// <para>如果区域输入为要素数据集，则它可以是面、线或点。 面要素区域不能包含多部分面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRegions { get; set; }

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
		/// <para>Output feature class</para>
		/// <para>优化（成本最低）路径网络的输出面要素类需要连接每个输入区域。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。 这些字段包括：</para>
		/// <para>PATHID- 路径的唯一标识符</para>
		/// <para>PATHCOST- 路径的总累计成本</para>
		/// <para>REGION1- 该路径连接的第一个区域</para>
		/// <para>REGION2- 该路径连接的另一个区域</para>
		/// <para>该信息有助于您深入分析网络内的路径。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output feature class of neighboring connections</para>
		/// <para>该输出面要素类用于标识从每个区域到其每个最近邻域的所有路径。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。 这些字段包括：</para>
		/// <para>PATHID- 路径的唯一标识符</para>
		/// <para>PATHCOST- 路径的总累计成本</para>
		/// <para>REGION1- 该路径连接的第一个区域</para>
		/// <para>REGION2- 该路径连接的另一个区域</para>
		/// <para>该信息有助于深入分析网络内的路径，而且对于决定应该移除哪条路径尤其有用（如有必要）。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutNeighborPaths { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostConnectivity SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? mask = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
