using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Zonal Statistics As Table</para>
	/// <para>Calculates the values of a raster within the zones of another dataset and reports the results to a table.</para>
	/// </summary>
	public class ZonalStatisticsAsTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputzonerasterorfeatures">
		/// <para>Input Zone Raster or Features</para>
		/// <para>The input that defines the zones.</para>
		/// <para>Both raster and feature data can be used for the zone input.</para>
		/// </param>
		/// <param name="Inputvalueraster">
		/// <para>Input Value Raster</para>
		/// <para>The raster that contains the values on which to summarize a statistic.</para>
		/// </param>
		/// <param name="Outputtablename">
		/// <para>Output Table Name</para>
		/// <para>The name of the output table.</para>
		/// <para>If the table already exists, you will be prompted to provide another name.</para>
		/// </param>
		/// <param name="Zonefield">
		/// <para>Zone Field</para>
		/// <para>The field that defines each zone.</para>
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </param>
		public ZonalStatisticsAsTable(object Inputzonerasterorfeatures, object Inputvalueraster, object Outputtablename, object Zonefield)
		{
			this.Inputzonerasterorfeatures = Inputzonerasterorfeatures;
			this.Inputvalueraster = Inputvalueraster;
			this.Outputtablename = Outputtablename;
			this.Zonefield = Zonefield;
		}

		/// <summary>
		/// <para>Tool Display Name : Zonal Statistics As Table</para>
		/// </summary>
		public override string DisplayName() => "Zonal Statistics As Table";

		/// <summary>
		/// <para>Tool Name : ZonalStatisticsAsTable</para>
		/// </summary>
		public override string ToolName() => "ZonalStatisticsAsTable";

		/// <summary>
		/// <para>Tool Excute Name : ra.ZonalStatisticsAsTable</para>
		/// </summary>
		public override string ExcuteName() => "ra.ZonalStatisticsAsTable";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputzonerasterorfeatures, Inputvalueraster, Outputtablename, Zonefield, Ignorenodata, Statistictype, Percentilevalues, Processasmultidimensional, Outputtable, Percentileinterpolationtype };

		/// <summary>
		/// <para>Input Zone Raster or Features</para>
		/// <para>The input that defines the zones.</para>
		/// <para>Both raster and feature data can be used for the zone input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputzonerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Value Raster</para>
		/// <para>The raster that contains the values on which to summarize a statistic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputvalueraster { get; set; }

		/// <summary>
		/// <para>Output Table Name</para>
		/// <para>The name of the output table.</para>
		/// <para>If the table already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputtablename { get; set; }

		/// <summary>
		/// <para>Zone Field</para>
		/// <para>The field that defines each zone.</para>
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Zonefield { get; set; }

		/// <summary>
		/// <para>Ignore Nodata</para>
		/// <para>Specifies whether NoData values in the value input will be ignored in the results of the zone that they fall within.</para>
		/// <para>Checked—Within any particular zone, only cells that have a value in the input value raster will be used in determining the output value for that zone. NoData cells in the value raster will be ignored in the statistic calculation. This is the default.</para>
		/// <para>Unchecked—Within any particular zone, if NoData cells exist in the value raster, they will not be ignored and their existence indicates that there is insufficient information to perform statistical calculations for all the cells in that zone. Consequently, the entire zone will receive the NoData value on the output raster.</para>
		/// <para><see cref="IgnorenodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Ignorenodata { get; set; } = "false";

		/// <summary>
		/// <para>Statistic Type</para>
		/// <para>Specifies the statistic type to calculate.</para>
		/// <para>The available options when the value raster is integer are All, Mean, Majority, Maximum, Median, Minimum, Minority, Percentile, Range, Standard deviation, Sum, Variety, Minimum and Maximum, Mean and Standard deviation, and Minimum, Maximum and Mean.</para>
		/// <para>If the value raster is float, the options are All, Mean, Maximum, Median, Percentile, Minimum, Range, Standard deviation, and Sum.</para>
		/// <para>All—All of the statistics will be calculated for an integer type value raster. All statistics except Median and Percentile will be calculated for a floating-point type value raster. This is the default.</para>
		/// <para>Mean—The mean of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Majority—The value that occurs most often of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Maximum—The largest value of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Median—The median value of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Minimum—The smallest value of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Minority—The value that occurs least often of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Percentile—The percentile of all cells in the value raster that belong to the same zone as the output cell will be calculated. The 90th percentile is calculated by default. You can specify other values (from 0 to 100) using the Percentile Values parameter.</para>
		/// <para>Range—The difference between the largest and smallest value of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Standard deviation—The standard deviation of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Sum—The total value of all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Variety—The number of unique values for all cells in the raster layer to be summarized that belong to the same zone as the output cell will be calculated.</para>
		/// <para>Minimum and Maximum—Both the minimum and maximum statistics will be calculated.</para>
		/// <para>Mean and Standard deviation—Both the mean and standard deviation statistics will be calculated.</para>
		/// <para>Minimum, Maximum and Mean—The minimum, maximum, and mean statistics will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Statistictype { get; set; } = "ALL";

		/// <summary>
		/// <para>Percentile Values</para>
		/// <para>The percentile to calculate. The default is 90, indicating the 90th percentile.</para>
		/// <para>The values can range from 0 to 100. The 0th percentile is essentially equivalent to the minimum statistic, and the 100th percentile is equivalent to maximum. A value of 50 will produce essentially the same result as the median statistic.</para>
		/// <para>This option is only available if the Statistic Type parameter is set to Percentile or All.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Percentilevalues { get; set; } = "90";

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>Specifies how the input rasters will be processed if they are multidimensional.</para>
		/// <para>Unchecked—Statistics will be calculated from the current slice of the input multidimensional dataset. This is the default.</para>
		/// <para>Checked— Statistics will be calculated for all dimensions (such as time or depth) from all slices of the multidimensional input rasters.</para>
		/// <para><see cref="ProcessasmultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Processasmultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object Outputtable { get; set; }

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// <para>Specifies the method of percentile interpolation to be used when the number of values from the input raster to be calculated are even.</para>
		/// <para>Auto-detect—If the input value raster is of integer pixel type, the Nearest method is used. If the input value raster is of floating point pixel type, the Linear method is used. This is the default.</para>
		/// <para>Nearest—The nearest available value to the desired percentile is used.</para>
		/// <para>Linear—The weighted average of the two surrounding values from the desired percentile is used.</para>
		/// <para><see cref="PercentileinterpolationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Percentileinterpolationtype { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalStatisticsAsTable SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore Nodata</para>
		/// </summary>
		public enum IgnorenodataEnum 
		{
			/// <summary>
			/// <para>Checked—Within any particular zone, only cells that have a value in the input value raster will be used in determining the output value for that zone. NoData cells in the value raster will be ignored in the statistic calculation. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NODATA")]
			NODATA,

			/// <summary>
			/// <para>Unchecked—Within any particular zone, if NoData cells exist in the value raster, they will not be ignored and their existence indicates that there is insufficient information to perform statistical calculations for all the cells in that zone. Consequently, the entire zone will receive the NoData value on the output raster.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA")]
			DATA,

		}

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// </summary>
		public enum ProcessasmultidimensionalEnum 
		{
			/// <summary>
			/// <para>Checked— Statistics will be calculated for all dimensions (such as time or depth) from all slices of the multidimensional input rasters.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

			/// <summary>
			/// <para>Unchecked—Statistics will be calculated from the current slice of the input multidimensional dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

		}

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// </summary>
		public enum PercentileinterpolationtypeEnum 
		{
			/// <summary>
			/// <para>Auto-detect—If the input value raster is of integer pixel type, the Nearest method is used. If the input value raster is of floating point pixel type, the Linear method is used. This is the default.</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("Auto-detect")]
			AUTO_DETECT,

			/// <summary>
			/// <para>Nearest—The nearest available value to the desired percentile is used.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Linear—The weighted average of the two surrounding values from the desired percentile is used.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

		}

#endregion
	}
}
