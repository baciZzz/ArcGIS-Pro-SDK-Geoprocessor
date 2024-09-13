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
	/// <para>Generalized Linear Regression</para>
	/// <para>广义线性回归</para>
	/// <para>执行广义线性回归 (GLR) 可生成预测，或对因变量与一组解释变量的关系进行建模。此工具可用于拟合连续 (OLS)、二进制（逻辑）和计数（泊松）模型。</para>
	/// </summary>
	public class GeneralizedLinearRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>包含因变量和自变量的图层。</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>包含要进行建模的观测值的数值字段。</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）— 因变量是连续的。将使用高斯模型，并且工具将执行普通最小二乘法回归。这是默认设置。</para>
		/// <para>二进制（逻辑）— 因变量表示存在或不存在。这可以是常规的 1 和 0，也可以是explanatory_variables_to_match参数中映射到 0 或 1 的字符串值。将使用逻辑回归模型。</para>
		/// <para>计数（泊松）—因变量是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。将使用泊松回归模型。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>将创建的包含因变量的估计数和残差的要素类的名称。</para>
		/// </param>
		public GeneralizedLinearRegression(object InputFeatures, object DependentVariable, object ModelType, object ExplanatoryVariables, object OutputFeatures)
		{
			this.InputFeatures = InputFeatures;
			this.DependentVariable = DependentVariable;
			this.ModelType = ModelType;
			this.ExplanatoryVariables = ExplanatoryVariables;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 广义线性回归</para>
		/// </summary>
		public override string DisplayName() => "广义线性回归";

		/// <summary>
		/// <para>Tool Name : GeneralizedLinearRegression</para>
		/// </summary>
		public override string ToolName() => "GeneralizedLinearRegression";

		/// <summary>
		/// <para>Tool Excute Name : gapro.GeneralizedLinearRegression</para>
		/// </summary>
		public override string ExcuteName() => "gapro.GeneralizedLinearRegression";

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
		public override object[] Parameters() => new object[] { InputFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeatures, InputFeaturesToPredict!, ExplanatoryVariablesToMatch!, DependentVariableMapping!, OutputPredictedFeatures!, CoefficientTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含因变量和自变量的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>包含要进行建模的观测值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）— 因变量是连续的。将使用高斯模型，并且工具将执行普通最小二乘法回归。这是默认设置。</para>
		/// <para>二进制（逻辑）— 因变量表示存在或不存在。这可以是常规的 1 和 0，也可以是explanatory_variables_to_match参数中映射到 0 或 1 的字符串值。将使用逻辑回归模型。</para>
		/// <para>计数（泊松）—因变量是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。将使用泊松回归模型。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Explanatory Variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>将创建的包含因变量的估计数和残差的要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>一个图层，包含表示将计算评估值的位置的要素。此数据集中的每个要素都应包含指定的所有解释变量的值。将使用针对输入图层数据进行校准的模型来评估这些要素的因变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		[Category("Prediction Options")]
		public object? InputFeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>将输入预测要素参数中的解释变量与输入要素参数中的相应解释变量进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Map Dependent Variables</para>
		/// <para>表示用于映射到二元回归的 0（不存在）和 1（存在）的值的两个字符串。默认情况下将使用 0 和 1。例如，要预测一次具有“逮捕”和“未逮捕”字段值的逮捕，您需要为 False Value (0) 输入 No Arrest，并为 True Value (1) 输入 Arrest。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DependentVariableMapping { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>带有每个输入预测要素值的因变量估计数的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Prediction Options")]
		public object? OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Table of Coefficients Features</para>
		/// <para>带有每个输入预测要素值的因变量估计数的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? CoefficientTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneralizedLinearRegression SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>二进制（逻辑）— 因变量表示存在或不存在。这可以是常规的 1 和 0，也可以是explanatory_variables_to_match参数中映射到 0 或 1 的字符串值。将使用逻辑回归模型。</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("二进制（逻辑）")]
			BINARY,

			/// <summary>
			/// <para>连续（高斯）— 因变量是连续的。将使用高斯模型，并且工具将执行普通最小二乘法回归。这是默认设置。</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("连续（高斯）")]
			CONTINUOUS,

			/// <summary>
			/// <para>计数（泊松）—因变量是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。将使用泊松回归模型。</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("计数（泊松）")]
			COUNT,

		}

#endregion
	}
}
