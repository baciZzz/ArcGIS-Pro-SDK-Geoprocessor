using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Curve Fit Forecast</para>
	/// <para>曲线拟合预测</para>
	/// <para>用于通过曲线拟合来预测时空立方体每个位置的值。</para>
	/// </summary>
	public class CurveFitForecast : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>netCDF 立方体包含用于预测未来时间步的变量。此文件必须具有 .nc 文件扩展名，并且必须使用通过聚合点创建时空立方体、通过已定义位置创建时空立方体或通过多维栅格图层创建时空立方体工具进行创建。</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>netCDF 文件中的数值变量，用于预测未来时间步长。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>时空立方体中所有位置的输出要素类，其中的预测值将存储为字段。该图层显示对最后的时间步长的预测，并包含弹出图表，其中显示每个位置的时间序列和预测。</para>
		/// </param>
		public CurveFitForecast(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 曲线拟合预测</para>
		/// </summary>
		public override string DisplayName() => "曲线拟合预测";

		/// <summary>
		/// <para>Tool Name : CurveFitForecast</para>
		/// </summary>
		public override string ToolName() => "CurveFitForecast";

		/// <summary>
		/// <para>Tool Excute Name : stpm.CurveFitForecast</para>
		/// </summary>
		public override string ExcuteName() => "stpm.CurveFitForecast";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, OutputCube, NumberOfTimeStepsToForecast, CurveType, NumberForValidation, OutlierOption, LevelOfConfidence, MaximumNumberOfOutliers };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>netCDF 立方体包含用于预测未来时间步的变量。此文件必须具有 .nc 文件扩展名，并且必须使用通过聚合点创建时空立方体、通过已定义位置创建时空立方体或通过多维栅格图层创建时空立方体工具进行创建。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>netCDF 文件中的数值变量，用于预测未来时间步长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>时空立方体中所有位置的输出要素类，其中的预测值将存储为字段。该图层显示对最后的时间步长的预测，并包含弹出图表，其中显示每个位置的时间序列和预测。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>新的时空立方体（.nc 文件），其中包含输入时空立方体的值，并追加了预测时间步长。可视化 3D 时空立方体工具可用于同时查看所有观测值和预测值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Forecast</para>
		/// <para>正整数，用于指定预测时间步长数。此值不能大于输入时空立方体中的时间步长数的百分之五十。默认值为一个时间步长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfTimeStepsToForecast { get; set; } = "1";

		/// <summary>
		/// <para>Curve Type</para>
		/// <para>指定曲线类型以用于预测输入时空立方体的值。</para>
		/// <para>线性—时间序列随时间呈线性增加或减少。</para>
		/// <para>抛物线—时间序列随时间呈抛物线或二次曲线变化。</para>
		/// <para>指数—时间序列随时间呈指数性增加或减少。</para>
		/// <para>S 型 (Gompertz)—时间序列随时间呈 S 型增加或减少。</para>
		/// <para>自动检测—在各个位置运行所有四种曲线类型，随后模型将提供最小“验证 RMSE”值。如果未为进行验证排除任何时间片，则使用“预测 RMSE”值最小的模型。这是默认设置。</para>
		/// <para><see cref="CurveTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CurveType { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Number of Time Steps to Exclude for Validation</para>
		/// <para>为进行验证，在每个时间序列末尾排除的时间步长数。默认值为输入时间步长的 10％（向下舍入），且该值不能大于时间步长的 25％。要不排除任何时间步长，请提供值 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberForValidation { get; set; }

		/// <summary>
		/// <para>Outlier Option</para>
		/// <para>指定是否将识别具有统计意义的时间序列异常值。</para>
		/// <para>无—不会识别异常值。这是默认设置。</para>
		/// <para>识别异常值—将使用广义 ESD 测试来识别异常值。</para>
		/// <para><see cref="OutlierOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutlierOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Level of Confidence</para>
		/// <para>指定时间序列异常值测试的置信度。</para>
		/// <para>90%—测试置信度为 90％。这是默认设置。</para>
		/// <para>95%—测试置信度为 95％。</para>
		/// <para>99%—测试置信度为 99％。</para>
		/// <para><see cref="LevelOfConfidenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LevelOfConfidence { get; set; } = "90%";

		/// <summary>
		/// <para>Maximum Number of Outliers</para>
		/// <para>每个位置可以声明为异常值的最大时间步数。默认值对应于输入时空立方体的时间步数的 5％（向下舍入）（将始终使用至少为 1 的值）。该值不能超过时间步数的 20％。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaximumNumberOfOutliers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CurveFitForecast SetEnviroment(object outputCoordinateSystem = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Curve Type</para>
		/// </summary>
		public enum CurveTypeEnum 
		{
			/// <summary>
			/// <para>线性—时间序列随时间呈线性增加或减少。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>抛物线—时间序列随时间呈抛物线或二次曲线变化。</para>
			/// </summary>
			[GPValue("PARABOLIC")]
			[Description("抛物线")]
			Parabolic,

			/// <summary>
			/// <para>指数—时间序列随时间呈指数性增加或减少。</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数")]
			Exponential,

			/// <summary>
			/// <para>S 型 (Gompertz)—时间序列随时间呈 S 型增加或减少。</para>
			/// </summary>
			[GPValue("GOMPERTZ")]
			[Description("S 型 (Gompertz)")]
			GOMPERTZ,

			/// <summary>
			/// <para>自动检测—在各个位置运行所有四种曲线类型，随后模型将提供最小“验证 RMSE”值。如果未为进行验证排除任何时间片，则使用“预测 RMSE”值最小的模型。这是默认设置。</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("自动检测")]
			AUTO_DETECT,

		}

		/// <summary>
		/// <para>Outlier Option</para>
		/// </summary>
		public enum OutlierOptionEnum 
		{
			/// <summary>
			/// <para>无—不会识别异常值。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>识别异常值—将使用广义 ESD 测试来识别异常值。</para>
			/// </summary>
			[GPValue("IDENTIFY")]
			[Description("识别异常值")]
			Identify_outliers,

		}

		/// <summary>
		/// <para>Level of Confidence</para>
		/// </summary>
		public enum LevelOfConfidenceEnum 
		{
			/// <summary>
			/// <para>90%—测试置信度为 90％。这是默认设置。</para>
			/// </summary>
			[GPValue("90%")]
			[Description("90%")]
			_90percent,

			/// <summary>
			/// <para>95%—测试置信度为 95％。</para>
			/// </summary>
			[GPValue("95%")]
			[Description("95%")]
			_95percent,

			/// <summary>
			/// <para>99%—测试置信度为 99％。</para>
			/// </summary>
			[GPValue("99%")]
			[Description("99%")]
			_99percent,

		}

#endregion
	}
}
