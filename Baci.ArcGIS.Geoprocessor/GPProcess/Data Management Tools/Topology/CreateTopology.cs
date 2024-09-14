using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Create Topology</para>
	/// <para>创建拓扑</para>
	/// <para>创建拓扑。拓扑将不包含任何要素类或规则。</para>
	/// </summary>
	public class CreateTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>将创建拓扑的要素数据集。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Topology</para>
		/// <para>要创建的拓扑的名称。该名称在整个地理数据库中必须唯一。</para>
		/// </param>
		public CreateTopology(object InDataset, object OutName)
		{
			this.InDataset = InDataset;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建拓扑</para>
		/// </summary>
		public override string DisplayName() => "创建拓扑";

		/// <summary>
		/// <para>Tool Name : CreateTopology</para>
		/// </summary>
		public override string ToolName() => "CreateTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateTopology</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutName, InClusterTolerance!, OutTopology! };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>将创建拓扑的要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Topology</para>
		/// <para>要创建的拓扑的名称。该名称在整个地理数据库中必须唯一。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Cluster Tolerance</para>
		/// <para>将对拓扑设置拓扑容差。该值越大，折点聚集在一起的几率就越大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? InClusterTolerance { get; set; }

		/// <summary>
		/// <para>Output Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETopology()]
		public object? OutTopology { get; set; }

	}
}
