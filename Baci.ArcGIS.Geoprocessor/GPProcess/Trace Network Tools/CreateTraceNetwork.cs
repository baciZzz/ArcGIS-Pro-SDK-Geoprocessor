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
	/// <para>Creates a trace network.</para>
	/// </summary>
	public class CreateTraceNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset that will contain the trace network.</para>
		/// </param>
		/// <param name="InTraceNetworkName">
		/// <para>Trace Network Name</para>
		/// <para>The name of the trace network that will be created.</para>
		/// </param>
		public CreateTraceNetwork(object InFeatureDataset, object InTraceNetworkName)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.InTraceNetworkName = InTraceNetworkName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Trace Network</para>
		/// </summary>
		public override string DisplayName => "Create Trace Network";

		/// <summary>
		/// <para>Tool Name : CreateTraceNetwork</para>
		/// </summary>
		public override string ToolName => "CreateTraceNetwork";

		/// <summary>
		/// <para>Tool Excute Name : tn.CreateTraceNetwork</para>
		/// </summary>
		public override string ExcuteName => "tn.CreateTraceNetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureDataset, InTraceNetworkName, InputJunctions, InputEdges, OutTraceNetwork };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset that will contain the trace network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		[GPDatasetDomain()]
		[DataSetType("FeatureDataset")]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Trace Network Name</para>
		/// <para>The name of the trace network that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InTraceNetworkName { get; set; }

		/// <summary>
		/// <para>Input Junctions</para>
		/// <para>The names of the point feature classes in the feature dataset to include in the trace network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InputJunctions { get; set; }

		/// <summary>
		/// <para>Input Edges</para>
		/// <para>The line feature classes and associated connectivity policy to include in the trace network.</para>
		/// <para>Class Name—The name of the line feature class in the feature dataset to include in the trace network.</para>
		/// <para>Connectivity Policy—The associated connectivity policy of the specified feature class.</para>
		/// <para>Simple edge—Resources will flow from one end of the edge and out the other end.</para>
		/// <para>Complex edge—Resources will be siphoned off along the length of the edge.</para>
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
