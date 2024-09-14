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
	/// <para>Export Contingent Values</para>
	/// <para>Export Contingent Values</para>
	/// <para>Exports field groups and contingent values to a .csv file.</para>
	/// </summary>
	public class ExportContingentValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>The input geodatabase table or feature class from which the field groups and contingent values will be exported.</para>
		/// </param>
		/// <param name="FieldGroupsFile">
		/// <para>Field Groups Output File (.csv)</para>
		/// <para>The location and name of the output .csv file that will be created with specific column names containing information about the field groups of the target table.</para>
		/// </param>
		/// <param name="ContingentValuesFile">
		/// <para>Contingent Values Output File (.csv)</para>
		/// <para>The location and name of the output .csv file that will be created with specific column names containing information about the contingent values of the target table.</para>
		/// </param>
		public ExportContingentValues(object TargetTable, object FieldGroupsFile, object ContingentValuesFile)
		{
			this.TargetTable = TargetTable;
			this.FieldGroupsFile = FieldGroupsFile;
			this.ContingentValuesFile = ContingentValuesFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Contingent Values</para>
		/// </summary>
		public override string DisplayName() => "Export Contingent Values";

		/// <summary>
		/// <para>Tool Name : ExportContingentValues</para>
		/// </summary>
		public override string ToolName() => "ExportContingentValues";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportContingentValues</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportContingentValues";

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
		public override object[] Parameters() => new object[] { TargetTable, FieldGroupsFile, ContingentValuesFile };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>The input geodatabase table or feature class from which the field groups and contingent values will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Groups Output File (.csv)</para>
		/// <para>The location and name of the output .csv file that will be created with specific column names containing information about the field groups of the target table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object FieldGroupsFile { get; set; }

		/// <summary>
		/// <para>Contingent Values Output File (.csv)</para>
		/// <para>The location and name of the output .csv file that will be created with specific column names containing information about the contingent values of the target table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object ContingentValuesFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportContingentValues SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
