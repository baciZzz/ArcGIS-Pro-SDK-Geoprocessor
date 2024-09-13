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
	/// <para>Block Statistics</para>
	/// <para>Block Statistics</para>
	/// <para>Partitions the input into non-overlapping blocks and calculates the statistic of the values within each block. The value is assigned to all of the cells in each block in the output.</para>
	/// </summary>
	public class BlockStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The raster for which the block statistics will be calculated.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output block statistics raster.</para>
		/// </param>
		public BlockStatistics(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Block Statistics</para>
		/// </summary>
		public override string DisplayName() => "Block Statistics";

		/// <summary>
		/// <para>Tool Name : BlockStatistics</para>
		/// </summary>
		public override string ToolName() => "BlockStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.BlockStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.BlockStatistics";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Neighborhood!, StatisticsType!, IgnoreNodata! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The raster for which the block statistics will be calculated.</para>
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
		/// <para>The output block statistics raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Neighborhood</para>
		/// <para>The cells of the processing block that will be used in the statistic calculation. There are several predefined neighborhood types to choose from, or a custom kernel can be defined.</para>
		/// <para>Once the neighborhood type is selected, other parameters can be set to fully define the shape, size, and units of measure. The default neighborhood is a square rectangle with a width and height of three cells.</para>
		/// <para>The following are the forms of the available neighborhood types:</para>
		/// <para>Annulus, Inner radius, Outer radius, Units typeA torus (donut-shaped) neighborhood defined by an inner radius and an outer radius. The default annulus is an inner radius of one cell and an outer radius of three cells.</para>
		/// <para>Circle, Radius, Units typeA circular neighborhood with the given radius. The default radius is three cells.</para>
		/// <para>Rectangle, Height, Width, Units typeA rectangular neighborhood defined by height and width. The default is a square with a height and width of three cells.</para>
		/// <para>Wedge, Radius, Start angle, End angle, Units typeA wedge-shaped neighborhood defined by a radius, the start angle, and the end angle. The wedge extends counterclockwise from the starting angle to the ending angle. Angles are specified in degrees, with 0 or 360 representing east. Negative angles can be used. The default wedge is from 0 to 90 degrees, with a radius of three cells.</para>
		/// <para>Irregular, Kernel fileA custom neighborhood with specifications set by the identified kernel text file.</para>
		/// <para>Weight, Kernel fileA custom neighborhood with specifications set by the identified kernel text file, which can apply weights to the members of the neighborhood.</para>
		/// <para>For the annulus, circle, rectangle and wedge neighborhood types, the distance units for the parameters can be specified in Cell units or Map units. Cell units is the default.</para>
		/// <para>For kernel neighborhoods, the first line in the kernel file defines the width and height of the neighborhood in numbers of cells. The subsequent lines indicate how the input value that corresponds to that location in the kernel will be processed. A value of 0 in the kernel file for either the irregular or the weight neighborhood type indicates the corresponding location will not be included in the calculation. For the irregular neighborhood, a value of 1 in the kernel file indicates that the corresponding input cell will be included in the operation. For the weight neighborhood, the value at each position indicates what the corresponding input cell value is to be multiplied by. Positive, negative, and decimal values can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSANeighborhood()]
		[GPSANeighborhoodDomain()]
		[NeighbourType("Rectangle", "Circle", "Annulus", "Wedge", "Irregular", "Weight")]
		public object? Neighborhood { get; set; } = "Rectangle 3 3 CELL";

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>Specifies the statistic type to be calculated.</para>
		/// <para>Mean—The mean (average value) of the cells in the neighborhood will be calculated.</para>
		/// <para>Majority—The majority (value that occurs most often) of the cells in the neighborhood will be identified.</para>
		/// <para>Maximum—The maximum (largest value) of the cells in the neighborhood will be identified.</para>
		/// <para>Median—The median of the cells in the neighborhood will be calculated.</para>
		/// <para>Minimum—The minimum (smallest value) of the cells in the neighborhood will be identified.</para>
		/// <para>Minority—The minority (value that occurs least often) of the cells in the neighborhood will be identified.</para>
		/// <para>Range—The range (difference between largest and smallest value) of the cells in the neighborhood will be calculated.</para>
		/// <para>Standard deviation—The standard deviation of the cells in the neighborhood will be calculated.</para>
		/// <para>Sum—The sum of the cells in the neighborhood will be calculated.</para>
		/// <para>Variety—The variety (the number of unique values) of the cells in the neighborhood will be calculated.</para>
		/// <para>The default statistic type is Mean.</para>
		/// <para>If the input raster is integer, all the statistics types will be available. If the input raster is floating point, only the Mean, Maximum, Minimum, Range, Standard deviation, and Sum statistic types will be available.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>Specifies whether NoData values will be ignored by the statistic calculation.</para>
		/// <para>Checked—If a NoData value exists within a block neighborhood, the NoData value will be ignored. Only cells within the neighborhood that have data values will be used in determining the output value. This is the default.</para>
		/// <para>Unchecked—If any cell in a block neighborhood has a value of NoData, the output for each cell in the corresponding block will be NoData. The presence of a NoData value implies that there is insufficient information to determine the statistic value for the neighborhood.</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BlockStatistics SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Mean—The mean (average value) of the cells in the neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Majority—The majority (value that occurs most often) of the cells in the neighborhood will be identified.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority")]
			Majority,

			/// <summary>
			/// <para>Maximum—The maximum (largest value) of the cells in the neighborhood will be identified.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Median—The median of the cells in the neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Minimum—The minimum (smallest value) of the cells in the neighborhood will be identified.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Minority—The minority (value that occurs least often) of the cells in the neighborhood will be identified.</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("Minority")]
			Minority,

			/// <summary>
			/// <para>Range—The range (difference between largest and smallest value) of the cells in the neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("Range")]
			Range,

			/// <summary>
			/// <para>Standard deviation—The standard deviation of the cells in the neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("STD")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Sum—The sum of the cells in the neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

			/// <summary>
			/// <para>Variety—The variety (the number of unique values) of the cells in the neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("VARIETY")]
			[Description("Variety")]
			Variety,

		}

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para>Checked—If a NoData value exists within a block neighborhood, the NoData value will be ignored. Only cells within the neighborhood that have data values will be used in determining the output value. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Unchecked—If any cell in a block neighborhood has a value of NoData, the output for each cell in the corresponding block will be NoData. The presence of a NoData value implies that there is insufficient information to determine the statistic value for the neighborhood.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
