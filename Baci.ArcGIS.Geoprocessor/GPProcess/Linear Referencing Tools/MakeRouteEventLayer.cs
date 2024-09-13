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
	/// <para>Make Route Event Layer</para>
	/// <para>创建路径事件图层</para>
	/// <para>使用路径和路径事件创建临时要素图层。</para>
	/// </summary>
	public class MakeRouteEventLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRoutes">
		/// <para>Input Route Features</para>
		/// <para>用于定位事件的路径要素。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。</para>
		/// </param>
		/// <param name="InTable">
		/// <para>Input Event Table</para>
		/// <para>将沿路径定位行的表。</para>
		/// </param>
		/// <param name="InEventProperties">
		/// <para>Event Table Properties</para>
		/// <para>输入事件表中由路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 包含指明每个事件所在路径的值的字段。该字段可以是数值或字符。</para>
		/// <para>事件类型 - 输入事件表中的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。只有“测量始于”是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。“测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 包含测量值的字段。此字段必须是数值型字段，并且在事件类型是 POINT 或 LINE 时必填。请注意，事件类型为 POINT 时，此参数的标注变为“测量字段”。</para>
		/// <para>测量止于字段 - 包含测量值的字段。此字段必须是数值字段，在事件类型是 LINE 时必填。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Layer Name or Table View</para>
		/// <para>要创建的图层。此图层存储在内存中，所以不需要路径。</para>
		/// </param>
		public MakeRouteEventLayer(object InRoutes, object RouteIdField, object InTable, object InEventProperties, object OutLayer)
		{
			this.InRoutes = InRoutes;
			this.RouteIdField = RouteIdField;
			this.InTable = InTable;
			this.InEventProperties = InEventProperties;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建路径事件图层</para>
		/// </summary>
		public override string DisplayName() => "创建路径事件图层";

		/// <summary>
		/// <para>Tool Name : MakeRouteEventLayer</para>
		/// </summary>
		public override string ToolName() => "MakeRouteEventLayer";

		/// <summary>
		/// <para>Tool Excute Name : lr.MakeRouteEventLayer</para>
		/// </summary>
		public override string ExcuteName() => "lr.MakeRouteEventLayer";

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
		public override object[] Parameters() => new object[] { InRoutes, RouteIdField, InTable, InEventProperties, OutLayer, OffsetField, AddErrorField, AddAngleField, AngleType, ComplementAngle, OffsetDirection, PointEventType };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>用于定位事件的路径要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteDomain>")]
		public object InRoutes { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Input Event Table</para>
		/// <para>将沿路径定位行的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[xmlserialize(Xml = "<GPRouteMeasureEventDomain xsi:type='typens:GPRouteMeasureEventDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteMeasureEventDomain>")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Event Table Properties</para>
		/// <para>输入事件表中由路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 包含指明每个事件所在路径的值的字段。该字段可以是数值或字符。</para>
		/// <para>事件类型 - 输入事件表中的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。只有“测量始于”是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。“测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>测量始于字段 - 包含测量值的字段。此字段必须是数值型字段，并且在事件类型是 POINT 或 LINE 时必填。请注意，事件类型为 POINT 时，此参数的标注变为“测量字段”。</para>
		/// <para>测量止于字段 - 包含测量值的字段。此字段必须是数值字段，在事件类型是 LINE 时必填。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object InEventProperties { get; set; }

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>要创建的图层。此图层存储在内存中，所以不需要路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Offset Field</para>
		/// <para>包含用于使事件从其基础路径偏移的值的字段。该字段必须为数值型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object OffsetField { get; set; }

		/// <summary>
		/// <para>Generate a field for locating errors</para>
		/// <para>指定是否将名为 LOC_ERROR 的字段添加到创建的临时图层。</para>
		/// <para>未选中 - 不添加用于存储定位错误的字段。这是默认设置。</para>
		/// <para>选中 - 添加用于存储定位错误的字段。</para>
		/// <para><see cref="AddErrorFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddErrorField { get; set; } = "false";

		/// <summary>
		/// <para>Generate an angle field</para>
		/// <para>指定是否将名为 LOC_ANGLE 的字段添加到创建的临时图层。此参数只有在事件类型为 POINT 时才有效。</para>
		/// <para>未选中 - 不添加用于存储定位角的字段。这是默认设置。</para>
		/// <para>选中 - 添加用于存储定位角的字段。</para>
		/// <para><see cref="AddAngleFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddAngleField { get; set; } = "false";

		/// <summary>
		/// <para>Calculated Angle Type</para>
		/// <para>指定要计算的定位角的类型。此参数仅在选中生成角度字段时才有效。</para>
		/// <para>法向—将计算法向角（直角）。这是默认设置。</para>
		/// <para>切向—将计算正切角。</para>
		/// <para><see cref="AngleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AngleType { get; set; } = "NORMAL";

		/// <summary>
		/// <para>Write the complement of the angle to the angle field</para>
		/// <para>指定是否计算定位角的余角。此参数仅在选中生成角度字段时才有效。</para>
		/// <para>未选中 - 不写入余角。只写入计算的角度。这是默认设置。</para>
		/// <para>选中 - 写入余角。</para>
		/// <para><see cref="ComplementAngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComplementAngle { get; set; } = "false";

		/// <summary>
		/// <para>Events with a positive offset will be placed to the right of the routes</para>
		/// <para>指定将具有正向偏移的路径事件显示在哪一侧。此参数只有在已指定偏移字段时才有效。</para>
		/// <para>未选中 - 具有正向偏移的事件显示在路径左侧。路径的这一侧由测量方向而不一定由数字化方向确定。这是默认设置。</para>
		/// <para>选中 - 具有正向偏移的事件显示在路径右侧。路径的这一侧由数字化方向确定。</para>
		/// <para><see cref="OffsetDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OffsetDirection { get; set; } = "false";

		/// <summary>
		/// <para>Point events will be generated as multipoint features</para>
		/// <para>指定将点事件视为点要素还是多点要素。</para>
		/// <para>未选中 - 将点事件视为点要素。这是默认设置。</para>
		/// <para>选中 - 将点事件视为多点要素。</para>
		/// <para><see cref="PointEventTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PointEventType { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeRouteEventLayer SetEnviroment(object configKeyword = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate a field for locating errors</para>
		/// </summary>
		public enum AddErrorFieldEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_FIELD")]
			ERROR_FIELD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ERROR_FIELD")]
			NO_ERROR_FIELD,

		}

		/// <summary>
		/// <para>Generate an angle field</para>
		/// </summary>
		public enum AddAngleFieldEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE_FIELD")]
			ANGLE_FIELD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE_FIELD")]
			NO_ANGLE_FIELD,

		}

		/// <summary>
		/// <para>Calculated Angle Type</para>
		/// </summary>
		public enum AngleTypeEnum 
		{
			/// <summary>
			/// <para>法向—将计算法向角（直角）。这是默认设置。</para>
			/// </summary>
			[GPValue("NORMAL")]
			[Description("法向")]
			Normal,

			/// <summary>
			/// <para>切向—将计算正切角。</para>
			/// </summary>
			[GPValue("TANGENT")]
			[Description("切向")]
			Tangent,

		}

		/// <summary>
		/// <para>Write the complement of the angle to the angle field</para>
		/// </summary>
		public enum ComplementAngleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPLEMENT")]
			COMPLEMENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ANGLE")]
			ANGLE,

		}

		/// <summary>
		/// <para>Events with a positive offset will be placed to the right of the routes</para>
		/// </summary>
		public enum OffsetDirectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RIGHT")]
			RIGHT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("LEFT")]
			LEFT,

		}

		/// <summary>
		/// <para>Point events will be generated as multipoint features</para>
		/// </summary>
		public enum PointEventTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPOINT")]
			MULTIPOINT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("POINT")]
			POINT,

		}

#endregion
	}
}
