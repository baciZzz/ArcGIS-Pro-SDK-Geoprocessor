using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Enable Network Topology</para>
	/// <para>启用网络拓扑</para>
	/// <para>启用公共设施网络的网络拓扑。</para>
	/// </summary>
	public class EnableNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将启用网络拓扑的公共设施网络。</para>
		/// </param>
		public EnableNetworkTopology(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
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
		/// <para>Tool Excute Name : un.EnableNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "un.EnableNetworkTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, MaxNumberOfErrors, OnlyGenerateErrors, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将启用网络拓扑的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Maximum number of errors</para>
		/// <para>在启用网络拓扑过程停止且错误被记录在错误表中之前显示的最大错误数。默认值为 10000。</para>
		/// <para>提高最大错误数值的同时将增加启用拓扑所需的时间长度。我们不建议您设置高于默认值 10000 的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object MaxNumberOfErrors { get; set; } = "10000";

		/// <summary>
		/// <para>Only generate errors</para>
		/// <para>指定启用拓扑还是仅生成网络错误。</para>
		/// <para>选中 - 将针对网络错误评估公共设施网络。将不会启用拓扑。如果要使用企业级地理数据库，则无法将数据注册为版本。可在您准备启用拓扑前，用于检查并修复网络中的错误。</para>
		/// <para>未选中 - 将启用拓扑，且存在的任何错误都将生成包含错误的脏区。这是默认设置。</para>
		/// <para><see cref="OnlyGenerateErrorsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object OnlyGenerateErrors { get; set; } = "false";

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

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
