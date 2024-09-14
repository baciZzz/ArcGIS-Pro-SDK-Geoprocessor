using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>ServerTool 1</para>
	/// <para>ServerTool 1</para>
	/// <para></para>
	/// </summary>
	public class EditVehicleRoutingProblem : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Orders">
		/// <para>Orders</para>
		/// </param>
		/// <param name="Depots">
		/// <para>Depots</para>
		/// </param>
		/// <param name="Routes">
		/// <para>Routes</para>
		/// </param>
		public EditVehicleRoutingProblem(object Orders, object Depots, object Routes)
		{
			this.Orders = Orders;
			this.Depots = Depots;
			this.Routes = Routes;
		}

		/// <summary>
		/// <para>Tool Display Name : ServerTool 1</para>
		/// </summary>
		public override string DisplayName() => "ServerTool 1";

		/// <summary>
		/// <para>Tool Name : EditVehicleRoutingProblem</para>
		/// </summary>
		public override string ToolName() => "EditVehicleRoutingProblem";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.EditVehicleRoutingProblem</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.EditVehicleRoutingProblem";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Orders, Depots, Routes, Breaks!, TimeUnits!, DistanceUnits!, AnalysisRegion!, DefaultDate!, UturnPolicy!, TimeWindowFactor!, SpatiallyClusterRoutes!, RouteZones!, RouteRenewals!, OrderPairs!, ExcessTransitFactor!, PointBarriers!, LineBarriers!, PolygonBarriers!, UseHierarchyInAnalysis!, Restrictions!, AttributeParameterValues!, PopulateRouteLines!, RouteLineSimplificationTolerance!, PopulateDirections!, DirectionsLanguage!, DirectionsStyleName!, TravelMode!, Impedance!, TimeZoneUsageForTimeFields!, SaveOutputLayer!, Overrides!, SaveRouteData!, TimeImpedance!, DistanceImpedance!, PopulateStopShapes!, OutputFormat!, IgnoreInvalidOrderLocations!, OutUnassignedStops!, OutStops!, OutRoutes!, OutDirections!, SolveSucceeded!, OutNetworkAnalysisLayer!, OutRouteData!, OutResultFile!, OutputNetworkAnalysisLayerPackage! };

		/// <summary>
		/// <para>Orders</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Orders { get; set; }

		/// <summary>
		/// <para>Depots</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Depots { get; set; }

		/// <summary>
		/// <para>Routes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		public object Routes { get; set; }

		/// <summary>
		/// <para>Breaks</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		public object? Breaks { get; set; }

		/// <summary>
		/// <para>Time Units</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnits { get; set; } = "Miles";

		/// <summary>
		/// <para>Analysis Region</para>
		/// <para><see cref="AnalysisRegionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? AnalysisRegion { get; set; }

		/// <summary>
		/// <para>Default Date</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object? DefaultDate { get; set; }

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// <para><see cref="UturnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? UturnPolicy { get; set; } = "ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY";

		/// <summary>
		/// <para>Time Window Factor</para>
		/// <para><see cref="TimeWindowFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeWindowFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Spatially Cluster Routes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Advanced Analysis")]
		public object? SpatiallyClusterRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Route Zones</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Advanced Analysis")]
		public object? RouteZones { get; set; }

		/// <summary>
		/// <para>Route Renewals</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object? RouteRenewals { get; set; }

		/// <summary>
		/// <para>Order Pairs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object? OrderPairs { get; set; }

		/// <summary>
		/// <para>Excess Transit Factor</para>
		/// <para><see cref="ExcessTransitFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? ExcessTransitFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Point Barriers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? PointBarriers { get; set; }

		/// <summary>
		/// <para>Line Barriers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? LineBarriers { get; set; }

		/// <summary>
		/// <para>Polygon Barriers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? PolygonBarriers { get; set; }

		/// <summary>
		/// <para>Use Hierarchy</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Custom Travel Mode")]
		public object? UseHierarchyInAnalysis { get; set; } = "true";

		/// <summary>
		/// <para>Restrictions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? Restrictions { get; set; } = "'Avoid Carpool Roads';'Avoid Express Lanes';'Avoid Gates';'Avoid Private Roads';'Avoid Unpaved Roads';'Driving an Automobile';'Roads Under Construction Prohibited';'Through Traffic Prohibited'";

		/// <summary>
		/// <para>Attribute Parameter Values</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Custom Travel Mode")]
		public object? AttributeParameterValues { get; set; }

		/// <summary>
		/// <para>Populate Route Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? PopulateRouteLines { get; set; } = "true";

		/// <summary>
		/// <para>Route Line Simplification Tolerance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Custom Travel Mode")]
		public object? RouteLineSimplificationTolerance { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Populate Directions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? PopulateDirections { get; set; } = "false";

		/// <summary>
		/// <para>Directions Language</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output")]
		public object? DirectionsLanguage { get; set; } = "en";

		/// <summary>
		/// <para>Directions Style Name</para>
		/// <para><see cref="DirectionsStyleNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? DirectionsStyleName { get; set; } = "NA Desktop";

		/// <summary>
		/// <para>Travel Mode</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TravelMode { get; set; } = "Custom";

		/// <summary>
		/// <para>Impedance</para>
		/// <para><see cref="ImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? Impedance { get; set; } = "Drive Time";

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// <para><see cref="TimeZoneUsageForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeZoneUsageForTimeFields { get; set; } = "GEO_LOCAL";

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? SaveOutputLayer { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Analysis")]
		public object? Overrides { get; set; }

		/// <summary>
		/// <para>Save Route Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? SaveRouteData { get; set; } = "false";

		/// <summary>
		/// <para>Time Impedance</para>
		/// <para><see cref="TimeImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? TimeImpedance { get; set; } = "TravelTime";

		/// <summary>
		/// <para>Distance Impedance</para>
		/// <para><see cref="DistanceImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? DistanceImpedance { get; set; } = "Kilometers";

		/// <summary>
		/// <para>Populate Stop Shapes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? PopulateStopShapes { get; set; } = "false";

		/// <summary>
		/// <para>Output Format</para>
		/// <para><see cref="OutputFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? OutputFormat { get; set; } = "Feature Set";

		/// <summary>
		/// <para>Ignore Invalid Order Locations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Network Locations")]
		public object? IgnoreInvalidOrderLocations { get; set; } = "false";

		/// <summary>
		/// <para>Output Unassigned Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutUnassignedStops { get; set; }

		/// <summary>
		/// <para>Output Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutStops { get; set; }

		/// <summary>
		/// <para>Output Routes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutRoutes { get; set; }

		/// <summary>
		/// <para>Output Directions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutDirections { get; set; }

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? SolveSucceeded { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutNetworkAnalysisLayer { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Route Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutRouteData { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Result File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutResultFile { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Network Analysis Layer Package</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputNetworkAnalysisLayerPackage { get; set; } = "scratchfile";

		#region InnerClass

		/// <summary>
		/// <para>Time Units</para>
		/// </summary>
		public enum TimeUnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

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

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

		}

		/// <summary>
		/// <para>Analysis Region</para>
		/// </summary>
		public enum AnalysisRegionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Europe")]
			[Description("Europe")]
			Europe,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Japan")]
			[Description("Japan")]
			Japan,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Korea")]
			[Description("Korea")]
			Korea,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MiddleEastAndAfrica")]
			[Description("MiddleEastAndAfrica")]
			MiddleEastAndAfrica,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NorthAmerica")]
			[Description("NorthAmerica")]
			NorthAmerica,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SouthAmerica")]
			[Description("SouthAmerica")]
			SouthAmerica,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SouthAsia")]
			[Description("SouthAsia")]
			SouthAsia,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Thailand")]
			[Description("Thailand")]
			Thailand,

		}

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// </summary>
		public enum UturnPolicyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ALLOW_UTURNS")]
			[Description("ALLOW_UTURNS")]
			ALLOW_UTURNS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_UTURNS")]
			[Description("NO_UTURNS")]
			NO_UTURNS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_ONLY")]
			[Description("ALLOW_DEAD_ENDS_ONLY")]
			ALLOW_DEAD_ENDS_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			[Description("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY,

		}

		/// <summary>
		/// <para>Time Window Factor</para>
		/// </summary>
		public enum TimeWindowFactorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Excess Transit Factor</para>
		/// </summary>
		public enum ExcessTransitFactorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Directions Style Name</para>
		/// </summary>
		public enum DirectionsStyleNameEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NA Desktop")]
			[Description("NA Desktop")]
			NA_Desktop,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NA Navigation")]
			[Description("NA Navigation")]
			NA_Navigation,

		}

		/// <summary>
		/// <para>Impedance</para>
		/// </summary>
		public enum ImpedanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Drive Time")]
			[Description("Drive Time")]
			Drive_Time,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Truck Time")]
			[Description("Truck Time")]
			Truck_Time,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Walk Time")]
			[Description("Walk Time")]
			Walk_Time,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TravelTime")]
			[Description("TravelTime")]
			TravelTime,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TimeAt1KPH")]
			[Description("TimeAt1KPH")]
			TimeAt1KPH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WalkTime")]
			[Description("WalkTime")]
			WalkTime,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckMinutes")]
			[Description("TruckMinutes")]
			TruckMinutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckTravelTime")]
			[Description("TruckTravelTime")]
			TruckTravelTime,

		}

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// </summary>
		public enum TimeZoneUsageForTimeFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("GEO_LOCAL")]
			[Description("GEO_LOCAL")]
			GEO_LOCAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>Time Impedance</para>
		/// </summary>
		public enum TimeImpedanceEnum 
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
			[GPValue("TravelTime")]
			[Description("TravelTime")]
			TravelTime,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TimeAt1KPH")]
			[Description("TimeAt1KPH")]
			TimeAt1KPH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WalkTime")]
			[Description("WalkTime")]
			WalkTime,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckMinutes")]
			[Description("TruckMinutes")]
			TruckMinutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckTravelTime")]
			[Description("TruckTravelTime")]
			TruckTravelTime,

		}

		/// <summary>
		/// <para>Distance Impedance</para>
		/// </summary>
		public enum DistanceImpedanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

		/// <summary>
		/// <para>Output Format</para>
		/// </summary>
		public enum OutputFormatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feature Set")]
			[Description("Feature Set")]
			Feature_Set,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("JSON File")]
			[Description("JSON File")]
			JSON_File,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("GeoJSON File")]
			[Description("GeoJSON File")]
			GeoJSON_File,

		}

#endregion
	}
}
