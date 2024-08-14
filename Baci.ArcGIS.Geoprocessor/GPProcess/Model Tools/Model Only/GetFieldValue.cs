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
	/// <para>Get Field Value</para>
	/// <para>Returns the value of the first row of a table for the specified field.</para>
	/// </summary>
	public class GetFieldValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table to get the value from.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>The input field to get the value from. The value of the first record will be output.</para>
		/// </param>
		public GetFieldValue(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Field Value</para>
		/// </summary>
		public override string DisplayName => "Get Field Value";

		/// <summary>
		/// <para>Tool Name : GetFieldValue</para>
		/// </summary>
		public override string ToolName => "GetFieldValue";

		/// <summary>
		/// <para>Tool Excute Name : mb.GetFieldValue</para>
		/// </summary>
		public override string ExcuteName => "mb.GetFieldValue";

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
		public override object[] Parameters => new object[] { InTable, Field, DataType!, NullValue!, Value! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table to get the value from.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>The input field to get the value from. The value of the first record will be output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>The data type of the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; } = "String";

		/// <summary>
		/// <para>Null Value</para>
		/// <para>The value to use for null values. The default is 0 for numbers and blank ("") for strings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NullValue { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object? Value { get; set; }

	}
}
