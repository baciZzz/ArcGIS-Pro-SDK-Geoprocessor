using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Points Solar Radiation</para>
	/// <para>太阳辐射点</para>
	/// <para>获得点要素类或位置表中特定位置的入射太阳辐射。</para>
	/// </summary>
	public class PointsSolarRadiation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input raster</para>
		/// <para>输入高程面栅格数据。</para>
		/// </param>
		/// <param name="InPointsFeatureOrTable">
		/// <para>Input points feature or table</para>
		/// <para>指定位置以分析太阳辐射位置的输入点要素类或表。</para>
		/// </param>
		/// <param name="OutGlobalRadiationFeatures">
		/// <para>Output global radiation features</para>
		/// <para>表示在每个位置计算而得的总辐射或日照入射量（直射 + 散射）的输出要素类。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </param>
		public PointsSolarRadiation(object InSurfaceRaster, object InPointsFeatureOrTable, object OutGlobalRadiationFeatures)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.InPointsFeatureOrTable = InPointsFeatureOrTable;
			this.OutGlobalRadiationFeatures = OutGlobalRadiationFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 太阳辐射点</para>
		/// </summary>
		public override string DisplayName() => "太阳辐射点";

		/// <summary>
		/// <para>Tool Name : PointsSolarRadiation</para>
		/// </summary>
		public override string ToolName() => "PointsSolarRadiation";

		/// <summary>
		/// <para>Tool Excute Name : sa.PointsSolarRadiation</para>
		/// </summary>
		public override string ExcuteName() => "sa.PointsSolarRadiation";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurfaceRaster, InPointsFeatureOrTable, OutGlobalRadiationFeatures, HeightOffset, Latitude, SkySize, TimeConfiguration, DayInterval, HourInterval, EachInterval, ZFactor, SlopeAspectInputType, CalculationDirections, ZenithDivisions, AzimuthDivisions, DiffuseModelType, DiffuseProportion, Transmittivity, OutDirectRadiationFeatures, OutDiffuseRadiationFeatures, OutDirectDurationFeatures };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入高程面栅格数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Input points feature or table</para>
		/// <para>指定位置以分析太阳辐射位置的输入点要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InPointsFeatureOrTable { get; set; }

		/// <summary>
		/// <para>Output global radiation features</para>
		/// <para>表示在每个位置计算而得的总辐射或日照入射量（直射 + 散射）的输出要素类。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutGlobalRadiationFeatures { get; set; }

		/// <summary>
		/// <para>Height offset</para>
		/// <para>要执行计算的 DEM 表面之上的高度（以米为单位）。</para>
		/// <para>高度偏移将应用到所有输入位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object HeightOffset { get; set; } = "0";

		/// <summary>
		/// <para>Latitude</para>
		/// <para>位置区域的纬度。单位为十进制度，北半球为正值，南半球为负值。</para>
		/// <para>对于包含空间参考的输入表面栅格数据，会自动计算平均纬度；否则，纬度将默认为 45 度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = -90)]
		[High(Allow = true, Value = 90)]
		public object Latitude { get; set; }

		/// <summary>
		/// <para>Sky size / Resolution</para>
		/// <para>视域、天空图和阳光图栅格的分辨率或天空大小。单位为像元。</para>
		/// <para>默认情况下会创建 200 x 200 像元的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 100)]
		[High(Allow = true, Value = 10000)]
		public object SkySize { get; set; } = "200";

		/// <summary>
		/// <para>Time configuration</para>
		/// <para>指定用于计算的时间段。</para>
		/// <para>特定的日子 - 计算夏至、冬至和春秋分（春分和秋分的日照是相同的）的太阳日照。</para>
		/// <para>一天内 - 针对一天内的指定时间段执行计算。选择儒略日，然后输入起始时间和结束时间。起始时间和结束时间相同时，将计算瞬时日照。起始时间在日出前而结束时间在日出后时，将计算全天的日照。</para>
		/// <para>为便于输入正确天数，可以使用日历按钮打开日历对话框。</para>
		/// <para>多天 - 针对一年中特定几天的时段执行计算。指定起始年、起始日和结束日。如果结束日小于起始日，则将结束日视为在下一年中。默认时间配置起始于当前儒略年的第 5 天，结束于第 160 天。</para>
		/// <para>为便于输入正确天数，可以使用日历按钮打开日历对话框。</para>
		/// <para>整年 - 使用每月间隔计算整年的数据。如果选中为每种间隔创建输出选项，将为每月创建输出文件；否则，将为整年创建一个输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSATimeConfiguration()]
		public object TimeConfiguration { get; set; } = "MultiDays 2021 5 160";

		/// <summary>
		/// <para>Day interval</para>
		/// <para>用于为太阳图计算天空分区的一年中的时间间隔（单位：天）。</para>
		/// <para>默认值为 14（两周）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object DayInterval { get; set; } = "14";

		/// <summary>
		/// <para>Hour interval</para>
		/// <para>用于为太阳图计算天空分区的一天中的时间间隔（单位：小时）。</para>
		/// <para>默认值为 0.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object HourInterval { get; set; } = "0.5";

		/// <summary>
		/// <para>Create outputs for each interval</para>
		/// <para>指定是针对所有位置计算一个总日射值，还是针对指定间隔小时数和间隔天数计算多个值。</para>
		/// <para>未选中—针对整个时间配置计算一个总日照值。这是默认设置。</para>
		/// <para>选中—针对整个时间配置中的各时间间隔计算多个日照值。输出数取决于间隔小时数或间隔天数。例如，使用每月间隔计算整年时，结果将包含针对各位置的 12 个输出辐射值。</para>
		/// <para><see cref="EachIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EachInterval { get; set; } = "false";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>一个表面 z 单位中地面 x,y 单位的数量。</para>
		/// <para>z 单位与输入表面的 x,y 单位不同时，可使用 z 因子调整 z 单位的测量单位。计算最终输出表面时，将用 z 因子乘以输入表面的 z 值。</para>
		/// <para>如果 x,y 单位和 z 单位采用相同的测量单位，则 z 因子为 1。这是默认设置。</para>
		/// <para>如果 x,y 单位和 z 单位采用不同的测量单位，则必须将 z 因子设置为适当的因子，否则会得到错误的结果。</para>
		/// <para>例如，如果 z 单位是英尺而 x,y 单位是米，则应使用 z 因子 0.3048 将 z 单位从英尺转换为米（1 英尺 = 0.3048 米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Topographic parameters")]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Slope and aspect input type</para>
		/// <para>如何为分析获取坡度和坡向信息。</para>
		/// <para>基于输入表面栅格— 基于输入表面栅格数据计算得出坡度和坡向栅格。这是默认设置。</para>
		/// <para>基于平面— 常数值零用于坡度和坡向。</para>
		/// <para>基于输入点表— 可与位置文件中的 x,y 坐标一起指定坡度和坡向的值。</para>
		/// <para><see cref="SlopeAspectInputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Topographic parameters")]
		public object SlopeAspectInputType { get; set; } = "FROM_DEM";

		/// <summary>
		/// <para>Calculation directions</para>
		/// <para>计算视域时使用的方位角方向数。</para>
		/// <para>有效值必须是 8 的倍数（8、16、24、32，依此类推）。默认值为 32 个方向，该值适用于复杂地形。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 8)]
		[High(Allow = true, Value = 360)]
		[Category("Topographic parameters")]
		public object CalculationDirections { get; set; } = "32";

		/// <summary>
		/// <para>Zenith divisions</para>
		/// <para>用于创建天空图中的天空分区的方位角分割数。</para>
		/// <para>默认值为八个分割（相对于天顶）。值必须大于零并且小于天空大小值的一半。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		[Category("Radiation parameters")]
		public object ZenithDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Azimuth divisions</para>
		/// <para>用于创建天空图中的天空分区的方位角分割数。</para>
		/// <para>默认值为八个分割（相对于北方）。有效值必须是 8 的倍数。值必须大于零且小于 160。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Radiation parameters")]
		public object AzimuthDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Diffuse model type</para>
		/// <para>散射辐射模型的类型。</para>
		/// <para>统一阴天天空— 均匀散射模型。所有天空方向的入射散射辐射均相同。这是默认设置。</para>
		/// <para>标准阴天天空— 标准阴天散射模型。入射散射辐射通量随天顶角而变化。</para>
		/// <para><see cref="DiffuseModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Radiation parameters")]
		public object DiffuseModelType { get; set; } = "UNIFORM_SKY";

		/// <summary>
		/// <para>Diffuse proportion</para>
		/// <para>散射的总正常辐射通量的比例。值的范围介于 0 到 1 之间。</para>
		/// <para>应根据大气条件设置该值。默认值为 0.3，适用于普通晴朗的天空条件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[High(Allow = true, Value = 1)]
		[Category("Radiation parameters")]
		public object DiffuseProportion { get; set; } = "0.3";

		/// <summary>
		/// <para>Transmittivity</para>
		/// <para>穿过大气层的辐射部分（所有波长的平均值）。值的范围介于 0（无透射）到 1（完全透射）之间。</para>
		/// <para>默认值为 0.5，适用于普通晴朗的天空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[High(Allow = true, Value = 1)]
		[Category("Radiation parameters")]
		public object Transmittivity { get; set; } = "0.5";

		/// <summary>
		/// <para>Output direct radiation features</para>
		/// <para>表示每个位置直接入射太阳辐射的输出要素类。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutDirectRadiationFeatures { get; set; }

		/// <summary>
		/// <para>Output diffuse radiation features</para>
		/// <para>表示每个散射位置的入射太阳辐射的输出要素类。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutDiffuseRadiationFeatures { get; set; }

		/// <summary>
		/// <para>Output direct duration features</para>
		/// <para>表示直接入射太阳辐射的持续时间的输出要素类。</para>
		/// <para>输出单位为小时。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutDirectDurationFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointsSolarRadiation SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object cellSize = null, object configKeyword = null, bool? maintainSpatialIndex = null, object mask = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create outputs for each interval</para>
		/// </summary>
		public enum EachIntervalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOINTERVAL")]
			NOINTERVAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INTERVAL")]
			INTERVAL,

		}

		/// <summary>
		/// <para>Slope and aspect input type</para>
		/// </summary>
		public enum SlopeAspectInputTypeEnum 
		{
			/// <summary>
			/// <para>基于输入表面栅格— 基于输入表面栅格数据计算得出坡度和坡向栅格。这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_DEM")]
			[Description("基于输入表面栅格")]
			From_the_input_surface_raster,

			/// <summary>
			/// <para>基于平面— 常数值零用于坡度和坡向。</para>
			/// </summary>
			[GPValue("FLAT_SURFACE")]
			[Description("基于平面")]
			From_a_flat_surface,

			/// <summary>
			/// <para>基于输入点表— 可与位置文件中的 x,y 坐标一起指定坡度和坡向的值。</para>
			/// </summary>
			[GPValue("FROM_POINTS_TABLE")]
			[Description("基于输入点表")]
			From_the_input_points_table,

		}

		/// <summary>
		/// <para>Diffuse model type</para>
		/// </summary>
		public enum DiffuseModelTypeEnum 
		{
			/// <summary>
			/// <para>统一阴天天空— 均匀散射模型。所有天空方向的入射散射辐射均相同。这是默认设置。</para>
			/// </summary>
			[GPValue("UNIFORM_SKY")]
			[Description("统一阴天天空")]
			Uniform_overcast_sky,

			/// <summary>
			/// <para>标准阴天天空— 标准阴天散射模型。入射散射辐射通量随天顶角而变化。</para>
			/// </summary>
			[GPValue("STANDARD_OVERCAST_SKY")]
			[Description("标准阴天天空")]
			Standard_overcast_sky,

		}

#endregion
	}
}
