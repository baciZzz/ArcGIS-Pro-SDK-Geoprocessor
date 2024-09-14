using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Generate Events</para>
	/// <para>生成事件</para>
	/// <para>为注册到 LRS 网络的事件要素重新生成形状。</para>
	/// </summary>
	public class GenerateEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InEventLayer">
		/// <para>Event Layer</para>
		/// <para>将为其重新生成形状的事件。</para>
		/// </param>
		public GenerateEvents(object InEventLayer)
		{
			this.InEventLayer = InEventLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成事件</para>
		/// </summary>
		public override string DisplayName() => "生成事件";

		/// <summary>
		/// <para>Tool Name : GenerateEvents</para>
		/// </summary>
		public override string ToolName() => "GenerateEvents";

		/// <summary>
		/// <para>Tool Excute Name : locref.GenerateEvents</para>
		/// </summary>
		public override string ExcuteName() => "locref.GenerateEvents";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InEventLayer, OutEventLayers!, OutDetailsFile! };

		/// <summary>
		/// <para>Event Layer</para>
		/// <para>将为其重新生成形状的事件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InEventLayer { get; set; }

		/// <summary>
		/// <para>Output Event Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutEventLayers { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateEvents SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
