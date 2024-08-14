using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Export Subnetwork</para>
	/// <para>Exports subnetworks from a utility network into a .json file. This tool also allows you to delete a row in the Subnetworks table as long as the Is deleted attribute is set to true. This indicates that the subnetwork controller has been removed from the subnetwork.</para>
	/// </summary>
	public class ExportSubnetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork to export.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the subnetwork.</para>
		/// </param>
		/// <param name="Tier">
		/// <para>Tier</para>
		/// <para>The tier that contains the subnetwork.</para>
		/// </param>
		/// <param name="SubnetworkName">
		/// <para>Subnetwork Name</para>
		/// <para>The name of the subnetwork to export. Select a specific source to export the corresponding subnetwork information.</para>
		/// </param>
		/// <param name="ExportAcknowledged">
		/// <para>Set export acknowledged</para>
		/// <para>Specifies whether the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table and feature in the SubnetLine feature class will be updated.</para>
		/// <para>Checked—The LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table will be updated. If the controller has been marked for deletion (Is deleted = True), it will be deleted from the Subnetworks table. This option requires that the input utility network reference the default version.</para>
		/// <para>Unchecked—The LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table will not be updated. This is the default.</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output JSON</para>
		/// <para>The name and location of the .json file that will be generated.</para>
		/// </param>
		public ExportSubnetwork(object InUtilityNetwork, object DomainNetwork, object Tier, object SubnetworkName, object ExportAcknowledged, object OutJsonFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Tier = Tier;
			this.SubnetworkName = SubnetworkName;
			this.ExportAcknowledged = ExportAcknowledged;
			this.OutJsonFile = OutJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Subnetwork</para>
		/// </summary>
		public override string DisplayName => "Export Subnetwork";

		/// <summary>
		/// <para>Tool Name : ExportSubnetwork</para>
		/// </summary>
		public override string ToolName => "ExportSubnetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportSubnetwork</para>
		/// </summary>
		public override string ExcuteName => "un.ExportSubnetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, DomainNetwork, Tier, SubnetworkName, ExportAcknowledged, OutJsonFile, ConditionBarriers!, FunctionBarriers!, IncludeBarriers!, TraversabilityScope!, Propagators!, OutUtilityNetwork!, IncludeGeometry!, ResultTypes!, ResultNetworkAttributes!, ResultFields!, IncludeDomainDescriptions! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// <para>The tier that contains the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Tier { get; set; }

		/// <summary>
		/// <para>Subnetwork Name</para>
		/// <para>The name of the subnetwork to export. Select a specific source to export the corresponding subnetwork information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SubnetworkName { get; set; }

		/// <summary>
		/// <para>Set export acknowledged</para>
		/// <para>Specifies whether the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table and feature in the SubnetLine feature class will be updated.</para>
		/// <para>Checked—The LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table will be updated. If the controller has been marked for deletion (Is deleted = True), it will be deleted from the Subnetworks table. This option requires that the input utility network reference the default version.</para>
		/// <para>Unchecked—The LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table will not be updated. This is the default.</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExportAcknowledged { get; set; } = "false";

		/// <summary>
		/// <para>Output JSON</para>
		/// <para>The name and location of the .json file that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutJsonFile { get; set; }

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>This parameter is only available for Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>This parameter is only available for Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>This parameter is only available for Python.</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>Specifies the type of traversability that will be applied. Traversability scope determines whether traversability is applied to junctions, edges, or both. For example, if a condition barrier is defined to stop the trace if DEVICESTATUS is set to Open and the traversability scope is set to edges only, the trace will not stop even if the trace encounters an open device, because DEVICESTATUS is only applicable to junctions. In other words, this parameter indicates to the trace whether to ignore junctions, edges, or both.</para>
		/// <para>Both junctions and edges—Traversability will be applied to both junctions and edges.</para>
		/// <para>Junctions only—Traversability will be applied to junctions only.</para>
		/// <para>Edges only—Traversability will be applied to edges only.</para>
		/// <para>This parameter is only available for Python.</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>This parameter is only available for Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? Propagators { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Include geometry</para>
		/// <para>Specifies whether geometry will be included in the results.</para>
		/// <para>Checked—Geometry will be included in the results.</para>
		/// <para>Unchecked—Geometry will not be included in the results. This is the default.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.7 or later.</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Result Types</para>
		/// <para>Specifies the types of results that will be returned.</para>
		/// <para>Connectivity—Features that are connected via geometric coincidence or connectivity associations will be returned. This is the default.</para>
		/// <para>Features—Feature-level information will be returned.</para>
		/// <para>Containment and attachment associations—Features that are associated via containment and structural attachment associations will be returned.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.7 or later.</para>
		/// <para>The containment and attachment associations option requires ArcGIS Enterprise 10.8.1 or later.</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ResultTypes { get; set; }

		/// <summary>
		/// <para>Result Network Attributes</para>
		/// <para>The network attributes that will be included in the results.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.7 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ResultNetworkAttributes { get; set; }

		/// <summary>
		/// <para>Result Fields</para>
		/// <para>Fields from a feature class that will be returned as results. The values of the field will be returned in the results for the features in the subnetwork.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.7 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ResultFields { get; set; }

		/// <summary>
		/// <para>Include domain descriptions</para>
		/// <para>Specifies whether domain descriptions will be included in the output .json file to communicate domain mapping for controllers, featureElements, connectivity, and associations.</para>
		/// <para>Checked—Domain descriptions will be included in the results.</para>
		/// <para>Unchecked—Domain descriptions will not be included in the results. This is the default.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.9.1 or later.</para>
		/// <para><see cref="IncludeDomainDescriptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeDomainDescriptions { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Set export acknowledged</para>
		/// </summary>
		public enum ExportAcknowledgedEnum 
		{
			/// <summary>
			/// <para>Checked—The LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table will be updated. If the controller has been marked for deletion (Is deleted = True), it will be deleted from the Subnetworks table. This option requires that the input utility network reference the default version.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ACKNOWLEDGE")]
			ACKNOWLEDGE,

			/// <summary>
			/// <para>Unchecked—The LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table will not be updated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ACKNOWLEDGE")]
			NO_ACKNOWLEDGE,

		}

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// </summary>
		public enum IncludeBarriersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_BARRIERS")]
			INCLUDE_BARRIERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_BARRIERS")]
			EXCLUDE_BARRIERS,

		}

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// </summary>
		public enum TraversabilityScopeEnum 
		{
			/// <summary>
			/// <para>Both junctions and edges—Traversability will be applied to both junctions and edges.</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("Both junctions and edges")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>Junctions only—Traversability will be applied to junctions only.</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para>Edges only—Traversability will be applied to edges only.</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("Edges only")]
			Edges_only,

		}

		/// <summary>
		/// <para>Include geometry</para>
		/// </summary>
		public enum IncludeGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—Geometry will be included in the results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRY")]
			INCLUDE_GEOMETRY,

			/// <summary>
			/// <para>Unchecked—Geometry will not be included in the results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRY")]
			EXCLUDE_GEOMETRY,

		}

		/// <summary>
		/// <para>Result Types</para>
		/// </summary>
		public enum ResultTypesEnum 
		{
			/// <summary>
			/// <para>Features—Feature-level information will be returned.</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("Features")]
			Features,

			/// <summary>
			/// <para>Connectivity—Features that are connected via geometric coincidence or connectivity associations will be returned. This is the default.</para>
			/// </summary>
			[GPValue("CONNECTIVITY")]
			[Description("Connectivity")]
			Connectivity,

			/// <summary>
			/// <para>Containment and attachment associations—Features that are associated via containment and structural attachment associations will be returned.</para>
			/// </summary>
			[GPValue("CONTAINMENT_AND_ATTACHMENT_ASSOCIATIONS")]
			[Description("Containment and attachment associations")]
			Containment_and_attachment_associations,

		}

		/// <summary>
		/// <para>Include domain descriptions</para>
		/// </summary>
		public enum IncludeDomainDescriptionsEnum 
		{
			/// <summary>
			/// <para>Checked—Domain descriptions will be included in the results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_DOMAIN_DESCRIPTIONS")]
			INCLUDE_DOMAIN_DESCRIPTIONS,

			/// <summary>
			/// <para>Unchecked—Domain descriptions will not be included in the results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_DOMAIN_DESCRIPTIONS")]
			EXCLUDE_DOMAIN_DESCRIPTIONS,

		}

#endregion
	}
}
