using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Semivariogram Sensitivity</para>
	/// <para>半变异函数灵敏度</para>
	/// <para>此工具通过在原始值的某一百分比范围内更改模型的半变异函数参数（块金、偏基台和主/次变程）对预测值和关联的标准误差执行灵敏度分析。</para>
	/// </summary>
	public class GASemivariogramSensitivity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGaModelSource">
		/// <para>Input geostatistical model source</para>
		/// <para>要分析的地统计模型源。</para>
		/// </param>
		/// <param name="InDatasets">
		/// <para>Input dataset(s)</para>
		/// <para>用于创建输出图层的输入数据集的名称和字段名称。</para>
		/// </param>
		/// <param name="InLocations">
		/// <para>Input point observation locations</para>
		/// <para>执行灵敏度分析的点位置。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>存储灵敏度结果的表。</para>
		/// </param>
		public GASemivariogramSensitivity(object InGaModelSource, object InDatasets, object InLocations, object OutTable)
		{
			this.InGaModelSource = InGaModelSource;
			this.InDatasets = InDatasets;
			this.InLocations = InLocations;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 半变异函数灵敏度</para>
		/// </summary>
		public override string DisplayName() => "半变异函数灵敏度";

		/// <summary>
		/// <para>Tool Name : GASemivariogramSensitivity</para>
		/// </summary>
		public override string ToolName() => "GASemivariogramSensitivity";

		/// <summary>
		/// <para>Tool Excute Name : ga.GASemivariogramSensitivity</para>
		/// </summary>
		public override string ExcuteName() => "ga.GASemivariogramSensitivity";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "coincidentPoints", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGaModelSource, InDatasets, InLocations, NuggetSpanPercents!, NuggetCalcTimes!, PartialsillSpanPercents!, PartialsillCalcTimes!, RangeSpanPercents!, RangeCalcTimes!, MinrangeSpanPercents!, MinrangeCalcTimes!, OutTable };

		/// <summary>
		/// <para>Input geostatistical model source</para>
		/// <para>要分析的地统计模型源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGaModelSource { get; set; }

		/// <summary>
		/// <para>Input dataset(s)</para>
		/// <para>用于创建输出图层的输入数据集的名称和字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGAValueTable()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Input point observation locations</para>
		/// <para>执行灵敏度分析的点位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InLocations { get; set; }

		/// <summary>
		/// <para>Nugget span (% of model value)</para>
		/// <para>从块金参数中减去和添加的百分比，用于创建后续随机块金参数选择的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? NuggetSpanPercents { get; set; } = "10";

		/// <summary>
		/// <para>Number of calculations for Nugget</para>
		/// <para>从块金跨度中随机采样的随机块金值的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		public object? NuggetCalcTimes { get; set; } = "3";

		/// <summary>
		/// <para>Partial Sill span (% of model value)</para>
		/// <para>从偏基台参数中减去和添加到的百分比，用于创建随机偏基台选择的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? PartialsillSpanPercents { get; set; } = "0";

		/// <summary>
		/// <para>Number of calculations for Partial Sill</para>
		/// <para>从偏基台跨度中随机采样的偏基台值的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		public object? PartialsillCalcTimes { get; set; } = "0";

		/// <summary>
		/// <para>Major Range span (% of model value)</para>
		/// <para>从主变程参数中减去和添加的百分比，可创建随机选择主变程的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? RangeSpanPercents { get; set; } = "0";

		/// <summary>
		/// <para>Number of calculations for Major Range</para>
		/// <para>从主变程跨度中随机采样的主变程值的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		public object? RangeCalcTimes { get; set; } = "0";

		/// <summary>
		/// <para>Minor Range span (% of model value)</para>
		/// <para>从次变程参数中减去和添加到次变程参数中的百分比，用于创建随机次变程选择的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? MinrangeSpanPercents { get; set; } = "0";

		/// <summary>
		/// <para>Number of calculations for Minor Range</para>
		/// <para>从次变程跨度中随机采样的次变程值的数目。</para>
		/// <para>如果已在输入地统计模型源中设置“各向异性”，则需要提供值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		public object? MinrangeCalcTimes { get; set; } = "0";

		/// <summary>
		/// <para>Output table</para>
		/// <para>存储灵敏度结果的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GASemivariogramSensitivity SetEnviroment(object? coincidentPoints = null , object? randomGenerator = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(coincidentPoints: coincidentPoints, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
