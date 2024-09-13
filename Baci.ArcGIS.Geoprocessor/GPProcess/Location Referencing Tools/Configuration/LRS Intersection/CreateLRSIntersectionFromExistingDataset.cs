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
	/// <para>Create LRS Intersection From Existing Dataset</para>
	/// <para>基于现有数据集创建 LRS 交叉点</para>
	/// <para>将现有交叉点要素类注册为交叉点。</para>
	/// </summary>
	public class CreateLRSIntersectionFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ParentNetwork">
		/// <para>Parent LRS Network</para>
		/// <para>交叉点将注册到的网络。</para>
		/// </param>
		/// <param name="NetworkDescriptionField">
		/// <para>Network Description Field</para>
		/// <para>网络图层中的字段，用于命名与其他相交图层的交叉点。</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Intersection Feature Class</para>
		/// <para>要注册的输入点要素类。</para>
		/// </param>
		/// <param name="IntersectionIdField">
		/// <para>Intersection ID Field</para>
		/// <para>交叉点要素类参数值中的 ID 字段。 该字段必须具有对于时间片的每个交叉点的唯一 ID。</para>
		/// </param>
		/// <param name="IntersectionNameField">
		/// <para>Intersection Name Field</para>
		/// <para>交叉点要素类参数值中的字段，是用于显示路径和相交要素描述符的串连字段。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>交叉点要素类参数值中包含 LRS 网络的路径 ID 的字段。</para>
		/// </param>
		/// <param name="FeatureIdField">
		/// <para>Feature ID Field</para>
		/// <para>交叉点要素类参数值中包含相交要素 ID 的字段。</para>
		/// </param>
		/// <param name="FeatureClassNameField">
		/// <para>Feature Class Name Field</para>
		/// <para>交叉点要素类参数值中包含参与交叉点的要素类名称的字段。</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>交叉点要素类参数值中的开始日期字段。</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>交叉点要素类参数值中的结束日期字段。</para>
		/// </param>
		/// <param name="IntersectingLayers">
		/// <para>Intersecting Layers</para>
		/// <para>与 LRS 网络相交并包含以下信息的要素类：</para>
		/// <para>交叉点图层 - 与 LRS 网络相交的要素类。</para>
		/// <para>ID 字段 - 相交图层中用于唯一识别与网络相交的要素的字段。</para>
		/// <para>描述字段 - 提供相交要素的描述（例如镇或县名称）的字段。</para>
		/// <para>名称分隔符 - 交叉点的名称分隔符，例如 AND、INTERSECT、+ 或 |。</para>
		/// </param>
		public CreateLRSIntersectionFromExistingDataset(object ParentNetwork, object NetworkDescriptionField, object InFeatureClass, object IntersectionIdField, object IntersectionNameField, object RouteIdField, object FeatureIdField, object FeatureClassNameField, object FromDateField, object ToDateField, object IntersectingLayers)
		{
			this.ParentNetwork = ParentNetwork;
			this.NetworkDescriptionField = NetworkDescriptionField;
			this.InFeatureClass = InFeatureClass;
			this.IntersectionIdField = IntersectionIdField;
			this.IntersectionNameField = IntersectionNameField;
			this.RouteIdField = RouteIdField;
			this.FeatureIdField = FeatureIdField;
			this.FeatureClassNameField = FeatureClassNameField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.IntersectingLayers = IntersectingLayers;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于现有数据集创建 LRS 交叉点</para>
		/// </summary>
		public override string DisplayName() => "基于现有数据集创建 LRS 交叉点";

		/// <summary>
		/// <para>Tool Name : CreateLRSIntersectionFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSIntersectionFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSIntersectionFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSIntersectionFromExistingDataset";

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
		public override object[] Parameters() => new object[] { ParentNetwork, NetworkDescriptionField, InFeatureClass, IntersectionIdField, IntersectionNameField, RouteIdField, FeatureIdField, FeatureClassNameField, FromDateField, ToDateField, IntersectingLayers, ConsiderZ!, ZTolerance!, MeasureField!, OutFeatureClass! };

		/// <summary>
		/// <para>Parent LRS Network</para>
		/// <para>交叉点将注册到的网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object ParentNetwork { get; set; }

		/// <summary>
		/// <para>Network Description Field</para>
		/// <para>网络图层中的字段，用于命名与其他相交图层的交叉点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object NetworkDescriptionField { get; set; }

		/// <summary>
		/// <para>Intersection Feature Class</para>
		/// <para>要注册的输入点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Intersection ID Field</para>
		/// <para>交叉点要素类参数值中的 ID 字段。 该字段必须具有对于时间片的每个交叉点的唯一 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID")]
		public object IntersectionIdField { get; set; }

		/// <summary>
		/// <para>Intersection Name Field</para>
		/// <para>交叉点要素类参数值中的字段，是用于显示路径和相交要素描述符的串连字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object IntersectionNameField { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>交叉点要素类参数值中包含 LRS 网络的路径 ID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Feature ID Field</para>
		/// <para>交叉点要素类参数值中包含相交要素 ID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object FeatureIdField { get; set; }

		/// <summary>
		/// <para>Feature Class Name Field</para>
		/// <para>交叉点要素类参数值中包含参与交叉点的要素类名称的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object FeatureClassNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>交叉点要素类参数值中的开始日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>交叉点要素类参数值中的结束日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Intersecting Layers</para>
		/// <para>与 LRS 网络相交并包含以下信息的要素类：</para>
		/// <para>交叉点图层 - 与 LRS 网络相交的要素类。</para>
		/// <para>ID 字段 - 相交图层中用于唯一识别与网络相交的要素的字段。</para>
		/// <para>描述字段 - 提供相交要素的描述（例如镇或县名称）的字段。</para>
		/// <para>名称分隔符 - 交叉点的名称分隔符，例如 AND、INTERSECT、+ 或 |。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object IntersectingLayers { get; set; }

		/// <summary>
		/// <para>Consider z-values when generating intersections</para>
		/// <para>指定生成交叉点时是否使用 z 值。</para>
		/// <para>选中 - 将在交叉点生成期间使用 Z 值。</para>
		/// <para>未选中 - 在交叉点生成期间不会使用 Z 值。 这是默认设置。</para>
		/// <para><see cref="ConsiderZEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConsiderZ { get; set; } = "false";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>用于生成交叉点的 z 容差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>交叉点处基本路径上的测量值。</para>
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

		#region InnerClass

		/// <summary>
		/// <para>Consider z-values when generating intersections</para>
		/// </summary>
		public enum ConsiderZEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONSIDER_Z")]
			CONSIDER_Z,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CONSIDER_Z")]
			DO_NOT_CONSIDER_Z,

		}

#endregion
	}
}
