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
	/// <para>Ordinary Least Squares (OLS)</para>
	/// <para>Ordinary Least Squares (OLS)</para>
	/// <para>Performs global Ordinary Least Squares (OLS) linear regression to generate predictions or to model a dependent variable in terms of its relationships to a set of explanatory variables.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools.GeneralizedLinearRegression"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools.GeneralizedLinearRegression))]
	public class OrdinaryLeastSquares : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class containing the dependent and independent variables for analysis.</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a different value for every feature in the Input Feature Class.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will receive dependent variable estimates and residuals.</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing values for what you are trying to model.</para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variables</para>
		/// <para>A list of fields representing explanatory variables in your regression model.</para>
		/// </param>
		public OrdinaryLeastSquares(object InputFeatureClass, object UniqueIDField, object OutputFeatureClass, object DependentVariable, object ExplanatoryVariables)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.UniqueIDField = UniqueIDField;
			this.OutputFeatureClass = OutputFeatureClass;
			this.DependentVariable = DependentVariable;
			this.ExplanatoryVariables = ExplanatoryVariables;
		}

		/// <summary>
		/// <para>Tool Display Name : Ordinary Least Squares (OLS)</para>
		/// </summary>
		public override string DisplayName() => "Ordinary Least Squares (OLS)";

		/// <summary>
		/// <para>Tool Name : OrdinaryLeastSquares</para>
		/// </summary>
		public override string ToolName() => "OrdinaryLeastSquares";

		/// <summary>
		/// <para>Tool Excute Name : stats.OrdinaryLeastSquares</para>
		/// </summary>
		public override string ExcuteName() => "stats.OrdinaryLeastSquares";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputFeatureClass, DependentVariable, ExplanatoryVariables, CoefficientOutputTable!, DiagnosticOutputTable!, OutputReportFile! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class containing the dependent and independent variables for analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a different value for every feature in the Input Feature Class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will receive dependent variable estimates and residuals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing values for what you are trying to model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Explanatory Variables</para>
		/// <para>A list of fields representing explanatory variables in your regression model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Coefficient Output Table</para>
		/// <para>The full path to an optional table that will receive model coefficients, standardized coefficients, standard errors, and probabilities for each explanatory variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object? CoefficientOutputTable { get; set; }

		/// <summary>
		/// <para>Diagnostic Output Table</para>
		/// <para>The full path to an optional table that will receive model summary diagnostics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object? DiagnosticOutputTable { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>The path to the optional PDF file the tool will create. This report file includes model diagnostics, graphs, and notes to help you interpret the OLS results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object? OutputReportFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OrdinaryLeastSquares SetEnviroment(double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
