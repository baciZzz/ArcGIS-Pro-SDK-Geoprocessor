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
	/// <para>Modify LRS Intersection</para>
	/// <para>修改 LRS 交叉点</para>
	/// <para>修改构成交叉点要素类并且可以添加或移除的交叉点要素类属性，例如字段和相交图层。</para>
	/// </summary>
	public class ModifyLRSIntersection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Intersection Feature Class</para>
		/// <para>输入 LRS 交叉点要素图层。 此要素类不能为服务。</para>
		/// </param>
		public ModifyLRSIntersection(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 修改 LRS 交叉点</para>
		/// </summary>
		public override string DisplayName() => "修改 LRS 交叉点";

		/// <summary>
		/// <para>Tool Name : ModifyLRSIntersection</para>
		/// </summary>
		public override string ToolName() => "ModifyLRSIntersection";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRSIntersection</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRSIntersection";

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
		public override object[] Parameters() => new object[] { InFeatureClass, IntersectionIdField!, IntersectionNameField!, RouteIdField!, FeatureIdField!, FeatureClassNameField!, FromDateField!, ToDateField!, IntersectingLayers!, MeasureField!, OutFeatureClass! };

		/// <summary>
		/// <para>Intersection Feature Class</para>
		/// <para>输入 LRS 交叉点要素图层。 此要素类不能为服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Intersection ID Field</para>
		/// <para>交叉点要素类中用作交叉点唯一 ID 字段的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID")]
		public object? IntersectionIdField { get; set; }

		/// <summary>
		/// <para>Intersection Name Field</para>
		/// <para>交叉点要素类中的串连字段，其中包含用于路径和相交要素描述符的串连字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? IntersectionNameField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>交叉点要素类中包含唯一路径 ID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object? RouteIdField { get; set; }

		/// <summary>
		/// <para>Feature ID Field</para>
		/// <para>交叉点要素类中包含相交要素 ID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? FeatureIdField { get; set; }

		/// <summary>
		/// <para>Feature Class Name Field</para>
		/// <para>交叉点要素类中包含参与交叉点的要素类名称的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? FeatureClassNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>交叉点要素类中包含路径开始日期的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>交叉点要素类中包含路径结束日期的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ToDateField { get; set; }

		/// <summary>
		/// <para>Intersecting Layers</para>
		/// <para>构成相交图层的交叉点要素类字段。</para>
		/// <para>交叉点图层 - 与 LRS 网络相交的要素类。</para>
		/// <para>ID 字段 - 相交图层中用于唯一识别与网络相交的要素的字段。</para>
		/// <para>描述字段 - 提供相交要素的描述（例如镇或县名称）的字段。</para>
		/// <para>名称分隔符 - 交叉点的名称分隔符，例如 AND、INTERSECT、+ 或 |。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? IntersectingLayers { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>交叉点要素类中的字段，其中包含在交叉点基本路径上的测量值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? MeasureField { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

	}
}
