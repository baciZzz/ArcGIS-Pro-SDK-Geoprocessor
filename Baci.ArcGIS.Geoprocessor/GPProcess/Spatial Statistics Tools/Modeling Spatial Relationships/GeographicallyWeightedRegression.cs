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
	/// <para>Geographically Weighted Regression (GWR)</para>
	/// <para>地理加权回归 (GWR)</para>
	/// <para>执行“地理加权回归 (GWR)”，这是一种用于建模空间变化关系的线性回归的局部形式。</para>
	/// </summary>
	[Obsolete()]
	public class GeographicallyWeightedRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>包含因变量和自变量的要素类。</para>
		/// </param>
		/// <param name="DependentField">
		/// <para>Dependent variable</para>
		/// <para>包含将进行建模的值的数值字段。</para>
		/// </param>
		/// <param name="ExplanatoryField">
		/// <para>Explanatory variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output feature class</para>
		/// <para>将接收因变量的估计数和残差的输出要素类。</para>
		/// </param>
		/// <param name="KernelType">
		/// <para>Kernel type</para>
		/// <para>指定核是否构建为固定距离，或者指定是否允许核在作为要素密度函数的范围内进行变化。</para>
		/// <para>固定—用来解决各局部回归分析的空间环境（“高斯”核）属于固定距离。</para>
		/// <para>自适应—空间环境（“高斯”核）是指定相邻要素的数目的函数。要素分布越密集，空间环境越小；要素分布越稀疏，空间环境越大。</para>
		/// <para><see cref="KernelTypeEnum"/></para>
		/// </param>
		/// <param name="BandwidthMethod">
		/// <para>Bandwidth method</para>
		/// <para>指定核范围的确定方式。当选择 Akaike 信息准则或交叉验证时，此工具将查找最佳距离或相邻要素的数目。通常，如果不确定对距离或相邻要素的数目参数使用哪个选项，则选择 Akaike 信息准则或交叉验证。但是，如果工具可以确定最佳距离或者相邻要素的数目，则需要使用如下面的指定选项。</para>
		/// <para>Akaike 信息准则—使用 Akaike 信息准则确定核的范围。</para>
		/// <para>交叉验证—使用交叉验证确定核的范围。</para>
		/// <para>如下面的指定—根据固定距离或固定相邻要素的数目确定核的范围。必须为距离或相邻要素的数目参数指定一个值。</para>
		/// <para><see cref="BandwidthMethodEnum"/></para>
		/// </param>
		public GeographicallyWeightedRegression(object InFeatures, object DependentField, object ExplanatoryField, object OutFeatureclass, object KernelType, object BandwidthMethod)
		{
			this.InFeatures = InFeatures;
			this.DependentField = DependentField;
			this.ExplanatoryField = ExplanatoryField;
			this.OutFeatureclass = OutFeatureclass;
			this.KernelType = KernelType;
			this.BandwidthMethod = BandwidthMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 地理加权回归 (GWR)</para>
		/// </summary>
		public override string DisplayName() => "地理加权回归 (GWR)";

		/// <summary>
		/// <para>Tool Name : GeographicallyWeightedRegression</para>
		/// </summary>
		public override string ToolName() => "GeographicallyWeightedRegression";

		/// <summary>
		/// <para>Tool Excute Name : stats.GeographicallyWeightedRegression</para>
		/// </summary>
		public override string ExcuteName() => "stats.GeographicallyWeightedRegression";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentField, ExplanatoryField, OutFeatureclass, KernelType, BandwidthMethod, Distance, NumberOfNeighbors, WeightField, CoefficientRasterWorkspace, CellSize, InPredictionLocations, PredictionExplanatoryField, OutPredictionFeatureclass, OutTable, OutRegressionRasters };

		/// <summary>
		/// <para>Input features</para>
		/// <para>包含因变量和自变量的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent variable</para>
		/// <para>包含将进行建模的值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentField { get; set; }

		/// <summary>
		/// <para>Explanatory variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryField { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>将接收因变量的估计数和残差的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Kernel type</para>
		/// <para>指定核是否构建为固定距离，或者指定是否允许核在作为要素密度函数的范围内进行变化。</para>
		/// <para>固定—用来解决各局部回归分析的空间环境（“高斯”核）属于固定距离。</para>
		/// <para>自适应—空间环境（“高斯”核）是指定相邻要素的数目的函数。要素分布越密集，空间环境越小；要素分布越稀疏，空间环境越大。</para>
		/// <para><see cref="KernelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelType { get; set; } = "FIXED";

		/// <summary>
		/// <para>Bandwidth method</para>
		/// <para>指定核范围的确定方式。当选择 Akaike 信息准则或交叉验证时，此工具将查找最佳距离或相邻要素的数目。通常，如果不确定对距离或相邻要素的数目参数使用哪个选项，则选择 Akaike 信息准则或交叉验证。但是，如果工具可以确定最佳距离或者相邻要素的数目，则需要使用如下面的指定选项。</para>
		/// <para>Akaike 信息准则—使用 Akaike 信息准则确定核的范围。</para>
		/// <para>交叉验证—使用交叉验证确定核的范围。</para>
		/// <para>如下面的指定—根据固定距离或固定相邻要素的数目确定核的范围。必须为距离或相邻要素的数目参数指定一个值。</para>
		/// <para><see cref="BandwidthMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BandwidthMethod { get; set; } = "AICc";

		/// <summary>
		/// <para>Distance</para>
		/// <para>将核类型参数设置为固定，带宽方法参数设置为如下面的指定时使用的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976900000000001e+308)]
		public object Distance { get; set; }

		/// <summary>
		/// <para>Number of neighbors</para>
		/// <para>将核类型参数设置为自适应，带宽方法参数设置为如下面的指定时包括在“高斯”核的局部带宽中的精确相邻要素的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 1000)]
		public object NumberOfNeighbors { get; set; } = "30";

		/// <summary>
		/// <para>Weights</para>
		/// <para>包含单个要素的空间权重的数值字段。此权重字段允许部分要素在模型校准过程中比其他要素更为重要。其用于在不同位置采集的样本数目发生变化以及对因变量和自变量中的值求平均值的情况中，并且样本越多，位置越稳定（应该进行更高的加权）。例如，如果一个位置平均具有 25 个不同的样本，但其他位置平均只具有 2 个样本，则可将样本数用作权重字段，以便在模型校准中具有更多样本的位置比具有少量样本的位置有更大的影响力。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Coefficient raster workspace</para>
		/// <para>将创建系数栅格的工作空间的完整路径。如果提供了此工作空间，则会为截距及各解释变量创建栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[Category("Additional Parameters (Optional)")]
		public object CoefficientRasterWorkspace { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>创建系数栅格时使用的像元大小（数字）或对像元大小的引用（栅格数据集的路径）。</para>
		/// <para>默认情况下，像元大小为在地理处理环境输出坐标系中指定的范围的最短宽度或高度除以 250。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[Category("Additional Parameters (Optional)")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Prediction locations</para>
		/// <para>一种要素类，包含表示应计算评估值的位置的要素。数据集中的每个要素都应包含所有指定的解释变量的值；将使用为输入要素类数据校准的模型来评估这些要素的因变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		[Category("Additional Parameters (Optional)")]
		public object InPredictionLocations { get; set; }

		/// <summary>
		/// <para>Prediction explanatory variable(s)</para>
		/// <para>表示“预测位置”要素类中的解释变量的字段列表。这些字段名的供应顺序应与在输入要素类“解释”变量参数中的列出顺序相同（一对一的对应关系）。如果未指定任何预测解释变量，则输出预测要素类将仅包含各预测位置的已计算系数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[Category("Additional Parameters (Optional)")]
		public object PredictionExplanatoryField { get; set; }

		/// <summary>
		/// <para>Output prediction feature class</para>
		/// <para>接收“预测”位置要素类中各要素的因变量估计数的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Parameters (Optional)")]
		public object OutPredictionFeatureclass { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output regression rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object OutRegressionRasters { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeographicallyWeightedRegression SetEnviroment(object cellSize = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Kernel type</para>
		/// </summary>
		public enum KernelTypeEnum 
		{
			/// <summary>
			/// <para>固定—用来解决各局部回归分析的空间环境（“高斯”核）属于固定距离。</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("固定")]
			Fixed,

			/// <summary>
			/// <para>自适应—空间环境（“高斯”核）是指定相邻要素的数目的函数。要素分布越密集，空间环境越小；要素分布越稀疏，空间环境越大。</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("自适应")]
			Adaptive,

		}

		/// <summary>
		/// <para>Bandwidth method</para>
		/// </summary>
		public enum BandwidthMethodEnum 
		{
			/// <summary>
			/// <para>Akaike 信息准则—使用 Akaike 信息准则确定核的范围。</para>
			/// </summary>
			[GPValue("AICc")]
			[Description("Akaike 信息准则")]
			Akaike_Information_Criterion,

			/// <summary>
			/// <para>交叉验证—使用交叉验证确定核的范围。</para>
			/// </summary>
			[GPValue("CV")]
			[Description("交叉验证")]
			Cross_Validation,

			/// <summary>
			/// <para>如下面的指定—根据固定距离或固定相邻要素的数目确定核的范围。必须为距离或相邻要素的数目参数指定一个值。</para>
			/// </summary>
			[GPValue("BANDWIDTH_PARAMETER")]
			[Description("如下面的指定")]
			As_specified_below,

		}

#endregion
	}
}
