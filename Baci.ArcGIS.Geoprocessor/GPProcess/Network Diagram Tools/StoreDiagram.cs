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
	/// <para>Store Diagram</para>
	/// <para>Store Diagram</para>
	/// <para>Stores a temporary network diagram in the database. Access rights and tags can be assigned to control security and searchability of the diagram.</para>
	/// </summary>
	public class StoreDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The temporary network diagram layer to be stored.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Network Diagram Name</para>
		/// <para>The name of the output network diagram.</para>
		/// </param>
		public StoreDiagram(object InNetworkDiagramLayer, object OutName)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Store Diagram</para>
		/// </summary>
		public override string DisplayName() => "Store Diagram";

		/// <summary>
		/// <para>Tool Name : StoreDiagram</para>
		/// </summary>
		public override string ToolName() => "StoreDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.StoreDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.StoreDiagram";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, OutName, AccessRightType, Tags };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The temporary network diagram layer to be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>The name of the output network diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object OutName { get; set; }

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
		public object AccessRightType { get; set; } = "PUBLIC";

		/// <summary>
		/// <para>Tags (optional)</para>
		/// <para>Tags help with querying the stored diagram using the Find Diagrams pane.</para>
		/// <para>Use the # character to separate each tag and aid in efficient diagram searches.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

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
