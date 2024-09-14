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
	/// <para>Make TIN Layer</para>
	/// <para>创建 TIN 图层</para>
	/// <para>基于输入 TIN 数据集或图层文件创建不规则三角网 (TIN) 图层。该工具创建的图层是临时图层，如果不将此图层保存到磁盘或保存地图文档，该图层在会话结束后将不会继续存在。</para>
	/// </summary>
	public class MakeTinLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>创建新图层时基于的输入 TIN 数据集或图层。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output TIN Layer</para>
		/// <para>要创建的 TIN 图层的名称。输出图层可用作任何接受 TIN 图层作为输入的地理处理工具的输入。</para>
		/// </param>
		public MakeTinLayer(object InTin, object OutLayer)
		{
			this.InTin = InTin;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 TIN 图层</para>
		/// </summary>
		public override string DisplayName() => "创建 TIN 图层";

		/// <summary>
		/// <para>Tool Name : MakeTinLayer</para>
		/// </summary>
		public override string ToolName() => "MakeTinLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeTinLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeTinLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutLayer };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>创建新图层时基于的输入 TIN 数据集或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output TIN Layer</para>
		/// <para>要创建的 TIN 图层的名称。输出图层可用作任何接受 TIN 图层作为输入的地理处理工具的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeTinLayer SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
