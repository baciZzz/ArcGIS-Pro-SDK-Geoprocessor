using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Import Topology</para>
	/// <para>Creates a geodatabase topology from a definition .xml file generated by the Export Topology tool in the Topographic Production toolbox.</para>
	/// </summary>
	public class ImportTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset in which the topology will be created. The feature dataset must contain the feature classes listed in the Input Topology Definition File.</para>
		/// </param>
		/// <param name="TopologyDefinitionFile">
		/// <para>Input Topology Definition File</para>
		/// <para>The .xml file that contains the topology definition.</para>
		/// </param>
		public ImportTopology(object InFeatureDataset, object TopologyDefinitionFile)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.TopologyDefinitionFile = TopologyDefinitionFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Topology</para>
		/// </summary>
		public override string DisplayName => "Import Topology";

		/// <summary>
		/// <para>Tool Name : ImportTopology</para>
		/// </summary>
		public override string ToolName => "ImportTopology";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ImportTopology</para>
		/// </summary>
		public override string ExcuteName => "topographic.ImportTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureDataset, TopologyDefinitionFile, OutTopology };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset in which the topology will be created. The feature dataset must contain the feature classes listed in the Input Topology Definition File.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Input Topology Definition File</para>
		/// <para>The .xml file that contains the topology definition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object TopologyDefinitionFile { get; set; }

		/// <summary>
		/// <para>Output Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETopology()]
		public object OutTopology { get; set; }

	}
}
