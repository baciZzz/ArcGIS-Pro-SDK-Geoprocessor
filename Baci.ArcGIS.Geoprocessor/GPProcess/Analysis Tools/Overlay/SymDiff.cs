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
	/// <para>Symmetrical Difference</para>
	/// <para>Symmetrical Difference</para>
	/// <para>Computes a geometric intersection of the input and update features, returning the input features and update features that do not overlap. Features or portions of features in the input and update features that do not overlap will be written to the output feature class.</para>
	/// </summary>
	public class SymDiff : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class or layer.</para>
		/// </param>
		/// <param name="UpdateFeatures">
		/// <para>Update Features</para>
		/// <para>The update feature class or layer. The geometry type must be the same as that of the input feature class or layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class to which the results will be written.</para>
		/// </param>
		public SymDiff(object InFeatures, object UpdateFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.UpdateFeatures = UpdateFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Symmetrical Difference</para>
		/// </summary>
		public override string DisplayName() => "Symmetrical Difference";

		/// <summary>
		/// <para>Tool Name : SymDiff</para>
		/// </summary>
		public override string ToolName() => "SymDiff";

		/// <summary>
		/// <para>Tool Excute Name : analysis.SymDiff</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SymDiff";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, UpdateFeatures, OutFeatureClass, JoinAttributes, ClusterTolerance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class or layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Update Features</para>
		/// <para>The update feature class or layer. The geometry type must be the same as that of the input feature class or layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object UpdateFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class to which the results will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attributes to Join</para>
		/// <para>Specifies the attributes that will be transferred to the output feature class.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SymDiff SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object parallelProcessingFactor = null, bool? qualifiedFieldNames = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes to Join</para>
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

#endregion
	}
}
