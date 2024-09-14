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
	/// <para>Float to Raster</para>
	/// <para>Float to Raster</para>
	/// <para>Converts a file of binary floating-point values representing raster data to a raster dataset.</para>
	/// </summary>
	[Obsolete()]
	public class FloatToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFloatFile">
		/// <para>Input floating point raster file</para>
		/// <para>The input floating-point binary file.</para>
		/// <para>The file must have a .flt extension. There must be a header file in association with the floating-point binary file, with a .hdr extension.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </param>
		public FloatToRaster(object InFloatFile, object OutRaster)
		{
			this.InFloatFile = InFloatFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Float to Raster</para>
		/// </summary>
		public override string DisplayName() => "Float to Raster";

		/// <summary>
		/// <para>Tool Name : FloatToRaster</para>
		/// </summary>
		public override string ToolName() => "FloatToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FloatToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FloatToRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "compression", "configKeyword", "pyramid", "scratchWorkspace", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFloatFile, OutRaster };

		/// <summary>
		/// <para>Input floating point raster file</para>
		/// <para>The input floating-point binary file.</para>
		/// <para>The file must have a .flt extension. There must be a header file in association with the floating-point binary file, with a .hdr extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("FLT")]
		public object InFloatFile { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FloatToRaster SetEnviroment(int? autoCommit = null, object? compression = null, object? configKeyword = null, object? pyramid = null, object? scratchWorkspace = null, object? tileSize = null)
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, pyramid: pyramid, scratchWorkspace: scratchWorkspace, tileSize: tileSize);
			return this;
		}

	}
}
