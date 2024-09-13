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
	/// <para>Set Subtype Field</para>
	/// <para>Defines the field in the input table or feature class that stores the subtype codes.</para>
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
		/// <para>The input table or feature class that contains the field to set as a subtype field.</para>
		/// </param>
		public SetSubtypeField(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Subtype Field</para>
		/// </summary>
		public override string DisplayName() => "Set Subtype Field";

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
		/// <para>The input table or feature class that contains the field to set as a subtype field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The integer field that will store the subtype codes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? Field { get; set; }

		/// <summary>
		/// <para>Clear Value</para>
		/// <para>Specifies whether to clear the subtype field.</para>
		/// <para>Checked—The subtype field will be cleared (set to null).</para>
		/// <para>Unchecked—The subtype field will not be cleared. This is the default.</para>
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
			/// <para>Checked—The subtype field will be cleared (set to null).</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_SUBTYPE_FIELD")]
			CLEAR_SUBTYPE_FIELD,

			/// <summary>
			/// <para>Unchecked—The subtype field will not be cleared. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR")]
			DO_NOT_CLEAR,

		}

#endregion
	}
}
