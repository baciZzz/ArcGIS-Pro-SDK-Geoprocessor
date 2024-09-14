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
	/// <para>Generalized Linear Regression</para>
	/// <para>广义线性回归</para>
	/// <para>执行广义线性回归 (GLR) 以生成预测，或对因变量与一组解释变量的关系进行建模。 此工具可用于拟合连续 (OLS)、二进制（逻辑）和计数（泊松）模型。</para>
	/// </summary>
	public class GeneralizedLinearRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含因变量和自变量的要素类。</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>包含要进行建模的观测值的数值字段。</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）—因变量值是连续的。 使用的模型为高斯模型，并且工具将执行普通最小二乘法回归。</para>
		/// <para>二进制（逻辑）—因变量值表示存在或不存在。 这可以是常规的 1 和 0，或者是基于某个阈值重新进行编码的连续数据。 使用的模型为逻辑回归。</para>
		/// <para>计数（泊松）—因变量值是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。 使用的模型为泊松回归。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>新要素类，其中将包含因变量的估计数和残差。</para>
		/// </param>
		public GeneralizedLinearRegression(object InFeatures, object DependentVariable, object ModelType, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.DependentVariable = DependentVariable;
			this.ModelType = ModelType;
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
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ModelType, OutputFeatures, ExplanatoryVariables!, DistanceFeatures!, PredictionLocations!, ExplanatoryVariablesToMatch!, ExplanatoryDistanceMatching!, OutputPredictedFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含因变量和自变量的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>包含要进行建模的观测值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）—因变量值是连续的。 使用的模型为高斯模型，并且工具将执行普通最小二乘法回归。</para>
		/// <para>二进制（逻辑）—因变量值表示存在或不存在。 这可以是常规的 1 和 0，或者是基于某个阈值重新进行编码的连续数据。 使用的模型为逻辑回归。</para>
		/// <para>计数（泊松）—因变量值是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。 使用的模型为泊松回归。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Output Features</para>
		/// <para>新要素类，其中将包含因变量的估计数和残差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Distance Features</para>
		/// <para>通过计算给定要素与输入要素值的距离可自动创建解释变量。 将计算每个输入解释距离要素值与最近的输入要素值的距离。 如果输入解释距离要素值为面要素或线要素，则距离属性将计算为要素对的最近线段之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point", "Polyline")]
		[FeatureType("Simple")]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Prediction Locations</para>
		/// <para>一种要素类，包含表示将计算评估值的位置的要素。 此数据集中的每个要素都应包含指定的所有解释变量的值。 将使用针对输入要素类数据进行校准的模型来评估这些要素的因变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		[Category("Prediction Options")]
		public object? PredictionLocations { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>将预测位置参数中的解释变量与输入要素类参数中的相应解释变量进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Match Distance Features</para>
		/// <para>将针对左侧预测位置参数指定的距离要素与右侧输入要素参数的相应距离要素进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryDistanceMatching { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>将接收每个预测位置值的因变量估计数的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object? OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneralizedLinearRegression SetEnviroment(object? outputCoordinateSystem = null)
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
			/// <para>连续（高斯）—因变量值是连续的。 使用的模型为高斯模型，并且工具将执行普通最小二乘法回归。</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("连续（高斯）")]
			CONTINUOUS,

			/// <summary>
			/// <para>二进制（逻辑）—因变量值表示存在或不存在。 这可以是常规的 1 和 0，或者是基于某个阈值重新进行编码的连续数据。 使用的模型为逻辑回归。</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("二进制（逻辑）")]
			BINARY,

			/// <summary>
			/// <para>计数（泊松）—因变量值是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。 使用的模型为泊松回归。</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("计数（泊松）")]
			COUNT,

		}

#endregion
	}
}
