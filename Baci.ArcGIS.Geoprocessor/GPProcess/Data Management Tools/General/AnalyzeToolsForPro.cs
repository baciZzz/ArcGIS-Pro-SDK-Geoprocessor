using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Analyze Tools For Pro</para>
	/// <para>针对 Pro 分析工具</para>
	/// <para>为 ArcGIS Pro 中不支持的功能分析 Python 脚本、自定义地理处理工具和工具箱。</para>
	/// </summary>
	public class AnalyzeToolsForPro : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Input</para>
		/// <para>输入可以是地理处理工具箱或 Python 文件。</para>
		/// </param>
		public AnalyzeToolsForPro(object Input)
		{
			this.Input = Input;
		}

		/// <summary>
		/// <para>Tool Display Name : 针对 Pro 分析工具</para>
		/// </summary>
		public override string DisplayName() => "针对 Pro 分析工具";

		/// <summary>
		/// <para>Tool Name : AnalyzeToolsForPro</para>
		/// </summary>
		public override string ToolName() => "AnalyzeToolsForPro";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeToolsForPro</para>
		/// </summary>
		public override string ExcuteName() => "management.AnalyzeToolsForPro";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, Report };

		/// <summary>
		/// <para>Input</para>
		/// <para>输入可以是地理处理工具箱或 Python 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>包含所有问题的输出文本文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object Report { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeToolsForPro SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
