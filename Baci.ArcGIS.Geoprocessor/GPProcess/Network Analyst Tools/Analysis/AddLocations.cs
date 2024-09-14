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
	/// <para>Add Locations</para>
	/// <para>Add Locations</para>
	/// <para>Adds input features or records to a network analysis layer. The inputs are added to specific sublayers such as stops and barriers.</para>
	/// </summary>
	public class AddLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer to which the network analysis objects will be added.</para>
		/// </param>
		/// <param name="SubLayer">
		/// <para>Sub Layer</para>
		/// <para>The name of the sublayer of the network analysis layer to which the network analysis objects will be added.</para>
		/// </param>
		/// <param name="InTable">
		/// <para>Input Locations</para>
		/// <para>The feature class or table containing the locations to be added to the network analysis sublayer.</para>
		/// </param>
		public AddLocations(object InNetworkAnalysisLayer, object SubLayer, object InTable)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
			this.SubLayer = SubLayer;
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Locations</para>
		/// </summary>
		public override string DisplayName() => "Add Locations";

		/// <summary>
		/// <para>Tool Name : AddLocations</para>
		/// </summary>
		public override string ToolName() => "AddLocations";

		/// <summary>
		/// <para>Tool Excute Name : na.AddLocations</para>
		/// </summary>
		public override string ExcuteName() => "na.AddLocations";

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
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, SubLayer, InTable, FieldMappings, SearchTolerance, SortField, SearchCriteria, MatchType, Append, SnapToPositionAlongNetwork, SnapOffset, ExcludeRestrictedElements, SearchQuery, OutputLayer };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer to which the network analysis objects will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Sub Layer</para>
		/// <para>The name of the sublayer of the network analysis layer to which the network analysis objects will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SubLayer { get; set; }

		/// <summary>
		/// <para>Input Locations</para>
		/// <para>The feature class or table containing the locations to be added to the network analysis sublayer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Mappings</para>
		/// <para>The mapping between the input fields of the network analysis sublayer to which you&apos;re adding locations and the fields in your input data or specified constants.</para>
		/// <para>Input sublayers of network analysis layers have a set of input fields that you can modify or populate according to the needs of your analysis. When adding locations to the sublayer, you can use this parameter to map field values from your input table to these fields in the sublayer. You can also use field mappings to specify a constant default value for each property.</para>
		/// <para>If neither the Field value nor the Default value is specified for a property, the resulting network analysis objects will have null values for that property.</para>
		/// <para>A complete list of input fields for each sublayer for each network analysis layer type is available in the documentation for each layer. For example, examine the Route layer&apos;s Stops sublayer&apos;s input fields.</para>
		/// <para>If the data you are loading contains network locations or location ranges based on the network dataset used for the analysis, choose the Use Network Location Fields option from the drop-down menu. Adding the network analysis objects using the network location fields is quicker than loading by geometry.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NAClassFieldMap()]
		public object FieldMappings { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The search tolerance that will be used to locate the input features on the network. Features that are outside the search tolerance are left unlocated. The parameter includes a value and units for the tolerance.</para>
		/// <para>The default is 5000 meters.</para>
		/// <para>The parameter is not used when adding locations to sublayers with line or polygon geometry, such as Line Barriers and Polygon Barriers.</para>
		/// <para>This parameter is not used when the input network analysis layer&apos;s network data source is a portal service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object SearchTolerance { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>The field on which the network analysis objects are sorted as they are added to the network analysis layer. The default is the ObjectID field in the input feature class or the table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID")]
		[Category("Advanced")]
		public object SortField { get; set; }

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
		/// <para>Append to Existing Locations</para>
		/// <para>Specifies whether new network analysis objects will be appended to existing objects.</para>
		/// <para>Checked—The new network analysis objects will be appended to the existing set of objects in the selected sublayer. This is the default.</para>
		/// <para>Unchecked—The existing network analysis objects will be deleted and replaced with the new objects.</para>
		/// <para><see cref="AppendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Append { get; set; } = "true";

		/// <summary>
		/// <para>Snap to Network</para>
		/// <para>Specifies whether the inputs will be snapped to their calculated network locations or will be represented at their original geographic location.</para>
		/// <para>To use curb approach in your analysis to control which side of the road a vehicle must use to approach a location, do not snap the inputs to their network locations, or use a snap offset to ensure that the point remains clearly to one side of the road.</para>
		/// <para>The parameter is not used when adding locations to sublayers with line or polygon geometry, such as Line Barriers and Polygon Barriers.</para>
		/// <para>This parameter is not used when the input network analysis layer&apos;s network data source is a portal service.</para>
		/// <para>If, after adding locations, you change the network analysis layer&apos;s travel mode or add or remove barriers, the network locations of affected points are automatically recalculated at solve time to ensure that they remain valid. This automatic recalculation process will not consider any settings, such as search queries, used previously when calculating network locations. Instead, it uses only the geometry of the input feature and the network analysis layer&apos;s travel mode and barriers. To make it more likely that the same network locations will be chosen if the point&apos;s network locations are automatically recalculated, use this parameter to snap the inputs to the network locations calculated while running this tool. In this way, the desired network location will be preserved in the geometry of the input point.</para>
		/// <para>Checked—The geometries of the network locations will be snapped to their network locations.</para>
		/// <para>Unchecked—The geometries of the network locations will be based on the geometries of the input features. This is the default.</para>
		/// <para><see cref="SnapToPositionAlongNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SnapToPositionAlongNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Snap Offset</para>
		/// <para>When snapping a point to the network, you can apply an offset distance. An offset distance of zero means the point will be coincident with the network feature (typically a line). To offset the point from the network feature, enter an offset distance. The offset is in relation to the original point location; that is, if the original point was on the left side, its new location will be offset to the left. If it was originally on the right side, its new location will be offset to the right.</para>
		/// <para>The default is 5 meters. However, this parameter is ignored if Snap to Network is unchecked.</para>
		/// <para>The parameter is not used when adding locations to sublayers with line or polygon geometry, such as Line Barriers and Polygon Barriers.</para>
		/// <para>This parameter is not used when the input network analysis layer&apos;s network data source is a portal service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SnapOffset { get; set; } = "5 Meters";

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
		/// <para>Updated Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddLocations SetEnviroment(object workspace = null)
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
		/// <para>Append to Existing Locations</para>
		/// </summary>
		public enum AppendEnum 
		{
			/// <summary>
			/// <para>Checked—The new network analysis objects will be appended to the existing set of objects in the selected sublayer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—The existing network analysis objects will be deleted and replaced with the new objects.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CLEAR")]
			CLEAR,

		}

		/// <summary>
		/// <para>Snap to Network</para>
		/// </summary>
		public enum SnapToPositionAlongNetworkEnum 
		{
			/// <summary>
			/// <para>Checked—The geometries of the network locations will be snapped to their network locations.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SNAP")]
			SNAP,

			/// <summary>
			/// <para>Unchecked—The geometries of the network locations will be based on the geometries of the input features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SNAP")]
			NO_SNAP,

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
