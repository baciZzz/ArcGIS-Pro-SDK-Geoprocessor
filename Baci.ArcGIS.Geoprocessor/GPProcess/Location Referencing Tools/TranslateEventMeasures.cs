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
	/// <para>Translate Event Measures</para>
	/// <para>Translates the measures (m-values) of a point or line event layer from one linear referencing method (LRM) to another.</para>
	/// </summary>
	public class TranslateEventMeasures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceEvent">
		/// <para>Source Event Layer</para>
		/// <para>The input event layer to be translated.</para>
		/// </param>
		/// <param name="InTargetRouteFeatures">
		/// <para>Input Target Route Features</para>
		/// <para>The target LRS Network against which the input events will be translated.</para>
		/// </param>
		/// <param name="OutTargetEvent">
		/// <para>Output Event Layer</para>
		/// <para>The output feature class that will contain the translated event features.</para>
		/// </param>
		public TranslateEventMeasures(object InSourceEvent, object InTargetRouteFeatures, object OutTargetEvent)
		{
			this.InSourceEvent = InSourceEvent;
			this.InTargetRouteFeatures = InTargetRouteFeatures;
			this.OutTargetEvent = OutTargetEvent;
		}

		/// <summary>
		/// <para>Tool Display Name : Translate Event Measures</para>
		/// </summary>
		public override string DisplayName() => "Translate Event Measures";

		/// <summary>
		/// <para>Tool Name : TranslateEventMeasures</para>
		/// </summary>
		public override string ToolName() => "TranslateEventMeasures";

		/// <summary>
		/// <para>Tool Excute Name : locref.TranslateEventMeasures</para>
		/// </summary>
		public override string ExcuteName() => "locref.TranslateEventMeasures";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSourceEvent, InTargetRouteFeatures, OutTargetEvent, InConcurrentRouteMatching };

		/// <summary>
		/// <para>Source Event Layer</para>
		/// <para>The input event layer to be translated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InSourceEvent { get; set; }

		/// <summary>
		/// <para>Input Target Route Features</para>
		/// <para>The target LRS Network against which the input events will be translated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InTargetRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Event Layer</para>
		/// <para>The output feature class that will contain the translated event features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTargetEvent { get; set; }

		/// <summary>
		/// <para>Concurrent Route Matching</para>
		/// <para>Specifies the method used to determine which route to translate the event against when concurrent routes exist in the target LRS Network. This parameter is only applied when the location of the event translation on the target LRS Network has concurrent routes (routes that share a location).</para>
		/// <para>Any concurrent route—The input event layer is translated against the first of two or more concurrent routes found in the target LRS Network.</para>
		/// <para>Route with matching RouteID—The Route ID of the source event is compared to the Route IDs of concurrent routes in the target LRS Network. The source event will translate based on Route ID matches in the source event and target network. The Route IDs of the input event and target LRS Network must be an exact match for this method to correctly translate the event. The input event layer must also be a registered LRS event to use this method.</para>
		/// <para>All concurrent routes—The input event is translated against all the concurrent routes at that location in the target LRS Network.</para>
		/// <para><see cref="InConcurrentRouteMatchingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InConcurrentRouteMatching { get; set; } = "ANY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TranslateEventMeasures SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Concurrent Route Matching</para>
		/// </summary>
		public enum InConcurrentRouteMatchingEnum 
		{
			/// <summary>
			/// <para>Any concurrent route—The input event layer is translated against the first of two or more concurrent routes found in the target LRS Network.</para>
			/// </summary>
			[GPValue("ANY")]
			[Description("Any concurrent route")]
			Any_concurrent_route,

			/// <summary>
			/// <para>Route with matching RouteID—The Route ID of the source event is compared to the Route IDs of concurrent routes in the target LRS Network. The source event will translate based on Route ID matches in the source event and target network. The Route IDs of the input event and target LRS Network must be an exact match for this method to correctly translate the event. The input event layer must also be a registered LRS event to use this method.</para>
			/// </summary>
			[GPValue("ROUTE_ID")]
			[Description("Route with matching RouteID")]
			Route_with_matching_RouteID,

			/// <summary>
			/// <para>All concurrent routes—The input event is translated against all the concurrent routes at that location in the target LRS Network.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All concurrent routes")]
			All_concurrent_routes,

		}

#endregion
	}
}
