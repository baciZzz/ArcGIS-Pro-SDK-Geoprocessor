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
	/// <para>Table Compare</para>
	/// <para>Compares two tables or table views and returns the comparison results.</para>
	/// </summary>
	public class TableCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseTable">
		/// <para>Input Base Table</para>
		/// <para>The Input Base Table is compared with the Input Test Table. The Input Base Table refers to tabular data that you have declared valid. The base data has the correct field definitions and attribute values.</para>
		/// </param>
		/// <param name="InTestTable">
		/// <para>Input Test Table</para>
		/// <para>The Input Test Table is compared against the Input Base Table. The Input Test Table refers to data that you have made changes to by editing or compiling new fields, new records, or new attribute values.</para>
		/// </param>
		/// <param name="SortField">
		/// <para>Sort Field</para>
		/// <para>The field or fields used to sort records in the Input Base Table and the Input Test Table. The records are sorted in ascending order. Sorting by a common field in both the Input Base Table and the Input Test Table ensures that you are comparing the same row from each input dataset.</para>
		/// </param>
		public TableCompare(object InBaseTable, object InTestTable, object SortField)
		{
			this.InBaseTable = InBaseTable;
			this.InTestTable = InTestTable;
			this.SortField = SortField;
		}

		/// <summary>
		/// <para>Tool Display Name : Table Compare</para>
		/// </summary>
		public override string DisplayName => "Table Compare";

		/// <summary>
		/// <para>Tool Name : TableCompare</para>
		/// </summary>
		public override string ToolName => "TableCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.TableCompare</para>
		/// </summary>
		public override string ExcuteName => "management.TableCompare";

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
		public override object[] Parameters => new object[] { InBaseTable, InTestTable, SortField, CompareType, IgnoreOptions, AttributeTolerances, OmitField, ContinueCompare, OutCompareFile, CompareStatus };

		/// <summary>
		/// <para>Input Base Table</para>
		/// <para>The Input Base Table is compared with the Input Test Table. The Input Base Table refers to tabular data that you have declared valid. The base data has the correct field definitions and attribute values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InBaseTable { get; set; }

		/// <summary>
		/// <para>Input Test Table</para>
		/// <para>The Input Test Table is compared against the Input Base Table. The Input Test Table refers to data that you have made changes to by editing or compiling new fields, new records, or new attribute values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTestTable { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>The field or fields used to sort records in the Input Base Table and the Input Test Table. The records are sorted in ascending order. Sorting by a common field in both the Input Base Table and the Input Test Table ensures that you are comparing the same row from each input dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>The comparison type. ALL is the default. The default will compare all properties of the tables being compared.</para>
		/// <para>All—Compare all properties. This is the default.</para>
		/// <para>Attributes only—Only compare the attributes and their values.</para>
		/// <para>Schema only—Only compare the schema.</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CompareType { get; set; } = "ALL";

		/// <summary>
		/// <para>Ignore Options</para>
		/// <para>These properties will not be compared.</para>
		/// <para>Ignore extension properties—Do not compare extension properties.</para>
		/// <para>Ignore subtypes—Do not compare subtypes.</para>
		/// <para>Ignore relationship classes—Do not compare relationship classes.</para>
		/// <para>Ignore field alias—Do not compare field aliases.</para>
		/// <para><see cref="IgnoreOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object IgnoreOptions { get; set; }

		/// <summary>
		/// <para>Attribute Tolerance</para>
		/// <para>The numeric value that determines the range in which attribute values are considered equal. This only applies to numeric field types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AttributeTolerances { get; set; }

		/// <summary>
		/// <para>Omit Fields</para>
		/// <para>The field or fields that will be omitted during comparison. The field definitions and the tabular values for these fields will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object OmitField { get; set; }

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>Indicates whether to compare all properties after encountering the first mismatch.</para>
		/// <para>Unchecked—Stop after encountering the first mismatch. This is the default.</para>
		/// <para>Checked—Compare other properties after encountering the first mismatch.</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>This file will contain all similarities and differences between the Input Base Table and the Input Test Table. This file is a comma-delimited text file that can be viewed and used as a table in ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompareStatus { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableCompare SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>All—Compare all properties. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Attributes only—Only compare the attributes and their values.</para>
			/// </summary>
			[GPValue("ATTRIBUTES_ONLY")]
			[Description("Attributes only")]
			Attributes_only,

			/// <summary>
			/// <para>Schema only—Only compare the schema.</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("Schema only")]
			Schema_only,

		}

		/// <summary>
		/// <para>Ignore Options</para>
		/// </summary>
		public enum IgnoreOptionsEnum 
		{
			/// <summary>
			/// <para>Ignore extension properties—Do not compare extension properties.</para>
			/// </summary>
			[GPValue("IGNORE_EXTENSION_PROPERTIES")]
			[Description("Ignore extension properties")]
			Ignore_extension_properties,

			/// <summary>
			/// <para>Ignore subtypes—Do not compare subtypes.</para>
			/// </summary>
			[GPValue("IGNORE_SUBTYPES")]
			[Description("Ignore subtypes")]
			Ignore_subtypes,

			/// <summary>
			/// <para>Ignore relationship classes—Do not compare relationship classes.</para>
			/// </summary>
			[GPValue("IGNORE_RELATIONSHIPCLASSES")]
			[Description("Ignore relationship classes")]
			Ignore_relationship_classes,

			/// <summary>
			/// <para>Ignore field alias—Do not compare field aliases.</para>
			/// </summary>
			[GPValue("IGNORE_FIELDALIAS")]
			[Description("Ignore field alias")]
			Ignore_field_alias,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para>Checked—Compare other properties after encountering the first mismatch.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para>Unchecked—Stop after encountering the first mismatch. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
