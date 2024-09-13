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
	/// <para>Create Field Group</para>
	/// <para>创建字段组</para>
	/// <para>可以为要素类或表创建字段组。字段组是在创建条件值时使用的。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CreateFieldGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>将在其中创建字段组的输入地理数据库表或要素类。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Field Group Name</para>
		/// <para>将创建的字段组的名称。此名称对于将包含字段组的要素类或表必须是唯一的。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Fields</para>
		/// <para>字段组中字段的名称。</para>
		/// </param>
		public CreateFieldGroup(object TargetTable, object Name, object Fields)
		{
			this.TargetTable = TargetTable;
			this.Name = Name;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建字段组</para>
		/// </summary>
		public override string DisplayName() => "创建字段组";

		/// <summary>
		/// <para>Tool Name : CreateFieldGroup</para>
		/// </summary>
		public override string ToolName() => "CreateFieldGroup";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFieldGroup</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFieldGroup";

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
		public override object[] Parameters() => new object[] { TargetTable, Name, Fields, OutTable, IsRestrictive };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>将在其中创建字段组的输入地理数据库表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Group Name</para>
		/// <para>将创建的字段组的名称。此名称对于将包含字段组的要素类或表必须是唯一的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>字段组中字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

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
		public object IsRestrictive { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFieldGroup SetEnviroment(object workspace = null )
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
