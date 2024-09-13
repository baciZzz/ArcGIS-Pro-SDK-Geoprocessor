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
	/// <para>Create LRS Network</para>
	/// <para>创建 LRS 网络</para>
	/// <para>在 ArcGIS Location Referencing 线性参考系统 (LRS) 中创建 LRS 网络。</para>
	/// </summary>
	public class CreateLRSNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPath">
		/// <para>Input Location</para>
		/// <para>将包含新 LRS 网络的输入工作空间。 工作空间必须为包含 Location Referencing LRS 的地理数据库。 除了顶级地理数据库之外，还支持要素数据集作为有效路径。</para>
		/// </param>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>要注册的新 LRS 网络的 LRS。 该 LRS 必须与输入位置参数值位于同一地理数据库中。</para>
		/// </param>
		/// <param name="NetworkName">
		/// <para>LRS Network Name</para>
		/// <para>将创建的 LRS 网络的名称，以及将创建并注册到 LRS 网络的要素类的名称。 LRS 网络名称不得超过 26 个字符，并且不能包含除下划线以外的特殊字符。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>输出要素类中将映射为 LRS 网络路径 ID 的字段。 字段类型派生自中心线序列表的 RouteId 字段，必须是字符串或 GUID 类型。</para>
		/// </param>
		/// <param name="RouteNameField">
		/// <para>Route Name Field</para>
		/// <para>输出要素类中将映射为 LRS 网络路径名称的字符串字段。</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>输出要素类中的日期字段，将映射为 LRS 网络的开始日期。</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>输出要素类中的日期字段，将映射为 LRS 网络的“结束日期”。</para>
		/// </param>
		public CreateLRSNetwork(object InPath, object LrsName, object NetworkName, object RouteIdField, object RouteNameField, object FromDateField, object ToDateField)
		{
			this.InPath = InPath;
			this.LrsName = LrsName;
			this.NetworkName = NetworkName;
			this.RouteIdField = RouteIdField;
			this.RouteNameField = RouteNameField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 LRS 网络</para>
		/// </summary>
		public override string DisplayName() => "创建 LRS 网络";

		/// <summary>
		/// <para>Tool Name : CreateLRSNetwork</para>
		/// </summary>
		public override string ToolName() => "CreateLRSNetwork";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSNetwork</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSNetwork";

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
		public override object[] Parameters() => new object[] { InPath, LrsName, NetworkName, RouteIdField, RouteNameField, FromDateField, ToDateField, DeriveFromLineNetwork!, LineNetworkName!, IncludeFieldsToSupportLines!, LineIdField!, LineNameField!, LineOrderField!, MeasureUnit!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Location</para>
		/// <para>将包含新 LRS 网络的输入工作空间。 工作空间必须为包含 Location Referencing LRS 的地理数据库。 除了顶级地理数据库之外，还支持要素数据集作为有效路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InPath { get; set; }

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>要注册的新 LRS 网络的 LRS。 该 LRS 必须与输入位置参数值位于同一地理数据库中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>LRS Network Name</para>
		/// <para>将创建的 LRS 网络的名称，以及将创建并注册到 LRS 网络的要素类的名称。 LRS 网络名称不得超过 26 个字符，并且不能包含除下划线以外的特殊字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkName { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>输出要素类中将映射为 LRS 网络路径 ID 的字段。 字段类型派生自中心线序列表的 RouteId 字段，必须是字符串或 GUID 类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteIdField { get; set; } = "RouteId";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>输出要素类中将映射为 LRS 网络路径名称的字符串字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteNameField { get; set; } = "RouteName";

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>输出要素类中的日期字段，将映射为 LRS 网络的开始日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromDateField { get; set; } = "FromDate";

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>输出要素类中的日期字段，将映射为 LRS 网络的“结束日期”。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToDateField { get; set; } = "ToDate";

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// <para>指定是否将网络配置为 LRS 派生网络。</para>
		/// <para>选中 - 输出将是 LRS 派生网络和支持 LRS 派生网络的要素类。 还必须提供线网络名称参数值。</para>
		/// <para>未选中 - 输出将不是 LRS 派生网络。 这是默认设置。</para>
		/// <para><see cref="DeriveFromLineNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeriveFromLineNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Line Network Name</para>
		/// <para>输出 LRS 派生网络将注册到的 LRS 线网络的名称。 该输入 LRS 线网络必须与线网络名称值位于同一地理数据库工作空间中。 此参数仅在选中从线网络派生参数时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineNetworkName { get; set; }

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// <para>指定是否将添加支持线的字段。</para>
		/// <para>选中 - 输出将是 LRS 线网络，并且输出要素类将包括支持线的字段。 还必须提供线 ID 字段、线名称字段和线顺序字段参数值。</para>
		/// <para>未选中 - 输出将不是 LRS 线网络。 这是默认设置。</para>
		/// <para><see cref="IncludeFieldsToSupportLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeFieldsToSupportLines { get; set; } = "false";

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>输出要素类中将映射为 LRS 网络线 ID 的字段。 此参数仅在选中包括字段以支持线参数时使用。 字段类型派生自中心线序列表的 RouteId 字段，可以是正好 38 个字符的字符串，也可以是 GUID 字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LineIdField { get; set; } = "LineId";

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>输出要素类中将映射为 LRS 网络线名称的字符串字段。 此参数仅在选中包括字段以支持线参数时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LineNameField { get; set; } = "LineName";

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>输出要素类中将映射为 LRS 网络线顺序的字段。 此参数仅在选中包括字段以支持线参数时使用。 该字段必须是长整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LineOrderField { get; set; } = "LineOrder";

		/// <summary>
		/// <para>Measure Unit</para>
		/// <para>指定 LRS 网络将使用的测量单位（m 单位）。</para>
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
		public object? MeasureUnit { get; set; } = "MILES";

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRSNetwork SetEnviroment(object? workspace = null )
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

#endregion
	}
}
