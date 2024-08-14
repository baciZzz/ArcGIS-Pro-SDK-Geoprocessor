using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Generate Floor Transitions</para>
	/// <para>Creates or updates transition line features that connect floors vertically.</para>
	/// </summary>
	public class GenerateFloorTransitions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FacilityFeatures">
		/// <para>Input Facility Features</para>
		/// <para>The input polygon features representing a facility or facilities. In the Indoors model, this is the Facilities layer. The tool processes only the facilities represented by these features.</para>
		/// </param>
		/// <param name="TransitionUnitFeatures">
		/// <para>Transition Unit Features</para>
		/// <para>The input polygon features representing the transition spaces in a facility. In the Indoors model, this is the Units layer.</para>
		/// </param>
		/// <param name="PathwayFeatures">
		/// <para>Pathway Features</para>
		/// <para>The input polyline features representing preliminary pathways. The new transition features will snap to these polyline features. In the Indoors model, this will be the PrelimPathways layer.</para>
		/// </param>
		/// <param name="TargetTransitions">
		/// <para>Target Transitions</para>
		/// <para>An existing feature class or layer that will be updated with the new transitions. In the Indoors model, this is the PrelimTransitions layer.</para>
		/// </param>
		public GenerateFloorTransitions(object FacilityFeatures, object TransitionUnitFeatures, object PathwayFeatures, object TargetTransitions)
		{
			this.FacilityFeatures = FacilityFeatures;
			this.TransitionUnitFeatures = TransitionUnitFeatures;
			this.PathwayFeatures = PathwayFeatures;
			this.TargetTransitions = TargetTransitions;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Floor Transitions</para>
		/// </summary>
		public override string DisplayName => "Generate Floor Transitions";

		/// <summary>
		/// <para>Tool Name : GenerateFloorTransitions</para>
		/// </summary>
		public override string ToolName => "GenerateFloorTransitions";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateFloorTransitions</para>
		/// </summary>
		public override string ExcuteName => "indoors.GenerateFloorTransitions";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { FacilityFeatures, TransitionUnitFeatures, PathwayFeatures, TargetTransitions, ElevatorDelay, DeleteExistingTransitions, StairwayUnitExp, ElevatorUnitExp, UpdatedTransitions };

		/// <summary>
		/// <para>Input Facility Features</para>
		/// <para>The input polygon features representing a facility or facilities. In the Indoors model, this is the Facilities layer. The tool processes only the facilities represented by these features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object FacilityFeatures { get; set; }

		/// <summary>
		/// <para>Transition Unit Features</para>
		/// <para>The input polygon features representing the transition spaces in a facility. In the Indoors model, this is the Units layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TransitionUnitFeatures { get; set; }

		/// <summary>
		/// <para>Pathway Features</para>
		/// <para>The input polyline features representing preliminary pathways. The new transition features will snap to these polyline features. In the Indoors model, this will be the PrelimPathways layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object PathwayFeatures { get; set; }

		/// <summary>
		/// <para>Target Transitions</para>
		/// <para>An existing feature class or layer that will be updated with the new transitions. In the Indoors model, this is the PrelimTransitions layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetTransitions { get; set; }

		/// <summary>
		/// <para>Elevator Delay</para>
		/// <para>The average elevator transit time. It is one-half the time in seconds that an elevator passenger can expect to spend waiting to enter and exit the elevator. Using this parameter can improve routing and transit time calculations. The value must be equal to or greater than zero.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object ElevatorDelay { get; set; }

		/// <summary>
		/// <para>Delete Existing Transitions</para>
		/// <para>Specifies whether existing transition features in selected transition spaces will be deleted before creating new transition features. If this parameter is not used, Updated Transitions will include both existing and newly created transition features.</para>
		/// <para>Checked—Existing transition features will be deleted. This is the default.</para>
		/// <para>Unchecked—Existing transition features will not be deleted.</para>
		/// <para><see cref="DeleteExistingTransitionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteExistingTransitions { get; set; } = "true";

		/// <summary>
		/// <para>Stairway Unit Expression</para>
		/// <para>An SQL expression used to define which Transition Unit Features values represent step-based transitions, such as stairs and escalators.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object StairwayUnitExp { get; set; }

		/// <summary>
		/// <para>Elevator Unit Expression</para>
		/// <para>An SQL expression used to define which Transition Unit Features values represent lift-based transitions, such as elevators.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object ElevatorUnitExp { get; set; }

		/// <summary>
		/// <para>Updated Transitions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object UpdatedTransitions { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Delete Existing Transitions</para>
		/// </summary>
		public enum DeleteExistingTransitionsEnum 
		{
			/// <summary>
			/// <para>Checked—Existing transition features will be deleted. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_FEATURES")]
			DELETE_FEATURES,

			/// <summary>
			/// <para>Unchecked—Existing transition features will not be deleted.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_FEATURES")]
			NO_DELETE_FEATURES,

		}

#endregion
	}
}
