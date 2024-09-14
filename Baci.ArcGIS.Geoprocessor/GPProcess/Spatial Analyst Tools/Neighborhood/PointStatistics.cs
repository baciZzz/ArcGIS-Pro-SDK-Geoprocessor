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
	/// <para>Point Statistics</para>
	/// <para>Point Statistics</para>
	/// <para>Calculates a statistic on the points in a neighborhood around each output cell.</para>
	/// </summary>
	public class PointStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>The input points to use in the neighborhood operation.</para>
		/// <para>For each output cell, any input points that fall within the defined neighborhood shape around it are identified. For the selected points, values from the specified attribute are obtained, and a statistic is calculated.</para>
		/// <para>The input can be either a point or multipoint feature class.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>The field for which the specified statistic will be calculated. It can be any numeric field of the input point features.</para>
		/// <para>It can be the Shape field if the input features contain z-values.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output point statistics raster.</para>
		/// </param>
		public PointStatistics(object InPointFeatures, object Field, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.Field = Field;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Point Statistics</para>
		/// </summary>
		public override string DisplayName() => "Point Statistics";

		/// <summary>
		/// <para>Tool Name : PointStatistics</para>
		/// </summary>
		public override string ToolName() => "PointStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.PointStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.PointStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, Field, OutRaster, CellSize!, Neighborhood!, StatisticsType! };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>The input points to use in the neighborhood operation.</para>
		/// <para>For each output cell, any input points that fall within the defined neighborhood shape around it are identified. For the selected points, values from the specified attribute are obtained, and a statistic is calculated.</para>
		/// <para>The input can be either a point or multipoint feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>The field for which the specified statistic will be calculated. It can be any numeric field of the input point features.</para>
		/// <para>It can be the Shape field if the input features contain z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output point statistics raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Neighborhood</para>
		/// <para>The area around each processing cell within which any input points found will be used in the statistics calculation. There are several predefined neighborhood types to choose from.</para>
		/// <para>Once the neighborhood type is selected, other parameters can be set to fully define the shape, size, and units of measure. The default neighborhood is a square rectangle with a width and height of three cells.</para>
		/// <para>The following are the forms of the available neighborhood types:</para>
		/// <para>Annulus, Inner radius, Outer radius, Units typeA torus (donut-shaped) neighborhood defined by an inner radius and an outer radius. The default annulus is an inner radius of one cell and an outer radius of three cells.</para>
		/// <para>Circle, Radius, Units typeA circular neighborhood with the given radius. The default radius is three cells.</para>
		/// <para>Rectangle, Height, Width, Units typeA rectangular neighborhood defined by height and width. The default is a square with a height and width of three cells.</para>
		/// <para>Wedge, Radius, Start angle, End angle, Units typeA wedge-shaped neighborhood defined by a radius, the start angle, and the end angle. The wedge extends counterclockwise from the starting angle to the ending angle. Angles are specified in degrees, with 0 or 360 representing east. Negative angles can be used. The default wedge is from 0 to 90 degrees, with a radius of three cells.</para>
		/// <para>The distance units for the parameters can be specified in Cell units or Map units. Cell units is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSANeighborhood()]
		[GPSANeighborhoodDomain()]
		[NeighbourType("Rectangle", "Circle", "Annulus", "Wedge")]
		public object? Neighborhood { get; set; } = "Rectangle 3 3 CELL";

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>Specifies the statistic type to be calculated.</para>
		/// <para>The calculation is performed on the values of the specified field of the points that fall within the specified neighborhood of each output raster cell.</para>
		/// <para>Mean—The average of the field values in each neighborhood will be calculated.</para>
		/// <para>Majority—The most frequently occurring field value in each neighborhood will be identified. In the case of a tie, the lower value is used.</para>
		/// <para>Maximum—The largest field value in each neighborhood will be identified.</para>
		/// <para>Median—The median field value in each neighborhood will be calculated. In the case of an even number of points in the neighborhood, the result will be the lower of the two middle values.</para>
		/// <para>Minimum—The smallest field value in each neighborhood will be identified.</para>
		/// <para>Minority—The least frequently occurring field value in each neighborhood will be identified. In the case of a tie, the lower value is used.</para>
		/// <para>Range—The range (the difference between the largest and smallest) of the field values in each neighborhood will be calculated.</para>
		/// <para>Standard Deviation—The standard deviation of the field values in each neighborhood will be calculated.</para>
		/// <para>Sum—The sum of the field values in the neighborhood will be calculated.</para>
		/// <para>Variety—The number of unique field values in each neighborhood will be calculated.</para>
		/// <para>The default statistic type is Mean.</para>
		/// <para>The available choices for the statistic type are determined by the numeric type of the specified field. If the field is integer, all the statistics types will be available. If the field is floating point, only the maximum, mean, minimum, range, standard deviation, and sum statistics will be available.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointStatistics SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Mean—The average of the field values in each neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Majority—The most frequently occurring field value in each neighborhood will be identified. In the case of a tie, the lower value is used.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority")]
			Majority,

			/// <summary>
			/// <para>Maximum—The largest field value in each neighborhood will be identified.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Median—The median field value in each neighborhood will be calculated. In the case of an even number of points in the neighborhood, the result will be the lower of the two middle values.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Minimum—The smallest field value in each neighborhood will be identified.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Minority—The least frequently occurring field value in each neighborhood will be identified. In the case of a tie, the lower value is used.</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("Minority")]
			Minority,

			/// <summary>
			/// <para>Range—The range (the difference between the largest and smallest) of the field values in each neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("Range")]
			Range,

			/// <summary>
			/// <para>Standard Deviation—The standard deviation of the field values in each neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("STD")]
			[Description("Standard Deviation")]
			Standard_Deviation,

			/// <summary>
			/// <para>Sum—The sum of the field values in the neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

			/// <summary>
			/// <para>Variety—The number of unique field values in each neighborhood will be calculated.</para>
			/// </summary>
			[GPValue("VARIETY")]
			[Description("Variety")]
			Variety,

		}

#endregion
	}
}
