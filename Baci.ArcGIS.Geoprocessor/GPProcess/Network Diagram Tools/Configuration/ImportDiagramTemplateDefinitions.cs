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
	/// <para>Import Diagram Template Definitions</para>
	/// <para>Imports a network diagram rule and layout definitions file (.ndbd), a network diagram layer definition file (.ndld), or both into an existing template.</para>
	/// </summary>
	public class ImportDiagramTemplateDefinitions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template that will be modified.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template onto which the definitions will be imported.</para>
		/// </param>
		public ImportDiagramTemplateDefinitions(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Diagram Template Definitions</para>
		/// </summary>
		public override string DisplayName => "Import Diagram Template Definitions";

		/// <summary>
		/// <para>Tool Name : ImportDiagramTemplateDefinitions</para>
		/// </summary>
		public override string ToolName => "ImportDiagramTemplateDefinitions";

		/// <summary>
		/// <para>Tool Excute Name : nd.ImportDiagramTemplateDefinitions</para>
		/// </summary>
		public override string ExcuteName => "nd.ImportDiagramTemplateDefinitions";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, NdbdFile!, NdldFile!, OutUtilityNetwork!, OutTemplateName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template that will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template onto which the definitions will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Rule and Layout Definitions File</para>
		/// <para>The network diagram rule and layout definitions file (.ndbd) to import.</para>
		/// <para>This file is the result of the execution of the Export Diagram Template Definitions tool on an existing template.</para>
		/// <para>At least one of the two input file parameters must be completed; that is, either the network diagram rule and layout definitions file (.ndbd) or the network diagram layer definition file (.ndld) must be completed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? NdbdFile { get; set; }

		/// <summary>
		/// <para>Diagram Layer Definition File</para>
		/// <para>The network diagram layer definition file (.ndld) to import.</para>
		/// <para>This file is the result of the execution of the Export Diagram Template Definitions or Export Diagram Layer Definition geoprocessing tool on an existing template.</para>
		/// <para>At least one of the two input file parameters must be completed; that is, either the network diagram rule and layout definitions file (.ndbd) or the network diagram layer definition file (.ndld) must be completed.</para>
		/// <para>When a diagram layer definition does not yet exist for the input diagram template and this parameter is not specified or loads an empty .ndld file, a default diagram layer definition is systematically initialized on the template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
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
