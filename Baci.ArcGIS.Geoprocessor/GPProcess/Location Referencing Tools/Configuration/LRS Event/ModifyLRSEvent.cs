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
	/// <para>Modify LRS Event</para>
	/// <para>修改 LRS 事件</para>
	/// <para>修改线性参考系统 (LRS) 事件的属性。</para>
	/// </summary>
	public class ModifyLRSEvent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Event Feature Class</para>
		/// <para>事件的输入要素类或要素图层。</para>
		/// </param>
		public ModifyLRSEvent(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 修改 LRS 事件</para>
		/// </summary>
		public override string DisplayName() => "修改 LRS 事件";

		/// <summary>
		/// <para>Tool Name : ModifyLRSEvent</para>
		/// </summary>
		public override string ToolName() => "ModifyLRSEvent";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRSEvent</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRSEvent";

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
		public override object[] Parameters() => new object[] { InFeatureClass, EventIdField!, RouteIdField!, FromDateField!, ToDateField!, LocErrorField!, MeasureField!, ToMeasureField!, EventSpansRoutes!, ToRouteIdField!, StoreRouteName!, RouteNameField!, ToRouteNameField!, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Event Feature Class</para>
		/// <para>事件的输入要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>事件 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? EventIdField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>路径 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? RouteIdField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>开始日期字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>结束日期字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ToDateField { get; set; }

		/// <summary>
		/// <para>Location Error Field</para>
		/// <para>位置错误字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? LocErrorField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>如果是点事件，则为测量字段的名称；如果是线事件，则为测量始于字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? MeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>测量止于字段的名称。 此为线事件的必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// <para>指定事件记录是否跨越路径。</para>
		/// <para>AS_IS—未更改属性。 这是默认设置。</para>
		/// <para>NO_SPANS_ROUTES—事件记录不会跨越路径。 仅适用于线事件。</para>
		/// <para>SPANS_ROUTES—事件记录可能跨越路径。 仅适用于线事件。</para>
		/// <para><see cref="EventSpansRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EventSpansRoutes { get; set; } = "AS_IS";

		/// <summary>
		/// <para>To Route ID Field</para>
		/// <para>路径止于 ID 字段的名称。 仅当其为线事件并且跨越路径时，此内容才为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? ToRouteIdField { get; set; }

		/// <summary>
		/// <para>Store Route Name</para>
		/// <para>指定事件记录是否将存储路径名称。</para>
		/// <para>AS_IS—未更改属性。 这是默认设置。</para>
		/// <para>STORE_ROUTE_NAME—路径名称将与事件记录一起存储。</para>
		/// <para>NO_STORE_ROUTE_NAME—路径名称不会与事件记录一起存储。</para>
		/// <para><see cref="StoreRouteNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StoreRouteName { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>如果为不跨越路径的点事件，则为路径名称字段；如果为跨越路径的线事件，则为路径始于名称字段。 如果启用了存储路径名称，则此内容为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>路径止于名称字段的名称。 如果其为线事件，已选择保存路径名称，并且跨越路径，则此内容为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Updated LRS Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Event Spans Routes</para>
		/// </summary>
		public enum EventSpansRoutesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("保留原样")]
			As_is,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_SPANS_ROUTES")]
			[Description("不跨越路径")]
			Do_not_span_routes,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("保留原样")]
			As_is,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_STORE_ROUTE_NAME")]
			[Description("不存储路径名称")]
			Do_not_store_route_name,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("STORE_ROUTE_NAME")]
			[Description("存储路径名称")]
			Store_route_name,

		}

#endregion
	}
}
