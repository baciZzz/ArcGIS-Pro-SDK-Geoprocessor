using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Generate Raster From Raster Function</para>
	/// <para>Generates a raster dataset from an input raster function or function chain.</para>
	/// </summary>
	public class GenerateRasterFromRasterFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="RasterFunction">
		/// <para>Input Raster Function</para>
		/// <para>The name of a raster function, raster function JSON object, or function chain (in .rft.xml format).</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset.</para>
		/// </param>
		public GenerateRasterFromRasterFunction(object RasterFunction, object OutRasterDataset)
		{
			this.RasterFunction = RasterFunction;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Raster From Raster Function</para>
		/// </summary>
		public override string DisplayName() => "Generate Raster From Raster Function";

		/// <summary>
		/// <para>Tool Name : GenerateRasterFromRasterFunction</para>
		/// </summary>
		public override string ToolName() => "GenerateRasterFromRasterFunction";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateRasterFromRasterFunction</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateRasterFromRasterFunction";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "gpuID", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { RasterFunction, OutRasterDataset, RasterFunctionArguments, RasterProperties, Format, ProcessAsMultidimensional };

		/// <summary>
		/// <para>Input Raster Function</para>
		/// <para>The name of a raster function, raster function JSON object, or function chain (in .rft.xml format).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object RasterFunction { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Raster Function Arguments</para>
		/// <para>The parameters associated with the function chain. For example, if the function chain applies the Hillshade raster function, set the data source, azimuth, and altitude.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object RasterFunctionArguments { get; set; }

		/// <summary>
		/// <para>Raster Properties</para>
		/// <para>The output raster dataset key properties, such as the sensor or wavelength.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object RasterProperties { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>The output raster format.</para>
		/// <para>The default format will be derived from the file extension that was specified in the Output Raster Dataset.</para>
		/// <para>TIFF—Tagged Image File Format for raster datasets</para>
		/// <para>Cloud Optimized GeoTIFF—Cloud Optimized GeoTIFF format.</para>
		/// <para>ERDAS IMAGINE file—ERDAS IMAGINE raster data format</para>
		/// <para>Esri Grid—Esri Grid raster dataset format</para>
		/// <para>CRF—Cloud Raster Format</para>
		/// <para>MRF—Meta Raster Format</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; }

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>Specifies whether to process the input mosaic dataset as a multidimensional raster dataset.</para>
		/// <para>Unchecked—The input will not be processed as a multidimensional raster dataset. If the input is multidimensional, only the slice that is currently displayed will be processed. This is the default.</para>
		/// <para>Checked—The input will be processed as a multidimensional raster dataset and all slices will be processed to produce a new multidimensional raster dataset. The output Format must be set to Cloud raster format to use this option.</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRasterFromRasterFunction SetEnviroment(object cellSize = null , object compression = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>TIFF—Tagged Image File Format for raster datasets</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF")]
			TIFF,

			/// <summary>
			/// <para>Cloud Optimized GeoTIFF—Cloud Optimized GeoTIFF format.</para>
			/// </summary>
			[GPValue("COG")]
			[Description("Cloud Optimized GeoTIFF")]
			Cloud_Optimized_GeoTIFF,

			/// <summary>
			/// <para>ERDAS IMAGINE file—ERDAS IMAGINE raster data format</para>
			/// </summary>
			[GPValue("IMAGINE Image")]
			[Description("ERDAS IMAGINE file")]
			ERDAS_IMAGINE_file,

			/// <summary>
			/// <para>Esri Grid—Esri Grid raster dataset format</para>
			/// </summary>
			[GPValue("GRID")]
			[Description("Esri Grid")]
			Esri_Grid,

			/// <summary>
			/// <para>CRF—Cloud Raster Format</para>
			/// </summary>
			[GPValue("CRF")]
			[Description("CRF")]
			CRF,

			/// <summary>
			/// <para>MRF—Meta Raster Format</para>
			/// </summary>
			[GPValue("MRF")]
			[Description("MRF")]
			MRF,

		}

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// </summary>
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para>Checked—The input will be processed as a multidimensional raster dataset and all slices will be processed to produce a new multidimensional raster dataset. The output Format must be set to Cloud raster format to use this option.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

			/// <summary>
			/// <para>Unchecked—The input will not be processed as a multidimensional raster dataset. If the input is multidimensional, only the slice that is currently displayed will be processed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

		}

#endregion
	}
}
