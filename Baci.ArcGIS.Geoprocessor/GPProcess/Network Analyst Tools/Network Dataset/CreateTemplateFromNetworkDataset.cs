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
	/// <para>Create Template From Network Dataset</para>
	/// <para>Creates a file containing the schema of an existing network dataset. This template file can then be used to create a new network dataset with the same schema.</para>
	/// </summary>
	public class CreateTemplateFromNetworkDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataset">
		/// <para>Network Dataset</para>
		/// <para>The network dataset whose schema will be written to the output template file.</para>
		/// </param>
		/// <param name="OutputNetworkDatasetTemplate">
		/// <para>Output Network Dataset Template</para>
		/// <para>The output file (.xml) that will contain the schema of the input network dataset.</para>
		/// </param>
		public CreateTemplateFromNetworkDataset(object NetworkDataset, object OutputNetworkDatasetTemplate)
		{
			this.NetworkDataset = NetworkDataset;
			this.OutputNetworkDatasetTemplate = OutputNetworkDatasetTemplate;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Template From Network Dataset</para>
		/// </summary>
		public override string DisplayName => "Create Template From Network Dataset";

		/// <summary>
		/// <para>Tool Name : CreateTemplateFromNetworkDataset</para>
		/// </summary>
		public override string ToolName => "CreateTemplateFromNetworkDataset";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateTemplateFromNetworkDataset</para>
		/// </summary>
		public override string ExcuteName => "na.CreateTemplateFromNetworkDataset";

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
		public override object[] Parameters => new object[] { NetworkDataset, OutputNetworkDatasetTemplate };

		/// <summary>
		/// <para>Network Dataset</para>
		/// <para>The network dataset whose schema will be written to the output template file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object NetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Network Dataset Template</para>
		/// <para>The output file (.xml) that will contain the schema of the input network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputNetworkDatasetTemplate { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTemplateFromNetworkDataset SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
