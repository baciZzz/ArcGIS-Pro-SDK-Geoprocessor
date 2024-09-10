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
	/// <para>Create LRS Event From Existing Dataset</para>
	/// <para>Registers an existing feature class as an LRS event.</para>
	/// </summary>
	public class CreateLRSEventFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>The network to which the event will be registered.</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>The event to be registered.</para>
		/// </param>
		/// <param name="EventIdField">
		/// <para>Event ID Field</para>
		/// <para>The event ID field in the event feature class.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The route ID field if the feature class is a point event that doesn't spans routes or the from route ID field if the feature class is a line event that spans routes.</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>The from date field in the event feature class.</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>The to date field in the event feature class.</para>
		/// </param>
		/// <param name="LocErrorField">
		/// <para>Loc Error Field</para>
		/// <para>The location error field in the event feature class.</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>The measure field if the feature class is a point event or the from measure field if the feature class is a line event.</para>
		/// </param>
		public CreateLRSEventFromExistingDataset(object ParentNetwork, object InFeatureClass, object EventIdField, object RouteIdField, object FromDateField, object ToDateField, object LocErrorField, object MeasureField)
		{
			this.ParentNetwork = ParentNetwork;
			this.InFeatureClass = InFeatureClass;
			this.EventIdField = EventIdField;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.LocErrorField = LocErrorField;
			this.MeasureField = MeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS Event From Existing Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create LRS Event From Existing Dataset";

		/// <summary>
		/// <para>Tool Name : CreateLRSEventFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSEventFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSEventFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSEventFromExistingDataset";

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
		public override object[] Parameters() => new object[] { ParentNetwork, InFeatureClass, EventIdField, RouteIdField, FromDateField, ToDateField, LocErrorField, MeasureField, ToMeasureField, EventSpansRoutes, ToRouteIdField, StoreRouteName, RouteNameField, ToRouteNameField, OutFeatureClass };

		/// <summary>
		/// <para>Parent LRS Network</para>
		/// <para>The network to which the event will be registered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object ParentNetwork { get; set; }

		/// <summary>
		/// <para>Event Feature Class</para>
		/// <para>The event to be registered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>The event ID field in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object EventIdField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The route ID field if the feature class is a point event that doesn't spans routes or the from route ID field if the feature class is a line event that spans routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>The from date field in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>The to date field in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Loc Error Field</para>
		/// <para>The location error field in the event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object LocErrorField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>The measure field if the feature class is a point event or the from measure field if the feature class is a line event.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object MeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>The to measure field in the event feature class. This parameter is required for line events.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object ToMeasureField { get; set; }

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// <para>Specifies whether the event records will span routes.</para>
		/// <para>Checked—The event records will span routes.</para>
		/// <para>Unchecked—The event records will not span routes. This is the default.</para>
		/// <para><see cref="EventSpansRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EventSpansRoutes { get; set; } = "false";

		/// <summary>
		/// <para>To Route ID Field</para>
		/// <para>The to route ID field for events that span routes. This parameter is required if the event feature class geometry type is polyline.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object ToRouteIdField { get; set; }

		/// <summary>
		/// <para>Store Route Name</para>
		/// <para>Specifies whether the route name will be stored with the event records.</para>
		/// <para>Checked—The route name will be stored with the event records.</para>
		/// <para>Unchecked—The route name will not be stored with the event records. This is the default.</para>
		/// <para><see cref="StoreRouteNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object StoreRouteName { get; set; } = "false";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>The route name field if the feature class is a point event that doesn't span routes or the from route name field if the feature class is a line event that spans routes. This parameter is required if Store Route Name is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>The to route name field for line events that span routes. This parameter is required if Store Route Name is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// </summary>
		public enum EventSpansRoutesEnum 
		{
			/// <summary>
			/// <para>Unchecked—The event records will not span routes. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPANS_ROUTES")]
			NO_SPANS_ROUTES,

			/// <summary>
			/// <para>Checked—The event records will span routes.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SPANS_ROUTES")]
			SPANS_ROUTES,

		}

		/// <summary>
		/// <para>Store Route Name</para>
		/// </summary>
		public enum StoreRouteNameEnum 
		{
			/// <summary>
			/// <para>Unchecked—The route name will not be stored with the event records. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STORE_ROUTE_NAME")]
			NO_STORE_ROUTE_NAME,

			/// <summary>
			/// <para>Checked—The route name will be stored with the event records.</para>
			/// </summary>
			[GPValue("true")]
			[Description("STORE_ROUTE_NAME")]
			STORE_ROUTE_NAME,

		}

#endregion
	}
}
