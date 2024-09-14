using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Merge Lines By Pseudo Node</para>
	/// <para>Merge Lines By Pseudo Node</para>
	/// <para>Dissolves features where pseudo nodes occur.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class MergeLinesByPseudoNode : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The line features from which pseudo nodes will be removed.</para>
		/// </param>
		public MergeLinesByPseudoNode(object InputFeatures)
		{
			this.InputFeatures = InputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Lines By Pseudo Node</para>
		/// </summary>
		public override string DisplayName() => "Merge Lines By Pseudo Node";

		/// <summary>
		/// <para>Tool Name : MergeLinesByPseudoNode</para>
		/// </summary>
		public override string ToolName() => "MergeLinesByPseudoNode";

		/// <summary>
		/// <para>Tool Excute Name : topographic.MergeLinesByPseudoNode</para>
		/// </summary>
		public override string ExcuteName() => "topographic.MergeLinesByPseudoNode";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, MergeFields!, AggregateOperations!, MergeFeatureRule!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line features from which pseudo nodes will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Merge Fields</para>
		/// <para>The field or fields on which features will be merged.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? MergeFields { get; set; }

		/// <summary>
		/// <para>Aggregate Operations</para>
		/// <para>Specifies the fields that will be used to calculate the specified statistic. Multiple statistic and field combinations can be specified. Null values are excluded from all statistical calculations.</para>
		/// <para>Text attribute fields can be summarized using first and last statistics. Numeric attribute fields can be summarized using any statistic.</para>
		/// <para>Available statistic types are as follows:</para>
		/// <para>Sum—The total value for the specified field will be calculated.</para>
		/// <para>Mean—The average for the specified field will be calculated.</para>
		/// <para>Minimum—The smallest value for all records of the specified field will be found.</para>
		/// <para>Maximum—The largest value for all records of the specified field will be found.</para>
		/// <para>Range—The range of values (maximum minus minimum) for the specified field will be calculated.</para>
		/// <para>Standard deviation—The standard deviation of values in the specified field will be calculated.</para>
		/// <para>Count—The number of values included in statistical calculations will be found. Each value will be counted except null values. To determine the number of null values in a field, create a count on the field in question, create a count on a different field that does not contain null values (for example, the OID if present), and subtract the two values.</para>
		/// <para>First—The value of the first record in the input will be used.</para>
		/// <para>Last—The value of the last record in the input will be used.</para>
		/// <para>Median—The median for all records of the specified field will be calculated.</para>
		/// <para>Variance—The variance for all records of the specified field will be calculated.</para>
		/// <para>Unique—The number of unique values of the specified field will be counted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? AggregateOperations { get; set; }

		/// <summary>
		/// <para>Merge Feature Rule</para>
		/// <para>Specifies which feature&apos;s attributes will be maintained when two features are merged at a pseudo node.</para>
		/// <para>First—The feature with the lowest ObjectID and its attributes will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value.</para>
		/// <para>Last—The feature with the highest ObjectID and its attributes will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value.</para>
		/// <para>By length—The feature with the longest length and its attributes will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value.</para>
		/// <para>Use defaults—The feature with the lowest ObjectID will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value. The value for fields that are not merge fields or calculated with an aggregation operation will have the value assigned with the default value from the field or subtype when applicable.</para>
		/// <para><see cref="MergeFeatureRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MergeFeatureRule { get; set; } = "FIRST";

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Merge Feature Rule</para>
		/// </summary>
		public enum MergeFeatureRuleEnum 
		{
			/// <summary>
			/// <para>First—The feature with the lowest ObjectID and its attributes will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—The feature with the highest ObjectID and its attributes will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>By length—The feature with the longest length and its attributes will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value.</para>
			/// </summary>
			[GPValue("BY_LENGTH")]
			[Description("By length")]
			By_length,

			/// <summary>
			/// <para>Use defaults—The feature with the lowest ObjectID will be maintained while merging. The value for the fields with a specified aggregation operation will be updated with the calculated value. The value for fields that are not merge fields or calculated with an aggregation operation will have the value assigned with the default value from the field or subtype when applicable.</para>
			/// </summary>
			[GPValue("USE_DEFAULTS")]
			[Description("Use defaults")]
			Use_defaults,

		}

#endregion
	}
}
