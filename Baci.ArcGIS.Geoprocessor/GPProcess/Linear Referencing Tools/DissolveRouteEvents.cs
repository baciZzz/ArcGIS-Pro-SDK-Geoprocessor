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
	/// <para>Dissolve Route Events</para>
	/// <para>Dissolve Route Events</para>
	/// <para>Removes redundant information from event tables or separates event tables having more than one descriptive attribute into individual tables.</para>
	/// </summary>
	public class DissolveRouteEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InEvents">
		/// <para>Input Event Table</para>
		/// <para>The table with the rows that will be aggregated.</para>
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
		/// <param name="DissolveField">
		/// <para>Dissolve Fields</para>
		/// <para>The fields that will be used to aggregate rows.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Event Table</para>
		/// <para>The table that will be created.</para>
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
		public DissolveRouteEvents(object InEvents, object InEventProperties, object DissolveField, object OutTable, object OutEventProperties)
		{
			this.InEvents = InEvents;
			this.InEventProperties = InEventProperties;
			this.DissolveField = DissolveField;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : Dissolve Route Events</para>
		/// </summary>
		public override string DisplayName() => "Dissolve Route Events";

		/// <summary>
		/// <para>Tool Name : DissolveRouteEvents</para>
		/// </summary>
		public override string ToolName() => "DissolveRouteEvents";

		/// <summary>
		/// <para>Tool Excute Name : lr.DissolveRouteEvents</para>
		/// </summary>
		public override string ExcuteName() => "lr.DissolveRouteEvents";

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
		public override object[] Parameters() => new object[] { InEvents, InEventProperties, DissolveField, OutTable, OutEventProperties, DissolveType!, BuildIndex! };

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>The table with the rows that will be aggregated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteMeasureEventDomain>")]
		public object InEvents { get; set; }

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
		/// <para>Dissolve Fields</para>
		/// <para>The fields that will be used to aggregate rows.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object DissolveField { get; set; }

		/// <summary>
		/// <para>Output Event Table</para>
		/// <para>The table that will be created.</para>
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
		/// <para>Combine adjacent events only</para>
		/// <para>Specifies whether the input events will be aggregated or dissolved.</para>
		/// <para>Unchecked—Events will be aggregated wherever there is measure overlap. This is the default.</para>
		/// <para>Checked—Events will be aggregated where the to-measure of one event matches the from-measure of the next event. This option is applicable only for line events.</para>
		/// <para><see cref="DissolveTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DissolveType { get; set; } = "false";

		/// <summary>
		/// <para>Build index</para>
		/// <para>Specifies whether an attribute index will be created for the route identifier field that is written to the output event table.</para>
		/// <para>Checked—An attribute index will be created. This is the default.</para>
		/// <para>Unchecked—An attribute index will not be created.</para>
		/// <para><see cref="BuildIndexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildIndex { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DissolveRouteEvents SetEnviroment(object? configKeyword = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Combine adjacent events only</para>
		/// </summary>
		public enum DissolveTypeEnum 
		{
			/// <summary>
			/// <para>Checked—Events will be aggregated where the to-measure of one event matches the from-measure of the next event. This option is applicable only for line events.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONCATENATE")]
			CONCATENATE,

			/// <summary>
			/// <para>Unchecked—Events will be aggregated wherever there is measure overlap. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISSOLVE")]
			DISSOLVE,

		}

		/// <summary>
		/// <para>Build index</para>
		/// </summary>
		public enum BuildIndexEnum 
		{
			/// <summary>
			/// <para>Checked—An attribute index will be created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INDEX")]
			INDEX,

			/// <summary>
			/// <para>Unchecked—An attribute index will not be created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INDEX")]
			NO_INDEX,

		}

#endregion
	}
}
