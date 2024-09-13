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
	/// <para>导入追踪配置</para>
	/// <para>将 JSON 格式文件（.json 文件）中的指定追踪配置导入公共设施网络。</para>
	/// </summary>
	public class ImportTraceConfigurations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将导入指定追踪配置的公共设施网络。</para>
		/// </param>
		/// <param name="InJsonFile">
		/// <para>Input  File (.json)</para>
		/// <para>包含要导入的指定追踪配置的 .json 文件。</para>
		/// </param>
		public ImportTraceConfigurations(object InUtilityNetwork, object InJsonFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.InJsonFile = InJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入追踪配置</para>
		/// </summary>
		public override string DisplayName() => "导入追踪配置";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, InJsonFile, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将导入指定追踪配置的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input  File (.json)</para>
		/// <para>包含要导入的指定追踪配置的 .json 文件。</para>
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
		public object? OutUtilityNetwork { get; set; }

	}
}
