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
	/// <para>Generalized Linear Regression (GLR)</para>
	/// <para>Performs Generalized Linear Regression </para>
	/// <para>(GLR) to generate predictions or to model a dependent variable in terms of its relationship to a set of explanatory variables.  This tool can be used to fit continuous (OLS), binary (logistic), and count (Poisson) models.</para>
	/// </summary>
	public class GeneralizedLinearRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class containing the dependent and independent variables.</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values to be modeled.</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>Specifies the type of data that will be modeled.</para>
		/// <para>Continuous (Gaussian)— The Dependent Variable is continuous. The model used is Gaussian, and the tool performs ordinary least squares regression.</para>
		/// <para>Binary (Logistic)— The Dependent Variable represents presence or absence. This can be either conventional 1s and 0s, or continuous data that has been recoded based on some threshold value. The model used is Logistic Regression.</para>
		/// <para>Count (Poisson)—The Dependent Variable is discrete and represents events, for example, crime counts, disease incidents, or traffic accidents. The model used is Poisson regression.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The new feature class that will contain the dependent variable estimates and residuals.</para>
		/// </param>
		public GeneralizedLinearRegression(object InFeatures, object DependentVariable, object ModelType, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.DependentVariable = DependentVariable;
			this.ModelType = ModelType;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Generalized Linear Regression (GLR)</para>
		/// </summary>
		public override string DisplayName() => "Generalized Linear Regression (GLR)";

		/// <summary>
		/// <para>Tool Name : GeneralizedLinearRegression</para>
		/// </summary>
		public override string ToolName() => "GeneralizedLinearRegression";

		/// <summary>
		/// <para>Tool Excute Name : stats.GeneralizedLinearRegression</para>
		/// </summary>
		public override string ExcuteName() => "stats.GeneralizedLinearRegression";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ModelType, OutputFeatures, ExplanatoryVariables, DistanceFeatures, PredictionLocations, ExplanatoryVariablesToMatch, ExplanatoryDistanceMatching, OutputPredictedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class containing the dependent and independent variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values to be modeled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Model Type</para>
		/// <para>Specifies the type of data that will be modeled.</para>
		/// <para>Continuous (Gaussian)— The Dependent Variable is continuous. The model used is Gaussian, and the tool performs ordinary least squares regression.</para>
		/// <para>Binary (Logistic)— The Dependent Variable represents presence or absence. This can be either conventional 1s and 0s, or continuous data that has been recoded based on some threshold value. The model used is Logistic Regression.</para>
		/// <para>Count (Poisson)—The Dependent Variable is discrete and represents events, for example, crime counts, disease incidents, or traffic accidents. The model used is Poisson regression.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The new feature class that will contain the dependent variable estimates and residuals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Distance Features</para>
		/// <para>Automatically creates explanatory variables by calculating a distance from the provided features to the Input Features. Distances will be calculated from each of the input Explanatory Distance Features to the nearest Input Features. If the input Explanatory Distance Features are polygons or lines, the distance attributes are calculated as the distance between the closest segments of the pair of features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point", "Polyline")]
		[FeatureType("Simple")]
		public object DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Prediction Locations</para>
		/// <para>A feature class containing features representing locations where estimates will be computed. Each feature in this dataset should contain values for all the explanatory variables specified. The dependent variable for these features will be estimated using the model calibrated for the input feature class data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		[Category("Prediction Options")]
		public object PredictionLocations { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>Matches the explanatory variables in the Prediction Locations to corresponding explanatory variables from the Input Feature Class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Match Distance Features</para>
		/// <para>Matches the distance features specified for the Prediction Locations on the left to corresponding distance features for the Input Features on the right.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object ExplanatoryDistanceMatching { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>The output feature class to receive dependent variable estimates for each Prediction Location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneralizedLinearRegression SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>Continuous (Gaussian)— The Dependent Variable is continuous. The model used is Gaussian, and the tool performs ordinary least squares regression.</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("Continuous (Gaussian)")]
			CONTINUOUS,

			/// <summary>
			/// <para>Binary (Logistic)— The Dependent Variable represents presence or absence. This can be either conventional 1s and 0s, or continuous data that has been recoded based on some threshold value. The model used is Logistic Regression.</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("Binary (Logistic)")]
			BINARY,

			/// <summary>
			/// <para>Count (Poisson)—The Dependent Variable is discrete and represents events, for example, crime counts, disease incidents, or traffic accidents. The model used is Poisson regression.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count (Poisson)")]
			COUNT,

		}

#endregion
	}
}
