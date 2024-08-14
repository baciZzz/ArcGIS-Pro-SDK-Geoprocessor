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
	/// <para>Generate Standard Geography Trade Areas</para>
	/// <para>Creates trade areas based on predefined named statistical areas. This tool does not consume credits.</para>
	/// </summary>
	public class StandardGeographyTA : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="GeographyLevel">
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the trade area.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature containing the trade area.</para>
		/// </param>
		public StandardGeographyTA(object GeographyLevel, object OutFeatureClass)
		{
			this.GeographyLevel = GeographyLevel;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Standard Geography Trade Areas</para>
		/// </summary>
		public override string DisplayName => "Generate Standard Geography Trade Areas";

		/// <summary>
		/// <para>Tool Name : StandardGeographyTA</para>
		/// </summary>
		public override string ToolName => "StandardGeographyTA";

		/// <summary>
		/// <para>Tool Excute Name : ba.StandardGeographyTA</para>
		/// </summary>
		public override string ExcuteName => "ba.StandardGeographyTA";

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
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { GeographyLevel, OutFeatureClass, InputType!, InIdsTable!, GeographyKeyField!, IdsList!, SummarizeDuplicates!, GroupField!, DissolveOutput! };

		/// <summary>
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the trade area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeographyLevel { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature containing the trade area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Type</para>
		/// <para>Specifies whether the geography IDs will be from a table or a list.</para>
		/// <para>Table—The input IDs will be from a table.</para>
		/// <para>List—The input IDs will be from a list. This is the default.</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InputType { get; set; } = "LIST";

		/// <summary>
		/// <para>Geography IDs Table</para>
		/// <para>The input table with IDs that will be used to select geographies that will define the trade area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InIdsTable { get; set; }

		/// <summary>
		/// <para>Geography Key Field</para>
		/// <para>A field in Geography IDs Table that identifies the records that will be included in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? GeographyKeyField { get; set; }

		/// <summary>
		/// <para>Geography IDs List</para>
		/// <para>The input list of comma-separated geography IDs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IdsList { get; set; }

		/// <summary>
		/// <para>Summarize Duplicate IDs</para>
		/// <para>Specifies whether duplicate fields in the table containing matching geography IDs will be summarized.</para>
		/// <para>Checked—The numeric fields for all duplicate records will be summarized.</para>
		/// <para>Unchecked—The data of the first record will be appended. Other records will be ignored. This is the default.</para>
		/// <para><see cref="SummarizeDuplicatesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SummarizeDuplicates { get; set; } = "false";

		/// <summary>
		/// <para>Group Field</para>
		/// <para>The field that will be used to perform a group by operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Dissolve Output Features</para>
		/// <para>Specifies whether the output will be dissolved based on the Group Field parameter value.</para>
		/// <para>Checked—The output will be dissolved.</para>
		/// <para>Unchecked—The output will not be dissolved. This is the default.</para>
		/// <para><see cref="DissolveOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DissolveOutput { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StandardGeographyTA SetEnviroment(object? baDataSource = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input Type</para>
		/// </summary>
		public enum InputTypeEnum 
		{
			/// <summary>
			/// <para>Table—The input IDs will be from a table.</para>
			/// </summary>
			[GPValue("TABLE")]
			[Description("Table")]
			Table,

			/// <summary>
			/// <para>List—The input IDs will be from a list. This is the default.</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("List")]
			List,

		}

		/// <summary>
		/// <para>Summarize Duplicate IDs</para>
		/// </summary>
		public enum SummarizeDuplicatesEnum 
		{
			/// <summary>
			/// <para>Checked—The numeric fields for all duplicate records will be summarized.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SUMMARIZE_DUPLICATES")]
			SUMMARIZE_DUPLICATES,

			/// <summary>
			/// <para>Unchecked—The data of the first record will be appended. Other records will be ignored. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("USE_FIRST")]
			USE_FIRST,

		}

		/// <summary>
		/// <para>Dissolve Output Features</para>
		/// </summary>
		public enum DissolveOutputEnum 
		{
			/// <summary>
			/// <para>Checked—The output will be dissolved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISSOLVE")]
			DISSOLVE,

			/// <summary>
			/// <para>Unchecked—The output will not be dissolved. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_DISSOLVE")]
			DONT_DISSOLVE,

		}

#endregion
	}
}
