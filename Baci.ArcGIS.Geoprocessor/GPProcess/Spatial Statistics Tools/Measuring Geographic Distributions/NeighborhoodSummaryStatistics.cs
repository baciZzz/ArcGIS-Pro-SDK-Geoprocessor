using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Neighborhood Summary Statistics</para>
	/// <para>邻域汇总统计数据</para>
	/// <para>使用每个要素周围的局部邻域来计算一个或多个数值字段的汇总统计数据。局部统计数据包括均值（平均值）、中位数、标准差、四分位距、偏度和不平衡分位数，并且所有统计数据都可以使用核来进行地理加权，以对更靠近焦点要素的相邻要素产生更大影响。可以使用各种邻域类型，其中包括距离范围、相邻要素的数目、面邻接、Delaunay 三角测量和空间权重矩阵 (.swm) 文件。还会针对与每个要素的相邻要素的距离来计算汇总统计数据。</para>
	/// </summary>
	public class NeighborhoodSummaryStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将用于计算局部统计数据的点或面要素。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>包含局部统计数据作为字段的输出要素类。各分析字段的每个统计数据将存储为一个单独的字段。</para>
		/// </param>
		public NeighborhoodSummaryStatistics(object InFeatures, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 邻域汇总统计数据</para>
		/// </summary>
		public override string DisplayName() => "邻域汇总统计数据";

		/// <summary>
		/// <para>Tool Name : NeighborhoodSummaryStatistics</para>
		/// </summary>
		public override string ToolName() => "NeighborhoodSummaryStatistics";

		/// <summary>
		/// <para>Tool Excute Name : stats.NeighborhoodSummaryStatistics</para>
		/// </summary>
		public override string ExcuteName() => "stats.NeighborhoodSummaryStatistics";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, AnalysisFields, LocalSummaryStatistic, IncludeFocalFeature, IgnoreNulls, NeighborhoodType, DistanceBand, NumberOfNeighbors, WeightsMatrixFile, LocalWeightingScheme, KernelBandwidth };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将用于计算局部统计数据的点或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>包含局部统计数据作为字段的输出要素类。各分析字段的每个统计数据将存储为一个单独的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>将为其计算局部统计数据的一个或多个字段。如果未提供任何分析字段，则将仅基于到相邻要素的距离计算局部统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Local Summary Statistic</para>
		/// <para>指定将为每个分析字段计算的局部汇总统计数据。</para>
		/// <para>所有—将计算所有的局部统计数据。这是默认设置。</para>
		/// <para>平均值—将计算局部均值（平均值）。</para>
		/// <para>中值— 将计算局部中值。</para>
		/// <para>标准差—将计算局部标准差。</para>
		/// <para>四分位距— 将计算局部四分位距。</para>
		/// <para>偏度— 将计算局部偏度。</para>
		/// <para>不平衡分位数— 将计算局部不平衡分位数。</para>
		/// <para><see cref="LocalSummaryStatisticEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocalSummaryStatistic { get; set; } = "ALL";

		/// <summary>
		/// <para>Include Focal Feature in Calculations</para>
		/// <para>指定在计算每个要素的局部统计数据时是否包含焦点要素。</para>
		/// <para>选中 - 在计算局部统计数据时，将包含焦点要素及其所有相邻要素。这是默认设置。</para>
		/// <para>未选中 - 在计算局部统计数据时，将不包含焦点要素。仅包含该要素的相邻要素。</para>
		/// <para><see cref="IncludeFocalFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeFocalFeature { get; set; } = "true";

		/// <summary>
		/// <para>Ignore Null Values in Calculations</para>
		/// <para>指定在计算中包含还是忽略分析字段中的空值。</para>
		/// <para>选中 - 将忽略分析字段中的空值，并且仅使用非空值来计算统计数据。这是默认设置。</para>
		/// <para>未选中 - 将在计算中包含分析字段中的空值，并且如果在计算中使用的任何值为空，则任何局部统计数据都将计算为空。</para>
		/// <para><see cref="IgnoreNullsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreNulls { get; set; } = "true";

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>指定如何为每个输入要素选择相邻要素。要计算局部统计数据，必须为每个输入要素标识相邻要素，并且这些相邻要素将用于计算每个要素的局部统计数据。对于点要素，默认值为 Delaunay 三角测量。对于面要素，默认值为邻接边拐角。</para>
		/// <para>距离范围—每个要素指定临界距离内的要素将作为相邻要素包含在内。</para>
		/// <para>相邻要素的数目— 最近要素将作为相邻要素包含在内。</para>
		/// <para>仅邻接边— 共享边的面要素将作为相邻要素包含在内。</para>
		/// <para>邻接边拐角— 共享边或拐角的面要素将作为相邻要素包含在内。这是面要素的默认选项。</para>
		/// <para>Delaunay 三角测量—其 Delaunay 三角测量共享边的要素将作为相邻要素包含在内。这是点要素的默认选项。</para>
		/// <para>通过文件获取空间权重— 将由指定空间权重文件定义相邻要素和权重。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>此距离内的所有要素都将作为相邻要素包含在内。如果未提供任何值，则将在执行过程中估算一个值，并将其作为地理处理消息包含在内。如果指定距离导致相邻要素的数目超过 1,000，则将仅包含最近的 1,000 个要素作为相邻要素。</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>针对每次局部计算将包含的相邻要素数目。该数值不包含焦点要素。如果计算中包含焦点要素，则将使用一个附加相邻要素。默认值为 8。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 1000)]
		public object NumberOfNeighbors { get; set; } = "8";

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>空间权重矩阵文件的路径和文件名，该文件用于定义要素之间的空间关系以及潜在的时态关系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt", "txt")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>指定在计算局部统计数据时应用于相邻要素的加权方案。</para>
		/// <para>未加权—将不会对相邻要素进行加权。这是默认设置。</para>
		/// <para>双平方—将使用双平方核方案对相邻要素进行加权。</para>
		/// <para>高斯函数—将使用高斯核方案对相邻要素进行加权。</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocalWeightingScheme { get; set; } = "UNWEIGHTED";

		/// <summary>
		/// <para>Kernel Bandwidth</para>
		/// <para>双平方或高斯局部加权方案的带宽。如果未提供任何值，则将在执行过程中估算一个值，并将其作为地理处理消息包含在内。</para>
		/// <para><see cref="KernelBandwidthEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object KernelBandwidth { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NeighborhoodSummaryStatistics SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Local Summary Statistic</para>
		/// </summary>
		public enum LocalSummaryStatisticEnum 
		{
			/// <summary>
			/// <para>所有—将计算所有的局部统计数据。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>平均值—将计算局部均值（平均值）。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>中值— 将计算局部中值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>标准差—将计算局部标准差。</para>
			/// </summary>
			[GPValue("STD_DEV")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>四分位距— 将计算局部四分位距。</para>
			/// </summary>
			[GPValue("IQR")]
			[Description("四分位距")]
			Interquartile_range,

			/// <summary>
			/// <para>偏度— 将计算局部偏度。</para>
			/// </summary>
			[GPValue("SKEWNESS")]
			[Description("偏度")]
			Skewness,

			/// <summary>
			/// <para>不平衡分位数— 将计算局部不平衡分位数。</para>
			/// </summary>
			[GPValue("QUANTILE_IMBALANCE")]
			[Description("不平衡分位数")]
			Quantile_imbalance,

		}

		/// <summary>
		/// <para>Include Focal Feature in Calculations</para>
		/// </summary>
		public enum IncludeFocalFeatureEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_FOCAL")]
			INCLUDE_FOCAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_FOCAL")]
			EXCLUDE_FOCAL,

		}

		/// <summary>
		/// <para>Ignore Null Values in Calculations</para>
		/// </summary>
		public enum IgnoreNullsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_NULLS")]
			IGNORE_NULLS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE_NULLS")]
			INCLUDE_NULLS,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>距离范围—每个要素指定临界距离内的要素将作为相邻要素包含在内。</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("距离范围")]
			Distance_band,

			/// <summary>
			/// <para>相邻要素的数目— 最近要素将作为相邻要素包含在内。</para>
			/// </summary>
			[GPValue("NUMBER_OF_NEIGHBORS")]
			[Description("相邻要素的数目")]
			Number_of_neighbors,

			/// <summary>
			/// <para>仅邻接边— 共享边的面要素将作为相邻要素包含在内。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角— 共享边或拐角的面要素将作为相邻要素包含在内。这是面要素的默认选项。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Delaunay 三角测量—其 Delaunay 三角测量共享边的要素将作为相邻要素包含在内。这是点要素的默认选项。</para>
			/// </summary>
			[GPValue("DELAUNAY_TRIANGULATION")]
			[Description("Delaunay 三角测量")]
			Delaunay_triangulation,

			/// <summary>
			/// <para>通过文件获取空间权重— 将由指定空间权重文件定义相邻要素和权重。</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("通过文件获取空间权重")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>未加权—将不会对相邻要素进行加权。这是默认设置。</para>
			/// </summary>
			[GPValue("UNWEIGHTED")]
			[Description("未加权")]
			Unweighted,

			/// <summary>
			/// <para>双平方—将使用双平方核方案对相邻要素进行加权。</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("双平方")]
			Bisquare,

			/// <summary>
			/// <para>高斯函数—将使用高斯核方案对相邻要素进行加权。</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("高斯函数")]
			Gaussian,

		}

		/// <summary>
		/// <para>Kernel Bandwidth</para>
		/// </summary>
		public enum KernelBandwidthEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

#endregion
	}
}
