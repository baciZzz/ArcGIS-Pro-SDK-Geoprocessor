using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Contour with Barriers</para>
	/// <para>Creates contours from a raster surface. The inclusion of barrier features allows you to independently generate contours on either side of a barrier.</para>
	/// </summary>
	public class ContourWithBarriers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="OutContourFeatureClass">
		/// <para>Output Contour Features</para>
		/// <para>The output contour features.</para>
		/// </param>
		public ContourWithBarriers(object InRaster, object OutContourFeatureClass)
		{
			this.InRaster = InRaster;
			this.OutContourFeatureClass = OutContourFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Contour with Barriers</para>
		/// </summary>
		public override string DisplayName() => "Contour with Barriers";

		/// <summary>
		/// <para>Tool Name : ContourWithBarriers</para>
		/// </summary>
		public override string ToolName() => "ContourWithBarriers";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ContourWithBarriers</para>
		/// </summary>
		public override string ExcuteName() => "3d.ContourWithBarriers";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutContourFeatureClass, InBarrierFeatures, InContourType, InContourValuesFile, ExplicitOnly, InBaseContour, InContourInterval, InIndexedContourInterval, InContourList, InZFactor };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Contour Features</para>
		/// <para>The output contour features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object OutContourFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Barrier Features</para>
		/// <para>The input barrier features.</para>
		/// <para>The features can be polyline or polygon type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InBarrierFeatures { get; set; }

		/// <summary>
		/// <para>Type of Contours</para>
		/// <para>The type of contour to create.</para>
		/// <para>Polylines— The contour or isoline representation of the input raster.</para>
		/// <para>Polygons— Closed polygons representing the contours.</para>
		/// <para>The current version of this tool only supports polyline output. If the polygon output option is used, it will be ignored and polyline output will be created.</para>
		/// <para><see cref="InContourTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InContourType { get; set; } = "POLYLINES";

		/// <summary>
		/// <para>File Containing Contour Value Specifications</para>
		/// <para>The base contour, contour interval, indexed contour interval, and explicit contour values can also be specified via a text file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object InContourValuesFile { get; set; }

		/// <summary>
		/// <para>Enter Explicit Contour Values Only</para>
		/// <para>Only explicit contour values are used. Base contour, contour interval, and indexed contour intervals are not specified.</para>
		/// <para>Unchecked—The default, contour interval must be specified.</para>
		/// <para>Checked—Only explicit contour values are specified.</para>
		/// <para><see cref="ExplicitOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExplicitOnly { get; set; } = "false";

		/// <summary>
		/// <para>Base Contour</para>
		/// <para>The base contour value.</para>
		/// <para>Contours are generated above and below this value as needed to cover the entire value range of the input raster. The default is zero.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object InBaseContour { get; set; } = "0";

		/// <summary>
		/// <para>Contour Interval</para>
		/// <para>The interval, or distance, between contour lines.</para>
		/// <para>This can be any positive number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object InContourInterval { get; set; }

		/// <summary>
		/// <para>Indexed Contour Interval</para>
		/// <para>Contours will also be generated for this interval and will be flagged accordingly in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object InIndexedContourInterval { get; set; } = "0";

		/// <summary>
		/// <para>Explicit Contour Values</para>
		/// <para>Explicit values at which to create contours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InContourList { get; set; }

		/// <summary>
		/// <para>Factor Applied to Raster Z-values</para>
		/// <para>The unit conversion factor used when generating contours. The default value is 1.</para>
		/// <para>The contour lines are generated based on the z-values in the input raster, which are often measured in units of meters or feet. With the default value of 1, the contours will be in the same units as the z-values of the input raster. To create contours in a unit other than that of the z-values, set an appropriate value for the z-factor. It is not necessary to have the ground x,y and surface z-units be consistent for this tool.</para>
		/// <para>For example, if the elevation values in your input raster are in feet, but you want the contours to be generated based on units of meters, set the z-factor to 0.3048 (since 1 foot = 0.3048 meter).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object InZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ContourWithBarriers SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , bool? maintainSpatialIndex = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type of Contours</para>
		/// </summary>
		public enum InContourTypeEnum 
		{
			/// <summary>
			/// <para>Polylines— The contour or isoline representation of the input raster.</para>
			/// </summary>
			[GPValue("POLYLINES")]
			[Description("Polylines")]
			Polylines,

			/// <summary>
			/// <para>Polygons— Closed polygons representing the contours.</para>
			/// </summary>
			[GPValue("POLYGONS")]
			[Description("Polygons")]
			Polygons,

		}

		/// <summary>
		/// <para>Enter Explicit Contour Values Only</para>
		/// </summary>
		public enum ExplicitOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Only explicit contour values are specified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPLICIT_VALUES_ONLY")]
			EXPLICIT_VALUES_ONLY,

			/// <summary>
			/// <para>Unchecked—The default, contour interval must be specified.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXPLICIT_VALUES_ONLY")]
			NO_EXPLICIT_VALUES_ONLY,

		}

#endregion
	}
}
