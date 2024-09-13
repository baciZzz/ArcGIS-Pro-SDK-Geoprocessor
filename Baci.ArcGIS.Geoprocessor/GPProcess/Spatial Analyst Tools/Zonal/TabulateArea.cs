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
	/// <para>Tabulate Area</para>
	/// <para>Calculates cross-tabulated areas between two datasets and outputs a table.</para>
	/// </summary>
	public class TabulateArea : AbstractGPProcess
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
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </param>
		/// <param name="InClassData">
		/// <para>Input raster or feature class data</para>
		/// <para>The dataset that defines the classes that will have their area summarized within each zone.</para>
		/// <para>The class input can be an integer raster layer or a feature layer.</para>
		/// </param>
		/// <param name="ClassField">
		/// <para>Class field</para>
		/// <para>The field that holds the class values.</para>
		/// <para>It can be an integer or a string field of the input class data.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>The output table that will contain the summary of the area of each class in each zone.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table if in a geodatabase workspace, and a dBASE table if in a file workspace.</para>
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
		/// <para>Tool Display Name : Tabulate Area</para>
		/// </summary>
		public override string DisplayName() => "Tabulate Area";

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
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Input raster or feature class data</para>
		/// <para>The dataset that defines the classes that will have their area summarized within each zone.</para>
		/// <para>The class input can be an integer raster layer or a feature layer.</para>
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
		/// <para>The field that holds the class values.</para>
		/// <para>It can be an integer or a string field of the input class data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object ClassField { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>The output table that will contain the summary of the area of each class in each zone.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table if in a geodatabase workspace, and a dBASE table if in a file workspace.</para>
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
		public object? ProcessingCellSize { get; set; }

		/// <summary>
		/// <para>Classes as rows in output table</para>
		/// <para>Specifies how the values from the input class raster will be represented in the output table.</para>
		/// <para>Unchecked—Classes will be represented as fields. This is the default.</para>
		/// <para>Checked—Classes will be represented as rows.</para>
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
			/// <para>Unchecked—Classes will be represented as fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CLASSES_AS_FIELDS")]
			CLASSES_AS_FIELDS,

			/// <summary>
			/// <para>Checked—Classes will be represented as rows.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSES_AS_ROWS")]
			CLASSES_AS_ROWS,

		}

#endregion
	}
}
