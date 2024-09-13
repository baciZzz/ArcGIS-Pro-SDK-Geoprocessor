using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Generate Block Adjustment Report</para>
	/// <para>生成区域网平差报告</para>
	/// <para>对镶嵌数据集执行正射映射区域网平差后将生成报告。该报告对于评估正射映射产品的质量和精度来说至关重要。</para>
	/// </summary>
	public class GenerateBlockAdjustmentReport : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>输入镶嵌数据集路径。</para>
		/// </param>
		/// <param name="InputSolutionTable">
		/// <para>Input Solution Table</para>
		/// <para>区域网平差后的关联解决方案点表。</para>
		/// </param>
		/// <param name="InputSolutionPoint">
		/// <para>Input Solution Points</para>
		/// <para>解决方案点要素类。</para>
		/// </param>
		/// <param name="OutputReport">
		/// <para>Output Report</para>
		/// <para>输出正射映射报告文件路径和名称。网站支持的输出格式为 HTML。</para>
		/// </param>
		public GenerateBlockAdjustmentReport(object InputMosaicDataset, object InputSolutionTable, object InputSolutionPoint, object OutputReport)
		{
			this.InputMosaicDataset = InputMosaicDataset;
			this.InputSolutionTable = InputSolutionTable;
			this.InputSolutionPoint = InputSolutionPoint;
			this.OutputReport = OutputReport;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成区域网平差报告</para>
		/// </summary>
		public override string DisplayName() => "生成区域网平差报告";

		/// <summary>
		/// <para>Tool Name : GenerateBlockAdjustmentReport</para>
		/// </summary>
		public override string ToolName() => "GenerateBlockAdjustmentReport";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateBlockAdjustmentReport</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateBlockAdjustmentReport";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMosaicDataset, InputSolutionTable, InputSolutionPoint, OutputReport, InputControlPointForAdjustment!, ReportFormat! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>输入镶嵌数据集路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Solution Table</para>
		/// <para>区域网平差后的关联解决方案点表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputSolutionTable { get; set; }

		/// <summary>
		/// <para>Input Solution Points</para>
		/// <para>解决方案点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputSolutionPoint { get; set; }

		/// <summary>
		/// <para>Output Report</para>
		/// <para>输出正射映射报告文件路径和名称。网站支持的输出格式为 HTML。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutputReport { get; set; }

		/// <summary>
		/// <para>Input Control Points For Adjustment</para>
		/// <para>包含连接点和地面控制点的关联控制点表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InputControlPointForAdjustment { get; set; }

		/// <summary>
		/// <para>Report Format</para>
		/// <para>区域网平差报告的输出格式。</para>
		/// <para>HTML—将平差报告创建为 HTML 文件。这是默认设置。</para>
		/// <para>PDF—将平差报告创建为 PDF 文件。</para>
		/// <para><see cref="ReportFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReportFormat { get; set; } = "HTML";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateBlockAdjustmentReport SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Report Format</para>
		/// </summary>
		public enum ReportFormatEnum 
		{
			/// <summary>
			/// <para>HTML—将平差报告创建为 HTML 文件。这是默认设置。</para>
			/// </summary>
			[GPValue("HTML")]
			[Description("HTML")]
			HTML,

			/// <summary>
			/// <para>PDF—将平差报告创建为 PDF 文件。</para>
			/// </summary>
			[GPValue("PDF")]
			[Description("PDF")]
			PDF,

		}

#endregion
	}
}
