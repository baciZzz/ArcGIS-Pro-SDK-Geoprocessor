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
	/// <para>Euclidean Distance</para>
	/// <para>欧氏距离</para>
	/// <para>计算每个像元到最近源的欧氏距离。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation))]
	public class EucDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceData">
		/// <para>Input raster or feature source data</para>
		/// <para>输入源位置。</para>
		/// <para>此为栅格或要素数据集，用于标识计算每个输出像元位置的欧氏距离所依据的像元或位置。</para>
		/// <para>对于栅格，输入类型可以为整型或浮点型。</para>
		/// </param>
		/// <param name="OutDistanceRaster">
		/// <para>Output distance raster</para>
		/// <para>输出欧氏距离栅格。</para>
		/// <para>此距离栅格标识每个像元至最近源像元、源像元集或源位置的欧氏距离。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </param>
		public EucDistance(object InSourceData, object OutDistanceRaster)
		{
			this.InSourceData = InSourceData;
			this.OutDistanceRaster = OutDistanceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 欧氏距离</para>
		/// </summary>
		public override string DisplayName() => "欧氏距离";

		/// <summary>
		/// <para>Tool Name : EucDistance</para>
		/// </summary>
		public override string ToolName() => "EucDistance";

		/// <summary>
		/// <para>Tool Excute Name : sa.EucDistance</para>
		/// </summary>
		public override string ExcuteName() => "sa.EucDistance";

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
		public override object[] Parameters() => new object[] { InSourceData, OutDistanceRaster, MaximumDistance, CellSize, OutDirectionRaster, DistanceMethod, InBarrierData, OutBackDirectionRaster };

		/// <summary>
		/// <para>Input raster or feature source data</para>
		/// <para>输入源位置。</para>
		/// <para>此为栅格或要素数据集，用于标识计算每个输出像元位置的欧氏距离所依据的像元或位置。</para>
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
		/// <para>Output distance raster</para>
		/// <para>输出欧氏距离栅格。</para>
		/// <para>此距离栅格标识每个像元至最近源像元、源像元集或源位置的欧氏距离。</para>
		/// <para>输出栅格为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutDistanceRaster { get; set; }

		/// <summary>
		/// <para>Maximum distance</para>
		/// <para>累积距离值不能超过的阈值。</para>
		/// <para>如果累积的欧氏距离值超过该值，则像元位置的输出值为 NoData。</para>
		/// <para>默认距离是到输出栅格边的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaximumDistance { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Output direction raster</para>
		/// <para>输出欧氏方向栅格。</para>
		/// <para>此方向栅格包含计算的方向（以度为单位），每个像元中心都来自最近的源像元中心。</para>
		/// <para>值的范围是 0 度到 360 度，并为源像元保留 0 度。正东（右侧）是 90 度，且值以顺时针方向增加（180 是南方、270 是西方、360 是北方）。</para>
		/// <para>输出栅格为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutDirectionRaster { get; set; }

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
		/// <para>Input raster or feature barrier data</para>
		/// <para>定义障碍的数据集。</para>
		/// <para>可通过整型栅格、浮点型栅格或要素图层来定义障碍。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InBarrierData { get; set; }

		/// <summary>
		/// <para>Out back direction raster</para>
		/// <para>输出欧氏反向栅格。</para>
		/// <para>反向栅格中包含以度为单位的计算方向。该方向可用于识别沿最短路径返回最近源同时避开障碍的下一像元。</para>
		/// <para>值的范围是 0 度到 360 度，并为源像元保留 0 度。正东（右侧）是 90 度，且值以顺时针方向增加（180 是南方、270 是西方、360 是北方）。</para>
		/// <para>输出栅格为浮点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutBackDirectionRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EucDistance SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
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
