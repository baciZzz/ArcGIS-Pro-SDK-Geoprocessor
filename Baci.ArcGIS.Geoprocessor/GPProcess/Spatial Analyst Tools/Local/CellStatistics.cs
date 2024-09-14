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
	/// <para>Cell Statistics</para>
	/// <para>Cell Statistics</para>
	/// <para>Calculates a per-cell statistic from multiple rasters.</para>
	/// </summary>
	public class CellStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRastersOrConstants">
		/// <para>Input rasters or constant values</para>
		/// <para>A list of input rasters for which a statistical operation will be calculated for each cell in the analysis window.</para>
		/// <para>A number can be used as an input; however, the cell size and extent must first be set in the environment.</para>
		/// <para>If the Process as multiband parameter is checked, all multiband inputs must have an equal number of bands.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For each cell, the value is determined by applying the specified statistic type to the input rasters at that location.</para>
		/// </param>
		public CellStatistics(object InRastersOrConstants, object OutRaster)
		{
			this.InRastersOrConstants = InRastersOrConstants;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Cell Statistics</para>
		/// </summary>
		public override string DisplayName() => "Cell Statistics";

		/// <summary>
		/// <para>Tool Name : CellStatistics</para>
		/// </summary>
		public override string ToolName() => "CellStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.CellStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.CellStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRastersOrConstants, OutRaster, StatisticsType!, IgnoreNodata!, ProcessAsMultiband!, PercentileValue!, PercentileInterpolationType! };

		/// <summary>
		/// <para>Input rasters or constant values</para>
		/// <para>A list of input rasters for which a statistical operation will be calculated for each cell in the analysis window.</para>
		/// <para>A number can be used as an input; however, the cell size and extent must first be set in the environment.</para>
		/// <para>If the Process as multiband parameter is checked, all multiband inputs must have an equal number of bands.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRastersOrConstants { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For each cell, the value is determined by applying the specified statistic type to the input rasters at that location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Overlay statistic</para>
		/// <para>Specifies the statistic type to be calculated.</para>
		/// <para>Mean—The mean (average) of the inputs will be calculated. This is the default.</para>
		/// <para>Majority—The majority (value that occurs most often) of the inputs will be determined.</para>
		/// <para>Maximum—The maximum (largest value) of the inputs will be determined.</para>
		/// <para>Median—The median of the inputs will be calculated.</para>
		/// <para>Minimum—The minimum (smallest value) of the inputs will be determined.</para>
		/// <para>Minority—The minority (value that occurs least often) of the inputs will be determined.</para>
		/// <para>Percentile—The percentile of the inputs will be calculated. The 90th percentile is calculated by default. You can specify other values (from 0 to 100) using the Percentile value parameter.</para>
		/// <para>Range—The range (difference between largest and smallest value) of the inputs will be calculated.</para>
		/// <para>Standard deviation—The standard deviation of the inputs will be calculated.</para>
		/// <para>Sum—The sum (total of all values) of the inputs will be calculated.</para>
		/// <para>Variety—The variety (number of unique values) of the inputs will be calculated.</para>
		/// <para>The default statistic type is Mean.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>Specifies whether NoData values will be ignored by the statistic calculation.</para>
		/// <para>Checked—At the processing cell location, if any of the input rasters has NoData, that NoData value will be ignored. The statistics will be computed by only considering the cells with valid data. This is the default.</para>
		/// <para>Unchecked—If the processing cell location for any of the input rasters is NoData, the output for that cell will be NoData.</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Process as multiband</para>
		/// <para>Specifies how the input multiband raster bands will be processed.</para>
		/// <para>Unchecked—Each band from a multiband raster input will be processed separately as a single band raster. This is the default.</para>
		/// <para>Checked—Each multiband raster input will be processed as a multiband raster. The operation will be performed for each band from one input using the corresponding band number from the other inputs.</para>
		/// <para><see cref="ProcessAsMultibandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProcessAsMultiband { get; set; } = "false";

		/// <summary>
		/// <para>Percentile value</para>
		/// <para>The percentile value that will be calculated. The default is 90, indicating the 90th percentile.</para>
		/// <para>The value can range from 0 to 100. The 0th percentile is essentially equivalent to the minimum statistic, and the 100th percentile is equivalent to the maximum statistic. A value of 50 will produce essentially the same result as the median statistic.</para>
		/// <para>This parameter is only available if the Overlay statistic parameter is set to Percentile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 100)]
		public object? PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile interpolation type</para>
		/// <para>Specifies the method of interpolation that will be used when the specified percentile value is between two input cell values.</para>
		/// <para>Auto-detect—If the input rasters are of integer pixel type, the Nearest method will be used. If the input rasters are of floating point pixel type, the Linear method will be used. This is the default.</para>
		/// <para>Nearest—The nearest available value to the desired percentile will be used. In this case, the output pixel type will be the same as that of the input rasters.</para>
		/// <para>Linear—The weighted average of the two surrounding values from the percentile will be used. In this case, the output pixel type will be floating point.</para>
		/// <para><see cref="PercentileInterpolationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PercentileInterpolationType { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CellStatistics SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para>Checked—At the processing cell location, if any of the input rasters has NoData, that NoData value will be ignored. The statistics will be computed by only considering the cells with valid data. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Unchecked—If the processing cell location for any of the input rasters is NoData, the output for that cell will be NoData.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

		/// <summary>
		/// <para>Process as multiband</para>
		/// </summary>
		public enum ProcessAsMultibandEnum 
		{
			/// <summary>
			/// <para>Unchecked—Each band from a multiband raster input will be processed separately as a single band raster. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_BAND")]
			SINGLE_BAND,

			/// <summary>
			/// <para>Checked—Each multiband raster input will be processed as a multiband raster. The operation will be performed for each band from one input using the corresponding band number from the other inputs.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_BAND")]
			MULTI_BAND,

		}

		/// <summary>
		/// <para>Percentile interpolation type</para>
		/// </summary>
		public enum PercentileInterpolationTypeEnum 
		{
			/// <summary>
			/// <para>Auto-detect—If the input rasters are of integer pixel type, the Nearest method will be used. If the input rasters are of floating point pixel type, the Linear method will be used. This is the default.</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("Auto-detect")]
			AUTO_DETECT,

			/// <summary>
			/// <para>Nearest—The nearest available value to the desired percentile will be used. In this case, the output pixel type will be the same as that of the input rasters.</para>
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
