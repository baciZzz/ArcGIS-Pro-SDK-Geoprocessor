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
	/// <para>Alter Diagram Properties</para>
	/// <para>Alter Diagram Properties</para>
	/// <para>Alters properties for a stored network diagram.</para>
	/// </summary>
	public class AlterDiagramProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The stored network diagram to alter.</para>
		/// </param>
		public AlterDiagramProperties(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Diagram Properties</para>
		/// </summary>
		public override string DisplayName() => "Alter Diagram Properties";

		/// <summary>
		/// <para>Tool Name : AlterDiagramProperties</para>
		/// </summary>
		public override string ToolName() => "AlterDiagramProperties";

		/// <summary>
		/// <para>Tool Excute Name : nd.AlterDiagramProperties</para>
		/// </summary>
		public override string ExcuteName() => "nd.AlterDiagramProperties";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, OutName!, AccessRightType!, Tags!, OutNetworkDiagramLayer! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The stored network diagram to alter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>The new name for the input network diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutName { get; set; }

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// <para>Specifies the access right level of the input diagram.</para>
		/// <para>Public—Other users will have full access to the diagram; everyone can see, edit, update, and overwrite the diagram. However, no one except the diagram owner and the portal utility network owner—in the case of diagrams related to a utility network in an enterprise geodatabase—can use the Alter Diagram Properties tool to change the access right level. This is the default.</para>
		/// <para>Protected—Other users will have read-only access to the diagram. They cannot edit, update, or overwrite the diagram.</para>
		/// <para>Private— Other users will not have access to the diagram. The corresponding diagram item will be hidden from other users in the Find Diagrams pane.</para>
		/// <para><see cref="AccessRightTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AccessRightType { get; set; } = "PUBLIC";

		/// <summary>
		/// <para>Tags (optional)</para>
		/// <para>One or several tags that will help find the stored diagram. These tags can be used in the Find Diagrams pane.</para>
		/// <para>To add several tags, use the number sign (#) to separate each tag. This also allows a more thorough and efficient diagram search.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; } = " ";

		/// <summary>
		/// <para>Altered Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// </summary>
		public enum AccessRightTypeEnum 
		{
			/// <summary>
			/// <para>Public—Other users will have full access to the diagram; everyone can see, edit, update, and overwrite the diagram. However, no one except the diagram owner and the portal utility network owner—in the case of diagrams related to a utility network in an enterprise geodatabase—can use the Alter Diagram Properties tool to change the access right level. This is the default.</para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("Public")]
			Public,

			/// <summary>
			/// <para>Protected—Other users will have read-only access to the diagram. They cannot edit, update, or overwrite the diagram.</para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("Protected")]
			Protected,

			/// <summary>
			/// <para>Private— Other users will not have access to the diagram. The corresponding diagram item will be hidden from other users in the Find Diagrams pane.</para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("Private")]
			Private,

		}

#endregion
	}
}
