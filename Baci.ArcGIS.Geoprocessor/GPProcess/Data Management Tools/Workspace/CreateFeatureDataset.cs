using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Create Feature Dataset</para>
	/// <para>创建要素数据集</para>
	/// <para>在输出位置（现有的企业级、文件或移动地理数据库）创建要素数据集。</para>
	/// </summary>
	public class CreateFeatureDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutDatasetPath">
		/// <para>Output Geodatabase</para>
		/// <para>将在其中创建输出要素数据集的企业级地理数据库、文件地理数据库或移动地理数据库。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Feature Dataset Name</para>
		/// <para>要创建的要素数据集的名称。</para>
		/// </param>
		public CreateFeatureDataset(object OutDatasetPath, object OutName)
		{
			this.OutDatasetPath = OutDatasetPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建要素数据集</para>
		/// </summary>
		public override string DisplayName() => "创建要素数据集";

		/// <summary>
		/// <para>Tool Name : CreateFeatureDataset</para>
		/// </summary>
		public override string ToolName() => "CreateFeatureDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFeatureDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFeatureDataset";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutDatasetPath, OutName, SpatialReference, OutDataset };

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>将在其中创建输出要素数据集的企业级地理数据库、文件地理数据库或移动地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutDatasetPath { get; set; }

		/// <summary>
		/// <para>Feature Dataset Name</para>
		/// <para>要创建的要素数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出要素数据集的空间参考。在空间参考属性对话框中，可以选择、导入或新建坐标系。要设置空间参考的各个方面（例如，x,y 值域、z 值域、m 值域、分辨率或容差），请使用环境对话框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFeatureDataset SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
