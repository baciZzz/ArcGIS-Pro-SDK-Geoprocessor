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
	/// <para>转置字段</para>
	/// <para>在新表或要素类中，将字段或列中存储的数据转换到行中。</para>
	/// </summary>
	public class TransposeFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要转置的数据值字段的输入要素类或表。</para>
		/// </param>
		/// <param name="InField">
		/// <para>Fields To Transpose</para>
		/// <para>输入表中包含要进行转置的数据值的字段或列。</para>
		/// <para>根据需要，可以选择多个要进行转置的字段。此处的值用于定义输出中的字段名。如果未指定，则值与字段名默认相同。不过，也可以指定您自己的值。例如，如果要转置的字段名是 Pop1991、Pop1992 等，默认情况下，输出中这些字段的值将相同（Pop1991、Pop1992 等）。但也可选择指定您自己的值，如 1991 和 1992。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>输出要素类或表。输出将包含转置后的字段、值字段以及指定的需要从输入表继承的任意数量的属性字段。</para>
		/// <para>默认情况下，输出表为一张表。当输入表为要素类，并且在属性字段参数中选择了 Shape 字段时，输出将为要素类。</para>
		/// </param>
		/// <param name="InTransposedFieldName">
		/// <para>Transposed Field</para>
		/// <para>要创建的字段的名称，该字段用于存储已转置字段的字段名。可使用任何有效的字段名。</para>
		/// </param>
		/// <param name="InValueFieldName">
		/// <para>Value Field</para>
		/// <para>要创建的字段的名称，该字段用于存储已转置字段的相应值。可设置任何有效的字段名，只要它不与来自输入表或要素类的现有字段名冲突。</para>
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
		/// <para>Tool Display Name : 转置字段</para>
		/// </summary>
		public override string DisplayName() => "转置字段";

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
		/// <para>包含要转置的数据值字段的输入要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Fields To Transpose</para>
		/// <para>输入表中包含要进行转置的数据值的字段或列。</para>
		/// <para>根据需要，可以选择多个要进行转置的字段。此处的值用于定义输出中的字段名。如果未指定，则值与字段名默认相同。不过，也可以指定您自己的值。例如，如果要转置的字段名是 Pop1991、Pop1992 等，默认情况下，输出中这些字段的值将相同（Pop1991、Pop1992 等）。但也可选择指定您自己的值，如 1991 和 1992。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出要素类或表。输出将包含转置后的字段、值字段以及指定的需要从输入表继承的任意数量的属性字段。</para>
		/// <para>默认情况下，输出表为一张表。当输入表为要素类，并且在属性字段参数中选择了 Shape 字段时，输出将为要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Transposed Field</para>
		/// <para>要创建的字段的名称，该字段用于存储已转置字段的字段名。可使用任何有效的字段名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InTransposedFieldName { get; set; }

		/// <summary>
		/// <para>Value Field</para>
		/// <para>要创建的字段的名称，该字段用于存储已转置字段的相应值。可设置任何有效的字段名，只要它不与来自输入表或要素类的现有字段名冲突。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InValueFieldName { get; set; }

		/// <summary>
		/// <para>Attribute Fields</para>
		/// <para>来自输入表的要被包含在输出表中的附加属性字段。如果要输出要素类，请添加 Shape 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object AttributeFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransposeFields SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
