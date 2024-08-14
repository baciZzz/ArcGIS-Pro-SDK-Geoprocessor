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
	/// <para>Classify Indoor Pathways</para>
	/// <para>Classifies pathways that pass through selected unit spaces, such as conference rooms or service areas, as lower priority.</para>
	/// </summary>
	public class ClassifyIndoorPathways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing spaces in a building for which the Target Pathways parameter values will be classified. In the ArcGIS Indoors Information Model, this is the Units layer. Select features in the units layer before running the tool.</para>
		/// </param>
		/// <param name="TargetPathways">
		/// <para>Target Pathways</para>
		/// <para>The existing feature class or feature layer in which pathways will be updated. In the Indoors model, this is the Pathways layer.</para>
		/// </param>
		public ClassifyIndoorPathways(object InUnitFeatures, object TargetPathways)
		{
			this.InUnitFeatures = InUnitFeatures;
			this.TargetPathways = TargetPathways;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Indoor Pathways</para>
		/// </summary>
		public override string DisplayName => "Classify Indoor Pathways";

		/// <summary>
		/// <para>Tool Name : ClassifyIndoorPathways</para>
		/// </summary>
		public override string ToolName => "ClassifyIndoorPathways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ClassifyIndoorPathways</para>
		/// </summary>
		public override string ExcuteName => "indoors.ClassifyIndoorPathways";

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
		public override object[] Parameters => new object[] { InUnitFeatures, TargetPathways, UpdatedPathways! };

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing spaces in a building for which the Target Pathways parameter values will be classified. In the ArcGIS Indoors Information Model, this is the Units layer. Select features in the units layer before running the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Target Pathways</para>
		/// <para>The existing feature class or feature layer in which pathways will be updated. In the Indoors model, this is the Pathways layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetPathways { get; set; }

		/// <summary>
		/// <para>Updated Pathways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedPathways { get; set; }

	}
}
