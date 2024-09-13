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
	/// <para>Contour</para>
	/// <para>Contour</para>
	/// <para>Creates a feature class of contours from a raster surface.</para>
	/// </summary>
	public class Contour : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output feature class</para>
		/// <para>The output contour features.</para>
		/// </param>
		/// <param name="ContourInterval">
		/// <para>Contour interval</para>
		/// <para>The interval, or distance, between contour lines.</para>
		/// <para>This can be any positive number.</para>
		/// </param>
		public Contour(object InRaster, object OutPolylineFeatures, object ContourInterval)
		{
			this.InRaster = InRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
			this.ContourInterval = ContourInterval;
		}

		/// <summary>
		/// <para>Tool Display Name : Contour</para>
		/// </summary>
		public override string DisplayName() => "Contour";

		/// <summary>
		/// <para>Tool Name : Contour</para>
		/// </summary>
		public override string ToolName() => "Contour";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Contour</para>
		/// </summary>
		public override string ExcuteName() => "3d.Contour";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutPolylineFeatures, ContourInterval, BaseContour!, ZFactor!, ContourType!, MaxVerticesPerFeature! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>The output contour features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Contour interval</para>
		/// <para>The interval, or distance, between contour lines.</para>
		/// <para>This can be any positive number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ContourInterval { get; set; }

		/// <summary>
		/// <para>Base contour</para>
		/// <para>The base contour value.</para>
		/// <para>Contours are generated above and below this value as needed to cover the entire value range of the input raster. The default is zero.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BaseContour { get; set; } = "0";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>The unit conversion factor used when generating contours. The default value is 1.</para>
		/// <para>The contour lines are generated based on the z-values in the input raster, which are often measured in units of meters or feet. With the default value of 1, the contours will be in the same units as the z-values of the input raster. To create contours in a unit other than that of the z-values, set an appropriate value for the z-factor. It is not necessary to have the ground x,y and surface z-units be consistent for this tool.</para>
		/// <para>For example, if the elevation values in your input raster are in feet, but you want the contours to be generated based on units of meters, set the z-factor to 0.3048 (since 1 foot = 0.3048 meter).</para>
		/// <para>For another example, consider an input raster in WGS_84 geographic coordinates and elevation units of meters for which you want to generate contour lines every 100 feet with a base of 50 feet (so the contours will be 50 ft, 150 ft, 250 ft, and so on). To do this, set the Contour interval to 100, the Base contour to 50, and the Z factor to 3.2808 (since 1 meter = 3.2808 feet).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Contour type</para>
		/// <para>Specifies the type of output. The output can represent the contours as either lines or polygons. There are several options for polygons.</para>
		/// <para>Contour—A polyline feature class of contours (isolines). This is the default.</para>
		/// <para>Contour polygon—A polygon feature class of filled contours.</para>
		/// <para>Contour shell—A polygon feature class in which the upper bound of the polygon increases cumulatively by the interval value. The lower bound remains constant at the raster minimum.</para>
		/// <para>Contour shell up—A polygon feature class in which the lower bound of the polygon increases cumulatively, from the raster minimum, by the interval value. The upper bound remains constant at the raster maximum.</para>
		/// <para><see cref="ContourTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ContourType { get; set; } = "CONTOUR";

		/// <summary>
		/// <para>Maximum vertices per feature</para>
		/// <para>The vertex limit when subdividing a feature. This should only be used when output features contain a very large number of vertices (many millions).</para>
		/// <para>This parameter is intended as a way to subdivide extremely large features that can cause issues later on, for example, when storing, analyzing, or drawing the features.</para>
		/// <para>If left empty, the output features will not be split. The default is empty.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 4)]
		[High(Allow = true, Value = 2147483646)]
		public object? MaxVerticesPerFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Contour SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contour type</para>
		/// </summary>
		public enum ContourTypeEnum 
		{
			/// <summary>
			/// <para>Contour type</para>
			/// </summary>
			[GPValue("CONTOUR")]
			[Description("Contour")]
			Contour,

			/// <summary>
			/// <para>Contour polygon—A polygon feature class of filled contours.</para>
			/// </summary>
			[GPValue("CONTOUR_POLYGON")]
			[Description("Contour polygon")]
			Contour_polygon,

			/// <summary>
			/// <para>Contour shell—A polygon feature class in which the upper bound of the polygon increases cumulatively by the interval value. The lower bound remains constant at the raster minimum.</para>
			/// </summary>
			[GPValue("CONTOUR_SHELL")]
			[Description("Contour shell")]
			Contour_shell,

			/// <summary>
			/// <para>Contour shell up—A polygon feature class in which the lower bound of the polygon increases cumulatively, from the raster minimum, by the interval value. The upper bound remains constant at the raster maximum.</para>
			/// </summary>
			[GPValue("CONTOUR_SHELL_UP")]
			[Description("Contour shell up")]
			Contour_shell_up,

		}

#endregion
	}
}
