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
	/// <para>执行“地理加权回归”，这是一种用于建模空间变化关系的线性回归的局部形式。</para>
	/// </summary>
	public class GWR : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含因变量和解释变量的要素类。</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>包含将进行建模的观测值的数值字段。</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）—因变量值是连续的。 将使用高斯模型，并且工具将执行普通最小二乘法回归。</para>
		/// <para>二进制（逻辑）—因变量值表示存在或不存在。 这可以是常规的 1 和 0，或者是基于阈值进行编码的连续数据。 将使用逻辑回归模型。</para>
		/// <para>计数（泊松）—因变量值是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。 将使用泊松回归模型。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>包含因变量的估计数和残差的新要素类。</para>
		/// </param>
		/// <param name="NeighborhoodType">
		/// <para>Neighborhood Type</para>
		/// <para>指定是将使用的邻域构造为固定距离，还是允许根据要素的密度在空间范围内变化。</para>
		/// <para>相邻要素的数目—邻域大小是每个要素的计算中包括的指定相邻要素数目的函数。 在要素密集的位置，邻域的空间范围较小；在要素稀疏的位置，邻域的空间范围较大。</para>
		/// <para>距离范围—邻域大小是每个要素的恒定或固定距离。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </param>
		/// <param name="NeighborhoodSelectionMethod">
		/// <para>Neighborhood Selection Method</para>
		/// <para>指定将如何确定邻域大小。 使用黄金搜索和手动间隔选项选择的邻域基于最小化 AICc 值。</para>
		/// <para>黄金搜索—工具将使用黄金分割搜索方法，基于数据的特征确定最佳距离或相邻要素数。</para>
		/// <para>手动间隔—测试邻域将由最小相邻要素的数目和相邻要素的数目增量参数（如果为邻域类型参数选择相邻要素的数目）或者最小搜索距离和搜索距离增量参数（如果为邻域类型参数选择距离范围）以及增量数参数中指定的值定义。</para>
		/// <para>用户定义—邻域大小将由相邻要素的数目或距离范围参数指定。</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </param>
		public GWR(object InFeatures, object DependentVariable, object ModelType, object ExplanatoryVariables, object OutputFeatures, object NeighborhoodType, object NeighborhoodSelectionMethod)
		{
			this.InFeatures = InFeatures;
			this.DependentVariable = DependentVariable;
			this.ModelType = ModelType;
			this.ExplanatoryVariables = ExplanatoryVariables;
			this.OutputFeatures = OutputFeatures;
			this.NeighborhoodType = NeighborhoodType;
			this.NeighborhoodSelectionMethod = NeighborhoodSelectionMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 地理加权回归 (GWR)</para>
		/// </summary>
		public override string DisplayName() => "地理加权回归 (GWR)";

		/// <summary>
		/// <para>Tool Name : GWR</para>
		/// </summary>
		public override string ToolName() => "GWR";

		/// <summary>
		/// <para>Tool Excute Name : stats.GWR</para>
		/// </summary>
		public override string ExcuteName() => "stats.GWR";

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
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeatures, NeighborhoodType, NeighborhoodSelectionMethod, MinimumNumberOfNeighbors!, MaximumNumberOfNeighbors!, MinimumSearchDistance!, MaximumSearchDistance!, NumberOfNeighborsIncrement!, SearchDistanceIncrement!, NumberOfIncrements!, NumberOfNeighbors!, DistanceBand!, PredictionLocations!, ExplanatoryVariablesToMatch!, OutputPredictedFeatures!, RobustPrediction!, LocalWeightingScheme!, CoefficientRasterWorkspace!, CoefficientRasterLayers!, Scale! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含因变量和解释变量的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>包含将进行建模的观测值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）—因变量值是连续的。 将使用高斯模型，并且工具将执行普通最小二乘法回归。</para>
		/// <para>二进制（逻辑）—因变量值表示存在或不存在。 这可以是常规的 1 和 0，或者是基于阈值进行编码的连续数据。 将使用逻辑回归模型。</para>
		/// <para>计数（泊松）—因变量值是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。 将使用泊松回归模型。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Explanatory Variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>包含因变量的估计数和残差的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>指定是将使用的邻域构造为固定距离，还是允许根据要素的密度在空间范围内变化。</para>
		/// <para>相邻要素的数目—邻域大小是每个要素的计算中包括的指定相邻要素数目的函数。 在要素密集的位置，邻域的空间范围较小；在要素稀疏的位置，邻域的空间范围较大。</para>
		/// <para>距离范围—邻域大小是每个要素的恒定或固定距离。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; }

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// <para>指定将如何确定邻域大小。 使用黄金搜索和手动间隔选项选择的邻域基于最小化 AICc 值。</para>
		/// <para>黄金搜索—工具将使用黄金分割搜索方法，基于数据的特征确定最佳距离或相邻要素数。</para>
		/// <para>手动间隔—测试邻域将由最小相邻要素的数目和相邻要素的数目增量参数（如果为邻域类型参数选择相邻要素的数目）或者最小搜索距离和搜索距离增量参数（如果为邻域类型参数选择距离范围）以及增量数参数中指定的值定义。</para>
		/// <para>用户定义—邻域大小将由相邻要素的数目或距离范围参数指定。</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodSelectionMethod { get; set; }

		/// <summary>
		/// <para>Minimum Number of Neighbors</para>
		/// <para>每个要素的最小相邻要素的数目将包含在其计算中。 建议至少使用 30 个相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 999)]
		public object? MinimumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>每个要素的最大相邻要素的数目（最多 1000 个）将包含在其计算中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 3, Max = 1000)]
		public object? MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Minimum Search Distance</para>
		/// <para>最小邻域搜索距离。 建议使用每个要素至少有 30 个相邻要素的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? MinimumSearchDistance { get; set; }

		/// <summary>
		/// <para>Maximum Search Distance</para>
		/// <para>最大邻域搜索距离。 如果距离导致要素具有超过 1000 个相邻要素，则该工具将在目标要素的计算中使用前 1000 个相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? MaximumSearchDistance { get; set; }

		/// <summary>
		/// <para>Number of Neighbors Increment</para>
		/// <para>将针对每个邻域测试增加手动间隔的相邻要素的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 500)]
		public object? NumberOfNeighborsIncrement { get; set; }

		/// <summary>
		/// <para>Search Distance Increment</para>
		/// <para>将针对每个邻域测试增加手动间隔的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchDistanceIncrement { get; set; }

		/// <summary>
		/// <para>Number of Increments</para>
		/// <para>要从最小相邻要素的数目或最小搜索距离参数值开始测试的邻域大小的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 20)]
		public object? NumberOfIncrements { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>将要考虑的各要素的最近相邻要素数目（最多 1000）。 该数值必须是介于 2 到 1000 之间的整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 1000)]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>邻域的空间范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? DistanceBand { get; set; }

		/// <summary>
		/// <para>Prediction Locations</para>
		/// <para>一种要素类，包含表示将计算评估值的位置的要素。 此数据集中的每个要素都应包含指定的所有解释变量的值。 将使用针对输入要素类数据进行校准的模型来评估这些要素的因变量。 需要预测的是，这些要素位置应该位于与输入要素值相同的研究区域内，或接近该研究区域（位于 +15% 范围内）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		[Category("Prediction Options")]
		public object? PredictionLocations { get; set; }

		/// <summary>
		/// <para>Explanatory Variables to Match</para>
		/// <para>预测位置参数中与输入要素类参数中的相应解释变量匹配的解释变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>将接收每个预测位置值的因变量估计数的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object? OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Robust Prediction</para>
		/// <para>用于指定将在预测计算中使用的要素。</para>
		/// <para>选中 - 值高于平均值（异常值）3 个标准偏差的要素以及权重为 0（空间异常值）的要素将从预测计算中排除，但将在输出要素类中接收预测。 这是默认设置。</para>
		/// <para>未选中 - 将在预测计算中使用所有要素。</para>
		/// <para><see cref="RobustPredictionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Prediction Options")]
		public object? RobustPrediction { get; set; } = "true";

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>用于指定将用于在模型中提供空间权重的核类型。 核将定义每个要素与其邻域内其他要素相关的方式。</para>
		/// <para>双平方—权重 0 将会分配给指定邻域外的任何要素。 这是默认设置。</para>
		/// <para>高斯函数—所有要素都将获得权重，但是距离目标要素越远，则权重将以指数方式变小。</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? LocalWeightingScheme { get; set; } = "BISQUARE";

		/// <summary>
		/// <para>Coefficient Raster Workspace</para>
		/// <para>将创建系数栅格的工作空间。 如果提供了此工作空间，则会为截距及各解释变量创建栅格。 仅当具有 Desktop Advanced 许可时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[Category("Additional Options")]
		public object? CoefficientRasterWorkspace { get; set; }

		/// <summary>
		/// <para>Coefficient Raster Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? CoefficientRasterLayers { get; set; }

		/// <summary>
		/// <para>Scale Data</para>
		/// <para>指定在拟合模型之前是否将解释变量和因变量的值缩放为平均值为 0 和标准差为 1。</para>
		/// <para>选中 - 系统将缩放变量的值。 结果将包含解释变量系数的已缩放和未缩放版本。</para>
		/// <para>未选中 - 系统将不会缩放变量的值。 所有系数都将是未缩放系数并将以原始数据单位表示。</para>
		/// <para><see cref="ScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Scale { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GWR SetEnviroment(object? cellSize = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>连续（高斯）—因变量值是连续的。 将使用高斯模型，并且工具将执行普通最小二乘法回归。</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("连续（高斯）")]
			CONTINUOUS,

			/// <summary>
			/// <para>二进制（逻辑）—因变量值表示存在或不存在。 这可以是常规的 1 和 0，或者是基于阈值进行编码的连续数据。 将使用逻辑回归模型。</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("二进制（逻辑）")]
			BINARY,

			/// <summary>
			/// <para>计数（泊松）—因变量值是离散的，并且可以表示事件，例如犯罪计数、疾病事件或交通事故。 将使用泊松回归模型。</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("计数（泊松）")]
			COUNT,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>相邻要素的数目—邻域大小是每个要素的计算中包括的指定相邻要素数目的函数。 在要素密集的位置，邻域的空间范围较小；在要素稀疏的位置，邻域的空间范围较大。</para>
			/// </summary>
			[GPValue("NUMBER_OF_NEIGHBORS")]
			[Description("相邻要素的数目")]
			Number_of_neighbors,

			/// <summary>
			/// <para>距离范围—邻域大小是每个要素的恒定或固定距离。</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("距离范围")]
			Distance_band,

		}

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// </summary>
		public enum NeighborhoodSelectionMethodEnum 
		{
			/// <summary>
			/// <para>黄金搜索—工具将使用黄金分割搜索方法，基于数据的特征确定最佳距离或相邻要素数。</para>
			/// </summary>
			[GPValue("GOLDEN_SEARCH")]
			[Description("黄金搜索")]
			Golden_search,

			/// <summary>
			/// <para>手动间隔—测试邻域将由最小相邻要素的数目和相邻要素的数目增量参数（如果为邻域类型参数选择相邻要素的数目）或者最小搜索距离和搜索距离增量参数（如果为邻域类型参数选择距离范围）以及增量数参数中指定的值定义。</para>
			/// </summary>
			[GPValue("MANUAL_INTERVALS")]
			[Description("手动间隔")]
			Manual_intervals,

			/// <summary>
			/// <para>用户定义—邻域大小将由相邻要素的数目或距离范围参数指定。</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("用户定义")]
			User_defined,

		}

		/// <summary>
		/// <para>Robust Prediction</para>
		/// </summary>
		public enum RobustPredictionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ROBUST")]
			ROBUST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_ROBUST")]
			NON_ROBUST,

		}

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>高斯函数—所有要素都将获得权重，但是距离目标要素越远，则权重将以指数方式变小。</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("高斯函数")]
			Gaussian,

			/// <summary>
			/// <para>双平方—权重 0 将会分配给指定邻域外的任何要素。 这是默认设置。</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("双平方")]
			Bisquare,

		}

		/// <summary>
		/// <para>Scale Data</para>
		/// </summary>
		public enum ScaleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SCALE_DATA")]
			SCALE_DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SCALE_DATA")]
			NO_SCALE_DATA,

		}

#endregion
	}
}
