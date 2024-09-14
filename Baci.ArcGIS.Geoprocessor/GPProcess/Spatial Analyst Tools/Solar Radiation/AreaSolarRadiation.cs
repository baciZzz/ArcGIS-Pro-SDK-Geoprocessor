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
	/// <para>Area Solar Radiation</para>
	/// <para>Derives incoming solar radiation from a raster surface.</para>
	/// </summary>
	public class AreaSolarRadiation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input raster</para>
		/// <para>The input elevation surface raster.</para>
		/// </param>
		/// <param name="OutGlobalRadiationRaster">
		/// <para>Output global radiation raster</para>
		/// <para>The output raster representing the global radiation or total amount of incoming solar insolation (direct + diffuse) calculated for each location of the input surface.</para>
		/// <para>The output has units of watt hours per square meter (WH/m2).</para>
		/// </param>
		public AreaSolarRadiation(object InSurfaceRaster, object OutGlobalRadiationRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutGlobalRadiationRaster = OutGlobalRadiationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Area Solar Radiation</para>
		/// </summary>
		public override string DisplayName() => "Area Solar Radiation";

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
		/// <para>The input elevation surface raster.</para>
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
		/// <para>The output raster representing the global radiation or total amount of incoming solar insolation (direct + diffuse) calculated for each location of the input surface.</para>
		/// <para>The output has units of watt hours per square meter (WH/m2).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutGlobalRadiationRaster { get; set; }

		/// <summary>
		/// <para>Latitude</para>
		/// <para>The latitude for the site area. The units are decimal degrees with positive values for the northern hemisphere and negative values for the southern hemisphere.</para>
		/// <para>For input surface rasters containing a spatial reference, the mean latitude is automatically calculated; otherwise, the latitude default is 45 degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = -90)]
		[High(Allow = true, Value = 90)]
		public object? Latitude { get; set; }

		/// <summary>
		/// <para>Sky size / Resolution</para>
		/// <para>The resolution or sky size for the viewshed, sky map, and sun map rasters. The units are cells.</para>
		/// <para>The default is a raster of 200 by 200 cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 100)]
		[High(Allow = true, Value = 10000)]
		public object? SkySize { get; set; } = "200";

		/// <summary>
		/// <para>Time configuration</para>
		/// <para>Specifies the time period that will be used for the calculations.</para>
		/// <para>Special days—Solar insolation will be calculated for the solstice days (summer and winter) and the equinox days (when the insolation for both spring and fall equinox are the same).</para>
		/// <para>Within day—Calculations will be performed for a specified time period within a single day.Select the Julian day and enter the start and end times. When the start time and the end time are the same, instantaneous insolation will be calculated. When the start time is before sunrise and the end time is after sunset, insolation will be calculated for the whole day.</para>
		/// <para>To enter the correct day, use the calendar button to open the Calendar dialog box.</para>
		/// <para>Multiple days—Calculations will be performed for a specific multiple-day period within a year.Specify the start year, start day, and end day. When the end day is smaller than the start day, the end day is considered to be in the following year. The default time configuration starts on day 5 and ends on day 160 of the current Julian year.</para>
		/// <para>To enter the correct days, use the calendar button to open the Calendar dialog box.</para>
		/// <para>Whole year—Calculations will be performed for an entire year using monthly intervals for calculations.If the Create outputs for each interval option is checked, output files will be created for each month; otherwise, a single output will be created for the whole year.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSATimeConfiguration()]
		public object? TimeConfiguration { get; set; } = "MultiDays 2022 5 160";

		/// <summary>
		/// <para>Day interval</para>
		/// <para>The time interval through the year (units: days) that will be used to calculate sky sectors for the sun map.</para>
		/// <para>The default value is 14 (biweekly).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object? DayInterval { get; set; } = "14";

		/// <summary>
		/// <para>Hour interval</para>
		/// <para>The time interval through the day (units: hours) that will be used to calculate sky sectors for the sun map.</para>
		/// <para>The default value is 0.5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? HourInterval { get; set; } = "0.5";

		/// <summary>
		/// <para>Create outputs for each interval</para>
		/// <para>Specifies whether a single total insolation value will be calculated for all locations or multiple values will be calculated for the specified hour and day interval.</para>
		/// <para>Unchecked—A single total radiation value will be calculated for the entire time configuration. This is the default.</para>
		/// <para>Checked—Multiple radiation values will be calculated for each time interval over the entire time configuration. The number of outputs depends on the hour or day interval. For example, for a whole year with monthly intervals, the result will contain 12 output radiation values for each location. The output raster will contain multiple bands that correspond to the radiation or duration values for each time interval.</para>
		/// <para><see cref="EachIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EachInterval { get; set; } = "false";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>The number of ground x,y units in one surface z-unit.</para>
		/// <para>The z-factor adjusts the units of measure for the z-units when they are different from the x,y units of the input surface. The z-values of the input surface are multiplied by the z-factor when calculating the final output surface.</para>
		/// <para>If the x,y units and z-units are in the same units of measure, the z-factor is 1. This is the default.</para>
		/// <para>If the x,y units and z-units are in different units of measure, the z-factor must be set to the appropriate factor or the results will be incorrect.</para>
		/// <para>For example, if the z-units are feet and the x,y units are meters, use a z-factor of 0.3048 to convert the z-units from feet to meters (1 foot = 0.3048 meter).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Topographic parameters")]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Slope and aspect input type</para>
		/// <para>Specifies how slope and aspect information will be derived for analysis.</para>
		/// <para>From the input surface raster—The slope and aspect rasters will be calculated from the input surface raster. This is the default.</para>
		/// <para>From a flat surface—Constant values of zero will be used for slope and aspect.</para>
		/// <para><see cref="SlopeAspectInputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Topographic parameters")]
		public object? SlopeAspectInputType { get; set; } = "FROM_DEM";

		/// <summary>
		/// <para>Calculation directions</para>
		/// <para>The number of azimuth directions that will be used when calculating the viewshed.</para>
		/// <para>Valid values must be multiples of 8 (8, 16, 24, 32, and so on). The default value is 32 directions, which is adequate for complex topography.</para>
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
		/// <para>The number of zenith divisions that will be used to create sky sectors in the sky map.</para>
		/// <para>The default is eight divisions (relative to zenith). Values must be greater than zero and less than half the sky size value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		[Category("Radiation parameters")]
		public object? ZenithDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Azimuth divisions</para>
		/// <para>The number of azimuth divisions that will be used to create sky sectors in the sky map.</para>
		/// <para>The default is eight divisions (relative to north). Valid values must be multiples of 8. Values must be greater than zero and less than 160.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Radiation parameters")]
		public object? AzimuthDivisions { get; set; } = "8";

		/// <summary>
		/// <para>Diffuse model type</para>
		/// <para>Specifies the type of diffuse radiation model that will be used.</para>
		/// <para>Uniform overcast sky—The uniform diffuse model will be used. The incoming diffuse radiation is the same from all sky directions. This is the default.</para>
		/// <para>Standard overcast sky—The standard overcast diffuse model will be used. The incoming diffuse radiation flux varies with the zenith angle.</para>
		/// <para><see cref="DiffuseModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Radiation parameters")]
		public object? DiffuseModelType { get; set; } = "UNIFORM_SKY";

		/// <summary>
		/// <para>Diffuse proportion</para>
		/// <para>The proportion of global normal radiation flux that is diffuse. Values range from 0 to 1.</para>
		/// <para>Set this value according to atmospheric conditions. The default value is 0.3 for generally clear sky conditions.</para>
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
		/// <para>The fraction of radiation that passes through the atmosphere (averaged overall wavelengths). Values range from 0 (no transmission) to 1 (all transmission).</para>
		/// <para>The default is 0.5 for a generally clear sky.</para>
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
		/// <para>The output raster representing the direct incoming solar radiation for each location.</para>
		/// <para>The output has units of watt hours per square meter (WH/m2).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional outputs")]
		public object? OutDirectRadiationRaster { get; set; }

		/// <summary>
		/// <para>Output diffuse radiation raster</para>
		/// <para>The output raster representing the diffuse incoming solar radiation for each location.</para>
		/// <para>The output has units of watt hours per square meter (WH/m2).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional outputs")]
		public object? OutDiffuseRadiationRaster { get; set; }

		/// <summary>
		/// <para>Output direct duration raster</para>
		/// <para>The output raster representing the duration of direct incoming solar radiation.</para>
		/// <para>The output has units of hours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Optional outputs")]
		public object? OutDirectDurationRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AreaSolarRadiation SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
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
			/// <para>Unchecked—A single total radiation value will be calculated for the entire time configuration. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOINTERVAL")]
			NOINTERVAL,

			/// <summary>
			/// <para>Checked—Multiple radiation values will be calculated for each time interval over the entire time configuration. The number of outputs depends on the hour or day interval. For example, for a whole year with monthly intervals, the result will contain 12 output radiation values for each location. The output raster will contain multiple bands that correspond to the radiation or duration values for each time interval.</para>
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
			/// <para>From the input surface raster—The slope and aspect rasters will be calculated from the input surface raster. This is the default.</para>
			/// </summary>
			[GPValue("FROM_DEM")]
			[Description("From the input surface raster")]
			From_the_input_surface_raster,

			/// <summary>
			/// <para>From a flat surface—Constant values of zero will be used for slope and aspect.</para>
			/// </summary>
			[GPValue("FLAT_SURFACE")]
			[Description("From a flat surface")]
			From_a_flat_surface,

		}

		/// <summary>
		/// <para>Diffuse model type</para>
		/// </summary>
		public enum DiffuseModelTypeEnum 
		{
			/// <summary>
			/// <para>Uniform overcast sky—The uniform diffuse model will be used. The incoming diffuse radiation is the same from all sky directions. This is the default.</para>
			/// </summary>
			[GPValue("UNIFORM_SKY")]
			[Description("Uniform overcast sky")]
			Uniform_overcast_sky,

			/// <summary>
			/// <para>Standard overcast sky—The standard overcast diffuse model will be used. The incoming diffuse radiation flux varies with the zenith angle.</para>
			/// </summary>
			[GPValue("STANDARD_OVERCAST_SKY")]
			[Description("Standard overcast sky")]
			Standard_overcast_sky,

		}

#endregion
	}
}
