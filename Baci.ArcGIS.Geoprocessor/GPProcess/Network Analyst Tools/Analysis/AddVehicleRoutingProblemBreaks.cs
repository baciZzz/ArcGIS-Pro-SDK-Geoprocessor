using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Add Vehicle Routing Problem Breaks</para>
	/// <para>Add Vehicle Routing Problem Breaks</para>
	/// <para>Creates breaks in a Vehicle Routing Problem (VRP) layer.</para>
	/// </summary>
	public class AddVehicleRoutingProblemBreaks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVrpLayer">
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>The vehicle routing problem analysis layer to which the breaks will be added.</para>
		/// </param>
		public AddVehicleRoutingProblemBreaks(object InVrpLayer)
		{
			this.InVrpLayer = InVrpLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Vehicle Routing Problem Breaks</para>
		/// </summary>
		public override string DisplayName() => "Add Vehicle Routing Problem Breaks";

		/// <summary>
		/// <para>Tool Name : AddVehicleRoutingProblemBreaks</para>
		/// </summary>
		public override string ToolName() => "AddVehicleRoutingProblemBreaks";

		/// <summary>
		/// <para>Tool Excute Name : na.AddVehicleRoutingProblemBreaks</para>
		/// </summary>
		public override string ExcuteName() => "na.AddVehicleRoutingProblemBreaks";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InVrpLayer, TargetRoute, BreakType, TimeWindowProperties, TravelTimeProperties, WorkTimeProperties, AppendToExistingBreaks, OutVrpLayer };

		/// <summary>
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>The vehicle routing problem analysis layer to which the breaks will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InVrpLayer { get; set; }

		/// <summary>
		/// <para>Target Route Name</para>
		/// <para>The route for the break parameters.  If this parameter is not specified, breaks are created for each existing route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetRoute { get; set; }

		/// <summary>
		/// <para>Break Type</para>
		/// <para>Specifies the type of breaks for the current VRP layer. All breaks must be of the same type.</para>
		/// <para>Time Window Break— Breaks take place during a specific time window. This is the default.</para>
		/// <para>Maximum Travel Time Break— Breaks are taken after a certain amount of travel time. These values are given as the amount of time either until the first break or between breaks.</para>
		/// <para>Maximum Work Time Break— Breaks are taken after a certain amount of cumulative time. These values are always an amount of elapsed time since the start of the route.</para>
		/// <para><see cref="BreakTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BreakType { get; set; } = "TIME_WINDOW_BREAK";

		/// <summary>
		/// <para>Break Properties</para>
		/// <para>Specifies a time range within which the break will begin. To set up a time window break, use two time-of-day values.</para>
		/// <para>The options below are enabled when the Break Type parameter is set to Time Window Break.</para>
		/// <para>Is Paid—A Boolean value indicating whether the break is paid.</para>
		/// <para>Break Duration—The duration of the break. This field can&apos;t contain null values and has a default value of 60.</para>
		/// <para>Time Window Start—The start time of the time window.</para>
		/// <para>Time Window End—The end time of the time window.</para>
		/// <para>Maximum Violation Time—The maximum allowable violation time for a time window break. A time window is considered violated if the arrival time falls outside the time range. A zero value indicates that the time window cannot be violated, that is, the time window is hard. A nonzero value indicates the maximum delay time. For example, the break can begin up to 30 minutes beyond the end of its time window but the delay is penalized pursuant to the Time Window Violation Importance setting, which rates the importance of honoring time windows without causing violations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object TimeWindowProperties { get; set; }

		/// <summary>
		/// <para>Break Properties</para>
		/// <para>Specifies how long a person can drive before the break is required.</para>
		/// <para>The properties below are enabled when the Break Type parameter is set to Maximum Travel Time Break.</para>
		/// <para>Is Paid—A Boolean value indicating whether the break is paid.</para>
		/// <para>Break Duration—The duration of the break. This field can&apos;t contain null values and has a default value of 60.</para>
		/// <para>Maximum Travel Time Between Breaks—The maximum amount of travel time that can be accumulated before the break is taken. The travel time is accumulated either from the end of the previous break or, if a break has not yet been taken, from the start of the route.If this is the route&apos;s final break, The MaxTravelTimeBetweenBreaks field also indicates the maximum travel time that can be accumulated from the final break to the end depot.</para>
		/// <para>This field limits how long a person can drive until a break is required. For example, if the Time Field Units parameter (time_units in Python) of the analysis is set to Minutes, and the MaxTravelTimeBetweenBreaks field has a value of 120, the driver will get a break after two hours of driving. To assign a second break after two additional hours of driving, the second break&apos;s MaxTravelTimeBetweenBreaks field value must be 120.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object TravelTimeProperties { get; set; }

		/// <summary>
		/// <para>Break Properties</para>
		/// <para>Specifies how long a person can work before a break is required.</para>
		/// <para>The properties below are enabled when the Break Type parameter is set to Maximum Work Time Break.</para>
		/// <para>Is Paid—A Boolean value indicating whether the break is paid.</para>
		/// <para>Break Duration—The duration of the break. This field can&apos;t contain null values and has a default value of 60.</para>
		/// <para>Maximum Cumulative Work Time—The maximum amount of work time that can be accumulated before the break is taken. Work time is always accumulated from the beginning of the route. Work time is the sum of travel time and service times at orders, depots, and breaks. However, this excludes wait time, which is the time a route (or driver) spends waiting at an order or depot for a time window to begin.The MaxCumulWorkTime field also indicates the maximum amount of work time that can be accumulated before the break is taken.</para>
		/// <para>This field limits how long a person can work until a break is required. For example, if the Time Field Units parameter (time_units in Python) is set to Minutes, the MaxCumulWorkTime field has a value of 120, and the ServiceTime field has a value of 15, the driver will get a 15-minute break after 2 hours of work.</para>
		/// <para>Continuing with this example, assume a second break is needed after 3 additional hours of work. To specify this break, you would enter 315 (5 hours and 15 minutes) as the second break&apos;s MaxCumulWorkTime field value. This number includes the MaxCumulWorkTime and ServiceTime field values of the preceding break, along with the 3 additional hours of work time before granting the second break. To avoid taking maximum work time breaks prematurely, remember that work time is accumulated from the beginning of the route and it includes the service time at previously visited depots, orders, and breaks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object WorkTimeProperties { get; set; }

		/// <summary>
		/// <para>Append To Existing Breaks</para>
		/// <para>Specifies whether new breaks will be appended to the existing breaks attribute table.</para>
		/// <para>Checked—New breaks will be appended to the existing set in the breaks attribute table. This is the default.</para>
		/// <para>Unchecked—Existing breaks will be replaced with new breaks.</para>
		/// <para><see cref="AppendToExistingBreaksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToExistingBreaks { get; set; } = "true";

		/// <summary>
		/// <para>Output Vehicle Routing Problem Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutVrpLayer { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Break Type</para>
		/// </summary>
		public enum BreakTypeEnum 
		{
			/// <summary>
			/// <para>Time Window Break— Breaks take place during a specific time window. This is the default.</para>
			/// </summary>
			[GPValue("TIME_WINDOW_BREAK")]
			[Description("Time Window Break")]
			Time_Window_Break,

			/// <summary>
			/// <para>Maximum Travel Time Break— Breaks are taken after a certain amount of travel time. These values are given as the amount of time either until the first break or between breaks.</para>
			/// </summary>
			[GPValue("MAXIMUM_TRAVEL_TIME_BREAK")]
			[Description("Maximum Travel Time Break")]
			Maximum_Travel_Time_Break,

			/// <summary>
			/// <para>Maximum Work Time Break— Breaks are taken after a certain amount of cumulative time. These values are always an amount of elapsed time since the start of the route.</para>
			/// </summary>
			[GPValue("MAXIMUM_WORK_TIME_BREAK")]
			[Description("Maximum Work Time Break")]
			Maximum_Work_Time_Break,

		}

		/// <summary>
		/// <para>Append To Existing Breaks</para>
		/// </summary>
		public enum AppendToExistingBreaksEnum 
		{
			/// <summary>
			/// <para>Checked—New breaks will be appended to the existing set in the breaks attribute table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—Existing breaks will be replaced with new breaks.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CLEAR")]
			CLEAR,

		}

#endregion
	}
}
