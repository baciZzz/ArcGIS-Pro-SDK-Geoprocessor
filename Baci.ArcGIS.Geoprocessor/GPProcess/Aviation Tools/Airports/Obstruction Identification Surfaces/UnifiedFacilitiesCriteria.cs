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
	/// <para>Unified Facilities Criteria</para>
	/// <para>Creates obstruction identification surfaces based on the Unified Facilities Criteria (UFC) 3-260-01 that is prescribed by MIL-STD 3007. These surfaces provide planning, design, construction, sustainment, restoration, and modernization criteria for the United States Department of Defense. Surfaces are created as polygon or multipatch features.</para>
	/// </summary>
	public class UnifiedFacilitiesCriteria : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRunwayFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </param>
		/// <param name="TargetOisFeatures">
		/// <para>Target OIS Features</para>
		/// <para>The existing output feature class that will contain the generated UFC surfaces.</para>
		/// </param>
		/// <param name="InWingType">
		/// <para>Wing Type</para>
		/// <para>Specifies the wing type of the aircraft.</para>
		/// <para>Fixed—The wing type is fixed.</para>
		/// <para>Rotary—The wing type is rotary.</para>
		/// <para>If you choose Rotary, the Runway Class parameter will default to Class A without affecting the surface generation.</para>
		/// <para><see cref="InWingTypeEnum"/></para>
		/// </param>
		/// <param name="InServiceType">
		/// <para>Service Type</para>
		/// <para>Specifies the type of military service.</para>
		/// <para>Air Force—The service type is Air Force.</para>
		/// <para>Army—The service type is Army.</para>
		/// <para>Navy—The service type is Navy.</para>
		/// <para>Marine Corps—The service type is Marine Corps.</para>
		/// <para><see cref="InServiceTypeEnum"/></para>
		/// </param>
		/// <param name="InRunwayClass">
		/// <para>Runway Class</para>
		/// <para>Specifies the runway class. Runways are classified as either Class A or Class B based on aircraft type.</para>
		/// <para>Class A—The runway classification is Class A.</para>
		/// <para>Class B—The runway classification is Class B.</para>
		/// <para><see cref="InRunwayClassEnum"/></para>
		/// </param>
		/// <param name="InFlightRule">
		/// <para>Flight Rule</para>
		/// <para>Specifies the flight rule. The rules that govern the procedures for conducting flight, either instrument or under visual conditions.</para>
		/// <para>Instrument—The flight rule is instrument flight condition.</para>
		/// <para>Visual—The flight rule is visual flight condition.</para>
		/// <para><see cref="InFlightRuleEnum"/></para>
		/// </param>
		public UnifiedFacilitiesCriteria(object InRunwayFeatures, object TargetOisFeatures, object InWingType, object InServiceType, object InRunwayClass, object InFlightRule)
		{
			this.InRunwayFeatures = InRunwayFeatures;
			this.TargetOisFeatures = TargetOisFeatures;
			this.InWingType = InWingType;
			this.InServiceType = InServiceType;
			this.InRunwayClass = InRunwayClass;
			this.InFlightRule = InFlightRule;
		}

		/// <summary>
		/// <para>Tool Display Name : Unified Facilities Criteria</para>
		/// </summary>
		public override string DisplayName => "Unified Facilities Criteria";

		/// <summary>
		/// <para>Tool Name : UnifiedFacilitiesCriteria</para>
		/// </summary>
		public override string ToolName => "UnifiedFacilitiesCriteria";

		/// <summary>
		/// <para>Tool Excute Name : aviation.UnifiedFacilitiesCriteria</para>
		/// </summary>
		public override string ExcuteName => "aviation.UnifiedFacilitiesCriteria";

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
		public override object[] Parameters => new object[] { InRunwayFeatures, TargetOisFeatures, InWingType, InServiceType, InRunwayClass, InFlightRule, HighendClearWayLength, LowendClearWayLength, AirportElevation, OutOisFeatures, CustomJsonFile, AirportControlPointFeatureClass };

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRunwayFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The existing output feature class that will contain the generated UFC surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>Wing Type</para>
		/// <para>Specifies the wing type of the aircraft.</para>
		/// <para>Fixed—The wing type is fixed.</para>
		/// <para>Rotary—The wing type is rotary.</para>
		/// <para>If you choose Rotary, the Runway Class parameter will default to Class A without affecting the surface generation.</para>
		/// <para><see cref="InWingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InWingType { get; set; }

		/// <summary>
		/// <para>Service Type</para>
		/// <para>Specifies the type of military service.</para>
		/// <para>Air Force—The service type is Air Force.</para>
		/// <para>Army—The service type is Army.</para>
		/// <para>Navy—The service type is Navy.</para>
		/// <para>Marine Corps—The service type is Marine Corps.</para>
		/// <para><see cref="InServiceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InServiceType { get; set; }

		/// <summary>
		/// <para>Runway Class</para>
		/// <para>Specifies the runway class. Runways are classified as either Class A or Class B based on aircraft type.</para>
		/// <para>Class A—The runway classification is Class A.</para>
		/// <para>Class B—The runway classification is Class B.</para>
		/// <para><see cref="InRunwayClassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InRunwayClass { get; set; }

		/// <summary>
		/// <para>Flight Rule</para>
		/// <para>Specifies the flight rule. The rules that govern the procedures for conducting flight, either instrument or under visual conditions.</para>
		/// <para>Instrument—The flight rule is instrument flight condition.</para>
		/// <para>Visual—The flight rule is visual flight condition.</para>
		/// <para><see cref="InFlightRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFlightRule { get; set; }

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
		/// <para>The highest elevation on any of the runways of the airport. The value should be given in the vertical coordinate system linear units of the target feature class. If no value is given, the highest point of the Input Runway Features parameter will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AirportElevation { get; set; } = "0";

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object OutOisFeatures { get; set; }

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
		public UnifiedFacilitiesCriteria SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Wing Type</para>
		/// </summary>
		public enum InWingTypeEnum 
		{
			/// <summary>
			/// <para>Fixed—The wing type is fixed.</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("Fixed")]
			Fixed,

			/// <summary>
			/// <para>Rotary—The wing type is rotary.</para>
			/// </summary>
			[GPValue("ROTARY")]
			[Description("Rotary")]
			Rotary,

		}

		/// <summary>
		/// <para>Service Type</para>
		/// </summary>
		public enum InServiceTypeEnum 
		{
			/// <summary>
			/// <para>Air Force—The service type is Air Force.</para>
			/// </summary>
			[GPValue("AIRFORCE")]
			[Description("Air Force")]
			Air_Force,

			/// <summary>
			/// <para>Army—The service type is Army.</para>
			/// </summary>
			[GPValue("ARMY")]
			[Description("Army")]
			Army,

			/// <summary>
			/// <para>Navy—The service type is Navy.</para>
			/// </summary>
			[GPValue("NAVY")]
			[Description("Navy")]
			Navy,

			/// <summary>
			/// <para>Marine Corps—The service type is Marine Corps.</para>
			/// </summary>
			[GPValue("MARINECORPS")]
			[Description("Marine Corps")]
			Marine_Corps,

		}

		/// <summary>
		/// <para>Runway Class</para>
		/// </summary>
		public enum InRunwayClassEnum 
		{
			/// <summary>
			/// <para>Class A—The runway classification is Class A.</para>
			/// </summary>
			[GPValue("CLASS_A")]
			[Description("Class A")]
			Class_A,

			/// <summary>
			/// <para>Class B—The runway classification is Class B.</para>
			/// </summary>
			[GPValue("CLASS_B")]
			[Description("Class B")]
			Class_B,

		}

		/// <summary>
		/// <para>Flight Rule</para>
		/// </summary>
		public enum InFlightRuleEnum 
		{
			/// <summary>
			/// <para>Instrument—The flight rule is instrument flight condition.</para>
			/// </summary>
			[GPValue("INSTRUMENT")]
			[Description("Instrument")]
			Instrument,

			/// <summary>
			/// <para>Visual—The flight rule is visual flight condition.</para>
			/// </summary>
			[GPValue("VISUAL")]
			[Description("Visual")]
			Visual,

		}

#endregion
	}
}
