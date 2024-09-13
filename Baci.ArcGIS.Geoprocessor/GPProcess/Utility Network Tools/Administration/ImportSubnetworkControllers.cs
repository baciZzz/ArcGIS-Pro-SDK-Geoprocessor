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
	/// <para>Import Subnetwork Controllers</para>
	/// <para>导入子网控制器</para>
	/// <para>用于将 .csv 文件中的子网控制器导入到公共设施网络。</para>
	/// </summary>
	public class ImportSubnetworkControllers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将导入子网控制器的公共设施网络。</para>
		/// </param>
		/// <param name="CsvFile">
		/// <para>Input File</para>
		/// <para>包含要导入的子网控制器的 .csv 文件。</para>
		/// </param>
		public ImportSubnetworkControllers(object InUtilityNetwork, object CsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.CsvFile = CsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入子网控制器</para>
		/// </summary>
		public override string DisplayName() => "导入子网控制器";

		/// <summary>
		/// <para>Tool Name : ImportSubnetworkControllers</para>
		/// </summary>
		public override string ToolName() => "ImportSubnetworkControllers";

		/// <summary>
		/// <para>Tool Excute Name : un.ImportSubnetworkControllers</para>
		/// </summary>
		public override string ExcuteName() => "un.ImportSubnetworkControllers";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, CsvFile, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将导入子网控制器的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input File</para>
		/// <para>包含要导入的子网控制器的 .csv 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object CsvFile { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportSubnetworkControllers SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
