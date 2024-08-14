using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Update Features With Incident Records</para>
	/// <para>Converts a nonspatial table to point features based on x,y-coordinates or  street addresses and updates an existing dataset with the new or updated record information from the table.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpdateFeaturesWithIncidentRecords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the x- and y-coordinates or addresses that define the locations of the records.</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>The point feature class or feature layer to be updated.</para>
		/// </param>
		/// <param name="LocationType">
		/// <para>Location Type</para>
		/// <para>Specifies whether features will be created using x,y-coordinates or addresses.</para>
		/// <para>Coordinates—Features will be created using the x,y-coordinates of the input record.</para>
		/// <para>Addresses—Features will be created using the address of the input record using a locator.</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </param>
		public UpdateFeaturesWithIncidentRecords(object InTable, object TargetFeatures, object LocationType)
		{
			this.InTable = InTable;
			this.TargetFeatures = TargetFeatures;
			this.LocationType = LocationType;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Features With Incident Records</para>
		/// </summary>
		public override string DisplayName => "Update Features With Incident Records";

		/// <summary>
		/// <para>Tool Name : UpdateFeaturesWithIncidentRecords</para>
		/// </summary>
		public override string ToolName => "UpdateFeaturesWithIncidentRecords";

		/// <summary>
		/// <para>Tool Excute Name : ca.UpdateFeaturesWithIncidentRecords</para>
		/// </summary>
		public override string ExcuteName => "ca.UpdateFeaturesWithIncidentRecords";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, TargetFeatures, LocationType, XField, YField, CoordinateSystem, AddressLocator, AddressType, AddressFields, InvalidRecordsTable, WhereClause, UpdateTarget, MatchFields, InDateField, TargetDateField, UpdateMatching, UpdateGeometry, FieldMatchingType, FieldMapping, TimeFormat, UpdatedTargetFeatures };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the x- and y-coordinates or addresses that define the locations of the records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>The point feature class or feature layer to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Location Type</para>
		/// <para>Specifies whether features will be created using x,y-coordinates or addresses.</para>
		/// <para>Coordinates—Features will be created using the x,y-coordinates of the input record.</para>
		/// <para>Addresses—Features will be created using the address of the input record using a locator.</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocationType { get; set; } = "COORDINATES";

		/// <summary>
		/// <para>X Field</para>
		/// <para>The field in the input table that contains the x-coordinates (or longitude).</para>
		/// <para>This parameter is only enabled when the Location Type parameter is set to Coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>The field in the input table that contains the y-coordinates (or latitude).</para>
		/// <para>This parameter is only enabled when the Location Type parameter is set to Coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object YField { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system of the x- and y-coordinates.</para>
		/// <para>This parameter is only enabled when the Location Type parameter is set to Coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object CoordinateSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]]";

		/// <summary>
		/// <para>Address Locator</para>
		/// <para>The address locator to use to geocode the table of addresses.</para>
		/// <para>When this parameter is set to use ArcGIS World Geocoding Service, this operation may consume credits.</para>
		/// <para>When using a local address locator, adding the .loc extension after the locator name at the end of the locator path is optional.</para>
		/// <para>This parameter is only enabled when the Location Type parameter is set to Addresses.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEAddressLocator()]
		public object AddressLocator { get; set; }

		/// <summary>
		/// <para>Address Type</para>
		/// <para>Specifies how address fields used by the address locator will be mapped to fields in the input table of addresses.</para>
		/// <para>Multiple Fields—Addresses are split into multiple fields.</para>
		/// <para>Single Field—Addresses are contained in one field.</para>
		/// <para>Select Single Field if the complete address is stored in one field in the input table, for example, 303 Peachtree St NE, Atlanta, GA 30308. Select Multiple Fields if the input addresses are split into multiple fields such as Address, City, State, and ZIP for a general United States address.</para>
		/// <para>This parameter is only enabled when the Location Type parameter is set to Addresses.</para>
		/// <para><see cref="AddressTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AddressType { get; set; } = "MULTI_FIELD_ADDRESS";

		/// <summary>
		/// <para>Address Fields</para>
		/// <para>The input table fields that correspond to the locator address fields of the address locator.</para>
		/// <para>Some locators support multiple input address fields, such as Address, Address2, and Address3. In this case, the address component can be separated into multiple fields, and the address fields will be concatenated at the time of geocoding. For example, 100, Main st, and Apt 140 across three fields, or 100 Main st and Apt 140 across two fields, both become 100 Main st Apt 140 when geocoding.</para>
		/// <para>If you choose not to map an optional input address field used by the address locator to a field in the input table of addresses, specify that there is no mapping by leaving the field name blank.</para>
		/// <para>This parameter is only active when the Location Type parameter is set to Addresses.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AddressFields { get; set; }

		/// <summary>
		/// <para>Invalid Records Table</para>
		/// <para>The output table containing a list of invalid records and associated invalidation codes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object InvalidRecordsTable { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>The SQL expression used to select a subset of the input datasets&apos; records. If multiple input datasets are specified, they will all be evaluated using the expression. If no records match the expression for an input dataset, no records from that dataset will be appended to the target.</para>
		/// <para>For more information about SQL syntax, see SQL reference for query expressions used in ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Update Existing Target Features</para>
		/// <para>Specifies whether existing records will be updated in the Target Features parameter.</para>
		/// <para>Checked—Records from the Input Table parameter will be updated in the Target Features parameter if they exist there.</para>
		/// <para>Unchecked—Records from the Input Table parameter will be appended to the Target Features parameter. This is the default.</para>
		/// <para><see cref="UpdateTargetEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateTarget { get; set; } = "false";

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>The ID field or fields that will be used to determine matches between the Input Table values and the Target Features values.</para>
		/// <para>This parameter is only enabled when the Update Existing Target Features parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Define Record Update Matching")]
		public object MatchFields { get; set; }

		/// <summary>
		/// <para>Input Table Last Modified Date Field</para>
		/// <para>The last modified date of the Input Features records.</para>
		/// <para>Date and string field types are supported.</para>
		/// <para>This parameter is only enabled when the Update Existing Target Features parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Define Record Update Matching")]
		public object InDateField { get; set; }

		/// <summary>
		/// <para>Target Features Last Modified Date Field</para>
		/// <para>The field containing the last modified date of the Target Features records.</para>
		/// <para>This field must be a date field type.</para>
		/// <para>This parameter is only enabled when the Update Existing Target Features parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Define Record Update Matching")]
		public object TargetDateField { get; set; }

		/// <summary>
		/// <para>Update Only Matching Features</para>
		/// <para>Specifies whether only existing records will be updated or existing records will be updated and new records will be added.</para>
		/// <para>Checked—Only existing records will be updated.</para>
		/// <para>Unchecked—Existing records will be updated and new records will be added. This is default.</para>
		/// <para>This parameter is only active when the Update Existing Target Features parameter is checked.</para>
		/// <para><see cref="UpdateMatchingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Define Record Update Matching")]
		public object UpdateMatching { get; set; } = "false";

		/// <summary>
		/// <para>Update Geometry for Existing Features</para>
		/// <para>Specifies whether the geometry of existing features will be updated.</para>
		/// <para>Checked—The geometry of existing records will be updated when the geometry information from the Input Table parameter is different than the geometry of the Target Features parameter. This is the default.</para>
		/// <para>Unchecked—The geometry of existing records will not be updated.</para>
		/// <para>This parameter is only enabled when the Update Existing Target Features parameter is checked.</para>
		/// <para><see cref="UpdateGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Define Record Update Matching")]
		public object UpdateGeometry { get; set; } = "true";

		/// <summary>
		/// <para>Field Matching Type</para>
		/// <para>Specifies whether the fields of the input table must match the fields of the target features for data to be appended.</para>
		/// <para>Input fields must match target fields—Fields from the input dataset match the fields of the target dataset. Fields that do not match will be ignored. This is the default</para>
		/// <para>Use the field map to reconcile field differences—Fields from the input dataset do not need to match the fields of the target dataset. Fields from the input dataset that do not match the fields of the target dataset will not be mapped to the target dataset unless the mapping is explicitly set in the Field Map parameter.</para>
		/// <para><see cref="FieldMatchingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Fields")]
		public object FieldMatchingType { get; set; } = "AUTOMATIC";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>Controls how the attribute fields from the input table will be transferred or mapped to the target features.</para>
		/// <para>This parameter is only active if the Field Matching Type parameter is set to Use the field map to reconcile field differences.</para>
		/// <para>Because the input table values are appended to an existing target feature that has predefined fields, you cannot add, remove, or change the type of the fields in the field map. You can, however, set merge rules for each output field.</para>
		/// <para>Merge rules allow you to specify how values from two or more input fields are merged or combined into a single output value. There are several merge rules you can use to determine how the output field will be populated with values.</para>
		/// <para>First—Use the input fields&apos; first value.</para>
		/// <para>Last—Use the input fields&apos; last value.</para>
		/// <para>Join—Concatenate (join) the input field values.</para>
		/// <para>Sum—Calculate the total of the input field values.</para>
		/// <para>Mean—Calculate the mean (average) of the input field values.</para>
		/// <para>Median—Calculate the median (middle) of the input field values.</para>
		/// <para>Mode—Use the value with the highest frequency.</para>
		/// <para>Min—Use the minimum value of all the input field values.</para>
		/// <para>Max—Use the maximum value of all the input field values.</para>
		/// <para>Standard deviation—Use the standard deviation classification method on all the input field values.</para>
		/// <para>Count—Find the number of records included in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		[Category("Fields")]
		public object FieldMapping { get; set; }

		/// <summary>
		/// <para>Time Format</para>
		/// <para>The format of the input field containing the time values. The type can be short, long, float, double, text, or date. You can either choose a standard time format from the drop-down list or enter a custom format.The format strings are case sensitive.</para>
		/// <para>If the data type of the time field is date, no time format is required.</para>
		/// <para>If the data type of the time field is numeric (Short, Long, Float, or Double), a list of standard numeric time formats is provided in the drop-down list.</para>
		/// <para>If the data type of the time field is string, a list of standard string time formats is provided in the drop-down list. For string fields, you can also choose to specify a custom time format. For example, the time values may have been stored in a string field in one of the standard formats such as yyyy/MM/dd HH:mm:ss or in a custom format such as dd/MM/yyyy HH:mm:ss. For the custom format, you can also specify the a.m., p.m. designator. Some commonly used formats are listed below:</para>
		/// <para>yyyy - Year represented by four digits.</para>
		/// <para>MM - Month as digits with leading zero for single-digit months.</para>
		/// <para>MMM - Month as a three-letter abbreviation.</para>
		/// <para>dd - Day of month as digits with leading zero for single-digit days.</para>
		/// <para>ddd - Day of week as a three-letter abbreviation.</para>
		/// <para>hh - Hours with leading zero for single-digit hours; 12-hour clock.</para>
		/// <para>HH - Hours with leading zero for single-digit hours; 24-hour clock.</para>
		/// <para>mm - Minutes with leading zero for single-digit minutes.</para>
		/// <para>ss - Seconds with leading zero for single-digit seconds.</para>
		/// <para>t - One character time marker string, such as A or P.</para>
		/// <para>tt - Multicharacter time marker string, such as AM or PM.</para>
		/// <para>unix_us - Unix time in microseconds.</para>
		/// <para>unix_ms - Unix time in milliseconds.</para>
		/// <para>unix_s - Unix time in seconds.</para>
		/// <para>unix_hex - Unix time in hexadecimal.</para>
		/// <para>This parameter is only active when the Input Table Last Modified Date parameter value is a text field and the Target Features Last Modified Date Field parameter value is a date field, or the Field Map parameter input value is a text field and the output value is a date field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Define Record Update Matching")]
		public object TimeFormat { get; set; }

		/// <summary>
		/// <para>Updated Target Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedTargetFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateFeaturesWithIncidentRecords SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location Type</para>
		/// </summary>
		public enum LocationTypeEnum 
		{
			/// <summary>
			/// <para>Coordinates—Features will be created using the x,y-coordinates of the input record.</para>
			/// </summary>
			[GPValue("COORDINATES")]
			[Description("Coordinates")]
			Coordinates,

			/// <summary>
			/// <para>Addresses—Features will be created using the address of the input record using a locator.</para>
			/// </summary>
			[GPValue("ADDRESSES")]
			[Description("Addresses")]
			Addresses,

		}

		/// <summary>
		/// <para>Address Type</para>
		/// </summary>
		public enum AddressTypeEnum 
		{
			/// <summary>
			/// <para>Single Field—Addresses are contained in one field.</para>
			/// </summary>
			[GPValue("SINGLE_FIELD_ADDRESS")]
			[Description("Single Field")]
			Single_Field,

			/// <summary>
			/// <para>Multiple Fields—Addresses are split into multiple fields.</para>
			/// </summary>
			[GPValue("MULTI_FIELD_ADDRESS")]
			[Description("Multiple Fields")]
			Multiple_Fields,

		}

		/// <summary>
		/// <para>Update Existing Target Features</para>
		/// </summary>
		public enum UpdateTargetEnum 
		{
			/// <summary>
			/// <para>Checked—Records from the Input Table parameter will be updated in the Target Features parameter if they exist there.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para>Unchecked—Records from the Input Table parameter will be appended to the Target Features parameter. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("APPEND")]
			APPEND,

		}

		/// <summary>
		/// <para>Update Only Matching Features</para>
		/// </summary>
		public enum UpdateMatchingEnum 
		{
			/// <summary>
			/// <para>Checked—Only existing records will be updated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_MATCHING_ONLY")]
			UPDATE_MATCHING_ONLY,

			/// <summary>
			/// <para>Unchecked—Existing records will be updated and new records will be added. This is default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("UPSERT")]
			UPSERT,

		}

		/// <summary>
		/// <para>Update Geometry for Existing Features</para>
		/// </summary>
		public enum UpdateGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—The geometry of existing records will be updated when the geometry information from the Input Table parameter is different than the geometry of the Target Features parameter. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_GEOMETRY")]
			UPDATE_GEOMETRY,

			/// <summary>
			/// <para>Unchecked—The geometry of existing records will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_GEOMETRY")]
			KEEP_GEOMETRY,

		}

		/// <summary>
		/// <para>Field Matching Type</para>
		/// </summary>
		public enum FieldMatchingTypeEnum 
		{
			/// <summary>
			/// <para>Input fields must match target fields—Fields from the input dataset match the fields of the target dataset. Fields that do not match will be ignored. This is the default</para>
			/// </summary>
			[GPValue("AUTOMATIC")]
			[Description("Input fields must match target fields")]
			Input_fields_must_match_target_fields,

			/// <summary>
			/// <para>Use the field map to reconcile field differences—Fields from the input dataset do not need to match the fields of the target dataset. Fields from the input dataset that do not match the fields of the target dataset will not be mapped to the target dataset unless the mapping is explicitly set in the Field Map parameter.</para>
			/// </summary>
			[GPValue("FIELD_MAP")]
			[Description("Use the field map to reconcile field differences")]
			Use_the_field_map_to_reconcile_field_differences,

		}

#endregion
	}
}
