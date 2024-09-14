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
	/// <para>Nibble</para>
	/// <para>Nibble</para>
	/// <para>Replaces cells of a raster corresponding to a mask with the values of the nearest neighbors.</para>
	/// </summary>
	public class Nibble : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster that will be nibbled.</para>
		/// <para>The input raster can be either integer or floating point type.</para>
		/// </param>
		/// <param name="InMaskRaster">
		/// <para>Input raster mask</para>
		/// <para>The raster used as the mask.</para>
		/// <para>Cells that are NoData in the mask raster identify the cells in the Input raster that will be nibbled, or replaced, by the value of the closest nearest neighbour.</para>
		/// <para>The mask raster can be either integer or floating point type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output nibbled raster.</para>
		/// <para>The identified input cells will be replaced with the values of their nearest neighbors.</para>
		/// <para>If the Input raster is integer, the output raster will be integer. If it is floating point, the output will be floating point.</para>
		/// </param>
		public Nibble(object InRaster, object InMaskRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InMaskRaster = InMaskRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Nibble</para>
		/// </summary>
		public override string DisplayName() => "Nibble";

		/// <summary>
		/// <para>Tool Name : Nibble</para>
		/// </summary>
		public override string ToolName() => "Nibble";

		/// <summary>
		/// <para>Tool Excute Name : sa.Nibble</para>
		/// </summary>
		public override string ExcuteName() => "sa.Nibble";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InMaskRaster, OutRaster, NibbleValues, NibbleNodata, InZoneRaster };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster that will be nibbled.</para>
		/// <para>The input raster can be either integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input raster mask</para>
		/// <para>The raster used as the mask.</para>
		/// <para>Cells that are NoData in the mask raster identify the cells in the Input raster that will be nibbled, or replaced, by the value of the closest nearest neighbour.</para>
		/// <para>The mask raster can be either integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InMaskRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output nibbled raster.</para>
		/// <para>The identified input cells will be replaced with the values of their nearest neighbors.</para>
		/// <para>If the Input raster is integer, the output raster will be integer. If it is floating point, the output will be floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Use NoData values if they are the nearest neighbor</para>
		/// <para>Specifies whether NoData cells in the input raster are allowed to nibble into the area defined by the mask raster.</para>
		/// <para>Checked—Both NoData and data values can nibble into areas defined in the mask raster. NoData values in the input raster are free to nibble into areas defined in the mask if they are the nearest neighbor. This is the default.</para>
		/// <para>Unchecked—Only data values are free to nibble into areas defined in the mask raster. NoData values in the input raster are not allowed to nibble into areas defined in the mask raster even if they are the nearest neighbor.</para>
		/// <para><see cref="NibbleValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object NibbleValues { get; set; } = "true";

		/// <summary>
		/// <para>Nibble NoData cells</para>
		/// <para>Specifies whether NoData cells in the input raster that are within the mask will remain NoData in the output raster.</para>
		/// <para>Unchecked—NoData cells in the input raster that are within the mask will remain NoData in the output. This is the default.</para>
		/// <para>Checked—NoData cells in the input raster that are within the mask can be nibbled into valid output cell values.</para>
		/// <para><see cref="NibbleNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object NibbleNodata { get; set; } = "false";

		/// <summary>
		/// <para>Input zone raster</para>
		/// <para>The input zone raster. For each zone, input cells that are within the mask will be replaced only by the nearest cell values within that same zone.</para>
		/// <para>A zone is all the cells in a raster that have the same value, whether or not they are contiguous. The input zone layer defines the shape, values, and locations of the zones. The zone raster can be either integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InZoneRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Nibble SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use NoData values if they are the nearest neighbor</para>
		/// </summary>
		public enum NibbleValuesEnum 
		{
			/// <summary>
			/// <para>Checked—Both NoData and data values can nibble into areas defined in the mask raster. NoData values in the input raster are free to nibble into areas defined in the mask if they are the nearest neighbor. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_VALUES")]
			ALL_VALUES,

			/// <summary>
			/// <para>Unchecked—Only data values are free to nibble into areas defined in the mask raster. NoData values in the input raster are not allowed to nibble into areas defined in the mask raster even if they are the nearest neighbor.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA_ONLY")]
			DATA_ONLY,

		}

		/// <summary>
		/// <para>Nibble NoData cells</para>
		/// </summary>
		public enum NibbleNodataEnum 
		{
			/// <summary>
			/// <para>Unchecked—NoData cells in the input raster that are within the mask will remain NoData in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_NODATA")]
			PRESERVE_NODATA,

			/// <summary>
			/// <para>Checked—NoData cells in the input raster that are within the mask can be nibbled into valid output cell values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCESS_NODATA")]
			PROCESS_NODATA,

		}

#endregion
	}
}
