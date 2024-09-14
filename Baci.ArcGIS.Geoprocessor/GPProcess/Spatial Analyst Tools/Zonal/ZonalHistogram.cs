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
	/// <para>Zonal Histogram</para>
	/// <para>区域直方图</para>
	/// <para>创建显示各唯一区域值输入中的像元值频数分布的表和直方图。</para>
	/// </summary>
	public class ZonalHistogram : AbstractGPProcess
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
		/// <para>该字段可以是区域数据集的整型字段或字符串型字段。</para>
		/// </param>
		/// <param name="InValueRaster">
		/// <para>Input value raster</para>
		/// <para>包含用于创建直方图的值的栅格。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>输出表文件。</para>
		/// <para>表的格式由输出位置和路径确定。默认情况下，如果在地理数据库工作空间中，则输出将是一个地理数据库表；如果在文件工作空间中，则输出将为 dBASE 表。</para>
		/// <para>根据表中的信息创建可选图形输出。</para>
		/// </param>
		public ZonalHistogram(object InZoneData, object ZoneField, object InValueRaster, object OutTable)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.InValueRaster = InValueRaster;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 区域直方图</para>
		/// </summary>
		public override string DisplayName() => "区域直方图";

		/// <summary>
		/// <para>Tool Name : ZonalHistogram</para>
		/// </summary>
		public override string ToolName() => "ZonalHistogram";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalHistogram</para>
		/// </summary>
		public override string ExcuteName() => "sa.ZonalHistogram";

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
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, InValueRaster, OutTable, OutGraph, ZonesAsRows };

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
		/// <para>该字段可以是区域数据集的整型字段或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Input value raster</para>
		/// <para>包含用于创建直方图的值的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InValueRaster { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>输出表文件。</para>
		/// <para>表的格式由输出位置和路径确定。默认情况下，如果在地理数据库工作空间中，则输出将是一个地理数据库表；如果在文件工作空间中，则输出将为 dBASE 表。</para>
		/// <para>根据表中的信息创建可选图形输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output graph name</para>
		/// <para>用于显示的输出图形的名称。</para>
		/// <para>将在独立表下的内容窗格中列出该图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutGraph { get; set; }

		/// <summary>
		/// <para>Zones as rows in output table</para>
		/// <para>指定输入值栅格中的值在输出表中的表示方式。</para>
		/// <para>未选中 - 区域将表示为字段。这是默认设置。</para>
		/// <para>选中 - 区域将表示为行。</para>
		/// <para><see cref="ZonesAsRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ZonesAsRows { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalHistogram SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, bool? transferDomains = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Zones as rows in output table</para>
		/// </summary>
		public enum ZonesAsRowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ZONES_AS_FIELDS")]
			ZONES_AS_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ZONES_AS_ROWS")]
			ZONES_AS_ROWS,

		}

#endregion
	}
}
