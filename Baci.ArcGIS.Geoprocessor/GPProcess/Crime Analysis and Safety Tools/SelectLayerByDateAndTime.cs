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
	/// <para>Select Layer By Date And Time</para>
	/// <para>Selects records based on date and time ranges or date properties, for example, single date, time range, time period, days of the week, month, or year.</para>
	/// </summary>
	public class SelectLayerByDateAndTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Rows</para>
		/// <para>The data containing a date field to which the selection will be applied.</para>
		/// </param>
		/// <param name="SelectionType">
		/// <para>Selection Type</para>
		/// <para>Specifies how the selection will be applied and what will occur if a selection already exists.</para>
		/// <para>New selection— The resulting selection will replace the current selection. This is the default.</para>
		/// <para>Add to the current selection— The resulting selection will be added to the current selection if one exists. If no selection exists, this is the same as the new selection option.</para>
		/// <para>Remove from the current selection— The resulting selection will be removed from the current selection. If no selection exists, this option has no effect.</para>
		/// <para>Select subset from the current selection— The resulting selection will be combined with the current selection. Only records that are common to both remain selected.</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </param>
		/// <param name="TimeType">
		/// <para>Time Type</para>
		/// <para>Specifies how date and time fields will be used to select records.</para>
		/// <para>Single Time Field—Records will be selected based on a single time field on the input feature.</para>
		/// <para>Time Range Fields—Records will be selected based on start and end time fields on the input feature.</para>
		/// <para><see cref="TimeTypeEnum"/></para>
		/// </param>
		public SelectLayerByDateAndTime(object InLayerOrView, object SelectionType, object TimeType)
		{
			this.InLayerOrView = InLayerOrView;
			this.SelectionType = SelectionType;
			this.TimeType = TimeType;
		}

		/// <summary>
		/// <para>Tool Display Name : Select Layer By Date And Time</para>
		/// </summary>
		public override string DisplayName() => "Select Layer By Date And Time";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayerOrView, SelectionType, TimeType, DateField, StartDateField, EndDateField, SelectionOptions, DateSelectionType, SingleDate, StartDate, EndDate, UseSystemTime, TimeSlice, StartTime, EndTime, DaysOfWeek, Months, Years, OutLayerOrView, Count };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>The data containing a date field to which the selection will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Selection Type</para>
		/// <para>Specifies how the selection will be applied and what will occur if a selection already exists.</para>
		/// <para>New selection— The resulting selection will replace the current selection. This is the default.</para>
		/// <para>Add to the current selection— The resulting selection will be added to the current selection if one exists. If no selection exists, this is the same as the new selection option.</para>
		/// <para>Remove from the current selection— The resulting selection will be removed from the current selection. If no selection exists, this option has no effect.</para>
		/// <para>Select subset from the current selection— The resulting selection will be combined with the current selection. Only records that are common to both remain selected.</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Time Type</para>
		/// <para>Specifies how date and time fields will be used to select records.</para>
		/// <para>Single Time Field—Records will be selected based on a single time field on the input feature.</para>
		/// <para>Time Range Fields—Records will be selected based on start and end time fields on the input feature.</para>
		/// <para><see cref="TimeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeType { get; set; } = "SINGLE_TIME_FIELD";

		/// <summary>
		/// <para>Date Field</para>
		/// <para>The date field from the input layer on which the selection will be based. This parameter is only active if the Time Type parameter is set to Single Time Field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Start Date Field</para>
		/// <para>The start date field from the time range on which the selection will be based. This parameter is only active if the Time Type parameter is set to Time Range Fields .</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object StartDateField { get; set; }

		/// <summary>
		/// <para>End Date Field</para>
		/// <para>The end date field from the time range on which the selection will be based. This parameter is only active if the Time Type parameter is set to Time Range Fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object EndDateField { get; set; }

		/// <summary>
		/// <para>Selection Options</para>
		/// <para>Specifies how date and time selections will be made.</para>
		/// <para>Date—The selection will be by date.</para>
		/// <para>Time—The selection will be by time of day.</para>
		/// <para>Day of week—The selection will be by day of the week.</para>
		/// <para>Month—The selection will be by month.</para>
		/// <para>Year—The selection will be by year.</para>
		/// <para><see cref="SelectionOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object SelectionOptions { get; set; }

		/// <summary>
		/// <para>Date Selection Type</para>
		/// <para>Specifies whether records will be selected based on a date range, singular date, recency period, or comparative time period.</para>
		/// <para>This parameter is only active when the Selection Options parameter is set to Date.</para>
		/// <para>By Date Range—Records will be selected based on a start and end date range.</para>
		/// <para>By Single Date—Records will be selected based on the date specified.</para>
		/// <para>By Recency—Records will be selected based on a time period in relation to the current date (system date and time), for example, within the last 14 days.</para>
		/// <para>By Comparative Time Period—Records will be selected based on the time period immediately preceding a recent time period in relation to the current date (system date and time). For example, if the current date is January 29 and the time slice is 14 days, records occurring between January 1 and January 14 will be selected. This option can be used in combination with a subsequent By Recency (RECENCY in Python) selection to compare record counts between two adjacent time periods (for example, the two 14-day time periods of January 1–14 and January 15–28).</para>
		/// <para><see cref="DateSelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Select by Date")]
		public object DateSelectionType { get; set; }

		/// <summary>
		/// <para>Date</para>
		/// <para>The single date and time to be selected.</para>
		/// <para>This parameter is only active when the Date Selection Type parameter is set to By Single Date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Date")]
		public object SingleDate { get; set; }

		/// <summary>
		/// <para>Start Date</para>
		/// <para>The start date of the date range.</para>
		/// <para>This parameter is only active when the Date Selection Type parameter is set to By Date Range.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Date")]
		public object StartDate { get; set; }

		/// <summary>
		/// <para>End Date</para>
		/// <para>The end date of the date range.</para>
		/// <para>This parameter is only active when the Date Selection Type parameter is set to By Date Range.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Date")]
		public object EndDate { get; set; }

		/// <summary>
		/// <para>Use Current System time as End Time</para>
		/// <para>Specifies whether records from the current day (local system time) will be included in the selection if they exist in the recent time period.</para>
		/// <para>Checked—Records from the current day will be included in the selection.</para>
		/// <para>Unchecked—Records from the current day will not be included in the selection.</para>
		/// <para>For example, the time slice specified is 14 days, the local system time is 5:00 p.m on January 15 when the tool executes, the recency time period includes all records between 5:00 p.m. on the date 14 days ago and 5:00 p.m. on the day the tool is executed, and this parameter is checked. In this example, the selection will be January 1, 2017 5:00:00 PM to January 15, 2017 5:00:00 PM for the 14-day time slice. Using this same example with this parameter unchecked, the recent period uses the beginning of the current day as the end time (based on local system time). In this case, the selection will be January 1, 2017 12:00:00 AM to January 15, 12:00:00 AM for the 14-day time slice.</para>
		/// <para>This parameter is only active when the Date Selection Type parameter is set to By Comparative Time Period or By Recency.</para>
		/// <para><see cref="UseSystemTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Select by Date")]
		public object UseSystemTime { get; set; } = "false";

		/// <summary>
		/// <para>Time Slice</para>
		/// <para>The number of time units (minutes, hours, days, weeks, months, or years) defining the recent time period on which the selection will be based, for example, events within the last 14 days.</para>
		/// <para>This parameter is only active when the Date Selection Type parameter is set to By Comparative Time Period or By Recency.</para>
		/// <para><see cref="TimeSliceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		[Category("Select by Date")]
		public object TimeSlice { get; set; }

		/// <summary>
		/// <para>Start Time</para>
		/// <para>The start time of the time range.</para>
		/// <para>This parameter is only active when the Selection Options parameter is set to Time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Time of Day")]
		public object StartTime { get; set; }

		/// <summary>
		/// <para>End Time</para>
		/// <para>The end time of the time range.</para>
		/// <para>This parameter is only active when the Selection Options parameter is set to Time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Select by Time of Day")]
		public object EndTime { get; set; }

		/// <summary>
		/// <para>Days of Week</para>
		/// <para>Specifies the days of the week used to select records.</para>
		/// <para>Monday—Records occurring on Monday will be selected.</para>
		/// <para>Tuesday—Records occurring on Tuesday will be selected.</para>
		/// <para>Wednesday—Records occurring on Wednesday will be selected.</para>
		/// <para>Thursday—Records occurring on Thursday will be selected.</para>
		/// <para>Friday—Records occurring on Friday will be selected.</para>
		/// <para>Saturday—Records occurring on Saturday will be selected.</para>
		/// <para>Sunday—Records occurring on Sunday will be selected.</para>
		/// <para>This parameter is only active when the Selection Options parameter is set to Day of week.</para>
		/// <para><see cref="DaysOfWeekEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Select by Days of Week")]
		public object DaysOfWeek { get; set; }

		/// <summary>
		/// <para>Months</para>
		/// <para>Specifies the months used to select records.</para>
		/// <para>January—Records occurring in January will be selected.</para>
		/// <para>February—Records occurring in February will be selected.</para>
		/// <para>March—Records occurring in March will be selected.</para>
		/// <para>April—Records occurring in April will be selected.</para>
		/// <para>May—Records occurring in May will be selected.</para>
		/// <para>June—Records occurring in June will be selected.</para>
		/// <para>July—Records occurring in July will be selected.</para>
		/// <para>August—Records occurring in August will be selected.</para>
		/// <para>September—Records occurring in September will be selected.</para>
		/// <para>October—Records occurring in October will be selected.</para>
		/// <para>November—Records occurring in November will be selected.</para>
		/// <para>December—Records occurring in December will be selected.</para>
		/// <para>This parameter is only active when the Selection Options parameter is set to Month.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Select by Month")]
		public object Months { get; set; }

		/// <summary>
		/// <para>Years</para>
		/// <para>Specifies the years used to select records.</para>
		/// <para>This parameter is only active when the Selection Options parameter is set to Years.</para>
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
			/// <para>New selection— The resulting selection will replace the current selection. This is the default.</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("New selection")]
			New_selection,

			/// <summary>
			/// <para>Add to the current selection— The resulting selection will be added to the current selection if one exists. If no selection exists, this is the same as the new selection option.</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("Add to the current selection")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>Remove from the current selection— The resulting selection will be removed from the current selection. If no selection exists, this option has no effect.</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("Remove from the current selection")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>Select subset from the current selection— The resulting selection will be combined with the current selection. Only records that are common to both remain selected.</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("Select subset from the current selection")]
			Select_subset_from_the_current_selection,

		}

		/// <summary>
		/// <para>Time Type</para>
		/// </summary>
		public enum TimeTypeEnum 
		{
			/// <summary>
			/// <para>Single Time Field—Records will be selected based on a single time field on the input feature.</para>
			/// </summary>
			[GPValue("SINGLE_TIME_FIELD")]
			[Description("Single Time Field")]
			Single_Time_Field,

			/// <summary>
			/// <para>Time Range Fields—Records will be selected based on start and end time fields on the input feature.</para>
			/// </summary>
			[GPValue("TIME_RANGE_FIELDS")]
			[Description("Time Range Fields")]
			Time_Range_Fields,

		}

		/// <summary>
		/// <para>Selection Options</para>
		/// </summary>
		public enum SelectionOptionsEnum 
		{
			/// <summary>
			/// <para>Date—The selection will be by date.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

			/// <summary>
			/// <para>Time—The selection will be by time of day.</para>
			/// </summary>
			[GPValue("TIME")]
			[Description("Time")]
			Time,

			/// <summary>
			/// <para>Day of week—The selection will be by day of the week.</para>
			/// </summary>
			[GPValue("DAY_OF_WEEK")]
			[Description("Day of week")]
			Day_of_week,

			/// <summary>
			/// <para>Month—The selection will be by month.</para>
			/// </summary>
			[GPValue("MONTH")]
			[Description("Month")]
			Month,

			/// <summary>
			/// <para>Year—The selection will be by year.</para>
			/// </summary>
			[GPValue("YEAR")]
			[Description("Year")]
			Year,

		}

		/// <summary>
		/// <para>Date Selection Type</para>
		/// </summary>
		public enum DateSelectionTypeEnum 
		{
			/// <summary>
			/// <para>By Date Range—Records will be selected based on a start and end date range.</para>
			/// </summary>
			[GPValue("DATE_RANGE")]
			[Description("By Date Range")]
			By_Date_Range,

			/// <summary>
			/// <para>By Single Date—Records will be selected based on the date specified.</para>
			/// </summary>
			[GPValue("SINGLE_DATE")]
			[Description("By Single Date")]
			By_Single_Date,

			/// <summary>
			/// <para>By Recency—Records will be selected based on a time period in relation to the current date (system date and time), for example, within the last 14 days.</para>
			/// </summary>
			[GPValue("RECENCY")]
			[Description("By Recency")]
			By_Recency,

			/// <summary>
			/// <para>By Comparative Time Period—Records will be selected based on the time period immediately preceding a recent time period in relation to the current date (system date and time). For example, if the current date is January 29 and the time slice is 14 days, records occurring between January 1 and January 14 will be selected. This option can be used in combination with a subsequent By Recency (RECENCY in Python) selection to compare record counts between two adjacent time periods (for example, the two 14-day time periods of January 1–14 and January 15–28).</para>
			/// </summary>
			[GPValue("COMPARATIVE")]
			[Description("By Comparative Time Period")]
			By_Comparative_Time_Period,

		}

		/// <summary>
		/// <para>Use Current System time as End Time</para>
		/// </summary>
		public enum UseSystemTimeEnum 
		{
			/// <summary>
			/// <para>Checked—Records from the current day will be included in the selection.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SYSTEM_TIME")]
			SYSTEM_TIME,

			/// <summary>
			/// <para>Unchecked—Records from the current day will not be included in the selection.</para>
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
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Days of Week</para>
		/// </summary>
		public enum DaysOfWeekEnum 
		{
			/// <summary>
			/// <para>Monday—Records occurring on Monday will be selected.</para>
			/// </summary>
			[GPValue("MONDAY")]
			[Description("Monday")]
			Monday,

			/// <summary>
			/// <para>Tuesday—Records occurring on Tuesday will be selected.</para>
			/// </summary>
			[GPValue("TUESDAY")]
			[Description("Tuesday")]
			Tuesday,

			/// <summary>
			/// <para>Wednesday—Records occurring on Wednesday will be selected.</para>
			/// </summary>
			[GPValue("WEDNESDAY")]
			[Description("Wednesday")]
			Wednesday,

			/// <summary>
			/// <para>Thursday—Records occurring on Thursday will be selected.</para>
			/// </summary>
			[GPValue("THURSDAY")]
			[Description("Thursday")]
			Thursday,

			/// <summary>
			/// <para>Friday—Records occurring on Friday will be selected.</para>
			/// </summary>
			[GPValue("FRIDAY")]
			[Description("Friday")]
			Friday,

			/// <summary>
			/// <para>Saturday—Records occurring on Saturday will be selected.</para>
			/// </summary>
			[GPValue("SATURDAY")]
			[Description("Saturday")]
			Saturday,

			/// <summary>
			/// <para>Sunday—Records occurring on Sunday will be selected.</para>
			/// </summary>
			[GPValue("SUNDAY")]
			[Description("Sunday")]
			Sunday,

		}

#endregion
	}
}
