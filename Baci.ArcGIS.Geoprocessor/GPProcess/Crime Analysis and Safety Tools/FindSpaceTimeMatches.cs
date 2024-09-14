using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Find Space Time Matches</para>
	/// <para>Find Space Time Matches</para>
	/// <para>Identifies matches between two feature classes based on proximity, time extent, or both.</para>
	/// </summary>
	public class FindSpaceTimeMatches : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPrimaryFeatures">
		/// <para>Input Primary Features</para>
		/// <para>The primary input feature class.</para>
		/// </param>
		/// <param name="InComparisonFeatures">
		/// <para>Input Comparison Features</para>
		/// <para>The comparison input feature class.</para>
		/// </param>
		/// <param name="OutPrimaryFeatureClass">
		/// <para>Output Matched Primary Features</para>
		/// <para>The output feature class containing features from the input primary features where output match types occurred.</para>
		/// </param>
		/// <param name="OutComparisonFeatureClass">
		/// <para>Output Matched Comparison Features</para>
		/// <para>The output feature class containing features from input comparison features where output match types occurred.</para>
		/// </param>
		/// <param name="MatchTypes">
		/// <para>Output Match Types</para>
		/// <para>Specifies the types of matches to compare.</para>
		/// <para>Space and time—Matches based on both the time extent and proximity defined in the temporal and spatial search radius will be compared, for example, 25 meters and 10 minutes.</para>
		/// <para>Space only—Matches based only on the proximity defined in the spatial search radius will be compared, for example, 25 meters.</para>
		/// <para>Time only—Matches based only on the time extent defined in the temporal search radius will be compared, for example, 10 minutes.</para>
		/// <para><see cref="MatchTypesEnum"/></para>
		/// </param>
		public FindSpaceTimeMatches(object InPrimaryFeatures, object InComparisonFeatures, object OutPrimaryFeatureClass, object OutComparisonFeatureClass, object MatchTypes)
		{
			this.InPrimaryFeatures = InPrimaryFeatures;
			this.InComparisonFeatures = InComparisonFeatures;
			this.OutPrimaryFeatureClass = OutPrimaryFeatureClass;
			this.OutComparisonFeatureClass = OutComparisonFeatureClass;
			this.MatchTypes = MatchTypes;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Space Time Matches</para>
		/// </summary>
		public override string DisplayName() => "Find Space Time Matches";

		/// <summary>
		/// <para>Tool Name : FindSpaceTimeMatches</para>
		/// </summary>
		public override string ToolName() => "FindSpaceTimeMatches";

		/// <summary>
		/// <para>Tool Excute Name : ca.FindSpaceTimeMatches</para>
		/// </summary>
		public override string ExcuteName() => "ca.FindSpaceTimeMatches";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPrimaryFeatures, InComparisonFeatures, OutPrimaryFeatureClass, OutComparisonFeatureClass, MatchTypes, SearchRadius!, TemporalSearchRadius!, PrimaryStartDateField!, ComparisonStartDateField!, PrimaryEndDateField!, ComparisonEndDateField! };

		/// <summary>
		/// <para>Input Primary Features</para>
		/// <para>The primary input feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InPrimaryFeatures { get; set; }

		/// <summary>
		/// <para>Input Comparison Features</para>
		/// <para>The comparison input feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InComparisonFeatures { get; set; }

		/// <summary>
		/// <para>Output Matched Primary Features</para>
		/// <para>The output feature class containing features from the input primary features where output match types occurred.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPrimaryFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Matched Comparison Features</para>
		/// <para>The output feature class containing features from input comparison features where output match types occurred.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutComparisonFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Match Types</para>
		/// <para>Specifies the types of matches to compare.</para>
		/// <para>Space and time—Matches based on both the time extent and proximity defined in the temporal and spatial search radius will be compared, for example, 25 meters and 10 minutes.</para>
		/// <para>Space only—Matches based only on the proximity defined in the spatial search radius will be compared, for example, 25 meters.</para>
		/// <para>Time only—Matches based only on the time extent defined in the temporal search radius will be compared, for example, 10 minutes.</para>
		/// <para><see cref="MatchTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object MatchTypes { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The radius used to search between input feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Temporal Search Radius</para>
		/// <para>The time extent used to search between input feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TemporalSearchRadius { get; set; }

		/// <summary>
		/// <para>Primary Features Start Date Field</para>
		/// <para>The primary start date and time field of the input primary features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? PrimaryStartDateField { get; set; }

		/// <summary>
		/// <para>Comparison Features Start Date Field</para>
		/// <para>The comparison start date and time field of the input comparison features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ComparisonStartDateField { get; set; }

		/// <summary>
		/// <para>Primary Features End Date Field</para>
		/// <para>The primary end date and time field of the input primary features. When specified, the time range defined by the start and end date and the temporal search radius will be used to search comparison features. The temporal search radius can be set to 0 to compare only the time defined by the feature's time range.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? PrimaryEndDateField { get; set; }

		/// <summary>
		/// <para>Comparison Features End Date Field</para>
		/// <para>The comparison end date and time field of the input comparison features. When specified, the time range defined by the start and end date and the temporal search radius will be used to evaluate relationships with primary features. The temporal search radius can be set to 0 to compare only the time defined by the feature's time range.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ComparisonEndDateField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindSpaceTimeMatches SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, bool? maintainAttachments = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Match Types</para>
		/// </summary>
		public enum MatchTypesEnum 
		{
			/// <summary>
			/// <para>Space and time—Matches based on both the time extent and proximity defined in the temporal and spatial search radius will be compared, for example, 25 meters and 10 minutes.</para>
			/// </summary>
			[GPValue("SPACE_AND_TIME")]
			[Description("Space and time")]
			Space_and_time,

			/// <summary>
			/// <para>Space only—Matches based only on the proximity defined in the spatial search radius will be compared, for example, 25 meters.</para>
			/// </summary>
			[GPValue("SPACE_ONLY")]
			[Description("Space only")]
			Space_only,

			/// <summary>
			/// <para>Time only—Matches based only on the time extent defined in the temporal search radius will be compared, for example, 10 minutes.</para>
			/// </summary>
			[GPValue("TIME_ONLY")]
			[Description("Time only")]
			Time_only,

		}

#endregion
	}
}
