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
	/// <para>Create Indoor 3D Dataset</para>
	/// <para>Create Indoor 3D Dataset</para>
	/// <para>Creates an indoor 3D dataset containing the necessary multipatch feature classes to maintain floor plan data using a streamlined schema that conforms to the ArcGIS Indoors Information Model. You can use these feature classes when preparing 3D scenes of floor plans and share them across your organization.</para>
	/// </summary>
	public class CreateIndoor3DDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The target file or enterprise geodatabase that will contain the indoor 3D dataset.</para>
		/// </param>
		/// <param name="IndoorDatasetName">
		/// <para>Indoor 3D Dataset Name</para>
		/// <para>The unique name assigned to the output indoor dataset. The default is Indoor3D. If a dataset with this name exists in the target geodatabase, the indoor 3D feature classes will be created in that dataset.</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Coordinate System</para>
		/// <para>The horizontal and vertical coordinate system of the output indoor 3D dataset.</para>
		/// </param>
		public CreateIndoor3DDataset(object TargetGdb, object IndoorDatasetName, object SpatialReference)
		{
			this.TargetGdb = TargetGdb;
			this.IndoorDatasetName = IndoorDatasetName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Indoor 3D Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create Indoor 3D Dataset";

		/// <summary>
		/// <para>Tool Name : CreateIndoor3DDataset</para>
		/// </summary>
		public override string ToolName() => "CreateIndoor3DDataset";

		/// <summary>
		/// <para>Tool Excute Name : indoors.CreateIndoor3DDataset</para>
		/// </summary>
		public override string ExcuteName() => "indoors.CreateIndoor3DDataset";

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
		public override object[] Parameters() => new object[] { TargetGdb, IndoorDatasetName, SpatialReference, OutputDataset! };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The target file or enterprise geodatabase that will contain the indoor 3D dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Indoor 3D Dataset Name</para>
		/// <para>The unique name assigned to the output indoor dataset. The default is Indoor3D. If a dataset with this name exists in the target geodatabase, the indoor 3D feature classes will be created in that dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IndoorDatasetName { get; set; } = "Indoor3D";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The horizontal and vertical coordinate system of the output indoor 3D dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutputDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateIndoor3DDataset SetEnviroment(object? configKeyword = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
