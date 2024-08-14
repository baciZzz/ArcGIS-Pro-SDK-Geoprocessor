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
	/// <para>Generate Range Rings From Lookup Table</para>
	/// <para>Creates a set of concentric circles from a center based on values stored in a lookup table.</para>
	/// </summary>
	public class GenerateRangeRingsFromTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features (Center Points)</para>
		/// <para>The point feature set that identifies the center of the range ring. The input must have at least one point.</para>
		/// </param>
		/// <param name="InTable">
		/// <para>Input Lookup Table</para>
		/// <para>The input table that contains values for creating rings.</para>
		/// </param>
		/// <param name="OutFeatureClassRings">
		/// <para>Output Feature Class (Rings)</para>
		/// <para>The output feature class containing the ring features.</para>
		/// </param>
		/// <param name="LookupName">
		/// <para>Selected Name</para>
		/// <para>The row from the Input Lookup Table that contains the input values for minimum and maximum values or number of rings and interval.</para>
		/// </param>
		/// <param name="RangeRingsType">
		/// <para>Range Ring Type</para>
		/// <para>Specifies the method used to create the range rings.</para>
		/// <para>Interval—Range rings will be generated based on the number of rings and distance between rings. This the default.</para>
		/// <para>Minimum and maximum—Range rings will be generated based on a minimum and maximum distance.</para>
		/// <para><see cref="RangeRingsTypeEnum"/></para>
		/// </param>
		public GenerateRangeRingsFromTable(object InFeatures, object InTable, object OutFeatureClassRings, object LookupName, object RangeRingsType)
		{
			this.InFeatures = InFeatures;
			this.InTable = InTable;
			this.OutFeatureClassRings = OutFeatureClassRings;
			this.LookupName = LookupName;
			this.RangeRingsType = RangeRingsType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Range Rings From Lookup Table</para>
		/// </summary>
		public override string DisplayName => "Generate Range Rings From Lookup Table";

		/// <summary>
		/// <para>Tool Name : GenerateRangeRingsFromTable</para>
		/// </summary>
		public override string ToolName => "GenerateRangeRingsFromTable";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateRangeRingsFromTable</para>
		/// </summary>
		public override string ExcuteName => "defense.GenerateRangeRingsFromTable";

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
		public override object[] Parameters => new object[] { InFeatures, InTable, OutFeatureClassRings, LookupName, RangeRingsType, OutFeatureClassRadials, NumberOfRadials, DistanceUnits, LookupNameField, MinRangeField, MaxRangeField, NumberOfRingsField, RingIntervalField };

		/// <summary>
		/// <para>Input Features (Center Points)</para>
		/// <para>The point feature set that identifies the center of the range ring. The input must have at least one point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Lookup Table</para>
		/// <para>The input table that contains values for creating rings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class (Rings)</para>
		/// <para>The output feature class containing the ring features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClassRings { get; set; }

		/// <summary>
		/// <para>Selected Name</para>
		/// <para>The row from the Input Lookup Table that contains the input values for minimum and maximum values or number of rings and interval.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LookupName { get; set; }

		/// <summary>
		/// <para>Range Ring Type</para>
		/// <para>Specifies the method used to create the range rings.</para>
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
		/// <para>The number of radials to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfRadials { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the linear unit of measurement for the Ring Interval Field parameter or the Input Table Minimum Range and Input Table Maximum Range parameters.</para>
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
		/// <para>Input Table Selected Name Field</para>
		/// <para>The field from the input table that contains the Selected Name value. The default field name is Name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Input Table Options")]
		public object LookupNameField { get; set; } = "Name";

		/// <summary>
		/// <para>Input Table Minimum Range</para>
		/// <para>The field from the input table that contains the minimum range value. The default field name is Min.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Input Table Options")]
		public object MinRangeField { get; set; } = "Min";

		/// <summary>
		/// <para>Input Table Maximum Range</para>
		/// <para>The field from the input table that contains the maximum range value. The default field name is Max.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Input Table Options")]
		public object MaxRangeField { get; set; } = "Max";

		/// <summary>
		/// <para>Number of Rings Field</para>
		/// <para>The field from the input table that contains the number of rings value. The default field name is Rings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Input Table Options")]
		public object NumberOfRingsField { get; set; } = "Rings";

		/// <summary>
		/// <para>Ring Interval Field</para>
		/// <para>The field from the input table that contains the ring interval value. The default field name is Interval.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Input Table Options")]
		public object RingIntervalField { get; set; } = "Intervals";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRangeRingsFromTable SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
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
