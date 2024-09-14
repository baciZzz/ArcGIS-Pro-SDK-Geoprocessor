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
	/// <para>Zonal Geometry</para>
	/// <para>分区几何统计</para>
	/// <para>为数据集中的各个区域计算指定的几何测量值（面积、周长、厚度或者椭圆的特征值）。</para>
	/// </summary>
	public class ZonalGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneData">
		/// <para>Input raster or feature zone data</para>
		/// <para>定义区域的数据集。</para>
		/// <para>可通过整型栅格或要素图层来定义区域。</para>
		/// </param>
		/// <param name="ZoneField">
		/// <para>Zone field</para>
		/// <para>包含定义每个区域的值的字段。</para>
		/// <para>必须是区域数据集的整型字段。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出分区几何栅格。</para>
		/// </param>
		public ZonalGeometry(object InZoneData, object ZoneField, object OutRaster)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 分区几何统计</para>
		/// </summary>
		public override string DisplayName() => "分区几何统计";

		/// <summary>
		/// <para>Tool Name : ZonalGeometry</para>
		/// </summary>
		public override string ToolName() => "ZonalGeometry";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalGeometry</para>
		/// </summary>
		public override string ExcuteName() => "sa.ZonalGeometry";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, OutRaster, GeometryType!, CellSize! };

		/// <summary>
		/// <para>Input raster or feature zone data</para>
		/// <para>定义区域的数据集。</para>
		/// <para>可通过整型栅格或要素图层来定义区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InZoneData { get; set; }

		/// <summary>
		/// <para>Zone field</para>
		/// <para>包含定义每个区域的值的字段。</para>
		/// <para>必须是区域数据集的整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long")]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出分区几何栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Geometry type</para>
		/// <para>要计算的几何类型。</para>
		/// <para>面积—各个区域的面积。</para>
		/// <para>周长—各个区域的周长。</para>
		/// <para>厚度—区域中最深（或最厚）的点距其周围像元的距离。</para>
		/// <para>质心—定位各个区域的质心。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "AREA";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalGeometry SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>面积—各个区域的面积。</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("面积")]
			Area,

			/// <summary>
			/// <para>周长—各个区域的周长。</para>
			/// </summary>
			[GPValue("PERIMETER")]
			[Description("周长")]
			Perimeter,

			/// <summary>
			/// <para>厚度—区域中最深（或最厚）的点距其周围像元的距离。</para>
			/// </summary>
			[GPValue("THICKNESS")]
			[Description("厚度")]
			Thickness,

			/// <summary>
			/// <para>质心—定位各个区域的质心。</para>
			/// </summary>
			[GPValue("CENTROID")]
			[Description("质心")]
			Centroid,

		}

#endregion
	}
}
