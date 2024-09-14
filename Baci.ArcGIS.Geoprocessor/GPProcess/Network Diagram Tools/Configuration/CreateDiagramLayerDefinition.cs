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
	/// <para>Create Diagram Layer Definition</para>
	/// <para>创建逻辑示意图图层定义</para>
	/// <para>使用活动地图中的网络要素图层设置，为输入逻辑示意图模板创建逻辑示意图图层定义。</para>
	/// </summary>
	public class CreateDiagramLayerDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>活动地图中的 utility network or trace network 图层。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板名称</para>
		/// </param>
		public CreateDiagramLayerDefinition(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建逻辑示意图图层定义</para>
		/// </summary>
		public override string DisplayName() => "创建逻辑示意图图层定义";

		/// <summary>
		/// <para>Tool Name : CreateDiagramLayerDefinition</para>
		/// </summary>
		public override string ToolName() => "CreateDiagramLayerDefinition";

		/// <summary>
		/// <para>Tool Excute Name : nd.CreateDiagramLayerDefinition</para>
		/// </summary>
		public override string ExcuteName() => "nd.CreateDiagramLayerDefinition";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, SystemJunctions!, ConnectivityAssociations!, StructuralAttachments!, ReductionEdges!, PointSublayers!, PolygonSublayers!, OutUtilityNetwork!, OutTemplateName!, JunctionObjectPointSublayers!, EdgeObjectPolylineSublayers!, OverwriteAllLayers! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>活动地图中的 utility network or trace network 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板名称</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>System Junctions</para>
		/// <para>指定是否在基于指定模板的逻辑示意图中表示系统交汇点和系统交汇点对象。</para>
		/// <para>选中 - 网络线沿线的系统交汇点和网络边对象沿线的系统交汇点对象在逻辑示意图中分别由“系统交汇点”图层和“系统交汇点对象”图层表示。这是默认设置。</para>
		/// <para>未选中 - 将不会在逻辑示意图中表示系统交汇点和系统交汇点对象。</para>
		/// <para><see cref="SystemJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object? SystemJunctions { get; set; } = "true";

		/// <summary>
		/// <para>Connectivity Associations</para>
		/// <para>指定是否在基于指定模板的逻辑示意图中表示连通性关联。</para>
		/// <para>选中 - 连通性关联在逻辑示意图中由“连通性关联”图层表示。这是默认设置。</para>
		/// <para>未选中 - 将不会在逻辑示意图中表示连通性关联。</para>
		/// <para><see cref="ConnectivityAssociationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object? ConnectivityAssociations { get; set; } = "true";

		/// <summary>
		/// <para>Structural Attachments</para>
		/// <para>指定是否在基于指定模板的逻辑示意图中表示结构附件。</para>
		/// <para>选中 - 结构附件关联在逻辑示意图中由“结构附件”图层表示。这是默认设置。</para>
		/// <para>未选中 - 将不会在逻辑示意图中表示结构附件关联。</para>
		/// <para><see cref="StructuralAttachmentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object? StructuralAttachments { get; set; } = "true";

		/// <summary>
		/// <para>Reduction Edges</para>
		/// <para>指定是否在基于指定模板的逻辑示意图中表示减少边。</para>
		/// <para>选中 - 缩减边在逻辑示意图中由“缩减边”图层表示。这是默认设置。</para>
		/// <para>未选中 - 将不会在逻辑示意图中表示缩减边。</para>
		/// <para><see cref="ReductionEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional SubLayers")]
		public object? ReductionEdges { get; set; } = "true";

		/// <summary>
		/// <para>Points for edges reduced as junctions or collapsed polygons</para>
		/// <para>指定是否添加图层以将容器面、线网络要素或网络边对象表示为逻辑示意图中的点要素。</para>
		/// <para>子类型图层列使用如下：</para>
		/// <para>选中 - 图层将通过子类型图层组创建。</para>
		/// <para>未选中 - 图层将以简单图层形式创建。这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object? PointSublayers { get; set; }

		/// <summary>
		/// <para>Polygons for containers</para>
		/// <para>指定是否添加图层以将容器点要素或容器交汇点对象表示为逻辑示意图中的面要素。</para>
		/// <para>子类型图层列使用如下：</para>
		/// <para>选中 - 图层将通过子类型图层组创建。</para>
		/// <para>未选中 - 图层将以简单图层形式创建。这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object? PolygonSublayers { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutTemplateName { get; set; }

		/// <summary>
		/// <para>Points for junction objects</para>
		/// <para>指定是否添加图层以将交汇点对象表示为逻辑示意图中的点要素。</para>
		/// <para>子类型图层列使用如下：</para>
		/// <para>选中 - 图层将通过子类型图层组创建。</para>
		/// <para>未选中 - 图层将以简单图层形式创建。这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object? JunctionObjectPointSublayers { get; set; }

		/// <summary>
		/// <para>Polylines for edge objects</para>
		/// <para>指定是否添加图层以将边对象表示为逻辑示意图中的折线要素。</para>
		/// <para>子类型图层列使用如下：</para>
		/// <para>选中 - 图层将通过子类型图层组创建。</para>
		/// <para>未选中 - 图层将以简单图层形式创建。这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Additional SubLayers")]
		public object? EdgeObjectPolylineSublayers { get; set; }

		/// <summary>
		/// <para>Overwrite all layers</para>
		/// <para>指定是覆盖还是保留逻辑示意图图层下的所有现有图层，输入网络地图中的图层和明确指定的其他子图层除外。</para>
		/// <para>选中 - 将初始化或完全重置（覆盖）逻辑示意图图层定义，包括输入地图和其他子图层部分的指定设置中的图层。这是默认设置。</para>
		/// <para>未选中 - 将保留逻辑示意图图层下的所有现有图层，输入网络地图中的图层以及在其他子图层部分中明确指定的图层除外。</para>
		/// <para><see cref="OverwriteAllLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OverwriteAllLayers { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>System Junctions</para>
		/// </summary>
		public enum SystemJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Connectivity Associations</para>
		/// </summary>
		public enum ConnectivityAssociationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Structural Attachments</para>
		/// </summary>
		public enum StructuralAttachmentsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Reduction Edges</para>
		/// </summary>
		public enum ReductionEdgesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHOW")]
			SHOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

		/// <summary>
		/// <para>Overwrite all layers</para>
		/// </summary>
		public enum OverwriteAllLayersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE_ALL")]
			OVERWRITE_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
