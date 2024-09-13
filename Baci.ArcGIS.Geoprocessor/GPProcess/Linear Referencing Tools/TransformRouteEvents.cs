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
	/// <para>Transform Route Events</para>
	/// <para>Transform Route Events</para>
	/// <para>Transforms the measures of events from one route reference to another and writes them to a new event table.</para>
	/// </summary>
	public class TransformRouteEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Event Table</para>
		/// <para>The input event table.</para>
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
		/// <param name="InRoutes">
		/// <para>Source Route Features</para>
		/// <para>The input route features.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Source Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each input route.</para>
		/// </param>
		/// <param name="TargetRoutes">
		/// <para>Target Route Features</para>
		/// <para>The route features to which the input events will be transformed.</para>
		/// </param>
		/// <param name="TargetRouteIdField">
		/// <para>Target Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each target route.</para>
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
		/// <param name="ClusterTolerance">
		/// <para>Cluster Tolerance</para>
		/// <para>The maximum tolerated distance between the input events and the target routes.</para>
		/// </param>
		public TransformRouteEvents(object InTable, object InEventProperties, object InRoutes, object RouteIdField, object TargetRoutes, object TargetRouteIdField, object OutTable, object OutEventProperties, object ClusterTolerance)
		{
			this.InTable = InTable;
			this.InEventProperties = InEventProperties;
			this.InRoutes = InRoutes;
			this.RouteIdField = RouteIdField;
			this.TargetRoutes = TargetRoutes;
			this.TargetRouteIdField = TargetRouteIdField;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
			this.ClusterTolerance = ClusterTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Transform Route Events</para>
		/// </summary>
		public override string DisplayName() => "Transform Route Events";

		/// <summary>
		/// <para>Tool Name : TransformRouteEvents</para>
		/// </summary>
		public override string ToolName() => "TransformRouteEvents";

		/// <summary>
		/// <para>Tool Excute Name : lr.TransformRouteEvents</para>
		/// </summary>
		public override string ExcuteName() => "lr.TransformRouteEvents";

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
		public override object[] Parameters() => new object[] { InTable, InEventProperties, InRoutes, RouteIdField, TargetRoutes, TargetRouteIdField, OutTable, OutEventProperties, ClusterTolerance, InFields! };

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>The input event table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteMeasureEventDomain>")]
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
		/// <para>Source Route Features</para>
		/// <para>The input route features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteDomain>")]
		public object InRoutes { get; set; }

		/// <summary>
		/// <para>Source Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each input route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Target Route Features</para>
		/// <para>The route features to which the input events will be transformed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteDomain>")]
		public object TargetRoutes { get; set; }

		/// <summary>
		/// <para>Target Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each target route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object TargetRouteIdField { get; set; }

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
		/// <para>Cluster Tolerance</para>
		/// <para>The maximum tolerated distance between the input events and the target routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Include all fields from input</para>
		/// <para>Specifies whether the Output Event Table parameter value will contain route location fields plus all the attributes from the input events.</para>
		/// <para>Checked—The Output Event Table parameter value will contain route location fields plus all the attributes from the input events. This is the default.</para>
		/// <para>Unchecked—The Output Event Table parameter value will only contain route location fields plus the ObjectID field from the input events.</para>
		/// <para><see cref="InFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InFields { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransformRouteEvents SetEnviroment(object? configKeyword = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include all fields from input</para>
		/// </summary>
		public enum InFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—The Output Event Table parameter value will contain route location fields plus all the attributes from the input events. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIELDS")]
			FIELDS,

			/// <summary>
			/// <para>Unchecked—The Output Event Table parameter value will only contain route location fields plus the ObjectID field from the input events.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIELDS")]
			NO_FIELDS,

		}

#endregion
	}
}
