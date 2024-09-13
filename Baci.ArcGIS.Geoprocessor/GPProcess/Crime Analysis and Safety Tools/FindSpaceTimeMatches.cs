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
	/// <para>查找时空匹配</para>
	/// <para>可基于邻域、时间范围或两者来标识两个要素类之间的匹配。</para>
	/// </summary>
	public class FindSpaceTimeMatches : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPrimaryFeatures">
		/// <para>Input Primary Features</para>
		/// <para>主要输入要素类。</para>
		/// </param>
		/// <param name="InComparisonFeatures">
		/// <para>Input Comparison Features</para>
		/// <para>比较输入要素类。</para>
		/// </param>
		/// <param name="OutPrimaryFeatureClass">
		/// <para>Output Matched Primary Features</para>
		/// <para>输出要素类，其中包含出现输出匹配类型的输入主要要素中的要素。</para>
		/// </param>
		/// <param name="OutComparisonFeatureClass">
		/// <para>Output Matched Comparison Features</para>
		/// <para>输出要素类，其中包含出现输出匹配类型的输入比较要素中的要素。</para>
		/// </param>
		/// <param name="MatchTypes">
		/// <para>Output Match Types</para>
		/// <para>用于指定要比较的匹配类型。</para>
		/// <para>空间和时间—将对基于时间和空间搜索半径中定义的时间范围和邻域的匹配进行比较，例如 25 米和 10 分钟。</para>
		/// <para>仅空间—将对仅基于空间搜索半径中定义的邻域的匹配进行比较，例如 25 米。</para>
		/// <para>仅时间—将对仅基于时间搜索半径中定义的时间范围的匹配进行比较，例如 10 分钟。</para>
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
		/// <para>Tool Display Name : 查找时空匹配</para>
		/// </summary>
		public override string DisplayName() => "查找时空匹配";

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
		/// <para>主要输入要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InPrimaryFeatures { get; set; }

		/// <summary>
		/// <para>Input Comparison Features</para>
		/// <para>比较输入要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InComparisonFeatures { get; set; }

		/// <summary>
		/// <para>Output Matched Primary Features</para>
		/// <para>输出要素类，其中包含出现输出匹配类型的输入主要要素中的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPrimaryFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Matched Comparison Features</para>
		/// <para>输出要素类，其中包含出现输出匹配类型的输入比较要素中的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutComparisonFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Match Types</para>
		/// <para>用于指定要比较的匹配类型。</para>
		/// <para>空间和时间—将对基于时间和空间搜索半径中定义的时间范围和邻域的匹配进行比较，例如 25 米和 10 分钟。</para>
		/// <para>仅空间—将对仅基于空间搜索半径中定义的邻域的匹配进行比较，例如 25 米。</para>
		/// <para>仅时间—将对仅基于时间搜索半径中定义的时间范围的匹配进行比较，例如 10 分钟。</para>
		/// <para><see cref="MatchTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object MatchTypes { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>用于在输入要素类之间进行搜索的半径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Temporal Search Radius</para>
		/// <para>用于在输入要素类之间进行搜索的时间范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TemporalSearchRadius { get; set; }

		/// <summary>
		/// <para>Primary Features Start Date Field</para>
		/// <para>输入主要要素的主要起始日期和时间字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? PrimaryStartDateField { get; set; }

		/// <summary>
		/// <para>Comparison Features Start Date Field</para>
		/// <para>输入比较要素的比较起始日期和时间字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ComparisonStartDateField { get; set; }

		/// <summary>
		/// <para>Primary Features End Date Field</para>
		/// <para>输入主要要素的主要结束日期和时间字段。如果指定，则将使用起始及结束日期和时间搜索半径定义的时间范围来搜索比较要素。可以将时间搜索半径设置为 0，以仅比较由要素的时间范围定义的时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? PrimaryEndDateField { get; set; }

		/// <summary>
		/// <para>Comparison Features End Date Field</para>
		/// <para>输入比较要素的比较结束日期和时间字段。如果指定，则将使用起始及结束日期和时间搜索半径定义的时间范围来评估与主要要素的关系。可以将时间搜索半径设置为 0，以仅比较由要素的时间范围定义的时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ComparisonEndDateField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindSpaceTimeMatches SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainAttachments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
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
			/// <para>空间和时间—将对基于时间和空间搜索半径中定义的时间范围和邻域的匹配进行比较，例如 25 米和 10 分钟。</para>
			/// </summary>
			[GPValue("SPACE_AND_TIME")]
			[Description("空间和时间")]
			Space_and_time,

			/// <summary>
			/// <para>仅空间—将对仅基于空间搜索半径中定义的邻域的匹配进行比较，例如 25 米。</para>
			/// </summary>
			[GPValue("SPACE_ONLY")]
			[Description("仅空间")]
			Space_only,

			/// <summary>
			/// <para>仅时间—将对仅基于时间搜索半径中定义的时间范围的匹配进行比较，例如 10 分钟。</para>
			/// </summary>
			[GPValue("TIME_ONLY")]
			[Description("仅时间")]
			Time_only,

		}

#endregion
	}
}
