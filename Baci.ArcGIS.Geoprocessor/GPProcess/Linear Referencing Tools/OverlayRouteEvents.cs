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
	/// <para>Overlay Route Events</para>
	/// <para>Overlays two event tables to create an output event table that represents the union or intersection of the input.</para>
	/// </summary>
	public class OverlayRouteEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Event Table</para>
		/// <para>The input event table.</para>
		/// </param>
		/// <param name="InEventProperties">
		/// <para>Input Event Table Properties</para>
		/// <para>Parameter consisting of the route location fields and the type of events in the input event table.</para>
		/// <para>Route Identifier Field—The field containing values that indicate the route on which each event is located. This field can be numeric or character.</para>
		/// <para>Event Type—The type of events in the input event table (POINT or LINE).</para>
		/// <para>POINT—Point events occur at a precise location along a route. Only a from-measure field must be specified.</para>
		/// <para>LINE—Line events define a portion of a route. Both from- and to-measure fields must be specified.</para>
		/// <para>From-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is POINT or LINE. Note when the Event Type is POINT, the label for this parameter becomes Measure Field.</para>
		/// <para>To-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is LINE.</para>
		/// </param>
		/// <param name="OverlayTable">
		/// <para>Overlay Event Table</para>
		/// <para>The overlay event table.</para>
		/// </param>
		/// <param name="OverlayEventProperties">
		/// <para>Overlay Event Table Properties</para>
		/// <para>Parameter consisting of the route location fields and the type of events in the overlay event table.</para>
		/// <para>Route Identifier Field—The field containing values that indicate which route each event is along. This field can be numeric or character.</para>
		/// <para>Event Type—The type of events in the overlay event table (POINT or LINE).</para>
		/// <para>POINT—Point events occur at a precise location along a route. Only a from-measure field must be specified.</para>
		/// <para>LINE—Line events define a portion of a route. Both from- and to-measure fields must be specified.</para>
		/// <para>From-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is POINT or LINE. Note when the Event Type is POINT the label for this parameter becomes &quot;Measure Field&quot;.</para>
		/// <para>To-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is LINE.</para>
		/// </param>
		/// <param name="OverlayType">
		/// <para>Type of Overlay</para>
		/// <para>The type of overlay to be performed.</para>
		/// <para>Intersect—Writes only overlapping events to the output event table. This is the default.</para>
		/// <para>Union—Writes all events to the output table. Linear events are split at their intersections.</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
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
		public OverlayRouteEvents(object InTable, object InEventProperties, object OverlayTable, object OverlayEventProperties, object OverlayType, object OutTable, object OutEventProperties)
		{
			this.InTable = InTable;
			this.InEventProperties = InEventProperties;
			this.OverlayTable = OverlayTable;
			this.OverlayEventProperties = OverlayEventProperties;
			this.OverlayType = OverlayType;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : Overlay Route Events</para>
		/// </summary>
		public override string DisplayName() => "Overlay Route Events";

		/// <summary>
		/// <para>Tool Name : OverlayRouteEvents</para>
		/// </summary>
		public override string ToolName() => "OverlayRouteEvents";

		/// <summary>
		/// <para>Tool Excute Name : lr.OverlayRouteEvents</para>
		/// </summary>
		public override string ExcuteName() => "lr.OverlayRouteEvents";

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
		public override object[] Parameters() => new object[] { InTable, InEventProperties, OverlayTable, OverlayEventProperties, OverlayType, OutTable, OutEventProperties, ZeroLengthEvents, InFields, BuildIndex };

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>The input event table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteMeasureEventDomain>")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Event Table Properties</para>
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
		/// <para>Overlay Event Table</para>
		/// <para>The overlay event table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteMeasureEventDomain>")]
		public object OverlayTable { get; set; }

		/// <summary>
		/// <para>Overlay Event Table Properties</para>
		/// <para>Parameter consisting of the route location fields and the type of events in the overlay event table.</para>
		/// <para>Route Identifier Field—The field containing values that indicate which route each event is along. This field can be numeric or character.</para>
		/// <para>Event Type—The type of events in the overlay event table (POINT or LINE).</para>
		/// <para>POINT—Point events occur at a precise location along a route. Only a from-measure field must be specified.</para>
		/// <para>LINE—Line events define a portion of a route. Both from- and to-measure fields must be specified.</para>
		/// <para>From-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is POINT or LINE. Note when the Event Type is POINT the label for this parameter becomes &quot;Measure Field&quot;.</para>
		/// <para>To-Measure Field—A field containing measure values. This field must be numeric and is required when the event type is LINE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object OverlayEventProperties { get; set; }

		/// <summary>
		/// <para>Type of Overlay</para>
		/// <para>The type of overlay to be performed.</para>
		/// <para>Intersect—Writes only overlapping events to the output event table. This is the default.</para>
		/// <para>Union—Writes all events to the output table. Linear events are split at their intersections.</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlayType { get; set; } = "INTERSECT";

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
		/// <para>Keep zero length line events</para>
		/// <para>Specifies whether to keep zero length line events in the output table. This parameter is only valid when the output event type is LINE.</para>
		/// <para>Checked—Keep zero length line events. This is the default.</para>
		/// <para>Unchecked—Do not keep zero length line events.</para>
		/// <para><see cref="ZeroLengthEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ZeroLengthEvents { get; set; } = "true";

		/// <summary>
		/// <para>Include all fields from input</para>
		/// <para>Specifies whether all the fields from the input and overlay event tables will be written to the output event table.</para>
		/// <para>Checked—Includes all the fields from the input tables in the output table. This is the default.</para>
		/// <para>Unchecked—Does not include all the fields from the input tables in the output table. Only the ObjectID and the route location fields are kept.</para>
		/// <para><see cref="InFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InFields { get; set; } = "true";

		/// <summary>
		/// <para>Build index</para>
		/// <para>Specifies whether an attribute index will be created for the route identifier field that is written to the output event table.</para>
		/// <para>Checked—Creates an attribute index. This is the default.</para>
		/// <para>Unchecked—Does not create an attribute index.</para>
		/// <para><see cref="BuildIndexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildIndex { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayRouteEvents SetEnviroment(object configKeyword = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type of Overlay</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>Intersect—Writes only overlapping events to the output event table. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("Intersect")]
			Intersect,

			/// <summary>
			/// <para>Union—Writes all events to the output table. Linear events are split at their intersections.</para>
			/// </summary>
			[GPValue("UNION")]
			[Description("Union")]
			Union,

		}

		/// <summary>
		/// <para>Keep zero length line events</para>
		/// </summary>
		public enum ZeroLengthEventsEnum 
		{
			/// <summary>
			/// <para>Checked—Keep zero length line events. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ZERO")]
			ZERO,

			/// <summary>
			/// <para>Unchecked—Do not keep zero length line events.</para>
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
			/// <para>Checked—Includes all the fields from the input tables in the output table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIELDS")]
			FIELDS,

			/// <summary>
			/// <para>Unchecked—Does not include all the fields from the input tables in the output table. Only the ObjectID and the route location fields are kept.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIELDS")]
			NO_FIELDS,

		}

		/// <summary>
		/// <para>Build index</para>
		/// </summary>
		public enum BuildIndexEnum 
		{
			/// <summary>
			/// <para>Checked—Creates an attribute index. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INDEX")]
			INDEX,

			/// <summary>
			/// <para>Unchecked—Does not create an attribute index.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INDEX")]
			NO_INDEX,

		}

#endregion
	}
}
