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
	/// <para>Extract by Circle</para>
	/// <para>Extract by Circle</para>
	/// <para>Extracts the cells of a raster based on a circle by specifying the circle's center and radius.</para>
	/// </summary>
	public class ExtractByCircle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </param>
		/// <param name="CenterPoint">
		/// <para>Center point</para>
		/// <para>The center coordinate (x,y) of the circle defining the area to be extracted.</para>
		/// <para>The coordinates are specified in the same map units as the input raster.</para>
		/// </param>
		/// <param name="Radius">
		/// <para>Radius</para>
		/// <para>The radius of the circle defining the area to be extracted.</para>
		/// <para>The radius is specified in map units and is in the same units as the input raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </param>
		public ExtractByCircle(object InRaster, object CenterPoint, object Radius, object OutRaster)
		{
			this.InRaster = InRaster;
			this.CenterPoint = CenterPoint;
			this.Radius = Radius;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract by Circle</para>
		/// </summary>
		public override string DisplayName() => "Extract by Circle";

		/// <summary>
		/// <para>Tool Name : ExtractByCircle</para>
		/// </summary>
		public override string ToolName() => "ExtractByCircle";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByCircle</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByCircle";

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
		public override object[] Parameters() => new object[] { InRaster, CenterPoint, Radius, OutRaster, ExtractionArea! };

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
		/// <para>Center point</para>
		/// <para>The center coordinate (x,y) of the circle defining the area to be extracted.</para>
		/// <para>The coordinates are specified in the same map units as the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object CenterPoint { get; set; }

		/// <summary>
		/// <para>Radius</para>
		/// <para>The radius of the circle defining the area to be extracted.</para>
		/// <para>The radius is specified in map units and is in the same units as the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object Radius { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>Specifies whether cells inside or outside the input circle will be selected and written to the output raster.</para>
		/// <para>Inside—Cells inside the input circle will be selected and written to the output raster. All cells outside the circle will receive NoData values on the output raster.</para>
		/// <para>Outside—Cells outside the input circle will be selected and written to the output raster. All cells inside the circle will receive NoData values on the output raster.</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByCircle SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
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
			/// <para>Inside—Cells inside the input circle will be selected and written to the output raster. All cells outside the circle will receive NoData values on the output raster.</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("Inside")]
			Inside,

			/// <summary>
			/// <para>Outside—Cells outside the input circle will be selected and written to the output raster. All cells inside the circle will receive NoData values on the output raster.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Outside")]
			Outside,

		}

#endregion
	}
}
