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
	/// <para>Multiple Ring Buffer</para>
	/// <para>Creates multiple buffers at specified distances around the input features. These buffers can optionally be merged and dissolved using the buffer distance values to create nonoverlapping buffers.</para>
	/// </summary>
	public class MultipleRingBuffer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The input point, line, or polygon features to be buffered.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature class</para>
		/// <para>The output feature class that will contain multiple buffers.</para>
		/// </param>
		/// <param name="Distances">
		/// <para>Distances</para>
		/// <para>The list of buffer distances.</para>
		/// </param>
		public MultipleRingBuffer(object InputFeatures, object OutputFeatureClass, object Distances)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.Distances = Distances;
		}

		/// <summary>
		/// <para>Tool Display Name : Multiple Ring Buffer</para>
		/// </summary>
		public override string DisplayName => "Multiple Ring Buffer";

		/// <summary>
		/// <para>Tool Name : MultipleRingBuffer</para>
		/// </summary>
		public override string ToolName => "MultipleRingBuffer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.MultipleRingBuffer</para>
		/// </summary>
		public override string ExcuteName => "analysis.MultipleRingBuffer";

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
		public override string[] ValidEnvironments => new string[] { "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatures, OutputFeatureClass, Distances, BufferUnit, FieldName, DissolveOption, OutsidePolygonsOnly };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point, line, or polygon features to be buffered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature class</para>
		/// <para>The output feature class that will contain multiple buffers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>The list of buffer distances.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Distances { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>Specifies the linear unit that will be used with the distance values.</para>
		/// <para>Default—The linear unit of the input features&apos; spatial reference will be used. If the Output Coordinate System geoprocessing environment has been set, the linear unit of the environment will be used. The linear unit is ignored if the input features have an unknown or undefined spatial reference. This is the default.</para>
		/// <para>Inches—The unit will be inches.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Nautical miles—The unit will be nautical miles.</para>
		/// <para>Millimeters—The unit will be millimeters.</para>
		/// <para>Centimeters—The unit will be centimeters.</para>
		/// <para>Decimeters—The unit will be decimeters.</para>
		/// <para>Meters—The unit will be meters.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Decimal degrees—The unit will be decimal degrees.</para>
		/// <para>Points—The unit will be points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferUnit { get; set; } = "Default";

		/// <summary>
		/// <para>Buffer Distance Field Name</para>
		/// <para>The name of the field in the output feature class that will store the buffer distance used to create each buffer feature. The default is distance. The field will be of type Double.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FieldName { get; set; } = "distance";

		/// <summary>
		/// <para>Dissolve Option</para>
		/// <para>Specifies whether buffers will be dissolved to resemble rings around the input features.</para>
		/// <para>Non-overlapping (rings)—Buffers will be dissolved to resemble rings around the input features that do not overlap (think of these as rings or donuts around the input features). The smallest buffer will cover the area of its input feature plus the buffer distance, and subsequent buffers will be rings around the smallest buffer that do not cover the area of the input feature or smaller buffers. All buffers of the same distance will be dissolved into a single feature. This is the default.</para>
		/// <para>Overlapping (disks)—Buffers will not be dissolved. All buffer areas will be maintained regardless of overlap. Each buffer will cover its input feature plus the area of any smaller buffers.</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DissolveOption { get; set; } = "ALL";

		/// <summary>
		/// <para>Outside Polygons Only</para>
		/// <para>Specifies whether the buffers will cover the input features. This parameter is valid only for polygon input features.</para>
		/// <para>Unchecked—Buffers will overlap or cover the input features. This is the default.</para>
		/// <para>Checked—Buffers will be rings around the input features, and will not overlap or cover the input features (the area inside the input polygon will be erased from the buffer).</para>
		/// <para><see cref="OutsidePolygonsOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OutsidePolygonsOnly { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultipleRingBuffer SetEnviroment(object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dissolve Option</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>Non-overlapping (rings)—Buffers will be dissolved to resemble rings around the input features that do not overlap (think of these as rings or donuts around the input features). The smallest buffer will cover the area of its input feature plus the buffer distance, and subsequent buffers will be rings around the smallest buffer that do not cover the area of the input feature or smaller buffers. All buffers of the same distance will be dissolved into a single feature. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("Non-overlapping (rings)")]
			ALL,

			/// <summary>
			/// <para>Overlapping (disks)—Buffers will not be dissolved. All buffer areas will be maintained regardless of overlap. Each buffer will cover its input feature plus the area of any smaller buffers.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("Overlapping (disks)")]
			NONE,

		}

		/// <summary>
		/// <para>Outside Polygons Only</para>
		/// </summary>
		public enum OutsidePolygonsOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Buffers will be rings around the input features, and will not overlap or cover the input features (the area inside the input polygon will be erased from the buffer).</para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTSIDE_ONLY")]
			OUTSIDE_ONLY,

			/// <summary>
			/// <para>Unchecked—Buffers will overlap or cover the input features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FULL")]
			FULL,

		}

#endregion
	}
}
