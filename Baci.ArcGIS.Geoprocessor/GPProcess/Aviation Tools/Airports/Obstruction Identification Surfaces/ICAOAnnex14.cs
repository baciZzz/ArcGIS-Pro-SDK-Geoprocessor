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
	/// <para>ICAO Annex 14</para>
	/// <para>Creates obstruction identification surfaces (OIS) based on ICAO Annex 14 specifications. These surfaces define the airspace around aerodromes to be free of obstacles so flight operations can be performed safely. This tool creates surfaces as a polygon or multipatch features.</para>
	/// </summary>
	public class ICAOAnnex14 : AbstractGPProcess
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
		/// <para>The output feature class that will contain the generated obstruction identification surfaces.</para>
		/// </param>
		/// <param name="RunwayType">
		/// <para>Runway Classification</para>
		/// <para>Specifies the runway classification of the Input Runway Features parameter.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_1—A runway intended for the operation of aircraft using visual approach procedures. Runway strip length is 30 meters.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_2—A runway with a 60-meter strip length and 40-meter strip width that is intended for the operation of aircraft using visual approach procedures.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_3—A runway with a 60-meter strip length and 75-meter strip width that is intended for the operation of aircraft using visual approach procedures.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_4—A runway with a 60-meter strip length and 75-meter strip width that is intended for the operation of aircraft using visual approach procedures.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_1—An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_2—An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_3 —An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_4—An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_I_CODE_NUMBER_1—An instrument runway served by an Instrument Landing System (ILS) or a Microwave Landing System (MLS) and visual aids intended for operations with a decision height not lower than 60 meters (200 feet) and either a visibility not less than 800 meters or a runway visual range not less than 550 meters. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_I_CODE_NUMBER_2—An instrument runway served by ILS and MLS and visual aids intended for operations with a decision height not lower than 60 meters (200 feet) and either a visibility not less than 800 meters or a runway visual range not less than 550 meters. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_I_CODE_NUMBER_3_4—An instrument runway served by ILS and MLS and visual aids intended for operations with a decision height not lower than 60 meters (200 feet) and either a visibility not less than 800 meters or a runway visual range not less than 550 meters. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_II_III_CODE_NUMBER_3_4—An instrument runway served by ILS and MLS and visual aids intended for operations with a decision height lower than 60 meters (200 feet) but not lower than 30 meters (100 feet) and a runway visual range not less than 350 meters. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// </param>
		public ICAOAnnex14(object InFeatures, object Target, object RunwayType)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
			this.RunwayType = RunwayType;
		}

		/// <summary>
		/// <para>Tool Display Name : ICAO Annex 14</para>
		/// </summary>
		public override string DisplayName => "ICAO Annex 14";

		/// <summary>
		/// <para>Tool Name : ICAOAnnex14</para>
		/// </summary>
		public override string ToolName => "ICAOAnnex14";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ICAOAnnex14</para>
		/// </summary>
		public override string ExcuteName => "aviation.ICAOAnnex14";

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
		public override object[] Parameters => new object[] { InFeatures, Target, RunwayType, HighendClearWayLength!, LowendClearWayLength!, AirportElevation!, RunwayDirection!, IncludeMergedSurface!, DerivedOutfeatureclass!, CustomJsonFile!, AirportControlPointFeatureClass! };

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
		/// <para>The output feature class that will contain the generated obstruction identification surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object Target { get; set; }

		/// <summary>
		/// <para>Runway Classification</para>
		/// <para>Specifies the runway classification of the Input Runway Features parameter.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_1—A runway intended for the operation of aircraft using visual approach procedures. Runway strip length is 30 meters.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_2—A runway with a 60-meter strip length and 40-meter strip width that is intended for the operation of aircraft using visual approach procedures.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_3—A runway with a 60-meter strip length and 75-meter strip width that is intended for the operation of aircraft using visual approach procedures.</para>
		/// <para>NON_INSTRUMENT_CODE_NUMBER_4—A runway with a 60-meter strip length and 75-meter strip width that is intended for the operation of aircraft using visual approach procedures.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_1—An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_2—An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_3 —An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// <para>NON_PRECISION_APPROACH_CODE_NUMBER_4—An instrument runway served by visual aids and a nonvisual aid providing at least directional guidance adequate for a straight-in approach. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_I_CODE_NUMBER_1—An instrument runway served by an Instrument Landing System (ILS) or a Microwave Landing System (MLS) and visual aids intended for operations with a decision height not lower than 60 meters (200 feet) and either a visibility not less than 800 meters or a runway visual range not less than 550 meters. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_I_CODE_NUMBER_2—An instrument runway served by ILS and MLS and visual aids intended for operations with a decision height not lower than 60 meters (200 feet) and either a visibility not less than 800 meters or a runway visual range not less than 550 meters. This runway type has a 60-meter strip length and a 75-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_I_CODE_NUMBER_3_4—An instrument runway served by ILS and MLS and visual aids intended for operations with a decision height not lower than 60 meters (200 feet) and either a visibility not less than 800 meters or a runway visual range not less than 550 meters. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// <para>PRECISION_APPROACH_CATEGORY_II_III_CODE_NUMBER_3_4—An instrument runway served by ILS and MLS and visual aids intended for operations with a decision height lower than 60 meters (200 feet) but not lower than 30 meters (100 feet) and a runway visual range not less than 350 meters. This runway type has a 60-meter strip length and a 150-meter strip width on either side of the runway centerline.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RunwayType { get; set; }

		/// <summary>
		/// <para>Length of High Runway End Clearway</para>
		/// <para>The length of the area at the high end of the runway. The unit of measurement is based on the input runway features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? HighendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Length of Low Runway End Clearway</para>
		/// <para>The length of the area at the low end of the runway. The unit of measurement is based on the input runway features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? LowendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Airport Elevation</para>
		/// <para>The highest elevation on any of the runways of the airport. The value must be in the vertical coordinate system linear units of the target feature class. If no value is given, the highest point in the Input Runway Features dataset will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AirportElevation { get; set; } = "0";

		/// <summary>
		/// <para>Runway Direction</para>
		/// <para>Specifies at which end of the runway the approach surface will be created.</para>
		/// <para>High end to low end—The approach surface will be created at the high end of the runway to the low end. If a displaced threshold point exists at the high end of the runway, that point will be honored when creating the OIS.</para>
		/// <para>Low end to high end—The approach surface will be created at the low end of the runway to the high end. If a displaced threshold point exists at the low end of the runway, that point will be honored when creating the OIS.</para>
		/// <para>Both ends—The approach surface will be created at both the low end and high end of the runway.</para>
		/// <para><see cref="RunwayDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RunwayDirection { get; set; } = "HIGH_END_TO_LOW_END";

		/// <summary>
		/// <para>Include Merged Surfaces</para>
		/// <para>Specifies whether merged surfaces will be generated.</para>
		/// <para>Checked—All the surfaces will be generated for the merged surfaces, as well as merged conical and horizontal surfaces. This is the default.</para>
		/// <para>Unchecked—Surfaces will not be generated for the merged surfaces.</para>
		/// <para><see cref="IncludeMergedSurfaceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeMergedSurface { get; set; } = "true";

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
		/// <para>Input Airport Control Point Feature</para>
		/// <para>The point features containing an Airport Elevation feature, displaced threshold features, or both. Values provided for the Airport Elevation parameter will take precedence over these point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ICAOAnnex14 SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Runway Direction</para>
		/// </summary>
		public enum RunwayDirectionEnum 
		{
			/// <summary>
			/// <para>High end to low end—The approach surface will be created at the high end of the runway to the low end. If a displaced threshold point exists at the high end of the runway, that point will be honored when creating the OIS.</para>
			/// </summary>
			[GPValue("HIGH_END_TO_LOW_END")]
			[Description("High end to low end")]
			High_end_to_low_end,

			/// <summary>
			/// <para>Low end to high end—The approach surface will be created at the low end of the runway to the high end. If a displaced threshold point exists at the low end of the runway, that point will be honored when creating the OIS.</para>
			/// </summary>
			[GPValue("LOW_END_TO_HIGH_END")]
			[Description("Low end to high end")]
			Low_end_to_high_end,

			/// <summary>
			/// <para>Both ends—The approach surface will be created at both the low end and high end of the runway.</para>
			/// </summary>
			[GPValue("BOTH_END")]
			[Description("Both ends")]
			Both_ends,

		}

		/// <summary>
		/// <para>Include Merged Surfaces</para>
		/// </summary>
		public enum IncludeMergedSurfaceEnum 
		{
			/// <summary>
			/// <para>Checked—All the surfaces will be generated for the merged surfaces, as well as merged conical and horizontal surfaces. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_MERGED_SURFACE")]
			INCLUDE_MERGED_SURFACE,

			/// <summary>
			/// <para>Unchecked—Surfaces will not be generated for the merged surfaces.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INCLUDE_MERGED_SURFACE")]
			NOT_INCLUDE_MERGED_SURFACE,

		}

#endregion
	}
}
