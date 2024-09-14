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
	/// <para>Create LRS Event</para>
	/// <para>创建 LRS 事件</para>
	/// <para>为现有 LRS 网络创建线或点事件。</para>
	/// </summary>
	public class CreateLRSEvent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>事件将注册到的网络。</para>
		/// </param>
		/// <param name="EventName">
		/// <para>Event Name</para>
		/// <para>要注册的事件。</para>
		/// </param>
		/// <param name="GeometryType">
		/// <para>Geometry Type</para>
		/// <para>输出事件的几何类型。</para>
		/// <para>点—事件的几何类型为“点”。 这是默认设置。</para>
		/// <para>线—事件的几何类型为“折线”。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </param>
		/// <param name="EventIdField">
		/// <para>Event ID Field</para>
		/// <para>事件要素类中可用的事件 ID 字段。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>如果是不跨越路径的点事件，则为路径 ID 字段的名称；如果事件跨越路径，则为路径始于 ID 字段。 路径可用于事件要素类。</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>事件要素类中可用的开始日期字段。</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>事件要素类中可用的结束日期字段。</para>
		/// </param>
		/// <param name="LocErrorField">
		/// <para>Location Error Field</para>
		/// <para>事件要素类中可用的位置错误字段。</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>如果是点事件，则为测量字段的名称；如果是线事件，则为测量始于字段。</para>
		/// </param>
		public CreateLRSEvent(object ParentNetwork, object EventName, object GeometryType, object EventIdField, object RouteIdField, object FromDateField, object ToDateField, object LocErrorField, object MeasureField)
		{
			this.ParentNetwork = ParentNetwork;
			this.EventName = EventName;
			this.GeometryType = GeometryType;
			this.EventIdField = EventIdField;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.LocErrorField = LocErrorField;
			this.MeasureField = MeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 LRS 事件</para>
		/// </summary>
		public override string DisplayName() => "创建 LRS 事件";

		/// <summary>
		/// <para>Tool Name : CreateLRSEvent</para>
		/// </summary>
		public override string ToolName() => "CreateLRSEvent";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSEvent</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSEvent";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ParentNetwork, EventName, GeometryType, EventIdField, RouteIdField, FromDateField, ToDateField, LocErrorField, MeasureField, ToMeasureField!, EventSpansRoutes!, ToRouteIdField!, StoreRouteName!, RouteNameField!, ToRouteNameField!, OutFeatureClass! };

		/// <summary>
		/// <para>Parent LRS Network</para>
		/// <para>事件将注册到的网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object ParentNetwork { get; set; }

		/// <summary>
		/// <para>Event Name</para>
		/// <para>要注册的事件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EventName { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>输出事件的几何类型。</para>
		/// <para>点—事件的几何类型为“点”。 这是默认设置。</para>
		/// <para>线—事件的几何类型为“折线”。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POINT";

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>事件要素类中可用的事件 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EventIdField { get; set; } = "EventId";

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>如果是不跨越路径的点事件，则为路径 ID 字段的名称；如果事件跨越路径，则为路径始于 ID 字段。 路径可用于事件要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteIdField { get; set; } = "RouteId";

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>事件要素类中可用的开始日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromDateField { get; set; } = "FromDate";

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>事件要素类中可用的结束日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToDateField { get; set; } = "ToDate";

		/// <summary>
		/// <para>Location Error Field</para>
		/// <para>事件要素类中可用的位置错误字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LocErrorField { get; set; } = "LocError";

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>如果是点事件，则为测量字段的名称；如果是线事件，则为测量始于字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object MeasureField { get; set; } = "Measure";

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>测量止于字段的名称。 此为线事件的必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// <para>指定事件记录是否跨越路径。</para>
		/// <para>选中 - 事件记录将跨越路径。</para>
		/// <para>未选中 - 事件记录不会跨越路径。 这是默认设置。</para>
		/// <para><see cref="EventSpansRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EventSpansRoutes { get; set; } = "false";

		/// <summary>
		/// <para>To Route ID Field</para>
		/// <para>路径止于 ID 字段的名称。 仅当几何类型为线且已选中事件跨越路径复选框时，此内容才为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ToRouteIdField { get; set; }

		/// <summary>
		/// <para>Store Route Name</para>
		/// <para>指定是否将路径名称与事件记录一起存储。</para>
		/// <para>选中 - 路径名称将与事件记录一起存储。</para>
		/// <para>未选中 - 路径名称不会与事件记录一起存储。 这是默认设置。</para>
		/// <para><see cref="StoreRouteNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? StoreRouteName { get; set; } = "false";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>如果为不跨越路径的点事件，则为路径名称字段；如果为跨越路径的线事件，则为路径始于名称字段。 如果选中存储路径名称，则此内容为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>跨越路径的线事件的“路径止于名称”字段。 如果选中存储路径名称，则此内容为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>点—事件的几何类型为“点”。 这是默认设置。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>线—事件的几何类型为“折线”。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SPANS_ROUTES")]
			SPANS_ROUTES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPANS_ROUTES")]
			NO_SPANS_ROUTES,

		}

		/// <summary>
		/// <para>Store Route Name</para>
		/// </summary>
		public enum StoreRouteNameEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("STORE_ROUTE_NAME")]
			STORE_ROUTE_NAME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STORE_ROUTE_NAME")]
			NO_STORE_ROUTE_NAME,

		}

#endregion
	}
}
