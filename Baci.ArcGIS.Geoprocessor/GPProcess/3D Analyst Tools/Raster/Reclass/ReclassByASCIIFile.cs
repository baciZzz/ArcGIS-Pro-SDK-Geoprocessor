using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Reclass by ASCII File</para>
	/// <para>使用 ASCII 文件重分类</para>
	/// <para>通过使用 ASCII 重映射文件重分类（或更改）输入栅格像元的值。</para>
	/// </summary>
	public class ReclassByASCIIFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
		/// </param>
		/// <param name="InRemapFile">
		/// <para>Input ASCII remap file</para>
		/// <para>该 ASCII 重映射文件定义要重分类的单个值或值范围以及它们将生成的值。</para>
		/// <para>ASCII 重映射文件允许使用的扩展名有 .rmp、.txt 和 .asc。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// </param>
		public ReclassByASCIIFile(object InRaster, object InRemapFile, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InRemapFile = InRemapFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用 ASCII 文件重分类</para>
		/// </summary>
		public override string DisplayName() => "使用 ASCII 文件重分类";

		/// <summary>
		/// <para>Tool Name : ReclassByASCIIFile</para>
		/// </summary>
		public override string ToolName() => "ReclassByASCIIFile";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ReclassByASCIIFile</para>
		/// </summary>
		public override string ExcuteName() => "3d.ReclassByASCIIFile";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InRemapFile, OutRaster, MissingValues };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input ASCII remap file</para>
		/// <para>该 ASCII 重映射文件定义要重分类的单个值或值范围以及它们将生成的值。</para>
		/// <para>ASCII 重映射文件允许使用的扩展名有 .rmp、.txt 和 .asc。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("RMP", "TXT", "ASC")]
		public object InRemapFile { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// <para>指示重分类文件中的缺失值是保持不变还是映射为 NoData。</para>
		/// <para>未选中 - 表明如果输入栅格的任何像元位置含有未在重映射文件中出现或重分类的值，则该值应保持不变，并且应写入输出栅格中的相应位置。这是默认设置。</para>
		/// <para>选中 - 表明如果输入栅格的任何像元位置含有未在重映射文件中出现或重分类的值，则该值将在输出栅格中的相应位置被重分类为 NoData。</para>
		/// <para><see cref="MissingValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MissingValues { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReclassByASCIIFile SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// </summary>
		public enum MissingValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
