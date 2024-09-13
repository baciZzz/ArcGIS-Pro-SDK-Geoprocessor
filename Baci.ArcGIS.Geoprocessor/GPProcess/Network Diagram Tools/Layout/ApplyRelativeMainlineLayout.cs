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
	/// <para>Apply Relative Mainline Layout</para>
	/// <para>应用相对主线布局</para>
	/// <para>用于在活动逻辑示意图中沿平行的直线排列网络逻辑示意图要素。</para>
	/// </summary>
	public class ApplyRelativeMainlineLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		/// <param name="LineAttribute">
		/// <para>Line Attribute</para>
		/// <para>用于标识构成直线的线的网络属性的名称。此网络属性必须存在于网络线类中。对于构成直线（例如线 1、线 2 等等）的所有边，其值都必须相同。</para>
		/// </param>
		public ApplyRelativeMainlineLayout(object InNetworkDiagramLayer, object LineAttribute)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.LineAttribute = LineAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用相对主线布局</para>
		/// </summary>
		public override string DisplayName() => "应用相对主线布局";

		/// <summary>
		/// <para>Tool Name : ApplyRelativeMainlineLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyRelativeMainlineLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyRelativeMainlineLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyRelativeMainlineLayout";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, LineAttribute, MainlineDirection, OffsetBetweenBranches, BreakpointAngle, TypeAttribute, MainlineValues, BranchValues, ExcludedValues, IsCompressing, CompressionRatio, MinimalDistance, AlignmentAttribute, InitialDistances, LengthAttribute, OutNetworkDiagramLayer, RunAsync };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Line Attribute</para>
		/// <para>用于标识构成直线的线的网络属性的名称。此网络属性必须存在于网络线类中。对于构成直线（例如线 1、线 2 等等）的所有边，其值都必须相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LineAttribute { get; set; }

		/// <summary>
		/// <para>Direction</para>
		/// <para>指定主线的方向。</para>
		/// <para>从左到右—主线将绘制为从左侧开始并于右侧终止的水平线。这是默认设置。</para>
		/// <para>从上到下—主线将绘制为从顶部开始并于底部终止的垂直线。</para>
		/// <para><see cref="MainlineDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MainlineDirection { get; set; } = "FROM_LEFT_TO_RIGHT";

		/// <summary>
		/// <para>Offset Between Branches</para>
		/// <para>两个相邻分支沿垂直于线方向的轴之间的间距。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object OffsetBetweenBranches { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Break Point Angle (in degrees)</para>
		/// <para>用于在分支上定位中断点的角度。该值介于 30 度和 90 度之间，与分支间的偏移量参数值结合使用可计算出这个位置。中断点角度值为 90 度时，将正交显示每个分支。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BreakpointAngle { get; set; } = "45";

		/// <summary>
		/// <para>Type Attribute</para>
		/// <para>用于限定线的网络属性的名称。此网络属性可能存在于网络线类中。</para>
		/// <para>类型属性和线属性参数值可以是相同的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Line Classification")]
		public object TypeAttribute { get; set; }

		/// <summary>
		/// <para>Mainline Values</para>
		/// <para>用于标识主线的类型属性值。如果存在这样的值，则无论主线相关网络要素线类或边对象表为何，对于构成主线的任何边而言，该值都必须是相同的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object MainlineValues { get; set; }

		/// <summary>
		/// <para>Branch Values</para>
		/// <para>用于标识分支的类型属性值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object BranchValues { get; set; }

		/// <summary>
		/// <para>Excluded Values</para>
		/// <para>用于标识边的类型属性值将从直线（交线或梯形线）中排除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object ExcludedValues { get; set; }

		/// <summary>
		/// <para>Compression along the direction</para>
		/// <para>指定是否压缩图形。</para>
		/// <para>选中 - 将使用压缩。在处理结束后将执行一个附加步骤，用于缩短邻近交汇点的相邻组之间沿该方向的距离，同时还保持这些组之间的相对定位。邻近交汇点是指地理位置彼此靠近但没有直接连接的交汇点。</para>
		/// <para>未选中 - 将不使用压缩。这是默认设置。</para>
		/// <para><see cref="IsCompressingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Compression")]
		public object IsCompressing { get; set; } = "false";

		/// <summary>
		/// <para>Ratio (%)</para>
		/// <para>0 和 100 之间应用于任何边的长度（在减去其长度的最小距离后）的值。比率 (%) 为 100 时，检测的各个交汇点组之间的距离等于最小距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Line Compression")]
		public object CompressionRatio { get; set; } = "0";

		/// <summary>
		/// <para>Minimal Distance</para>
		/// <para>两个邻近交汇点的相邻组之间的最小距离。此最小距离也用于根据邻近交汇点沿方向轴的投影将它们分组。当在该轴上投影的两个交汇点之间的距离小于此距离时，这两个交汇点将属于同一组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Line Compression")]
		public object MinimalDistance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Alignment Attribute</para>
		/// <para>用于对齐分割的线的网络属性的名称。此算法将线与相同的属性值对齐。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object AlignmentAttribute { get; set; }

		/// <summary>
		/// <para>Initial Distances</para>
		/// <para>用于指定如何评估逻辑示意图边的长度。此长度可确定交汇点沿这一方向的位置。已连接交汇点沿方向的距离并不相等；它们彼此相关且取决于当前边的长度和最短边的长度。</para>
		/// <para>根据当前边几何— 根据当前的边几何计算距离。这是默认设置。</para>
		/// <para>根据属性边—根据边上存在的给定属性计算距离。</para>
		/// <para><see cref="InitialDistancesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object InitialDistances { get; set; } = "FROM_CURRENT_EDGE_GEOMETRY";

		/// <summary>
		/// <para>Length Attribute</para>
		/// <para>当初始距离为 根据属性边时，将用于计算距离的网络属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object LengthAttribute { get; set; }

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>指定布局算法在服务器上将异步运行还是同步运行。</para>
		/// <para>选中 - 布局算法将在服务器上异步运行。服务器资源可通过该选项来运行超时较长的布局算法。当执行耗时且可能导致服务器超时的布局（例如，部分重叠边）并应用于大型逻辑示意图（超过 25,000 个要素）时，建议进行异步运行。</para>
		/// <para>未选中 - 布局算法将在服务器上同步运行。如果执行时超过服务超时值（默认为 600 秒），则布局算法可能失败，无法完成。这是默认设置。</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object RunAsync { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Direction</para>
		/// </summary>
		public enum MainlineDirectionEnum 
		{
			/// <summary>
			/// <para>从左到右—主线将绘制为从左侧开始并于右侧终止的水平线。这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_LEFT_TO_RIGHT")]
			[Description("从左到右")]
			From_left_to_right,

			/// <summary>
			/// <para>从上到下—主线将绘制为从顶部开始并于底部终止的垂直线。</para>
			/// </summary>
			[GPValue("FROM_TOP_TO_BOTTOM")]
			[Description("从上到下")]
			From_top_to_bottom,

		}

		/// <summary>
		/// <para>Compression along the direction</para>
		/// </summary>
		public enum IsCompressingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_COMPRESSION")]
			USE_COMPRESSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_COMPRESSION")]
			DO_NOT_USE_COMPRESSION,

		}

		/// <summary>
		/// <para>Initial Distances</para>
		/// </summary>
		public enum InitialDistancesEnum 
		{
			/// <summary>
			/// <para>根据当前边几何— 根据当前的边几何计算距离。这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_CURRENT_EDGE_GEOMETRY")]
			[Description("根据当前边几何")]
			From_current_edge_geometry,

			/// <summary>
			/// <para>根据属性边—根据边上存在的给定属性计算距离。</para>
			/// </summary>
			[GPValue("FROM_ATTRIBUTE_EDGE")]
			[Description("根据属性边")]
			From_attribute_edge,

		}

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RUN_ASYNCHRONOUSLY")]
			RUN_ASYNCHRONOUSLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("RUN_SYNCHRONOUSLY")]
			RUN_SYNCHRONOUSLY,

		}

#endregion
	}
}
