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
	/// <para>Create Diagram Layer Definition</para>
	/// <para>Create or overwwrite a diagram template layer definitions</para>
	/// </summary>
	[Obsolete()]
	public class CreateDiagramLayerDefinition : AbstractGPProcess
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
		public CreateDiagramLayerDefinition(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Diagram Layer Definition</para>
		/// </summary>
		public override string DisplayName() => "Create Diagram Layer Definition";

		/// <summary>
		/// <para>Tool Name : CreateDiagramLayerDefinition</para>
		/// </summary>
		public override string ToolName() => "CreateDiagramLayerDefinition";

		/// <summary>
		/// <para>Tool Excute Name : un.CreateDiagramLayerDefinition</para>
		/// </summary>
		public override string ExcuteName() => "un.CreateDiagramLayerDefinition";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, SystemJunctions, ConnectivityAssociations, StructuralAttachments, ReductionEdges, PointSublayers, PolygonSublayers, OutUtilityNetwork, OutTemplateName, JunctionObjectPointSublayers, EdgeObjectPolylineSublayers, OverwriteAllLayers };

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
		/// <para>System Junctions</para>
		/// <para><see cref="SystemJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object SystemJunctions { get; set; } = "true";

		/// <summary>
		/// <para>Connectivity Associations</para>
		/// <para><see cref="ConnectivityAssociationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object ConnectivityAssociations { get; set; } = "true";

		/// <summary>
		/// <para>Structural Attachments</para>
		/// <para><see cref="StructuralAttachmentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object StructuralAttachments { get; set; } = "true";

		/// <summary>
		/// <para>Reduction Edge</para>
		/// <para><see cref="ReductionEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object ReductionEdges { get; set; } = "true";

		/// <summary>
		/// <para>Points for edges reduced as junctions and collapsed polygons</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object PointSublayers { get; set; }

		/// <summary>
		/// <para>Polygons for containers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object PolygonSublayers { get; set; }

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
		/// <para>Points for junction objects</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object JunctionObjectPointSublayers { get; set; }

		/// <summary>
		/// <para>Polylines for edge objects</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object EdgeObjectPolylineSublayers { get; set; }

		/// <summary>
		/// <para>Overwrite all layers</para>
		/// <para><see cref="OverwriteAllLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OverwriteAllLayers { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>System Junctions</para>
		/// </summary>
		public enum SystemJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Connectivity Associations</para>
		/// </summary>
		public enum ConnectivityAssociationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Structural Attachments</para>
		/// </summary>
		public enum StructuralAttachmentsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Reduction Edge</para>
		/// </summary>
		public enum ReductionEdgesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Overwrite all layers</para>
		/// </summary>
		public enum OverwriteAllLayersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE_ALL")]
			OVERWRITE_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
