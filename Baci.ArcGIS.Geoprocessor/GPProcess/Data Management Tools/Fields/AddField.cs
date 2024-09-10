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
	/// <para>Add Field</para>
	/// <para>Adds a new field to a table or the table of a feature class or feature layer, as well as to rasters with attribute tables.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table to which the specified field will be added. The field will be added to the existing input table and will not create a new output table.</para>
		/// <para>Fields can be added to feature classes in geodatabases, shapefiles, coverages, stand-alone tables, raster catalogs, rasters with attribute tables, and layers.</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>The name of the field that will be added to the input table.</para>
		/// </param>
		/// <param name="FieldType">
		/// <para>Field Type</para>
		/// <para>Specifies the field type of the new field.</para>
		/// <para>Text—Any string of characters.</para>
		/// <para>Float (single precision)— Fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para>Double (double precision)— Fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Short (small integer)— Whole numbers between -32,768 and 32,767.</para>
		/// <para>Long (large integer)— Whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Date—Date and/or time.</para>
		/// <para>Blob (binary data)—Long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
		/// <para>Raster imagery—Raster images. All ArcGIS software-supported raster dataset formats can be stored, but it is highly recommended that only small images be used.</para>
		/// <para>GUID (globally unique identifier)—Globally unique identifier.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </param>
		public AddField(object InTable, object FieldName, object FieldType)
		{
			this.InTable = InTable;
			this.FieldName = FieldName;
			this.FieldType = FieldType;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Field</para>
		/// </summary>
		public override string DisplayName() => "Add Field";

		/// <summary>
		/// <para>Tool Name : AddField</para>
		/// </summary>
		public override string ToolName() => "AddField";

		/// <summary>
		/// <para>Tool Excute Name : management.AddField</para>
		/// </summary>
		public override string ExcuteName() => "management.AddField";

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
		public override object[] Parameters() => new object[] { InTable, FieldName, FieldType, FieldPrecision, FieldScale, FieldLength, FieldAlias, FieldIsNullable, FieldIsRequired, FieldDomain, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table to which the specified field will be added. The field will be added to the existing input table and will not create a new output table.</para>
		/// <para>Fields can be added to feature classes in geodatabases, shapefiles, coverages, stand-alone tables, raster catalogs, rasters with attribute tables, and layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The name of the field that will be added to the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>Specifies the field type of the new field.</para>
		/// <para>Text—Any string of characters.</para>
		/// <para>Float (single precision)— Fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para>Double (double precision)— Fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Short (small integer)— Whole numbers between -32,768 and 32,767.</para>
		/// <para>Long (large integer)— Whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Date—Date and/or time.</para>
		/// <para>Blob (binary data)—Long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
		/// <para>Raster imagery—Raster images. All ArcGIS software-supported raster dataset formats can be stored, but it is highly recommended that only small images be used.</para>
		/// <para>GUID (globally unique identifier)—Globally unique identifier.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; } = "LONG";

		/// <summary>
		/// <para>Field Precision</para>
		/// <para>The number of digits that can be stored in the field. All digits are counted regardless of which side of the decimal they are on.</para>
		/// <para>If the input table is a file geodatabase, the field precision value will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object FieldPrecision { get; set; }

		/// <summary>
		/// <para>Field Scale</para>
		/// <para>The number of decimal places stored in a field. This parameter is only used in float and double data field types.</para>
		/// <para>If the input table is a file geodatabase, the field scale value will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object FieldScale { get; set; }

		/// <summary>
		/// <para>Field Length</para>
		/// <para>The length of the field being added. This sets the maximum number of allowable characters for each record of the field. This parameter is only applicable to fields of type text.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object FieldLength { get; set; }

		/// <summary>
		/// <para>Field Alias</para>
		/// <para>The alternate name given to the field name. This name is used to describe cryptic field names. This parameter only applies to geodatabases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FieldAlias { get; set; }

		/// <summary>
		/// <para>Field IsNullable</para>
		/// <para>Specifies whether the field can contain null values. Null values are different from zero or empty fields and are only supported for fields in a geodatabase.</para>
		/// <para>Checked—The field will allow null values. This is the default.</para>
		/// <para>Unchecked—The field will not allow null values.</para>
		/// <para><see cref="FieldIsNullableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FieldIsNullable { get; set; } = "true";

		/// <summary>
		/// <para>Field IsRequired</para>
		/// <para>Specifies whether the field being created is a required field for the table. Required fields are only supported in a geodatabase.</para>
		/// <para>Checked—The field is a required field. Required fields are permanent and cannot be deleted.</para>
		/// <para>Unchecked—The field is not a required field. This is the default.</para>
		/// <para><see cref="FieldIsRequiredEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FieldIsRequired { get; set; } = "false";

		/// <summary>
		/// <para>Field Domain</para>
		/// <para>Constrains the values allowed in any particular attribute for a table, feature class, or subtype in a geodatabase. You must specify the name of an existing domain for it to be applied to the field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FieldDomain { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddField SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>Text—Any string of characters.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>Float (single precision)— Fractional numbers between -3.4E38 and 1.2E38.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float (single precision)")]
			FLOAT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double  (double precision)")]
			DOUBLE,

			/// <summary>
			/// <para>Short (small integer)— Whole numbers between -32,768 and 32,767.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short (small integer)")]
			SHORT,

			/// <summary>
			/// <para>Long (large integer)— Whole numbers between -2,147,483,648 and 2,147,483,647.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long (large integer)")]
			LONG,

			/// <summary>
			/// <para>Date—Date and/or time.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

			/// <summary>
			/// <para>Blob (binary data)—Long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob (binary data)")]
			BLOB,

			/// <summary>
			/// <para>Raster imagery—Raster images. All ArcGIS software-supported raster dataset formats can be stored, but it is highly recommended that only small images be used.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster imagery")]
			Raster_imagery,

			/// <summary>
			/// <para>GUID (globally unique identifier)—Globally unique identifier.</para>
			/// </summary>
			[GPValue("GUID")]
			[Description("GUID (globally unique identifier)")]
			GUID,

		}

		/// <summary>
		/// <para>Field IsNullable</para>
		/// </summary>
		public enum FieldIsNullableEnum 
		{
			/// <summary>
			/// <para>Checked—The field will allow null values. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NULLABLE")]
			NULLABLE,

			/// <summary>
			/// <para>Unchecked—The field will not allow null values.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_NULLABLE")]
			NON_NULLABLE,

		}

		/// <summary>
		/// <para>Field IsRequired</para>
		/// </summary>
		public enum FieldIsRequiredEnum 
		{
			/// <summary>
			/// <para>Checked—The field is a required field. Required fields are permanent and cannot be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRED")]
			REQUIRED,

			/// <summary>
			/// <para>Unchecked—The field is not a required field. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_REQUIRED")]
			NON_REQUIRED,

		}

#endregion
	}
}
