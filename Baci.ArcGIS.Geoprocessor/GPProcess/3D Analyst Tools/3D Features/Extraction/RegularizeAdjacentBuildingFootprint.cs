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
	/// <para>Regularize Adjacent Building Footprint</para>
	/// <para>Regularizes building footprints that have common boundaries.</para>
	/// </summary>
	public class RegularizeAdjacentBuildingFootprint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features to process.</para>
		/// </param>
		/// <param name="Group">
		/// <para>Grouping Field</para>
		/// <para>The field that will be used to determine which features share coincident, non-overlapping boundaries.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public RegularizeAdjacentBuildingFootprint(object InFeatures, object Group, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.Group = Group;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Regularize Adjacent Building Footprint</para>
		/// </summary>
		public override string DisplayName => "Regularize Adjacent Building Footprint";

		/// <summary>
		/// <para>Tool Name : RegularizeAdjacentBuildingFootprint</para>
		/// </summary>
		public override string ToolName => "RegularizeAdjacentBuildingFootprint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RegularizeAdjacentBuildingFootprint</para>
		/// </summary>
		public override string ExcuteName => "3d.RegularizeAdjacentBuildingFootprint";

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
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, Group, OutFeatureClass, Method, Tolerance, Precision, AngularLimit };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Grouping Field</para>
		/// <para>The field that will be used to determine which features share coincident, non-overlapping boundaries.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Text")]
		public object Group { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>The method that will be used to regularize the input features.</para>
		/// <para>Right angles—Identifies the best line segments that fit the input feature vertices along 90° and 180° angles.</para>
		/// <para>Right angles and diagonals—Identifies the best line segments that fit the input feature vertices along 90°, 135°, and 180° interior angles.</para>
		/// <para>Any angles—Identifies the best fit line that falls along any angle while reducing the overall vertex count of the input features.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "RIGHT_ANGLES";

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>The maximum distance that the regularized footprint can deviate from the boundary of its originating feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Tolerance { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Precision</para>
		/// <para>The precision of the spatial grid used in the regularization process. Valid values range from 0.05 to 0.25.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.050000000000000003, Max = 0.25)]
		public object Precision { get; set; } = "0.25";

		/// <summary>
		/// <para>Angular Deviation Limit</para>
		/// <para>The maximum deviation of the best fit line's interior angles that will be tolerated when using the Right Angles and Diagonals (RIGHT_ANGLES_AND_DIAGONALS) method. This value should generally be kept to less than 5° to obtain best results. This parameter is disabled for other regularization methods.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.001, Max = 15)]
		public object AngularLimit { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegularizeAdjacentBuildingFootprint SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Any angles—Identifies the best fit line that falls along any angle while reducing the overall vertex count of the input features.</para>
			/// </summary>
			[GPValue("ANY_ANGLES")]
			[Description("Any angles")]
			Any_angles,

			/// <summary>
			/// <para>Right angles—Identifies the best line segments that fit the input feature vertices along 90° and 180° angles.</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES")]
			[Description("Right angles")]
			Right_angles,

			/// <summary>
			/// <para>Right angles and diagonals—Identifies the best line segments that fit the input feature vertices along 90°, 135°, and 180° interior angles.</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES_AND_DIAGONALS")]
			[Description("Right angles and diagonals")]
			Right_angles_and_diagonals,

		}

#endregion
	}
}
