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
	/// <para>Generate Indoor Pathways</para>
	/// <para>Generate Indoor Pathways</para>
	/// <para>Generates preliminary pathways that are cut according to obstructions, such as walls or columns, on selected levels in one or more facilities.</para>
	/// </summary>
	public class GenerateIndoorPathways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLevelFeatures">
		/// <para>Input Level Features</para>
		/// <para>The input polygon features representing levels in facilities. In the Indoors model, this will be the Levels layer. The tool honors selections and definition queries applied to the layer.</para>
		/// </param>
		/// <param name="InDetailFeatures">
		/// <para>Input Detail Features</para>
		/// <para>The input polyline features representing architectural details that can serve as barriers to travel within a facility. In the Indoors model, this will be the Details layer</para>
		/// </param>
		/// <param name="TargetPathways">
		/// <para>Target PrelimPathways</para>
		/// <para>The feature class or feature layer to which generated pathway polylines will be written. In the Indoors model, this will be the PrelimPathways layer.</para>
		/// </param>
		public GenerateIndoorPathways(object InLevelFeatures, object InDetailFeatures, object TargetPathways)
		{
			this.InLevelFeatures = InLevelFeatures;
			this.InDetailFeatures = InDetailFeatures;
			this.TargetPathways = TargetPathways;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Indoor Pathways</para>
		/// </summary>
		public override string DisplayName() => "Generate Indoor Pathways";

		/// <summary>
		/// <para>Tool Name : GenerateIndoorPathways</para>
		/// </summary>
		public override string ToolName() => "GenerateIndoorPathways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateIndoorPathways</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateIndoorPathways";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLevelFeatures, InDetailFeatures, TargetPathways, LatticeRotation!, LatticeDensity!, RestrictedUnitFeatures!, RestrictedUnitExp!, DetailExp!, UpdatedPathways! };

		/// <summary>
		/// <para>Input Level Features</para>
		/// <para>The input polygon features representing levels in facilities. In the Indoors model, this will be the Levels layer. The tool honors selections and definition queries applied to the layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InLevelFeatures { get; set; }

		/// <summary>
		/// <para>Input Detail Features</para>
		/// <para>The input polyline features representing architectural details that can serve as barriers to travel within a facility. In the Indoors model, this will be the Details layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InDetailFeatures { get; set; }

		/// <summary>
		/// <para>Target PrelimPathways</para>
		/// <para>The feature class or feature layer to which generated pathway polylines will be written. In the Indoors model, this will be the PrelimPathways layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetPathways { get; set; }

		/// <summary>
		/// <para>Lattice Rotation</para>
		/// <para>The number of degrees by which the input floors&apos; primary travel direction is rotated clockwise from due west. If left blank, the tool will calculate a value based on the minimum bounding rectangle of each floor.</para>
		/// <para>The value must be between 0.0 and 180.0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 180)]
		public object? LatticeRotation { get; set; }

		/// <summary>
		/// <para>Lattice Density</para>
		/// <para>The longest distance, in meters, allowed between nodes in the generated lattice of pathways. The default value is 0.6.</para>
		/// <para>The value must be between 0.25 and 0.9.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.25, Max = 2.8999999999999999)]
		public object? LatticeDensity { get; set; } = "0.6";

		/// <summary>
		/// <para>Restricted Unit Features</para>
		/// <para>The input polygon features representing restricted and unrestricted spaces within a facility. In the Indoors model, this will be the Units layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? RestrictedUnitFeatures { get; set; }

		/// <summary>
		/// <para>Restricted Unit Expression</para>
		/// <para>An SQL expression used to select the Restricted Unit Features parameter values in which the tool will not generate pathways.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? RestrictedUnitExp { get; set; }

		/// <summary>
		/// <para>Detail Expression</para>
		/// <para>An SQL expression used to select the Input Detail Features parameter values across which the tool will not generate pathways.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? DetailExp { get; set; }

		/// <summary>
		/// <para>Updated Pathways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedPathways { get; set; }

	}
}
