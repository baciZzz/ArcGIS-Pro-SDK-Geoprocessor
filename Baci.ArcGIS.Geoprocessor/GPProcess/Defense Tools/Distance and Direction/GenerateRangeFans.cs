using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Generate Range Fans</para>
	/// <para>Creates range fans originating from a starting point given a </para>
	/// <para>horizontal start angle, horizontal end angle, minimum distance, and maximum distance.</para>
	/// </summary>
	public class GenerateRangeFans : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Points</para>
		/// <para>The input point feature set that identifies the origin points of the range fans. The input must have at least one point.</para>
		/// </param>
		/// <param name="OutRangeFanFeatureClass">
		/// <para>Output Range Fan Feature Class</para>
		/// <para>The feature class that will contain the output range fan features.</para>
		/// </param>
		/// <param name="InnerRadius">
		/// <para>Minimum Distance</para>
		/// <para>The distance from the origin point to the start of the range fan.</para>
		/// </param>
		/// <param name="OuterRadius">
		/// <para>Maximum Distance</para>
		/// <para>The distance from the origin point to the end of the range fan.</para>
		/// </param>
		/// <param name="HorizontalStartAngle">
		/// <para>Horizontal Start Angle</para>
		/// <para>The angle from the origin point to the start of the range fan.</para>
		/// </param>
		/// <param name="HorizontalEndAngle">
		/// <para>Horizontal End Angle</para>
		/// <para>The angle from the origin point to the end of the range fan.</para>
		/// </param>
		public GenerateRangeFans(object InFeatures, object OutRangeFanFeatureClass, object InnerRadius, object OuterRadius, object HorizontalStartAngle, object HorizontalEndAngle)
		{
			this.InFeatures = InFeatures;
			this.OutRangeFanFeatureClass = OutRangeFanFeatureClass;
			this.InnerRadius = InnerRadius;
			this.OuterRadius = OuterRadius;
			this.HorizontalStartAngle = HorizontalStartAngle;
			this.HorizontalEndAngle = HorizontalEndAngle;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Range Fans</para>
		/// </summary>
		public override string DisplayName() => "Generate Range Fans";

		/// <summary>
		/// <para>Tool Name : GenerateRangeFans</para>
		/// </summary>
		public override string ToolName() => "GenerateRangeFans";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateRangeFans</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateRangeFans";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutRangeFanFeatureClass, InnerRadius, OuterRadius, HorizontalStartAngle, HorizontalEndAngle, DistanceUnits, AngleUnits };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The input point feature set that identifies the origin points of the range fans. The input must have at least one point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Range Fan Feature Class</para>
		/// <para>The feature class that will contain the output range fan features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutRangeFanFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum Distance</para>
		/// <para>The distance from the origin point to the start of the range fan.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object InnerRadius { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>The distance from the origin point to the end of the range fan.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object OuterRadius { get; set; }

		/// <summary>
		/// <para>Horizontal Start Angle</para>
		/// <para>The angle from the origin point to the start of the range fan.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object HorizontalStartAngle { get; set; }

		/// <summary>
		/// <para>Horizontal End Angle</para>
		/// <para>The angle from the origin point to the end of the range fan.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object HorizontalEndAngle { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the linear unit of measurement for minimum and maximum distance.</para>
		/// <para>Meters—The unit will be meters. This is the default.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Nautical miles—The unit will be nautical miles.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>US survey feet—The unit will be U.S. survey feet.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Angular Units</para>
		/// <para>Specifies the angular unit of measurement for start and end angles.</para>
		/// <para>Degrees—The angle will be degrees. This is the default.</para>
		/// <para>Mils—The angle will be mils.</para>
		/// <para>Radians—The angle will be radians.</para>
		/// <para>Gradians—The angle will be gradians.</para>
		/// <para><see cref="AngleUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object AngleUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRangeFans SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—The unit will be meters. This is the default.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The unit will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Miles—The unit will be miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical miles—The unit will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("Nautical miles")]
			Nautical_miles,

			/// <summary>
			/// <para>Feet—The unit will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>US survey feet—The unit will be U.S. survey feet.</para>
			/// </summary>
			[GPValue("US_SURVEY_FEET")]
			[Description("US survey feet")]
			US_survey_feet,

		}

		/// <summary>
		/// <para>Angular Units</para>
		/// </summary>
		public enum AngleUnitsEnum 
		{
			/// <summary>
			/// <para>Degrees—The angle will be degrees. This is the default.</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("Degrees")]
			Degrees,

			/// <summary>
			/// <para>Mils—The angle will be mils.</para>
			/// </summary>
			[GPValue("MILS")]
			[Description("Mils")]
			Mils,

			/// <summary>
			/// <para>Radians—The angle will be radians.</para>
			/// </summary>
			[GPValue("RADS")]
			[Description("Radians")]
			Radians,

			/// <summary>
			/// <para>Gradians—The angle will be gradians.</para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("Gradians")]
			Gradians,

		}

#endregion
	}
}
