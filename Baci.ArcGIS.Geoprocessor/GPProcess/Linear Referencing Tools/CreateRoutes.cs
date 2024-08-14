using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LinearReferencingTools
{
	/// <summary>
	/// <para>Create Routes</para>
	/// <para>Creates routes from existing lines. The input line features that share a common identifier are merged to create a single route.</para>
	/// </summary>
	public class CreateRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The features from which routes will be created.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Route Feature Class</para>
		/// <para>The feature class to be created. It can be a shapefile or a geodatabase feature class.</para>
		/// </param>
		/// <param name="MeasureSource">
		/// <para>Measure Source</para>
		/// <para>Specifies how route measures will be obtained.</para>
		/// <para>Length of features—The geometric length of the input features will be used to accumulate the measures. This is the default.</para>
		/// <para>Values from a single field—The value stored in a single field will be used to accumulate the measures.</para>
		/// <para>Values from two fields—The values stored in both from- and to- measure fields will be used to set the measures.</para>
		/// <para><see cref="MeasureSourceEnum"/></para>
		/// </param>
		public CreateRoutes(object InLineFeatures, object RouteIdField, object OutFeatureClass, object MeasureSource)
		{
			this.InLineFeatures = InLineFeatures;
			this.RouteIdField = RouteIdField;
			this.OutFeatureClass = OutFeatureClass;
			this.MeasureSource = MeasureSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Routes</para>
		/// </summary>
		public override string DisplayName => "Create Routes";

		/// <summary>
		/// <para>Tool Name : CreateRoutes</para>
		/// </summary>
		public override string ToolName => "CreateRoutes";

		/// <summary>
		/// <para>Tool Excute Name : lr.CreateRoutes</para>
		/// </summary>
		public override string ExcuteName => "lr.CreateRoutes";

		/// <summary>
		/// <para>Toolbox Display Name : Linear Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Linear Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : lr</para>
		/// </summary>
		public override string ToolboxAlise => "lr";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "ZDomain", "configKeyword", "extent", "outputCoordinateSystem", "outputZFlag", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLineFeatures, RouteIdField, OutFeatureClass, MeasureSource, FromMeasureField!, ToMeasureField!, CoordinatePriority!, MeasureFactor!, MeasureOffset!, IgnoreGaps!, BuildIndex! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The features from which routes will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Output Route Feature Class</para>
		/// <para>The feature class to be created. It can be a shapefile or a geodatabase feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Measure Source</para>
		/// <para>Specifies how route measures will be obtained.</para>
		/// <para>Length of features—The geometric length of the input features will be used to accumulate the measures. This is the default.</para>
		/// <para>Values from a single field—The value stored in a single field will be used to accumulate the measures.</para>
		/// <para>Values from two fields—The values stored in both from- and to- measure fields will be used to set the measures.</para>
		/// <para><see cref="MeasureSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MeasureSource { get; set; } = "LENGTH";

		/// <summary>
		/// <para>From-Measure Field</para>
		/// <para>A field containing measure values. This field must be numeric and is required when the measure source is Values from a single field or Values from two fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? FromMeasureField { get; set; }

		/// <summary>
		/// <para>To-Measure Field</para>
		/// <para>A field containing measure values. This field must be numeric and is required when the measure source is Values from two fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Coordinate Priority</para>
		/// <para>The position from which measures will be accumulated for each output route. This parameter is ignored when the measure source is Values from two fields.</para>
		/// <para>Upper left corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s upper left corner. This is the default.</para>
		/// <para>Lower left corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s lower left corner.</para>
		/// <para>Upper right corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s upper right corner.</para>
		/// <para>Lower right corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s lower right corner.</para>
		/// <para><see cref="CoordinatePriorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CoordinatePriority { get; set; } = "UPPER_LEFT";

		/// <summary>
		/// <para>Measure Factor</para>
		/// <para>A value multiplied by the measure length of each input line before they are merged to create route measures. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MeasureFactor { get; set; } = "1";

		/// <summary>
		/// <para>Measure Offset</para>
		/// <para>A value added to the route measures after the input lines have been merged to create a route. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MeasureOffset { get; set; } = "0";

		/// <summary>
		/// <para>Ignore spatial gaps</para>
		/// <para>Specifies whether spatial gaps will be ignored when calculating the measures on disjointed routes. This parameter is applicable when the measure source is Length of features or Values from a single field.</para>
		/// <para>Checked—Spatial gaps will be ignored. Measure values will be continuous for disjointed routes. This is the default.</para>
		/// <para>Unchecked—Do not ignore spatial gaps. The measure values on disjointed routes will have gaps. The gap distance is calculated using the straight-line distance between the endpoints of the disjointed parts.</para>
		/// <para><see cref="IgnoreGapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreGaps { get; set; } = "true";

		/// <summary>
		/// <para>Build index</para>
		/// <para>Specifies whether an attribute index will be created for the route identifier field that is written to the output route feature class.</para>
		/// <para>Checked—Create an attribute index. This is the default.</para>
		/// <para>Unchecked—Do not create an attribute index.</para>
		/// <para><see cref="BuildIndexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildIndex { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRoutes SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? ZDomain = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputZFlag = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Measure Source</para>
		/// </summary>
		public enum MeasureSourceEnum 
		{
			/// <summary>
			/// <para>Length of features—The geometric length of the input features will be used to accumulate the measures. This is the default.</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("Length of features")]
			Length_of_features,

			/// <summary>
			/// <para>Values from a single field—The value stored in a single field will be used to accumulate the measures.</para>
			/// </summary>
			[GPValue("ONE_FIELD")]
			[Description("Values from a single field")]
			Values_from_a_single_field,

			/// <summary>
			/// <para>Values from two fields—The values stored in both from- and to- measure fields will be used to set the measures.</para>
			/// </summary>
			[GPValue("TWO_FIELDS")]
			[Description("Values from two fields")]
			Values_from_two_fields,

		}

		/// <summary>
		/// <para>Coordinate Priority</para>
		/// </summary>
		public enum CoordinatePriorityEnum 
		{
			/// <summary>
			/// <para>Upper left corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s upper left corner. This is the default.</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("Upper left corner")]
			Upper_left_corner,

			/// <summary>
			/// <para>Lower left corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s lower left corner.</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("Lower left corner")]
			Lower_left_corner,

			/// <summary>
			/// <para>Upper right corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s upper right corner.</para>
			/// </summary>
			[GPValue("UPPER_RIGHT")]
			[Description("Upper right corner")]
			Upper_right_corner,

			/// <summary>
			/// <para>Lower right corner—Measures will be accumulated from the point closest to the minimum bounding rectangle&apos;s lower right corner.</para>
			/// </summary>
			[GPValue("LOWER_RIGHT")]
			[Description("Lower right corner")]
			Lower_right_corner,

		}

		/// <summary>
		/// <para>Ignore spatial gaps</para>
		/// </summary>
		public enum IgnoreGapsEnum 
		{
			/// <summary>
			/// <para>Checked—Spatial gaps will be ignored. Measure values will be continuous for disjointed routes. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE")]
			IGNORE,

			/// <summary>
			/// <para>Unchecked—Do not ignore spatial gaps. The measure values on disjointed routes will have gaps. The gap distance is calculated using the straight-line distance between the endpoints of the disjointed parts.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_IGNORE")]
			NO_IGNORE,

		}

		/// <summary>
		/// <para>Build index</para>
		/// </summary>
		public enum BuildIndexEnum 
		{
			/// <summary>
			/// <para>Checked—Create an attribute index. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INDEX")]
			INDEX,

			/// <summary>
			/// <para>Unchecked—Do not create an attribute index.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INDEX")]
			NO_INDEX,

		}

#endregion
	}
}
