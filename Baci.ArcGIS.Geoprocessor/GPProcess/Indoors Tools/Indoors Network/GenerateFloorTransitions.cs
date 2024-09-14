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
	/// <para>Generate Floor Transitions</para>
	/// <para>生成楼层过渡</para>
	/// <para>用于创建或更新垂直连接楼层的过渡线要素。</para>
	/// </summary>
	public class GenerateFloorTransitions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FacilityFeatures">
		/// <para>Input Facility Features</para>
		/// <para>表示一个或多个设施点的输入面要素。 在 Indoors 模型中，此项将为 Facilities 图层。 该工具将仅处理这些要素表示的设施点。</para>
		/// </param>
		/// <param name="TransitionUnitFeatures">
		/// <para>Transition Unit Features</para>
		/// <para>表示设施点中的过渡空间的输入面要素。 在 Indoors 模型中，此项将为 Units 图层。</para>
		/// </param>
		/// <param name="PathwayFeatures">
		/// <para>Pathway Features</para>
		/// <para>表示初步路径的输入折线要素。 新的过渡要素将捕捉到这些折线要素。 在 Indoors 模型中，此项将为 PrelimPathways 图层。</para>
		/// </param>
		/// <param name="TargetTransitions">
		/// <para>Target Transitions</para>
		/// <para>将使用新过渡更新的现有要素类或图层。 在 Indoors 模型中，此项将为 PrelimTransitions 图层。</para>
		/// </param>
		public GenerateFloorTransitions(object FacilityFeatures, object TransitionUnitFeatures, object PathwayFeatures, object TargetTransitions)
		{
			this.FacilityFeatures = FacilityFeatures;
			this.TransitionUnitFeatures = TransitionUnitFeatures;
			this.PathwayFeatures = PathwayFeatures;
			this.TargetTransitions = TargetTransitions;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成楼层过渡</para>
		/// </summary>
		public override string DisplayName() => "生成楼层过渡";

		/// <summary>
		/// <para>Tool Name : GenerateFloorTransitions</para>
		/// </summary>
		public override string ToolName() => "GenerateFloorTransitions";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateFloorTransitions</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateFloorTransitions";

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
		public override object[] Parameters() => new object[] { FacilityFeatures, TransitionUnitFeatures, PathwayFeatures, TargetTransitions, ElevatorDelay!, DeleteExistingTransitions!, StairwayUnitExp!, ElevatorUnitExp!, UpdatedTransitions! };

		/// <summary>
		/// <para>Input Facility Features</para>
		/// <para>表示一个或多个设施点的输入面要素。 在 Indoors 模型中，此项将为 Facilities 图层。 该工具将仅处理这些要素表示的设施点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object FacilityFeatures { get; set; }

		/// <summary>
		/// <para>Transition Unit Features</para>
		/// <para>表示设施点中的过渡空间的输入面要素。 在 Indoors 模型中，此项将为 Units 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object TransitionUnitFeatures { get; set; }

		/// <summary>
		/// <para>Pathway Features</para>
		/// <para>表示初步路径的输入折线要素。 新的过渡要素将捕捉到这些折线要素。 在 Indoors 模型中，此项将为 PrelimPathways 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object PathwayFeatures { get; set; }

		/// <summary>
		/// <para>Target Transitions</para>
		/// <para>将使用新过渡更新的现有要素类或图层。 在 Indoors 模型中，此项将为 PrelimTransitions 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetTransitions { get; set; }

		/// <summary>
		/// <para>Elevator Delay</para>
		/// <para>平均电梯过渡时间。 电梯乘客预期等待进入和离开电梯所花费时间的一半，以秒为单位。 使用此参数可以改善路径选择和过渡时间计算。 该值必须等于或大于零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 1000)]
		public object? ElevatorDelay { get; set; }

		/// <summary>
		/// <para>Delete Existing Transitions</para>
		/// <para>指定在创建新的过渡要素之前，是否将删除所选过渡空间中的现有过渡要素。 如果不使用此参数，则已更新的过渡将包含现有过渡要素和新创建的过渡要素。</para>
		/// <para>选中 - 将删除现有过渡要素。 这是默认设置。</para>
		/// <para>未选中 - 将不删除现有过渡要素。</para>
		/// <para><see cref="DeleteExistingTransitionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteExistingTransitions { get; set; } = "true";

		/// <summary>
		/// <para>Stairway Unit Expression</para>
		/// <para>一个 SQL 表达式，用于定义表示基于台阶的过渡的过渡单元要素值，例如楼梯和自动扶梯。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? StairwayUnitExp { get; set; }

		/// <summary>
		/// <para>Elevator Unit Expression</para>
		/// <para>一个 SQL 表达式，用于定义表示基于提升的过渡的过渡单元要素值，例如电梯。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? ElevatorUnitExp { get; set; }

		/// <summary>
		/// <para>Updated Transitions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedTransitions { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Delete Existing Transitions</para>
		/// </summary>
		public enum DeleteExistingTransitionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_FEATURES")]
			DELETE_FEATURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_FEATURES")]
			NO_DELETE_FEATURES,

		}

#endregion
	}
}
