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
	/// <para>Create LRS Intersection</para>
	/// <para>创建 LRS 交叉点</para>
	/// <para>为现有 LRS 网络创建交叉点要素类。</para>
	/// </summary>
	public class CreateLRSIntersection : AbstractGPProcess
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
		/// <param name="IntersectionFeatureClassName">
		/// <para>Intersection Feature Class</para>
		/// <para>新建交点要素类的名称。</para>
		/// </param>
		/// <param name="IntersectingLayers">
		/// <para>Intersecting Layers</para>
		/// <para>与 LRS 网络相交并包含以下信息的要素类：</para>
		/// <para>交叉点图层 - 与 LRS 网络相交的要素类。</para>
		/// <para>ID 字段 - 相交图层中用于唯一识别与网络相交的要素的字段。</para>
		/// <para>描述字段 - 提供相交要素的描述（例如镇或县名称）的字段。</para>
		/// <para>名称分隔符 - 交叉点的名称分隔符，例如 AND、INTERSECT、+ 或 |。</para>
		/// </param>
		public CreateLRSIntersection(object ParentNetwork, object NetworkDescriptionField, object IntersectionFeatureClassName, object IntersectingLayers)
		{
			this.ParentNetwork = ParentNetwork;
			this.NetworkDescriptionField = NetworkDescriptionField;
			this.IntersectionFeatureClassName = IntersectionFeatureClassName;
			this.IntersectingLayers = IntersectingLayers;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 LRS 交叉点</para>
		/// </summary>
		public override string DisplayName() => "创建 LRS 交叉点";

		/// <summary>
		/// <para>Tool Name : CreateLRSIntersection</para>
		/// </summary>
		public override string ToolName() => "CreateLRSIntersection";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSIntersection</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSIntersection";

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
		public override object[] Parameters() => new object[] { ParentNetwork, NetworkDescriptionField, IntersectionFeatureClassName, IntersectingLayers, ConsiderZ!, ZTolerance!, OutFeatureClass! };

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
		/// <para>新建交点要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IntersectionFeatureClassName { get; set; }

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
		/// <para>Output Feature Class</para>
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
