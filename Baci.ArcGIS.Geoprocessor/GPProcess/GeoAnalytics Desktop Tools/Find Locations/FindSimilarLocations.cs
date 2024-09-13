using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Find Similar Locations</para>
	/// <para>Find Similar Locations</para>
	/// <para>Identifies the candidate features that are most similar or dissimilar to one or more input features based on feature attributes.</para>
	/// </summary>
	public class FindSimilarLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The reference layer (or a selection on a layer) containing the features to be matched. The tool searches for other features similar to these features. When more than one feature is provided, matching is based on attribute averages.</para>
		/// </param>
		/// <param name="SearchLayer">
		/// <para>Search Layer</para>
		/// <para>The candidate layer (or a selection on a layer) containing candidate-matching features. The tool searches for features most similar (or dissimilar) to the Input Layer parameter among these candidates.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>The name of the output feature class. The output feature class contains a record for each of the Input Layer parameters and for all the solution-matching features found.</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>A list of numeric attributes representing the matching criteria.</para>
		/// </param>
		public FindSimilarLocations(object InputLayer, object SearchLayer, object Output, object AnalysisFields)
		{
			this.InputLayer = InputLayer;
			this.SearchLayer = SearchLayer;
			this.Output = Output;
			this.AnalysisFields = AnalysisFields;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Similar Locations</para>
		/// </summary>
		public override string DisplayName() => "Find Similar Locations";

		/// <summary>
		/// <para>Tool Name : FindSimilarLocations</para>
		/// </summary>
		public override string ToolName() => "FindSimilarLocations";

		/// <summary>
		/// <para>Tool Excute Name : gapro.FindSimilarLocations</para>
		/// </summary>
		public override string ExcuteName() => "gapro.FindSimilarLocations";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, SearchLayer, Output, AnalysisFields, MostOrLeastSimilar!, MatchMethod!, NumberOfResults!, AppendFields! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The reference layer (or a selection on a layer) containing the features to be matched. The tool searches for other features similar to these features. When more than one feature is provided, matching is based on attribute averages.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Search Layer</para>
		/// <para>The candidate layer (or a selection on a layer) containing candidate-matching features. The tool searches for features most similar (or dissimilar) to the Input Layer parameter among these candidates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object SearchLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The name of the output feature class. The output feature class contains a record for each of the Input Layer parameters and for all the solution-matching features found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>A list of numeric attributes representing the matching criteria.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// <para>Specifies whether the features to be found are most similar or least similar to the Input Layer parameter.</para>
		/// <para>Most similar—Finds the features that are most similar.</para>
		/// <para>Least similar—Finds the features that are least similar.</para>
		/// <para>Both—Finds the features that are most similar and the features that are least similar.</para>
		/// <para><see cref="MostOrLeastSimilarEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MostOrLeastSimilar { get; set; } = "MOST_SIMILAR";

		/// <summary>
		/// <para>Match Method</para>
		/// <para>Specifies whether matches will be based on values or cosine relationships.</para>
		/// <para>Attribute values—Similarity or dissimilarity will be based on the sum of squared standardized attribute value differences for all the Analysis Fields attributes.</para>
		/// <para>Attribute profiles—Similarity or dissimilarity will be computed as a function of cosine similarity for all the Analysis Fields attributes.</para>
		/// <para><see cref="MatchMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MatchMethod { get; set; } = "ATTRIBUTE_VALUES";

		/// <summary>
		/// <para>Number Of Results</para>
		/// <para>The number of solution matches to be found. Entering zero or a number larger than the total number of Search Layer features will return rankings for all the candidate features, with a maximum of 10,000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000)]
		public object? NumberOfResults { get; set; } = "10";

		/// <summary>
		/// <para>Append Fields</para>
		/// <para>An optional list of attributes to include with the output. You can include a name identifier, categorical field, or date field, for example. These fields are not used to determine similarity; they are only included in the output parameter attributes for your reference. By default, all fields are added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "GUID", "GlobalID", "XML")]
		public object? AppendFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindSimilarLocations SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Most Or Least Similar</para>
		/// </summary>
		public enum MostOrLeastSimilarEnum 
		{
			/// <summary>
			/// <para>Most similar—Finds the features that are most similar.</para>
			/// </summary>
			[GPValue("MOST_SIMILAR")]
			[Description("Most similar")]
			Most_similar,

			/// <summary>
			/// <para>Least similar—Finds the features that are least similar.</para>
			/// </summary>
			[GPValue("LEAST_SIMILAR")]
			[Description("Least similar")]
			Least_similar,

			/// <summary>
			/// <para>Both—Finds the features that are most similar and the features that are least similar.</para>
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
			/// <para>Attribute values—Similarity or dissimilarity will be based on the sum of squared standardized attribute value differences for all the Analysis Fields attributes.</para>
			/// </summary>
			[GPValue("ATTRIBUTE_VALUES")]
			[Description("Attribute values")]
			Attribute_values,

			/// <summary>
			/// <para>Attribute profiles—Similarity or dissimilarity will be computed as a function of cosine similarity for all the Analysis Fields attributes.</para>
			/// </summary>
			[GPValue("ATTRIBUTE_PROFILES")]
			[Description("Attribute profiles")]
			Attribute_profiles,

		}

#endregion
	}
}
