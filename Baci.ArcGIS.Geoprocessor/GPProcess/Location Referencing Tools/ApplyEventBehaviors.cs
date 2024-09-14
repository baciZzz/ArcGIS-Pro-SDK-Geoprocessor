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
	/// <para>Apply Event Behaviors</para>
	/// <para>应用事件行为</para>
	/// <para>根据执行的路径编辑更新在输入网络中注册的所有事件要素类的事件位置。</para>
	/// </summary>
	public class ApplyEventBehaviors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>将更新其活动位置的 LRS 网络。 必须是向 LRS 注册为网络的要素图层。</para>
		/// </param>
		public ApplyEventBehaviors(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用事件行为</para>
		/// </summary>
		public override string DisplayName() => "应用事件行为";

		/// <summary>
		/// <para>Tool Name : ApplyEventBehaviors</para>
		/// </summary>
		public override string ToolName() => "ApplyEventBehaviors";

		/// <summary>
		/// <para>Tool Excute Name : locref.ApplyEventBehaviors</para>
		/// </summary>
		public override string ExcuteName() => "locref.ApplyEventBehaviors";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, OutEventLayers!, OutDetailsFile! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>将更新其活动位置的 LRS 网络。 必须是向 LRS 注册为网络的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Event Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutEventLayers { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

	}
}
