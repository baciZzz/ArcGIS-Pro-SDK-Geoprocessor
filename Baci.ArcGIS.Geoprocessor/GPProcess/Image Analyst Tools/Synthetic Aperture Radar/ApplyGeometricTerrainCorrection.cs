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
	/// <para>Apply Geometric Terrain Correction</para>
	/// <para>应用几何地形校正</para>
	/// <para>使用距离多普勒反向地理编码算法输入对合成孔径雷达 (SAR) 数据进行正射校正。</para>
	/// </summary>
	public class ApplyGeometricTerrainCorrection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar  Data</para>
		/// <para>输入雷达数据。</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>校正后的几何地形雷达数据。</para>
		/// </param>
		public ApplyGeometricTerrainCorrection(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用几何地形校正</para>
		/// </summary>
		public override string DisplayName() => "应用几何地形校正";

		/// <summary>
		/// <para>Tool Name : ApplyGeometricTerrainCorrection</para>
		/// </summary>
		public override string ToolName() => "ApplyGeometricTerrainCorrection";

		/// <summary>
		/// <para>Tool Excute Name : ia.ApplyGeometricTerrainCorrection</para>
		/// </summary>
		public override string ExcuteName() => "ia.ApplyGeometricTerrainCorrection";

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
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRadarData, OutRadarData, PolarizationBands!, InDemRaster!, Geoid! };

		/// <summary>
		/// <para>Input Radar  Data</para>
		/// <para>输入雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>校正后的几何地形雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>Polarization Bands</para>
		/// <para>要校正的极化波段。</para>
		/// <para>默认情况下，第一个波段处于选中状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? PolarizationBands { get; set; }

		/// <summary>
		/// <para>DEM Raster</para>
		/// <para>输入 DEM。</para>
		/// <para>如果未指定 DEM 或在指定 DEM 未覆盖的区域中，将创建从元数据连接点插值的近似 DEM。</para>
		/// <para>仅对完全海洋雷达场景使用连接点方法；当雷达场景中包含陆地要素时，必须指定 DEM。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InDemRaster { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ApplyGeometricTerrainCorrection SetEnviroment(object? cellAlignment = null, object? cellSize = null, object? compression = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
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

#endregion
	}
}
