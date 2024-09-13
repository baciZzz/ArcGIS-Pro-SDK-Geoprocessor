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
	/// <para>Update Is Connected</para>
	/// <para>更新已连接</para>
	/// <para>可基于连通性更新指定公共设施网络中所有网络要素的 IsConnected 属性。</para>
	/// </summary>
	public class UpdateIsConnected : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Utility Network</para>
		/// <para>将更新 IsConnected 属性的公共设施网络。</para>
		/// </param>
		public UpdateIsConnected(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新已连接</para>
		/// </summary>
		public override string DisplayName() => "更新已连接";

		/// <summary>
		/// <para>Tool Name : UpdateIsConnected</para>
		/// </summary>
		public override string ToolName() => "UpdateIsConnected";

		/// <summary>
		/// <para>Tool Excute Name : un.UpdateIsConnected</para>
		/// </summary>
		public override string ExcuteName() => "un.UpdateIsConnected";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutUtilityNetwork };

		/// <summary>
		/// <para>Utility Network</para>
		/// <para>将更新 IsConnected 属性的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
