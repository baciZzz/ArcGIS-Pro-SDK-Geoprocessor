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
	/// <para>Add Diagram Feature Capability By Attribute Rule</para>
	/// <para>Add Diagram Feature Capability By Attribute Rule</para>
	/// <para>Add a diagram feature capability by attribute rule to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddDiagramFeatureCapabilityByAttributeRule : AbstractGPProcess
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
		/// <param name="NetworkSource">
		/// <para>Network Source</para>
		/// </param>
		/// <param name="WhereClause">
		/// <para>Expression</para>
		/// </param>
		/// <param name="Capability">
		/// <para>Capability</para>
		/// <para><see cref="CapabilityEnum"/></para>
		/// </param>
		public AddDiagramFeatureCapabilityByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object NetworkSource, object WhereClause, object Capability)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.NetworkSource = NetworkSource;
			this.WhereClause = WhereClause;
			this.Capability = Capability;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Diagram Feature Capability By Attribute Rule</para>
		/// </summary>
		public override string DisplayName() => "Add Diagram Feature Capability By Attribute Rule";

		/// <summary>
		/// <para>Tool Name : AddDiagramFeatureCapabilityByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddDiagramFeatureCapabilityByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddDiagramFeatureCapabilityByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "un.AddDiagramFeatureCapabilityByAttributeRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, NetworkSource, WhereClause, Capability, Description!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Network Source</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Capability</para>
		/// <para><see cref="CapabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Capability { get; set; } = "PREVENT_TO_COLLAPSE_CONTAINER";

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
		/// <para>Capability</para>
		/// </summary>
		public enum CapabilityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ALLOW_TO_COLLAPSE_CONTAINER")]
			[Description("ALLOW_TO_COLLAPSE_CONTAINER")]
			ALLOW_TO_COLLAPSE_CONTAINER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PREVENT_TO_COLLAPSE_CONTAINER")]
			[Description("PREVENT_TO_COLLAPSE_CONTAINER")]
			PREVENT_TO_COLLAPSE_CONTAINER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ALLOW_TO_REDUCE_JUNCTION")]
			[Description("ALLOW_TO_REDUCE_JUNCTION")]
			ALLOW_TO_REDUCE_JUNCTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PREVENT_TO_REDUCE_JUNCTION")]
			[Description("PREVENT_TO_REDUCE_JUNCTION")]
			PREVENT_TO_REDUCE_JUNCTION,

		}

#endregion
	}
}
