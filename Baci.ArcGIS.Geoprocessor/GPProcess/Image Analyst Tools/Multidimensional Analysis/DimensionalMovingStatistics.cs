using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Dimensional Moving Statistics</para>
	/// <para>Dimensional Moving Statistics</para>
	/// <para>Calculates statistics over a moving window on multidimensional data along a specified dimension.</para>
	/// </summary>
	public class DimensionalMovingStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input raster can only be a multidimensional raster in Cloud Raster Format (.crf file).</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output raster can only be a multidimensional raster in Cloud Raster Format (.crf file).</para>
		/// </param>
		public DimensionalMovingStatistics(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Dimensional Moving Statistics</para>
		/// </summary>
		public override string DisplayName() => "Dimensional Moving Statistics";

		/// <summary>
		/// <para>Tool Name : DimensionalMovingStatistics</para>
		/// </summary>
		public override string ToolName() => "DimensionalMovingStatistics";

		/// <summary>
		/// <para>Tool Excute Name : ia.DimensionalMovingStatistics</para>
		/// </summary>
		public override string ExcuteName() => "ia.DimensionalMovingStatistics";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Dimension!, BackwardWindow!, ForwardWindow!, NodataHandling!, StatisticsType!, PercentileValue!, PercentileInterpolationType!, CircularWrapValue!, RasterFunctionArgumentsJson! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input raster can only be a multidimensional raster in Cloud Raster Format (.crf file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output raster can only be a multidimensional raster in Cloud Raster Format (.crf file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>The name of the dimension along which the window will move.</para>
		/// <para>The default value is the first dimension other than x,y found in the input multidimensional raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Dimension { get; set; }

		/// <summary>
		/// <para>Backward Window</para>
		/// <para>The value of how many slices before or above to be included in the defined window. The value must be a positive integer from 1 to 100. The default value is 1.</para>
		/// <para>The unit of this parameter is slice.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000)]
		public object? BackwardWindow { get; set; } = "1";

		/// <summary>
		/// <para>Forward Window</para>
		/// <para>The value of how many slices after or below to be included in the defined window. The value must be a positive integer from 1 to 100. The default value is 1.</para>
		/// <para>The unit of this parameter is slice.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000)]
		public object? ForwardWindow { get; set; } = "1";

		/// <summary>
		/// <para>NoData Handling</para>
		/// <para>Specifies how NoData values will be handled by the statistic calculation.</para>
		/// <para>Data—NoData values in the value input will be ignored in the results of the defined window that they fall within. This is the default.</para>
		/// <para>NoData—Output values will be NoData if any NoData values are found in the input within the defined window.</para>
		/// <para>Fill NoData—NoData cell values will be replaced using the selected statistic on the values within the defined window.</para>
		/// <para><see cref="NodataHandlingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NodataHandling { get; set; } = "DATA";

		/// <summary>
		/// <para>Statistics Type</para>
		/// <para>Specifies the statistic type to be calculated.</para>
		/// <para>Mean—The mean (average value) of the cells in the defined window will be calculated. This is the default.</para>
		/// <para>Circular Mean—The mean for angles or other cyclic quantities—such as compass direction in degrees, daytimes, or fractional parts of real numbers—will be calculated. When this statistics type is selected, the Circular Wrap Value parameter becomes available. Use this parameter to designate a wrap value.</para>
		/// <para>Majority—The majority (value that occurs most often) of the cells in the defined window will be identified.</para>
		/// <para>Maximum—The maximum (largest value) of the cells in the defined window will be identified.</para>
		/// <para>Median—The median of the cells in the defined window will be identified.</para>
		/// <para>Minimum—The minimum (smallest value) of the cells in the defined window will be identified.</para>
		/// <para>Percentile—A percentile of the cells in the defined window will be calculated. The 90th percentile is calculated by default. When this statistics type is selected, the Percentile Value and Percentile Interpolation Type parameters become available. Use these new parameters to designate the percentile to calculate and choose the interpolation type to use, respectively.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Percentile Value</para>
		/// <para>The percentile value that will be calculated. The default is 90, for the 90th percentile.</para>
		/// <para>The value can range from 0 to 100. The 0th percentile is essentially equivalent to the minimum statistic, and the 100th percentile is equivalent to the maximum statistic. A value of 50 will produce essentially the same result as the median statistic.</para>
		/// <para>This parameter is only supported if the Statistics Type parameter is set to Percentile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// <para>Specifies the method of interpolation that will be used when the percentile value falls between two cell values.</para>
		/// <para>This parameter is only supported if the Statistics Type parameter is set to Median or Percentile.</para>
		/// <para>Auto-detect—If the input raster is of integer pixel type, the Nearest method will be used. If the input raster is of float pixel type, the Linear method will be used.</para>
		/// <para>Nearest—The nearest available value to the percentile will be used. In this case, the output pixel type will be the same as that of the input raster.</para>
		/// <para>Linear—The weighted average of the two surrounding values from the percentile will be used. In this case, the output pixel type will be floating point.</para>
		/// <para><see cref="PercentileInterpolationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PercentileInterpolationType { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Circular Wrap Value</para>
		/// <para>The value that will be used to convert a linear value to the range of a given circular mean. Its value must be positive. The default value is 360 degrees.</para>
		/// <para>This parameter is only supported if the Statistics Type parameter is set to Circular Mean.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1e-10, Max = 10000000000)]
		public object? CircularWrapValue { get; set; } = "360";

		/// <summary>
		/// <para>Raster Function Arguments JSON</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? RasterFunctionArgumentsJson { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DimensionalMovingStatistics SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>NoData Handling</para>
		/// </summary>
		public enum NodataHandlingEnum 
		{
			/// <summary>
			/// <para>Data—NoData values in the value input will be ignored in the results of the defined window that they fall within. This is the default.</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("Data")]
			Data,

			/// <summary>
			/// <para>NoData Handling</para>
			/// </summary>
			[GPValue("NODATA")]
			[Description("NoData")]
			NoData,

			/// <summary>
			/// <para>Fill NoData—NoData cell values will be replaced using the selected statistic on the values within the defined window.</para>
			/// </summary>
			[GPValue("FILL_NODATA")]
			[Description("Fill NoData")]
			Fill_NoData,

		}

		/// <summary>
		/// <para>Statistics Type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Mean—The mean (average value) of the cells in the defined window will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Circular Mean—The mean for angles or other cyclic quantities—such as compass direction in degrees, daytimes, or fractional parts of real numbers—will be calculated. When this statistics type is selected, the Circular Wrap Value parameter becomes available. Use this parameter to designate a wrap value.</para>
			/// </summary>
			[GPValue("CIRCULAR_MEAN")]
			[Description("Circular Mean")]
			Circular_Mean,

			/// <summary>
			/// <para>Majority—The majority (value that occurs most often) of the cells in the defined window will be identified.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority")]
			Majority,

			/// <summary>
			/// <para>Maximum—The maximum (largest value) of the cells in the defined window will be identified.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Median—The median of the cells in the defined window will be identified.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Minimum—The minimum (smallest value) of the cells in the defined window will be identified.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Percentile—A percentile of the cells in the defined window will be calculated. The 90th percentile is calculated by default. When this statistics type is selected, the Percentile Value and Percentile Interpolation Type parameters become available. Use these new parameters to designate the percentile to calculate and choose the interpolation type to use, respectively.</para>
			/// </summary>
			[GPValue("PERCENTILE")]
			[Description("Percentile")]
			Percentile,

		}

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// </summary>
		public enum PercentileInterpolationTypeEnum 
		{
			/// <summary>
			/// <para>Auto-detect—If the input raster is of integer pixel type, the Nearest method will be used. If the input raster is of float pixel type, the Linear method will be used.</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("Auto-detect")]
			AUTO_DETECT,

			/// <summary>
			/// <para>Nearest—The nearest available value to the percentile will be used. In this case, the output pixel type will be the same as that of the input raster.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Linear—The weighted average of the two surrounding values from the percentile will be used. In this case, the output pixel type will be floating point.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

		}

#endregion
	}
}
