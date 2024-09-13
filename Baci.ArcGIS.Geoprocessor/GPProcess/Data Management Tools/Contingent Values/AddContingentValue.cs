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
	/// <para>Add Contingent Value</para>
	/// <para>添加条件值</para>
	/// <para>向要素类或表中的字段组添加条件值。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddContingentValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>要添加条件值的输入地理数据库要素类或表。</para>
		/// </param>
		/// <param name="FieldGroupName">
		/// <para>Field Group Name</para>
		/// <para>要添加条件值的字段组。</para>
		/// </param>
		/// <param name="Values">
		/// <para>Values</para>
		/// <para>将用于新条件值的字段名、字段值类型和相关字段值。</para>
		/// <para>字段名 - 参与字段组的字段名称</para>
		/// <para>字段值类型 - 条件值的类型。 “Any”和“Null”类型将忽略字段值字段中指定的任何值。</para>
		/// <para>Any - 该值可以为任意字段值。</para>
		/// <para>Null - 该值为空。</para>
		/// <para>编码值 - 该值来自于编码值属性域。</para>
		/// <para>范围 - 该值为范围属性域的最小/最大子集。</para>
		/// <para>字段值 - 特定字段值。 如果字段值类型为编码值，请指定编码描述。 如果字段值类型为范围，则请以“最小值;最大值”（例如 10;100）的格式指定最小值和最大值。</para>
		/// </param>
		public AddContingentValue(object TargetTable, object FieldGroupName, object Values)
		{
			this.TargetTable = TargetTable;
			this.FieldGroupName = FieldGroupName;
			this.Values = Values;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加条件值</para>
		/// </summary>
		public override string DisplayName() => "添加条件值";

		/// <summary>
		/// <para>Tool Name : AddContingentValue</para>
		/// </summary>
		public override string ToolName() => "AddContingentValue";

		/// <summary>
		/// <para>Tool Excute Name : management.AddContingentValue</para>
		/// </summary>
		public override string ExcuteName() => "management.AddContingentValue";

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
		public override object[] Parameters() => new object[] { TargetTable, FieldGroupName, Values, Subtype!, RetireValue!, OutTable! };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>要添加条件值的输入地理数据库要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Group Name</para>
		/// <para>要添加条件值的字段组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldGroupName { get; set; }

		/// <summary>
		/// <para>Values</para>
		/// <para>将用于新条件值的字段名、字段值类型和相关字段值。</para>
		/// <para>字段名 - 参与字段组的字段名称</para>
		/// <para>字段值类型 - 条件值的类型。 “Any”和“Null”类型将忽略字段值字段中指定的任何值。</para>
		/// <para>Any - 该值可以为任意字段值。</para>
		/// <para>Null - 该值为空。</para>
		/// <para>编码值 - 该值来自于编码值属性域。</para>
		/// <para>范围 - 该值为范围属性域的最小/最大子集。</para>
		/// <para>字段值 - 特定字段值。 如果字段值类型为编码值，请指定编码描述。 如果字段值类型为范围，则请以“最小值;最大值”（例如 10;100）的格式指定最小值和最大值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object Values { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>要添加条件值的输入表子类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Subtype { get; set; }

		/// <summary>
		/// <para>Retire Value</para>
		/// <para>指定是否停用条件值。 如果不再创建条件值，但其仍可在现有字段中使用，则将此条件值视为停用状态。 停用一个条件值后，它仍然会显示在字段的有限值列表中（例如，在属性窗格中），但处于非活动状态，此时您将无法将其选为字段值。 例如，将石棉用作建筑材料时。 新的构造无法使用石棉作为建筑材料，但是现有结构可能仍然具有此属性。</para>
		/// <para>选中 - 将停用条件值。</para>
		/// <para>未选中 - 不会停用条件值。 这是默认设置。</para>
		/// <para><see cref="RetireValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RetireValue { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddContingentValue SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Retire Value</para>
		/// </summary>
		public enum RetireValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RETIRE")]
			RETIRE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RETIRE")]
			DO_NOT_RETIRE,

		}

#endregion
	}
}
