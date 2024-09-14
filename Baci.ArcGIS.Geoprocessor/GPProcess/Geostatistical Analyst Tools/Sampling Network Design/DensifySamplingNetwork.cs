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
	/// <para>Densify Sampling Network</para>
	/// <para>增密采样网络</para>
	/// <para>使用预定义的地统计克里金图层来确定新监测站的构建位置。也可用于确定哪些监测站应从现有网络中移除。</para>
	/// </summary>
	public class DensifySamplingNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>输入由克里金模型生成的地统计图层。</para>
		/// </param>
		/// <param name="NumberOutputPoints">
		/// <para>Number of  output points</para>
		/// <para>指定要生成的采样位置的数量。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output point feature class</para>
		/// <para>输出要素类的名称。</para>
		/// </param>
		public DensifySamplingNetwork(object InGeostatLayer, object NumberOutputPoints, object OutFeatureClass)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.NumberOutputPoints = NumberOutputPoints;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 增密采样网络</para>
		/// </summary>
		public override string DisplayName() => "增密采样网络";

		/// <summary>
		/// <para>Tool Name : DensifySamplingNetwork</para>
		/// </summary>
		public override string ToolName() => "DensifySamplingNetwork";

		/// <summary>
		/// <para>Tool Excute Name : ga.DensifySamplingNetwork</para>
		/// </summary>
		public override string ExcuteName() => "ga.DensifySamplingNetwork";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, NumberOutputPoints, OutFeatureClass, SelectionCriteria, Threshold, InWeightRaster, InCandidatePointFeatures, InhibitionDistance };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>输入由克里金模型生成的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Number of  output points</para>
		/// <para>指定要生成的采样位置的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		public object NumberOutputPoints { get; set; }

		/// <summary>
		/// <para>Output point feature class</para>
		/// <para>输出要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Selection criteria</para>
		/// <para>采样网络的增密方法。</para>
		/// <para>预测的标准误差—预测标准误差条件</para>
		/// <para>标准误差阈值—标准误差阈值条件</para>
		/// <para>下限四分位数阈值— 下限四分位阈值条件</para>
		/// <para>上限四分位阈值— 上限四分位阈值条件</para>
		/// <para>预测标准误差选项会向预测标准误差较大的位置分配额外的权重。如果正在研究的变量存在临界阈值（例如可接受的最高臭氧含量），则标准误差阈值、下限四分位阈值和上限四分位阈值选项将非常有用。标准误差阈值选项会向值接近于阈值的位置分配额外的权重。下限四分位阈值选项会向最不可能超出临界阈值的位置分配额外的权重。上限四分位阈值选项会向最有可能超出临界阈值的位置分配额外的权重。</para>
		/// <para>当选择条件设置为标准误差阈值、下限四分位阈值或上限四分位阈值时，阈值参数将变为可用，以便您指定感兴趣的阈值。</para>
		/// <para>每个选项的公式为：&lt;code&gt;Standard error of prediction = stderr Standard error threshold = stderr(s)(1 - 2 · abs(prob[Z(s) &gt; threshold] - 0.5)) Lower quartile threshold = (Z0.75(s) - Z0.25(s)) · (prob[Z(s) &lt; threshold]) Upper quartile threshold = (Z0.75(s) - Z0.25(s)) · (prob[Z(s) &gt; threshold])&lt;/code&gt;</para>
		/// <para><see cref="SelectionCriteriaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionCriteria { get; set; } = "STDERR";

		/// <summary>
		/// <para>Threshold value</para>
		/// <para>用来增密采样网络的阈值。</para>
		/// <para>仅在使用标准误差阈值、下限四分位阈值或上限四分位阈值选择条件时，该参数才适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 1.7976931348623157e+308)]
		public object Threshold { get; set; }

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>该栅格用于确定要对哪些位置的优先顺序进行权衡。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		public object InWeightRaster { get; set; }

		/// <summary>
		/// <para>Input candidate point features</para>
		/// <para>可供选择的采样位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InCandidatePointFeatures { get; set; }

		/// <summary>
		/// <para>Inhibition distance</para>
		/// <para>用于避免样本的放置间距小于该距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object InhibitionDistance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DensifySamplingNetwork SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Selection criteria</para>
		/// </summary>
		public enum SelectionCriteriaEnum 
		{
			/// <summary>
			/// <para>预测的标准误差—预测标准误差条件</para>
			/// </summary>
			[GPValue("STDERR")]
			[Description("预测的标准误差")]
			Standard_error_of_prediction,

			/// <summary>
			/// <para>标准误差阈值—标准误差阈值条件</para>
			/// </summary>
			[GPValue("STDERR_THRESHOLD")]
			[Description("标准误差阈值")]
			Standard_error_threshold,

			/// <summary>
			/// <para>下限四分位数阈值— 下限四分位阈值条件</para>
			/// </summary>
			[GPValue("QUARTILE_THRESHOLD")]
			[Description("下限四分位数阈值")]
			Lower_quartile_threshold,

			/// <summary>
			/// <para>上限四分位阈值— 上限四分位阈值条件</para>
			/// </summary>
			[GPValue("QUARTILE_THRESHOLD_UPPER")]
			[Description("上限四分位阈值")]
			Upper_quartile_threshold,

		}

#endregion
	}
}
