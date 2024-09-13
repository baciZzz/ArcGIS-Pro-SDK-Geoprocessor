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
	/// <para>导入追踪配置</para>
	/// <para>将 JSON 格式文件（.json 文件）中的指定追踪配置导入追踪网络。</para>
	/// </summary>
	public class ImportTraceConfigurations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>将导入指定追踪配置的目标追踪网络。</para>
		/// </param>
		/// <param name="InJsonFile">
		/// <para>Input  File (.json)</para>
		/// <para>包含要导入的指定追踪配置的 .json 文件。</para>
		/// </param>
		public ImportTraceConfigurations(object InTraceNetwork, object InJsonFile)
		{
			this.InTraceNetwork = InTraceNetwork;
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
		/// <para>Tool Excute Name : tn.ImportTraceConfigurations</para>
		/// </summary>
		public override string ExcuteName() => "tn.ImportTraceConfigurations";

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
		public override object[] Parameters() => new object[] { InTraceNetwork, InJsonFile, OutTraceNetwork };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>将导入指定追踪配置的目标追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

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
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object OutTraceNetwork { get; set; }

	}
}
