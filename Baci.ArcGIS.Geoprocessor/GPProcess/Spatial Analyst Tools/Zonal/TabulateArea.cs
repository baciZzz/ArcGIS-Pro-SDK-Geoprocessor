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
	/// <para>Tabulate Area</para>
	/// <para>区域制表</para>
	/// <para>计算两个数据集之间交叉制表的区域并输出表。</para>
	/// </summary>
	public class TabulateArea : AbstractGPProcess
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
		/// <param name="InClassData">
		/// <para>Input raster or feature class data</para>
		/// <para>定义类的数据集将在各个区域内对类的面积进行汇总。</para>
		/// <para>类输入可以是整型栅格图层或要素图层。</para>
		/// </param>
		/// <param name="ClassField">
		/// <para>Class field</para>
		/// <para>用于保存类值的字段。</para>
		/// <para>该字段可以是输入类数据的整型或字符串型字段。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>将包含各区域中各个类面积的汇总的输出表。</para>
		/// <para>表的格式由输出位置和路径确定。 默认情况下，如果在地理数据库工作空间中，则输出将是一个地理数据库表；如果在文件工作空间中，则输出将为 dBASE 表。</para>
		/// </param>
		public TabulateArea(object InZoneData, object ZoneField, object InClassData, object ClassField, object OutTable)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.InClassData = InClassData;
			this.ClassField = ClassField;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 区域制表</para>
		/// </summary>
		public override string DisplayName() => "区域制表";

		/// <summary>
		/// <para>Tool Name : TabulateArea</para>
		/// </summary>
		public override string ToolName() => "TabulateArea";

		/// <summary>
		/// <para>Tool Excute Name : sa.TabulateArea</para>
		/// </summary>
		public override string ExcuteName() => "sa.TabulateArea";

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
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, InClassData, ClassField, OutTable, ProcessingCellSize!, ClassesAsRows! };

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
		/// <para>Input raster or feature class data</para>
		/// <para>定义类的数据集将在各个区域内对类的面积进行汇总。</para>
		/// <para>类输入可以是整型栅格图层或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Class field</para>
		/// <para>用于保存类值的字段。</para>
		/// <para>该字段可以是输入类数据的整型或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object ClassField { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>将包含各区域中各个类面积的汇总的输出表。</para>
		/// <para>表的格式由输出位置和路径确定。 默认情况下，如果在地理数据库工作空间中，则输出将是一个地理数据库表；如果在文件工作空间中，则输出将为 dBASE 表。</para>
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
		/// <para>Classes as rows in output table</para>
		/// <para>指定输入类栅格中的值在输出表中的表示方式。</para>
		/// <para>未选中 - 类将表示为字段。这是默认设置。</para>
		/// <para>选中 - 类将表示为行。</para>
		/// <para><see cref="ClassesAsRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClassesAsRows { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TabulateArea SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , bool? transferDomains = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Classes as rows in output table</para>
		/// </summary>
		public enum ClassesAsRowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CLASSES_AS_FIELDS")]
			CLASSES_AS_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSES_AS_ROWS")]
			CLASSES_AS_ROWS,

		}

#endregion
	}
}
