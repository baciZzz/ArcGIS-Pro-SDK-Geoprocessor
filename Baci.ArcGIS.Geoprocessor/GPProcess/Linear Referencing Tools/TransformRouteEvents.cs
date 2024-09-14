using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LinearReferencingTools
{
	/// <summary>
	/// <para>Transform Route Events</para>
	/// <para>转换路径事件</para>
	/// <para>将事件测量值从一种路径参考转换到另一种路径参考，并将其写入新事件表。</para>
	/// </summary>
	public class TransformRouteEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Event Table</para>
		/// <para>输入事件表。</para>
		/// </param>
		/// <param name="InEventProperties">
		/// <para>Event Table Properties</para>
		/// <para>输入事件表中由路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 该字段包含指示每个事件所在路径的值。 字段可以是数值或字符。</para>
		/// <para>事件类型 - 输入事件表中的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。 只有“测量始于”是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。 “测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 包含测量值的字段。 此字段必须是数值型字段，并且在事件类型是 POINT 或 LINE 时必填。 请注意，在事件类型是 POINT 时，此参数的标注将变为测量字段。</para>
		/// <para>测量止于字段 - 包含测量值的字段。 此字段必须是数值字段，在事件类型是 LINE 时必填。</para>
		/// </param>
		/// <param name="InRoutes">
		/// <para>Source Route Features</para>
		/// <para>输入路径要素。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Source Route Identifier Field</para>
		/// <para>包含可唯一识别每条输入路径的值的字段。</para>
		/// </param>
		/// <param name="TargetRoutes">
		/// <para>Target Route Features</para>
		/// <para>要将输入事件转换到的路径要素。</para>
		/// </param>
		/// <param name="TargetRouteIdField">
		/// <para>Target Route Identifier Field</para>
		/// <para>包含可唯一识别每条目标路径的值的字段。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Event Table</para>
		/// <para>要创建的表。</para>
		/// </param>
		/// <param name="OutEventProperties">
		/// <para>Output Event Table Properties</para>
		/// <para>由将写入输出事件表的路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 该字段将包含指示每个事件所在路径的值。</para>
		/// <para>事件类型 - 输出事件表中将包含的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。 仅可指定只有单一测量字段</para>
		/// <para>LINE - 线事件定义路径的一部分。 “测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 将包含测量值的字段。 此字段在事件类型是 POINT 或 LINE 时必填。 请注意，在事件类型是 POINT 时，此参数的标注将变为测量字段。</para>
		/// <para>测量止于字段 - 将包含测量值的字段。 此字段在事件类型是 LINE 时必填。</para>
		/// </param>
		/// <param name="ClusterTolerance">
		/// <para>Cluster Tolerance</para>
		/// <para>输入事件与目标路径之间的最大容许距离。</para>
		/// </param>
		public TransformRouteEvents(object InTable, object InEventProperties, object InRoutes, object RouteIdField, object TargetRoutes, object TargetRouteIdField, object OutTable, object OutEventProperties, object ClusterTolerance)
		{
			this.InTable = InTable;
			this.InEventProperties = InEventProperties;
			this.InRoutes = InRoutes;
			this.RouteIdField = RouteIdField;
			this.TargetRoutes = TargetRoutes;
			this.TargetRouteIdField = TargetRouteIdField;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
			this.ClusterTolerance = ClusterTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换路径事件</para>
		/// </summary>
		public override string DisplayName() => "转换路径事件";

		/// <summary>
		/// <para>Tool Name : TransformRouteEvents</para>
		/// </summary>
		public override string ToolName() => "TransformRouteEvents";

		/// <summary>
		/// <para>Tool Excute Name : lr.TransformRouteEvents</para>
		/// </summary>
		public override string ExcuteName() => "lr.TransformRouteEvents";

		/// <summary>
		/// <para>Toolbox Display Name : Linear Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Linear Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : lr</para>
		/// </summary>
		public override string ToolboxAlise() => "lr";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, InEventProperties, InRoutes, RouteIdField, TargetRoutes, TargetRouteIdField, OutTable, OutEventProperties, ClusterTolerance, InFields! };

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>输入事件表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteMeasureEventDomain>")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Event Table Properties</para>
		/// <para>输入事件表中由路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 该字段包含指示每个事件所在路径的值。 字段可以是数值或字符。</para>
		/// <para>事件类型 - 输入事件表中的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。 只有“测量始于”是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。 “测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 包含测量值的字段。 此字段必须是数值型字段，并且在事件类型是 POINT 或 LINE 时必填。 请注意，在事件类型是 POINT 时，此参数的标注将变为测量字段。</para>
		/// <para>测量止于字段 - 包含测量值的字段。 此字段必须是数值字段，在事件类型是 LINE 时必填。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object InEventProperties { get; set; }

		/// <summary>
		/// <para>Source Route Features</para>
		/// <para>输入路径要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteDomain>")]
		public object InRoutes { get; set; }

		/// <summary>
		/// <para>Source Route Identifier Field</para>
		/// <para>包含可唯一识别每条输入路径的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Target Route Features</para>
		/// <para>要将输入事件转换到的路径要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteDomain>")]
		public object TargetRoutes { get; set; }

		/// <summary>
		/// <para>Target Route Identifier Field</para>
		/// <para>包含可唯一识别每条目标路径的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object TargetRouteIdField { get; set; }

		/// <summary>
		/// <para>Output Event Table</para>
		/// <para>要创建的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output Event Table Properties</para>
		/// <para>由将写入输出事件表的路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 该字段将包含指示每个事件所在路径的值。</para>
		/// <para>事件类型 - 输出事件表中将包含的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。 仅可指定只有单一测量字段</para>
		/// <para>LINE - 线事件定义路径的一部分。 “测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 将包含测量值的字段。 此字段在事件类型是 POINT 或 LINE 时必填。 请注意，在事件类型是 POINT 时，此参数的标注将变为测量字段。</para>
		/// <para>测量止于字段 - 将包含测量值的字段。 此字段在事件类型是 LINE 时必填。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object OutEventProperties { get; set; }

		/// <summary>
		/// <para>Cluster Tolerance</para>
		/// <para>输入事件与目标路径之间的最大容许距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Include all fields from input</para>
		/// <para>指定输出事件表参数值是否包含路径位置字段以及输入事件的所有属性。</para>
		/// <para>选中 - 输出事件表参数值包含路径位置字段以及输入事件的所有属性。 这是默认设置。</para>
		/// <para>未选中 - 输出事件表参数值将只包含路径位置字段和输入事件的 ObjectID 字段。</para>
		/// <para><see cref="InFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InFields { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransformRouteEvents SetEnviroment(object? configKeyword = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include all fields from input</para>
		/// </summary>
		public enum InFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FIELDS")]
			FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIELDS")]
			NO_FIELDS,

		}

#endregion
	}
}
