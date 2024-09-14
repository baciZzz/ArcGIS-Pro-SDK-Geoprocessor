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
	/// <para>导出子网控制器</para>
	/// <para>将公共设施网络中的子网控制器导出为 .csv 文件。</para>
	/// </summary>
	public class ExportSubnetworkControllers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将从中导出子网控制器的公共设施网络。</para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output File</para>
		/// <para>要生成的 .csv 文件的位置和名称。</para>
		/// </param>
		public ExportSubnetworkControllers(object InUtilityNetwork, object OutCsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出子网控制器</para>
		/// </summary>
		public override string DisplayName() => "导出子网控制器";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutCsvFile };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将从中导出子网控制器的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>要生成的 .csv 文件的位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

	}
}
