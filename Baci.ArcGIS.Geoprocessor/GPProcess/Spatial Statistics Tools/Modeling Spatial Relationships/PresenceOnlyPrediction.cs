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
	/// <para>Presence-only Prediction (MaxEnt)</para>
	/// <para>仅存在预测 (MaxEnt)</para>
	/// <para>使用最大熵方法 (MaxEnt) 对已知存在位置和解释变量的现象的存在进行建模。 该工具提供包含存在概率的输出要素和栅格，可应用于仅存在已知和缺失未知的问题。</para>
	/// </summary>
	public class PresenceOnlyPrediction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>点要素表示已知发生感兴趣现象的位置。</para>
		/// </param>
		public PresenceOnlyPrediction(object InputPointFeatures)
		{
			this.InputPointFeatures = InputPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 仅存在预测 (MaxEnt)</para>
		/// </summary>
		public override string DisplayName() => "仅存在预测 (MaxEnt)";

		/// <summary>
		/// <para>Tool Name : PresenceOnlyPrediction</para>
		/// </summary>
		public override string ToolName() => "PresenceOnlyPrediction";

		/// <summary>
		/// <para>Tool Excute Name : stats.PresenceOnlyPrediction</para>
		/// </summary>
		public override string ExcuteName() => "stats.PresenceOnlyPrediction";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPointFeatures, ContainsBackground!, PresenceIndicatorField!, ExplanatoryVariables!, DistanceFeatures!, ExplanatoryRasters!, BasisExpansionFunctions!, NumberKnots!, StudyAreaType!, StudyAreaPolygon!, SpatialThinning!, ThinningDistanceBand!, NumberOfIterations!, RelativeWeight!, LinkFunction!, PresenceProbabilityCutoff!, OutputTrainedFeatures!, OutputTrainedRaster!, OutputResponseCurveTable!, OutputSensitivityTable!, FeaturesToPredict!, OutputPredFeatures!, OutputPredRaster!, ExplanatoryVariableMatching!, ExplanatoryDistanceMatching!, ExplanatoryRastersMatching!, AllowPredictionsOutsideOfDataRanges!, ResamplingScheme!, NumberOfGroups! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>点要素表示已知发生感兴趣现象的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Contains Background Points</para>
		/// <para>指定输入点要素是否包含背景点。</para>
		/// <para>如果输入点不包含背景点，该工具将使用解释训练栅格中的像元生成背景点。 该工具使用背景点对未知位置的景观特征进行建模，并将它们与已知存在位置的景观特征进行比较。 因此，可以将背景点视为研究区域。 通常情况下，这些是未知感兴趣现象存在的位置。 然而，如果任何关于背景点的信息是已知的，则可以使用存在与背景的相对权重参数来指示此内容。</para>
		/// <para>选中 - 输入点要素包含背景点。</para>
		/// <para>未选中 - 输入点要素不包含背景点。 这是默认设置。</para>
		/// <para><see cref="ContainsBackgroundEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContainsBackground { get; set; } = "false";

		/// <summary>
		/// <para>Presence Indicator Field</para>
		/// <para>来自输入点要素的字段，其中包含指示每个点为存在 (1) 或背景 (0) 的二进制值。 字段必须为数值字段（短整型、长整型、浮点型、双精度型）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? PresenceIndicatorField { get; set; }

		/// <summary>
		/// <para>Explanatory Training Variables</para>
		/// <para>表示解释变量的字段列表，这些变量将有助于预测存在概率。 可以指定每个变量是分类变量还是数值变量。 选中代表类或类别（例如土地覆被）的每个变量的分类复选框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Training Distance Features</para>
		/// <para>将用于自动创建解释变量的要素图层或要素类列表，这些解释变量表示从输入点要素到最近提供的距离要素的距离。 如果输入解释训练距离要素为面要素或线要素，则距离属性将计算为最近线段和点之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point", "Polyline")]
		[FeatureType("Simple")]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Training Rasters</para>
		/// <para>将用于在模型中自动创建解释训练变量的栅格列表，其值是从栅格中提取的。 对于输入点要素中的每个要素（存在点和背景点），将在此确切位置提取栅格像元的值。</para>
		/// <para>提取连续栅格的栅格值时，将使用双线性栅格重采样。 从分类栅格中提取栅格值时，将使用最邻近分配法。</para>
		/// <para>可以指定每个栅格值是分类变量还是数值变量。 选中代表类或类别（例如土地覆被）的每个栅格的分类复选框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Explanatory Variable Expansions (Basis Functions)</para>
		/// <para>指定将用于变换提供的解释变量以在模型中使用的基函数。 如果选择了多个基函数，该工具将生成多个变换后的变量并尝试在模型中使用它们。</para>
		/// <para>原始（线性）—将应用对输入变量的线性变换。 这是默认设置</para>
		/// <para>成对交互（乘积）—将使用连续解释变量的成对乘法，生成交互变量。 此选项仅在提供了多个解释变量时可用。</para>
		/// <para>平滑步长（铰链）—将连续解释变量值转换为两个段，一个静态段（全为 0 或 1）和一个线性函数（增加或减少）。</para>
		/// <para>离散步长（阈值）—连续解释变量值将转换为由 0 和 1 组成的二进制变量。</para>
		/// <para>平方（二次）—将返回每个连续解释变量值的平方。</para>
		/// <para><see cref="BasisExpansionFunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? BasisExpansionFunctions { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Number of Knots</para>
		/// <para>铰链和阈值解释变量扩展将使用的节数。 该值控制创建的阈值数量，并将使用每个阈值创建多个解释变量扩展。 该值必须介于 2 到 50 之间。 默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 50)]
		public object? NumberKnots { get; set; } = "10";

		/// <summary>
		/// <para>Study Area</para>
		/// <para>指定将用于定义当输入点要素不包含背景点时可能存在的位置的研究区域类型。</para>
		/// <para>凸包—将使用包含输入点要素中所有存在点的最小凸多边形。 这是默认设置</para>
		/// <para>栅格范围—将使用解释训练栅格的相交范围。</para>
		/// <para>面研究区域—将使用由面要素类定义的自定义研究区域。</para>
		/// <para><see cref="StudyAreaTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StudyAreaType { get; set; } = "CONVEX_HULL";

		/// <summary>
		/// <para>Study Area Polygon</para>
		/// <para>包含定义自定义研究区域的面要素类。 输入点要素必须位于面要素覆盖的自定义研究区域内。 一个研究区域可以由多个面组成。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? StudyAreaPolygon { get; set; }

		/// <summary>
		/// <para>Apply Spatial Thinning</para>
		/// <para>指定在训练模型之前是否将空间细化应用于存在点和背景点。</para>
		/// <para>空间细化通过移除点并确保剩余点具有最小最近邻距离（在最小最近邻参数中设置）来帮助减少采样偏差。 空间细化也适用于背景点，无论它们是在输入点要素中提供还是由工具生成。</para>
		/// <para>选中 - 将应用空间细化。</para>
		/// <para>未选中 - 不应用空间细化。 这是默认设置。</para>
		/// <para><see cref="SpatialThinningEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SpatialThinning { get; set; } = "false";

		/// <summary>
		/// <para>Minimum Nearest Neighbor Distance</para>
		/// <para>应用空间细化时任何两个存在点或任何两个背景点之间的最小距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? ThinningDistanceBand { get; set; }

		/// <summary>
		/// <para>Number of Iterations for Thinning</para>
		/// <para>将用于寻找最佳空间细化解决方案的运行次数，力求在保持尽可能多的存在点和背景点的同时，确保任何两个存在点或两个背景点之间的距离均不在指定的最小最近邻距离参数值内。 最少可能是 1 次迭代，最多可能是 50 次迭代。 默认值为 10。</para>
		/// <para>此参数仅适用于应用于输入点要素中的存在点和背景点的空间细化。 应用于从栅格单元生成的背景点的空间细化通过将栅格单元重新采样到指定的最小最近距离参数值来进行空间细化，而无需迭代以获得最佳解决方案。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 50)]
		public object? NumberOfIterations { get; set; } = "10";

		/// <summary>
		/// <para>Relative Weight of Presence to Background</para>
		/// <para>一个介于 1 和 100 之间的值，用于指定存在点与背景点的相对信息权重。 默认值为 100。</para>
		/// <para>较高的值表明存在点是主要的信息来源；背景点是否代表存在或缺失是未知的，背景点在模型中的权重较低。 较低的值表示背景点也提供可与存在点结合使用的有价值的信息；背景点代表缺失的可信度更高，它们的信息可以在模型中用作缺失位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Model Options")]
		public object? RelativeWeight { get; set; } = "100";

		/// <summary>
		/// <para>Presence Probability Transformation (Link Function)</para>
		/// <para>指定将模型的无界输出转换为 0 到 1 之间的数字的函数。 该值可以解释为该位置的存在概率。 每个选项将相同的连续值转换为不同的概率。</para>
		/// <para>C-log-log—C-log-log 链接函数将用于将预测转换为概率。 当现象的存在和位置明确时，建议使用此选项，例如，在模拟固定植物物种的存在时。 这是默认设置。</para>
		/// <para>逻辑—逻辑链接函数将用于将预测转换为概率。 当现象的存在和位置不明确时，建议使用此选项，例如，在模拟迁徙动物物种的存在时。</para>
		/// <para><see cref="LinkFunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Options")]
		public object? LinkFunction { get; set; }

		/// <summary>
		/// <para>Presence Probability Cutoff</para>
		/// <para>中断值介于 0.01 和 0.99 之间，用于确定哪些概率与结果分类中的存在相对应。 中断值用于使用训练数据和已知存在点帮助评估模型的性能。 在地理处理消息和输出训练要素中提供分类诊断信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 0.98999999999999999)]
		[Category("Advanced Model Options")]
		public object? PresenceProbabilityCutoff { get; set; } = "0.5";

		/// <summary>
		/// <para>Output Trained Features</para>
		/// <para>将包含模型训练中使用的所有要素和解释变量的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Training Outputs")]
		public object? OutputTrainedFeatures { get; set; }

		/// <summary>
		/// <para>Output Trained Raster</para>
		/// <para>具有像元值的输出栅格，使用所选链接函数指示存在概率。 默认像元大小为解释训练栅格中像元大小的最大值。 仅当输入点要素不包含背景点时，才能创建输出训练栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Training Outputs")]
		public object? OutputTrainedRaster { get; set; }

		/// <summary>
		/// <para>Output Response Curve Table</para>
		/// <para>输出表将包含来自训练模型的诊断，这些诊断表明在考虑模型中所有其他解释变量的平均影响的情况下，每个解释变量对存在概率的影响。</para>
		/// <para>该表将有最多两个部分依赖性图的派生图表：一组连续变量的折线图和一组分类变量的条形图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Training Outputs")]
		public object? OutputResponseCurveTable { get; set; }

		/// <summary>
		/// <para>Output Sensitivity Table</para>
		/// <para>当概率存在中断值从 0 变为 1 时，输出表将包含训练模型准确性的诊断信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Training Outputs")]
		public object? OutputSensitivityTable { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>表示将进行预测的位置的要素类。 要素类必须包含从输入点要素中使用的任何提供的解释变量字段。</para>
		/// <para>使用空间细化时，可以使用原始输入点要素作为输入预测要素来接收对整个数据集的预测。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[Category("Prediction Options")]
		public object? FeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Output Prediction Features</para>
		/// <para>输出要素类将包含应用于输入预测要素的预测模型的结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object? OutputPredFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Raster</para>
		/// <para>包含匹配解释栅格的每个像元的预测结果的输出栅格。 默认像元大小为解释训练栅格中像元大小的最大值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Prediction Options")]
		public object? OutputPredRaster { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>输入点要素和输入预测要素的匹配解释变量字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryVariableMatching { get; set; }

		/// <summary>
		/// <para>Match Distance Features</para>
		/// <para>用于训练和预测的匹配距离要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryDistanceMatching { get; set; }

		/// <summary>
		/// <para>Match Explanatory Rasters</para>
		/// <para>用于训练和预测的匹配栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryRastersMatching { get; set; }

		/// <summary>
		/// <para>Allow Predictions Outside of Data Ranges</para>
		/// <para>指定当解释变量值超出训练中使用的值范围时，预测是否允许外推。</para>
		/// <para>选中 - 预测将允许外推超出训练中使用的值范围。 这是默认设置。</para>
		/// <para>未选中 - 预测不允许外推超出训练中使用的值范围。</para>
		/// <para><see cref="AllowPredictionsOutsideOfDataRangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Prediction Options")]
		public object? AllowPredictionsOutsideOfDataRanges { get; set; } = "true";

		/// <summary>
		/// <para>Resampling Scheme</para>
		/// <para>指定将用于执行预测模型的交叉验证的方法。 交叉验证会在模型训练期间排除一部分数据，并在模型训练后使用该数据来测试模型的性能。</para>
		/// <para>无—不会执行交叉验证。 这是默认设置</para>
		/// <para>随机—点将被随机分组，在进行交叉验证时每组将被排除一次。 在组数参数中指定组的数量。</para>
		/// <para><see cref="ResamplingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Validation Options")]
		public object? ResamplingScheme { get; set; } = "NONE";

		/// <summary>
		/// <para>Number of Groups</para>
		/// <para>将用于随机重采样方案的交叉验证的组数。 输出训练要素中的字段指示每个点分配到的组。 默认值为 3。 最少 2 组，最多 10 组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 10)]
		[Category("Validation Options")]
		public object? NumberOfGroups { get; set; } = "3";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PresenceOnlyPrediction SetEnviroment(object? cellSize = null , object? cellSizeProjectionMethod = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? randomGenerator = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contains Background Points</para>
		/// </summary>
		public enum ContainsBackgroundEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESENCE_AND_BACKGROUND_POINTS")]
			PRESENCE_AND_BACKGROUND_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESENCE_ONLY_POINTS")]
			PRESENCE_ONLY_POINTS,

		}

		/// <summary>
		/// <para>Explanatory Variable Expansions (Basis Functions)</para>
		/// </summary>
		public enum BasisExpansionFunctionsEnum 
		{
			/// <summary>
			/// <para>原始（线性）—将应用对输入变量的线性变换。 这是默认设置</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("原始（线性）")]
			LINEAR,

			/// <summary>
			/// <para>平方（二次）—将返回每个连续解释变量值的平方。</para>
			/// </summary>
			[GPValue("QUADRATIC")]
			[Description("平方（二次）")]
			QUADRATIC,

			/// <summary>
			/// <para>成对交互（乘积）—将使用连续解释变量的成对乘法，生成交互变量。 此选项仅在提供了多个解释变量时可用。</para>
			/// </summary>
			[GPValue("PRODUCT")]
			[Description("成对交互（乘积）")]
			PRODUCT,

			/// <summary>
			/// <para>平滑步长（铰链）—将连续解释变量值转换为两个段，一个静态段（全为 0 或 1）和一个线性函数（增加或减少）。</para>
			/// </summary>
			[GPValue("HINGE")]
			[Description("平滑步长（铰链）")]
			HINGE,

			/// <summary>
			/// <para>离散步长（阈值）—连续解释变量值将转换为由 0 和 1 组成的二进制变量。</para>
			/// </summary>
			[GPValue("THRESHOLD")]
			[Description("离散步长（阈值）")]
			THRESHOLD,

		}

		/// <summary>
		/// <para>Study Area</para>
		/// </summary>
		public enum StudyAreaTypeEnum 
		{
			/// <summary>
			/// <para>凸包—将使用包含输入点要素中所有存在点的最小凸多边形。 这是默认设置</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("凸包")]
			Convex_hull,

			/// <summary>
			/// <para>栅格范围—将使用解释训练栅格的相交范围。</para>
			/// </summary>
			[GPValue("RASTER_EXTENT")]
			[Description("栅格范围")]
			Raster_extent,

			/// <summary>
			/// <para>面研究区域—将使用由面要素类定义的自定义研究区域。</para>
			/// </summary>
			[GPValue("STUDY_POLYGON")]
			[Description("面研究区域")]
			Polygon_study_area,

		}

		/// <summary>
		/// <para>Apply Spatial Thinning</para>
		/// </summary>
		public enum SpatialThinningEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("THINNING")]
			THINNING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_THINNING")]
			NO_THINNING,

		}

		/// <summary>
		/// <para>Presence Probability Transformation (Link Function)</para>
		/// </summary>
		public enum LinkFunctionEnum 
		{
			/// <summary>
			/// <para>C-log-log—C-log-log 链接函数将用于将预测转换为概率。 当现象的存在和位置明确时，建议使用此选项，例如，在模拟固定植物物种的存在时。 这是默认设置。</para>
			/// </summary>
			[GPValue("CLOGLOG")]
			[Description("C-log-log")]
			CLOGLOG,

			/// <summary>
			/// <para>逻辑—逻辑链接函数将用于将预测转换为概率。 当现象的存在和位置不明确时，建议使用此选项，例如，在模拟迁徙动物物种的存在时。</para>
			/// </summary>
			[GPValue("LOGISTIC")]
			[Description("逻辑")]
			Logistic,

		}

		/// <summary>
		/// <para>Allow Predictions Outside of Data Ranges</para>
		/// </summary>
		public enum AllowPredictionsOutsideOfDataRangesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOWED")]
			ALLOWED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_ALLOWED")]
			NOT_ALLOWED,

		}

		/// <summary>
		/// <para>Resampling Scheme</para>
		/// </summary>
		public enum ResamplingSchemeEnum 
		{
			/// <summary>
			/// <para>无—不会执行交叉验证。 这是默认设置</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>随机—点将被随机分组，在进行交叉验证时每组将被排除一次。 在组数参数中指定组的数量。</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("随机")]
			Random,

		}

#endregion
	}
}
