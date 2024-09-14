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
	/// <para>Forest-based Forecast</para>
	/// <para>基于森林的预测</para>
	/// <para>使用 Leo Breiman 的随机森林算法的改编版本来预测时空立方体每个位置的值。 使用时空立方体的每个位置上的时间窗口来对森林回归模型进行训练。</para>
	/// </summary>
	public class ForestBasedForecast : AbstractGPProcess
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
		/// <para>时空立方体中所有位置的输出要素类，其中的预测值将存储为字段。 该图层显示对最后的时间步长的预测，并包含弹出图表，其中显示每个位置的时间序列、预测和 90% 的置信界限。</para>
		/// </param>
		public ForestBasedForecast(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于森林的预测</para>
		/// </summary>
		public override string DisplayName() => "基于森林的预测";

		/// <summary>
		/// <para>Tool Name : ForestBasedForecast</para>
		/// </summary>
		public override string ToolName() => "ForestBasedForecast";

		/// <summary>
		/// <para>Tool Excute Name : stpm.ForestBasedForecast</para>
		/// </summary>
		public override string ExcuteName() => "stpm.ForestBasedForecast";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, OutputCube, NumberOfTimeStepsToForecast, TimeWindow, NumberForValidation, NumberOfTrees, MinimumLeafSize, MaximumDepth, SampleSize, ForecastApproach, OutlierOption, LevelOfConfidence, MaximumNumberOfOutliers };

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
		/// <para>时空立方体中所有位置的输出要素类，其中的预测值将存储为字段。 该图层显示对最后的时间步长的预测，并包含弹出图表，其中显示每个位置的时间序列、预测和 90% 的置信界限。</para>
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
		/// <para>Time Step Window</para>
		/// <para>对模型进行训练时所要使用的先前时间步长数。 如果您的数据显示季节性（重复周期），提供与一个季节相对应的时间步数。 此值不能大于输入时空立方体中的时间步长数的三分之一。 如果未提供任何值，则使用光谱密度函数为每个位置估计一个时间窗。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object TimeWindow { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Exclude for Validation</para>
		/// <para>为进行验证，在每个时间序列末尾排除的时间步长数。默认值为输入时间步长的 10％（向下舍入），且该值不能大于时间步长的 25％。要不排除任何时间步长，请提供值 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberForValidation { get; set; }

		/// <summary>
		/// <para>Number of Trees</para>
		/// <para>要在森林模型中创建的树的数量。 增大树数通常将产生更加精确的模型预测，但是将增加模型计算的时间。 默认树数为 100，并且该值必须至少为 1 并且不大于 1,000。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 1000)]
		[Category("Advanced Forest Options")]
		public object NumberOfTrees { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Leaf Size</para>
		/// <para>保留叶子（未进一步进行分割的树上的终端节点）所需的最小观测值数。 对于非常大的数据，增大此数值将减少工具的运行时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object MinimumLeafSize { get; set; }

		/// <summary>
		/// <para>Maximum Tree Depth</para>
		/// <para>对树进行的最大分割数。 如果使用较大的最大深度，则将创建更多分割，这可能会增大过度拟合模型的可能性。 如果未提供任何值，则该工具将根据由模型创建的树数和时间步窗的大小确定一个值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100000000)]
		[Category("Advanced Forest Options")]
		public object MaximumDepth { get; set; }

		/// <summary>
		/// <para>Percentage of Training Available per Tree</para>
		/// <para>将用于拟合预测模型的训练数据的百分比。 训练数据由使用时间窗口构建的相关解释变量和因变量组成。 其余所有的训练数据将用于优化预测模型的参数。 默认值为 100%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Forest Options")]
		public object SampleSize { get; set; } = "100";

		/// <summary>
		/// <para>Forecast Approach</para>
		/// <para>指定在每个位置训练森林模型时将如何表示解释变量和因变量。</para>
		/// <para>要训练将用于预测的森林模型，必须使用时间窗创建一系列解释变量和因变量。 使用此参数可指定是否会对这些变量进行线性去除趋势，以及因变量将由其原始值还是由线性回归模型的残差表示。 该线性回归模型将时间窗口内的所有时间步长用作解释变量，并将以下时间步长用作因变量。 通过从因变量的原始值中基于线性回归减去预测值来计算残差。</para>
		/// <para>通过价值构建模型—时间窗内的值不会被去除趋势，并且因变量将由其原始值表示。</para>
		/// <para>去除趋势后通过价值构建模型—时间窗内的值被线性去除趋势，并且因变量将以其去除趋势的值表示。 这是默认设置。</para>
		/// <para>通过残差构建模型—时间窗内的值不会被去除趋势，并且将使用时间窗内的值作为解释变量的线性回归模型的残差来表示因变量。</para>
		/// <para>去除趋势后通过残差构建模型—时间窗内的值被线性去除趋势，并且使用时间窗内被去除趋势的值作为解释变量的线性回归模型的残差来表示因变量。</para>
		/// <para><see cref="ForecastApproachEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ForecastApproach { get; set; } = "VALUE_DETREND";

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
		public ForestBasedForecast SetEnviroment(object outputCoordinateSystem = null, object parallelProcessingFactor = null, object randomGenerator = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Forecast Approach</para>
		/// </summary>
		public enum ForecastApproachEnum 
		{
			/// <summary>
			/// <para>通过价值构建模型—时间窗内的值不会被去除趋势，并且因变量将由其原始值表示。</para>
			/// </summary>
			[GPValue("VALUE")]
			[Description("通过价值构建模型")]
			Build_model_by_value,

			/// <summary>
			/// <para>去除趋势后通过价值构建模型—时间窗内的值被线性去除趋势，并且因变量将以其去除趋势的值表示。 这是默认设置。</para>
			/// </summary>
			[GPValue("VALUE_DETREND")]
			[Description("去除趋势后通过价值构建模型")]
			Build_model_by_value_after_detrending,

			/// <summary>
			/// <para>通过残差构建模型—时间窗内的值不会被去除趋势，并且将使用时间窗内的值作为解释变量的线性回归模型的残差来表示因变量。</para>
			/// </summary>
			[GPValue("RESIDUAL")]
			[Description("通过残差构建模型")]
			Build_model_by_residual,

			/// <summary>
			/// <para>去除趋势后通过残差构建模型—时间窗内的值被线性去除趋势，并且使用时间窗内被去除趋势的值作为解释变量的线性回归模型的残差来表示因变量。</para>
			/// </summary>
			[GPValue("RESIDUAL_DETREND")]
			[Description("去除趋势后通过残差构建模型")]
			Build_model_by_residual_after_detrending,

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
