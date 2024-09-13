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
	/// <para>Zonal Geometry as Table</para>
	/// <para>以表格显示分区几何统计</para>
	/// <para>为数据集中的各个区域计算几何测量值（面积、周长、厚度和椭圆的特征值），并以表的形式来显示结果。</para>
	/// </summary>
	public class ZonalGeometryAsTable : AbstractGPProcess
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
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>将包含每个区域中值的汇总的输出表。</para>
		/// <para>表的格式由输出位置和路径确定。 默认情况下，输出为一张地理数据库表。 如果路径不在地理数据库中，则格式将由表达式确定。 如果扩展名为 .dbf，则将采用 dBASE 格式。 如果未指定扩展名，则输出将为 INFO 表。 不支持将 INFO 表作为 ArcGIS Pro 中的输入且无法显示 INFO 表。</para>
		/// </param>
		public ZonalGeometryAsTable(object InZoneData, object ZoneField, object OutTable)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 以表格显示分区几何统计</para>
		/// </summary>
		public override string DisplayName() => "以表格显示分区几何统计";

		/// <summary>
		/// <para>Tool Name : ZonalGeometryAsTable</para>
		/// </summary>
		public override string ToolName() => "ZonalGeometryAsTable";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalGeometryAsTable</para>
		/// </summary>
		public override string ExcuteName() => "sa.ZonalGeometryAsTable";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "qualifiedFieldNames", "scratchWorkspace", "snapRaster", "tileSize", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, OutTable, ProcessingCellSize! };

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
		/// <para>Output table</para>
		/// <para>将包含每个区域中值的汇总的输出表。</para>
		/// <para>表的格式由输出位置和路径确定。 默认情况下，输出为一张地理数据库表。 如果路径不在地理数据库中，则格式将由表达式确定。 如果扩展名为 .dbf，则将采用 dBASE 格式。 如果未指定扩展名，则输出将为 INFO 表。 不支持将 INFO 表作为 ArcGIS Pro 中的输入且无法显示 INFO 表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Processing cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。 如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。 有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? ProcessingCellSize { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalGeometryAsTable SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , bool? transferDomains = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
