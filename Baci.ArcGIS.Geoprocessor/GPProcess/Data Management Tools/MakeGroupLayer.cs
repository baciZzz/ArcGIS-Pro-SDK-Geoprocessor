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
	/// <para>Make Group Layer</para>
	/// <para>Make Group Layer</para>
	/// </summary>
	[Obsolete()]
	public class MakeGroupLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// </param>
		public MakeGroupLayer(object OutLayer)
		{
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Group Layer</para>
		/// </summary>
		public override string DisplayName => "Make Group Layer";

		/// <summary>
		/// <para>Tool Name : MakeGroupLayer</para>
		/// </summary>
		public override string ToolName => "MakeGroupLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeGroupLayer</para>
		/// </summary>
		public override string ExcuteName => "management.MakeGroupLayer";

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
		public override object[] Parameters => new object[] { OutLayer, Layers };

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGroupLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>FeatureClasses To Add</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Layers { get; set; }

	}
}
