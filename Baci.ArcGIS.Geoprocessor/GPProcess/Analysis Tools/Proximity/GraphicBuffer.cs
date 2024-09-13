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
	/// <para>Graphic Buffer</para>
	/// <para>Graphic Buffer</para>
	/// <para>Creates buffer polygons around input features to a specified distance. A number of cartographic shapes are available for buffer ends (caps) and corners (joins) when the buffer is generated around the feature.</para>
	/// </summary>
	public class GraphicBuffer : AbstractGPProcess
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
		/// <para>If linear units are not specified or are entered as Unknown, the linear unit of the input features&apos; spatial reference will be used.</para>
		/// </param>
		public GraphicBuffer(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : Graphic Buffer</para>
		/// </summary>
		public override string DisplayName() => "Graphic Buffer";

		/// <summary>
		/// <para>Tool Name : GraphicBuffer</para>
		/// </summary>
		public override string ToolName() => "GraphicBuffer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.GraphicBuffer</para>
		/// </summary>
		public override string ExcuteName() => "analysis.GraphicBuffer";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, LineCaps!, LineJoins!, MiterLimit!, MaxDeviation! };

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
		/// <para>If linear units are not specified or are entered as Unknown, the linear unit of the input features&apos; spatial reference will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistanceOrField { get; set; }

		/// <summary>
		/// <para>Caps Type</para>
		/// <para>Specifies the type of caps (ends) of the input features that will be buffered. This parameter is only supported for point and polygon features.</para>
		/// <para>Square—The output buffer will have a square cap around the end of the input segment. This is the default.</para>
		/// <para>Butt—The output buffer will have a cap perpendicular to the end of the input segment.</para>
		/// <para>Round—The output buffer will have a cap that is round at the end of the input segment.</para>
		/// <para><see cref="LineCapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineCaps { get; set; } = "SQUARE";

		/// <summary>
		/// <para>Join Type</para>
		/// <para>The shape of the buffer at corners where two segments join. This parameter is only supported for line and polygon features.</para>
		/// <para>Miter—Results in an output buffer feature that is a square or sharp shape around corners. For example, a square input polygon feature will have a square buffer feature. This is the default.</para>
		/// <para>Bevel—The output buffer feature for inner corners will be squared while the outer corner will be cut perpendicular to the furthest point of the corner.</para>
		/// <para>Round—The output buffer feature for inner corners will be squared while the outer corner will be round.</para>
		/// <para><see cref="LineJoinsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineJoins { get; set; } = "MITER";

		/// <summary>
		/// <para>Miter Limit</para>
		/// <para>Where line segments meet at a sharp angle and a Join Type of MITER has been specified, this parameter can be used to control how sharp corners in buffer output come to a point. In some cases, the outer angle where two lines join is quite large when using the MITER Join Type. This could cause the point of the corner to extend further than intended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MiterLimit { get; set; } = "10";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>The maximum distance the output buffer polygon boundary will deviate from the true ideal buffer boundary. The true buffer boundary is a curve, and the output polygon boundary is a densified polyline. Using this parameter, you can control how well the output polygon boundary approximates the true buffer boundary.</para>
		/// <para>If the parameter is not set or is set to 0, the tool will identify the maximum deviation. It is recommended that you use the default value. Performance degradation in the tool or in subsequent analysis can result from using a maximum offset deviation value that is too small.</para>
		/// <para>See the Maximum Offset Deviation parameter information in the Densify tool documentation for more details.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MaxDeviation { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GraphicBuffer SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Caps Type</para>
		/// </summary>
		public enum LineCapsEnum 
		{
			/// <summary>
			/// <para>Square—The output buffer will have a square cap around the end of the input segment. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Butt—The output buffer will have a cap perpendicular to the end of the input segment.</para>
			/// </summary>
			[GPValue("BUTT")]
			[Description("Butt")]
			Butt,

			/// <summary>
			/// <para>Round—The output buffer will have a cap that is round at the end of the input segment.</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("Round")]
			Round,

		}

		/// <summary>
		/// <para>Join Type</para>
		/// </summary>
		public enum LineJoinsEnum 
		{
			/// <summary>
			/// <para>Miter—Results in an output buffer feature that is a square or sharp shape around corners. For example, a square input polygon feature will have a square buffer feature. This is the default.</para>
			/// </summary>
			[GPValue("MITER")]
			[Description("Miter")]
			Miter,

			/// <summary>
			/// <para>Bevel—The output buffer feature for inner corners will be squared while the outer corner will be cut perpendicular to the furthest point of the corner.</para>
			/// </summary>
			[GPValue("BEVEL")]
			[Description("Bevel")]
			Bevel,

			/// <summary>
			/// <para>Round—The output buffer feature for inner corners will be squared while the outer corner will be round.</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("Round")]
			Round,

		}

#endregion
	}
}
