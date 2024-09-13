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
	/// <para>Calibrate Routes</para>
	/// <para>Calibrate Routes</para>
	/// <para>Recalculates route measures using points.</para>
	/// </summary>
	public class CalibrateRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The route features to be calibrated.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route. This field can be numeric or character.</para>
		/// </param>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>The point features used to calibrate the routes.</para>
		/// </param>
		/// <param name="PointIdField">
		/// <para>Point Identifier Field</para>
		/// <para>The field that identifies the route on which each calibration point is located. The values in this field match those in the route identifier field. This field can be numeric or character.</para>
		/// </param>
		/// <param name="MeasureField">
		/// <para>Measure Field</para>
		/// <para>The field containing the measure value for each calibration point. This field must be numeric.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Route Feature Class</para>
		/// <para>The feature class to be created. It can be a shapefile or a geodatabase feature class.</para>
		/// </param>
		public CalibrateRoutes(object InRouteFeatures, object RouteIdField, object InPointFeatures, object PointIdField, object MeasureField, object OutFeatureClass)
		{
			this.InRouteFeatures = InRouteFeatures;
			this.RouteIdField = RouteIdField;
			this.InPointFeatures = InPointFeatures;
			this.PointIdField = PointIdField;
			this.MeasureField = MeasureField;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Calibrate Routes</para>
		/// </summary>
		public override string DisplayName() => "Calibrate Routes";

		/// <summary>
		/// <para>Tool Name : CalibrateRoutes</para>
		/// </summary>
		public override string ToolName() => "CalibrateRoutes";

		/// <summary>
		/// <para>Tool Excute Name : lr.CalibrateRoutes</para>
		/// </summary>
		public override string ExcuteName() => "lr.CalibrateRoutes";

		/// <summary>
		/// <para>Toolbox Display Name : Linear Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Linear Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : lr</para>
		/// </summary>
		public override string ToolboxAlise() => "lr";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "ZDomain", "configKeyword", "extent", "outputCoordinateSystem", "outputZFlag", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, RouteIdField, InPointFeatures, PointIdField, MeasureField, OutFeatureClass, CalibrateMethod!, SearchRadius!, InterpolateBetween!, ExtrapolateBefore!, ExtrapolateAfter!, IgnoreGaps!, KeepAllRoutes!, BuildIndex! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The route features to be calibrated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Route Identifier Field</para>
		/// <para>The field containing values that uniquely identify each route. This field can be numeric or character.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The point features used to calibrate the routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Point Identifier Field</para>
		/// <para>The field that identifies the route on which each calibration point is located. The values in this field match those in the route identifier field. This field can be numeric or character.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4A4F70B0-913C-4A82-A33F-E190FFA409EA}")]
		public object PointIdField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>The field containing the measure value for each calibration point. This field must be numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{C06E2425-30D9-4C9D-8CD3-7FE243B3AFCB}")]
		public object MeasureField { get; set; }

		/// <summary>
		/// <para>Output Route Feature Class</para>
		/// <para>The feature class to be created. It can be a shapefile or a geodatabase feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Measure Calculation Method</para>
		/// <para>Specifies how route measures will be recalculated.</para>
		/// <para>Distance—Measures will be recalculated using the shortest path distance between the calibration points. This is the default.</para>
		/// <para>Measures—Measures will be recalculated using the pre-existing measure distance between the calibration points.</para>
		/// <para><see cref="CalibrateMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrateMethod { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>Limits how far a calibration point can be from a route by specifying the distance and its unit of measure. If the unit of measure is unknown, the units of the coordinate system of the route feature class will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Interpolate between calibration points</para>
		/// <para>Specifies whether measure values will be interpolated between the calibration points.</para>
		/// <para>Checked—Interpolate between the calibration points. This is the default.</para>
		/// <para>Unchecked—Do not interpolate between the calibration points.</para>
		/// <para><see cref="InterpolateBetweenEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InterpolateBetween { get; set; } = "true";

		/// <summary>
		/// <para>Extrapolate before calibration points</para>
		/// <para>Specifies whether measure values will be extrapolated before the calibration points.</para>
		/// <para>Checked—Extrapolate before the calibration points. This is the default.</para>
		/// <para>Unchecked—Do not extrapolate before the calibration points.</para>
		/// <para><see cref="ExtrapolateBeforeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExtrapolateBefore { get; set; } = "true";

		/// <summary>
		/// <para>Extrapolate after calibration points</para>
		/// <para>Specifies whether measure values will be extrapolated after the calibration points.</para>
		/// <para>Checked—Extrapolate after the calibration points. This is the default.</para>
		/// <para>Unchecked—Do not extrapolate after the calibration points.</para>
		/// <para><see cref="ExtrapolateAfterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExtrapolateAfter { get; set; } = "true";

		/// <summary>
		/// <para>Ignore spatial gaps</para>
		/// <para>Specifies whether spatial gaps will be ignored when recalculating the measures on disjointed routes.</para>
		/// <para>Checked—Spatial gaps will be ignored. Measure values will be continuous for disjointed routes. This is the default.</para>
		/// <para>Unchecked—Do not ignore spatial gaps. The measure values on disjointed routes will have gaps. The gap distance is calculated using the straight-line distance between the endpoints of the disjointed parts.</para>
		/// <para><see cref="IgnoreGapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreGaps { get; set; } = "true";

		/// <summary>
		/// <para>Include all features in the output feature class</para>
		/// <para>Specifies whether route features that do not have any calibration points will be excluded from the output feature class.</para>
		/// <para>Checked—Keep all route features in the output feature class. This is the default.</para>
		/// <para>Unchecked—Do not keep all route features in the output feature class. Features that have no calibration points will be excluded.</para>
		/// <para><see cref="KeepAllRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepAllRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Build index</para>
		/// <para>Specifies whether an attribute index will be created for the route identifier field that is written to the Output Route Feature Class.</para>
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
		public CalibrateRoutes SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? ZDomain = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputZFlag = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Measure Calculation Method</para>
		/// </summary>
		public enum CalibrateMethodEnum 
		{
			/// <summary>
			/// <para>Distance—Measures will be recalculated using the shortest path distance between the calibration points. This is the default.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

			/// <summary>
			/// <para>Measures—Measures will be recalculated using the pre-existing measure distance between the calibration points.</para>
			/// </summary>
			[GPValue("MEASURES")]
			[Description("Measures")]
			Measures,

		}

		/// <summary>
		/// <para>Interpolate between calibration points</para>
		/// </summary>
		public enum InterpolateBetweenEnum 
		{
			/// <summary>
			/// <para>Checked—Interpolate between the calibration points. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BETWEEN")]
			BETWEEN,

			/// <summary>
			/// <para>Unchecked—Do not interpolate between the calibration points.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BETWEEN")]
			NO_BETWEEN,

		}

		/// <summary>
		/// <para>Extrapolate before calibration points</para>
		/// </summary>
		public enum ExtrapolateBeforeEnum 
		{
			/// <summary>
			/// <para>Checked—Extrapolate before the calibration points. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BEFORE")]
			BEFORE,

			/// <summary>
			/// <para>Unchecked—Do not extrapolate before the calibration points.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BEFORE")]
			NO_BEFORE,

		}

		/// <summary>
		/// <para>Extrapolate after calibration points</para>
		/// </summary>
		public enum ExtrapolateAfterEnum 
		{
			/// <summary>
			/// <para>Checked—Extrapolate after the calibration points. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AFTER")]
			AFTER,

			/// <summary>
			/// <para>Unchecked—Do not extrapolate after the calibration points.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AFTER")]
			NO_AFTER,

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
		/// <para>Include all features in the output feature class</para>
		/// </summary>
		public enum KeepAllRoutesEnum 
		{
			/// <summary>
			/// <para>Checked—Keep all route features in the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP")]
			KEEP,

			/// <summary>
			/// <para>Unchecked—Do not keep all route features in the output feature class. Features that have no calibration points will be excluded.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP")]
			NO_KEEP,

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
