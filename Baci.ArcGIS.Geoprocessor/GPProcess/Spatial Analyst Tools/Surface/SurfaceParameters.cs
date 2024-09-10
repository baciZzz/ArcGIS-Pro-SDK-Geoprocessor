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
	/// <para>Surface Parameters</para>
	/// <para>Determines parameters of a raster surface such as aspect, slope and curvatures.</para>
	/// </summary>
	public class SurfaceParameters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input surface raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// </param>
		public SurfaceParameters(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Surface Parameters</para>
		/// </summary>
		public override string DisplayName() => "Surface Parameters";

		/// <summary>
		/// <para>Tool Name : SurfaceParameters</para>
		/// </summary>
		public override string ToolName() => "SurfaceParameters";

		/// <summary>
		/// <para>Tool Excute Name : sa.SurfaceParameters</para>
		/// </summary>
		public override string ExcuteName() => "sa.SurfaceParameters";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, ParameterType, LocalSurfaceType, NeighborhoodDistance, UseAdaptiveNeighborhood, ZUnit, OutputSlopeMeasurement, ProjectGeodesicAzimuths, UseEquatorialAspect };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Parameter type</para>
		/// <para>Determines the output surface parameter type to compute.</para>
		/// <para>Slope—The rate of change in elevation. This is the default.</para>
		/// <para>Aspect—The downslope direction of the maximum rate of change for each cell.</para>
		/// <para>Mean curvature—Measures the overall curvature of the surface. It is computed as the average of the minimum and maximum curvature. This curvature describes the intrinsic convexity or concavity of the surface, independent of direction or gravity influence.</para>
		/// <para>Tangential (normal contour) curvature—Measures the geometric normal curvature perpendicular to the slope line, tangent to the contour line. This curvature is typically applied to characterize the convergence or divergence of flow across the surface.</para>
		/// <para>Profile (normal slope line) curvature—Measures the geometric normal curvature along the slope line. This curvature is typically applied to characterize the acceleration and deceleration of flow down the surface.</para>
		/// <para><see cref="ParameterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ParameterType { get; set; } = "SLOPE";

		/// <summary>
		/// <para>Local surface type</para>
		/// <para>Determines the type of surface function fitted around the target cell.</para>
		/// <para>Quadratic—Fits a quadratic surface function to the neighborhood cells. This is the default.</para>
		/// <para>Biquadratic—Fits a biquadratic surface function to the neighborhood cells.</para>
		/// <para><see cref="LocalSurfaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocalSurfaceType { get; set; } = "QUADRATIC";

		/// <summary>
		/// <para>Neighborhood distance</para>
		/// <para>The output is calculated over this distance from the target cell center. It determines the neighborhood size.</para>
		/// <para>The default value is the input raster cell size, resulting in a 3 x 3 neighborhood.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object NeighborhoodDistance { get; set; }

		/// <summary>
		/// <para>Use adaptive neighborhood</para>
		/// <para>Allow neighborhood distance to vary with landscape changes. The maximum distance is determined by the neighborhood distance. The minimum distance is the input raster cell size.</para>
		/// <para>Unchecked—Use a single (fixed) neighborhood distance at all locations. This is the default.</para>
		/// <para>Checked—Use an adaptive neighborhood distance at all locations.</para>
		/// <para><see cref="UseAdaptiveNeighborhoodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseAdaptiveNeighborhood { get; set; } = "false";

		/// <summary>
		/// <para>Z unit</para>
		/// <para>The linear unit of vertical z-values.</para>
		/// <para>It is defined by a vertical coordinate system if it exists. If a vertical coordinate system does not exist, the z-unit should be defined from the unit list to ensure correct geodesic computation. The default is meter.</para>
		/// <para>Inch—The linear unit will be inches.</para>
		/// <para>Foot—The linear unit will be feet.</para>
		/// <para>Yard—The linear unit will be yards.</para>
		/// <para>Mile US—The linear unit will be miles.</para>
		/// <para>Nautical mile—The linear unit will be nautical miles.</para>
		/// <para>Millimeter—The linear unit will be millimeters.</para>
		/// <para>Centimeter—The linear unit will be centimeters.</para>
		/// <para>Meter—The linear unit will be meters.</para>
		/// <para>Kilometer—The linear unit will be kilometers.</para>
		/// <para>Decimeter—The linear unit will be decimeters.</para>
		/// <para><see cref="ZUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ZUnit { get; set; } = "METER";

		/// <summary>
		/// <para>Output slope measurement</para>
		/// <para>When Parameter type is Slope, determines the measurement units (degrees or percentages) of the output slope raster.</para>
		/// <para>Degree—The inclination of slope will be calculated in degrees.</para>
		/// <para>Percent rise—The inclination of slope will be calculated as percent rise, also referred to as the percent slope.</para>
		/// <para><see cref="OutputSlopeMeasurementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputSlopeMeasurement { get; set; } = "DEGREE";

		/// <summary>
		/// <para>Project geodesic azimuths</para>
		/// <para>Specifies whether geodesic azimuths will be projected to correct the angle distortion caused by the output spatial reference.</para>
		/// <para>Unchecked—Geodesic azimuths will not be projected. This is the default.</para>
		/// <para>Checked—Geodesic azimuths will be projected.</para>
		/// <para><see cref="ProjectGeodesicAzimuthsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProjectGeodesicAzimuths { get; set; } = "false";

		/// <summary>
		/// <para>Use equatorial aspect</para>
		/// <para>Measure aspect from a point on the equator.</para>
		/// <para>Unchecked—Measure aspect from the North Pole. This is the default.</para>
		/// <para>Checked—Measure aspect from a point on the equator.</para>
		/// <para><see cref="UseEquatorialAspectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseEquatorialAspect { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceParameters SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Parameter type</para>
		/// </summary>
		public enum ParameterTypeEnum 
		{
			/// <summary>
			/// <para>Slope—The rate of change in elevation. This is the default.</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("Slope")]
			Slope,

			/// <summary>
			/// <para>Aspect—The downslope direction of the maximum rate of change for each cell.</para>
			/// </summary>
			[GPValue("ASPECT")]
			[Description("Aspect")]
			Aspect,

			/// <summary>
			/// <para>Mean curvature—Measures the overall curvature of the surface. It is computed as the average of the minimum and maximum curvature. This curvature describes the intrinsic convexity or concavity of the surface, independent of direction or gravity influence.</para>
			/// </summary>
			[GPValue("MEAN_CURVATURE")]
			[Description("Mean curvature")]
			Mean_curvature,

			/// <summary>
			/// <para>Profile (normal slope line) curvature—Measures the geometric normal curvature along the slope line. This curvature is typically applied to characterize the acceleration and deceleration of flow down the surface.</para>
			/// </summary>
			[GPValue("PROFILE_CURVATURE")]
			[Description("Profile (normal slope line) curvature")]
			PROFILE_CURVATURE,

			/// <summary>
			/// <para>Tangential (normal contour) curvature—Measures the geometric normal curvature perpendicular to the slope line, tangent to the contour line. This curvature is typically applied to characterize the convergence or divergence of flow across the surface.</para>
			/// </summary>
			[GPValue("TANGENTIAL_CURVATURE")]
			[Description("Tangential (normal contour) curvature")]
			TANGENTIAL_CURVATURE,

		}

		/// <summary>
		/// <para>Local surface type</para>
		/// </summary>
		public enum LocalSurfaceTypeEnum 
		{
			/// <summary>
			/// <para>Quadratic—Fits a quadratic surface function to the neighborhood cells. This is the default.</para>
			/// </summary>
			[GPValue("QUADRATIC")]
			[Description("Quadratic")]
			Quadratic,

			/// <summary>
			/// <para>Biquadratic—Fits a biquadratic surface function to the neighborhood cells.</para>
			/// </summary>
			[GPValue("BIQUADRATIC")]
			[Description("Biquadratic")]
			Biquadratic,

		}

		/// <summary>
		/// <para>Use adaptive neighborhood</para>
		/// </summary>
		public enum UseAdaptiveNeighborhoodEnum 
		{
			/// <summary>
			/// <para>Unchecked—Use a single (fixed) neighborhood distance at all locations. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FIXED_NEIGHBORHOOD")]
			FIXED_NEIGHBORHOOD,

			/// <summary>
			/// <para>Checked—Use an adaptive neighborhood distance at all locations.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADAPTIVE_NEIGHBORHOOD")]
			ADAPTIVE_NEIGHBORHOOD,

		}

		/// <summary>
		/// <para>Z unit</para>
		/// </summary>
		public enum ZUnitEnum 
		{
			/// <summary>
			/// <para>Inch—The linear unit will be inches.</para>
			/// </summary>
			[GPValue("INCH")]
			[Description("Inch")]
			Inch,

			/// <summary>
			/// <para>Foot—The linear unit will be feet.</para>
			/// </summary>
			[GPValue("FOOT")]
			[Description("Foot")]
			Foot,

			/// <summary>
			/// <para>Yard—The linear unit will be yards.</para>
			/// </summary>
			[GPValue("YARD")]
			[Description("Yard")]
			Yard,

			/// <summary>
			/// <para>Mile US—The linear unit will be miles.</para>
			/// </summary>
			[GPValue("MILE_US")]
			[Description("Mile US")]
			Mile_US,

			/// <summary>
			/// <para>Nautical mile—The linear unit will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILE")]
			[Description("Nautical mile")]
			Nautical_mile,

			/// <summary>
			/// <para>Millimeter—The linear unit will be millimeters.</para>
			/// </summary>
			[GPValue("MILLIMETER")]
			[Description("Millimeter")]
			Millimeter,

			/// <summary>
			/// <para>Centimeter—The linear unit will be centimeters.</para>
			/// </summary>
			[GPValue("CENTIMETER")]
			[Description("Centimeter")]
			Centimeter,

			/// <summary>
			/// <para>Meter—The linear unit will be meters.</para>
			/// </summary>
			[GPValue("METER")]
			[Description("Meter")]
			Meter,

			/// <summary>
			/// <para>Kilometer—The linear unit will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETER")]
			[Description("Kilometer")]
			Kilometer,

			/// <summary>
			/// <para>Decimeter—The linear unit will be decimeters.</para>
			/// </summary>
			[GPValue("DECIMETER")]
			[Description("Decimeter")]
			Decimeter,

		}

		/// <summary>
		/// <para>Output slope measurement</para>
		/// </summary>
		public enum OutputSlopeMeasurementEnum 
		{
			/// <summary>
			/// <para>Degree—The inclination of slope will be calculated in degrees.</para>
			/// </summary>
			[GPValue("DEGREE")]
			[Description("Degree")]
			Degree,

			/// <summary>
			/// <para>Percent rise—The inclination of slope will be calculated as percent rise, also referred to as the percent slope.</para>
			/// </summary>
			[GPValue("PERCENT_RISE")]
			[Description("Percent rise")]
			Percent_rise,

		}

		/// <summary>
		/// <para>Project geodesic azimuths</para>
		/// </summary>
		public enum ProjectGeodesicAzimuthsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Geodesic azimuths will not be projected. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("GEODESIC_AZIMUTHS")]
			GEODESIC_AZIMUTHS,

			/// <summary>
			/// <para>Checked—Geodesic azimuths will be projected.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_GEODESIC_AZIMUTHS")]
			PROJECT_GEODESIC_AZIMUTHS,

		}

		/// <summary>
		/// <para>Use equatorial aspect</para>
		/// </summary>
		public enum UseEquatorialAspectEnum 
		{
			/// <summary>
			/// <para>Unchecked—Measure aspect from the North Pole. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NORTH_POLE_ASPECT")]
			NORTH_POLE_ASPECT,

			/// <summary>
			/// <para>Checked—Measure aspect from a point on the equator.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EQUATORIAL_ASPECT")]
			EQUATORIAL_ASPECT,

		}

#endregion
	}
}
