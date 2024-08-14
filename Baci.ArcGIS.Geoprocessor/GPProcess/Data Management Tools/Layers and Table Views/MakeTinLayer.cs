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
	/// <para>Creates a triangulated irregular network (TIN) layer</para>
	/// <para>from an input TIN dataset or layer file. The layer that is created by the tool is temporary and will not persist after the session ends unless the layer is saved to disk or the map document is saved.</para>
	/// </summary>
	public class MakeTinLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The input TIN dataset or layer from which the new layer will be created.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output TIN Layer</para>
		/// <para>The name of the TIN layer to be created. The output layer can be used as an input to any geoprocessing tool that accepts a TIN layer as input.</para>
		/// </param>
		public MakeTinLayer(object InTin, object OutLayer)
		{
			this.InTin = InTin;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make TIN Layer</para>
		/// </summary>
		public override string DisplayName => "Make TIN Layer";

		/// <summary>
		/// <para>Tool Name : MakeTinLayer</para>
		/// </summary>
		public override string ToolName => "MakeTinLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeTinLayer</para>
		/// </summary>
		public override string ExcuteName => "management.MakeTinLayer";

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
		public override object[] Parameters => new object[] { InTin, OutLayer };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The input TIN dataset or layer from which the new layer will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output TIN Layer</para>
		/// <para>The name of the TIN layer to be created. The output layer can be used as an input to any geoprocessing tool that accepts a TIN layer as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeTinLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
