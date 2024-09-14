using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Layers</para>
	/// <para>迭代图层</para>
	/// <para>迭代地图中的图层。</para>
	/// </summary>
	public class IterateLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>包含要迭代的图层的输入地图。</para>
		/// </param>
		public IterateLayers(object InputMap)
		{
			this.InputMap = InputMap;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代图层</para>
		/// </summary>
		public override string DisplayName() => "迭代图层";

		/// <summary>
		/// <para>Tool Name : IterateLayers</para>
		/// </summary>
		public override string ToolName() => "IterateLayers";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateLayers</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMap, Wildcard!, LayerType!, WorkspaceType!, FeatureType!, RasterFormatType!, LayerVisibility!, LayerState!, Recursive!, OutputLayer!, OutputName!, OutputLayerType!, OutputWorkspaceType! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>包含要迭代的图层的输入地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>* 与有助于限制结果的字符的组合。 星号相当于指定全部。 如果未指定通配符，将返回所有输入。 例如，可将其用于将输入名称迭代限制为从某一字符或词语开始（例如，A*、Ari* 或 Land* 等）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Layer Type</para>
		/// <para>指定将用于过滤图层的图层类型。 如果未指定图层类型，则将迭代所有受支持的图层类型。 可以使用多种图层类型来过滤图层。</para>
		/// <para>注记图层—将迭代注记图层。</para>
		/// <para>建筑图层—将迭代建筑物图层。</para>
		/// <para>构建场景图层—将迭代建筑物场景图层。</para>
		/// <para>尺寸图层—将迭代尺寸注记图层。</para>
		/// <para>要素图层—将迭代要素图层。</para>
		/// <para>地统计分析图层—将迭代地统计图层。</para>
		/// <para>分组图层—将迭代图层组。</para>
		/// <para>子类型图层组—将迭代子类型图层组。</para>
		/// <para>KML 图层—将迭代 KML 图层。</para>
		/// <para>LAS 数据集图层—将迭代 LAS 数据集图层。</para>
		/// <para>镶嵌图层—将迭代镶嵌图层。</para>
		/// <para>网络分析图层—将迭代 Network Analyst 图层。</para>
		/// <para>网络数据集图层—将迭代网络数据集图层。</para>
		/// <para>宗地图层—将迭代宗地图层。</para>
		/// <para>栅格图层—将迭代栅格图层。</para>
		/// <para>场景服务图层—将迭代场景服务图层。</para>
		/// <para>表视图—将迭代表视图。</para>
		/// <para>Terrain 图层—将迭代地形图层。</para>
		/// <para>TIN 图层—将迭代 TIN 图层。</para>
		/// <para>拓扑图层—将迭代拓扑图层。</para>
		/// <para>追踪网络图层—将迭代追踪网络图层。</para>
		/// <para>公共设施网络图层—将迭代公共设施网络图层。</para>
		/// <para>体素图层—将迭代体素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? LayerType { get; set; }

		/// <summary>
		/// <para>Workspace Type</para>
		/// <para>指定将用于过滤图层的工作空间类型。 如果未指定工作空间类型，则将迭代受支持的工作空间类型的所有字段。</para>
		/// <para>仅当图层类型参数设置为要素图层、栅格图层或表视图时，才启用工作空间类型参数。</para>
		/// <para>多文件要素连接—多文件要素连接工作空间中的图层将被迭代。</para>
		/// <para>BIM 文件—将迭代 BIM 文件工作空间中的图层。</para>
		/// <para>CAD—将迭代 CAD 工作空间中的图层。</para>
		/// <para>分隔文本文件—将迭代分隔文本文件工作空间中的图层。</para>
		/// <para>企业级地理数据库—将迭代企业级地理数据库工作空间中的图层。</para>
		/// <para>要素服务—将迭代要素服务工作空间中的图层。</para>
		/// <para>文件地理数据库—将迭代文件地理数据库工作空间中的图层。</para>
		/// <para>内存数据库—将迭代内存数据库工作空间中的图层。</para>
		/// <para>Microsoft Excel—将迭代 Microsoft Excel 工作空间中的图层。</para>
		/// <para>NetCDF—将迭代 NetCDF 工作空间中的图层。</para>
		/// <para>OLE DB—将迭代 OLE DB 工作空间中的图层。</para>
		/// <para>栅格—将迭代栅格工作空间中的图层。</para>
		/// <para>Shapefile—将迭代 Shapefile 工作空间中的图层。</para>
		/// <para>SQLite—将迭代 SQLite 工作空间中的图层。</para>
		/// <para>SQL 查询图层—将迭代 SQL 查询图层工作空间中的图层。</para>
		/// <para>流服务—将迭代流服务工作空间中的图层。</para>
		/// <para>Web 要素服务—将迭代 Web 要素服务工作空间中的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? WorkspaceType { get; set; }

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>指定将用于过滤图层的要素类型。 如果未指定要素类型，则将迭代所有受支持的要素类型。</para>
		/// <para>注记—将迭代注记要素类。</para>
		/// <para>尺寸注记—将迭代尺寸注记要素类。</para>
		/// <para>简单边—将迭代简单边要素类。</para>
		/// <para>复杂边—将迭代复杂边要素类。</para>
		/// <para>简单交汇点—将迭代简单交汇点要素类。</para>
		/// <para>复杂交汇点—将迭代复杂交汇点要素类。</para>
		/// <para>线—将迭代线要素类。</para>
		/// <para>点—将迭代点要素类。</para>
		/// <para>面—将迭代面要素类。</para>
		/// <para>多面体—将迭代多面体要素类。</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? FeatureType { get; set; }

		/// <summary>
		/// <para>Raster Type</para>
		/// <para>当工作空间类型参数设置为栅格时将用于过滤栅格图层的栅格格式类型。 如果未指定栅格类型，则将迭代受支持栅格类型的所有图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? RasterFormatType { get; set; }

		/// <summary>
		/// <para>Visibility</para>
		/// <para>指定是否将使用图层可见性来过滤图层。</para>
		/// <para>全部—图层可见性将不会用于过滤图层。</para>
		/// <para>可见—可见图层将被迭代。</para>
		/// <para>不可见—不可见图层将被迭代。</para>
		/// <para><see cref="LayerVisibilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Layer Properties")]
		public object? LayerVisibility { get; set; } = "ALL";

		/// <summary>
		/// <para>State</para>
		/// <para>指定将用于过滤图层的图层状态。 如果该参数设置为无效，则将返回源路径图层损坏的图层。</para>
		/// <para>全部—图层状态将不会用于过滤图层。</para>
		/// <para>有效—将迭代有效图层。</para>
		/// <para>无效—将迭代无效图层。</para>
		/// <para><see cref="LayerStateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Layer Properties")]
		public object? LayerState { get; set; } = "ALL";

		/// <summary>
		/// <para>Recursive</para>
		/// <para>指定迭代器是否将迭代嵌套的图层组。</para>
		/// <para>选中 - 将迭代嵌套的图层组。</para>
		/// <para>未选中 - 不会迭代嵌套的图层组。</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "true";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputName { get; set; }

		/// <summary>
		/// <para>Output Layer Type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputLayerType { get; set; }

		/// <summary>
		/// <para>Workspace or Format Type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputWorkspaceType { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>注记—将迭代注记要素类。</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("注记")]
			Annotation,

			/// <summary>
			/// <para>尺寸注记—将迭代尺寸注记要素类。</para>
			/// </summary>
			[GPValue("DIMENSION")]
			[Description("尺寸注记")]
			Dimension,

			/// <summary>
			/// <para>简单边—将迭代简单边要素类。</para>
			/// </summary>
			[GPValue("SIMPLE_EDGE")]
			[Description("简单边")]
			Simple_Edge,

			/// <summary>
			/// <para>复杂边—将迭代复杂边要素类。</para>
			/// </summary>
			[GPValue("COMPLEX_EDGE")]
			[Description("复杂边")]
			Complex_Edge,

			/// <summary>
			/// <para>简单交汇点—将迭代简单交汇点要素类。</para>
			/// </summary>
			[GPValue("SIMPLE_JUNCTION")]
			[Description("简单交汇点")]
			Simple_Junction,

			/// <summary>
			/// <para>复杂交汇点—将迭代复杂交汇点要素类。</para>
			/// </summary>
			[GPValue("COMPLEX_JUNCTION")]
			[Description("复杂交汇点")]
			Complex_Junction,

			/// <summary>
			/// <para>线—将迭代线要素类。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线")]
			Line,

			/// <summary>
			/// <para>点—将迭代点要素类。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>面—将迭代面要素类。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>多面体—将迭代多面体要素类。</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("多面体")]
			Multipatch,

		}

		/// <summary>
		/// <para>Visibility</para>
		/// </summary>
		public enum LayerVisibilityEnum 
		{
			/// <summary>
			/// <para>全部—图层可见性将不会用于过滤图层。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>可见—可见图层将被迭代。</para>
			/// </summary>
			[GPValue("VISIBLE")]
			[Description("可见")]
			Visible,

			/// <summary>
			/// <para>不可见—不可见图层将被迭代。</para>
			/// </summary>
			[GPValue("NOT_VISIBLE")]
			[Description("不可见")]
			Not_Visible,

		}

		/// <summary>
		/// <para>State</para>
		/// </summary>
		public enum LayerStateEnum 
		{
			/// <summary>
			/// <para>全部—图层状态将不会用于过滤图层。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>有效—将迭代有效图层。</para>
			/// </summary>
			[GPValue("VALID")]
			[Description("有效")]
			Valid,

			/// <summary>
			/// <para>无效—将迭代无效图层。</para>
			/// </summary>
			[GPValue("INVALID")]
			[Description("无效")]
			Invalid,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
