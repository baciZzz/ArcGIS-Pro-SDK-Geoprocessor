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
	/// <para>Zonal Statistics</para>
	/// <para>Zonal Statistics</para>
	/// <para>Summarizes the values of a raster within the zones of another dataset.</para>
	/// </summary>
	public class ZonalStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneData">
		/// <para>Input Raster or Feature Zone Data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </param>
		/// <param name="ZoneField">
		/// <para>Zone Field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </param>
		/// <param name="InValueRaster">
		/// <para>Input Value Raster</para>
		/// <para>The raster that contains the values on which to calculate a statistic.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The output zonal statistics raster.</para>
		/// </param>
		public ZonalStatistics(object InZoneData, object ZoneField, object InValueRaster, object OutRaster)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.InValueRaster = InValueRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Zonal Statistics</para>
		/// </summary>
		public override string DisplayName() => "Zonal Statistics";

		/// <summary>
		/// <para>Tool Name : ZonalStatistics</para>
		/// </summary>
		public override string ToolName() => "ZonalStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.ZonalStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, InValueRaster, OutRaster, StatisticsType!, IgnoreNodata!, ProcessAsMultidimensional!, PercentileValue!, PercentileInterpolationType!, CircularCalculation!, CircularWrapValue! };

		/// <summary>
		/// <para>Input Raster or Feature Zone Data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InZoneData { get; set; }

		/// <summary>
		/// <para>Zone Field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Input Value Raster</para>
		/// <para>The raster that contains the values on which to calculate a statistic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InValueRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output zonal statistics raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Statistics Type</para>
		/// <para>Specifies the statistic type to be calculated.</para>
		/// <para>Mean—The average of all cells in the value raster that belong to the same zone as the output cell will be calculated. This is the default.</para>
		/// <para>Majority—The value that occurs most often of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Maximum—The largest value of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Median—The median value of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Minimum—The smallest value of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Minority—The value that occurs least often of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Percentile—The percentile of all cells in the value raster that belong to the same zone as the output cell will be calculated. The 90th percentile is calculated by default. You can specify other values (from 0 to 100) using the Percentile Value parameter.</para>
		/// <para>Range—The difference between the largest and smallest value of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Standard deviation—The standard deviation of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Sum—The total value of all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Variety—The number of unique values for all cells in the value raster that belong to the same zone as the output cell will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Ignore NoData in Calculations</para>
		/// <para>Specifies whether NoData values in the value input will be ignored in the results of the zone that they fall within.</para>
		/// <para>Checked—Within any particular zone, only cells that have a value in the input value raster will be used in determining the output value for that zone. NoData cells in the value raster will be ignored in the statistic calculation. This is the default.</para>
		/// <para>Unchecked—Within any particular zone, if NoData cells exist in the value raster, they will not be ignored and their existence indicates that there is insufficient information to perform statistical calculations for all the cells in that zone. Consequently, the entire zone will receive the NoData value on the output raster.</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>Specifies how the input rasters will be calculated if they are multidimensional.</para>
		/// <para>Unchecked—Statistics will be calculated from the current slice of the input multidimensional dataset. This is the default.</para>
		/// <para>Checked—Statistics will be calculated for all dimensions of the input multidimensional dataset.</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Percentile Value</para>
		/// <para>The percentile to calculate. The default is 90, indicating the 90th percentile.</para>
		/// <para>The values can range from 0 to 100. The 0th percentile is essentially equivalent to the minimum statistic, and the 100th percentile is equivalent to maximum. A value of 50 will produce essentially the same result as the median statistic.</para>
		/// <para>This parameter is only available if the Statistics type parameter is set to Percentile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// <para>Specifies the method of interpolation that will be used when the percentile value falls between two cell values from the input value raster.</para>
		/// <para>Auto-detect—If the input value raster is of integer pixel type, the Nearest method will be used. If the input value raster is of floating point pixel type, the Linear method will be used. This is the default.</para>
		/// <para>Nearest—The nearest available value to the desired percentile is used. In this case, the output pixel type is the same as that of the input value raster.</para>
		/// <para>Linear—The weighted average of the two surrounding values from the desired percentile is used. In this case, the output pixel type is floating point.</para>
		/// <para><see cref="PercentileInterpolationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PercentileInterpolationType { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Calculate Circular Statistics</para>
		/// <para>Specifies how the input raster will be processed for circular data.</para>
		/// <para>Unchecked—Ordinary linear statistics will be calculated. This is the default.</para>
		/// <para>Checked—The statistics for angles or other cyclic quantities, such as compass direction in degrees, daytimes, and fractional parts of real numbers, will be calculated.</para>
		/// <para><see cref="CircularCalculationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CircularCalculation { get; set; } = "false";

		/// <summary>
		/// <para>Circular Wrap Value</para>
		/// <para>The value that will be used to round a linear value to the range of a given circular statistic. Its value must be a positive integer or a floating-point value. The default value is 360 degrees.</para>
		/// <para>This parameter is only supported if the Calculate Circular Statistics parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? CircularWrapValue { get; set; } = "360";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalStatistics SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore NoData in Calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para>Checked—Within any particular zone, only cells that have a value in the input value raster will be used in determining the output value for that zone. NoData cells in the value raster will be ignored in the statistic calculation. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Unchecked—Within any particular zone, if NoData cells exist in the value raster, they will not be ignored and their existence indicates that there is insufficient information to perform statistical calculations for all the cells in that zone. Consequently, the entire zone will receive the NoData value on the output raster.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// </summary>
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para>Unchecked—Statistics will be calculated from the current slice of the input multidimensional dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

			/// <summary>
			/// <para>Checked—Statistics will be calculated for all dimensions of the input multidimensional dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

		}

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// </summary>
		public enum PercentileInterpolationTypeEnum 
		{
			/// <summary>
			/// <para>Auto-detect—If the input value raster is of integer pixel type, the Nearest method will be used. If the input value raster is of floating point pixel type, the Linear method will be used. This is the default.</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("Auto-detect")]
			AUTO_DETECT,

			/// <summary>
			/// <para>Nearest—The nearest available value to the desired percentile is used. In this case, the output pixel type is the same as that of the input value raster.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Linear—The weighted average of the two surrounding values from the desired percentile is used. In this case, the output pixel type is floating point.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

		}

		/// <summary>
		/// <para>Calculate Circular Statistics</para>
		/// </summary>
		public enum CircularCalculationEnum 
		{
			/// <summary>
			/// <para>Unchecked—Ordinary linear statistics will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ARITHMETIC")]
			ARITHMETIC,

			/// <summary>
			/// <para>Checked—The statistics for angles or other cyclic quantities, such as compass direction in degrees, daytimes, and fractional parts of real numbers, will be calculated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CIRCULAR")]
			CIRCULAR,

		}

#endregion
	}
}
