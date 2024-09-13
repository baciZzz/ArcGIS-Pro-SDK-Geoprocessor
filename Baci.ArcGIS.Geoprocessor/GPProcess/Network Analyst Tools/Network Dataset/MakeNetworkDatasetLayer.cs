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
	/// <para>Make Network Dataset Layer</para>
	/// <para>Make Network Dataset Layer</para>
	/// <para>Creates a network dataset layer from a network  dataset.</para>
	/// </summary>
	public class MakeNetworkDatasetLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset from which to make the new layer.</para>
		/// </param>
		/// <param name="OutputLayer">
		/// <para>Output Layer</para>
		/// <para>The name of the network dataset layer to be created.</para>
		/// <para>The layer can be used as an input to any geoprocessing tool that accepts a network dataset layer as input.</para>
		/// <para>The output layer created is temporary and will not persist after the session ends. To save the layer to the disk, run the Save To Layer File tool.</para>
		/// </param>
		public MakeNetworkDatasetLayer(object InNetworkDataset, object OutputLayer)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutputLayer = OutputLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Network Dataset Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Network Dataset Layer";

		/// <summary>
		/// <para>Tool Name : MakeNetworkDatasetLayer</para>
		/// </summary>
		public override string ToolName() => "MakeNetworkDatasetLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeNetworkDatasetLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeNetworkDatasetLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDataset, OutputLayer, DrawElements! };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset from which to make the new layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The name of the network dataset layer to be created.</para>
		/// <para>The layer can be used as an input to any geoprocessing tool that accepts a network dataset layer as input.</para>
		/// <para>The output layer created is temporary and will not persist after the session ends. To save the layer to the disk, run the Save To Layer File tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Network Elements to Draw</para>
		/// <para>This parameter is not yet supported in ArcGIS Pro.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? DrawElements { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeNetworkDatasetLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
