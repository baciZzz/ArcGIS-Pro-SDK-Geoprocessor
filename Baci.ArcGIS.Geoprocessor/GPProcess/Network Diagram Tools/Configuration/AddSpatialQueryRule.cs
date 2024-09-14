using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Add Spatial Query Rule</para>
	/// <para>添加空间查询规则</para>
	/// <para>添加逻辑示意图规则，根据逻辑示意图中当前显示的网络要素的位置，自动将新的网络要素追加到逻辑示意图中。</para>
	/// </summary>
	public class AddSpatialQueryRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板的名称。</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="AddedFeatures">
		/// <para>Add Features</para>
		/// <para>将向其添加要素的源要素类。</para>
		/// </param>
		/// <param name="OverlapType">
		/// <para>Relationship</para>
		/// <para>指定要素之间的空间关系。</para>
		/// <para>相交— 如果添加要素源要素类中的要素与一个现有要素相交，则这些要素将追加到逻辑示意图中。这是默认设置。</para>
		/// <para>在某一距离范围内— 如果添加要素源要素类中的要素与一个现有要素在指定距离（采用欧氏距离）范围内，则这些要素将追加到逻辑示意图中。使用搜索距离参数指定距离。</para>
		/// <para>包含|属于— 如果添加要素源要素类中的要素来自或包含于现有要素，则这些要素将追加到逻辑示意图中。</para>
		/// <para>位于— 如果添加要素源要素类中的要素在现有要素范围内，则这些要素将追加到逻辑示意图中。</para>
		/// <para>边界接触— 如果添加要素源要素类中的要素的边界与现有要素相接触，则这些要素将追加到逻辑示意图中。如果现有要素为线或面，则添加要素输入要素的边界只能接触一个现有要素的边界，且输入要素的任何部分均不可跨越现有要素的边界。</para>
		/// <para>与其他要素共线— 如果添加要素源要素类中的要素与一个现有要素共线，则这些要素将追加到逻辑示意图中。已添加要素和现有要素必须是线或面。</para>
		/// <para>与轮廓交叉— 如果添加要素源要素类中的要素与一个现有要素的轮廓交叉，则这些要素将追加到逻辑示意图中。已添加要素和现有要素必须是线或面。如果将面用于现有要素，则会使用面的边界（线）。将追加在某一点交叉的线；不会追加共线的线。</para>
		/// <para><see cref="OverlapTypeEnum"/></para>
		/// </param>
		/// <param name="ExistingFeatures">
		/// <para>Existing Features</para>
		/// <para>将对其执行空间查询的源要素类。</para>
		/// </param>
		public AddSpatialQueryRule(object InUtilityNetwork, object TemplateName, object IsActive, object AddedFeatures, object OverlapType, object ExistingFeatures)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.AddedFeatures = AddedFeatures;
			this.OverlapType = OverlapType;
			this.ExistingFeatures = ExistingFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加空间查询规则</para>
		/// </summary>
		public override string DisplayName() => "添加空间查询规则";

		/// <summary>
		/// <para>Tool Name : AddSpatialQueryRule</para>
		/// </summary>
		public override string ToolName() => "AddSpatialQueryRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddSpatialQueryRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddSpatialQueryRule";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AddedFeatures, OverlapType, ExistingFeatures, SearchDistance, AddedWhereClause, ExistingWhereClause, Description, OutUtilityNetwork, OutTemplateName };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Add Features</para>
		/// <para>将向其添加要素的源要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object AddedFeatures { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>指定要素之间的空间关系。</para>
		/// <para>相交— 如果添加要素源要素类中的要素与一个现有要素相交，则这些要素将追加到逻辑示意图中。这是默认设置。</para>
		/// <para>在某一距离范围内— 如果添加要素源要素类中的要素与一个现有要素在指定距离（采用欧氏距离）范围内，则这些要素将追加到逻辑示意图中。使用搜索距离参数指定距离。</para>
		/// <para>包含|属于— 如果添加要素源要素类中的要素来自或包含于现有要素，则这些要素将追加到逻辑示意图中。</para>
		/// <para>位于— 如果添加要素源要素类中的要素在现有要素范围内，则这些要素将追加到逻辑示意图中。</para>
		/// <para>边界接触— 如果添加要素源要素类中的要素的边界与现有要素相接触，则这些要素将追加到逻辑示意图中。如果现有要素为线或面，则添加要素输入要素的边界只能接触一个现有要素的边界，且输入要素的任何部分均不可跨越现有要素的边界。</para>
		/// <para>与其他要素共线— 如果添加要素源要素类中的要素与一个现有要素共线，则这些要素将追加到逻辑示意图中。已添加要素和现有要素必须是线或面。</para>
		/// <para>与轮廓交叉— 如果添加要素源要素类中的要素与一个现有要素的轮廓交叉，则这些要素将追加到逻辑示意图中。已添加要素和现有要素必须是线或面。如果将面用于现有要素，则会使用面的边界（线）。将追加在某一点交叉的线；不会追加共线的线。</para>
		/// <para><see cref="OverlapTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Existing Features</para>
		/// <para>将对其执行空间查询的源要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object ExistingFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>现有要素参数中的要素与添加要素参数中的要素之间的距离。仅当关系参数设置为以下选项时，该参数才有效：相交、在某一距离范围内、包含或位于。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Added Features Query Definition</para>
		/// <para>用于过滤要添加到逻辑示意图中的要素的 SQL 查询。如果没有 SQL 查询，基于指定源类的与指定现有要素在空间上相关的要素将追加到逻辑示意图中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object AddedWhereClause { get; set; }

		/// <summary>
		/// <para>Existing Features Query Definition</para>
		/// <para>用于过滤逻辑示意图中现有要素的 SQL 查询。如果没有 SQL 查询，将考虑基于逻辑示意图中存在的指定源类的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object ExistingWhereClause { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>规则的描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutTemplateName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INACTIVE")]
			INACTIVE,

		}

		/// <summary>
		/// <para>Relationship</para>
		/// </summary>
		public enum OverlapTypeEnum 
		{
			/// <summary>
			/// <para>相交— 如果添加要素源要素类中的要素与一个现有要素相交，则这些要素将追加到逻辑示意图中。这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("相交")]
			Intersect,

			/// <summary>
			/// <para>在某一距离范围内— 如果添加要素源要素类中的要素与一个现有要素在指定距离（采用欧氏距离）范围内，则这些要素将追加到逻辑示意图中。使用搜索距离参数指定距离。</para>
			/// </summary>
			[GPValue("WITHIN_A_DISTANCE")]
			[Description("在某一距离范围内")]
			Within_a_distance,

			/// <summary>
			/// <para>包含|属于— 如果添加要素源要素类中的要素来自或包含于现有要素，则这些要素将追加到逻辑示意图中。</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("包含|属于")]
			CONTAINS,

			/// <summary>
			/// <para>位于— 如果添加要素源要素类中的要素在现有要素范围内，则这些要素将追加到逻辑示意图中。</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("位于")]
			Within,

			/// <summary>
			/// <para>边界接触— 如果添加要素源要素类中的要素的边界与现有要素相接触，则这些要素将追加到逻辑示意图中。如果现有要素为线或面，则添加要素输入要素的边界只能接触一个现有要素的边界，且输入要素的任何部分均不可跨越现有要素的边界。</para>
			/// </summary>
			[GPValue("BOUNDARY_TOUCHES")]
			[Description("边界接触")]
			Boundary_touches,

			/// <summary>
			/// <para>与其他要素共线— 如果添加要素源要素类中的要素与一个现有要素共线，则这些要素将追加到逻辑示意图中。已添加要素和现有要素必须是线或面。</para>
			/// </summary>
			[GPValue("SHARE_A_LINE_SEGMENT_WITH")]
			[Description("与其他要素共线")]
			Share_a_line_segment_with,

			/// <summary>
			/// <para>与轮廓交叉— 如果添加要素源要素类中的要素与一个现有要素的轮廓交叉，则这些要素将追加到逻辑示意图中。已添加要素和现有要素必须是线或面。如果将面用于现有要素，则会使用面的边界（线）。将追加在某一点交叉的线；不会追加共线的线。</para>
			/// </summary>
			[GPValue("CROSSED_BY_THE_OUTLINE_OF")]
			[Description("与轮廓交叉")]
			Crossed_by_the_outline_of,

		}

#endregion
	}
}
