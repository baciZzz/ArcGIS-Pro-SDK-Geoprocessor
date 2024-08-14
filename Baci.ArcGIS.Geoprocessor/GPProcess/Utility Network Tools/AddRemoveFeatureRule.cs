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
	/// <para>Add Remove Feature Rule</para>
	/// <para>Add a remove feature rule to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddRemoveFeatureRule : AbstractGPProcess
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
		/// <param name="SourceType">
		/// <para>Source Type</para>
		/// <para><see cref="SourceTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		/// <param name="NetworkSource">
		/// <para>Network Sources</para>
		/// </param>
		public AddRemoveFeatureRule(object InUtilityNetwork, object TemplateName, object IsActive, object SourceType, object InverseSourceSelection, object NetworkSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.SourceType = SourceType;
			this.InverseSourceSelection = InverseSourceSelection;
			this.NetworkSource = NetworkSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Remove Feature Rule</para>
		/// </summary>
		public override string DisplayName => "Add Remove Feature Rule";

		/// <summary>
		/// <para>Tool Name : AddRemoveFeatureRule</para>
		/// </summary>
		public override string ToolName => "AddRemoveFeatureRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddRemoveFeatureRule</para>
		/// </summary>
		public override string ExcuteName => "un.AddRemoveFeatureRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, SourceType, InverseSourceSelection, NetworkSource, Description!, OutUtilityNetwork!, OutTemplateName!, UnconnectedJunctions!, OneConnectedJunction! };

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
		/// <para>Source Type</para>
		/// <para><see cref="SourceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SourceType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "INCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Network Sources</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object NetworkSource { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutTemplateName { get; set; }

		/// <summary>
		/// <para>Junctions must be unconnected</para>
		/// <para><see cref="UnconnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? UnconnectedJunctions { get; set; } = "false";

		/// <summary>
		/// <para>Junctions must be connected to a single junction</para>
		/// <para><see cref="OneConnectedJunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? OneConnectedJunction { get; set; } = "false";

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
		/// <para>Source Type</para>
		/// </summary>
		public enum SourceTypeEnum 
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
		/// <para>Junctions must be unconnected</para>
		/// </summary>
		public enum UnconnectedJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_UNCONNECTED")]
			MUST_BE_UNCONNECTED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONSTRAINT")]
			NO_CONSTRAINT,

		}

		/// <summary>
		/// <para>Junctions must be connected to a single junction</para>
		/// </summary>
		public enum OneConnectedJunctionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_CONNECTED_TO_SINGLE_JUNCTION")]
			MUST_BE_CONNECTED_TO_SINGLE_JUNCTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONSTRAINT")]
			NO_CONSTRAINT,

		}

#endregion
	}
}
