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
	/// <para>Assign Default To Field</para>
	/// <para>为字段分配默认值</para>
	/// <para>为指定字段创建默认值。一旦向表或要素类添加一个新行，就会将指定字段设置为该默认值。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AssignDefaultToField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要向其中一个字段添加默认值的输入表或要素类。</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>每次向表或要素类添加新行时都会添加默认值的字段。</para>
		/// </param>
		public AssignDefaultToField(object InTable, object FieldName)
		{
			this.InTable = InTable;
			this.FieldName = FieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : 为字段分配默认值</para>
		/// </summary>
		public override string DisplayName() => "为字段分配默认值";

		/// <summary>
		/// <para>Tool Name : AssignDefaultToField</para>
		/// </summary>
		public override string ToolName() => "AssignDefaultToField";

		/// <summary>
		/// <para>Tool Excute Name : management.AssignDefaultToField</para>
		/// </summary>
		public override string ExcuteName() => "management.AssignDefaultToField";

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
		public override object[] Parameters() => new object[] { InTable, FieldName, DefaultValue!, SubtypeCode!, ClearValue!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要向其中一个字段添加默认值的输入表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>每次向表或要素类添加新行时都会添加默认值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Default Value</para>
		/// <para>要添加到每个新表或要素类的默认值。所输入的值必须与字段的数据类型相匹配。如果已向所选字段分配了编码值属性域，则该编码属性域中的值将包含在参数值列表中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DefaultValue { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>可添加到默认值的子类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? SubtypeCode { get; set; }

		/// <summary>
		/// <para>Clear Value</para>
		/// <para>指定是清除字段的默认值还是子类型的默认值。要清除字段的默认值，默认值参数必须为空。要清除子类型的默认值，请将默认值参数留空并指定要清除默认值的子类型。</para>
		/// <para>选中 - 将清除默认值（设为空值）。默认值参数必须为空。</para>
		/// <para>未选中 - 不会清除默认值。这是默认设置。</para>
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
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AssignDefaultToField SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
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
			[Description("CLEAR_VALUE")]
			CLEAR_VALUE,

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
