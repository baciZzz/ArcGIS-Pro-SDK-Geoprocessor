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
	/// <para>Configure External Event With LRS</para>
	/// <para>使用 LRS 配置外部事件</para>
	/// <para>将存储在外部系统中的事件数据与 LRS 相关联。</para>
	/// </summary>
	public class ConfigureExternalEventWithLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InEvent">
		/// <para>Input Event</para>
		/// <para>要注册到 LRS 的外部事件要素类或表。</para>
		/// </param>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>事件将注册到的 LRS 网络。</para>
		/// </param>
		/// <param name="EventName">
		/// <para>LRS Event Name</para>
		/// <para>将注册到 LRS 的外部事件或表的名称。</para>
		/// </param>
		/// <param name="EventIdField">
		/// <para>Event ID Field</para>
		/// <para>事件要素类或表中可用的事件 ID 字段。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>如果是不跨越路径的点事件或线事件，则为路径 ID 字段的名称；如果事件跨越路径，则为来自路径 ID 字段的名称。 该字段必须在外部事件表或要素类中可用。</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>如果是点事件，则为“测量”字段的名称；如果是线事件，则为“测量始于”字段的名称。</para>
		/// </param>
		public ConfigureExternalEventWithLRS(object InEvent, object ParentNetwork, object EventName, object EventIdField, object RouteIdField, object MeasureField)
		{
			this.InEvent = InEvent;
			this.ParentNetwork = ParentNetwork;
			this.EventName = EventName;
			this.EventIdField = EventIdField;
			this.RouteIdField = RouteIdField;
			this.MeasureField = MeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用 LRS 配置外部事件</para>
		/// </summary>
		public override string DisplayName() => "使用 LRS 配置外部事件";

		/// <summary>
		/// <para>Tool Name : ConfigureExternalEventWithLRS</para>
		/// </summary>
		public override string ToolName() => "ConfigureExternalEventWithLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.ConfigureExternalEventWithLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.ConfigureExternalEventWithLRS";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InEvent, ParentNetwork, EventName, EventIdField, RouteIdField, MeasureField, GeometryType!, ToMeasureField!, FromDateField!, ToDateField!, EventSpansRoutes!, ToRouteIdField!, StoreRouteName!, RouteNameField!, ToRouteNameField!, CalibrateRule!, RetireRule!, ExtendRule!, ReassignRule!, RealignRule!, OutExternalEventTable!, ReverseRule!, CartoRealignRule! };

		/// <summary>
		/// <para>Input Event</para>
		/// <para>要注册到 LRS 的外部事件要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InEvent { get; set; }

		/// <summary>
		/// <para>Parent LRS Network</para>
		/// <para>事件将注册到的 LRS 网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object ParentNetwork { get; set; }

		/// <summary>
		/// <para>LRS Event Name</para>
		/// <para>将注册到 LRS 的外部事件或表的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EventName { get; set; }

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>事件要素类或表中可用的事件 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object EventIdField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>如果是不跨越路径的点事件或线事件，则为路径 ID 字段的名称；如果事件跨越路径，则为来自路径 ID 字段的名称。 该字段必须在外部事件表或要素类中可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>如果是点事件，则为“测量”字段的名称；如果是线事件，则为“测量始于”字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object MeasureField { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>指定外部事件或表的几何类型。</para>
		/// <para>点—事件的几何类型将是点。 这是默认设置。</para>
		/// <para>线—事件的几何类型将是折线。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "POINT";

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>“测量止于”字段的名称 此字段仅对线路事件是必需的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>事件要素类或表中的开始日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>事件要素类或表中的“结束日期”字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ToDateField { get; set; }

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// <para>指定事件记录是否跨越路径。</para>
		/// <para>原样—不会更改属性。 这是默认设置。</para>
		/// <para>不跨越路径—事件记录不会跨越路径。 此选项仅适用于线事件。</para>
		/// <para>跨越路径—事件记录将跨越路径。 此选项仅适用于线事件。</para>
		/// <para><see cref="EventSpansRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EventSpansRoutes { get; set; } = "AS_IS";

		/// <summary>
		/// <para>To Route ID Field</para>
		/// <para>事件要素类或表中可用的“路径止于 ID”字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? ToRouteIdField { get; set; }

		/// <summary>
		/// <para>Store Route Name</para>
		/// <para>指定是否将路径名称与事件记录一起存储。</para>
		/// <para>原样—不会更改属性。 这是默认设置。</para>
		/// <para>不存储路径名称—路径名称不会与事件记录一起存储。</para>
		/// <para>存储路径名称—路径名称将与事件记录一起存储。</para>
		/// <para><see cref="StoreRouteNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StoreRouteName { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>如果是不跨越路径的点事件或线事件，则为路径名称字段；如果事件跨越路径，则为“路径始于名称”字段的名称。 该字段必须在外部事件表或要素类中可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>跨越路径的线事件的“路径止于名称”字段。 如果设置了存储路径名称和事件跨越路径参数，则需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// <para>指定校准活动的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para><see cref="CalibrateRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object? CalibrateRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Retire Rule</para>
		/// <para>指定停用活动的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para><see cref="RetireRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object? RetireRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Extend Rule</para>
		/// <para>指定扩展活动的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
		/// <para><see cref="ExtendRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object? ExtendRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Reassign Rule</para>
		/// <para>指定重新分配活动的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para>捕捉—通过将事件捕捉到并发路线，保留事件的地理位置；测量值可能会改变。</para>
		/// <para><see cref="ReassignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object? ReassignRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Realign Rule</para>
		/// <para>指定重新对齐活动的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para>捕捉—通过将事件捕捉到并发路线，保留事件的地理位置；测量值可能会改变。</para>
		/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
		/// <para><see cref="RealignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object? RealignRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Output External Event Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutExternalEventTable { get; set; }

		/// <summary>
		/// <para>Reverse Rule</para>
		/// <para>指定反向活动的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para><see cref="ReverseRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object? ReverseRule { get; set; } = "STAY_PUT";

		/// <summary>
		/// <para>Carto Realign Rule</para>
		/// <para>指定制图重新对齐活动的事件行为规则。</para>
		/// <para>支持路径测量—将保留事件的测量值，或与路径测量值更改成比例地更改测量值。 这是默认设置。</para>
		/// <para><see cref="CartoRealignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Behavior Rules")]
		public object? CartoRealignRule { get; set; } = "HONOR_ROUTE_MEASURE";

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>点—事件的几何类型将是点。 这是默认设置。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>线—事件的几何类型将是折线。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线")]
			Line,

		}

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// </summary>
		public enum EventSpansRoutesEnum 
		{
			/// <summary>
			/// <para>原样—不会更改属性。 这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("原样")]
			As_is,

			/// <summary>
			/// <para>不跨越路径—事件记录不会跨越路径。 此选项仅适用于线事件。</para>
			/// </summary>
			[GPValue("NO_SPANS_ROUTES")]
			[Description("不跨越路径")]
			Do_not_span_routes,

			/// <summary>
			/// <para>跨越路径—事件记录将跨越路径。 此选项仅适用于线事件。</para>
			/// </summary>
			[GPValue("SPANS_ROUTES")]
			[Description("跨越路径")]
			Spans_routes,

		}

		/// <summary>
		/// <para>Store Route Name</para>
		/// </summary>
		public enum StoreRouteNameEnum 
		{
			/// <summary>
			/// <para>原样—不会更改属性。 这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("原样")]
			As_is,

			/// <summary>
			/// <para>不存储路径名称—路径名称不会与事件记录一起存储。</para>
			/// </summary>
			[GPValue("NO_STORE_ROUTE_NAME")]
			[Description("不存储路径名称")]
			Do_not_store_route_name,

			/// <summary>
			/// <para>存储路径名称—路径名称将与事件记录一起存储。</para>
			/// </summary>
			[GPValue("STORE_ROUTE_NAME")]
			[Description("存储路径名称")]
			Store_route_name,

		}

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// </summary>
		public enum CalibrateRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

		}

		/// <summary>
		/// <para>Retire Rule</para>
		/// </summary>
		public enum RetireRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

		}

		/// <summary>
		/// <para>Extend Rule</para>
		/// </summary>
		public enum ExtendRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

			/// <summary>
			/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
			/// </summary>
			[GPValue("COVER")]
			[Description("覆盖")]
			Cover,

		}

		/// <summary>
		/// <para>Reassign Rule</para>
		/// </summary>
		public enum ReassignRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

			/// <summary>
			/// <para>捕捉—通过将事件捕捉到并发路线，保留事件的地理位置；测量值可能会改变。</para>
			/// </summary>
			[GPValue("SNAP")]
			[Description("捕捉")]
			Snap,

		}

		/// <summary>
		/// <para>Realign Rule</para>
		/// </summary>
		public enum RealignRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

			/// <summary>
			/// <para>捕捉—通过将事件捕捉到并发路线，保留事件的地理位置；测量值可能会改变。</para>
			/// </summary>
			[GPValue("SNAP")]
			[Description("捕捉")]
			Snap,

			/// <summary>
			/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
			/// </summary>
			[GPValue("COVER")]
			[Description("覆盖")]
			Cover,

		}

		/// <summary>
		/// <para>Reverse Rule</para>
		/// </summary>
		public enum ReverseRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

		}

		/// <summary>
		/// <para>Carto Realign Rule</para>
		/// </summary>
		public enum CartoRealignRuleEnum 
		{
			/// <summary>
			/// <para>支持路径测量—将保留事件的测量值，或与路径测量值更改成比例地更改测量值。 这是默认设置。</para>
			/// </summary>
			[GPValue("HONOR_ROUTE_MEASURE")]
			[Description("支持路径测量")]
			Honor_Route_Measure,

		}

#endregion
	}
}
