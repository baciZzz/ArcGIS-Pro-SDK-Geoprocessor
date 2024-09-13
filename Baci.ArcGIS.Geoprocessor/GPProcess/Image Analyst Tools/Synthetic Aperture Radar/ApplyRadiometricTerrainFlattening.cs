using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Apply Radiometric Terrain Flattening</para>
	/// <para>应用辐射地形扁率</para>
	/// <para>校正输入合成孔径雷达 (SAR) 数据中因地形引起的辐射变形。</para>
	/// </summary>
	public class ApplyRadiometricTerrainFlattening : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// <para>必须通过辐射方法将数据校准到 beta nought。</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>应用辐射地形扁率的雷达数据。</para>
		/// </param>
		/// <param name="InDemRaster">
		/// <para>DEM Raster</para>
		/// <para>输入 DEM。</para>
		/// <para>将使用 DEM 估算局部照明区域和局部入射角。</para>
		/// </param>
		public ApplyRadiometricTerrainFlattening(object InRadarData, object OutRadarData, object InDemRaster)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
			this.InDemRaster = InDemRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用辐射地形扁率</para>
		/// </summary>
		public override string DisplayName() => "应用辐射地形扁率";

		/// <summary>
		/// <para>Tool Name : ApplyRadiometricTerrainFlattening</para>
		/// </summary>
		public override string ToolName() => "ApplyRadiometricTerrainFlattening";

		/// <summary>
		/// <para>Tool Excute Name : ia.ApplyRadiometricTerrainFlattening</para>
		/// </summary>
		public override string ExcuteName() => "ia.ApplyRadiometricTerrainFlattening";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRadarData, OutRadarData, InDemRaster, Geoid!, PolarizationBands!, CalibrationType!, OutScatteringArea!, OutGeometricDistortion!, OutGeometricDistortionMask! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// <para>必须通过辐射方法将数据校准到 beta nought。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>应用辐射地形扁率的雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>DEM Raster</para>
		/// <para>输入 DEM。</para>
		/// <para>将使用 DEM 估算局部照明区域和局部入射角。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDemRaster { get; set; }

		/// <summary>
		/// <para>Apply geoid correction</para>
		/// <para>指定是否将输入 DEM 的垂直参考系统转换为椭球体高度。 大多数高程数据集均参考海平面正高，因此在这些情况下，需要进行校正以将海平面正高转换为椭球体高度。</para>
		/// <para>选中 - 将进行大地水准面校正以将正高转换为椭球体高度（根据 EGM96 大地水准面）。 这是默认设置。</para>
		/// <para>未选中 - 不会进行大地水准面校正。 只有在使用椭球体高度表示 DEM 的情况下，才使用此选项。</para>
		/// <para><see cref="GeoidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Geoid { get; set; } = "true";

		/// <summary>
		/// <para>Polarization Bands</para>
		/// <para>将应用辐射地形扁率的极化波段。</para>
		/// <para>默认情况下，第一个波段处于选中状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? PolarizationBands { get; set; }

		/// <summary>
		/// <para>Calibration Type</para>
		/// <para>指定是否将使用 sigma naught 或 gamma nought 对输出应用地形扁率。</para>
		/// <para>Gamma nought—将使用 DEM 对区域进行精确计算来校正 beta nought 反向散射。 这是默认设置。</para>
		/// <para>Sigma nought—将使用与 DEM 局部相切的平面单位面积来校正 beta nought 反向散射。</para>
		/// <para><see cref="CalibrationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationType { get; set; } = "GAMMA_NOUGHT";

		/// <summary>
		/// <para>Out Scattering Area</para>
		/// <para>散射区域雷达数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Supplemental Radar Products")]
		public object? OutScatteringArea { get; set; }

		/// <summary>
		/// <para>Out Geometric Distortion</para>
		/// <para>4 波段几何畸变雷达数据集。 第一波段为地形坡度，第二波段为视角，第三波段为收缩率，第四波段为局部入射角。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Supplemental Radar Products")]
		public object? OutGeometricDistortion { get; set; }

		/// <summary>
		/// <para>Out Geometric Distortion Mask</para>
		/// <para>1 波段几何畸变掩膜雷达数据集。 像素使用六个唯一值进行分类，每种畸变类型一个：</para>
		/// <para>未指定 - 值为 0</para>
		/// <para>收缩 - 值为 1</para>
		/// <para>延长 - 值为 2</para>
		/// <para>阴影 - 值为 3</para>
		/// <para>重叠 - 值为 4</para>
		/// <para>重叠和阴影 - 值为 5</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Supplemental Radar Products")]
		public object? OutGeometricDistortionMask { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ApplyRadiometricTerrainFlattening SetEnviroment(object? cellAlignment = null , object? cellSize = null , object? compression = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Apply geoid correction</para>
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

		/// <summary>
		/// <para>Calibration Type</para>
		/// </summary>
		public enum CalibrationTypeEnum 
		{
			/// <summary>
			/// <para>Sigma nought—将使用与 DEM 局部相切的平面单位面积来校正 beta nought 反向散射。</para>
			/// </summary>
			[GPValue("SIGMA_NOUGHT")]
			[Description("Sigma nought")]
			Sigma_nought,

			/// <summary>
			/// <para>Gamma nought—将使用 DEM 对区域进行精确计算来校正 beta nought 反向散射。 这是默认设置。</para>
			/// </summary>
			[GPValue("GAMMA_NOUGHT")]
			[Description("Gamma nought")]
			Gamma_nought,

		}

#endregion
	}
}
