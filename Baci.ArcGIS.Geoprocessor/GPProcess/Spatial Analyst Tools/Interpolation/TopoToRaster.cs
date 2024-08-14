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
	/// <para>Topo to Raster</para>
	/// <para>Interpolates a hydrologically correct raster surface from point, line, and polygon data.</para>
	/// </summary>
	public class TopoToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopoFeatures">
		/// <para>Input feature data</para>
		/// <para>The input features containing the z-values to be interpolated into a surface raster.</para>
		/// <para>Each feature input can have a field specified that contains the z-values and one of six types specified.</para>
		/// <para>Feature layer—The input feature dataset.</para>
		/// <para>Field—The name of the field that stores the attributes, where appropriate.</para>
		/// <para>Type—The type of input feature dataset.</para>
		/// <para>There are nine types of accepted inputs:</para>
		/// <para>Point elevation—A point feature class representing surface elevations. The Field stores the elevations of the points.</para>
		/// <para>Contour—A line feature class that represents elevation contours. The Field stores the elevations of the contour lines.</para>
		/// <para>Stream—A line feature class of stream locations. All arcs must be oriented to point downstream. The feature class should only contain single arc streams. There is no Field option for this input type.</para>
		/// <para>Sink—A point feature class that represents known topographic depressions. The tool will not attempt to remove from the analysis any points explicitly identified as sinks. The Field used should be one that stores the elevation of the legitimate sink. If NONE is selected, only the location of the sink is used.</para>
		/// <para>Boundary—A feature class containing a single polygon that represents the outer boundary of the output raster. Cells in the output raster outside this boundary will be NoData. This option can be used for clipping out water areas along coastlines before making the final output raster. There is no Field option for this input type.</para>
		/// <para>Lake—A polygon feature class that specifies the location of lakes. All output raster cells within a lake will be assigned to the minimum elevation value of all cells along the shoreline. There is no Field option for this input type.</para>
		/// <para>Cliff—A line feature class of the cliffs. The cliff line features must be oriented so that the left-hand side of the line is on the low side of the cliff and the right-hand side is the high side of the cliff. There is no Field option for this input type.</para>
		/// <para>Exclusion—A polygon feature class of the areas in which the input data should be ignored. These polygons permit removal of elevation data from the interpolation process. This is typically used to remove elevation data associated with dam walls and bridges. This enables interpolation of the underlying valley with connected drainage structure. There is no Field option for this input type.</para>
		/// <para>Coast—A polygon feature class containing the outline of a coastal area. Cells in the final output raster that lie outside these polygons are set to a value that is less than the user-specified minimum height limit. There is no Field option for this input type.</para>
		/// </param>
		/// <param name="OutSurfaceRaster">
		/// <para>Output surface raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
		/// </param>
		public TopoToRaster(object InTopoFeatures, object OutSurfaceRaster)
		{
			this.InTopoFeatures = InTopoFeatures;
			this.OutSurfaceRaster = OutSurfaceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Topo to Raster</para>
		/// </summary>
		public override string DisplayName => "Topo to Raster";

		/// <summary>
		/// <para>Tool Name : TopoToRaster</para>
		/// </summary>
		public override string ToolName => "TopoToRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.TopoToRaster</para>
		/// </summary>
		public override string ExcuteName => "sa.TopoToRaster";

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
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "tileSize", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTopoFeatures, OutSurfaceRaster, CellSize, Extent, Margin, MinimumZValue, MaximumZValue, Enforce, DataType, MaximumIterations, RoughnessPenalty, DiscreteErrorFactor, VerticalStandardError, Tolerance1, Tolerance2, OutStreamFeatures, OutSinkFeatures, OutDiagnosticFile, OutParameterFile, ProfilePenalty, OutResidualFeature, OutStreamCliffErrorFeature, OutContourErrorFeature };

		/// <summary>
		/// <para>Input feature data</para>
		/// <para>The input features containing the z-values to be interpolated into a surface raster.</para>
		/// <para>Each feature input can have a field specified that contains the z-values and one of six types specified.</para>
		/// <para>Feature layer—The input feature dataset.</para>
		/// <para>Field—The name of the field that stores the attributes, where appropriate.</para>
		/// <para>Type—The type of input feature dataset.</para>
		/// <para>There are nine types of accepted inputs:</para>
		/// <para>Point elevation—A point feature class representing surface elevations. The Field stores the elevations of the points.</para>
		/// <para>Contour—A line feature class that represents elevation contours. The Field stores the elevations of the contour lines.</para>
		/// <para>Stream—A line feature class of stream locations. All arcs must be oriented to point downstream. The feature class should only contain single arc streams. There is no Field option for this input type.</para>
		/// <para>Sink—A point feature class that represents known topographic depressions. The tool will not attempt to remove from the analysis any points explicitly identified as sinks. The Field used should be one that stores the elevation of the legitimate sink. If NONE is selected, only the location of the sink is used.</para>
		/// <para>Boundary—A feature class containing a single polygon that represents the outer boundary of the output raster. Cells in the output raster outside this boundary will be NoData. This option can be used for clipping out water areas along coastlines before making the final output raster. There is no Field option for this input type.</para>
		/// <para>Lake—A polygon feature class that specifies the location of lakes. All output raster cells within a lake will be assigned to the minimum elevation value of all cells along the shoreline. There is no Field option for this input type.</para>
		/// <para>Cliff—A line feature class of the cliffs. The cliff line features must be oriented so that the left-hand side of the line is on the low side of the cliff and the right-hand side is the high side of the cliff. There is no Field option for this input type.</para>
		/// <para>Exclusion—A polygon feature class of the areas in which the input data should be ignored. These polygons permit removal of elevation data from the interpolation process. This is typically used to remove elevation data associated with dam walls and bridges. This enables interpolation of the underlying valley with connected drainage structure. There is no Field option for this input type.</para>
		/// <para>Coast—A polygon feature class containing the outline of a coastal area. Cells in the final output raster that lie outside these polygons are set to a value that is less than the user-specified minimum height limit. There is no Field option for this input type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSATopoFeatures()]
		[GPCompositeDomain()]
		public object InTopoFeatures { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Output extent</para>
		/// <para>Extent for the output raster dataset.</para>
		/// <para>Interpolation will occur out to the x and y limits, and cells outside that extent will be NoData. For best interpolation results along the edges of the output raster, the x and y limits should be smaller than the extent of the input data by at least 10 cells on each side.</para>
		/// <para>Left—The default is the smallest x coordinate of all inputs.</para>
		/// <para>Bottom—The default is the smallest y coordinate of all inputs.</para>
		/// <para>Right—The default is the largest x coordinate of all inputs.</para>
		/// <para>Top—The default is the largest y coordinate of all inputs.</para>
		/// <para>The default extent is the largest of all extents of the input feature data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Margin in cells</para>
		/// <para>Distance in cells to interpolate beyond the specified output extent and boundary.</para>
		/// <para>The value must be greater than or equal to 0 (zero). The default value is 20.</para>
		/// <para>If the Output extent and Boundary feature datasets are the same as the limit of the input data (the default), values interpolated along the edge of the DEM will not match well with adjacent DEM data. This is because they have been interpolated using one-half as much data as the points inside the raster, which are surrounded on all sides by input data. The Margin In Cells option allows input data beyond these limits to be used in the interpolation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object Margin { get; set; } = "20";

		/// <summary>
		/// <para>Smallest z value to be used in interpolation</para>
		/// <para>The minimum z-value to be used in the interpolation.</para>
		/// <para>The default is 20 percent below the smallest of all the input values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinimumZValue { get; set; }

		/// <summary>
		/// <para>Largest z value to be used in interpolation</para>
		/// <para>The maximum z-value to be used in the interpolation.</para>
		/// <para>The default is 20 percent above the largest of all input values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumZValue { get; set; }

		/// <summary>
		/// <para>Drainage enforcement</para>
		/// <para>The type of drainage enforcement to apply.</para>
		/// <para>The drainage enforcement option can be set to attempt to remove all sinks or depressions so a hydrologically correct DEM can be created. If sink points have been explicitly identified in the input feature data, these depressions will not be filled.</para>
		/// <para>Enforce—The algorithm will attempt to remove all sinks it encounters, whether they are real or spurious. This is the default.</para>
		/// <para>Do not enforce—No sinks will be filled.</para>
		/// <para>Enforce with sink—Points identified as sinks in Input feature data represent known topographic depressions and will not be altered. Any sink not identified in input feature data is considered spurious, and the algorithm will attempt to fill it.Having more than 8,000 spurious sinks causes the tool to fail.</para>
		/// <para><see cref="EnforceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Enforce { get; set; } = "ENFORCE";

		/// <summary>
		/// <para>Primary type of input data</para>
		/// <para>The dominant elevation data type of the input feature data.</para>
		/// <para>Contour—The dominant type of input data will be elevation contours. This is the default.</para>
		/// <para>Spot—The dominant type of input will be point.</para>
		/// <para>Specifying the relevant selection optimizes the search method used during the generation of streams and ridges.</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "CONTOUR";

		/// <summary>
		/// <para>Maximum number of iterations</para>
		/// <para>The maximum number of interpolation iterations.</para>
		/// <para>The number of iterations must be greater than zero. A default of 20 is normally adequate for both contour and line data.</para>
		/// <para>A value of 30 will clear fewer sinks. Rarely, higher values (45–50) may be useful to clear more sinks or to set more ridges and streams. Iteration ceases for each grid resolution when the maximum number of iterations has been reached.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object MaximumIterations { get; set; } = "20";

		/// <summary>
		/// <para>Roughness penalty</para>
		/// <para>The integrated squared second derivative as a measure of roughness.</para>
		/// <para>The roughness penalty must be zero or greater. If the primary input data type is Contour, the default is zero. If the primary data type is Spot, the default is 0.5. Larger values are not normally recommended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object RoughnessPenalty { get; set; }

		/// <summary>
		/// <para>Discretisation error factor</para>
		/// <para>The discrete error factor is used to adjust the amount of smoothing when converting the input data to a raster.</para>
		/// <para>The value must be greater than zero. The normal range of adjustment is 0.25 to 4, and the default is 1. A smaller value results in less data smoothing; a larger value causes greater smoothing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object DiscreteErrorFactor { get; set; } = "1";

		/// <summary>
		/// <para>Vertical standard error</para>
		/// <para>The amount of random error in the z-values of the input data.</para>
		/// <para>The value must be zero or greater. The default is zero.</para>
		/// <para>The vertical standard error may be set to a small positive value if the data has significant random (non-systematic) vertical errors with uniform variance. In this case, set the vertical standard error to the standard deviation of these errors. For most elevation datasets, the vertical error should be set to zero, but it may be set to a small positive value to stabilize convergence when rasterizing point data with stream line data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object VerticalStandardError { get; set; } = "0";

		/// <summary>
		/// <para>Tolerance 1</para>
		/// <para>This tolerance reflects the accuracy and density of the elevation points in relation to surface drainage.</para>
		/// <para>For point datasets, set the tolerance to the standard error of the data heights. For contour datasets, use one-half the average contour interval.</para>
		/// <para>The value must be zero or greater. The default is 2.5 if the data type is Contour and zero if the data type is Spot.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Tolerance1 { get; set; }

		/// <summary>
		/// <para>Tolerance 2</para>
		/// <para>This tolerance prevents drainage clearance through unrealistically high barriers.</para>
		/// <para>The value must be greater than zero. The default is 100 if the data type is Contour and 200 if the data type is Spot.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Tolerance2 { get; set; }

		/// <summary>
		/// <para>Output stream polyline features</para>
		/// <para>The output line feature class of stream polyline features and ridge line features.</para>
		/// <para>The line features are created at the beginning of the interpolation process. It provides the general morphology of the surface for interpolation. It can be used to verify correct drainage and morphology by comparing known stream and ridge data.</para>
		/// <para>The polyline features are coded as follows:</para>
		/// <para>1. Input stream line not over cliff.</para>
		/// <para>2. Input stream line over cliff (waterfall).</para>
		/// <para>3. Drainage enforcement clearing a spurious sink.</para>
		/// <para>4. Stream line determined from contour corner.</para>
		/// <para>5. Ridge line determined from contour corner.</para>
		/// <para>6. Code not used.</para>
		/// <para>7. Data stream line side conditions.</para>
		/// <para>8. Code not used.</para>
		/// <para>9. Line indicating large elevation data clearance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutStreamFeatures { get; set; }

		/// <summary>
		/// <para>Output remaining sink point features</para>
		/// <para>The output point feature class of the remaining sink point features.</para>
		/// <para>These are the sinks that were not specified in the sink input feature data and were not cleared during drainage enforcement. Adjusting the values of the tolerances, Tolerance 1 and Tolerance 2, can reduce the number of remaining sinks. Remaining sinks often indicate errors in the input data that the drainage enforcement algorithm could not resolve. This can be an efficient way of detecting subtle elevation errors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutSinkFeatures { get; set; }

		/// <summary>
		/// <para>Output diagnostic file</para>
		/// <para>The output diagnostic file listing all inputs and parameters used and the number of sinks cleared at each resolution and iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[Category("Optional outputs")]
		public object OutDiagnosticFile { get; set; }

		/// <summary>
		/// <para>Output parameter file</para>
		/// <para>The output parameter file listing all inputs and parameters used, which can be used with Topo to Raster by File to run the interpolation again.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[Category("Optional outputs")]
		public object OutParameterFile { get; set; }

		/// <summary>
		/// <para>Profile curvature roughness penalty</para>
		/// <para>The profile curvature roughness penalty is a locally adaptive penalty that can be used to partly replace total curvature.</para>
		/// <para>It can yield good results with high-quality contour data but can lead to instability in convergence with poor data. Set to 0.0 for no profile curvature (the default), set to 0.5 for moderate profile curvature, and set to 0.8 for maximum profile curvature. Values larger than 0.8 are not recommended and should not be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ProfilePenalty { get; set; }

		/// <summary>
		/// <para>Output residual point features</para>
		/// <para>The output point feature class of all the large elevation residuals as scaled by the local discretisation error.</para>
		/// <para>All the scaled residuals larger than 10 should be inspected for possible errors in input elevation and stream data. Large-scaled residuals indicate conflicts between input elevation data and streamline data. These may also be associated with poor automatic drainage enforcements. These conflicts can be remedied by providing additional streamline and/or point elevation data after first checking and correcting errors in existing input data. Large unscaled residuals usually indicate input elevation errors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutResidualFeature { get; set; }

		/// <summary>
		/// <para>Output stream and cliff error point features</para>
		/// <para>The output point feature class of locations where possible stream and cliff errors occur.</para>
		/// <para>The locations where the streams have closed loops, distributaries, and streams over cliffs can be identified from the point feature class. Cliffs with neighboring cells that are inconsistent with the high and low sides of the cliff are also indicated. This can be a good indicator of cliffs with incorrect direction.</para>
		/// <para>Points are coded as follows:</para>
		/// <para>1. True circuit in data streamline network.</para>
		/// <para>2. Circuit in stream network as encoded on the out raster.</para>
		/// <para>3. Circuit in stream network via connecting lakes.</para>
		/// <para>4. Distributaries point.</para>
		/// <para>5. Stream over a cliff (waterfall).</para>
		/// <para>6. Points indicating multiple stream outflows from lakes.</para>
		/// <para>7. Code not used.</para>
		/// <para>8. Points beside cliffs with heights inconsistent with cliff direction.</para>
		/// <para>9. Code not used.</para>
		/// <para>10. Circular distributary removed.</para>
		/// <para>11. Distributary with no inflowing stream.</para>
		/// <para>12. Rasterized distributary in output cell different to where the data stream line distributary occurs.</para>
		/// <para>13. Error processing side conditions—an indicator of very complex streamline data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutStreamCliffErrorFeature { get; set; }

		/// <summary>
		/// <para>Output contour error point features</para>
		/// <para>The output point feature class of possible errors pertaining to the input contour data.</para>
		/// <para>Contours with bias in height exceeding five times the standard deviation of the contour values as represented on the output raster are reported to this feature class. Contours that join other contours with a different elevation are flagged in this feature class by the code 1; this is a sure sign of a contour label error.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Optional outputs")]
		public object OutContourErrorFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TopoToRaster SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , bool? maintainSpatialIndex = null , object mask = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , bool? transferDomains = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Drainage enforcement</para>
		/// </summary>
		public enum EnforceEnum 
		{
			/// <summary>
			/// <para>Enforce—The algorithm will attempt to remove all sinks it encounters, whether they are real or spurious. This is the default.</para>
			/// </summary>
			[GPValue("ENFORCE")]
			[Description("Enforce")]
			Enforce,

			/// <summary>
			/// <para>Do not enforce—No sinks will be filled.</para>
			/// </summary>
			[GPValue("NO_ENFORCE")]
			[Description("Do not enforce")]
			Do_not_enforce,

			/// <summary>
			/// <para>Enforce with sink—Points identified as sinks in Input feature data represent known topographic depressions and will not be altered. Any sink not identified in input feature data is considered spurious, and the algorithm will attempt to fill it.Having more than 8,000 spurious sinks causes the tool to fail.</para>
			/// </summary>
			[GPValue("ENFORCE_WITH_SINK")]
			[Description("Enforce with sink")]
			Enforce_with_sink,

		}

		/// <summary>
		/// <para>Primary type of input data</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Contour—The dominant type of input data will be elevation contours. This is the default.</para>
			/// </summary>
			[GPValue("CONTOUR")]
			[Description("Contour")]
			Contour,

			/// <summary>
			/// <para>Spot—The dominant type of input will be point.</para>
			/// </summary>
			[GPValue("SPOT")]
			[Description("Spot")]
			Spot,

		}

#endregion
	}
}
