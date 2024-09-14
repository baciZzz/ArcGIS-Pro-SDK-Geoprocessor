using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Create Diagram Layer Definition</para>
	/// <para>Create Diagram Layer Definition</para>
	/// <para>Creates a diagram layer definition for the input diagram template using the settings of the network feature layers in the active map.</para>
	/// </summary>
	public class CreateDiagramLayerDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network layer in the active map.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to modify.</para>
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
		/// <para>Tool Excute Name : nd.CreateDiagramLayerDefinition</para>
		/// </summary>
		public override string ExcuteName() => "nd.CreateDiagramLayerDefinition";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, SystemJunctions, ConnectivityAssociations, StructuralAttachments, ReductionEdges, PointSublayers, PolygonSublayers, OutUtilityNetwork, OutTemplateName, JunctionObjectPointSublayers, EdgeObjectPolylineSublayers, OverwriteAllLayers };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network layer in the active map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to modify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>System Junctions</para>
		/// <para>Specifies whether system junctions and system junction objects will be represented in the diagrams based on the specified template.</para>
		/// <para>Checked—The system junctions along the network lines and the system junction objects along the network edge objects will be represented in the diagrams by a System Junction layer and a System Junction Objects layer, respectively. This is the default.</para>
		/// <para>Unchecked—System junctions and system junction objects will not be represented in the diagrams.</para>
		/// <para><see cref="SystemJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object SystemJunctions { get; set; } = "true";

		/// <summary>
		/// <para>Connectivity Associations</para>
		/// <para>Specifies whether connectivity associations will be represented in the diagrams based on the specified template.</para>
		/// <para>Checked—Connectivity associations will be represented in the diagrams by the Connectivity Associations layer. This is the default.</para>
		/// <para>Unchecked— Connectivity associations will not be represented in the diagrams.</para>
		/// <para><see cref="ConnectivityAssociationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object ConnectivityAssociations { get; set; } = "true";

		/// <summary>
		/// <para>Structural Attachments</para>
		/// <para>Specifies whether structural attachment associations will be represented in the diagrams based on the specified template.</para>
		/// <para>Checked—Structural attachment associations will be represented in the diagrams by the Structural Attachments layer. This is the default.</para>
		/// <para>Unchecked—Structural attachment associations will not be represented in the diagrams.</para>
		/// <para><see cref="StructuralAttachmentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object StructuralAttachments { get; set; } = "true";

		/// <summary>
		/// <para>Reduction Edges</para>
		/// <para>Specifies whether reduction edges will be represented in the diagrams based on the specified template.</para>
		/// <para>Checked—Reduction edges will be represented in the diagrams by the Reduction Edges layer. This is the default.</para>
		/// <para>Unchecked—Reduction edges will not be represented in the diagrams.</para>
		/// <para><see cref="ReductionEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object ReductionEdges { get; set; } = "true";

		/// <summary>
		/// <para>Points for edges reduced as junctions or collapsed polygons</para>
		/// <para>Specifies whether layers will be added to represent container polygon features, network line features, or network edge objects as point features in the diagrams.</para>
		/// <para>The Subtype Layer column is used as follows:</para>
		/// <para>Checked—The layer will be created with subtype group layers.</para>
		/// <para>Unchecked—The layer will be created as a simple layer. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object PointSublayers { get; set; }

		/// <summary>
		/// <para>Polygons for containers</para>
		/// <para>Specifies whether layers will be added to represent container point features or container junction objects as polygon features in the diagrams.</para>
		/// <para>The Subtype Layer column is used as follows:</para>
		/// <para>Checked—The layer will be created with subtype group layers.</para>
		/// <para>Unchecked—The layer will be created as a simple layer. This is the default.</para>
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
		/// <para>Specifies whether layers will be added to represent junction objects as point features in the diagrams.</para>
		/// <para>The Subtype Layer column is used as follows:</para>
		/// <para>Checked—The layer will be created with subtype group layers.</para>
		/// <para>Unchecked—The layer will be created as a simple layer. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object JunctionObjectPointSublayers { get; set; }

		/// <summary>
		/// <para>Polylines for edge objects</para>
		/// <para>Specifies whether layers will be added to represent edge objects as polyline features in the diagrams.</para>
		/// <para>The Subtype Layer column is used as follows:</para>
		/// <para>Checked—The layer will be created with subtype group layers.</para>
		/// <para>Unchecked—The layer will be created as a simple layer. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object EdgeObjectPolylineSublayers { get; set; }

		/// <summary>
		/// <para>Overwrite all layers</para>
		/// <para>Specifies whether all existing layers under the diagram layer will be overwritten or preserved, except those in the input network map and explicitly specified additional sublayers.</para>
		/// <para>Checked—The diagram layer definition is initialized or entirely reset (overwritten) including layers in the input map and in specified settings in the Additional Sublayers section. This is the default.</para>
		/// <para>Unchecked— All existing layers under the diagram layer will be preserved except those in the input network map as well as those explicitly specified in the Additional Sublayers section.</para>
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
			/// <para>Checked—The system junctions along the network lines and the system junction objects along the network edge objects will be represented in the diagrams by a System Junction layer and a System Junction Objects layer, respectively. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para>Unchecked—System junctions and system junction objects will not be represented in the diagrams.</para>
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
			/// <para>Checked—Connectivity associations will be represented in the diagrams by the Connectivity Associations layer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para>Unchecked— Connectivity associations will not be represented in the diagrams.</para>
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
			/// <para>Checked—Structural attachment associations will be represented in the diagrams by the Structural Attachments layer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para>Unchecked—Structural attachment associations will not be represented in the diagrams.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Reduction Edges</para>
		/// </summary>
		public enum ReductionEdgesEnum 
		{
			/// <summary>
			/// <para>Checked—Reduction edges will be represented in the diagrams by the Reduction Edges layer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para>Unchecked—Reduction edges will not be represented in the diagrams.</para>
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
			/// <para>Checked—The diagram layer definition is initialized or entirely reset (overwritten) including layers in the input map and in specified settings in the Additional Sublayers section. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE_ALL")]
			OVERWRITE_ALL,

			/// <summary>
			/// <para>Unchecked— All existing layers under the diagram layer will be preserved except those in the input network map as well as those explicitly specified in the Additional Sublayers section.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
