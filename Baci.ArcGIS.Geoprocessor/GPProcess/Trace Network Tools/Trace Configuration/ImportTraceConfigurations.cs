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
	/// <para>Import Trace Configurations</para>
	/// <para>Imports named trace configurations from JSON format (.json file) to a trace network.</para>
	/// </summary>
	public class ImportTraceConfigurations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The target trace network to which the named trace configurations will be imported.</para>
		/// </param>
		/// <param name="InJsonFile">
		/// <para>Input  File (.json)</para>
		/// <para>The .json file containing the named trace configurations to import.</para>
		/// </param>
		public ImportTraceConfigurations(object InTraceNetwork, object InJsonFile)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.InJsonFile = InJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Trace Configurations</para>
		/// </summary>
		public override string DisplayName => "Import Trace Configurations";

		/// <summary>
		/// <para>Tool Name : ImportTraceConfigurations</para>
		/// </summary>
		public override string ToolName => "ImportTraceConfigurations";

		/// <summary>
		/// <para>Tool Excute Name : tn.ImportTraceConfigurations</para>
		/// </summary>
		public override string ExcuteName => "tn.ImportTraceConfigurations";

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
		public override object[] Parameters => new object[] { InTraceNetwork, InJsonFile, OutTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The target trace network to which the named trace configurations will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Input  File (.json)</para>
		/// <para>The .json file containing the named trace configurations to import.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InJsonFile { get; set; }

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? OutTraceNetwork { get; set; }

	}
}
