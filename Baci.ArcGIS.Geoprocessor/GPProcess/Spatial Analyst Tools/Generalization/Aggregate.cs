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
	/// <para>Aggregate</para>
	/// <para>Generates a reduced-resolution version of a raster. Each output cell contains the Sum, Minimum, Maximum, Mean, or Median of the input cells that are encompassed by the extent of that cell.</para>
	/// </summary>
	public class Aggregate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to aggregate.</para>
		/// <para>It can be of integer or floating point type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output aggregated raster.</para>
		/// <para>It is a reduced-resolution version of the input raster.</para>
		/// </param>
		/// <param name="CellFactor">
		/// <para>Cell factor</para>
		/// <para>The factor by which to multiply the cell size of the input raster to obtain the desired resolution for the output raster.</para>
		/// <para>For example, a cell factor value of three would result in an output cell size three times larger than that of the input raster.</para>
		/// <para>The value must be an integer greater than 1.</para>
		/// </param>
		public Aggregate(object InRaster, object OutRaster, object CellFactor)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.CellFactor = CellFactor;
		}

		/// <summary>
		/// <para>Tool Display Name : Aggregate</para>
		/// </summary>
		public override string DisplayName => "Aggregate";

		/// <summary>
		/// <para>Tool Name : Aggregate</para>
		/// </summary>
		public override string ToolName => "Aggregate";

		/// <summary>
		/// <para>Tool Excute Name : sa.Aggregate</para>
		/// </summary>
		public override string ExcuteName => "sa.Aggregate";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRaster, CellFactor, AggregationType, ExtentHandling, IgnoreNodata };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to aggregate.</para>
		/// <para>It can be of integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output aggregated raster.</para>
		/// <para>It is a reduced-resolution version of the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Cell factor</para>
		/// <para>The factor by which to multiply the cell size of the input raster to obtain the desired resolution for the output raster.</para>
		/// <para>For example, a cell factor value of three would result in an output cell size three times larger than that of the input raster.</para>
		/// <para>The value must be an integer greater than 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		public object CellFactor { get; set; }

		/// <summary>
		/// <para>Aggregation technique</para>
		/// <para>Establishes how the value for each output cell will be determined.</para>
		/// <para>The values of the input cells encompassed by the coarser output cell are aggregated by one of the following statistics:</para>
		/// <para>Sum—The sum (total) of the input cell values.This is the default.</para>
		/// <para>Maximum—The largest value of the input cells.</para>
		/// <para>Mean—The average value of the input cells.</para>
		/// <para>Median—The median value of the input cells.</para>
		/// <para>Minimum—The smallest value of the input cells.</para>
		/// <para><see cref="AggregationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AggregationType { get; set; } = "SUM";

		/// <summary>
		/// <para>Expand extent if needed</para>
		/// <para>Defines how to handle the boundaries of the input raster when its rows or columns are not a multiple of the cell factor.</para>
		/// <para>Checked—Expands the top or right boundaries of the input raster so the total number of cells in a row or column is a multiple of the cell factor. Those expanded cells are given a value of NoData when put into the calculation.With this option, the output raster can cover a larger spatial extent than the input raster.</para>
		/// <para>This is the default.</para>
		/// <para>Unchecked—Reduces the number of rows or columns in the output raster. This will truncate the remaining cells on the top or right boundaries of the input raster, making the number of rows or columns in the input raster a multiple of the cell factor.With this option, the output raster can cover a smaller spatial extent than the input raster.</para>
		/// <para>If the number of rows and columns in the input raster is a multiple of the Cell factor, these keywords are not used.</para>
		/// <para><see cref="ExtentHandlingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExtentHandling { get; set; } = "true";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>Denotes whether NoData values are ignored by the aggregation calculation.</para>
		/// <para>Checked—Specifies that if NoData values exist for any of the cells that fall within the spatial extent of a larger cell on the output raster, the NoData values will be ignored when determining the value for output cell locations. Only input cells within the extent of the output cell that have data values will be used in determining the value of the output cell.This is the default.</para>
		/// <para>Unchecked—Specifies that if any cell that falls within the spatial extent of a larger cell on the output raster has a value of NoData, the value for that output cell location will be NoData.When Unchecked is used, it is implied that when cells within an aggregation contain the NoData value, there is insufficient information to perform the specified calculations necessary to determine an output value.</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Aggregate SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Aggregation technique</para>
		/// </summary>
		public enum AggregationTypeEnum 
		{
			/// <summary>
			/// <para>Sum—The sum (total) of the input cell values.This is the default.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

			/// <summary>
			/// <para>Maximum—The largest value of the input cells.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Mean—The average value of the input cells.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Median—The median value of the input cells.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Minimum—The smallest value of the input cells.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

		}

		/// <summary>
		/// <para>Expand extent if needed</para>
		/// </summary>
		public enum ExtentHandlingEnum 
		{
			/// <summary>
			/// <para>Checked—Expands the top or right boundaries of the input raster so the total number of cells in a row or column is a multiple of the cell factor. Those expanded cells are given a value of NoData when put into the calculation.With this option, the output raster can cover a larger spatial extent than the input raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPAND")]
			EXPAND,

			/// <summary>
			/// <para>Unchecked—Reduces the number of rows or columns in the output raster. This will truncate the remaining cells on the top or right boundaries of the input raster, making the number of rows or columns in the input raster a multiple of the cell factor.With this option, the output raster can cover a smaller spatial extent than the input raster.</para>
			/// </summary>
			[GPValue("false")]
			[Description("TRUNCATE")]
			TRUNCATE,

		}

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para>Checked—Specifies that if NoData values exist for any of the cells that fall within the spatial extent of a larger cell on the output raster, the NoData values will be ignored when determining the value for output cell locations. Only input cells within the extent of the output cell that have data values will be used in determining the value of the output cell.This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Unchecked—Specifies that if any cell that falls within the spatial extent of a larger cell on the output raster has a value of NoData, the value for that output cell location will be NoData.When Unchecked is used, it is implied that when cells within an aggregation contain the NoData value, there is insufficient information to perform the specified calculations necessary to determine an output value.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
