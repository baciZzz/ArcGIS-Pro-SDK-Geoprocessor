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
	/// <para>Buffer</para>
	/// <para>Creates buffer polygons around input features to a specified distance.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseBuffer"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseBuffer))]
	public class Buffer : AbstractGPProcess
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
		public Buffer(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : Buffer</para>
		/// </summary>
		public override string DisplayName => "Buffer";

		/// <summary>
		/// <para>Tool Name : Buffer</para>
		/// </summary>
		public override string ToolName => "Buffer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Buffer</para>
		/// </summary>
		public override string ExcuteName => "analysis.Buffer";

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
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, LineSide, LineEndType, DissolveOption, DissolveField, Method };

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
		/// <para>Side Type</para>
		/// <para>Specifies the sides of the input features that will be buffered.</para>
		/// <para>Full—For line input features, buffers will be generated on both sides of the line. For polygon input features, buffers will be generated around the polygon and will contain and overlap the area of the input features. For point input features, buffers will be generated around the point. This is the default.</para>
		/// <para>Left—For line input features, buffers will be generated on the topological left of the line. This option is not valid for polygon input features.</para>
		/// <para>Right—For line input features, buffers will be generated on the topological right of the line. This option is not valid for polygon input features.</para>
		/// <para>Exclude the input polygon from buffer—For polygon input features, buffers will be generated outside the input polygon only (the area inside the input polygon will be erased from the output buffer). This option is not valid for line input features.</para>
		/// <para>This optional parameter is not available with a Desktop Basic or Desktop Standard license.</para>
		/// <para><see cref="LineSideEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LineSide { get; set; } = "FULL";

		/// <summary>
		/// <para>End Type</para>
		/// <para>Specifies the shape of the buffer at the end of line input features. This parameter is not valid for polygon input features.</para>
		/// <para>Round—The ends of the buffer will be round, in the shape of a half circle. This is the default.</para>
		/// <para>Flat—The ends of the buffer will be flat, or squared, and will end at the endpoint of the input line feature.</para>
		/// <para>This optional parameter is not available with a Desktop Basic or Desktop Standard license.</para>
		/// <para><see cref="LineEndTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LineEndType { get; set; } = "ROUND";

		/// <summary>
		/// <para>Dissolve Type</para>
		/// <para>Specifies the type of dissolve to be performed to remove buffer overlap.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Buffer SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Side Type</para>
		/// </summary>
		public enum LineSideEnum 
		{
			/// <summary>
			/// <para>Full—For line input features, buffers will be generated on both sides of the line. For polygon input features, buffers will be generated around the polygon and will contain and overlap the area of the input features. For point input features, buffers will be generated around the point. This is the default.</para>
			/// </summary>
			[GPValue("FULL")]
			[Description("Full")]
			Full,

			/// <summary>
			/// <para>Left—For line input features, buffers will be generated on the topological left of the line. This option is not valid for polygon input features.</para>
			/// </summary>
			[GPValue("LEFT")]
			[Description("Left")]
			Left,

			/// <summary>
			/// <para>Right—For line input features, buffers will be generated on the topological right of the line. This option is not valid for polygon input features.</para>
			/// </summary>
			[GPValue("RIGHT")]
			[Description("Right")]
			Right,

			/// <summary>
			/// <para>Exclude the input polygon from buffer—For polygon input features, buffers will be generated outside the input polygon only (the area inside the input polygon will be erased from the output buffer). This option is not valid for line input features.</para>
			/// </summary>
			[GPValue("OUTSIDE_ONLY")]
			[Description("Exclude the input polygon from buffer")]
			Exclude_the_input_polygon_from_buffer,

		}

		/// <summary>
		/// <para>End Type</para>
		/// </summary>
		public enum LineEndTypeEnum 
		{
			/// <summary>
			/// <para>Round—The ends of the buffer will be round, in the shape of a half circle. This is the default.</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("Round")]
			Round,

			/// <summary>
			/// <para>Flat—The ends of the buffer will be flat, or squared, and will end at the endpoint of the input line feature.</para>
			/// </summary>
			[GPValue("FLAT")]
			[Description("Flat")]
			Flat,

		}

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
