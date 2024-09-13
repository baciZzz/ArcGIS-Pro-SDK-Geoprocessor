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
	/// <para>Enable Referent Fields</para>
	/// <para>启用参考字段</para>
	/// <para>启用或修改参考字段，这样您可以管理已注册 LRS 事件的参考信息。</para>
	/// </summary>
	public class EnableReferentFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>将用于 LRS 事件的要素类。</para>
		/// </param>
		public EnableReferentFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用参考字段</para>
		/// </summary>
		public override string DisplayName() => "启用参考字段";

		/// <summary>
		/// <para>Tool Name : EnableReferentFields</para>
		/// </summary>
		public override string ToolName() => "EnableReferentFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.EnableReferentFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.EnableReferentFields";

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
		public override object[] Parameters() => new object[] { InFeatureClass, FromReferentMethodField!, FromReferentLocationField!, FromReferentOffsetField!, ToReferentMethodField!, ToReferentLocationField!, ToReferentOffsetField!, OffsetUnits!, OutFeatureClass! };

		/// <summary>
		/// <para>Event Feature Class</para>
		/// <para>将用于 LRS 事件的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Referent Method Field</para>
		/// <para>自参考方法字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		public object? FromReferentMethodField { get; set; }

		/// <summary>
		/// <para>Referent Location Field</para>
		/// <para>自参考位置字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? FromReferentLocationField { get; set; }

		/// <summary>
		/// <para>Referent Offset Field</para>
		/// <para>自参考偏移字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? FromReferentOffsetField { get; set; }

		/// <summary>
		/// <para>To Referent Method Field</para>
		/// <para>至参考方法字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		public object? ToReferentMethodField { get; set; }

		/// <summary>
		/// <para>To Referent Location Field</para>
		/// <para>至参考位置字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToReferentLocationField { get; set; }

		/// <summary>
		/// <para>To Referent Offset Field</para>
		/// <para>至参考偏移字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToReferentOffsetField { get; set; }

		/// <summary>
		/// <para>Offset Units</para>
		/// <para>指定要使用的偏移单位。</para>
		/// <para>英里(美制测量)—测量单位为英里。 这是默认设置。</para>
		/// <para>英寸(美制测量)—测量单位为英寸。</para>
		/// <para>英尺(美制测量)—测量单位为英尺。</para>
		/// <para>码(美制测量)—测量单位为码。</para>
		/// <para>海里(美制测量)—测量单位为海里。</para>
		/// <para>英尺(国际)—测量单位为国际英尺。</para>
		/// <para>毫米—测量单位为毫米。</para>
		/// <para>厘米—测量单位为厘米。</para>
		/// <para>米—测量单位为米。</para>
		/// <para>千米—测量单位为千米。</para>
		/// <para>分米—测量单位为分米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OffsetUnits { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
