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
	/// <para>Solar Radiation Graphics</para>
	/// <para>太阳辐射图</para>
	/// <para>获得用于计算直接太阳辐射、散射太阳辐射和整体太阳辐射的半球视域、太阳图和星空图的栅格表达。</para>
	/// </summary>
	public class SolarRadiationGraphics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input raster</para>
		/// <para>输入高程面栅格数据。</para>
		/// </param>
		/// <param name="OutViewshedRaster">
		/// <para>Output viewshed raster</para>
		/// <para>输出视域栅格。</para>
		/// <para>生成的某一位置的视域表示哪些星空方向可见，哪些星空方向模糊不清。这与通过仰视半球（鱼眼镜头）照片提供的视角类似。</para>
		/// </param>
		public SolarRadiationGraphics(object InSurfaceRaster, object OutViewshedRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutViewshedRaster = OutViewshedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 太阳辐射图</para>
		/// </summary>
		public override string DisplayName() => "太阳辐射图";

		/// <summary>
		/// <para>Tool Name : SolarRadiationGraphics</para>
		/// </summary>
		public override string ToolName() => "SolarRadiationGraphics";

		/// <summary>
		/// <para>Tool Excute Name : sa.SolarRadiationGraphics</para>
		/// </summary>
		public override string ExcuteName() => "sa.SolarRadiationGraphics";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutViewshedRaster, InPointsFeatureOrTable, SkySize, HeightOffset, CalculationDirections, Latitude, TimeConfiguration, DayInterval, HourInterval, OutSunmapRaster, ZenithDivisions, AzimuthDivisions, OutSkymapRaster };

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
		/// <para>Output viewshed raster</para>
		/// <para>输出视域栅格。</para>
		/// <para>生成的某一位置的视域表示哪些星空方向可见，哪些星空方向模糊不清。这与通过仰视半球（鱼眼镜头）照片提供的视角类似。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutViewshedRaster { get; set; }

		/// <summary>
		/// <para>Input points feature or table</para>
		/// <para>指定位置以分析太阳辐射位置的输入点要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object InPointsFeatureOrTable { get; set; }

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
		/// <para>Calculation directions</para>
		/// <para>计算视域时使用的方位角方向数。</para>
		/// <para>有效值必须是 8 的倍数（8、16、24、32，依此类推）。默认值为 32 个方向，该值适用于复杂地形。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 8)]
		[High(Allow = true, Value = 360)]
		public object CalculationDirections { get; set; } = "32";

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
		[Category("Optional sunmap output")]
		public object Latitude { get; set; }

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
		[Category("Optional sunmap output")]
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
		[Category("Optional sunmap output")]
		public object DayInterval { get; set; } = "14";

		/// <summary>
		/// <para>Hour interval</para>
		/// <para>用于为太阳图计算天空分区的一天中的时间间隔（单位：小时）。</para>
		/// <para>默认值为 0.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Optional sunmap output")]
		public object HourInterval { get; set; } = "0.5";

		/// <summary>
		/// <para>Output sunmap raster</para>
		/// <para>输出太阳图栅格。</para>
		/// <para>该输出是指定太阳轨迹（即，太阳随着时间的推移而发生变化时所处的明显位置）的栅格表达。该输出的分辨率与视域和星空图相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional sunmap output")]
		public object OutSunmapRaster { get; set; }

		/// <summary>
		/// <para>Zenith divisions</para>
		/// <para>用于创建天空图中的天空分区的方位角分割数。</para>
		/// <para>默认值为八个分割（相对于天顶）。值必须大于零并且小于天空大小值的一半。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		[Category("Optional skymap output")]
		public object ZenithDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Azimuth divisions</para>
		/// <para>用于创建天空图中的天空分区的方位角分割数。</para>
		/// <para>默认值为八个分割（相对于北方）。有效值必须是 8 的倍数。值必须大于零且小于 160。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Optional skymap output")]
		public object AzimuthDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Output skymap raster</para>
		/// <para>输出星空图栅格。</para>
		/// <para>可通过将整个星空分成一系列由天顶分割和方位角分割定义的天空扇区来构造输出。该输出的分辨率与视域和太阳图相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional skymap output")]
		public object OutSkymapRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SolarRadiationGraphics SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
