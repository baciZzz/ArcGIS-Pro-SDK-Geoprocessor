using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Import Trace Configurations</para>
	/// <para>Imports named trace configurations from JSON format (.json file) to a utility network.</para>
	/// </summary>
	public class ImportTraceConfigurations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network to which the named trace configurations will be imported.</para>
		/// </param>
		/// <param name="InJsonFile">
		/// <para>Input  File (.json)</para>
		/// <para>The .json file containing the named trace configurations to import.</para>
		/// </param>
		public ImportTraceConfigurations(object InUtilityNetwork, object InJsonFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.InJsonFile = InJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Trace Configurations</para>
		/// </summary>
		public override string DisplayName() => "Import Trace Configurations";

		/// <summary>
		/// <para>Tool Name : ImportTraceConfigurations</para>
		/// </summary>
		public override string ToolName() => "ImportTraceConfigurations";

		/// <summary>
		/// <para>Tool Excute Name : un.ImportTraceConfigurations</para>
		/// </summary>
		public override string ExcuteName() => "un.ImportTraceConfigurations";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, InJsonFile, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network to which the named trace configurations will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input  File (.json)</para>
		/// <para>The .json file containing the named trace configurations to import.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("JSON")]
		public object InJsonFile { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
