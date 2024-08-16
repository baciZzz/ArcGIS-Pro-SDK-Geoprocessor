using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Similarity Search</para>
	/// <para>Identifies which candidate features are most similar or most dissimilar to one or more input features based on feature attributes.</para>
	/// </summary>
	public class SimilaritySearch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeaturesToMatch">
		/// <para>Input Features To Match</para>
		/// <para>The layer, or a selection on a layer, containing the features you want to match; you are searching for other features that look like these features. When more than one feature is provided, matching is based on attribute averages.</para>
		/// <para>When the Input Features To Match and Candidate Features values are from a single dataset layer, you can do the following:</para>
		/// <para>Copy the layer to the Contents pane, making a duplicate layer.</para>
		/// <para>Rename the duplicate layer.</para>
		/// <para>On the renamed layer, make a selection or set a definition query for the reference features you want to match. Use the new layer created for the Input Features To Match parameter.</para>
		/// <para>Apply a selection or set a definition query on the original layer so it excludes the reference features. This will be the layer to use for the Candidate Features parameter.</para>
		/// </param>
		/// <param name="CandidateFeatures">
		/// <para>Candidate Features</para>
		/// <para>The layer, or a selection on a layer, containing candidate matching features. The tool will check for features most similar (or most dissimilar) to the Input Features To Match values among these candidates.</para>
		/// <para>When the Input Features To Match and Candidate Features values are from a single dataset layer, you can do the following:</para>
		/// <para>Copy the layer to the Contents pane, making a duplicate layer.</para>
		/// <para>Rename the duplicate layer.</para>
		/// <para>On the renamed layer, make a selection or set a definition query for the reference features you want to match. Use the new layer created for the Input Features To Match parameter.</para>
		/// <para>Apply a selection or set a definition query on the original layer so it excludes the reference features. This will be the layer to use for the Candidate Features parameter.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class containing a record for each of the Input Features To Match values and for all the solution-matching features found.</para>
		/// </param>
		/// <param name="CollapseOutputToPoints">
		/// <para>Collapse Output To Points</para>
		/// <para>Specifies whether the geometry for the Output Features parameter will be collapsed to points or will match the original geometry (lines or polygons) of the input features if the Input Features To Match and Candidate Features parameter values are both either lines or polygons. This parameter is only available with an Desktop Advanced license. Checking this parameter will improve tool performance for large line and polygon datasets.</para>
		/// <para>Checked—The line and polygon features will be represented as feature centroids (points).</para>
		/// <para>Unchecked—The output geometry will match the line or polygon geometry of the input features. This is the default.</para>
		/// <para><see cref="CollapseOutputToPointsEnum"/></para>
		/// </param>
		/// <param name="MostOrLeastSimilar">
		/// <para>Most Or Least Similar</para>
		/// <para>Specifies whether features that are most similar or most dissimilar to the Input Features To Match values will be identified.</para>
		/// <para>Most similar—Features that are most similar will be identified. This is the default.</para>
		/// <para>Least similar—Features that are most dissimilar will be identified.</para>
		/// <para>Both—Features that are most similar and features that are most dissimilar will both be identified.</para>
		/// <para><see cref="MostOrLeastSimilarEnum"/></para>
		/// </param>
		/// <param name="MatchMethod">
		/// <para>Match Method</para>
		/// <para>Specifies whether matching will be based on values, ranks, or cosine relationships.</para>
		/// <para>Attribute values—Matching will be based on the sum of squared standardized attribute value differences for all of the Attributes Of Interest values. This is the default.</para>
		/// <para>Ranked attribute values—Matching will be based on the sum of squared rank differences for all of the Attributes Of Interest values.</para>
		/// <para>Attribute profiles—Matching will be computed as a function of cosine similarity for all of the Attributes Of Interest values.</para>
		/// <para><see cref="MatchMethodEnum"/></para>
		/// </param>
		/// <param name="NumberOfResults">
		/// <para>Number Of Results</para>
		/// <para>The number of solution matches to find. Entering zero or a number larger than the total number of Candidate Features values will return rankings for all the candidate features. The default is 10.</para>
		/// </param>
		/// <param name="AttributesOfInterest">
		/// <para>Attributes Of Interest</para>
		/// <para>The numeric attributes representing the matching criteria.</para>
		/// </param>
		public SimilaritySearch(object InputFeaturesToMatch, object CandidateFeatures, object OutputFeatures, object CollapseOutputToPoints, object MostOrLeastSimilar, object MatchMethod, object NumberOfResults, object AttributesOfInterest)
		{
			this.InputFeaturesToMatch = InputFeaturesToMatch;
			this.CandidateFeatures = CandidateFeatures;
			this.OutputFeatures = OutputFeatures;
			this.CollapseOutputToPoints = CollapseOutputToPoints;
			this.MostOrLeastSimilar = MostOrLeastSimilar;
			this.MatchMethod = MatchMethod;
			this.NumberOfResults = NumberOfResults;
			this.AttributesOfInterest = AttributesOfInterest;
		}

		/// <summary>
		/// <para>Tool Display Name : Similarity Search</para>
		/// </summary>
		public override string DisplayName => "Similarity Search";

		/// <summary>
		/// <para>Tool Name : SimilaritySearch</para>
		/// </summary>
		public override string ToolName => "SimilaritySearch";

		/// <summary>
		/// <para>Tool Excute Name : stats.SimilaritySearch</para>
		/// </summary>
		public override string ExcuteName => "stats.SimilaritySearch";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeaturesToMatch, CandidateFeatures, OutputFeatures, CollapseOutputToPoints, MostOrLeastSimilar, MatchMethod, NumberOfResults, AttributesOfInterest, FieldsToAppendToOutput };

		/// <summary>
		/// <para>Input Features To Match</para>
		/// <para>The layer, or a selection on a layer, containing the features you want to match; you are searching for other features that look like these features. When more than one feature is provided, matching is based on attribute averages.</para>
		/// <para>When the Input Features To Match and Candidate Features values are from a single dataset layer, you can do the following:</para>
		/// <para>Copy the layer to the Contents pane, making a duplicate layer.</para>
		/// <para>Rename the duplicate layer.</para>
		/// <para>On the renamed layer, make a selection or set a definition query for the reference features you want to match. Use the new layer created for the Input Features To Match parameter.</para>
		/// <para>Apply a selection or set a definition query on the original layer so it excludes the reference features. This will be the layer to use for the Candidate Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeaturesToMatch { get; set; }

		/// <summary>
		/// <para>Candidate Features</para>
		/// <para>The layer, or a selection on a layer, containing candidate matching features. The tool will check for features most similar (or most dissimilar) to the Input Features To Match values among these candidates.</para>
		/// <para>When the Input Features To Match and Candidate Features values are from a single dataset layer, you can do the following:</para>
		/// <para>Copy the layer to the Contents pane, making a duplicate layer.</para>
		/// <para>Rename the duplicate layer.</para>
		/// <para>On the renamed layer, make a selection or set a definition query for the reference features you want to match. Use the new layer created for the Input Features To Match parameter.</para>
		/// <para>Apply a selection or set a definition query on the original layer so it excludes the reference features. This will be the layer to use for the Candidate Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object CandidateFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing a record for each of the Input Features To Match values and for all the solution-matching features found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Collapse Output To Points</para>
		/// <para>Specifies whether the geometry for the Output Features parameter will be collapsed to points or will match the original geometry (lines or polygons) of the input features if the Input Features To Match and Candidate Features parameter values are both either lines or polygons. This parameter is only available with an Desktop Advanced license. Checking this parameter will improve tool performance for large line and polygon datasets.</para>
		/// <para>Checked—The line and polygon features will be represented as feature centroids (points).</para>
		/// <para>Unchecked—The output geometry will match the line or polygon geometry of the input features. This is the default.</para>
		/// <para><see cref="CollapseOutputToPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapseOutputToPoints { get; set; } = "false";

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// <para>Specifies whether features that are most similar or most dissimilar to the Input Features To Match values will be identified.</para>
		/// <para>Most similar—Features that are most similar will be identified. This is the default.</para>
		/// <para>Least similar—Features that are most dissimilar will be identified.</para>
		/// <para>Both—Features that are most similar and features that are most dissimilar will both be identified.</para>
		/// <para><see cref="MostOrLeastSimilarEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MostOrLeastSimilar { get; set; } = "MOST_SIMILAR";

		/// <summary>
		/// <para>Match Method</para>
		/// <para>Specifies whether matching will be based on values, ranks, or cosine relationships.</para>
		/// <para>Attribute values—Matching will be based on the sum of squared standardized attribute value differences for all of the Attributes Of Interest values. This is the default.</para>
		/// <para>Ranked attribute values—Matching will be based on the sum of squared rank differences for all of the Attributes Of Interest values.</para>
		/// <para>Attribute profiles—Matching will be computed as a function of cosine similarity for all of the Attributes Of Interest values.</para>
		/// <para><see cref="MatchMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MatchMethod { get; set; } = "ATTRIBUTE_VALUES";

		/// <summary>
		/// <para>Number Of Results</para>
		/// <para>The number of solution matches to find. Entering zero or a number larger than the total number of Candidate Features values will return rankings for all the candidate features. The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfResults { get; set; } = "10";

		/// <summary>
		/// <para>Attributes Of Interest</para>
		/// <para>The numeric attributes representing the matching criteria.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AttributesOfInterest { get; set; }

		/// <summary>
		/// <para>Fields To Append To Output</para>
		/// <para>The fields to include with the Output Features parameter. These fields are not used to determine similarity; they are only included in the Output Features parameter for reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Additional Options")]
		public object FieldsToAppendToOutput { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimilaritySearch SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Collapse Output To Points</para>
		/// </summary>
		public enum CollapseOutputToPointsEnum 
		{
			/// <summary>
			/// <para>Checked—The line and polygon features will be represented as feature centroids (points).</para>
			/// </summary>
			[GPValue("true")]
			[Description("COLLAPSE")]
			COLLAPSE,

			/// <summary>
			/// <para>Unchecked—The output geometry will match the line or polygon geometry of the input features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COLLAPSE")]
			NO_COLLAPSE,

		}

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// </summary>
		public enum MostOrLeastSimilarEnum 
		{
			/// <summary>
			/// <para>Most similar—Features that are most similar will be identified. This is the default.</para>
			/// </summary>
			[GPValue("MOST_SIMILAR")]
			[Description("Most similar")]
			Most_similar,

			/// <summary>
			/// <para>Least similar—Features that are most dissimilar will be identified.</para>
			/// </summary>
			[GPValue("LEAST_SIMILAR")]
			[Description("Least similar")]
			Least_similar,

			/// <summary>
			/// <para>Both—Features that are most similar and features that are most dissimilar will both be identified.</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("Both")]
			Both,

		}

		/// <summary>
		/// <para>Match Method</para>
		/// </summary>
		public enum MatchMethodEnum 
		{
			/// <summary>
			/// <para>Attribute values—Matching will be based on the sum of squared standardized attribute value differences for all of the Attributes Of Interest values. This is the default.</para>
			/// </summary>
			[GPValue("ATTRIBUTE_VALUES")]
			[Description("Attribute values")]
			Attribute_values,

			/// <summary>
			/// <para>Ranked attribute values—Matching will be based on the sum of squared rank differences for all of the Attributes Of Interest values.</para>
			/// </summary>
			[GPValue("RANKED_ATTRIBUTE_VALUES")]
			[Description("Ranked attribute values")]
			Ranked_attribute_values,

			/// <summary>
			/// <para>Attribute profiles—Matching will be computed as a function of cosine similarity for all of the Attributes Of Interest values.</para>
			/// </summary>
			[GPValue("ATTRIBUTE_PROFILES")]
			[Description("Attribute profiles")]
			Attribute_profiles,

		}

#endregion
	}
}
