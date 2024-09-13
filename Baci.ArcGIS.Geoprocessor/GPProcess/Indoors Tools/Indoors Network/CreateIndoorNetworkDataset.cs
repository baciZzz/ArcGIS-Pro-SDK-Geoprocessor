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
	/// <para>创建 Indoor 网络数据集</para>
	/// <para>创建包含必要的要素类的 Indoor 网络数据集，这些要素类可使用符合 ArcGIS Indoors 信息模型的简化方案维护 Indoor 网络数据。 Indoor 网络数据集可用于支持 Indoor 可路由网络。</para>
	/// </summary>
	public class CreateIndoorNetworkDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>包含输出 Indoor 网络数据集的目标文件地理数据库或企业级地理数据库。</para>
		/// </param>
		/// <param name="IndoorNetworkDatasetName">
		/// <para>Indoor Network Dataset Name</para>
		/// <para>输出 Indoor 网络数据集的唯一名称。 此名称也用于原始 Indoor 网络数据集。 Indoor 网络数据集的默认名称为 IndoorNetwork。 原始 Indoor 网络数据集的默认名称为 PrelimIndoorNetwork。</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Coordinate System</para>
		/// <para>输出 Indoor 网络数据集的空间参考。</para>
		/// </param>
		public CreateIndoorNetworkDataset(object TargetGdb, object IndoorNetworkDatasetName, object SpatialReference)
		{
			this.TargetGdb = TargetGdb;
			this.IndoorNetworkDatasetName = IndoorNetworkDatasetName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 Indoor 网络数据集</para>
		/// </summary>
		public override string DisplayName() => "创建 Indoor 网络数据集";

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
		/// <para>包含输出 Indoor 网络数据集的目标文件地理数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Indoor Network Dataset Name</para>
		/// <para>输出 Indoor 网络数据集的唯一名称。 此名称也用于原始 Indoor 网络数据集。 Indoor 网络数据集的默认名称为 IndoorNetwork。 原始 Indoor 网络数据集的默认名称为 PrelimIndoorNetwork。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IndoorNetworkDatasetName { get; set; } = "IndoorNetwork";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出 Indoor 网络数据集的空间参考。</para>
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
		public CreateIndoorNetworkDataset SetEnviroment(object configKeyword = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
