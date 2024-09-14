using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Summarize Attributes</para>
	/// <para>汇总属性</para>
	/// <para>针对要素类中的字段计算汇总统计数据。</para>
	/// </summary>
	public class SummarizeAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>要进行汇总的点、折线或面图层。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>包含汇总属性的新表。</para>
		/// </param>
		public SummarizeAttributes(object InputLayer, object OutTable)
		{
			this.InputLayer = InputLayer;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 汇总属性</para>
		/// </summary>
		public override string DisplayName() => "汇总属性";

		/// <summary>
		/// <para>Tool Name : SummarizeAttributes</para>
		/// </summary>
		public override string ToolName() => "SummarizeAttributes";

		/// <summary>
		/// <para>Tool Excute Name : gapro.SummarizeAttributes</para>
		/// </summary>
		public override string ExcuteName() => "gapro.SummarizeAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutTable, Fields!, SummaryFields!, TimeStepInterval!, TimeStepRepeat!, TimeStepReference! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要进行汇总的点、折线或面图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含汇总属性的新表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>用于汇总相似要素的一个或多个字段。例如，如果选择具有商业和住宅值的名为 PropertyType 的单个字段，则会将所有具有住宅字段值的字段汇总到一起，计算汇总统计数据，并会将所有具有商业字段值的字段汇总到一起。本示例将在输出中生成两行，一行用于商业，一行用于住宅汇总值。</para>
		/// <para>您可以不选择任何字段，并在单个汇总结果中汇总所有要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>将根据指定字段进行计算的统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Time step interval</para>
		/// <para>用来指定时间步长持续时间的值。 只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// <para>只有对输入启用了时间的情况下，才可应用时间步长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time step repeat</para>
		/// <para>用来指定时间步长间隔发生频率的值。 只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepRepeat { get; set; }

		/// <summary>
		/// <para>Time step reference</para>
		/// <para>用来指定时间步长所要对齐的参考时间的日期。 默认情况下为 1970 年 1 月 1 日 12:00 a.m.。只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeStepReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeAttributes SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
