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
	/// <para>Encode Field</para>
	/// <para>编码字段</para>
	/// <para>将分类值（字符串、整数或日期）转换为多个数值字段，每个字段表示一个类别。编码的数值字段可用于大多数数据科学和统计工作流，包括回归模型。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EncodeField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要编码的字段的输入表或要素类。字段将添加到现有输入表，并且不会创建新的输出表。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field to Encode</para>
		/// <para>包含要编码的分类值或时间值的字段。</para>
		/// </param>
		public EncodeField(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 编码字段</para>
		/// </summary>
		public override string DisplayName() => "编码字段";

		/// <summary>
		/// <para>Tool Name : EncodeField</para>
		/// </summary>
		public override string ToolName() => "EncodeField";

		/// <summary>
		/// <para>Tool Excute Name : management.EncodeField</para>
		/// </summary>
		public override string ExcuteName() => "management.EncodeField";

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
		public override object[] Parameters() => new object[] { InTable, Field, Method!, TimeStepInterval!, TimeStepAlignment!, ReferenceTime!, UpdatedTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要编码的字段的输入表或要素类。字段将添加到现有输入表，并且不会创建新的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Encode</para>
		/// <para>包含要编码的分类值或时间值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Text", "Long", "Date")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Encoding Method</para>
		/// <para>指定用于对要编码的字段参数中包含的值进行编码的方法。</para>
		/// <para>一热—每个分类值都将转换为一个新字段，并且分配值 0 和 1，其中 1 表示存在该分类值。这是默认设置。</para>
		/// <para>一冷— 每个分类值都将转换为一个新字段，并且分配值 0 和 1，其中 0 表示存在该分类值。</para>
		/// <para>时态—要编码的字段参数中的每个时间值将根据时间步间隔、时间步对齐和指定的参考时间转换为整数。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "ONEHOT";

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>用来表示单个时间步长的秒数、分钟数、小时数、天数、周数或年数。时间值将聚合到其所在范围内的某一时间步中。如果未提供任何值，默认时间步间隔将基于两种算法，来确定时间步间隔的最佳数量和宽度。将使用两个结果中的较小者作为时间步间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>指定如何根据时间步间隔参数值进行聚合。</para>
		/// <para>结束时间— 时间步长将与最后一次时间事件对齐，并向后聚合时间。这是默认设置。</para>
		/// <para>开始时间— 时间步长将与第一次时间事件对齐，并向前聚合时间。</para>
		/// <para>参考时间— 时间步将与在参考时间参数中指定的日期和时间对齐。将从参考时间到开始向前和向后聚合时间，直到到达第一个和最后一个时间值。</para>
		/// <para><see cref="TimeStepAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeStepAlignment { get; set; } = "END_TIME";

		/// <summary>
		/// <para>Reference Time</para>
		/// <para>时间间隔将对齐到的日期和时间。例如，要按星期从星期一至星期天对数据进行图格组合，将星期天的午夜设置为参考时间，以确保时间步在星期天和星期一之间的午夜进行划分。</para>
		/// <para>该值可以是日期和时间值或仅为日期值；不能仅为时间。预期格式由计算机的区域时间设置确定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ReferenceTime { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EncodeField SetEnviroment(object? extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Encoding Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>一热—每个分类值都将转换为一个新字段，并且分配值 0 和 1，其中 1 表示存在该分类值。这是默认设置。</para>
			/// </summary>
			[GPValue("ONEHOT")]
			[Description("一热")]
			ONEHOT,

			/// <summary>
			/// <para>一冷— 每个分类值都将转换为一个新字段，并且分配值 0 和 1，其中 0 表示存在该分类值。</para>
			/// </summary>
			[GPValue("ONECOLD")]
			[Description("一冷")]
			ONECOLD,

			/// <summary>
			/// <para>时态—要编码的字段参数中的每个时间值将根据时间步间隔、时间步对齐和指定的参考时间转换为整数。</para>
			/// </summary>
			[GPValue("TEMPORAL")]
			[Description("时态")]
			Temporal,

		}

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// </summary>
		public enum TimeStepAlignmentEnum 
		{
			/// <summary>
			/// <para>结束时间— 时间步长将与最后一次时间事件对齐，并向后聚合时间。这是默认设置。</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("结束时间")]
			End_time,

			/// <summary>
			/// <para>开始时间— 时间步长将与第一次时间事件对齐，并向前聚合时间。</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("开始时间")]
			Start_time,

			/// <summary>
			/// <para>参考时间— 时间步将与在参考时间参数中指定的日期和时间对齐。将从参考时间到开始向前和向后聚合时间，直到到达第一个和最后一个时间值。</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("参考时间")]
			Reference_time,

		}

#endregion
	}
}
