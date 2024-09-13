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
	/// <para>浮点型转栅格</para>
	/// <para>将表示栅格数据的二进制浮点型值文件转换为栅格数据集。</para>
	/// </summary>
	[Obsolete()]
	public class FloatToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFloatFile">
		/// <para>Input floating point raster file</para>
		/// <para>输入的浮点型二进制文件。</para>
		/// <para>该文件的扩展名必须是 .flt。必须存在一个与浮点型二进制文件相关联且扩展名为 .hdr 的头文件。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </param>
		public FloatToRaster(object InFloatFile, object OutRaster)
		{
			this.InFloatFile = InFloatFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 浮点型转栅格</para>
		/// </summary>
		public override string DisplayName() => "浮点型转栅格";

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
		/// <para>输入的浮点型二进制文件。</para>
		/// <para>该文件的扩展名必须是 .flt。必须存在一个与浮点型二进制文件相关联且扩展名为 .hdr 的头文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("FLT")]
		public object InFloatFile { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FloatToRaster SetEnviroment(int? autoCommit = null , object compression = null , object configKeyword = null , object pyramid = null , object scratchWorkspace = null , double[] tileSize = null )
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, pyramid: pyramid, scratchWorkspace: scratchWorkspace, tileSize: tileSize);
			return this;
		}

	}
}
