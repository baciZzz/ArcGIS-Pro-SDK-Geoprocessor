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
	/// <para>FAA 13A Surfaces</para>
	/// <para>Creates obstruction identification surfaces (OIS) based on the FAA Advisory Circular 150/5300-13A specification. These primary and approach surfaces are designed to determine which objects are vertical obstructions and are used to support planning and design activities. The type, function, and dimension of a surface differ by its runway classification. This tool creates surfaces as a polygon or multipatch features.</para>
	/// </summary>
	public class FAA13ASurfaces : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </param>
		/// <param name="TargetOisFeatures">
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated OIS.</para>
		/// </param>
		/// <param name="HighRunwayEndType">
		/// <para>High Runway End Classification</para>
		/// <para>Specifies the classification of the high end of the runway.</para>
		/// <para>Small airplanes approach speeds less than 50 knots—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 254 pounds and approach speed less than 50 knots. This is a visual runway only that can be used during the day or night.</para>
		/// <para>Small airplanes approach speeds 50 knots or more—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 1,320 pounds and approach speed more than 50 knots. This is a visual runway only that can be used during the day or night.</para>
		/// <para>Large airplanes or instrument approach greater than or equal to 1 mile visibility— This runway classification is designed for aircraft with a maximum certified takeoff weight of more than 12,500 pounds. The approach end of the runway is expected to serve large airplanes as a visual runway available day or night, or instrument approach with a minimum greater than one statute mile (1.6 kilometers) only during the day.</para>
		/// <para>Instrument approach visibility greater than or equal to 3/4 mile and less than 1 mile— This runway classification is designed for an instrument approach procedure where the visibility is greater than (&gt;) three-fourths of a mile and less than one mile. The approach end of the runway is expected to accommodate instrument approaches with visible minimums more than three-fourths but less than 1 statute mile (1.2 &lt; 1.6 kilometers) during day or night.</para>
		/// <para>Precision or instrument approach less than 3/4 mile visibility— This runway classification&apos;s course and vertical path guidance are provided with visibility less than (&lt;) three-fourths of a mile. The approach end of the runway is expected to accommodate instrument approaches with visibility minimum less than three-fourths of a statute mile (1.2 kilometers) or precision approach (Instrument landing System [ILS] or Global Navigation Satellite System [GNSS] Landing System [GLS]) day or night.</para>
		/// <para>Vertical guidance approach— This runway classification uses precision guidance systems to support aircraft approach and landing. The approach of the runway is expected to accommodate approaches with vertical guidance such as a Glide Path Qualification Surface (GPQS).</para>
		/// <para><see cref="HighRunwayEndTypeEnum"/></para>
		/// </param>
		public FAA13ASurfaces(object InFeatures, object TargetOisFeatures, object HighRunwayEndType)
		{
			this.InFeatures = InFeatures;
			this.TargetOisFeatures = TargetOisFeatures;
			this.HighRunwayEndType = HighRunwayEndType;
		}

		/// <summary>
		/// <para>Tool Display Name : FAA 13A Surfaces</para>
		/// </summary>
		public override string DisplayName => "FAA 13A Surfaces";

		/// <summary>
		/// <para>Tool Name : FAA13ASurfaces</para>
		/// </summary>
		public override string ToolName => "FAA13ASurfaces";

		/// <summary>
		/// <para>Tool Excute Name : aviation.FAA13ASurfaces</para>
		/// </summary>
		public override string ExcuteName => "aviation.FAA13ASurfaces";

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
		public override object[] Parameters => new object[] { InFeatures, TargetOisFeatures, HighRunwayEndType, LowRunwayEndType!, GenerateDepartureSurfaces!, GenerateClearwaySurfaces!, ThresholdPointFeatureClass!, CustomJsonFile!, DerivedOutfeatureclass };

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>High Runway End Classification</para>
		/// <para>Specifies the classification of the high end of the runway.</para>
		/// <para>Small airplanes approach speeds less than 50 knots—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 254 pounds and approach speed less than 50 knots. This is a visual runway only that can be used during the day or night.</para>
		/// <para>Small airplanes approach speeds 50 knots or more—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 1,320 pounds and approach speed more than 50 knots. This is a visual runway only that can be used during the day or night.</para>
		/// <para>Large airplanes or instrument approach greater than or equal to 1 mile visibility— This runway classification is designed for aircraft with a maximum certified takeoff weight of more than 12,500 pounds. The approach end of the runway is expected to serve large airplanes as a visual runway available day or night, or instrument approach with a minimum greater than one statute mile (1.6 kilometers) only during the day.</para>
		/// <para>Instrument approach visibility greater than or equal to 3/4 mile and less than 1 mile— This runway classification is designed for an instrument approach procedure where the visibility is greater than (&gt;) three-fourths of a mile and less than one mile. The approach end of the runway is expected to accommodate instrument approaches with visible minimums more than three-fourths but less than 1 statute mile (1.2 &lt; 1.6 kilometers) during day or night.</para>
		/// <para>Precision or instrument approach less than 3/4 mile visibility— This runway classification&apos;s course and vertical path guidance are provided with visibility less than (&lt;) three-fourths of a mile. The approach end of the runway is expected to accommodate instrument approaches with visibility minimum less than three-fourths of a statute mile (1.2 kilometers) or precision approach (Instrument landing System [ILS] or Global Navigation Satellite System [GNSS] Landing System [GLS]) day or night.</para>
		/// <para>Vertical guidance approach— This runway classification uses precision guidance systems to support aircraft approach and landing. The approach of the runway is expected to accommodate approaches with vertical guidance such as a Glide Path Qualification Surface (GPQS).</para>
		/// <para><see cref="HighRunwayEndTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HighRunwayEndType { get; set; }

		/// <summary>
		/// <para>Low Runway End Classification</para>
		/// <para>Specifies the classification of the low end of the runway.</para>
		/// <para>The low runway end is the same as the high runway end classification—Same as high runway end classification</para>
		/// <para>Small airplanes approach speeds less than 50 knots—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 254 pounds and approach speed less than 50 knots. This is a visual runway only that can be used during the day or night.</para>
		/// <para>Small airplanes approach speeds 50 knots or more—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 1,320 pounds and approach speed more than 50 knots. This is a visual runway only that can be used during the day or night.</para>
		/// <para>Large airplanes or instrument approach greater than or equal to 1 mile visibility— This runway classification is designed for aircraft with a maximum certified takeoff weight of more than 12,500 pounds. The approach end of the runway is expected to serve large airplanes as a visual runway available day or night, or instrument approach with a minimum greater than one statute mile (1.6 kilometers) only during the day.</para>
		/// <para>Instrument approach visibility greater than or equal to 3/4 mile and less than 1 mile—This runway classification is designed for an instrument approach procedure where the visibility is greater than (&gt;) three-fourths of a mile and less than one mile. The approach end of the runway is expected to accommodate instrument approaches with visible minimums more than three-fourths but less than 1 statute mile (1.2 &lt; 1.6 kilometers) during day or night.</para>
		/// <para>Precision or instrument approach less than 3/4 mile visibility— This runway classification&apos;s course and vertical path guidance are provided with visibility less than (&lt;) three-fourths of a mile. The approach end of the runway is expected to accommodate instrument approaches with visibility minimum less than three-fourths of a statute mile (1.2 kilometers) or precision approach (Instrument landing System [ILS] or Global Navigation Satellite System [GNSS] Landing System [GLS]) day or night.</para>
		/// <para>Vertical guidance approach— This runway classification uses precision guidance systems to support aircraft approach and landing. The approach of the runway is expected to accommodate approaches with vertical guidance such as a Glide Path Qualification Surface (GPQS).</para>
		/// <para><see cref="LowRunwayEndTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LowRunwayEndType { get; set; } = "SAME_AS_HIGH_RUNWAY_END_CLASSIFICATION";

		/// <summary>
		/// <para>Generate Departure Surfaces</para>
		/// <para>Specifies whether a departure surface will be generated for departure runways.</para>
		/// <para>Generate Departure Surface at Both Ends—A departure surface will be generated at both ends of the runway.</para>
		/// <para>Generate Departure Surface at High End—A departure surface will be generated at the high end of the runway.</para>
		/// <para>Generate Departure Surface at Low End—A departure surface will be generated at the low end of the runway.</para>
		/// <para>Do Not Generate Departure Surface—A departure surface will not be generated.</para>
		/// <para><see cref="GenerateDepartureSurfacesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GenerateDepartureSurfaces { get; set; } = "GENERATE_DEPARTURE_SURFACE_AT_BOTH_ENDS";

		/// <summary>
		/// <para>Generate Clearway Surfaces</para>
		/// <para>Specifies whether a clearway surface will be generated for departure runways. Clearway surfaces will only be generated if an option has been specified for the Generate Departure Surfaces parameter.</para>
		/// <para>Checked—A clearway surface will be generated.</para>
		/// <para>Unchecked—A clearway surface will not be generated. This is the default.</para>
		/// <para><see cref="GenerateClearwaySurfacesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateClearwaySurfaces { get; set; } = "false";

		/// <summary>
		/// <para>Input Threshold Point Features</para>
		/// <para>The input threshold point dataset. The feature class must be z-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? ThresholdPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Custom JSON File</para>
		/// <para>The import configuration, in JSON format, that creates the custom OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? DerivedOutfeatureclass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FAA13ASurfaces SetEnviroment(object? workspace = null )
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
			/// <para>Small airplanes approach speeds less than 50 knots—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 254 pounds and approach speed less than 50 knots. This is a visual runway only that can be used during the day or night.</para>
			/// </summary>
			[GPValue("SMALL_AIRPLANE_APPROACH_SPEEDS_LT_50")]
			[Description("Small airplanes approach speeds less than 50 knots")]
			Small_airplanes_approach_speeds_less_than_50_knots,

			/// <summary>
			/// <para>Small airplanes approach speeds 50 knots or more—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 1,320 pounds and approach speed more than 50 knots. This is a visual runway only that can be used during the day or night.</para>
			/// </summary>
			[GPValue("SMALL_AIRPLANE_APPROACH_SPEEDS_GT_50")]
			[Description("Small airplanes approach speeds 50 knots or more")]
			Small_airplanes_approach_speeds_50_knots_or_more,

			/// <summary>
			/// <para>Large airplanes or instrument approach greater than or equal to 1 mile visibility— This runway classification is designed for aircraft with a maximum certified takeoff weight of more than 12,500 pounds. The approach end of the runway is expected to serve large airplanes as a visual runway available day or night, or instrument approach with a minimum greater than one statute mile (1.6 kilometers) only during the day.</para>
			/// </summary>
			[GPValue("LARGE_AIRPLANE_VISUAL_RUNWAY_DAY_NIGHT")]
			[Description("Large airplanes or instrument approach greater than or equal to 1 mile visibility")]
			Large_airplanes_or_instrument_approach_greater_than_or_equal_to_1_mile_visibility,

			/// <summary>
			/// <para>Instrument approach visibility greater than or equal to 3/4 mile and less than 1 mile— This runway classification is designed for an instrument approach procedure where the visibility is greater than (&gt;) three-fourths of a mile and less than one mile. The approach end of the runway is expected to accommodate instrument approaches with visible minimums more than three-fourths but less than 1 statute mile (1.2 &lt; 1.6 kilometers) during day or night.</para>
			/// </summary>
			[GPValue("INSTRUMENT_GT_EQ_3/4_MILE")]
			[Description("Instrument approach visibility greater than or equal to 3/4 mile and less than 1 mile")]
			INSTRUMENT_GT_EQ_3_4_MILE,

			/// <summary>
			/// <para>Precision or instrument approach less than 3/4 mile visibility— This runway classification&apos;s course and vertical path guidance are provided with visibility less than (&lt;) three-fourths of a mile. The approach end of the runway is expected to accommodate instrument approaches with visibility minimum less than three-fourths of a statute mile (1.2 kilometers) or precision approach (Instrument landing System [ILS] or Global Navigation Satellite System [GNSS] Landing System [GLS]) day or night.</para>
			/// </summary>
			[GPValue("INSTRUMENT_LT_3/4_MILE_VISIBILITY")]
			[Description("Precision or instrument approach less than 3/4 mile visibility")]
			INSTRUMENT_LT_3_4_MILE_VISIBILITY,

			/// <summary>
			/// <para>Vertical guidance approach— This runway classification uses precision guidance systems to support aircraft approach and landing. The approach of the runway is expected to accommodate approaches with vertical guidance such as a Glide Path Qualification Surface (GPQS).</para>
			/// </summary>
			[GPValue("VERTICAL_GUIDANCE_APPROACH")]
			[Description("Vertical guidance approach")]
			Vertical_guidance_approach,

		}

		/// <summary>
		/// <para>Low Runway End Classification</para>
		/// </summary>
		public enum LowRunwayEndTypeEnum 
		{
			/// <summary>
			/// <para>The low runway end is the same as the high runway end classification—Same as high runway end classification</para>
			/// </summary>
			[GPValue("SAME_AS_HIGH_RUNWAY_END_CLASSIFICATION")]
			[Description("The low runway end is the same as the high runway end classification")]
			The_low_runway_end_is_the_same_as_the_high_runway_end_classification,

			/// <summary>
			/// <para>Small airplanes approach speeds less than 50 knots—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 254 pounds and approach speed less than 50 knots. This is a visual runway only that can be used during the day or night.</para>
			/// </summary>
			[GPValue("SMALL_AIRPLANE_APPROACH_SPEEDS_LT_50")]
			[Description("Small airplanes approach speeds less than 50 knots")]
			Small_airplanes_approach_speeds_less_than_50_knots,

			/// <summary>
			/// <para>Small airplanes approach speeds 50 knots or more—This runway classification is designed for light aircraft with a maximum takeoff weight of less than 1,320 pounds and approach speed more than 50 knots. This is a visual runway only that can be used during the day or night.</para>
			/// </summary>
			[GPValue("SMALL_AIRPLANE_APPROACH_SPEEDS_GT_50")]
			[Description("Small airplanes approach speeds 50 knots or more")]
			Small_airplanes_approach_speeds_50_knots_or_more,

			/// <summary>
			/// <para>Large airplanes or instrument approach greater than or equal to 1 mile visibility— This runway classification is designed for aircraft with a maximum certified takeoff weight of more than 12,500 pounds. The approach end of the runway is expected to serve large airplanes as a visual runway available day or night, or instrument approach with a minimum greater than one statute mile (1.6 kilometers) only during the day.</para>
			/// </summary>
			[GPValue("LARGE_AIRPLANE_VISUAL_RUNWAY_DAY_NIGHT")]
			[Description("Large airplanes or instrument approach greater than or equal to 1 mile visibility")]
			Large_airplanes_or_instrument_approach_greater_than_or_equal_to_1_mile_visibility,

			/// <summary>
			/// <para>Instrument approach visibility greater than or equal to 3/4 mile and less than 1 mile—This runway classification is designed for an instrument approach procedure where the visibility is greater than (&gt;) three-fourths of a mile and less than one mile. The approach end of the runway is expected to accommodate instrument approaches with visible minimums more than three-fourths but less than 1 statute mile (1.2 &lt; 1.6 kilometers) during day or night.</para>
			/// </summary>
			[GPValue("INSTRUMENT_GT_EQ_3/4_MILE")]
			[Description("Instrument approach visibility greater than or equal to 3/4 mile and less than 1 mile")]
			INSTRUMENT_GT_EQ_3_4_MILE,

			/// <summary>
			/// <para>Precision or instrument approach less than 3/4 mile visibility— This runway classification&apos;s course and vertical path guidance are provided with visibility less than (&lt;) three-fourths of a mile. The approach end of the runway is expected to accommodate instrument approaches with visibility minimum less than three-fourths of a statute mile (1.2 kilometers) or precision approach (Instrument landing System [ILS] or Global Navigation Satellite System [GNSS] Landing System [GLS]) day or night.</para>
			/// </summary>
			[GPValue("INSTRUMENT_LT_3/4_MILE_VISIBILITY")]
			[Description("Precision or instrument approach less than 3/4 mile visibility")]
			INSTRUMENT_LT_3_4_MILE_VISIBILITY,

			/// <summary>
			/// <para>Vertical guidance approach— This runway classification uses precision guidance systems to support aircraft approach and landing. The approach of the runway is expected to accommodate approaches with vertical guidance such as a Glide Path Qualification Surface (GPQS).</para>
			/// </summary>
			[GPValue("VERTICAL_GUIDANCE_APPROACH")]
			[Description("Vertical guidance approach")]
			Vertical_guidance_approach,

		}

		/// <summary>
		/// <para>Generate Departure Surfaces</para>
		/// </summary>
		public enum GenerateDepartureSurfacesEnum 
		{
			/// <summary>
			/// <para>Generate Departure Surface at Both Ends—A departure surface will be generated at both ends of the runway.</para>
			/// </summary>
			[GPValue("GENERATE_DEPARTURE_SURFACE_AT_BOTH_ENDS")]
			[Description("Generate Departure Surface at Both Ends")]
			Generate_Departure_Surface_at_Both_Ends,

			/// <summary>
			/// <para>Generate Departure Surface at High End—A departure surface will be generated at the high end of the runway.</para>
			/// </summary>
			[GPValue("GENERATE_DEPARTURE_SURFACE_AT_HIGH_END")]
			[Description("Generate Departure Surface at High End")]
			Generate_Departure_Surface_at_High_End,

			/// <summary>
			/// <para>Generate Departure Surface at Low End—A departure surface will be generated at the low end of the runway.</para>
			/// </summary>
			[GPValue("GENERATE_DEPARTURE_SURFACE_AT_LOW_END")]
			[Description("Generate Departure Surface at Low End")]
			Generate_Departure_Surface_at_Low_End,

			/// <summary>
			/// <para>Do Not Generate Departure Surface—A departure surface will not be generated.</para>
			/// </summary>
			[GPValue("DO_NOT_GENERATE_DEPARTURE_SURFACE")]
			[Description("Do Not Generate Departure Surface")]
			Do_Not_Generate_Departure_Surface,

		}

		/// <summary>
		/// <para>Generate Clearway Surfaces</para>
		/// </summary>
		public enum GenerateClearwaySurfacesEnum 
		{
			/// <summary>
			/// <para>Checked—A clearway surface will be generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_CLEARWAY_SURFACES")]
			GENERATE_CLEARWAY_SURFACES,

			/// <summary>
			/// <para>Unchecked—A clearway surface will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_GENERATE_CLEARWAY_SURFACES")]
			NOT_GENERATE_CLEARWAY_SURFACES,

		}

#endregion
	}
}
