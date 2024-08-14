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
	/// <para>FAA 13A</para>
	/// <para>Creates obstruction identification surfaces (OIS) based on the FAA Advisory Circular 150/5300-13A specification. These approach and departure surfaces are designed to protect the use of the runway in both visual and instrument meteorological conditions near the airport and are used to support planning and design activities. The type, function, and dimension of a surface differ by its runway classification. This tool creates surfaces as a polygon or multipatch features.</para>
	/// </summary>
	[Obsolete()]
	public class FAA13A : AbstractGPProcess
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
		/// <para>The target feature class that will contain the generated OIS.</para>
		/// </param>
		/// <param name="RunwayType">
		/// <para>Runway Classification</para>
		/// <para>Specifies the classification of the runway.</para>
		/// <para>Small airplanes approach speeds less than 50 knots—Approach end of runways are expected to serve small airplanes with approach speeds less than 50 knots. This applies to visual runways only, day or night.</para>
		/// <para>Small airplanes approach speeds 50 knots or more—Approach end of runways are expected to serve small airplanes with approach speeds of 50 knots or more. This applies to visual runways only, day or night.</para>
		/// <para>Large airplanes for visual runways only, day or night—Approach end of runway are expected to serve large airplanes. This applies to visual runways only, day or night.</para>
		/// <para>Instrument approach visibility greater than or equal to 3/4 mile— Approach end of runways are expected to accommodate instrument approaches having visibility greater than or equal to 3/4 statute mile.</para>
		/// <para>Instrument approach less than 3/4 mile visibility—Approach end of runways are expected to accommodate instrument approaches having visibility minimums less than 3/4 statute mile.</para>
		/// <para>Vertical guidance approach—Approach end of runways are expected to accommodate instrument approaches with vertical guidance.</para>
		/// <para>Departure— Departure runway ends are used for any instrument operations.</para>
		/// <para><see cref="RunwayTypeEnum"/></para>
		/// </param>
		public FAA13A(object InFeatures, object Target, object RunwayType)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
			this.RunwayType = RunwayType;
		}

		/// <summary>
		/// <para>Tool Display Name : FAA 13A</para>
		/// </summary>
		public override string DisplayName => "FAA 13A";

		/// <summary>
		/// <para>Tool Name : FAA13A</para>
		/// </summary>
		public override string ToolName => "FAA13A";

		/// <summary>
		/// <para>Tool Excute Name : aviation.FAA13A</para>
		/// </summary>
		public override string ExcuteName => "aviation.FAA13A";

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
		public override object[] Parameters => new object[] { InFeatures, Target, RunwayType, HighendClearWayLength!, LowendClearWayLength!, DerivedOutfeatureclass!, CustomJsonFile!, GenerateClearwaySurface!, AirportControlPointFeatureClass! };

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
		public object Target { get; set; }

		/// <summary>
		/// <para>Runway Classification</para>
		/// <para>Specifies the classification of the runway.</para>
		/// <para>Small airplanes approach speeds less than 50 knots—Approach end of runways are expected to serve small airplanes with approach speeds less than 50 knots. This applies to visual runways only, day or night.</para>
		/// <para>Small airplanes approach speeds 50 knots or more—Approach end of runways are expected to serve small airplanes with approach speeds of 50 knots or more. This applies to visual runways only, day or night.</para>
		/// <para>Large airplanes for visual runways only, day or night—Approach end of runway are expected to serve large airplanes. This applies to visual runways only, day or night.</para>
		/// <para>Instrument approach visibility greater than or equal to 3/4 mile— Approach end of runways are expected to accommodate instrument approaches having visibility greater than or equal to 3/4 statute mile.</para>
		/// <para>Instrument approach less than 3/4 mile visibility—Approach end of runways are expected to accommodate instrument approaches having visibility minimums less than 3/4 statute mile.</para>
		/// <para>Vertical guidance approach—Approach end of runways are expected to accommodate instrument approaches with vertical guidance.</para>
		/// <para>Departure— Departure runway ends are used for any instrument operations.</para>
		/// <para><see cref="RunwayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RunwayType { get; set; }

		/// <summary>
		/// <para>Length of High Runway End Clearway</para>
		/// <para>This parameter is no longer supported. It is still included in the tool's syntax for compatibility in scripts and models but is hidden on the tool dialog box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? HighendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Length of Low Runway End Clearway</para>
		/// <para>This parameter is no longer supported. It is still included in the tool's syntax for compatibility in scripts and models but is hidden on the tool dialog box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? LowendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? DerivedOutfeatureclass { get; set; }

		/// <summary>
		/// <para>Custom JSON File</para>
		/// <para>The import configuration, in JSON format, that creates the custom OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Generate Clearway</para>
		/// <para>Specifies whether a clearway surface will be generated for departure runways.</para>
		/// <para>Checked—A clearway surface will be generated.</para>
		/// <para>Unchecked—A clearway surface will not be generated. This is the default.</para>
		/// <para><see cref="GenerateClearwaySurfaceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateClearwaySurface { get; set; } = "false";

		/// <summary>
		/// <para>Input Airport Control Point Feature</para>
		/// <para>Supplies x-, y-, and z-geometry for displaced threshold features. If displaced thresholds are included, surfaces will be constructed based on their x-, y-, and z-geometry instead of their corresponding runway feature endpoint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FAA13A SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Runway Classification</para>
		/// </summary>
		public enum RunwayTypeEnum 
		{
			/// <summary>
			/// <para>Small airplanes approach speeds less than 50 knots—Approach end of runways are expected to serve small airplanes with approach speeds less than 50 knots. This applies to visual runways only, day or night.</para>
			/// </summary>
			[GPValue("SMALL_AIRPLANE_APPROACH_SPEEDS_LT_50")]
			[Description("Small airplanes approach speeds less than 50 knots")]
			Small_airplanes_approach_speeds_less_than_50_knots,

			/// <summary>
			/// <para>Small airplanes approach speeds 50 knots or more—Approach end of runways are expected to serve small airplanes with approach speeds of 50 knots or more. This applies to visual runways only, day or night.</para>
			/// </summary>
			[GPValue("SMALL_AIRPLANE_APPROACH_SPEEDS_GT_50")]
			[Description("Small airplanes approach speeds 50 knots or more")]
			Small_airplanes_approach_speeds_50_knots_or_more,

			/// <summary>
			/// <para>Large airplanes for visual runways only, day or night—Approach end of runway are expected to serve large airplanes. This applies to visual runways only, day or night.</para>
			/// </summary>
			[GPValue("LARGE_AIRPLANE_VISUAL_RUNWAY_DAY_NIGHT")]
			[Description("Large airplanes for visual runways only, day or night")]
			LARGE_AIRPLANE_VISUAL_RUNWAY_DAY_NIGHT,

			/// <summary>
			/// <para>Instrument approach visibility greater than or equal to 3/4 mile— Approach end of runways are expected to accommodate instrument approaches having visibility greater than or equal to 3/4 statute mile.</para>
			/// </summary>
			[GPValue("INSTRUMENT_GT_EQ_3/4_MILE")]
			[Description("Instrument approach visibility greater than or equal to 3/4 mile")]
			INSTRUMENT_GT_EQ_3_4_MILE,

			/// <summary>
			/// <para>Instrument approach less than 3/4 mile visibility—Approach end of runways are expected to accommodate instrument approaches having visibility minimums less than 3/4 statute mile.</para>
			/// </summary>
			[GPValue("INSTRUMENT_LT_3/4_MILE_VISIBILITY")]
			[Description("Instrument approach less than 3/4 mile visibility")]
			INSTRUMENT_LT_3_4_MILE_VISIBILITY,

			/// <summary>
			/// <para>Vertical guidance approach—Approach end of runways are expected to accommodate instrument approaches with vertical guidance.</para>
			/// </summary>
			[GPValue("VERTICAL_GUIDANCE_APPROACH")]
			[Description("Vertical guidance approach")]
			Vertical_guidance_approach,

			/// <summary>
			/// <para>Departure— Departure runway ends are used for any instrument operations.</para>
			/// </summary>
			[GPValue("DEPARTURE")]
			[Description("Departure")]
			Departure,

		}

		/// <summary>
		/// <para>Generate Clearway</para>
		/// </summary>
		public enum GenerateClearwaySurfaceEnum 
		{
			/// <summary>
			/// <para>Checked—A clearway surface will be generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_CLEARWAY_SURFACE")]
			GENERATE_CLEARWAY_SURFACE,

			/// <summary>
			/// <para>Unchecked—A clearway surface will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_GENERATE_CLEARWAY_SURFACE")]
			NOT_GENERATE_CLEARWAY_SURFACE,

		}

#endregion
	}
}
