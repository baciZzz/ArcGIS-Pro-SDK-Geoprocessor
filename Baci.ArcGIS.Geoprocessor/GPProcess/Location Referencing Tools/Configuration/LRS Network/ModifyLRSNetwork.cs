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
	/// <para>Modify LRS Network</para>
	/// <para>修改 LRS 网络</para>
	/// <para>在 Location Referencing 线性参考系统 (LRS) 中修改 LRS 网络。</para>
	/// </summary>
	public class ModifyLRSNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>要更改的输入 LRS 网络要素类。</para>
		/// </param>
		public ModifyLRSNetwork(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 修改 LRS 网络</para>
		/// </summary>
		public override string DisplayName() => "修改 LRS 网络";

		/// <summary>
		/// <para>Tool Name : ModifyLRSNetwork</para>
		/// </summary>
		public override string ToolName() => "ModifyLRSNetwork";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRSNetwork</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRSNetwork";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, RouteIdField!, RouteNameField!, FromDateField!, ToDateField!, DeriveFromLineNetwork!, LineNetworkName!, IncludeFieldsToSupportLines!, LineIdField!, LineNameField!, LineOrderField!, OutFeatureClass!, RouteIdConfiguration!, IndividualRouteIdFields! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>要更改的输入 LRS 网络要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>输入要素类中将映射为 LRS 网络路径 ID 的字段。 字段类型必须与 Centerline_Sequence 表的 RouteId 字段类型匹配，并且必须是字符串或 GUID 字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? RouteIdField { get; set; }

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>输入要素类中将映射为 LRS 网络路径名称的字符串字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>输入要素类中的日期字段，将映射为 LRS 网络的开始日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>输入要素类中的日期字段，将映射为 LRS 网络的结束日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ToDateField { get; set; }

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// <para>确定是否将当前 LRS 网络配置为 LRS 派生网络。</para>
		/// <para>保留原样—当前的 LRS 网络派生属性不会更改。 这是默认设置。</para>
		/// <para>派生—输入的 LRS 派生网络将被修改为 LRS 派生网络。 还必须提供 line network name 参数以指定从哪个 LRS 网络派生。</para>
		/// <para>不派生—输入的 LRS 派生网络将不被修改为 LRS 派生网络。</para>
		/// <para><see cref="DeriveFromLineNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DeriveFromLineNetwork { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Line Network Name</para>
		/// <para>输入 LRS 派生网络将注册到的 LRS 线网络的名称。 该输入 LRS 线网络必须与 LRS 网络要素类位于同一地理数据库工作空间和 LRS 中。 此参数仅在将从线网络派生参数设置为派生时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineNetworkName { get; set; }

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// <para>确定是否将当前 LRS 网络配置为支持线。</para>
		/// <para>保留原样—当前的 LRS 网络线支持属性不会更改。 这是默认设置。</para>
		/// <para>包括—将修改输入 LRS 网络以添加对线的支持。 还必须提供线 ID 字段、线名称字段和线顺序字段参数，并且映射到这些参数的有效字段必须存在于 LRS 网络要素类中。</para>
		/// <para>不包括—将修改输入 LRS 网络以删除对线的支持。</para>
		/// <para><see cref="IncludeFieldsToSupportLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IncludeFieldsToSupportLines { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>输入要素类中将映射为 LRS 网络线 ID 的字段。 此参数仅在将包括字段以支持线参数设置为包括时使用。 字段类型必须与 Centerline_Sequence 表的 RouteId 字段类型匹配，并且必须是 38 个字符的字符串或 GUID 字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? LineIdField { get; set; }

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>输入要素类中将映射为 LRS 网络线名称的字符串字段。 此参数仅在将包括字段以支持线参数设置为包括时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? LineNameField { get; set; }

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>输入要素类中将映射为 LRS 网络线顺序的字段。 此参数仅在将包括字段以支持线参数设置为包括时使用。 该字段必须是长整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long")]
		public object? LineOrderField { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Field Configuration</para>
		/// <para>确定 LRS 网络的路径 ID 配置。</para>
		/// <para>保留原样—当前 LRS 网络路径 ID 配置不会更改。 这是默认设置。</para>
		/// <para>自动生成的路径 ID—路径 ID 字段将为自动生成的 GUID 字段，并且可以将路径名称配置为 LRS 字段。</para>
		/// <para>单字段路径 ID—仅支持非线网络。</para>
		/// <para>多字段路径 ID—仅支持非线网络。 要形成串联路径 ID，需要多个字段。</para>
		/// <para><see cref="RouteIdConfigurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RouteIdConfiguration { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>LRS 网络要素类中用于组成路径 ID 的各个字段。 此参数仅在路径 ID 字段配置参数设置为多字段路径 ID 时使用。 字段必须是字符串或整数字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? IndividualRouteIdFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyLRSNetwork SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// </summary>
		public enum DeriveFromLineNetworkEnum 
		{
			/// <summary>
			/// <para>保留原样—当前的 LRS 网络派生属性不会更改。 这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("保留原样")]
			As_is,

			/// <summary>
			/// <para>不派生—输入的 LRS 派生网络将不被修改为 LRS 派生网络。</para>
			/// </summary>
			[GPValue("DO_NOT_DERIVE")]
			[Description("不派生")]
			Do_not_derive,

			/// <summary>
			/// <para>派生—输入的 LRS 派生网络将被修改为 LRS 派生网络。 还必须提供 line network name 参数以指定从哪个 LRS 网络派生。</para>
			/// </summary>
			[GPValue("DERIVE")]
			[Description("派生")]
			Derive,

		}

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// </summary>
		public enum IncludeFieldsToSupportLinesEnum 
		{
			/// <summary>
			/// <para>保留原样—当前的 LRS 网络线支持属性不会更改。 这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("保留原样")]
			As_is,

			/// <summary>
			/// <para>不包括—将修改输入 LRS 网络以删除对线的支持。</para>
			/// </summary>
			[GPValue("DO_NOT_INCLUDE")]
			[Description("不包括")]
			Do_not_include,

			/// <summary>
			/// <para>包括—将修改输入 LRS 网络以添加对线的支持。 还必须提供线 ID 字段、线名称字段和线顺序字段参数，并且映射到这些参数的有效字段必须存在于 LRS 网络要素类中。</para>
			/// </summary>
			[GPValue("INCLUDE")]
			[Description("包括")]
			Include,

		}

		/// <summary>
		/// <para>Route ID Field Configuration</para>
		/// </summary>
		public enum RouteIdConfigurationEnum 
		{
			/// <summary>
			/// <para>保留原样—当前 LRS 网络路径 ID 配置不会更改。 这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("保留原样")]
			As_is,

			/// <summary>
			/// <para>自动生成的路径 ID—路径 ID 字段将为自动生成的 GUID 字段，并且可以将路径名称配置为 LRS 字段。</para>
			/// </summary>
			[GPValue("AUTOGENERATED_ROUTE_ID")]
			[Description("自动生成的路径 ID")]
			Autogenerated_Route_ID,

			/// <summary>
			/// <para>单字段路径 ID—仅支持非线网络。</para>
			/// </summary>
			[GPValue("SINGLE_FIELD_ROUTE_ID")]
			[Description("单字段路径 ID")]
			SINGLE_FIELD_ROUTE_ID,

			/// <summary>
			/// <para>多字段路径 ID—仅支持非线网络。 要形成串联路径 ID，需要多个字段。</para>
			/// </summary>
			[GPValue("MULTI_FIELD_ROUTE_ID")]
			[Description("多字段路径 ID")]
			MULTI_FIELD_ROUTE_ID,

		}

#endregion
	}
}
