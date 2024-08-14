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
	/// <para>Adds input features or records to a network analysis layer. The inputs are added to specific sublayers such as stops and barriers. When the network analysis layer references a network dataset as its network data source, the tool calculates the network locations of the inputs, unless precalculated network location fields are mapped from the inputs.</para>
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
		public override string DisplayName => "Add Locations";

		/// <summary>
		/// <para>Tool Name : AddLocations</para>
		/// </summary>
		public override string ToolName => "AddLocations";

		/// <summary>
		/// <para>Tool Excute Name : na.AddLocations</para>
		/// </summary>
		public override string ExcuteName => "na.AddLocations";

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
		public override object[] Parameters => new object[] { InNetworkAnalysisLayer, SubLayer, InTable, FieldMappings!, SearchTolerance!, SortField!, SearchCriteria!, MatchType!, Append!, SnapToPositionAlongNetwork!, SnapOffset!, ExcludeRestrictedElements!, SearchQuery!, OutputLayer!, AllowAutoRelocate! };

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
		/// <para>The mapping between the input fields of the network analysis sublayer to which locations will be added and the fields in the input data or specified constants.</para>
		/// <para>Input sublayers of network analysis layers have a set of input fields that can be populated to modify or control analysis behavior. When adding locations to the sublayer, you can use this parameter to map field values from the input table to these fields in the sublayer. You can also use field mappings to specify a constant default value for each property.</para>
		/// <para>If neither the Field value nor the Default value is specified for a property, the resulting network analysis objects will have null values for that property.</para>
		/// <para>A complete list of input fields for each sublayer for each network analysis layer type is available in the documentation for each layer. For example, examine the Route layer&apos;s Stops sublayer&apos;s input fields.</para>
		/// <para>If the data being loaded contains precalculated network locations or location ranges based on the network data source and travel mode used for the analysis, choose the Use Network Location Fields option from the drop-down menu. Adding the network analysis objects using the network location fields is quicker than loading by geometry.</para>
		/// <para>ArcGIS Online and some ArcGIS Enterprise portals do not support using network location fields. For network analysis layers that use one of these portals as the network data source, all inputs will be located at solve time, and any mapped location fields will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NAClassFieldMap()]
		public object? FieldMappings { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The maximum search distance that will be used when locating the input features on the network. Features that are outside the search tolerance will be left unlocated. The parameter includes a value and units.</para>
		/// <para>The default value for this parameter is determined based on location properties stored in the input network analysis layer. If the network analysis layer has location settings overrides for the selected sublayer, those settings will be used. Otherwise, the network analysis layer&apos;s default location settings will be used. Setting a nondefault value for this parameter updates the network analysis layer&apos;s location settings overrides for the selected sublayer.</para>
		/// <para>The parameter is not used when adding locations to sublayers with line or polygon geometry, such as Line Barriers and Polygon Barriers.</para>
		/// <para>This parameter is not used when adding locations using existing network location fields.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is a portal running a version of ArcGIS Enterprise older than 11.0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>The field on which the network analysis objects will be sorted as they are added to the network analysis layer. The default is the ObjectID field in the input feature class or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Advanced")]
		public object? SortField { get; set; }

		/// <summary>
		/// <para>Search Criteria</para>
		/// <para>The edge and junction sources in the network dataset that will be searched when locating inputs on the network. For example, if the network dataset references separate feature classes representing streets and sidewalks, you can choose to locate inputs on streets but not on sidewalks.</para>
		/// <para>The following are the available snap type choices for each network source:</para>
		/// <para>None—The point will not locate on elements in this network source.</para>
		/// <para>Shape—The point will locate on the closest point of an element in this network source.</para>
		/// <para>Middle—This option is deprecated and behaves the same as Shape.</para>
		/// <para>End—This option is deprecated and behaves the same as Shape.</para>
		/// <para>The default value for this parameter is determined based on location properties stored in the input network analysis layer. If the network analysis layer has location settings overrides for the selected sublayer, those settings will be used. Otherwise, the network analysis layer&apos;s default location settings will be used. Setting a nondefault value for this parameter updates the network analysis layer&apos;s location settings overrides for the selected sublayer.</para>
		/// <para>This parameter is not used when adding locations using existing network location fields.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is ArcGIS Online.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is a portal running a version of ArcGIS Enterprise older than 11.0.</para>
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
		/// <para>Append to Existing Locations</para>
		/// <para>Specifies whether new network analysis objects will be appended to existing objects.</para>
		/// <para>Checked—The new network analysis objects will be appended to the existing set of objects in the selected sublayer. This is the default.</para>
		/// <para>Unchecked—The existing network analysis objects will be deleted and replaced with the new objects.</para>
		/// <para><see cref="AppendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Append { get; set; } = "true";

		/// <summary>
		/// <para>Snap to Network</para>
		/// <para>Specifies whether the inputs will be snapped to their calculated network locations or represented at their original geographic location.</para>
		/// <para>To use curb approach in the analysis to control which side of the road a vehicle must use to approach a location, do not snap the inputs to their network locations, or use a snap offset to ensure that the point remains clearly to one side of the road.</para>
		/// <para>The parameter is not used when adding locations to sublayers with line or polygon geometry, such as Line Barriers and Polygon Barriers.</para>
		/// <para>This parameter is not used when the input network analysis layer&apos;s network data source is a portal service.</para>
		/// <para>Checked—The geometries of the network locations will be snapped to their network locations.</para>
		/// <para>Unchecked—The geometries of the network locations will be based on the geometries of the input features. This is the default.</para>
		/// <para><see cref="SnapToPositionAlongNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SnapToPositionAlongNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Snap Offset</para>
		/// <para>An offset distance that will be applied when snapping a point to the network. An offset distance of zero means the point will be coincident with the network feature (typically a line). To offset the point from the network feature, enter an offset distance. The offset is in relation to the original point location; that is, if the original point was on the left side, its new location will be offset to the left. If it was originally on the right side, its new location will be offset to the right.</para>
		/// <para>The default is 5 meters. However, this parameter is ignored if Snap to Network is unchecked.</para>
		/// <para>The parameter is not used when adding locations to sublayers with line or polygon geometry, such as Line Barriers and Polygon Barriers.</para>
		/// <para>This parameter is not used when the input network analysis layer&apos;s network data source is a portal service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SnapOffset { get; set; } = "5 Meters";

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
		/// <para>The default value for this parameter is determined based on location properties stored in the input network analysis layer. If the network analysis layer has location settings overrides for the selected sublayer, those settings will be used. Otherwise, the network analysis layer&apos;s default location settings will be used. Setting a nondefault value for this parameter updates the network analysis layer&apos;s location settings overrides for the selected sublayer.</para>
		/// <para>This parameter is not used when adding locations using existing network location fields.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is ArcGIS Online.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is a portal running a version of ArcGIS Enterprise older than 11.0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object? SearchQuery { get; set; }

		/// <summary>
		/// <para>Updated Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Allow automatic relocating at solve time</para>
		/// <para>Specifies whether inputs with existing network location fields can be automatically relocated at solve time to ensure valid, routable location fields for the analysis.</para>
		/// <para>Checked—Points located on restricted network elements and points affected by barriers will be relocated at solve time to the closest routable location. This is the default.</para>
		/// <para>Unchecked—Network location fields will be used at solve time as is, even if the points are unreachable, and this may cause the solve to fail.</para>
		/// <para>The default value for this parameter is determined based on location properties stored in the input network analysis layer. If the network analysis layer has location settings overrides for the selected sublayer, those settings will be used. Otherwise, the network analysis layer&apos;s default location settings will be used. Setting a nondefault value for this parameter updates the network analysis layer&apos;s location settings overrides for the selected sublayer.</para>
		/// <para>Even if the automatic relocating at solve time is not allowed, inputs with no location fields or incomplete location fields will be located at solve time.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is ArcGIS Online.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is an ArcGIS Enterprise portal that does not support using network location fields.</para>
		/// <para>This parameter is not used when the network analysis layer&apos;s network data source is a portal running a version of ArcGIS Enterprise older than 11.0.</para>
		/// <para><see cref="AllowAutoRelocateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? AllowAutoRelocate { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddLocations SetEnviroment(object? workspace = null )
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

		/// <summary>
		/// <para>Allow automatic relocating at solve time</para>
		/// </summary>
		public enum AllowAutoRelocateEnum 
		{
			/// <summary>
			/// <para>Checked—Points located on restricted network elements and points affected by barriers will be relocated at solve time to the closest routable location. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOW")]
			ALLOW,

			/// <summary>
			/// <para>Unchecked—Network location fields will be used at solve time as is, even if the points are unreachable, and this may cause the solve to fail.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ALLOW")]
			NO_ALLOW,

		}

#endregion
	}
}
