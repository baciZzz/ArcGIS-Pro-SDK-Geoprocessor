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
	/// <para>Evaluate Forecasts By Location</para>
	/// <para>按位置评估预测</para>
	/// <para>用于在多个预测结果中为时空立方体的每个位置选择最准确的结果。这使您可以在具有相同时间序列数据的时间序列预测工具集中使用多个工具，并为每个位置选择最佳预测。</para>
	/// </summary>
	public class EvaluateForecastsByLocation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCubes">
		/// <para>Input Forecast Space Time Cubes</para>
		/// <para>昆输入时空立方体包含要进行比较的预测。为了进行比较，必须根据相同的原始时间序列数据创建所有预测立方体。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>新的输出要素类表示时空立方体的位置以及包含每个位置上所选方法的预测值的字段。要素的弹出窗口将显示原始时间序列数据的图表以及所有方法的预测。</para>
		/// </param>
		public EvaluateForecastsByLocation(object InCubes, object OutputFeatures)
		{
			this.InCubes = InCubes;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 按位置评估预测</para>
		/// </summary>
		public override string DisplayName() => "按位置评估预测";

		/// <summary>
		/// <para>Tool Name : EvaluateForecastsByLocation</para>
		/// </summary>
		public override string ToolName() => "EvaluateForecastsByLocation";

		/// <summary>
		/// <para>Tool Excute Name : stpm.EvaluateForecastsByLocation</para>
		/// </summary>
		public override string ExcuteName() => "stpm.EvaluateForecastsByLocation";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCubes, OutputFeatures, OutputCube, EvaluateUsingValidationResults };

		/// <summary>
		/// <para>Input Forecast Space Time Cubes</para>
		/// <para>昆输入时空立方体包含要进行比较的预测。为了进行比较，必须根据相同的原始时间序列数据创建所有预测立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCubes { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>新的输出要素类表示时空立方体的位置以及包含每个位置上所选方法的预测值的字段。要素的弹出窗口将显示原始时间序列数据的图表以及所有方法的预测。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>输出时空立方体（.nc 文件）包含原始时间序列数据以及每个位置上的所选方法的预测。可视化 3D 时空立方体工具可用于同时查看原始值和预测值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Evaluate Using Validation Results</para>
		/// <para>指定将使用最小验证 RMSE 还是最小预测 RMSE 来确定位置的预测方法。</para>
		/// <para>选中 - 预测方法将使用最小验证 RMSE 进行确定。这是默认设置。</para>
		/// <para>未选中 - 预测方法将使用最小预测 RMSE 进行确定。</para>
		/// <para><see cref="EvaluateUsingValidationResultsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EvaluateUsingValidationResults { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EvaluateForecastsByLocation SetEnviroment(object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Evaluate Using Validation Results</para>
		/// </summary>
		public enum EvaluateUsingValidationResultsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_VALIDATION")]
			USE_VALIDATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_VALIDATION")]
			NO_VALIDATION,

		}

#endregion
	}
}
