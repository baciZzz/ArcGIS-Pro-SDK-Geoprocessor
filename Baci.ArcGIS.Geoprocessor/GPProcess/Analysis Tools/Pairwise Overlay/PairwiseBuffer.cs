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
	/// <para>Pairwise Buffer</para>
	/// <para>Creates buffer polygons around input features to a specified distance using a parallel processing approach.</para>
	/// </summary>
	public class PairwiseBuffer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point, line, or polygon features to be buffered.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output buffers.</para>
		/// </param>
		/// <param name="BufferDistanceOrField">
		/// <para>Distance [value or field]</para>
		/// <para>The distance around the input features that will be buffered. Distances can be provided as either a value representing a linear distance or as a field from the input features that contains the distance to buffer each feature.</para>
		/// <para>If linear units are not specified or are entered as Unknown, the linear unit of the input features&apos; spatial reference is used.</para>
		/// </param>
		public PairwiseBuffer(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : Pairwise Buffer</para>
		/// </summary>
		public override string DisplayName() => "Pairwise Buffer";

		/// <summary>
		/// <para>Tool Name : PairwiseBuffer</para>
		/// </summary>
		public override string ToolName() => "PairwiseBuffer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseBuffer</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseBuffer";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, DissolveOption, DissolveField, Method, MaxDeviation };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point, line, or polygon features to be buffered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output buffers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance [value or field]</para>
		/// <para>The distance around the input features that will be buffered. Distances can be provided as either a value representing a linear distance or as a field from the input features that contains the distance to buffer each feature.</para>
		/// <para>If linear units are not specified or are entered as Unknown, the linear unit of the input features&apos; spatial reference is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistanceOrField { get; set; }

		/// <summary>
		/// <para>Dissolve Type</para>
		/// <para>Specifies the type of dissolve operation to be performed to remove buffer overlap.</para>
		/// <para>No Dissolve—An individual buffer for each feature will be maintained, regardless of overlap. This is the default.</para>
		/// <para>Dissolve all output features into a single feature—All buffers will be dissolved together into a single feature, removing any overlap.</para>
		/// <para>Dissolve features using the listed fields&apos; unique values or combination of values—Any buffers sharing attribute values in the listed fields (carried over from the input features) will be dissolved.</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DissolveOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Dissolve Field(s)</para>
		/// <para>The list of fields from the input features on which the output buffers will be dissolved. Any buffers sharing attribute values in the listed fields (carried over from the input features) will be dissolved.</para>
		/// <para>The Add Field button, which is only used in ModelBuilder, allows you to add expected fields to the Dissolve Field(s) list.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID")]
		public object DissolveField { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the method to use, planar or geodesic, to create the buffer.</para>
		/// <para>Planar—If the input features are in a projected coordinate system, Euclidean buffers will be created. If the input features are in a geographic coordinate system and the buffer distance is in linear units (meters, feet, and so forth, as opposed to angular units such as degrees), geodesic buffers will be created. This is the default. You can use the Output Coordinate System environment setting to specify the coordinate system to use. For example, if your input features are in a projected coordinate system, you can set the environment to a geographic coordinate system to create geodesic buffers.</para>
		/// <para>Geodesic (shape preserving)—All buffers will be created using a shape-preserving geodesic buffer method, regardless of the input coordinate system.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>The maximum distance the resulting output buffer polygon boundary will deviate from the true buffer boundary.</para>
		/// <para>The true buffer boundary is a curve. However, the resulting polygon boundary is a densified polyline. Using this parameter, you can control how the output polygon boundary approximates the true buffer boundary.</para>
		/// <para>If this parameter is not set or is set to 0, the tool will identify the maximum deviation. It is recommended that you use the default value. Performance degradation (in the tool and in subsequent analyses) may result from using a maximum offset deviation that is too small.</para>
		/// <para>See the Maximum Offset Deviation parameter information in the Densify tool documentation for details.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxDeviation { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PairwiseBuffer SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dissolve Type</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>No Dissolve—An individual buffer for each feature will be maintained, regardless of overlap. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No Dissolve")]
			No_Dissolve,

			/// <summary>
			/// <para>Dissolve all output features into a single feature—All buffers will be dissolved together into a single feature, removing any overlap.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("Dissolve all output features into a single feature")]
			Dissolve_all_output_features_into_a_single_feature,

			/// <summary>
			/// <para>Dissolve features using the listed fields&apos; unique values or combination of values—Any buffers sharing attribute values in the listed fields (carried over from the input features) will be dissolved.</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("Dissolve features using the listed fields' unique values or combination of values")]
			LIST,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Geodesic (shape preserving)—All buffers will be created using a shape-preserving geodesic buffer method, regardless of the input coordinate system.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic (shape preserving)")]
			GEODESIC,

			/// <summary>
			/// <para>Planar—If the input features are in a projected coordinate system, Euclidean buffers will be created. If the input features are in a geographic coordinate system and the buffer distance is in linear units (meters, feet, and so forth, as opposed to angular units such as degrees), geodesic buffers will be created. This is the default. You can use the Output Coordinate System environment setting to specify the coordinate system to use. For example, if your input features are in a projected coordinate system, you can set the environment to a geographic coordinate system to create geodesic buffers.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

		}

#endregion
	}
}
