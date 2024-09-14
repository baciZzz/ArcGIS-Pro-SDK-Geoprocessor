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
	/// <para>Import Contingent Values</para>
	/// <para>导入条件值</para>
	/// <para>将多个条件值和字段组从逗号分隔值文件 (.csv) 导入到数据集中。</para>
	/// </summary>
	public class ImportContingentValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>将向其中导入字段组和条件值的输入地理数据库表或要素类。</para>
		/// </param>
		/// <param name="FieldGroupFile">
		/// <para>Field Groups Input File (.csv)</para>
		/// <para>带有包含字段组相关信息的指定列名称的 .csv 文件。</para>
		/// </param>
		/// <param name="ContingentValueFile">
		/// <para>Contingent Values Input File (.csv)</para>
		/// <para>带有包含条件值相关信息的指定列名称的 .csv 文件。</para>
		/// </param>
		public ImportContingentValues(object TargetTable, object FieldGroupFile, object ContingentValueFile)
		{
			this.TargetTable = TargetTable;
			this.FieldGroupFile = FieldGroupFile;
			this.ContingentValueFile = ContingentValueFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入条件值</para>
		/// </summary>
		public override string DisplayName() => "导入条件值";

		/// <summary>
		/// <para>Tool Name : ImportContingentValues</para>
		/// </summary>
		public override string ToolName() => "ImportContingentValues";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportContingentValues</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportContingentValues";

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
		public override object[] Parameters() => new object[] { TargetTable, FieldGroupFile, ContingentValueFile, ImportType, UpdatedTable };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>将向其中导入字段组和条件值的输入地理数据库表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Groups Input File (.csv)</para>
		/// <para>带有包含字段组相关信息的指定列名称的 .csv 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object FieldGroupFile { get; set; }

		/// <summary>
		/// <para>Contingent Values Input File (.csv)</para>
		/// <para>带有包含条件值相关信息的指定列名称的 .csv 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object ContingentValueFile { get; set; }

		/// <summary>
		/// <para>Replace existing contingent values</para>
		/// <para>指定导入时将替换还是合并现有值。</para>
		/// <para>选中 - 目标表的现有值将被替换为输入 .csv 文件中的值。</para>
		/// <para>未选中 - 现有值将与输入 .csv 文件中的值合并。任何重复项都将被排除。这是默认设置。</para>
		/// <para><see cref="ImportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ImportType { get; set; } = "false";

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportContingentValues SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Replace existing contingent values</para>
		/// </summary>
		public enum ImportTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REPLACE")]
			REPLACE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("UNION")]
			UNION,

		}

#endregion
	}
}
