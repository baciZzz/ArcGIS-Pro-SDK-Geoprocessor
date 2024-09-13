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
	/// <para>Generate Indoor Pathways</para>
	/// <para>生成室内路径</para>
	/// <para>用于在一个或多个设施点中的所选楼层上生成根据障碍物（例如墙壁或圆柱）切割的初步路径。</para>
	/// </summary>
	public class GenerateIndoorPathways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLevelFeatures">
		/// <para>Input Level Features</para>
		/// <para>表示设施点中楼层的输入面要素。 在 Indoors 模型中，此项将为 Levels 图层。 该工具支持应用于图层的选择和定义查询。</para>
		/// </param>
		/// <param name="InDetailFeatures">
		/// <para>Input Detail Features</para>
		/// <para>表示建筑细节的输入折线要素，可能会作为设施点内要行驶的障碍。 在 Indoors 模型中，此项将为 Details 图层</para>
		/// </param>
		/// <param name="TargetPathways">
		/// <para>Target Pathways</para>
		/// <para>将写入生成的路径折线的要素类或要素图层。 在 Indoors 模型中，此项将为 PrelimPathways 图层。</para>
		/// </param>
		public GenerateIndoorPathways(object InLevelFeatures, object InDetailFeatures, object TargetPathways)
		{
			this.InLevelFeatures = InLevelFeatures;
			this.InDetailFeatures = InDetailFeatures;
			this.TargetPathways = TargetPathways;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成室内路径</para>
		/// </summary>
		public override string DisplayName() => "生成室内路径";

		/// <summary>
		/// <para>Tool Name : GenerateIndoorPathways</para>
		/// </summary>
		public override string ToolName() => "GenerateIndoorPathways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateIndoorPathways</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateIndoorPathways";

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
		public override object[] Parameters() => new object[] { InLevelFeatures, InDetailFeatures, TargetPathways, LatticeRotation, LatticeDensity, RestrictedUnitFeatures, RestrictedUnitExp, DetailExp, UpdatedPathways };

		/// <summary>
		/// <para>Input Level Features</para>
		/// <para>表示设施点中楼层的输入面要素。 在 Indoors 模型中，此项将为 Levels 图层。 该工具支持应用于图层的选择和定义查询。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InLevelFeatures { get; set; }

		/// <summary>
		/// <para>Input Detail Features</para>
		/// <para>表示建筑细节的输入折线要素，可能会作为设施点内要行驶的障碍。 在 Indoors 模型中，此项将为 Details 图层</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InDetailFeatures { get; set; }

		/// <summary>
		/// <para>Target Pathways</para>
		/// <para>将写入生成的路径折线的要素类或要素图层。 在 Indoors 模型中，此项将为 PrelimPathways 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetPathways { get; set; }

		/// <summary>
		/// <para>Lattice Rotation</para>
		/// <para>从正西方向开始顺时针旋转输入楼层的主要途经方向的度数。 如果保留空白，则该工具将基于每个楼层的最小边界矩形计算一个值。</para>
		/// <para>该值必须介于 0.0 到 180.0 之间</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 180)]
		public object LatticeRotation { get; set; }

		/// <summary>
		/// <para>Lattice Density</para>
		/// <para>在生成的路径格网中，节点之间允许的最长距离，以米为单位。 默认值为 0.6。</para>
		/// <para>该值必须介于 0.25 到 0.9 之间</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.25, Max = 0.90000000000000002)]
		public object LatticeDensity { get; set; } = "0.6";

		/// <summary>
		/// <para>Restricted Unit Features</para>
		/// <para>表示设施点内的受限空间和非受限空间的输入面要素。 在 Indoors 模型中，此项将为 Units 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object RestrictedUnitFeatures { get; set; }

		/// <summary>
		/// <para>Restricted Unit Expression</para>
		/// <para>一个 SQL 表达式，用于选择该工具不会在其中生成路径的受限单元要素值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object RestrictedUnitExp { get; set; }

		/// <summary>
		/// <para>Detail Expression</para>
		/// <para>一个 SQL 表达式，用于选择该工具不会在其中生成路径的输入细节要素值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object DetailExp { get; set; }

		/// <summary>
		/// <para>Updated Pathways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object UpdatedPathways { get; set; }

	}
}
