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
	/// <para>Calculate Locations</para>
	/// <para>Locates input features on a network and adds fields describing these network locations  to the input features. The tool is used to store the network location information as feature attributes to quickly load the features as inputs for a network analysis.</para>
	/// </summary>
	public class CalculateLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Features</para>
		/// <para>The input features for which the network locations will be calculated.</para>
		/// <para>For line and polygon features, since the network location information is stored in a BLOB field (specified in the Location Ranges Field parameter), only geodatabase feature classes are supported.</para>
		/// </param>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset that will be used to calculate the locations.</para>
		/// <para>If a sublayer of a network analysis layer is used as input features, the parameter is automatically set to the network dataset referenced by the network analysis layer.</para>
		/// </param>
		public CalculateLocations(object InPointFeatures, object InNetworkDataset)
		{
			this.InPointFeatures = InPointFeatures;
			this.InNetworkDataset = InNetworkDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Locations</para>
		/// </summary>
		public override string DisplayName => "Calculate Locations";

		/// <summary>
		/// <para>Tool Name : CalculateLocations</para>
		/// </summary>
		public override string ToolName => "CalculateLocations";

		/// <summary>
		/// <para>Tool Excute Name : na.CalculateLocations</para>
		/// </summary>
		public override string ExcuteName => "na.CalculateLocations";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPointFeatures, InNetworkDataset, SearchTolerance, SearchCriteria, MatchType, SourceIDField, SourceOIDField, PositionField, SideField, SnapXField, SnapYField, DistanceField, SnapZField, LocationField, ExcludeRestrictedElements, SearchQuery, OutPointFeatureClass, TravelMode };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features for which the network locations will be calculated.</para>
		/// <para>For line and polygon features, since the network location information is stored in a BLOB field (specified in the Location Ranges Field parameter), only geodatabase feature classes are supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset that will be used to calculate the locations.</para>
		/// <para>If a sublayer of a network analysis layer is used as input features, the parameter is automatically set to the network dataset referenced by the network analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The search tolerance that will be used to locate the input features on the network. Features that are outside the search tolerance are left unlocated. The parameter includes a value and units for the tolerance.</para>
		/// <para>The default is 5000 meters.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object SearchTolerance { get; set; } = "5000 Meters";

		/// <summary>
		/// <para>Search Criteria</para>
		/// <para>The sources in the network dataset that will be searched when calculating network locations and the portions of geometry (also known as snap types) that will be used. For example, if the network dataset references separate feature classes representing streets and sidewalks, you can choose to locate inputs on streets but not on sidewalks.</para>
		/// <para>The following are the available snap type choices for each network source:</para>
		/// <para>SHAPE—The point will locate on the closest point of an element in this network source.</para>
		/// <para>MIDDLE—The point will locate on the closest midpoint of an element in this network source.</para>
		/// <para>END—The point will locate on the closest endpoint of an element in this network source.</para>
		/// <para>NONE—The point will not locate on elements in this network source.</para>
		/// <para>The MIDDLE and END options are maintained for backward compatibility. Use the SHAPE option to locate your inputs on a particular network source; otherwise, use NONE.</para>
		/// <para>When calculating locations for line or polygon features, only the SHAPE snap type is used, even if other snap types are specified.</para>
		/// <para>The default value is SHAPE for all network sources except override junctions created by running the Dissolve Network tool and system junctions, which have a default of NONE.</para>
		/// <para>This parameter is not used when the network data source is a portal service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object SearchCriteria { get; set; }

		/// <summary>
		/// <para>Find Closest among All Classes</para>
		/// <para>This parameter is only available via Python.</para>
		/// <para><see cref="MatchTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MatchType { get; set; } = "true";

		/// <summary>
		/// <para>Source ID Field</para>
		/// <para>The name of the field to be created or updated with the source ID of the computed network location. A field named SourceID will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object SourceIDField { get; set; }

		/// <summary>
		/// <para>Source OID Field</para>
		/// <para>The name of the field to be created or updated with the source OID of the computed network location. A field named SourceOID will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object SourceOIDField { get; set; }

		/// <summary>
		/// <para>Percent Along Field</para>
		/// <para>The name of the field to be created or updated with the percent along with the computed network location. A field named PosAlong will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object PositionField { get; set; }

		/// <summary>
		/// <para>Side of Edge Field</para>
		/// <para>The name of the field to be created or updated with the side of edge on which the point feature is located on the computed network location. A field named SideOfEdge will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object SideField { get; set; }

		/// <summary>
		/// <para>Located X-Coordinate Field</para>
		/// <para>The name of the field to be created or updated with the x-coordinate of the computed network location. A field named SnapX will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object SnapXField { get; set; }

		/// <summary>
		/// <para>Located Y-Coordinate Field</para>
		/// <para>The name of the field to be created or updated with the y-coordinate of the computed network location. A field named SnapY will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object SnapYField { get; set; }

		/// <summary>
		/// <para>Distance from Feature Field</para>
		/// <para>The name of the field to be created or updated with the distance of the point feature from the computed network location. A field named Distance is created or updated by default.</para>
		/// <para>The output field is in meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object DistanceField { get; set; }

		/// <summary>
		/// <para>Located Z-Coordinate Field</para>
		/// <para>The name of the field to be created or updated with the z-coordinate of the computed network location. A field named SnapZ will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object SnapZField { get; set; }

		/// <summary>
		/// <para>Location Ranges Field</para>
		/// <para>The name of the field to be created or updated with the location ranges of the computed network locations for the line or polygon features. A field named Locations will be created or updated by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Blob")]
		[Category("Network Location Fields")]
		public object LocationField { get; set; }

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// <para>This parameter is only available via Python.</para>
		/// <para><see cref="ExcludeRestrictedElementsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExcludeRestrictedElements { get; set; } = "true";

		/// <summary>
		/// <para>Search Query</para>
		/// <para>Defines a query that will restrict the search to a subset of the features in a source feature class. This is useful if you don&apos;t want to locate on features that may be unsuitable for your analysis. For example, you can use the query to exclude all features with a particular road class.</para>
		/// <para>A separate SQL expression can be specified per source feature class of the network dataset. By default, no query is used for any source.</para>
		/// <para>This parameter is not used when the network data source is a portal service.</para>
		/// <para>The SQL expression for a given network source is specified by selecting the source name in the Name column and using the SQL expression builder in the Query column. For more information on SQL syntax, see SQL reference for query expressions used in ArcGIS.</para>
		/// <para>Any network source not explicitly specified in the tool dialog box will have no query applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object SearchQuery { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The name of the travel mode to be used in the analysis.</para>
		/// <para>If you select a travel mode, the travel mode settings, such as restrictions and impedance attributes, will be considered when calculating location fields. For example, if the closest network edge to one of your input points is forbidden to trucks and your travel mode is set for trucking, Calculate Locations will locate the point on the next-closest network edge that is not forbidden for trucks.</para>
		/// <para>The available travel modes depend on the Input Analysis Network parameter value.</para>
		/// <para>If a sublayer of a network analysis layer is used as input features, the travel mode parameter must be set to the network analysis layer&apos;s travel mode.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateLocations SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Find Closest among All Classes</para>
		/// </summary>
		public enum MatchTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MATCH_TO_CLOSEST")]
			MATCH_TO_CLOSEST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRIORITY")]
			PRIORITY,

		}

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// </summary>
		public enum ExcludeRestrictedElementsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE")]
			EXCLUDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE")]
			INCLUDE,

		}

#endregion
	}
}
