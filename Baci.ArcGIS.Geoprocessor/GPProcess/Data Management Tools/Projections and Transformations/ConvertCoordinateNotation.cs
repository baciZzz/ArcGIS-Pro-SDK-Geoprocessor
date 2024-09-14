using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Convert Coordinate Notation</para>
	/// <para>Convert Coordinate Notation</para>
	/// <para>Converts coordinate notations contained in one or two fields from one notation format to another.</para>
	/// </summary>
	public class ConvertCoordinateNotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table or text file. Point features are also valid.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class. The attribute table will contain all fields of the input table along with the fields containing converted values in the output format.</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field (Longitude)</para>
		/// <para>A field from the input table containing the longitude value.</para>
		/// <para>For the Input Coordinate Format parameter&apos;s DD 2, DD numeric, DDM 2, and DMS 2 options, this is the longitude field.</para>
		/// <para>For the DD 1, DDM 1, and DMS 1 options, this field contains both latitude and longitude values in a single string.</para>
		/// <para>For the Gars, Georef, Georef 16, UTM zones, UTM bands, USNG, USNG 16, MGRS, and MGRS 16 options, this field contains an alphanumeric notation in a single text field.</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field (Latitude)</para>
		/// <para>A field from the input table containing the latitude value.</para>
		/// <para>For the Input Coordinate Format parameter&apos;s DD 2, DD numeric, DDM 2, and DMS 2 options, this is the latitude field.</para>
		/// <para>This parameter is inactive when one of the single-string formats is chosen.</para>
		/// </param>
		/// <param name="InputCoordinateFormat">
		/// <para>Input Coordinate Format</para>
		/// <para>Specifies the coordinate format of the input fields.</para>
		/// <para>DD 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DD 2—Longitude and latitude values are in two separate fields.This is the default.</para>
		/// <para>DDM 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DDM 2— Longitude and latitude values are in two separate fields.</para>
		/// <para>DMS 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DMS 2—Longitude and latitude values are in two separate fields.</para>
		/// <para>Gars—Global Area Reference System. Based on latitude and longitude, it divides and subdivides the world into cells.</para>
		/// <para>Georef—World Geographic Reference System. A grid-based system that divides the world into 15-degree quadrangles and then subdivides into smaller quadrangles.</para>
		/// <para>Georef 16—World Geographic Reference System in 16-digit precision.</para>
		/// <para>UTM zones—The letter N or S after the UTM zone number designates only North or South hemisphere.</para>
		/// <para>UTM bands—The letter after the UTM zone number designates one of the 20 latitude bands. N or S does not designate a hemisphere.</para>
		/// <para>USNG—United States National Grid. Almost exactly the same as MGRS but uses North American Datum 1983 (NAD83) as its datum.</para>
		/// <para>USNG 16—United States National Grid in 16-digit higher precision.</para>
		/// <para>MGRS—Military Grid Reference System. Follows the UTM coordinates and divides the world into 6-degree longitude and 20 latitude bands, but MGRS then further subdivides the grid zones into smaller 100,000-meter grids. These 100,000-meter grids are then divided into 10,000-meter, 1,000-meter, 100-meter, 10-meter, and 1-meter grids.</para>
		/// <para>MGRS 16—Military Grid Reference System in 16-digit precision.</para>
		/// <para>Shape—Only available when a point feature layer is selected as input. The coordinates of each point are used to define the output format.</para>
		/// <para>DD, DDM, DMS, and UTM are also valid keywords; they can be used just by typing in (on dialog) or passing the value in scripting. However, keywords with underscore and a qualifier tell more about the field values.</para>
		/// </param>
		/// <param name="OutputCoordinateFormat">
		/// <para>Output Coordinate Format</para>
		/// <para>Specifies the coordinate format to which the input notations will be converted.</para>
		/// <para>DD 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DD 2—Longitude and latitude values are in two separate fields.</para>
		/// <para>DD numeric—Longitude and latitude values are in two separate fields of type Double. Values in the West and South are denoted by a minus sign.</para>
		/// <para>DDM 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DDM 2— Longitude and latitude values are in two separate fields.</para>
		/// <para>DMS 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DMS 2—Longitude and latitude values are in two separate fields.</para>
		/// <para>Gars—Global Area Reference System. Based on latitude and longitude, it divides and subdivides the world into cells.</para>
		/// <para>Georef—World Geographic Reference System. A grid-based system that divides the world into 15-degree quadrangles and then subdivides into smaller quadrangles.</para>
		/// <para>Georef 16—World Geographic Reference System in 16-digit precision.</para>
		/// <para>UTM zones—The letter N or S after the UTM zone number designates only North or South hemisphere.</para>
		/// <para>UTM bands—The letter after the UTM zone number designates one of the 20 latitude bands. N or S does not designate a hemisphere.</para>
		/// <para>USNG—United States National Grid. Almost exactly the same as MGRS but uses North American Datum 1983 (NAD83) as its datum.</para>
		/// <para>USNG 16—United States National Grid in 16-digit higher precision.</para>
		/// <para>MGRS—Military Grid Reference System. Follows the UTM coordinates and divides the world into 6-degree longitude and 20 latitude bands, but MGRS then further subdivides the grid zones into smaller 100,000-meter grids. These 100,000-meter grids are then divided into 10,000-meter, 1,000-meter, 100-meter, 10-meter, and 1-meter grids.</para>
		/// <para>MGRS 16—Military Grid Reference System in 16-digit precision.</para>
		/// <para>DD, DDM, DMS, and UTM are also valid keywords; they can be used just by typing in (on dialog) or passing the value in scripting. However, keywords with underscore and a qualifier tell more about the field values.</para>
		/// </param>
		public ConvertCoordinateNotation(object InTable, object OutFeatureclass, object XField, object YField, object InputCoordinateFormat, object OutputCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.XField = XField;
			this.YField = YField;
			this.InputCoordinateFormat = InputCoordinateFormat;
			this.OutputCoordinateFormat = OutputCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Coordinate Notation</para>
		/// </summary>
		public override string DisplayName() => "Convert Coordinate Notation";

		/// <summary>
		/// <para>Tool Name : ConvertCoordinateNotation</para>
		/// </summary>
		public override string ToolName() => "ConvertCoordinateNotation";

		/// <summary>
		/// <para>Tool Excute Name : management.ConvertCoordinateNotation</para>
		/// </summary>
		public override string ExcuteName() => "management.ConvertCoordinateNotation";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYTolerance", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutFeatureclass, XField, YField, InputCoordinateFormat, OutputCoordinateFormat, IdField!, SpatialReference!, InCoorSystem!, ExcludeInvalidRecords! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table or text file. Point features are also valid.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class. The attribute table will contain all fields of the input table along with the fields containing converted values in the output format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>X Field (Longitude)</para>
		/// <para>A field from the input table containing the longitude value.</para>
		/// <para>For the Input Coordinate Format parameter&apos;s DD 2, DD numeric, DDM 2, and DMS 2 options, this is the longitude field.</para>
		/// <para>For the DD 1, DDM 1, and DMS 1 options, this field contains both latitude and longitude values in a single string.</para>
		/// <para>For the Gars, Georef, Georef 16, UTM zones, UTM bands, USNG, USNG 16, MGRS, and MGRS 16 options, this field contains an alphanumeric notation in a single text field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field (Latitude)</para>
		/// <para>A field from the input table containing the latitude value.</para>
		/// <para>For the Input Coordinate Format parameter&apos;s DD 2, DD numeric, DDM 2, and DMS 2 options, this is the latitude field.</para>
		/// <para>This parameter is inactive when one of the single-string formats is chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object YField { get; set; }

		/// <summary>
		/// <para>Input Coordinate Format</para>
		/// <para>Specifies the coordinate format of the input fields.</para>
		/// <para>DD 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DD 2—Longitude and latitude values are in two separate fields.This is the default.</para>
		/// <para>DDM 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DDM 2— Longitude and latitude values are in two separate fields.</para>
		/// <para>DMS 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DMS 2—Longitude and latitude values are in two separate fields.</para>
		/// <para>Gars—Global Area Reference System. Based on latitude and longitude, it divides and subdivides the world into cells.</para>
		/// <para>Georef—World Geographic Reference System. A grid-based system that divides the world into 15-degree quadrangles and then subdivides into smaller quadrangles.</para>
		/// <para>Georef 16—World Geographic Reference System in 16-digit precision.</para>
		/// <para>UTM zones—The letter N or S after the UTM zone number designates only North or South hemisphere.</para>
		/// <para>UTM bands—The letter after the UTM zone number designates one of the 20 latitude bands. N or S does not designate a hemisphere.</para>
		/// <para>USNG—United States National Grid. Almost exactly the same as MGRS but uses North American Datum 1983 (NAD83) as its datum.</para>
		/// <para>USNG 16—United States National Grid in 16-digit higher precision.</para>
		/// <para>MGRS—Military Grid Reference System. Follows the UTM coordinates and divides the world into 6-degree longitude and 20 latitude bands, but MGRS then further subdivides the grid zones into smaller 100,000-meter grids. These 100,000-meter grids are then divided into 10,000-meter, 1,000-meter, 100-meter, 10-meter, and 1-meter grids.</para>
		/// <para>MGRS 16—Military Grid Reference System in 16-digit precision.</para>
		/// <para>Shape—Only available when a point feature layer is selected as input. The coordinates of each point are used to define the output format.</para>
		/// <para>DD, DDM, DMS, and UTM are also valid keywords; they can be used just by typing in (on dialog) or passing the value in scripting. However, keywords with underscore and a qualifier tell more about the field values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputCoordinateFormat { get; set; } = "DD_2";

		/// <summary>
		/// <para>Output Coordinate Format</para>
		/// <para>Specifies the coordinate format to which the input notations will be converted.</para>
		/// <para>DD 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DD 2—Longitude and latitude values are in two separate fields.</para>
		/// <para>DD numeric—Longitude and latitude values are in two separate fields of type Double. Values in the West and South are denoted by a minus sign.</para>
		/// <para>DDM 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DDM 2— Longitude and latitude values are in two separate fields.</para>
		/// <para>DMS 1—Both longitude and latitude values are in a single field. Two values are separated by a space, a comma, or a slash.</para>
		/// <para>DMS 2—Longitude and latitude values are in two separate fields.</para>
		/// <para>Gars—Global Area Reference System. Based on latitude and longitude, it divides and subdivides the world into cells.</para>
		/// <para>Georef—World Geographic Reference System. A grid-based system that divides the world into 15-degree quadrangles and then subdivides into smaller quadrangles.</para>
		/// <para>Georef 16—World Geographic Reference System in 16-digit precision.</para>
		/// <para>UTM zones—The letter N or S after the UTM zone number designates only North or South hemisphere.</para>
		/// <para>UTM bands—The letter after the UTM zone number designates one of the 20 latitude bands. N or S does not designate a hemisphere.</para>
		/// <para>USNG—United States National Grid. Almost exactly the same as MGRS but uses North American Datum 1983 (NAD83) as its datum.</para>
		/// <para>USNG 16—United States National Grid in 16-digit higher precision.</para>
		/// <para>MGRS—Military Grid Reference System. Follows the UTM coordinates and divides the world into 6-degree longitude and 20 latitude bands, but MGRS then further subdivides the grid zones into smaller 100,000-meter grids. These 100,000-meter grids are then divided into 10,000-meter, 1,000-meter, 100-meter, 10-meter, and 1-meter grids.</para>
		/// <para>MGRS 16—Military Grid Reference System in 16-digit precision.</para>
		/// <para>DD, DDM, DMS, and UTM are also valid keywords; they can be used just by typing in (on dialog) or passing the value in scripting. However, keywords with underscore and a qualifier tell more about the field values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputCoordinateFormat { get; set; } = "DD_2";

		/// <summary>
		/// <para>ID</para>
		/// <para>This parameter is no longer used as all fields are transferred to output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object? IdField { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The spatial reference of the output feature class. The default is GCS_WGS_1984.</para>
		/// <para>The tool projects the output to the spatial reference specified. If the input and output coordinate systems are in a different datum, a default transformation will be used based on the coordinate systems of the input and the output and the extent of the data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>The spatial reference of the input data. If the input spatial reference cannot be obtained from the input table, a default of GCS_WGS_1984 will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InCoorSystem { get; set; }

		/// <summary>
		/// <para>Exclude records with invalid notation</para>
		/// <para>Specifies whether records with invalid notation will be excluded.</para>
		/// <para>Unchecked—Invalid records will be excluded, and only valid records will be converted to points in the output. This is the default.</para>
		/// <para>Checked—Valid records will be converted to points in the output and invalid records will be included as null geometry.</para>
		/// <para><see cref="ExcludeInvalidRecordsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExcludeInvalidRecords { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertCoordinateNotation SetEnviroment(object? XYTolerance = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(XYTolerance: XYTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Exclude records with invalid notation</para>
		/// </summary>
		public enum ExcludeInvalidRecordsEnum 
		{
			/// <summary>
			/// <para>Checked—Valid records will be converted to points in the output and invalid records will be included as null geometry.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE_INVALID")]
			EXCLUDE_INVALID,

			/// <summary>
			/// <para>Unchecked—Invalid records will be excluded, and only valid records will be converted to points in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE_INVALID")]
			INCLUDE_INVALID,

		}

#endregion
	}
}
