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
	/// <para>Export Topology</para>
	/// <para>Exports a topology from a geodatabase to an .xml file.</para>
	/// </summary>
	public class ExportTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Topology">
		/// <para>Input Topology</para>
		/// <para>An existing topology in a geodatabase. All feature classes that participate in this topology will be listed in the output .xml file.</para>
		/// </param>
		/// <param name="Location">
		/// <para>Topology XML Document Location</para>
		/// <para>The folder in which the .xml file will be written.</para>
		/// </param>
		/// <param name="FileName">
		/// <para>Topology XML Document Name</para>
		/// <para>The name of the topology .xml file that will be created by the tool.</para>
		/// </param>
		public ExportTopology(object Topology, object Location, object FileName)
		{
			this.Topology = Topology;
			this.Location = Location;
			this.FileName = FileName;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Topology</para>
		/// </summary>
		public override string DisplayName => "Export Topology";

		/// <summary>
		/// <para>Tool Name : ExportTopology</para>
		/// </summary>
		public override string ToolName => "ExportTopology";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ExportTopology</para>
		/// </summary>
		public override string ExcuteName => "topographic.ExportTopology";

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
		public override object[] Parameters => new object[] { Topology, Location, FileName, OutFile! };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>An existing topology in a geodatabase. All feature classes that participate in this topology will be listed in the output .xml file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Topology { get; set; }

		/// <summary>
		/// <para>Topology XML Document Location</para>
		/// <para>The folder in which the .xml file will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object Location { get; set; }

		/// <summary>
		/// <para>Topology XML Document Name</para>
		/// <para>The name of the topology .xml file that will be created by the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FileName { get; set; }

		/// <summary>
		/// <para>Output Topology XML Document</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutFile { get; set; }

	}
}
