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
	/// <para>Configure Utility Network Feature Class</para>
	/// <para>配置 Utility Network 要素类</para>
	/// <para>配置 Utility Network 管道要素类以与线性参考系 (LRS) 搭配使用。</para>
	/// </summary>
	public class ConfigureUtilityNetworkFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Utility Network Feature Layer</para>
		/// <para>同时是 LRS 中心线要素的输入 Utility Network 要素。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>要素类中将映射为 LRS 网络路径 ID 的字段。</para>
		/// </param>
		/// <param name="FromMeasureField">
		/// <para>From Measure Field</para>
		/// <para>中心线要素类的测量始于字段。</para>
		/// </param>
		/// <param name="ToMeasureField">
		/// <para>To Measure Field</para>
		/// <para>中心线要素类的测量止于字段。</para>
		/// </param>
		public ConfigureUtilityNetworkFeatureClass(object InFeatureClass, object RouteIdField, object FromMeasureField, object ToMeasureField)
		{
			this.InFeatureClass = InFeatureClass;
			this.RouteIdField = RouteIdField;
			this.FromMeasureField = FromMeasureField;
			this.ToMeasureField = ToMeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : 配置 Utility Network 要素类</para>
		/// </summary>
		public override string DisplayName() => "配置 Utility Network 要素类";

		/// <summary>
		/// <para>Tool Name : ConfigureUtilityNetworkFeatureClass</para>
		/// </summary>
		public override string ToolName() => "ConfigureUtilityNetworkFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : locref.ConfigureUtilityNetworkFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "locref.ConfigureUtilityNetworkFeatureClass";

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
		public override object[] Parameters() => new object[] { InFeatureClass, RouteIdField, FromMeasureField, ToMeasureField, OutFeatureClass! };

		/// <summary>
		/// <para>Utility Network Feature Layer</para>
		/// <para>同时是 LRS 中心线要素的输入 Utility Network 要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>要素类中将映射为 LRS 网络路径 ID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>From Measure Field</para>
		/// <para>中心线要素类的测量始于字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object FromMeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>中心线要素类的测量止于字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object ToMeasureField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
