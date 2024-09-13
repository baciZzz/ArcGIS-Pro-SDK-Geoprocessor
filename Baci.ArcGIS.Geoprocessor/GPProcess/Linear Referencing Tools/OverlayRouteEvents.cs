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
	/// <para>Overlay Route Events</para>
	/// <para>叠加路径事件</para>
	/// <para>将两个事件表叠加起来创建一个输出事件表，以表示输入的并集或交集。</para>
	/// </summary>
	public class OverlayRouteEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Event Table</para>
		/// <para>输入事件表。</para>
		/// </param>
		/// <param name="InEventProperties">
		/// <para>Input Event Table Properties</para>
		/// <para>输入事件表中由路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 该字段包含指示每个事件所在路径的值。 字段可以是数值或字符。</para>
		/// <para>事件类型 - 输入事件表中的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。 只有“测量始于”是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。 “测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 包含测量值的字段。 此字段必须是数值型字段，并且在事件类型是 POINT 或 LINE 时必填。 请注意，在事件类型是 POINT 时，此参数的标注将变为测量字段。</para>
		/// <para>测量止于字段 - 包含测量值的字段。 此字段必须是数值字段，在事件类型是 LINE 时必填。</para>
		/// </param>
		/// <param name="OverlayTable">
		/// <para>Overlay Event Table</para>
		/// <para>叠加事件表。</para>
		/// </param>
		/// <param name="OverlayEventProperties">
		/// <para>Overlay Event Table Properties</para>
		/// <para>叠加事件表中的路径位置字段和事件类型。</para>
		/// <para>路径标识符字段 - 包含指明每个事件所沿路径的值的字段。 字段可以是数值或字符。</para>
		/// <para>事件类型 - 叠加事件表中的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。 只有“测量始于”是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。 “测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 包含测量值的字段。 此字段必须是数值型字段，并且在事件类型是 POINT 或 LINE 时必填。 在事件类型是 POINT 时，此参数的标注将变为测量字段。</para>
		/// <para>测量止于字段 - 包含测量值的字段。 此字段必须是数值字段，在事件类型是 LINE 时必填。</para>
		/// </param>
		/// <param name="OverlayType">
		/// <para>Type of Overlay</para>
		/// <para>指定要执行的叠加的类型。</para>
		/// <para>相交—只有重叠事件将被写入输出事件表。 这是默认设置。</para>
		/// <para>联合—所有事件都将被写入输出事件表。 线性事件将在其相交位置进行分割。</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
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
		public OverlayRouteEvents(object InTable, object InEventProperties, object OverlayTable, object OverlayEventProperties, object OverlayType, object OutTable, object OutEventProperties)
		{
			this.InTable = InTable;
			this.InEventProperties = InEventProperties;
			this.OverlayTable = OverlayTable;
			this.OverlayEventProperties = OverlayEventProperties;
			this.OverlayType = OverlayType;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : 叠加路径事件</para>
		/// </summary>
		public override string DisplayName() => "叠加路径事件";

		/// <summary>
		/// <para>Tool Name : OverlayRouteEvents</para>
		/// </summary>
		public override string ToolName() => "OverlayRouteEvents";

		/// <summary>
		/// <para>Tool Excute Name : lr.OverlayRouteEvents</para>
		/// </summary>
		public override string ExcuteName() => "lr.OverlayRouteEvents";

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
		public override object[] Parameters() => new object[] { InTable, InEventProperties, OverlayTable, OverlayEventProperties, OverlayType, OutTable, OutEventProperties, ZeroLengthEvents!, InFields!, BuildIndex! };

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>输入事件表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteMeasureEventDomain>")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Event Table Properties</para>
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
		/// <para>Overlay Event Table</para>
		/// <para>叠加事件表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteMeasureEventDomain>")]
		public object OverlayTable { get; set; }

		/// <summary>
		/// <para>Overlay Event Table Properties</para>
		/// <para>叠加事件表中的路径位置字段和事件类型。</para>
		/// <para>路径标识符字段 - 包含指明每个事件所沿路径的值的字段。 字段可以是数值或字符。</para>
		/// <para>事件类型 - 叠加事件表中的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。 只有“测量始于”是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。 “测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 包含测量值的字段。 此字段必须是数值型字段，并且在事件类型是 POINT 或 LINE 时必填。 在事件类型是 POINT 时，此参数的标注将变为测量字段。</para>
		/// <para>测量止于字段 - 包含测量值的字段。 此字段必须是数值字段，在事件类型是 LINE 时必填。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object OverlayEventProperties { get; set; }

		/// <summary>
		/// <para>Type of Overlay</para>
		/// <para>指定要执行的叠加的类型。</para>
		/// <para>相交—只有重叠事件将被写入输出事件表。 这是默认设置。</para>
		/// <para>联合—所有事件都将被写入输出事件表。 线性事件将在其相交位置进行分割。</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlayType { get; set; } = "INTERSECT";

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
		/// <para>Keep zero length line events</para>
		/// <para>指定是否将零长度线事件添加到输出事件表参数值。 此参数只有在输出事件类型为 LINE 时才有效。</para>
		/// <para>选中 - 将添加零长度线事件。 这是默认设置。</para>
		/// <para>取消选中 - 将不添加零长度线事件。</para>
		/// <para><see cref="ZeroLengthEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ZeroLengthEvents { get; set; } = "true";

		/// <summary>
		/// <para>Include all fields from input</para>
		/// <para>指定是否将输入和叠加事件表中的所有字段都包括到输出事件表参数值。</para>
		/// <para>选中 - 来自输入表的所有字段都将被包括到输出表中。 这是默认设置。</para>
		/// <para>取消选中 - 不是来自输入表的所有字段都将被包括到输出表中。 只包括 ObjectID 字段 和路径位置字段。</para>
		/// <para><see cref="InFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InFields { get; set; } = "true";

		/// <summary>
		/// <para>Build index</para>
		/// <para>指定是否为写入输出事件表参数值的路径标识符字段创建属性索引。</para>
		/// <para>选中 - 将创建属性索引。 这是默认设置。</para>
		/// <para>未选中 - 不会创建属性索引。</para>
		/// <para><see cref="BuildIndexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildIndex { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayRouteEvents SetEnviroment(object? configKeyword = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type of Overlay</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>相交—只有重叠事件将被写入输出事件表。 这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("相交")]
			Intersect,

			/// <summary>
			/// <para>联合—所有事件都将被写入输出事件表。 线性事件将在其相交位置进行分割。</para>
			/// </summary>
			[GPValue("UNION")]
			[Description("联合")]
			Union,

		}

		/// <summary>
		/// <para>Keep zero length line events</para>
		/// </summary>
		public enum ZeroLengthEventsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ZERO")]
			ZERO,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ZERO")]
			NO_ZERO,

		}

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

		/// <summary>
		/// <para>Build index</para>
		/// </summary>
		public enum BuildIndexEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INDEX")]
			INDEX,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INDEX")]
			NO_INDEX,

		}

#endregion
	}
}
