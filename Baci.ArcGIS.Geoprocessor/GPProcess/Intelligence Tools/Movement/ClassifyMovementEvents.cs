using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Classify Movement Events</para>
	/// <para>分类移动事件</para>
	/// <para>识别输入点轨迹数据集中的转弯事件、加速事件和速度。</para>
	/// </summary>
	public class ClassifyMovementEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>启用时间的点要素图层，具有用于注记与每个点关联的轨迹的字段。 几何、对象标识符、轨迹名称和时间将传递到输出要素类。 输入必须采用投影坐标系。</para>
		/// </param>
		/// <param name="IdField">
		/// <para>ID Field</para>
		/// <para>输入要素中的字段，用于获取每个点轨迹的唯一标识符。 该字段将复制到输出要素类。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>将包含计算的移动事件的输出要素类。</para>
		/// </param>
		public ClassifyMovementEvents(object InFeatures, object IdField, object OutFeatureclass)
		{
			this.InFeatures = InFeatures;
			this.IdField = IdField;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : 分类移动事件</para>
		/// </summary>
		public override string DisplayName() => "分类移动事件";

		/// <summary>
		/// <para>Tool Name : ClassifyMovementEvents</para>
		/// </summary>
		public override string ToolName() => "ClassifyMovementEvents";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.ClassifyMovementEvents</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.ClassifyMovementEvents";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, IdField, OutFeatureclass, Curvature!, NumberOfPoints!, RegionsOfInterest!, RoiIdField!, IncludeTurnIds!, ExcludeNonTurnEvents!, TurnEventsRepresentation! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>启用时间的点要素图层，具有用于注记与每个点关联的轨迹的字段。 几何、对象标识符、轨迹名称和时间将传递到输出要素类。 输入必须采用投影坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>输入要素中的字段，用于获取每个点轨迹的唯一标识符。 该字段将复制到输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含计算的移动事件的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Curvature</para>
		/// <para>将事件分类为转弯事件所需的最小值。 在计算曲率后，大于此值的任何计算曲率都会导致在 turn_event 字段中填充相关的转弯事件，而小于此值的值将导致 turn_event 字段分类为行驶中。</para>
		/// <para>转弯使用曲率和点数参数进行计算。 系统将基于从轨迹中上一个点到当前点以及从当前点到轨迹中下一个点的方位角来计算每个点。 如果该值超过曲率参数中指定的值，则系统会将其视为转弯。 否则，系统会将其视为行驶中。 对于代表大型对象的轨迹，建议您增加点数值，以解决转弯执行时间较长的问题。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Curvature { get; set; } = "15";

		/// <summary>
		/// <para>Number Of Points</para>
		/// <para>计算方位角差值时，位于给定点之前和之后的待计算点数。 使用采样速率（亚秒）较高的数据时，可能需要增加点数参数值，以考虑在该短暂时间内可能发生的移动减少。 假设每秒对输入数据采样一次，则值 1 适用于汽车和行人。 对于航空器和船舶，必须使用较大的值；对这些使用值 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfPoints { get; set; } = "1";

		/// <summary>
		/// <para>Regions Of Interest</para>
		/// <para>感兴趣区域。 此输入要素图层必须为面要素类。 如果提供了一个值，roi 字段将添加到输出要素类参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? RegionsOfInterest { get; set; }

		/// <summary>
		/// <para>Regions Of Interest ID Field</para>
		/// <para>来自感兴趣区域参数的字段，包含每个感兴趣区域的唯一标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? RoiIdField { get; set; }

		/// <summary>
		/// <para>Create Turn Event Identifiers</para>
		/// <para>指定在输出要素类中是否将创建转弯事件标识符。</para>
		/// <para>选中 - 将创建唯一转弯事件标识符。</para>
		/// <para>未选中 - 不创建唯一转弯事件标识符。 这是默认设置。</para>
		/// <para><see cref="IncludeTurnIdsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeTurnIds { get; set; } = "false";

		/// <summary>
		/// <para>Exclude Non-Turn Events</para>
		/// <para>指定是否排除 turn_event 字段值为 Traveling 的要素。</para>
		/// <para>选中 - 将排除 turn_event 字段值为 Traveling 的要素。</para>
		/// <para>未选中 - 不排除 turn_event 字段值为 Traveling 的要素；将返回所有要素。 这是默认设置。</para>
		/// <para><see cref="ExcludeNonTurnEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExcludeNonTurnEvents { get; set; } = "false";

		/// <summary>
		/// <para>Turn Events Feature Representation</para>
		/// <para>指定如何表示输出转弯事件。</para>
		/// <para>所有要素—将返回与转弯事件相关的所有点。 这是默认设置。</para>
		/// <para>转弯中点—将返回转弯事件的平均中心。</para>
		/// <para><see cref="TurnEventsRepresentationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TurnEventsRepresentation { get; set; } = "ALL_FEATURES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyMovementEvents SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Turn Event Identifiers</para>
		/// </summary>
		public enum IncludeTurnIdsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_TURN_IDS")]
			INCLUDE_TURN_IDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TURN_IDS")]
			NO_TURN_IDS,

		}

		/// <summary>
		/// <para>Exclude Non-Turn Events</para>
		/// </summary>
		public enum ExcludeNonTurnEventsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_TURN_EVENTS")]
			ONLY_TURN_EVENTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL_FEATURES")]
			ALL_FEATURES,

		}

		/// <summary>
		/// <para>Turn Events Feature Representation</para>
		/// </summary>
		public enum TurnEventsRepresentationEnum 
		{
			/// <summary>
			/// <para>所有要素—将返回与转弯事件相关的所有点。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("所有要素")]
			All_features,

			/// <summary>
			/// <para>转弯中点—将返回转弯事件的平均中心。</para>
			/// </summary>
			[GPValue("TURN_MIDPOINT")]
			[Description("转弯中点")]
			Turn_midpoint,

		}

#endregion
	}
}
