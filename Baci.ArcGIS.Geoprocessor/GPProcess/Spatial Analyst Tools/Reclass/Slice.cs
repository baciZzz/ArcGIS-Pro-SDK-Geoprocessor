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
	/// <para>Slice</para>
	/// <para>Slices or reclassifies the range of values of the input cells into zones (classes). The available data classification methods are equal interval, equal area (quantile), natural breaks, standard deviation (mean-centered), standard deviation (mean as a break), defined interval, and geometric interval.</para>
	/// </summary>
	public class Slice : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// <para>The attribute table of the output raster will have two new fields in addition to the standard ObjectID, Value, and Count fields. The Value field indicates the class value. The ZoneMin and ZoneMax fields record the minimum and maximum values, respectively, used for generating a class.</para>
		/// </param>
		public Slice(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Slice</para>
		/// </summary>
		public override string DisplayName => "Slice";

		/// <summary>
		/// <para>Tool Name : Slice</para>
		/// </summary>
		public override string ToolName => "Slice";

		/// <summary>
		/// <para>Tool Excute Name : sa.Slice</para>
		/// </summary>
		public override string ExcuteName => "sa.Slice";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRaster, NumberZones!, SliceType!, BaseOutputZone!, NodataToValue!, ClassIntervalSize! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// <para>The attribute table of the output raster will have two new fields in addition to the standard ObjectID, Value, and Count fields. The Value field indicates the class value. The ZoneMin and ZoneMax fields record the minimum and maximum values, respectively, used for generating a class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of output zones</para>
		/// <para>The number of zones that the input raster will be reclassified into.</para>
		/// <para>This parameter is required when the Slice method parameter value is Equal area, Equal interval, Natural breaks, or Geometric interval.</para>
		/// <para>When the Slice method parameter value is Defined interval, Standard deviation (mean-centered), or Standard deviation (mean as a break), the Number of output zones parameter will be inactive. The number of output zones will be determined by the Interval size parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? NumberZones { get; set; }

		/// <summary>
		/// <para>Slice method</para>
		/// <para>Specifies the manner in which the input raster will be reclassified into zones.</para>
		/// <para>Equal interval—The range of input values will be equally divided into the specified number of output zones to determine the class breaks. This is the default.</para>
		/// <para>Equal area—The number of input cells will be equally divided into the specified number of output zones to determine the class breaks. Each zone will have a similar number of cells, indicating a similar amount of area.</para>
		/// <para>Natural breaks—The class breaks will be determined in a way that minimizes the variance within classes and maximizes the variance between classes. The breaks are usually set at relatively big changes in the data values.</para>
		/// <para>Standard deviation (mean-centered)—The class breaks will be placed above and below the mean value at a specified interval size, such as 2, 1, or 0.5, in the unit of standard deviation, until reaching the minimum and maximum values of the input raster. Mean is not used as a break but centered by two class breaks. One break is at half of the specified interval size above the mean and the other is at half of the specified interval size below the mean. Standard deviation is calculated with the n-1 denominator, where n is the number of pixels with value.</para>
		/// <para>Standard deviation (mean as a break)—The mean value will be used as a class break. Other class breaks will be placed above and below the mean value at a specified interval size, such as 2, 1, or 0.5, in the unit of standard deviation, until reaching the minimum and maximum values of the input raster. Standard deviation is calculated with the n-1 denominator, where n is the number of pixels with value.</para>
		/// <para>Defined interval—The class breaks will be set to zero and a multiple of the specified interval size relative to zero. They will then be clipped to the minimum and maximum values of the input data for the first and last classes. For a value range that contains zero, zero will always be included as a break point.</para>
		/// <para>Geometric interval—The class breaks will be created based on class intervals that have a geometric series. This is a pattern in which the current value equals the previous value divided by a geometric coefficient. The geometric coefficient in this classifier can change once (to its inverse) to optimize the class ranges. The algorithm creates these geometrical intervals by minimizing the sum of squares of the number of elements in each class. This ensures that each class has approximately the same number of values and that the change between intervals is consistent.</para>
		/// <para><see cref="SliceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SliceType { get; set; } = "EQUAL_INTERVAL";

		/// <summary>
		/// <para>Starting value for output</para>
		/// <para>The starting value that will be used for zones (classes) on the output raster dataset.</para>
		/// <para>Classes will be assigned integer values, increasing by 1 from the starting value.</para>
		/// <para>The default starting value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? BaseOutputZone { get; set; } = "1";

		/// <summary>
		/// <para>Change NoData to value for output</para>
		/// <para>Replace NoData with a value in the output.</para>
		/// <para>If this parameter is not set, NoData cells will remain as NoData in the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? NodataToValue { get; set; }

		/// <summary>
		/// <para>Interval size</para>
		/// <para>The size of the interval between classes.</para>
		/// <para>This parameter is required when the Slice method parameter is set to Defined interval, Standard deviation (mean-centered), or Standard deviation (mean as a break).</para>
		/// <para>If Defined interval is used, the interval size indicates the actual value range of a class used to calculate class breaks.</para>
		/// <para>If Standard deviation (mean-centered) or Standard deviation (mean as a break) is used, the interval size indicates the number of standard deviations used to calculate class breaks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ClassIntervalSize { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Slice SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slice method</para>
		/// </summary>
		public enum SliceTypeEnum 
		{
			/// <summary>
			/// <para>Equal interval—The range of input values will be equally divided into the specified number of output zones to determine the class breaks. This is the default.</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("Equal interval")]
			Equal_interval,

			/// <summary>
			/// <para>Equal area—The number of input cells will be equally divided into the specified number of output zones to determine the class breaks. Each zone will have a similar number of cells, indicating a similar amount of area.</para>
			/// </summary>
			[GPValue("EQUAL_AREA")]
			[Description("Equal area")]
			Equal_area,

			/// <summary>
			/// <para>Natural breaks—The class breaks will be determined in a way that minimizes the variance within classes and maximizes the variance between classes. The breaks are usually set at relatively big changes in the data values.</para>
			/// </summary>
			[GPValue("NATURAL_BREAKS")]
			[Description("Natural breaks")]
			Natural_breaks,

			/// <summary>
			/// <para>Standard deviation (mean-centered)—The class breaks will be placed above and below the mean value at a specified interval size, such as 2, 1, or 0.5, in the unit of standard deviation, until reaching the minimum and maximum values of the input raster. Mean is not used as a break but centered by two class breaks. One break is at half of the specified interval size above the mean and the other is at half of the specified interval size below the mean. Standard deviation is calculated with the n-1 denominator, where n is the number of pixels with value.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION_MEAN_CENTERED")]
			[Description("Standard deviation (mean-centered)")]
			STANDARD_DEVIATION_MEAN_CENTERED,

			/// <summary>
			/// <para>Standard deviation (mean as a break)—The mean value will be used as a class break. Other class breaks will be placed above and below the mean value at a specified interval size, such as 2, 1, or 0.5, in the unit of standard deviation, until reaching the minimum and maximum values of the input raster. Standard deviation is calculated with the n-1 denominator, where n is the number of pixels with value.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION_MEAN_BREAK")]
			[Description("Standard deviation (mean as a break)")]
			STANDARD_DEVIATION_MEAN_BREAK,

			/// <summary>
			/// <para>Defined interval—The class breaks will be set to zero and a multiple of the specified interval size relative to zero. They will then be clipped to the minimum and maximum values of the input data for the first and last classes. For a value range that contains zero, zero will always be included as a break point.</para>
			/// </summary>
			[GPValue("DEFINED_INTERVAL")]
			[Description("Defined interval")]
			Defined_interval,

			/// <summary>
			/// <para>Geometric interval—The class breaks will be created based on class intervals that have a geometric series. This is a pattern in which the current value equals the previous value divided by a geometric coefficient. The geometric coefficient in this classifier can change once (to its inverse) to optimize the class ranges. The algorithm creates these geometrical intervals by minimizing the sum of squares of the number of elements in each class. This ensures that each class has approximately the same number of values and that the change between intervals is consistent.</para>
			/// </summary>
			[GPValue("GEOMETRIC_INTERVAL")]
			[Description("Geometric interval")]
			Geometric_interval,

		}

#endregion
	}
}
