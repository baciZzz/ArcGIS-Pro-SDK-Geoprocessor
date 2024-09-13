using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Thin Indoor Pathways</para>
	/// <para>稀疏化室内路径</para>
	/// <para>用于移除每个楼层上所选位置之间路径选择不需要的初步网络路径，从而减小网络数据集大小并改善其路径求解性能。</para>
	/// </summary>
	public class ThinIndoorPathways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLevelFeatures">
		/// <para>Input Level Features</para>
		/// <para>输入面要素，表示一个或多个设施点中的一个或多个楼层。 在 ArcGIS Indoors 信息模型中，此项将为 Levels 图层。 系统将仅处理这些要素表示的楼层。</para>
		/// </param>
		/// <param name="InPathwayFeatures">
		/// <para>Input Pathway Features</para>
		/// <para>表示要细化的初步路径的输入折线要素。 在 Indoors 模型中，此项将为 PrelimPathways 图层。</para>
		/// </param>
		/// <param name="InTransitionFeatures">
		/// <para>Input Transition Features</para>
		/// <para>表示要细化的初步过渡的输入折线要素。 在 Indoors 模型中，此项将为 PrelimTransitions 图层。</para>
		/// </param>
		/// <param name="RoutableLocations">
		/// <para>Routable Locations</para>
		/// <para>表示用于计算路径的位置的输入点或面要素。 该要素可以是符合 Indoors 模型或配置为楼层感知型的任何点或面要素。</para>
		/// </param>
		/// <param name="TargetPathways">
		/// <para>Target Pathways</para>
		/// <para>将添加细化路径的现有要素类或要素图层。 在 Indoors 模型中，此项将为 Pathways 图层。</para>
		/// </param>
		/// <param name="TargetTransitions">
		/// <para>Target Transitions</para>
		/// <para>将添加细化过渡的现有要素类或要素。 在 Indoors 模型中，此项将为 Transitions 图层。</para>
		/// </param>
		public ThinIndoorPathways(object InLevelFeatures, object InPathwayFeatures, object InTransitionFeatures, object RoutableLocations, object TargetPathways, object TargetTransitions)
		{
			this.InLevelFeatures = InLevelFeatures;
			this.InPathwayFeatures = InPathwayFeatures;
			this.InTransitionFeatures = InTransitionFeatures;
			this.RoutableLocations = RoutableLocations;
			this.TargetPathways = TargetPathways;
			this.TargetTransitions = TargetTransitions;
		}

		/// <summary>
		/// <para>Tool Display Name : 稀疏化室内路径</para>
		/// </summary>
		public override string DisplayName() => "稀疏化室内路径";

		/// <summary>
		/// <para>Tool Name : ThinIndoorPathways</para>
		/// </summary>
		public override string ToolName() => "ThinIndoorPathways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ThinIndoorPathways</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ThinIndoorPathways";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLevelFeatures, InPathwayFeatures, InTransitionFeatures, RoutableLocations, TargetPathways, TargetTransitions, SearchTolerance!, NeighborSolveCount!, UpdatedPathways!, UpdatedTransitions! };

		/// <summary>
		/// <para>Input Level Features</para>
		/// <para>输入面要素，表示一个或多个设施点中的一个或多个楼层。 在 ArcGIS Indoors 信息模型中，此项将为 Levels 图层。 系统将仅处理这些要素表示的楼层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InLevelFeatures { get; set; }

		/// <summary>
		/// <para>Input Pathway Features</para>
		/// <para>表示要细化的初步路径的输入折线要素。 在 Indoors 模型中，此项将为 PrelimPathways 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InPathwayFeatures { get; set; }

		/// <summary>
		/// <para>Input Transition Features</para>
		/// <para>表示要细化的初步过渡的输入折线要素。 在 Indoors 模型中，此项将为 PrelimTransitions 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InTransitionFeatures { get; set; }

		/// <summary>
		/// <para>Routable Locations</para>
		/// <para>表示用于计算路径的位置的输入点或面要素。 该要素可以是符合 Indoors 模型或配置为楼层感知型的任何点或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object RoutableLocations { get; set; }

		/// <summary>
		/// <para>Target Pathways</para>
		/// <para>将添加细化路径的现有要素类或要素图层。 在 Indoors 模型中，此项将为 Pathways 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetPathways { get; set; }

		/// <summary>
		/// <para>Target Transitions</para>
		/// <para>将添加细化过渡的现有要素类或要素。 在 Indoors 模型中，此项将为 Transitions 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetTransitions { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>该工具将搜索的距离（以米为单位），以查找输入路径附近的可路由位置要素。 距离大于此值的可路由位置要素将不会用于稀疏化。 默认值为 5。该值必须大于等于 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SearchTolerance { get; set; } = "5";

		/// <summary>
		/// <para>Neighbor Solve Count</para>
		/// <para>在计算设施点中给定位置与其他可路由位置之间的路径时，将要求解的最接近相邻位置数量。 默认值为 50。该值必须大于等于 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NeighborSolveCount { get; set; } = "50";

		/// <summary>
		/// <para>Updated Pathways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedPathways { get; set; }

		/// <summary>
		/// <para>Updated Transitions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedTransitions { get; set; }

	}
}
