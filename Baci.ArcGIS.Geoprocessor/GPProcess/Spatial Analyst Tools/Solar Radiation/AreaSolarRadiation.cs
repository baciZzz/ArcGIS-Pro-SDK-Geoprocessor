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
	/// <para>Area Solar Radiation</para>
	/// <para>太阳辐射区域</para>
	/// <para>基于栅格表面获得入射太阳辐射。</para>
	/// </summary>
	public class AreaSolarRadiation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input raster</para>
		/// <para>输入高程表面栅格。</para>
		/// </param>
		/// <param name="OutGlobalRadiationRaster">
		/// <para>Output global radiation raster</para>
		/// <para>用于表示为输入表面的每个位置所计算的全局辐射或全部日照入射量（直射 + 散射）的输出栅格。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </param>
		public AreaSolarRadiation(object InSurfaceRaster, object OutGlobalRadiationRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutGlobalRadiationRaster = OutGlobalRadiationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 太阳辐射区域</para>
		/// </summary>
		public override string DisplayName() => "太阳辐射区域";

		/// <summary>
		/// <para>Tool Name : AreaSolarRadiation</para>
		/// </summary>
		public override string ToolName() => "AreaSolarRadiation";

		/// <summary>
		/// <para>Tool Excute Name : sa.AreaSolarRadiation</para>
		/// </summary>
		public override string ExcuteName() => "sa.AreaSolarRadiation";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutGlobalRadiationRaster, Latitude!, SkySize!, TimeConfiguration!, DayInterval!, HourInterval!, EachInterval!, ZFactor!, SlopeAspectInputType!, CalculationDirections!, ZenithDivisions!, AzimuthDivisions!, DiffuseModelType!, DiffuseProportion!, Transmittivity!, OutDirectRadiationRaster!, OutDiffuseRadiationRaster!, OutDirectDurationRaster! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入高程表面栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output global radiation raster</para>
		/// <para>用于表示为输入表面的每个位置所计算的全局辐射或全部日照入射量（直射 + 散射）的输出栅格。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutGlobalRadiationRaster { get; set; }

		/// <summary>
		/// <para>Latitude</para>
		/// <para>位置区域的纬度。 单位为十进制度，北半球为正值，南半球为负值。</para>
		/// <para>对于包含空间参考的输入表面栅格，会自动计算平均纬度；否则，纬度将默认为 45 度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = -90)]
		[High(Allow = true, Value = 90)]
		public object? Latitude { get; set; }

		/// <summary>
		/// <para>Sky size / Resolution</para>
		/// <para>视域、天空图和阳光图栅格的分辨率或天空大小。 单位为像元。</para>
		/// <para>默认为 200 x 200 像元的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 100)]
		[High(Allow = true, Value = 10000)]
		public object? SkySize { get; set; } = "200";

		/// <summary>
		/// <para>Time configuration</para>
		/// <para>指定将用于计算的时间段。</para>
		/// <para>特殊日期 - 将计算夏至、冬至和春秋分（春分和秋分的日照是相同的）的太阳日照。</para>
		/// <para>一天内 - 将对一天内的指定时间段执行计算。选择儒略日，然后输入起始时间和结束时间。 起始时间和结束时间相同时，将计算瞬时日照。 起始时间在日出前而结束时间在日出后时，将计算全天的日照。</para>
		/// <para>要输入正确日期，可以使用日历按钮打开日历对话框。</para>
		/// <para>多天 - 将对一年中的特定多天时间段执行计算。指定起始年、起始日和结束日。 如果结束日小于起始日，则将结束日视为在下一年中。 默认时间配置起始于当前儒略年的第 5 天，结束于第 160 天。</para>
		/// <para>要输入正确日期，可以使用日历按钮打开日历对话框。</para>
		/// <para>整年 - 将使用计算的每月间隔对整年执行计算。如果选中为每种间隔创建输出选项，将为每月创建输出文件；否则，将为整年创建一个输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSATimeConfiguration()]
		public object? TimeConfiguration { get; set; } = "MultiDays 2022 5 160";

		/// <summary>
		/// <para>Day interval</para>
		/// <para>用于为太阳图计算天空分区的一年中的时间间隔（单位：天）。</para>
		/// <para>默认值为 14（两周）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object? DayInterval { get; set; } = "14";

		/// <summary>
		/// <para>Hour interval</para>
		/// <para>用于为太阳图计算天空分区的一天中的时间间隔（单位：小时）。</para>
		/// <para>默认值为 0.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? HourInterval { get; set; } = "0.5";

		/// <summary>
		/// <para>Create outputs for each interval</para>
		/// <para>指定将针对所有位置计算单一总日射值，还是针对指定的小时和天间隔计算多个值。</para>
		/// <para>未选中 - 针对整个时间配置计算一个总日照值。 这是默认设置。</para>
		/// <para>选中 - 针对整个时间配置中的各时间间隔计算多个日照值。 输出数取决于小时或天间隔。 例如，使用每月间隔计算整年时，结果将包含针对各位置的 12 个输出辐射值。 输出栅格将包含多个波段，这些波段对应于每个时间间隔的辐射或持续时间值。</para>
		/// <para><see cref="EachIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EachInterval { get; set; } = "false";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>一个表面 z 单位中地面 x,y 单位的数量。</para>
		/// <para>z 单位与输入表面的 x,y 单位不同时，可使用 z 因子调整 z 单位的测量单位。 计算最终输出表面时，将用 z 因子乘以输入表面的 z 值。</para>
		/// <para>如果 x,y 单位和 z 单位采用相同的测量单位，则 z 因子为 1。 这是默认设置。</para>
		/// <para>如果 x,y 单位和 z 单位采用不同的测量单位，则必须将 z 因子设置为适当的因子，否则会得到错误的结果。</para>
		/// <para>例如，如果 z 单位是英尺，而 x,y 单位是米，则可以使用 z 因子 0.3048 将 z 单位从英尺转换为米（1 英尺 = 0.3048 米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Topographic parameters")]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Slope and aspect input type</para>
		/// <para>指定如何获取坡度和坡向信息以进行分析。</para>
		/// <para>基于输入表面栅格—将根据输入表面栅格计算坡度和坡向栅格。 这是默认设置。</para>
		/// <para>基于平面—常数值零将用于坡度和坡向。</para>
		/// <para><see cref="SlopeAspectInputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Topographic parameters")]
		public object? SlopeAspectInputType { get; set; } = "FROM_DEM";

		/// <summary>
		/// <para>Calculation directions</para>
		/// <para>计算视域时将使用的方位角方向数。</para>
		/// <para>有效值必须是 8 的倍数（8、16、24、32，依此类推）。 默认值为 32 个方向，该值适用于复杂地形。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 8)]
		[High(Allow = true, Value = 360)]
		[Category("Topographic parameters")]
		public object? CalculationDirections { get; set; } = "32";

		/// <summary>
		/// <para>Zenith divisions</para>
		/// <para>用于创建天空图中的天空分区的天顶分割数。</para>
		/// <para>默认值为八个分割（相对于天顶）。 值必须大于零并且小于天空大小值的一半。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		[Category("Radiation parameters")]
		public object? ZenithDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Azimuth divisions</para>
		/// <para>用于创建天空图中的天空分区的方位角分割数。</para>
		/// <para>默认值为八个分割（相对于北方）。 有效值必须是 8 的倍数。 值必须大于零且小于 160。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Radiation parameters")]
		public object? AzimuthDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Diffuse model type</para>
		/// <para>指定将使用的散射辐射模型的类型。</para>
		/// <para>统一阴天天空—将使用均匀散射模型。 所有天空方向的入射散射辐射均相同。 这是默认设置。</para>
		/// <para>标准阴天天空—将使用标准阴天散射模型。 入射散射辐射通量随天顶角而变化。</para>
		/// <para><see cref="DiffuseModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Radiation parameters")]
		public object? DiffuseModelType { get; set; } = "UNIFORM_SKY";

		/// <summary>
		/// <para>Diffuse proportion</para>
		/// <para>散射的总正常辐射通量的比例。 值的范围介于 0 到 1 之间。</para>
		/// <para>根据大气条件设置该值。 默认值为 0.3，适用于普通晴朗的天空条件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		[Category("Radiation parameters")]
		public object? DiffuseProportion { get; set; } = "0.3";

		/// <summary>
		/// <para>Transmittivity</para>
		/// <para>穿过大气层的辐射部分（所有波长的平均值）。 值的范围介于 0（无透射）到 1（完全透射）之间。</para>
		/// <para>默认值为 0.5，适用于普通晴朗的天空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		[Category("Radiation parameters")]
		public object? Transmittivity { get; set; } = "0.5";

		/// <summary>
		/// <para>Output direct radiation raster</para>
		/// <para>表示每个位置的直接入射的太阳辐射的输出栅格。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional outputs")]
		public object? OutDirectRadiationRaster { get; set; }

		/// <summary>
		/// <para>Output diffuse radiation raster</para>
		/// <para>表示每个位置的散射入射的太阳辐射的输出栅格。</para>
		/// <para>输出单位为瓦特小时每平方米 (WH/m2)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional outputs")]
		public object? OutDiffuseRadiationRaster { get; set; }

		/// <summary>
		/// <para>Output direct duration raster</para>
		/// <para>表示直接入射太阳辐射的持续时间的输出栅格。</para>
		/// <para>输出单位为小时。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional outputs")]
		public object? OutDirectDurationRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AreaSolarRadiation SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
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
			/// <para>基于输入表面栅格—将根据输入表面栅格计算坡度和坡向栅格。 这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_DEM")]
			[Description("基于输入表面栅格")]
			From_the_input_surface_raster,

			/// <summary>
			/// <para>基于平面—常数值零将用于坡度和坡向。</para>
			/// </summary>
			[GPValue("FLAT_SURFACE")]
			[Description("基于平面")]
			From_a_flat_surface,

		}

		/// <summary>
		/// <para>Diffuse model type</para>
		/// </summary>
		public enum DiffuseModelTypeEnum 
		{
			/// <summary>
			/// <para>统一阴天天空—将使用均匀散射模型。 所有天空方向的入射散射辐射均相同。 这是默认设置。</para>
			/// </summary>
			[GPValue("UNIFORM_SKY")]
			[Description("统一阴天天空")]
			Uniform_overcast_sky,

			/// <summary>
			/// <para>标准阴天天空—将使用标准阴天散射模型。 入射散射辐射通量随天顶角而变化。</para>
			/// </summary>
			[GPValue("STANDARD_OVERCAST_SKY")]
			[Description("标准阴天天空")]
			Standard_overcast_sky,

		}

#endregion
	}
}
