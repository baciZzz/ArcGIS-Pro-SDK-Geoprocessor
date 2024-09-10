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
	/// <para>Calculates the geometry measures (area, perimeter, thickness, and the characteristics of ellipse) for each zone in a dataset and reports the results as a table.</para>
	/// </summary>
	public class ZonalGeometryAsTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneData">
		/// <para>Input raster or feature zone data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </param>
		/// <param name="ZoneField">
		/// <para>Zone field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It must be an integer field of the zone dataset.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>Output table that will contain the summary of the values in each zone.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table. If the path is not in a geodatabase, the format is determined by the extension. If the extension is .dbf, it will be in dBASE format. If no extension is specified, the output will be an INFO table. Note that INFO tables are not supported as input in ArcGIS Pro and cannot be displayed.</para>
		/// </param>
		public ZonalGeometryAsTable(object InZoneData, object ZoneField, object OutTable)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Zonal Geometry as Table</para>
		/// </summary>
		public override string DisplayName() => "Zonal Geometry as Table";

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
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, OutTable, ProcessingCellSize };

		/// <summary>
		/// <para>Input raster or feature zone data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
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
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It must be an integer field of the zone dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long")]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>Output table that will contain the summary of the values in each zone.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table. If the path is not in a geodatabase, the format is determined by the extension. If the extension is .dbf, it will be in dBASE format. If no extension is specified, the output will be an INFO table. Note that INFO tables are not supported as input in ArcGIS Pro and cannot be displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Processing cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object ProcessingCellSize { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalGeometryAsTable SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , bool? transferDomains = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
