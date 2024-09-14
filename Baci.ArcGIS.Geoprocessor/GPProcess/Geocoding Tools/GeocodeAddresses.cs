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
	/// <para>Geocode Addresses</para>
	/// <para>Geocode Addresses</para>
	/// <para>Geocodes a table of addresses. This process requires a table that stores the addresses you want to geocode and an address locator or a composite address locator. This tool matches the stored addresses against the locator and saves the result for each input record in a new point feature class. When using the ArcGIS World Geocoding Service, this operation may consume credits.</para>
	/// </summary>
	public class GeocodeAddresses : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table of addresses to geocode.</para>
		/// </param>
		/// <param name="AddressLocator">
		/// <para>Input Address Locator</para>
		/// <para>The address locator to use to geocode the table of addresses.Including the .loc extension after the locator name at the end of the locator path is optional.</para>
		/// </param>
		/// <param name="InAddressFields">
		/// <para>Input Address Fields</para>
		/// <para>The mapping of address fields used by the address locator to fields in the input table of addresses. Select Single Field if the complete address is stored in one field in the input table, for example, 303 Peachtree St NE, Atlanta, GA 30308. Select Multiple Fields if the input addresses are split into multiple fields such as Address, City, State, and ZIP for a general United States address. Select Single Field and Country Field if the complete address and the country are split into separate fields such as Address (303 Peachtree St NE, Atlanta, GA 30308) and Country (USA).</para>
		/// <para>Some locators support multiple input addresses fields, such as Address, Address2, and Address3. In this case, the address component can be separated into multiple fields, and the address fields will be concatenated at the time of geocoding. For example, 100, Main st, and Apt 140 across three fields, or 100 Main st and Apt 140 across two fields, both become 100 Main st Apt 140 when geocoding.</para>
		/// <para>If you do not map an optional input address field used by the address locator to a field in the input table of addresses, specify that there is no mapping using &lt;None&gt; in place of the field name.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output geocoded feature class.</para>
		/// <para>Saving the output to shapefile format is not supported due to shapefile limitations.</para>
		/// </param>
		public GeocodeAddresses(object InTable, object AddressLocator, object InAddressFields, object OutFeatureClass)
		{
			this.InTable = InTable;
			this.AddressLocator = AddressLocator;
			this.InAddressFields = InAddressFields;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Geocode Addresses</para>
		/// </summary>
		public override string DisplayName() => "Geocode Addresses";

		/// <summary>
		/// <para>Tool Name : GeocodeAddresses</para>
		/// </summary>
		public override string ToolName() => "GeocodeAddresses";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.GeocodeAddresses</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.GeocodeAddresses";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, AddressLocator, InAddressFields, OutFeatureClass, OutRelationshipType!, Country!, LocationType!, Category!, OutputFields! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table of addresses to geocode.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_gt_tables")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Address Locator</para>
		/// <para>The address locator to use to geocode the table of addresses.Including the .loc extension after the locator name at the end of the locator path is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object AddressLocator { get; set; }

		/// <summary>
		/// <para>Input Address Fields</para>
		/// <para>The mapping of address fields used by the address locator to fields in the input table of addresses. Select Single Field if the complete address is stored in one field in the input table, for example, 303 Peachtree St NE, Atlanta, GA 30308. Select Multiple Fields if the input addresses are split into multiple fields such as Address, City, State, and ZIP for a general United States address. Select Single Field and Country Field if the complete address and the country are split into separate fields such as Address (303 Peachtree St NE, Atlanta, GA 30308) and Country (USA).</para>
		/// <para>Some locators support multiple input addresses fields, such as Address, Address2, and Address3. In this case, the address component can be separated into multiple fields, and the address fields will be concatenated at the time of geocoding. For example, 100, Main st, and Apt 140 across three fields, or 100 Main st and Apt 140 across two fields, both become 100 Main st Apt 140 when geocoding.</para>
		/// <para>If you do not map an optional input address field used by the address locator to a field in the input table of addresses, specify that there is no mapping using &lt;None&gt; in place of the field name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldInfo()]
		public object InAddressFields { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output geocoded feature class.</para>
		/// <para>Saving the output to shapefile format is not supported due to shapefile limitations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_geodatabaseItems_featureClasses")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Dynamic Output Feature Class</para>
		/// <para>This parameter is inactive in ArcGIS Pro. It remains to support backward compatibility with ArcGIS Desktop.</para>
		/// <para><see cref="OutRelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutRelationshipType { get; set; } = "false";

		/// <summary>
		/// <para>Country</para>
		/// <para>This parameter is available for locators that support a country parameter and will limit geocoding to the selected countries. Selecting a country will improve the accuracy of geocoding in most cases. When you select Single Field and Country Field for the Input Address Fields parameter and map a field representing countries using the Input Table parameter value to the Country field for the Input Address Fields parameter value, the country value from the Input Table parameter value will override the Country parameter.</para>
		/// <para>This is limited to the selected country or countries. When no country is specified, geocoding is performed using all supported countries of the locator.</para>
		/// <para>The Country parameter is not supported for all locators.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Country { get; set; }

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// <para>Specifies the preferred output geometry for PointAddress matches. The options for this parameter are Routing location, the side of street location, which can be used for routing, or Address location, the location that represents the rooftop or parcel centroid for the address. If the preferred location does not exist in the data, the default location will be returned instead. For geocode results with Addr_type=PointAddress, the x,y attribute values describe the coordinates of the address along the street, while the DisplayX and DisplayY values describe the rooftop or building centroid coordinates.</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// <para>Address location—Geometry for geocode results that represent an address location such as rooftop location, parcel centroid, or front door will be returned.</para>
		/// <para>Routing location—Geometry for geocode results that represent a location close to the side of the street, which can be used for vehicle routing, will be returned. This is the default.</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocationType { get; set; } = "ROUTING_LOCATION";

		/// <summary>
		/// <para>Category</para>
		/// <para>Limits the types of places the locator searches, which eliminates false positive matches and potentially speeds up the search process. When no category is used, geocoding is performed using all supported categories. Not all category values are supported for all locations and countries. In general, the parameter can be used for the following:</para>
		/// <para>Limit matches to specific place types or address levels</para>
		/// <para>Avoid fallback matches to unwanted address levels</para>
		/// <para>Disambiguate coordinate searches</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// <para>See the ArcGIS REST API web help for details about category filtering.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Category { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>Specifies which locator output fields will be returned in the geocode results.</para>
		/// <para>This parameter can be used with input locators created with the Create Locator tool or Create Feature Locator tool stored on disk or published to Enterprise 10.9 or later. Composite locators that contain at least one locator created with the Create Address Locator tool do not support this parameter.</para>
		/// <para>All— Includes all available locator output fields in the geocode results. This is the default.</para>
		/// <para>Location Only—Stores the Shape field in the geocode results. The original field names from the Input Table parameter are maintained with their original field names.</para>
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
		public GeocodeAddresses SetEnviroment(object? configKeyword = null, object? outputCoordinateSystem = null)
		{
			base.SetEnv(configKeyword: configKeyword, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dynamic Output Feature Class</para>
		/// </summary>
		public enum OutRelationshipTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DYNAMIC")]
			DYNAMIC,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("STATIC")]
			STATIC,

		}

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// </summary>
		public enum LocationTypeEnum 
		{
			/// <summary>
			/// <para>Routing location—Geometry for geocode results that represent a location close to the side of the street, which can be used for vehicle routing, will be returned. This is the default.</para>
			/// </summary>
			[GPValue("ROUTING_LOCATION")]
			[Description("Routing location")]
			Routing_location,

			/// <summary>
			/// <para>Address location—Geometry for geocode results that represent an address location such as rooftop location, parcel centroid, or front door will be returned.</para>
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
			/// <para>Location Only—Stores the Shape field in the geocode results. The original field names from the Input Table parameter are maintained with their original field names.</para>
			/// </summary>
			[GPValue("LOCATION_ONLY")]
			[Description("Location Only")]
			Location_Only,

		}

#endregion
	}
}
