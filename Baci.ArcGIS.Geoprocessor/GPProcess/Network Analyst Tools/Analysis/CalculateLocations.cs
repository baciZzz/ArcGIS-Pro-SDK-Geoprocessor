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
	/// <para>Calculate Locations</para>
	/// <para>Locates input features on a network and adds fields  to the input features that describe the network locations. The tool is used to precalculate the network locations of inputs that will be used in a Network Analyst workflow, improving performance of the analysis at solve time.  The tool stores the calculated network locations of the inputs in fields in the input data.</para>
	/// </summary>
	public class CalculateLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Features</para>
		/// <para>The input features for which the network locations will be calculated.</para>
		/// <para>For line and polygon features, since the network location information is stored in a BLOB field, only geodatabase feature classes are supported.</para>
		/// </param>
		public CalculateLocations(object InPointFeatures)
		{
			this.InPointFeatures = InPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Locations</para>
		/// </summary>
		public override string DisplayName() => "Calculate Locations";

		/// <summary>
		/// <para>Tool Name : CalculateLocations</para>
		/// </summary>
		public override string ToolName() => "CalculateLocations";

		/// <summary>
		/// <para>Tool Excute Name : na.CalculateLocations</para>
		/// </summary>
		public override string ExcuteName() => "na.CalculateLocations";

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
		public override object[] Parameters() => new object[] { InPointFeatures, InNetworkDataset!, SearchTolerance!, SearchCriteria!, MatchType!, SourceIDField!, SourceOIDField!, PositionField!, SideField!, SnapXField!, SnapYField!, DistanceField!, SnapZField!, LocationField!, ExcludeRestrictedElements!, SearchQuery!, OutPointFeatureClass!, TravelMode!, OutputLayer! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features for which the network locations will be calculated.</para>
		/// <para>For line and polygon features, since the network location information is stored in a BLOB field, only geodatabase feature classes are supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset that will be used to calculate the locations.</para>
		/// <para>This parameter is required unless a sublayer of a network analysis layer is used as input features. In that case, the parameter is hidden and automatically set to the network dataset referenced by the network analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDatasetLayer()]
		public object? InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The maximum search distance that will be used when locating the input features on the network. Features that are outside the search tolerance will be left unlocated. The parameter includes a value and units.</para>
		/// <para>The default is 5000 meters.</para>
		/// <para>If the input features are a sublayer of a network analysis layer, the default value for this parameter is determined based on location properties stored in the input network analysis layer. If the network analysis layer has location settings overrides for the selected sublayer, those settings will be used. Otherwise, the network analysis layer&apos;s default location settings will be used. Setting a nondefault value for this parameter updates the network analysis layer&apos;s location settings overrides for the selected sublayer.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Search Criteria</para>
		/// <para>The edge and junction sources in the network dataset that will be searched when locating inputs on the network. For example, if the network dataset references separate feature classes representing streets and sidewalks, you can choose to locate inputs on streets but not on sidewalks.</para>
		/// <para>The following are the available snap type choices for each network source:</para>
		/// <para>None—The point will not locate on elements in this network source.</para>
		/// <para>Shape—The point will locate on the closest point of an element in this network source.</para>
		/// <para>Middle—This option is deprecated and behaves the same as Shape.</para>
		/// <para>End—This option is deprecated and behaves the same as Shape.</para>
		/// <para>The default value is to locate on all network sources except override junctions created by running the Dissolve Network tool and system junctions.</para>
		/// <para>If the input features are a sublayer of a network analysis layer, the default value for this parameter is determined based on location properties stored in the input network analysis layer. If the network analysis layer has location settings overrides for the selected sublayer, those settings will be used. Otherwise, the network analysis layer&apos;s default location settings will be used. Setting a nondefault value for this parameter updates the network analysis layer&apos;s location settings overrides for the selected sublayer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object? SearchCriteria { get; set; }

		/// <summary>
		/// <para>Find Closest among All Classes</para>
		/// <para>This parameter is deprecated and maintained only for backward compatibility. Inputs will always be matched to the closest network source among all the sources used for locating, corresponding to a parameter value of MATCH_TO_CLOSEST or True.</para>
		/// <para><see cref="MatchTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MatchType { get; set; } = "true";

		/// <summary>
		/// <para>Source ID Field</para>
		/// <para>The name of the field to be created or updated that will be populated with the ID of the network dataset source feature class for the input feature&apos;s computed network location. The default value is SourceID.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object? SourceIDField { get; set; }

		/// <summary>
		/// <para>Source OID Field</para>
		/// <para>The name of the field to be created or updated that will be populated with the ObjectID field value of the network dataset source feature class for the input feature&apos;s computed network location. The default value is SourceOID.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object? SourceOIDField { get; set; }

		/// <summary>
		/// <para>Percent Along Field</para>
		/// <para>The name of the field to be created or updated describing the computed network location&apos;s percent along the network element where it was located. The default value is PosAlong.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? PositionField { get; set; }

		/// <summary>
		/// <para>Side of Edge Field</para>
		/// <para>The name of the field to be created or updated describing the side of the network edge on which the computed network location falls. The default value is SideOfEdge.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object? SideField { get; set; }

		/// <summary>
		/// <para>Located X-Coordinate Field</para>
		/// <para>The name of the field to be created or updated with the x-coordinate of the computed network location. The default value is SnapX.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? SnapXField { get; set; }

		/// <summary>
		/// <para>Located Y-Coordinate Field</para>
		/// <para>The name of the field to be created or updated with the y-coordinate of the computed network location. The default value is SnapY.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? SnapYField { get; set; }

		/// <summary>
		/// <para>Distance from Feature Field</para>
		/// <para>The name of the field to be created or updated describing the distance in meters of the original point feature from its computed network location. The default value is DistanceToNetworkInMeters.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? DistanceField { get; set; }

		/// <summary>
		/// <para>Located Z-Coordinate Field</para>
		/// <para>The name of the field to be created or updated with the z-coordinate of the computed network location. The default value is SnapZ.</para>
		/// <para>The parameter is used only when the input network dataset supports connectivity based on z-coordinate values of the network sources.</para>
		/// <para>The parameter is not used when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? SnapZField { get; set; }

		/// <summary>
		/// <para>Location Ranges Field</para>
		/// <para>The name of the field to be created or updated with the location ranges of the computed network locations for line or polygon features. The default value is Locations.</para>
		/// <para>The parameter is used only when calculating locations for line or polygon features.</para>
		/// <para>Do not use this parameter when the input features are a sublayer of a network analysis layer. Network locations in a sublayer must be stored in location fields with the default names or they will not be used when the layer is solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Blob")]
		[Category("Network Location Fields")]
		public object? LocationField { get; set; }

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// <para>This parameter is deprecated and maintained only for backward compatibility. Analysis inputs will never be located on network elements that are restricted, corresponding to a parameter value of EXCLUDE or True.</para>
		/// <para><see cref="ExcludeRestrictedElementsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExcludeRestrictedElements { get; set; } = "true";

		/// <summary>
		/// <para>Search Query</para>
		/// <para>A query that restricts the search to a subset of the features within a source feature class. This is useful if you don&apos;t want to find features that may be unsuited for a network location. For example, if you don&apos;t want to locate on highway ramps, you can define a query to exclude them. A separate SQL expression can be specified per edge or junction source feature class of the network dataset.</para>
		/// <para>Any network source not explicitly specified in the Geoprocessing pane will have no query applied.</para>
		/// <para>By default, no query is used for any source.</para>
		/// <para>If the input features are a sublayer of a network analysis layer, the default value for this parameter is determined based on location properties stored in the input network analysis layer. If the network analysis layer has location settings overrides for the selected sublayer, those settings will be used. Otherwise, the network analysis layer&apos;s default location settings will be used. Setting a nondefault value for this parameter updates the network analysis layer&apos;s location settings overrides for the selected sublayer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object? SearchQuery { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object? OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The name of the travel mode that will be used.</para>
		/// <para>If you select a travel mode, the travel mode settings, such as restrictions and impedance attributes, will be considered when calculating network location. For example, if the closest network edge to one of the input points is restricted when the selected travel mode is applied, the tool will locate the point on the next-closest network edge that is not restricted.</para>
		/// <para>The available travel modes depend on the Input Analysis Network parameter value.</para>
		/// <para>If a sublayer of a network analysis layer is used as input features, this parameter is hidden and should not be used. When network locations are calculated, the network analysis layer&apos;s current travel mode will automatically be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateLocations SetEnviroment(object? workspace = null)
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
