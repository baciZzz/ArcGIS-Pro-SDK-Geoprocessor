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
	/// <para>Geocode Locations From Table</para>
	/// <para>Geocodes hosted tables using locators hosted on an ArcGIS Enterprise portal, which creates a hosted feature layer containing the geocoded results.</para>
	/// </summary>
	public class GeocodeLocationsFromTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table on the portal that contains addresses or places to geocode.</para>
		/// </param>
		/// <param name="InAddressLocator">
		/// <para>Address Locator</para>
		/// <para>The portal locator that will be used to geocode the input table from the portal.</para>
		/// <para>You can select a locator from the populated list of locators on the active portal or browse the active portal for other available locators. Locators that have been set as utility services in the active portal will be available by default. If the portal locator you want to use is not in the populated list, ask your portal administrator to add the locator as a portal utility service, and configure the locator for batch geocoding.</para>
		/// <para>The ArcGIS World Geocoding Service is disabled for this tool. Use the Geocode Addresses tool if you want to use the ArcGIS World Geocoding Service.</para>
		/// </param>
		/// <param name="AddressFields">
		/// <para>Address Field Mapping</para>
		/// <para>The mapping of address fields used by the locator to fields in the input table of addresses. Select Single Field if the complete address is stored in one field in the input table, for example, 303 Peachtree St NE, Atlanta, GA 30308. Select Multiple Fields if the input addresses are split into multiple fields such as Address, City, State, and ZIP for a general United States address.</para>
		/// <para>Some locators support multiple input address fields such as Address, Address2, and Address3. In this case, the address component can be separated into multiple fields and the address fields will be concatenated at the time of geocoding. For example, 100, Main St, and Apt 140 across three fields or 100 Main St and Apt 140 across two fields would both become 100 Main St Apt 140 when geocoding.</para>
		/// <para>If you choose not to map an optional input address field used by the locator to a field in the input table of addresses, specify that there is no mapping by using &lt;None&gt; in place of a field name.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Feature Layer Name</para>
		/// <para>The name of the output geocoded feature layer that will be created on the portal.</para>
		/// </param>
		public GeocodeLocationsFromTable(object InTable, object InAddressLocator, object AddressFields, object OutputName)
		{
			this.InTable = InTable;
			this.InAddressLocator = InAddressLocator;
			this.AddressFields = AddressFields;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : Geocode Locations From Table</para>
		/// </summary>
		public override string DisplayName => "Geocode Locations From Table";

		/// <summary>
		/// <para>Tool Name : GeocodeLocationsFromTable</para>
		/// </summary>
		public override string ToolName => "GeocodeLocationsFromTable";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.GeocodeLocationsFromTable</para>
		/// </summary>
		public override string ExcuteName => "geocoding.GeocodeLocationsFromTable";

		/// <summary>
		/// <para>Toolbox Display Name : Geocoding Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geocoding Tools";

		/// <summary>
		/// <para>Toolbox Alise : geocoding</para>
		/// </summary>
		public override string ToolboxAlise => "geocoding";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, InAddressLocator, AddressFields, OutputName, Country, LocationType, Category, OutputLayer, OutputFields };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table on the portal that contains addresses or places to geocode.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPBrowseFiltersDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Address Locator</para>
		/// <para>The portal locator that will be used to geocode the input table from the portal.</para>
		/// <para>You can select a locator from the populated list of locators on the active portal or browse the active portal for other available locators. Locators that have been set as utility services in the active portal will be available by default. If the portal locator you want to use is not in the populated list, ask your portal administrator to add the locator as a portal utility service, and configure the locator for batch geocoding.</para>
		/// <para>The ArcGIS World Geocoding Service is disabled for this tool. Use the Geocode Addresses tool if you want to use the ArcGIS World Geocoding Service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InAddressLocator { get; set; }

		/// <summary>
		/// <para>Address Field Mapping</para>
		/// <para>The mapping of address fields used by the locator to fields in the input table of addresses. Select Single Field if the complete address is stored in one field in the input table, for example, 303 Peachtree St NE, Atlanta, GA 30308. Select Multiple Fields if the input addresses are split into multiple fields such as Address, City, State, and ZIP for a general United States address.</para>
		/// <para>Some locators support multiple input address fields such as Address, Address2, and Address3. In this case, the address component can be separated into multiple fields and the address fields will be concatenated at the time of geocoding. For example, 100, Main St, and Apt 140 across three fields or 100 Main St and Apt 140 across two fields would both become 100 Main St Apt 140 when geocoding.</para>
		/// <para>If you choose not to map an optional input address field used by the locator to a field in the input table of addresses, specify that there is no mapping by using &lt;None&gt; in place of a field name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldInfo()]
		public object AddressFields { get; set; }

		/// <summary>
		/// <para>Output Feature Layer Name</para>
		/// <para>The name of the output geocoded feature layer that will be created on the portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Country</para>
		/// <para>The country or countries to search for the geocoded addresses. This parameter is available for locators that support a country parameter and will limit geocoding to the selected countries. Making a country selection will improve the accuracy of geocoding in most cases. If a field representing countries in the Input Table parameter is mapped to the Country Input Address Field, the country value from the Input Table parameter will override the Country parameter.</para>
		/// <para>If no country is specified, geocoding is performed using all supported countries of the locator.</para>
		/// <para>The Country parameter is not supported for all locators.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Country { get; set; }

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// <para>Specifies the preferred output geometry for PointAddress matches. The options for this parameter are Routing location, which is the side of street location that can be used for routing and Address location, which is the location that represents the rooftop or parcel centroid for the address. If the preferred location does not exist in the data, the default location will be returned. For geocode results with Addr_type=PointAddress, the x,y attribute values describe the coordinates of the address along the street, while the DisplayX and DisplayY values describe the rooftop, or building centroid, coordinates.</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// <para>Address location—Geometry for geocode results that represent an address location such as a rooftop location, parcel centroid, or front door is returned.</para>
		/// <para>Routing location—Geometry for geocode results that represent a location close to the side of the street that can be used for vehicle routing is returned. This is the default.</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocationType { get; set; } = "ROUTING_LOCATION";

		/// <summary>
		/// <para>Category</para>
		/// <para>Limits the types of places the locator searches, eliminating false positive matches and potentially speeding up the search process. When no category is used, geocoding is performed using all supported categories. Not all category values are supported for all locations and countries. In general, the Category parameter can be used for the following:</para>
		/// <para>Limit matches to specific place types or address levels</para>
		/// <para>Avoid fallback matches to unwanted address levels</para>
		/// <para>Disambiguate coordinate searches</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Category { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>Specifies which locator output fields are returned in the geocode results.</para>
		/// <para>This parameter can be used with input locators created with the Create Locator tool or Create Feature Locator tool published to Enterprise 10.9 or later. Composite locators that contain at least one locator created with the Create Address Locator tool do not support this parameter.</para>
		/// <para>All— Includes all available locator output fields in the geocode results. This is the default.</para>
		/// <para>Location Only—Stores the Shape field in the geocode results. The original field names from the Input Table parameter are maintained with their original field names. Rematching geocode results is not available with this option.</para>
		/// <para>Minimal—Adds the following fields that describe the location and how well it matches to information in the locator in the geocode results: Shape, Status, Score, Match_type, Match_addr, and Addr_type. The original field names from the Input Table parameter are maintained with their original field names.</para>
		/// <para><see cref="OutputFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Optional parameters")]
		public object OutputFields { get; set; } = "ALL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeocodeLocationsFromTable SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// </summary>
		public enum LocationTypeEnum 
		{
			/// <summary>
			/// <para>Routing location—Geometry for geocode results that represent a location close to the side of the street that can be used for vehicle routing is returned. This is the default.</para>
			/// </summary>
			[GPValue("ROUTING_LOCATION")]
			[Description("Routing location")]
			Routing_location,

			/// <summary>
			/// <para>Address location—Geometry for geocode results that represent an address location such as a rooftop location, parcel centroid, or front door is returned.</para>
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
			/// <para>Minimal—Adds the following fields that describe the location and how well it matches to information in the locator in the geocode results: Shape, Status, Score, Match_type, Match_addr, and Addr_type. The original field names from the Input Table parameter are maintained with their original field names.</para>
			/// </summary>
			[GPValue("MINIMAL")]
			[Description("Minimal")]
			Minimal,

			/// <summary>
			/// <para>Location Only—Stores the Shape field in the geocode results. The original field names from the Input Table parameter are maintained with their original field names. Rematching geocode results is not available with this option.</para>
			/// </summary>
			[GPValue("LOCATION_ONLY")]
			[Description("Location Only")]
			Location_Only,

		}

#endregion
	}
}
