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
	/// <para>Dimension Reduction</para>
	/// <para>Reduces the number of dimensions of a set of continuous variables by aggregating the highest possible amount of variance into fewer components using Principal Component Analysis (PCA) or Reduced-Rank Linear Discriminant Analysis (LDA).</para>
	/// </summary>
	public class DimensionReduction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table or Features</para>
		/// <para>The table or features containing the fields with the dimension that will be reduced.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Analysis Fields</para>
		/// <para>The fields representing the data with the dimension that will be reduced.</para>
		/// </param>
		public DimensionReduction(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Dimension Reduction</para>
		/// </summary>
		public override string DisplayName => "Dimension Reduction";

		/// <summary>
		/// <para>Tool Name : DimensionReduction</para>
		/// </summary>
		public override string ToolName => "DimensionReduction";

		/// <summary>
		/// <para>Tool Excute Name : stats.DimensionReduction</para>
		/// </summary>
		public override string ExcuteName => "stats.DimensionReduction";

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
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutputData!, Fields, Method!, Scale!, CategoricalField!, MinVariance!, MinComponents!, AppendFields!, OutputEigenvaluesTable!, OutputEigenvectorsTable!, NumberOfPermutations!, AppendToInput!, UpdatedTable! };

		/// <summary>
		/// <para>Input Table or Features</para>
		/// <para>The table or features containing the fields with the dimension that will be reduced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table or Feature Class</para>
		/// <para>The output table or feature class containing the resulting components of the dimension reduction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputData { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>The fields representing the data with the dimension that will be reduced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Dimension Reduction Method</para>
		/// <para>Specifies the method that will be used to reduce the dimensions of the analysis fields.</para>
		/// <para>Principal Component Analysis (PCA)—The analysis fields will be partitioned into components that each maintain the maximum proportion of the total variance. This is the default.</para>
		/// <para>Reduced-Rank Linear Discriminant Analysis (LDA)—The analysis fields will be partitioned into components that each maintain the maximum between-category separability of a categorical variable.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PCA";

		/// <summary>
		/// <para>Scale Data</para>
		/// <para>Specifies whether the values of each analysis will be scaled to have a variance equal to one. This scaling ensures that each analysis field is given equal priority in the components. Scaling also removes the effect of linear units; for example, the same data measured in meters and feet will result in equivalent components. The values of the analysis fields will be shifted to have mean zero for both options.</para>
		/// <para>Checked—The values of each analysis field will be scaled to have a variance equal to one by dividing each value by the standard deviation of the analysis field. This is the default.</para>
		/// <para>Unchecked—The variance of each analysis field will not be scaled.</para>
		/// <para><see cref="ScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Scale { get; set; } = "true";

		/// <summary>
		/// <para>Categorical Field</para>
		/// <para>The field representing the categorical variable for LDA. The components will maintain the maximum amount of information needed to classify each input record into these categories.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? CategoricalField { get; set; }

		/// <summary>
		/// <para>Minimum Percent Variance to Maintain</para>
		/// <para>The minimum percent of total variance of the analysis fields that must be maintained in the components. The total variance depends on whether the analysis fields were scaled using the Scale Data parameter(scale in Python).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? MinVariance { get; set; }

		/// <summary>
		/// <para>Minimum Number of Components</para>
		/// <para>The minimum number of components.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? MinComponents { get; set; }

		/// <summary>
		/// <para>Copy All Fields to Output Dataset</para>
		/// <para>Specifies whether all fields from the input table or features will be copied and appended to the output table or feature class. The fields provided in the Analysis Fields parameter will be copied to the output regardless of the value of this parameter.</para>
		/// <para>Checked—All fields from the input table or features will be copied and appended to the output table or feature class.</para>
		/// <para>Unchecked—Only the analysis fields will be included in the output table or feature class. This is the default.</para>
		/// <para><see cref="AppendFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? AppendFields { get; set; } = "false";

		/// <summary>
		/// <para>Output Eigenvalues Table</para>
		/// <para>The output table containing the eigenvalues of each component.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object? OutputEigenvaluesTable { get; set; }

		/// <summary>
		/// <para>Output Eigenvectors Table</para>
		/// <para>The output table containing the eigenvectors of each component.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object? OutputEigenvectorsTable { get; set; }

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>The number of permutations to be used when determining the optimal number of components. The default value is 0, which indicates that no permutation test will be performed.</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? NumberOfPermutations { get; set; } = "0";

		/// <summary>
		/// <para>Append Fields to Input Data</para>
		/// <para>Specifies whether the component fields will be appended to the input dataset or saved to an output table or feature class. If you append the fields to the input, the output coordinate system environment will be ignored.</para>
		/// <para>Checked—The fields containing the components will be appended to the input features. This option modifies the input data.</para>
		/// <para>Unchecked—An output table or feature class will be created containing the component fields. This is the default.</para>
		/// <para><see cref="AppendToInputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendToInput { get; set; } = "false";

		/// <summary>
		/// <para>Updated Table or Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DimensionReduction SetEnviroment(object? outputCoordinateSystem = null , object? randomGenerator = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dimension Reduction Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Principal Component Analysis (PCA)—The analysis fields will be partitioned into components that each maintain the maximum proportion of the total variance. This is the default.</para>
			/// </summary>
			[GPValue("PCA")]
			[Description("Principal Component Analysis (PCA)")]
			PCA,

			/// <summary>
			/// <para>Reduced-Rank Linear Discriminant Analysis (LDA)—The analysis fields will be partitioned into components that each maintain the maximum between-category separability of a categorical variable.</para>
			/// </summary>
			[GPValue("LDA")]
			[Description("Reduced-Rank Linear Discriminant Analysis (LDA)")]
			LDA,

		}

		/// <summary>
		/// <para>Scale Data</para>
		/// </summary>
		public enum ScaleEnum 
		{
			/// <summary>
			/// <para>Checked—The values of each analysis field will be scaled to have a variance equal to one by dividing each value by the standard deviation of the analysis field. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SCALE_DATA")]
			SCALE_DATA,

			/// <summary>
			/// <para>Unchecked—The variance of each analysis field will not be scaled.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SCALE_DATA")]
			NO_SCALE_DATA,

		}

		/// <summary>
		/// <para>Copy All Fields to Output Dataset</para>
		/// </summary>
		public enum AppendFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—All fields from the input table or features will be copied and appended to the output table or feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—Only the analysis fields will be included in the output table or feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPEND")]
			NO_APPEND,

		}

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

		}

		/// <summary>
		/// <para>Append Fields to Input Data</para>
		/// </summary>
		public enum AppendToInputEnum 
		{
			/// <summary>
			/// <para>Checked—The fields containing the components will be appended to the input features. This option modifies the input data.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND_TO_INPUT")]
			APPEND_TO_INPUT,

			/// <summary>
			/// <para>Unchecked—An output table or feature class will be created containing the component fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NEW_OUTPUT")]
			NEW_OUTPUT,

		}

#endregion
	}
}
