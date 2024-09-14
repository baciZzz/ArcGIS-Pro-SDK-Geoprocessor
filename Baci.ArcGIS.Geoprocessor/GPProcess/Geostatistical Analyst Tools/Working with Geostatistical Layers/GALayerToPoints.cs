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
	/// <para>GA Layer To Points</para>
	/// <para>GA 图层转点</para>
	/// <para>将地统计图层导出为点。 该工具还可用于预测未测量位置的值或验证在测量位置所做的预测。</para>
	/// </summary>
	public class GALayerToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </param>
		/// <param name="InLocations">
		/// <para>Input point observation locations</para>
		/// <para>将执行预测或验证的点位置。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output statistics at point locations</para>
		/// <para>包含预测值或预测值和验证结果的输出要素类。</para>
		/// <para>此要素类中的字段可能包括以下字段（如适用）：</para>
		/// <para>Source_ID (源 ID) - 输入观测点位置中源要素的对象 ID。</para>
		/// <para>使用的输入数据集的要素或对象标识符。</para>
		/// <para>Included (包括) - 表示是否为此要素计算预测值。 此字段中的值可为以下一种：</para>
		/// <para>Yes - 此时进行预测没有问题。</para>
		/// <para>Not enough neighbors - 相邻点数不足而无法进行预测。</para>
		/// <para>Weight parameter is too small - 权重参数太小。</para>
		/// <para>Overfilling - 浮点计算溢出。</para>
		/// <para>Problem with data transformation - 要变换的值超出所选变换支持的范围（仅使用克里金法）。</para>
		/// <para>No explanatory rasters - 无法计算该值，因为有一个解释变量处于未定义状态。 该点可在至少一个解释变量栅格范围之外，或该点可在至少一个解释变量栅格中的 NoData 像元的顶部。 此情况仅适用于 EBK 回归预测模型。</para>
		/// <para>Predicted (预测值) - 在此位置的预测值。</para>
		/// <para>Error (误差) - 预测值减去验证字段中的值。</para>
		/// <para>StdError (标准误差) - 克里金法标准误差。</para>
		/// <para>Stdd_Error (标准化误差) - 标准预测误差。 理想情况下，标准预测误差呈正态分布。</para>
		/// <para>NormValue (正态值) - 对应于正态 QQ 图中标准预测误差（y 轴）的正态分布值（x 轴）。</para>
		/// <para>CRPS (连续分级概率评分) - 这是一种诊断方法，用于测量预测的累积分布函数与每个已观测数据值之间的偏差。 该值应尽可能小。 该诊断方法优于交叉验证诊断方法，因为它将数据与整个分布进行比较而不是与单点预测进行比较。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。</para>
		/// <para>Interval90 (90% 区间内) - 表示验证点是否位于 90% 置信区间。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。 如果模型与数据相符，则约 90% 的要素应位于 90% 置信区间内。 此字段可能具有下列值：</para>
		/// <para>Yes - 验证点位于 90% 置信区间内。</para>
		/// <para>No - 验证点不在 90% 置信区间内。</para>
		/// <para>Excluded - 无法在该位置生成预测值。</para>
		/// <para>Interval95 (95% 区间内) - 表示验证点是否位于 95% 置信区间。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。 如果模型与数据相符，则约 95% 的要素应位于 95% 置信区间内。 此字段可能具有下列值：</para>
		/// <para>Yes - 验证点位于 95% 置信区间内。</para>
		/// <para>No - 验证点不在 95% 置信区间内。</para>
		/// <para>Excluded - 无法在该位置生成预测值。</para>
		/// <para>QuanVal (验证分位数) - 针对预测值分布的要素测量值的分位数。 该值的范围在 0 到 1 之间，接近 0 的值表示测量值位于分布的最左侧端，接近 1 的值表示测量值位于分布的最右侧端。 如果很多值都位于两端，这表示预测值分布并未完美体现数据模型，部分插值参数需进行更改。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。</para>
		/// </param>
		public GALayerToPoints(object InGeostatLayer, object InLocations, object OutFeatureClass)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.InLocations = InLocations;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GA 图层转点</para>
		/// </summary>
		public override string DisplayName() => "GA 图层转点";

		/// <summary>
		/// <para>Tool Name : GALayerToPoints</para>
		/// </summary>
		public override string ToolName() => "GALayerToPoints";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayerToPoints</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayerToPoints";

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
		public override object[] Parameters() => new object[] { InGeostatLayer, InLocations, ZField!, OutFeatureClass, AppendAllFields!, ElevationField!, ElevationUnits! };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Input point observation locations</para>
		/// <para>将执行预测或验证的点位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InLocations { get; set; }

		/// <summary>
		/// <para>Field to validate on</para>
		/// <para>如果此字段留空，则在相应点位置上进行预测。 如果选中此字段，则在点位置上进行预测，并将预测结果与点位置的 Z_value_field 值进行比较，然后执行验证分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[ExcludeField("Predicted", "StdError", "Error", "Stdd_Error", "NormValue", "Source_ID", "Included")]
		public object? ZField { get; set; }

		/// <summary>
		/// <para>Output statistics at point locations</para>
		/// <para>包含预测值或预测值和验证结果的输出要素类。</para>
		/// <para>此要素类中的字段可能包括以下字段（如适用）：</para>
		/// <para>Source_ID (源 ID) - 输入观测点位置中源要素的对象 ID。</para>
		/// <para>使用的输入数据集的要素或对象标识符。</para>
		/// <para>Included (包括) - 表示是否为此要素计算预测值。 此字段中的值可为以下一种：</para>
		/// <para>Yes - 此时进行预测没有问题。</para>
		/// <para>Not enough neighbors - 相邻点数不足而无法进行预测。</para>
		/// <para>Weight parameter is too small - 权重参数太小。</para>
		/// <para>Overfilling - 浮点计算溢出。</para>
		/// <para>Problem with data transformation - 要变换的值超出所选变换支持的范围（仅使用克里金法）。</para>
		/// <para>No explanatory rasters - 无法计算该值，因为有一个解释变量处于未定义状态。 该点可在至少一个解释变量栅格范围之外，或该点可在至少一个解释变量栅格中的 NoData 像元的顶部。 此情况仅适用于 EBK 回归预测模型。</para>
		/// <para>Predicted (预测值) - 在此位置的预测值。</para>
		/// <para>Error (误差) - 预测值减去验证字段中的值。</para>
		/// <para>StdError (标准误差) - 克里金法标准误差。</para>
		/// <para>Stdd_Error (标准化误差) - 标准预测误差。 理想情况下，标准预测误差呈正态分布。</para>
		/// <para>NormValue (正态值) - 对应于正态 QQ 图中标准预测误差（y 轴）的正态分布值（x 轴）。</para>
		/// <para>CRPS (连续分级概率评分) - 这是一种诊断方法，用于测量预测的累积分布函数与每个已观测数据值之间的偏差。 该值应尽可能小。 该诊断方法优于交叉验证诊断方法，因为它将数据与整个分布进行比较而不是与单点预测进行比较。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。</para>
		/// <para>Interval90 (90% 区间内) - 表示验证点是否位于 90% 置信区间。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。 如果模型与数据相符，则约 90% 的要素应位于 90% 置信区间内。 此字段可能具有下列值：</para>
		/// <para>Yes - 验证点位于 90% 置信区间内。</para>
		/// <para>No - 验证点不在 90% 置信区间内。</para>
		/// <para>Excluded - 无法在该位置生成预测值。</para>
		/// <para>Interval95 (95% 区间内) - 表示验证点是否位于 95% 置信区间。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。 如果模型与数据相符，则约 95% 的要素应位于 95% 置信区间内。 此字段可能具有下列值：</para>
		/// <para>Yes - 验证点位于 95% 置信区间内。</para>
		/// <para>No - 验证点不在 95% 置信区间内。</para>
		/// <para>Excluded - 无法在该位置生成预测值。</para>
		/// <para>QuanVal (验证分位数) - 针对预测值分布的要素测量值的分位数。 该值的范围在 0 到 1 之间，接近 0 的值表示测量值位于分布的最左侧端，接近 1 的值表示测量值位于分布的最右侧端。 如果很多值都位于两端，这表示预测值分布并未完美体现数据模型，部分插值参数需进行更改。 仅针对经验贝叶斯克里金法和 EBK 回归预测工具模型创建该字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// <para>确定是否所有字段都将从输入要素复制到输出要素类。</para>
		/// <para>选中 - 输入要素的所有字段都将复制到输出要素类。这是默认设置。</para>
		/// <para>未选中 - 仅复制要素 ID 值，并在输出要素类中将其命名为 Source_ID。</para>
		/// <para><see cref="AppendAllFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendAllFields { get; set; } = "true";

		/// <summary>
		/// <para>Elevation field</para>
		/// <para>包含每个输入点的高程的字段。 该参数仅适用于 3D 地统计模型。 如果高程值存储为 Shape.Z 中的几何属性，则建议您使用该字段。 如果高程存储在属性字段中，则高程必须表示距海平面的距离。 正值表示海平面以上的距离，负值表示海平面以下的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? ElevationField { get; set; }

		/// <summary>
		/// <para>Elevation field units</para>
		/// <para>高程字段的单位。 该参数仅适用于 3D 地统计模型。 如果提供 Shape.Z 作为高程字段，则单位将自动匹配垂直坐标系的 Z 单位。</para>
		/// <para>美国测量英寸—高程以美制英寸为单位。</para>
		/// <para>美国测量英尺—高程以美制英尺为单位。</para>
		/// <para>美国测量码—高程以美制码为单位。</para>
		/// <para>美国测量英里—高程以美制英里为单位。</para>
		/// <para>美国测量海里—高程以美制海里为单位。</para>
		/// <para>毫米—高程以毫米为单位。</para>
		/// <para>厘米—高程以厘米为单位。</para>
		/// <para>分米—高程以分米为单位。</para>
		/// <para>米—高程以米为单位。</para>
		/// <para>千米—高程以千米为单位。</para>
		/// <para>国际英寸—高程以国际英寸为单位。</para>
		/// <para>国际英尺—高程以国际英尺为单位。</para>
		/// <para>国际码—高程以国际码为单位。</para>
		/// <para>法定英里—高程以法定英里为单位。</para>
		/// <para>国际海里—高程以国际海里为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ElevationUnits { get; set; } = "METER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToPoints SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// </summary>
		public enum AppendAllFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL")]
			ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FID_ONLY")]
			FID_ONLY,

		}

#endregion
	}
}
