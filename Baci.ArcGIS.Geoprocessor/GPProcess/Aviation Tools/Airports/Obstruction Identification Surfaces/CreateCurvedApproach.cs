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
	/// <para>Create Curved Approach</para>
	/// <para>Creates curved approach obstacle identification surfaces (OIS) based on the supported specifications in ArcGIS Aviation. These curved approach surfaces are based on an input flight path and the information in the selected specification, for example, ICAO Annex 15, FAA 18B and classification. This tool creates surfaces in existing polygon or multipatch features.</para>
	/// </summary>
	public class CreateCurvedApproach : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRunwayFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </param>
		/// <param name="InFlightpathFeatures">
		/// <para>Input Flight Path Features</para>
		/// <para>The polyline features that define curved approaches to the specified runways.</para>
		/// </param>
		/// <param name="TargetOisFeatures">
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated OIS.</para>
		/// </param>
		/// <param name="Specification">
		/// <para>Specification</para>
		/// <para>Specifies the approach surface specification.</para>
		/// <para>ICAO Annex 15—ICAO Annex 15 (ETOD)</para>
		/// <para>ICAO Annex 14—ICAO Annex 14 (OLS)</para>
		/// <para>FAA regulations part 77—FAA regulations part 77 (FAR77)</para>
		/// <para>FAA Advisory circular 150/5300_18B—FAA Advisory circular 150/5300_18B (18B)</para>
		/// <para>FAA Advisory circular 150/5300_13A—FAA Advisory circular 150/5300_13A (13A)</para>
		/// <para><see cref="SpecificationEnum"/></para>
		/// </param>
		/// <param name="RunwayClassification">
		/// <para>Runway Classification</para>
		/// <para>The runway classification of the approach surface.</para>
		/// <para>The option used for the Specification parameter (specification in Python) will determine the available options for the this parameter.</para>
		/// </param>
		public CreateCurvedApproach(object InRunwayFeatures, object InFlightpathFeatures, object TargetOisFeatures, object Specification, object RunwayClassification)
		{
			this.InRunwayFeatures = InRunwayFeatures;
			this.InFlightpathFeatures = InFlightpathFeatures;
			this.TargetOisFeatures = TargetOisFeatures;
			this.Specification = Specification;
			this.RunwayClassification = RunwayClassification;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Curved Approach</para>
		/// </summary>
		public override string DisplayName => "Create Curved Approach";

		/// <summary>
		/// <para>Tool Name : CreateCurvedApproach</para>
		/// </summary>
		public override string ToolName => "CreateCurvedApproach";

		/// <summary>
		/// <para>Tool Excute Name : aviation.CreateCurvedApproach</para>
		/// </summary>
		public override string ExcuteName => "aviation.CreateCurvedApproach";

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
		public override object[] Parameters => new object[] { InRunwayFeatures, InFlightpathFeatures, TargetOisFeatures, Specification, RunwayClassification, OutOisFeatures, CustomJsonFile, ThresholdOffset };

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InRunwayFeatures { get; set; }

		/// <summary>
		/// <para>Input Flight Path Features</para>
		/// <para>The polyline features that define curved approaches to the specified runways.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFlightpathFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>Specification</para>
		/// <para>Specifies the approach surface specification.</para>
		/// <para>ICAO Annex 15—ICAO Annex 15 (ETOD)</para>
		/// <para>ICAO Annex 14—ICAO Annex 14 (OLS)</para>
		/// <para>FAA regulations part 77—FAA regulations part 77 (FAR77)</para>
		/// <para>FAA Advisory circular 150/5300_18B—FAA Advisory circular 150/5300_18B (18B)</para>
		/// <para>FAA Advisory circular 150/5300_13A—FAA Advisory circular 150/5300_13A (13A)</para>
		/// <para><see cref="SpecificationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Specification { get; set; }

		/// <summary>
		/// <para>Runway Classification</para>
		/// <para>The runway classification of the approach surface.</para>
		/// <para>The option used for the Specification parameter (specification in Python) will determine the available options for the this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RunwayClassification { get; set; }

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
		public object CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Threshold Offset</para>
		/// <para>The distance offset from the runway end point. The threshold will be applied in the units of the input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ThresholdOffset { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateCurvedApproach SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Specification</para>
		/// </summary>
		public enum SpecificationEnum 
		{
			/// <summary>
			/// <para>ICAO Annex 15—ICAO Annex 15 (ETOD)</para>
			/// </summary>
			[GPValue("ETOD")]
			[Description("ICAO Annex 15")]
			ICAO_Annex_15,

			/// <summary>
			/// <para>ICAO Annex 14—ICAO Annex 14 (OLS)</para>
			/// </summary>
			[GPValue("OLS")]
			[Description("ICAO Annex 14")]
			ICAO_Annex_14,

			/// <summary>
			/// <para>FAA regulations part 77—FAA regulations part 77 (FAR77)</para>
			/// </summary>
			[GPValue("FAR77")]
			[Description("FAA regulations part 77")]
			FAA_regulations_part_77,

			/// <summary>
			/// <para>FAA Advisory circular 150/5300_18B—FAA Advisory circular 150/5300_18B (18B)</para>
			/// </summary>
			[GPValue("18B")]
			[Description("FAA Advisory circular 150/5300_18B")]
			_18B,

			/// <summary>
			/// <para>FAA Advisory circular 150/5300_13A—FAA Advisory circular 150/5300_13A (13A)</para>
			/// </summary>
			[GPValue("13A")]
			[Description("FAA Advisory circular 150/5300_13A")]
			_13A,

		}

#endregion
	}
}
