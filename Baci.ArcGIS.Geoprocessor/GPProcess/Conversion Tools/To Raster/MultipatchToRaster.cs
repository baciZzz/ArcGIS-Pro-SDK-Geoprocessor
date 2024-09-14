using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Multipatch to Raster</para>
	/// <para>Multipatch to Raster</para>
	/// <para>Converts multipatch features to a raster dataset.</para>
	/// </summary>
	public class MultipatchToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultipatchFeatures">
		/// <para>Input multipatch features</para>
		/// <para>The input multipatch features to be converted to a raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>It will be of floating point type.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </param>
		public MultipatchToRaster(object InMultipatchFeatures, object OutRaster)
		{
			this.InMultipatchFeatures = InMultipatchFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Multipatch to Raster</para>
		/// </summary>
		public override string DisplayName() => "Multipatch to Raster";

		/// <summary>
		/// <para>Tool Name : MultipatchToRaster</para>
		/// </summary>
		public override string ToolName() => "MultipatchToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.MultipatchToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.MultipatchToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultipatchFeatures, OutRaster, CellSize!, CellAssignmentMethod! };

		/// <summary>
		/// <para>Input multipatch features</para>
		/// <para>The input multipatch features to be converted to a raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[GeometryType("MultiPatch")]
		public object InMultipatchFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>It will be of floating point type.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster being created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn’t been explicitly specified as the parameter value, the environment cell size value is used, if specified; otherwise, additional rules are used to calculate it from the other inputs. See Usages for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Cell assignment method</para>
		/// <para>Specifies whether the maximum or minimum z-value will be used for a cell when more than one z-value is detected at the cell center location when a vertical line is extended from the cell center location to intersect the input multipatch feature.</para>
		/// <para>Maximum height—The maximum z-value will be assigned to the cell. This is the default.</para>
		/// <para>Minimum height—The minimum z-value will be assigned to the cell.</para>
		/// <para><see cref="CellAssignmentMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CellAssignmentMethod { get; set; } = "MAXIMUM_HEIGHT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultipatchToRaster SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell assignment method</para>
		/// </summary>
		public enum CellAssignmentMethodEnum 
		{
			/// <summary>
			/// <para>Maximum height—The maximum z-value will be assigned to the cell. This is the default.</para>
			/// </summary>
			[GPValue("MAXIMUM_HEIGHT")]
			[Description("Maximum height")]
			Maximum_height,

			/// <summary>
			/// <para>Minimum height—The minimum z-value will be assigned to the cell.</para>
			/// </summary>
			[GPValue("MINIMUM_HEIGHT")]
			[Description("Minimum height")]
			Minimum_height,

		}

#endregion
	}
}
