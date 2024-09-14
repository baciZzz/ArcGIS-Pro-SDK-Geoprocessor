using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Frequency</para>
	/// <para>频数</para>
	/// <para>读取表和一组字段，并创建一个包含唯一字段值以及各唯一字段值所出现次数的新表。</para>
	/// </summary>
	public class Frequency : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>表中包含将用于计算频数统计值的字段。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>输出表用于存储频数统计数据。</para>
		/// </param>
		/// <param name="FrequencyFields">
		/// <para>Frequency Field(s)</para>
		/// <para>该字段用于计算频数统计数据。字段值的每种唯一组合都将作为新的一行包括在输出表中。</para>
		/// </param>
		public Frequency(object InTable, object OutTable, object FrequencyFields)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.FrequencyFields = FrequencyFields;
		}

		/// <summary>
		/// <para>Tool Display Name : 频数</para>
		/// </summary>
		public override string DisplayName() => "频数";

		/// <summary>
		/// <para>Tool Name : 频数</para>
		/// </summary>
		public override string ToolName() => "频数";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Frequency</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Frequency";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutTable, FrequencyFields, SummaryFields };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>表中包含将用于计算频数统计值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表用于存储频数统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Frequency Field(s)</para>
		/// <para>该字段用于计算频数统计数据。字段值的每种唯一组合都将作为新的一行包括在输出表中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object FrequencyFields { get; set; }

		/// <summary>
		/// <para>Summary Field(s)</para>
		/// <para>该属性字段用于求和或添加到输出表。值将根据频数字段的各种唯一组合进行求和。空值被排除在此计算之外。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Frequency SetEnviroment(object configKeyword = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
