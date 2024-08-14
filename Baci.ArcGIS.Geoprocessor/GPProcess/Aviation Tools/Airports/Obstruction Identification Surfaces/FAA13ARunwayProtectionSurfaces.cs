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
	/// <para>FAA 13A Runway Protection Surfaces</para>
	/// <para>Generates runway protection surfaces based on FAA Advisory Circular 150/5300-13A.</para>
	/// </summary>
	public class FAA13ARunwayProtectionSurfaces : AbstractGPProcess
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
		/// <param name="SurfaceGeneration">
		/// <para>Surface Generation</para>
		/// <para>Specifies the type of surface that will be generated.</para>
		/// <para>Runway Safety Area—A runway safety area (RSA) will be generated.</para>
		/// <para>Runway Object Free Area—A runway object free area (ROFA) will be generated.</para>
		/// <para>Runway Obstacle Free Zone—A runway obstacle free zone (ROFZ) will be generated.</para>
		/// <para>Precision Obstacle Free Zone—A precision obstacle free zone (POFZ) will be generated.</para>
		/// <para>Approach Runway Protection Zone—An approach runway protection zone (RPZ) will be generated.</para>
		/// <para>Departure Runway Protection Zone—A departure runway protection zone (RPZ) will be generated.</para>
		/// <para><see cref="SurfaceGenerationEnum"/></para>
		/// </param>
		/// <param name="VisibilityMinimums">
		/// <para>Visibility Minimums</para>
		/// <para>Specifies the visibility minimums that will be used for the runways.</para>
		/// <para>Visual—Visual flight rules will be used.</para>
		/// <para>Not lower than 1 mile—Visibility minimums will not be lower than 1 mile.</para>
		/// <para>Not lower than 3/4 mile—Visibility minimums will not be lower that 3/4 mile.</para>
		/// <para>Lower than 3/4 mile—Visibility minimums will be lower than 3/4 mile.</para>
		/// <para><see cref="VisibilityMinimumsEnum"/></para>
		/// </param>
		/// <param name="ApproachCategory">
		/// <para>Approach Category</para>
		/// <para>Specifies the approach category that will be used to generate surfaces.</para>
		/// <para>A—The approach category A will be used.</para>
		/// <para>B—The approach category B will be used.</para>
		/// <para>C—The approach category C will be used.</para>
		/// <para>D—The approach category D will be used.</para>
		/// <para>E—The approach category E will be used.</para>
		/// <para><see cref="ApproachCategoryEnum"/></para>
		/// </param>
		/// <param name="ApproachDesignGroup">
		/// <para>Aircraft Design Group</para>
		/// <para>Specifies the approach design group that will be used to generate surfaces.</para>
		/// <para>I—The approach design group I will be used.</para>
		/// <para>II—The approach design group II will be used.</para>
		/// <para>III—The approach design group III will be used.</para>
		/// <para>IV—The approach design group IV will be used.</para>
		/// <para>V—The approach design group V will be used.</para>
		/// <para>VI—The approach design group VI will be used.</para>
		/// <para><see cref="ApproachDesignGroupEnum"/></para>
		/// </param>
		public FAA13ARunwayProtectionSurfaces(object InFeatures, object Target, object SurfaceGeneration, object VisibilityMinimums, object ApproachCategory, object ApproachDesignGroup)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
			this.SurfaceGeneration = SurfaceGeneration;
			this.VisibilityMinimums = VisibilityMinimums;
			this.ApproachCategory = ApproachCategory;
			this.ApproachDesignGroup = ApproachDesignGroup;
		}

		/// <summary>
		/// <para>Tool Display Name : FAA 13A Runway Protection Surfaces</para>
		/// </summary>
		public override string DisplayName => "FAA 13A Runway Protection Surfaces";

		/// <summary>
		/// <para>Tool Name : FAA13ARunwayProtectionSurfaces</para>
		/// </summary>
		public override string ToolName => "FAA13ARunwayProtectionSurfaces";

		/// <summary>
		/// <para>Tool Excute Name : aviation.FAA13ARunwayProtectionSurfaces</para>
		/// </summary>
		public override string ExcuteName => "aviation.FAA13ARunwayProtectionSurfaces";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, Target, SurfaceGeneration, VisibilityMinimums, ApproachCategory, ApproachDesignGroup, SmallAircraft!, ApproachGuidance!, RunwayDirection!, AirportElevation!, AirportControlPointFeatureClass!, RunwayEndFeatures!, LastLowLight!, LastHighLight!, CustomJsonFile!, DerivedOutfeatureclass };

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
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object Target { get; set; }

		/// <summary>
		/// <para>Surface Generation</para>
		/// <para>Specifies the type of surface that will be generated.</para>
		/// <para>Runway Safety Area—A runway safety area (RSA) will be generated.</para>
		/// <para>Runway Object Free Area—A runway object free area (ROFA) will be generated.</para>
		/// <para>Runway Obstacle Free Zone—A runway obstacle free zone (ROFZ) will be generated.</para>
		/// <para>Precision Obstacle Free Zone—A precision obstacle free zone (POFZ) will be generated.</para>
		/// <para>Approach Runway Protection Zone—An approach runway protection zone (RPZ) will be generated.</para>
		/// <para>Departure Runway Protection Zone—A departure runway protection zone (RPZ) will be generated.</para>
		/// <para><see cref="SurfaceGenerationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object SurfaceGeneration { get; set; }

		/// <summary>
		/// <para>Visibility Minimums</para>
		/// <para>Specifies the visibility minimums that will be used for the runways.</para>
		/// <para>Visual—Visual flight rules will be used.</para>
		/// <para>Not lower than 1 mile—Visibility minimums will not be lower than 1 mile.</para>
		/// <para>Not lower than 3/4 mile—Visibility minimums will not be lower that 3/4 mile.</para>
		/// <para>Lower than 3/4 mile—Visibility minimums will be lower than 3/4 mile.</para>
		/// <para><see cref="VisibilityMinimumsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object VisibilityMinimums { get; set; }

		/// <summary>
		/// <para>Approach Category</para>
		/// <para>Specifies the approach category that will be used to generate surfaces.</para>
		/// <para>A—The approach category A will be used.</para>
		/// <para>B—The approach category B will be used.</para>
		/// <para>C—The approach category C will be used.</para>
		/// <para>D—The approach category D will be used.</para>
		/// <para>E—The approach category E will be used.</para>
		/// <para><see cref="ApproachCategoryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ApproachCategory { get; set; }

		/// <summary>
		/// <para>Aircraft Design Group</para>
		/// <para>Specifies the approach design group that will be used to generate surfaces.</para>
		/// <para>I—The approach design group I will be used.</para>
		/// <para>II—The approach design group II will be used.</para>
		/// <para>III—The approach design group III will be used.</para>
		/// <para>IV—The approach design group IV will be used.</para>
		/// <para>V—The approach design group V will be used.</para>
		/// <para>VI—The approach design group VI will be used.</para>
		/// <para><see cref="ApproachDesignGroupEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ApproachDesignGroup { get; set; }

		/// <summary>
		/// <para>Small Aircraft</para>
		/// <para>Specifies whether surfaces will be generated with the small aircraft design matrix.This parameter only applies when the Approach Category parameter is set to A or B.</para>
		/// <para>Checked—Surfaces will be generated with the small aircraft design matrix.</para>
		/// <para>Unchecked—Surfaces will not be generated with the small aircraft design matrix. This is the default.</para>
		/// <para><see cref="SmallAircraftEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SmallAircraft { get; set; } = "false";

		/// <summary>
		/// <para>Approach Guidance</para>
		/// <para>Specifies the type of approach guidance that will be used at the end of the runway.</para>
		/// <para>Precision Category I—Precision Category I approach operations will be used for the runway.</para>
		/// <para>Precision Category II—Precision Category II approach operations will be used for the runway.</para>
		/// <para>Precision Category III A—Precision Category III A approach operations will be used for the runway.</para>
		/// <para>Precision Category III B—Precision Category III B approach operations will be used for the runway.</para>
		/// <para>Precision Category III C—Precision Category III C approach operations will be used for the runway.</para>
		/// <para>Precision Category III D—Precision Category III D approach operations will be used for the runway.</para>
		/// <para>Non-vertical—Nonvertical approach operations (nonprecision approach category) will be used for the runway.</para>
		/// <para>Vertical—Vertically guided approach operations will be used for the runway.</para>
		/// <para>Visual—Only visual approach operations will be used for the runway.</para>
		/// <para><see cref="ApproachGuidanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ApproachGuidance { get; set; }

		/// <summary>
		/// <para>Runway Direction</para>
		/// <para>Specifies the end of the runway where the approach surface will be created.</para>
		/// <para>High end to low end—The approach surface will be created from the high end of the runway to the low end. If a displaced threshold point exists at the high end of the runway, that point will be honored when creating the OIS.</para>
		/// <para>Low end to high end—The approach surface will be created from the low end of the runway to the high end. If a displaced threshold point exists at the low end of the runway, that point will be honored when creating the OIS.</para>
		/// <para>Both ends—The approach surface will be created from both the low end and high end of the runway.</para>
		/// <para><see cref="RunwayDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RunwayDirection { get; set; } = "HIGH_END_TO_LOW_END";

		/// <summary>
		/// <para>Airport Elevation</para>
		/// <para>The highest elevation on any of the runways of the airport. The value should be in the vertical coordinate system linear units of the target feature class. If no value is provided, the highest point from the Input Runway Features parameter value will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Airfield Information")]
		public object? AirportElevation { get; set; } = "0";

		/// <summary>
		/// <para>Input Airport Control Point Feature</para>
		/// <para>The point features containing an Airport Elevation parameter feature, displaced threshold features, or both. Values provided for the Airport Elevation parameter will take precedence over these point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[Category("Airfield Information")]
		public object? AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Runway End Features</para>
		/// <para>The input runway end point features associated with each runway. The corresponding field values in this layer will override the values specified in the Approach Category, Aircraft Design Group, and Approach Guidance parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[Category("Airfield Information")]
		public object? RunwayEndFeatures { get; set; }

		/// <summary>
		/// <para>Last Low End Approach Light</para>
		/// <para>The distance in feet of the Approach Lighting System (ALS) from the end of the low end of the runway. If no value is provided, it is assumed that there is no ALS at the low end of the runway.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Runway  Obstacle Free Zone Options")]
		public object? LastLowLight { get; set; } = "0";

		/// <summary>
		/// <para>Last High End Approach Light</para>
		/// <para>The distance in feet of the Approach Lighting System (ALS) from the end of the high end of the runway. If no value is provided, it is assumed that there is no ALS at the high end of the runway.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Runway  Obstacle Free Zone Options")]
		public object? LastHighLight { get; set; } = "0";

		/// <summary>
		/// <para>Custom JSON File</para>
		/// <para>The import configuration, in JSON format, that creates the custom OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[Category("Customize Surfaces")]
		public object? CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? DerivedOutfeatureclass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Surface Generation</para>
		/// </summary>
		public enum SurfaceGenerationEnum 
		{
			/// <summary>
			/// <para>Runway Safety Area—A runway safety area (RSA) will be generated.</para>
			/// </summary>
			[GPValue("RUNWAY_SAFETY_AREA")]
			[Description("Runway Safety Area")]
			Runway_Safety_Area,

			/// <summary>
			/// <para>Runway Object Free Area—A runway object free area (ROFA) will be generated.</para>
			/// </summary>
			[GPValue("RUNWAY_OBJECT_FREE_AREA")]
			[Description("Runway Object Free Area")]
			Runway_Object_Free_Area,

			/// <summary>
			/// <para>Runway Obstacle Free Zone—A runway obstacle free zone (ROFZ) will be generated.</para>
			/// </summary>
			[GPValue("RUNWAY_OBSTACLE_FREE_ZONE")]
			[Description("Runway Obstacle Free Zone")]
			Runway_Obstacle_Free_Zone,

			/// <summary>
			/// <para>Precision Obstacle Free Zone—A precision obstacle free zone (POFZ) will be generated.</para>
			/// </summary>
			[GPValue("PRECISION_OBSTACLE_FREE_ZONE")]
			[Description("Precision Obstacle Free Zone")]
			Precision_Obstacle_Free_Zone,

			/// <summary>
			/// <para>Approach Runway Protection Zone—An approach runway protection zone (RPZ) will be generated.</para>
			/// </summary>
			[GPValue("APPROACH_RUNWAY_PROTECTION_ZONE")]
			[Description("Approach Runway Protection Zone")]
			Approach_Runway_Protection_Zone,

			/// <summary>
			/// <para>Departure Runway Protection Zone—A departure runway protection zone (RPZ) will be generated.</para>
			/// </summary>
			[GPValue("DEPARTURE_RUNWAY_PROTECTION_ZONE")]
			[Description("Departure Runway Protection Zone")]
			Departure_Runway_Protection_Zone,

		}

		/// <summary>
		/// <para>Visibility Minimums</para>
		/// </summary>
		public enum VisibilityMinimumsEnum 
		{
			/// <summary>
			/// <para>Visual—Visual flight rules will be used.</para>
			/// </summary>
			[GPValue("VISUAL")]
			[Description("Visual")]
			Visual,

			/// <summary>
			/// <para>Not lower than 1 mile—Visibility minimums will not be lower than 1 mile.</para>
			/// </summary>
			[GPValue("NOT_LOWER_THAN_1_MILE")]
			[Description("Not lower than 1 mile")]
			Not_lower_than_1_mile,

			/// <summary>
			/// <para>Not lower than 3/4 mile—Visibility minimums will not be lower that 3/4 mile.</para>
			/// </summary>
			[GPValue("NOT_LOWER_THAN_3_4_MILE")]
			[Description("Not lower than 3/4 mile")]
			NOT_LOWER_THAN_3_4_MILE,

			/// <summary>
			/// <para>Lower than 3/4 mile—Visibility minimums will be lower than 3/4 mile.</para>
			/// </summary>
			[GPValue("LOWER_THAN_3_4_MILE")]
			[Description("Lower than 3/4 mile")]
			LOWER_THAN_3_4_MILE,

		}

		/// <summary>
		/// <para>Approach Category</para>
		/// </summary>
		public enum ApproachCategoryEnum 
		{
			/// <summary>
			/// <para>Approach Category</para>
			/// </summary>
			[GPValue("A")]
			[Description("A")]
			A,

			/// <summary>
			/// <para>B—The approach category B will be used.</para>
			/// </summary>
			[GPValue("B")]
			[Description("B")]
			B,

			/// <summary>
			/// <para>C—The approach category C will be used.</para>
			/// </summary>
			[GPValue("C")]
			[Description("C")]
			C,

			/// <summary>
			/// <para>D—The approach category D will be used.</para>
			/// </summary>
			[GPValue("D")]
			[Description("D")]
			D,

			/// <summary>
			/// <para>E—The approach category E will be used.</para>
			/// </summary>
			[GPValue("E")]
			[Description("E")]
			E,

		}

		/// <summary>
		/// <para>Aircraft Design Group</para>
		/// </summary>
		public enum ApproachDesignGroupEnum 
		{
			/// <summary>
			/// <para>I—The approach design group I will be used.</para>
			/// </summary>
			[GPValue("I")]
			[Description("I")]
			I,

			/// <summary>
			/// <para>II—The approach design group II will be used.</para>
			/// </summary>
			[GPValue("II")]
			[Description("II")]
			II,

			/// <summary>
			/// <para>III—The approach design group III will be used.</para>
			/// </summary>
			[GPValue("III")]
			[Description("III")]
			III,

			/// <summary>
			/// <para>IV—The approach design group IV will be used.</para>
			/// </summary>
			[GPValue("IV")]
			[Description("IV")]
			IV,

			/// <summary>
			/// <para>V—The approach design group V will be used.</para>
			/// </summary>
			[GPValue("V")]
			[Description("V")]
			V,

			/// <summary>
			/// <para>VI—The approach design group VI will be used.</para>
			/// </summary>
			[GPValue("VI")]
			[Description("VI")]
			VI,

		}

		/// <summary>
		/// <para>Small Aircraft</para>
		/// </summary>
		public enum SmallAircraftEnum 
		{
			/// <summary>
			/// <para>Checked—Surfaces will be generated with the small aircraft design matrix.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SMALL_AIRCRAFT")]
			SMALL_AIRCRAFT,

			/// <summary>
			/// <para>Unchecked—Surfaces will not be generated with the small aircraft design matrix. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_SMALL_AIRCRAFT")]
			NOT_SMALL_AIRCRAFT,

		}

		/// <summary>
		/// <para>Approach Guidance</para>
		/// </summary>
		public enum ApproachGuidanceEnum 
		{
			/// <summary>
			/// <para>Precision Category I—Precision Category I approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("PRECISION_CAT_I")]
			[Description("Precision Category I")]
			Precision_Category_I,

			/// <summary>
			/// <para>Precision Category II—Precision Category II approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("PRECISION_CAT_II")]
			[Description("Precision Category II")]
			Precision_Category_II,

			/// <summary>
			/// <para>Precision Category III A—Precision Category III A approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("PRECISION_CAT_IIIA")]
			[Description("Precision Category III A")]
			Precision_Category_III_A,

			/// <summary>
			/// <para>Precision Category III B—Precision Category III B approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("PRECISION_CAT_IIIB")]
			[Description("Precision Category III B")]
			Precision_Category_III_B,

			/// <summary>
			/// <para>Precision Category III C—Precision Category III C approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("PRECISION_CAT_IIIC")]
			[Description("Precision Category III C")]
			Precision_Category_III_C,

			/// <summary>
			/// <para>Precision Category III D—Precision Category III D approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("PRECISION_CAT_IIID")]
			[Description("Precision Category III D")]
			Precision_Category_III_D,

			/// <summary>
			/// <para>Non-vertical—Nonvertical approach operations (nonprecision approach category) will be used for the runway.</para>
			/// </summary>
			[GPValue("NON_VERTICAL")]
			[Description("Non-vertical")]
			NON_VERTICAL,

			/// <summary>
			/// <para>Vertical—Vertically guided approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("VERTICAL")]
			[Description("Vertical")]
			Vertical,

			/// <summary>
			/// <para>Visual—Only visual approach operations will be used for the runway.</para>
			/// </summary>
			[GPValue("VISUAL")]
			[Description("Visual")]
			Visual,

		}

		/// <summary>
		/// <para>Runway Direction</para>
		/// </summary>
		public enum RunwayDirectionEnum 
		{
			/// <summary>
			/// <para>High end to low end—The approach surface will be created from the high end of the runway to the low end. If a displaced threshold point exists at the high end of the runway, that point will be honored when creating the OIS.</para>
			/// </summary>
			[GPValue("HIGH_END_TO_LOW_END")]
			[Description("High end to low end")]
			High_end_to_low_end,

			/// <summary>
			/// <para>Low end to high end—The approach surface will be created from the low end of the runway to the high end. If a displaced threshold point exists at the low end of the runway, that point will be honored when creating the OIS.</para>
			/// </summary>
			[GPValue("LOW_END_TO_HIGH_END")]
			[Description("Low end to high end")]
			Low_end_to_high_end,

			/// <summary>
			/// <para>Both ends—The approach surface will be created from both the low end and high end of the runway.</para>
			/// </summary>
			[GPValue("BOTH_END")]
			[Description("Both ends")]
			Both_ends,

		}

#endregion
	}
}
