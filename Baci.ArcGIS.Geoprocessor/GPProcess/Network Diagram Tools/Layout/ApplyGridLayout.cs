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
	/// <para>Apply Grid Layout</para>
	/// <para>应用格网布局</para>
	/// <para>可相对于预定义的磁格网定位逻辑示意图交汇点。</para>
	/// </summary>
	public class ApplyGridLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		public ApplyGridLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用格网布局</para>
		/// </summary>
		public override string DisplayName() => "应用格网布局";

		/// <summary>
		/// <para>Tool Name : ApplyGridLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyGridLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyGridLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyGridLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved!, CellWidthAbsolute!, CellHeightAbsolute!, OutNetworkDiagramLayer!, RunAsync! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>指定算法将如何处理容器。</para>
		/// <para>选中 - 将对逻辑示意图的上方图执行布局算法，以保留容器。</para>
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行布局算法。 这是默认设置。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Cell Width</para>
		/// <para>每个格网像元的宽度。默认值为 2（采用逻辑示意图坐标系的单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? CellWidthAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Cell Height</para>
		/// <para>每个格网像元的高度。默认值为 2（采用逻辑示意图坐标系的单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? CellHeightAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>指定布局算法在服务器上将异步运行还是同步运行。</para>
		/// <para>选中 - 布局算法将在服务器上异步运行。 服务器资源可通过该选项来运行超时较长的布局算法。 当执行耗时且可能导致服务器超时的布局（例如，部分重叠边）并应用于大型逻辑示意图（超过 25,000 个要素）时，建议进行异步运行。</para>
		/// <para>未选中 - 布局算法将在服务器上同步运行。 如果执行时超过服务默认超时值（600 秒），则布局算法可能失败，无法完成。 这是默认设置。</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? RunAsync { get; set; } = "false";

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
