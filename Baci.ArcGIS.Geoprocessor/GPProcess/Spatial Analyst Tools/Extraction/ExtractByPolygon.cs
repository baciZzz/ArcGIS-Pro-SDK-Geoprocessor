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
	/// <para>Extract by Polygon</para>
	/// <para>Extracts the cells of a raster based on a polygon by specifying the polygon's vertices.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.ExtractByMask"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.ExtractByMask))]
	public class ExtractByPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </param>
		/// <param name="Polygon">
		/// <para>Polygon</para>
		/// <para>A polygon (or polygons) defined by a series of vertices (x,y point coordinates) that identify the area of the input raster to be extracted. The last coordinate of a polygon part should be the same as the first in order to close a polygon.</para>
		/// <para>When specifying multiple polygons, they must be contiguous. Enter the series of coordinates polygon by polygon. Be sure to close each part by defining the last coordinate the same as the first one.</para>
		/// <para>The points are in the same map units as the input raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </param>
		public ExtractByPolygon(object InRaster, object Polygon, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Polygon = Polygon;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract by Polygon</para>
		/// </summary>
		public override string DisplayName => "Extract by Polygon";

		/// <summary>
		/// <para>Tool Name : ExtractByPolygon</para>
		/// </summary>
		public override string ToolName => "ExtractByPolygon";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByPolygon</para>
		/// </summary>
		public override string ExcuteName => "sa.ExtractByPolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, Polygon, OutRaster, ExtractionArea! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Polygon</para>
		/// <para>A polygon (or polygons) defined by a series of vertices (x,y point coordinates) that identify the area of the input raster to be extracted. The last coordinate of a polygon part should be the same as the first in order to close a polygon.</para>
		/// <para>When specifying multiple polygons, they must be contiguous. Enter the series of coordinates polygon by polygon. Be sure to close each part by defining the last coordinate the same as the first one.</para>
		/// <para>The points are in the same map units as the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Polygon { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>Identifies whether to extract cells inside or outside the input polygon.</para>
		/// <para>Inside—The cells inside the input polygon should be selected and written to the output raster. All cells outside the polygon will receive NoData values on the output raster.</para>
		/// <para>Outside—The cells outside the input polygon should be selected and written to the output raster. All cells inside the polygon will receive NoData.</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByPolygon SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Extraction area</para>
		/// </summary>
		public enum ExtractionAreaEnum 
		{
			/// <summary>
			/// <para>Inside—The cells inside the input polygon should be selected and written to the output raster. All cells outside the polygon will receive NoData values on the output raster.</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("Inside")]
			Inside,

			/// <summary>
			/// <para>Outside—The cells outside the input polygon should be selected and written to the output raster. All cells inside the polygon will receive NoData.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Outside")]
			Outside,

		}

#endregion
	}
}
