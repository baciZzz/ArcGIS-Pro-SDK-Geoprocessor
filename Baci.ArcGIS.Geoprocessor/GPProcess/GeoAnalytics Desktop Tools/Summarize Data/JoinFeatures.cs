using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Join Features</para>
	/// <para>连接要素</para>
	/// <para>可根据空间、时态、属性关系或这些关系的某种组合将一个图层的属性连接到另一个图层。</para>
	/// </summary>
	public class JoinFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetLayer">
		/// <para>Target Layer</para>
		/// <para>包含目标要素。 目标要素的属性和已连接要素的属性将传递到输出。</para>
		/// </param>
		/// <param name="JoinLayer">
		/// <para>Join Layer</para>
		/// <para>包含连接要素。 连接要素的属性将被连接到目标要素的属性中。 有关连接操作的类型对所连接属性聚合的影响的详细信息，请参阅连接操作（Python 中的 join_operation）参数的说明。</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>包含具有连接要素的目标图层要素的新要素类。</para>
		/// </param>
		/// <param name="JoinOperation">
		/// <para>Join Operation</para>
		/// <para>指定当多个连接要素与单个目标要素之间存在同一空间关系时，如何在输出中处理目标图层值和连接图层值之间的连接。</para>
		/// <para>一对一连接—系统将聚合来自多个连接要素的属性。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，将对这两个面的属性进行聚合，然后将其传递到输出点要素类。 如果一个面要素的属性值为 3，另一个面要素的属性值为 7，且为该字段指定了汇总统计数据总和，则输出要素类中的聚合值将为 10。 此为默认设置，且仅会返回计数统计数据。</para>
		/// <para>一对多连接—输出要素类将包含目标要素的多个副本（记录）。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，则输出要素类将包含目标要素的两个副本：分别包含两个面的属性记录。 使用此方法时，没有可用的汇总统计数据。</para>
		/// <para><see cref="JoinOperationEnum"/></para>
		/// </param>
		public JoinFeatures(object TargetLayer, object JoinLayer, object Output, object JoinOperation)
		{
			this.TargetLayer = TargetLayer;
			this.JoinLayer = JoinLayer;
			this.Output = Output;
			this.JoinOperation = JoinOperation;
		}

		/// <summary>
		/// <para>Tool Display Name : 连接要素</para>
		/// </summary>
		public override string DisplayName() => "连接要素";

		/// <summary>
		/// <para>Tool Name : JoinFeatures</para>
		/// </summary>
		public override string ToolName() => "JoinFeatures";

		/// <summary>
		/// <para>Tool Excute Name : gapro.JoinFeatures</para>
		/// </summary>
		public override string ExcuteName() => "gapro.JoinFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetLayer, JoinLayer, Output, JoinOperation, SpatialRelationship!, SpatialNearDistance!, TemporalRelationship!, TemporalNearDistance!, AttributeRelationship!, SummaryFields!, JoinCondition!, KeepAllTargetFeatures! };

		/// <summary>
		/// <para>Target Layer</para>
		/// <para>包含目标要素。 目标要素的属性和已连接要素的属性将传递到输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object TargetLayer { get; set; }

		/// <summary>
		/// <para>Join Layer</para>
		/// <para>包含连接要素。 连接要素的属性将被连接到目标要素的属性中。 有关连接操作的类型对所连接属性聚合的影响的详细信息，请参阅连接操作（Python 中的 join_operation）参数的说明。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object JoinLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>包含具有连接要素的目标图层要素的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Join Operation</para>
		/// <para>指定当多个连接要素与单个目标要素之间存在同一空间关系时，如何在输出中处理目标图层值和连接图层值之间的连接。</para>
		/// <para>一对一连接—系统将聚合来自多个连接要素的属性。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，将对这两个面的属性进行聚合，然后将其传递到输出点要素类。 如果一个面要素的属性值为 3，另一个面要素的属性值为 7，且为该字段指定了汇总统计数据总和，则输出要素类中的聚合值将为 10。 此为默认设置，且仅会返回计数统计数据。</para>
		/// <para>一对多连接—输出要素类将包含目标要素的多个副本（记录）。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，则输出要素类将包含目标要素的两个副本：分别包含两个面的属性记录。 使用此方法时，没有可用的汇总统计数据。</para>
		/// <para><see cref="JoinOperationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinOperation { get; set; } = "JOIN_ONE_TO_ONE";

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// <para>指定将用于空间连接要素的条件。</para>
		/// <para>相交—如果连接要素与目标要素相交，将匹配连接要素中相交的要素。 这是默认设置。</para>
		/// <para>相等—如果连接要素与目标要素的几何类型相同，则将匹配连接要素中的要素。</para>
		/// <para>平面邻近—如果连接要素在目标要素的指定距离之内，将匹配处于该距离内的要素。 使用平面距离测量距离。 在空间邻近距离参数中指定距离。</para>
		/// <para>测地线邻近—如果连接要素在目标要素的指定距离之内，将匹配处于该距离内的要素。 距离将以测地线方法进行测量。 在空间邻近距离参数中指定距离。</para>
		/// <para>包含—如果目标要素中包含连接要素中的要素，将匹配连接要素中被包含的要素。 目标要素必须是面或折线。 只有当目标要素也为面时连接要素才可为面。 面可以包含任何要素类型。 折线只能包含折线和点。 点不能包含任何要素，甚至不能包含点。 如果连接要素完全位于目标要素的边界上（没有任何部件完全位于里面或外面），则不会匹配要素。</para>
		/// <para>位于—如果目标要素位于连接要素内，将匹配连接要素中包含目标要素的要素。 它与包含关系相反。 对于此选项，只有当连接要素也为面时目标要素才可为面。 仅当点同样为目标要素时，连接要素才能为点。 如果连接要素中的全部要素均位于目标要素的边界上，则不会匹配要素。</para>
		/// <para>接触—如果连接要素中具有边界与目标要素相接的要素，将匹配这些要素。 如果目标和连接要素为线或面，则连接要素的边界只可接触目标要素的边界，且连接要素的任何部分均不可跨越目标要素的边界。</para>
		/// <para>交叉—如果连接要素中具有轮廓与目标要素交叉的要素，则将匹配这些要素。 连接要素和目标要素必须是线或面。 如果将面用于连接或目标要素，则会使用面的边界（线）。 将匹配在某一点交叉的线，而不是共线的线。</para>
		/// <para>重叠—如果连接要素与目标要素重叠，将匹配连接要素中的要素。</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialRelationship { get; set; }

		/// <summary>
		/// <para>Spatial Near Distance</para>
		/// <para>与目标要素的距离，在此距离内将有可能使用连接要素进行空间连接。 仅当空间关系参数值为平面邻近或测地线邻近时，搜索半径才有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SpatialNearDistance { get; set; }

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// <para>指定将用于匹配要素的时间条件。</para>
		/// <para>汇合—当目标时间间隔终点与连接时间间隔起点一致时，目标时间与连接时间汇合。</para>
		/// <para>被汇合—当目标时间间隔起点与连接时间间隔终点一致时，目标时间被连接时间汇合。</para>
		/// <para>重叠—当目标时间间隔分别在连接时间间隔的起点和终点前开始和结束时，目标时间与连接时间重叠。</para>
		/// <para>被重叠—当目标时间间隔分别在连接时间间隔的起点和终点时间后开始和结束时，目标时间被连接时间重叠。</para>
		/// <para>期间—当目标时间发生在连接时间间隔的起点和终点之间时，目标时间处于连接时间期间。</para>
		/// <para>包含—当连接要素时间发生在目标时间间隔的起点和终点之间时，目标时间包含连接时间。</para>
		/// <para>等于—如果两个时间的时刻或间隔完全一致，则这两个时间被视为完全相同。</para>
		/// <para>结束—当目标时间与连接时间在同一时间结束，且目标时间在连接时间之后开始时，目标时间在连接时间之前结束。</para>
		/// <para>之后结束—当连接要素时间与目标时间在同一时间结束，且连接时间在目标时间之后开始时，目标时间在连接时间之后结束。</para>
		/// <para>开始—当目标时间与连接时间间隔在同一时间开始，且目标时间在连接时间间隔结束之前结束时，目标时间在连接时间之前开始。</para>
		/// <para>之后开始—当目标间隔时间与连接时间在同一时间开始，且目标时间在连接时间之后结束时，目标时间在连接时间之后开始。</para>
		/// <para>相交—当目标时间的任何一部分与连接时间在同一时间发生时，目标时间与连接时间相交。</para>
		/// <para>周边—当目标时间在连接时间的指定时间范围内时，目标时间邻近连接时间。</para>
		/// <para>近前—当目标时间在连接时间之前且与其间隔在指定时间范围内时，目标时间将处于连接时间的近前位置。</para>
		/// <para>近后—当目标时间在连接时间之后且与其间隔在指定时间范围内时，目标时间将处于连接时间的近后位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TemporalRelationship { get; set; }

		/// <summary>
		/// <para>Temporal Near Distance</para>
		/// <para>与目标要素的时间距离，其中将考虑使用连接要素来进行空间连接。 时间仅在时态关系参数值为邻近、近前或近后且两个要素均已启用时间时才有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TemporalNearDistance { get; set; }

		/// <summary>
		/// <para>Attribute Relationship</para>
		/// <para>基于属性字段内值的连接要素。 指定目标图层中与连接图层中的属性字段匹配的属性字段。</para>
		/// <para>目标字段 - 包含待匹配值的目标图层中的属性字段。</para>
		/// <para>连接字段 - 包含待匹配值的连接图层中的属性字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? AttributeRelationship { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>将根据指定字段进行计算的统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Join Condition</para>
		/// <para>将条件应用到指定字段。 将仅连接带有符合这些条件的字段的要素。</para>
		/// <para>例如，如果连接图层中的 HealthSpending 属性比目标图层中的 Income 属性大 20%，则可将连接条件应用到要素。 请使用 Arcade 表达式，例如 $join[&quot;HealthSpending&quot;] &gt; $target[&quot;Income&quot;] * .2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object? JoinCondition { get; set; }

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// <para>指定是在输出要素类中保留所有目标要素（称为左外连接），还是仅保留与连接要素具有指定关系的目标要素（内部连接）。</para>
		/// <para>选中 - 将在输出中保留所有目标要素（外部连接）。</para>
		/// <para>未选中 - 仅在输出要素类中保留具有指定关系的目标要素（内部连接）。 将从输出中排除不在面要素内部的所有点要素。 这是默认设置。</para>
		/// <para><see cref="KeepAllTargetFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepAllTargetFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JoinFeatures SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Join Operation</para>
		/// </summary>
		public enum JoinOperationEnum 
		{
			/// <summary>
			/// <para>一对一连接—系统将聚合来自多个连接要素的属性。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，将对这两个面的属性进行聚合，然后将其传递到输出点要素类。 如果一个面要素的属性值为 3，另一个面要素的属性值为 7，且为该字段指定了汇总统计数据总和，则输出要素类中的聚合值将为 10。 此为默认设置，且仅会返回计数统计数据。</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_ONE")]
			[Description("一对一连接")]
			Join_one_to_one,

			/// <summary>
			/// <para>一对多连接—输出要素类将包含目标要素的多个副本（记录）。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，则输出要素类将包含目标要素的两个副本：分别包含两个面的属性记录。 使用此方法时，没有可用的汇总统计数据。</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_MANY")]
			[Description("一对多连接")]
			Join_one_to_many,

		}

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// </summary>
		public enum SpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>相等—如果连接要素与目标要素的几何类型相同，则将匹配连接要素中的要素。</para>
			/// </summary>
			[GPValue("EQUALS")]
			[Description("相等")]
			Equals,

			/// <summary>
			/// <para>相交—如果连接要素与目标要素相交，将匹配连接要素中相交的要素。 这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("相交")]
			Intersects,

			/// <summary>
			/// <para>包含—如果目标要素中包含连接要素中的要素，将匹配连接要素中被包含的要素。 目标要素必须是面或折线。 只有当目标要素也为面时连接要素才可为面。 面可以包含任何要素类型。 折线只能包含折线和点。 点不能包含任何要素，甚至不能包含点。 如果连接要素完全位于目标要素的边界上（没有任何部件完全位于里面或外面），则不会匹配要素。</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("包含")]
			Contains,

			/// <summary>
			/// <para>位于—如果目标要素位于连接要素内，将匹配连接要素中包含目标要素的要素。 它与包含关系相反。 对于此选项，只有当连接要素也为面时目标要素才可为面。 仅当点同样为目标要素时，连接要素才能为点。 如果连接要素中的全部要素均位于目标要素的边界上，则不会匹配要素。</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("位于")]
			Within,

			/// <summary>
			/// <para>交叉—如果连接要素中具有轮廓与目标要素交叉的要素，则将匹配这些要素。 连接要素和目标要素必须是线或面。 如果将面用于连接或目标要素，则会使用面的边界（线）。 将匹配在某一点交叉的线，而不是共线的线。</para>
			/// </summary>
			[GPValue("CROSSES")]
			[Description("交叉")]
			Crosses,

			/// <summary>
			/// <para>接触—如果连接要素中具有边界与目标要素相接的要素，将匹配这些要素。 如果目标和连接要素为线或面，则连接要素的边界只可接触目标要素的边界，且连接要素的任何部分均不可跨越目标要素的边界。</para>
			/// </summary>
			[GPValue("TOUCHES")]
			[Description("接触")]
			Touches,

			/// <summary>
			/// <para>重叠—如果连接要素与目标要素重叠，将匹配连接要素中的要素。</para>
			/// </summary>
			[GPValue("OVERLAPS")]
			[Description("重叠")]
			Overlaps,

			/// <summary>
			/// <para>平面邻近—如果连接要素在目标要素的指定距离之内，将匹配处于该距离内的要素。 使用平面距离测量距离。 在空间邻近距离参数中指定距离。</para>
			/// </summary>
			[GPValue("NEAR")]
			[Description("平面邻近")]
			Planar_Near,

			/// <summary>
			/// <para>测地线邻近—如果连接要素在目标要素的指定距离之内，将匹配处于该距离内的要素。 距离将以测地线方法进行测量。 在空间邻近距离参数中指定距离。</para>
			/// </summary>
			[GPValue("NEAR_GEODESIC")]
			[Description("测地线邻近")]
			Geodesic_Near,

		}

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// </summary>
		public enum KeepAllTargetFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_COMMON")]
			KEEP_COMMON,

		}

#endregion
	}
}
