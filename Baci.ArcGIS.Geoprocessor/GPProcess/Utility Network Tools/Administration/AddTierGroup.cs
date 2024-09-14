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
	/// <para>Add Tier Group</para>
	/// <para>添加层组</para>
	/// <para>向公共设施网络内的域网络添加层组。</para>
	/// </summary>
	public class AddTierGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含域网络的公共设施网络，将向该域网络中添加层组。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>要添加层组的域网络名称。只能将层组添加到具有等级层定义的域网络。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Tier Group Name</para>
		/// <para>新层组的唯一名称。名称最长为 64 个字符。</para>
		/// </param>
		public AddTierGroup(object InUtilityNetwork, object DomainNetwork, object Name)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加层组</para>
		/// </summary>
		public override string DisplayName() => "添加层组";

		/// <summary>
		/// <para>Tool Name : AddTierGroup</para>
		/// </summary>
		public override string ToolName() => "AddTierGroup";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTierGroup</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTierGroup";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Name, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含域网络的公共设施网络，将向该域网络中添加层组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>要添加层组的域网络名称。只能将层组添加到具有等级层定义的域网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier Group Name</para>
		/// <para>新层组的唯一名称。名称最长为 64 个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
