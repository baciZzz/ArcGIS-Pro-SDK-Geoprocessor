using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Reduce Point Density</para>
	/// <para>Thins points from a point or multipoint feature class.</para>
	/// </summary>
	public class ReducePointDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point or multipoint features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		/// <param name="DepthField">
		/// <para>Depth Field</para>
		/// <para>The field where the depth is stored. It is either a numeric field or the shape field specified in Input Features.For multipoint features, this must be the shape field.</para>
		/// </param>
		/// <param name="DepthDirection">
		/// <para>Depth Direction</para>
		/// <para>Specifies how the depth value will be captured in the depth field of the input features.</para>
		/// <para>Positive Up—Depth values will be positive above the surface and negative below the surface. This is default.</para>
		/// <para>Positive Down—Depth values will be positive below the surface and negative above the surface.</para>
		/// <para><see cref="DepthDirectionEnum"/></para>
		/// </param>
		/// <param name="DepthBias">
		/// <para>Depth Selection Method</para>
		/// <para>Specifies the bias that will be used to select the depths to be retained.</para>
		/// <para>Shallow Biased—Shallow bias will be used for depth. This is default.</para>
		/// <para>Deep Biased—Deep bias will be used for depth.</para>
		/// <para><see cref="DepthBiasEnum"/></para>
		/// </param>
		/// <param name="RadiusUnit">
		/// <para>Thinning Radius Unit</para>
		/// <para>Specifies the unit of measure that will be used by the Start Thinning Radius and End Thinning Radius parameters.</para>
		/// <para>Kilometers—The radius unit will be kilometers.</para>
		/// <para>Meters—The radius unit will be meters. This is default.</para>
		/// <para>Decimeters—The radius unit will be decimeters.</para>
		/// <para>Centimeters—The radius unit will be centimeters.</para>
		/// <para>Millimeters—The radius unit will be millimeters.</para>
		/// <para>Nautical Miles—The radius unit will be nautical miles.</para>
		/// <para>Miles—The radius unit will be miles.</para>
		/// <para>Yards—The radius unit will be yards.</para>
		/// <para>Feet—The radius unit will be feet.</para>
		/// <para>Inches—The radius unit will be inches.</para>
		/// <para>Decimal Degrees—The radius unit will be decimal degrees.</para>
		/// <para>Points—The radius unit will be points.</para>
		/// </param>
		/// <param name="StartThinningRadius">
		/// <para>Start Thinning Radius</para>
		/// <para>The beginning radius that will be used to remove or thin points relative to each other.</para>
		/// </param>
		public ReducePointDensity(object InFeatures, object OutFeatureClass, object DepthField, object DepthDirection, object DepthBias, object RadiusUnit, object StartThinningRadius)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.DepthField = DepthField;
			this.DepthDirection = DepthDirection;
			this.DepthBias = DepthBias;
			this.RadiusUnit = RadiusUnit;
			this.StartThinningRadius = StartThinningRadius;
		}

		/// <summary>
		/// <para>Tool Display Name : Reduce Point Density</para>
		/// </summary>
		public override string DisplayName => "Reduce Point Density";

		/// <summary>
		/// <para>Tool Name : ReducePointDensity</para>
		/// </summary>
		public override string ToolName => "ReducePointDensity";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ReducePointDensity</para>
		/// </summary>
		public override string ExcuteName => "maritime.ReducePointDensity";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, DepthField, DepthDirection, DepthBias, RadiusUnit, StartThinningRadius, EndThinningRadius, StartDepth, EndDepth };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point or multipoint features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Depth Field</para>
		/// <para>The field where the depth is stored. It is either a numeric field or the shape field specified in Input Features.For multipoint features, this must be the shape field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object DepthField { get; set; }

		/// <summary>
		/// <para>Depth Direction</para>
		/// <para>Specifies how the depth value will be captured in the depth field of the input features.</para>
		/// <para>Positive Up—Depth values will be positive above the surface and negative below the surface. This is default.</para>
		/// <para>Positive Down—Depth values will be positive below the surface and negative above the surface.</para>
		/// <para><see cref="DepthDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DepthDirection { get; set; } = "POSITIVE_UP";

		/// <summary>
		/// <para>Depth Selection Method</para>
		/// <para>Specifies the bias that will be used to select the depths to be retained.</para>
		/// <para>Shallow Biased—Shallow bias will be used for depth. This is default.</para>
		/// <para>Deep Biased—Deep bias will be used for depth.</para>
		/// <para><see cref="DepthBiasEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DepthBias { get; set; } = "SHALLOW_BIASED";

		/// <summary>
		/// <para>Thinning Radius Unit</para>
		/// <para>Specifies the unit of measure that will be used by the Start Thinning Radius and End Thinning Radius parameters.</para>
		/// <para>Kilometers—The radius unit will be kilometers.</para>
		/// <para>Meters—The radius unit will be meters. This is default.</para>
		/// <para>Decimeters—The radius unit will be decimeters.</para>
		/// <para>Centimeters—The radius unit will be centimeters.</para>
		/// <para>Millimeters—The radius unit will be millimeters.</para>
		/// <para>Nautical Miles—The radius unit will be nautical miles.</para>
		/// <para>Miles—The radius unit will be miles.</para>
		/// <para>Yards—The radius unit will be yards.</para>
		/// <para>Feet—The radius unit will be feet.</para>
		/// <para>Inches—The radius unit will be inches.</para>
		/// <para>Decimal Degrees—The radius unit will be decimal degrees.</para>
		/// <para>Points—The radius unit will be points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RadiusUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Start Thinning Radius</para>
		/// <para>The beginning radius that will be used to remove or thin points relative to each other.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object StartThinningRadius { get; set; }

		/// <summary>
		/// <para>End Thinning Radius</para>
		/// <para>The end radius that will be used to remove or thin points relative to each other. The thinning radius will dynamically change as the algorithm progresses through the range of depth values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object EndThinningRadius { get; set; }

		/// <summary>
		/// <para>Start Depth</para>
		/// <para>The depth that will be used to begin the thinning algorithm. Depth values that appear before this depth based on the Depth Direction parameter value will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object StartDepth { get; set; }

		/// <summary>
		/// <para>End Depth</para>
		/// <para>The depth that will be used to end the thinning algorithm. Depth values that appear after this depth based on the Depth Direction parameter value will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object EndDepth { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Depth Direction</para>
		/// </summary>
		public enum DepthDirectionEnum 
		{
			/// <summary>
			/// <para>Positive Up—Depth values will be positive above the surface and negative below the surface. This is default.</para>
			/// </summary>
			[GPValue("POSITIVE_UP")]
			[Description("Positive Up")]
			Positive_Up,

			/// <summary>
			/// <para>Positive Down—Depth values will be positive below the surface and negative above the surface.</para>
			/// </summary>
			[GPValue("POSITIVE_DOWN")]
			[Description("Positive Down")]
			Positive_Down,

		}

		/// <summary>
		/// <para>Depth Selection Method</para>
		/// </summary>
		public enum DepthBiasEnum 
		{
			/// <summary>
			/// <para>Shallow Biased—Shallow bias will be used for depth. This is default.</para>
			/// </summary>
			[GPValue("SHALLOW_BIASED")]
			[Description("Shallow Biased")]
			Shallow_Biased,

			/// <summary>
			/// <para>Deep Biased—Deep bias will be used for depth.</para>
			/// </summary>
			[GPValue("DEEP_BIASED")]
			[Description("Deep Biased")]
			Deep_Biased,

		}

#endregion
	}
}
