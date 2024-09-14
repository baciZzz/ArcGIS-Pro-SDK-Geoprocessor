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
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, IgnoreInvalids, TerminateOnSolveError, SimplificationTolerance, OutputLayer, SolveSucceeded, Overrides };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>要进行分析计算的网络分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// <para>指定是否忽略无效的输入位置。</para>
		/// <para>选中 - 求解程序将跳过未定位的网络位置而仅根据有效的网络位置来求解分析图层。如果这些位置位于不可遍历的元素上或有其他错误，求解程序仍会继续求解。如果您知道您的网络位置并不完全正确，但是想对有效的网络位置求解，此选项很有用。这是默认设置。</para>
		/// <para>未选中 - 如果存在无效位置，则不进行求解。随后您可对这些无效位置进行调整，然后重新运行分析。</para>
		/// <para><see cref="IgnoreInvalidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreInvalids { get; set; } = "true";

		/// <summary>
		/// <para>Terminate on Solve Error</para>
		/// <para>指定在求解过程中遇到错误时是否应终止工具执行。</para>
		/// <para>选中 - 该工具在求解程序遇到错误时将无法执行操作。这是默认设置。</para>
		/// <para>未选中 - 即使求解程序遇到错误，该工具也不停止，而是继续执行操作。求解程序返回的所有错误消息都将转换为警告消息。如果在应用程序中启用了后台处理，则应使用该选项。</para>
		/// <para><see cref="TerminateOnSolveErrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TerminateOnSolveError { get; set; } = "true";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>容差确定输出几何的简化程度。如果已指定了容差，容差必须大于零。可以选择首选单位；默认单位为十进制度。</para>
		/// <para>指定简化容差会减少渲染路径或服务区的时间。但缺点是，简化几何移除了折点，这样会降低以更大比例输出的空间精确度。</para>
		/// <para>由于带两个折点的线不能再简化，所以此参数对单一线段输出的绘制时间没有影响，例如直线路线、 OD 成本矩阵线和位置分配线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object SolveSucceeded { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>求解网络分析问题时，指定可影响求解程序行为的其他设置。</para>
		/// <para>需要在 JavaScript 对象表示法 (JSON) 中指定此参数的值。例如，有效值的格式如下：{&quot;overrideSetting1&quot; : &quot;value1&quot;, &quot;overrideSetting2&quot; : &quot;value2&quot;}。覆盖设置名称始终以双引号括起。该值可以是数字、布尔值或字符串。</para>
		/// <para>此参数的默认值为无值，表示不覆盖任何求解程序设置。</para>
		/// <para>覆盖是高级设置，应仅在谨慎分析应用设置前后得到的结果之后使用。要获得每个求解程序支持的覆盖设置及其可接受值的列表，请联系 Esri 技术支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Overrides { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Solve SetEnviroment(object workspace = null)
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
