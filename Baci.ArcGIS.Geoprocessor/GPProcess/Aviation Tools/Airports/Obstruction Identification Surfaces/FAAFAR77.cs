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
	/// <para>FAA FAR 77</para>
	/// <para>Creates obstruction identification surfaces (OIS) based on the FAA Part 77 specification. This regulation establishes standards and notification requirements for objects affecting navigable airspace. The type, function, and dimension of a surface differ by its runway classification. This tool creates surfaces as a polygon or multipatch features.</para>
	/// </summary>
	public class FAAFAR77 : AbstractGPProcess
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
		/// <param name="HighRunwayEndType">
		/// <para>High Runway End Classification</para>
		/// <para>Specifies the classification of the high end of the runway.</para>
		/// <para>Construction or alteration on an airport with longest runway more than 3200 feet—Construction on or alteration to a runway longer than 3,200 feet with an imaginary surface that extends outward 20,000 feet and has a slope that does not exceed 100 to 1.</para>
		/// <para>Construction or alteration on an airport with longest runway less than 3200 feet—Construction on or alteration to a runway less than 3,200 feet long with an imaginary surface that extends outward 10,000 feet and has a slope that does not exceed 50 to 1.</para>
		/// <para>Construction or alteration on a heliport—Construction on or alteration to a heliport landing and takeoff area with an imaginary surface that extends outward 5,000 feet and has a slope that does not exceed 25 to 1.</para>
		/// <para>Military airport—Military airport runways are operated by an armed force of the United States. Primary surfaces are the same length as the runway. Primary surface width is 2,000 feet. Clear zone surface length is 1,000 feet, and width is the same as the primary surface. The approach clearance surface starts 200 feet beyond each end of the primary surface and extends for 50,000 feet. Approach surface width matches the primary surface width at the runway end but flares to a width of 16,000 feet at an elevation of 50,000 feet. Approach clearance surface slope is 50 to 1 to an elevation of 500 feet above airport elevation. It then rises horizontally to 50,000 feet. Transitional surface slope is 7 to 1 outward and upward at right angles to the runway centerline. See section 77.28 in the FAR Part 77 specification for more information.</para>
		/// <para>Non precision instrument runway greater than (&gt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions greater than three-quarters of a mile.</para>
		/// <para>Non precision instrument runway less than (&lt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions less than three-quarters of a mile.</para>
		/// <para>Precision instrument runway—A runway that uses Instrument Landing System (ILS) or Precision Approach Radar (PAR) for approach procedures.</para>
		/// <para>Utility runway visual approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. Aircraft using the runway employ visual approach procedures.</para>
		/// <para>Utility runway non precision instrument approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. The runway has an instrument approach procedure that uses air navigation facilities with horizontal guidance. It can also have area-type navigation equipment with approved nonprecision instrument approach procedures.</para>
		/// <para>Visual runway visual approach—A runway that supports only visual approach procedures.</para>
		/// <para><see cref="HighRunwayEndTypeEnum"/></para>
		/// </param>
		/// <param name="LowRunwayEndType">
		/// <para>Low Runway End Classification</para>
		/// <para>Specifies the classification of the low end of the runway.</para>
		/// <para>Same as high runway end classification—No low runway end type.</para>
		/// <para>Non precision instrument runway greater than (&gt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions greater than three-quarters of a mile.</para>
		/// <para>Non precision instrument runway less than (&lt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions less than three-quarters of a mile.</para>
		/// <para>Precision instrument runway—A runway that uses Instrument Landing System (ILS) or Precision Approach Radar (PAR) for approach procedures.</para>
		/// <para>Utility runway visual approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. Aircraft using the runway employ visual approach procedures.</para>
		/// <para>Utility runway non precision instrument approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. The runway has an instrument approach procedure that uses air navigation facilities with horizontal guidance. It can also have area-type navigation equipment with approved nonprecision instrument approach procedures.</para>
		/// <para>Visual runway visual approach—A runway that supports only visual approach procedures.</para>
		/// <para><see cref="LowRunwayEndTypeEnum"/></para>
		/// </param>
		public FAAFAR77(object InFeatures, object Target, object HighRunwayEndType, object LowRunwayEndType)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
			this.HighRunwayEndType = HighRunwayEndType;
			this.LowRunwayEndType = LowRunwayEndType;
		}

		/// <summary>
		/// <para>Tool Display Name : FAA FAR 77</para>
		/// </summary>
		public override string DisplayName => "FAA FAR 77";

		/// <summary>
		/// <para>Tool Name : FAAFAR77</para>
		/// </summary>
		public override string ToolName => "FAAFAR77";

		/// <summary>
		/// <para>Tool Excute Name : aviation.FAAFAR77</para>
		/// </summary>
		public override string ExcuteName => "aviation.FAAFAR77";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, Target, HighRunwayEndType, LowRunwayEndType, SpeciallyPreparedHardSurfaceRunway, HighendClearWayLength, LowendClearWayLength, AirportElevation, IncludeMergedSurface, DerivedOutfeatureclass, CustomJsonFile, AirportControlPointFeatureClass };

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
		/// <para>High Runway End Classification</para>
		/// <para>Specifies the classification of the high end of the runway.</para>
		/// <para>Construction or alteration on an airport with longest runway more than 3200 feet—Construction on or alteration to a runway longer than 3,200 feet with an imaginary surface that extends outward 20,000 feet and has a slope that does not exceed 100 to 1.</para>
		/// <para>Construction or alteration on an airport with longest runway less than 3200 feet—Construction on or alteration to a runway less than 3,200 feet long with an imaginary surface that extends outward 10,000 feet and has a slope that does not exceed 50 to 1.</para>
		/// <para>Construction or alteration on a heliport—Construction on or alteration to a heliport landing and takeoff area with an imaginary surface that extends outward 5,000 feet and has a slope that does not exceed 25 to 1.</para>
		/// <para>Military airport—Military airport runways are operated by an armed force of the United States. Primary surfaces are the same length as the runway. Primary surface width is 2,000 feet. Clear zone surface length is 1,000 feet, and width is the same as the primary surface. The approach clearance surface starts 200 feet beyond each end of the primary surface and extends for 50,000 feet. Approach surface width matches the primary surface width at the runway end but flares to a width of 16,000 feet at an elevation of 50,000 feet. Approach clearance surface slope is 50 to 1 to an elevation of 500 feet above airport elevation. It then rises horizontally to 50,000 feet. Transitional surface slope is 7 to 1 outward and upward at right angles to the runway centerline. See section 77.28 in the FAR Part 77 specification for more information.</para>
		/// <para>Non precision instrument runway greater than (&gt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions greater than three-quarters of a mile.</para>
		/// <para>Non precision instrument runway less than (&lt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions less than three-quarters of a mile.</para>
		/// <para>Precision instrument runway—A runway that uses Instrument Landing System (ILS) or Precision Approach Radar (PAR) for approach procedures.</para>
		/// <para>Utility runway visual approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. Aircraft using the runway employ visual approach procedures.</para>
		/// <para>Utility runway non precision instrument approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. The runway has an instrument approach procedure that uses air navigation facilities with horizontal guidance. It can also have area-type navigation equipment with approved nonprecision instrument approach procedures.</para>
		/// <para>Visual runway visual approach—A runway that supports only visual approach procedures.</para>
		/// <para><see cref="HighRunwayEndTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HighRunwayEndType { get; set; }

		/// <summary>
		/// <para>Low Runway End Classification</para>
		/// <para>Specifies the classification of the low end of the runway.</para>
		/// <para>Same as high runway end classification—No low runway end type.</para>
		/// <para>Non precision instrument runway greater than (&gt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions greater than three-quarters of a mile.</para>
		/// <para>Non precision instrument runway less than (&lt;) 3/4 mile visibility—A runway with a nonprecision instrument approach procedure that allows for landing in visibility conditions less than three-quarters of a mile.</para>
		/// <para>Precision instrument runway—A runway that uses Instrument Landing System (ILS) or Precision Approach Radar (PAR) for approach procedures.</para>
		/// <para>Utility runway visual approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. Aircraft using the runway employ visual approach procedures.</para>
		/// <para>Utility runway non precision instrument approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. The runway has an instrument approach procedure that uses air navigation facilities with horizontal guidance. It can also have area-type navigation equipment with approved nonprecision instrument approach procedures.</para>
		/// <para>Visual runway visual approach—A runway that supports only visual approach procedures.</para>
		/// <para><see cref="LowRunwayEndTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LowRunwayEndType { get; set; } = "SAME_AS_HIGH_RUNWAY_END_CLASSIFICATION";

		/// <summary>
		/// <para>Specially Prepared Hard Surface Runway</para>
		/// <para>Specifies whether the runway has a specially prepared hard surface. A specially prepared hard surface indicates that the primary surface extends 200 feet beyond each end of the runway.</para>
		/// <para>Checked—The runway has a specially prepared hard surface. This is the default.</para>
		/// <para>Unchecked—The runway does not have a specially prepared hard surface.</para>
		/// <para><see cref="SpeciallyPreparedHardSurfaceRunwayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SpeciallyPreparedHardSurfaceRunway { get; set; } = "true";

		/// <summary>
		/// <para>Length of High Runway End Clearway</para>
		/// <para>The length of the area at the high end of the runway. The unit of measurement is based on the input runway features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object HighendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Length of Low Runway End Clearway</para>
		/// <para>The length of the area at the low end of the runway. The unit of measurement is based on the input runway features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object LowendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Airport Elevation</para>
		/// <para>The highest elevation on any of the runways of the airport. The value should be in the vertical coordinate system linear units of the target feature class. If no value is provided, the highest point from the Input Runway Features parameter value will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AirportElevation { get; set; } = "0";

		/// <summary>
		/// <para>Include Merged Surfaces</para>
		/// <para>Specifies whether merged horizontal and conical surfaces are included in the OIS in addition to the regular surfaces.</para>
		/// <para>Checked—Merged surfaces are included in the OIS output. This is the default.</para>
		/// <para>Unchecked—Merged surfaces are not included in the OIS output.</para>
		/// <para><see cref="IncludeMergedSurfaceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeMergedSurface { get; set; } = "true";

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object DerivedOutfeatureclass { get; set; }

		/// <summary>
		/// <para>Custom JSON File</para>
		/// <para>The import configuration, in JSON format, that creates the custom OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Input Airport Control Point Feature</para>
		/// <para>The point features containing an Airport Elevation feature, displaced threshold features, or both. Values provided for the Airport Elevation parameter will take precedence over these point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FAAFAR77 SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>High Runway End Classification</para>
		/// </summary>
		public enum HighRunwayEndTypeEnum 
		{
			/// <summary>
			/// <para>Construction or alteration on an airport with longest runway more than 3200 feet—Construction on or alteration to a runway longer than 3,200 feet with an imaginary surface that extends outward 20,000 feet and has a slope that does not exceed 100 to 1.</para>
			/// </summary>
			[GPValue("CONSTRUCTION_OR_ALTERATION_ON_AN_AIRPORT_WITH_LONGEST_RUNWAY_MORE_THAN_3200_FEET")]
			[Description("Construction or alteration on an airport with longest runway more than 3200 feet")]
			Construction_or_alteration_on_an_airport_with_longest_runway_more_than_3200_feet,

			/// <summary>
			/// <para>Construction or alteration on an airport with longest runway less than 3200 feet—Construction on or alteration to a runway less than 3,200 feet long with an imaginary surface that extends outward 10,000 feet and has a slope that does not exceed 50 to 1.</para>
			/// </summary>
			[GPValue("CONSTRUCTION_OR_ALTERATION_ON_AN_AIRPORT_WITH_LONGEST_RUNWAY_LESS_THAN_3200_FEET")]
			[Description("Construction or alteration on an airport with longest runway less than 3200 feet")]
			Construction_or_alteration_on_an_airport_with_longest_runway_less_than_3200_feet,

			/// <summary>
			/// <para>Construction or alteration on a heliport—Construction on or alteration to a heliport landing and takeoff area with an imaginary surface that extends outward 5,000 feet and has a slope that does not exceed 25 to 1.</para>
			/// </summary>
			[GPValue("CONSTRUCTION_OR_ALTERATION_ON_A_HELIPORT")]
			[Description("Construction or alteration on a heliport")]
			Construction_or_alteration_on_a_heliport,

			/// <summary>
			/// <para>Military airport—Military airport runways are operated by an armed force of the United States. Primary surfaces are the same length as the runway. Primary surface width is 2,000 feet. Clear zone surface length is 1,000 feet, and width is the same as the primary surface. The approach clearance surface starts 200 feet beyond each end of the primary surface and extends for 50,000 feet. Approach surface width matches the primary surface width at the runway end but flares to a width of 16,000 feet at an elevation of 50,000 feet. Approach clearance surface slope is 50 to 1 to an elevation of 500 feet above airport elevation. It then rises horizontally to 50,000 feet. Transitional surface slope is 7 to 1 outward and upward at right angles to the runway centerline. See section 77.28 in the FAR Part 77 specification for more information.</para>
			/// </summary>
			[GPValue("MILITARY_AIRPORT")]
			[Description("Military airport")]
			Military_airport,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NONPRECISION_INSTRUMENT_RUNWAY_GREATER_THAN_(>)_3/4_MILE_VISIBILITY")]
			[Description("Non precision instrument runway greater than (>) 3/4 mile visibility")]
			NONPRECISION_INSTRUMENT_RUNWAY_GREATER_THAN__3_4_MILE_VISIBILITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NONPRECISION_INSTRUMENT_RUNWAY_LESS_THAN_(<)_3/4_MILE_VISIBILITY")]
			[Description("Non precision instrument runway less than (<) 3/4 mile visibility")]
			NONPRECISION_INSTRUMENT_RUNWAY_LESS_THAN__3_4_MILE_VISIBILITY,

			/// <summary>
			/// <para>Precision instrument runway—A runway that uses Instrument Landing System (ILS) or Precision Approach Radar (PAR) for approach procedures.</para>
			/// </summary>
			[GPValue("PRECISION_INSTRUMENT_RUNWAY")]
			[Description("Precision instrument runway")]
			Precision_instrument_runway,

			/// <summary>
			/// <para>Utility runway visual approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. Aircraft using the runway employ visual approach procedures.</para>
			/// </summary>
			[GPValue("UTILITY_RUNWAY_VISUAL_APPROACH")]
			[Description("Utility runway visual approach")]
			Utility_runway_visual_approach,

			/// <summary>
			/// <para>Utility runway non precision instrument approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. The runway has an instrument approach procedure that uses air navigation facilities with horizontal guidance. It can also have area-type navigation equipment with approved nonprecision instrument approach procedures.</para>
			/// </summary>
			[GPValue("UTILITY_RUNWAY_NON_PRECISION_INSTRUMENT_APPROACH")]
			[Description("Utility runway non precision instrument approach")]
			Utility_runway_non_precision_instrument_approach,

			/// <summary>
			/// <para>Visual runway visual approach—A runway that supports only visual approach procedures.</para>
			/// </summary>
			[GPValue("VISUAL_RUNWAY_VISUAL_APPROACH")]
			[Description("Visual runway visual approach")]
			Visual_runway_visual_approach,

		}

		/// <summary>
		/// <para>Low Runway End Classification</para>
		/// </summary>
		public enum LowRunwayEndTypeEnum 
		{
			/// <summary>
			/// <para>Same as high runway end classification—No low runway end type.</para>
			/// </summary>
			[GPValue("SAME_AS_HIGH_RUNWAY_END_CLASSIFICATION")]
			[Description("Same as high runway end classification")]
			Same_as_high_runway_end_classification,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NONPRECISION_INSTRUMENT_RUNWAY_GREATER_THAN_(>)_3/4_MILE_VISIBILITY")]
			[Description("Non precision instrument runway greater than (>) 3/4 mile visibility")]
			NONPRECISION_INSTRUMENT_RUNWAY_GREATER_THAN__3_4_MILE_VISIBILITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NONPRECISION_INSTRUMENT_RUNWAY_LESS_THAN_(<)_3/4_MILE_VISIBILITY")]
			[Description("Non precision instrument runway less than (<) 3/4 mile visibility")]
			NONPRECISION_INSTRUMENT_RUNWAY_LESS_THAN__3_4_MILE_VISIBILITY,

			/// <summary>
			/// <para>Precision instrument runway—A runway that uses Instrument Landing System (ILS) or Precision Approach Radar (PAR) for approach procedures.</para>
			/// </summary>
			[GPValue("PRECISION_INSTRUMENT_RUNWAY")]
			[Description("Precision instrument runway")]
			Precision_instrument_runway,

			/// <summary>
			/// <para>Utility runway visual approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. Aircraft using the runway employ visual approach procedures.</para>
			/// </summary>
			[GPValue("UTILITY_RUNWAY_VISUAL_APPROACH")]
			[Description("Utility runway visual approach")]
			Utility_runway_visual_approach,

			/// <summary>
			/// <para>Utility runway non precision instrument approach—A runway built for propeller aircraft not exceeding 12,500 pounds gross weight. The runway has an instrument approach procedure that uses air navigation facilities with horizontal guidance. It can also have area-type navigation equipment with approved nonprecision instrument approach procedures.</para>
			/// </summary>
			[GPValue("UTILITY_RUNWAY_NON_PRECISION_INSTRUMENT_APPROACH")]
			[Description("Utility runway non precision instrument approach")]
			Utility_runway_non_precision_instrument_approach,

			/// <summary>
			/// <para>Visual runway visual approach—A runway that supports only visual approach procedures.</para>
			/// </summary>
			[GPValue("VISUAL_RUNWAY_VISUAL_APPROACH")]
			[Description("Visual runway visual approach")]
			Visual_runway_visual_approach,

		}

		/// <summary>
		/// <para>Specially Prepared Hard Surface Runway</para>
		/// </summary>
		public enum SpeciallyPreparedHardSurfaceRunwayEnum 
		{
			/// <summary>
			/// <para>Checked—The runway has a specially prepared hard surface. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SPECIALLY_PREPARED_HARD_SURFACE_RUNWAY")]
			SPECIALLY_PREPARED_HARD_SURFACE_RUNWAY,

			/// <summary>
			/// <para>Unchecked—The runway does not have a specially prepared hard surface.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_SPECIALLY_PREPARED_HARD_SURFACE_RUNWAY")]
			NON_SPECIALLY_PREPARED_HARD_SURFACE_RUNWAY,

		}

		/// <summary>
		/// <para>Include Merged Surfaces</para>
		/// </summary>
		public enum IncludeMergedSurfaceEnum 
		{
			/// <summary>
			/// <para>Checked—Merged surfaces are included in the OIS output. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_MERGED_SURFACE")]
			INCLUDE_MERGED_SURFACE,

			/// <summary>
			/// <para>Unchecked—Merged surfaces are not included in the OIS output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INCLUDE_MERGED_SURFACE")]
			NOT_INCLUDE_MERGED_SURFACE,

		}

#endregion
	}
}
