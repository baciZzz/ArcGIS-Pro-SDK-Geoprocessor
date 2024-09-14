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
	/// <para>Transpose Fields</para>
	/// <para>Transpose Fields</para>
	/// <para>Switch  data stored in fields or columns to rows in a new table or feature class.</para>
	/// </summary>
	public class TransposeFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input feature class or table containing data value fields to be transposed.</para>
		/// </param>
		/// <param name="InField">
		/// <para>Fields To Transpose</para>
		/// <para>The fields or columns containing data values in the input table that need to be transposed.</para>
		/// <para>Depending on your needs, you can select multiple fields to be transposed. The value here defines what the field name will be in the output. When not specified, the value is the same as the field name by default. However, you can also specify your own value. For example, if the field names to be transposed are Pop1991, Pop1992, and so on, by default, the values for these fields in the output will be the same (Pop1991, Pop1992, and so forth). However, you can choose to specify your own values such as 1991 and 1992.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output feature class or table. The output will contain a transposed field, a value field, and any number of specified attribute fields that need to be inherited from the input table.</para>
		/// <para>By default the Output Table is a table. The output will be a feature class when the Input Table is a feature class and the Shape field is selected in the Attribute Fields parameter.</para>
		/// </param>
		/// <param name="InTransposedFieldName">
		/// <para>Transposed Field</para>
		/// <para>The name of the field that will be created to store field names of the transposed fields. Any valid field name can be used.</para>
		/// </param>
		/// <param name="InValueFieldName">
		/// <para>Value Field</para>
		/// <para>The name of the field that will be created to store the corresponding values of the transposed fields. Any valid field name can be set, as long as it does not conflict with existing field names from the input table or feature class.</para>
		/// </param>
		public TransposeFields(object InTable, object InField, object OutTable, object InTransposedFieldName, object InValueFieldName)
		{
			this.InTable = InTable;
			this.InField = InField;
			this.OutTable = OutTable;
			this.InTransposedFieldName = InTransposedFieldName;
			this.InValueFieldName = InValueFieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : Transpose Fields</para>
		/// </summary>
		public override string DisplayName() => "Transpose Fields";

		/// <summary>
		/// <para>Tool Name : TransposeFields</para>
		/// </summary>
		public override string ToolName() => "TransposeFields";

		/// <summary>
		/// <para>Tool Excute Name : management.TransposeFields</para>
		/// </summary>
		public override string ExcuteName() => "management.TransposeFields";

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
		public override object[] Parameters() => new object[] { InTable, InField, OutTable, InTransposedFieldName, InValueFieldName, AttributeFields };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input feature class or table containing data value fields to be transposed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Fields To Transpose</para>
		/// <para>The fields or columns containing data values in the input table that need to be transposed.</para>
		/// <para>Depending on your needs, you can select multiple fields to be transposed. The value here defines what the field name will be in the output. When not specified, the value is the same as the field name by default. However, you can also specify your own value. For example, if the field names to be transposed are Pop1991, Pop1992, and so on, by default, the values for these fields in the output will be the same (Pop1991, Pop1992, and so forth). However, you can choose to specify your own values such as 1991 and 1992.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output feature class or table. The output will contain a transposed field, a value field, and any number of specified attribute fields that need to be inherited from the input table.</para>
		/// <para>By default the Output Table is a table. The output will be a feature class when the Input Table is a feature class and the Shape field is selected in the Attribute Fields parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Transposed Field</para>
		/// <para>The name of the field that will be created to store field names of the transposed fields. Any valid field name can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InTransposedFieldName { get; set; }

		/// <summary>
		/// <para>Value Field</para>
		/// <para>The name of the field that will be created to store the corresponding values of the transposed fields. Any valid field name can be set, as long as it does not conflict with existing field names from the input table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InValueFieldName { get; set; }

		/// <summary>
		/// <para>Attribute Fields</para>
		/// <para>Additional attribute fields from the input table to be included in the output table. If you want to output a feature class, add the Shape field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object AttributeFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransposeFields SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
