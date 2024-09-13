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
	/// <para>Derive Event Measures</para>
	/// <para>派生事件测量</para>
	/// <para>使用已配置和启用的 DerivedRouteID 字段填充和更新点和线事件上的这些字段和测量值。</para>
	/// </summary>
	public class DeriveEventMeasures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>LRS 网络包含配置了 DerivedRouteID 和测量字段的事件。</para>
		/// </param>
		public DeriveEventMeasures(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 派生事件测量</para>
		/// </summary>
		public override string DisplayName() => "派生事件测量";

		/// <summary>
		/// <para>Tool Name : DeriveEventMeasures</para>
		/// </summary>
		public override string ToolName() => "DeriveEventMeasures";

		/// <summary>
		/// <para>Tool Excute Name : locref.DeriveEventMeasures</para>
		/// </summary>
		public override string ExcuteName() => "locref.DeriveEventMeasures";

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
		public override object[] Parameters() => new object[] { InRouteFeatures, UpdateAllEvents!, EventLayers!, OutEvents!, OutDetailsFile! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>LRS 网络包含配置了 DerivedRouteID 和测量字段的事件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Update all event feature classes registered in the selected network</para>
		/// <para>指定是否更新网络中的所有事件要素类。</para>
		/// <para>选中 - 将更新在输入路径要素参数值中选择的网络中的所有事件要素类。 这是默认设置。</para>
		/// <para>未选中 - 不会更新在输入路径要素参数值中选择的网络中的所有事件要素类。 可以使用事件图层参数选择单个事件图层。</para>
		/// <para><see cref="UpdateAllEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateAllEvents { get; set; } = "true";

		/// <summary>
		/// <para>Event Layers</para>
		/// <para>将更新 DerivedRouteID 和测量字段的事件图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? EventLayers { get; set; }

		/// <summary>
		/// <para>Output Events</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutEvents { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeriveEventMeasures SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update all event feature classes registered in the selected network</para>
		/// </summary>
		public enum UpdateAllEventsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_ALL")]
			UPDATE_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("UPDATE_SOME")]
			UPDATE_SOME,

		}

#endregion
	}
}
