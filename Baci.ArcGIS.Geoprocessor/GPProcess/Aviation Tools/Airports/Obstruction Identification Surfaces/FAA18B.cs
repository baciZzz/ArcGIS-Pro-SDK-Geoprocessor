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
	/// <para>FAA 18B</para>
	/// <para>FAA 18B</para>
	/// <para>Creates obstruction identification surfaces (OIS) based on the FAA Advisory Circular 150/5300-18B specification. These OIS assist in the identification of possible hazards to air navigation and critical approach/departure obstructions within the vicinity of the airport and are used to support planning and design activities. The type, function, and dimension of a surface differ by its runway classification. This tool creates surfaces such as a polygon or multipatch features</para>
	/// </summary>
	public class FAA18B : AbstractGPProcess
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
		/// <param name="RunwayType">
		/// <para>Runway Classification</para>
		/// <para>Specifies the runway classification of Input Runway Features.</para>
		/// <para>NON_VERTICAL_GUIDANCE_TYPE_1 —A runway designed for visual maneuvers, nonvertically guided operations, and instrument departure procedures.</para>
		/// <para>NON_VERTICAL_GUIDANCE_TYPE_2—A specially prepared hard surface (SPHS) runway designed for visual maneuvers, nonvertically guided operations, and instrument departure procedures. SPHS runways have a primary surface that extends 200 feet beyond each end of the runway.</para>
		/// <para>VERTICAL_GUIDANCE —A runway that uses precision guidance systems to support aircraft approach and landing.</para>
		/// <para><see cref="RunwayTypeEnum"/></para>
		/// </param>
		public FAA18B(object InFeatures, object Target, object RunwayType)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
			this.RunwayType = RunwayType;
		}

		/// <summary>
		/// <para>Tool Display Name : FAA 18B</para>
		/// </summary>
		public override string DisplayName() => "FAA 18B";

		/// <summary>
		/// <para>Tool Name : FAA18B</para>
		/// </summary>
		public override string ToolName() => "FAA18B";

		/// <summary>
		/// <para>Tool Excute Name : aviation.FAA18B</para>
		/// </summary>
		public override string ExcuteName() => "aviation.FAA18B";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Target, RunwayType, HighendClearWayLength!, LowendClearWayLength!, AirportElevation!, IncludeMergedSurface!, DerivedOutfeatureclass!, CustomJsonFile!, AirportControlPointFeatureClass! };

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
		/// <para>Runway Classification</para>
		/// <para>Specifies the runway classification of Input Runway Features.</para>
		/// <para>NON_VERTICAL_GUIDANCE_TYPE_1 —A runway designed for visual maneuvers, nonvertically guided operations, and instrument departure procedures.</para>
		/// <para>NON_VERTICAL_GUIDANCE_TYPE_2—A specially prepared hard surface (SPHS) runway designed for visual maneuvers, nonvertically guided operations, and instrument departure procedures. SPHS runways have a primary surface that extends 200 feet beyond each end of the runway.</para>
		/// <para>VERTICAL_GUIDANCE —A runway that uses precision guidance systems to support aircraft approach and landing.</para>
		/// <para><see cref="RunwayTypeEnum"/></para>
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
		/// <para>The highest elevation on any of the runways of the airport. The value should be given in the vertical coordinate system linear units of the target feature class. If no value is given, the highest point on the Input Runway Features will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AirportElevation { get; set; } = "0";

		/// <summary>
		/// <para>Include Merged Surfaces</para>
		/// <para>Indicates whether merged horizontal and conical surfaces are included in the OIS in addition to the regular surfaces.</para>
		/// <para>Checked—Include merged surfaces in the OIS output. This is the default.</para>
		/// <para>Unchecked—Do not include merged surfaces in the OIS output.</para>
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
		[FileTypes("json")]
		public object? CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Input Airport Control Point Feature</para>
		/// <para>The point features containing an Airport Elevation feature, displaced threshold features, or both. Values provided for the Airport Elevation parameter will take precedence over these point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object? AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FAA18B SetEnviroment(object? workspace = null )
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
			/// <para></para>
			/// </summary>
			[GPValue("NON_VERTICAL_GUIDANCE_TYPE_1")]
			[Description("Non vertical guidance type 1")]
			Non_vertical_guidance_type_1,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NON_VERTICAL_GUIDANCE_TYPE_2")]
			[Description("Non vertical guidance type 2")]
			Non_vertical_guidance_type_2,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("VERTICAL_GUIDANCE")]
			[Description("Vertical guidance")]
			Vertical_guidance,

		}

		/// <summary>
		/// <para>Include Merged Surfaces</para>
		/// </summary>
		public enum IncludeMergedSurfaceEnum 
		{
			/// <summary>
			/// <para>Checked—Include merged surfaces in the OIS output. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_MERGED_SURFACE")]
			INCLUDE_MERGED_SURFACE,

			/// <summary>
			/// <para>Unchecked—Do not include merged surfaces in the OIS output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INCLUDE_MERGED_SURFACE")]
			NOT_INCLUDE_MERGED_SURFACE,

		}

#endregion
	}
}
