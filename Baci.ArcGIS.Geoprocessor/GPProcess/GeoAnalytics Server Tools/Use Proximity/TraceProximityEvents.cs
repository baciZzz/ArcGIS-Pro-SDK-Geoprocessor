using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Trace Proximity Events</para>
	/// <para>Traces events near each other in space (location) and time. The time-enabled point data must include features that represent an instant in time.</para>
	/// </summary>
	public class TraceProximityEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPoints">
		/// <para>Input Points</para>
		/// <para>The time-enabled point feature class that will be used to trace proximity events.</para>
		/// </param>
		/// <param name="EntityIdField">
		/// <para>Entity ID Field</para>
		/// <para>The field representing unique IDs for each entity.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies the distance type that will be used with the Spatial Search Distance parameter.</para>
		/// <para>Planar—Planar distance will be used between features. This is the default.</para>
		/// <para>Geodesic—Geodesic distance will be used between features. This line type takes into account the curvature of the spheroid and correctly deals with data near the dateline and poles.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="SpatialSearchDistance">
		/// <para>Spatial Search Distance</para>
		/// <para>The maximum distance between two points to be considered in proximity. Features within the spatial search distance and temporal search distance criteria are considered to be in proximity of each other.</para>
		/// <para><see cref="SpatialSearchDistanceEnum"/></para>
		/// </param>
		/// <param name="TemporalSearchDistance">
		/// <para>Temporal Search Distance</para>
		/// <para>The maximum duration between two points to be considered in proximity. Features within the temporal search distance and that meet the spatial search distance criteria are considered to be in proximity of each other.</para>
		/// <para><see cref="TemporalSearchDistanceEnum"/></para>
		/// </param>
		/// <param name="EntitiesOfInterestInputType">
		/// <para>Define Entities of Interest Using</para>
		/// <para>Specifies the entities of interest.</para>
		/// <para>Entities of Interest IDs—Entity names and times will be used as the entities of interest. This is the default.</para>
		/// <para>Selected features in a specified entity of interest layer—The selected feature in a specified entity of interest layer will be used as the entities of interest.</para>
		/// <para><see cref="EntitiesOfInterestInputTypeEnum"/></para>
		/// </param>
		public TraceProximityEvents(object InPoints, object EntityIdField, object OutputName, object DistanceMethod, object SpatialSearchDistance, object TemporalSearchDistance, object EntitiesOfInterestInputType)
		{
			this.InPoints = InPoints;
			this.EntityIdField = EntityIdField;
			this.OutputName = OutputName;
			this.DistanceMethod = DistanceMethod;
			this.SpatialSearchDistance = SpatialSearchDistance;
			this.TemporalSearchDistance = TemporalSearchDistance;
			this.EntitiesOfInterestInputType = EntitiesOfInterestInputType;
		}

		/// <summary>
		/// <para>Tool Display Name : Trace Proximity Events</para>
		/// </summary>
		public override string DisplayName => "Trace Proximity Events";

		/// <summary>
		/// <para>Tool Name : TraceProximityEvents</para>
		/// </summary>
		public override string ToolName => "TraceProximityEvents";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.TraceProximityEvents</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.TraceProximityEvents";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPoints, EntityIdField, OutputName, DistanceMethod, SpatialSearchDistance, TemporalSearchDistance, EntitiesOfInterestInputType, EntitiesInterestIds, EntitiesInterestLayer, IncludeTracksLayer, MaxTraceDepth, AttributeMatchCriteria, DataStore, Output, TracksLayer };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The time-enabled point feature class that will be used to trace proximity events.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InPoints { get; set; }

		/// <summary>
		/// <para>Entity ID Field</para>
		/// <para>The field representing unique IDs for each entity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object EntityIdField { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies the distance type that will be used with the Spatial Search Distance parameter.</para>
		/// <para>Planar—Planar distance will be used between features. This is the default.</para>
		/// <para>Geodesic—Geodesic distance will be used between features. This line type takes into account the curvature of the spheroid and correctly deals with data near the dateline and poles.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Spatial Search Distance</para>
		/// <para>The maximum distance between two points to be considered in proximity. Features within the spatial search distance and temporal search distance criteria are considered to be in proximity of each other.</para>
		/// <para><see cref="SpatialSearchDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SpatialSearchDistance { get; set; }

		/// <summary>
		/// <para>Temporal Search Distance</para>
		/// <para>The maximum duration between two points to be considered in proximity. Features within the temporal search distance and that meet the spatial search distance criteria are considered to be in proximity of each other.</para>
		/// <para><see cref="TemporalSearchDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TemporalSearchDistance { get; set; }

		/// <summary>
		/// <para>Define Entities of Interest Using</para>
		/// <para>Specifies the entities of interest.</para>
		/// <para>Entities of Interest IDs—Entity names and times will be used as the entities of interest. This is the default.</para>
		/// <para>Selected features in a specified entity of interest layer—The selected feature in a specified entity of interest layer will be used as the entities of interest.</para>
		/// <para><see cref="EntitiesOfInterestInputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EntitiesOfInterestInputType { get; set; } = "ID_START_TIME";

		/// <summary>
		/// <para>Entities of Interest IDs</para>
		/// <para>The entity names and start times for the entities of interest. This parameter is supported only when Entities of Interest IDs is specified for the Define Entities of Interest Using parameter.</para>
		/// <para>Entity ID—A unique entity name. The names are case sensitive.</para>
		/// <para>Starting From—An optional starting time to trace an entity of interest. If a time is not specified, January 1, 1970, will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object EntitiesInterestIds { get; set; }

		/// <summary>
		/// <para>Entities of Interest Layer</para>
		/// <para>The layer or table that contains the entities of interest. This parameter is supported only when Selected features in a specified entity of interest layer is specified for the Define Entities of Interest Using parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[GPTablesDomain()]
		public object EntitiesInterestLayer { get; set; }

		/// <summary>
		/// <para>Output Tracks</para>
		/// <para>Specifies whether an output layer containing the first trace event and all subsequent features for that specified entity will be generated.</para>
		/// <para>Checked—An output layer containing the first trace event and all subsequent features will be generated.</para>
		/// <para>Unchecked—An output layer containing the first trace event and all subsequent features will not be generated. This is the default.</para>
		/// <para><see cref="IncludeTracksLayerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Outputs")]
		public object IncludeTracksLayer { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Trace Depth</para>
		/// <para>The maximum degrees of separation between an entity of interest and an entity farther down the trace (downstream).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object MaxTraceDepth { get; set; }

		/// <summary>
		/// <para>Attribute Match Criteria</para>
		/// <para>The fields used to constrain the proximity event.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[Category("Advanced Options")]
		public object AttributeMatchCriteria { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Proximity Events</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Output Tracks</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object TracksLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TraceProximityEvents SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Planar—Planar distance will be used between features. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—Geodesic distance will be used between features. This line type takes into account the curvature of the spheroid and correctly deals with data near the dateline and poles.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Spatial Search Distance</para>
		/// </summary>
		public enum SpatialSearchDistanceEnum 
		{
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

		}

		/// <summary>
		/// <para>Temporal Search Distance</para>
		/// </summary>
		public enum TemporalSearchDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

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
		/// <para>Define Entities of Interest Using</para>
		/// </summary>
		public enum EntitiesOfInterestInputTypeEnum 
		{
			/// <summary>
			/// <para>Entities of Interest IDs—Entity names and times will be used as the entities of interest. This is the default.</para>
			/// </summary>
			[GPValue("ID_START_TIME")]
			[Description("Entities of Interest IDs")]
			Entities_of_Interest_IDs,

			/// <summary>
			/// <para>Selected features in a specified entity of interest layer—The selected feature in a specified entity of interest layer will be used as the entities of interest.</para>
			/// </summary>
			[GPValue("SELECTED_FEATURE")]
			[Description("Selected features in a specified entity of interest layer")]
			Selected_features_in_a_specified_entity_of_interest_layer,

		}

		/// <summary>
		/// <para>Output Tracks</para>
		/// </summary>
		public enum IncludeTracksLayerEnum 
		{
			/// <summary>
			/// <para>Checked—An output layer containing the first trace event and all subsequent features will be generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACKS")]
			TRACKS,

			/// <summary>
			/// <para>Unchecked—An output layer containing the first trace event and all subsequent features will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRACKS")]
			NO_TRACKS,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

#endregion
	}
}
