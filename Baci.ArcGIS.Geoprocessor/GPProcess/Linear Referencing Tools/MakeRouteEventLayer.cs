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
	/// <para>Make Route Event Layer</para>
	/// <para>Make Route Event Layer</para>
	/// <para>Creates a temporary feature layer using routes and route events.</para>
	/// </summary>
	public class MakeRouteEventLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRoutes">
		/// <para>Input Route Features</para>
		/// <para>The route features upon which events will be located.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route.</para>
		/// </param>
		/// <param name="InTable">
		/// <para>Input Event Table</para>
		/// <para>The table whose rows will be located along routes.</para>
		/// </param>
		/// <param name="InEventProperties">
		/// <para>Event Table Properties</para>
		/// <para>Parameter consisting of the route location fields and the type of events in the input event table.</para>
		/// <para>Route Identifier Field—The field containing values that indicate the route on which each event is located. This field can be numeric or character.</para>
		/// <para>Event Type—The type of events in the input event table (POINT or LINE).</para>
		/// <para>POINT—Point events occur at a precise location along a route. Only a from-measure field must be specified.</para>
		/// <para>LINE—Line events define a portion of a route. Both from- and to-measure fields must be specified.</para>
		/// <para>From-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is POINT or LINE. Note when the Event Type is POINT, the label for this parameter becomes Measure Field.</para>
		/// <para>To-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is LINE.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Layer Name or Table View</para>
		/// <para>The layer to be created. This layer is stored in memory, so a path is not necessary.</para>
		/// </param>
		public MakeRouteEventLayer(object InRoutes, object RouteIdField, object InTable, object InEventProperties, object OutLayer)
		{
			this.InRoutes = InRoutes;
			this.RouteIdField = RouteIdField;
			this.InTable = InTable;
			this.InEventProperties = InEventProperties;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Route Event Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Route Event Layer";

		/// <summary>
		/// <para>Tool Name : MakeRouteEventLayer</para>
		/// </summary>
		public override string ToolName() => "MakeRouteEventLayer";

		/// <summary>
		/// <para>Tool Excute Name : lr.MakeRouteEventLayer</para>
		/// </summary>
		public override string ExcuteName() => "lr.MakeRouteEventLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Linear Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Linear Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : lr</para>
		/// </summary>
		public override string ToolboxAlise() => "lr";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRoutes, RouteIdField, InTable, InEventProperties, OutLayer, OffsetField, AddErrorField, AddAngleField, AngleType, ComplementAngle, OffsetDirection, PointEventType };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The route features upon which events will be located.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteDomain>")]
		public object InRoutes { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>The table whose rows will be located along routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteMeasureEventDomain>")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Event Table Properties</para>
		/// <para>Parameter consisting of the route location fields and the type of events in the input event table.</para>
		/// <para>Route Identifier Field—The field containing values that indicate the route on which each event is located. This field can be numeric or character.</para>
		/// <para>Event Type—The type of events in the input event table (POINT or LINE).</para>
		/// <para>POINT—Point events occur at a precise location along a route. Only a from-measure field must be specified.</para>
		/// <para>LINE—Line events define a portion of a route. Both from- and to-measure fields must be specified.</para>
		/// <para>From-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is POINT or LINE. Note when the Event Type is POINT, the label for this parameter becomes Measure Field.</para>
		/// <para>To-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is LINE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object InEventProperties { get; set; }

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>The layer to be created. This layer is stored in memory, so a path is not necessary.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Offset Field</para>
		/// <para>The field containing values used to offset events from their underlying route. This field must be numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object OffsetField { get; set; }

		/// <summary>
		/// <para>Generate a field for locating errors</para>
		/// <para>Specifies whether a field named LOC_ERROR will be added to the temporary layer that is created.</para>
		/// <para>Unchecked—Do not add a field to store locating errors. This is the default.</para>
		/// <para>Checked—Add a field to store locating errors.</para>
		/// <para><see cref="AddErrorFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddErrorField { get; set; } = "false";

		/// <summary>
		/// <para>Generate an angle field</para>
		/// <para>Specifies whether a field named LOC_ANGLE will be added to the temporary layer that is created. This parameter is only valid when the event type is POINT.</para>
		/// <para>Unchecked—Do not add a field to store locating angles. This is the default.</para>
		/// <para>Checked—Add a field to store locating angles.</para>
		/// <para><see cref="AddAngleFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddAngleField { get; set; } = "false";

		/// <summary>
		/// <para>Calculated Angle Type</para>
		/// <para>Specifies the type of locating angle that will be calculated. This parameter is only valid if Generate an angle field is checked.</para>
		/// <para>Normal—The normal (perpendicular) angle will be calculated. This is the default.</para>
		/// <para>Tangent—The tangent angle will be calculated.</para>
		/// <para><see cref="AngleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AngleType { get; set; } = "NORMAL";

		/// <summary>
		/// <para>Write the complement of the angle to the angle field</para>
		/// <para>Specifies whether the complement of the locating angle will be calculated. This parameter is only valid if Generate an angle field is checked.</para>
		/// <para>Unchecked—Do not write the complement of the angle. Write only the calculated angle. This is the default.</para>
		/// <para>Checked—Write the complement of the angle.</para>
		/// <para><see cref="ComplementAngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComplementAngle { get; set; } = "false";

		/// <summary>
		/// <para>Events with a positive offset will be placed to the right of the routes</para>
		/// <para>Specifies the side on which the route events with a positive offset are displayed. This parameter is only valid if an offset field has been specified.</para>
		/// <para>Unchecked—Events with a positive offset will be displayed to the left of the route. The side of the route is determined by the measures and not necessarily the digitized direction. This is the default.</para>
		/// <para>Checked—Events with a positive offset will be displayed to the right of the route. The side of the route is determined by the digitized direction.</para>
		/// <para><see cref="OffsetDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OffsetDirection { get; set; } = "false";

		/// <summary>
		/// <para>Point events will be generated as multipoint features</para>
		/// <para>Specifies whether point events will be treated as point features or multipoint features.</para>
		/// <para>Unchecked—Point events will be treated as point features. This is the default.</para>
		/// <para>Checked—Point events will be treated as multipoint features.</para>
		/// <para><see cref="PointEventTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PointEventType { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeRouteEventLayer SetEnviroment(object configKeyword = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate a field for locating errors</para>
		/// </summary>
		public enum AddErrorFieldEnum 
		{
			/// <summary>
			/// <para>Checked—Add a field to store locating errors.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_FIELD")]
			ERROR_FIELD,

			/// <summary>
			/// <para>Unchecked—Do not add a field to store locating errors. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ERROR_FIELD")]
			NO_ERROR_FIELD,

		}

		/// <summary>
		/// <para>Generate an angle field</para>
		/// </summary>
		public enum AddAngleFieldEnum 
		{
			/// <summary>
			/// <para>Checked—Add a field to store locating angles.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE_FIELD")]
			ANGLE_FIELD,

			/// <summary>
			/// <para>Unchecked—Do not add a field to store locating angles. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE_FIELD")]
			NO_ANGLE_FIELD,

		}

		/// <summary>
		/// <para>Calculated Angle Type</para>
		/// </summary>
		public enum AngleTypeEnum 
		{
			/// <summary>
			/// <para>Normal—The normal (perpendicular) angle will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("NORMAL")]
			[Description("Normal")]
			Normal,

			/// <summary>
			/// <para>Tangent—The tangent angle will be calculated.</para>
			/// </summary>
			[GPValue("TANGENT")]
			[Description("Tangent")]
			Tangent,

		}

		/// <summary>
		/// <para>Write the complement of the angle to the angle field</para>
		/// </summary>
		public enum ComplementAngleEnum 
		{
			/// <summary>
			/// <para>Checked—Write the complement of the angle.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPLEMENT")]
			COMPLEMENT,

			/// <summary>
			/// <para>Unchecked—Do not write the complement of the angle. Write only the calculated angle. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ANGLE")]
			ANGLE,

		}

		/// <summary>
		/// <para>Events with a positive offset will be placed to the right of the routes</para>
		/// </summary>
		public enum OffsetDirectionEnum 
		{
			/// <summary>
			/// <para>Checked—Events with a positive offset will be displayed to the right of the route. The side of the route is determined by the digitized direction.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RIGHT")]
			RIGHT,

			/// <summary>
			/// <para>Unchecked—Events with a positive offset will be displayed to the left of the route. The side of the route is determined by the measures and not necessarily the digitized direction. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("LEFT")]
			LEFT,

		}

		/// <summary>
		/// <para>Point events will be generated as multipoint features</para>
		/// </summary>
		public enum PointEventTypeEnum 
		{
			/// <summary>
			/// <para>Checked—Point events will be treated as multipoint features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPOINT")]
			MULTIPOINT,

			/// <summary>
			/// <para>Unchecked—Point events will be treated as point features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("POINT")]
			POINT,

		}

#endregion
	}
}
