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
	/// <para>Normalizes the footprint of building polygons by eliminating undesirable artifacts in their  geometry.</para>
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
		/// <para>The regularization method to be used in processing the input features.</para>
		/// <para>Right Angles—Constructs shapes comprised of 90° angles between adjoining edges.</para>
		/// <para>Right Angles and Diagonals—Constructs shapes comprised of 45° and 90° angles between adjoining edges.</para>
		/// <para>Any Angles—Constructs shapes that form any angles between adjoining edges.</para>
		/// <para>Circle—Constructs the best fitting circle around the input features.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Tolerance</para>
		/// <para>The maximum distance that the regularized footprint can deviate from the boundary of its originating feature. The specified value will be based on the linear units of the input feature's coordinate system.</para>
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
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Method, Tolerance, Densification, Precision, DiagonalPenalty, MinRadius, MaxRadius };

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
		/// <para>The regularization method to be used in processing the input features.</para>
		/// <para>Right Angles—Constructs shapes comprised of 90° angles between adjoining edges.</para>
		/// <para>Right Angles and Diagonals—Constructs shapes comprised of 45° and 90° angles between adjoining edges.</para>
		/// <para>Any Angles—Constructs shapes that form any angles between adjoining edges.</para>
		/// <para>Circle—Constructs the best fitting circle around the input features.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "RIGHT_ANGLES";

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>The maximum distance that the regularized footprint can deviate from the boundary of its originating feature. The specified value will be based on the linear units of the input feature's coordinate system.</para>
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
		public object Densification { get; set; }

		/// <summary>
		/// <para>Precision</para>
		/// <para>The precision of the spatial grid used in the regularization process. Valid values range from 0.05 to 0.25.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object Precision { get; set; } = "0.25";

		/// <summary>
		/// <para>Diagonal Penalty</para>
		/// <para>When the Right Angles and Diagonals method is used, this value dictates the likelihood of constructing right angles or diagonal edges between two adjoining segments. When the Any Angles method is used, this value dictates the likelihood of constructing diagonal edges that do not conform to the preferred edges determined by the tool's algorithm. If the penalty value is set to 0, the preferred edges will not be used, resulting in the production of a simplified irregular polygon. Generally, the higher the value, the less likely a diagonal edge will be constructed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object DiagonalPenalty { get; set; } = "1.5";

		/// <summary>
		/// <para>Minimum Radius</para>
		/// <para>The smallest radius allowed for a regularized circle. A value of 0 implies there is no minimum size limit. This option is only available with the Circle method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MinRadius { get; set; } = "0.1";

		/// <summary>
		/// <para>Maximum Radius</para>
		/// <para>The largest radius allowed for a regularized circular. This option is only available with the Circle method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaxRadius { get; set; } = "1000000";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegularizeBuildingFootprint SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Right Angles—Constructs shapes comprised of 90° angles between adjoining edges.</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES")]
			[Description("Right Angles")]
			Right_Angles,

			/// <summary>
			/// <para>Right Angles and Diagonals—Constructs shapes comprised of 45° and 90° angles between adjoining edges.</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES_AND_DIAGONALS")]
			[Description("Right Angles and Diagonals")]
			Right_Angles_and_Diagonals,

			/// <summary>
			/// <para>Any Angles—Constructs shapes that form any angles between adjoining edges.</para>
			/// </summary>
			[GPValue("ANY_ANGLE")]
			[Description("Any Angles")]
			Any_Angles,

			/// <summary>
			/// <para>Circle—Constructs the best fitting circle around the input features.</para>
			/// </summary>
			[GPValue("CIRCLE")]
			[Description("Circle")]
			Circle,

		}

#endregion
	}
}
