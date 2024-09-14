using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Create Indoor Network Dataset</para>
	/// <para>Create Indoor Network Dataset</para>
	/// <para>Creates an indoor network dataset containing the necessary feature classes to maintain indoor network data using a streamlined schema that conforms to the ArcGIS Indoors Information Model. The indoor network dataset can be used to support indoor routable networks.</para>
	/// </summary>
	public class CreateIndoorNetworkDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The target file or enterprise geodatabase that will contain the output indoor network dataset.</para>
		/// </param>
		/// <param name="IndoorNetworkDatasetName">
		/// <para>Indoor Network Dataset Name</para>
		/// <para>The unique name of the output indoor network dataset. This name is also used for the preliminary indoor network dataset. The default name for the indoor network dataset is IndoorNetwork. The default name for the preliminary indoor network dataset is PrelimIndoorNetwork.</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output indoor network dataset.</para>
		/// </param>
		public CreateIndoorNetworkDataset(object TargetGdb, object IndoorNetworkDatasetName, object SpatialReference)
		{
			this.TargetGdb = TargetGdb;
			this.IndoorNetworkDatasetName = IndoorNetworkDatasetName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Indoor Network Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create Indoor Network Dataset";

		/// <summary>
		/// <para>Tool Name : CreateIndoorNetworkDataset</para>
		/// </summary>
		public override string ToolName() => "CreateIndoorNetworkDataset";

		/// <summary>
		/// <para>Tool Excute Name : indoors.CreateIndoorNetworkDataset</para>
		/// </summary>
		public override string ExcuteName() => "indoors.CreateIndoorNetworkDataset";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetGdb, IndoorNetworkDatasetName, SpatialReference, OutputDataset };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The target file or enterprise geodatabase that will contain the output indoor network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Indoor Network Dataset Name</para>
		/// <para>The unique name of the output indoor network dataset. This name is also used for the preliminary indoor network dataset. The default name for the indoor network dataset is IndoorNetwork. The default name for the preliminary indoor network dataset is PrelimIndoorNetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IndoorNetworkDatasetName { get; set; } = "IndoorNetwork";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output indoor network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object OutputDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateIndoorNetworkDataset SetEnviroment(object configKeyword = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
