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
	/// <para>Add Force Directed Layout</para>
	/// <para>Add a force directed layout to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddForceDirectedLayout : AbstractGPProcess
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
		public AddForceDirectedLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Force Directed Layout</para>
		/// </summary>
		public override string DisplayName() => "Add Force Directed Layout";

		/// <summary>
		/// <para>Tool Name : AddForceDirectedLayout</para>
		/// </summary>
		public override string ToolName() => "AddForceDirectedLayout";

		/// <summary>
		/// <para>Tool Excute Name : un.AddForceDirectedLayout</para>
		/// </summary>
		public override string ExcuteName() => "un.AddForceDirectedLayout";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved, IterationsNumber, RepelFactor, DegreeFreedom, OutUtilityNetwork, OutTemplateName, BreakpointPosition, EdgeDisplayType };

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
		/// <para>Preserve container layout</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object IterationsNumber { get; set; } = "20";

		/// <summary>
		/// <para>Repel Factor</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RepelFactor { get; set; } = "1";

		/// <summary>
		/// <para>Degree of Freedom</para>
		/// <para><see cref="DegreeFreedomEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DegreeFreedom { get; set; } = "LOW";

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
		/// <para>Break Point Relative Position (%)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para><see cref="EdgeDisplayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeDisplayType { get; set; } = "REGULAR_EDGES";

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
		/// <para>Preserve container layout</para>
		/// </summary>
		public enum AreContainersPreservedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_CONTAINERS")]
			IGNORE_CONTAINERS,

		}

		/// <summary>
		/// <para>Degree of Freedom</para>
		/// </summary>
		public enum DegreeFreedomEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("LOW")]
			[Description("LOW")]
			LOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("MEDIUM")]
			MEDIUM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("HIGH")]
			HIGH,

		}

		/// <summary>
		/// <para>Edge Display Type</para>
		/// </summary>
		public enum EdgeDisplayTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("REGULAR_EDGES")]
			[Description("REGULAR_EDGES")]
			REGULAR_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CURVED_EDGES")]
			[Description("CURVED_EDGES")]
			CURVED_EDGES,

		}

#endregion
	}
}
