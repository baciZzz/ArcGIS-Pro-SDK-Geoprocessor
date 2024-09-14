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
	/// <para>Derive Event Measures</para>
	/// <para>Derive Event Measures</para>
	/// <para>Populates and updates the DerivedRouteID field and measure values on point and line events with those fields configured and enabled.</para>
	/// </summary>
	public class DeriveEventMeasures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The LRS Network containing the events with DerivedRouteID and measure fields configured.</para>
		/// </param>
		public DeriveEventMeasures(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Derive Event Measures</para>
		/// </summary>
		public override string DisplayName() => "Derive Event Measures";

		/// <summary>
		/// <para>Tool Name : DeriveEventMeasures</para>
		/// </summary>
		public override string ToolName() => "DeriveEventMeasures";

		/// <summary>
		/// <para>Tool Excute Name : locref.DeriveEventMeasures</para>
		/// </summary>
		public override string ExcuteName() => "locref.DeriveEventMeasures";

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
		public override object[] Parameters() => new object[] { InRouteFeatures, UpdateAllEvents, EventLayers, OutEvents, OutDetailsFile };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The LRS Network containing the events with DerivedRouteID and measure fields configured.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Update all event feature classes registered in the selected network</para>
		/// <para>Determines whether all event feature classes in the network will be updated.</para>
		/// <para>Checked—Updates all events in the network selected in Input Route Features. This is the default.</para>
		/// <para>Unchecked—Does not update all events in the network selected in Input Route Features. Allows the user to select individual event layers in the event layers parameter below.</para>
		/// <para><see cref="UpdateAllEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateAllEvents { get; set; } = "true";

		/// <summary>
		/// <para>Event Layers</para>
		/// <para>The event layers that will have DerivedRouteID and measure fields updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object EventLayers { get; set; }

		/// <summary>
		/// <para>Output Events</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutEvents { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeriveEventMeasures SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update all event feature classes registered in the selected network</para>
		/// </summary>
		public enum UpdateAllEventsEnum 
		{
			/// <summary>
			/// <para>Checked—Updates all events in the network selected in Input Route Features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_ALL")]
			UPDATE_ALL,

			/// <summary>
			/// <para>Unchecked—Does not update all events in the network selected in Input Route Features. Allows the user to select individual event layers in the event layers parameter below.</para>
			/// </summary>
			[GPValue("false")]
			[Description("UPDATE_SOME")]
			UPDATE_SOME,

		}

#endregion
	}
}
