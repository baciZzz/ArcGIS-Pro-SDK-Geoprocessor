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
	/// <para>Create Trace Network</para>
	/// <para>创建追踪网络</para>
	/// <para>创建追踪网络。</para>
	/// </summary>
	public class CreateTraceNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>将包含追踪网络的要素数据集。</para>
		/// </param>
		/// <param name="InTraceNetworkName">
		/// <para>Trace Network Name</para>
		/// <para>将创建的追踪网络的名称。</para>
		/// </param>
		public CreateTraceNetwork(object InFeatureDataset, object InTraceNetworkName)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.InTraceNetworkName = InTraceNetworkName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建追踪网络</para>
		/// </summary>
		public override string DisplayName() => "创建追踪网络";

		/// <summary>
		/// <para>Tool Name : CreateTraceNetwork</para>
		/// </summary>
		public override string ToolName() => "CreateTraceNetwork";

		/// <summary>
		/// <para>Tool Excute Name : tn.CreateTraceNetwork</para>
		/// </summary>
		public override string ExcuteName() => "tn.CreateTraceNetwork";

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
		public override object[] Parameters() => new object[] { InFeatureDataset, InTraceNetworkName, InputJunctions, InputEdges, OutTraceNetwork };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>将包含追踪网络的要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		[GPDatasetDomain()]
		[DataSetType("FeatureDataset")]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Trace Network Name</para>
		/// <para>将创建的追踪网络的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InTraceNetworkName { get; set; }

		/// <summary>
		/// <para>Input Junctions</para>
		/// <para>要素数据集中要包含在追踪网络中的点要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InputJunctions { get; set; }

		/// <summary>
		/// <para>Input Edges</para>
		/// <para>要包含在追踪网络中的线要素类和关联的连通性策略。</para>
		/// <para>类名称 - 要素数据集中要包含在追踪网络中的线要素类的名称。</para>
		/// <para>连通性策略 - 指定要素类的关联连通性策略。</para>
		/// <para>简单边 - 资源将从边的一端流入，从另一端流出。</para>
		/// <para>复杂边 - 将沿边的长度方向抽取资源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InputEdges { get; set; }

		/// <summary>
		/// <para>Output Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object OutTraceNetwork { get; set; }

	}
}
