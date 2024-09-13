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
	/// <para>Generate Blind Spot Areas</para>
	/// <para>Generate Blind Spot Areas</para>
	/// <para>Creates an output nonvisible area, or blind spot, for input Intelligence, Surveillance, Reconnaissance (ISR) or patrol visible buffer features based on start and end times. The output blind spot layer is used with the  time slider to visualize and explore areas that are not visible to ISR or patrol assets at specified times.</para>
	/// <para>For example, the output can show areas that a guard is not able to observe for given input time periods at posts along a patrol route.</para>
	/// </summary>
	public class GenerateBlindSpotAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input visible buffer features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Features</para>
		/// <para>The output blind spot area features.</para>
		/// </param>
		public GenerateBlindSpotAreas(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Blind Spot Areas</para>
		/// </summary>
		public override string DisplayName() => "Generate Blind Spot Areas";

		/// <summary>
		/// <para>Tool Name : GenerateBlindSpotAreas</para>
		/// </summary>
		public override string ToolName() => "GenerateBlindSpotAreas";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.GenerateBlindSpotAreas</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.GenerateBlindSpotAreas";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, ClipFeatures!, StartTimeField!, EndTimeField! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input visible buffer features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output blind spot area features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>The features used to define the input boundary.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? ClipFeatures { get; set; }

		/// <summary>
		/// <para>Start Time Field</para>
		/// <para>The field containing the start date and time when the asset is available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? StartTimeField { get; set; }

		/// <summary>
		/// <para>End Time Field</para>
		/// <para>The field containing the end date and time when the asset is no longer available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? EndTimeField { get; set; }

	}
}
