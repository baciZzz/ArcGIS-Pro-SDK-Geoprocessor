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
	/// <para>Append Events</para>
	/// <para>追加事件</para>
	/// <para>将其他事件记录从表、图层或要素类附加到现有的 ArcGIS Location Referencing 事件要素类。</para>
	/// </summary>
	public class AppendEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Event</para>
		/// <para>要追加的源事件记录。</para>
		/// </param>
		/// <param name="InTargetEvent">
		/// <para>Target Event</para>
		/// <para>源事件记录将追加到的 Location Referencing 事件图层或要素类。</para>
		/// </param>
		/// <param name="FieldMapping">
		/// <para>Field Map</para>
		/// <para>控制如何将输入事件参数值字段中的属性信息传输到目标事件参数值。</para>
		/// <para>由于输入事件参数值被追加到具有预定义方案（字段定义）的现有目标数据集中，因此不允许在目标数据集中添加或移除字段。 虽然您可以为每个输出字段设置合并规则，但该工具会忽略这些规则。</para>
		/// </param>
		public AppendEvents(object InDataset, object InTargetEvent, object FieldMapping)
		{
			this.InDataset = InDataset;
			this.InTargetEvent = InTargetEvent;
			this.FieldMapping = FieldMapping;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加事件</para>
		/// </summary>
		public override string DisplayName() => "追加事件";

		/// <summary>
		/// <para>Tool Name : AppendEvents</para>
		/// </summary>
		public override string ToolName() => "AppendEvents";

		/// <summary>
		/// <para>Tool Excute Name : locref.AppendEvents</para>
		/// </summary>
		public override string ExcuteName() => "locref.AppendEvents";

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
		public override object[] Parameters() => new object[] { InDataset, InTargetEvent, FieldMapping, LoadType!, GenerateEventIds!, GenerateShapes!, OutTargetEvent!, OutDetailsFile! };

		/// <summary>
		/// <para>Input Event</para>
		/// <para>要追加的源事件记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Target Event</para>
		/// <para>源事件记录将追加到的 Location Referencing 事件图层或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InTargetEvent { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>控制如何将输入事件参数值字段中的属性信息传输到目标事件参数值。</para>
		/// <para>由于输入事件参数值被追加到具有预定义方案（字段定义）的现有目标数据集中，因此不允许在目标数据集中添加或移除字段。 虽然您可以为每个输出字段设置合并规则，但该工具会忽略这些规则。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldMapping()]
		public object FieldMapping { get; set; }

		/// <summary>
		/// <para>Load Type</para>
		/// <para>指定如何将与目标事件记录具有相同事件 ID、测量值或时间性重叠的追加事件，加载到事件要素类中。</para>
		/// <para>加—输入事件记录将追加到目标事件参数值。 不会对目标事件记录进行任何更改。</para>
		/// <para>淘汰重叠—输入事件记录将追加到目标事件的参数值，并且目标事件参数值中与追加事件具有相同测量值或时间性重叠的任何记录都将被淘汰。 如果追加事件超过目标事件参数值，则目标事件参数值将被删除。 此选项应仅用于线性事件。</para>
		/// <para>按事件 ID 淘汰—输入事件记录将追加到目标事件的参数值，并且目标事件参数值中与追加事件具有相同事件 ID 和时间性重叠的任何记录都将被淘汰。 如果追加事件超过具有相同事件 ID 的目标事件参数值，则目标事件参数值将被删除。</para>
		/// <para>按事件 ID 替换—输入事件记录将追加到目标事件的参数值，并且目标事件参数值中与追加事件具有相同事件 ID 的任何记录都将被删除。</para>
		/// <para><see cref="LoadTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LoadType { get; set; } = "ADD";

		/// <summary>
		/// <para>Generate Event ID GUIDs for loaded events</para>
		/// <para>指定是否将为追加的输入事件记录生成事件 ID。 事件 ID 的生成将仅应用于 Event ID 字段值为 Null 的输入事件记录。</para>
		/// <para>选中 - 将为正在追加的输入事件记录生成事件 ID。</para>
		/// <para>未选中 - 不会为正在追加的输入事件记录生成事件 ID。 这是默认设置。</para>
		/// <para><see cref="GenerateEventIdsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateEventIds { get; set; } = "false";

		/// <summary>
		/// <para>Generate Shapes</para>
		/// <para>指定是否将为正在追加的记录重新生成形状。 仅当输入事件是要素图层或要素类时，此参数才有效。</para>
		/// <para>选中 - 将重新生成输入事件要素的形状。 这是默认设置。</para>
		/// <para>未选中 - 不会重新生成输入事件要素的形状。</para>
		/// <para><see cref="GenerateShapesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateShapes { get; set; } = "true";

		/// <summary>
		/// <para>Output Target Event</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutTargetEvent { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendEvents SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Load Type</para>
		/// </summary>
		public enum LoadTypeEnum 
		{
			/// <summary>
			/// <para>加—输入事件记录将追加到目标事件参数值。 不会对目标事件记录进行任何更改。</para>
			/// </summary>
			[GPValue("ADD")]
			[Description("加")]
			Add,

			/// <summary>
			/// <para>淘汰重叠—输入事件记录将追加到目标事件的参数值，并且目标事件参数值中与追加事件具有相同测量值或时间性重叠的任何记录都将被淘汰。 如果追加事件超过目标事件参数值，则目标事件参数值将被删除。 此选项应仅用于线性事件。</para>
			/// </summary>
			[GPValue("RETIRE_OVERLAPS")]
			[Description("淘汰重叠")]
			Retire_overlaps,

			/// <summary>
			/// <para>按事件 ID 淘汰—输入事件记录将追加到目标事件的参数值，并且目标事件参数值中与追加事件具有相同事件 ID 和时间性重叠的任何记录都将被淘汰。 如果追加事件超过具有相同事件 ID 的目标事件参数值，则目标事件参数值将被删除。</para>
			/// </summary>
			[GPValue("RETIRE_BY_EVENT_ID")]
			[Description("按事件 ID 淘汰")]
			Retire_by_event_ID,

			/// <summary>
			/// <para>按事件 ID 替换—输入事件记录将追加到目标事件的参数值，并且目标事件参数值中与追加事件具有相同事件 ID 的任何记录都将被删除。</para>
			/// </summary>
			[GPValue("REPLACE_BY_EVENT_ID")]
			[Description("按事件 ID 替换")]
			Replace_by_event_ID,

		}

		/// <summary>
		/// <para>Generate Event ID GUIDs for loaded events</para>
		/// </summary>
		public enum GenerateEventIdsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_EVENT_IDS")]
			GENERATE_EVENT_IDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERATE_EVENT_IDS")]
			NO_GENERATE_EVENT_IDS,

		}

		/// <summary>
		/// <para>Generate Shapes</para>
		/// </summary>
		public enum GenerateShapesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_SHAPES")]
			GENERATE_SHAPES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPES")]
			NO_SHAPES,

		}

#endregion
	}
}
