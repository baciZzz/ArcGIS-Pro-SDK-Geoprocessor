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
	/// <para>Update</para>
	/// <para>Computes the geometric intersection of the Input Features and Update Features. The attributes and geometry of the input features are updated by the update features in the output feature class.</para>
	/// </summary>
	public class Update : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class or layer. The geometry type must be polygon.</para>
		/// </param>
		/// <param name="UpdateFeatures">
		/// <para>Update Features</para>
		/// <para>The features that will be used to update the input features. The geometry type must be polygon.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class to contain the results.</para>
		/// </param>
		public Update(object InFeatures, object UpdateFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.UpdateFeatures = UpdateFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Update</para>
		/// </summary>
		public override string DisplayName => "Update";

		/// <summary>
		/// <para>Tool Name : Update</para>
		/// </summary>
		public override string ToolName => "Update";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Update</para>
		/// </summary>
		public override string ExcuteName => "analysis.Update";

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
		public override object[] Parameters => new object[] { InFeatures, UpdateFeatures, OutFeatureClass, KeepBorders, ClusterTolerance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class or layer. The geometry type must be polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Update Features</para>
		/// <para>The features that will be used to update the input features. The geometry type must be polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object UpdateFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class to contain the results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Borders</para>
		/// <para>Specifies whether the boundary of the update polygon features will be kept.</para>
		/// <para>Checked—The outside border of the Update Features will be kept in the Output Feature Class. This is the default option.</para>
		/// <para>Unchecked—The outside border of the Update Features are dropped after they are inserted into the Input Features. Item values of the Update Features take precedence over Input Features attributes.</para>
		/// <para><see cref="KeepBordersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object KeepBorders { get; set; } = "true";

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The minimum distance separating all feature coordinates (nodes and vertices) as well as the distance a coordinate can move in X or Y (or both).</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that this parameter not be modified. It has been removed from view in the tool dialog. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Update SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , bool? qualifiedFieldNames = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Borders</para>
		/// </summary>
		public enum KeepBordersEnum 
		{
			/// <summary>
			/// <para>Checked—The outside border of the Update Features will be kept in the Output Feature Class. This is the default option.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BORDERS")]
			BORDERS,

			/// <summary>
			/// <para>Unchecked—The outside border of the Update Features are dropped after they are inserted into the Input Features. Item values of the Update Features take precedence over Input Features attributes.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BORDERS")]
			NO_BORDERS,

		}

#endregion
	}
}
