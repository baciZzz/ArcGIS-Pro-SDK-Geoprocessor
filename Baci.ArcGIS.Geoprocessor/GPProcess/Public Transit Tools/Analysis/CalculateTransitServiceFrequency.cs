using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.PublicTransitTools
{
	/// <summary>
	/// <para>Calculate Transit Service Frequency</para>
	/// <para>Calculates the frequency of scheduled public transit service available within one or more specified time windows at public transit stops, along public transit lines, at points of interest, or in areas.</para>
	/// </summary>
	public class CalculateTransitServiceFrequency : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTransitFeatureDataset">
		/// <para>Input Transit Feature Dataset</para>
		/// <para>A feature dataset containing the Stops and LineVariantElements feature classes from the Network Analyst public transit data model. The feature dataset&apos;s parent geodatabase must contain the public transit data model&apos;s LineVariants, Schedules, ScheduleElements, and Runs tables and the Calendars table, the CalendarExceptions table, or both.</para>
		/// <para>A valid feature dataset with its associated feature classes and tables can be created from General Transit Feed Specification (GTFS) public transit data using the GTFS To Public Transit Data Model tool.</para>
		/// </param>
		/// <param name="AnalysisType">
		/// <para>Analysis Type</para>
		/// <para>Specifies the location type for which the tool will calculate the frequency of public transit service.</para>
		/// <para>Transit stops—The frequency of public transit service at public transit stops will be calculated. The output will be a feature class containing a copy of the public transit stops from the input public transit data model Stops feature class.</para>
		/// <para>Transit lines—The frequency of public transit service along public transit lines will be calculated. The output will be a feature class containing a copy of the public transit lines from the input public transit data model&apos;s LineVariantElements feature class.</para>
		/// <para>Points of interest—The frequency of public transit service at specified points of interest will be calculated. The output will be a copy of the input points of interest.</para>
		/// <para>Areas—The frequency of public transit service for all areas within range of all public transit stops will be calculated. The output will be a polygon feature class representing the area served by the public transit system.</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// <para>A shapefile is not a valid value.</para>
		/// </param>
		/// <param name="TimeWindows">
		/// <para>Time Windows</para>
		/// <para>The periods of time for which public transit service frequency will be calculated.</para>
		/// <para>Multiple time windows can be specified. The output feature class will include a set of fields representing the transit frequency statistics for each time window. These fields will be prefixed by the value specified in the Output Field Prefix column.</para>
		/// <para>Time windows can be interpreted either as specific dates or as generic weekdays. The Use Specific Date column determines whether the date component of the Start Datetime column will be interpreted as an exact date or as a generic weekday. For example, if the date component of the Start Datetime value is December 25, 2021, and Use Specific Date is True, the exact date will be used, and the public transit service frequency calculated will include any special service added or removed for the Christmas holiday. If Use Specific Date is False, this date will be interpreted as Saturday, and the public transit service frequency calculated will include regular service for any typical Saturday.</para>
		/// <para>For specific dates, all exceptions to the regular public transit service included in the CalendarExceptions table and the date range defined in the Calendars table will be considered. For a generic weekday, only regular service defined in the weekday fields in the Calendars table will be considered.</para>
		/// <para>Use Specific Date—A Boolean value indicating whether the time window&apos;s date will be interpreted as the exact date specified (True) or the generic weekday represented by the date (False).</para>
		/// <para>Start Datetime—The date and time the time window begins.</para>
		/// <para>Duration (minutes)—The duration of the time window in minutes.</para>
		/// <para>Count Arrivals or Departures—Whether arrivals or departures at public transit stops will be counted when calculating transit frequency statistics.</para>
		/// <para>Arrivals—Count arrivals at public transit stops. The arrival times will be considered in the calculations.</para>
		/// <para>Departures—Count departures from public transit stops. The departure times will be considered in the calculations.</para>
		/// <para>Output Field Prefix—A string prefix that will be included in the names of all output fields associated with this time window. String prefixes must be unique and must contain only characters valid for field names in the output feature class.</para>
		/// </param>
		public CalculateTransitServiceFrequency(object InTransitFeatureDataset, object AnalysisType, object OutFeatureClass, object TimeWindows)
		{
			this.InTransitFeatureDataset = InTransitFeatureDataset;
			this.AnalysisType = AnalysisType;
			this.OutFeatureClass = OutFeatureClass;
			this.TimeWindows = TimeWindows;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Transit Service Frequency</para>
		/// </summary>
		public override string DisplayName => "Calculate Transit Service Frequency";

		/// <summary>
		/// <para>Tool Name : CalculateTransitServiceFrequency</para>
		/// </summary>
		public override string ToolName => "CalculateTransitServiceFrequency";

		/// <summary>
		/// <para>Tool Excute Name : transit.CalculateTransitServiceFrequency</para>
		/// </summary>
		public override string ExcuteName => "transit.CalculateTransitServiceFrequency";

		/// <summary>
		/// <para>Toolbox Display Name : Public Transit Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Public Transit Tools";

		/// <summary>
		/// <para>Toolbox Alise : transit</para>
		/// </summary>
		public override string ToolboxAlise => "transit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTransitFeatureDataset, AnalysisType, OutFeatureClass, TimeWindows, SeparateCountsByLine!, InPointsOfInterest!, NetworkDataSource!, TravelMode!, TravelLimit!, TravelLimitUnits!, CellSize!, Barriers };

		/// <summary>
		/// <para>Input Transit Feature Dataset</para>
		/// <para>A feature dataset containing the Stops and LineVariantElements feature classes from the Network Analyst public transit data model. The feature dataset&apos;s parent geodatabase must contain the public transit data model&apos;s LineVariants, Schedules, ScheduleElements, and Runs tables and the Calendars table, the CalendarExceptions table, or both.</para>
		/// <para>A valid feature dataset with its associated feature classes and tables can be created from General Transit Feed Specification (GTFS) public transit data using the GTFS To Public Transit Data Model tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InTransitFeatureDataset { get; set; }

		/// <summary>
		/// <para>Analysis Type</para>
		/// <para>Specifies the location type for which the tool will calculate the frequency of public transit service.</para>
		/// <para>Transit stops—The frequency of public transit service at public transit stops will be calculated. The output will be a feature class containing a copy of the public transit stops from the input public transit data model Stops feature class.</para>
		/// <para>Transit lines—The frequency of public transit service along public transit lines will be calculated. The output will be a feature class containing a copy of the public transit lines from the input public transit data model&apos;s LineVariantElements feature class.</para>
		/// <para>Points of interest—The frequency of public transit service at specified points of interest will be calculated. The output will be a copy of the input points of interest.</para>
		/// <para>Areas—The frequency of public transit service for all areas within range of all public transit stops will be calculated. The output will be a polygon feature class representing the area served by the public transit system.</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisType { get; set; } = "STOPS";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// <para>A shapefile is not a valid value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Time Windows</para>
		/// <para>The periods of time for which public transit service frequency will be calculated.</para>
		/// <para>Multiple time windows can be specified. The output feature class will include a set of fields representing the transit frequency statistics for each time window. These fields will be prefixed by the value specified in the Output Field Prefix column.</para>
		/// <para>Time windows can be interpreted either as specific dates or as generic weekdays. The Use Specific Date column determines whether the date component of the Start Datetime column will be interpreted as an exact date or as a generic weekday. For example, if the date component of the Start Datetime value is December 25, 2021, and Use Specific Date is True, the exact date will be used, and the public transit service frequency calculated will include any special service added or removed for the Christmas holiday. If Use Specific Date is False, this date will be interpreted as Saturday, and the public transit service frequency calculated will include regular service for any typical Saturday.</para>
		/// <para>For specific dates, all exceptions to the regular public transit service included in the CalendarExceptions table and the date range defined in the Calendars table will be considered. For a generic weekday, only regular service defined in the weekday fields in the Calendars table will be considered.</para>
		/// <para>Use Specific Date—A Boolean value indicating whether the time window&apos;s date will be interpreted as the exact date specified (True) or the generic weekday represented by the date (False).</para>
		/// <para>Start Datetime—The date and time the time window begins.</para>
		/// <para>Duration (minutes)—The duration of the time window in minutes.</para>
		/// <para>Count Arrivals or Departures—Whether arrivals or departures at public transit stops will be counted when calculating transit frequency statistics.</para>
		/// <para>Arrivals—Count arrivals at public transit stops. The arrival times will be considered in the calculations.</para>
		/// <para>Departures—Count departures from public transit stops. The departure times will be considered in the calculations.</para>
		/// <para>Output Field Prefix—A string prefix that will be included in the names of all output fields associated with this time window. String prefixes must be unique and must contain only characters valid for field names in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object TimeWindows { get; set; }

		/// <summary>
		/// <para>Separate Counts By Transit Line</para>
		/// <para>Specifies whether service from multiple transit lines using the same stop or corridor will be separated by transit line or combined when calculating transit frequency statistics.</para>
		/// <para>When separated by transit line, the output will contain a copy of each stop or transit line segment for each unique transit line using the stop or corridor, and these duplicated features will have overlapping geometry.</para>
		/// <para>If the LineVariants table in the input data has the optional GDirectionID field, the output will additionally separate counts by the GDirectionID field value. For example, if a stop serves both direction of travels along the same line, the output will contain a copy of the stop for each direction of travel as defined by the GDirectionID field.</para>
		/// <para>Checked—Multiple transit lines serving the same stop or corridor will be counted separately when calculating transit frequency statistics.</para>
		/// <para>Unchecked—Multiple transit lines serving the same stop or corridor will not be counted separately when calculating transit frequency statistics; they will be combined. This is the default.</para>
		/// <para>This parameter only applies when the Analysis Type parameter is set to Transit stops or Transit lines.</para>
		/// <para><see cref="SeparateCountsByLineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SeparateCountsByLine { get; set; } = "false";

		/// <summary>
		/// <para>Input Points of Interest</para>
		/// <para>The points of interest for which the frequency of available public transit service will be calculated.</para>
		/// <para>If a polygon layer is specified, the public transit service available at the polygon centroids will be used.</para>
		/// <para>This parameter is required when the Analysis Type parameter is set to Points of interest; otherwise, it is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? InPointsOfInterest { get; set; }

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service that will be used to determine the public transit stops within range of the designated points of interest or to calculate the polygon areas within range of public transit stops. You can use a catalog path to a network dataset, a network dataset layer object, the string name of the network dataset layer, or a portal URL for a network analysis service. The network must have at least one travel mode.</para>
		/// <para>To use a portal URL, you must be signed in to the portal with an account that has routing privileges.</para>
		/// <para>Running the tool will consume credits if you use ArcGIS Online as the network data source.</para>
		/// <para>Use a network dataset appropriate for modeling passengers traveling to and from public transit stops. Don&apos;t use a network dataset configured to use public transit data with the Public Transit evaluator because this type of network models passengers riding public transit, not people traveling to and from the public transit stops.</para>
		/// <para>This parameter is required when the Analysis Type parameter is set to Points of interest or Areas; otherwise, it is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDataSource()]
		public object? NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The travel mode on the network data source that will be used to determine the public transit stops within range of the designated points of interest or to calculate the polygon areas within range of public transit stops. You can specify the travel mode as a string name of the travel mode or as an arcpy.nax.TravelMode object.</para>
		/// <para>Use the travel mode most appropriate for modeling passengers traveling to and from public transit stops. Typically, a travel mode that models walking time or distance should be used.</para>
		/// <para>Do not use a travel mode with an impedance attribute that uses the Public Transit evaluator because that travel mode models passengers riding public transit, not passengers traveling to and from the public transit stops.</para>
		/// <para>This parameter is required when the Analysis Type parameter is set to Points of interest or Areas; otherwise, it is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NetworkTravelMode()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Maximum travel time or distance to stops</para>
		/// <para>The impedance limit that will be used when finding the public transit stops within range of points of interest or when calculating the area reachable from public transit stops.</para>
		/// <para>This parameter should be specified in the units designated in the Units of maximum travel time or distance to stops parameter.</para>
		/// <para>This parameter is required when the Analysis Type parameter is set to Points of interest or Areas; otherwise, it is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? TravelLimit { get; set; }

		/// <summary>
		/// <para>Units of travel time or distance to stops</para>
		/// <para>Specifies the units that will be used for the impedance limit specified in the Maximum travel time or distance to stops parameter.</para>
		/// <para>The available units depend on the value specified in the Travel Mode parameter. If the travel mode&apos;s impedance has units of time, only time-based units will be available. If the travel mode&apos;s impedance has units of distance, only distance-based units will available. If the travel mode&apos;s impedance units are neither time based nor distance based, the only option available will be unknown units, and the Maximum travel time or distance to stops parameter value will be in the units of the travel mode&apos;s impedance.</para>
		/// <para>Kilometers—The impedance limit will be specified in kilometers.</para>
		/// <para>Meters—The impedance limit will be specified in meters.</para>
		/// <para>Miles—The impedance limit will be specified in miles.</para>
		/// <para>Yards—The impedance limit will be specified in yards.</para>
		/// <para>Feet—The impedance limit will be specified in feet.</para>
		/// <para>Nautical Miles—The impedance limit will be specified in nautical miles.</para>
		/// <para>Days—The impedance limit will be specified in days.</para>
		/// <para>Hours—The impedance limit will be specified in hours.</para>
		/// <para>Minutes—The impedance limit will be specified in minutes.</para>
		/// <para>Seconds—The impedance limit will be specified in seconds.</para>
		/// <para>Travel mode&apos;s impedance units—The impedance limit will be specified in the impedance unit of the selected travel mode.</para>
		/// <para>This parameter is required when the Analysis Type parameter is set to Points of interest or Areas; otherwise, it is ignored.</para>
		/// <para>It is recommended that you use a distance-based travel limit when calculating public transit service frequency for points of interest. With a distance-based limit, the tool can reduce the OD cost matrix size in advance using a simple straight-line distance selection. This may eliminate some origins and destinations from the OD cost matrix analysis and improve performance. If the network data source is a service that charges credits, this optimization also reduces the number of credits needed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelLimitUnits { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The size (edge length) of cells that will be used to represent the area reachable from transit stops in the tool output. The numerical value and the units are set using this parameter.</para>
		/// <para>When calculating the area reachable from public transit stops, a service area is calculated. The resulting service area polygons, which often overlap, are simplified into a raster-like polygon feature class composed of square cells of the size specified in this parameter. The public transit service frequency statistics are calculated for each of these cells based on the public transit stops whose service area polygons overlap the cell centroid.</para>
		/// <para>Use a cell size relevant to how pedestrians travel in the real world. For example, you can base the cell size on the size of city blocks or parcels or the distance a pedestrian can walk in less than a minute. Smaller cells are more accurate but take longer to process.</para>
		/// <para>The default is 80 meters.</para>
		/// <para>This parameter is required when the Analysis Type parameter is set to Areas; otherwise, it is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? CellSize { get; set; } = "80 Meters";

		/// <summary>
		/// <para>Barriers</para>
		/// <para>The point, line, or polygon features that will be used as barriers in the network analysis when calculating the public transit stops within range of the designated points of interest or when calculating the polygon areas within range of public transit stops.</para>
		/// <para>This parameter is relevant only when the Analysis Type parameter is set to Points of interest or Areas; otherwise, it is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Barriers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Analysis Type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>Transit stops—The frequency of public transit service at public transit stops will be calculated. The output will be a feature class containing a copy of the public transit stops from the input public transit data model Stops feature class.</para>
			/// </summary>
			[GPValue("STOPS")]
			[Description("Transit stops")]
			Transit_stops,

			/// <summary>
			/// <para>Transit lines—The frequency of public transit service along public transit lines will be calculated. The output will be a feature class containing a copy of the public transit lines from the input public transit data model&apos;s LineVariantElements feature class.</para>
			/// </summary>
			[GPValue("LINES")]
			[Description("Transit lines")]
			Transit_lines,

			/// <summary>
			/// <para>Points of interest—The frequency of public transit service at specified points of interest will be calculated. The output will be a copy of the input points of interest.</para>
			/// </summary>
			[GPValue("POINTS_OF_INTEREST")]
			[Description("Points of interest")]
			Points_of_interest,

			/// <summary>
			/// <para>Areas—The frequency of public transit service for all areas within range of all public transit stops will be calculated. The output will be a polygon feature class representing the area served by the public transit system.</para>
			/// </summary>
			[GPValue("AREAS")]
			[Description("Areas")]
			Areas,

		}

		/// <summary>
		/// <para>Separate Counts By Transit Line</para>
		/// </summary>
		public enum SeparateCountsByLineEnum 
		{
			/// <summary>
			/// <para>Checked—Multiple transit lines serving the same stop or corridor will be counted separately when calculating transit frequency statistics.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SEPARATE")]
			SEPARATE,

			/// <summary>
			/// <para>Unchecked—Multiple transit lines serving the same stop or corridor will not be counted separately when calculating transit frequency statistics; they will be combined. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SEPARATE")]
			NO_SEPARATE,

		}

#endregion
	}
}
