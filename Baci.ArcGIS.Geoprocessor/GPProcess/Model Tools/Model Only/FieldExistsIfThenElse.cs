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
	/// <para>If Field Exists</para>
	/// <para>如果字段已存在</para>
	/// <para>用于评估输入数据是否具有指定字段。</para>
	/// </summary>
	public class FieldExistsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>将用于评估是否存在指定字段的输入表。</para>
		/// </param>
		/// <param name="FieldTestType">
		/// <para>Field Test</para>
		/// <para>用于测试指定字段列表的依据条件。</para>
		/// <para>必须具有所有字段—所有字段必须存在。</para>
		/// <para>必须至少具有一个字段—必须至少具有其中一个指定字段。</para>
		/// <para>不能具有所有字段—不能具有任意指定字段。</para>
		/// <para>不能只具有一个字段—不能至少具有其中一个指定字段。</para>
		/// <para><see cref="FieldTestTypeEnum"/></para>
		/// </param>
		/// <param name="Field">
		/// <para>Fields</para>
		/// <para>输入表中要检查的字段名称。</para>
		/// </param>
		public FieldExistsIfThenElse(object InTable, object FieldTestType, object Field)
		{
			this.InTable = InTable;
			this.FieldTestType = FieldTestType;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 如果字段已存在</para>
		/// </summary>
		public override string DisplayName() => "如果字段已存在";

		/// <summary>
		/// <para>Tool Name : FieldExistsIfThenElse</para>
		/// </summary>
		public override string ToolName() => "FieldExistsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.FieldExistsIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.FieldExistsIfThenElse";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, FieldTestType, Field, True!, False! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>将用于评估是否存在指定字段的输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Test</para>
		/// <para>用于测试指定字段列表的依据条件。</para>
		/// <para>必须具有所有字段—所有字段必须存在。</para>
		/// <para>必须至少具有一个字段—必须至少具有其中一个指定字段。</para>
		/// <para>不能具有所有字段—不能具有任意指定字段。</para>
		/// <para>不能只具有一个字段—不能至少具有其中一个指定字段。</para>
		/// <para><see cref="FieldTestTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldTestType { get; set; } = "MUST_HAVE_AT_LEAST_ONE_FIELD";

		/// <summary>
		/// <para>Fields</para>
		/// <para>输入表中要检查的字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Field { get; set; }

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Field Test</para>
		/// </summary>
		public enum FieldTestTypeEnum 
		{
			/// <summary>
			/// <para>必须具有所有字段—所有字段必须存在。</para>
			/// </summary>
			[GPValue("MUST_HAVE_ALL_FIELDS")]
			[Description("必须具有所有字段")]
			Must_have_all_fields,

			/// <summary>
			/// <para>必须至少具有一个字段—必须至少具有其中一个指定字段。</para>
			/// </summary>
			[GPValue("MUST_HAVE_AT_LEAST_ONE_FIELD")]
			[Description("必须至少具有一个字段")]
			Must_have_at_least_one_field,

			/// <summary>
			/// <para>不能具有所有字段—不能具有任意指定字段。</para>
			/// </summary>
			[GPValue("MUST_NOT_HAVE_ALL_FIELDS")]
			[Description("不能具有所有字段")]
			Must_not_have_all_fields,

			/// <summary>
			/// <para>不能只具有一个字段—不能至少具有其中一个指定字段。</para>
			/// </summary>
			[GPValue("MUST_NOT_HAVE_AT_LEAST_ONE_FIELD")]
			[Description("不能只具有一个字段")]
			Must_not_have_at_least_one_field,

		}

#endregion
	}
}
