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
	/// <para>Multiscale Geographically Weighted Regression (MGWR)</para>
	/// <para>多比例地理加权回归 (MGWR)</para>
	/// <para>用于执行多比例地理加权回归 (MGWR)，这是一种用于对空间变化关系进行建模的线性回归的局部形式。</para>
	/// </summary>
	public class MGWR : AbstractGPProcess
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
		/// <para>根据因变量的值来指定回归模型。 目前，系统仅支持连续数据，并且该参数隐藏在地理处理窗格中。 请勿使用分类、计数或二进制因变量。</para>
		/// <para>连续—该因变量表示连续值。 这是默认设置。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variables</para>
		/// <para>将在回归模型中用作独立解释变量的字段列表。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>包含 MGWR 模型的系数、残差和显著性水平的新要素类。</para>
		/// </param>
		/// <param name="NeighborhoodType">
		/// <para>Neighborhood Type</para>
		/// <para>指定邻域是固定距离，还是允许根据要素的密度在空间范围内变化。</para>
		/// <para>相邻要素的数目—邻域大小将是每个要素的最近相邻要素的指定数量。 在要素密集的位置，邻域的空间范围将会较小；在要素稀疏的位置，邻域的空间范围将会较大。</para>
		/// <para>距离范围—邻域大小将是每个要素的恒定或固定距离。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </param>
		/// <param name="NeighborhoodSelectionMethod">
		/// <para>Neighborhood Selection Method</para>
		/// <para>指定将如何确定邻域大小。</para>
		/// <para>黄金搜索—最佳距离或相邻要素数目将通过使用黄金搜索算法来最小化 AICc 值进行确定。</para>
		/// <para>手动间隔—系统将通过测试值范围和选择具有最小 AICc 的值来确定距离或相邻要素数目。 如果邻域类型参数设置为距离范围，则此范围的最小值将由最小搜索距离参数提供。 随后系统会为最小值增加搜索距离增量参数中指定的值。 该操作将重复增量数参数所指定的次数。 如果邻域类型参数设置为相邻要素的数目，则最小值、增量大小和增量数将分别由最小相邻要素数、相邻要素的数目增量和增量数参数提供。</para>
		/// <para>用户定义—邻域大小将由相邻要素的数目参数或距离范围参数指定。</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </param>
		public MGWR(object InFeatures, object DependentVariable, object ModelType, object ExplanatoryVariables, object OutputFeatures, object NeighborhoodType, object NeighborhoodSelectionMethod)
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
		/// <para>Tool Display Name : 多比例地理加权回归 (MGWR)</para>
		/// </summary>
		public override string DisplayName() => "多比例地理加权回归 (MGWR)";

		/// <summary>
		/// <para>Tool Name : MGWR</para>
		/// </summary>
		public override string ToolName() => "MGWR";

		/// <summary>
		/// <para>Tool Excute Name : stats.MGWR</para>
		/// </summary>
		public override string ExcuteName() => "stats.MGWR";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeatures, NeighborhoodType, NeighborhoodSelectionMethod, MinimumNumberOfNeighbors!, MaximumNumberOfNeighbors!, DistanceUnit!, MinimumSearchDistance!, MaximumSearchDistance!, NumberOfNeighborsIncrement!, SearchDistanceIncrement!, NumberOfIncrements!, NumberOfNeighbors!, DistanceBand!, NumberOfNeighborsGolden!, NumberOfNeighborsManual!, NumberOfNeighborsDefined!, DistanceGolden!, DistanceManual!, DistanceDefined!, PredictionLocations!, ExplanatoryVariablesToMatch!, OutputPredictedFeatures!, RobustPrediction!, LocalWeightingScheme!, OutputTable!, CoefficientRasterWorkspace!, Scale!, CoefficientRasterLayers!, OutputLayerGroup! };

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
		/// <para>根据因变量的值来指定回归模型。 目前，系统仅支持连续数据，并且该参数隐藏在地理处理窗格中。 请勿使用分类、计数或二进制因变量。</para>
		/// <para>连续—该因变量表示连续值。 这是默认设置。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Explanatory Variables</para>
		/// <para>将在回归模型中用作独立解释变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>包含 MGWR 模型的系数、残差和显著性水平的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>指定邻域是固定距离，还是允许根据要素的密度在空间范围内变化。</para>
		/// <para>相邻要素的数目—邻域大小将是每个要素的最近相邻要素的指定数量。 在要素密集的位置，邻域的空间范围将会较小；在要素稀疏的位置，邻域的空间范围将会较大。</para>
		/// <para>距离范围—邻域大小将是每个要素的恒定或固定距离。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; }

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// <para>指定将如何确定邻域大小。</para>
		/// <para>黄金搜索—最佳距离或相邻要素数目将通过使用黄金搜索算法来最小化 AICc 值进行确定。</para>
		/// <para>手动间隔—系统将通过测试值范围和选择具有最小 AICc 的值来确定距离或相邻要素数目。 如果邻域类型参数设置为距离范围，则此范围的最小值将由最小搜索距离参数提供。 随后系统会为最小值增加搜索距离增量参数中指定的值。 该操作将重复增量数参数所指定的次数。 如果邻域类型参数设置为相邻要素的数目，则最小值、增量大小和增量数将分别由最小相邻要素数、相邻要素的数目增量和增量数参数提供。</para>
		/// <para>用户定义—邻域大小将由相邻要素的数目参数或距离范围参数指定。</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodSelectionMethod { get; set; }

		/// <summary>
		/// <para>Minimum Number of Neighbors</para>
		/// <para>每个要素将包含在其计算中的最小相邻要素的数目。 建议至少使用 30 个相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinimumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>每个要素将包含在其计算中的最大相邻要素的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>指定将用于测量要素之间距离的距离单位。</para>
		/// <para>美国测量英尺—距离将以美国测量英尺为单位进行测量。</para>
		/// <para>米—距离将以米为单位进行测量。</para>
		/// <para>千米—距离将以千米为单位进行测量。</para>
		/// <para>美国测量英里—距离将以美国测量英里为单位进行测量。</para>
		/// <para><see cref="DistanceUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnit { get; set; }

		/// <summary>
		/// <para>Minimum Search Distance</para>
		/// <para>将应用于每个解释变量的最小搜索距离。 建议您为每个要素提供至少包含 30 个相邻要素的最小距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumSearchDistance { get; set; }

		/// <summary>
		/// <para>Maximum Search Distance</para>
		/// <para>将应用于所有变量的最大邻域搜索距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumSearchDistance { get; set; }

		/// <summary>
		/// <para>Number of Neighbors Increment</para>
		/// <para>将针对每个邻域测试增加手动间隔的相邻要素的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfNeighborsIncrement { get; set; }

		/// <summary>
		/// <para>Search Distance Increment</para>
		/// <para>将针对每个邻域测试增加手动间隔的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchDistanceIncrement { get; set; }

		/// <summary>
		/// <para>Number of Increments</para>
		/// <para>使用手动间隔时要测试的邻域大小的数量。 第一个邻域大小是最小相邻要素数或最小搜索距离参数的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 20)]
		public object? NumberOfIncrements { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>将用于用户定义的邻域类型的相邻要素数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>将用于用户定义的邻域类型的距离范围的大小。 此距离内的所有要素都将作为局部模型中的相邻要素包含在内。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? DistanceBand { get; set; }

		/// <summary>
		/// <para>Number of Neighbors for Golden Search</para>
		/// <para>单个解释变量的自定义 黄金搜索选项。 对于要自定义的每个解释变量，请在列中提供变量、最小相邻要素数和最大相邻要素数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? NumberOfNeighborsGolden { get; set; }

		/// <summary>
		/// <para>Number of Neighbors for Manual Intervals</para>
		/// <para>单个解释变量的自定义手动间隔选项。 对于要自定义的每个解释变量，请在列中提供最小相邻要素数、相邻要素的数目增量以及增量数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? NumberOfNeighborsManual { get; set; }

		/// <summary>
		/// <para>User Defined Number of Neighbors</para>
		/// <para>单个解释变量的自定义用户定义选项。 对于要自定义的每个解释变量，请提供相邻要素的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? NumberOfNeighborsDefined { get; set; }

		/// <summary>
		/// <para>Search Distance for Golden Search</para>
		/// <para>单个解释变量的自定义黄金搜索选项。 对于要自定义的每个解释变量，请在列中提供变量、最小搜索距离和最大搜索距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? DistanceGolden { get; set; }

		/// <summary>
		/// <para>Search Distance for Manual Intervals</para>
		/// <para>单个解释变量的自定义手动间隔选项。 对于要自定义的每个变量，请在列中提供变量、最小搜索距离、搜索距离增量和增量数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? DistanceManual { get; set; }

		/// <summary>
		/// <para>User Defined Search Distance</para>
		/// <para>单个解释变量的自定义用户定义选项。 对于要自定义的每个变量，请在列中提供变量和距离范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? DistanceDefined { get; set; }

		/// <summary>
		/// <para>Prediction Locations</para>
		/// <para>具有将计算评估值的位置的要素类。 此数据集中的每个要素都应包含指定的每个解释变量的值。 将使用针对输入要素类数据进行校准的模型来评估这些要素的因变量。 这些要素位置应该位于与输入要素相同的研究区域内，或接近该研究区域（位于 115% 范围内）。</para>
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
		/// <para>预测位置中与输入要素中的相应解释变量匹配的解释变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>将接收每个预测位置的因变量估计数的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object? OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Robust Prediction</para>
		/// <para>用于指定将在预测计算中使用的要素。</para>
		/// <para>选中 - 值高于平均值（异常值）3 个标准偏差的要素以及权重为 0（空间异常值）的要素将从预测计算中排除，但将在输出要素类中接收预测。 这是默认设置。</para>
		/// <para>未选中 - 将在预测计算中使用每个要素。</para>
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
		/// <para>Output Neighborhood Table</para>
		/// <para>包含 MGWR 模型的输出统计数据的表。 输出中将包含估计带宽或相邻要素数目的条形图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object? OutputTable { get; set; }

		/// <summary>
		/// <para>Coefficient Raster Workspace</para>
		/// <para>将创建系数栅格的工作空间。 如果提供了此工作空间，则会为截距及各解释变量创建栅格。 仅当具有 Desktop Advanced 许可时，此参数才可用。 如果提供了目录，则栅格将为 TIFF (.tif) 栅格类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[Category("Additional Options")]
		public object? CoefficientRasterWorkspace { get; set; }

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
		public object? Scale { get; set; } = "true";

		/// <summary>
		/// <para>Coefficient Raster Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? CoefficientRasterLayers { get; set; }

		/// <summary>
		/// <para>Output Layer Group</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutputLayerGroup { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MGWR SetEnviroment(object? cellSize = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>连续—该因变量表示连续值。 这是默认设置。</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("连续")]
			Continuous,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>相邻要素的数目—邻域大小将是每个要素的最近相邻要素的指定数量。 在要素密集的位置，邻域的空间范围将会较小；在要素稀疏的位置，邻域的空间范围将会较大。</para>
			/// </summary>
			[GPValue("NUMBER_OF_NEIGHBORS")]
			[Description("相邻要素的数目")]
			Number_of_Neighbors,

			/// <summary>
			/// <para>距离范围—邻域大小将是每个要素的恒定或固定距离。</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("距离范围")]
			Distance_Band,

		}

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// </summary>
		public enum NeighborhoodSelectionMethodEnum 
		{
			/// <summary>
			/// <para>黄金搜索—最佳距离或相邻要素数目将通过使用黄金搜索算法来最小化 AICc 值进行确定。</para>
			/// </summary>
			[GPValue("GOLDEN_SEARCH")]
			[Description("黄金搜索")]
			Golden_Search,

			/// <summary>
			/// <para>手动间隔—系统将通过测试值范围和选择具有最小 AICc 的值来确定距离或相邻要素数目。 如果邻域类型参数设置为距离范围，则此范围的最小值将由最小搜索距离参数提供。 随后系统会为最小值增加搜索距离增量参数中指定的值。 该操作将重复增量数参数所指定的次数。 如果邻域类型参数设置为相邻要素的数目，则最小值、增量大小和增量数将分别由最小相邻要素数、相邻要素的数目增量和增量数参数提供。</para>
			/// </summary>
			[GPValue("MANUAL_INTERVALS")]
			[Description("手动间隔")]
			Manual_Intervals,

			/// <summary>
			/// <para>用户定义—邻域大小将由相邻要素的数目参数或距离范围参数指定。</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("用户定义")]
			User_Defined,

		}

		/// <summary>
		/// <para>Distance Unit</para>
		/// </summary>
		public enum DistanceUnitEnum 
		{
			/// <summary>
			/// <para>美国测量英尺—距离将以美国测量英尺为单位进行测量。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("美国测量英尺")]
			US_Survey_Feet,

			/// <summary>
			/// <para>米—距离将以米为单位进行测量。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—距离将以千米为单位进行测量。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>美国测量英里—距离将以美国测量英里为单位进行测量。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("美国测量英里")]
			US_Survey_Miles,

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
