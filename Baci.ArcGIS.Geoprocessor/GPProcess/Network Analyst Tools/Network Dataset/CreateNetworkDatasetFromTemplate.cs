using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Create Network Dataset From Template</para>
	/// <para>Creates a new network dataset with the schema contained in the input template file (.xml). All the feature classes and input tables required for creating the network dataset must already exist before this tool is executed.</para>
	/// </summary>
	public class CreateNetworkDatasetFromTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDatasetTemplate">
		/// <para>Network Dataset Template</para>
		/// <para>The template file (.xml) created by the Create Template From Network Dataset tool containing the schema of the output network dataset to be created.</para>
		/// </param>
		/// <param name="OutputFeatureDataset">
		/// <para>Output Feature Dataset</para>
		/// <para>The feature dataset containing the feature classes that will take part in the network dataset being created. The network will be created in this dataset using the name specified in the network dataset template.</para>
		/// </param>
		public CreateNetworkDatasetFromTemplate(object NetworkDatasetTemplate, object OutputFeatureDataset)
		{
			this.NetworkDatasetTemplate = NetworkDatasetTemplate;
			this.OutputFeatureDataset = OutputFeatureDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Network Dataset From Template</para>
		/// </summary>
		public override string DisplayName => "Create Network Dataset From Template";

		/// <summary>
		/// <para>Tool Name : CreateNetworkDatasetFromTemplate</para>
		/// </summary>
		public override string ToolName => "CreateNetworkDatasetFromTemplate";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateNetworkDatasetFromTemplate</para>
		/// </summary>
		public override string ExcuteName => "na.CreateNetworkDatasetFromTemplate";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { NetworkDatasetTemplate, OutputFeatureDataset, OutputNetwork };

		/// <summary>
		/// <para>Network Dataset Template</para>
		/// <para>The template file (.xml) created by the Create Template From Network Dataset tool containing the schema of the output network dataset to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object NetworkDatasetTemplate { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// <para>The feature dataset containing the feature classes that will take part in the network dataset being created. The network will be created in this dataset using the name specified in the network dataset template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object OutputFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DENetworkDataset()]
		public object OutputNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateNetworkDatasetFromTemplate SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
