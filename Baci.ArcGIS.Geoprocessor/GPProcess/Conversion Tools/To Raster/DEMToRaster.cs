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
	/// <para>DEM to Raster</para>
	/// <para>DEM 转栅格</para>
	/// <para>将美国地质勘探局 (USGS) 的数字高程模型 (DEM) 格式（即 USGS DEM 格式）转换为栅格数据集。</para>
	/// </summary>
	[Obsolete()]
	public class DEMToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDemFile">
		/// <para>Input USGS DEM file</para>
		/// <para>输入 USGS DEM 文件。DEM 必须是标准 USGS 7.5 分、1 度文件，或 USGS DEM 格式的任何其他文件。DEM 的记录长度可以是固定的，也可以是变化的。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </param>
		public DEMToRaster(object InDemFile, object OutRaster)
		{
			this.InDemFile = InDemFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : DEM 转栅格</para>
		/// </summary>
		public override string DisplayName() => "DEM 转栅格";

		/// <summary>
		/// <para>Tool Name : DEMToRaster</para>
		/// </summary>
		public override string ToolName() => "DEMToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.DEMToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.DEMToRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "pyramid", "rasterStatistics", "scratchWorkspace", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDemFile, OutRaster, DataType!, ZFactor! };

		/// <summary>
		/// <para>Input USGS DEM file</para>
		/// <para>输入 USGS DEM 文件。DEM 必须是标准 USGS 7.5 分、1 度文件，或 USGS DEM 格式的任何其他文件。DEM 的记录长度可以是固定的，也可以是变化的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("DEM", "TXT", "ASC")]
		public object InDemFile { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output data type</para>
		/// <para>输出栅格数据集的数据类型。</para>
		/// <para>整型—将创建整型栅格数据集。</para>
		/// <para>浮点型—将创建浮点栅格数据集。这是默认设置。</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; } = "FLOAT";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>一个表面 z 单位中地面 x,y 单位的数量。</para>
		/// <para>z 单位与输入表面的 x,y 单位不同时，可使用 z 因子调整 z 单位的测量单位。计算最终输出表面时，将用 z 因子乘以输入表面的 z 值。</para>
		/// <para>如果 x,y 单位和 z 单位采用相同的测量单位，则 z 因子为 1。这是默认设置。</para>
		/// <para>如果 x,y 单位和 z 单位采用不同的测量单位，则必须将 z 因子设置为适当的因子，否则会得到错误的结果。例如，如果 z 单位是英尺而 x,y 单位是米，则应使用 z 因子 0.3048 将 z 单位从英尺转换为米（1 英尺 = 0.3048 米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DEMToRaster SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? pyramid = null , object? rasterStatistics = null , object? scratchWorkspace = null , object? tileSize = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output data type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>浮点型—将创建浮点栅格数据集。这是默认设置。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型")]
			Float,

			/// <summary>
			/// <para>整型—将创建整型栅格数据集。</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("整型")]
			Integer,

		}

#endregion
	}
}
