using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Get Field Value</para>
	/// <para>获取字段值</para>
	/// <para>为指定字段返回表中首行的值。</para>
	/// </summary>
	public class GetFieldValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要从中获取值的输入表。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>要从中获取值的输入字段。 将输出第一条记录的值。</para>
		/// </param>
		public GetFieldValue(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取字段值</para>
		/// </summary>
		public override string DisplayName() => "获取字段值";

		/// <summary>
		/// <para>Tool Name : GetFieldValue</para>
		/// </summary>
		public override string ToolName() => "GetFieldValue";

		/// <summary>
		/// <para>Tool Excute Name : mb.GetFieldValue</para>
		/// </summary>
		public override string ExcuteName() => "mb.GetFieldValue";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Field, DataType!, NullValue!, Value! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要从中获取值的输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>要从中获取值的输入字段。 将输出第一条记录的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>输出的数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; } = "String";

		/// <summary>
		/// <para>Null Value</para>
		/// <para>用于空值的输出。 数字的默认值为 0，字符串的默认值为空 ("")。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NullValue { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object? Value { get; set; }

	}
}
