using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Export Diagram Content</para>
	/// <para>导出逻辑示意图内容</para>
	/// <para>以反映基本连通性的简单格式 (JSON) 导出逻辑示意图内容。还可以导出其他可选信息，例如逻辑示意图属性、逻辑示意图要素几何、网络元素属性和聚合元素。</para>
	/// </summary>
	public class ExportDiagramContent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>公共设施网络或追踪网络图层、公共设施网络或追踪网络数据元素或与要导出的网络逻辑示意图相关的网络逻辑示意图图层。</para>
		/// </param>
		/// <param name="NetworkDiagramName">
		/// <para>Network Diagram Name</para>
		/// <para>要导出的网络逻辑示意图的名称。</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output File</para>
		/// <para>将使用导出的逻辑示意图内容创建的输出 .json 文件。</para>
		/// </param>
		public ExportDiagramContent(object InUtilityNetwork, object NetworkDiagramName, object OutFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.NetworkDiagramName = NetworkDiagramName;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出逻辑示意图内容</para>
		/// </summary>
		public override string DisplayName() => "导出逻辑示意图内容";

		/// <summary>
		/// <para>Tool Name : ExportDiagramContent</para>
		/// </summary>
		public override string ToolName() => "ExportDiagramContent";

		/// <summary>
		/// <para>Tool Excute Name : nd.ExportDiagramContent</para>
		/// </summary>
		public override string ExcuteName() => "nd.ExportDiagramContent";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, NetworkDiagramName, OutFile, IncludeDiagramProperties, IncludeGeometries, IncludeAttributes, IncludeAggregations, UseDomains };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>公共设施网络或追踪网络图层、公共设施网络或追踪网络数据元素或与要导出的网络逻辑示意图相关的网络逻辑示意图图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>要导出的网络逻辑示意图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkDiagramName { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>将使用导出的逻辑示意图内容创建的输出 .json 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>Include diagram properties</para>
		/// <para>指定是否导出逻辑示意图属性。</para>
		/// <para>选中 - 将导出逻辑示意图属性（统计信息、创建和更新日期等）。</para>
		/// <para>未选中 - 不会导出逻辑示意图属性。这是默认设置。</para>
		/// <para><see cref="IncludeDiagramPropertiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeDiagramProperties { get; set; } = "false";

		/// <summary>
		/// <para>Include geometries</para>
		/// <para>指定是否导出逻辑示意图要素的几何。</para>
		/// <para>选中 - 每个逻辑示意图要素将与其几何一起导出。</para>
		/// <para>未选中 - 将导出每个逻辑示意图要素而不导出其几何。这是默认设置。</para>
		/// <para><see cref="IncludeGeometriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeGeometries { get; set; } = "false";

		/// <summary>
		/// <para>Include attributes</para>
		/// <para>指定是否将导出关联网络元素的属性。</para>
		/// <para>选中 - 将导出关联的网络元素属性。</para>
		/// <para>未选中 - 不会导出关联的网络元素属性。这是默认设置。</para>
		/// <para><see cref="IncludeAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeAttributes { get; set; } = "false";

		/// <summary>
		/// <para>Include aggregations</para>
		/// <para>指定导出每个逻辑示意图要素时是否导出其聚合的网络元素的列表。</para>
		/// <para>选中 - 将导出每个逻辑示意图要素及其聚合的网络元素的列表及其资产组和资产类型值。</para>
		/// <para>未选中 - 不会导出逻辑示意图要素聚合。这是默认设置。</para>
		/// <para><see cref="IncludeAggregationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeAggregations { get; set; } = "false";

		/// <summary>
		/// <para>Use domain and subtype descriptions</para>
		/// <para>指定将导出编码属性域和子类型值的方式。当选中包括属性或包括聚合参数时，将启用此参数。</para>
		/// <para>选中 - 将使用字符串描述，而非原始值来导出编码属性域和子类型值。</para>
		/// <para>未选中 - 编码属性域和子类型值将导出为原始值。这是默认设置。</para>
		/// <para><see cref="UseDomainsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseDomains { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Include diagram properties</para>
		/// </summary>
		public enum IncludeDiagramPropertiesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_DIAGRAM_PROPERTIES")]
			INCLUDE_DIAGRAM_PROPERTIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_DIAGRAM_PROPERTIES")]
			EXCLUDE_DIAGRAM_PROPERTIES,

		}

		/// <summary>
		/// <para>Include geometries</para>
		/// </summary>
		public enum IncludeGeometriesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRIES")]
			INCLUDE_GEOMETRIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRIES")]
			EXCLUDE_GEOMETRIES,

		}

		/// <summary>
		/// <para>Include attributes</para>
		/// </summary>
		public enum IncludeAttributesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_ATTRIBUTES")]
			INCLUDE_ATTRIBUTES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_ATTRIBUTES")]
			EXCLUDE_ATTRIBUTES,

		}

		/// <summary>
		/// <para>Include aggregations</para>
		/// </summary>
		public enum IncludeAggregationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_AGGREGATIONS")]
			INCLUDE_AGGREGATIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_AGGREGATIONS")]
			EXCLUDE_AGGREGATIONS,

		}

		/// <summary>
		/// <para>Use domain and subtype descriptions</para>
		/// </summary>
		public enum UseDomainsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CODED_VALUE_NAMES")]
			USE_CODED_VALUE_NAMES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_USE_CODED_VALUE_NAMES")]
			DONT_USE_CODED_VALUE_NAMES,

		}

#endregion
	}
}
