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
	/// <para>Analyze Toolbox For Version</para>
	/// <para>分析工具箱的版本</para>
	/// <para>分析工具箱的内容并识别与 ArcGIS 软件先前版本的兼容性问题。</para>
	/// </summary>
	public class AnalyzeToolboxForVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InToolbox">
		/// <para>Input</para>
		/// <para>将要分析的输入工具箱（.tbx 或 .atbx）。</para>
		/// <para>不支持将 Python 工具箱 (.pyt) 格式作为输入。</para>
		/// </param>
		/// <param name="Version">
		/// <para>Target  Version</para>
		/// <para>指定将用于工具箱兼容性分析的软件版本。</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 将用于工具箱兼容性问题分析。</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 将用于工具箱兼容性问题分析。</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 将用于工具箱兼容性问题分析。</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 将用于工具箱兼容性问题分析。</para>
		/// <para>2.2—ArcGIS Pro 2.2 将用于工具箱兼容性问题分析。</para>
		/// <para>2.3—ArcGIS Pro 2.3 将用于工具箱兼容性问题分析。</para>
		/// <para>2.4—ArcGIS Pro 2.4 将用于工具箱兼容性问题分析。</para>
		/// <para>2.5—ArcGIS Pro 2.5 将用于工具箱兼容性问题分析。</para>
		/// <para>2.6—ArcGIS Pro 2.6 将用于工具箱兼容性问题分析。</para>
		/// <para>2.7—ArcGIS Pro 2.7 将用于工具箱兼容性问题分析。</para>
		/// <para>2.8—ArcGIS Pro 2.8 将用于工具箱兼容性问题分析。</para>
		/// <para>2.9—ArcGIS Pro 2.9 将用于工具箱兼容性问题分析。</para>
		/// </param>
		public AnalyzeToolboxForVersion(object InToolbox, object Version)
		{
			this.InToolbox = InToolbox;
			this.Version = Version;
		}

		/// <summary>
		/// <para>Tool Display Name : 分析工具箱的版本</para>
		/// </summary>
		public override string DisplayName() => "分析工具箱的版本";

		/// <summary>
		/// <para>Tool Name : AnalyzeToolboxForVersion</para>
		/// </summary>
		public override string ToolName() => "AnalyzeToolboxForVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeToolboxForVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.AnalyzeToolboxForVersion";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InToolbox, Version, Report! };

		/// <summary>
		/// <para>Input</para>
		/// <para>将要分析的输入工具箱（.tbx 或 .atbx）。</para>
		/// <para>不支持将 Python 工具箱 (.pyt) 格式作为输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEToolbox()]
		public object InToolbox { get; set; }

		/// <summary>
		/// <para>Target  Version</para>
		/// <para>指定将用于工具箱兼容性分析的软件版本。</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 将用于工具箱兼容性问题分析。</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 将用于工具箱兼容性问题分析。</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 将用于工具箱兼容性问题分析。</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 将用于工具箱兼容性问题分析。</para>
		/// <para>2.2—ArcGIS Pro 2.2 将用于工具箱兼容性问题分析。</para>
		/// <para>2.3—ArcGIS Pro 2.3 将用于工具箱兼容性问题分析。</para>
		/// <para>2.4—ArcGIS Pro 2.4 将用于工具箱兼容性问题分析。</para>
		/// <para>2.5—ArcGIS Pro 2.5 将用于工具箱兼容性问题分析。</para>
		/// <para>2.6—ArcGIS Pro 2.6 将用于工具箱兼容性问题分析。</para>
		/// <para>2.7—ArcGIS Pro 2.7 将用于工具箱兼容性问题分析。</para>
		/// <para>2.8—ArcGIS Pro 2.8 将用于工具箱兼容性问题分析。</para>
		/// <para>2.9—ArcGIS Pro 2.9 将用于工具箱兼容性问题分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>将创建的文本文件，其中包含分析程序识别的兼容性问题。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? Report { get; set; }

	}
}
