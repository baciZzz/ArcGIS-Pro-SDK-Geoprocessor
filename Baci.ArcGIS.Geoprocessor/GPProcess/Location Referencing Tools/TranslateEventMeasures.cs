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
	/// <para>Translate Event Measures</para>
	/// <para>转换事件测量值</para>
	/// <para>可将点或线事件图层的测量值（m 值）从一种线性参考方法 (LRM) 转换为另一种。</para>
	/// </summary>
	public class TranslateEventMeasures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceEvent">
		/// <para>Source Event Layer</para>
		/// <para>要转换的输入事件图层。</para>
		/// </param>
		/// <param name="InTargetRouteFeatures">
		/// <para>Input Target Route Features</para>
		/// <para>要将输入事件转换到的目标 LRS 网络。</para>
		/// </param>
		/// <param name="OutTargetEvent">
		/// <para>Output Event Layer</para>
		/// <para>包含转换后事件要素的输出要素类。</para>
		/// </param>
		public TranslateEventMeasures(object InSourceEvent, object InTargetRouteFeatures, object OutTargetEvent)
		{
			this.InSourceEvent = InSourceEvent;
			this.InTargetRouteFeatures = InTargetRouteFeatures;
			this.OutTargetEvent = OutTargetEvent;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换事件测量值</para>
		/// </summary>
		public override string DisplayName() => "转换事件测量值";

		/// <summary>
		/// <para>Tool Name : TranslateEventMeasures</para>
		/// </summary>
		public override string ToolName() => "TranslateEventMeasures";

		/// <summary>
		/// <para>Tool Excute Name : locref.TranslateEventMeasures</para>
		/// </summary>
		public override string ExcuteName() => "locref.TranslateEventMeasures";

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
		public override object[] Parameters() => new object[] { InSourceEvent, InTargetRouteFeatures, OutTargetEvent, InConcurrentRouteMatching! };

		/// <summary>
		/// <para>Source Event Layer</para>
		/// <para>要转换的输入事件图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InSourceEvent { get; set; }

		/// <summary>
		/// <para>Input Target Route Features</para>
		/// <para>要将输入事件转换到的目标 LRS 网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InTargetRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Event Layer</para>
		/// <para>包含转换后事件要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTargetEvent { get; set; }

		/// <summary>
		/// <para>Concurrent Route Matching</para>
		/// <para>指定此方法，该方法在当目标 LRS 网络中存在并发路径时用于确定使用哪个路径来转换事件。 仅当目标 LRS 网络上的事件转换位置存在并发路径（共享同一位置的路径）时，才应用此参数。</para>
		/// <para>任一并发路径—如果在目标 LRS 网络中找到两个或多个并发路径，将使用其中的第一个路径对输入事件图层进行转换。</para>
		/// <para>使用路径 ID 匹配路径—将源事件的路径 ID 与目标 LRS 网络中并发路径的路径 ID 进行比较。 源事件将根据源事件和目标网络中的路径 ID 的匹配程度进行转换。 输入事件和目标 LRS 网络的路径 ID 必须完全匹配，此方法才能正确转换事件。 此外，输入事件图层必须是已注册的 LRS 事件，才能使用此方法。</para>
		/// <para>所有并发路径—将针对目标 LRS 网络中该位置的所有并发路径对输入事件进行转换。</para>
		/// <para><see cref="InConcurrentRouteMatchingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InConcurrentRouteMatching { get; set; } = "ANY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TranslateEventMeasures SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Concurrent Route Matching</para>
		/// </summary>
		public enum InConcurrentRouteMatchingEnum 
		{
			/// <summary>
			/// <para>任一并发路径—如果在目标 LRS 网络中找到两个或多个并发路径，将使用其中的第一个路径对输入事件图层进行转换。</para>
			/// </summary>
			[GPValue("ANY")]
			[Description("任一并发路径")]
			Any_concurrent_route,

			/// <summary>
			/// <para>使用路径 ID 匹配路径—将源事件的路径 ID 与目标 LRS 网络中并发路径的路径 ID 进行比较。 源事件将根据源事件和目标网络中的路径 ID 的匹配程度进行转换。 输入事件和目标 LRS 网络的路径 ID 必须完全匹配，此方法才能正确转换事件。 此外，输入事件图层必须是已注册的 LRS 事件，才能使用此方法。</para>
			/// </summary>
			[GPValue("ROUTE_ID")]
			[Description("使用路径 ID 匹配路径")]
			Route_with_matching_RouteID,

			/// <summary>
			/// <para>所有并发路径—将针对目标 LRS 网络中该位置的所有并发路径对输入事件进行转换。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有并发路径")]
			All_concurrent_routes,

		}

#endregion
	}
}
