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
	/// <para>Creates a topology. The topology will not contain any feature classes or rules.</para>
	/// </summary>
	public class CreateTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset in which the topology will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Topology</para>
		/// <para>The name of the topology to be created. This name must be unique across the entire geodatabase.</para>
		/// </param>
		public CreateTopology(object InDataset, object OutName)
		{
			this.InDataset = InDataset;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Topology</para>
		/// </summary>
		public override string DisplayName => "Create Topology";

		/// <summary>
		/// <para>Tool Name : CreateTopology</para>
		/// </summary>
		public override string ToolName => "CreateTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateTopology</para>
		/// </summary>
		public override string ExcuteName => "management.CreateTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutName, InClusterTolerance!, OutTopology! };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset in which the topology will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Topology</para>
		/// <para>The name of the topology to be created. This name must be unique across the entire geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Cluster Tolerance</para>
		/// <para>The cluster tolerance to be set on the topology. The larger the value, the more likely vertices will be to cluster together.</para>
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
