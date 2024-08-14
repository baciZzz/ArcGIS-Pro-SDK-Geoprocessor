using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Parse S-58 Log File</para>
	/// <para>Parses log files produced by the Validate S-57 File tool and third-party validation software against S-58 (recommended ENC validation checks). Critical errors and warnings are imported as records in a Data Reviewer table.</para>
	/// </summary>
	public class ParseS58LogFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InS58LogFile">
		/// <para>Input S-58 Log File</para>
		/// <para>The S-58 log file that contains validation errors. It can be an *.S58, *.ANL, or *.VLD file.</para>
		/// </param>
		/// <param name="InS57File">
		/// <para>Input S-57 File</para>
		/// <para>The base cell file (*.000) from which the validation result was produced. The name of the ENC cell referenced in this parameter must match the name of the ENC cell referenced in the validation log file.</para>
		/// </param>
		/// <param name="InProductionDatabaseWorkspace">
		/// <para>Production Database</para>
		/// <para>The workspace to validate and correct. This workspace contains the data used to generate the S-57 format file.</para>
		/// </param>
		/// <param name="InReviewerWorkspace">
		/// <para>Data Reviewer Workspace</para>
		/// <para>The path to the Data Reviewer workspace where the features or table records will be written. A Data Reviewer workspace must be created for each ENC product.</para>
		/// </param>
		/// <param name="ReviewerSession">
		/// <para>Data Reviewer Session</para>
		/// <para>An existing Data Reviewer session. The options are populated based on the sessions in the Data Reviewer workspace.</para>
		/// </param>
		public ParseS58LogFile(object InS58LogFile, object InS57File, object InProductionDatabaseWorkspace, object InReviewerWorkspace, object ReviewerSession)
		{
			this.InS58LogFile = InS58LogFile;
			this.InS57File = InS57File;
			this.InProductionDatabaseWorkspace = InProductionDatabaseWorkspace;
			this.InReviewerWorkspace = InReviewerWorkspace;
			this.ReviewerSession = ReviewerSession;
		}

		/// <summary>
		/// <para>Tool Display Name : Parse S-58 Log File</para>
		/// </summary>
		public override string DisplayName => "Parse S-58 Log File";

		/// <summary>
		/// <para>Tool Name : ParseS58LogFile</para>
		/// </summary>
		public override string ToolName => "ParseS58LogFile";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ParseS58LogFile</para>
		/// </summary>
		public override string ExcuteName => "maritime.ParseS58LogFile";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InS58LogFile, InS57File, InProductionDatabaseWorkspace, InReviewerWorkspace, ReviewerSession, InUpdateCells!, ParseCount! };

		/// <summary>
		/// <para>Input S-58 Log File</para>
		/// <para>The S-58 log file that contains validation errors. It can be an *.S58, *.ANL, or *.VLD file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InS58LogFile { get; set; }

		/// <summary>
		/// <para>Input S-57 File</para>
		/// <para>The base cell file (*.000) from which the validation result was produced. The name of the ENC cell referenced in this parameter must match the name of the ENC cell referenced in the validation log file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InS57File { get; set; }

		/// <summary>
		/// <para>Production Database</para>
		/// <para>The workspace to validate and correct. This workspace contains the data used to generate the S-57 format file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InProductionDatabaseWorkspace { get; set; }

		/// <summary>
		/// <para>Data Reviewer Workspace</para>
		/// <para>The path to the Data Reviewer workspace where the features or table records will be written. A Data Reviewer workspace must be created for each ENC product.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Data Reviewer Session</para>
		/// <para>An existing Data Reviewer session. The options are populated based on the sessions in the Data Reviewer workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ReviewerSession { get; set; }

		/// <summary>
		/// <para>Update Cells</para>
		/// <para>The cell files (*.001 - *.999) that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFileDomain()]
		public object? InUpdateCells { get; set; }

		/// <summary>
		/// <para>Log Parse Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? ParseCount { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ParseS58LogFile SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
