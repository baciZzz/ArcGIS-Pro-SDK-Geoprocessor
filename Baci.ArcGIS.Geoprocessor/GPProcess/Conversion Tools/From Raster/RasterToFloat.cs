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
	/// <para>Raster to Float</para>
	/// <para>Raster to Float</para>
	/// <para>Converts a raster dataset to a file of binary floating-point values representing raster data.</para>
	/// </summary>
	public class RasterToFloat : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster can be integer or floating-point type.</para>
		/// </param>
		/// <param name="OutFloatFile">
		/// <para>Output floating point raster file</para>
		/// <para>The output floating-point raster file.</para>
		/// <para>The file name must have a .flt extension.</para>
		/// </param>
		public RasterToFloat(object InRaster, object OutFloatFile)
		{
			this.InRaster = InRaster;
			this.OutFloatFile = OutFloatFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster to Float</para>
		/// </summary>
		public override string DisplayName() => "Raster to Float";

		/// <summary>
		/// <para>Tool Name : RasterToFloat</para>
		/// </summary>
		public override string ToolName() => "RasterToFloat";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToFloat</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToFloat";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFloatFile };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster can be integer or floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output floating point raster file</para>
		/// <para>The output floating-point raster file.</para>
		/// <para>The file name must have a .flt extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("FLT")]
		public object OutFloatFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToFloat SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
