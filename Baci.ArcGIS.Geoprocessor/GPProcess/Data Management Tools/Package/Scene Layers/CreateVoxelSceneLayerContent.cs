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
	/// <para>Creates a scene layer package (.slpk file) from a voxel layer input.</para>
	/// </summary>
	public class CreateVoxelSceneLayerContent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Voxel Layer</para>
		/// <para>The input voxel layer or layer file.</para>
		/// </param>
		/// <param name="OutSlpk">
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk file).</para>
		/// </param>
		public CreateVoxelSceneLayerContent(object InDataset, object OutSlpk)
		{
			this.InDataset = InDataset;
			this.OutSlpk = OutSlpk;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Voxel Scene Layer Content</para>
		/// </summary>
		public override string DisplayName => "Create Voxel Scene Layer Content";

		/// <summary>
		/// <para>Tool Name : CreateVoxelSceneLayerContent</para>
		/// </summary>
		public override string ToolName => "CreateVoxelSceneLayerContent";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVoxelSceneLayerContent</para>
		/// </summary>
		public override string ExcuteName => "management.CreateVoxelSceneLayerContent";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutSlpk };

		/// <summary>
		/// <para>Input Voxel Layer</para>
		/// <para>The input voxel layer or layer file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutSlpk { get; set; }

	}
}
