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
	/// <para>Update Measures From LRS</para>
	/// <para>从 LRS 更新测量值</para>
	/// <para>用于填充或更新 Utility Network (UN) 要素，例如管道、设备和交汇点，或者非 UN 或 LRS 要素类中的要素上的测量值和路径 ID。</para>
	/// </summary>
	public class UpdateMeasuresFromLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LrsNetwork">
		/// <para>LRS Network</para>
		/// <para>包含路径、路径 ID 和测量值的要素图层。</para>
		/// </param>
		/// <param name="LrsDate">
		/// <para>LRS Date</para>
		/// <para>用于定义网络时间视图以收集路径和测量值的日期。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含路径 ID 和测量字段的图层，这些字段将根据与 LRS 网络参数中的路径相关的要素几何进行更新。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>输入要素图层中包含路径 ID 值的字段。</para>
		/// </param>
		/// <param name="FromMeasureField">
		/// <para>Measure Field</para>
		/// <para>输入要素图层中包含折线要素的测量值的字段。</para>
		/// </param>
		public UpdateMeasuresFromLRS(object LrsNetwork, object LrsDate, object InFeatures, object RouteIdField, object FromMeasureField)
		{
			this.LrsNetwork = LrsNetwork;
			this.LrsDate = LrsDate;
			this.InFeatures = InFeatures;
			this.RouteIdField = RouteIdField;
			this.FromMeasureField = FromMeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : 从 LRS 更新测量值</para>
		/// </summary>
		public override string DisplayName() => "从 LRS 更新测量值";

		/// <summary>
		/// <para>Tool Name : UpdateMeasuresFromLRS</para>
		/// </summary>
		public override string ToolName() => "UpdateMeasuresFromLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.UpdateMeasuresFromLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.UpdateMeasuresFromLRS";

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
		public override object[] Parameters() => new object[] { LrsNetwork, LrsDate, InFeatures, RouteIdField, FromMeasureField, ToMeasureField!, OutFeatures!, OutDetailsFile! };

		/// <summary>
		/// <para>LRS Network</para>
		/// <para>包含路径、路径 ID 和测量值的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object LrsNetwork { get; set; }

		/// <summary>
		/// <para>LRS Date</para>
		/// <para>用于定义网络时间视图以收集路径和测量值的日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object LrsDate { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含路径 ID 和测量字段的图层，这些字段将根据与 LRS 网络参数中的路径相关的要素几何进行更新。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>输入要素图层中包含路径 ID 值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>输入要素图层中包含折线要素的测量值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object FromMeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>输入要素图层中包含点要素测量值或折线要素测量值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Out Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

	}
}
