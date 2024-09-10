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
	/// <para>Transpose Time Fields</para>
	/// <para>Shifts fields from columns to rows in a table or feature class that have time as the field names. This tool is useful when your table or feature class stores time in field names (such as Pop1980, Pop1990, Pop2000, and so on), and you want to create time stamps for the feature class or table so that it can be animated through time.</para>
	/// </summary>
	[Obsolete()]
	public class TransposeTimeFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClassOrTable">
		/// <para>Input Feature Class or Table</para>
		/// <para>The input feature class or table for which time stamps will be created.</para>
		/// </param>
		/// <param name="FieldsToTranspose">
		/// <para>Fields to Transpose</para>
		/// <para>The columns from the input table and the corresponding time values.</para>
		/// <para>Multiple strings can be entered, depending on how many fields you are transposing. Each string should be formatted as &quot;Field_Name Time&quot; (without the quotation marks). Each is a pair of substrings separated by a space. For example, the following string is a valid input: &quot;POP1980 1980&quot;. In this example, POP1980 is the field name of a field containing population values for 1980. 1980 is the string that will be substituted for POP1980 and populated in the time field of the output table or feature class.</para>
		/// </param>
		/// <param name="OutputFeatureClassOrTable">
		/// <para>Output Feature Class or Table</para>
		/// <para>The output feature class or table. The output table can be specified as a .dbf table, an info table, or a geodatabase table. The output feature class can only be stored in a geodatabase (shapefile is not available as a format for the output). The output feature class or table will contain a time field, a value field, and any number of attribute fields specified that need to be inherited from the input table.</para>
		/// </param>
		/// <param name="TimeFieldName">
		/// <para>Time Field Name</para>
		/// <para>The name of the time field that will be created to store time values. The default name is "Time". Any valid field name can be used.</para>
		/// </param>
		/// <param name="ValueFieldName">
		/// <para>Value Field Name</para>
		/// <para>The name of the value field that will be created to store the values from the input table. The default name is "Value". Any valid field name can be set, as long as it does not conflict with existing field names from the input table or feature class.</para>
		/// </param>
		public TransposeTimeFields(object InputFeatureClassOrTable, object FieldsToTranspose, object OutputFeatureClassOrTable, object TimeFieldName, object ValueFieldName)
		{
			this.InputFeatureClassOrTable = InputFeatureClassOrTable;
			this.FieldsToTranspose = FieldsToTranspose;
			this.OutputFeatureClassOrTable = OutputFeatureClassOrTable;
			this.TimeFieldName = TimeFieldName;
			this.ValueFieldName = ValueFieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : Transpose Time Fields</para>
		/// </summary>
		public override string DisplayName() => "Transpose Time Fields";

		/// <summary>
		/// <para>Tool Name : TransposeTimeFields</para>
		/// </summary>
		public override string ToolName() => "TransposeTimeFields";

		/// <summary>
		/// <para>Tool Excute Name : management.TransposeTimeFields</para>
		/// </summary>
		public override string ExcuteName() => "management.TransposeTimeFields";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClassOrTable, FieldsToTranspose, OutputFeatureClassOrTable, TimeFieldName, ValueFieldName, AttributeFields };

		/// <summary>
		/// <para>Input Feature Class or Table</para>
		/// <para>The input feature class or table for which time stamps will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputFeatureClassOrTable { get; set; }

		/// <summary>
		/// <para>Fields to Transpose</para>
		/// <para>The columns from the input table and the corresponding time values.</para>
		/// <para>Multiple strings can be entered, depending on how many fields you are transposing. Each string should be formatted as &quot;Field_Name Time&quot; (without the quotation marks). Each is a pair of substrings separated by a space. For example, the following string is a valid input: &quot;POP1980 1980&quot;. In this example, POP1980 is the field name of a field containing population values for 1980. 1980 is the string that will be substituted for POP1980 and populated in the time field of the output table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object FieldsToTranspose { get; set; }

		/// <summary>
		/// <para>Output Feature Class or Table</para>
		/// <para>The output feature class or table. The output table can be specified as a .dbf table, an info table, or a geodatabase table. The output feature class can only be stored in a geodatabase (shapefile is not available as a format for the output). The output feature class or table will contain a time field, a value field, and any number of attribute fields specified that need to be inherited from the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputFeatureClassOrTable { get; set; }

		/// <summary>
		/// <para>Time Field Name</para>
		/// <para>The name of the time field that will be created to store time values. The default name is "Time". Any valid field name can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TimeFieldName { get; set; } = "Time";

		/// <summary>
		/// <para>Value Field Name</para>
		/// <para>The name of the value field that will be created to store the values from the input table. The default name is "Value". Any valid field name can be set, as long as it does not conflict with existing field names from the input table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ValueFieldName { get; set; } = "Value";

		/// <summary>
		/// <para>Attribute Fields</para>
		/// <para>Attribute fields from the input table to be included in the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object AttributeFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransposeTimeFields SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
