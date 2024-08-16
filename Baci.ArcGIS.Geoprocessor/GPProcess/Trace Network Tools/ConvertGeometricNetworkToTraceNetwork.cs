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
	/// <para>Converts a geometric network to a trace network.</para>
	/// </summary>
	public class ConvertGeometricNetworkToTraceNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeometricNetwork">
		/// <para>Input Geometric Network</para>
		/// <para>The geometric network that will be converted to a trace network.</para>
		/// <para>Converting a geometric network to a trace network will drop the geometric network and create a trace network in its place. This change cannot be undone. Make a backup of your data before proceeding.</para>
		/// </param>
		/// <param name="OutTraceNetworkName">
		/// <para>Output Trace Network Name</para>
		/// <para>The name of the output trace network.</para>
		/// </param>
		public ConvertGeometricNetworkToTraceNetwork(object InGeometricNetwork, object OutTraceNetworkName)
		{
			this.InGeometricNetwork = InGeometricNetwork;
			this.OutTraceNetworkName = OutTraceNetworkName;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Geometric Network To Trace Network</para>
		/// </summary>
		public override string DisplayName => "Convert Geometric Network To Trace Network";

		/// <summary>
		/// <para>Tool Name : ConvertGeometricNetworkToTraceNetwork</para>
		/// </summary>
		public override string ToolName => "ConvertGeometricNetworkToTraceNetwork";

		/// <summary>
		/// <para>Tool Excute Name : tn.ConvertGeometricNetworkToTraceNetwork</para>
		/// </summary>
		public override string ExcuteName => "tn.ConvertGeometricNetworkToTraceNetwork";

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
		public override object[] Parameters => new object[] { InGeometricNetwork, OutTraceNetworkName, OutTraceNetwork };

		/// <summary>
		/// <para>Input Geometric Network</para>
		/// <para>The geometric network that will be converted to a trace network.</para>
		/// <para>Converting a geometric network to a trace network will drop the geometric network and create a trace network in its place. This change cannot be undone. Make a backup of your data before proceeding.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEGeometricNetwork()]
		[GPDatasetDomain()]
		[DataSetType("GeometricNetwork")]
		public object InGeometricNetwork { get; set; }

		/// <summary>
		/// <para>Output Trace Network Name</para>
		/// <para>The name of the output trace network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutTraceNetworkName { get; set; }

		/// <summary>
		/// <para>Output Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object OutTraceNetwork { get; set; }

	}
}
