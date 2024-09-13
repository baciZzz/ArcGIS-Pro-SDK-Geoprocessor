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
	/// <para>Generate Facility Entryways</para>
	/// <para>Generate Facility Entryways</para>
	/// <para>Creates or updates points representing a building's entry or exit locations.</para>
	/// </summary>
	public class GenerateFacilityEntryways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLevelFeatures">
		/// <para>Input Level Features</para>
		/// <para>The input polygon features representing a level or levels in one or more facilities. In the Indoors model, this is the Levels layer. The tool will process only the levels represented by these features.</para>
		/// </param>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing building spaces. In the Indoors model, this is the Units layer. The tool will use these features when identifying exterior edges of a facility.</para>
		/// </param>
		/// <param name="InDoorFeatures">
		/// <para>Input Door Features</para>
		/// <para>The input polyline features representing doors. In the Indoors model, this is a subset of features from the Details layer. The tool will use these features when identifying entryways along the exterior of a facility.The layer must have one or more door features selected for the tool to run. Use the Select Layer By Attribute tool to make a selection.</para>
		/// </param>
		/// <param name="TargetEntryways">
		/// <para>Target Entryways</para>
		/// <para>The feature class or feature layer to which generated entryway points will be written.</para>
		/// </param>
		public GenerateFacilityEntryways(object InLevelFeatures, object InUnitFeatures, object InDoorFeatures, object TargetEntryways)
		{
			this.InLevelFeatures = InLevelFeatures;
			this.InUnitFeatures = InUnitFeatures;
			this.InDoorFeatures = InDoorFeatures;
			this.TargetEntryways = TargetEntryways;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Facility Entryways</para>
		/// </summary>
		public override string DisplayName() => "Generate Facility Entryways";

		/// <summary>
		/// <para>Tool Name : GenerateFacilityEntryways</para>
		/// </summary>
		public override string ToolName() => "GenerateFacilityEntryways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateFacilityEntryways</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateFacilityEntryways";

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
		public override object[] Parameters() => new object[] { InLevelFeatures, InUnitFeatures, InDoorFeatures, TargetEntryways, BufferSize!, EntrywayUseType!, ExteriorUnitExp!, DeleteExistingEntryways!, UpdatedEntryways!, LevelIdField!, UseTypeField! };

		/// <summary>
		/// <para>Input Level Features</para>
		/// <para>The input polygon features representing a level or levels in one or more facilities. In the Indoors model, this is the Levels layer. The tool will process only the levels represented by these features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InLevelFeatures { get; set; }

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing building spaces. In the Indoors model, this is the Units layer. The tool will use these features when identifying exterior edges of a facility.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Input Door Features</para>
		/// <para>The input polyline features representing doors. In the Indoors model, this is a subset of features from the Details layer. The tool will use these features when identifying entryways along the exterior of a facility.The layer must have one or more door features selected for the tool to run. Use the Select Layer By Attribute tool to make a selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InDoorFeatures { get; set; }

		/// <summary>
		/// <para>Target Entryways</para>
		/// <para>The feature class or feature layer to which generated entryway points will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object TargetEntryways { get; set; }

		/// <summary>
		/// <para>Buffer Size</para>
		/// <para>The distance, in meters, the tool will search inward and outward from a facility's exterior edge to identify potential entryways. The default value is 0.5 and must be greater than 0 and less than 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 10)]
		public object? BufferSize { get; set; } = "0.5";

		/// <summary>
		/// <para>Entryway Use Type</para>
		/// <para>The value used to calculate the USE_TYPE field for new entryway points. The default value is Entry.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? EntrywayUseType { get; set; } = "Entry";

		/// <summary>
		/// <para>Exterior Unit Expression</para>
		/// <para>An SQL expression used to define which Input Unit Features values represent a facility's exterior spaces, such as patios or fire escapes. Spaces matching this expression will be treated as exterior features during entryway generation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? ExteriorUnitExp { get; set; }

		/// <summary>
		/// <para>Delete Existing Entryways</para>
		/// <para>Specifies whether existing entryway features with a USE_TYPE field value matching the Entryway Use Type parameter value will be deleted before creating new entryway points. When deleting existing entryways, the tool only identifies entryways on levels included in the Input Level Features parameter.</para>
		/// <para>Checked—Existing features will be deleted.</para>
		/// <para>Unchecked—Existing features will not be deleted. This is the default.</para>
		/// <para><see cref="DeleteExistingEntrywaysEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteExistingEntryways { get; set; } = "false";

		/// <summary>
		/// <para>Updated Entryways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedEntryways { get; set; }

		/// <summary>
		/// <para>Level ID Field</para>
		/// <para>The field that will be updated with the associated level ID for the new entryway features. If the Input Level Features parameter value is a floor-aware layer, this parameter will default to the layer's configured Floor Field value. Otherwise, the parameter will default to the LEVEL_ID field. If the defined field does not exist in the Target Entryways feature layer, a new field with the supplied name will be created and populated with the level ID field values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? LevelIdField { get; set; } = "LEVEL_ID";

		/// <summary>
		/// <para>Use Type Field</para>
		/// <para>The field that will be updated with the Entryway Use Type value for the new entryway features. The default is the USE_TYPE field. If the defined field does not exist in the Target Entryways feature layer, a field with the supplied name will be created and populated with the Entryway Use Type value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? UseTypeField { get; set; } = "USE_TYPE";

		#region InnerClass

		/// <summary>
		/// <para>Delete Existing Entryways</para>
		/// </summary>
		public enum DeleteExistingEntrywaysEnum 
		{
			/// <summary>
			/// <para>Checked—Existing features will be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_FEATURES")]
			DELETE_FEATURES,

			/// <summary>
			/// <para>Unchecked—Existing features will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_FEATURES")]
			NO_DELETE_FEATURES,

		}

#endregion
	}
}
