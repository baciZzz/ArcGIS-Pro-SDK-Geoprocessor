using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Kriging</para>
	/// <para>克里金法</para>
	/// <para>使用克里金法将点插值成栅格表面。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools.EmpiricalBayesianKriging"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools.EmpiricalBayesianKriging))]
	public class Kriging : AbstractGPProcess
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
		/// <param name="OutSurfaceRaster">
		/// <para>Output surface raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </param>
		/// <param name="SemivariogramProps">
		/// <para>Semivariogram properties</para>
		/// <para>要使用的半变异函数模型。有两种克里金法：普通克里金法和泛克里金法。</para>
		/// <para>普通克里金法可使用下列半变异函数模型：</para>
		/// <para>Spherical—球面半变异函数模型。这是默认设置。</para>
		/// <para>Circular—圆半变异函数模型。</para>
		/// <para>Exponential—指数半变异函数模型。</para>
		/// <para>Gaussian—高斯（或正态分布）半变异函数模型。</para>
		/// <para>Linear—采用基台的线性半变异函数模型。</para>
		/// <para>泛克里金法可使用下列半变异函数模型：</para>
		/// <para>Linear with Linear drift—采用一次漂移函数的泛克里金法。</para>
		/// <para>Linear with Quadratic drift—采用二次漂移函数的泛克里金法。</para>
		/// <para>高级参数对话框中有一些选项可供使用。这些参数是：</para>
		/// <para>Lag size—默认值为输出栅格的像元大小。</para>
		/// <para>Major range—表示距离，超出此距离即认定为不相关。</para>
		/// <para>Partial sill—块金和基台之间的差值。</para>
		/// <para>Nugget—表示在因过小而无法检测到的空间尺度下的误差和变差。块金效应被视为在原点处的不连续。</para>
		/// </param>
		public Kriging(object InPointFeatures, object ZField, object OutSurfaceRaster, object SemivariogramProps)
		{
			this.InPointFeatures = InPointFeatures;
			this.ZField = ZField;
			this.OutSurfaceRaster = OutSurfaceRaster;
			this.SemivariogramProps = SemivariogramProps;
		}

		/// <summary>
		/// <para>Tool Display Name : 克里金法</para>
		/// </summary>
		public override string DisplayName() => "克里金法";

		/// <summary>
		/// <para>Tool Name : 克里金法</para>
		/// </summary>
		public override string ToolName() => "克里金法";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Kriging</para>
		/// </summary>
		public override string ExcuteName() => "3d.Kriging";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, ZField, OutSurfaceRaster, SemivariogramProps, CellSize!, SearchRadius!, OutVariancePredictionRaster! };

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
		/// <para>Output surface raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Semivariogram properties</para>
		/// <para>要使用的半变异函数模型。有两种克里金法：普通克里金法和泛克里金法。</para>
		/// <para>普通克里金法可使用下列半变异函数模型：</para>
		/// <para>Spherical—球面半变异函数模型。这是默认设置。</para>
		/// <para>Circular—圆半变异函数模型。</para>
		/// <para>Exponential—指数半变异函数模型。</para>
		/// <para>Gaussian—高斯（或正态分布）半变异函数模型。</para>
		/// <para>Linear—采用基台的线性半变异函数模型。</para>
		/// <para>泛克里金法可使用下列半变异函数模型：</para>
		/// <para>Linear with Linear drift—采用一次漂移函数的泛克里金法。</para>
		/// <para>Linear with Quadratic drift—采用二次漂移函数的泛克里金法。</para>
		/// <para>高级参数对话框中有一些选项可供使用。这些参数是：</para>
		/// <para>Lag size—默认值为输出栅格的像元大小。</para>
		/// <para>Major range—表示距离，超出此距离即认定为不相关。</para>
		/// <para>Partial sill—块金和基台之间的差值。</para>
		/// <para>Nugget—表示在因过小而无法检测到的空间尺度下的误差和变差。块金效应被视为在原点处的不连续。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSASemiVariogram()]
		public object SemivariogramProps { get; set; } = "Spherical # # # #";

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
		/// <para>Output variance of prediction raster</para>
		/// <para>可选的输出栅格，其中每个像元都包含该位置的预测方差值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutVariancePredictionRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Kriging SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
