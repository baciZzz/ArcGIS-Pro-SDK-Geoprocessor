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
	/// <para>Add Collapse Container Rule</para>
	/// <para>Add a collapse container rule to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddCollapseContainerRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="ContainerType">
		/// <para>Container Type</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		public AddCollapseContainerRule(object InUtilityNetwork, object TemplateName, object IsActive, object ContainerType, object InverseSourceSelection)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.ContainerType = ContainerType;
			this.InverseSourceSelection = InverseSourceSelection;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Collapse Container Rule</para>
		/// </summary>
		public override string DisplayName => "Add Collapse Container Rule";

		/// <summary>
		/// <para>Tool Name : AddCollapseContainerRule</para>
		/// </summary>
		public override string ToolName => "AddCollapseContainerRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddCollapseContainerRule</para>
		/// </summary>
		public override string ExcuteName => "un.AddCollapseContainerRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, ContainerType, InverseSourceSelection, ContainerSources, Description, OutUtilityNetwork, OutTemplateName, ReconnectedEdgesOption };

		/// <summary>
		/// <para>Input Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Container Type</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContainerType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "EXCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Container Sources</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object ContainerSources { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutTemplateName { get; set; }

		/// <summary>
		/// <para>Aggregate reconnected edges</para>
		/// <para><see cref="ReconnectedEdgesOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReconnectedEdgesOption { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INACTIVE")]
			INACTIVE,

		}

		/// <summary>
		/// <para>Container Type</para>
		/// </summary>
		public enum ContainerTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("JUNCTIONS")]
			[Description("JUNCTIONS")]
			JUNCTIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDGES")]
			[Description("EDGES")]
			EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("BOTH")]
			BOTH,

		}

		/// <summary>
		/// <para>Rule Process</para>
		/// </summary>
		public enum InverseSourceSelectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("EXCLUDE_SOURCE_CLASSES")]
			EXCLUDE_SOURCE_CLASSES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("INCLUDE_SOURCE_CLASSES")]
			INCLUDE_SOURCE_CLASSES,

		}

		/// <summary>
		/// <para>Aggregate reconnected edges</para>
		/// </summary>
		public enum ReconnectedEdgesOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AGGREGATE_RECONNECTED_EDGES")]
			AGGREGATE_RECONNECTED_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_AGGREGATE_RECONNECTED_EDGES")]
			DONT_AGGREGATE_RECONNECTED_EDGES,

		}

#endregion
	}
}
