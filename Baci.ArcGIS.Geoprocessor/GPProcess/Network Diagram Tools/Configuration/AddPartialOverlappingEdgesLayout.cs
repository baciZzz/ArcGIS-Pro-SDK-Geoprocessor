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
	/// <para>Add Partial Overlapping Edges Layout</para>
	/// <para>Adds the Partial Overlapping Edges Layout algorithm to the list of layouts to be automatically chained at the end of the building of diagrams based on a given template. This tool also presets the Partial Overlapping Edges Layout algorithm parameters for any diagram based on that template.</para>
	/// </summary>
	public class AddPartialOverlappingEdgesLayout : AbstractGPProcess
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
		/// <param name="BufferWidthAbsolute">
		/// <para>Buffer Width</para>
		/// <para>The width of the buffer zone in which to search for collinear edge segments.</para>
		/// </param>
		/// <param name="OffsetAbsolute">
		/// <para>Offset</para>
		/// <para>The distance that will separate the detected edge segments.</para>
		/// </param>
		public AddPartialOverlappingEdgesLayout(object InUtilityNetwork, object TemplateName, object IsActive, object BufferWidthAbsolute, object OffsetAbsolute)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.BufferWidthAbsolute = BufferWidthAbsolute;
			this.OffsetAbsolute = OffsetAbsolute;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Partial Overlapping Edges Layout</para>
		/// </summary>
		public override string DisplayName() => "Add Partial Overlapping Edges Layout";

		/// <summary>
		/// <para>Tool Name : AddPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ToolName() => "AddPartialOverlappingEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddPartialOverlappingEdgesLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, BufferWidthAbsolute, OffsetAbsolute, OptimizeEdges, OutUtilityNetwork, OutTemplateName };

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
		/// <para>Buffer Width</para>
		/// <para>The width of the buffer zone in which to search for collinear edge segments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BufferWidthAbsolute { get; set; } = "1 Unknown";

		/// <summary>
		/// <para>Offset</para>
		/// <para>The distance that will separate the detected edge segments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object OffsetAbsolute { get; set; } = "0.5 Unknown";

		/// <summary>
		/// <para>Optimize edges</para>
		/// <para>Specifies how segments will be placed along edges:</para>
		/// <para>Checked—The placement of segments will be optimized in each set of collinear segments. This is done by focusing on their connections instead of their positions. Segments that cross each other can be repositioned so they do not cross.</para>
		/// <para>Unchecked—The initial position of each segment will be maintained in the collinear segment set and crossings will be preserved. This is the default.</para>
		/// <para><see cref="OptimizeEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OptimizeEdges { get; set; } = "false";

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
		/// <para>Optimize edges</para>
		/// </summary>
		public enum OptimizeEdgesEnum 
		{
			/// <summary>
			/// <para>Checked—The placement of segments will be optimized in each set of collinear segments. This is done by focusing on their connections instead of their positions. Segments that cross each other can be repositioned so they do not cross.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OPTIMIZE_EDGES")]
			OPTIMIZE_EDGES,

			/// <summary>
			/// <para>Unchecked—The initial position of each segment will be maintained in the collinear segment set and crossings will be preserved. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_OPTIMIZE_EDGES")]
			DO_NOT_OPTIMIZE_EDGES,

		}

#endregion
	}
}
