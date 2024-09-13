using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Enable Network Topology</para>
	/// <para>启用网络拓扑</para>
	/// <para>用于启用追踪网络的网络拓扑。</para>
	/// </summary>
	public class EnableNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>将启用网络拓扑的追踪网络。</para>
		/// </param>
		public EnableNetworkTopology(object InTraceNetwork)
		{
			this.InTraceNetwork = InTraceNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用网络拓扑</para>
		/// </summary>
		public override string DisplayName() => "启用网络拓扑";

		/// <summary>
		/// <para>Tool Name : EnableNetworkTopology</para>
		/// </summary>
		public override string ToolName() => "EnableNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : tn.EnableNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "tn.EnableNetworkTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, MaxNumberOfErrors!, OnlyGenerateErrors!, OutTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>将启用网络拓扑的追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Maximum number of errors</para>
		/// <para>在启用网络拓扑的过程停止之前，可以发生的最大错误数。错误将记录在错误表中。默认值为 10000。</para>
		/// <para>提高最大错误数值的同时将增加启用拓扑所需的时间长度。我们不建议您设置高于默认值 10000 的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object? MaxNumberOfErrors { get; set; } = "10000";

		/// <summary>
		/// <para>Only generate errors</para>
		/// <para>指定启用拓扑还是仅生成网络错误。</para>
		/// <para>选中 - 仅评估追踪网络的网络错误，不会启用拓扑。允许您在启用拓扑之前，检查并修复网络中的错误。如果要使用企业级地理数据库，则无法将数据注册为版本。在启用拓扑之前，用于检查并修复网络中的错误。</para>
		/// <para>未选中 - 将启用拓扑，且存在的任何错误都将生成错误要素。这是默认设置。</para>
		/// <para><see cref="OnlyGenerateErrorsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? OnlyGenerateErrors { get; set; } = "false";

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? OutTraceNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Only generate errors</para>
		/// </summary>
		public enum OnlyGenerateErrorsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_ERRORS")]
			ONLY_ERRORS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ENABLE_TOPO")]
			ENABLE_TOPO,

		}

#endregion
	}
}
