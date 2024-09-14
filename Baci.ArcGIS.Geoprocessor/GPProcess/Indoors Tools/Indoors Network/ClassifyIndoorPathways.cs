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
	/// <para>Classify Indoor Pathways</para>
	/// <para>分类室内路径</para>
	/// <para>用于将通过所选单位空间（例如会议室或服务区）的路径分类为较低优先级。</para>
	/// </summary>
	public class ClassifyIndoorPathways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>输入面要素，表示将对目标路径参数值进行分类的建筑物内的空间。 在 ArcGIS Indoors 信息模型中，此项将为 Units 图层。 在运行该工具之前选择单位图层中的要素。</para>
		/// </param>
		/// <param name="TargetPathways">
		/// <para>Target Pathways</para>
		/// <para>将更新其中路径的现有要素类或要素图层。 在 Indoors 模型中，此项将为 Pathways 图层。</para>
		/// </param>
		public ClassifyIndoorPathways(object InUnitFeatures, object TargetPathways)
		{
			this.InUnitFeatures = InUnitFeatures;
			this.TargetPathways = TargetPathways;
		}

		/// <summary>
		/// <para>Tool Display Name : 分类室内路径</para>
		/// </summary>
		public override string DisplayName() => "分类室内路径";

		/// <summary>
		/// <para>Tool Name : ClassifyIndoorPathways</para>
		/// </summary>
		public override string ToolName() => "ClassifyIndoorPathways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ClassifyIndoorPathways</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ClassifyIndoorPathways";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUnitFeatures, TargetPathways, UpdatedPathways! };

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>输入面要素，表示将对目标路径参数值进行分类的建筑物内的空间。 在 ArcGIS Indoors 信息模型中，此项将为 Units 图层。 在运行该工具之前选择单位图层中的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Target Pathways</para>
		/// <para>将更新其中路径的现有要素类或要素图层。 在 Indoors 模型中，此项将为 Pathways 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetPathways { get; set; }

		/// <summary>
		/// <para>Updated Pathways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedPathways { get; set; }

	}
}
