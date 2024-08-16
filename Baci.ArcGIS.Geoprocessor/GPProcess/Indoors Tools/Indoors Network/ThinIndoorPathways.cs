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
	/// <para>Thin Indoor Pathways</para>
	/// <para>Removes preliminary network pathways that are not needed for routing between selected locations on each level, reducing the network dataset size and improving its route-solving performance.</para>
	/// </summary>
	public class ThinIndoorPathways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLevelFeatures">
		/// <para>Input Level Features</para>
		/// <para>The input polygon features representing a level or levels in one or more facilities. In the ArcGIS Indoors Information Model, this will be the Levels layer. The tool processes only the levels represented by these features.</para>
		/// </param>
		/// <param name="InPathwayFeatures">
		/// <para>Input Pathway Features</para>
		/// <para>The input polyline features representing the preliminary pathways to be thinned. In the Indoors model, this will be the PrelimPathways layer.</para>
		/// </param>
		/// <param name="InTransitionFeatures">
		/// <para>Input Transition Features</para>
		/// <para>The input polyline features representing the preliminary transitions to be thinned. In the Indoors model, this will be the PrelimTransitions layer.</para>
		/// </param>
		/// <param name="RoutableLocations">
		/// <para>Routable Locations</para>
		/// <para>The input point or polygon features representing the locations used to calculate routes. This can be any point or polygon features that conform to the Indoors model, or any floor-aware point or polygon layer that either is configured in the layer's Floors properties or has a LEVEL_ID field that associates the features to the level on which they are located.</para>
		/// </param>
		/// <param name="TargetPathways">
		/// <para>Target Pathways</para>
		/// <para>The existing feature class or feature layer to which the thinned pathways will be added. In the Indoors model, this will be the Pathways layer.</para>
		/// </param>
		/// <param name="TargetTransitions">
		/// <para>Target Transitions</para>
		/// <para>The existing feature class or feature to which thinned transitions will be added. In the Indoors model, this will be the Transitions layer.</para>
		/// </param>
		public ThinIndoorPathways(object InLevelFeatures, object InPathwayFeatures, object InTransitionFeatures, object RoutableLocations, object TargetPathways, object TargetTransitions)
		{
			this.InLevelFeatures = InLevelFeatures;
			this.InPathwayFeatures = InPathwayFeatures;
			this.InTransitionFeatures = InTransitionFeatures;
			this.RoutableLocations = RoutableLocations;
			this.TargetPathways = TargetPathways;
			this.TargetTransitions = TargetTransitions;
		}

		/// <summary>
		/// <para>Tool Display Name : Thin Indoor Pathways</para>
		/// </summary>
		public override string DisplayName => "Thin Indoor Pathways";

		/// <summary>
		/// <para>Tool Name : ThinIndoorPathways</para>
		/// </summary>
		public override string ToolName => "ThinIndoorPathways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ThinIndoorPathways</para>
		/// </summary>
		public override string ExcuteName => "indoors.ThinIndoorPathways";

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
		public override object[] Parameters => new object[] { InLevelFeatures, InPathwayFeatures, InTransitionFeatures, RoutableLocations, TargetPathways, TargetTransitions, SearchTolerance, NeighborSolveCount, UpdatedPathways, UpdatedTransitions };

		/// <summary>
		/// <para>Input Level Features</para>
		/// <para>The input polygon features representing a level or levels in one or more facilities. In the ArcGIS Indoors Information Model, this will be the Levels layer. The tool processes only the levels represented by these features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InLevelFeatures { get; set; }

		/// <summary>
		/// <para>Input Pathway Features</para>
		/// <para>The input polyline features representing the preliminary pathways to be thinned. In the Indoors model, this will be the PrelimPathways layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InPathwayFeatures { get; set; }

		/// <summary>
		/// <para>Input Transition Features</para>
		/// <para>The input polyline features representing the preliminary transitions to be thinned. In the Indoors model, this will be the PrelimTransitions layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InTransitionFeatures { get; set; }

		/// <summary>
		/// <para>Routable Locations</para>
		/// <para>The input point or polygon features representing the locations used to calculate routes. This can be any point or polygon features that conform to the Indoors model, or any floor-aware point or polygon layer that either is configured in the layer's Floors properties or has a LEVEL_ID field that associates the features to the level on which they are located.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object RoutableLocations { get; set; }

		/// <summary>
		/// <para>Target Pathways</para>
		/// <para>The existing feature class or feature layer to which the thinned pathways will be added. In the Indoors model, this will be the Pathways layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetPathways { get; set; }

		/// <summary>
		/// <para>Target Transitions</para>
		/// <para>The existing feature class or feature to which thinned transitions will be added. In the Indoors model, this will be the Transitions layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetTransitions { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The distance, in meters, the tool will search for Routable Locations features near the input pathways. Routable Locations features farther away than this value will not be used for thinning. The default value is 5.The value must be 0 or greater.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object SearchTolerance { get; set; } = "5";

		/// <summary>
		/// <para>Neighbor Solve Count</para>
		/// <para>The number of closest neighboring locations that will be solved when calculating routes between a given location and other routable locations in the facility. The default value is 50.The value must be 1 or greater.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NeighborSolveCount { get; set; } = "50";

		/// <summary>
		/// <para>Updated Pathways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object UpdatedPathways { get; set; }

		/// <summary>
		/// <para>Updated Transitions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object UpdatedTransitions { get; set; }

	}
}
