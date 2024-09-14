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
	/// <para>Convert Geometric Network To Trace Network</para>
	/// <para>将几何网络转换为追踪网络</para>
	/// <para>将几何网络转换为追踪网络。</para>
	/// </summary>
	public class ConvertGeometricNetworkToTraceNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeometricNetwork">
		/// <para>Input Geometric Network</para>
		/// <para>将转换为追踪网络的几何网络。</para>
		/// <para>将几何网络转换为追踪网络将删除几何网络并就地创建追踪网络。 无法撤消此更改。 请先创建数据的备份，然后再继续操作。</para>
		/// </param>
		/// <param name="OutTraceNetworkName">
		/// <para>Output Trace Network Name</para>
		/// <para>输出追踪网络的名称。</para>
		/// </param>
		public ConvertGeometricNetworkToTraceNetwork(object InGeometricNetwork, object OutTraceNetworkName)
		{
			this.InGeometricNetwork = InGeometricNetwork;
			this.OutTraceNetworkName = OutTraceNetworkName;
		}

		/// <summary>
		/// <para>Tool Display Name : 将几何网络转换为追踪网络</para>
		/// </summary>
		public override string DisplayName() => "将几何网络转换为追踪网络";

		/// <summary>
		/// <para>Tool Name : ConvertGeometricNetworkToTraceNetwork</para>
		/// </summary>
		public override string ToolName() => "ConvertGeometricNetworkToTraceNetwork";

		/// <summary>
		/// <para>Tool Excute Name : tn.ConvertGeometricNetworkToTraceNetwork</para>
		/// </summary>
		public override string ExcuteName() => "tn.ConvertGeometricNetworkToTraceNetwork";

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
		public override object[] Parameters() => new object[] { InGeometricNetwork, OutTraceNetworkName, OutTraceNetwork! };

		/// <summary>
		/// <para>Input Geometric Network</para>
		/// <para>将转换为追踪网络的几何网络。</para>
		/// <para>将几何网络转换为追踪网络将删除几何网络并就地创建追踪网络。 无法撤消此更改。 请先创建数据的备份，然后再继续操作。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEGeometricNetwork()]
		[GPDatasetDomain()]
		[DataSetType("GeometricNetwork")]
		public object InGeometricNetwork { get; set; }

		/// <summary>
		/// <para>Output Trace Network Name</para>
		/// <para>输出追踪网络的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutTraceNetworkName { get; set; }

		/// <summary>
		/// <para>Output Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? OutTraceNetwork { get; set; }

	}
}
