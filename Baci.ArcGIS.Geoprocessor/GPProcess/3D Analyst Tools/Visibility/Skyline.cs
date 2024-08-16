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
	/// <para>Skyline</para>
	/// <para>Generates a line or multipatch feature class containing the results from a skyline or silhouette analysis.</para>
	/// </summary>
	public class Skyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPointFeatures">
		/// <para>Input Observer Point Features</para>
		/// <para>The 3D points representing observers. Each feature will have its own output.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The 3D features that will either be lines that represent the skyline or multipatches that represent silhouettes.</para>
		/// </param>
		public Skyline(object InObserverPointFeatures, object OutFeatureClass)
		{
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Skyline</para>
		/// </summary>
		public override string DisplayName => "Skyline";

		/// <summary>
		/// <para>Tool Name : Skyline</para>
		/// </summary>
		public override string ToolName => "Skyline";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Skyline</para>
		/// </summary>
		public override string ExcuteName => "3d.Skyline";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "geographicTransformations", "outputCoordinateSystem", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InObserverPointFeatures, OutFeatureClass, InSurface, VirtualSurfaceRadius, VirtualSurfaceElevation, InFeatures, FeatureLod, FromAzimuthValueOrField, ToAzimuthValueOrField, AzimuthIncrementValueOrField, MaxHorizonRadius, SegmentSkyline, ScaleToPercent, ScaleAccordingTo, ScaleMethod, UseCurvature, UseRefraction, RefractionFactor, PyramidLevelResolution, CreateSilhouettes };

		/// <summary>
		/// <para>Input Observer Point Features</para>
		/// <para>The 3D points representing observers. Each feature will have its own output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The 3D features that will either be lines that represent the skyline or multipatches that represent silhouettes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The topographic surface that will be used to define the horizon. If no surface is provided, then a virtual surface will be employed using the Virtual Surface Radius and Virtual Surface Elevation parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Virtual Surface Radius</para>
		/// <para>The radius of the virtual surface that will be used to define the horizon when a topographic surface is not provided. The default is 1,000 meters.</para>
		/// <para>The following units are supported:</para>
		/// <para>Unknown—Unknown</para>
		/// <para>Inches—Inches</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Miles—Miles</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Meters—Meters</para>
		/// <para>Kilometers—Kilometers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object VirtualSurfaceRadius { get; set; } = "1000 Meters";

		/// <summary>
		/// <para>Virtual Surface Elevation</para>
		/// <para>The elevation of the virtual surface for defining the horizon in lieu of an actual surface. It is ignored if an actual surface is provided. The default is 0.</para>
		/// <para>The following units are supported:</para>
		/// <para>Unknown—Unknown</para>
		/// <para>Inches—Inches</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Miles—Miles</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Meters—Meters</para>
		/// <para>Kilometers—Kilometers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object VirtualSurfaceElevation { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features used in determining the skyline. If no features are specified, then the skyline will consist solely of the horizon line as defined by the topographic or virtual surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Feature Level of Detail</para>
		/// <para>The level of detail at which each feature should be examined in the skyline analysis.</para>
		/// <para>Full Detail—Every edge within the feature is considered in the skyline analysis (only edges of triangles and exterior rings are considered). This time intensive operation is the most precise, and is also the default option.</para>
		/// <para>Convex Footprint—The skyline analysis will use the upper perimeter of the convex hull of each feature&apos;s footprint extruded to the elevation of the highest vertex within the feature.</para>
		/// <para>Envelope— The skyline analysis will use the perimeter of the 3-dimensional feature envelope. This is the fastest technique.</para>
		/// <para><see cref="FeatureLodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FeatureLod { get; set; } = "FULL_DETAIL";

		/// <summary>
		/// <para>From Azimuth</para>
		/// <para>The azimuth, in degrees, from which the skyline analysis should be started. The analysis starts from the observer point and goes to the right, from the From Azimuth until the To Azimuth is reached. Must be greater than minus 360 and less than 360. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Azimuths")]
		public object FromAzimuthValueOrField { get; set; } = "0";

		/// <summary>
		/// <para>To Azimuth</para>
		/// <para>The direction, in degrees, at which the skyline analysis should be completed. The analysis starts from the observer point and goes to the right, from the From Azimuth until the To Azimuth is reached. Must be no more than 360 greater than the From Azimuth. The default is 360.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Azimuths")]
		public object ToAzimuthValueOrField { get; set; } = "360";

		/// <summary>
		/// <para>Azimuth Increment</para>
		/// <para>The angular interval, in degrees, at which the horizon should be evaluated while conducting the skyline analysis between the From Azimuth and the To Azimuth. Must be no greater than the To Azimuth minus the From Azimuth. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Azimuths")]
		public object AzimuthIncrementValueOrField { get; set; } = "1";

		/// <summary>
		/// <para>Maximum Horizon Radius</para>
		/// <para>The maximum distance for which a horizon should be sought from the observer location. A value of zero indicates that there should be no limit imposed. The default is 0.</para>
		/// <para>The following units are supported:</para>
		/// <para>Unknown—Unknown</para>
		/// <para>Inches—Inches</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Miles—Miles</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Meters—Meters</para>
		/// <para>Kilometers—Kilometers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Skyline Options")]
		public object MaxHorizonRadius { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Segment Skyline</para>
		/// <para>Determines whether the resulting skyline will have one feature for each observer point, or if each observer&apos;s skyline will be segmented by the unique elements that contribute to the skyline.</para>
		/// <para>If silhouettes are being generated, then this parameter will indicate whether divergent rays should be used; for sun shadows, this should generally be no or unchecked.</para>
		/// <para>Unchecked—Each skyline feature will represent one observer. This is the default.</para>
		/// <para>Checked—Each observer&apos;s skyline will be segmented by the unique elements that contribute to the skyline.</para>
		/// <para><see cref="SegmentSkylineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Skyline Options")]
		public object SegmentSkyline { get; set; } = "false";

		/// <summary>
		/// <para>Scale To Percent</para>
		/// <para>Indicates to what percent of the original vertical angle (angle above the horizon, or angle of elevation) or elevation each skyline vertex should be placed. If either 0 or 100 is entered, then no scaling will occur. The default is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Scaling Options")]
		public object ScaleToPercent { get; set; } = "100";

		/// <summary>
		/// <para>Scale According To</para>
		/// <para>The values according to which the scaling should be determined.</para>
		/// <para>Vertical Angle From Observer—Scaling is done by considering the vertical angle of each vertex relative to the observer point. This is the default.</para>
		/// <para>Elevation—Scaling is done by considering the elevation of each vertex relative to the observer point.</para>
		/// <para><see cref="ScaleAccordingToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Scaling Options")]
		public object ScaleAccordingTo { get; set; } = "VERTICAL_ANGLE";

		/// <summary>
		/// <para>Scale Method</para>
		/// <para>The vertex to be used to calculate against.</para>
		/// <para>Skyline Maximum—Vertices will be scaled relative to the vertical angle (or the elevation) of the vertex with the highest vertical angle (or elevation). This is the default.</para>
		/// <para>Each Vertex—Vertices will be scaled relative to the original vertical angle (or elevation) of each vertex.</para>
		/// <para><see cref="ScaleMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Scaling Options")]
		public object ScaleMethod { get; set; } = "SKYLINE_MAXIMUM";

		/// <summary>
		/// <para>Use Curvature</para>
		/// <para>Indicates whether the earth&apos;s curvature should be taken into consideration when generating the ridgeline from a functional surface.</para>
		/// <para>Unchecked—The earth&apos;s curvature will not be taken into consideration. This is the default.</para>
		/// <para>Checked—The earth&apos;s curvature will be taken into consideration.</para>
		/// <para><see cref="UseCurvatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object UseCurvature { get; set; } = "false";

		/// <summary>
		/// <para>Use Refraction</para>
		/// <para>Indicates whether atmospheric refraction will be applied when generating the ridgeline from a functional surface.</para>
		/// <para>Unchecked—Atmospheric refraction will not be taken into consideration. This is the default.</para>
		/// <para>Checked—Atmospheric refraction will be taken into consideration.</para>
		/// <para><see cref="UseRefractionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object UseRefraction { get; set; } = "false";

		/// <summary>
		/// <para>Refraction Factor</para>
		/// <para>The refraction coefficient to be used if atmospheric refraction is being considered. The default is 0.13.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object RefractionFactor { get; set; } = "0.13";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used by this tool. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Create Silhouettes</para>
		/// <para>Specifies whether output features will represent skylines or silhouettes.</para>
		/// <para>Unchecked—The output will be created as polyline features that represent the skyline. This is the default.</para>
		/// <para>Checked—The output will be created as multipatch features that represent silhouettes.</para>
		/// <para><see cref="CreateSilhouettesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Skyline Options")]
		public object CreateSilhouettes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Skyline SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object geographicTransformations = null , object outputCoordinateSystem = null , object terrainMemoryUsage = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Feature Level of Detail</para>
		/// </summary>
		public enum FeatureLodEnum 
		{
			/// <summary>
			/// <para>Full Detail—Every edge within the feature is considered in the skyline analysis (only edges of triangles and exterior rings are considered). This time intensive operation is the most precise, and is also the default option.</para>
			/// </summary>
			[GPValue("FULL_DETAIL")]
			[Description("Full Detail")]
			Full_Detail,

			/// <summary>
			/// <para>Convex Footprint—The skyline analysis will use the upper perimeter of the convex hull of each feature&apos;s footprint extruded to the elevation of the highest vertex within the feature.</para>
			/// </summary>
			[GPValue("CONVEX_FOOTPRINT")]
			[Description("Convex Footprint")]
			Convex_Footprint,

			/// <summary>
			/// <para>Envelope— The skyline analysis will use the perimeter of the 3-dimensional feature envelope. This is the fastest technique.</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("Envelope")]
			Envelope,

		}

		/// <summary>
		/// <para>Segment Skyline</para>
		/// </summary>
		public enum SegmentSkylineEnum 
		{
			/// <summary>
			/// <para>Checked—Each observer&apos;s skyline will be segmented by the unique elements that contribute to the skyline.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SEGMENT_SKYLINE")]
			SEGMENT_SKYLINE,

			/// <summary>
			/// <para>Unchecked—Each skyline feature will represent one observer. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SEGMENT_SKYLINE")]
			NO_SEGMENT_SKYLINE,

		}

		/// <summary>
		/// <para>Scale According To</para>
		/// </summary>
		public enum ScaleAccordingToEnum 
		{
			/// <summary>
			/// <para>Vertical Angle From Observer—Scaling is done by considering the vertical angle of each vertex relative to the observer point. This is the default.</para>
			/// </summary>
			[GPValue("VERTICAL_ANGLE")]
			[Description("Vertical Angle From Observer")]
			Vertical_Angle_From_Observer,

			/// <summary>
			/// <para>Elevation—Scaling is done by considering the elevation of each vertex relative to the observer point.</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("Elevation")]
			Elevation,

		}

		/// <summary>
		/// <para>Scale Method</para>
		/// </summary>
		public enum ScaleMethodEnum 
		{
			/// <summary>
			/// <para>Skyline Maximum—Vertices will be scaled relative to the vertical angle (or the elevation) of the vertex with the highest vertical angle (or elevation). This is the default.</para>
			/// </summary>
			[GPValue("SKYLINE_MAXIMUM")]
			[Description("Skyline Maximum")]
			Skyline_Maximum,

			/// <summary>
			/// <para>Each Vertex—Vertices will be scaled relative to the original vertical angle (or elevation) of each vertex.</para>
			/// </summary>
			[GPValue("EACH_VERTEX")]
			[Description("Each Vertex")]
			Each_Vertex,

		}

		/// <summary>
		/// <para>Use Curvature</para>
		/// </summary>
		public enum UseCurvatureEnum 
		{
			/// <summary>
			/// <para>Checked—The earth&apos;s curvature will be taken into consideration.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CURVATURE")]
			CURVATURE,

			/// <summary>
			/// <para>Unchecked—The earth&apos;s curvature will not be taken into consideration. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CURVATURE")]
			NO_CURVATURE,

		}

		/// <summary>
		/// <para>Use Refraction</para>
		/// </summary>
		public enum UseRefractionEnum 
		{
			/// <summary>
			/// <para>Checked—Atmospheric refraction will be taken into consideration.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REFRACTION")]
			REFRACTION,

			/// <summary>
			/// <para>Unchecked—Atmospheric refraction will not be taken into consideration. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REFRACTION")]
			NO_REFRACTION,

		}

		/// <summary>
		/// <para>Create Silhouettes</para>
		/// </summary>
		public enum CreateSilhouettesEnum 
		{
			/// <summary>
			/// <para>Checked—The output will be created as multipatch features that represent silhouettes.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_SILHOUETTES")]
			CREATE_SILHOUETTES,

			/// <summary>
			/// <para>Unchecked—The output will be created as polyline features that represent the skyline. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_SILHOUETTES")]
			NO_CREATE_SILHOUETTES,

		}

#endregion
	}
}
