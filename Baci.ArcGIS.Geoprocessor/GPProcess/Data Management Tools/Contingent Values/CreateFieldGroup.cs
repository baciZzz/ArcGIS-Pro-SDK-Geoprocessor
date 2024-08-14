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
	/// <para>Create a field group for a feature class or table. Field groups are used when creating contingent values.</para>
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
		/// <para>The input geodatabase table or feature class in which the field group will be created.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Field Group Name</para>
		/// <para>The name of the field group that will be created. This name must be unique to the feature class or table that will contain the field group.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Fields</para>
		/// <para>The names of the fields in the field group.</para>
		/// </param>
		public CreateFieldGroup(object TargetTable, object Name, object Fields)
		{
			this.TargetTable = TargetTable;
			this.Name = Name;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Field Group</para>
		/// </summary>
		public override string DisplayName => "Create Field Group";

		/// <summary>
		/// <para>Tool Name : CreateFieldGroup</para>
		/// </summary>
		public override string ToolName => "CreateFieldGroup";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFieldGroup</para>
		/// </summary>
		public override string ExcuteName => "management.CreateFieldGroup";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { TargetTable, Name, Fields, OutTable, IsRestrictive };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>The input geodatabase table or feature class in which the field group will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Group Name</para>
		/// <para>The name of the field group that will be created. This name must be unique to the feature class or table that will contain the field group.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>The names of the fields in the field group.</para>
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
		/// <para>Specifies if the field group is restrictive. This parameter allows you to control the editing experience when using contingent values.</para>
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
