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
	/// <para>创建 Indoor 3D 数据集</para>
	/// <para>创建包含必要的多面体要素类的室内 3D 数据集，这些要素类可使用符合 ArcGIS Indoors 信息模型的简化方案维护楼层平面图数据。 在准备楼层平面图的 3D 场景并将其在整个组织中共享时，您可以使用这些要素类。</para>
	/// </summary>
	public class CreateIndoor3DDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>将包含室内 3D 数据集的目标文件数据库或企业级地理数据库。</para>
		/// </param>
		/// <param name="IndoorDatasetName">
		/// <para>Indoor 3D Dataset Name</para>
		/// <para>分配至输出室内数据集的唯一名称。 默认设置为 Indoor3D。 如果在目标地理数据库中已存在具有此名称的数据集，则会在该数据集中创建室内 3D 要素类。</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Coordinate System</para>
		/// <para>输出室内 3D 数据集的水平和垂直坐标系。</para>
		/// </param>
		public CreateIndoor3DDataset(object TargetGdb, object IndoorDatasetName, object SpatialReference)
		{
			this.TargetGdb = TargetGdb;
			this.IndoorDatasetName = IndoorDatasetName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 Indoor 3D 数据集</para>
		/// </summary>
		public override string DisplayName() => "创建 Indoor 3D 数据集";

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
		/// <para>将包含室内 3D 数据集的目标文件数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Indoor 3D Dataset Name</para>
		/// <para>分配至输出室内数据集的唯一名称。 默认设置为 Indoor3D。 如果在目标地理数据库中已存在具有此名称的数据集，则会在该数据集中创建室内 3D 要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IndoorDatasetName { get; set; } = "Indoor3D";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出室内 3D 数据集的水平和垂直坐标系。</para>
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
