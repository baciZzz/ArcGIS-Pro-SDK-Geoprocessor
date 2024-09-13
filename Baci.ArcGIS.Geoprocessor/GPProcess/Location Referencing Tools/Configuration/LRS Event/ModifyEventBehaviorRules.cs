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
	/// <para>Modify Event Behavior Rules</para>
	/// <para>Modify Event Behavior Rules</para>
	/// <para>Modifies event behavior rules for the registered event  layer or feature class.</para>
	/// </summary>
	public class ModifyEventBehaviorRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>The event feature class.</para>
		/// </param>
		public ModifyEventBehaviorRules(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Modify Event Behavior Rules</para>
		/// </summary>
		public override string DisplayName() => "Modify Event Behavior Rules";

		/// <summary>
		/// <para>Tool Name : ModifyEventBehaviorRules</para>
		/// </summary>
		public override string ToolName() => "ModifyEventBehaviorRules";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyEventBehaviorRules</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyEventBehaviorRules";

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
		public override object[] Parameters() => new object[] { InFeatureClass, CalibrateRule!, RetireRule!, ExtendRule!, ReassignRule!, RealignRule!, OutFeatureClass!, ReverseRule!, CartoRealignRule! };

		/// <summary>
		/// <para>Event Feature Class</para>
		/// <para>The event feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// <para>Specifies the event behavior rule that will be defined for the calibrate activity.</para>
		/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire—Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
		/// <para><see cref="CalibrateRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrateRule { get; set; }

		/// <summary>
		/// <para>Retire Rule</para>
		/// <para>Specifies the event behavior rule that will be defined for the retire activity.</para>
		/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire—Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
		/// <para><see cref="RetireRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RetireRule { get; set; }

		/// <summary>
		/// <para>Extend Rule</para>
		/// <para>Specifies the event behavior rule that will be defined for the extend activity.</para>
		/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire—Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
		/// <para>Cover—The geometric location and measure of a line event will be modified to include a new or newly modified section.</para>
		/// <para><see cref="ExtendRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtendRule { get; set; }

		/// <summary>
		/// <para>Reassign Rule</para>
		/// <para>Specifies the event behavior rule that will be defined for the reassign activity.</para>
		/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire—Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
		/// <para>Snap—The geographic location of an event will be preserved by snapping the event to a concurrent route; measures may change.</para>
		/// <para><see cref="ReassignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReassignRule { get; set; }

		/// <summary>
		/// <para>Realign Rule</para>
		/// <para>Specifies the event behavior rule that will be defined for the realign activity.</para>
		/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire—Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
		/// <para>Snap—The geographic location of an event will be preserved by snapping the event to a concurrent route; measures may change.</para>
		/// <para>Cover—The geometric location and measure of a line event will be modified to include a new or newly modified section.</para>
		/// <para><see cref="RealignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RealignRule { get; set; }

		/// <summary>
		/// <para>Updated Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Reverse Rule</para>
		/// <para>Specifies the event behavior rule that will be defined for the reverse activity.</para>
		/// <para>Stay put— The geographic location of the event will be preserved; measures may change. This is the default.</para>
		/// <para>Retire— Both measure and geographic location will be preserved; the event will be retired.</para>
		/// <para>Move— The measures of the event will be preserved; the geographic location may change.</para>
		/// <para><see cref="ReverseRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReverseRule { get; set; }

		/// <summary>
		/// <para>Carto Realign Rule</para>
		/// <para>Specifies the event behavior rule that will be defined for the cartographic realignment activity.</para>
		/// <para>Honor Route Measure—The measure of the event will be preserved or will change proportionally to the route&apos;s measure change. This is the default.</para>
		/// <para>Honor Referent Location—The referent location of the event will be preserved.</para>
		/// <para><see cref="CartoRealignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CartoRealignRule { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyEventBehaviorRules SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// </summary>
		public enum CalibrateRuleEnum 
		{
			/// <summary>
			/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
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
			/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
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
			/// <para>Move—The measures of the event will be preserved; the geographic location may change.</para>
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
			/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
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

			/// <summary>
			/// <para>Cover—The geometric location and measure of a line event will be modified to include a new or newly modified section.</para>
			/// </summary>
			[GPValue("COVER")]
			[Description("Cover")]
			Cover,

		}

		/// <summary>
		/// <para>Reassign Rule</para>
		/// </summary>
		public enum ReassignRuleEnum 
		{
			/// <summary>
			/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
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

			/// <summary>
			/// <para>Snap—The geographic location of an event will be preserved by snapping the event to a concurrent route; measures may change.</para>
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
			/// <para>Stay put—The geographic location of the event will be preserved; measures may change. This is the default.</para>
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

			/// <summary>
			/// <para>Snap—The geographic location of an event will be preserved by snapping the event to a concurrent route; measures may change.</para>
			/// </summary>
			[GPValue("SNAP")]
			[Description("Snap")]
			Snap,

			/// <summary>
			/// <para>Cover—The geometric location and measure of a line event will be modified to include a new or newly modified section.</para>
			/// </summary>
			[GPValue("COVER")]
			[Description("Cover")]
			Cover,

		}

		/// <summary>
		/// <para>Reverse Rule</para>
		/// </summary>
		public enum ReverseRuleEnum 
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
		/// <para>Carto Realign Rule</para>
		/// </summary>
		public enum CartoRealignRuleEnum 
		{
			/// <summary>
			/// <para>Honor Route Measure—The measure of the event will be preserved or will change proportionally to the route&apos;s measure change. This is the default.</para>
			/// </summary>
			[GPValue("HONOR_ROUTE_MEASURE")]
			[Description("Honor Route Measure")]
			Honor_Route_Measure,

			/// <summary>
			/// <para>Honor Referent Location—The referent location of the event will be preserved.</para>
			/// </summary>
			[GPValue("HONOR_REFERENT_LOCATION")]
			[Description("Honor Referent Location")]
			Honor_Referent_Location,

		}

#endregion
	}
}
