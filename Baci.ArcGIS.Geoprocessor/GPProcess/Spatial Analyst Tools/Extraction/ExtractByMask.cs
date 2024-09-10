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
	/// <para>Extract by Mask</para>
	/// <para>Extracts the cells of a raster that correspond to the areas defined by a mask.</para>
	/// </summary>
	public class ExtractByMask : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </param>
		/// <param name="InMaskData">
		/// <para>Input raster or feature mask data</para>
		/// <para>Input mask data defining areas to extract.</para>
		/// <para>It can be a raster or feature dataset.</para>
		/// <para>When the input mask data is a raster, NoData cells on the mask will be assigned NoData values on the output raster.</para>
		/// <para>When the input mask is feature data, cells in the input raster whose center falls within the perimeter of the feature will be included in the output, while cells whose center falls outside it will receive NoData.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </param>
		public ExtractByMask(object InRaster, object InMaskData, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InMaskData = InMaskData;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract by Mask</para>
		/// </summary>
		public override string DisplayName() => "Extract by Mask";

		/// <summary>
		/// <para>Tool Name : ExtractByMask</para>
		/// </summary>
		public override string ToolName() => "ExtractByMask";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByMask</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByMask";

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
		public override object[] Parameters() => new object[] { InRaster, InMaskData, OutRaster };

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
		/// <para>Input raster or feature mask data</para>
		/// <para>Input mask data defining areas to extract.</para>
		/// <para>It can be a raster or feature dataset.</para>
		/// <para>When the input mask data is a raster, NoData cells on the mask will be assigned NoData values on the output raster.</para>
		/// <para>When the input mask is feature data, cells in the input raster whose center falls within the perimeter of the feature will be included in the output, while cells whose center falls outside it will receive NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InMaskData { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByMask SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
