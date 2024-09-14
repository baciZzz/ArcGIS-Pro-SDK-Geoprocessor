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
	/// <para>Iterate Fields</para>
	/// <para>迭代字段</para>
	/// <para>迭代表中的字段。</para>
	/// </summary>
	public class IterateFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>具有要迭代字段的输入表。</para>
		/// </param>
		public IterateFields(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代字段</para>
		/// </summary>
		public override string DisplayName() => "迭代字段";

		/// <summary>
		/// <para>Tool Name : IterateFields</para>
		/// </summary>
		public override string ToolName() => "IterateFields";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateFields</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateFields";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, FieldType!, Wildcard!, InputFields!, OutputField!, OutputCount! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>具有要迭代字段的输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>指定用于过滤字段的字段类型。如果未指定字段类型，则将迭代受支持字段类型的所有字段。</para>
		/// <para>Blob—BLOB 字段将被迭代。</para>
		/// <para>日期—日期字段将被迭代。</para>
		/// <para>双精度—双精度型字段将被迭代。</para>
		/// <para>浮点型—浮点型字段将被迭代。</para>
		/// <para>GUID—GUID 字段将被迭代。</para>
		/// <para>长整型—长整型字段将被迭代。</para>
		/// <para>栅格—栅格字段将被迭代。</para>
		/// <para>短整型—短整型字段将被迭代。</para>
		/// <para>文本型—文本字段将被迭代。</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? FieldType { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>限制将要迭代的字段。通配符可用于字段名称和字段别名，并且是 * 和其他字符的组合。例如，可使用此参数来限制对以某个字符或词语（例如 A* 或 Ari* 或 Land* 等）开头的输入字段名称或字段别名进行迭代。星号等同于搜索所有字段。如果未指定通配符，则将返回所有输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Field Names</para>
		/// <para>将要迭代的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object? InputFields { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object? OutputField { get; set; }

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputCount { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>文本型—文本字段将被迭代。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本型")]
			Text,

			/// <summary>
			/// <para>浮点型—浮点型字段将被迭代。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型")]
			Float,

			/// <summary>
			/// <para>双精度—双精度型字段将被迭代。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度")]
			Double,

			/// <summary>
			/// <para>短整型—短整型字段将被迭代。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型")]
			Short,

			/// <summary>
			/// <para>长整型—长整型字段将被迭代。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型")]
			Long,

			/// <summary>
			/// <para>日期—日期字段将被迭代。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

			/// <summary>
			/// <para>Blob—BLOB 字段将被迭代。</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob")]
			Blob,

			/// <summary>
			/// <para>栅格—栅格字段将被迭代。</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("栅格")]
			Raster,

			/// <summary>
			/// <para>GUID—GUID 字段将被迭代。</para>
			/// </summary>
			[GPValue("GUID")]
			[Description("GUID")]
			GUID,

		}

#endregion
	}
}
