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
	/// <para>Export Attribute Rules</para>
	/// <para>导出属性规则</para>
	/// <para>将属性规则从数据集导出到逗号分隔值 (.csv) 文件。</para>
	/// </summary>
	public class ExportAttributeRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>将从中导出属性规则的表或要素类。</para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output File</para>
		/// <para>待创建的 .csv 文件的文件夹位置和名称。</para>
		/// </param>
		public ExportAttributeRules(object InTable, object OutCsvFile)
		{
			this.InTable = InTable;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出属性规则</para>
		/// </summary>
		public override string DisplayName() => "导出属性规则";

		/// <summary>
		/// <para>Tool Name : ExportAttributeRules</para>
		/// </summary>
		public override string ToolName() => "ExportAttributeRules";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportAttributeRules</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportAttributeRules";

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
		public override object[] Parameters() => new object[] { InTable, OutCsvFile };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>将从中导出属性规则的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>待创建的 .csv 文件的文件夹位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportAttributeRules SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
