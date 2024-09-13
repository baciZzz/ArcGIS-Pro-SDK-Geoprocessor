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
	/// <para>Dissolve Route Events</para>
	/// <para>融合路径事件</para>
	/// <para>用于将冗余信息从事件表中移除，或将包含多个描述性属性的事件表分解为单独的表。</para>
	/// </summary>
	public class DissolveRouteEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InEvents">
		/// <para>Input Event Table</para>
		/// <para>该表包含将要进行聚合的行。</para>
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
		/// <param name="DissolveField">
		/// <para>Dissolve Fields</para>
		/// <para>用于聚合行的字段。</para>
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
		public DissolveRouteEvents(object InEvents, object InEventProperties, object DissolveField, object OutTable, object OutEventProperties)
		{
			this.InEvents = InEvents;
			this.InEventProperties = InEventProperties;
			this.DissolveField = DissolveField;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : 融合路径事件</para>
		/// </summary>
		public override string DisplayName() => "融合路径事件";

		/// <summary>
		/// <para>Tool Name : DissolveRouteEvents</para>
		/// </summary>
		public override string ToolName() => "DissolveRouteEvents";

		/// <summary>
		/// <para>Tool Excute Name : lr.DissolveRouteEvents</para>
		/// </summary>
		public override string ExcuteName() => "lr.DissolveRouteEvents";

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
		public override object[] Parameters() => new object[] { InEvents, InEventProperties, DissolveField, OutTable, OutEventProperties, DissolveType!, BuildIndex! };

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>该表包含将要进行聚合的行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPRouteMeasureEventDomain>")]
		public object InEvents { get; set; }

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
		/// <para>Dissolve Fields</para>
		/// <para>用于聚合行的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object DissolveField { get; set; }

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
		/// <para>Combine adjacent events only</para>
		/// <para>指定是否对输入事件进行聚合或是分解。</para>
		/// <para>未选中 - 只要存在测量值重叠就聚合事件。 这是默认设置。</para>
		/// <para>选中 - 仅在一个事件的“测量止于”与下一事件的“测量始于”相匹配时聚合事件。 此选项仅适用于线事件。</para>
		/// <para><see cref="DissolveTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DissolveType { get; set; } = "false";

		/// <summary>
		/// <para>Build index</para>
		/// <para>指定是否为写入输出事件表的路径标识符字段创建属性索引。</para>
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
		public DissolveRouteEvents SetEnviroment(object? configKeyword = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Combine adjacent events only</para>
		/// </summary>
		public enum DissolveTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONCATENATE")]
			CONCATENATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DISSOLVE")]
			DISSOLVE,

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
