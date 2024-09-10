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
	/// <para>Alters the properties of a field group.</para>
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
		/// <para>The table containing the field group to be altered.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Field Group Name</para>
		/// <para>The name of the field group to be altered.</para>
		/// </param>
		public AlterFieldGroup(object TargetTable, object Name)
		{
			this.TargetTable = TargetTable;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Field Group</para>
		/// </summary>
		public override string DisplayName() => "Alter Field Group";

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
		public override object[] Parameters() => new object[] { TargetTable, Name, NewName, Fields, OutTable, IsRestrictive };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>The table containing the field group to be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Group Name</para>
		/// <para>The name of the field group to be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>New Field Group Name</para>
		/// <para>The new, unique name for the field group.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewName { get; set; }

		/// <summary>
		/// <para>New Fields</para>
		/// <para>The fields that participate in the field group. To modify the fields, enter new field names. Provided values will replace, not append, the current list of fields that participates in the field group. If no values are provided, the fields will not be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
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
		/// <para>Specifies whether the field group is restrictive. This parameter allows you to control the editing experience when using contingent values.</para>
		/// <para>Checked—The field group is restrictive. Values entered on a field in the field group are restricted to those specified as contingent values. This is the default.</para>
		/// <para>Unchecked—The field group is not restrictive. Values can be committed to a field in a field group even if they are not specified as contingent values.</para>
		/// <para><see cref="IsRestrictiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsRestrictive { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterFieldGroup SetEnviroment(object workspace = null )
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
			/// <para>Checked—The field group is restrictive. Values entered on a field in the field group are restricted to those specified as contingent values. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RESTRICT")]
			RESTRICT,

			/// <summary>
			/// <para>Unchecked—The field group is not restrictive. Values can be committed to a field in a field group even if they are not specified as contingent values.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RESTRICT")]
			DO_NOT_RESTRICT,

		}

#endregion
	}
}
