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
	/// <para>Create Ortho Corrected Raster Dataset</para>
	/// <para>创建正射校正的栅格数据集</para>
	/// <para>通过合并高程数据和与卫星数据相关联的有理多项式系数 (RPC) 来创建正射校正的栅格数据集以准确地排列影像。</para>
	/// </summary>
	public class CreateOrthoCorrectedRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待正射的栅格数据集。该栅格的元数据必须具有 RPC。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。</para>
		/// <para>以文件格式存储栅格数据集时，需要指定文件扩展名，具体如下：</para>
		/// <para>.bil - Esri BIL</para>
		/// <para>.bip - Esri BIP</para>
		/// <para>.bmp - BMP</para>
		/// <para>.bsq - Esri BSQ</para>
		/// <para>.dat - ENVI DAT</para>
		/// <para>.gif - GIF</para>
		/// <para>.img - ERDAS IMAGINE</para>
		/// <para>.jpg - JPEG</para>
		/// <para>.jp2 - JPEG 2000</para>
		/// <para>.png - PNG</para>
		/// <para>.tif - TIFF</para>
		/// <para>.mrf - MRF</para>
		/// <para>.crf - CRF</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储到 JPEG 文件、JPEG 2000 文件或地理数据库时，可在环境中指定压缩类型和压缩质量。</para>
		/// </param>
		/// <param name="OrthoType">
		/// <para>Orthorectification Type</para>
		/// <para>表示整个影像平均高程的 DEM 或指定值。</para>
		/// <para>常量高程—将使用指定高程值。</para>
		/// <para>DEM—将使用指定的数字高程模型栅格。</para>
		/// <para><see cref="OrthoTypeEnum"/></para>
		/// </param>
		/// <param name="ConstantElevation">
		/// <para>Constant Elevation (Meters)</para>
		/// <para>当正射校正类型参数为常量高程时要使用的常量高程值。</para>
		/// <para>如果在正射校正过程中使用 DEM，将不使用该值。</para>
		/// </param>
		public CreateOrthoCorrectedRasterDataset(object InRaster, object OutRasterDataset, object OrthoType, object ConstantElevation)
		{
			this.InRaster = InRaster;
			this.OutRasterDataset = OutRasterDataset;
			this.OrthoType = OrthoType;
			this.ConstantElevation = ConstantElevation;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建正射校正的栅格数据集</para>
		/// </summary>
		public override string DisplayName() => "创建正射校正的栅格数据集";

		/// <summary>
		/// <para>Tool Name : CreateOrthoCorrectedRasterDataset</para>
		/// </summary>
		public override string ToolName() => "CreateOrthoCorrectedRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateOrthoCorrectedRasterDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateOrthoCorrectedRasterDataset";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRasterDataset, OrthoType, ConstantElevation, InDEMRaster, Zfactor, Zoffset, Geoid };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待正射的栅格数据集。该栅格的元数据必须具有 RPC。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。</para>
		/// <para>以文件格式存储栅格数据集时，需要指定文件扩展名，具体如下：</para>
		/// <para>.bil - Esri BIL</para>
		/// <para>.bip - Esri BIP</para>
		/// <para>.bmp - BMP</para>
		/// <para>.bsq - Esri BSQ</para>
		/// <para>.dat - ENVI DAT</para>
		/// <para>.gif - GIF</para>
		/// <para>.img - ERDAS IMAGINE</para>
		/// <para>.jpg - JPEG</para>
		/// <para>.jp2 - JPEG 2000</para>
		/// <para>.png - PNG</para>
		/// <para>.tif - TIFF</para>
		/// <para>.mrf - MRF</para>
		/// <para>.crf - CRF</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储到 JPEG 文件、JPEG 2000 文件或地理数据库时，可在环境中指定压缩类型和压缩质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Orthorectification Type</para>
		/// <para>表示整个影像平均高程的 DEM 或指定值。</para>
		/// <para>常量高程—将使用指定高程值。</para>
		/// <para>DEM—将使用指定的数字高程模型栅格。</para>
		/// <para><see cref="OrthoTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OrthoType { get; set; }

		/// <summary>
		/// <para>Constant Elevation (Meters)</para>
		/// <para>当正射校正类型参数为常量高程时要使用的常量高程值。</para>
		/// <para>如果在正射校正过程中使用 DEM，将不使用该值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ConstantElevation { get; set; }

		/// <summary>
		/// <para>DEM Raster</para>
		/// <para>当正射校正类型参数为 DEM 时要用来进行正射校正的 DEM 栅格</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InDEMRaster { get; set; }

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>用于在 DEM 中转换高程值的比例因子。</para>
		/// <para>如果垂直单位是米，请将 Z 因子设置为 1。如果垂直单位是英尺，请将 Z 因子设置为 0.3048。如果使用任何其他垂直单位，则使用 Z 因子将单位按比例换算为米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Zfactor { get; set; } = "1";

		/// <summary>
		/// <para>Z Offset</para>
		/// <para>在 DEM 中要添加到高程值的基础值。可使用此参数偏移不是从海平面开始的高程值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Zoffset { get; set; } = "0";

		/// <summary>
		/// <para>Geoid</para>
		/// <para>指定是否将对参考椭球体高的 RPC 进行大地水准面校正。大多数高程数据集均参考海平面正高，因此在这些情况下，需要进行此项校正以将海平面正高转换为椭球体高。</para>
		/// <para>未选中 - 不进行大地水准面校正。只有在已使用椭球体高表示 DEM 的情况下，才能使用此选项。</para>
		/// <para>选中 - 将进行大地水准面校正以将正高转换为椭球体高（根据 EGM96 大地水准面）。</para>
		/// <para><see cref="GeoidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Geoid { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateOrthoCorrectedRasterDataset SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Orthorectification Type</para>
		/// </summary>
		public enum OrthoTypeEnum 
		{
			/// <summary>
			/// <para>常量高程—将使用指定高程值。</para>
			/// </summary>
			[GPValue("CONSTANT_ELEVATION")]
			[Description("常量高程")]
			Constant_elevation,

			/// <summary>
			/// <para>DEM—将使用指定的数字高程模型栅格。</para>
			/// </summary>
			[GPValue("DEM")]
			[Description("DEM")]
			DEM,

		}

		/// <summary>
		/// <para>Geoid</para>
		/// </summary>
		public enum GeoidEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOID")]
			GEOID,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
