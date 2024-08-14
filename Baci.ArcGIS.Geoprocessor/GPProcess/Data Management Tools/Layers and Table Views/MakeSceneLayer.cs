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
	/// <para>Creates a scene layer from a scene layer package (.slpk) or scene service.</para>
	/// </summary>
	public class MakeSceneLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The input scene layer package (.slpk) or scene service from which the new scene layer will be created.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The name of the scene layer to be created.</para>
		/// </param>
		public MakeSceneLayer(object InDataset, object OutLayer)
		{
			this.InDataset = InDataset;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Scene Layer</para>
		/// </summary>
		public override string DisplayName => "Make Scene Layer";

		/// <summary>
		/// <para>Tool Name : MakeSceneLayer</para>
		/// </summary>
		public override string ToolName => "MakeSceneLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeSceneLayer</para>
		/// </summary>
		public override string ExcuteName => "management.MakeSceneLayer";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutLayer };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The input scene layer package (.slpk) or scene service from which the new scene layer will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The name of the scene layer to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSceneServiceLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeSceneLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
