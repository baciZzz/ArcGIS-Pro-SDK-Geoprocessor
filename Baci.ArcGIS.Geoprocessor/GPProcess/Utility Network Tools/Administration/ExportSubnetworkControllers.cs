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
	/// <para>Export Subnetwork Controllers</para>
	/// <para>Exports subnetwork controllers from a utility network to a .csv file.</para>
	/// </summary>
	public class ExportSubnetworkControllers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network from which subnetwork controllers will be exported.</para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output File</para>
		/// <para>The location and name of the .csv file to be generated.</para>
		/// </param>
		public ExportSubnetworkControllers(object InUtilityNetwork, object OutCsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Subnetwork Controllers</para>
		/// </summary>
		public override string DisplayName() => "Export Subnetwork Controllers";

		/// <summary>
		/// <para>Tool Name : ExportSubnetworkControllers</para>
		/// </summary>
		public override string ToolName() => "ExportSubnetworkControllers";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportSubnetworkControllers</para>
		/// </summary>
		public override string ExcuteName() => "un.ExportSubnetworkControllers";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutCsvFile };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network from which subnetwork controllers will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The location and name of the .csv file to be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

	}
}
