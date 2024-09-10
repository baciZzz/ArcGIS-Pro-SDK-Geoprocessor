using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Generate Coverage Areas</para>
	/// <para>Creates a proximity buffer for input Intelligence, Surveillance, and Reconnaissance (ISR) or patrol assets for use in the Generate Blind Spot Areas tool.</para>
	/// </summary>
	public class GenerateCoverageAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input asset features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Blind Spot Buffer</para>
		/// <para>The output blind spot buffer features.</para>
		/// </param>
		/// <param name="BufferType">
		/// <para>Buffer Type</para>
		/// <para>The distance around the input features that will be buffered. Distances can be provided as either a value representing a linear distance or a field from the input features that defines the individual ranges and units to buffer each feature.</para>
		/// </param>
		public GenerateCoverageAreas(object InFeatures, object OutFeatureClass, object BufferType)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferType = BufferType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Coverage Areas</para>
		/// </summary>
		public override string DisplayName() => "Generate Coverage Areas";

		/// <summary>
		/// <para>Tool Name : GenerateCoverageAreas</para>
		/// </summary>
		public override string ToolName() => "GenerateCoverageAreas";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.GenerateCoverageAreas</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.GenerateCoverageAreas";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferType, RangeUnit, StartTimeField, EndTimeField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input asset features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Blind Spot Buffer</para>
		/// <para>The output blind spot buffer features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Buffer Type</para>
		/// <para>The distance around the input features that will be buffered. Distances can be provided as either a value representing a linear distance or a field from the input features that defines the individual ranges and units to buffer each feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferType { get; set; }

		/// <summary>
		/// <para>Range Unit</para>
		/// <para>Specifies a linear unit when the chosen Buffer Type parameter value does not contain the unit of distance.</para>
		/// <para>Meters—The distance unit will be meters.</para>
		/// <para>Kilometers—The distance unit will be kilometers.</para>
		/// <para>Feet—The distance unit will be feet.</para>
		/// <para>Miles—The distance unit will be miles.</para>
		/// <para>Nautical Miles—The distance unit will be nautical miles.</para>
		/// <para><see cref="RangeUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RangeUnit { get; set; }

		/// <summary>
		/// <para>Start Time Field</para>
		/// <para>The field containing the start date and time the asset is available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object StartTimeField { get; set; }

		/// <summary>
		/// <para>End Time Field</para>
		/// <para>The field containing the end date and time the asset is no longer available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object EndTimeField { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Range Unit</para>
		/// </summary>
		public enum RangeUnitEnum 
		{
			/// <summary>
			/// <para>Meters—The distance unit will be meters.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The distance unit will be kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The distance unit will be feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Miles—The distance unit will be miles.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical Miles—The distance unit will be nautical miles.</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("Nautical Miles")]
			Nautical_Miles,

		}

#endregion
	}
}
