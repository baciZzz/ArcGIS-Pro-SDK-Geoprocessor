using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Generate Excel From Geodatabase</para>
	/// <para>Generate Excel From Geodatabase</para>
	/// <para>Creates a Microsoft Excel file (.xls or .xlsx) from the contents of a geodatabase.</para>
	/// </summary>
	public class GenerateExcelFromGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>The geodatabase that will be used to create the Excel spreadsheet.</para>
		/// </param>
		/// <param name="OutExcelFile">
		/// <para>Output Excel File</para>
		/// <para>The Excel file that will be created from the geodatabase.</para>
		/// </param>
		public GenerateExcelFromGeodatabase(object InGeodatabase, object OutExcelFile)
		{
			this.InGeodatabase = InGeodatabase;
			this.OutExcelFile = OutExcelFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Excel From Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Generate Excel From Geodatabase";

		/// <summary>
		/// <para>Tool Name : GenerateExcelFromGeodatabase</para>
		/// </summary>
		public override string ToolName() => "GenerateExcelFromGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateExcelFromGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GenerateExcelFromGeodatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeodatabase, OutExcelFile };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>The geodatabase that will be used to create the Excel spreadsheet.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Excel File</para>
		/// <para>The Excel file that will be created from the geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object OutExcelFile { get; set; }

	}
}
