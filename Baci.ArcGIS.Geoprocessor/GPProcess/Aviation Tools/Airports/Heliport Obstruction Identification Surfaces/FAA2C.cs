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
	/// <para>FAA 2C</para>
	/// <para>Generates an Obstruction Identification Surface (OIS) for helipads based on specifications from FAA Advisory Circular 150/5390-2C.</para>
	/// </summary>
	public class FAA2C : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFatoFeatures">
		/// <para>Input FATO Features</para>
		/// <para>The input Final Approach and Takeoff (FATO) features.</para>
		/// </param>
		/// <param name="TargetOisFeatures">
		/// <para>Target OIS Features</para>
		/// <para>The target polygon or multipatch feature layer containing the Obstruction Identification Surfaces (OIS).</para>
		/// </param>
		/// <param name="SurfaceClassification">
		/// <para>Surface  Classification</para>
		/// <para>Specifies the classification type of the Final Approach and Takeoff (FATO) surface.</para>
		/// <para>Non Prior Permission Required (PPR) Facilities—Publically available helipads for general use by pilots. This is the default.</para>
		/// <para>Prior Permission Required (PPR) Facilities—A heliport used exclusively by the owner and individuals authorized by the owner to use the facility.</para>
		/// <para><see cref="SurfaceClassificationEnum"/></para>
		/// </param>
		public FAA2C(object InputFatoFeatures, object TargetOisFeatures, object SurfaceClassification)
		{
			this.InputFatoFeatures = InputFatoFeatures;
			this.TargetOisFeatures = TargetOisFeatures;
			this.SurfaceClassification = SurfaceClassification;
		}

		/// <summary>
		/// <para>Tool Display Name : FAA 2C</para>
		/// </summary>
		public override string DisplayName => "FAA 2C";

		/// <summary>
		/// <para>Tool Name : FAA2C</para>
		/// </summary>
		public override string ToolName => "FAA2C";

		/// <summary>
		/// <para>Tool Excute Name : aviation.FAA2C</para>
		/// </summary>
		public override string ExcuteName => "aviation.FAA2C";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFatoFeatures, TargetOisFeatures, SurfaceClassification, SurfaceShape, ApproachBearing, InFlightpathFeatures, HelipadElevation, CustomJsonFile, DerivedOutfeatureclass };

		/// <summary>
		/// <para>Input FATO Features</para>
		/// <para>The input Final Approach and Takeoff (FATO) features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputFatoFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The target polygon or multipatch feature layer containing the Obstruction Identification Surfaces (OIS).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>Surface  Classification</para>
		/// <para>Specifies the classification type of the Final Approach and Takeoff (FATO) surface.</para>
		/// <para>Non Prior Permission Required (PPR) Facilities—Publically available helipads for general use by pilots. This is the default.</para>
		/// <para>Prior Permission Required (PPR) Facilities—A heliport used exclusively by the owner and individuals authorized by the owner to use the facility.</para>
		/// <para><see cref="SurfaceClassificationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SurfaceClassification { get; set; } = "NON_PRIOR_PERMISSION_REQUIRED_FACILITIES";

		/// <summary>
		/// <para>Surface Shape</para>
		/// <para>Specifies the shape of the take off or approach surface.</para>
		/// <para>Straight Surface—The take off or approach surface is straight. This is the default.</para>
		/// <para>Curved Surface—The take off or approach surface is curved.</para>
		/// <para><see cref="SurfaceShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SurfaceShape { get; set; } = "STRAIGHT_SURFACE";

		/// <summary>
		/// <para>Approach Bearing</para>
		/// <para>The absolute bearing that an approaching aircraft will travel along the surface. A value of 0 will align the surface to true north. The default value is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ApproachBearing { get; set; } = "0";

		/// <summary>
		/// <para>Input Flight Path Features</para>
		/// <para>The polyline flight path features that the curved surface will follow.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFlightpathFeatures { get; set; }

		/// <summary>
		/// <para>Helipad Elevation</para>
		/// <para>The elevation of the highest point of the helipad. The value must be in the vertical coordinate system linear units of the target feature class. If no value is provided, the highest point of the Input FATO Features parameter value will be used. The default value is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object HelipadElevation { get; set; } = "0";

		/// <summary>
		/// <para>Custom JSON File</para>
		/// <para>The import configuration file, in JSON format, that creates the custom OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object DerivedOutfeatureclass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Surface  Classification</para>
		/// </summary>
		public enum SurfaceClassificationEnum 
		{
			/// <summary>
			/// <para>Non Prior Permission Required (PPR) Facilities—Publically available helipads for general use by pilots. This is the default.</para>
			/// </summary>
			[GPValue("NON_PRIOR_PERMISSION_REQUIRED_FACILITIES")]
			[Description("Non Prior Permission Required (PPR) Facilities")]
			NON_PRIOR_PERMISSION_REQUIRED_FACILITIES,

			/// <summary>
			/// <para>Prior Permission Required (PPR) Facilities—A heliport used exclusively by the owner and individuals authorized by the owner to use the facility.</para>
			/// </summary>
			[GPValue("PRIOR_PERMISSION_REQUIRED_FACILITIES")]
			[Description("Prior Permission Required (PPR) Facilities")]
			PRIOR_PERMISSION_REQUIRED_FACILITIES,

		}

		/// <summary>
		/// <para>Surface Shape</para>
		/// </summary>
		public enum SurfaceShapeEnum 
		{
			/// <summary>
			/// <para>Straight Surface—The take off or approach surface is straight. This is the default.</para>
			/// </summary>
			[GPValue("STRAIGHT_SURFACE")]
			[Description("Straight Surface")]
			Straight_Surface,

			/// <summary>
			/// <para>Curved Surface—The take off or approach surface is curved.</para>
			/// </summary>
			[GPValue("CURVED_SURFACE")]
			[Description("Curved Surface")]
			Curved_Surface,

		}

#endregion
	}
}
