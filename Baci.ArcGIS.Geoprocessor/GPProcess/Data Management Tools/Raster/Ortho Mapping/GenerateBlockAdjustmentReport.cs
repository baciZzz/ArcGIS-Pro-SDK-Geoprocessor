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
	/// <para>Generates a  report after performing ortho mapping block adjustment to a mosaic dataset. The report is critical in evaluating the quality and accuracy of the ortho mapping products.</para>
	/// </summary>
	public class GenerateBlockAdjustmentReport : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset path.</para>
		/// </param>
		/// <param name="InputSolutionTable">
		/// <para>Input Solution Table</para>
		/// <para>The associated solution point table after block adjustment.</para>
		/// </param>
		/// <param name="InputSolutionPoint">
		/// <para>Input Solution Points</para>
		/// <para>The solution point feature class.</para>
		/// </param>
		/// <param name="OutputReport">
		/// <para>Output Report</para>
		/// <para>The output ortho mapping report file path and name. The supported output format for a website is HTML.</para>
		/// </param>
		public GenerateBlockAdjustmentReport(object InputMosaicDataset, object InputSolutionTable, object InputSolutionPoint, object OutputReport)
		{
			this.InputMosaicDataset = InputMosaicDataset;
			this.InputSolutionTable = InputSolutionTable;
			this.InputSolutionPoint = InputSolutionPoint;
			this.OutputReport = OutputReport;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Block Adjustment Report</para>
		/// </summary>
		public override string DisplayName => "Generate Block Adjustment Report";

		/// <summary>
		/// <para>Tool Name : GenerateBlockAdjustmentReport</para>
		/// </summary>
		public override string ToolName => "GenerateBlockAdjustmentReport";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateBlockAdjustmentReport</para>
		/// </summary>
		public override string ExcuteName => "management.GenerateBlockAdjustmentReport";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputMosaicDataset, InputSolutionTable, InputSolutionPoint, OutputReport, InputControlPointForAdjustment, ReportFormat };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset path.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Solution Table</para>
		/// <para>The associated solution point table after block adjustment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputSolutionTable { get; set; }

		/// <summary>
		/// <para>Input Solution Points</para>
		/// <para>The solution point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputSolutionPoint { get; set; }

		/// <summary>
		/// <para>Output Report</para>
		/// <para>The output ortho mapping report file path and name. The supported output format for a website is HTML.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutputReport { get; set; }

		/// <summary>
		/// <para>Input Control Points For Adjustment</para>
		/// <para>The associated control points table, which may include tie points and ground control points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object InputControlPointForAdjustment { get; set; }

		/// <summary>
		/// <para>Report Format</para>
		/// <para>The output format of the block adjustment report.</para>
		/// <para>HTML—Adjustment report is created as an HTML file. This is the default.</para>
		/// <para>PDF—Adjustment report is created as a PDF file.</para>
		/// <para><see cref="ReportFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReportFormat { get; set; } = "HTML";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateBlockAdjustmentReport SetEnviroment(object workspace = null )
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
			/// <para>HTML—Adjustment report is created as an HTML file. This is the default.</para>
			/// </summary>
			[GPValue("HTML")]
			[Description("HTML")]
			HTML,

			/// <summary>
			/// <para>PDF—Adjustment report is created as a PDF file.</para>
			/// </summary>
			[GPValue("PDF")]
			[Description("PDF")]
			PDF,

		}

#endregion
	}
}
