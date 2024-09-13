using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAITools
{
	/// <summary>
	/// <para>Predict Using AutoML</para>
	/// <para>使用 AutoML 进行预测</para>
	/// <para>使用通过使用 AutoML 进行训练工具生成的 .dlpk 训练模型来预测潜在兼容数据集上的连续变量（回归）或分类变量（分类）。</para>
	/// </summary>
	public class PredictUsingAutoML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>.dlpk 文件或 .emd 文件。</para>
		/// </param>
		/// <param name="PredictionType">
		/// <para>Prediction Type</para>
		/// <para>指定将创建的输出文件类型。</para>
		/// <para>预测要素—将创建一个包含预测值的要素图层。 此选项需要输出预测要素值。</para>
		/// <para>预测栅格—将创建一个包含预测值的栅格图层。 此选项需要输出预测表面值。</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Prediction Features</para>
		/// <para>将获取其预测的要素。 输入应包括确定因变量值所需的部分或全部字段。 如果预测类型参数设置为预测要素，则此参数为必需项。</para>
		/// </param>
		public PredictUsingAutoML(object InModelDefinition, object PredictionType, object InFeatures)
		{
			this.InModelDefinition = InModelDefinition;
			this.PredictionType = PredictionType;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用 AutoML 进行预测</para>
		/// </summary>
		public override string DisplayName() => "使用 AutoML 进行预测";

		/// <summary>
		/// <para>Tool Name : PredictUsingAutoML</para>
		/// </summary>
		public override string ToolName() => "PredictUsingAutoML";

		/// <summary>
		/// <para>Tool Excute Name : geoai.PredictUsingAutoML</para>
		/// </summary>
		public override string ExcuteName() => "geoai.PredictUsingAutoML";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAI Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAI Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoai</para>
		/// </summary>
		public override string ToolboxAlise() => "geoai";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InModelDefinition, PredictionType, InFeatures, ExplanatoryRasters!, DistanceFeatures!, OutPredictionFeatures!, OutPredictionSurface!, MatchExplanatoryVariables!, MatchDistanceVariables!, MatchExplanatoryRasters! };

		/// <summary>
		/// <para>Model Definition</para>
		/// <para>.dlpk 文件或 .emd 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("dlpk")]
		public object InModelDefinition { get; set; }

		/// <summary>
		/// <para>Prediction Type</para>
		/// <para>指定将创建的输出文件类型。</para>
		/// <para>预测要素—将创建一个包含预测值的要素图层。 此选项需要输出预测要素值。</para>
		/// <para>预测栅格—将创建一个包含预测值的栅格图层。 此选项需要输出预测表面值。</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PredictionType { get; set; } = "PREDICT_FEATURE";

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>将获取其预测的要素。 输入应包括确定因变量值所需的部分或全部字段。 如果预测类型参数设置为预测要素，则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Rasters</para>
		/// <para>包含确定因变量值所需的部分或全部字段的栅格列表。 如果预测类型参数设置为预测栅格，则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Distance Features</para>
		/// <para>将自动估计该要素与输入训练要素的距离并将其添加为其他解释变量。 将计算每个输入解释训练距离要素与最近的输入训练要素的距离。 如果输入解释训练距离要素为面要素或线要素，则距离属性将计算为要素对的最近线段之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Features</para>
		/// <para>输出表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? OutPredictionFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Surface</para>
		/// <para>将保存输出预测栅格的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? OutPredictionSurface { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>字段名称从预测集到训练集的映射。 测试要素类中的列和字段必须与训练期间提供的字段名称匹配。 字符串值是训练数据集中与输入要素类中的字段名称匹配的列名称。 仅当训练和测试数据集中相同的变量由不同名称标识时才需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? MatchExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Match Distance Variables</para>
		/// <para>距离要素名称从预测集到训练集的映射。 用于预测的距离要素名称必须与训练期间使用的相同距离要素匹配。 字符串值是用于预测的要素名称，与用于训练的距离要素名称相匹配。 仅当训练和预测期间使用的相同距离要素由不同名称标识时，才需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? MatchDistanceVariables { get; set; }

		/// <summary>
		/// <para>Match Explanatory Rasters</para>
		/// <para>字段名称从预测栅格到训练栅格的映射。 用于预测的解释栅格的名称必须与训练期间使用的相同解释栅格相匹配。 字符串值是用于预测的解释栅格名称，与用于训练的解释栅格名称相匹配。 仅当训练和预测期间使用的相同解释栅格由不同名称标识时，才需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? MatchExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PredictUsingAutoML SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Prediction Type</para>
		/// </summary>
		public enum PredictionTypeEnum 
		{
			/// <summary>
			/// <para>预测要素—将创建一个包含预测值的要素图层。 此选项需要输出预测要素值。</para>
			/// </summary>
			[GPValue("PREDICT_FEATURE")]
			[Description("预测要素")]
			Predict_feature,

			/// <summary>
			/// <para>预测栅格—将创建一个包含预测值的栅格图层。 此选项需要输出预测表面值。</para>
			/// </summary>
			[GPValue("PREDICT_RASTER")]
			[Description("预测栅格")]
			Predict_raster,

		}

#endregion
	}
}
