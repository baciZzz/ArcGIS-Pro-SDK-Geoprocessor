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
	/// <para>ICAO Annex 4 Surfaces</para>
	/// <para>Creates obstruction identification surfaces</para>
	/// <para>(OIS) based on the ICAO Annex 4 specifications for either a</para>
	/// <para>Take-Off Flight Path Area or a Precision Approach Terrain</para>
	/// <para>Area.</para>
	/// </summary>
	public class ICAOAnnex4Surfaces : AbstractGPProcess
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
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </param>
		/// <param name="SurfaceGeneration">
		/// <para>Surface Generation</para>
		/// <para>Specifies the types of surfaces that will be created.</para>
		/// <para>Precision approach terrain area— A surface that is 60 meters either side of the extended runway centerline to a distance of 900 meters from the threshold, with a 3 percent slope rising outward from the threshold will be created.The surface will be created pursuant to, Chapter 6, 6.5.1.<italics>ICAO Annex 4</italics></para>
		/// <para>Takeoff flight path area— A surface with a 180 meter width at its point of origin (end of runway or clearway), which increases at a rate of 0.25D to a maximum of 1800 meters, where D is the distance from the point of origin will be created. This surface extends to a distance of 10 kilometers and has a 1.2 percent slope ascending outward from the point of origin. The surface will be created pursuant to, Chapter 3, 3.8.2.<italics>ICAO Annex 4</italics></para>
		/// <para><see cref="SurfaceGenerationEnum"/></para>
		/// </param>
		public ICAOAnnex4Surfaces(object InFeatures, object TargetOisFeatures, object SurfaceGeneration)
		{
			this.InFeatures = InFeatures;
			this.TargetOisFeatures = TargetOisFeatures;
			this.SurfaceGeneration = SurfaceGeneration;
		}

		/// <summary>
		/// <para>Tool Display Name : ICAO Annex 4 Surfaces</para>
		/// </summary>
		public override string DisplayName => "ICAO Annex 4 Surfaces";

		/// <summary>
		/// <para>Tool Name : ICAOAnnex4Surfaces</para>
		/// </summary>
		public override string ToolName => "ICAOAnnex4Surfaces";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ICAOAnnex4Surfaces</para>
		/// </summary>
		public override string ExcuteName => "aviation.ICAOAnnex4Surfaces";

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
		public override object[] Parameters => new object[] { InFeatures, TargetOisFeatures, SurfaceGeneration, RunwayDirection!, ClearWayLength!, ThresholdPointFeatureClass!, CustomJsonFile!, DerivedOutfeatureclass };

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
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>Surface Generation</para>
		/// <para>Specifies the types of surfaces that will be created.</para>
		/// <para>Precision approach terrain area— A surface that is 60 meters either side of the extended runway centerline to a distance of 900 meters from the threshold, with a 3 percent slope rising outward from the threshold will be created.The surface will be created pursuant to, Chapter 6, 6.5.1.<italics>ICAO Annex 4</italics></para>
		/// <para>Takeoff flight path area— A surface with a 180 meter width at its point of origin (end of runway or clearway), which increases at a rate of 0.25D to a maximum of 1800 meters, where D is the distance from the point of origin will be created. This surface extends to a distance of 10 kilometers and has a 1.2 percent slope ascending outward from the point of origin. The surface will be created pursuant to, Chapter 3, 3.8.2.<italics>ICAO Annex 4</italics></para>
		/// <para><see cref="SurfaceGenerationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object SurfaceGeneration { get; set; }

		/// <summary>
		/// <para>Runway Direction</para>
		/// <para>Specifies the end of the runway where the approach surface will be created.</para>
		/// <para>High end to low end—The approach surface will be created at the high end of the runway to the low end. If a displaced threshold point exists at the high end of the runway, that point will be honored when creating the OIS.</para>
		/// <para>Low end to high end—The approach surface will be created at the low end of the runway to the high end. If a displaced threshold point exists at the low end of the runway, that point will be honored when creating the OIS.</para>
		/// <para><see cref="RunwayDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RunwayDirection { get; set; } = "HIGH_END_TO_LOW_END";

		/// <summary>
		/// <para>Length of Clearway</para>
		/// <para>The length of the area beyond the runway in meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Input Threshold Point Features</para>
		/// <para>Supplies x-, y-, and z-geometry for displaced threshold features. If displaced thresholds are included, surfaces will be constructed based on their x-, y-, and z-geometry instead of their corresponding runway feature endpoint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? ThresholdPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Custom JSON File</para>
		/// <para>The import configuration, in JSON format, that creates the custom OIS.</para>
		/// <para>To create a JSON file for this parameter, use the CustomizeOIS.exe file that is part of the ArcGIS Aviation data package available from My Esri.</para>
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
		public ICAOAnnex4Surfaces SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Surface Generation</para>
		/// </summary>
		public enum SurfaceGenerationEnum 
		{
			/// <summary>
			/// <para>Precision approach terrain area— A surface that is 60 meters either side of the extended runway centerline to a distance of 900 meters from the threshold, with a 3 percent slope rising outward from the threshold will be created.The surface will be created pursuant to, Chapter 6, 6.5.1.<italics>ICAO Annex 4</italics></para>
			/// </summary>
			[GPValue("PRECISION_APPROACH_TERRAIN_AREA")]
			[Description("Precision approach terrain area")]
			Precision_approach_terrain_area,

			/// <summary>
			/// <para>Takeoff flight path area— A surface with a 180 meter width at its point of origin (end of runway or clearway), which increases at a rate of 0.25D to a maximum of 1800 meters, where D is the distance from the point of origin will be created. This surface extends to a distance of 10 kilometers and has a 1.2 percent slope ascending outward from the point of origin. The surface will be created pursuant to, Chapter 3, 3.8.2.<italics>ICAO Annex 4</italics></para>
			/// </summary>
			[GPValue("TAKEOFF_FLIGHT_PATH_AREA")]
			[Description("Takeoff flight path area")]
			Takeoff_flight_path_area,

		}

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

		}

#endregion
	}
}
