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
	/// <para>Make OD Cost Matrix Analysis Layer</para>
	/// <para>Make OD Cost Matrix Analysis Layer</para>
	/// <para>Makes an origin destination (OD) cost matrix network analysis layer and sets its analysis properties. An OD cost matrix analysis layer is useful for representing a matrix of costs going from a set of origin locations to a set of destination locations. The layer can be created using a local network dataset or a service hosted online or in a portal.</para>
	/// </summary>
	public class MakeODCostMatrixAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </param>
		public MakeODCostMatrixAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Make OD Cost Matrix Analysis Layer</para>
		/// </summary>
		public override string DisplayName() => "Make OD Cost Matrix Analysis Layer";

		/// <summary>
		/// <para>Tool Name : MakeODCostMatrixAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeODCostMatrixAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeODCostMatrixAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeODCostMatrixAnalysisLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName!, TravelMode!, Cutoff!, NumberOfDestinationsToFind!, TimeOfDay!, TimeZone!, LineShape!, AccumulateAttributes!, OutNetworkAnalysisLayer!, IgnoreInvalidLocations! };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>The name of the network analysis layer to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The name of the travel mode to use in the analysis. The travel mode represents a collection of network settings, such as travel restrictions and U-turn policies, that determine how a pedestrian, car, truck, or other medium of transportation moves through the network. Travel modes are defined on your network data source.</para>
		/// <para>An arcpy.na.TravelMode object and a string containing the valid JSON representation of a travel mode can also be used as input to the parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for destinations for a given origin. This value will be in the units of the impedance attribute used by your chosen travel mode. No destinations beyond this limit will be found. This cutoff value can be overridden on a per-origin basis by specifying individual cutoff values in the origins sublayer. By default, no cutoff is used for the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Cutoff { get; set; }

		/// <summary>
		/// <para>Number of Destinations to Find</para>
		/// <para>The number of destinations to find per origin. This default can be overridden by specifying an individual value for the TargetDestinationCount property in the origins sublayer. By default, no limit is used, and all destinations are found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfDestinationsToFind { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The departure time from origins.</para>
		/// <para>If you have chosen a traffic-based impedance attribute, the solution will be generated given dynamic traffic conditions at the time of day specified here. A date and time can be specified as 5/14/2012 10:30 AM.</para>
		/// <para>Instead of using a particular date, a day of the week can be specified using the following dates:</para>
		/// <para>Today—12/30/1899</para>
		/// <para>Sunday—12/31/1899</para>
		/// <para>Monday—1/1/1900</para>
		/// <para>Tuesday—1/2/1900</para>
		/// <para>Wednesday—1/3/1900</para>
		/// <para>Thursday—1/4/1900</para>
		/// <para>Friday—1/5/1900</para>
		/// <para>Saturday—1/6/1900</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Time of Day")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>The time zone of the Time of Day parameter.</para>
		/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the origins are located. This is the default.</para>
		/// <para>UTC—The Time of Day parameter refers to Coordinated Universal Time (UTC). Choose this option if you want to calculate your OD cost matrix for a specific time, such as now, but aren&apos;t certain in which time zone the origins will be located.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object? TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>Specifies the output line shape.</para>
		/// <para>No lines—No shape will be generated for the output origin-destination route pair. This is useful when you have a large number of origins and destinations and are interested only in the impedance costs in the OD cost matrix table, not in visualizing your OD cost matrix in a map.</para>
		/// <para>Straight lines—The output route shape will be a single straight line between each of the origin-destination pairs. This is the default.</para>
		/// <para>Regardless of the output shape type specified, the best route is always determined by the network impedance, never Euclidean distance. This means that only the route shapes are different, not the underlying traversal of the network.</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object? LineShape { get; set; } = "STRAIGHT_LINES";

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>A list of cost attributes to be accumulated during analysis. These accumulated attributes are for reference only; the solver only uses the cost attribute used by the designated travel mode when solving the analysis.</para>
		/// <para>For each cost attribute that is accumulated, a Total_[Impedance] property is populated in the network analysis output features.</para>
		/// <para>This parameter is not available if the network data source is an ArcGIS Online service or the network data source is a service on a version of Portal for ArcGIS that does not support accumulation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulate Attributes")]
		public object? AccumulateAttributes { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// <para>Specifies whether invalid input locations will be ignored. Typically, locations are invalid if they cannot be located on the network. When invalid locations are ignored, the solver will skip them and attempt to perform the analysis using the remaining locations.</para>
		/// <para>Checked—Invalid input locations will be ignored and only valid locations will be used. This is the default.</para>
		/// <para>Unchecked—All input locations will be used. Invalid locations will cause the analysis to fail.</para>
		/// <para><see cref="IgnoreInvalidLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeODCostMatrixAnalysisLayer SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—The Time of Day parameter refers to Coordinated Universal Time (UTC). Choose this option if you want to calculate your OD cost matrix for a specific time, such as now, but aren&apos;t certain in which time zone the origins will be located.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the origins are located. This is the default.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Line Shape</para>
		/// </summary>
		public enum LineShapeEnum 
		{
			/// <summary>
			/// <para>No lines—No shape will be generated for the output origin-destination route pair. This is useful when you have a large number of origins and destinations and are interested only in the impedance costs in the OD cost matrix table, not in visualizing your OD cost matrix in a map.</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("No lines")]
			No_lines,

			/// <summary>
			/// <para>Straight lines—The output route shape will be a single straight line between each of the origin-destination pairs. This is the default.</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("Straight lines")]
			Straight_lines,

		}

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// </summary>
		public enum IgnoreInvalidLocationsEnum 
		{
			/// <summary>
			/// <para>Checked—Invalid input locations will be ignored and only valid locations will be used. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para>Unchecked—All input locations will be used. Invalid locations will cause the analysis to fail.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

#endregion
	}
}
