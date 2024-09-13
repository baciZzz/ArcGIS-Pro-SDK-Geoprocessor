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
	/// <para>Create LRS Event From Existing Dataset</para>
	/// <para>基于现有数据集创建 LRS 事件</para>
	/// <para>将现有要素类注册为 LRS 事件。</para>
	/// </summary>
	public class CreateLRSEventFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>事件将注册到的网络。</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>要注册的事件。</para>
		/// </param>
		/// <param name="EventIdField">
		/// <para>Event ID Field</para>
		/// <para>事件要素类中的事件 ID 字段。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>如果要素类是不跨越路径的点事件，则为路径 ID 字段；如果要素类是跨越路径的线事件，则为路径始于 ID 字段。</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>事件要素类中的开始日期字段。</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>事件要素类中的结束日期字段。</para>
		/// </param>
		/// <param name="LocErrorField">
		/// <para>Loc Error Field</para>
		/// <para>事件要素类中的位置错误字段。</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>如果要素类是点事件，则为测量字段；如果要素类是线事件，则为测量始于字段。</para>
		/// </param>
		public CreateLRSEventFromExistingDataset(object ParentNetwork, object InFeatureClass, object EventIdField, object RouteIdField, object FromDateField, object ToDateField, object LocErrorField, object MeasureField)
		{
			this.ParentNetwork = ParentNetwork;
			this.InFeatureClass = InFeatureClass;
			this.EventIdField = EventIdField;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.LocErrorField = LocErrorField;
			this.MeasureField = MeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于现有数据集创建 LRS 事件</para>
		/// </summary>
		public override string DisplayName() => "基于现有数据集创建 LRS 事件";

		/// <summary>
		/// <para>Tool Name : CreateLRSEventFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSEventFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSEventFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSEventFromExistingDataset";

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
		public override object[] Parameters() => new object[] { ParentNetwork, InFeatureClass, EventIdField, RouteIdField, FromDateField, ToDateField, LocErrorField, MeasureField, ToMeasureField!, EventSpansRoutes!, ToRouteIdField!, StoreRouteName!, RouteNameField!, ToRouteNameField!, OutFeatureClass! };

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
		/// <para>Event Feature Class</para>
		/// <para>要注册的事件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Event ID Field</para>
		/// <para>事件要素类中的事件 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object EventIdField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>如果要素类是不跨越路径的点事件，则为路径 ID 字段；如果要素类是跨越路径的线事件，则为路径始于 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>事件要素类中的开始日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>事件要素类中的结束日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Loc Error Field</para>
		/// <para>事件要素类中的位置错误字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object LocErrorField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>如果要素类是点事件，则为测量字段；如果要素类是线事件，则为测量始于字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object MeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>事件要素类中的测量止于字段。 此参数为线路事件的必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
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
		/// <para>跨越路径的事件的路径 ID 字段。 如果事件要素类几何类型为折线，则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
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
		/// <para>如果要素类是不跨越路径的点事件，则为路径名称字段；如果要素类是跨越路径的线事件，则为路径始于名称字段。 如果选中存储路径名称，则该参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>To Route Name Field</para>
		/// <para>跨越路径的线事件的“路径止于名称”字段。 如果选中存储路径名称，则该参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToRouteNameField { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
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
