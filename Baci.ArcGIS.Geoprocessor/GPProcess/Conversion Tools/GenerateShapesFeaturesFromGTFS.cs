using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Generate Shapes Features From GTFS</para>
	/// <para>Generates an estimate of the paths traveled by the vehicles in a public transit system. The output from this tool can be used to generate a new shapes.txt file for a GTFS public transit dataset.</para>
	/// </summary>
	[Obsolete()]
	public class GenerateShapesFeaturesFromGTFS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsFolder">
		/// <para>Input GTFS Folder</para>
		/// <para>A folder containing a valid GTFS dataset for which you want to create a new shapes.txt file. The folder must contain the GTFS stops.txt, trips.txt, routes.txt, and stop_times.txt files.</para>
		/// </param>
		/// <param name="OutShapeLines">
		/// <para>Output Transit Shape Lines</para>
		/// <para>A line feature class representing the estimated route shapes calculated by this tool. Each line in the output represents a unique shape required for this GTFS dataset. You can edit the line geometry and use this feature class as input to the Features To GTFS Shapes tool.</para>
		/// </param>
		/// <param name="OutShapeStops">
		/// <para>Output Shape Stops</para>
		/// <para>A point feature class of GTFS transit stops with an ID associating them with each shape line to be created by the tool. In cases where the same GTFS stop is visited by multiple shapes, this feature class will contain multiple copies of that stop, one for each shape with which it is associated. This feature class is useful with definition queries when editing one shape line at a time. Use this feature class as input to the Features To GTFS Shapes tool.</para>
		/// <para>This output feature class is not equivalent to the output of the GTFS Stops To Features tool. That tool produces a feature class of the GTFS stops exactly as they are in the original dataset; this tool may produce multiple copies of each stop to associate them with different shapes. Use this output feature class in conjunction with the other outputs of the Generate Shapes Features From GTFS tool to create a shapes.txt file.</para>
		/// </param>
		/// <param name="OutGtfsTrips">
		/// <para>Output GTFS Trips</para>
		/// <para>The output GTFS trips.txt file. This file will be equivalent to the trips.txt file in the input GTFS folder but will include the shape_id field added and populated with values corresponding to the shape_id field in the Output Transit Shape Lines feature class.</para>
		/// </param>
		public GenerateShapesFeaturesFromGTFS(object InGtfsFolder, object OutShapeLines, object OutShapeStops, object OutGtfsTrips)
		{
			this.InGtfsFolder = InGtfsFolder;
			this.OutShapeLines = OutShapeLines;
			this.OutShapeStops = OutShapeStops;
			this.OutGtfsTrips = OutGtfsTrips;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Shapes Features From GTFS</para>
		/// </summary>
		public override string DisplayName => "Generate Shapes Features From GTFS";

		/// <summary>
		/// <para>Tool Name : GenerateShapesFeaturesFromGTFS</para>
		/// </summary>
		public override string ToolName => "GenerateShapesFeaturesFromGTFS";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GenerateShapesFeaturesFromGTFS</para>
		/// </summary>
		public override string ExcuteName => "conversion.GenerateShapesFeaturesFromGTFS";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InGtfsFolder, OutShapeLines, OutShapeStops, OutGtfsTrips, NetworkModes!, NetworkDataSource!, TravelMode!, DriveSide!, BearingTolerance!, MaxBearingAngle };

		/// <summary>
		/// <para>Input GTFS Folder</para>
		/// <para>A folder containing a valid GTFS dataset for which you want to create a new shapes.txt file. The folder must contain the GTFS stops.txt, trips.txt, routes.txt, and stop_times.txt files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InGtfsFolder { get; set; }

		/// <summary>
		/// <para>Output Transit Shape Lines</para>
		/// <para>A line feature class representing the estimated route shapes calculated by this tool. Each line in the output represents a unique shape required for this GTFS dataset. You can edit the line geometry and use this feature class as input to the Features To GTFS Shapes tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutShapeLines { get; set; }

		/// <summary>
		/// <para>Output Shape Stops</para>
		/// <para>A point feature class of GTFS transit stops with an ID associating them with each shape line to be created by the tool. In cases where the same GTFS stop is visited by multiple shapes, this feature class will contain multiple copies of that stop, one for each shape with which it is associated. This feature class is useful with definition queries when editing one shape line at a time. Use this feature class as input to the Features To GTFS Shapes tool.</para>
		/// <para>This output feature class is not equivalent to the output of the GTFS Stops To Features tool. That tool produces a feature class of the GTFS stops exactly as they are in the original dataset; this tool may produce multiple copies of each stop to associate them with different shapes. Use this output feature class in conjunction with the other outputs of the Generate Shapes Features From GTFS tool to create a shapes.txt file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutShapeStops { get; set; }

		/// <summary>
		/// <para>Output GTFS Trips</para>
		/// <para>The output GTFS trips.txt file. This file will be equivalent to the trips.txt file in the input GTFS folder but will include the shape_id field added and populated with values corresponding to the shape_id field in the Output Transit Shape Lines feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutGtfsTrips { get; set; }

		/// <summary>
		/// <para>Transit Modes for Network</para>
		/// <para>Specifies the modes of transit for which line shapes will be generated along the road network rather than with straight lines. Shapes for all modes not selected will be generated using straight lines.</para>
		/// <para>You should typically select modes that run on streets, such as buses, since those modes are most accurately represented by the road network. Do not select modes that are not modeled by your road network. For example, unless your network explicitly models ferry lanes, don&apos;t use the network to represent the paths traveled by ferries.</para>
		/// <para>The modes are specified using the codes in the table below. These correspond to the valid GTFS routes.txt file&apos;s route_type field values from the GTFS documentation.</para>
		/// <para>Modes 3, 5, and 11 are used by default.</para>
		/// <para>Tram, streetcar, light rail (GTFS 0)— Tram, streetcar, light rail. This mode corresponds to GTFS route_type 0.</para>
		/// <para>Subway, metro (GTFS 1)— Subway or metro. This mode corresponds to GTFS route_type 1.</para>
		/// <para>Rail (GTFS 2)— Rail. This mode corresponds to GTFS route_type 2.</para>
		/// <para>Bus (GTFS 3)— Bus. This mode corresponds to GTFS route_type 3.</para>
		/// <para>Ferry (GTFS 4)— Ferry. This mode corresponds to GTFS route_type 4.</para>
		/// <para>Cable tram (GTFS 5)— Cable tram. This mode corresponds to GTFS route_type 5.</para>
		/// <para>Aerial lift, suspended cable car, gondola lift, aerial tramway (GTFS 6)— Aerial lift, suspended cable car, gondola lift, aerial tramway. This mode corresponds to GTFS route_type 6.</para>
		/// <para>Funicular (GTFS 7)— Funicular. This mode corresponds to GTFS route_type 7.</para>
		/// <para>Trolleybus (GTFS 11)— Trolleybus. This mode corresponds to GTFS route_type 11.</para>
		/// <para>Monorail (GTFS 12)— Monorail. This mode corresponds to GTFS route_type 12.</para>
		/// <para>Other transit mode—This option corresponds to any mode of public transit not encompassed by the other options.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? NetworkModes { get; set; } = "3;5;11";

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service that will be used for calculating route shapes along a road network. You can use a catalog path to a network dataset, a network dataset layer object, the string name of the network dataset layer, or a portal URL for a network analysis service. The network must have at least one travel mode.</para>
		/// <para>To use a portal URL, you must be signed in to the portal with an account that has routing privileges.</para>
		/// <para>Running the tool will consume credits if you use ArcGIS Online as the network data source.</para>
		/// <para>This parameter is required when any network modes are selected.</para>
		/// <para>The network dataset you choose should be appropriate for modeling transit vehicles, such as buses, driving on streets. Don&apos;t use a network dataset configured to use public transit data with the Public Transit evaluator because this type of network models passengers riding on public transit, not public transit vehicles driving on streets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDataSource()]
		[Category("Network options")]
		public object? NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The travel mode on the network data source that will be used when calculating route shapes along a road network. You can specify the travel mode as a string name of the travel mode or as an arcpy.nax.TravelMode object.</para>
		/// <para>Use the travel mode most appropriate for modeling vehicles in your transit system driving along the road network.</para>
		/// <para>This parameter is required when any network modes are selected.</para>
		/// <para>Do not use a travel mode with an impedance attribute that uses the Public Transit evaluator because that travel mode models passengers riding on public transit, not transit vehicles driving on streets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NetworkTravelMode()]
		[Category("Network options")]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Side of Road on which Vehicles Drive</para>
		/// <para>Specifies the side of the road on which vehicles drive in your transit system. This is used to ensure that stops are visited on the correct side of the road.</para>
		/// <para>Left—Vehicles drive on the left side of the road.</para>
		/// <para>Right—Vehicles drive on the right side of the road. This is the default.</para>
		/// <para><see cref="DriveSideEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network options")]
		public object? DriveSide { get; set; } = "RIGHT";

		/// <summary>
		/// <para>Bearing Tolerance</para>
		/// <para>The maximum allowed angle between a transit vehicle&apos;s estimated direction of travel at a stop and the angle of the network edge where the stop could locate. If the angles differ by more than this value, it is assumed that this is not the correct network edge on which to locate the stop, and Network Analyst will continue searching other nearby network edges for a more appropriate edge.</para>
		/// <para>When calculating route shapes along a road network, bearing and bearing tolerance are used to more accurately locate transit stops along the road network. The transit vehicle&apos;s bearing is estimated at each stop based on the angles between the current stop and the previous and next stops along the transit route.</para>
		/// <para>Specify the value in units of degrees between 0 and 180. The default is 30.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		[Category("Network options")]
		public object? BearingTolerance { get; set; } = "30";

		/// <summary>
		/// <para>Maximum Bearing Angle Difference</para>
		/// <para>The maximum allowable difference in bearing angle between the previous stop and the current stop and the current stop to the next stop.</para>
		/// <para>The transit vehicle&apos;s bearing is estimated at each stop based on the angles between the current stop and the previous and next stops along the transit route. When the transit route follows a relatively straight road, this angle is a good representation of the bearing. However, if the route goes around a corner, makes a U-turn, follows a twisty road, or diverts into a parking lot or side road, the average angle is not a good estimate of bearing and using this estimate can cause the stop to locate on the network far away from where it should and worsen the quality of the tool output.</para>
		/// <para>The tool will ignore the bearing estimate if the difference in angle from the previous stop to the current stop and the current stop to the next stop is greater than the value specified in this parameter. In this situation, the stop will revert to the normal network locating behavior and will snap to the closest nonrestricted network edge.</para>
		/// <para>Specify the value in units of degrees between 0 and 180. The default is 65.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		[Category("Network options")]
		public object? MaxBearingAngle { get; set; } = "65";

		#region InnerClass

		/// <summary>
		/// <para>Side of Road on which Vehicles Drive</para>
		/// </summary>
		public enum DriveSideEnum 
		{
			/// <summary>
			/// <para>Left—Vehicles drive on the left side of the road.</para>
			/// </summary>
			[GPValue("LEFT")]
			[Description("Left")]
			Left,

			/// <summary>
			/// <para>Right—Vehicles drive on the right side of the road. This is the default.</para>
			/// </summary>
			[GPValue("RIGHT")]
			[Description("Right")]
			Right,

		}

#endregion
	}
}
