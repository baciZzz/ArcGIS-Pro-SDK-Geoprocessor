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
	/// <para>Generate Range Rings</para>
	/// <para>Creates a set of concentric circles from a point, given a number of rings and distance between rings or a minimum and maximum distance from center.</para>
	/// </summary>
	public class GenerateRangeRings : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features (Center Points)</para>
		/// <para>The point feature set that identifies the center of the range ring. The input must have at least one point.</para>
		/// </param>
		/// <param name="OutFeatureClassRings">
		/// <para>Output Feature Class (Rings)</para>
		/// <para>The feature class containing the output ring features.</para>
		/// </param>
		/// <param name="RangeRingsType">
		/// <para>Range Ring Type</para>
		/// <para>Specifies the method to create the range rings.</para>
		/// <para>Interval—Range rings will be generated based on the number of rings and distance between rings. This the default.</para>
		/// <para>Minimum and maximum—Range rings will be generated based on a minimum and maximum distance.</para>
		/// <para><see cref="RangeRingsTypeEnum"/></para>
		/// </param>
		public GenerateRangeRings(object InFeatures, object OutFeatureClassRings, object RangeRingsType)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClassRings = OutFeatureClassRings;
			this.RangeRingsType = RangeRingsType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Range Rings</para>
		/// </summary>
		public override string DisplayName => "Generate Range Rings";

		/// <summary>
		/// <para>Tool Name : GenerateRangeRings</para>
		/// </summary>
		public override string ToolName => "GenerateRangeRings";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateRangeRings</para>
		/// </summary>
		public override string ExcuteName => "defense.GenerateRangeRings";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClassRings, RangeRingsType, OutFeatureClassRadials, NumberOfRadials, DistanceUnits, NumberOfRings, IntervalBetweenRings, MinimumRange, MaximumRange };

		/// <summary>
		/// <para>Input Features (Center Points)</para>
		/// <para>The point feature set that identifies the center of the range ring. The input must have at least one point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class (Rings)</para>
		/// <para>The feature class containing the output ring features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClassRings { get; set; }

		/// <summary>
		/// <para>Range Ring Type</para>
		/// <para>Specifies the method to create the range rings.</para>
		/// <para>Interval—Range rings will be generated based on the number of rings and distance between rings. This the default.</para>
		/// <para>Minimum and maximum—Range rings will be generated based on a minimum and maximum distance.</para>
		/// <para><see cref="RangeRingsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RangeRingsType { get; set; } = "INTERVAL";

		/// <summary>
		/// <para>Output Feature Class (Radials)</para>
		/// <para>The feature class containing the output radial features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatureClassRadials { get; set; }

		/// <summary>
		/// <para>Number of Radials</para>
		/// <para>The number of radials to generate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfRadials { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the linear unit of measurement for the Interval Between Rings parameter or the Minimum Range and Maximum Range parameters.</para>
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
		/// <para>Number of Rings</para>
		/// <para>The number of rings to generate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfRings { get; set; } = "4";

		/// <summary>
		/// <para>Interval Between Rings</para>
		/// <para>The distance between each ring.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object IntervalBetweenRings { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Range</para>
		/// <para>The distance from the center to the nearest ring.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinimumRange { get; set; } = "200";

		/// <summary>
		/// <para>Maximum Range</para>
		/// <para>The distance from the center to the farthest ring.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumRange { get; set; } = "1000";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRangeRings SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Range Ring Type</para>
		/// </summary>
		public enum RangeRingsTypeEnum 
		{
			/// <summary>
			/// <para>Interval—Range rings will be generated based on the number of rings and distance between rings. This the default.</para>
			/// </summary>
			[GPValue("INTERVAL")]
			[Description("Interval")]
			Interval,

			/// <summary>
			/// <para>Minimum and maximum—Range rings will be generated based on a minimum and maximum distance.</para>
			/// </summary>
			[GPValue("MIN_MAX")]
			[Description("Minimum and maximum")]
			Minimum_and_maximum,

		}

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

#endregion
	}
}
