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
	/// <para>Join Field</para>
	/// <para>Permanently joins the contents of a table to another table based on a common attribute field. The input table is updated to contain the fields from the join table. You can select which fields from the join table will be added to the input table.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class JoinField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Table</para>
		/// <para>The table or feature class to which the join table will be joined.</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Join Field</para>
		/// <para>The field in the input table on which the join will be based.</para>
		/// </param>
		/// <param name="JoinTable">
		/// <para>Join Table</para>
		/// <para>The table to be joined to the input table.</para>
		/// </param>
		/// <param name="Join_Field">
		/// <para>Join Table Field</para>
		/// <para>The field in the join table that contains the values on which the join will be based.</para>
		/// </param>
		public JoinField(object InData, object InField, object JoinTable, object Join_Field)
		{
			this.InData = InData;
			this.InField = InField;
			this.JoinTable = JoinTable;
			this.Join_Field = Join_Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Join Field</para>
		/// </summary>
		public override string DisplayName => "Join Field";

		/// <summary>
		/// <para>Tool Name : JoinField</para>
		/// </summary>
		public override string ToolName => "JoinField";

		/// <summary>
		/// <para>Tool Excute Name : management.JoinField</para>
		/// </summary>
		public override string ExcuteName => "management.JoinField";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InData, InField, JoinTable, Join_Field, Fields!, OutLayerOrView!, FmOption!, FieldMapping! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table or feature class to which the join table will be joined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>The field in the input table on which the join will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InField { get; set; }

		/// <summary>
		/// <para>Join Table</para>
		/// <para>The table to be joined to the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JoinTable { get; set; }

		/// <summary>
		/// <para>Join Table Field</para>
		/// <para>The field in the join table that contains the values on which the join will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object Join_Field { get; set; }

		/// <summary>
		/// <para>Transfer Fields</para>
		/// <para>The fields from the join table to be transferred to the input table, based on a join between the input table and the join table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Transfer Method</para>
		/// <para>Specifies how joining fields and field types will be transferred to the output.</para>
		/// <para>NOT_USE_FM—Fields and field types from the joined table will be transferred to the output. This is the default.</para>
		/// <para>USE_FM—The transfer of fields and field types from the joined table to the output will be controlled by the Field Map parameter.</para>
		/// <para>Specifies how joining fields and field types will be transferred to the output.</para>
		/// <para>NOT_USE_FM—Fields and field types from the joined table will be transferred to the output. This is the default.</para>
		/// <para>USE_FM—The transfer of fields and field types from the joined table to the output will be controlled by the field_mapping parameter.</para>
		/// <para><see cref="FmOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FmOption { get; set; } = "NOT_USE_FM";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>The attribute fields that will be in the output with the corresponding field properties and source fields. By default, all fields from the inputs will be included.</para>
		/// <para>Fields can be added, deleted, renamed, and reordered, and you can change their properties.</para>
		/// <para>Merge rules allow you to specify how values from two or more input fields are merged or combined into a single output value. There are several merge rules you can use to determine how the output field will be populated with values.</para>
		/// <para>First—Use the input fields&apos; first value.</para>
		/// <para>Last—Use the input fields&apos; last value.</para>
		/// <para>Join—Concatenate (join) the input field values.</para>
		/// <para>Sum—Calculate the total of the input field values.</para>
		/// <para>Mean—Calculate the mean (average) of the input field values.</para>
		/// <para>Median—Calculate the median (middle) of the input field values.</para>
		/// <para>Mode—Use the value with the highest frequency.</para>
		/// <para>Min—Use the minimum value of all the input field values.</para>
		/// <para>Max—Use the maximum value of all the input field values.</para>
		/// <para>Standard deviation—Use the standard deviation classification method on all the input field values.</para>
		/// <para>Count—Find the number of records included in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JoinField SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transfer Method</para>
		/// </summary>
		public enum FmOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NOT_USE_FM")]
			[Description("Select transfer fields")]
			Select_transfer_fields,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("USE_FM")]
			[Description("Use field mapping")]
			Use_field_mapping,

		}

#endregion
	}
}
