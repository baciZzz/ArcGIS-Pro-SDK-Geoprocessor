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
	/// <para>Identity</para>
	/// <para>Identity</para>
	/// <para>Computes a geometric intersection of the input features and identity features. The input features or portions thereof that overlap identity features will get the attributes of those identity features.</para>
	/// </summary>
	public class Identity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class or layer.</para>
		/// </param>
		/// <param name="IdentityFeatures">
		/// <para>Identity Features</para>
		/// <para>The identity feature class or layer. It must be polygon or the same geometry type as the input features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be created and to which the results will be written.</para>
		/// </param>
		public Identity(object InFeatures, object IdentityFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.IdentityFeatures = IdentityFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Identity</para>
		/// </summary>
		public override string DisplayName() => "Identity";

		/// <summary>
		/// <para>Tool Name : Identity</para>
		/// </summary>
		public override string ToolName() => "Identity";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Identity</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Identity";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames", "transferGDBAttributeProperties" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, IdentityFeatures, OutFeatureClass, JoinAttributes!, ClusterTolerance!, Relationship! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class or layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Identity Features</para>
		/// <para>The identity feature class or layer. It must be polygon or the same geometry type as the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object IdentityFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be created and to which the results will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>Specifies how attributes will be transferred to the output feature class.</para>
		/// <para>All attributes—All the attributes (including FIDs) from the input features, as well as the identity features, will be transferred to the output features. If no intersection is found, the identity feature values will not be transferred to the output (their values will be set to empty strings or 0) and the identity feature FID will be -1. This is the default.</para>
		/// <para>All attributes except feature IDs—All the attributes except the FID from the input features and identity features will be transferred to the output features. If no intersection is found, the identity feature values will not be transferred to the output (their values will be set to empty strings or 0).</para>
		/// <para>Only feature IDs—All the attributes from the input features and only the FID from the identity features will be transferred to the output features. If no intersection is found, the identity features&apos; FID attribute value in the output will be -1.</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The minimum distance separating all feature coordinates (nodes and vertices) as well as the distance a coordinate can move in x or y (or both).</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that you do not modify this parameter. It has been removed from view on the tool dialog box. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Keep relationships</para>
		/// <para>Specifies whether additional spatial relationships between the Input Features and Identity Features parameter values will be written to the output. This only applies when the geometry type of the Input Features parameter value is line and the geometry type of the Identity Features parameter value is polygon.</para>
		/// <para>Unchecked—No additional spatial relationship will be written to the output.</para>
		/// <para>Checked—The output line features will contain two additional fields, LEFT_poly and RIGHT_poly. These fields contain the feature ID of the Identity Features parameter value on the left and right side of the line feature.</para>
		/// <para><see cref="RelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Relationship { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Identity SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? parallelProcessingFactor = null, bool? qualifiedFieldNames = null, bool? transferGDBAttributeProperties = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames, transferGDBAttributeProperties: transferGDBAttributeProperties);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes To Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>All attributes except feature IDs—All the attributes except the FID from the input features and identity features will be transferred to the output features. If no intersection is found, the identity feature values will not be transferred to the output (their values will be set to empty strings or 0).</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("All attributes except feature IDs")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>Only feature IDs—All the attributes from the input features and only the FID from the identity features will be transferred to the output features. If no intersection is found, the identity features&apos; FID attribute value in the output will be -1.</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("Only feature IDs")]
			Only_feature_IDs,

			/// <summary>
			/// <para>All attributes—All the attributes (including FIDs) from the input features, as well as the identity features, will be transferred to the output features. If no intersection is found, the identity feature values will not be transferred to the output (their values will be set to empty strings or 0) and the identity feature FID will be -1. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All attributes")]
			All_attributes,

		}

		/// <summary>
		/// <para>Keep relationships</para>
		/// </summary>
		public enum RelationshipEnum 
		{
			/// <summary>
			/// <para>Checked—The output line features will contain two additional fields, LEFT_poly and RIGHT_poly. These fields contain the feature ID of the Identity Features parameter value on the left and right side of the line feature.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_RELATIONSHIPS")]
			KEEP_RELATIONSHIPS,

			/// <summary>
			/// <para>Unchecked—No additional spatial relationship will be written to the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RELATIONSHIPS")]
			NO_RELATIONSHIPS,

		}

#endregion
	}
}
