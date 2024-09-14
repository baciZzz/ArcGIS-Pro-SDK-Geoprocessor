using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Pairwise Intersect</para>
	/// <para>Pairwise Intersect</para>
	/// <para>Computes a pairwise intersection of the input features. Features or portions of features that overlap between the input feature layers or feature classes are written to the output feature class. Pairwise intersection refers to selecting one feature from the first input and intersecting it with the features in the second input that it overlaps.</para>
	/// </summary>
	public class PairwiseIntersect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature classes or layers to intersect. Only two inputs are allowed.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		public PairwiseIntersect(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Pairwise Intersect</para>
		/// </summary>
		public override string DisplayName() => "Pairwise Intersect";

		/// <summary>
		/// <para>Tool Name : PairwiseIntersect</para>
		/// </summary>
		public override string ToolName() => "PairwiseIntersect";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseIntersect</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseIntersect";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "maintainCurveSegments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, JoinAttributes, ClusterTolerance, OutputType };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature classes or layers to intersect. Only two inputs are allowed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Join Attributes</para>
		/// <para>Specifies which attributes from the input features will be transferred to the output feature class.</para>
		/// <para>All attributes—All the attributes from the input features will be transferred to the output feature class. This is the default.</para>
		/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output feature class.</para>
		/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output feature class.</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The minimum distance separating all feature coordinates (nodes and vertices) as well as the distance a coordinate can move in x or y (or both).</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that this parameter not be modified. It has been removed from view in the tool dialog. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies the type of intersections to be returned.</para>
		/// <para>Same as input—The intersections returned will be the same geometry type as the input features with the lowest dimension geometry. If all inputs are polygons, the output feature class will contain polygons. If one or more of the inputs are lines and none of the inputs are points, the output will be lines. If one or more of the inputs are points, the output feature class will contain points. This is the default.</para>
		/// <para>Line—The intersections returned will be line. This is only valid if none of the inputs are points.</para>
		/// <para>Point—The intersections returned will be point. If the inputs are line or polygon, the output will be a multipoint feature class.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "INPUT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PairwiseIntersect SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object parallelProcessingFactor = null, bool? qualifiedFieldNames = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Join Attributes</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output feature class.</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("All attributes except feature IDs")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output feature class.</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("Only feature IDs")]
			Only_feature_IDs,

			/// <summary>
			/// <para>All attributes—All the attributes from the input features will be transferred to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All attributes")]
			All_attributes,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Same as input—The intersections returned will be the same geometry type as the input features with the lowest dimension geometry. If all inputs are polygons, the output feature class will contain polygons. If one or more of the inputs are lines and none of the inputs are points, the output will be lines. If one or more of the inputs are points, the output feature class will contain points. This is the default.</para>
			/// </summary>
			[GPValue("INPUT")]
			[Description("Same as input")]
			Same_as_input,

			/// <summary>
			/// <para>Line—The intersections returned will be line. This is only valid if none of the inputs are points.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

			/// <summary>
			/// <para>Point—The intersections returned will be point. If the inputs are line or polygon, the output will be a multipoint feature class.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

		}

#endregion
	}
}
