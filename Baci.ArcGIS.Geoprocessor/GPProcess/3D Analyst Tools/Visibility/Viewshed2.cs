using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Geodesic Viewshed</para>
	/// <para>Geodesic Viewshed</para>
	/// <para>Determines the raster surface locations visible to a set of observer features using geodesic methods.</para>
	/// </summary>
	public class Viewshed2 : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input surface raster. It can be an integer or a floating-point raster.</para>
		/// <para>The input raster is transformed into a 3D geocentric coordinate system during the visibility calculation. NoData cells on the input raster do not block the visibility determination.</para>
		/// </param>
		/// <param name="InObserverFeatures">
		/// <para>Input point or polyline observer features</para>
		/// <para>The input feature class that identifies the observer locations. It can be point, multipoint, or polyline features.</para>
		/// <para>The input feature class is transformed into a 3D geocentric coordinate system during the visibility calculation. Observers outside of the extent of the surface raster or located on NoData cells will be ignored in the calculation.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For the Frequency analysis type, when the vertical error parameter is 0 or not specified, the output raster records the number of times that each cell location in the input surface raster can be seen by the input observation points. When the vertical error parameter is greater than 0, each cell on the output raster records the sum of probabilities that the cell is visible to any of the observers. For the Observers analysis type, the output raster records the unique region IDs for the visible areas, which can be related back to the observer features through the output observer-region relationship table.</para>
		/// </param>
		public Viewshed2(object InRaster, object InObserverFeatures, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InObserverFeatures = InObserverFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Geodesic Viewshed</para>
		/// </summary>
		public override string DisplayName() => "Geodesic Viewshed";

		/// <summary>
		/// <para>Tool Name : Viewshed2</para>
		/// </summary>
		public override string ToolName() => "Viewshed2";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Viewshed2</para>
		/// </summary>
		public override string ExcuteName() => "3d.Viewshed2";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InObserverFeatures, OutRaster, OutAglRaster!, AnalysisType!, VerticalError!, OutObserverRegionRelationshipTable!, RefractivityCoefficient!, SurfaceOffset!, ObserverElevation!, ObserverOffset!, InnerRadius!, InnerRadiusIs3D!, OuterRadius!, OuterRadiusIs3D!, HorizontalStartAngle!, HorizontalEndAngle!, VerticalUpperAngle!, VerticalLowerAngle!, AnalysisMethod! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input surface raster. It can be an integer or a floating-point raster.</para>
		/// <para>The input raster is transformed into a 3D geocentric coordinate system during the visibility calculation. NoData cells on the input raster do not block the visibility determination.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input point or polyline observer features</para>
		/// <para>The input feature class that identifies the observer locations. It can be point, multipoint, or polyline features.</para>
		/// <para>The input feature class is transformed into a 3D geocentric coordinate system during the visibility calculation. Observers outside of the extent of the surface raster or located on NoData cells will be ignored in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Multipoint", "Polyline")]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For the Frequency analysis type, when the vertical error parameter is 0 or not specified, the output raster records the number of times that each cell location in the input surface raster can be seen by the input observation points. When the vertical error parameter is greater than 0, each cell on the output raster records the sum of probabilities that the cell is visible to any of the observers. For the Observers analysis type, the output raster records the unique region IDs for the visible areas, which can be related back to the observer features through the output observer-region relationship table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output above ground level raster</para>
		/// <para>The output above ground level (AGL) raster.</para>
		/// <para>The AGL result is a raster where each cell value is the minimum height that must be added to an otherwise nonvisible cell to make it visible by at least one observer. Cells that were already visible will be assigned 0 in this output raster.</para>
		/// <para>When the vertical error parameter is 0, the output AGL raster is a one-band raster. When vertical error is greater than 0, to account for the random effects from the input raster, the output AGL raster is created as a three-band raster. The first band represents the mean AGL values, the second band represents the minimum AGL values, and the third band represents the maximum AGL values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Viewshed parameters")]
		public object? OutAglRaster { get; set; }

		/// <summary>
		/// <para>Analysis type</para>
		/// <para>Specifies the type of visibility analysis you wish to perform, either determining how visible each cell is to the observers, or identifying for each surface location which observers are visible.</para>
		/// <para>Frequency—The output records the number of times that each cell location in the input surface raster can be seen by the input observation locations (as points or as vertices for polyline observer features). This is the default.</para>
		/// <para>Observers—The output identifies exactly which observer points are visible from each raster surface location. The allowed maximum number of input observers is 32 with this analysis type.</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Viewshed parameters")]
		public object? AnalysisType { get; set; } = "FREQUENCY";

		/// <summary>
		/// <para>Vertical error</para>
		/// <para>The amount of uncertainty (the Root Mean Square error, or RMSE) in the surface elevation values. It is a floating-point value representing the expected error of the input elevation values. When this parameter is assigned a value greater than 0, the output visibility raster will be floating point. In this case, each cell value on the output visibility raster represents the sum of probabilities that the cell is visible to any of the observers.</para>
		/// <para>When the analysis type is Observers or the analysis method is Perimeter Sightlines, this parameter is disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Viewshed parameters")]
		public object? VerticalError { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Output observer-region relationship table</para>
		/// <para>The output table for identifying the regions that are visible to each observer. This table can be related to the input observer feature class and the output visibility raster for identifying the regions visible to given observers.</para>
		/// <para>This output is only created when the analysis type is Observers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Viewshed parameters")]
		public object? OutObserverRegionRelationshipTable { get; set; }

		/// <summary>
		/// <para>Refractivity coefficient</para>
		/// <para>The coefficient of the refraction of visible light in air.</para>
		/// <para>The default value is 0.13.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		[Category("Viewshed parameters")]
		public object? RefractivityCoefficient { get; set; } = "0.13";

		/// <summary>
		/// <para>Surface offset</para>
		/// <para>A vertical distance to be added to the z-value of each cell as it is considered for visibility. It must be a positive integer or floating-point value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>For example, if the object to be observed is a vehicle, the height of the vehicle should be specified here.</para>
		/// <para>If this parameter is set to a value, that value will be used by all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// <para>The default value is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? SurfaceOffset { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Observer elevation</para>
		/// <para>The surface elevations of the observer points or vertices.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>If this parameter is not specified, the observer elevation will be obtained from the surface raster using bilinear interpolation. If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? ObserverElevation { get; set; }

		/// <summary>
		/// <para>Observer offset</para>
		/// <para>A vertical distance to be added to the observer elevation. It must be a positive integer or floating-point value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>For example, if an observer is looking from a tower, the height of that tower should be specified here.</para>
		/// <para>If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// <para>The default value is 1 meter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? ObserverOffset { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Inner radius</para>
		/// <para>The start distance from which visibility is determined. Cells closer than this distance are not visible in the output but can still block visibility of the cells between inner radius and outer radius.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// <para>The default value is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? InnerRadius { get; set; }

		/// <summary>
		/// <para>Inner radius is 3D distance</para>
		/// <para>Specifies the type of distance for the inner radius parameter.</para>
		/// <para>Unchecked—The inner radius is to be interpreted as a 2D distance. This is the default.</para>
		/// <para>Checked—The inner radius is to be interpreted as a 3D distance.</para>
		/// <para><see cref="InnerRadiusIs3DEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? InnerRadiusIs3D { get; set; } = "false";

		/// <summary>
		/// <para>Outer radius</para>
		/// <para>The maximum distance from which visibility is determined. Cells beyond this distance are excluded from the analysis.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? OuterRadius { get; set; }

		/// <summary>
		/// <para>Outer radius is 3D distance</para>
		/// <para>Specifies the type of distance for the outer radius parameter.</para>
		/// <para>Unchecked—The outer radius is to be interpreted as a 2D distance. This is the default.</para>
		/// <para>Checked—The outer radius is to be interpreted as a 3D distance.</para>
		/// <para><see cref="OuterRadiusIs3DEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? OuterRadiusIs3D { get; set; } = "false";

		/// <summary>
		/// <para>Horizontal start angle</para>
		/// <para>The start angle of the horizontal scan range. The value should be specified in degrees from 0 to 360, either as integer or floating point, with 0 oriented to north. The default value is 0.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? HorizontalStartAngle { get; set; } = "0";

		/// <summary>
		/// <para>Horizontal end angle</para>
		/// <para>The end angle of the horizontal scan range. The value should be specified in degrees from 0 to 360, either as integer or floating point, with 0 oriented to north. The default value is 360.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? HorizontalEndAngle { get; set; } = "360";

		/// <summary>
		/// <para>Vertical upper angle</para>
		/// <para>The upper vertical angle limit of the scan relative to the horizontal plane. The value is specified in degrees and can be integer or floating point. The allowed range is from above -90 up to and including 90.</para>
		/// <para>This parameter value must be greater than the Vertical Lower Angle parameter value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// <para>The default value is 90 (straight up).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? VerticalUpperAngle { get; set; } = "90";

		/// <summary>
		/// <para>Vertical lower angle</para>
		/// <para>The lower vertical angle limit of the scan relative to the horizontal plane. The value is specified in degrees and can be integer or floating point. The allowed range is from -90 up to but not including 90.</para>
		/// <para>This parameter value must be less than the Vertical Upper Angle parameter value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features dataset.</para>
		/// <para>The default value is -90 (straight down).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Observer parameters")]
		public object? VerticalLowerAngle { get; set; } = "-90";

		/// <summary>
		/// <para>Analysis method</para>
		/// <para>Specifies the method by which the visibility will be calculated. This option allows you to trade some accuracy for increased performance.</para>
		/// <para>All Sightlines—A sightline is run to every cell on the raster in order to establish visible areas. This is the default method.</para>
		/// <para>Perimeter Sightlines—Sightlines are only run to the cells on the perimeter of the visible areas in order to establish visibility areas. This method has a better performance than the All Sightlines method since less sightlines are run in the calculation.</para>
		/// <para><see cref="AnalysisMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Viewshed parameters")]
		public object? AnalysisMethod { get; set; } = "ALL_SIGHTLINES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Viewshed2 SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Analysis type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>Frequency—The output records the number of times that each cell location in the input surface raster can be seen by the input observation locations (as points or as vertices for polyline observer features). This is the default.</para>
			/// </summary>
			[GPValue("FREQUENCY")]
			[Description("Frequency")]
			Frequency,

			/// <summary>
			/// <para>Observers—The output identifies exactly which observer points are visible from each raster surface location. The allowed maximum number of input observers is 32 with this analysis type.</para>
			/// </summary>
			[GPValue("OBSERVERS")]
			[Description("Observers")]
			Observers,

		}

		/// <summary>
		/// <para>Inner radius is 3D distance</para>
		/// </summary>
		public enum InnerRadiusIs3DEnum 
		{
			/// <summary>
			/// <para>Checked—The inner radius is to be interpreted as a 3D distance.</para>
			/// </summary>
			[GPValue("true")]
			[Description("3D")]
			_3D,

			/// <summary>
			/// <para>Unchecked—The inner radius is to be interpreted as a 2D distance. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("GROUND")]
			GROUND,

		}

		/// <summary>
		/// <para>Outer radius is 3D distance</para>
		/// </summary>
		public enum OuterRadiusIs3DEnum 
		{
			/// <summary>
			/// <para>Checked—The outer radius is to be interpreted as a 3D distance.</para>
			/// </summary>
			[GPValue("true")]
			[Description("3D")]
			_3D,

			/// <summary>
			/// <para>Unchecked—The outer radius is to be interpreted as a 2D distance. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("GROUND")]
			GROUND,

		}

		/// <summary>
		/// <para>Analysis method</para>
		/// </summary>
		public enum AnalysisMethodEnum 
		{
			/// <summary>
			/// <para>All Sightlines—A sightline is run to every cell on the raster in order to establish visible areas. This is the default method.</para>
			/// </summary>
			[GPValue("ALL_SIGHTLINES")]
			[Description("All Sightlines")]
			All_Sightlines,

			/// <summary>
			/// <para>Perimeter Sightlines—Sightlines are only run to the cells on the perimeter of the visible areas in order to establish visibility areas. This method has a better performance than the All Sightlines method since less sightlines are run in the calculation.</para>
			/// </summary>
			[GPValue("PERIMETER_SIGHTLINES")]
			[Description("Perimeter Sightlines")]
			Perimeter_Sightlines,

		}

#endregion
	}
}
