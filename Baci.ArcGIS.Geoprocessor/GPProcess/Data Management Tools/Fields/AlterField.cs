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
	/// <para>Alter Field</para>
	/// <para>Alter Field</para>
	/// <para>Renames fields and field aliases or alters field properties.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input geodatabase table or feature class that contains the field to alter.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field Name</para>
		/// <para>The name of the field to alter. If the field is a required field, only the field alias can be altered.</para>
		/// </param>
		public AlterField(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Field</para>
		/// </summary>
		public override string DisplayName() => "Alter Field";

		/// <summary>
		/// <para>Tool Name : AlterField</para>
		/// </summary>
		public override string ToolName() => "AlterField";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterField</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterField";

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
		public override object[] Parameters() => new object[] { InTable, Field, NewFieldName!, NewFieldAlias!, FieldType!, FieldLength!, FieldIsNullable!, ClearFieldAlias!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input geodatabase table or feature class that contains the field to alter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain(HideJoinedLayers = true, ShowOnlyStandaloneTables = false)]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The name of the field to alter. If the field is a required field, only the field alias can be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object Field { get; set; }

		/// <summary>
		/// <para>New Field Name</para>
		/// <para>The new name for the field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NewFieldName { get; set; }

		/// <summary>
		/// <para>New Field Alias</para>
		/// <para>The new field alias for the field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NewFieldAlias { get; set; }

		/// <summary>
		/// <para>New Field Type</para>
		/// <para>Specifies the new field type for the field. This parameter is only applicable if the input table is empty (does not contain records).</para>
		/// <para>Text—The field type will be text. Text fields support a string of characters.</para>
		/// <para>Float (32-bit floating point)—The field type will be float. Float fields support fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para>Double (64-bit floating point)—The field type will be double. Double fields support fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Short (16-bit integer)—The field type will be short. Short fields support whole numbers between -32,768 and 32,767.</para>
		/// <para>Long (32-bit integer)—The field type will be long. Long fields support whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Date—The field type will be date. Date fields support date and time values.</para>
		/// <para>Blob (binary data)—The field type will be BLOB. BLOB fields support data stored as a long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
		/// <para>Raster imagery—The field type will be raster. Raster fields can store raster data in or alongside the geodatabase. All ArcGIS software-supported raster dataset formats can be stored, but it is recommended that only small images be used.</para>
		/// <para>GUID (globally unique identifier)—The field type will be GUID. GUID fields store registry-style strings consisting of 36 characters enclosed in curly brackets.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FieldType { get; set; } = "LONG";

		/// <summary>
		/// <para>New Field Length</para>
		/// <para>The new length of the field. This sets the maximum number of allowable characters for each record of the field. This parameter is only applicable to fields of type Text or Blob (binary data). If the table is empty, the field length can be increased or decreased. If the table is not empty, the length can only be increased from the current value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldLength { get; set; }

		/// <summary>
		/// <para>New Field IsNullable</para>
		/// <para>Specifies whether the field can contain null values. Null values are only supported for fields in a geodatabase. This parameter is only applicable if the table is empty (does not contain records).</para>
		/// <para>Checked—The field can contain null values. This is the default.</para>
		/// <para>Unchecked—The field cannot contain null values.</para>
		/// <para><see cref="FieldIsNullableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FieldIsNullable { get; set; } = "true";

		/// <summary>
		/// <para>Clear Alias</para>
		/// <para>Specifies whether the alias for the input field will be cleared. The New Field Alias parameter value must be empty to clear the alias of the field.</para>
		/// <para>Checked—The field alias will be cleared (set to null). The field alias parameter must be empty.</para>
		/// <para>Unchecked—The field alias will not be cleared. This is the default.</para>
		/// <para><see cref="ClearFieldAliasEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClearFieldAlias { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterField SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>New Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>Text—The field type will be text. Text fields support a string of characters.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>Float (32-bit floating point)—The field type will be float. Float fields support fractional numbers between -3.4E38 and 1.2E38.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float (32-bit floating point)")]
			FLOAT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double  (64-bit floating point)")]
			DOUBLE,

			/// <summary>
			/// <para>Short (16-bit integer)—The field type will be short. Short fields support whole numbers between -32,768 and 32,767.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short (16-bit integer)")]
			SHORT,

			/// <summary>
			/// <para>Long (32-bit integer)—The field type will be long. Long fields support whole numbers between -2,147,483,648 and 2,147,483,647.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long (32-bit integer)")]
			LONG,

			/// <summary>
			/// <para>Date—The field type will be date. Date fields support date and time values.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

			/// <summary>
			/// <para>Blob (binary data)—The field type will be BLOB. BLOB fields support data stored as a long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob (binary data)")]
			BLOB,

			/// <summary>
			/// <para>Raster imagery—The field type will be raster. Raster fields can store raster data in or alongside the geodatabase. All ArcGIS software-supported raster dataset formats can be stored, but it is recommended that only small images be used.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster imagery")]
			Raster_imagery,

			/// <summary>
			/// <para>GUID (globally unique identifier)—The field type will be GUID. GUID fields store registry-style strings consisting of 36 characters enclosed in curly brackets.</para>
			/// </summary>
			[GPValue("GUID")]
			[Description("GUID (globally unique identifier)")]
			GUID,

		}

		/// <summary>
		/// <para>New Field IsNullable</para>
		/// </summary>
		public enum FieldIsNullableEnum 
		{
			/// <summary>
			/// <para>Checked—The field can contain null values. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NULLABLE")]
			NULLABLE,

			/// <summary>
			/// <para>Unchecked—The field cannot contain null values.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_NULLABLE")]
			NON_NULLABLE,

		}

		/// <summary>
		/// <para>Clear Alias</para>
		/// </summary>
		public enum ClearFieldAliasEnum 
		{
			/// <summary>
			/// <para>Checked—The field alias will be cleared (set to null). The field alias parameter must be empty.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_ALIAS")]
			CLEAR_ALIAS,

			/// <summary>
			/// <para>Unchecked—The field alias will not be cleared. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR")]
			DO_NOT_CLEAR,

		}

#endregion
	}
}
