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
	/// <para>栅格转浮点型</para>
	/// <para>将栅格数据集转换为可表示栅格数据的二进制浮点值文件。</para>
	/// </summary>
	public class RasterToFloat : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入栅格数据集。</para>
		/// <para>栅格数据可为整型或浮点型。</para>
		/// </param>
		/// <param name="OutFloatFile">
		/// <para>Output floating point raster file</para>
		/// <para>输出浮点栅格文件。</para>
		/// <para>文件名的扩展名必须是 .flt。</para>
		/// </param>
		public RasterToFloat(object InRaster, object OutFloatFile)
		{
			this.InRaster = InRaster;
			this.OutFloatFile = OutFloatFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转浮点型</para>
		/// </summary>
		public override string DisplayName() => "栅格转浮点型";

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
		/// <para>输入栅格数据集。</para>
		/// <para>栅格数据可为整型或浮点型。</para>
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
		/// <para>输出浮点栅格文件。</para>
		/// <para>文件名的扩展名必须是 .flt。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("FLT")]
		public object OutFloatFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToFloat SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
