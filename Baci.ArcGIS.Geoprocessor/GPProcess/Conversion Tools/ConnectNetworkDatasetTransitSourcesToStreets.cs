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
	/// <para>Connect Network Dataset Transit Sources To Streets</para>
	/// <para>Connect Network Dataset Transit Sources To Streets</para>
	/// <para>Connects transit stops to street features for use in a transit-enabled network dataset. This tool creates the StopsOnStreets and StopConnectors feature classes defined by the Network Analyst public transit data model and is intended to be run as part of a larger workflow for creating a transit-network dataset described in Create and use a network dataset with public transit data.</para>
	/// </summary>
	[Obsolete()]
	public class ConnectNetworkDatasetTransitSourcesToStreets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetFeatureDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset where the transit-enabled network dataset will be created. This feature dataset must already exist and contain a point feature class called Stops with the schema described by the Network Analyst public transit data model. A valid Stops feature class can be created with the GTFS To Network Dataset Transit Sources tool.</para>
		/// <para>The Stops feature class may be altered after running the tool. Stop features with a GStopType value of 2, representing station entrances, may be deleted. These stop features will instead be included in the output StopsOnStreets feature class to model correct connections from the streets, through the station entrances, and to the stops. Parent stations that are spatially coincident with stops may also be deleted.</para>
		/// </param>
		/// <param name="InStreetsFeatures">
		/// <para>Input Streets Features</para>
		/// <para>A polyline feature class of streets to which transit stops and lines will connect. This streets feature class should be the same feature class you intend to use in your transit-enabled network dataset for modeling pedestrians walking along streets. The feature class does not need to be in the target feature dataset to run this tool; however, the feature class must be in the target feature dataset at the time you create the network dataset.</para>
		/// <para>The input streets features will be altered after running the tool. Vertices will be added at the locations where StopsOnStreets features intersect the streets. If you do not want your street data altered, make a copy of it before running this tool.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The search distance for snapping transit stops to the input street features. Stops that are outside the search distance will not be snapped and will not be connected to the streets. A small search distance will ensure that stops do not snap to streets that are far away, but it increases the likelihood of stops failing to snap when they should. A large search distance increases the number of stops likely to snap but may lead to errors that should instead be corrected by editing the street data. If no street features are found within the search distance of a particular stop, the output StopsOnStreets feature will not be snapped to a street and will be coincident with its corresponding feature in Stops, which could lead to poor connectivity in the network dataset at that location.</para>
		/// <para>The default is 100 meters.</para>
		/// </param>
		public ConnectNetworkDatasetTransitSourcesToStreets(object TargetFeatureDataset, object InStreetsFeatures, object SearchDistance)
		{
			this.TargetFeatureDataset = TargetFeatureDataset;
			this.InStreetsFeatures = InStreetsFeatures;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Connect Network Dataset Transit Sources To Streets</para>
		/// </summary>
		public override string DisplayName() => "Connect Network Dataset Transit Sources To Streets";

		/// <summary>
		/// <para>Tool Name : ConnectNetworkDatasetTransitSourcesToStreets</para>
		/// </summary>
		public override string ToolName() => "ConnectNetworkDatasetTransitSourcesToStreets";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ConnectNetworkDatasetTransitSourcesToStreets</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ConnectNetworkDatasetTransitSourcesToStreets";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetFeatureDataset, InStreetsFeatures, SearchDistance, Expression!, UpdatedTargetFeatureDataset!, UpdatedInStreetsFeatures!, UpdatedInStops!, OutputStopsOnStreets!, OutputStopConnectors! };

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset where the transit-enabled network dataset will be created. This feature dataset must already exist and contain a point feature class called Stops with the schema described by the Network Analyst public transit data model. A valid Stops feature class can be created with the GTFS To Network Dataset Transit Sources tool.</para>
		/// <para>The Stops feature class may be altered after running the tool. Stop features with a GStopType value of 2, representing station entrances, may be deleted. These stop features will instead be included in the output StopsOnStreets feature class to model correct connections from the streets, through the station entrances, and to the stops. Parent stations that are spatially coincident with stops may also be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Input Streets Features</para>
		/// <para>A polyline feature class of streets to which transit stops and lines will connect. This streets feature class should be the same feature class you intend to use in your transit-enabled network dataset for modeling pedestrians walking along streets. The feature class does not need to be in the target feature dataset to run this tool; however, the feature class must be in the target feature dataset at the time you create the network dataset.</para>
		/// <para>The input streets features will be altered after running the tool. Vertices will be added at the locations where StopsOnStreets features intersect the streets. If you do not want your street data altered, make a copy of it before running this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InStreetsFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The search distance for snapping transit stops to the input street features. Stops that are outside the search distance will not be snapped and will not be connected to the streets. A small search distance will ensure that stops do not snap to streets that are far away, but it increases the likelihood of stops failing to snap when they should. A large search distance increases the number of stops likely to snap but may lead to errors that should instead be corrected by editing the street data. If no street features are found within the search distance of a particular stop, the output StopsOnStreets feature will not be snapped to a street and will be coincident with its corresponding feature in Stops, which could lead to poor connectivity in the network dataset at that location.</para>
		/// <para>The default is 100 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of input street feature records. Transit stops will be snapped only to street features matching this expression. For example, the expression can be used to prevent stops from snapping to streets where pedestrian travel is prohibited.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Updated Target Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? UpdatedTargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Updated Input Streets Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedInStreetsFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedInStops { get; set; }

		/// <summary>
		/// <para>Output Stops On Streets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutputStopsOnStreets { get; set; }

		/// <summary>
		/// <para>Output Stop Connectors</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutputStopConnectors { get; set; }

	}
}
