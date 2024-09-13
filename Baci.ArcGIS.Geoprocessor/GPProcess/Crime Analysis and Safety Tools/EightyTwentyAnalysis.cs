using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>80-20 Analysis</para>
	/// <para>80-20 Analysis</para>
	/// <para>Conducts an 80/20 analysis of features and creates point clusters, lines, or polygons based on the number of associated incidents. The tool calculates a cumulative percentage field to identify the locations where incidents are disproportionately occurring.</para>
	/// </summary>
	public class EightyTwentyAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Point Features</para>
		/// <para>The input point features that will be used to create clusters, lines, or polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// <para>When the Aggregation Method parameter is set to Cluster, the output will be a point feature class.</para>
		/// <para>When the Aggregation Method parameter is set to Closest Feature, the geometry type of the output will be the same as the Input Comparison Features parameter value.</para>
		/// </param>
		public EightyTwentyAnalysis(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 80-20 Analysis</para>
		/// </summary>
		public override string DisplayName() => "80-20 Analysis";

		/// <summary>
		/// <para>Tool Name : EightyTwentyAnalysis</para>
		/// </summary>
		public override string ToolName() => "EightyTwentyAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : ca.EightyTwentyAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "ca.EightyTwentyAnalysis";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, ClusterTolerance!, OutFields!, AggregationMethod!, InComparisonFeatures! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The input point features that will be used to create clusters, lines, or polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// <para>When the Aggregation Method parameter is set to Cluster, the output will be a point feature class.</para>
		/// <para>When the Aggregation Method parameter is set to Closest Feature, the geometry type of the output will be the same as the Input Comparison Features parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Cluster Tolerance</para>
		/// <para>The maximum distance separating points at which they will be considered part of the same cluster.</para>
		/// <para>If no cluster tolerance is specified, the tool will create a cluster where point features overlap.</para>
		/// <para>This parameter is active when the Aggregation Method parameter is set to Cluster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>The fields from the input features that will be transferred to the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Text", "Float", "Double", "Short", "Long", "Date")]
		public object? OutFields { get; set; }

		/// <summary>
		/// <para>Aggregation Method</para>
		/// <para>Specifies how the input point features will be aggregated.</para>
		/// <para>Cluster—The input point features will be clustered. This is the default.</para>
		/// <para>Closest Feature—The input point features will be aggregated to the closest comparison polygon or line feature.</para>
		/// <para><see cref="AggregationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AggregationMethod { get; set; } = "POINT_CLUSTER";

		/// <summary>
		/// <para>Input Comparison Features</para>
		/// <para>The comparison input polygon or line feature class by which the Input Point Features parameter value is aggregated.</para>
		/// <para>This parameter is active when the Aggregation Method parameter is set to Closest Feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object? InComparisonFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EightyTwentyAnalysis SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainAttachments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Aggregation Method</para>
		/// </summary>
		public enum AggregationMethodEnum 
		{
			/// <summary>
			/// <para>Cluster—The input point features will be clustered. This is the default.</para>
			/// </summary>
			[GPValue("POINT_CLUSTER")]
			[Description("Cluster")]
			Cluster,

			/// <summary>
			/// <para>Closest Feature—The input point features will be aggregated to the closest comparison polygon or line feature.</para>
			/// </summary>
			[GPValue("CLOSEST_FEATURE")]
			[Description("Closest Feature")]
			Closest_Feature,

		}

#endregion
	}
}
