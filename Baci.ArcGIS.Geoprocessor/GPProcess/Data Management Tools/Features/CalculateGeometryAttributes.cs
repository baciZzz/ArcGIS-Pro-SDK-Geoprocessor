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
	/// <para>Calculate Geometry Attributes</para>
	/// <para>Calculate Geometry Attributes</para>
	/// <para>Adds information to a feature's attribute fields representing the spatial or geometric characteristics and location of each feature, such as length or area and x-, y-, z-, and m-coordinates.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateGeometryAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features with a field that will be updated with geometry calculations.</para>
		/// </param>
		/// <param name="GeometryProperty">
		/// <para>Geometry Attributes</para>
		/// <para>Specifies the fields in which the selected geometry properties will be calculated.</para>
		/// <para>You can select an existing field or provide a new field name. If a new field name is specified, the field type is determined by the type of values that are written to the field. Count attributes are written to long integer fields, area, length, and x-, y-, z-, and m-coordinate attributes are written to double fields, and coordinate notations such as Degrees Minutes Seconds or MGRS are written to text fields.</para>
		/// <para>AREA—The area of each polygon feature.</para>
		/// <para>AREA_GEODESIC—The shape-preserving geodesic area of each polygon feature.</para>
		/// <para>CENTROID_X—The centroid x-coordinate of each feature.</para>
		/// <para>CENTROID_Y—The centroid y-coordinate of each feature.</para>
		/// <para>CENTROID_Z—The centroid z-coordinate of each feature.</para>
		/// <para>CENTROID_M—The centroid m-coordinate of each feature.</para>
		/// <para>INSIDE_X—The x-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>INSIDE_Y—The y-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>INSIDE_Z—The z-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>INSIDE_M—The m-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>CURVE_COUNT—The number of curves in each feature. Curves include elliptical arcs, circular arcs, and Bezier curves.</para>
		/// <para>HOLE_COUNT—The number of interior holes within each polygon feature.</para>
		/// <para>EXTENT_MIN_X—The minimum x-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MIN_Y—The minimum y-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MIN_Z—The minimum z-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MAX_X—The maximum x-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MAX_Y—The maximum y-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MAX_Z—The maximum z-coordinate of each feature&apos;s extent.</para>
		/// <para>LENGTH—The length of each line feature.</para>
		/// <para>LENGTH_GEODESIC—The shape-preserving geodesic length of each line feature.</para>
		/// <para>LENGTH_3D—The 3D length of each line feature.</para>
		/// <para>LINE_BEARING—The start-to-end bearing of each line feature. Values range from 0 to 360, with 0 meaning north, 90 east, 180 south, 270 west, and so on.</para>
		/// <para>LINE_START_X—The x-coordinate of the start point of each line feature.</para>
		/// <para>LINE_START_Y—The y-coordinate of the start point of each line feature.</para>
		/// <para>LINE_START_Z—The z-coordinate of the start point of each line feature.</para>
		/// <para>LINE_START_M—The m-coordinate of the start point of each line feature.</para>
		/// <para>LINE_END_X—The x-coordinate of the end point of each line feature.</para>
		/// <para>LINE_END_Y—The y-coordinate of the end point of each line feature.</para>
		/// <para>LINE_END_Z—The z-coordinate of the end point of each line feature.</para>
		/// <para>LINE_END_M—The m-coordinate of the end point of each line feature.</para>
		/// <para>PART_COUNT—The number of parts composing each feature.</para>
		/// <para>PERIMETER_LENGTH—The length of the perimeter or border of each polygon feature.</para>
		/// <para>PERIMETER_LENGTH_GEODESIC—The shape-preserving geodesic length of the perimeter or border of each polygon feature.</para>
		/// <para>POINT_COUNT—The number of points or vertices composing each feature.</para>
		/// <para>POINT_X—The x-coordinate of each point feature.</para>
		/// <para>POINT_Y—The y-coordinate of each point feature.</para>
		/// <para>POINT_Z—The z-coordinate of each point feature.</para>
		/// <para>POINT_M—The m-coordinate of each point feature.</para>
		/// <para>POINT_COORD_NOTATION—The x- and y-coordinate of each point feature formatted as a specified coordinate notation.</para>
		/// </param>
		public CalculateGeometryAttributes(object InFeatures, object GeometryProperty)
		{
			this.InFeatures = InFeatures;
			this.GeometryProperty = GeometryProperty;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Geometry Attributes</para>
		/// </summary>
		public override string DisplayName() => "Calculate Geometry Attributes";

		/// <summary>
		/// <para>Tool Name : CalculateGeometryAttributes</para>
		/// </summary>
		public override string ToolName() => "CalculateGeometryAttributes";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateGeometryAttributes</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateGeometryAttributes";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, GeometryProperty, LengthUnit!, AreaUnit!, CoordinateSystem!, UpdatedFeatures!, CoordinateFormat! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features with a field that will be updated with geometry calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Multipoint", "Point", "Polyline", "MultiPatch")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Geometry Attributes</para>
		/// <para>Specifies the fields in which the selected geometry properties will be calculated.</para>
		/// <para>You can select an existing field or provide a new field name. If a new field name is specified, the field type is determined by the type of values that are written to the field. Count attributes are written to long integer fields, area, length, and x-, y-, z-, and m-coordinate attributes are written to double fields, and coordinate notations such as Degrees Minutes Seconds or MGRS are written to text fields.</para>
		/// <para>AREA—The area of each polygon feature.</para>
		/// <para>AREA_GEODESIC—The shape-preserving geodesic area of each polygon feature.</para>
		/// <para>CENTROID_X—The centroid x-coordinate of each feature.</para>
		/// <para>CENTROID_Y—The centroid y-coordinate of each feature.</para>
		/// <para>CENTROID_Z—The centroid z-coordinate of each feature.</para>
		/// <para>CENTROID_M—The centroid m-coordinate of each feature.</para>
		/// <para>INSIDE_X—The x-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>INSIDE_Y—The y-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>INSIDE_Z—The z-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>INSIDE_M—The m-coordinate of a central point inside or on each feature. This point is the same as the centroid if the centroid is inside the feature; otherwise, it is an inner label point.</para>
		/// <para>CURVE_COUNT—The number of curves in each feature. Curves include elliptical arcs, circular arcs, and Bezier curves.</para>
		/// <para>HOLE_COUNT—The number of interior holes within each polygon feature.</para>
		/// <para>EXTENT_MIN_X—The minimum x-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MIN_Y—The minimum y-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MIN_Z—The minimum z-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MAX_X—The maximum x-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MAX_Y—The maximum y-coordinate of each feature&apos;s extent.</para>
		/// <para>EXTENT_MAX_Z—The maximum z-coordinate of each feature&apos;s extent.</para>
		/// <para>LENGTH—The length of each line feature.</para>
		/// <para>LENGTH_GEODESIC—The shape-preserving geodesic length of each line feature.</para>
		/// <para>LENGTH_3D—The 3D length of each line feature.</para>
		/// <para>LINE_BEARING—The start-to-end bearing of each line feature. Values range from 0 to 360, with 0 meaning north, 90 east, 180 south, 270 west, and so on.</para>
		/// <para>LINE_START_X—The x-coordinate of the start point of each line feature.</para>
		/// <para>LINE_START_Y—The y-coordinate of the start point of each line feature.</para>
		/// <para>LINE_START_Z—The z-coordinate of the start point of each line feature.</para>
		/// <para>LINE_START_M—The m-coordinate of the start point of each line feature.</para>
		/// <para>LINE_END_X—The x-coordinate of the end point of each line feature.</para>
		/// <para>LINE_END_Y—The y-coordinate of the end point of each line feature.</para>
		/// <para>LINE_END_Z—The z-coordinate of the end point of each line feature.</para>
		/// <para>LINE_END_M—The m-coordinate of the end point of each line feature.</para>
		/// <para>PART_COUNT—The number of parts composing each feature.</para>
		/// <para>PERIMETER_LENGTH—The length of the perimeter or border of each polygon feature.</para>
		/// <para>PERIMETER_LENGTH_GEODESIC—The shape-preserving geodesic length of the perimeter or border of each polygon feature.</para>
		/// <para>POINT_COUNT—The number of points or vertices composing each feature.</para>
		/// <para>POINT_X—The x-coordinate of each point feature.</para>
		/// <para>POINT_Y—The y-coordinate of each point feature.</para>
		/// <para>POINT_Z—The z-coordinate of each point feature.</para>
		/// <para>POINT_M—The m-coordinate of each point feature.</para>
		/// <para>POINT_COORD_NOTATION—The x- and y-coordinate of each point feature formatted as a specified coordinate notation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object GeometryProperty { get; set; }

		/// <summary>
		/// <para>Length Unit</para>
		/// <para>Specifies the unit that will be used to calculate length.</para>
		/// <para>Kilometers—The length unit will be Kilometers.</para>
		/// <para>Meters—The length unit will be Meters.</para>
		/// <para>Statute Miles—The length unit will be Statute Miles.</para>
		/// <para>International Nautical Miles—The length unit will be International Nautical Miles.</para>
		/// <para>International Yards—The length unit will be International Yards.</para>
		/// <para>International Feet—The length unit will be International Feet.</para>
		/// <para>US Survey Miles—The length unit will be US Survey Miles.</para>
		/// <para>US Survey Nautical Miles—The length unit will be US Survey Nautical Miles.</para>
		/// <para>US Survey Yards—The length unit will be US Survey Yards.</para>
		/// <para>US Survey Feet—The length unit will be US Survey Feet.</para>
		/// <para><see cref="LengthUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LengthUnit { get; set; }

		/// <summary>
		/// <para>Area Unit</para>
		/// <para>Specifies the unit that will be used to calculate area.</para>
		/// <para>Square Kilometers—The area unit will be Square Kilometers.</para>
		/// <para>Hectares—The area unit will be Hectares.</para>
		/// <para>Square Meters—The area unit will be Square Meters.</para>
		/// <para>Square Statute Miles—The area unit will be Square Statute Miles.</para>
		/// <para>Square International Nautical Miles—The area unit will be Square International Nautical Miles.</para>
		/// <para>International Acres—The area unit will be International Acres.</para>
		/// <para>Square International Yards—The area unit will be Square International Yards.</para>
		/// <para>Square International Feet—The area unit will be Square International Feet.</para>
		/// <para>Square US Survey Miles—The area unit will be Square US Survey Miles.</para>
		/// <para>Square US Survey Nautical Miles—The area unit will be Square US Survey Nautical Miles.</para>
		/// <para>US Survey Acres—The area unit will be US Survey Acres.</para>
		/// <para>Square US Survey Yards—The area unit will be Square US Survey Yards.</para>
		/// <para>Square US Survey Feet—The area unit will be Square US Survey Feet.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnit { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system in which the coordinates, length, and area will be calculated. The coordinate system of the input features is used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Coordinate Format</para>
		/// <para>Specifies the coordinate format in which the x- and y-coordinates will be calculated. The coordinate format matching the input features&apos; spatial reference units is used by default.</para>
		/// <para>Several coordinate formats, including Degrees Minutes Seconds, Degrees Decimal Minutes, and others, require the calculation to be performed in a text field.</para>
		/// <para>Same as input—The input features&apos; spatial reference units will be used for coordinate formatting. This is the default.</para>
		/// <para>Decimal Degrees—Decimal Degrees.</para>
		/// <para>Degrees Minutes Seconds (DDD° MM&apos; SSS.ss&quot; &lt;N|S|E|W&gt;)—Degrees Minutes Seconds with cardinal direction component at the end (DDD° MM&apos; SSS.ss&quot; &lt;N|S|E|W&gt;).</para>
		/// <para>Degrees Minutes Seconds (&lt;N|S|E|W&gt; DDD° MM&apos; SSS.ss&quot;)—Degrees Minutes Seconds with cardinal direction component at the beginning (&lt;N|S|E|W&gt; DDD° MM&apos; SSS.ss&quot;).</para>
		/// <para>Degrees Minutes Seconds (&lt;+|-&gt; DDD° MM&apos; SSS.ss&quot;)—Degrees Minutes Seconds with positive or negative direction component at the beginning (&lt;+|-&gt; DDD° MM&apos; SSS.ss&quot;).</para>
		/// <para>Degrees Minutes Seconds (&lt;+|-&gt; DDD.MMSSSss)—Degrees Minutes Seconds packed into a single value with positive or negative direction component at the beginning (&lt;+|-&gt; DDD.MMSSSss).</para>
		/// <para>Degrees Decimal Minutes (DDD° MM.mmm&apos; &lt;N|S|E|W&gt;)—Degrees Decimal Minutes with cardinal direction component at the end (DDD° MM.mmm&apos; &lt;N|S|E|W&gt;).</para>
		/// <para>Degrees Decimal Minutes (&lt;N|S|E|W&gt; DDD° MM.mmm&apos;)—Degrees Decimal Minutes with cardinal direction component at the beginning (&lt;N|S|E|W&gt; DDD° MM.mmm&apos;).</para>
		/// <para>Degrees Decimal Minutes (&lt;+|-&gt; DDD° MM.mmm&apos;)—Degrees Decimal Minutes with positive or negative direction component at the beginning (&lt;+|-&gt; DDD° MM.mmm&apos;).</para>
		/// <para>GARS (Global Area Reference System)—The Global Area Reference System is based on latitude and longitude, dividing and subdividing the world into cells.</para>
		/// <para>GEOREF (World Geographic Reference System)—The World Geographic Reference System is based on the geographic system of latitude and longitude, but using a simpler and more flexible notation.</para>
		/// <para>MGRS (Military Grid Reference System)—Military Grid Reference System.</para>
		/// <para>USNG (United States National Grid)—United States National Grid.</para>
		/// <para>UTM (Universal Transverse Mercator)—Universal Transverse Mercator.</para>
		/// <para>UTM with no spaces—Universal Transverse Mercator with no spaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CoordinateFormat { get; set; } = "SAME_AS_INPUT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateGeometryAttributes SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Length Unit</para>
		/// </summary>
		public enum LengthUnitEnum 
		{
			/// <summary>
			/// <para>Kilometers—The length unit will be Kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—The length unit will be Meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>International Nautical Miles—The length unit will be International Nautical Miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES_INT")]
			[Description("International Nautical Miles")]
			International_Nautical_Miles,

			/// <summary>
			/// <para>Statute Miles—The length unit will be Statute Miles.</para>
			/// </summary>
			[GPValue("MILES_INT")]
			[Description("Statute Miles")]
			Statute_Miles,

			/// <summary>
			/// <para>International Yards—The length unit will be International Yards.</para>
			/// </summary>
			[GPValue("YARDS_INT")]
			[Description("International Yards")]
			International_Yards,

			/// <summary>
			/// <para>International Feet—The length unit will be International Feet.</para>
			/// </summary>
			[GPValue("FEET_INT")]
			[Description("International Feet")]
			International_Feet,

			/// <summary>
			/// <para>US Survey Nautical Miles—The length unit will be US Survey Nautical Miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("US Survey Nautical Miles")]
			US_Survey_Nautical_Miles,

			/// <summary>
			/// <para>US Survey Miles—The length unit will be US Survey Miles.</para>
			/// </summary>
			[GPValue("MILES_US")]
			[Description("US Survey Miles")]
			US_Survey_Miles,

			/// <summary>
			/// <para>US Survey Yards—The length unit will be US Survey Yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("US Survey Yards")]
			US_Survey_Yards,

			/// <summary>
			/// <para>US Survey Feet—The length unit will be US Survey Feet.</para>
			/// </summary>
			[GPValue("FEET_US")]
			[Description("US Survey Feet")]
			US_Survey_Feet,

		}

#endregion
	}
}
