using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Thin</para>
	/// <para>Thins rasterized linear features by reducing the number of cells representing the width of the features.</para>
	/// </summary>
	public class Thin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to be thinned.</para>
		/// <para>It must be of integer type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output thinned raster.</para>
		/// <para>The output is always of integer type.</para>
		/// </param>
		public Thin(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Thin</para>
		/// </summary>
		public override string DisplayName() => "Thin";

		/// <summary>
		/// <para>Tool Name : Thin</para>
		/// </summary>
		public override string ToolName() => "Thin";

		/// <summary>
		/// <para>Tool Excute Name : sa.Thin</para>
		/// </summary>
		public override string ExcuteName() => "sa.Thin";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, BackgroundValue, Filter, Corners, MaximumThickness };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to be thinned.</para>
		/// <para>It must be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output thinned raster.</para>
		/// <para>The output is always of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Background value</para>
		/// <para>Specifies the cell value that will identify the background cells. The linear features are formed from the foreground cells.</para>
		/// <para>Zero—The background is composed of cells of 0 or less, or NoData. All cells whose value is greater than 0 are the foreground.</para>
		/// <para>NoData— The background is composed of NoData cells. All cells with valid values belong to the foreground.</para>
		/// <para><see cref="BackgroundValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BackgroundValue { get; set; } = "ZERO";

		/// <summary>
		/// <para>Filter input first</para>
		/// <para>Specifies whether a filter will be applied as the first phase of thinning.</para>
		/// <para>Unchecked—No filter will be applied. This is the default.</para>
		/// <para>Checked—The raster will be filtered to smooth the boundaries between foreground and background cells. This option will eliminate minor irregularities from the output raster.</para>
		/// <para><see cref="FilterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Filter { get; set; } = "false";

		/// <summary>
		/// <para>Shape for corners</para>
		/// <para>Specifies whether round or sharp turns will be made at turns or junctions.</para>
		/// <para>It is also used during the vector conversion process to spline curves or create sharp intersections and corners.</para>
		/// <para>Round— Attempts to smooth corners and junctions. This is best for vectorizing natural features, such as contours or streams.</para>
		/// <para>Sharp— Attempts to preserve rectangular corners and junctions. This is best for vectorizing man-made features such as streets.</para>
		/// <para><see cref="CornersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Corners { get; set; } = "ROUND";

		/// <summary>
		/// <para>Maximum thickness of input linear features</para>
		/// <para>The maximum thickness, in map units, of linear features in the input raster.</para>
		/// <para>The default thickness is ten times the cell size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MaximumThickness { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Thin SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Background value</para>
		/// </summary>
		public enum BackgroundValueEnum 
		{
			/// <summary>
			/// <para>Zero—The background is composed of cells of 0 or less, or NoData. All cells whose value is greater than 0 are the foreground.</para>
			/// </summary>
			[GPValue("ZERO")]
			[Description("Zero")]
			Zero,

			/// <summary>
			/// <para>NoData— The background is composed of NoData cells. All cells with valid values belong to the foreground.</para>
			/// </summary>
			[GPValue("NODATA")]
			[Description("NoData")]
			NoData,

		}

		/// <summary>
		/// <para>Filter input first</para>
		/// </summary>
		public enum FilterEnum 
		{
			/// <summary>
			/// <para>Unchecked—No filter will be applied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER")]
			NO_FILTER,

			/// <summary>
			/// <para>Checked—The raster will be filtered to smooth the boundaries between foreground and background cells. This option will eliminate minor irregularities from the output raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER")]
			FILTER,

		}

		/// <summary>
		/// <para>Shape for corners</para>
		/// </summary>
		public enum CornersEnum 
		{
			/// <summary>
			/// <para>Round— Attempts to smooth corners and junctions. This is best for vectorizing natural features, such as contours or streams.</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("Round")]
			Round,

			/// <summary>
			/// <para>Sharp— Attempts to preserve rectangular corners and junctions. This is best for vectorizing man-made features such as streets.</para>
			/// </summary>
			[GPValue("SHARP")]
			[Description("Sharp")]
			Sharp,

		}

#endregion
	}
}
