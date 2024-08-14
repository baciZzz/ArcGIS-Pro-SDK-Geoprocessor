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
	/// <para>Union</para>
	/// <para>Computes a geometric union of the input features. All features and their attributes will be written to the output feature class.</para>
	/// </summary>
	public class Union : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature classes or layers. When the distance between features is less than the cluster tolerance, the features with the lower rank will snap to the feature with the higher rank. The highest rank is one. All of the input features must be polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the results.</para>
		/// </param>
		public Union(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Union</para>
		/// </summary>
		public override string DisplayName => "Union";

		/// <summary>
		/// <para>Tool Name : Union</para>
		/// </summary>
		public override string ToolName => "Union";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Union</para>
		/// </summary>
		public override string ExcuteName => "analysis.Union";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, JoinAttributes, ClusterTolerance, Gaps };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature classes or layers. When the distance between features is less than the cluster tolerance, the features with the lower rank will snap to the feature with the higher rank. The highest rank is one. All of the input features must be polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attributes To Join</para>
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
		/// <para>The minimum distance separating all feature coordinates (nodes and vertices) as well as the distance a coordinate can move in X or Y (or both).</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that this parameter not be modified. It has been removed from view in the tool dialog. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Gaps Allowed</para>
		/// <para>Specifies whether a feature will be created for areas in the output that are completely enclosed by polygons.</para>
		/// <para>Gaps are areas in the output feature class that are completely enclosed by other polygons (created from the intersection of features or from existing holes in the input polygons). These areas are not invalid, but you can identify them for analysis. To identify the gaps in the output, uncheck this parameter; a feature will be created in these areas. To select these features, query the output feature class based on all the input feature&apos;s FID values being equal to -1.</para>
		/// <para>Checked—A feature will not be created for an area in the output that is completely enclosed by polygons. This is the default.</para>
		/// <para>Unchecked—A feature will be created for an area in the output that is completely enclosed by polygons. This feature will have no attribute values and will have a FID value of -1.</para>
		/// <para><see cref="GapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Gaps { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Union SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , bool? qualifiedFieldNames = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes To Join</para>
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
		/// <para>Gaps Allowed</para>
		/// </summary>
		public enum GapsEnum 
		{
			/// <summary>
			/// <para>Checked—A feature will not be created for an area in the output that is completely enclosed by polygons. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GAPS")]
			GAPS,

			/// <summary>
			/// <para>Unchecked—A feature will be created for an area in the output that is completely enclosed by polygons. This feature will have no attribute values and will have a FID value of -1.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GAPS")]
			NO_GAPS,

		}

#endregion
	}
}
