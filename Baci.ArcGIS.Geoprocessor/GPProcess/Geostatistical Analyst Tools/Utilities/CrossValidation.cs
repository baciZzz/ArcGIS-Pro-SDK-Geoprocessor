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
	/// <para>Cross Validation</para>
	/// <para>交叉验证</para>
	/// <para>先移除一个数据位置，然后使用其余位置处的数据预测关联数据。该工具的主要用途是，比较预测值与实测值以获取有关某些模型参数的有用信息。</para>
	/// </summary>
	public class CrossValidation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </param>
		public CrossValidation(object InGeostatLayer)
		{
			this.InGeostatLayer = InGeostatLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 交叉验证</para>
		/// </summary>
		public override string DisplayName() => "交叉验证";

		/// <summary>
		/// <para>Tool Name : CrossValidation</para>
		/// </summary>
		public override string ToolName() => "CrossValidation";

		/// <summary>
		/// <para>Tool Excute Name : ga.CrossValidation</para>
		/// </summary>
		public override string ExcuteName() => "ga.CrossValidation";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, OutPointFeatureClass, Count, MeanError, RootMeanSquare, AverageStandard, MeanStandardized, RootMeanSquareStandardized, PercentIn90Interval, PercentIn95Interval, AverageCrps };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output point feature class</para>
		/// <para>将交叉验证统计信息存储在地统计图层中的各个位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object Count { get; set; } = "0";

		/// <summary>
		/// <para>Mean error</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MeanError { get; set; } = "NaN";

		/// <summary>
		/// <para>Root mean square</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object RootMeanSquare { get; set; } = "NaN";

		/// <summary>
		/// <para>Average standard</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object AverageStandard { get; set; } = "NaN";

		/// <summary>
		/// <para>Mean standardized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MeanStandardized { get; set; } = "NaN";

		/// <summary>
		/// <para>Root mean square standardized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object RootMeanSquareStandardized { get; set; } = "NaN";

		/// <summary>
		/// <para>Percent in 90% Interval</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object PercentIn90Interval { get; set; } = "NaN";

		/// <summary>
		/// <para>Percent in 95% Interval</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object PercentIn95Interval { get; set; } = "NaN";

		/// <summary>
		/// <para>Average CRPS</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object AverageCrps { get; set; } = "NaN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CrossValidation SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
