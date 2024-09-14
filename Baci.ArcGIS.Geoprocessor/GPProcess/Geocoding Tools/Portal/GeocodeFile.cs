using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeocodingTools
{
	/// <summary>
	/// <para>Geocode File</para>
	/// <para>Geocode File</para>
	/// <para>Converts large local tables of addresses or places into points in a feature class or as a stand-alone .csv or .xls table. This tool uses locators hosted on an ArcGIS Enterprise portal.</para>
	/// </summary>
	public class GeocodeFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table that contains addresses or places to geocode in CSV, XLS, or XLSX format or in a file geodatabase table.</para>
		/// </param>
		/// <param name="Locator">
		/// <para>Locator</para>
		/// <para>The portal locator that will be used to geocode the table.</para>
		/// <para>You can select a locator from the populated list of locators on the active portal or browse the active portal for other available locators. Locators that have been set as utility services on the active portal will be available by default.</para>
		/// <para>The ArcGIS World Geocoding Service is disabled for this tool. Use the Geocode Addresses tool if you want to use the ArcGIS World Geocoding Service.</para>
		/// </param>
		/// <param name="AddressFields">
		/// <para>Address Field Mapping</para>
		/// <para>The address fields used by the locator are mapped to fields in the input table of addresses. Select Single Field if the complete address is stored in one field in the input table, for example, 303 Peachtree St NE, Atlanta, GA 30308. Select Multiple Fields if the input addresses are divided into multiple fields such as Address, City, State, and ZIP for a general United States address. Select Single Field and Country Field if the complete address, for example, 303 Peachtree St NE, Atlanta, GA 30308, and the country, for example, USA, are divided into separate fields such as Address and Country.</para>
		/// <para>Some locators support multiple input addresses fields such as Address, Address2, and Address3. In this case, the address component can be separated into multiple fields and the address fields will be concatenated at the time of geocoding. For example, 100, Main st, and Apt 140 across three fields, or 100 Main st and Apt 140 across two fields, both become 100 Main st Apt 140 when geocoding.</para>
		/// <para>If you do not map an optional input address field used by the locator to a field in the input table of addresses, specify that there is no mapping using &lt;None&gt; in place of a field name.</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>Specifies the file type to which the geocode results will be written.</para>
		/// <para>CSV—A .csv file will be returned.</para>
		/// <para>Feature class—A feature class in a file geodatabase will be returned.</para>
		/// <para>XLS—An .xls file will be returned.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>The folder where the output geocoding results will be written.</para>
		/// <para>If the output is a .csv or .xls file, an output file will be placed in the specified folder.</para>
		/// <para>If the output is a feature class, an output file geodatabase will be created and placed in the specified folder, and the new file geodatabase will contain the geocoded feature class. The output file geodatabase and feature class in the file geodatabase will have the same name.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output geocoded results.</para>
		/// </param>
		public GeocodeFile(object InTable, object Locator, object AddressFields, object OutputType, object OutputLocation, object OutputName)
		{
			this.InTable = InTable;
			this.Locator = Locator;
			this.AddressFields = AddressFields;
			this.OutputType = OutputType;
			this.OutputLocation = OutputLocation;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : Geocode File</para>
		/// </summary>
		public override string DisplayName() => "Geocode File";

		/// <summary>
		/// <para>Tool Name : GeocodeFile</para>
		/// </summary>
		public override string ToolName() => "GeocodeFile";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.GeocodeFile</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.GeocodeFile";

		/// <summary>
		/// <para>Toolbox Display Name : Geocoding Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geocoding Tools";

		/// <summary>
		/// <para>Toolbox Alise : geocoding</para>
		/// </summary>
		public override string ToolboxAlise() => "geocoding";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Locator, AddressFields, OutputType, OutputLocation, OutputName, Country!, LocationType!, Category!, OutFeatureClass!, OutTable!, OutputFields! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table that contains addresses or places to geocode in CSV, XLS, or XLSX format or in a file geodatabase table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_tables_geocode_file")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Locator</para>
		/// <para>The portal locator that will be used to geocode the table.</para>
		/// <para>You can select a locator from the populated list of locators on the active portal or browse the active portal for other available locators. Locators that have been set as utility services on the active portal will be available by default.</para>
		/// <para>The ArcGIS World Geocoding Service is disabled for this tool. Use the Geocode Addresses tool if you want to use the ArcGIS World Geocoding Service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object Locator { get; set; }

		/// <summary>
		/// <para>Address Field Mapping</para>
		/// <para>The address fields used by the locator are mapped to fields in the input table of addresses. Select Single Field if the complete address is stored in one field in the input table, for example, 303 Peachtree St NE, Atlanta, GA 30308. Select Multiple Fields if the input addresses are divided into multiple fields such as Address, City, State, and ZIP for a general United States address. Select Single Field and Country Field if the complete address, for example, 303 Peachtree St NE, Atlanta, GA 30308, and the country, for example, USA, are divided into separate fields such as Address and Country.</para>
		/// <para>Some locators support multiple input addresses fields such as Address, Address2, and Address3. In this case, the address component can be separated into multiple fields and the address fields will be concatenated at the time of geocoding. For example, 100, Main st, and Apt 140 across three fields, or 100 Main st and Apt 140 across two fields, both become 100 Main st Apt 140 when geocoding.</para>
		/// <para>If you do not map an optional input address field used by the locator to a field in the input table of addresses, specify that there is no mapping using &lt;None&gt; in place of a field name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldInfo()]
		public object AddressFields { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies the file type to which the geocode results will be written.</para>
		/// <para>CSV—A .csv file will be returned.</para>
		/// <para>Feature class—A feature class in a file geodatabase will be returned.</para>
		/// <para>XLS—An .xls file will be returned.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder where the output geocoding results will be written.</para>
		/// <para>If the output is a .csv or .xls file, an output file will be placed in the specified folder.</para>
		/// <para>If the output is a feature class, an output file geodatabase will be created and placed in the specified folder, and the new file geodatabase will contain the geocoded feature class. The output file geodatabase and feature class in the file geodatabase will have the same name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System")]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output geocoded results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Country</para>
		/// <para>This parameter is available for locators that support a country parameter and will limit geocoding to the selected countries. Making a country selection will improve the accuracy of geocoding in most cases. When you select Single Field and Country Field in Address Field Mapping and map a field representing countries in Input Table to the Country field in Address Field Mapping, the country value from Input Table will override the Country parameter.</para>
		/// <para>This is limited to the selected country or countries. If no country is specified, geocoding is performed using all supported countries of the locator.</para>
		/// <para>The Country parameter is not supported for all locators.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Country { get; set; }

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// <para>Specifies the preferred output geometry for PointAddress matches. The options for this parameter are Routing location, which is the side of street location that can be used for routing and Address location, which is the location that represents the rooftop or parcel centroid for the address. If the preferred location does not exist in the data, the default location will be returned instead. For geocode results with Addr_type=PointAddress, the x,y attribute values describe the coordinates of the address along the street, while the DisplayX and DisplayY values describe the rooftop or building centroid coordinates.</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// <para>Address location—Geometry for geocode results that represent an address location—such as a rooftop location, parcel centroid, or front door—will be returned.</para>
		/// <para>Routing location—Geometry for geocode results that represent a location close to the side of the street that can be used for vehicle routing will be returned. This is the default.</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocationType { get; set; } = "ROUTING_LOCATION";

		/// <summary>
		/// <para>Category</para>
		/// <para>Limits the types of places the locator searches, eliminating false positive matches and potentially speeding up the search process. When no category is used, geocoding is performed on all supported categories. Not all category values are supported for all locations and countries. In general, the Category parameter can be used for the following:</para>
		/// <para>Limit matches to specific place types or address levels</para>
		/// <para>Avoid fallback matches to unwanted address levels</para>
		/// <para>Disambiguate coordinate searches</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Category { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>Specifies which locator output fields will be returned in the geocode results.</para>
		/// <para>This parameter can be used with input locators created with the Create Locator tool or Create Feature Locator tool published to Enterprise 10.9 or later. Composite locators that contain at least one locator created with the Create Address Locator tool do not support this parameter.</para>
		/// <para>All— Includes all available locator output fields in the geocode results. This is the default.</para>
		/// <para>Location Only—The Shape field is stored if the geocode result is a feature class. The Shape X and Shape Y fields are stored if the result is either a .csv or .xls file. The original field names from the Input Table parameter are maintained with their original field names.</para>
		/// <para>Minimal—Adds the following fields that describe the location and how well it matches information in the locator in the geocode results: Shape, Status, Score, Match_type, Match_addr, and Addr_type. The original field names from the Input Table parameter are maintained.</para>
		/// <para><see cref="OutputFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Optional parameters")]
		public object? OutputFields { get; set; } = "ALL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeocodeFile SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>CSV—A .csv file will be returned.</para>
			/// </summary>
			[GPValue("CSV")]
			[Description("CSV")]
			CSV,

			/// <summary>
			/// <para>Feature class—A feature class in a file geodatabase will be returned.</para>
			/// </summary>
			[GPValue("FEATURE_CLASS")]
			[Description("Feature class")]
			Feature_class,

			/// <summary>
			/// <para>XLS—An .xls file will be returned.</para>
			/// </summary>
			[GPValue("XLS")]
			[Description("XLS")]
			XLS,

		}

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// </summary>
		public enum LocationTypeEnum 
		{
			/// <summary>
			/// <para>Routing location—Geometry for geocode results that represent a location close to the side of the street that can be used for vehicle routing will be returned. This is the default.</para>
			/// </summary>
			[GPValue("ROUTING_LOCATION")]
			[Description("Routing location")]
			Routing_location,

			/// <summary>
			/// <para>Address location—Geometry for geocode results that represent an address location—such as a rooftop location, parcel centroid, or front door—will be returned.</para>
			/// </summary>
			[GPValue("ADDRESS_LOCATION")]
			[Description("Address location")]
			Address_location,

		}

		/// <summary>
		/// <para>Output Fields</para>
		/// </summary>
		public enum OutputFieldsEnum 
		{
			/// <summary>
			/// <para>All— Includes all available locator output fields in the geocode results. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Minimal—Adds the following fields that describe the location and how well it matches information in the locator in the geocode results: Shape, Status, Score, Match_type, Match_addr, and Addr_type. The original field names from the Input Table parameter are maintained.</para>
			/// </summary>
			[GPValue("MINIMAL")]
			[Description("Minimal")]
			Minimal,

			/// <summary>
			/// <para>Location Only—The Shape field is stored if the geocode result is a feature class. The Shape X and Shape Y fields are stored if the result is either a .csv or .xls file. The original field names from the Input Table parameter are maintained with their original field names.</para>
			/// </summary>
			[GPValue("LOCATION_ONLY")]
			[Description("Location Only")]
			Location_Only,

		}

#endregion
	}
}
