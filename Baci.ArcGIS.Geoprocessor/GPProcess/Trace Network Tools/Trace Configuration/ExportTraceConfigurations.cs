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
	/// <para>导出追踪配置</para>
	/// <para>将追踪网络中的指定追踪配置导出为 JSON 格式（.json 文件）。</para>
	/// </summary>
	public class ExportTraceConfigurations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>包含要导出的指定追踪配置的追踪网络。</para>
		/// </param>
		/// <param name="TraceConfigName">
		/// <para>Trace Configuration</para>
		/// <para>要导出的指定追踪配置。</para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output  File (.json)</para>
		/// <para>输出 .json 文件。</para>
		/// </param>
		public ExportTraceConfigurations(object InTraceNetwork, object TraceConfigName, object OutJsonFile)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.TraceConfigName = TraceConfigName;
			this.OutJsonFile = OutJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出追踪配置</para>
		/// </summary>
		public override string DisplayName() => "导出追踪配置";

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
		/// <para>包含要导出的指定追踪配置的追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Trace Configuration</para>
		/// <para>要导出的指定追踪配置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object TraceConfigName { get; set; }

		/// <summary>
		/// <para>Output  File (.json)</para>
		/// <para>输出 .json 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("JSON")]
		public object OutJsonFile { get; set; }

	}
}
