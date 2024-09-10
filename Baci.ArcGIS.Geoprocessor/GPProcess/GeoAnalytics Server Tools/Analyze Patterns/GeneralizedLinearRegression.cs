using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Generalized Linear Regression</para>
	/// <para>Performs generalized linear regression </para>
	/// <para>(GLR) to generate predictions or to model a dependent variable in terms of its relationship to a set of explanatory variables. This tool can be used to fit continuous (OLS), binary (logistic), and count (Poisson) models.</para>
	/// </summary>
	public class GeneralizedLinearRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The layer containing the dependent and independent variables.</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values to be modeled.</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>Specifies the type of data that will be modeled.</para>
		/// <para>Continuous (Gaussian)— The Dependent Variable is continuous. The Gaussian model will be used, and the tool will perform ordinary least squares regression. This is the default.</para>
		/// <para>Binary (Logistic)— The Dependent Variable represents presence or absence. This can be either conventional 1s and 0s, or string values mapped to 0 or 1s in the explanatory_variables_to_match parameter. The Logistic regression model will be used.</para>
		/// <para>Count (Poisson)—The Dependent Variable is discrete and represents events, for example, crime counts, disease incidents, or traffic accidents. The Poisson regression model will be used.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </param>
		/// <param name="OutputFeaturesName">
		/// <para>Output Features Name</para>
		/// <para>The name of the feature class that will be created containing the dependent variable estimates and residuals.</para>
		/// </param>
		public GeneralizedLinearRegression(object InputFeatures, object DependentVariable, object ModelType, object ExplanatoryVariables, object OutputFeaturesName)
		{
			this.InputFeatures = InputFeatures;
			this.DependentVariable = DependentVariable;
			this.ModelType = ModelType;
			this.ExplanatoryVariables = ExplanatoryVariables;
			this.OutputFeaturesName = OutputFeaturesName;
		}

		/// <summary>
		/// <para>Tool Display Name : Generalized Linear Regression</para>
		/// </summary>
		public override string DisplayName() => "Generalized Linear Regression";

		/// <summary>
		/// <para>Tool Name : GeneralizedLinearRegression</para>
		/// </summary>
		public override string ToolName() => "GeneralizedLinearRegression";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.GeneralizedLinearRegression</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.GeneralizedLinearRegression";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeaturesName, GenerateCoefficientTable, InputFeaturesToPredict, ExplanatoryVariablesToMatch, DependentVariableMapping, DataStore, Output, OutputPredictedFeatures, CoefficientTable };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The layer containing the dependent and independent variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values to be modeled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Model Type</para>
		/// <para>Specifies the type of data that will be modeled.</para>
		/// <para>Continuous (Gaussian)— The Dependent Variable is continuous. The Gaussian model will be used, and the tool will perform ordinary least squares regression. This is the default.</para>
		/// <para>Binary (Logistic)— The Dependent Variable represents presence or absence. This can be either conventional 1s and 0s, or string values mapped to 0 or 1s in the explanatory_variables_to_match parameter. The Logistic regression model will be used.</para>
		/// <para>Count (Poisson)—The Dependent Variable is discrete and represents events, for example, crime counts, disease incidents, or traffic accidents. The Poisson regression model will be used.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Explanatory Variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Output Features Name</para>
		/// <para>The name of the feature class that will be created containing the dependent variable estimates and residuals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputFeaturesName { get; set; }

		/// <summary>
		/// <para>Generate Coefficient Table</para>
		/// <para>Specifies whether an output table with coefficient (Boolean) values will be generated.</para>
		/// <para>Checked—A table with coefficient values will be generated.</para>
		/// <para>Unchecked—A table with coefficient values will not be generated. This is the default.</para>
		/// <para><see cref="GenerateCoefficientTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateCoefficientTable { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>A layer containing features representing locations where estimates will be computed. Each feature in this dataset should contain values for all the explanatory variables specified. The dependent variable for these features will be estimated using the model calibrated for the input layer data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		[Category("Prediction Options")]
		public object InputFeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>Matches the explanatory variables in the Input Prediction Features parameter to corresponding explanatory variables from the Input Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Map Dependent Variables</para>
		/// <para>Two strings representing the values used to map to 0 (absence) and 1 (presence) for binary regression. By default, 0 and 1 will be used. For example, to predict an arrest with field values of Arrest and No Arrest, you would enter No Arrest for False Value (0) and Arrest for True Value (1).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object DependentVariableMapping { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Table of Coefficients</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object CoefficientTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneralizedLinearRegression SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>Binary (Logistic)— The Dependent Variable represents presence or absence. This can be either conventional 1s and 0s, or string values mapped to 0 or 1s in the explanatory_variables_to_match parameter. The Logistic regression model will be used.</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("Binary (Logistic)")]
			BINARY,

			/// <summary>
			/// <para>Continuous (Gaussian)— The Dependent Variable is continuous. The Gaussian model will be used, and the tool will perform ordinary least squares regression. This is the default.</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("Continuous (Gaussian)")]
			CONTINUOUS,

			/// <summary>
			/// <para>Count (Poisson)—The Dependent Variable is discrete and represents events, for example, crime counts, disease incidents, or traffic accidents. The Poisson regression model will be used.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count (Poisson)")]
			COUNT,

		}

		/// <summary>
		/// <para>Generate Coefficient Table</para>
		/// </summary>
		public enum GenerateCoefficientTableEnum 
		{
			/// <summary>
			/// <para>Checked—A table with coefficient values will be generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_TABLE")]
			CREATE_TABLE,

			/// <summary>
			/// <para>Unchecked—A table with coefficient values will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TABLE")]
			NO_TABLE,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
