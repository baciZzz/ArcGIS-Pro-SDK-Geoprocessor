using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Create Buffers</para>
	/// <para>Create Buffers</para>
	/// <para>Creates buffers around input features to a specified distance.</para>
	/// </summary>
	public class CreateBuffers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, polyline, or polygon features to be buffered.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>A new feature class of buffered results.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>Specifies the method that will be used to create the buffer.</para>
		/// <para>Geodesic— Buffers are created using a shape-preserving geodesic buffer method regardless of the input coordinate system. This is the default.</para>
		/// <para>Planar— If the input features are in a projected coordinate system, Euclidean buffers are created. If the input features are in a geographic coordinate system, geodesic buffers are created. The Output Coordinate System environment setting can be used to specify a coordinate system.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="BufferType">
		/// <para>Buffer Type</para>
		/// <para>Specifies how the buffer distance will be defined.</para>
		/// <para>Distance—Apply the same linear distance to all features.</para>
		/// <para>Field—Select a numeric or string field to represent the buffer distance.</para>
		/// <para>Expression—Build an equation using fields, constants, and mathematical operations to represent the buffer distance.</para>
		/// <para><see cref="BufferTypeEnum"/></para>
		/// </param>
		public CreateBuffers(object InputLayer, object OutFeatureClass, object Method, object BufferType)
		{
			this.InputLayer = InputLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.Method = Method;
			this.BufferType = BufferType;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Buffers</para>
		/// </summary>
		public override string DisplayName() => "Create Buffers";

		/// <summary>
		/// <para>Tool Name : CreateBuffers</para>
		/// </summary>
		public override string ToolName() => "CreateBuffers";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CreateBuffers</para>
		/// </summary>
		public override string ExcuteName() => "gapro.CreateBuffers";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutFeatureClass, Method, BufferType, BufferField!, BufferDistance!, BufferExpression!, DissolveOption!, DissolveFields!, SummaryFields!, Multipart! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, polyline, or polygon features to be buffered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>A new feature class of buffered results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the method that will be used to create the buffer.</para>
		/// <para>Geodesic— Buffers are created using a shape-preserving geodesic buffer method regardless of the input coordinate system. This is the default.</para>
		/// <para>Planar— If the input features are in a projected coordinate system, Euclidean buffers are created. If the input features are in a geographic coordinate system, geodesic buffers are created. The Output Coordinate System environment setting can be used to specify a coordinate system.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Buffer Type</para>
		/// <para>Specifies how the buffer distance will be defined.</para>
		/// <para>Distance—Apply the same linear distance to all features.</para>
		/// <para>Field—Select a numeric or string field to represent the buffer distance.</para>
		/// <para>Expression—Build an equation using fields, constants, and mathematical operations to represent the buffer distance.</para>
		/// <para><see cref="BufferTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferType { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Buffer Field</para>
		/// <para>The field that contains the buffer distance for each feature. If a field value is a number, it is assumed that the distance is in the linear unit of the Input Layer spatial reference, unless the Input Layer is in a geographic coordinate system, in which case, the value is assumed to be in meters. If the linear unit specified in the field values is invalid or not recognized, the linear unit of the input features' spatial reference will be used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object? BufferField { get; set; }

		/// <summary>
		/// <para>Buffer Distance</para>
		/// <para>The distance around the input features that will be buffered. Distance can be expressed in meters, kilometers, feet, yards, miles, or nautical miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? BufferDistance { get; set; }

		/// <summary>
		/// <para>Buffer Expression</para>
		/// <para>An equation using fields and mathematical operators that will be applied as a buffer to each feature. Fields must be numeric, and the expression can include [+ - * / ] operators and multiple fields. Calculated values are applied in meters unless otherwise specified. For example, apply a buffer that multiples a numeric field named distance in kilometers by 2 and adds 15 meters.</para>
		/// <para>Use an Arcade expression such as as_kilometers($feature[&quot;distance&quot;]) * 2 + as_meters(15).</para>
		/// <para>If the layer is added to the map, the Fields and Helpers filters can be used to build an expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? BufferExpression { get; set; }

		/// <summary>
		/// <para>Dissolve Option</para>
		/// <para>Specifies the dissolve option that will be used to remove buffer overlap.</para>
		/// <para>None—An individual buffer for each feature will be maintained regardless of overlap. This is the default.</para>
		/// <para>All—All buffers will be dissolved together into a single feature, removing any overlap.</para>
		/// <para>List—Any buffers sharing attribute values in the listed fields (carried over from the input features) will be dissolved.</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DissolveOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Dissolve Fields</para>
		/// <para>A list of one or more fields from the input features on which output buffers will be dissolved. Any buffers sharing attribute values in the listed fields will be dissolved. This option is only required when Dissolve Option is List.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? DissolveFields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>Specifies statistics that can be applied to numeric and string fields. If left empty, only count will be calculated. These statistics are only applied when Dissolve Option is List or All.</para>
		/// <para>Count—The number of nonnull values. It can be used on numeric fields or strings. The count of [null, 0, 2] is 2.</para>
		/// <para>Sum—The sum of numeric values in a field. The sum of [null, null, 3] is 3.</para>
		/// <para>Mean—The mean of numeric values. The mean of [0, 2, null] is 1.</para>
		/// <para>Min—The minimum value of a numeric field. The minimum of [0, 2, null] is 0.</para>
		/// <para>Max—The maximum value of a numeric field. The maximum value of [0, 2, null] is 2.</para>
		/// <para>Standard Deviation—The standard deviation of a numeric field. The standard deviation of [1] is null. The standard deviation of [null, 1,1,1] is null.</para>
		/// <para>Variance—The variance of a numeric field in a track. The variance of [1] is null. The variance of [null, 1, 1, 1] is null.</para>
		/// <para>Range—The range of a numeric field. This is calculated as the minimum value subtracted from the maximum value. The range of [0, null, 1] is 1. The range of [null, 4] is 0.</para>
		/// <para>Any—A sample string from a field of type string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Multipart</para>
		/// <para>Specifies whether multipart features will be created.</para>
		/// <para>Checked—Output multipart features will be created where appropriate.</para>
		/// <para>Unchecked—Instead of creating multipart features, individual features will be created for each part. This is the default.</para>
		/// <para><see cref="MultipartEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Multipart { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateBuffers SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Planar— If the input features are in a projected coordinate system, Euclidean buffers are created. If the input features are in a geographic coordinate system, geodesic buffers are created. The Output Coordinate System environment setting can be used to specify a coordinate system.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic— Buffers are created using a shape-preserving geodesic buffer method regardless of the input coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Buffer Type</para>
		/// </summary>
		public enum BufferTypeEnum 
		{
			/// <summary>
			/// <para>Distance—Apply the same linear distance to all features.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

			/// <summary>
			/// <para>Field—Select a numeric or string field to represent the buffer distance.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

			/// <summary>
			/// <para>Expression—Build an equation using fields, constants, and mathematical operations to represent the buffer distance.</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("Expression")]
			Expression,

		}

		/// <summary>
		/// <para>Dissolve Option</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>None—An individual buffer for each feature will be maintained regardless of overlap. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>All—All buffers will be dissolved together into a single feature, removing any overlap.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>List—Any buffers sharing attribute values in the listed fields (carried over from the input features) will be dissolved.</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("List")]
			List,

		}

		/// <summary>
		/// <para>Multipart</para>
		/// </summary>
		public enum MultipartEnum 
		{
			/// <summary>
			/// <para>Checked—Output multipart features will be created where appropriate.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_PART")]
			MULTI_PART,

			/// <summary>
			/// <para>Unchecked—Instead of creating multipart features, individual features will be created for each part. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_PART")]
			SINGLE_PART,

		}

#endregion
	}
}
