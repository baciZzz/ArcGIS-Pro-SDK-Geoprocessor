using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Add Field To Analysis Layer</para>
	/// <para>Adds a field to a sublayer of a network analysis layer.</para>
	/// </summary>
	public class AddFieldToAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer to which the new field will be added.</para>
		/// </param>
		/// <param name="SubLayer">
		/// <para>Sub Layer</para>
		/// <para>The sublayer of the network analysis layer to which the new field will be added.</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>The name of the field that will be added to the specified sublayer of the network analysis layer.</para>
		/// </param>
		/// <param name="FieldType">
		/// <para>Field Type</para>
		/// <para>Specifies the field type that will be used in the creation of the new field.</para>
		/// <para>Long (large integer)— Whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Text—Any string of characters.</para>
		/// <para>Float (single precision)— Fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para>Double (double precision)— Fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Short (small integer)— Whole numbers between -32,768 and 32,767.</para>
		/// <para>Date—Date and/or time.</para>
		/// <para>Blob (binary data)—Long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </param>
		public AddFieldToAnalysisLayer(object InNetworkAnalysisLayer, object SubLayer, object FieldName, object FieldType)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
			this.SubLayer = SubLayer;
			this.FieldName = FieldName;
			this.FieldType = FieldType;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Field To Analysis Layer</para>
		/// </summary>
		public override string DisplayName => "Add Field To Analysis Layer";

		/// <summary>
		/// <para>Tool Name : AddFieldToAnalysisLayer</para>
		/// </summary>
		public override string ToolName => "AddFieldToAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.AddFieldToAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName => "na.AddFieldToAnalysisLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkAnalysisLayer, SubLayer, FieldName, FieldType, FieldPrecision, FieldScale, FieldLength, FieldAlias, FieldIsNullable, OutputLayer };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer to which the new field will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Sub Layer</para>
		/// <para>The sublayer of the network analysis layer to which the new field will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SubLayer { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The name of the field that will be added to the specified sublayer of the network analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>Specifies the field type that will be used in the creation of the new field.</para>
		/// <para>Long (large integer)— Whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Text—Any string of characters.</para>
		/// <para>Float (single precision)— Fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para>Double (double precision)— Fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Short (small integer)— Whole numbers between -32,768 and 32,767.</para>
		/// <para>Date—Date and/or time.</para>
		/// <para>Blob (binary data)—Long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; } = "LONG";

		/// <summary>
		/// <para>Field Precision</para>
		/// <para>The number of digits that can be stored in the field. All digits are counted regardless of which side of the decimal they are on.</para>
		/// <para>The parameter value is only valid for numeric field types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object FieldPrecision { get; set; }

		/// <summary>
		/// <para>Field Scale</para>
		/// <para>The number of decimal places stored in a field. This parameter is only used in float and double data field types.</para>
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
		/// <para>Updated Input Sublayer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFieldToAnalysisLayer SetEnviroment(object workspace = null )
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

#endregion
	}
}
