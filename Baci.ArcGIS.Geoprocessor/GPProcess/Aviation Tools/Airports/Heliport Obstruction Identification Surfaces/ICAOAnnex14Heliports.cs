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
	/// <para>ICAO Annex 14 Heliports</para>
	/// <para>ICAO Annex 14 Heliports</para>
	/// <para>Generates obstruction identification surfaces (OIS) for heliports based on ICAO Annex 14 Volume II specifications.</para>
	/// </summary>
	public class ICAOAnnex14Heliports : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputSafetyAreaFeatures">
		/// <para>Input Safety Area Features</para>
		/// <para>The input safety area around which the obstruction identification surfaces will be generated.</para>
		/// </param>
		/// <param name="TargetOisFeatures">
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </param>
		/// <param name="SurfaceClassification">
		/// <para>Surface Classification</para>
		/// <para>Specifies the slope design category that will be used for the obstruction identification surfaces.</para>
		/// <para>Category A—Rotor aircraft operated with performance class 1 will be used.</para>
		/// <para>Category B—Rotor aircraft operated with performance class 3 will be used.</para>
		/// <para>Category C—Rotor aircraft operated with performance class 2 will be used.</para>
		/// <para><see cref="SurfaceClassificationEnum"/></para>
		/// </param>
		/// <param name="OperationType">
		/// <para>Operation Type</para>
		/// <para>Specifies the time when normal flight operations occur.</para>
		/// <para>Day operation—Normal flight operations occur during the day. This is the default.</para>
		/// <para>Night operation—Normal flight operations occur during the night.</para>
		/// <para><see cref="OperationTypeEnum"/></para>
		/// </param>
		public ICAOAnnex14Heliports(object InputSafetyAreaFeatures, object TargetOisFeatures, object SurfaceClassification, object OperationType)
		{
			this.InputSafetyAreaFeatures = InputSafetyAreaFeatures;
			this.TargetOisFeatures = TargetOisFeatures;
			this.SurfaceClassification = SurfaceClassification;
			this.OperationType = OperationType;
		}

		/// <summary>
		/// <para>Tool Display Name : ICAO Annex 14 Heliports</para>
		/// </summary>
		public override string DisplayName() => "ICAO Annex 14 Heliports";

		/// <summary>
		/// <para>Tool Name : ICAOAnnex14Heliports</para>
		/// </summary>
		public override string ToolName() => "ICAOAnnex14Heliports";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ICAOAnnex14Heliports</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ICAOAnnex14Heliports";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputSafetyAreaFeatures, TargetOisFeatures, SurfaceClassification, OperationType, RotorDiameter, ClearwayLength, SurfaceShape, ApproachBearing, InFlightpathFeatures, HeliportElevation, CustomJsonFile, DerivedOutfeatureclass };

		/// <summary>
		/// <para>Input Safety Area Features</para>
		/// <para>The input safety area around which the obstruction identification surfaces will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InputSafetyAreaFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>Surface Classification</para>
		/// <para>Specifies the slope design category that will be used for the obstruction identification surfaces.</para>
		/// <para>Category A—Rotor aircraft operated with performance class 1 will be used.</para>
		/// <para>Category B—Rotor aircraft operated with performance class 3 will be used.</para>
		/// <para>Category C—Rotor aircraft operated with performance class 2 will be used.</para>
		/// <para><see cref="SurfaceClassificationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SurfaceClassification { get; set; }

		/// <summary>
		/// <para>Operation Type</para>
		/// <para>Specifies the time when normal flight operations occur.</para>
		/// <para>Day operation—Normal flight operations occur during the day. This is the default.</para>
		/// <para>Night operation—Normal flight operations occur during the night.</para>
		/// <para><see cref="OperationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OperationType { get; set; } = "DAY_OPERATION";

		/// <summary>
		/// <para>Rotor Diameter</para>
		/// <para>The rotor diameter, in meters, of aircraft using the heliport. The default is 16.5 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RotorDiameter { get; set; } = "16.5";

		/// <summary>
		/// <para>Clearway Length</para>
		/// <para>The length of the clearway. The unit of measurement for the clearway depends on the Input Safety Area Features parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ClearwayLength { get; set; } = "0";

		/// <summary>
		/// <para>Surface Shape</para>
		/// <para>Specifies the shape of the take off or approach surface.</para>
		/// <para>Straight Surface—The take off climb or approach surface is straight. This is the default.</para>
		/// <para>Curved Surface—The take off climb or approach surface is curved.</para>
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
		[GeometryType("Polyline")]
		public object InFlightpathFeatures { get; set; }

		/// <summary>
		/// <para>Heliport Elevation</para>
		/// <para>The elevation of the highest point of the heliport. The value must be in the vertical coordinate system linear units of the target feature class. If no value is provided, the highest point of the Input Safety Area Features parameter value will be used. The default value is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object HeliportElevation { get; set; } = "0";

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
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object DerivedOutfeatureclass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Surface Classification</para>
		/// </summary>
		public enum SurfaceClassificationEnum 
		{
			/// <summary>
			/// <para>Category A—Rotor aircraft operated with performance class 1 will be used.</para>
			/// </summary>
			[GPValue("CATEGORY_A")]
			[Description("Category A")]
			Category_A,

			/// <summary>
			/// <para>Category B—Rotor aircraft operated with performance class 3 will be used.</para>
			/// </summary>
			[GPValue("CATEGORY_B")]
			[Description("Category B")]
			Category_B,

			/// <summary>
			/// <para>Category C—Rotor aircraft operated with performance class 2 will be used.</para>
			/// </summary>
			[GPValue("CATEGORY_C")]
			[Description("Category C")]
			Category_C,

		}

		/// <summary>
		/// <para>Operation Type</para>
		/// </summary>
		public enum OperationTypeEnum 
		{
			/// <summary>
			/// <para>Day operation—Normal flight operations occur during the day. This is the default.</para>
			/// </summary>
			[GPValue("DAY_OPERATION")]
			[Description("Day operation")]
			Day_operation,

			/// <summary>
			/// <para>Night operation—Normal flight operations occur during the night.</para>
			/// </summary>
			[GPValue("NIGHT_OPERATION")]
			[Description("Night operation")]
			Night_operation,

		}

		/// <summary>
		/// <para>Surface Shape</para>
		/// </summary>
		public enum SurfaceShapeEnum 
		{
			/// <summary>
			/// <para>Straight Surface—The take off climb or approach surface is straight. This is the default.</para>
			/// </summary>
			[GPValue("STRAIGHT_SURFACE")]
			[Description("Straight Surface")]
			Straight_Surface,

			/// <summary>
			/// <para>Curved Surface—The take off climb or approach surface is curved.</para>
			/// </summary>
			[GPValue("CURVED_SURFACE")]
			[Description("Curved Surface")]
			Curved_Surface,

		}

#endregion
	}
}
