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
	/// <para>Modify LRS Event</para>
	/// <para>Modify LRS Event</para>
	/// <para>Modifies properties of a linear referencing system (LRS) event.</para>
	/// </summary>
	public class ModifyLRSEvent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Event Feature Class</para>
		/// <para>The input feature class or feature layer for the event.</para>
		/// </param>
		public ModifyLRSEvent(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Modify LRS Event</para>
		/// </summary>
		public override string DisplayName() => "Modify LRS Event";

		/// <summary>
		/// <para>Tool Name : ModifyLRSEvent</para>
		/// </summary>
		public override string ToolName() => "ModifyLRSEvent";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRSEvent</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRSEvent";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, EventIdField!, RouteIdField!, FromDateField!, ToDateField!, LocErrorField!, MeasureField!, ToMeasureField!, EventSpansRoutes!, ToRouteIdField!, StoreRouteName!, RouteNameField!, ToRouteNameField!, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Event Feature Class</para>
		/// <para>The input feature class or feature layer for the event.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>Name of the event ID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? EventIdField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>Name of the route ID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? RouteIdField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>Name of the from date field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>Name of the to date field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ToDateField { get; set; }

		/// <summary>
		/// <para>Location Error Field</para>
		/// <para>Name of the location error field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? LocErrorField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>Name of the measure field if it is a point event or from measure field if it is a line event.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? MeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>Name of the to measure field. Required only for line events.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// <para>Determines if the event records will span routes.</para>
		/// <para>AS_IS—No change to the property. This is the default.</para>
		/// <para>NO_SPANS_ROUTES—The event records do not span routes. Applicable only for line events.</para>
		/// <para>SPANS_ROUTES— The event records may span routes. Applicable only for line events.</para>
		/// <para><see cref="EventSpansRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EventSpansRoutes { get; set; } = "AS_IS";

		/// <summary>
		/// <para>To Route ID Field</para>
		/// <para>Name of the to route ID field. Required only if it is a line event and it spans routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? ToRouteIdField { get; set; }

		/// <summary>
		/// <para>Store Route Name</para>
		/// <para>Determines if the event records will store the route name.</para>
		/// <para>AS_IS—No change to the property. This is the default.</para>
		/// <para>STORE_ROUTE_NAME—Stores the route name with the event records.</para>
		/// <para>NO_STORE_ROUTE_NAME—Does not store the route name with the event records.</para>
		/// <para><see cref="StoreRouteNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StoreRouteName { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>The route name field if it is a point event that does not span routes, or the from route name field if it is a line event that spans routes. Required if Store Route Name is enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>Name of the to route name field. Required if it is a line event, Store Route Name is chosen, and it spans routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Updated LRS Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// </summary>
		public enum EventSpansRoutesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_SPANS_ROUTES")]
			[Description("Do not span routes")]
			Do_not_span_routes,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_STORE_ROUTE_NAME")]
			[Description("Do not store route name")]
			Do_not_store_route_name,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("STORE_ROUTE_NAME")]
			[Description("Store route name")]
			Store_route_name,

		}

#endregion
	}
}
