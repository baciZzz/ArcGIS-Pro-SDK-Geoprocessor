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
	/// <para>Set Network Attribute</para>
	/// <para>设置网络属性</para>
	/// <para>用于将网络属性分配到要在追踪操作中使用的资产类型级别要素类或表。</para>
	/// </summary>
	public class SetNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含要设置的网络属性的公共设施网络。</para>
		/// </param>
		/// <param name="NetworkAttribute">
		/// <para>Network Attribute</para>
		/// <para>要分配给要素类或表字段的网络属性。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>包含将在其上设置网络属性的要素类或表的域网络。</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Input Table</para>
		/// <para>输入要素类或表，其中包括将用于设置网络属性的字段。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>将分配网络属性的现有字段。字段数据类型必须与网络属性的数据类型相匹配。例如，如果网络属性是短整型，则字段必须也是短整型。仅可以将不支持空值的网络属性分配给不允许空值的字段。</para>
		/// </param>
		public SetNetworkAttribute(object InUtilityNetwork, object NetworkAttribute, object DomainNetwork, object Featureclass, object Field)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.NetworkAttribute = NetworkAttribute;
			this.DomainNetwork = DomainNetwork;
			this.Featureclass = Featureclass;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置网络属性</para>
		/// </summary>
		public override string DisplayName() => "设置网络属性";

		/// <summary>
		/// <para>Tool Name : SetNetworkAttribute</para>
		/// </summary>
		public override string ToolName() => "SetNetworkAttribute";

		/// <summary>
		/// <para>Tool Excute Name : un.SetNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName() => "un.SetNetworkAttribute";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, NetworkAttribute, DomainNetwork, Featureclass, Field, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含要设置的网络属性的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Attribute</para>
		/// <para>要分配给要素类或表字段的网络属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkAttribute { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>包含将在其上设置网络属性的要素类或表的域网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入要素类或表，其中包括将用于设置网络属性的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>将分配网络属性的现有字段。字段数据类型必须与网络属性的数据类型相匹配。例如，如果网络属性是短整型，则字段必须也是短整型。仅可以将不支持空值的网络属性分配给不允许空值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetNetworkAttribute SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
