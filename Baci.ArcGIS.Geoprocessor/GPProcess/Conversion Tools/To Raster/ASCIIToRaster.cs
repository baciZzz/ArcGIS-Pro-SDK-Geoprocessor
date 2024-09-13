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
	/// <para>ASCII To Raster</para>
	/// <para>ASCII 转栅格</para>
	/// <para>将表示栅格数据的 ASCII 文件转换为栅格数据集。</para>
	/// </summary>
	[Obsolete()]
	public class ASCIIToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAsciiFile">
		/// <para>Input ASCII raster file</para>
		/// <para>要转换的输入 ASCII 文件。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </param>
		public ASCIIToRaster(object InAsciiFile, object OutRaster)
		{
			this.InAsciiFile = InAsciiFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : ASCII 转栅格</para>
		/// </summary>
		public override string DisplayName() => "ASCII 转栅格";

		/// <summary>
		/// <para>Tool Name : ASCIIToRaster</para>
		/// </summary>
		public override string ToolName() => "ASCIIToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ASCIIToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ASCIIToRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "compression", "configKeyword", "pyramid", "rasterStatistics", "scratchWorkspace", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAsciiFile, OutRaster, DataType };

		/// <summary>
		/// <para>Input ASCII raster file</para>
		/// <para>要转换的输入 ASCII 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object InAsciiFile { get; set; }

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
		/// <para>指定输出栅格数据集的数据类型。</para>
		/// <para>整型—将创建整型栅格数据集。</para>
		/// <para>浮点型—将创建浮点栅格数据集。</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "INTEGER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ASCIIToRaster SetEnviroment(int? autoCommit = null , object compression = null , object configKeyword = null , object pyramid = null , object rasterStatistics = null , object scratchWorkspace = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output data type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>整型—将创建整型栅格数据集。</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("整型")]
			Integer,

			/// <summary>
			/// <para>浮点型—将创建浮点栅格数据集。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型")]
			Float,

		}

#endregion
	}
}
