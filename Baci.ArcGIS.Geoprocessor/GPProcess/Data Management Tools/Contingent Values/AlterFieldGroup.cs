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
	/// <para>Alter Field Group</para>
	/// <para>更改字段组</para>
	/// <para>用于更改字段组的属性。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterFieldGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>包含要更改的字段组的表。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Field Group Name</para>
		/// <para>要更改的字段组的名称。</para>
		/// </param>
		public AlterFieldGroup(object TargetTable, object Name)
		{
			this.TargetTable = TargetTable;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改字段组</para>
		/// </summary>
		public override string DisplayName() => "更改字段组";

		/// <summary>
		/// <para>Tool Name : AlterFieldGroup</para>
		/// </summary>
		public override string ToolName() => "AlterFieldGroup";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterFieldGroup</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterFieldGroup";

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
		public override object[] Parameters() => new object[] { TargetTable, Name, NewName!, Fields!, OutTable!, IsRestrictive! };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>包含要更改的字段组的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Group Name</para>
		/// <para>要更改的字段组的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>New Field Group Name</para>
		/// <para>字段组唯一的新名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NewName { get; set; }

		/// <summary>
		/// <para>New Fields</para>
		/// <para>参与字段组的字段。要修改字段，请输入新的字段名称。输入的值将会替换（而非追加）字段组中当前包含字段的列表。如果未提供值，则不会更改字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Is Restrictive</para>
		/// <para>指定字段组是否具有限制性。此参数允许您控制使用条件值时的编辑体验。</para>
		/// <para>选中 - 字段组具有限制性。在字段组的字段上输入的值将限制为指定为条件值的值。这是默认设置。</para>
		/// <para>未选中 - 字段组不具有限制性。即使未将值指定为条件值，也可以将其提交到字段组中的字段。</para>
		/// <para><see cref="IsRestrictiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsRestrictive { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterFieldGroup SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Is Restrictive</para>
		/// </summary>
		public enum IsRestrictiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RESTRICT")]
			RESTRICT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RESTRICT")]
			DO_NOT_RESTRICT,

		}

#endregion
	}
}
