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
	/// <para>Create Indoor Dataset</para>
	/// <para>Create Indoor Dataset</para>
	/// <para>Creates an indoor dataset containing the necessary feature classes to maintain floor plan data using a streamlined schema that conforms to the ArcGIS Indoors Information Model. The indoor dataset can be used for visualizing, analyzing, and editing indoor data.</para>
	/// </summary>
	public class CreateIndoorDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The target file or enterprise geodatabase that will contain the output indoor dataset.</para>
		/// </param>
		/// <param name="IndoorDatasetName">
		/// <para>Indoor Dataset Name</para>
		/// <para>The unique name of the output indoor dataset. The default is Indoor.</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output indoor dataset.</para>
		/// </param>
		public CreateIndoorDataset(object TargetGdb, object IndoorDatasetName, object SpatialReference)
		{
			this.TargetGdb = TargetGdb;
			this.IndoorDatasetName = IndoorDatasetName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Indoor Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create Indoor Dataset";

		/// <summary>
		/// <para>Tool Name : CreateIndoorDataset</para>
		/// </summary>
		public override string ToolName() => "CreateIndoorDataset";

		/// <summary>
		/// <para>Tool Excute Name : indoors.CreateIndoorDataset</para>
		/// </summary>
		public override string ExcuteName() => "indoors.CreateIndoorDataset";

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
		public override object[] Parameters() => new object[] { TargetGdb, IndoorDatasetName, SpatialReference, OutputDataset };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The target file or enterprise geodatabase that will contain the output indoor dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Indoor Dataset Name</para>
		/// <para>The unique name of the output indoor dataset. The default is Indoor.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IndoorDatasetName { get; set; } = "Indoor";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output indoor dataset.</para>
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
		public CreateIndoorDataset SetEnviroment(object configKeyword = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
