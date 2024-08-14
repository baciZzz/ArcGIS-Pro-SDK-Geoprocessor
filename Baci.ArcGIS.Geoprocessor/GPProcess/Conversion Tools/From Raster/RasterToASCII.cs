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
	/// <para>Raster to ASCII</para>
	/// <para>Converts a raster dataset to an ASCII text file representing raster data.</para>
	/// </summary>
	public class RasterToASCII : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster can be integer or floating-point type.</para>
		/// </param>
		/// <param name="OutAsciiFile">
		/// <para>Output ASCII raster file</para>
		/// <para>The output ASCII raster file.</para>
		/// </param>
		public RasterToASCII(object InRaster, object OutAsciiFile)
		{
			this.InRaster = InRaster;
			this.OutAsciiFile = OutAsciiFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster to ASCII</para>
		/// </summary>
		public override string DisplayName => "Raster to ASCII";

		/// <summary>
		/// <para>Tool Name : RasterToASCII</para>
		/// </summary>
		public override string ToolName => "RasterToASCII";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToASCII</para>
		/// </summary>
		public override string ExcuteName => "conversion.RasterToASCII";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutAsciiFile };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster can be integer or floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output ASCII raster file</para>
		/// <para>The output ASCII raster file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutAsciiFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToASCII SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
