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
	/// <para>Extend Diagram</para>
	/// <para>Extends a network diagram one network element level based on network connectivity or traversability or on containment or structural attachment associations.</para>
	/// </summary>
	public class ExtendDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to extend.</para>
		/// </param>
		public ExtendDiagram(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Extend Diagram</para>
		/// </summary>
		public override string DisplayName => "Extend Diagram";

		/// <summary>
		/// <para>Tool Name : ExtendDiagram</para>
		/// </summary>
		public override string ToolName => "ExtendDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.ExtendDiagram</para>
		/// </summary>
		public override string ExcuteName => "nd.ExtendDiagram";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkDiagramLayer, IgnoreTraversability, OutNetworkDiagramLayer, ExtensionType };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to extend.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Ignore traversability</para>
		/// <para>Specifies whether traversability or connectivity is used to extend the diagram.This parameter was deprecated at ArcGIS Pro 2.2. It is systematically ignored regardless of its value when the extension_type parameter is specified. To maintain compatibility with models and Python scripts written at ArcGIS Pro 2.1, it remains enabled when the extension_type parameter is not specified.</para>
		/// <para>IGNORE_TRAVERSABILITY—The traversability of the network is ignored. This is the default.</para>
		/// <para>HONOR_TRAVERSABILITY —The traversability of the network is honored.</para>
		/// <para><see cref="IgnoreTraversabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreTraversability { get; set; } = "true";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Extension Type</para>
		/// <para>Specifies how the diagram will be extended.</para>
		/// <para>By connectivity—Extends the network diagram one network element level based on network connectivity. This is the default.</para>
		/// <para>By traversability—Extends the network diagram one network element level based on network traversability.</para>
		/// <para>By attachment—Extends the network diagram one network element level based on structural attachment associations.</para>
		/// <para>By containment—Extends the network diagram one network element level based on containment associations.</para>
		/// <para><see cref="ExtensionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExtensionType { get; set; } = "BY_CONNECTIVITY";

		#region InnerClass

		/// <summary>
		/// <para>Ignore traversability</para>
		/// </summary>
		public enum IgnoreTraversabilityEnum 
		{
			/// <summary>
			/// <para>IGNORE_TRAVERSABILITY—The traversability of the network is ignored. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_TRAVERSABILITY")]
			IGNORE_TRAVERSABILITY,

			/// <summary>
			/// <para>HONOR_TRAVERSABILITY —The traversability of the network is honored.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HONOR_TRAVERSABILITY")]
			HONOR_TRAVERSABILITY,

		}

		/// <summary>
		/// <para>Extension Type</para>
		/// </summary>
		public enum ExtensionTypeEnum 
		{
			/// <summary>
			/// <para>By connectivity—Extends the network diagram one network element level based on network connectivity. This is the default.</para>
			/// </summary>
			[GPValue("BY_CONNECTIVITY")]
			[Description("By connectivity")]
			By_connectivity,

			/// <summary>
			/// <para>By traversability—Extends the network diagram one network element level based on network traversability.</para>
			/// </summary>
			[GPValue("BY_TRAVERSABILITY")]
			[Description("By traversability")]
			By_traversability,

			/// <summary>
			/// <para>By attachment—Extends the network diagram one network element level based on structural attachment associations.</para>
			/// </summary>
			[GPValue("BY_ATTACHMENT")]
			[Description("By attachment")]
			By_attachment,

			/// <summary>
			/// <para>By containment—Extends the network diagram one network element level based on containment associations.</para>
			/// </summary>
			[GPValue("BY_CONTAINMENT")]
			[Description("By containment")]
			By_containment,

		}

#endregion
	}
}
