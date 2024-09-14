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
	/// <para>Pivot Table</para>
	/// <para>数据透视表</para>
	/// <para>通过在“输入表”中减少记录中的冗余并简化一对多关系来创建表。</para>
	/// </summary>
	public class PivotTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要透视的记录的表。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Input Fields</para>
		/// <para>用于定义要包含在输出表中的记录的字段。</para>
		/// </param>
		/// <param name="PivotField">
		/// <para>Pivot Field</para>
		/// <para>记录值将用于在输出表中生成字段名称的字段。</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value Field</para>
		/// <para>值将用于填充输出表中的透视表字段的字段。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>要创建的表。</para>
		/// </param>
		public PivotTable(object InTable, object Fields, object PivotField, object ValueField, object OutTable)
		{
			this.InTable = InTable;
			this.Fields = Fields;
			this.PivotField = PivotField;
			this.ValueField = ValueField;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 数据透视表</para>
		/// </summary>
		public override string DisplayName() => "数据透视表";

		/// <summary>
		/// <para>Tool Name : PivotTable</para>
		/// </summary>
		public override string ToolName() => "PivotTable";

		/// <summary>
		/// <para>Tool Excute Name : management.PivotTable</para>
		/// </summary>
		public override string ExcuteName() => "management.PivotTable";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Fields, PivotField, ValueField, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要透视的记录的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Fields</para>
		/// <para>用于定义要包含在输出表中的记录的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Pivot Field</para>
		/// <para>记录值将用于在输出表中生成字段名称的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object PivotField { get; set; }

		/// <summary>
		/// <para>Value Field</para>
		/// <para>值将用于填充输出表中的透视表字段的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>要创建的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PivotTable SetEnviroment(object? configKeyword = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
