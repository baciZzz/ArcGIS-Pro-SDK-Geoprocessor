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
	/// <para>Create Diagram</para>
	/// <para>Create Diagram</para>
	/// <para>Creates a temporary network diagram from network elements currently selected in the active map or from layers created from a Python script.</para>
	/// </summary>
	public class CreateDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network from which the diagram will be created.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Template Name</para>
		/// <para>The name of the template that will be used to create the diagram.</para>
		/// </param>
		public CreateDiagram(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Diagram</para>
		/// </summary>
		public override string DisplayName() => "Create Diagram";

		/// <summary>
		/// <para>Tool Name : CreateDiagram</para>
		/// </summary>
		public override string ToolName() => "CreateDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.CreateDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.CreateDiagram";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, Features!, OutUtilityNetwork!, OutName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network from which the diagram will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Template Name</para>
		/// <para>The name of the template that will be used to create the diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Features</para>
		/// <para>One or more feature layers that will be used as input for diagram generation.</para>
		/// <para>When feature layers are specified and network elements are selected in the active map, the selected elements set is ignored and all the features in the specified layers are used as input for diagram creation.</para>
		/// <para>When no feature layers are specified, the process searches for the network elements selected in the active map and creates the diagram from those elements.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Features { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutName { get; set; }

	}
}
