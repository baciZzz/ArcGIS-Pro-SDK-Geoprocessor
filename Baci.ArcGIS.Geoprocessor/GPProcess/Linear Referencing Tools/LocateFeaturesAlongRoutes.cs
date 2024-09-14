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
	/// <para>Locate Features Along Routes</para>
	/// <para>沿路径定位要素</para>
	/// <para>计算输入要素（点、线或面）与路径要素的交集，并将路径和测量信息写入新的事件表。</para>
	/// </summary>
	public class LocateFeaturesAlongRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入点、线或面要素。</para>
		/// </param>
		/// <param name="InRoutes">
		/// <para>Input Route Features</para>
		/// <para>将与输入要素相交的路径。</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。该字段可以是数值或字符。</para>
		/// </param>
		/// <param name="RadiusOrTolerance">
		/// <para>Search Radius</para>
		/// <para>如果输入要素是点，则搜索半径是数值，定义可在每个点周围的多大范围内执行搜索以找到目标路径。</para>
		/// <para>如果输入要素是线，则搜索容差实际上是拓扑容差，即表示输入线与目标路径之间的最大容许距离的数值。</para>
		/// <para>如果输入要素是面，则忽略此参数且不使用搜索半径。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Event Table</para>
		/// <para>要创建的表。</para>
		/// </param>
		/// <param name="OutEventProperties">
		/// <para>Output Event Table Properties</para>
		/// <para>由要写入输出事件表的路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 包含指明每个事件所在路径的值的字段。</para>
		/// <para>事件类型 - 输出事件表包含的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。只有一个测量字段是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。“测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>“测量始于”字段 - 包含测量值的字段。在事件类型是 POINT 或 LINE 时必填。请注意，事件类型为 POINT 时，此参数的标注变为“测量字段”。</para>
		/// <para>“测量止于”字段 - 包含测量值的字段。在事件类型是 LINE 时必填。</para>
		/// </param>
		public LocateFeaturesAlongRoutes(object InFeatures, object InRoutes, object RouteIdField, object RadiusOrTolerance, object OutTable, object OutEventProperties)
		{
			this.InFeatures = InFeatures;
			this.InRoutes = InRoutes;
			this.RouteIdField = RouteIdField;
			this.RadiusOrTolerance = RadiusOrTolerance;
			this.OutTable = OutTable;
			this.OutEventProperties = OutEventProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : 沿路径定位要素</para>
		/// </summary>
		public override string DisplayName() => "沿路径定位要素";

		/// <summary>
		/// <para>Tool Name : LocateFeaturesAlongRoutes</para>
		/// </summary>
		public override string ToolName() => "LocateFeaturesAlongRoutes";

		/// <summary>
		/// <para>Tool Excute Name : lr.LocateFeaturesAlongRoutes</para>
		/// </summary>
		public override string ExcuteName() => "lr.LocateFeaturesAlongRoutes";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InRoutes, RouteIdField, RadiusOrTolerance, OutTable, OutEventProperties, RouteLocations, DistanceField, ZeroLengthEvents, InFields, MDirectionOffsetting };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>将与输入要素相交的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[xmlserialize(Xml = "<GPRouteDomain xsi:type='typens:GPRouteDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/2.8.0'></GPRouteDomain>")]
		public object InRoutes { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>包含可唯一识别每条路径的值的字段。该字段可以是数值或字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>如果输入要素是点，则搜索半径是数值，定义可在每个点周围的多大范围内执行搜索以找到目标路径。</para>
		/// <para>如果输入要素是线，则搜索容差实际上是拓扑容差，即表示输入线与目标路径之间的最大容许距离的数值。</para>
		/// <para>如果输入要素是面，则忽略此参数且不使用搜索半径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object RadiusOrTolerance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Output Event Table</para>
		/// <para>要创建的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output Event Table Properties</para>
		/// <para>由要写入输出事件表的路径位置字段和事件类型组成的参数。</para>
		/// <para>路径标识符字段 - 包含指明每个事件所在路径的值的字段。</para>
		/// <para>事件类型 - 输出事件表包含的事件类型（POINT 或 LINE）。</para>
		/// <para>POINT - 点事件出现在沿路径的确切点位置处。只有一个测量字段是必须指定的字段。</para>
		/// <para>LINE - 线事件定义路径的一部分。“测量始于”和“测量止于”都是必须指定的字段。</para>
		/// <para>“测量始于”字段 - 包含测量值的字段。在事件类型是 POINT 或 LINE 时必填。请注意，事件类型为 POINT 时，此参数的标注变为“测量字段”。</para>
		/// <para>“测量止于”字段 - 包含测量值的字段。在事件类型是 LINE 时必填。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRouteMeasureEventProperties()]
		public object OutEventProperties { get; set; }

		/// <summary>
		/// <para>Keep only the closest route location</para>
		/// <para>在沿路径定位点时，对于任何给定的点来说，在搜索半径范围内可能有多条路径。沿路径定位线或面时将忽略此参数。</para>
		/// <para>选中 - 只将最近的路径位置写入输出事件表。这是默认设置。</para>
		/// <para>未选中 - 将每个路径位置（搜索半径范围内）都写入输出事件表。</para>
		/// <para><see cref="RouteLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RouteLocations { get; set; } = "true";

		/// <summary>
		/// <para>Include distance field on output table</para>
		/// <para>指定是否将名为 DISTANCE 的字段添加到输出事件表。该字段中值的单位与指定搜索半径的单位相同。沿路径定位线或面时将忽略此参数。</para>
		/// <para>选中 - 包含点到路径距离的字段被添加到输出事件表。这是默认设置。</para>
		/// <para>未选中 - 包含点到路径距离的字段不被添加到输出事件表。</para>
		/// <para><see cref="DistanceFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DistanceField { get; set; } = "true";

		/// <summary>
		/// <para>Keep zero length line events</para>
		/// <para>沿路径定位面时，可在“测量始于”等于“测量止于”的位置处创建事件。沿路径定位点或线时将忽略此参数。</para>
		/// <para>选中 - 零长度线事件被写入输出事件表。这是默认设置。</para>
		/// <para>未选中 - 零长度线事件不被写入输出事件表。</para>
		/// <para><see cref="ZeroLengthEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ZeroLengthEvents { get; set; } = "true";

		/// <summary>
		/// <para>Include all fields from input</para>
		/// <para>指定输出事件表中是否包含路径位置字段以及输入要素的所有属性。</para>
		/// <para>选中 - 输出事件表中包含路径位置字段和输入要素的所有属性。这是默认设置。</para>
		/// <para>未选中 - 输出事件表中只包含路径位置字段和输入要素的 ObjectID 字段。</para>
		/// <para><see cref="InFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InFields { get; set; } = "true";

		/// <summary>
		/// <para>Use M direction offsetting</para>
		/// <para>指定计算的偏移距离应基于 M 方向还是数字化方向。如果已选中将距离字段添加到输出表上，则输出事件表中包括距离。</para>
		/// <para>选中 - 基于路径的 M 方向计算输出事件表中的距离值。位于路径 M 方向左侧的输入要素将被赋予正偏移值 (+)，位于 M 方向右侧的要素将被赋予负偏移值 (-)。这是默认设置。</para>
		/// <para>未选中 - 基于路径的数字化方向计算输出事件表中的距离值。位于路径数字化方向左侧的输入要素将被赋予负偏移值 (-)，位于路径数字化方向右侧的要素将被赋予正偏移值 (+)。</para>
		/// <para><see cref="MDirectionOffsettingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MDirectionOffsetting { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateFeaturesAlongRoutes SetEnviroment(object configKeyword = null, object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep only the closest route location</para>
		/// </summary>
		public enum RouteLocationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FIRST")]
			FIRST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Include distance field on output table</para>
		/// </summary>
		public enum DistanceFieldEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISTANCE")]
			DISTANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISTANCE")]
			NO_DISTANCE,

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
		/// <para>Use M direction offsetting</para>
		/// </summary>
		public enum MDirectionOffsettingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("M_DIRECTON")]
			M_DIRECTON,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_M_DIRECTION")]
			NO_M_DIRECTION,

		}

#endregion
	}
}
