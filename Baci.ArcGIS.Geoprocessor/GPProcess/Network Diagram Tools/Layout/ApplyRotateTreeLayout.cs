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
	/// <para>Apply Rotate Tree Layout</para>
	/// <para>Apply Rotate Tree Layout</para>
	/// <para>Rotates the tree or trees related to pivot junctions currently set up in a diagram to the specified angle.</para>
	/// </summary>
	public class ApplyRotateTreeLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ApplyRotateTreeLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Rotate Tree Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Rotate Tree Layout";

		/// <summary>
		/// <para>Tool Name : ApplyRotateTreeLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyRotateTreeLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyRotateTreeLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyRotateTreeLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved!, RotationAngle!, OutNetworkDiagramLayer!, RunAsync!, RotateJunction! };

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
		public object? AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Angle</para>
		/// <para>The angle in degrees that will be used to rotate the tree. The default is 45 degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? RotationAngle { get; set; } = "45";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>Specifies whether the layout algorithm will run asynchronously or synchronously on the server.</para>
		/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out (for example, Partial Overlapping Edges) and applying to large diagrams (more than 25,000 features).</para>
		/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service default time-out value of 600 seconds. This is the default.</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? RunAsync { get; set; } = "false";

		/// <summary>
		/// <para>Rotate junction symbols with the same angle</para>
		/// <para>Specifies whether the Angle parameter value is added to the value of the rotation field for each processed diagram junction.</para>
		/// <para>Checked—The rotation field value is updated for each processed diagram junction.</para>
		/// <para>Unchecked—The rotation field value is not updated. This is the default.</para>
		/// <para><see cref="RotateJunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RotateJunction { get; set; } = "false";

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
		/// <para>Run in asynchronous mode on the server</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out (for example, Partial Overlapping Edges) and applying to large diagrams (more than 25,000 features).</para>
			/// </summary>
			[GPValue("true")]
			[Description("RUN_ASYNCHRONOUSLY")]
			RUN_ASYNCHRONOUSLY,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service default time-out value of 600 seconds. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("RUN_SYNCHRONOUSLY")]
			RUN_SYNCHRONOUSLY,

		}

		/// <summary>
		/// <para>Rotate junction symbols with the same angle</para>
		/// </summary>
		public enum RotateJunctionEnum 
		{
			/// <summary>
			/// <para>Checked—The rotation field value is updated for each processed diagram junction.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROTATE")]
			ROTATE,

			/// <summary>
			/// <para>Unchecked—The rotation field value is not updated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_ROTATE")]
			DO_NOT_ROTATE,

		}

#endregion
	}
}
