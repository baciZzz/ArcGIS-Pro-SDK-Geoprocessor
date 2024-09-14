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
	/// <para>Distance Accumulation</para>
	/// <para>Distance Accumulation</para>
	/// <para>Calculates accumulated distance for each cell to sources, allowing for straight-line distance, cost distance, and true surface distance, as well as vertical and horizontal cost factors.</para>
	/// </summary>
	public class DistanceAccumulation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsourcerasterorfeatures">
		/// <para>Input source raster or features</para>
		/// <para>The input source locations.</para>
		/// <para>This is an image service or feature service that identifies the cells or locations from which, or to which, the least accumulated cost distance for every output cell location is calculated.</para>
		/// <para>For an image service, the input type can be integer or floating point.</para>
		/// </param>
		/// <param name="Outputdistanceaccumulationrastername">
		/// <para>Out distance accumulation raster name</para>
		/// <para>The output distance accumulation raster name.</para>
		/// <para>The distance accumulation raster contains the accumulative distance for each cell from, or to, the least-cost source.</para>
		/// </param>
		public DistanceAccumulation(object Inputsourcerasterorfeatures, object Outputdistanceaccumulationrastername)
		{
			this.Inputsourcerasterorfeatures = Inputsourcerasterorfeatures;
			this.Outputdistanceaccumulationrastername = Outputdistanceaccumulationrastername;
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
		/// <para>Tool Excute Name : ra.DistanceAccumulation</para>
		/// </summary>
		public override string ExcuteName() => "ra.DistanceAccumulation";

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
		public override object[] Parameters() => new object[] { Inputsourcerasterorfeatures, Outputdistanceaccumulationrastername, Inputbarrierrasterorfeatures, Inputsurfaceraster, Inputcostraster, Inputverticalraster, Verticalfactor, Inputhorizontalraster, Horizontalfactor, Outputbackdirectionrastername, Outputsourcedirectionrastername, Outputsourcelocationrastername, Sourceinitialaccumulation, Sourcemaximumaccumulation, Sourcecostmultiplier, Sourcedirection, Distancemethod, Outputdistanceaccumulationraster, Outputbackdirectionraster, Outputsourcedirectionraster, Outputsourcelocationraster };

		/// <summary>
		/// <para>Input source raster or features</para>
		/// <para>The input source locations.</para>
		/// <para>This is an image service or feature service that identifies the cells or locations from which, or to which, the least accumulated cost distance for every output cell location is calculated.</para>
		/// <para>For an image service, the input type can be integer or floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsourcerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Out distance accumulation raster name</para>
		/// <para>The output distance accumulation raster name.</para>
		/// <para>The distance accumulation raster contains the accumulative distance for each cell from, or to, the least-cost source.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputdistanceaccumulationrastername { get; set; }

		/// <summary>
		/// <para>Input barrier raster or features</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be defined by an integer or a floating-point image service, or by a feature service.</para>
		/// <para>For an image service barrier, the barrier must have a valid value, including zero, and the areas that are not barriers must be NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputbarrierrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>An image service defining the elevation values at each cell location.</para>
		/// <para>The values are used to calculate the actual surface distance covered when passing between cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Input cost raster</para>
		/// <para>An image service defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Input vertical raster</para>
		/// <para>An image service defining the z-values for each cell location.</para>
		/// <para>The values are used for calculating the slope used to identify the vertical factor incurred when moving from one cell to another.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Costs relative to vertical movement (optional)")]
		public object Inputverticalraster { get; set; }

		/// <summary>
		/// <para>Vertical factor</para>
		/// <para>Specifies the relationship between the vertical cost factor and the vertical relative moving angle (VRMA).</para>
		/// <para>There are several factors with modifiers from which to select that identify a defined vertical factor graph. The graphs are used to identify the vertical factor used in calculating the total cost for moving into a neighboring cell.</para>
		/// <para>In the descriptions below, vertical factor (VF) defines the vertical difficulty encountered in moving from one cell to the next, and vertical relative moving angle (VRMA) identifies the slope angle between the FROM or processing cell and the TO cell.</para>
		/// <para>The Vertical factor options are as follows:</para>
		/// <para>Binary—If the VRMA is greater than the low-cut angle and less than the high-cut angle, the VF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Linear—The VF is a linear function of the VRMA.</para>
		/// <para>Symmetric Linear—The VF is a linear function of the VRMA in either the negative or positive side of the VRMA, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Inverse Linear—The VF is an inverse linear function of the VRMA.</para>
		/// <para>Symmetric Inverse Linear—The VF is an inverse linear function of the VRMA in either the negative or positive side of the VRMA, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Cos—The VF is the cosine-based function of the VRMA.</para>
		/// <para>Sec—The VF is the secant-based function of the VRMA.</para>
		/// <para>Cos-Sec—The VF is the cosine-based function of the VRMA when the VRMA is negative and is the secant-based function of the VRMA when the VRMA is nonnegative.</para>
		/// <para>Sec-Cos—The VF is the secant-based function of the VRMA when the VRMA is negative and is the cosine-based function of the VRMA when the VRMA is nonnegative.</para>
		/// <para>Modifiers to the vertical keywords are as follows:</para>
		/// <para>Zero factor—The vertical factor used when the VRMA is zero. This factor positions the y-intercept of the specified function. By definition, the zero factor is not applicable to any of the trigonometric vertical functions (COS, SEC, COS-SEC, or SEC-COS). The y-intercept is defined by these functions.</para>
		/// <para>Low Cut angle—The VRMA angle below which the VF will be set to infinity.</para>
		/// <para>High Cut angle—The VRMA angle above which the VF will be set to infinity.</para>
		/// <para>Slope—The slope of the straight line used with the Linear and Inverse Linear vertical factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAVerticalFactor()]
		[Category("Costs relative to vertical movement (optional)")]
		public object Verticalfactor { get; set; } = "BINARY 1 -30 30";

		/// <summary>
		/// <para>Input horizontal raster</para>
		/// <para>An image service defining the horizontal direction at each cell.</para>
		/// <para>The values on the raster must be integers ranging from 0 to 360, with 0 degrees being north, or toward the top of the screen, and increasing clockwise. Flat areas should be given a value of -1. The values at each location will be used in conjunction with the Horizontal factor parameter to determine the horizontal cost incurred when moving from a cell to its neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Costs relative to horizontal movement (optional)")]
		public object Inputhorizontalraster { get; set; }

		/// <summary>
		/// <para>Horizontal factor</para>
		/// <para>Specifies the relationship between the horizontal cost factor and the horizontal relative moving angle (HRMA).</para>
		/// <para>There are several factors with modifiers from which to select that identify a defined horizontal factor graph. The graphs are used to identify the horizontal factor used in calculating the total cost for moving into a neighboring cell.</para>
		/// <para>In the descriptions below, horizontal factor (HF) defines the horizontal difficulty encountered when moving from one cell to the next, and horizontal relative moving angle (HRMA) identifies the angle between the horizontal direction from a cell and the moving direction.</para>
		/// <para>The Horizontal factor options are as follows:</para>
		/// <para>Binary—If the HRMA is less than the cut angle, the HF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Forward—Only forward movement is allowed. The HRMA must be greater than or equal to 0 and less than 90 degrees (0 &lt;= HRMA &lt; 90). If the HRMA is greater than 0 and less than 45 degrees, the HF for the cell is set to the value associated with the zero factor. If the HRMA is greater than or equal to 45 degrees, the side value modifier value is used. The HF for any HRMA equal to or greater than 90 degrees is set to infinity.</para>
		/// <para>Linear—The HF is a linear function of the HRMA.</para>
		/// <para>Inverse Linear—The HF is an inverse linear function of the HRMA.</para>
		/// <para>Modifiers to the horizontal factors are as follows:</para>
		/// <para>Zero factor—The horizontal factor to be used when the HRMA is zero. This factor positions the y-intercept for any of the horizontal factor functions.</para>
		/// <para>Cut angle—The HRMA angle beyond which the HF will be set to infinity.</para>
		/// <para>Slope—The slope of the straight line used with the Linear and Inverse Linear horizontal factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// <para>Side value—The HF when the HRMA is greater than or equal to 45 degrees and less than 90 degrees when the Forward horizontal factor keyword is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAHorizontalFactor()]
		[Category("Costs relative to horizontal movement (optional)")]
		public object Horizontalfactor { get; set; } = "BINARY 1 45";

		/// <summary>
		/// <para>Out back direction raster name</para>
		/// <para>The output back direction raster name.</para>
		/// <para>The back direction raster contains calculated directions in degrees. The direction identifies the next cell along the optimal path back to the least accumulative cost source while avoiding barriers.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees. The value 0 is reserved for the source cells. Due east (right) is 90 degrees, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// <para>The output raster is of type float.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputbackdirectionrastername { get; set; }

		/// <summary>
		/// <para>Out source direction raster name</para>
		/// <para>The output source direction raster name.</para>
		/// <para>The source direction raster identifies the direction of the least accumulated cost source cell as an azimuth in degrees.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees. The value 0 is reserved for the source cells. Due east (right) is 90 degrees, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// <para>The output raster is of type float.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Additional output rasters (optional)")]
		public object Outputsourcedirectionrastername { get; set; }

		/// <summary>
		/// <para>Out source location raster name</para>
		/// <para>The source location raster is a multiband output. The first band contains a row index, and the second band contains a column index. These indexes identify the location of the source cell that is the least accumulated cost distance away.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Additional output rasters (optional)")]
		public object Outputsourcelocationrastername { get; set; }

		/// <summary>
		/// <para>Initial accumulation</para>
		/// <para>The initial accumulative cost to begin the cost calculation.</para>
		/// <para>Allows for the specification of the fixed cost associated with a source. Instead of starting at a cost of zero, the cost algorithm will begin with the value set by Initial accumulation.</para>
		/// <para>The values must be zero or greater. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Characteristics of the sources (optional)")]
		public object Sourceinitialaccumulation { get; set; }

		/// <summary>
		/// <para>Maximum accumulation</para>
		/// <para>The maximum accumulation for the traveler for a source.</para>
		/// <para>The cost calculations continue for each source until the specified accumulation is reached.</para>
		/// <para>The values must be greater than zero. The default accumulation is to the edge of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Characteristics of the sources (optional)")]
		public object Sourcemaximumaccumulation { get; set; }

		/// <summary>
		/// <para>Multiplier to apply to costs</para>
		/// <para>The multiplier to apply to the cost values.</para>
		/// <para>This allows for control of the mode of travel or the magnitude at a source. The greater the multiplier, the greater the cost to move through each cell.</para>
		/// <para>The values must be greater than zero. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Characteristics of the sources (optional)")]
		public object Sourcecostmultiplier { get; set; }

		/// <summary>
		/// <para>Travel direction</para>
		/// <para>Specifies the direction of the traveler when applying horizontal and vertical factors.</para>
		/// <para>Travel from source—The horizontal factor and vertical factor will be applied beginning at the input source and travel out to the nonsource cells. This is the default.</para>
		/// <para>Travel to source—The horizontal factor and vertical factor will be applied beginning at each nonsource cell and travel back to the input source.</para>
		/// <para>If you select the String option, you can choose between from and to options, which will be applied to all sources.</para>
		/// <para>If you select the Field option, you can select the field from the source data that determines the direction to use for each source. The field must contain the text string FROM_SOURCE or TO_SOURCE.</para>
		/// <para><see cref="SourcedirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Characteristics of the sources (optional)")]
		public object Sourcedirection { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies whether to calculate the distance using a planar (flat earth) or a geodesic (ellipsoid) method.</para>
		/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
		/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
		/// <para><see cref="DistancemethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Distancemethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Output distance accumulation raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputdistanceaccumulationraster { get; set; }

		/// <summary>
		/// <para>Output back direction raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputbackdirectionraster { get; set; }

		/// <summary>
		/// <para>Output source direction raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputsourcedirectionraster { get; set; }

		/// <summary>
		/// <para>Output source location raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputsourcelocationraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DistanceAccumulation SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel direction</para>
		/// </summary>
		public enum SourcedirectionEnum 
		{
			/// <summary>
			/// <para>Travel to source—The horizontal factor and vertical factor will be applied beginning at each nonsource cell and travel back to the input source.</para>
			/// </summary>
			[GPValue("TO_SOURCE")]
			[Description("Travel to source")]
			Travel_to_source,

			/// <summary>
			/// <para>Travel from source—The horizontal factor and vertical factor will be applied beginning at the input source and travel out to the nonsource cells. This is the default.</para>
			/// </summary>
			[GPValue("FROM_SOURCE")]
			[Description("Travel from source")]
			Travel_from_source,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistancemethodEnum 
		{
			/// <summary>
			/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
