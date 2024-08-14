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
	/// <para>Calculate Travel Cost</para>
	/// <para>Calculates the least accumulative cost distance from or to the least-cost source, while accounting for surface distance along with horizontal and vertical cost factors.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation))]
	public class CalculateTravelCost : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsourcerasterorfeatures">
		/// <para>Input Source Raster or Features</para>
		/// <para>The layer that defines the sources to calculate the distance to. The layer can be raster or feature.</para>
		/// </param>
		/// <param name="Outputdistancename">
		/// <para>Output Distance Name</para>
		/// <para>The name of the output distance raster service.</para>
		/// <para>The cost distance image service identifies, for each cell, the least accumulative cost distance over a cost surface to the identified source locations.</para>
		/// </param>
		public CalculateTravelCost(object Inputsourcerasterorfeatures, object Outputdistancename)
		{
			this.Inputsourcerasterorfeatures = Inputsourcerasterorfeatures;
			this.Outputdistancename = Outputdistancename;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Travel Cost</para>
		/// </summary>
		public override string DisplayName => "Calculate Travel Cost";

		/// <summary>
		/// <para>Tool Name : CalculateTravelCost</para>
		/// </summary>
		public override string ToolName => "CalculateTravelCost";

		/// <summary>
		/// <para>Tool Excute Name : ra.CalculateTravelCost</para>
		/// </summary>
		public override string ExcuteName => "ra.CalculateTravelCost";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputsourcerasterorfeatures, Outputdistancename, Inputcostraster, Inputsurfaceraster, Maximumdistance, Inputhorizontalraster, Horizontalfactor, Inputverticalraster, Verticalfactor, Sourcecostmultiplier, Sourcestartcost, Sourceresistancerate, Sourcecapacity, Sourcetraveldirection, Outputbacklinkname, Outputallocationname, Allocationfield, Outputdistanceraster, Outputbacklinkraster, Outputallocationraster };

		/// <summary>
		/// <para>Input Source Raster or Features</para>
		/// <para>The layer that defines the sources to calculate the distance to. The layer can be raster or feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsourcerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Distance Name</para>
		/// <para>The name of the output distance raster service.</para>
		/// <para>The cost distance image service identifies, for each cell, the least accumulative cost distance over a cost surface to the identified source locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputdistancename { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>A raster defining the elevation values at each cell location. The values are used to calculate the actual surface distance covered when passing between cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>Defines the threshold that the accumulative cost values cannot exceed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Maximumdistance { get; set; }

		/// <summary>
		/// <para>Input Horizontal Raster</para>
		/// <para>A raster defining the horizontal direction at each cell.</para>
		/// <para>The values on the raster must be integers ranging from 0 to 360, with 0 degrees being north, or toward the top of the screen, and increasing clockwise. Flat areas should be given a value of -1.</para>
		/// <para>The values at each location will be used in conjunction with the Horizontal Factor to determine the horizontal cost incurred when moving from a cell to its neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputhorizontalraster { get; set; }

		/// <summary>
		/// <para>Horizontal Factor</para>
		/// <para>The Horizontal Factor defines the relationship between the horizontal cost factor and the horizontal relative moving angle.</para>
		/// <para>There are several factors with modifiers from which to select that identify a defined horizontal factor graph. The graphs are used to identify the horizontal factor used in calculating the total cost of moving into a neighboring cell.</para>
		/// <para>In the explanations below, two acronyms are used: HF stands for horizontal factor, which defines the horizontal difficulty encountered when moving from one cell to the next; and HRMA stands for horizontal relative moving angle, which identifies the angle between the horizontal direction from a cell and the moving direction.</para>
		/// <para>There are several types of horizontal factor available:</para>
		/// <para>Binary—Indicates that if the HRMA is less than the cut angle, the HF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Forward—Establishes that only forward movement is allowed. The HRMA must be greater or equal to 0 and less than 90 degrees (0 &lt;= HRMA &lt; 90). If the HRMA is greater than 0 and less than 45 degrees, the HF for the cell is set to the value associated with the zero factor. If the HRMA is greater than or equal to 45 degrees, the side value modifier value is used. The HF for any HRMA equal to or greater than 90 degrees is set to infinity.</para>
		/// <para>Linear—Specifies that the HF is a linear function of the HRMA.</para>
		/// <para>Inverse Linear—Specifies that the HF is an inverse linear function of the HRMA.</para>
		/// <para>The default is Binary.</para>
		/// <para>Characteristics for the horizontal keywords:</para>
		/// <para>Zero factor—Establishes the horizontal factor to be used when the HRMA is zero. This factor positions the y-intercept for any of the horizontal factor functions.</para>
		/// <para>Cut angle—Defines the HRMA angle beyond which the HF will be set to infinity.</para>
		/// <para>Slope—Establishes the slope of the straight line used with the Linear and Inverse Linear horizontal factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// <para>Side value—Establishes the HF when the HRMA is greater than or equal to 45 degrees and less than 90 degrees when the Forward horizontal factor keyword is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAHorizontalFactor()]
		public object Horizontalfactor { get; set; } = "BINARY 1 45";

		/// <summary>
		/// <para>Input Vertical Raster</para>
		/// <para>A raster defining the vertical (z) value for each cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputverticalraster { get; set; }

		/// <summary>
		/// <para>Vertical Factor</para>
		/// <para>The Vertical Factor defines the relationship between the vertical cost factor and the vertical relative moving angle (VRMA).</para>
		/// <para>There are several factors with modifiers from which to select that identify a defined vertical factor graph. The graphs are used to identify the vertical factor used in calculating the total cost for moving into a neighboring cell.</para>
		/// <para>In the explanations below, two acronyms are used: VF stands for vertical factor, which defines the vertical difficulty encountered in moving from one cell to the next; and VRMA stands for vertical relative moving angle, which identifies the slope angle between the FROM or processing cell and the TO cell.</para>
		/// <para>There are several types of vertical factor available:</para>
		/// <para>Binary—Specifies that if the VRMA is greater than the low-cut angle and less than the high-cut angle, the VF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Linear—Indicates that the VF is a linear function of the VRMA.</para>
		/// <para>Symmetric Linear—Specifies that the VF is a linear function of the VRMA in either the negative or positive side of the VRMA, respectively, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Inverse Linear—Indicates that the VF is an inverse linear function of the VRMA.</para>
		/// <para>Symmetric Inverse Linear—Specifies that the VF is an inverse linear function of the VRMA in either the negative or positive side of the VRMA, respectively, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Cos—Identifies the VF as the cosine-based function of the VRMA.</para>
		/// <para>Sec—Identifies the VF as the secant-based function of the VRMA.</para>
		/// <para>Cos-Sec—Specifies that the VF is the cosine-based function of the VRMA when the VRMA is negative and the secant-based function of the VRMA when the VRMA is nonnegative.</para>
		/// <para>Sec-Cos—Specifies that the VF is the secant-based function of the VRMA when the VRMA is negative and the cosine-based function of the VRMA when the VRMA is nonnegative.</para>
		/// <para>The default is Binary.</para>
		/// <para>Characteristics for the vertical keywords:</para>
		/// <para>Zero factor—Establishes the vertical factor used when the VRMA is zero. This factor positions the y-intercept of the specified function. By definition, the zero factor is not applicable to any of the trigonometric vertical functions (COS, SEC, COS-SEC, or SEC-COS). The y-intercept is defined by these functions.</para>
		/// <para>Low Cut angle—Defines the VRMA angle below which the VF will be set to infinity.</para>
		/// <para>High Cut angle—Defines the VRMA angle above which the VF will be set to infinity.</para>
		/// <para>Slope—Establishes the slope of the straight line used with the Linear and Inverse Linear vertical-factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAVerticalFactor()]
		public object Verticalfactor { get; set; } = "BINARY 1 -30 30";

		/// <summary>
		/// <para>Cost Multiplier</para>
		/// <para>Multiplier to apply to the cost values.</para>
		/// <para>Allows for control of the mode of travel or the magnitude at a source. The greater the multiplier, the greater the cost to move through each cell.</para>
		/// <para>The values must be greater than zero. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourcecostmultiplier { get; set; }

		/// <summary>
		/// <para>Start Cost</para>
		/// <para>The starting cost from which to begin the cost calculations.</para>
		/// <para>Allows for the specification of the fixed cost associated with a source. Instead of starting at a cost of zero, the cost algorithm will begin with the value set by Start Cost.</para>
		/// <para>The values must be zero or greater. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourcestartcost { get; set; }

		/// <summary>
		/// <para>Resistance Rate</para>
		/// <para>This parameter simulates the increase in the effort to overcome costs as the accumulative cost increases. It is used to model fatigue of the traveler. The growing accumulative cost to reach a cell is multiplied by the resistance rate and added to the cost to move into the subsequent cell.</para>
		/// <para>It is a modified version of a compound interest rate formula that is used to calculate the apparent cost of moving through a cell. As the value of the resistance rate increases, it increases the cost of the cells that are visited later. The greater the resistance rate, the more additional cost is added to reach the next cell, which is compounded for each subsequent movement. Since the resistance rate is similar to a compound rate and generally the accumulative cost values are very large, small resistance rates are suggested, such as 0.02, 0.005, or even smaller, depending on the accumulative cost values.</para>
		/// <para>The values must be zero or greater. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourceresistancerate { get; set; }

		/// <summary>
		/// <para>Capacity</para>
		/// <para>Defines the cost capacity for the traveler for a source.</para>
		/// <para>The cost calculations continue for each source until the specified capacity is reached.</para>
		/// <para>The values must be greater than zero. The default capacity is to the edge of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourcecapacity { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Defines the direction of the traveler when applying horizontal and vertical factors, the source resistance rate, and the source starting cost.</para>
		/// <para>From source—The horizontal factor, vertical factor, source resistance rate, and source starting cost will be applied beginning at the input source, and moving out to the non-source cells. This is the default.</para>
		/// <para>To source—The horizontal factor, vertical factor, source resistance rate, and source starting cost will be applied beginning at each non-source cell and moving back to the input source.</para>
		/// <para>Either specify the From source or To source keyword, which will be applied to all sources, or specify a field in the source data that contains the keywords to identify the direction of travel for each source. That field must contain the strings FROM_SOURCE or TO_SOURCE.</para>
		/// <para><see cref="SourcetraveldirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Source Characteristics")]
		public object Sourcetraveldirection { get; set; }

		/// <summary>
		/// <para>Output Backlink Name</para>
		/// <para>The name of the output backlink raster service.</para>
		/// <para>The backlink raster contains values of 0 through 360, which define the direction along the least accumulative cost path from a cell to reach its least-cost source, while accounting for surface distance as well as horizontal and vertical surface factors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputbacklinkname { get; set; }

		/// <summary>
		/// <para>Output Allocation Name</para>
		/// <para>The name of the output allocation raster service.</para>
		/// <para>This raster identifies the zone of each source location (cell or feature) that could be reached with the least accumulative cost.</para>
		/// <para>The output raster is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputallocationname { get; set; }

		/// <summary>
		/// <para>Allocation Field</para>
		/// <para>A field on the source input that holds the values that define each source.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Allocationfield { get; set; }

		/// <summary>
		/// <para>Output Distance Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputdistanceraster { get; set; }

		/// <summary>
		/// <para>Output Backlink Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputbacklinkraster { get; set; }

		/// <summary>
		/// <para>Output Allocation Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputallocationraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateTravelCost SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum SourcetraveldirectionEnum 
		{
			/// <summary>
			/// <para>From source—The horizontal factor, vertical factor, source resistance rate, and source starting cost will be applied beginning at the input source, and moving out to the non-source cells. This is the default.</para>
			/// </summary>
			[GPValue("FROM_SOURCE")]
			[Description("From source")]
			From_source,

			/// <summary>
			/// <para>To source—The horizontal factor, vertical factor, source resistance rate, and source starting cost will be applied beginning at each non-source cell and moving back to the input source.</para>
			/// </summary>
			[GPValue("TO_SOURCE")]
			[Description("To source")]
			To_source,

		}

#endregion
	}
}
