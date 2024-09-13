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
	/// <para>Surface Parameters</para>
	/// <para>Surface Parameters</para>
	/// <para>Determines parameters of a surface raster such as aspect, slope, and several types of curvatures using geodesic methods.</para>
	/// </summary>
	public class SurfaceParameters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsurfaceraster">
		/// <para>Input Surface Raster</para>
		/// <para>The input surface raster. It can be integer or floating point type.</para>
		/// </param>
		/// <param name="Outputrastername">
		/// <para>Output Raster Name</para>
		/// <para>The name of the output raster service.</para>
		/// </param>
		public SurfaceParameters(object Inputsurfaceraster, object Outputrastername)
		{
			this.Inputsurfaceraster = Inputsurfaceraster;
			this.Outputrastername = Outputrastername;
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
		/// <para>Tool Excute Name : ra.SurfaceParameters</para>
		/// </summary>
		public override string ExcuteName() => "ra.SurfaceParameters";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputsurfaceraster, Outputrastername, Parametertype!, Localsurfacetype!, Neighborhooddistance!, Useadaptiveneighborhood!, Zunit!, Outputslopemeasurement!, Projectgeodesicazimuths!, Useequatorialaspect!, Outputraster! };

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>The input surface raster. It can be integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Output Raster Name</para>
		/// <para>The name of the output raster service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputrastername { get; set; }

		/// <summary>
		/// <para>Parameter Type</para>
		/// <para>Specifies the output surface parameter type that will be computed.</para>
		/// <para>Slope—The rate of change in elevation will be computed. This is the default.</para>
		/// <para>Aspect—The downslope direction of the maximum rate of change for each cell will be computed.</para>
		/// <para>Mean curvature—The overall curvature of the surface will be measured. It is computed as the average of the minimum and maximum curvature. This curvature describes the intrinsic convexity or concavity of the surface, independent of direction or gravity influence.</para>
		/// <para>Tangential (normal contour) curvature—The geometric normal curvature perpendicular to the slope line, tangent to the contour line will be measured. This curvature is typically applied to characterize the convergence or divergence of flow across the surface.</para>
		/// <para>Profile (normal slope line) curvature—The geometric normal curvature along the slope line will be measured. This curvature is typically applied to characterize the acceleration and deceleration of flow down the surface.</para>
		/// <para>Plan (projected contour) curvature—The curvature along contour lines will be measured.</para>
		/// <para>Contour geodesic torsion—The rate of change in slope angle along contour lines will be measured.</para>
		/// <para>Gaussian curvature—The overall curvature of the surface will be measured. It is computed as the product of the minimum and maximum curvature.</para>
		/// <para>Casorati curvature—The general curvature of the surface will be measured. It can be zero or any other positive number.</para>
		/// <para><see cref="ParametertypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Parametertype { get; set; } = "SLOPE";

		/// <summary>
		/// <para>Local Surface Type</para>
		/// <para>Specifies the type of surface function that will be fitted around the target cell.</para>
		/// <para>Quadratic—A quadratic surface function will be fitted to the neighborhood cells. This is the default.</para>
		/// <para>Biquadratic—A biquadratic surface function will be fitted to the neighborhood cells.</para>
		/// <para><see cref="LocalsurfacetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Localsurfacetype { get; set; } = "QUADRATIC";

		/// <summary>
		/// <para>Neighborhood Distance</para>
		/// <para>The output will be calculated over this distance from the target cell center. It determines the neighborhood size.</para>
		/// <para>The default value is the input raster cell size, resulting in a 3 by 3 neighborhood.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? Neighborhooddistance { get; set; }

		/// <summary>
		/// <para>Use Adaptive Neighborhood</para>
		/// <para>Specifies whether neighborhood distance will vary with landscape changes (adaptive). The maximum distance is determined by the neighborhood distance. The minimum distance is the input raster cell size.</para>
		/// <para>Unchecked—A single (fixed) neighborhood distance will be used at all locations. This is the default.</para>
		/// <para>Checked—An adaptive neighborhood distance will be used at all locations.</para>
		/// <para><see cref="UseadaptiveneighborhoodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Useadaptiveneighborhood { get; set; } = "false";

		/// <summary>
		/// <para>Z Unit</para>
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
		/// <para><see cref="ZunitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Zunit { get; set; } = "METER";

		/// <summary>
		/// <para>Output Slope Measurement</para>
		/// <para>The measurement units (degrees or percentages) that will be used for the output slope raster. This parameter is only active when Parameter Type is Slope.</para>
		/// <para>Degree—The inclination of slope will be calculated in degrees.</para>
		/// <para>Percent rise—The inclination of slope will be calculated as percent rise, also referred to as the percent slope.</para>
		/// <para><see cref="OutputslopemeasurementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Outputslopemeasurement { get; set; } = "DEGREE";

		/// <summary>
		/// <para>Project Geodesic Azimuths</para>
		/// <para>Specifies whether geodesic azimuths will be projected to correct the angle distortion caused by the output spatial reference.</para>
		/// <para>Unchecked—Geodesic azimuths will not be projected. This is the default.</para>
		/// <para>Checked—Geodesic azimuths will be projected.</para>
		/// <para><see cref="ProjectgeodesicazimuthsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Projectgeodesicazimuths { get; set; } = "false";

		/// <summary>
		/// <para>Use Equatorial Aspect</para>
		/// <para>Specifies whether aspect will be measured from a point on the equator or from the north pole.</para>
		/// <para>Unchecked—Aspect will be measured from the north pole. This is the default.</para>
		/// <para>Checked—Aspect will be measured from a point on the equator.</para>
		/// <para><see cref="UseequatorialaspectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Useequatorialaspect { get; set; } = "false";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceParameters SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Parameter Type</para>
		/// </summary>
		public enum ParametertypeEnum 
		{
			/// <summary>
			/// <para>Slope—The rate of change in elevation will be computed. This is the default.</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("Slope")]
			Slope,

			/// <summary>
			/// <para>Aspect—The downslope direction of the maximum rate of change for each cell will be computed.</para>
			/// </summary>
			[GPValue("ASPECT")]
			[Description("Aspect")]
			Aspect,

			/// <summary>
			/// <para>Mean curvature—The overall curvature of the surface will be measured. It is computed as the average of the minimum and maximum curvature. This curvature describes the intrinsic convexity or concavity of the surface, independent of direction or gravity influence.</para>
			/// </summary>
			[GPValue("MEAN_CURVATURE")]
			[Description("Mean curvature")]
			Mean_curvature,

			/// <summary>
			/// <para>Tangential (normal contour) curvature—The geometric normal curvature perpendicular to the slope line, tangent to the contour line will be measured. This curvature is typically applied to characterize the convergence or divergence of flow across the surface.</para>
			/// </summary>
			[GPValue("TANGENTIAL_CURVATURE")]
			[Description("Tangential (normal contour) curvature")]
			TANGENTIAL_CURVATURE,

			/// <summary>
			/// <para>Profile (normal slope line) curvature—The geometric normal curvature along the slope line will be measured. This curvature is typically applied to characterize the acceleration and deceleration of flow down the surface.</para>
			/// </summary>
			[GPValue("PROFILE_CURVATURE")]
			[Description("Profile (normal slope line) curvature")]
			PROFILE_CURVATURE,

			/// <summary>
			/// <para>Plan (projected contour) curvature—The curvature along contour lines will be measured.</para>
			/// </summary>
			[GPValue("CONTOUR_CURVATURE")]
			[Description("Plan (projected contour) curvature")]
			CONTOUR_CURVATURE,

			/// <summary>
			/// <para>Contour geodesic torsion—The rate of change in slope angle along contour lines will be measured.</para>
			/// </summary>
			[GPValue("CONTOUR_GEODESIC_TORSION")]
			[Description("Contour geodesic torsion")]
			Contour_geodesic_torsion,

			/// <summary>
			/// <para>Gaussian curvature—The overall curvature of the surface will be measured. It is computed as the product of the minimum and maximum curvature.</para>
			/// </summary>
			[GPValue("GAUSSIAN_CURVATURE")]
			[Description("Gaussian curvature")]
			Gaussian_curvature,

			/// <summary>
			/// <para>Casorati curvature—The general curvature of the surface will be measured. It can be zero or any other positive number.</para>
			/// </summary>
			[GPValue("CASORATI_CURVATURE")]
			[Description("Casorati curvature")]
			Casorati_curvature,

		}

		/// <summary>
		/// <para>Local Surface Type</para>
		/// </summary>
		public enum LocalsurfacetypeEnum 
		{
			/// <summary>
			/// <para>Quadratic—A quadratic surface function will be fitted to the neighborhood cells. This is the default.</para>
			/// </summary>
			[GPValue("QUADRATIC")]
			[Description("Quadratic")]
			Quadratic,

			/// <summary>
			/// <para>Biquadratic—A biquadratic surface function will be fitted to the neighborhood cells.</para>
			/// </summary>
			[GPValue("BIQUADRATIC")]
			[Description("Biquadratic")]
			Biquadratic,

		}

		/// <summary>
		/// <para>Use Adaptive Neighborhood</para>
		/// </summary>
		public enum UseadaptiveneighborhoodEnum 
		{
			/// <summary>
			/// <para>Checked—An adaptive neighborhood distance will be used at all locations.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADAPTIVE_NEIGHBORHOOD")]
			ADAPTIVE_NEIGHBORHOOD,

			/// <summary>
			/// <para>Unchecked—A single (fixed) neighborhood distance will be used at all locations. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FIXED_NEIGHBORHOOD")]
			FIXED_NEIGHBORHOOD,

		}

		/// <summary>
		/// <para>Z Unit</para>
		/// </summary>
		public enum ZunitEnum 
		{
			/// <summary>
			/// <para>Meter—The linear unit will be meters.</para>
			/// </summary>
			[GPValue("METER")]
			[Description("Meter")]
			Meter,

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
		/// <para>Output Slope Measurement</para>
		/// </summary>
		public enum OutputslopemeasurementEnum 
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
		/// <para>Project Geodesic Azimuths</para>
		/// </summary>
		public enum ProjectgeodesicazimuthsEnum 
		{
			/// <summary>
			/// <para>Checked—Geodesic azimuths will be projected.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_GEODESIC_AZIMUTHS")]
			PROJECT_GEODESIC_AZIMUTHS,

			/// <summary>
			/// <para>Unchecked—Geodesic azimuths will not be projected. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("GEODESIC_AZIMUTHS")]
			GEODESIC_AZIMUTHS,

		}

		/// <summary>
		/// <para>Use Equatorial Aspect</para>
		/// </summary>
		public enum UseequatorialaspectEnum 
		{
			/// <summary>
			/// <para>Checked—Aspect will be measured from a point on the equator.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EQUATORIAL_ASPECT")]
			EQUATORIAL_ASPECT,

			/// <summary>
			/// <para>Unchecked—Aspect will be measured from the north pole. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NORTH_POLE_ASPECT")]
			NORTH_POLE_ASPECT,

		}

#endregion
	}
}
