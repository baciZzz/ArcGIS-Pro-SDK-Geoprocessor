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
	/// <para>Make Building Layer</para>
	/// <para>Creates a composite building layer from a dataset, either a BIM file workspace or a geodatabase dataset, such as the output of the BIM File To Geodatabase tool.</para>
	/// </summary>
	public class MakeBuildingLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>The input dataset from which the new building feature layers will be made. The building layer keeps the structure and the symbology grouped together.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The name of the feature layer that will be created. The layer can be used as input to any geoprocessing tool that accepts a feature layer as input.</para>
		/// </param>
		public MakeBuildingLayer(object InFeatureDataset, object OutLayer)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Building Layer</para>
		/// </summary>
		public override string DisplayName => "Make Building Layer";

		/// <summary>
		/// <para>Tool Name : MakeBuildingLayer</para>
		/// </summary>
		public override string ToolName => "MakeBuildingLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeBuildingLayer</para>
		/// </summary>
		public override string ExcuteName => "management.MakeBuildingLayer";

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
		public override object[] Parameters => new object[] { InFeatureDataset, OutLayer };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>The input dataset from which the new building feature layers will be made. The building layer keeps the structure and the symbology grouped together.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The name of the feature layer that will be created. The layer can be used as input to any geoprocessing tool that accepts a feature layer as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBuildingLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeBuildingLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
