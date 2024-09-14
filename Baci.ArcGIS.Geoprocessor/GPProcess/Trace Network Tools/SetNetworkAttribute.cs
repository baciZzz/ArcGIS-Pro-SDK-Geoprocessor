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
	/// <para>Set Network Attribute</para>
	/// <para>设置网络属性</para>
	/// <para>将网络属性分配到要在追踪操作期间使用的要素类。</para>
	/// </summary>
	public class SetNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>包含要设置的网络属性的追踪网络。</para>
		/// </param>
		/// <param name="NetworkAttribute">
		/// <para>Network Attribute</para>
		/// <para>要分配到要素类字段的网络属性。</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Feature Class</para>
		/// <para>包括将用于设置网络属性的字段的输入要素类。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>将分配网络属性的现有字段。字段数据类型必须与网络属性的数据类型相匹配。例如，如果网络属性是短整型，则字段必须也是短整型。只能将不支持空值的网络属性分配给不允许空值的字段。</para>
		/// </param>
		public SetNetworkAttribute(object InTraceNetwork, object NetworkAttribute, object Featureclass, object Field)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.NetworkAttribute = NetworkAttribute;
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
		/// <para>Tool Excute Name : tn.SetNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName() => "tn.SetNetworkAttribute";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, NetworkAttribute, Featureclass, Field, OutTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>包含要设置的网络属性的追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Network Attribute</para>
		/// <para>要分配到要素类字段的网络属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkAttribute { get; set; }

		/// <summary>
		/// <para>Feature Class</para>
		/// <para>包括将用于设置网络属性的字段的输入要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>将分配网络属性的现有字段。字段数据类型必须与网络属性的数据类型相匹配。例如，如果网络属性是短整型，则字段必须也是短整型。只能将不支持空值的网络属性分配给不允许空值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? OutTraceNetwork { get; set; }

	}
}
