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
	/// <para>Enrich</para>
	/// <para>丰富</para>
	/// <para>可通过添加与数据位置周围或内部的人员及地点相关的人口统计和景观信息来丰富数据。输出是您的输入的副本，其中包含其他属性字段。此工具需要 ArcGIS Online 组织帐户或本地安装的 Business Analyst 数据集。</para>
	/// </summary>
	[Obsolete()]
	public class Enrich : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要丰富的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>包含输入属性和用户所选属性的新图层。可以根据基本人口统计边界来汇总用户所选属性。仅考虑输入边界内的区域。</para>
		/// </param>
		public Enrich(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 丰富</para>
		/// </summary>
		public override string DisplayName() => "丰富";

		/// <summary>
		/// <para>Tool Name : 丰富</para>
		/// </summary>
		public override string ToolName() => "丰富";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Enrich</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Enrich";

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
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Variables, BufferType, Distance, Unit };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要丰富的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>包含输入属性和用户所选属性的新图层。可以根据基本人口统计边界来汇总用户所选属性。仅考虑输入边界内的区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>要进行汇总并添加到输出要素类的变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Define areas to enrich</para>
		/// <para>输入点要素必须具有相关联的边界面，才能对其进行丰富。连接到 ArcGIS Online 后，将动态填充出行模式选项。输入线要素只能使用直线距离。默认值为直线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BufferType { get; set; }

		/// <summary>
		/// <para>Distance or time</para>
		/// <para>确定要丰富的区域的距离或大小（例如，1 英里缓冲区或 5 分钟步行时间）。单位对应于缓冲区类型。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Distance { get; set; } = "1";

		/// <summary>
		/// <para>Unit</para>
		/// <para>与距离或时间参数相关联的单位。</para>
		/// <para>Miles—英里</para>
		/// <para>Yards—码</para>
		/// <para>Feet—英尺</para>
		/// <para>Kilometers—千米</para>
		/// <para>Meters—米</para>
		/// <para>Hours—小时</para>
		/// <para>Minutes—分</para>
		/// <para>Seconds—秒</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Unit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Enrich SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
