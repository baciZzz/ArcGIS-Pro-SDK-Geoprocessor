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
	/// <para>Add Reduce Junction Rule</para>
	/// <para>Add a reduce junction rule to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddReduceJunctionRule : AbstractGPProcess
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
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		public AddReduceJunctionRule(object InUtilityNetwork, object TemplateName, object IsActive, object InverseSourceSelection)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.InverseSourceSelection = InverseSourceSelection;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Reduce Junction Rule</para>
		/// </summary>
		public override string DisplayName => "Add Reduce Junction Rule";

		/// <summary>
		/// <para>Tool Name : AddReduceJunctionRule</para>
		/// </summary>
		public override string ToolName => "AddReduceJunctionRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddReduceJunctionRule</para>
		/// </summary>
		public override string ExcuteName => "un.AddReduceJunctionRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, InverseSourceSelection, JunctionSource, ConnectivityOptions, UnconnectedJunctions, OneConnectedJunction, TwoConnectedJunctions, EdgesAttributes, Description, OutUtilityNetwork, OutTemplateName };

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
		/// <para>Rule Process</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "INCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Junction Sources</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object JunctionSource { get; set; }

		/// <summary>
		/// <para>Reduce Junctions With</para>
		/// <para><see cref="ConnectivityOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object ConnectivityOptions { get; set; } = "MAX_2_CONNECTED_JUNCTIONS";

		/// <summary>
		/// <para>Reduce if unconnected</para>
		/// <para><see cref="UnconnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object UnconnectedJunctions { get; set; } = "false";

		/// <summary>
		/// <para>Reduce if connected to a single junction</para>
		/// <para><see cref="OneConnectedJunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object OneConnectedJunction { get; set; } = "false";

		/// <summary>
		/// <para>Reduce if connected to 2 different junctions</para>
		/// <para><see cref="TwoConnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object TwoConnectedJunctions { get; set; } = "true";

		/// <summary>
		/// <para>Edge Attribute Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Connected edges constraints")]
		public object EdgesAttributes { get; set; }

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
		/// <para>Reduce Junctions With</para>
		/// </summary>
		public enum ConnectivityOptionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MAX_2_CONNECTED_JUNCTIONS")]
			[Description("MAX_2_CONNECTED_JUNCTIONS")]
			MAX_2_CONNECTED_JUNCTIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MIN_3_CONNECTED_JUNCTIONS")]
			[Description("MIN_3_CONNECTED_JUNCTIONS")]
			MIN_3_CONNECTED_JUNCTIONS,

		}

		/// <summary>
		/// <para>Reduce if unconnected</para>
		/// </summary>
		public enum UnconnectedJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_UNCONNECTED_JCT")]
			REDUCE_UNCONNECTED_JCT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_UNCONNECTED_JCT")]
			KEEP_UNCONNECTED_JCT,

		}

		/// <summary>
		/// <para>Reduce if connected to a single junction</para>
		/// </summary>
		public enum OneConnectedJunctionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_JCT_TO_1JCT")]
			REDUCE_JCT_TO_1JCT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_JCT_TO_1JCT")]
			KEEP_JCT_TO_1JCT,

		}

		/// <summary>
		/// <para>Reduce if connected to 2 different junctions</para>
		/// </summary>
		public enum TwoConnectedJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_JCT_TO_2JCTS")]
			REDUCE_JCT_TO_2JCTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_JCT_TO_2JCTS")]
			KEEP_JCT_TO_2JCTS,

		}

#endregion
	}
}
