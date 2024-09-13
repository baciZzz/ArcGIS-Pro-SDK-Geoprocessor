using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Select Layer By Date And Time</para>
	/// <para>按日期和时间选择</para>
	/// <para>将根据日期和时间范围或日期属性（例如，单个日期、时间范围、时间段、星期、月或年）选择记录。</para>
	/// </summary>
	public class SelectLayerByDateAndTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Rows</para>
		/// <para>包含将应用选择内容的日期字段的数据。</para>
		/// </param>
		/// <param name="SelectionType">
		/// <para>Selection Type</para>
		/// <para>指定将如何应用选择内容，以及如果选择内容已存在，则将执行的操作。</para>
		/// <para>新建选择内容—生成的选择内容将替换当前选择内容。 这是默认设置。</para>
		/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
		/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。 如果不存在选择内容，该选项不起作用。</para>
		/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </param>
		/// <param name="TimeType">
		/// <para>Time Type</para>
		/// <para>指定将用于选择记录的日期和时间字段。</para>
		/// <para>单个时间字段—将基于输入要素上的单个时间字段选择记录。</para>
		/// <para>时间范围字段—将基于输入要素上的起始和结束时间字段选择记录。</para>
		/// <para><see cref="TimeTypeEnum"/></para>
		/// </param>
		public SelectLayerByDateAndTime(object InLayerOrView, object SelectionType, object TimeType)
		{
			this.InLayerOrView = InLayerOrView;
			this.SelectionType = SelectionType;
			this.TimeType = TimeType;
		}

		/// <summary>
		/// <para>Tool Display Name : 按日期和时间选择</para>
		/// </summary>
		public override string DisplayName() => "按日期和时间选择";

		/// <summary>
		/// <para>Tool Name : SelectLayerByDateAndTime</para>
		/// </summary>
		public override string ToolName() => "SelectLayerByDateAndTime";

		/// <summary>
		/// <para>Tool Excute Name : ca.SelectLayerByDateAndTime</para>
		/// </summary>
		public override string ExcuteName() => "ca.SelectLayerByDateAndTime";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayerOrView, SelectionType, TimeType, DateField, StartDateField, EndDateField, SelectionOptions, DateSelectionType, SingleDate, StartDate, EndDate, UseSystemTime, TimeSlice, StartTime, EndTime, DaysOfWeek, Months, Years, OutLayerOrView, Count };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>包含将应用选择内容的日期字段的数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Selection Type</para>
		/// <para>指定将如何应用选择内容，以及如果选择内容已存在，则将执行的操作。</para>
		/// <para>新建选择内容—生成的选择内容将替换当前选择内容。 这是默认设置。</para>
		/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
		/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。 如果不存在选择内容，该选项不起作用。</para>
		/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Time Type</para>
		/// <para>指定将用于选择记录的日期和时间字段。</para>
		/// <para>单个时间字段—将基于输入要素上的单个时间字段选择记录。</para>
		/// <para>时间范围字段—将基于输入要素上的起始和结束时间字段选择记录。</para>
		/// <para><see cref="TimeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeType { get; set; } = "SINGLE_TIME_FIELD";

		/// <summary>
		/// <para>Date Field</para>
		/// <para>输入图层中将用作选择依据的日期字段。 如果时间类型参数设置为单个时间字段，则此参数仅处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Start Date Field</para>
		/// <para>时间范围中将用作选择依据的起始日期字段。 如果时间类型参数设置为时间范围字段，则此参数仅处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object StartDateField { get; set; }

		/// <summary>
		/// <para>End Date Field</para>
		/// <para>时间范围中将用作选择依据的结束日期字段。 如果时间类型参数设置为时间范围字段，则此参数仅处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object EndDateField { get; set; }

		/// <summary>
		/// <para>Selection Options</para>
		/// <para>指定将如何选择日期和时间。</para>
		/// <para>日期—将按日期进行选择。</para>
		/// <para>时间—将按时间进行选择。</para>
		/// <para>星期—将按星期进行选择。</para>
		/// <para>月—将按月进行选择。</para>
		/// <para>年—将按年进行选择。</para>
		/// <para><see cref="SelectionOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object SelectionOptions { get; set; }

		/// <summary>
		/// <para>Date Selection Type</para>
		/// <para>指定根据日期范围、单数日期、新近时间段或比较时间段选择记录。</para>
		/// <para>仅在将选择选项参数设置为日期时才启用此参数。</para>
		/// <para>按日期范围—将根据起始和结束日期范围选择记录。</para>
		/// <para>按单个日期—将根据指定日期选择记录。</para>
		/// <para>按新近性—将根据与当前日期（系统日期和时间）相关的时间段（例如最近 14 天内）选择记录。</para>
		/// <para>按比较时间段—将根据与当前日期（系统日期和时间）相关的最近时间段的上一时间段选择记录。 例如，如果当前日期为 1 月 29 日，时间片为 14 天，则将选择 1 月 1 日至 1 月 14 日之间发生的记录。 此选项可以与后续按新近性（Python 中的 RECENCY）选择结合使用，用于比较两个相邻时间段之间的记录计数（例如，1 月 1 日至 14 日和 1 月 15 日至 28 日的两个 14 天时间段）。</para>
		/// <para><see cref="DateSelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Select by Date")]
		public object DateSelectionType { get; set; }

		/// <summary>
		/// <para>Date</para>
		/// <para>要选择的单个日期和时间。</para>
		/// <para>仅在将日期选择类型参数设置为按单个日期时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Date")]
		public object SingleDate { get; set; }

		/// <summary>
		/// <para>Start Date</para>
		/// <para>日期范围的开始日期。</para>
		/// <para>仅在将日期选择类型参数设置为按日期范围时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Date")]
		public object StartDate { get; set; }

		/// <summary>
		/// <para>End Date</para>
		/// <para>日期范围的结束日期。</para>
		/// <para>仅在将日期选择类型参数设置为按日期范围时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Date")]
		public object EndDate { get; set; }

		/// <summary>
		/// <para>Use Current System time as End Time</para>
		/// <para>指定是否将当前日期（本地系统时间）的记录包含在选择中（如果其在最近时间段中存在）。</para>
		/// <para>选中 - 当前日期的记录将包含在选择中。</para>
		/// <para>未选中 - 当前日期的记录将不包含在选择中。</para>
		/// <para>例如，指定的时间片为 14 天，本地系统时间为 5:00 p.m.，该工具在 1 月 15 日执行时，新近时间段将包含 14 天前的日期 5:00 p.m. 和执行工具当天 5:00 p.m. 之间的所有记录，并选中此参数。 在本示例中，对于 14 天时间片，选择将为 2017 年 1 月 1 日 5:00:00 PM 至 2017 年 1 月 15 日 5:00:00 PM。 如果在未选中此参数的情况下使用此相同示例，则最近时间段将使用当天的开始时间作为结束时间（基于本地系统时间）。 在本示例中，对于 14 天时间片，选择将为 2017 年 1 月 1 日 12:00:00 AM 至 2017 年 1 月 15 日 12:00:00 AM。</para>
		/// <para>仅在将日期选择类型参数设置为按比较时间段或按新近性时才启用此参数。</para>
		/// <para><see cref="UseSystemTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Select by Date")]
		public object UseSystemTime { get; set; } = "false";

		/// <summary>
		/// <para>Time Slice</para>
		/// <para>用于定义选择将基于的最近时间段的时间单位（分钟、小时、天、周、月或年）数量，例如最近 14 天内的事件。</para>
		/// <para>仅在将日期选择类型参数设置为按比较时间段或按新近性时才启用此参数。</para>
		/// <para><see cref="TimeSliceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		[Category("Select by Date")]
		public object TimeSlice { get; set; }

		/// <summary>
		/// <para>Start Time</para>
		/// <para>时间范围的开始时间。</para>
		/// <para>仅在将选择选项参数设置为时间时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Time of Day")]
		public object StartTime { get; set; }

		/// <summary>
		/// <para>End Time</para>
		/// <para>时间范围的结束时间。</para>
		/// <para>仅在将选择选项参数设置为时间时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Time of Day")]
		public object EndTime { get; set; }

		/// <summary>
		/// <para>Days of Week</para>
		/// <para>指定用于选择记录的星期。</para>
		/// <para>星期一—将选择星期一发生的记录。</para>
		/// <para>星期二—将选择星期二发生的记录。</para>
		/// <para>星期三—将选择星期三发生的记录。</para>
		/// <para>星期四—将选择星期四发生的记录。</para>
		/// <para>星期五—将选择星期五发生的记录。</para>
		/// <para>星期六—将选择星期六发生的记录。</para>
		/// <para>星期日—将选择星期日发生的记录。</para>
		/// <para>仅在将选择选项参数设置为星期时才启用此参数。</para>
		/// <para><see cref="DaysOfWeekEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Select by Days of Week")]
		public object DaysOfWeek { get; set; }

		/// <summary>
		/// <para>Months</para>
		/// <para>指定用于选择记录的月。</para>
		/// <para>一月—将选择 1 月发生的记录。</para>
		/// <para>二月—将选择 2 月发生的记录。</para>
		/// <para>三月—将选择 3 月发生的记录。</para>
		/// <para>四月—将选择 4 月发生的记录。</para>
		/// <para>五月—将选择 5 月发生的记录。</para>
		/// <para>六月—将选择 6 月发生的记录。</para>
		/// <para>七月—将选择 7 月发生的记录。</para>
		/// <para>八月—将选择 8 月发生的记录。</para>
		/// <para>九月—将选择 9 月发生的记录。</para>
		/// <para>十月—将选择 10 月发生的记录。</para>
		/// <para>十一月—将选择 11 月发生的记录。</para>
		/// <para>十二月—将选择 12 月发生的记录。</para>
		/// <para>仅在将选择选项参数设置为月时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Select by Month")]
		public object Months { get; set; }

		/// <summary>
		/// <para>Years</para>
		/// <para>指定用于选择记录的年。</para>
		/// <para>仅在将选择选项参数设置为年时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPRangeDomain(Min = 1, Max = 9999)]
		[Category("Select by Year")]
		public object Years { get; set; }

		/// <summary>
		/// <para>Updated Layer or Table View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Row Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object Count { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Selection Type</para>
		/// </summary>
		public enum SelectionTypeEnum 
		{
			/// <summary>
			/// <para>新建选择内容—生成的选择内容将替换当前选择内容。 这是默认设置。</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("新建选择内容")]
			New_selection,

			/// <summary>
			/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("添加到当前选择内容")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。 如果不存在选择内容，该选项不起作用。</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("从当前选择内容中移除")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("选择当前选择内容的子集")]
			Select_subset_from_the_current_selection,

		}

		/// <summary>
		/// <para>Time Type</para>
		/// </summary>
		public enum TimeTypeEnum 
		{
			/// <summary>
			/// <para>单个时间字段—将基于输入要素上的单个时间字段选择记录。</para>
			/// </summary>
			[GPValue("SINGLE_TIME_FIELD")]
			[Description("单个时间字段")]
			Single_Time_Field,

			/// <summary>
			/// <para>时间范围字段—将基于输入要素上的起始和结束时间字段选择记录。</para>
			/// </summary>
			[GPValue("TIME_RANGE_FIELDS")]
			[Description("时间范围字段")]
			Time_Range_Fields,

		}

		/// <summary>
		/// <para>Selection Options</para>
		/// </summary>
		public enum SelectionOptionsEnum 
		{
			/// <summary>
			/// <para>日期—将按日期进行选择。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

			/// <summary>
			/// <para>时间—将按时间进行选择。</para>
			/// </summary>
			[GPValue("TIME")]
			[Description("时间")]
			Time,

			/// <summary>
			/// <para>星期—将按星期进行选择。</para>
			/// </summary>
			[GPValue("DAY_OF_WEEK")]
			[Description("星期")]
			Day_of_week,

			/// <summary>
			/// <para>月—将按月进行选择。</para>
			/// </summary>
			[GPValue("MONTH")]
			[Description("月")]
			Month,

			/// <summary>
			/// <para>年—将按年进行选择。</para>
			/// </summary>
			[GPValue("YEAR")]
			[Description("年")]
			Year,

		}

		/// <summary>
		/// <para>Date Selection Type</para>
		/// </summary>
		public enum DateSelectionTypeEnum 
		{
			/// <summary>
			/// <para>按日期范围—将根据起始和结束日期范围选择记录。</para>
			/// </summary>
			[GPValue("DATE_RANGE")]
			[Description("按日期范围")]
			By_Date_Range,

			/// <summary>
			/// <para>按单个日期—将根据指定日期选择记录。</para>
			/// </summary>
			[GPValue("SINGLE_DATE")]
			[Description("按单个日期")]
			By_Single_Date,

			/// <summary>
			/// <para>按新近性—将根据与当前日期（系统日期和时间）相关的时间段（例如最近 14 天内）选择记录。</para>
			/// </summary>
			[GPValue("RECENCY")]
			[Description("按新近性")]
			By_Recency,

			/// <summary>
			/// <para>按比较时间段—将根据与当前日期（系统日期和时间）相关的最近时间段的上一时间段选择记录。 例如，如果当前日期为 1 月 29 日，时间片为 14 天，则将选择 1 月 1 日至 1 月 14 日之间发生的记录。 此选项可以与后续按新近性（Python 中的 RECENCY）选择结合使用，用于比较两个相邻时间段之间的记录计数（例如，1 月 1 日至 14 日和 1 月 15 日至 28 日的两个 14 天时间段）。</para>
			/// </summary>
			[GPValue("COMPARATIVE")]
			[Description("按比较时间段")]
			By_Comparative_Time_Period,

		}

		/// <summary>
		/// <para>Use Current System time as End Time</para>
		/// </summary>
		public enum UseSystemTimeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SYSTEM_TIME")]
			SYSTEM_TIME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SYSTEM_TIME")]
			NO_SYSTEM_TIME,

		}

		/// <summary>
		/// <para>Time Slice</para>
		/// </summary>
		public enum TimeSliceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("年")]
			Years,

		}

		/// <summary>
		/// <para>Days of Week</para>
		/// </summary>
		public enum DaysOfWeekEnum 
		{
			/// <summary>
			/// <para>星期一—将选择星期一发生的记录。</para>
			/// </summary>
			[GPValue("MONDAY")]
			[Description("星期一")]
			Monday,

			/// <summary>
			/// <para>星期二—将选择星期二发生的记录。</para>
			/// </summary>
			[GPValue("TUESDAY")]
			[Description("星期二")]
			Tuesday,

			/// <summary>
			/// <para>星期三—将选择星期三发生的记录。</para>
			/// </summary>
			[GPValue("WEDNESDAY")]
			[Description("星期三")]
			Wednesday,

			/// <summary>
			/// <para>星期四—将选择星期四发生的记录。</para>
			/// </summary>
			[GPValue("THURSDAY")]
			[Description("星期四")]
			Thursday,

			/// <summary>
			/// <para>星期五—将选择星期五发生的记录。</para>
			/// </summary>
			[GPValue("FRIDAY")]
			[Description("星期五")]
			Friday,

			/// <summary>
			/// <para>星期六—将选择星期六发生的记录。</para>
			/// </summary>
			[GPValue("SATURDAY")]
			[Description("星期六")]
			Saturday,

			/// <summary>
			/// <para>星期日—将选择星期日发生的记录。</para>
			/// </summary>
			[GPValue("SUNDAY")]
			[Description("星期日")]
			Sunday,

		}

#endregion
	}
}
