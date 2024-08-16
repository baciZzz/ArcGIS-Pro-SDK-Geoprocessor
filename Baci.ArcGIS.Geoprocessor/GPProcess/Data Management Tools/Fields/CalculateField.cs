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
	/// <para>Calculate Field</para>
	/// <para>Calculates the values of a field for a feature class, feature layer, or raster.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the field that will be updated with the new calculation.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field Name (Existing or New)</para>
		/// <para>The field that will be updated with the new calculation.</para>
		/// <para>If a field with the specified name does not exist in the input table, it will be added.</para>
		/// </param>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>The simple calculation expression used to create a value that will populate the selected rows.</para>
		/// </param>
		public CalculateField(object InTable, object Field, object Expression)
		{
			this.InTable = InTable;
			this.Field = Field;
			this.Expression = Expression;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Field</para>
		/// </summary>
		public override string DisplayName => "Calculate Field";

		/// <summary>
		/// <para>Tool Name : CalculateField</para>
		/// </summary>
		public override string ToolName => "CalculateField";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateField</para>
		/// </summary>
		public override string ExcuteName => "management.CalculateField";

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
		public override string[] ValidEnvironments => new string[] { "extent", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, Field, Expression, ExpressionType, CodeBlock, OutTable, FieldType, EnforceDomains };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the field that will be updated with the new calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name (Existing or New)</para>
		/// <para>The field that will be updated with the new calculation.</para>
		/// <para>If a field with the specified name does not exist in the input table, it will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Geometry", "GUID")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>The simple calculation expression used to create a value that will populate the selected rows.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Expression Type</para>
		/// <para>Specifies the type of expression that will be used.</para>
		/// <para>Python 3—The Python expression type will be used. This is the default.</para>
		/// <para>Arcade—The Arcade expression type will be used.</para>
		/// <para>SQL—The SQL expression type will be used.</para>
		/// <para>To learn more about Python expressions, see Calculate Field Python examples.</para>
		/// <para>To learn more about Arcade expressions, see the ArcGIS Arcade guide.</para>
		/// <para>To learn more about SQL expressions, see Calculate field values.</para>
		/// <para>SQL expressions support faster calculations for feature services and enterprise geodatabases. Instead of performing calculations one feature or row at a time, a single request is set to the server or database, resulting in significantly faster calculations.</para>
		/// <para>Only feature services and enterprise geodatabases support SQL expressions. For other formats, use Python or Arcade expressions.</para>
		/// <para><see cref="ExpressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExpressionType { get; set; } = "PYTHON3";

		/// <summary>
		/// <para>Code Block</para>
		/// <para>A block of code that will be entered for complex expressions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CodeBlock { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>Specifies the field type of the new field. This parameter is only used when the field name does not exist in the input table.</para>
		/// <para>If the field is of type text, the new field will have a length of 512. For shapefiles and dBASE files, the field will have a length of 254. The length of the new field can be adjusted using the Alter Field tool.</para>
		/// <para>Text—Any string of characters can be used.</para>
		/// <para>Float (single precision)— Fractional numbers between -3.4E38 and 1.2E38 can be used.</para>
		/// <para>Double (double precision)— Fractional numbers between -2.2E308 and 1.8E308 can be used.</para>
		/// <para>Short (small integer)— Whole numbers between -32,768 and 32,767 can be used.</para>
		/// <para>Long (large integer)— Whole numbers between -2,147,483,648 and 2,147,483,647 can be used.</para>
		/// <para>Date—Date and time will be used.</para>
		/// <para>Blob (binary data)—A long sequence of binary numbers will be used.</para>
		/// <para>Raster imagery—Raster images will be used. All ArcGIS software-supported raster dataset formats can be stored; however, it is recommended that you use only small images.</para>
		/// <para>GUID (globally unique identifier)—A globally unique identifier will be used.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; } = "TEXT";

		/// <summary>
		/// <para>Enforce Domains</para>
		/// <para>Specifies whether field domain rules will be enforced.</para>
		/// <para>Checked—Field domain rules will be enforced. If a field cannot be updated, the field value will remain unchanged, and the tool messages will include a warning message.</para>
		/// <para>Unchecked—Field domain rules will not be enforced. This is the default</para>
		/// <para><see cref="EnforceDomainsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnforceDomains { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateField SetEnviroment(object extent = null , bool? transferDomains = null , object workspace = null )
		{
			base.SetEnv(extent: extent, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Expression Type</para>
		/// </summary>
		public enum ExpressionTypeEnum 
		{
			/// <summary>
			/// <para>Python 3—The Python expression type will be used. This is the default.</para>
			/// </summary>
			[GPValue("PYTHON3")]
			[Description("Python 3")]
			Python_3,

			/// <summary>
			/// <para>Arcade—The Arcade expression type will be used.</para>
			/// </summary>
			[GPValue("ARCADE")]
			[Description("Arcade")]
			Arcade,

			/// <summary>
			/// <para>SQL—The SQL expression type will be used.</para>
			/// </summary>
			[GPValue("SQL")]
			[Description("SQL")]
			SQL,

		}

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>Text—Any string of characters can be used.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>Float (single precision)— Fractional numbers between -3.4E38 and 1.2E38 can be used.</para>
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
			/// <para>Short (small integer)— Whole numbers between -32,768 and 32,767 can be used.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short (small integer)")]
			SHORT,

			/// <summary>
			/// <para>Long (large integer)— Whole numbers between -2,147,483,648 and 2,147,483,647 can be used.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long (large integer)")]
			LONG,

			/// <summary>
			/// <para>Date—Date and time will be used.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

			/// <summary>
			/// <para>Blob (binary data)—A long sequence of binary numbers will be used.</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob (binary data)")]
			BLOB,

			/// <summary>
			/// <para>Raster imagery—Raster images will be used. All ArcGIS software-supported raster dataset formats can be stored; however, it is recommended that you use only small images.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster imagery")]
			Raster_imagery,

			/// <summary>
			/// <para>GUID (globally unique identifier)—A globally unique identifier will be used.</para>
			/// </summary>
			[GPValue("GUID")]
			[Description("GUID (globally unique identifier)")]
			GUID,

		}

		/// <summary>
		/// <para>Enforce Domains</para>
		/// </summary>
		public enum EnforceDomainsEnum 
		{
			/// <summary>
			/// <para>Checked—Field domain rules will be enforced. If a field cannot be updated, the field value will remain unchanged, and the tool messages will include a warning message.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENFORCE_DOMAINS")]
			ENFORCE_DOMAINS,

			/// <summary>
			/// <para>Unchecked—Field domain rules will not be enforced. This is the default</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ENFORCE_DOMAINS")]
			NO_ENFORCE_DOMAINS,

		}

#endregion
	}
}
