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
	/// <para>导出条件值</para>
	/// <para>将字段组和条件值导出为 .csv 文件。</para>
	/// </summary>
	public class ExportContingentValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>将从其中导出字段组和条件值的输入地理数据库表或要素类。</para>
		/// </param>
		/// <param name="FieldGroupsFile">
		/// <para>Field Groups Output File (.csv)</para>
		/// <para>将使用包含目标表的字段组相关信息的指定列名称 创建的输出 .csv 文件的位置和名称。</para>
		/// </param>
		/// <param name="ContingentValuesFile">
		/// <para>Contingent Values Output File (.csv)</para>
		/// <para>将使用包含目标表的条件值相关信息的指定列名称创建的输出 .csv 文件的位置和名称。</para>
		/// </param>
		public ExportContingentValues(object TargetTable, object FieldGroupsFile, object ContingentValuesFile)
		{
			this.TargetTable = TargetTable;
			this.FieldGroupsFile = FieldGroupsFile;
			this.ContingentValuesFile = ContingentValuesFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出条件值</para>
		/// </summary>
		public override string DisplayName() => "导出条件值";

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
		/// <para>将从其中导出字段组和条件值的输入地理数据库表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Groups Output File (.csv)</para>
		/// <para>将使用包含目标表的字段组相关信息的指定列名称 创建的输出 .csv 文件的位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object FieldGroupsFile { get; set; }

		/// <summary>
		/// <para>Contingent Values Output File (.csv)</para>
		/// <para>将使用包含目标表的条件值相关信息的指定列名称创建的输出 .csv 文件的位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object ContingentValuesFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportContingentValues SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
