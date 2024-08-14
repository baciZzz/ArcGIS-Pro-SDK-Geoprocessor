using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Points From Business Listings</para>
	/// <para>Generates a point feature layer from a business point location search.</para>
	/// </summary>
	public class GeneratePointsFromBusinessListings : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the returned businesses.</para>
		/// </param>
		public GeneratePointsFromBusinessListings(object OutFeatureClass)
		{
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Points From Business Listings</para>
		/// </summary>
		public override string DisplayName => "Generate Points From Business Listings";

		/// <summary>
		/// <para>Tool Name : GeneratePointsFromBusinessListings</para>
		/// </summary>
		public override string ToolName => "GeneratePointsFromBusinessListings";

		/// <summary>
		/// <para>Tool Excute Name : ba.GeneratePointsFromBusinessListings</para>
		/// </summary>
		public override string ExcuteName => "ba.GeneratePointsFromBusinessListings";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutFeatureClass, InSearchFeatures, SearchTerms, ExactMatch, MatchNameOnly, Filters, MaxCount, BusinessDataset };

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the returned businesses.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Search Features</para>
		/// <para>The area that will be used to search for businesses. Selected features supersede the feature class and will be used as the search area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InSearchFeatures { get; set; }

		/// <summary>
		/// <para>Search Terms</para>
		/// <para>The terms that will be used to search for businesses. You can use terms such as business name or business type keywords. If this parameter is not set, all businesses from the Input Search Features parameter will be returned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SearchTerms { get; set; }

		/// <summary>
		/// <para>Include Only Exact Matches</para>
		/// <para>Specifies whether only the text entered in the Search Terms parameter will be returned from the search.</para>
		/// <para>Checked—Only exact matches to the text entered in the Search Terms parameter will be returned.</para>
		/// <para>Unchecked—Partial matches to the text entered in the Search Terms parameter as well as exact matches will be returned. This is the default.</para>
		/// <para><see cref="ExactMatchEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExactMatch { get; set; } = "false";

		/// <summary>
		/// <para>Match Business or Facility Name Only</para>
		/// <para>Specifies whether the search will be limited to the business name only.</para>
		/// <para>Checked—Only exact matches to the business name entered in the Search Terms parameter will be returned.</para>
		/// <para>Unchecked—Partial matches to the business name entered in the Search Terms parameter as well as exact matches will be returned. This is the default.</para>
		/// <para><see cref="MatchNameOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MatchNameOnly { get; set; } = "false";

		/// <summary>
		/// <para>Filters</para>
		/// <para>The filters that will be applied to the Search Terms parameter.</para>
		/// <para>FilterName—Set filter by dataset field.</para>
		/// <para>FilterValue—Set filter by applying a value to the selected field.</para>
		/// <para>Include—Set filter by including or excluding field values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Filters { get; set; }

		/// <summary>
		/// <para>Maximum Number of Points to Return</para>
		/// <para>The limit for the number of returned features. The default value is 1000000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxCount { get; set; } = "1000000";

		/// <summary>
		/// <para>Business Dataset</para>
		/// <para>The dataset that will be used in the business search.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BusinessDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneratePointsFromBusinessListings SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Only Exact Matches</para>
		/// </summary>
		public enum ExactMatchEnum 
		{
			/// <summary>
			/// <para>Checked—Only exact matches to the text entered in the Search Terms parameter will be returned.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXACT_MATCH")]
			EXACT_MATCH,

			/// <summary>
			/// <para>Unchecked—Partial matches to the text entered in the Search Terms parameter as well as exact matches will be returned. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PARTIAL_MATCH")]
			PARTIAL_MATCH,

		}

		/// <summary>
		/// <para>Match Business or Facility Name Only</para>
		/// </summary>
		public enum MatchNameOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Only exact matches to the business name entered in the Search Terms parameter will be returned.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MATCH_NAME_ONLY")]
			MATCH_NAME_ONLY,

			/// <summary>
			/// <para>Unchecked—Partial matches to the business name entered in the Search Terms parameter as well as exact matches will be returned. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MATCH_ALL_FIELDS")]
			MATCH_ALL_FIELDS,

		}

#endregion
	}
}
