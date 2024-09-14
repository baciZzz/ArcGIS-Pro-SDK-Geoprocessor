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
	/// <para>Apply Compression Layout</para>
	/// <para>应用压缩布局</para>
	/// <para>用于将逻辑示意图要素压缩到逻辑示意图的中部。</para>
	/// </summary>
	public class ApplyCompressionLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		public ApplyCompressionLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用压缩布局</para>
		/// </summary>
		public override string DisplayName() => "应用压缩布局";

		/// <summary>
		/// <para>Tool Name : ApplyCompressionLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyCompressionLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyCompressionLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyCompressionLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, GroupingDistanceAbsolute, VerticesRemovalRule, OutNetworkDiagramLayer, RunAsync };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>指定压缩布局算法将如何处理容器。</para>
		/// <para>选中 - 将对逻辑示意图的上方图执行压缩布局算法，以保留容器。这是默认设置。</para>
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行压缩布局算法。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Distance for Grouping</para>
		/// <para>分组距离用于确定两个连接的交汇点是否足够近，可将其视为相同交汇点组的一部分。交汇点组表示执行期间可作为组进行移动的多个交汇点。组可包含交汇点和容器。要将两个交汇点分为一组，则必须在逻辑示意图中通过边将其相连。默认值为 20（采用逻辑示意图坐标系的单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object GroupingDistanceAbsolute { get; set; } = "20 Unknown";

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// <para>指定逻辑示意图中要移除的沿边的折点。</para>
		/// <para>所有折点—将从逻辑示意图中移除所有边上的所有折点。</para>
		/// <para>所有外部折点—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将在边与容器面的交叉点处添加折点。这是默认设置。</para>
		/// <para>所有外部折点（第一个除外）—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将保留边上与容器面相交的第一个（或最后一个）外部折点。将在边与容器面的交叉点处自动插入折点。</para>
		/// <para><see cref="VerticesRemovalRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object VerticesRemovalRule { get; set; } = "OUTER";

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
		/// <para>Preserve container layout</para>
		/// </summary>
		public enum AreContainersPreservedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_CONTAINERS")]
			IGNORE_CONTAINERS,

		}

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// </summary>
		public enum VerticesRemovalRuleEnum 
		{
			/// <summary>
			/// <para>所有折点—将从逻辑示意图中移除所有边上的所有折点。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有折点")]
			All_vertices,

			/// <summary>
			/// <para>所有外部折点—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将在边与容器面的交叉点处添加折点。这是默认设置。</para>
			/// </summary>
			[GPValue("OUTER")]
			[Description("所有外部折点")]
			All_outer_vertices,

			/// <summary>
			/// <para>所有外部折点（第一个除外）—将保留检测到的交汇点组内的所有边折点，而移除外部的边折点。如果逻辑示意图中的容器具有与容器面相交的边，则将保留边上与容器面相交的第一个（或最后一个）外部折点。将在边与容器面的交叉点处自动插入折点。</para>
			/// </summary>
			[GPValue("OUTER_EXCEPT_FIRST")]
			[Description("所有外部折点（第一个除外）")]
			All_outer_vertices_except_the_first_one,

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
