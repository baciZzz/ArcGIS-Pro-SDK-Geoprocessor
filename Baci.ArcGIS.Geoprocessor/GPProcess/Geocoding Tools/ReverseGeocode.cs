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
	/// <para>Reverse Geocode</para>
	/// <para>Creates addresses from point locations in a feature class. The reverse geocoding process searches for the nearest address or intersection for the point location based on the specified search distance. When using the ArcGIS World Geocoding Service, this operation may consume credits.</para>
	/// </summary>
	public class ReverseGeocode : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Feature Class or layer</para>
		/// <para>A point feature class or layer from which matching places or addresses will be returned based on the features' point location.</para>
		/// </param>
		/// <param name="InAddressLocator">
		/// <para>Input Address Locator</para>
		/// <para>The locator that will be used to reverse geocode the input feature class or layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance that will be used to search for the nearest address or intersection for the point location. Some locators use optimized distance values that do not support overriding the search distance parameter.</para>
		/// <para>This parameter only applies to locators built with the Create Address Locator tool or composite locators that contain locators built with the Create Address Locator tool.</para>
		/// </param>
		public ReverseGeocode(object InFeatures, object InAddressLocator, object OutFeatureClass, object SearchDistance)
		{
			this.InFeatures = InFeatures;
			this.InAddressLocator = InAddressLocator;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Reverse Geocode</para>
		/// </summary>
		public override string DisplayName() => "Reverse Geocode";

		/// <summary>
		/// <para>Tool Name : ReverseGeocode</para>
		/// </summary>
		public override string ToolName() => "ReverseGeocode";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.ReverseGeocode</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.ReverseGeocode";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InAddressLocator, OutFeatureClass, AddressType, SearchDistance, FeatureType, LocationType };

		/// <summary>
		/// <para>Input Feature Class or layer</para>
		/// <para>A point feature class or layer from which matching places or addresses will be returned based on the features' point location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Address Locator</para>
		/// <para>The locator that will be used to reverse geocode the input feature class or layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InAddressLocator { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Address Type</para>
		/// <para>Specifies whether addresses for the points will be returned as street addresses or intersection addresses if the locator supports intersection matching.</para>
		/// <para>This parameter only applies to locators built with the Create Address Locator tool or composite locators that contain locators built with the Create Address Locator tool.</para>
		/// <para>Address—Addresses will be returned as street addresses or in the format defined by the input address locator. This is the default.</para>
		/// <para>Intersection—Addresses will be returned as intersection addresses. This option is available if the address locator supports matching intersection addresses.</para>
		/// <para><see cref="AddressTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AddressType { get; set; } = "ADDRESS";

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance that will be used to search for the nearest address or intersection for the point location. Some locators use optimized distance values that do not support overriding the search distance parameter.</para>
		/// <para>This parameter only applies to locators built with the Create Address Locator tool or composite locators that contain locators built with the Create Address Locator tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>Specifies the possible match types that will be returned. A single value or multiple values can be selected. If a single value is selected, the search tolerance for the input feature type is 500 meters. If multiple values are included, the default search distances specified in the feature type hierarchy table will be applied.</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// <para>Subaddress—The match will be limited to a street address based on points that represent house and building subaddress locations.</para>
		/// <para>Point Address—The match will be limited to a street address based on points that represent house and building locations.</para>
		/// <para>Parcel—The match will be limited to a plot of land that is considered real property and can include one or more homes or other structures. This match type typically has an address and a parcel identification number assigned to it.</para>
		/// <para>Street Address—The match will be limited to a street address that differs from Point Address because the house number is interpolated from a range of numbers. Street Address matches include the house number range for the matching street segment rather than the interpolated house number value.</para>
		/// <para>Street Intersection— The match will be limited to a street address consisting of a street intersection along with city and optional state and postal code information. This is derived from Street Address reference data, for example, Redlands Blvd &amp; New York St, Redlands, CA, 92373.</para>
		/// <para>Street Name—The match will be limited to a street address similar to Street Address but without house numbers along with administrative divisions and optional postal code, for example, W Olive Ave, Redlands, CA, 92373 .</para>
		/// <para>Locality—The match will be limited to a place-name representing a populated place.</para>
		/// <para>Postal—The match will be limited to a postal code. Reference data is postal code points, for example, 90210 USA.</para>
		/// <para>Point of Interest—The match will be limited to a point of interest. Reference data consists of administrative division place-names, businesses, landmarks, and geographic features, for example, Starbucks.</para>
		/// <para>Distance Marker— The match will be limited to a street address that represents the linear distance along a street, typically in kilometers or miles, from a designated origin location, for example, Mile 25 I-5 N, San Diego, CA.</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object FeatureType { get; set; }

		/// <summary>
		/// <para>Preferred Location Type</para>
		/// <para>Specifies the preferred output geometry for Point Address matches. The options for this parameter are a side of street location, which can be used for routing, or the location that represents the rooftop or parcel centroid for the address. If the preferred location does not exist in the data, the default location will be returned instead. For geocode results with Addr_type=PointAddress, the x,y attribute values describe the coordinates of the address along the street, while the DisplayX and DisplayY values describe the rooftop or building centroid coordinates.</para>
		/// <para>This parameter is not supported for all locators.</para>
		/// <para>Address location—Geometry for geocode results that represent an address location such as rooftop, building centroid, or front door is returned will be returned.</para>
		/// <para>Routing location—Geometry for geocode results that represent a location close to the side of the street, which can be used for vehicle routing, will be returned. This is the default.</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocationType { get; set; } = "ROUTING_LOCATION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReverseGeocode SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Address Type</para>
		/// </summary>
		public enum AddressTypeEnum 
		{
			/// <summary>
			/// <para>Address—Addresses will be returned as street addresses or in the format defined by the input address locator. This is the default.</para>
			/// </summary>
			[GPValue("ADDRESS")]
			[Description("Address")]
			Address,

			/// <summary>
			/// <para>Intersection—Addresses will be returned as intersection addresses. This option is available if the address locator supports matching intersection addresses.</para>
			/// </summary>
			[GPValue("INTERSECTION")]
			[Description("Intersection")]
			Intersection,

		}

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>Point Address—The match will be limited to a street address based on points that represent house and building locations.</para>
			/// </summary>
			[GPValue("POINT_ADDRESS")]
			[Description("Point Address")]
			Point_Address,

			/// <summary>
			/// <para>Street Address—The match will be limited to a street address that differs from Point Address because the house number is interpolated from a range of numbers. Street Address matches include the house number range for the matching street segment rather than the interpolated house number value.</para>
			/// </summary>
			[GPValue("STREET_ADDRESS")]
			[Description("Street Address")]
			Street_Address,

			/// <summary>
			/// <para>Street Intersection— The match will be limited to a street address consisting of a street intersection along with city and optional state and postal code information. This is derived from Street Address reference data, for example, Redlands Blvd &amp; New York St, Redlands, CA, 92373.</para>
			/// </summary>
			[GPValue("STREET_INTERSECTION")]
			[Description("Street Intersection")]
			Street_Intersection,

			/// <summary>
			/// <para>Street Name—The match will be limited to a street address similar to Street Address but without house numbers along with administrative divisions and optional postal code, for example, W Olive Ave, Redlands, CA, 92373 .</para>
			/// </summary>
			[GPValue("STREET_NAME")]
			[Description("Street Name")]
			Street_Name,

			/// <summary>
			/// <para>Locality—The match will be limited to a place-name representing a populated place.</para>
			/// </summary>
			[GPValue("LOCALITY")]
			[Description("Locality")]
			Locality,

			/// <summary>
			/// <para>Postal—The match will be limited to a postal code. Reference data is postal code points, for example, 90210 USA.</para>
			/// </summary>
			[GPValue("POSTAL")]
			[Description("Postal")]
			Postal,

			/// <summary>
			/// <para>Point of Interest—The match will be limited to a point of interest. Reference data consists of administrative division place-names, businesses, landmarks, and geographic features, for example, Starbucks.</para>
			/// </summary>
			[GPValue("POINT_OF_INTEREST")]
			[Description("Point of Interest")]
			Point_of_Interest,

			/// <summary>
			/// <para>Distance Marker— The match will be limited to a street address that represents the linear distance along a street, typically in kilometers or miles, from a designated origin location, for example, Mile 25 I-5 N, San Diego, CA.</para>
			/// </summary>
			[GPValue("DISTANCE_MARKER")]
			[Description("Distance Marker")]
			Distance_Marker,

			/// <summary>
			/// <para>Parcel—The match will be limited to a plot of land that is considered real property and can include one or more homes or other structures. This match type typically has an address and a parcel identification number assigned to it.</para>
			/// </summary>
			[GPValue("PARCEL")]
			[Description("Parcel")]
			Parcel,

			/// <summary>
			/// <para>Subaddress—The match will be limited to a street address based on points that represent house and building subaddress locations.</para>
			/// </summary>
			[GPValue("SUBADDRESS")]
			[Description("Subaddress")]
			Subaddress,

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
			/// <para>Address location—Geometry for geocode results that represent an address location such as rooftop, building centroid, or front door is returned will be returned.</para>
			/// </summary>
			[GPValue("ADDRESS_LOCATION")]
			[Description("Address location")]
			Address_location,

		}

#endregion
	}
}
