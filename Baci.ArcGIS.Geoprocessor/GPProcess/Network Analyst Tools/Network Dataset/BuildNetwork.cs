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
	/// <para>Build Network</para>
	/// <para>Reconstructs the network connectivity and attribute information of a network dataset. The network dataset must be rebuilt after edits are made to the attributes or the features of a participating source feature class. After the source features are edited, the tool establishes the network connectivity only in the areas that have been edited to speed up the build process; however, when the network attributes are edited, the entire extent of the network dataset is rebuilt. This may be a slow operation on a large network dataset.</para>
	/// </summary>
	public class BuildNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset to be built.</para>
		/// </param>
		public BuildNetwork(object InNetworkDataset)
		{
			this.InNetworkDataset = InNetworkDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Network</para>
		/// </summary>
		public override string DisplayName => "Build Network";

		/// <summary>
		/// <para>Tool Name : BuildNetwork</para>
		/// </summary>
		public override string ToolName => "BuildNetwork";

		/// <summary>
		/// <para>Tool Excute Name : na.BuildNetwork</para>
		/// </summary>
		public override string ExcuteName => "na.BuildNetwork";

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
		public override object[] Parameters => new object[] { InNetworkDataset, OutNetworkDataset };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset to be built.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Updated Input Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNetworkDatasetLayer()]
		public object OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildNetwork SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
