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
	/// <para>ICAO Annex 4</para>
	/// <para>ICAO Annex 4</para>
	/// <para>Creates obstruction identification surfaces (OIS) based on the ICAO Annex 4 specification for the Precision Approach Terrain chart.</para>
	/// </summary>
	public class ICAOAnnex4 : AbstractGPProcess
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
		public ICAOAnnex4(object InFeatures, object Target)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
		}

		/// <summary>
		/// <para>Tool Display Name : ICAO Annex 4</para>
		/// </summary>
		public override string DisplayName() => "ICAO Annex 4";

		/// <summary>
		/// <para>Tool Name : ICAOAnnex4</para>
		/// </summary>
		public override string ToolName() => "ICAOAnnex4";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ICAOAnnex4</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ICAOAnnex4";

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
		public override object[] Parameters() => new object[] { InFeatures, Target, RunwayDirection, Length, Width, Slope, Height, DerivedOutfeatureclass, AirportControlPointFeatureClass };

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
		/// <para>Specifies at which end of the runway the approach surface will be created.</para>
		/// <para>High end to low end—The approach surface will be created at the high end of the runway to the low end. If a displaced threshold point exists at the high end of the runway, that point will be honored when creating the OIS.</para>
		/// <para>Low end to high end—The approach surface will be created at the low end of the runway to the high end. If a displaced threshold point exists at the low end of the runway, that point will be honored when creating the OIS.</para>
		/// <para><see cref="RunwayDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RunwayDirection { get; set; }

		/// <summary>
		/// <para>Length</para>
		/// <para>The length of the surface in meters. The default value is 900.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Length { get; set; } = "900";

		/// <summary>
		/// <para>Width</para>
		/// <para>The width of the surface in meters. The default value is 120.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Width { get; set; } = "120";

		/// <summary>
		/// <para>Slope</para>
		/// <para>The slope of the surface in degrees. The default value is 3.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Slope { get; set; } = "3";

		/// <summary>
		/// <para>Start Height</para>
		/// <para>The start height of the surface in meters. The default value is 15.24.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Height { get; set; } = "15.24";

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object DerivedOutfeatureclass { get; set; }

		/// <summary>
		/// <para>Input Airport Control Point Feature</para>
		/// <para>Supplies x-, y-, and z-geometry for displaced threshold features. If displaced thresholds are included, surfaces will be constructed based on their x-, y-, and z-geometry instead of their corresponding runway feature endpoint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ICAOAnnex4 SetEnviroment(object workspace = null )
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

		}

#endregion
	}
}
