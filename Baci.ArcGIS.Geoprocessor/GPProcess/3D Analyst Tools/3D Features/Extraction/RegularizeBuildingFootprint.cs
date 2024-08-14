using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Regularize Building Footprint</para>
	/// <para>Normalizes the footprint of building polygons by eliminating undesirable artifacts in their geometry.</para>
	/// </summary>
	public class RegularizeBuildingFootprint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polygons that represent the building footprints to be regularized.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>Specifies the regularization method that will be used in processing the input features.</para>
		/// <para>Right Angles—Shapes composed of 90° angles between adjoining edges will be constructed.</para>
		/// <para>Right Angles and Diagonals—Shapes composed of 45° and 90° angles between adjoining edges will be constructed.</para>
		/// <para>Any Angles—Shapes that form any angles between adjoining edges will be constructed.</para>
		/// <para>Circle—The best fitting circle around the input features will be constructed.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Tolerance</para>
		/// <para>For most methods, this value represents the maximum distance that the regularized footprint can deviate from the boundary of its originating feature. The specified value will be based on the linear units of the input feature's coordinate system. When using the Circle method, this option can also be interpreted as a ratio of the difference between the original feature and its regularized result against the area of the regularized result based on the selection that is made in the Tolerance Type parameter.</para>
		/// </param>
		public RegularizeBuildingFootprint(object InFeatures, object OutFeatureClass, object Method, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Method = Method;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Regularize Building Footprint</para>
		/// </summary>
		public override string DisplayName => "Regularize Building Footprint";

		/// <summary>
		/// <para>Tool Name : RegularizeBuildingFootprint</para>
		/// </summary>
		public override string ToolName => "RegularizeBuildingFootprint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RegularizeBuildingFootprint</para>
		/// </summary>
		public override string ExcuteName => "3d.RegularizeBuildingFootprint";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Method, Tolerance, Densification!, Precision!, DiagonalPenalty!, MinRadius!, MaxRadius!, AlignmentFeature!, AlignmentTolerance!, ToleranceType! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygons that represent the building footprints to be regularized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the regularization method that will be used in processing the input features.</para>
		/// <para>Right Angles—Shapes composed of 90° angles between adjoining edges will be constructed.</para>
		/// <para>Right Angles and Diagonals—Shapes composed of 45° and 90° angles between adjoining edges will be constructed.</para>
		/// <para>Any Angles—Shapes that form any angles between adjoining edges will be constructed.</para>
		/// <para>Circle—The best fitting circle around the input features will be constructed.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "RIGHT_ANGLES";

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>For most methods, this value represents the maximum distance that the regularized footprint can deviate from the boundary of its originating feature. The specified value will be based on the linear units of the input feature's coordinate system. When using the Circle method, this option can also be interpreted as a ratio of the difference between the original feature and its regularized result against the area of the regularized result based on the selection that is made in the Tolerance Type parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Densification</para>
		/// <para>The sampling interval that will be used to evaluate whether the regularized feature will be straight or bent. The densification must be equal to or less than the tolerance value.</para>
		/// <para>This parameter is only used with methods that support right angle identification.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? Densification { get; set; }

		/// <summary>
		/// <para>Precision</para>
		/// <para>The precision of the spatial grid that will be used in the regularization process. Valid values range from 0.05 to 0.25.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? Precision { get; set; } = "0.25";

		/// <summary>
		/// <para>Diagonal Penalty</para>
		/// <para>When the Right Angles and Diagonals method is used, this value identifies the likelihood of constructing right angles or diagonal edges between two adjoining segments. When the Any Angles method is used, this value identifies the likelihood of constructing diagonal edges that do not conform to the preferred edges determined by the tool's algorithm. If the penalty value is set to 0, the preferred edges will not be used, resulting in the production of a simplified irregular polygon. Generally, the higher the value, the less likely a diagonal edge will be constructed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? DiagonalPenalty { get; set; } = "1.5";

		/// <summary>
		/// <para>Minimum Radius</para>
		/// <para>The smallest radius allowed for a regularized circle. A value of 0 implies that there is no minimum size limit. This option is only available with the Circle method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? MinRadius { get; set; } = "0.1";

		/// <summary>
		/// <para>Maximum Radius</para>
		/// <para>The largest radius allowed for a regularized circle. This option is only available with the Circle method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? MaxRadius { get; set; } = "1000000";

		/// <summary>
		/// <para>Alignment Feature</para>
		/// <para>The line feature that will be used to align the orientation of the regularized polygons. Each polygon will only be aligned to one line feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? AlignmentFeature { get; set; }

		/// <summary>
		/// <para>Alignment Tolerance</para>
		/// <para>The maximum distance threshold that will be used for finding the nearest alignment feature. For example, a value of 20 meters means the nearest line that is within 20 meters will be used to align the regularized polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? AlignmentTolerance { get; set; }

		/// <summary>
		/// <para>Tolerance Type</para>
		/// <para>Specifies how tolerance will be applied when the Method parameter is set to Circle.</para>
		/// <para>Distance—The tolerance will represent the maximum distance from the boundary of the feature being processed. This is the default.</para>
		/// <para>Area Ratio—The tolerance will represent the maximum limit for the ratio between the area of the original feature that differs from the regularized circle and the area of the regularized circle.</para>
		/// <para><see cref="ToleranceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ToleranceType { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegularizeBuildingFootprint SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? processorType = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Right Angles—Shapes composed of 90° angles between adjoining edges will be constructed.</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES")]
			[Description("Right Angles")]
			Right_Angles,

			/// <summary>
			/// <para>Right Angles and Diagonals—Shapes composed of 45° and 90° angles between adjoining edges will be constructed.</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES_AND_DIAGONALS")]
			[Description("Right Angles and Diagonals")]
			Right_Angles_and_Diagonals,

			/// <summary>
			/// <para>Any Angles—Shapes that form any angles between adjoining edges will be constructed.</para>
			/// </summary>
			[GPValue("ANY_ANGLE")]
			[Description("Any Angles")]
			Any_Angles,

			/// <summary>
			/// <para>Circle—The best fitting circle around the input features will be constructed.</para>
			/// </summary>
			[GPValue("CIRCLE")]
			[Description("Circle")]
			Circle,

		}

		/// <summary>
		/// <para>Tolerance Type</para>
		/// </summary>
		public enum ToleranceTypeEnum 
		{
			/// <summary>
			/// <para>Distance—The tolerance will represent the maximum distance from the boundary of the feature being processed. This is the default.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

			/// <summary>
			/// <para>Area Ratio—The tolerance will represent the maximum limit for the ratio between the area of the original feature that differs from the regularized circle and the area of the regularized circle.</para>
			/// </summary>
			[GPValue("AREA_RATIO")]
			[Description("Area Ratio")]
			Area_Ratio,

		}

#endregion
	}
}
