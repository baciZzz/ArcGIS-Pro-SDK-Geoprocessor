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
	/// <para>Visibility</para>
	/// <para>Determines the raster surface locations visible to a set of observer features, or identifies which observer points are visible from each raster surface location.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.Viewshed2"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.Viewshed2))]
	public class Visibility : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="InObserverFeatures">
		/// <para>Input point or polyline observer features</para>
		/// <para>The feature class that identifies the observer locations.</para>
		/// <para>The input can be point or polyline features.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output will either record the number of times that each cell location in the input surface raster can be seen by the input observation locations (the frequency analysis type), or record which observer locations are visible from each cell in the raster surface (the observers type).</para>
		/// </param>
		public Visibility(object InRaster, object InObserverFeatures, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InObserverFeatures = InObserverFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Visibility</para>
		/// </summary>
		public override string DisplayName => "Visibility";

		/// <summary>
		/// <para>Tool Name : Visibility</para>
		/// </summary>
		public override string ToolName => "Visibility";

		/// <summary>
		/// <para>Tool Excute Name : sa.Visibility</para>
		/// </summary>
		public override string ExcuteName => "sa.Visibility";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, InObserverFeatures, OutRaster, OutAglRaster!, AnalysisType!, NonvisibleCellValue!, ZFactor!, CurvatureCorrection!, RefractivityCoefficient!, SurfaceOffset!, ObserverElevation!, ObserverOffset!, InnerRadius!, OuterRadius!, HorizontalStartAngle!, HorizontalEndAngle!, VerticalUpperAngle!, VerticalLowerAngle! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input point or polyline observer features</para>
		/// <para>The feature class that identifies the observer locations.</para>
		/// <para>The input can be point or polyline features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output will either record the number of times that each cell location in the input surface raster can be seen by the input observation locations (the frequency analysis type), or record which observer locations are visible from each cell in the raster surface (the observers type).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output above ground level raster</para>
		/// <para>The output above-ground-level (AGL) raster.</para>
		/// <para>The AGL result is a raster where each cell value is the minimum height that must be added to an otherwise nonvisible cell to make it visible by at least one observer.</para>
		/// <para>Cells that were already visible will have a value of 0 in this output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutAglRaster { get; set; }

		/// <summary>
		/// <para>Analysis type</para>
		/// <para>The visibility analysis type.</para>
		/// <para>Frequency—The output records the number of times that each cell location in the input surface raster can be seen by the input observation locations (as points, or as vertices for polyline observer features). This is the default.</para>
		/// <para>Observers—The output identifies exactly which observer points are visible from each raster surface location.</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AnalysisType { get; set; } = "FREQUENCY";

		/// <summary>
		/// <para>Use NoData for non-visible cells</para>
		/// <para>Value assigned to nonvisible cells.</para>
		/// <para>Unchecked—0 is assigned to nonvisible cells. This is the default.</para>
		/// <para>Checked—NoData is assigned to nonvisible cells.</para>
		/// <para><see cref="NonvisibleCellValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NonvisibleCellValue { get; set; } = "false";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>Number of ground x,y units in one surface z unit.</para>
		/// <para>The z-factor adjusts the units of measure for the z units when they are different from the x,y units of the input surface. The z-values of the input surface are multiplied by the z-factor when calculating the final output surface.</para>
		/// <para>If the x,y units and z units are in the same units of measure, the z-factor is 1. This is the default.</para>
		/// <para>If the x,y units and z units are in different units of measure, the z-factor must be set to the appropriate factor, or the results will be incorrect. For example, if your z units are feet and your x,y units are meters, you would use a z-factor of 0.3048 to convert your z units from feet to meters (1 foot = 0.3048 meter).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Use earth curvature corrections</para>
		/// <para>Specifies whether correction for the earth&apos;s curvature will be applied.</para>
		/// <para>Unchecked—No curvature correction will be applied. This is the default.</para>
		/// <para>Checked—Curvature correction will be applied.</para>
		/// <para><see cref="CurvatureCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CurvatureCorrection { get; set; } = "false";

		/// <summary>
		/// <para>Refractivity coefficient</para>
		/// <para>The coefficient of the refraction of visible light in air.</para>
		/// <para>The default value is 0.13.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? RefractivityCoefficient { get; set; } = "0.13";

		/// <summary>
		/// <para>Surface offset</para>
		/// <para>A vertical distance to be added to the z-value of each cell as it is considered for visibility. It must be a positive integer or floating-point value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field OFFSETB is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? SurfaceOffset { get; set; }

		/// <summary>
		/// <para>Observer elevation</para>
		/// <para>The surface elevations of the observer points or vertices.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field SPOT is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it will be estimated through bilinear interpolation with the surface elevation values in the neighboring cells of the observer location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? ObserverElevation { get; set; }

		/// <summary>
		/// <para>Observer offset</para>
		/// <para>A vertical distance to be added to the observer elevation. It must be a positive integer or floating-point value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field OFFSETA is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? ObserverOffset { get; set; }

		/// <summary>
		/// <para>Inner radius</para>
		/// <para>The start distance from which visibility is determined. Cells closer than this distance are not visible in the output but can still block visibility of the cells between inner radius and outer radius.</para>
		/// <para>It can be a positive or negative integer or floating point value. If it is a positive value, then it is interpreted as three-dimensional, line-of-sight distance. If it is a negative value, then it is interpreted as two-dimensional planimetric distance.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field RADIUS1 is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? InnerRadius { get; set; }

		/// <summary>
		/// <para>Outer radius</para>
		/// <para>The maximum distance from which visibility is determined. Cells beyond this distance are excluded from the analysis.</para>
		/// <para>It can be a positive or negative integer or floating point value. If it is a positive value, then it is interpreted as three-dimensional, line-of-sight distance. If it is a negative value, then it is interpreted as two-dimensional planimetric distance.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field RADIUS2 is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to infinity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? OuterRadius { get; set; }

		/// <summary>
		/// <para>Horizontal start angle</para>
		/// <para>The start angle of the horizontal scan range. The value should be specified in degrees from 0 to 360, either as integer or floating point, with 0 oriented to north. The default value is 0.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field AZIMUTH1 is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? HorizontalStartAngle { get; set; }

		/// <summary>
		/// <para>Horizontal end angle</para>
		/// <para>The end angle of the horizontal scan range. The value should be specified in degrees from 0 to 360, either as integer or floating point, with 0 oriented to north. The default value is 360.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field AZIMUTH2 is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to 360.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? HorizontalEndAngle { get; set; }

		/// <summary>
		/// <para>Vertical upper angle</para>
		/// <para>The upper vertical angle limit of the scan relative to the horizontal plane. The value is specified in degrees and can be integer or floating point. The allowed range is from above -90 up to and including 90.</para>
		/// <para>This parameter value must be greater than the Vertical Lower Angle parameter value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field VERT1 is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to 90.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? VerticalUpperAngle { get; set; }

		/// <summary>
		/// <para>Vertical lower angle</para>
		/// <para>The lower vertical angle limit of the scan relative to the horizontal plane. The value is specified in degrees and can be integer or floating point. The allowed range is from -90 up to but not including 90.</para>
		/// <para>This parameter value must be less than the Vertical Upper Angle parameter value.</para>
		/// <para>You can select a field in the input observers dataset, or you can specify a numerical value.</para>
		/// <para>By default, a numerical field VERT2 is used if it exists in the input observer features attribute table. You may overwrite it by specifying another numerical field or a value.</para>
		/// <para>If this parameter is unspecified and the default field does not exist in the input observer features attribute table, it defaults to -90.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Observer parameters")]
		public object? VerticalLowerAngle { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Visibility SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Analysis type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>Frequency—The output records the number of times that each cell location in the input surface raster can be seen by the input observation locations (as points, or as vertices for polyline observer features). This is the default.</para>
			/// </summary>
			[GPValue("FREQUENCY")]
			[Description("Frequency")]
			Frequency,

			/// <summary>
			/// <para>Observers—The output identifies exactly which observer points are visible from each raster surface location.</para>
			/// </summary>
			[GPValue("OBSERVERS")]
			[Description("Observers")]
			Observers,

		}

		/// <summary>
		/// <para>Use NoData for non-visible cells</para>
		/// </summary>
		public enum NonvisibleCellValueEnum 
		{
			/// <summary>
			/// <para>Unchecked—0 is assigned to nonvisible cells. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ZERO")]
			ZERO,

			/// <summary>
			/// <para>Checked—NoData is assigned to nonvisible cells.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NODATA")]
			NODATA,

		}

		/// <summary>
		/// <para>Use earth curvature corrections</para>
		/// </summary>
		public enum CurvatureCorrectionEnum 
		{
			/// <summary>
			/// <para>Unchecked—No curvature correction will be applied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FLAT_EARTH")]
			FLAT_EARTH,

			/// <summary>
			/// <para>Checked—Curvature correction will be applied.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CURVED_EARTH")]
			CURVED_EARTH,

		}

#endregion
	}
}
