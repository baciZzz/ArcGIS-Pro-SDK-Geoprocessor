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
	/// <para>Generate Range Rings From Features</para>
	/// <para>Generate Range Rings From Features</para>
	/// <para>Creates range rings with attributes derived from fields in a point feature class.</para>
	/// </summary>
	public class GenerateRangeRingsFromFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point feature set that identifies the center of the range ring. The input must have at least one point.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Range Ring Feature Class</para>
		/// <para>The feature class that will contain the output ring features.</para>
		/// </param>
		/// <param name="RangeRingsType">
		/// <para>Range Ring Type</para>
		/// <para>Specifies how range rings will be generated..</para>
		/// <para>Interval—Range rings will be generated based on the number of rings and distance between rings. This the default.</para>
		/// <para>Minimum and maximum—Range rings will be generated based on a minimum and maximum distance.</para>
		/// <para><see cref="RangeRingsTypeEnum"/></para>
		/// </param>
		public GenerateRangeRingsFromFeatures(object InFeatures, object OutputFeatureClass, object RangeRingsType)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.RangeRingsType = RangeRingsType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Range Rings From Features</para>
		/// </summary>
		public override string DisplayName() => "Generate Range Rings From Features";

		/// <summary>
		/// <para>Tool Name : GenerateRangeRingsFromFeatures</para>
		/// </summary>
		public override string ToolName() => "GenerateRangeRingsFromFeatures";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateRangeRingsFromFeatures</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateRangeRingsFromFeatures";

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
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatureClass, RangeRingsType, OutFeatureClassRadials, RadialCountField, MinRangeField, MaxRangeField, RingCountField, RingIntervalField, DistanceUnits };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point feature set that identifies the center of the range ring. The input must have at least one point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Range Ring Feature Class</para>
		/// <para>The feature class that will contain the output ring features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Range Ring Type</para>
		/// <para>Specifies how range rings will be generated..</para>
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
		/// <para>The feature class that will contain the output radial features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatureClassRadials { get; set; }

		/// <summary>
		/// <para>Radial Count Field</para>
		/// <para>The field that contains the number of radials to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object RadialCountField { get; set; }

		/// <summary>
		/// <para>Minimum Range Field</para>
		/// <para>The field that contains the values for the distance from the origin point to the inner ring.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		public object MinRangeField { get; set; }

		/// <summary>
		/// <para>Maximum Range Field</para>
		/// <para>The field that contains the values for the distance from the origin point to the outer ring.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		public object MaxRangeField { get; set; }

		/// <summary>
		/// <para>Ring Count Field</para>
		/// <para>The field that contains the values for the number of rings to generate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object RingCountField { get; set; }

		/// <summary>
		/// <para>Ring Interval Field</para>
		/// <para>The field that contains the values for the interval between rings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Double", "Float")]
		public object RingIntervalField { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the linear unit of measure for the value in the Ring Interval Field parameter or the values in the Minimum Range Field and Maximum Range Field parameters.</para>
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
		public object DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRangeRingsFromFeatures SetEnviroment(object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
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
