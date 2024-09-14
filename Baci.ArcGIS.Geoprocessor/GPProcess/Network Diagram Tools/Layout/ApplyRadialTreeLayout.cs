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
	/// <para>Apply Radial Tree Layout</para>
	/// <para>Apply Radial Tree Layout</para>
	/// <para>Arranges diagram features hierarchically and places them in a radial tree.</para>
	/// </summary>
	public class ApplyRadialTreeLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ApplyRadialTreeLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Radial Tree Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Radial Tree Layout";

		/// <summary>
		/// <para>Tool Name : ApplyRadialTreeLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyRadialTreeLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyRadialTreeLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyRadialTreeLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, IsUnitAbsolute, InitialRadiusAbsolute, InitialRadiusProportional, DisjoinedGraphAbsolute, DisjoinedGraphProportional, RadiusFactor, OutNetworkDiagramLayer, RunAsync };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>Specifies how the algorithm will process containers.</para>
		/// <para>Checked—The layout algorithm will execute on the top graph of the diagram so containers are preserved.</para>
		/// <para>Unchecked—The layout algorithm will execute on both content and noncontent features in the diagram. This is the default.</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// <para>Specifies how parameters representing distances will be interpreted.</para>
		/// <para>Checked—The layout algorithm will interpret any distance values as linear units.</para>
		/// <para>Unchecked—The layout algorithm will interpret any distance values as relative units to an estimation of the average of the junction sizes in the current diagram extent. This is the default.</para>
		/// <para><see cref="IsUnitAbsoluteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsUnitAbsolute { get; set; } = "false";

		/// <summary>
		/// <para>Initial Radius</para>
		/// <para>The radius of the first concentric circle whose center is the radial tree root junction—that is, the radius of the circle around which the diagram junctions belonging to the first hierarchical level are placed. The default is 5 in the units of the diagram's coordinate system. This parameter can only be used with absolute units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object InitialRadiusAbsolute { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Initial Radius</para>
		/// <para>The radius of the first concentric circle whose center is the radial tree root junction—that is, the radius of the circle around which the diagram junctions belonging to the first hierarchical level are placed. The default is 5. This parameter can only be used with proportional units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object InitialRadiusProportional { get; set; } = "5";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>The minimum spacing that will separate features belonging to disjoined graphs when the diagram contains such graphs. This parameter is used with absolute units. The default is 4 in the units of the diagram's coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object DisjoinedGraphAbsolute { get; set; } = "10 Unknown";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>The minimum spacing that will separate features belonging to disjoined graphs when the diagram contains such graphs. This parameter is used with proportional units. The default is 4.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DisjoinedGraphProportional { get; set; } = "10";

		/// <summary>
		/// <para>Radius Factor</para>
		/// <para>The multiplicative factor used to increase or decrease the radius of each concentric circle. It is also the distance that separates each concentric circle related to a hierarchical level. When using a radius factor less than 1, the distance that separates the diagram junctions belonging to the (n) hierarchical level and the (n+1) hierarchical level progressively decreases. With a factor greater than 1, the distance between the hierarchical levels increases progressively. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RadiusFactor { get; set; } = "1";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>Specifies whether the layout algorithm will run asynchronously or synchronously on the server.</para>
		/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out—for example, Partial Overlapping Edges—and applying to large diagrams—more than 25,000 features.</para>
		/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service time-out: 600 seconds by default. This is the default.</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object RunAsync { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Preserve container layout</para>
		/// </summary>
		public enum AreContainersPreservedEnum 
		{
			/// <summary>
			/// <para>Checked—The layout algorithm will execute on the top graph of the diagram so containers are preserved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will execute on both content and noncontent features in the diagram. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_CONTAINERS")]
			IGNORE_CONTAINERS,

		}

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// </summary>
		public enum IsUnitAbsoluteEnum 
		{
			/// <summary>
			/// <para>Checked—The layout algorithm will interpret any distance values as linear units.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ABSOLUTE_UNIT")]
			ABSOLUTE_UNIT,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will interpret any distance values as relative units to an estimation of the average of the junction sizes in the current diagram extent. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PROPORTIONAL_UNIT")]
			PROPORTIONAL_UNIT,

		}

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out—for example, Partial Overlapping Edges—and applying to large diagrams—more than 25,000 features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RUN_ASYNCHRONOUSLY")]
			RUN_ASYNCHRONOUSLY,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service time-out: 600 seconds by default. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("RUN_SYNCHRONOUSLY")]
			RUN_SYNCHRONOUSLY,

		}

#endregion
	}
}
