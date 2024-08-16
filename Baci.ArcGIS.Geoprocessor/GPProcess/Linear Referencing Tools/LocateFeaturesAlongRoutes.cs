using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LinearReferencingTools
{
	/// <summary>
	/// <para>Locate Features Along Routes</para>
	/// <para>Computes the intersection of input features (point, line, or polygon) and route features and writes the route and measure information to a new event table.</para>
	/// </summary>
	public class LocateFeaturesAlongRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point, line, or polygon features.</para>
		/// </param>
		/// <param name="InRoutes">
		/// <para>Input Route Features</para>
		/// <para>The routes with which the input features will be intersected.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route. This field can be numeric or character.</para>
		/// </param>
		/// <param name="RadiusOrTolerance">
		/// <para>Search Radius</para>
		/// <para>If the input features are points, the search radius is a numeric value defining how far around each point a search will be done to find a target route.</para>
		/// <para>If the input features are lines, the search tolerance is really a cluster tolerance, which is a numeric value representing the maximum tolerated distance between the input lines and the target routes.</para>
		/// <para>If the input features are polygons, this parameter is ignored and no search radius is used.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Event Table</para>
		/// <para>The table to be created.</para>
		/// </param>
		/// <param name="OutEventProperties">
		/// <para>Output Event Table Properties</para>
		/// <para>Parameter consisting of the route location fields and the type of events that will be written to the output event table.</para>
		/// <para>Route Identifier Field—The field that will contain values that indicate the route on which each event is located.</para>
		/// <para>Event Type—The type of events the output event table will contain (POINT or LINE).</para>
		/// <para>POINT—Point events occur at a precise location along a route. Only a single measure field must be specified.</para>
		/// <para>LINE—Line events define a portion of a route. Both from- and to-measure fields must be specified.</para>
		/// <para>From-Measure Field—A field that will contain measure values. Required when the event type is POINT or LINE. Note when the Event Type is POINT, the label for this parameter becomes Measure Field.</para>
		/// <para>To-Measure Field—A field that will contain measure values. Required when the event type is LINE.</para>
		/// </param>
		public LocateFeaturesAlongRoutes(object InFeatures, object InRoutes, object RouteIdField, object RadiusOrTolerance, object OutTable, object OutEventProperties)
		{
			this.InFeatures = InFeatures;
			this.InRoutes = InRoutes;
			this.RouteIdField = RouteIdField;
			this.RadiusOrTolerance = RadiusOrTolerance;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : Locate Features Along Routes</para>
		/// </summary>
		public override string DisplayName => "Locate Features Along Routes";

		/// <summary>
		/// <para>Tool Name : LocateFeaturesAlongRoutes</para>
		/// </summary>
		public override string ToolName => "LocateFeaturesAlongRoutes";

		/// <summary>
		/// <para>Tool Excute Name : lr.LocateFeaturesAlongRoutes</para>
		/// </summary>
		public override string ExcuteName => "lr.LocateFeaturesAlongRoutes";

		/// <summary>
		/// <para>Toolbox Display Name : Linear Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Linear Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : lr</para>
		/// </summary>
		public override string ToolboxAlise => "lr";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, InRoutes, RouteIdField, RadiusOrTolerance, OutTable, OutEventProperties, RouteLocations, DistanceField, ZeroLengthEvents, InFields, MDirectionOffsetting };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point, line, or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The routes with which the input features will be intersected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteDomain>")]
		public object InRoutes { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route. This field can be numeric or character.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>If the input features are points, the search radius is a numeric value defining how far around each point a search will be done to find a target route.</para>
		/// <para>If the input features are lines, the search tolerance is really a cluster tolerance, which is a numeric value representing the maximum tolerated distance between the input lines and the target routes.</para>
		/// <para>If the input features are polygons, this parameter is ignored and no search radius is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object RadiusOrTolerance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Output Event Table</para>
		/// <para>The table to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output Event Table Properties</para>
		/// <para>Parameter consisting of the route location fields and the type of events that will be written to the output event table.</para>
		/// <para>Route Identifier Field—The field that will contain values that indicate the route on which each event is located.</para>
		/// <para>Event Type—The type of events the output event table will contain (POINT or LINE).</para>
		/// <para>POINT—Point events occur at a precise location along a route. Only a single measure field must be specified.</para>
		/// <para>LINE—Line events define a portion of a route. Both from- and to-measure fields must be specified.</para>
		/// <para>From-Measure Field—A field that will contain measure values. Required when the event type is POINT or LINE. Note when the Event Type is POINT, the label for this parameter becomes Measure Field.</para>
		/// <para>To-Measure Field—A field that will contain measure values. Required when the event type is LINE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object OutEventProperties { get; set; }

		/// <summary>
		/// <para>Keep only the closest route location</para>
		/// <para>When locating points along routes, it is possible that more than one route may be within the search radius of any given point. This parameter is ignored when locating lines or polygons along routes.</para>
		/// <para>Checked—Only the closest route location will be written to the output event table. This is the default.</para>
		/// <para>Unchecked—Every route location (within the search radius) will be written to the output event table.</para>
		/// <para><see cref="RouteLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RouteLocations { get; set; } = "true";

		/// <summary>
		/// <para>Include distance field on output table</para>
		/// <para>Specifies whether a field named DISTANCE will be added to the output event table. The values in this field are in the units of the specified search radius. This parameter is ignored when locating lines or polygons along routes.</para>
		/// <para>Checked—A field containing the point-to-route distance will be added to the output event table. This is the default.</para>
		/// <para>Unchecked—A field containing the point-to-route distance will not be added to the output event table.</para>
		/// <para><see cref="DistanceFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DistanceField { get; set; } = "true";

		/// <summary>
		/// <para>Keep zero length line events</para>
		/// <para>When locating polygons along routes, it is possible that events can be created where the from-measure is equal to the to-measure. This parameter is ignored when locating points or lines along routes.</para>
		/// <para>Checked—Zero-length line events will be written to the output event table. This is the default.</para>
		/// <para>Unchecked—Zero-length line events will not be written to the output event table.</para>
		/// <para><see cref="ZeroLengthEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ZeroLengthEvents { get; set; } = "true";

		/// <summary>
		/// <para>Include all fields from input</para>
		/// <para>Specifies whether the output event table will contain route location fields plus all the attributes from the input features.</para>
		/// <para>Checked—The output event table will contain route location fields plus all the attributes from the input features. This is the default.</para>
		/// <para>Unchecked—The output event table will only contain route location fields plus the ObjectID field from the input features.</para>
		/// <para><see cref="InFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InFields { get; set; } = "true";

		/// <summary>
		/// <para>Use M direction offsetting</para>
		/// <para>Specifies whether the offset distance calculated should be based on the M direction or the digitized direction. Distances are included in the output event table if Include distance field on output table is checked.</para>
		/// <para>Checked—The distance values in the output event table will be calculated based on the routes&apos; M direction. Input features to the left of the M direction of the route will be assigned a positive offset (+), and features to the right of the M direction will be assigned a negative offset value (-). This is the default.</para>
		/// <para>Unchecked—The distance values in the output event table will be calculated based on the routes&apos; digitized direction. Input features to the left of the digitized direction of the route will be assigned a negative (-) offset, and features to the right of the digitized direction will be assigned a positive offset value (+).</para>
		/// <para><see cref="MDirectionOffsettingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MDirectionOffsetting { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateFeaturesAlongRoutes SetEnviroment(object configKeyword = null , object extent = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep only the closest route location</para>
		/// </summary>
		public enum RouteLocationsEnum 
		{
			/// <summary>
			/// <para>Checked—Only the closest route location will be written to the output event table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIRST")]
			FIRST,

			/// <summary>
			/// <para>Unchecked—Every route location (within the search radius) will be written to the output event table.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Include distance field on output table</para>
		/// </summary>
		public enum DistanceFieldEnum 
		{
			/// <summary>
			/// <para>Checked—A field containing the point-to-route distance will be added to the output event table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISTANCE")]
			DISTANCE,

			/// <summary>
			/// <para>Unchecked—A field containing the point-to-route distance will not be added to the output event table.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISTANCE")]
			NO_DISTANCE,

		}

		/// <summary>
		/// <para>Keep zero length line events</para>
		/// </summary>
		public enum ZeroLengthEventsEnum 
		{
			/// <summary>
			/// <para>Checked—Zero-length line events will be written to the output event table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ZERO")]
			ZERO,

			/// <summary>
			/// <para>Unchecked—Zero-length line events will not be written to the output event table.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ZERO")]
			NO_ZERO,

		}

		/// <summary>
		/// <para>Include all fields from input</para>
		/// </summary>
		public enum InFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—The output event table will contain route location fields plus all the attributes from the input features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIELDS")]
			FIELDS,

			/// <summary>
			/// <para>Unchecked—The output event table will only contain route location fields plus the ObjectID field from the input features.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIELDS")]
			NO_FIELDS,

		}

		/// <summary>
		/// <para>Use M direction offsetting</para>
		/// </summary>
		public enum MDirectionOffsettingEnum 
		{
			/// <summary>
			/// <para>Checked—The distance values in the output event table will be calculated based on the routes&apos; M direction. Input features to the left of the M direction of the route will be assigned a positive offset (+), and features to the right of the M direction will be assigned a negative offset value (-). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("M_DIRECTON")]
			M_DIRECTON,

			/// <summary>
			/// <para>Unchecked—The distance values in the output event table will be calculated based on the routes&apos; digitized direction. Input features to the left of the digitized direction of the route will be assigned a negative (-) offset, and features to the right of the digitized direction will be assigned a positive offset value (+).</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_M_DIRECTION")]
			NO_M_DIRECTION,

		}

#endregion
	}
}
