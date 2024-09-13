using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Add Date Attributes</para>
	/// <para>添加日期属性</para>
	/// <para>添加包含输入日期字段中的日期或时间属性的字段，例如星期全名、日、月和年。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddDateAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含待提取日期值的字段所在的图层或表。</para>
		/// </param>
		/// <param name="DateField">
		/// <para>Date Field</para>
		/// <para>将从中提取数据和时间属性以填充新字段值的日期字段。</para>
		/// </param>
		public AddDateAttributes(object InTable, object DateField)
		{
			this.InTable = InTable;
			this.DateField = DateField;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加日期属性</para>
		/// </summary>
		public override string DisplayName() => "添加日期属性";

		/// <summary>
		/// <para>Tool Name : AddDateAttributes</para>
		/// </summary>
		public override string ToolName() => "AddDateAttributes";

		/// <summary>
		/// <para>Tool Excute Name : ca.AddDateAttributes</para>
		/// </summary>
		public override string ExcuteName() => "ca.AddDateAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, DateField, DateAttributes!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含待提取日期值的字段所在的图层或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>将从中提取数据和时间属性以填充新字段值的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Date Attributes</para>
		/// <para>将添加到输入表的日期和时间属性以及字段。</para>
		/// <para>输出时间格式 - 将添加到输出字段名称的日期或时间属性。</para>
		/// <para>输出字段名称 - 将添加到输入表的字段的名称。</para>
		/// <para>输出时间格式选项如下：</para>
		/// <para>小时 - 介于 0 到 23 之间的小时值。</para>
		/// <para>星期全名 - 星期全名，例如，星期三。</para>
		/// <para>星期数值 - 介于 1 到 7 之间的星期值。</para>
		/// <para>月 - 介于 1 到 12 之间的月值。</para>
		/// <para>日 - 介于 1 到 31 之间日值。</para>
		/// <para>年 - 采用 yyyy 格式的年值，例如 1983。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? DateAttributes { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddDateAttributes SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
