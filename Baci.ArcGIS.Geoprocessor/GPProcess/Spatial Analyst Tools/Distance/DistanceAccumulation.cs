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
	/// <para>Distance Accumulation</para>
	/// <para>Distance Accumulation</para>
	/// <para>Calculates accumulated distance for each cell to sources, allowing for straight-line distance, cost distance, and true surface distance, as well as vertical and horizontal cost factors.</para>
	/// </summary>
	public class DistanceAccumulation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceData">
		/// <para>Input raster or feature source data</para>
		/// <para>The input source locations.</para>
		/// <para>This is a raster or feature (point, line, or polygon) identifying the cells or locations that will be used to calculate the least accumulated cost distance for each output cell location.</para>
		/// <para>For rasters, the input type can be integer or floating point.</para>
		/// </param>
		/// <param name="OutDistanceAccumulationRaster">
		/// <para>Output distance accumulation raster</para>
		/// <para>The output distance raster.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </param>
		public DistanceAccumulation(object InSourceData, object OutDistanceAccumulationRaster)
		{
			this.InSourceData = InSourceData;
			this.OutDistanceAccumulationRaster = OutDistanceAccumulationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Distance Accumulation</para>
		/// </summary>
		public override string DisplayName() => "Distance Accumulation";

		/// <summary>
		/// <para>Tool Name : DistanceAccumulation</para>
		/// </summary>
		public override string ToolName() => "DistanceAccumulation";

		/// <summary>
		/// <para>Tool Excute Name : sa.DistanceAccumulation</para>
		/// </summary>
		public override string ExcuteName() => "sa.DistanceAccumulation";

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
		public override object[] Parameters() => new object[] { InSourceData, OutDistanceAccumulationRaster, InBarrierData!, InSurfaceRaster!, InCostRaster!, InVerticalRaster!, VerticalFactor!, InHorizontalRaster!, HorizontalFactor!, OutBackDirectionRaster!, OutSourceDirectionRaster!, OutSourceLocationRaster!, SourceInitialAccumulation!, SourceMaximumAccumulation!, SourceCostMultiplier!, SourceDirection!, DistanceMethod! };

		/// <summary>
		/// <para>Input raster or feature source data</para>
		/// <para>The input source locations.</para>
		/// <para>This is a raster or feature (point, line, or polygon) identifying the cells or locations that will be used to calculate the least accumulated cost distance for each output cell location.</para>
		/// <para>For rasters, the input type can be integer or floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSourceData { get; set; }

		/// <summary>
		/// <para>Output distance accumulation raster</para>
		/// <para>The output distance raster.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutDistanceAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Input barrier raster or feature data</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be defined by an integer or a floating-point raster, or by a point, line, or polygon feature.</para>
		/// <para>For a raster barrier, the barrier must have a valid value, including zero, and the areas that are not barriers must be NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InBarrierData { get; set; }

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>A raster defining the elevation values at each cell location.</para>
		/// <para>The values are used to calculate the actual surface distance covered when passing between cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Input cost raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InCostRaster { get; set; }

		/// <summary>
		/// <para>Input vertical raster</para>
		/// <para>A raster defining the z-values for each cell location.</para>
		/// <para>The values are used for calculating the slope used to identify the vertical factor incurred when moving from one cell to another.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		[Category("Costs relative to vertical movement (optional)")]
		public object? InVerticalRaster { get; set; }

		/// <summary>
		/// <para>Vertical factor</para>
		/// <para>Specifies the relationship between the vertical cost factor and the vertical relative moving angle (VRMA).</para>
		/// <para>There are several factors with modifiers that identify a defined vertical factor graph. Additionally, a table can be used to create a custom graph. The graphs are used to identify the vertical factor used in calculating the total cost for moving into a neighboring cell.</para>
		/// <para>In the descriptions below, two acronyms are used: VF stands for vertical factor, which defines the vertical difficulty encountered in moving from one cell to the next; and VRMA stands for vertical relative moving angle, which identifies the slope angle between the FROM or processing cell and the TO cell.</para>
		/// <para>The Vertical factor options are as follows:</para>
		/// <para>Binary—If the VRMA is greater than the low-cut angle and less than the high-cut angle, the VF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Linear—The VF is a linear function of the VRMA.</para>
		/// <para>Symmetric Linear—The VF is a linear function of the VRMA in either the negative or positive side of the VRMA, respectively, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Inverse Linear—The VF is an inverse linear function of the VRMA.</para>
		/// <para>Symmetric Inverse Linear—The VF is an inverse linear function of the VRMA in either the negative or positive side of the VRMA, respectively, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Cos—The VF is the cosine-based function of the VRMA.</para>
		/// <para>Sec—The VF is the secant-based function of the VRMA.</para>
		/// <para>Cos-Sec—The VF is the cosine-based function of the VRMA when the VRMA is negative and is the secant-based function of the VRMA when the VRMA is not negative.</para>
		/// <para>Sec-Cos—The VF is the secant-based function of the VRMA when the VRMA is negative and is the cosine-based function of the VRMA when the VRMA is not negative.</para>
		/// <para>Table—A table file will be used to define the vertical-factor graph that is used to determine the VFs.</para>
		/// <para>Modifiers to the vertical keywords are the following:</para>
		/// <para>Zero factor—The vertical factor used when the VRMA is zero. This factor positions the y-intercept of the specified function. By definition, the zero factor is not applicable to any of the trigonometric vertical functions (COS, SEC, COS-SEC, or SEC-COS). The y-intercept is defined by these functions.</para>
		/// <para>Low Cut angle—The VRMA angle below which the VF will be set to infinity.</para>
		/// <para>High Cut angle—The VRMA angle above which the VF will be set to infinity.</para>
		/// <para>Slope—The slope of the straight line used with the Linear and Inverse Linear vertical-factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// <para>Table name—The name of the table defining the VF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAVerticalFactor()]
		[Category("Costs relative to vertical movement (optional)")]
		public object? VerticalFactor { get; set; } = "BINARY 1 -30 30";

		/// <summary>
		/// <para>Input horizontal raster</para>
		/// <para>A raster defining the horizontal direction at each cell.</para>
		/// <para>The values on the raster must be integers ranging from 0 to 360, with 0 degrees being north, or toward the top of the screen, and increasing clockwise. Flat areas should be given a value of -1. The values at each location will be used in conjunction with the Horizontal factor parameter to determine the horizontal cost incurred when moving from a cell to its neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		[Category("Costs relative to horizontal movement (optional)")]
		public object? InHorizontalRaster { get; set; }

		/// <summary>
		/// <para>Horizontal factor</para>
		/// <para>Specifies the relationship between the horizontal cost factor and the horizontal relative moving angle (HRMA).</para>
		/// <para>There are several factors with modifiers that identify a defined horizontal factor graph. Additionally, a table can be used to create a custom graph. The graphs are used to identify the horizontal factor used in calculating the total cost of moving into a neighboring cell.</para>
		/// <para>In the descriptions below, two acronyms are used: HF stands for horizontal factor, which defines the horizontal difficulty encountered when moving from one cell to the next; and HRMA stands for horizontal relative moving angle, which identifies the angle between the horizontal direction from a cell and the moving direction.</para>
		/// <para>The Horizontal factor options are as follows:</para>
		/// <para>Binary—If the HRMA is less than the cut angle, the HF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Forward—Only forward movement is allowed. The HRMA must be greater than or equal to 0 and less than 90 degrees (0 &lt;= HRMA &lt; 90). If the HRMA is greater than 0 and less than 45 degrees, the HF for the cell is set to the value associated with the zero factor. If the HRMA is greater than or equal to 45 degrees, the side value modifier value is used. The HF for any HRMA equal to or greater than 90 degrees is set to infinity.</para>
		/// <para>Linear—The HF is a linear function of the HRMA.</para>
		/// <para>Inverse Linear—The HF is an inverse linear function of the HRMA.</para>
		/// <para>Table—A table file will be used to define the horizontal factor graph used to determine the HFs.</para>
		/// <para>Modifiers to the horizontal factors are the following:</para>
		/// <para>Zero factor—The horizontal factor to be used when the HRMA is zero. This factor positions the y-intercept for any of the horizontal factor functions.</para>
		/// <para>Cut angle—The HRMA angle beyond which the HF will be set to infinity.</para>
		/// <para>Slope—The slope of the straight line used with the Linear and Inverse Linear horizontal factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// <para>Side value—The HF when the HRMA is greater than or equal to 45 degrees and less than 90 degrees when the Forward horizontal-factor keyword is specified.</para>
		/// <para>Table name—The name of the table defining the HF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAHorizontalFactor()]
		[Category("Costs relative to horizontal movement (optional)")]
		public object? HorizontalFactor { get; set; } = "BINARY 1 45";

		/// <summary>
		/// <para>Out back direction raster</para>
		/// <para>The back direction raster contains the calculated direction in degrees. The direction identifies the next cell along the shortest path back to the closest source while avoiding barriers.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees, with 0 reserved for the source cells. Due east (right) is 90, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// <para>The output raster is of type float.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutBackDirectionRaster { get; set; }

		/// <summary>
		/// <para>Out source direction raster</para>
		/// <para>The source direction raster identifies the direction of the least accumulated cost source cell as an azimuth in degrees.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees, with 0 reserved for the source cells. Due east (right) is 90, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// <para>The output raster is of type float.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Additional output rasters (optional)")]
		public object? OutSourceDirectionRaster { get; set; }

		/// <summary>
		/// <para>Out source location raster</para>
		/// <para>The source location raster is a multiband output. The first band contains a row index, and the second band contains a column index. These indexes identify the location of the source cell that is the least accumulated cost distance away.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Additional output rasters (optional)")]
		public object? OutSourceLocationRaster { get; set; }

		/// <summary>
		/// <para>Initial accumulation</para>
		/// <para>The initial accumulative cost that will be used to begin the cost calculation.</para>
		/// <para>Allows for the specification of the fixed cost associated with a source. Instead of starting at a cost of zero, the cost algorithm will begin with the value set by Initial accumulation.</para>
		/// <para>The values must be zero or greater. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object? SourceInitialAccumulation { get; set; }

		/// <summary>
		/// <para>Maximum accumulation</para>
		/// <para>The maximum accumulation for the traveler for a source.</para>
		/// <para>The cost calculations continue for each source until the specified accumulation is reached.</para>
		/// <para>The values must be greater than zero. The default accumulation is to the edge of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object? SourceMaximumAccumulation { get; set; }

		/// <summary>
		/// <para>Multiplier to apply to costs</para>
		/// <para>The multiplier that will be applied to the cost values.</para>
		/// <para>This allows for control of the mode of travel or the magnitude at a source. The greater the multiplier, the greater the cost to move through each cell.</para>
		/// <para>The values must be greater than zero. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object? SourceCostMultiplier { get; set; }

		/// <summary>
		/// <para>Travel direction</para>
		/// <para>Specifies the direction of the traveler when applying horizontal and vertical factors.</para>
		/// <para>Travel from source—The horizontal factor and vertical factor will be applied beginning at the input source and travel out to the nonsource cells. This is the default.</para>
		/// <para>Travel to source—The horizontal factor and vertical factor will be applied beginning at each nonsource cell and travel back to the input source.</para>
		/// <para>If you select the String option, you can choose between from and to options, which will be applied to all sources.</para>
		/// <para>If you select the Field option, you can select the field from the source data that determines the direction to use for each source. The field must contain the text string FROM_SOURCE or TO_SOURCE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object? SourceDirection { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies whether the distance will be calculated using a planar (flat earth) or a geodesic (ellipsoid) method.</para>
		/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
		/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Regardless of input or output projection, the results will not change.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DistanceAccumulation SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Regardless of input or output projection, the results will not change.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
