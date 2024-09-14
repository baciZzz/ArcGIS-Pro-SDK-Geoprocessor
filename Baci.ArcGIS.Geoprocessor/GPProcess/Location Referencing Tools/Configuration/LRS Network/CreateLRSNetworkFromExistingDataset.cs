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
	/// <para>Create LRS Network From Existing Dataset</para>
	/// <para>基于现有数据集创建 LRS 网络</para>
	/// <para>使用现有折线要素类创建 LRS 网络。</para>
	/// </summary>
	public class CreateLRSNetworkFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>将注册为 LRS 网络的输入要素类。 要素类的名称不得超过 26 个字符。 要素类必须位于包含有 Pipeline Referencing LRS 的地理数据库中。 此要素类的名称将用作 LRS 网络的名称。</para>
		/// </param>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>要注册的新 LRS 网络的 LRS 名称。 该 LRS 必须与 LRS 网络要素类位于同一地理数据库中。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络路径 ID 的字段。 该字段必须是字符串或 GUID 字段类型。</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络开始日期的日期字段。</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络结束日期的日期字段。</para>
		/// </param>
		public CreateLRSNetworkFromExistingDataset(object InFeatureClass, object LrsName, object RouteIdField, object FromDateField, object ToDateField)
		{
			this.InFeatureClass = InFeatureClass;
			this.LrsName = LrsName;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于现有数据集创建 LRS 网络</para>
		/// </summary>
		public override string DisplayName() => "基于现有数据集创建 LRS 网络";

		/// <summary>
		/// <para>Tool Name : CreateLRSNetworkFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSNetworkFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSNetworkFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSNetworkFromExistingDataset";

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
		public override object[] Parameters() => new object[] { InFeatureClass, LrsName, RouteIdField, RouteNameField!, FromDateField, ToDateField, DeriveFromLineNetwork!, LineNetworkName!, IncludeFieldsToSupportLines!, LineIdField!, LineNameField!, LineOrderField!, OutFeatureClass!, RouteIdConfiguration!, IndividualRouteIdFields! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>将注册为 LRS 网络的输入要素类。 要素类的名称不得超过 26 个字符。 要素类必须位于包含有 Pipeline Referencing LRS 的地理数据库中。 此要素类的名称将用作 LRS 网络的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>要注册的新 LRS 网络的 LRS 名称。 该 LRS 必须与 LRS 网络要素类位于同一地理数据库中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络路径 ID 的字段。 该字段必须是字符串或 GUID 字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络路径名称的字符串字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络开始日期的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络结束日期的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// <para>指定是否将网络配置为 LRS 派生网络。</para>
		/// <para>选中 - 此工具的输出将为 LRS 派生网络。 还必须提供线网络名称参数。</para>
		/// <para>未选中 - 此工具的输出将不是 LRS 派生网络。 这是默认设置。</para>
		/// <para><see cref="DeriveFromLineNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeriveFromLineNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Line Network Name</para>
		/// <para>输出 LRS 派生网络将注册到的 LRS 线网络的名称。 该输入 LRS 线网络必须与 LRS 网络要素类位于同一地理数据库工作空间中。 此参数仅在选中从线网络派生参数时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineNetworkName { get; set; }

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// <para>指定是否将网络配置为支持线。</para>
		/// <para>选中 - 此工具的输出将为 LRS 线网络。 还必须提供线 ID 字段、线名称字段和线顺序字段参数。</para>
		/// <para>未选中 - 此工具的输出将不是 LRS 线网络。 这是默认设置。</para>
		/// <para><see cref="IncludeFieldsToSupportLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeFieldsToSupportLines { get; set; } = "false";

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络线 ID 的字段。 此参数仅在选中包括字段以支持线参数时使用。 必须使用字符串或 GUID 字段类型，并且必须与中心线序列表中路径 ID 字段的字段类型和长度相匹配。 线 ID 字段参数输入的字段类型也必须与路径 ID 字段参数输入的相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? LineIdField { get; set; }

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络线名称的字符串字段。 此参数仅在选中包括字段以支持线参数时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? LineNameField { get; set; }

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>LRS 网络要素类中将映射为 LRS 网络线顺序的整型字段。 此参数仅在选中包括字段以支持线参数时使用。 该字段必须是长整型字段类型。</para>
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
		/// <para>指定 LRS 网络的路径 ID 配置。</para>
		/// <para>自动生成的路径 ID—路径 ID 字段是一个自动生成的 GUID。 路径名称可以配置为 LRS 字段。 这是默认设置。</para>
		/// <para>单字段路径 ID—路径 ID 字段是由用户生成的单个字段。 仅支持非线网络。</para>
		/// <para>多字段路径 ID—路径 ID 字段是由用户生成的字段，由多个字段串联组成。 仅支持非线网络。</para>
		/// <para><see cref="RouteIdConfigurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RouteIdConfiguration { get; set; } = "AUTOGENERATED_ROUTE_ID";

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>LRS 网络要素类中用于组成路径 ID 的各个字段。 此参数仅在路径 ID 字段配置参数设置为多字段路径 ID 时使用。 字段必须是字符串或整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? IndividualRouteIdFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRSNetworkFromExistingDataset SetEnviroment(object? workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DERIVE")]
			DERIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_DERIVE")]
			DO_NOT_DERIVE,

		}

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// </summary>
		public enum IncludeFieldsToSupportLinesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE")]
			INCLUDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE")]
			DO_NOT_INCLUDE,

		}

		/// <summary>
		/// <para>Route ID Field Configuration</para>
		/// </summary>
		public enum RouteIdConfigurationEnum 
		{
			/// <summary>
			/// <para>自动生成的路径 ID—路径 ID 字段是一个自动生成的 GUID。 路径名称可以配置为 LRS 字段。 这是默认设置。</para>
			/// </summary>
			[GPValue("AUTOGENERATED_ROUTE_ID")]
			[Description("自动生成的路径 ID")]
			Autogenerated_Route_ID,

			/// <summary>
			/// <para>单字段路径 ID—路径 ID 字段是由用户生成的单个字段。 仅支持非线网络。</para>
			/// </summary>
			[GPValue("SINGLE_FIELD_ROUTE_ID")]
			[Description("单字段路径 ID")]
			SINGLE_FIELD_ROUTE_ID,

			/// <summary>
			/// <para>多字段路径 ID—路径 ID 字段是由用户生成的字段，由多个字段串联组成。 仅支持非线网络。</para>
			/// </summary>
			[GPValue("MULTI_FIELD_ROUTE_ID")]
			[Description("多字段路径 ID")]
			MULTI_FIELD_ROUTE_ID,

		}

#endregion
	}
}
