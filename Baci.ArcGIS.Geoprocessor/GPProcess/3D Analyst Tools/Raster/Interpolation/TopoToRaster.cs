using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Topo to Raster</para>
	/// <para>地形转栅格</para>
	/// <para>将点、线和面数据插值成符合真实地表的栅格表面。</para>
	/// </summary>
	public class TopoToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopoFeatures">
		/// <para>Input feature data</para>
		/// <para>包含要插值到表面栅格中的 z 值的输入要素。</para>
		/// <para>每个要素输入均可具有一个包含 z 值的特定字段并可指定为六种输入类型之一。</para>
		/// <para>要素图层 - 输入要素数据集。</para>
		/// <para>字段 - 用于存储属性的字段名称（适当时）。</para>
		/// <para>类型 - 输入要素数据集的类型。</para>
		/// <para>共有九种支持的输入类型：</para>
		/// <para>点高程 - 表示表面高程的点要素类。“字段”用于存储点的高程。</para>
		/// <para>Contour - 表示高程等值线的线要素类。“字段” 用于存储等值线的高程。</para>
		/// <para>Stream - 河流位置的线要素类。所有弧线必须定向为指向下游。要素类中应该仅包含单条弧线组成的河流。此输入类型没有“字段”选项。</para>
		/// <para>Sink - 表示已知地形凹陷的点要素类。此工具不会试图将任何明确指定为汇的点从分析中移除。所用“字段”应存储了合理的汇高程。如果选择了 NONE，将仅使用汇的位置。</para>
		/// <para>Boundary - 包含表示输出栅格外边界的单个面的要素类。在输出栅格中，位于此边界以外的像元将为 NoData。此选项可用于在创建最终输出栅格之前沿海岸线裁剪出水域。此输入类型没有“字段”选项。</para>
		/// <para>Lake - 指定湖泊位置的面要素类。湖面内的所有输出栅格像元均将指定为使用沿湖岸线所有像元高程值中最小的那个高程值。此输入类型没有“字段”选项。</para>
		/// <para>Cliff - 悬崖的线要素类。必须对悬崖线要素进行定向以使线的左侧位于悬崖的低侧，线的右侧位于悬崖的高侧。此输入类型没有“字段”选项。</para>
		/// <para>Exclusion - 其中的输入数据应被忽略的区域的面要素类。这些面允许从插值过程中移除高程数据。通常将其用于移除与堤壁和桥相关联的高程数据。这样就可以内插带有连续地形结构的基础山谷。此输入类型没有“字段”选项。</para>
		/// <para>Coast - 包含沿海地区轮廓的面要素类。位于这些面之外的最终输出栅格中的像元会被设置为小于用户所指定的最小高度限制的值。此输入类型没有“字段”选项。</para>
		/// </param>
		/// <param name="OutSurfaceRaster">
		/// <para>Output surface raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </param>
		public TopoToRaster(object InTopoFeatures, object OutSurfaceRaster)
		{
			this.InTopoFeatures = InTopoFeatures;
			this.OutSurfaceRaster = OutSurfaceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 地形转栅格</para>
		/// </summary>
		public override string DisplayName() => "地形转栅格";

		/// <summary>
		/// <para>Tool Name : TopoToRaster</para>
		/// </summary>
		public override string ToolName() => "TopoToRaster";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TopoToRaster</para>
		/// </summary>
		public override string ExcuteName() => "3d.TopoToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "tileSize", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTopoFeatures, OutSurfaceRaster, CellSize, Extent, Margin, MinimumZValue, MaximumZValue, Enforce, DataType, MaximumIterations, RoughnessPenalty, DiscreteErrorFactor, VerticalStandardError, Tolerance1, Tolerance2, OutStreamFeatures, OutSinkFeatures, OutDiagnosticFile, OutParameterFile, ProfilePenalty, OutResidualFeature, OutStreamCliffErrorFeature, OutContourErrorFeature };

		/// <summary>
		/// <para>Input feature data</para>
		/// <para>包含要插值到表面栅格中的 z 值的输入要素。</para>
		/// <para>每个要素输入均可具有一个包含 z 值的特定字段并可指定为六种输入类型之一。</para>
		/// <para>要素图层 - 输入要素数据集。</para>
		/// <para>字段 - 用于存储属性的字段名称（适当时）。</para>
		/// <para>类型 - 输入要素数据集的类型。</para>
		/// <para>共有九种支持的输入类型：</para>
		/// <para>点高程 - 表示表面高程的点要素类。“字段”用于存储点的高程。</para>
		/// <para>Contour - 表示高程等值线的线要素类。“字段” 用于存储等值线的高程。</para>
		/// <para>Stream - 河流位置的线要素类。所有弧线必须定向为指向下游。要素类中应该仅包含单条弧线组成的河流。此输入类型没有“字段”选项。</para>
		/// <para>Sink - 表示已知地形凹陷的点要素类。此工具不会试图将任何明确指定为汇的点从分析中移除。所用“字段”应存储了合理的汇高程。如果选择了 NONE，将仅使用汇的位置。</para>
		/// <para>Boundary - 包含表示输出栅格外边界的单个面的要素类。在输出栅格中，位于此边界以外的像元将为 NoData。此选项可用于在创建最终输出栅格之前沿海岸线裁剪出水域。此输入类型没有“字段”选项。</para>
		/// <para>Lake - 指定湖泊位置的面要素类。湖面内的所有输出栅格像元均将指定为使用沿湖岸线所有像元高程值中最小的那个高程值。此输入类型没有“字段”选项。</para>
		/// <para>Cliff - 悬崖的线要素类。必须对悬崖线要素进行定向以使线的左侧位于悬崖的低侧，线的右侧位于悬崖的高侧。此输入类型没有“字段”选项。</para>
		/// <para>Exclusion - 其中的输入数据应被忽略的区域的面要素类。这些面允许从插值过程中移除高程数据。通常将其用于移除与堤壁和桥相关联的高程数据。这样就可以内插带有连续地形结构的基础山谷。此输入类型没有“字段”选项。</para>
		/// <para>Coast - 包含沿海地区轮廓的面要素类。位于这些面之外的最终输出栅格中的像元会被设置为小于用户所指定的最小高度限制的值。此输入类型没有“字段”选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSATopoFeatures()]
		[GPCompositeDomain()]
		public object InTopoFeatures { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>输出插值后的表面栅格。</para>
		/// <para>其总为浮点栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Output extent</para>
		/// <para>输出栅格数据集的范围。</para>
		/// <para>插值可能会超出 x 和 y 坐标范围，在此范围之外的像元将为 NoData。要在输出栅格边界上获得最佳插值结果，四边的 x 和 y 坐标界限应该比输入数据的范围至少小 10 个像元。</para>
		/// <para>左 - 默认值为所有输入的最小 x 坐标值。</para>
		/// <para>下 - 默认值为所有输入的最小 y 坐标值。</para>
		/// <para>右 - 默认值为所有输入的最大 x 坐标值。</para>
		/// <para>上 - 默认值为所有输入的最大 y 坐标值。</para>
		/// <para>默认范围是输入要素数据所有范围中的最大范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Margin in cells</para>
		/// <para>在超出指定输出范围和边界外进行像元插值的距离。</para>
		/// <para>该值必须大于或等于 0（零）。默认值为 20。</para>
		/// <para>如果输出范围和边界要素数据集与输入数据的界限相同（默认值），则沿 DEM 边内插的值与相邻的 DEM 数据将无法很好的匹配。这是因为插值时使用的是四周均环绕输入数据的点，仅相当于栅格内一半点数的数据。通过像元间距选项可使输入数据超出这些界限从而应用于插值过程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Margin { get; set; } = "20";

		/// <summary>
		/// <para>Smallest z value to be used in interpolation</para>
		/// <para>插值所用的最小 z 值。</para>
		/// <para>默认值比所有输入值中最小的值低 20%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinimumZValue { get; set; }

		/// <summary>
		/// <para>Largest z value to be used in interpolation</para>
		/// <para>插值所用的最大 z 值。</para>
		/// <para>默认值比所有输入值中最大的值高 20%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumZValue { get; set; }

		/// <summary>
		/// <para>Drainage enforcement</para>
		/// <para>要应用的地形强化类型。</para>
		/// <para>可对地形强化选项进行设置以便移除所有汇或洼地，从而创建符合真实地表的 DEM。如果输入要素数据中已明确指出这些汇点，则这些洼地将不会被填充。</para>
		/// <para>强制—该算法将尝试移除遇到的所有汇，无论是“真”汇还是“伪”汇。这是默认设置。</para>
		/// <para>不强化—汇不会被填充。</para>
		/// <para>通过凹陷强化—输入要素数据中已指出为汇的点表示已知的地形凹陷并且将不会被更改。输入要素数据中未指出的所有汇均将视为伪汇，算法将尝试填充此汇。伪汇数量超过 8,000 个将导致工具无法使用。</para>
		/// <para><see cref="EnforceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Enforce { get; set; } = "ENFORCE";

		/// <summary>
		/// <para>Primary type of input data</para>
		/// <para>输入要素数据的主要高程数据类型。</para>
		/// <para>等值线—输入数据的主要类型为高程等值线。这是默认设置。</para>
		/// <para>点—输入的主要类型为点。</para>
		/// <para>指定相关的选项可优化河流和山脊生成期间所用搜索方法。</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "CONTOUR";

		/// <summary>
		/// <para>Maximum number of iterations</para>
		/// <para>插值迭代的最大次数。</para>
		/// <para>迭代次数必须大于零。通常，默认值 20 适合等值线数据也适合线数据。</para>
		/// <para>值 30 可清除少量的汇。在极少数情况下，设置成更高的值 (45–50) 可能适合于清除更多的汇或设置更多的山脊和河流。达到最大迭代次数后，各格网分辨率的迭代将停止。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object MaximumIterations { get; set; } = "20";

		/// <summary>
		/// <para>Roughness penalty</para>
		/// <para>作为粗糙度衡量指标的二阶导数平方积分。</para>
		/// <para>粗糙度惩罚系数必须大于等于零。如果主要输入数据类型为 等值线，则默认值为零。如果主要数据类型为 点，则默认值为 0.5。通常不建议使用更大的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		public object RoughnessPenalty { get; set; }

		/// <summary>
		/// <para>Discretisation error factor</para>
		/// <para>离散误差系数用于在将输入数据转换为栅格时调整平滑量。</para>
		/// <para>值必须大于零。正常的调整范围是 0.25 到 4，默认值为 1。值越小，数据的平滑处理就越少；而值越大，平滑处理也就越多。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object DiscreteErrorFactor { get; set; } = "1";

		/// <summary>
		/// <para>Vertical standard error</para>
		/// <para>输入数据 z 值的随机误差量。</para>
		/// <para>该值必须大于等于零。默认值为零。</para>
		/// <para>如果数据的垂直误差的方差一致性检验为显著随机（非系统），则垂直标准误差可设置为较小的正值。这种情况下，请将垂直标准误差设置为这些误差的标准差。对于大多数高程数据集，垂直误差应该设置为零，但当通过河流线数据对点数据进行栅格化时，可能会将其设置为较小的正值以稳定收敛。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object VerticalStandardError { get; set; } = "0";

		/// <summary>
		/// <para>Tolerance 1</para>
		/// <para>此容差可反映出高程点相对于表面地形的精度和密度。</para>
		/// <para>对于点数据集，请将容差设置为数据高度的标准误差。对于等值线数据集，请使用平均等值线间距的一半。</para>
		/// <para>该值必须大于等于零。如果数据类型是 等值线，则默认值为 2.5；如果数据类型是 点，则默认值为零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Tolerance1 { get; set; }

		/// <summary>
		/// <para>Tolerance 2</para>
		/// <para>此容差将通过极大的界限值防止产生地形间隙。</para>
		/// <para>值必须大于零。如果数据类型是 等值线，则默认值为 100；如果数据类型是 点，则默认值为 200。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Tolerance2 { get; set; }

		/// <summary>
		/// <para>Output stream polyline features</para>
		/// <para>河流折线要素和山脊线要素的输出线要素类。</para>
		/// <para>线要素创建于插值过程开始之时。它提供了插值表面的大致形态。此值可用于通过比较已知河流和山脊数据验证地形和形态的正确性。</para>
		/// <para>折线要素按如下方式编码：</para>
		/// <para>1. 不在悬崖上的输入河流线。</para>
		/// <para>2. 在悬崖上的输入河流线（瀑布）。</para>
		/// <para>3. 清除伪汇的地形强化。</para>
		/// <para>4. 从等值线拐角确定的河流线。</para>
		/// <para>5. 从等值线拐角确定的山脊线。</para>
		/// <para>6. 未使用代码。</para>
		/// <para>7. 数据河流线边条件。</para>
		/// <para>8. 未使用代码。</para>
		/// <para>9. 表示大型高程数据间隙的线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutStreamFeatures { get; set; }

		/// <summary>
		/// <para>Output remaining sink point features</para>
		/// <para>遗留汇点要素的输出点要素类。</para>
		/// <para>这些汇未在汇输入要素数据中进行指定且在地形强化期间未被清除。调整容差值（容差 1 和容差 2）可减少遗留汇的数量。遗留汇通常用于指示输入数据中地形加强算法无法解决的误差。这是检测微小高程误差的有效方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutSinkFeatures { get; set; }

		/// <summary>
		/// <para>Output diagnostic file</para>
		/// <para>此输出诊断文件列出了使用的所有输入和参数以及各分辨率和迭代中清除的汇数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		[Category("Optional outputs")]
		public object OutDiagnosticFile { get; set; }

		/// <summary>
		/// <para>Output parameter file</para>
		/// <para>此输出参数文件列出了使用的所有输入和参数，这些输入和参数可与通过文件实现地形转栅格结合使用以便再次运行插值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		[Category("Optional outputs")]
		public object OutParameterFile { get; set; }

		/// <summary>
		/// <para>Profile curvature roughness penalty</para>
		/// <para>剖面曲率粗糙度惩罚系数是一个可用于部分替换总曲率的局部自适应惩罚系数。</para>
		/// <para>使用高质量的等值线数据会获得良好的成果，但是对于质量差的数据，会导致收敛不稳定。对于无剖面曲率，设置为 0.0（默认值）；对于中等剖面曲率，设置为 0.5；对于最大剖面曲率，设置为 0.8。不建议并且也不应使用大于 0.8 的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[High(Allow = true, Value = 0.90000000000000002)]
		public object ProfilePenalty { get; set; }

		/// <summary>
		/// <para>Output residual point features</para>
		/// <para>由局部离散误差进行衡量的所有大高程残差的输出点要素类。</para>
		/// <para>应对所有大于 10 的比例缩放残差进行检查，查看输入高程和河流数据是否存在错误。大比例缩放残差表示输入高程数据和河流线数据之间存在冲突。这可能也与不良的自动地形强化有关。这些冲突可以通过在首次检查和纠正现有输入数据中的错误后提供附加的流线和/或点高程数据来进行修复。未大比例缩放的残差通常表示存在输入高程误差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutResidualFeature { get; set; }

		/// <summary>
		/// <para>Output stream and cliff error point features</para>
		/// <para>可能出现河流和悬崖错误的位置的输出点要素类。</para>
		/// <para>可从点要素类来识别其河流有闭合环、支流和悬崖上河流的位置。还可识别相邻像元与悬崖高低边不一致的悬崖。这可以理想地指出方向错误的悬崖。</para>
		/// <para>点按如下方式编码：</para>
		/// <para>1. 数据河流线网络中的真回路。</para>
		/// <para>2. 以外栅格编码的河流网络中的回路。</para>
		/// <para>3. 通过连接湖泊的河流网络中的回路。</para>
		/// <para>4. 支流点。</para>
		/// <para>5. 悬崖上的河流（瀑布）。</para>
		/// <para>6. 表示从湖泊流出多条河流的点。</para>
		/// <para>7. 未使用代码。</para>
		/// <para>8. 悬崖旁高度与悬崖方向不一致的点。</para>
		/// <para>9. 未使用代码。</para>
		/// <para>10. 已移除圆形支流。</para>
		/// <para>11. 无流入河流的支流。</para>
		/// <para>12. 不同于出现数据河流线支流位置的输出像元中的栅格化支流。</para>
		/// <para>13. 处理边条件时出错 - 非常复杂的河流线数据的指示符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutStreamCliffErrorFeature { get; set; }

		/// <summary>
		/// <para>Output contour error point features</para>
		/// <para>可能发生的与输入等值线数据相关的错误的输出点要素类。</para>
		/// <para>高度偏差达到输出栅格所示等值线值标准偏差五倍以上的等值线会报告至此要素类。与不同高程值的等值线相连接的等值线在此要素类中会使用代码 1 进行标记，这是等值线标注错误的明确标志。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutContourErrorFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TopoToRaster SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , bool? maintainSpatialIndex = null , object mask = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , bool? transferDomains = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Drainage enforcement</para>
		/// </summary>
		public enum EnforceEnum 
		{
			/// <summary>
			/// <para>强制—该算法将尝试移除遇到的所有汇，无论是“真”汇还是“伪”汇。这是默认设置。</para>
			/// </summary>
			[GPValue("ENFORCE")]
			[Description("强制")]
			Enforce,

			/// <summary>
			/// <para>不强化—汇不会被填充。</para>
			/// </summary>
			[GPValue("NO_ENFORCE")]
			[Description("不强化")]
			Do_not_enforce,

			/// <summary>
			/// <para>通过凹陷强化—输入要素数据中已指出为汇的点表示已知的地形凹陷并且将不会被更改。输入要素数据中未指出的所有汇均将视为伪汇，算法将尝试填充此汇。伪汇数量超过 8,000 个将导致工具无法使用。</para>
			/// </summary>
			[GPValue("ENFORCE_WITH_SINK")]
			[Description("通过凹陷强化")]
			Enforce_with_sink,

		}

		/// <summary>
		/// <para>Primary type of input data</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>等值线—输入数据的主要类型为高程等值线。这是默认设置。</para>
			/// </summary>
			[GPValue("CONTOUR")]
			[Description("等值线")]
			Contour,

			/// <summary>
			/// <para>点—输入的主要类型为点。</para>
			/// </summary>
			[GPValue("SPOT")]
			[Description("点")]
			Spot,

		}

#endregion
	}
}
