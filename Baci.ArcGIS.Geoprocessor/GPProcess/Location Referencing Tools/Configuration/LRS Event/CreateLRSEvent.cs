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
	/// <para>Create LRS Event</para>
	/// <para>Creates line or point events for an existing LRS Network.</para>
	/// </summary>
	public class CreateLRSEvent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>The network to which the event is registered.</para>
		/// </param>
		/// <param name="EventName">
		/// <para>Event Name</para>
		/// <para>The event to be registered.</para>
		/// </param>
		/// <param name="GeometryType">
		/// <para>Geometry Type</para>
		/// <para>The geometry type of the output event.</para>
		/// <para>Point—The geometry type of the event is Point. This is the default.</para>
		/// <para>Line—The geometry type of the event is Polyline.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </param>
		/// <param name="EventIdField">
		/// <para>Event ID Field</para>
		/// <para>The event ID field available in the event feature class.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>Name of the route ID field if it is a point event that does not span routes, or from route ID field if the event spans routes. The field is available in the event feature class.</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>The from date field available in the event feature class.</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>The to date field available in the event feature class.</para>
		/// </param>
		/// <param name="LocErrorField">
		/// <para>Location Error Field</para>
		/// <para>The location error field available in the event feature class.</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>Name of the measure field if it is a point event or from measure field if it is a line event.</para>
		/// </param>
		public CreateLRSEvent(object ParentNetwork, object EventName, object GeometryType, object EventIdField, object RouteIdField, object FromDateField, object ToDateField, object LocErrorField, object MeasureField)
		{
			this.ParentNetwork = ParentNetwork;
			this.EventName = EventName;
			this.GeometryType = GeometryType;
			this.EventIdField = EventIdField;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.LocErrorField = LocErrorField;
			this.MeasureField = MeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS Event</para>
		/// </summary>
		public override string DisplayName => "Create LRS Event";

		/// <summary>
		/// <para>Tool Name : CreateLRSEvent</para>
		/// </summary>
		public override string ToolName => "CreateLRSEvent";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSEvent</para>
		/// </summary>
		public override string ExcuteName => "locref.CreateLRSEvent";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { ParentNetwork, EventName, GeometryType, EventIdField, RouteIdField, FromDateField, ToDateField, LocErrorField, MeasureField, ToMeasureField!, EventSpansRoutes!, ToRouteIdField!, StoreRouteName!, RouteNameField!, ToRouteNameField!, OutFeatureClass! };

		/// <summary>
		/// <para>Parent LRS Network</para>
		/// <para>The network to which the event is registered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object ParentNetwork { get; set; }

		/// <summary>
		/// <para>Event Name</para>
		/// <para>The event to be registered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EventName { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>The geometry type of the output event.</para>
		/// <para>Point—The geometry type of the event is Point. This is the default.</para>
		/// <para>Line—The geometry type of the event is Polyline.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POINT";

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>The event ID field available in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EventIdField { get; set; } = "EventId";

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>Name of the route ID field if it is a point event that does not span routes, or from route ID field if the event spans routes. The field is available in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteIdField { get; set; } = "RouteId";

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>The from date field available in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromDateField { get; set; } = "FromDate";

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>The to date field available in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToDateField { get; set; } = "ToDate";

		/// <summary>
		/// <para>Location Error Field</para>
		/// <para>The location error field available in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LocErrorField { get; set; } = "LocError";

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>Name of the measure field if it is a point event or from measure field if it is a line event.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object MeasureField { get; set; } = "Measure";

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>Name of the to measure field. Required only for Line events.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// <para>Specifies whether the event records spans routes.</para>
		/// <para>Checked—The event records span routes.</para>
		/// <para>Unchecked—The event records do not span routes. This is the default.</para>
		/// <para><see cref="EventSpansRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EventSpansRoutes { get; set; } = "false";

		/// <summary>
		/// <para>To Route ID Field</para>
		/// <para>Name of the to route ID field. Required only if the geometry type is a line and the Event Spans Routes check box is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ToRouteIdField { get; set; }

		/// <summary>
		/// <para>Store Route Name</para>
		/// <para>Specifies whether the route name should be stored with the event records.</para>
		/// <para>Checked—Stores route name with the event records.</para>
		/// <para>Unchecked—Does not store route name with the event records. This is the default.</para>
		/// <para><see cref="StoreRouteNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? StoreRouteName { get; set; } = "false";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>The route name field if it is a point event that does not span routes, or the from route name field if it is a line event that spans routes. Required if Store Route Name is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>The to route name field for line events that span routes. Required if Store Route Name is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Point—The geometry type of the event is Point. This is the default.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Line—The geometry type of the event is Polyline.</para>
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
			/// <para>Checked—The event records span routes.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SPANS_ROUTES")]
			SPANS_ROUTES,

			/// <summary>
			/// <para>Unchecked—The event records do not span routes. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPANS_ROUTES")]
			NO_SPANS_ROUTES,

		}

		/// <summary>
		/// <para>Store Route Name</para>
		/// </summary>
		public enum StoreRouteNameEnum 
		{
			/// <summary>
			/// <para>Checked—Stores route name with the event records.</para>
			/// </summary>
			[GPValue("true")]
			[Description("STORE_ROUTE_NAME")]
			STORE_ROUTE_NAME,

			/// <summary>
			/// <para>Unchecked—Does not store route name with the event records. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STORE_ROUTE_NAME")]
			NO_STORE_ROUTE_NAME,

		}

#endregion
	}
}
