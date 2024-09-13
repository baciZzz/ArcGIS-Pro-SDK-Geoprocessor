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
	/// <para>Set Subtype Field</para>
	/// <para>设置子类型字段</para>
	/// <para>为存储子类型编码的输入表或要素类定义字段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetSubtypeField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要设置为子类型字段的字段的输入表或要素类。</para>
		/// </param>
		public SetSubtypeField(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置子类型字段</para>
		/// </summary>
		public override string DisplayName() => "设置子类型字段";

		/// <summary>
		/// <para>Tool Name : SetSubtypeField</para>
		/// </summary>
		public override string ToolName() => "SetSubtypeField";

		/// <summary>
		/// <para>Tool Excute Name : management.SetSubtypeField</para>
		/// </summary>
		public override string ExcuteName() => "management.SetSubtypeField";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Field!, ClearValue!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要设置为子类型字段的字段的输入表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>将存储子类型编码的整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? Field { get; set; }

		/// <summary>
		/// <para>Clear Value</para>
		/// <para>指定是否清除子类型字段。</para>
		/// <para>选中 - 将清除子类型字段（设为空值）。</para>
		/// <para>未选中 - 不会清除子类型字段。这是默认设置。</para>
		/// <para><see cref="ClearValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClearValue { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetSubtypeField SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clear Value</para>
		/// </summary>
		public enum ClearValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_SUBTYPE_FIELD")]
			CLEAR_SUBTYPE_FIELD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR")]
			DO_NOT_CLEAR,

		}

#endregion
	}
}
