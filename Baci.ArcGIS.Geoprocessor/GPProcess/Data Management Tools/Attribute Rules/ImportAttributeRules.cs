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
	/// <para>Import Attribute Rules</para>
	/// <para>导入属性规则</para>
	/// <para>用于将属性规则从逗号分隔值 (.csv) 文件导入到数据集中。</para>
	/// </summary>
	public class ImportAttributeRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>将应用属性规则的表或要素类。数据集必须具有规则定义中指定的所有要素。</para>
		/// </param>
		/// <param name="CsvFile">
		/// <para>Input File</para>
		/// <para>包含待导入规则的 .csv 文件。</para>
		/// </param>
		public ImportAttributeRules(object TargetTable, object CsvFile)
		{
			this.TargetTable = TargetTable;
			this.CsvFile = CsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入属性规则</para>
		/// </summary>
		public override string DisplayName() => "导入属性规则";

		/// <summary>
		/// <para>Tool Name : ImportAttributeRules</para>
		/// </summary>
		public override string ToolName() => "ImportAttributeRules";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportAttributeRules</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportAttributeRules";

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
		public override object[] Parameters() => new object[] { TargetTable, CsvFile, OutTable };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>将应用属性规则的表或要素类。数据集必须具有规则定义中指定的所有要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Input File</para>
		/// <para>包含待导入规则的 .csv 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object CsvFile { get; set; }

		/// <summary>
		/// <para>Attribute Rules Imported</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportAttributeRules SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
