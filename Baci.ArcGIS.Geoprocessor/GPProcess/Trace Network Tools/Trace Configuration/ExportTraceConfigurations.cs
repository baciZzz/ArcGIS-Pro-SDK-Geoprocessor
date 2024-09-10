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
	/// <para>Export Trace Configurations</para>
	/// <para>Exports named trace configurations from a trace network to JSON format (.json file).</para>
	/// </summary>
	public class ExportTraceConfigurations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The trace network containing the named trace configuration or configurations to export.</para>
		/// </param>
		/// <param name="TraceConfigName">
		/// <para>Trace Configuration</para>
		/// <para>The named trace configuration or configurations to export.</para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output  File (.json)</para>
		/// <para>The output .json file.</para>
		/// </param>
		public ExportTraceConfigurations(object InTraceNetwork, object TraceConfigName, object OutJsonFile)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.TraceConfigName = TraceConfigName;
			this.OutJsonFile = OutJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Trace Configurations</para>
		/// </summary>
		public override string DisplayName() => "Export Trace Configurations";

		/// <summary>
		/// <para>Tool Name : ExportTraceConfigurations</para>
		/// </summary>
		public override string ToolName() => "ExportTraceConfigurations";

		/// <summary>
		/// <para>Tool Excute Name : tn.ExportTraceConfigurations</para>
		/// </summary>
		public override string ExcuteName() => "tn.ExportTraceConfigurations";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, TraceConfigName, OutJsonFile };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The trace network containing the named trace configuration or configurations to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Trace Configuration</para>
		/// <para>The named trace configuration or configurations to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object TraceConfigName { get; set; }

		/// <summary>
		/// <para>Output  File (.json)</para>
		/// <para>The output .json file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("JSON")]
		public object OutJsonFile { get; set; }

	}
}
