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
	/// <para>Derives raster representations of a hemispherical viewshed, sun map, and sky map, which are used in the calculation of direct, diffuse, and global solar radiation.</para>
	/// </summary>
	public class SolarRadiationGraphics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input raster</para>
		/// <para>Input elevation surface raster.</para>
		/// </param>
		/// <param name="OutViewshedRaster">
		/// <para>Output viewshed raster</para>
		/// <para>The output viewshed raster.</para>
		/// <para>The resulting viewshed for a location represents which sky directions are visible and which are obscured. This is similar to the view provided by upward-looking hemispherical (fisheye) photographs.</para>
		/// </param>
		public SolarRadiationGraphics(object InSurfaceRaster, object OutViewshedRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutViewshedRaster = OutViewshedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Solar Radiation Graphics</para>
		/// </summary>
		public override string DisplayName => "Solar Radiation Graphics";

		/// <summary>
		/// <para>Tool Name : SolarRadiationGraphics</para>
		/// </summary>
		public override string ToolName => "SolarRadiationGraphics";

		/// <summary>
		/// <para>Tool Excute Name : sa.SolarRadiationGraphics</para>
		/// </summary>
		public override string ExcuteName => "sa.SolarRadiationGraphics";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSurfaceRaster, OutViewshedRaster, InPointsFeatureOrTable, SkySize, HeightOffset, CalculationDirections, Latitude, TimeConfiguration, DayInterval, HourInterval, OutSunmapRaster, ZenithDivisions, AzimuthDivisions, OutSkymapRaster };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>Input elevation surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output viewshed raster</para>
		/// <para>The output viewshed raster.</para>
		/// <para>The resulting viewshed for a location represents which sky directions are visible and which are obscured. This is similar to the view provided by upward-looking hemispherical (fisheye) photographs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutViewshedRaster { get; set; }

		/// <summary>
		/// <para>Input points feature or table</para>
		/// <para>The input point feature class or table specifying the locations to analyze solar radiation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object InPointsFeatureOrTable { get; set; }

		/// <summary>
		/// <para>Sky size / Resolution</para>
		/// <para>The resolution or sky size for the viewshed, sky map, and sun map rasters. The units are cells.</para>
		/// <para>The default creates a raster of 200 by 200 cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object SkySize { get; set; } = "200";

		/// <summary>
		/// <para>Height offset</para>
		/// <para>The height (in meters) above the DEM surface for which calculations are to be performed.</para>
		/// <para>The height offset will be applied to all input locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object HeightOffset { get; set; } = "0";

		/// <summary>
		/// <para>Calculation directions</para>
		/// <para>The number of azimuth directions used when calculating the viewshed.</para>
		/// <para>Valid values must be multiples of 8 (8, 16, 24, 32, and so on). The default value is 32 directions, which is adequate for complex topography.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object CalculationDirections { get; set; } = "32";

		/// <summary>
		/// <para>Latitude</para>
		/// <para>The latitude for the site area. The units are decimal degrees, with positive values for the northern hemisphere and negative for the southern.</para>
		/// <para>For input surface rasters containing a spatial reference, the mean latitude is automatically calculated; otherwise, latitude will default to 45 degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Optional sunmap output")]
		public object Latitude { get; set; }

		/// <summary>
		/// <para>Time configuration</para>
		/// <para>Specifies the time period to use for the calculations.</para>
		/// <para>Special days—Calculates solar insolation for the solstice days (summer and winter) and the equinox days (where the insolation for both spring and fall equinox are the same).</para>
		/// <para>Within day—Performs calculations for a specified time period within one single day.Select the Julian Day and enter the start and end times. When the start time and the end time are the same, instantaneous insolation will be calculated. When the start time is before sunrise and the end time is after sunset, insolation will be calculated for the whole day.</para>
		/// <para>To facilitate entering the correct day, use the calendar button to open the Calendar dialog box.</para>
		/// <para>Multiple days—Performs calculations for a specific multiple-day period within a year.Specify the start year, start day, and end day. When the end day is smaller than the start day, the end day is considered to be in the following year. The default time configuration starts on day 5 and ends on day 160 of the current Julian year.</para>
		/// <para>To facilitate entering the correct days, use the calendar button to open the Calendar dialog box.</para>
		/// <para>Whole year—Performs calculations for an entire year using monthly intervals for calculations.If the Create outputs for each interval option is checked, output files will be created for each month; otherwise, a single output will be created for the whole year.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSATimeConfiguration()]
		[Category("Optional sunmap output")]
		public object TimeConfiguration { get; set; } = "MultiDays 2021 5 160";

		/// <summary>
		/// <para>Day interval</para>
		/// <para>The time interval through the year (units: days) used for calculation of sky sectors for the sun map.</para>
		/// <para>The default value is 14 (biweekly).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Optional sunmap output")]
		public object DayInterval { get; set; } = "14";

		/// <summary>
		/// <para>Hour interval</para>
		/// <para>Time interval through the day (units: hours) used for calculation of sky sectors for sun maps.</para>
		/// <para>The default value is 0.5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Optional sunmap output")]
		public object HourInterval { get; set; } = "0.5";

		/// <summary>
		/// <para>Output sunmap raster</para>
		/// <para>The output sun map raster.</para>
		/// <para>The output is a representation that specifies sun tracks, the apparent position of the sun as it varies through time. The output is at the same resolution as the viewshed and sky map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional sunmap output")]
		public object OutSunmapRaster { get; set; }

		/// <summary>
		/// <para>Zenith divisions</para>
		/// <para>The number of divisions used to create sky sectors in the sky map.</para>
		/// <para>The default is eight divisions (relative to zenith). Values must be greater than zero and less than half the sky size value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Optional skymap output")]
		public object ZenithDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Azimuth divisions</para>
		/// <para>The number of divisions used to create sky sectors in the sky map.</para>
		/// <para>The default is eight divisions (relative to north). Valid values must be multiples of 8. Values must be greater than zero and less than 160.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Optional skymap output")]
		public object AzimuthDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Output skymap raster</para>
		/// <para>The output sky map raster.</para>
		/// <para>The output is constructed by dividing the whole sky into a series of sky sectors defined by zenith and azimuth divisions. The output is at the same resolution as the viewshed and sun map.</para>
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
