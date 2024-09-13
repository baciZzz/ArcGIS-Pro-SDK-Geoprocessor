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
	/// <para>普通最小二乘法 (OLS)</para>
	/// <para>执行全局“普通最小二乘法 (OLS)”线性回归可生成预测，也可为一个因变量针对它与一组解释变量关系建模。</para>
	/// </summary>
	public class OrdinaryLeastSquares : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>包含用于分析的因变量和自变量的要素类。</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将接收因变量的估计数和残差的输出要素类。</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>包含要尝试建模的值的数值字段。</para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variables</para>
		/// <para>表示回归模型中解释变量的字段列表。</para>
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
		/// <para>Tool Display Name : 普通最小二乘法 (OLS)</para>
		/// </summary>
		public override string DisplayName() => "普通最小二乘法 (OLS)";

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
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputFeatureClass, DependentVariable, ExplanatoryVariables, CoefficientOutputTable, DiagnosticOutputTable, OutputReportFile };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>包含用于分析的因变量和自变量的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将接收因变量的估计数和残差的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>包含要尝试建模的值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Explanatory Variables</para>
		/// <para>表示回归模型中解释变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Coefficient Output Table</para>
		/// <para>可选表的完整路径,该可选表将接收各解释变量的模型系数、标准化系数、标准误差和概率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object CoefficientOutputTable { get; set; }

		/// <summary>
		/// <para>Diagnostic Output Table</para>
		/// <para>将接收模型汇总诊断的可选表的完整路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object DiagnosticOutputTable { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>工具将创建的可选 PDF 文件的路径。此报表文件包括模型诊断、图表以及有助于您解释 OLS 结果的注释。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object OutputReportFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OrdinaryLeastSquares SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
