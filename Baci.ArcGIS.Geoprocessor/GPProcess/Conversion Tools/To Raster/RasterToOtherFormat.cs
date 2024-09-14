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
	/// <para>Raster To Other Format</para>
	/// <para>Raster To Other Format</para>
	/// <para>Converts one or more raster datasets to a different format.</para>
	/// </summary>
	public class RasterToOtherFormat : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasters">
		/// <para>Input Rasters</para>
		/// <para>The raster datasets to convert.</para>
		/// </param>
		/// <param name="OutputWorkspace">
		/// <para>Output Workspace</para>
		/// <para>The folder where the raster dataset will be written.</para>
		/// </param>
		public RasterToOtherFormat(object InputRasters, object OutputWorkspace)
		{
			this.InputRasters = InputRasters;
			this.OutputWorkspace = OutputWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster To Other Format</para>
		/// </summary>
		public override string DisplayName() => "Raster To Other Format";

		/// <summary>
		/// <para>Tool Name : RasterToOtherFormat</para>
		/// </summary>
		public override string ToolName() => "RasterToOtherFormat";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToOtherFormat</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToOtherFormat";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "ZResolution", "compression", "configKeyword", "extent", "nodata", "outputCoordinateSystem", "outputZFlag", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasters, OutputWorkspace, RasterFormat!, DerivedWorkspace! };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The raster datasets to convert.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasters { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// <para>The folder where the raster dataset will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>The format of the new raster dataset.</para>
		/// <para>BIL—Esri Band Interleaved by Line file</para>
		/// <para>BIP—Esri Band Interleaved by Pixel file</para>
		/// <para>BMP—Microsoft bitmap graphic raster dataset format</para>
		/// <para>BSQ—Esri Band Sequential file</para>
		/// <para>CRF—Cloud Raster Format</para>
		/// <para>ENVI DAT file—ENVI DAT file</para>
		/// <para>GIF—Graphic Interchange Format for raster datasets</para>
		/// <para>Esri Grid—Esri Grid raster dataset format</para>
		/// <para>ERDAS IMAGINE file—ERDAS IMAGINE raster data format</para>
		/// <para>JPEG 2000—JPEG 2000 raster dataset format</para>
		/// <para>JPEG—Joint Photographic Experts Group raster dataset format</para>
		/// <para>MRF—Meta Raster Format</para>
		/// <para>PNG—Portable Network Graphic raster dataset format</para>
		/// <para>TIFF—Tagged Image File Format for raster datasets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RasterFormat { get; set; } = "TIFF";

		/// <summary>
		/// <para>Updated Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? DerivedWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToOtherFormat SetEnviroment(object? XYDomain = null, object? ZDomain = null, object? ZResolution = null, object? compression = null, object? configKeyword = null, object? extent = null, object? nodata = null, object? outputCoordinateSystem = null, object? outputZFlag = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, ZResolution: ZResolution, compression: compression, configKeyword: configKeyword, extent: extent, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
