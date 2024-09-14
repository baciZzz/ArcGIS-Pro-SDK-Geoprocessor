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
	/// <para>Extract by Rectangle</para>
	/// <para>Extract by Rectangle</para>
	/// <para>Extracts the cells of a raster based on a rectangle by specifying the rectangle's extent.</para>
	/// </summary>
	public class ExtractByRectangle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </param>
		/// <param name="Rectangle">
		/// <para>Extent</para>
		/// <para>A rectangle that defines the area to be extracted.</para>
		/// <para>If the Extent parameter is set to As Specified Below, use the parameters identified with the left and down arrows to define the lower left coordinate of the area to be extracted, and those with the right and up arrows to define the upper right coordinate.</para>
		/// <para>If the Extent parameter is set to Browse, you can select a dataset whose bounding box will define the extent.</para>
		/// <para>The coordinates are specified in the same map units as the input raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </param>
		public ExtractByRectangle(object InRaster, object Rectangle, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Rectangle = Rectangle;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract by Rectangle</para>
		/// </summary>
		public override string DisplayName() => "Extract by Rectangle";

		/// <summary>
		/// <para>Tool Name : ExtractByRectangle</para>
		/// </summary>
		public override string ToolName() => "ExtractByRectangle";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByRectangle</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByRectangle";

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
		public override object[] Parameters() => new object[] { InRaster, Rectangle, OutRaster, ExtractionArea! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>A rectangle that defines the area to be extracted.</para>
		/// <para>If the Extent parameter is set to As Specified Below, use the parameters identified with the left and down arrows to define the lower left coordinate of the area to be extracted, and those with the right and up arrows to define the upper right coordinate.</para>
		/// <para>If the Extent parameter is set to Browse, you can select a dataset whose bounding box will define the extent.</para>
		/// <para>The coordinates are specified in the same map units as the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPExtent()]
		public object Rectangle { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>Specifies whether cells inside or outside the input rectangle will be selected and written to the output raster.</para>
		/// <para>Inside—Cells inside the input rectangle will be selected and written to the output raster. All cells outside the rectangle will receive NoData values on the output raster.</para>
		/// <para>Outside—Cells outside the input rectangle will be selected and written to the output raster. All cells inside the rectangle will receive NoData values on the output raster.</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByRectangle SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
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
			/// <para>Inside—Cells inside the input rectangle will be selected and written to the output raster. All cells outside the rectangle will receive NoData values on the output raster.</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("Inside")]
			Inside,

			/// <summary>
			/// <para>Outside—Cells outside the input rectangle will be selected and written to the output raster. All cells inside the rectangle will receive NoData values on the output raster.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Outside")]
			Outside,

		}

#endregion
	}
}
