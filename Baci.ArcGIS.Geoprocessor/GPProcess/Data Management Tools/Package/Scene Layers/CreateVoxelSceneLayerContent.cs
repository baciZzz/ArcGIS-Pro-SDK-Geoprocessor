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
	/// <para>Create Voxel Scene Layer Content</para>
	/// <para>创建体素场景图层内容</para>
	/// <para>从体素图层输入创建场景图层包（.slpk 文件）。</para>
	/// </summary>
	public class CreateVoxelSceneLayerContent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Voxel Layer</para>
		/// <para>输入体素图层或图层文件。</para>
		/// </param>
		/// <param name="OutSlpk">
		/// <para>Output Scene Layer Package</para>
		/// <para>输出场景图层包（.slpk 文件）。</para>
		/// </param>
		public CreateVoxelSceneLayerContent(object InDataset, object OutSlpk)
		{
			this.InDataset = InDataset;
			this.OutSlpk = OutSlpk;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建体素场景图层内容</para>
		/// </summary>
		public override string DisplayName() => "创建体素场景图层内容";

		/// <summary>
		/// <para>Tool Name : CreateVoxelSceneLayerContent</para>
		/// </summary>
		public override string ToolName() => "CreateVoxelSceneLayerContent";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVoxelSceneLayerContent</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateVoxelSceneLayerContent";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutSlpk };

		/// <summary>
		/// <para>Input Voxel Layer</para>
		/// <para>输入体素图层或图层文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>输出场景图层包（.slpk 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("slpk")]
		public object OutSlpk { get; set; }

	}
}
