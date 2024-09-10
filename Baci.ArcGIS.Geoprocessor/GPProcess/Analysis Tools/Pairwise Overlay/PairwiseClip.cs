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
	/// <para>Pairwise Clip</para>
	/// <para>Extracts input features that overlay the clip features.</para>
	/// </summary>
	public class PairwiseClip : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to be clipped.</para>
		/// </param>
		/// <param name="ClipFeatures">
		/// <para>Clip Features</para>
		/// <para>The features to use to clip the input features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class to be created.</para>
		/// </param>
		public PairwiseClip(object InFeatures, object ClipFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.ClipFeatures = ClipFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Pairwise Clip</para>
		/// </summary>
		public override string DisplayName() => "Pairwise Clip";

		/// <summary>
		/// <para>Tool Name : PairwiseClip</para>
		/// </summary>
		public override string ToolName() => "PairwiseClip";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseClip</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseClip";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "maintainCurveSegments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ClipFeatures, OutFeatureClass, ClusterTolerance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to be clipped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>The features to use to clip the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object ClipFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The minimum distance separating all feature coordinates as well as the distance a coordinate can move in X or Y (or both). Set the value higher for data with less coordinate accuracy and lower for data with extremely high accuracy.</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that this parameter not be modified. It has been removed from view in the tool dialog. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PairwiseClip SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
