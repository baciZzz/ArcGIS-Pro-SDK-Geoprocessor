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
	/// <para>Dissolve Network</para>
	/// <para>Creates a network dataset that minimizes the number of line features required to correctly model the input network dataset. The more efficient output network dataset reduces the time required to solve analyses, draw results, and generate driving directions. This tool outputs a new network dataset and source feature classes; the input network dataset and its source features remain unchanged.</para>
	/// </summary>
	public class DissolveNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset to be dissolved.</para>
		/// <para>The input network dataset must be a file or personal geodatabase network dataset with exactly one edge source. Any number of junction sources and turn sources is allowed. The edge source must have:</para>
		/// <para>End point connectivity policy</para>
		/// <para>An elevation policy of either None or Elevation Fields</para>
		/// <para>The input network dataset must be built before it can be used in this tool.</para>
		/// </param>
		/// <param name="OutWorkspaceLocation">
		/// <para>Output Geodatabase Workspace</para>
		/// <para>The geodatabase workspace in which to create the dissolved network dataset. The workspace must be an ArcGIS 10 geodatabase or later, and it must be a different geodatabase than the one where the input network dataset resides.</para>
		/// </param>
		public DissolveNetwork(object InNetworkDataset, object OutWorkspaceLocation)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutWorkspaceLocation = OutWorkspaceLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Dissolve Network</para>
		/// </summary>
		public override string DisplayName() => "Dissolve Network";

		/// <summary>
		/// <para>Tool Name : DissolveNetwork</para>
		/// </summary>
		public override string ToolName() => "DissolveNetwork";

		/// <summary>
		/// <para>Tool Excute Name : na.DissolveNetwork</para>
		/// </summary>
		public override string ExcuteName() => "na.DissolveNetwork";

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
		public override object[] Parameters() => new object[] { InNetworkDataset, OutWorkspaceLocation, OutNetworkDataset };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset to be dissolved.</para>
		/// <para>The input network dataset must be a file or personal geodatabase network dataset with exactly one edge source. Any number of junction sources and turn sources is allowed. The edge source must have:</para>
		/// <para>End point connectivity policy</para>
		/// <para>An elevation policy of either None or Elevation Fields</para>
		/// <para>The input network dataset must be built before it can be used in this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Geodatabase Workspace</para>
		/// <para>The geodatabase workspace in which to create the dissolved network dataset. The workspace must be an ArcGIS 10 geodatabase or later, and it must be a different geodatabase than the one where the input network dataset resides.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object OutWorkspaceLocation { get; set; }

		/// <summary>
		/// <para>Output Dissolved Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DENetworkDataset()]
		public object OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DissolveNetwork SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
