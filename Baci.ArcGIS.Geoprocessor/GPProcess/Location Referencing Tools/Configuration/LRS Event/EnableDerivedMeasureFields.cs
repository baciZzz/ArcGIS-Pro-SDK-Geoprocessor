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
	/// <para>Enable Derived Measure Fields</para>
	/// <para>启用派生的测量字段</para>
	/// <para>通过字段存储指定 LRS 事件要素类的派生路径 ID、派生路径名称和派生测量字段。</para>
	/// </summary>
	public class EnableDerivedMeasureFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Event Feature Class</para>
		/// <para>已注册到 LRS 的现有事件要素类或要素图层。</para>
		/// </param>
		public EnableDerivedMeasureFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用派生的测量字段</para>
		/// </summary>
		public override string DisplayName() => "启用派生的测量字段";

		/// <summary>
		/// <para>Tool Name : EnableDerivedMeasureFields</para>
		/// </summary>
		public override string ToolName() => "EnableDerivedMeasureFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.EnableDerivedMeasureFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.EnableDerivedMeasureFields";

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
		public override object[] Parameters() => new object[] { InFeatureClass, DerivedRouteIdField!, DerivedRouteNameField!, DerivedFromMeasureField!, DerivedToMeasureField!, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Event Feature Class</para>
		/// <para>已注册到 LRS 的现有事件要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Derived Route ID Field</para>
		/// <para>派生路径 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? DerivedRouteIdField { get; set; }

		/// <summary>
		/// <para>Derived Route Name Field</para>
		/// <para>派生路径名称字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? DerivedRouteNameField { get; set; }

		/// <summary>
		/// <para>Derived (From) Measure Field</para>
		/// <para>派生测量始于字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? DerivedFromMeasureField { get; set; }

		/// <summary>
		/// <para>Derived To Measure Field</para>
		/// <para>派生测量止于字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? DerivedToMeasureField { get; set; }

		/// <summary>
		/// <para>Updated Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
