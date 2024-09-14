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
	/// <para>Delete Trace Configuration</para>
	/// <para>删除追踪配置</para>
	/// <para>用于从公共设施网络中删除一个或多个指定追踪配置。</para>
	/// </summary>
	public class DeleteTraceConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含要删除的指定追踪配置的公共设施网络。</para>
		/// </param>
		/// <param name="TraceConfigName">
		/// <para>Trace Configuration</para>
		/// <para>要删除的指定追踪配置。</para>
		/// </param>
		public DeleteTraceConfiguration(object InUtilityNetwork, object TraceConfigName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TraceConfigName = TraceConfigName;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除追踪配置</para>
		/// </summary>
		public override string DisplayName() => "删除追踪配置";

		/// <summary>
		/// <para>Tool Name : DeleteTraceConfiguration</para>
		/// </summary>
		public override string ToolName() => "DeleteTraceConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : un.DeleteTraceConfiguration</para>
		/// </summary>
		public override string ExcuteName() => "un.DeleteTraceConfiguration";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TraceConfigName, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含要删除的指定追踪配置的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Trace Configuration</para>
		/// <para>要删除的指定追踪配置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object TraceConfigName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

	}
}
