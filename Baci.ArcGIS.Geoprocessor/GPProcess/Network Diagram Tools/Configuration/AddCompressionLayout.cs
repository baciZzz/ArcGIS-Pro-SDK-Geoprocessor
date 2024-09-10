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
	/// <para>Add Compression Layout</para>
	/// <para>Adds the Compression Layout algorithm to the layout list of the input diagram template so it automatically executes at the end of diagram buildings. This tool also presets the Compression Layout algorithm parameters for any diagram based on that template.</para>
	/// </summary>
	public class AddCompressionLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template to modify.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to modify.</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>Specifies whether the layout algorithm will automatically execute when generating diagrams based on the specified template.</para>
		/// <para>Checked—The added layout algorithm will automatically run during the generation of any diagram that is based on the Input Diagram Template parameter. This is the default.The parameter values specified for the layout algorithm are used to run the layout during diagram generation. They are also loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
		/// <para>Unchecked—All the parameter values currently specified for the added layout algorithm will be loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		public AddCompressionLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Compression Layout</para>
		/// </summary>
		public override string DisplayName() => "Add Compression Layout";

		/// <summary>
		/// <para>Tool Name : AddCompressionLayout</para>
		/// </summary>
		public override string ToolName() => "AddCompressionLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddCompressionLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddCompressionLayout";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved, GroupingDistanceAbsolute, VerticesRemovalRule, OutUtilityNetwork, OutTemplateName };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template to modify.</para>
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
		/// <para>Active</para>
		/// <para>Specifies whether the layout algorithm will automatically execute when generating diagrams based on the specified template.</para>
		/// <para>Checked—The added layout algorithm will automatically run during the generation of any diagram that is based on the Input Diagram Template parameter. This is the default.The parameter values specified for the layout algorithm are used to run the layout during diagram generation. They are also loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
		/// <para>Unchecked—All the parameter values currently specified for the added layout algorithm will be loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>Specifies how containers will be processed by the Compression layout algorithm.</para>
		/// <para>Checked—The Compression layout algorithm will execute on the top graph of the diagram so containers are preserved. This is the default.</para>
		/// <para>Unchecked—The Compression layout algorithm will execute on both content and noncontent features in the diagram.</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Distance for Grouping</para>
		/// <para>The grouping distance is used to determine whether two connected junctions are close enough to be considered part of the same junctions group. A junctions group represents many junctions that are moved as a group during execution. The group can contain both junctions and containers. To group two junctions, they must also be connected in the diagram by an edge. The default is 20 units in the diagram's coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object GroupingDistanceAbsolute { get; set; } = "20 Unknown";

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// <para>Specifies which vertices along edges in the diagram will be removed.</para>
		/// <para>All vertices—All vertices on all edges will be removed from the diagram.</para>
		/// <para>All outer vertices—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, a vertex is added at the intersection of the edge and container polygon. This is the default.</para>
		/// <para>All outer vertices except the first one—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, the first (or last) outside vertex is preserved on edges that intersect a container polygon. A vertex is automatically inserted at the intersection of the edges and container polygons.</para>
		/// <para><see cref="VerticesRemovalRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object VerticesRemovalRule { get; set; } = "OUTER";

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
			/// <para>Checked—The added layout algorithm will automatically run during the generation of any diagram that is based on the Input Diagram Template parameter. This is the default.The parameter values specified for the layout algorithm are used to run the layout during diagram generation. They are also loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para>Unchecked—All the parameter values currently specified for the added layout algorithm will be loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
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
			/// <para>Checked—The Compression layout algorithm will execute on the top graph of the diagram so containers are preserved. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para>Unchecked—The Compression layout algorithm will execute on both content and noncontent features in the diagram.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_CONTAINERS")]
			IGNORE_CONTAINERS,

		}

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// </summary>
		public enum VerticesRemovalRuleEnum 
		{
			/// <summary>
			/// <para>All vertices—All vertices on all edges will be removed from the diagram.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All vertices")]
			All_vertices,

			/// <summary>
			/// <para>All outer vertices—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, a vertex is added at the intersection of the edge and container polygon. This is the default.</para>
			/// </summary>
			[GPValue("OUTER")]
			[Description("All outer vertices")]
			All_outer_vertices,

			/// <summary>
			/// <para>All outer vertices except the first one—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, the first (or last) outside vertex is preserved on edges that intersect a container polygon. A vertex is automatically inserted at the intersection of the edges and container polygons.</para>
			/// </summary>
			[GPValue("OUTER_EXCEPT_FIRST")]
			[Description("All outer vertices except the first one")]
			All_outer_vertices_except_the_first_one,

		}

#endregion
	}
}
