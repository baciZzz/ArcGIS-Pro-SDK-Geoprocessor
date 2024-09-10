using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Configure External Event With LRS</para>
	/// <para>Associates event data stored in an external system with an LRS.</para>
	/// </summary>
	public class ConfigureExternalEventWithLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InEvent">
		/// <para>Input Event</para>
		/// <para>The external event feature class or table to be registered to an LRS.</para>
		/// </param>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>The LRS Network to which the event will be registered.</para>
		/// </param>
		/// <param name="EventName">
		/// <para>LRS Event Name</para>
		/// <para>The name of the external event or table that will be registered to the LRS.</para>
		/// </param>
		/// <param name="EventIdField">
		/// <para>Event ID Field</para>
		/// <para>The event ID field available in the event feature class or table.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The name of the route ID field if it is a point event or a line event that does not span routes, or the name of the from route ID field if the event spans routes. The field must be available in the external event table or feature class.</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>The name of the measure field if it is a point event or the name of the from measure field if it is a line event.</para>
		/// </param>
		public ConfigureExternalEventWithLRS(object InEvent, object ParentNetwork, object EventName, object EventIdField, object RouteIdField, object MeasureField)
		{
			this.InEvent = InEvent;
			this.ParentNetwork = ParentNetwork;
			this.EventName = EventName;
			this.EventIdField = EventIdField;
			this.RouteIdField = RouteIdField;
			this.MeasureField = MeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : Configure External Event With LRS</para>
		/// </summary>
		public override string DisplayName() => "Configure External Event With LRS";

		/// <summary>
		/// <para>Tool Name : ConfigureExternalEventWithLRS</para>
		/// </summary>
		public override string ToolName() => "ConfigureExternalEventWithLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.ConfigureExternalEventWithLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.ConfigureExternalEventWithLRS";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InEvent, ParentNetwork, EventName, EventIdField, RouteIdField, MeasureField, GeometryType, ToMeasureField, FromDateField, ToDateField, EventSpansRoutes, ToRouteIdField, StoreRouteName, RouteNameField, ToRouteNameField, CalibrateRule, RetireRule, ExtendRule, ReassignRule, RealignRule, OutExternalEventTable };

		/// <summary>
		/// <para>Input Event</para>
		/// <para>The external event feature class or table to be registered to an LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InEvent { get; set; }

		/// <summary>
		/// <para>Parent LRS Network</para>
		/// <para>The LRS Network to which the event will be registered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object ParentNetwork { get; set; }

		/// <summary>
		/// <para>LRS Event Name</para>
		/// <para>The name of the external event or table that will be registered to the LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EventName { get; set; }

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>The event ID field available in the event feature class or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object EventIdField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The name of the route ID field if it is a point event or a line event that does not span routes, or the name of the from route ID field if the event spans routes. The field must be available in the external event table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>The name of the measure field if it is a point event or the name of the from measure field if it is a line event.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object MeasureField { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>Specifies the geometry type of the external event or table.</para>
		/// <para>Point— The geometry type of the event will be point. This is the default.</para>
		/// <para>Line— The geometry type of the event will be polyline.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POINT";

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>The name of the to measure field. A field is only required for line events.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object ToMeasureField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>The from date field in the event feature class or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>The to date field in the event feature class or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// <para>Specifies whether the event records will span routes.</para>
		/// <para>As is—The property will not change. This is the default.</para>
		/// <para>Do not span routes—The event records will not span routes. This is applicable to line events only.</para>
		/// <para>Spans routes— The event records will span routes. This is applicable to line events only.</para>
		/// <para><see cref="EventSpansRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EventSpansRoutes { get; set; } = "AS_IS";

		/// <summary>
		/// <para>To Route ID Field</para>
		/// <para>The name of the to route ID field available in the event feature class or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object ToRouteIdField { get; set; }

		/// <summary>
		/// <para>Store Route Name</para>
		/// <para>Specifies whether the route name will be stored with the event records.</para>
		/// <para>As is—The property will not change. This is the default.</para>
		/// <para>Do not store route name—The route name will not be stored with the event records.</para>
		/// <para>Store route name—The route name will be stored with the event records.</para>
		/// <para><see cref="StoreRouteNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StoreRouteName { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>The route name field if it is a point event or line event that does not span routes, or the name of the from route name field if the event spans routes. The field must be available in the external event table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>The to route name field for line events that span routes. This parameter is required if the Store Route Name and Event Spans Routes parameters are set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// <para>Specifies the event behavior rule for the calibrate activity.</para>
		/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire—Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
		/// <para><see cref="CalibrateRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object CalibrateRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Retire Rule</para>
		/// <para>Specifies the event behavior rule for the retire activity.</para>
		/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
		/// <para><see cref="RetireRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object RetireRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Extend Rule</para>
		/// <para>Specifies the event behavior rule for the extend activity.</para>
		/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
		/// <para><see cref="ExtendRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object ExtendRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Reassign Rule</para>
		/// <para>Specifies the event behavior rule for the reassign activity.</para>
		/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
		/// <para>Snap— The geographic location of the event will be preserved by snapping the event to a concurrent route; measures may change.</para>
		/// <para><see cref="ReassignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object ReassignRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Realign Rule</para>
		/// <para>Specifies the event behavior rule for the realign activity.</para>
		/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
		/// <para><see cref="RealignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object RealignRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Output External Event Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutExternalEventTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Point— The geometry type of the event will be point. This is the default.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Line— The geometry type of the event will be polyline.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

		}

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// </summary>
		public enum EventSpansRoutesEnum 
		{
			/// <summary>
			/// <para>As is—The property will not change. This is the default.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para>Do not span routes—The event records will not span routes. This is applicable to line events only.</para>
			/// </summary>
			[GPValue("NO_SPANS_ROUTES")]
			[Description("Do not span routes")]
			Do_not_span_routes,

			/// <summary>
			/// <para>Spans routes— The event records will span routes. This is applicable to line events only.</para>
			/// </summary>
			[GPValue("SPANS_ROUTES")]
			[Description("Spans routes")]
			Spans_routes,

		}

		/// <summary>
		/// <para>Store Route Name</para>
		/// </summary>
		public enum StoreRouteNameEnum 
		{
			/// <summary>
			/// <para>As is—The property will not change. This is the default.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para>Do not store route name—The route name will not be stored with the event records.</para>
			/// </summary>
			[GPValue("NO_STORE_ROUTE_NAME")]
			[Description("Do not store route name")]
			Do_not_store_route_name,

			/// <summary>
			/// <para>Store route name—The route name will be stored with the event records.</para>
			/// </summary>
			[GPValue("STORE_ROUTE_NAME")]
			[Description("Store route name")]
			Store_route_name,

		}

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// </summary>
		public enum CalibrateRuleEnum 
		{
			/// <summary>
			/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("Stay put")]
			Stay_put,

			/// <summary>
			/// <para>Retire—Both measure and geographic location will be preserved; the event will be retired.</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("Retire")]
			Retire,

			/// <summary>
			/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("Move")]
			Move,

		}

		/// <summary>
		/// <para>Retire Rule</para>
		/// </summary>
		public enum RetireRuleEnum 
		{
			/// <summary>
			/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("Stay put")]
			Stay_put,

			/// <summary>
			/// <para>Retire Rule</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("Retire")]
			Retire,

			/// <summary>
			/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("Move")]
			Move,

		}

		/// <summary>
		/// <para>Extend Rule</para>
		/// </summary>
		public enum ExtendRuleEnum 
		{
			/// <summary>
			/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("Stay put")]
			Stay_put,

			/// <summary>
			/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("Retire")]
			Retire,

			/// <summary>
			/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("Move")]
			Move,

		}

		/// <summary>
		/// <para>Reassign Rule</para>
		/// </summary>
		public enum ReassignRuleEnum 
		{
			/// <summary>
			/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("Stay put")]
			Stay_put,

			/// <summary>
			/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("Retire")]
			Retire,

			/// <summary>
			/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("Move")]
			Move,

			/// <summary>
			/// <para>Snap— The geographic location of the event will be preserved by snapping the event to a concurrent route; measures may change.</para>
			/// </summary>
			[GPValue("SNAP")]
			[Description("Snap")]
			Snap,

		}

		/// <summary>
		/// <para>Realign Rule</para>
		/// </summary>
		public enum RealignRuleEnum 
		{
			/// <summary>
			/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("Stay put")]
			Stay_put,

			/// <summary>
			/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("Retire")]
			Retire,

			/// <summary>
			/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("Move")]
			Move,

		}

#endregion
	}
}
