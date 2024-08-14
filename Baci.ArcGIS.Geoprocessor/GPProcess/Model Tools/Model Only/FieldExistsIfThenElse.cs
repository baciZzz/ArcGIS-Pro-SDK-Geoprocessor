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
	/// <para>Evaluates if the input data has the specified fields.</para>
	/// </summary>
	public class FieldExistsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>Input table that will be evaluated for the existence of the specified fields.</para>
		/// </param>
		/// <param name="FieldTestType">
		/// <para>Field Test</para>
		/// <para>The criteria to test the specified list of fields against.</para>
		/// <para>Must have all fields—All fields must exists.</para>
		/// <para>Must have at least one field—Must have at least one of the specified fields.</para>
		/// <para>Must not have all fields—Must not have any of the specified fields.</para>
		/// <para>Must not have at least one field—Must not have at least one of the specified fields.</para>
		/// <para><see cref="FieldTestTypeEnum"/></para>
		/// </param>
		/// <param name="Field">
		/// <para>Fields</para>
		/// <para>Field names to check for in the input table.</para>
		/// </param>
		public FieldExistsIfThenElse(object InTable, object FieldTestType, object Field)
		{
			this.InTable = InTable;
			this.FieldTestType = FieldTestType;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : If Field Exists</para>
		/// </summary>
		public override string DisplayName => "If Field Exists";

		/// <summary>
		/// <para>Tool Name : FieldExistsIfThenElse</para>
		/// </summary>
		public override string ToolName => "FieldExistsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.FieldExistsIfThenElse</para>
		/// </summary>
		public override string ExcuteName => "mb.FieldExistsIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, FieldTestType, Field, True!, False! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>Input table that will be evaluated for the existence of the specified fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Test</para>
		/// <para>The criteria to test the specified list of fields against.</para>
		/// <para>Must have all fields—All fields must exists.</para>
		/// <para>Must have at least one field—Must have at least one of the specified fields.</para>
		/// <para>Must not have all fields—Must not have any of the specified fields.</para>
		/// <para>Must not have at least one field—Must not have at least one of the specified fields.</para>
		/// <para><see cref="FieldTestTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldTestType { get; set; } = "MUST_HAVE_AT_LEAST_ONE_FIELD";

		/// <summary>
		/// <para>Fields</para>
		/// <para>Field names to check for in the input table.</para>
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
			/// <para>Must have all fields—All fields must exists.</para>
			/// </summary>
			[GPValue("MUST_HAVE_ALL_FIELDS")]
			[Description("Must have all fields")]
			Must_have_all_fields,

			/// <summary>
			/// <para>Must have at least one field—Must have at least one of the specified fields.</para>
			/// </summary>
			[GPValue("MUST_HAVE_AT_LEAST_ONE_FIELD")]
			[Description("Must have at least one field")]
			Must_have_at_least_one_field,

			/// <summary>
			/// <para>Must not have all fields—Must not have any of the specified fields.</para>
			/// </summary>
			[GPValue("MUST_NOT_HAVE_ALL_FIELDS")]
			[Description("Must not have all fields")]
			Must_not_have_all_fields,

			/// <summary>
			/// <para>Must not have at least one field—Must not have at least one of the specified fields.</para>
			/// </summary>
			[GPValue("MUST_NOT_HAVE_AT_LEAST_ONE_FIELD")]
			[Description("Must not have at least one field")]
			Must_not_have_at_least_one_field,

		}

#endregion
	}
}
