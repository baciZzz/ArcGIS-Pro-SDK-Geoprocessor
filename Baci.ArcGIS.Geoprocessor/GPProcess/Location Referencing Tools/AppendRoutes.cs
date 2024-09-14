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
	/// <para>Append Routes</para>
	/// <para>追加路径</para>
	/// <para>可将输入折线中的路径附加到 LRS 网络中。</para>
	/// </summary>
	public class AppendRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceRoutes">
		/// <para>Source Routes</para>
		/// <para>从中派生路径的输入。 输入可以是折线要素类、shapefile、要素服务或 LRS 网络要素类。</para>
		/// </param>
		/// <param name="InLrsNetwork">
		/// <para>LRS Network</para>
		/// <para>路径将加载到的目标 LRS 网络。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>输入折线要素类中将映射到 LRS 网络路径 ID 的字段。 字段类型必须与目标 LRS 网络的 RouteID 字段类型匹配，并且必须是字符串或 GUID 字段类型。 如果是文本字段，则字段长度必须小于或等于目标 RouteID 字段的长度。</para>
		/// </param>
		public AppendRoutes(object SourceRoutes, object InLrsNetwork, object RouteIdField)
		{
			this.SourceRoutes = SourceRoutes;
			this.InLrsNetwork = InLrsNetwork;
			this.RouteIdField = RouteIdField;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加路径</para>
		/// </summary>
		public override string DisplayName() => "追加路径";

		/// <summary>
		/// <para>Tool Name : AppendRoutes</para>
		/// </summary>
		public override string ToolName() => "AppendRoutes";

		/// <summary>
		/// <para>Tool Excute Name : locref.AppendRoutes</para>
		/// </summary>
		public override string ExcuteName() => "locref.AppendRoutes";

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
		public override object[] Parameters() => new object[] { SourceRoutes, InLrsNetwork, RouteIdField, RouteNameField!, FromDateField!, ToDateField!, LineIdField!, LineNameField!, LineOrderField!, FieldMap!, LoadType!, OutLrsNetwork!, OutDetailsFile! };

		/// <summary>
		/// <para>Source Routes</para>
		/// <para>从中派生路径的输入。 输入可以是折线要素类、shapefile、要素服务或 LRS 网络要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object SourceRoutes { get; set; }

		/// <summary>
		/// <para>LRS Network</para>
		/// <para>路径将加载到的目标 LRS 网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLrsNetwork { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>输入折线要素类中将映射到 LRS 网络路径 ID 的字段。 字段类型必须与目标 LRS 网络的 RouteID 字段类型匹配，并且必须是字符串或 GUID 字段类型。 如果是文本字段，则字段长度必须小于或等于目标 RouteID 字段的长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>输入折线要素类中将映射到 LRS 网络路径名称的字段。 该字段必须是字符串字段，并且字段长度必须小于或等于目标路径名称字段的长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>输入折线要素类中的日期字段，将映射为 LRS 网络中的起始日期字段值。 如果该字段未映射，则将为所有追加路径提供一个表示开始时间的空值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>输入折线要素类中的日期字段，将在 LRS 网络中映射为结束日期。 如果结束日期字段未映射，则将为所有追加路径提供一个表示结束时间的空值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ToDateField { get; set; }

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>输入折线要素类中将映射到 LRS 网络线 ID 的字段。 此参数仅在目标 LRS 网络是 LRS 线网络时使用。 字段类型必须与中心线序列表的 RouteID 字段类型匹配，并且必须是正好 38 个字符的字符串或 GUID 字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? LineIdField { get; set; }

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>输入折线要素类中的字符串字段，将被映射为 LRS 网络线名称。 此参数仅在目标 LRS 网络是 LRS 线网络时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? LineNameField { get; set; }

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>输入折线要素类中的长整型字段，将被映射为 LRS 网络线顺序。 此参数仅在目标 LRS 网络是 LRS 线网络时使用。</para>
		/// <para>了解更多有关 Pipeline Referencing 中的线网络和线顺序或 Roads and Highways 中的线网络和线顺序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long")]
		public object? LineOrderField { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>控制源路径字段中的属性信息如何传输到输入 LRS 网络。 无法将字段添加到目标 LRS 网络或从目标 LRS 网络中删除，因为源路径的数据已追加到具有预定义模式的现有 LRS 网络。 虽然您可以为每个输出字段设置合并规则，但该工具会忽略这些规则。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? FieldMap { get; set; }

		/// <summary>
		/// <para>Load Type</para>
		/// <para>指定具有测量值或时间的附加路径如何与具有相同 ID 的路径重叠，目标网络记录将被加载到网络要素类中。</para>
		/// <para>添加—追加路径将加载到目标 LRS 网络。 如果源路径中的任何路径 ID 已经存在于目标 LRS 网络中且具有相同的时间，则它将作为重复路径写入输出日志，并且必须在完成加载过程之前更正或过滤掉。 这是默认设置。</para>
		/// <para>按 ID 停用路径—追加路径将被加载到目标 LRS 网络中，并且目标 LRS 网络中任何与追加路径具有相同路径 ID 和时间重叠的路径都将被淘汰。 如果追加路径覆盖了具有相同路径 ID 的目标路径，则该目标路径将被删除。</para>
		/// <para>按 ID 替换路径—追加路径将被加载到目标 LRS 网络中，并且目标 LRS 网络中任何与追加路径具有相同路径 ID 的路径都将被删除。</para>
		/// <para><see cref="LoadTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LoadType { get; set; } = "ADD";

		/// <summary>
		/// <para>LRS Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutLrsNetwork { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendRoutes SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Load Type</para>
		/// </summary>
		public enum LoadTypeEnum 
		{
			/// <summary>
			/// <para>添加—追加路径将加载到目标 LRS 网络。 如果源路径中的任何路径 ID 已经存在于目标 LRS 网络中且具有相同的时间，则它将作为重复路径写入输出日志，并且必须在完成加载过程之前更正或过滤掉。 这是默认设置。</para>
			/// </summary>
			[GPValue("ADD")]
			[Description("添加")]
			Add,

			/// <summary>
			/// <para>按 ID 停用路径—追加路径将被加载到目标 LRS 网络中，并且目标 LRS 网络中任何与追加路径具有相同路径 ID 和时间重叠的路径都将被淘汰。 如果追加路径覆盖了具有相同路径 ID 的目标路径，则该目标路径将被删除。</para>
			/// </summary>
			[GPValue("RETIRE_BY_ROUTE_ID")]
			[Description("按 ID 停用路径")]
			Retire_by_route_ID,

			/// <summary>
			/// <para>按 ID 替换路径—追加路径将被加载到目标 LRS 网络中，并且目标 LRS 网络中任何与追加路径具有相同路径 ID 的路径都将被删除。</para>
			/// </summary>
			[GPValue("REPLACE_BY_ROUTE_ID")]
			[Description("按 ID 替换路径")]
			Replace_by_route_ID,

		}

#endregion
	}
}
