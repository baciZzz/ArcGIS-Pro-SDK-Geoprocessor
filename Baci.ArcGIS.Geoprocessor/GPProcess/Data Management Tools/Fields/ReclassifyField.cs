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
	/// <para>Reclassify Field</para>
	/// <para>重分类字段</para>
	/// <para>根据手动定义的边界或使用重分类方法将数值字段或文本字段中的值重分类为多个类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ReclassifyField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要重分类的字段的输入表或要素类。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field to Reclassify</para>
		/// <para>要重分类的字段。 字段必须为数值或文本字段。</para>
		/// </param>
		public ReclassifyField(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 重分类字段</para>
		/// </summary>
		public override string DisplayName() => "重分类字段";

		/// <summary>
		/// <para>Tool Name : ReclassifyField</para>
		/// </summary>
		public override string ToolName() => "ReclassifyField";

		/// <summary>
		/// <para>Tool Excute Name : management.ReclassifyField</para>
		/// </summary>
		public override string ExcuteName() => "management.ReclassifyField";

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
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Field, Method, Classes, Interval, StandardDeviations, ReclassTable, ReverseValues, OutputFieldName, UpdatedTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要重分类的字段的输入表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Reclassify</para>
		/// <para>要重分类的字段。 字段必须为数值或文本字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Reclassification Method</para>
		/// <para>指定在要重分类的字段参数中指定的字段中包含值的方式。</para>
		/// <para>定义的间隔—创建基于要重分类的字段值的跨度分类范围相同的类。</para>
		/// <para>相等间隔—创建类范围整除指定分类数量的类。 这是默认设置。</para>
		/// <para>几何间隔—创建在几何上将分类范围增加或减小为指定数量的分类的类。</para>
		/// <para>手动间隔—分类间隔和重分类值手动指定。</para>
		/// <para>自然间断点分级法 (Jenks)—创建使用 Jenks 自然间断点分级法算法在数据中自然分组的类。</para>
		/// <para>分位数—创建每个类包含相等数量的值的类。</para>
		/// <para>标准差—通过加减高于和低于平均值一定比例的标准差创建类。</para>
		/// <para>唯一值—创建字段的每个唯一值变为一个类的类。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "EQUAL_INTERVAL";

		/// <summary>
		/// <para>Number of Classes</para>
		/// <para>重分类字段中的目标分类数量。 类的最大数量为 256。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		public object Classes { get; set; }

		/// <summary>
		/// <para>Interval Size</para>
		/// <para>重分类字段的类间隔大小。 提供的值必须生成至少 3 个类，并且不超过 1000 个类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Interval { get; set; }

		/// <summary>
		/// <para>Number of Standard Deviations</para>
		/// <para>指定重分类字段的标准差数。 分类间隔和类别以相等间隔范围创建，这些间隔范围与相对于平均值的标准差成比例。</para>
		/// <para>一个标准差—间隔使用一个标准差进行创建。 这是默认设置。</para>
		/// <para>二分之一标准差—间隔使用二分之一标准差进行创建。</para>
		/// <para>三分之一标准差—间隔使用三分之一标准差进行创建。</para>
		/// <para>四分之一标准差—间隔使用四分之一标准差进行创建。</para>
		/// <para><see cref="StandardDeviationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StandardDeviations { get; set; } = "ONE";

		/// <summary>
		/// <para>Reclassification Table</para>
		/// <para>手动重分类方法的上限和重分类值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ReclassTable { get; set; }

		/// <summary>
		/// <para>Reverse Values (Descending)</para>
		/// <para>指定如何对重分类值进行排序。</para>
		/// <para>选中 - 按降序向类分配值；值最高的类将分配 1，下一个最高类将分配 2，依此类推。</para>
		/// <para>未选中 - 按升序向类分配值；值最低的类将分配 1，下一个最低类将分配 2，依此类推。 这是默认设置。</para>
		/// <para><see cref="ReverseValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReverseValues { get; set; } = "false";

		/// <summary>
		/// <para>Output Field Name</para>
		/// <para>输出字段的名称或前缀。 如果要重分类的字段是数值字段，则将创建两个字段，并且将以该名称作为字段名称的前缀。 如果要重分类的字段是文本字段，则将使用此名称创建一个新字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutputFieldName { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReclassifyField SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reclassification Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>定义的间隔—创建基于要重分类的字段值的跨度分类范围相同的类。</para>
			/// </summary>
			[GPValue("DEFINED_INTERVAL")]
			[Description("定义的间隔")]
			Defined_interval,

			/// <summary>
			/// <para>相等间隔—创建类范围整除指定分类数量的类。 这是默认设置。</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("相等间隔")]
			Equal_interval,

			/// <summary>
			/// <para>几何间隔—创建在几何上将分类范围增加或减小为指定数量的分类的类。</para>
			/// </summary>
			[GPValue("GEOMETRIC_INTERVAL")]
			[Description("几何间隔")]
			Geometric_interval,

			/// <summary>
			/// <para>手动间隔—分类间隔和重分类值手动指定。</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("手动间隔")]
			Manual_interval,

			/// <summary>
			/// <para>自然间断点分级法 (Jenks)—创建使用 Jenks 自然间断点分级法算法在数据中自然分组的类。</para>
			/// </summary>
			[GPValue("NATURAL_BREAKS")]
			[Description("自然间断点分级法 (Jenks)")]
			NATURAL_BREAKS,

			/// <summary>
			/// <para>分位数—创建每个类包含相等数量的值的类。</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("分位数")]
			Quantile,

			/// <summary>
			/// <para>标准差—通过加减高于和低于平均值一定比例的标准差创建类。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>唯一值—创建字段的每个唯一值变为一个类的类。</para>
			/// </summary>
			[GPValue("UNIQUE_VALUES")]
			[Description("唯一值")]
			Unique_values,

		}

		/// <summary>
		/// <para>Number of Standard Deviations</para>
		/// </summary>
		public enum StandardDeviationsEnum 
		{
			/// <summary>
			/// <para>一个标准差—间隔使用一个标准差进行创建。 这是默认设置。</para>
			/// </summary>
			[GPValue("ONE")]
			[Description("一个标准差")]
			One_standard_deviation,

			/// <summary>
			/// <para>二分之一标准差—间隔使用二分之一标准差进行创建。</para>
			/// </summary>
			[GPValue("HALF")]
			[Description("二分之一标准差")]
			One_half_of_a_standard_deviation,

			/// <summary>
			/// <para>三分之一标准差—间隔使用三分之一标准差进行创建。</para>
			/// </summary>
			[GPValue("THIRD")]
			[Description("三分之一标准差")]
			One_third_of_a_standard_deviation,

			/// <summary>
			/// <para>四分之一标准差—间隔使用四分之一标准差进行创建。</para>
			/// </summary>
			[GPValue("QUARTER")]
			[Description("四分之一标准差")]
			One_quarter_of_a_standard_deviation,

		}

		/// <summary>
		/// <para>Reverse Values (Descending)</para>
		/// </summary>
		public enum ReverseValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DESC")]
			DESC,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ASC")]
			ASC,

		}

#endregion
	}
}
