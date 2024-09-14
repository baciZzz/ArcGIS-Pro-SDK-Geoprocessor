using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Solve</para>
	/// <para>求解</para>
	/// <para>基于网络位置和属性求解网络分析图层问题。</para>
	/// </summary>
	[Obsolete()]
	public class Solve : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>要进行分析计算的网络分析图层。</para>
		/// </param>
		public Solve(object InNetworkAnalysisLayer)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 求解</para>
		/// </summary>
		public override string DisplayName() => "求解";

		/// <summary>
		/// <para>Tool Name : 求解</para>
		/// </summary>
		public override string ToolName() => "求解";

		/// <summary>
		/// <para>Tool Excute Name : na.Solve</para>
		/// </summary>
		public override string ExcuteName() => "na.Solve";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, IgnoreInvalids!, TerminateOnSolveError!, SimplificationTolerance!, OutputLayer!, SolveSucceeded!, Overrides! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>要进行分析计算的网络分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// <para>指定是否忽略无效的输入位置。 通常，如果无法在网络上定位，则位置无效。 当无效位置被忽略时，求解器将跳过它们并尝试使用剩余位置执行分析。</para>
		/// <para>选中 - 将忽略无效的输入位置，并且仅使用有效的位置。</para>
		/// <para>未选中 - 将使用所有输入位置。 无效的位置将导致求解失败。</para>
		/// <para>默认值将与指定输入网络分析图层值上的求解时忽略无效位置设置相匹配。</para>
		/// <para><see cref="IgnoreInvalidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreInvalids { get; set; } = "true";

		/// <summary>
		/// <para>Terminate on Solve Error</para>
		/// <para>指定在求解过程中遇到错误时是否终止工具运行。</para>
		/// <para>选中 - 该工具在求解程序遇到错误时将终止工具运行。 这是默认设置。</para>
		/// <para>未选中 - 即使求解程序遇到错误，该工具也不停止，而是继续运行。 求解器返回的所有错误消息都将转换为警告消息。 如果在应用程序中启用了后台处理，则使用该选项。</para>
		/// <para><see cref="TerminateOnSolveErrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TerminateOnSolveError { get; set; } = "true";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>容差确定输出几何的简化程度。 如果已指定了容差，容差必须大于零。 可以选择首选单位；默认单位为十进制度。</para>
		/// <para>指定简化容差会减少渲染路径或服务区的时间。 但缺点是，简化几何移除了折点，这样会降低以更大比例输出的空间精确度。</para>
		/// <para>由于带两个折点的线不能再简化，所以此参数对单一线段输出的绘制时间没有影响，例如直线路线、 OD 成本矩阵线和位置分配线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? SolveSucceeded { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>此参数仅供内部使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Overrides { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Solve SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// </summary>
		public enum IgnoreInvalidsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

		/// <summary>
		/// <para>Terminate on Solve Error</para>
		/// </summary>
		public enum TerminateOnSolveErrorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TERMINATE")]
			TERMINATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CONTINUE")]
			CONTINUE,

		}

#endregion
	}
}
