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
	/// <para>Exploratory Regression</para>
	/// <para>探索性回归</para>
	/// <para>对输入的候选解释变量的所有可能组合进行评估，以便根据用户所指定的指标来查找能够最好地对因变量做出解释的 OLS 模型。</para>
	/// </summary>
	public class ExploratoryRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>包含要分析的因变量和候选解释变量的要素类或要素图层。</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>包含要使用 OLS 进行建模的观测值的数值型字段。</para>
		/// </param>
		/// <param name="CandidateExplanatoryVariables">
		/// <para>Candidate Explanatory Variables</para>
		/// <para>尝试作为 OLS 模型解释变量的字段列表。</para>
		/// </param>
		public ExploratoryRegression(object InputFeatures, object DependentVariable, object CandidateExplanatoryVariables)
		{
			this.InputFeatures = InputFeatures;
			this.DependentVariable = DependentVariable;
			this.CandidateExplanatoryVariables = CandidateExplanatoryVariables;
		}

		/// <summary>
		/// <para>Tool Display Name : 探索性回归</para>
		/// </summary>
		public override string DisplayName() => "探索性回归";

		/// <summary>
		/// <para>Tool Name : ExploratoryRegression</para>
		/// </summary>
		public override string ToolName() => "ExploratoryRegression";

		/// <summary>
		/// <para>Tool Excute Name : stats.ExploratoryRegression</para>
		/// </summary>
		public override string ExcuteName() => "stats.ExploratoryRegression";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, DependentVariable, CandidateExplanatoryVariables, WeightsMatrixFile, OutputReportFile, OutputResultsTable, MaximumNumberOfExplanatoryVariables, MinimumNumberOfExplanatoryVariables, MinimumAcceptableAdjRSquared, MaximumCoefficientPValueCutoff, MaximumVIFValueCutoff, MinimumAcceptableJarqueBeraPValue, MinimumAcceptableSpatialAutocorrelationPValue };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含要分析的因变量和候选解释变量的要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>包含要使用 OLS 进行建模的观测值的数值型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Candidate Explanatory Variables</para>
		/// <para>尝试作为 OLS 模型解释变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object CandidateExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>包含用于定义输入要素之间空间关系的空间权重的文件。此文件用于评估回归残差之间的空间自相关。您可以使用生成空间权重矩阵文件工具来创建此文件。尚未提供空间权重矩阵文件的情况下，将根据每个要素的 8 个最相邻像元对残差的空间自相关进行评估。</para>
		/// <para>注意：空间权重矩阵文件仅用于分析模型残差中的空间结构；不用于构建或校准任何 OLS 模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>报表文件包含工具结果，包括已通过您所输入的所有搜索条件的任何模型的相关详细信息。此输出文件还包含诊断信息，以帮助您在没有找到任何合格模型的情况下修复常见的回归问题。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutputReportFile { get; set; }

		/// <summary>
		/// <para>Output Results Table</para>
		/// <para>创建的可选输出表，包含系数 p 值和 VIF 值边界内所有模型的解释变量和诊断信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutputResultsTable { get; set; }

		/// <summary>
		/// <para>Maximum Number of Explanatory Variables</para>
		/// <para>将对解释变量数不超过此处输入值的所有模型进行评估。例如，如果解释变量的最小数量是 2，解释变量的最大数量是 3，探索性回归工具会对包含两个解释变量的任一组合的所有模型进行评估，还会对包含三个解释变量的任一组合的所有模型进行评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Search Criteria")]
		public object MaximumNumberOfExplanatoryVariables { get; set; } = "5";

		/// <summary>
		/// <para>Minimum Number of Explanatory Variables</para>
		/// <para>此值表示所评估模型的解释变量的最小数量。例如，如果解释变量的最小数量是 2，解释变量的最大数量是 3，探索性回归工具会对包含两个解释变量的任一组合的所有模型进行评估，还会对包含三个解释变量的任一组合的所有模型进行评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Search Criteria")]
		public object MinimumNumberOfExplanatoryVariables { get; set; } = "1";

		/// <summary>
		/// <para>Minimum Acceptable Adj R Squared</para>
		/// <para>这是您视为合格模型的最小校正可决系数值。如果模型已通过所有其他搜索条件，但“校正可决系数”值小于此处输入的值，则不会在输出报表文件中将其显示为“合格模型”。此参数的有效值范围是 0.0 至 1.0。默认值为 0.05，表示合格模型将解释因变量中至少 50% 的变化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object MinimumAcceptableAdjRSquared { get; set; } = "0.5";

		/// <summary>
		/// <para>Maximum Coefficient p value Cutoff</para>
		/// <para>对于所评估的每个模型，OLS 会计算解释变量系数 p 值。此处输入的边界 p 值表示模型中所有系数所需的置信度，需要达到此置信度才能认为模型满足条件。p 值较小表示置信度较强。此参数有效值的范围是 1.0 至 0.0，但很可能是 0.1、0.05、0.01、0.001 等等。默认值是 0.05，表示合格模型只包含其系数在统计学上处于 95% 置信度（p 值小于 0.05）的解释变量。要放宽此默认值，则应输入较大的 p 值边界，例如 0.1。如果得到的合格模型较多，则您可能希望使此搜索条件更为严格，那么可以将默认 p 值边界从 0.05 减小为 0.01 或者更小的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object MaximumCoefficientPValueCutoff { get; set; } = "0.05";

		/// <summary>
		/// <para>Maximum VIF Value Cutoff</para>
		/// <para>此值表示您可接受的模型解释变量之间的冗余（多重共线性）。当 VIF（方差膨胀因子）值高于 7.5 时，多重共线性会使模型变得不稳定；因此，此处的默认值是 7.5。如果您想让合格模型具有更少的冗余，则应为此参数输入较小的值，如 5.0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 99999999)]
		[Category("Search Criteria")]
		public object MaximumVIFValueCutoff { get; set; } = "7.5";

		/// <summary>
		/// <para>Minimum Acceptable Jarque Bera p value</para>
		/// <para>Jarque-Bera 诊断检验所返回的 p 值将表示模型残差是否呈正态分布。如果 p 值在统计学上具有显著性（小），则模型残差不呈现正态分布，模型有偏差。合格模型应具有较大的 Jarque-Bera p 值。默认可接受的最小 p 值是 0.1。只有返回的 p 值大于此最小值的模型才被认为是合格的。如果查找无偏合格模型很困难，并决定放宽此条件，则可以输入更小的最小 p 值，如 0.05。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object MinimumAcceptableJarqueBeraPValue { get; set; } = "0.1";

		/// <summary>
		/// <para>Minimum Acceptable Spatial Autocorrelation p value</para>
		/// <para>对于通过所有其他搜索条件的模型，探索性回归工具将使用 Global Moran's I 对模型残差进行空间聚类检查。当此诊断检验的 p 值在统计学上具有显著性（小）时，表示该模型很可能缺少关键的解释变量（不能说明整个情况）。遗憾的是，如果回归残差中存在空间自相关，则模型将被错误指定，因此您的结果是无法信任的。对于此诊断检验，合格模型应具有较大的 p 值。默认的最小 p 值是 0.1。只有返回的 p 值大于此最小值的模型才被认为是合格的。如果对于此诊断检验，查找正确指定的模型很困难，并决定放宽此搜索条件，则可以输入更小的最小值，如 0.05。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object MinimumAcceptableSpatialAutocorrelationPValue { get; set; } = "0.1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExploratoryRegression SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
