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
		/// <param name="OutputFeaturesName">
		/// <para>Output Features Name</para>
		/// <para>将创建的包含因变量的估计数和残差的要素类的名称。</para>
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
		/// <para>Tool Display Name : 广义线性回归</para>
		/// </summary>
		public override string DisplayName() => "广义线性回归";

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
		/// <para>包含因变量和自变量的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
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
		/// <para>Output Features Name</para>
		/// <para>将创建的包含因变量的估计数和残差的要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputFeaturesName { get; set; }

		/// <summary>
		/// <para>Generate Coefficient Table</para>
		/// <para>指定是否将生成具有系数（布尔）值的输出表。</para>
		/// <para>选中 - 将生成具有系数值的表。</para>
		/// <para>未选中 - 将不会生成具有系数值的表。这是默认设置。</para>
		/// <para><see cref="GenerateCoefficientTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateCoefficientTable { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>一个图层，包含表示将计算评估值的位置的要素。此数据集中的每个要素都应包含指定的所有解释变量的值。将使用针对输入图层数据进行校准的模型来评估这些要素的因变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		[Category("Prediction Options")]
		public object InputFeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>将输入预测要素参数中的解释变量与输入要素参数中的相应解释变量进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Map Dependent Variables</para>
		/// <para>表示用于映射到二元回归的 0（不存在）和 1（存在）的值的两个字符串。默认情况下将使用 0 和 1。例如，要预测一次具有“逮捕”和“未逮捕”字段值的逮捕，您需要为 False Value (0) 输入 No Arrest，并为 True Value (1) 输入 Arrest。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object DependentVariableMapping { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
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
		public GeneralizedLinearRegression SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
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

		/// <summary>
		/// <para>Generate Coefficient Table</para>
		/// </summary>
		public enum GenerateCoefficientTableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_TABLE")]
			CREATE_TABLE,

			/// <summary>
			/// <para></para>
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
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
