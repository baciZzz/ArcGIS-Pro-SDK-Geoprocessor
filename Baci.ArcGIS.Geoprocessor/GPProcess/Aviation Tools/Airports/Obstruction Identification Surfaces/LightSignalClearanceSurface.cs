using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Light Signal Clearance Surface</para>
	/// <para>Light Signal Clearance Surface</para>
	/// <para>Creates a Light Signal Clearance Surface (LSCS) based on the FAA Engineering Brief (EB) 95.</para>
	/// </summary>
	public class LightSignalClearanceSurface : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </param>
		/// <param name="Target">
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </param>
		public LightSignalClearanceSurface(object InFeatures, object Target)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
		}

		/// <summary>
		/// <para>Tool Display Name : Light Signal Clearance Surface</para>
		/// </summary>
		public override string DisplayName() => "Light Signal Clearance Surface";

		/// <summary>
		/// <para>Tool Name : LightSignalClearanceSurface</para>
		/// </summary>
		public override string ToolName() => "LightSignalClearanceSurface";

		/// <summary>
		/// <para>Tool Excute Name : aviation.LightSignalClearanceSurface</para>
		/// </summary>
		public override string ExcuteName() => "aviation.LightSignalClearanceSurface";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Target, RunwayDirection!, Length!, Divergence!, Slope!, DistanceFromThreshold!, FirstPapiLight!, LastPapiLight!, StartHeight!, DerivedOutfeatureclass!, AirportControlPointFeatureClass!, SurfacePosition! };

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object Target { get; set; }

		/// <summary>
		/// <para>Runway Direction</para>
		/// <para>Specifies the end of the runway where the approach surface will be created.</para>
		/// <para>High Runway End Designator— The approach surface will be created at the high end of the runway. This is the default.</para>
		/// <para>Low Runway End Designator—The approach surface will be created at the low end of the runway.</para>
		/// <para><see cref="RunwayDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RunwayDirection { get; set; } = "HIGH_RUNWAY_END_DESIGNATOR";

		/// <summary>
		/// <para>Length</para>
		/// <para>The length of the surface in miles. The default value is 8.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Length { get; set; } = "8";

		/// <summary>
		/// <para>Divergence</para>
		/// <para>The divergence of the surface in degrees. The default value is 14.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Divergence { get; set; } = "14";

		/// <summary>
		/// <para>Slope</para>
		/// <para>The slope of the surface in degrees. The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Slope { get; set; } = "1";

		/// <summary>
		/// <para>Distance From Threshold</para>
		/// <para>The distance from the threshold in feet. The default value is 1000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? DistanceFromThreshold { get; set; } = "1000";

		/// <summary>
		/// <para>First PAPI Light</para>
		/// <para>The location of the first precision approach path indicator. The default value is 60.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? FirstPapiLight { get; set; } = "60";

		/// <summary>
		/// <para>Last PAPI Light</para>
		/// <para>The location of the last precision approach path indicator. The default value is 120.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? LastPapiLight { get; set; } = "120";

		/// <summary>
		/// <para>Start Height</para>
		/// <para>The start height of the surface. The default value is 35.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? StartHeight { get; set; } = "35";

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? DerivedOutfeatureclass { get; set; }

		/// <summary>
		/// <para>Input Airport Control Point Feature</para>
		/// <para>Supplies x-, y-, and z-geometry for displaced threshold features. If displaced thresholds are included, surfaces will be constructed based on their x-, y-, and z-geometry instead of their corresponding runway feature endpoint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object? AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Surface Position</para>
		/// <para>Specifies the position of the precision approach path indicator (PAPI) lights on either side of a runway. The position of the PAPI lights will be used to determine the position of the output surface.</para>
		/// <para>Generate surface on left approach side of the runway—PAPI lights are on the left approach side of the runway. The surface will generate on the left approach side of the runway. This is the default.</para>
		/// <para>Generate surface on right approach side of the runway—PAPI lights are on the right approach side of the runway. The surface will generate on the right approach side of the runway.</para>
		/// <para><see cref="SurfacePositionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SurfacePosition { get; set; } = "SURFACE_GENERATED_ON_LEFT";

		#region InnerClass

		/// <summary>
		/// <para>Runway Direction</para>
		/// </summary>
		public enum RunwayDirectionEnum 
		{
			/// <summary>
			/// <para>High Runway End Designator— The approach surface will be created at the high end of the runway. This is the default.</para>
			/// </summary>
			[GPValue("HIGH_RUNWAY_END_DESIGNATOR")]
			[Description("High Runway End Designator")]
			High_Runway_End_Designator,

			/// <summary>
			/// <para>Low Runway End Designator—The approach surface will be created at the low end of the runway.</para>
			/// </summary>
			[GPValue("LOW_RUNWAY_END_DESIGNATOR")]
			[Description("Low Runway End Designator")]
			Low_Runway_End_Designator,

		}

		/// <summary>
		/// <para>Surface Position</para>
		/// </summary>
		public enum SurfacePositionEnum 
		{
			/// <summary>
			/// <para>Generate surface on left approach side of the runway—PAPI lights are on the left approach side of the runway. The surface will generate on the left approach side of the runway. This is the default.</para>
			/// </summary>
			[GPValue("SURFACE_GENERATED_ON_LEFT")]
			[Description("Generate surface on left approach side of the runway")]
			Generate_surface_on_left_approach_side_of_the_runway,

			/// <summary>
			/// <para>Generate surface on right approach side of the runway—PAPI lights are on the right approach side of the runway. The surface will generate on the right approach side of the runway.</para>
			/// </summary>
			[GPValue("SURFACE_GENERATED_ON_RIGHT")]
			[Description("Generate surface on right approach side of the runway")]
			Generate_surface_on_right_approach_side_of_the_runway,

		}

#endregion
	}
}
