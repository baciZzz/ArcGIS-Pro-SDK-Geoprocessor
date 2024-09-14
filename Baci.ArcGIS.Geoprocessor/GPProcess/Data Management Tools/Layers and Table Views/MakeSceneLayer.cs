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
	/// <para>Make Scene Layer</para>
	/// <para>创建场景图层</para>
	/// <para>从场景图层包 (.slpk) 创建场景图层或场景服务。</para>
	/// </summary>
	public class MakeSceneLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>输入场景图层包 (.slpk) 或场景服务，基于该包或服务创建新场景图层。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>要创建的场景图层的名称。</para>
		/// </param>
		public MakeSceneLayer(object InDataset, object OutLayer)
		{
			this.InDataset = InDataset;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建场景图层</para>
		/// </summary>
		public override string DisplayName() => "创建场景图层";

		/// <summary>
		/// <para>Tool Name : MakeSceneLayer</para>
		/// </summary>
		public override string ToolName() => "MakeSceneLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeSceneLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeSceneLayer";

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
		public override object[] Parameters() => new object[] { InDataset, OutLayer };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>输入场景图层包 (.slpk) 或场景服务，基于该包或服务创建新场景图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>要创建的场景图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSceneServiceLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeSceneLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
