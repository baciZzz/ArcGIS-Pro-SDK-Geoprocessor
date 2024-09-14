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
	/// <para>Add Diagram Template</para>
	/// <para>Add Diagram Template</para>
	/// <para>Adds a new diagram template to a network. Both a network diagram rule and layout definitions file (.ndbd) and a network diagram layer definition file (.ndld) can be imported.</para>
	/// </summary>
	public class AddDiagramTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network to which the template will be added.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Diagram Template  Name</para>
		/// <para>The name of the output diagram template.</para>
		/// </param>
		public AddDiagramTemplate(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Diagram Template</para>
		/// </summary>
		public override string DisplayName() => "Add Diagram Template";

		/// <summary>
		/// <para>Tool Name : AddDiagramTemplate</para>
		/// </summary>
		public override string ToolName() => "AddDiagramTemplate";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddDiagramTemplate</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddDiagramTemplate";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, NdbdFile!, NdldFile!, OutUtilityNetwork!, OutTemplateName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network to which the template will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Diagram Template  Name</para>
		/// <para>The name of the output diagram template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Rule and Layout Definitions File</para>
		/// <para>The network diagram rule and layout definitions file (.ndbd) to import. This file can be created using the Export Diagram Template Definitions tool on an existing template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndbd")]
		public object? NdbdFile { get; set; }

		/// <summary>
		/// <para>Diagram Layer Definition File</para>
		/// <para>The diagram layer definition file (.ndld) to import. This file can be created using the Export Diagram Template Definitions or Export Diagram Layer Definition tool on an existing template.</para>
		/// <para>When this parameter is not specified or loads an empty .ndld file, a default diagram layer definition is systematically initialized on the input diagram template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndld")]
		public object? NdldFile { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutTemplateName { get; set; }

	}
}
