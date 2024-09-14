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
	/// <para>Make Diagram Layer</para>
	/// <para>Make Diagram Layer</para>
	/// <para>Make a diagram layer</para>
	/// </summary>
	[Obsolete()]
	public class MakeDiagramLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// </param>
		/// <param name="NetworkDiagramName">
		/// <para>Network Diagram Name</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// </param>
		public MakeDiagramLayer(object InUtilityNetwork, object NetworkDiagramName, object OutLayer)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.NetworkDiagramName = NetworkDiagramName;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Diagram Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Diagram Layer";

		/// <summary>
		/// <para>Tool Name : MakeDiagramLayer</para>
		/// </summary>
		public override string ToolName() => "MakeDiagramLayer";

		/// <summary>
		/// <para>Tool Excute Name : un.MakeDiagramLayer</para>
		/// </summary>
		public override string ExcuteName() => "un.MakeDiagramLayer";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, NetworkDiagramName, OutLayer };

		/// <summary>
		/// <para>Input Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkDiagramName { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object OutLayer { get; set; }

	}
}
