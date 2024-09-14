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
	/// <para>Update Subnetwork</para>
	/// <para>Update Subnetwork</para>
	/// <para>Updates subnetwork information in the Subnetworks table, the SubnetLine feature class, and subnetwork system diagrams for the specified subnetworks. Also certain attributes are created or updated for subnetwork features. A record for any new subnetworks will be generated, the records for any deleted subnetworks will be removed, and the shape and information for any modified subnetworks will be updated.</para>
	/// </summary>
	public class UpdateSubnetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the subnetwork.</para>
		/// </param>
		/// <param name="Tier">
		/// <para>Tier</para>
		/// <para>The tier that contains the subnetwork.</para>
		/// </param>
		/// <param name="AllSubnetworksInTier">
		/// <para>All subnetworks in tier</para>
		/// <para>Specifies whether all subnetworks in the tier are updated. To update a subset of subnetworks in the tier, use the Subnetwork Name(s) parameter.</para>
		/// <para>Checked—Updates all subnetworks in the tier. This option uses asynchronous processing to update the subnetworks using the system UtilityNetworkTools geoprocessing service. The service is reserved for utility network geoprocessing tasks and has a longer default timeout setting. This is the default.</para>
		/// <para>Unchecked—Updates only the subnetworks that are specified in the Subnetwork Name(s) parameter.</para>
		/// <para><see cref="AllSubnetworksInTierEnum"/></para>
		/// </param>
		public UpdateSubnetwork(object InUtilityNetwork, object DomainNetwork, object Tier, object AllSubnetworksInTier)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Tier = Tier;
			this.AllSubnetworksInTier = AllSubnetworksInTier;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Subnetwork</para>
		/// </summary>
		public override string DisplayName() => "Update Subnetwork";

		/// <summary>
		/// <para>Tool Name : UpdateSubnetwork</para>
		/// </summary>
		public override string ToolName() => "UpdateSubnetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.UpdateSubnetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.UpdateSubnetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Tier, AllSubnetworksInTier, SubnetworkName!, ContinueOnFailure!, ConditionBarriers!, FunctionBarriers!, IncludeBarriers!, TraversabilityScope!, Propagators!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork.</para>
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
		/// <para>All subnetworks in tier</para>
		/// <para>Specifies whether all subnetworks in the tier are updated. To update a subset of subnetworks in the tier, use the Subnetwork Name(s) parameter.</para>
		/// <para>Checked—Updates all subnetworks in the tier. This option uses asynchronous processing to update the subnetworks using the system UtilityNetworkTools geoprocessing service. The service is reserved for utility network geoprocessing tasks and has a longer default timeout setting. This is the default.</para>
		/// <para>Unchecked—Updates only the subnetworks that are specified in the Subnetwork Name(s) parameter.</para>
		/// <para><see cref="AllSubnetworksInTierEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllSubnetworksInTier { get; set; } = "true";

		/// <summary>
		/// <para>Subnetwork Name</para>
		/// <para>The name of the subnetworks to update. If all subnetworks will be updated using the All subnetworks in tier parameter, this parameter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SubnetworkName { get; set; }

		/// <summary>
		/// <para>Continue on failure</para>
		/// <para>Specifies whether to stop the update process if a subnetwork fails to update when updating multiple subnetworks.</para>
		/// <para>Checked—Continues to update subnetworks upon failure.</para>
		/// <para>Unchecked—Stops updating subnetworks if a failure occurs. This is the default.</para>
		/// <para><see cref="ContinueOnFailureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContinueOnFailure { get; set; } = "false";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>This parameter is only available via Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>This parameter is only available via Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>This parameter is only available via Python.</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>Specifies the type of traversability to enforce. Traversability scope dictates whether traversability is enforced at junctions, edges, or both. For example, if a condition barrier is defined to stop the trace if DEVICESTATUS is equal to Open and traversability scope is set to edges only, the trace would not stop even if the trace encounters an open device, because the DEVICESTATUS is only applicable for junctions. In other words, this parameter indicates to the trace whether to ignore junctions, edges, or both.</para>
		/// <para>Both junctions and edges—Apply traversability to both junctions and edges. This is the default.</para>
		/// <para>Junctions only—Apply traversability to only junctions.</para>
		/// <para>Edges only—Apply traversability to only edges.</para>
		/// <para>This parameter is only available via Python.</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>This parameter is only available via Python.</para>
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
		[GPUtilityNetworkLayer()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>All subnetworks in tier</para>
		/// </summary>
		public enum AllSubnetworksInTierEnum 
		{
			/// <summary>
			/// <para>Checked—Updates all subnetworks in the tier. This option uses asynchronous processing to update the subnetworks using the system UtilityNetworkTools geoprocessing service. The service is reserved for utility network geoprocessing tasks and has a longer default timeout setting. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SUBNETWORKS_IN_TIER")]
			ALL_SUBNETWORKS_IN_TIER,

			/// <summary>
			/// <para>Unchecked—Updates only the subnetworks that are specified in the Subnetwork Name(s) parameter.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SPECIFIC_SUBNETWORK")]
			SPECIFIC_SUBNETWORK,

		}

		/// <summary>
		/// <para>Continue on failure</para>
		/// </summary>
		public enum ContinueOnFailureEnum 
		{
			/// <summary>
			/// <para>Checked—Continues to update subnetworks upon failure.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_ON_FAILURE")]
			CONTINUE_ON_FAILURE,

			/// <summary>
			/// <para>Unchecked—Stops updating subnetworks if a failure occurs. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("STOP_ON_FAILURE")]
			STOP_ON_FAILURE,

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
			/// <para>Both junctions and edges—Apply traversability to both junctions and edges. This is the default.</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("Both junctions and edges")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>Junctions only—Apply traversability to only junctions.</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para>Edges only—Apply traversability to only edges.</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("Edges only")]
			Edges_only,

		}

#endregion
	}
}
