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
	/// <para>Apply Radiometric Calibration</para>
	/// <para>应用辐射校准</para>
	/// <para>校正输入合成孔径雷达 (SAR) 数据中的系统误差，并将雷达反射率转换为参考平面上的雷达反向散射。</para>
	/// </summary>
	public class ApplyRadiometricCalibration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>校准的雷达数据。</para>
		/// </param>
		public ApplyRadiometricCalibration(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用辐射校准</para>
		/// </summary>
		public override string DisplayName() => "应用辐射校准";

		/// <summary>
		/// <para>Tool Name : ApplyRadiometricCalibration</para>
		/// </summary>
		public override string ToolName() => "ApplyRadiometricCalibration";

		/// <summary>
		/// <para>Tool Excute Name : ia.ApplyRadiometricCalibration</para>
		/// </summary>
		public override string ExcuteName() => "ia.ApplyRadiometricCalibration";

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
		public override object[] Parameters() => new object[] { InRadarData, OutRadarData, PolarizationBands!, CalibrationType! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>校准的雷达数据。</para>
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
		/// <para>Calibration Type</para>
		/// <para>指定将应用的校准类型。</para>
		/// <para>Beta nought—雷达反射率将被校准为倾斜范围上单位面积的反向散射。 这是默认设置。</para>
		/// <para>Sigma nought—返回的反向散射将从地面上的单位区域校准到天线，该平面与椭圆体局部相切。 这被称为雷达横截面。Sigma nought 值因入射角、波长、极化、地形和表面散射属性而有所不同。</para>
		/// <para>Gamma nought—返回的反向散射将从与垂直于倾斜范围的平面对齐的单位区域校准到天线。 这将使用相对于椭球体的入射角来归一化 gamma nought。Gamma nought 值因波长、极化、地形和表面散射属性而有所不同。</para>
		/// <para><see cref="CalibrationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationType { get; set; } = "BETA_NOUGHT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ApplyRadiometricCalibration SetEnviroment(object? cellAlignment = null , object? cellSize = null , object? compression = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Calibration Type</para>
		/// </summary>
		public enum CalibrationTypeEnum 
		{
			/// <summary>
			/// <para>Beta nought—雷达反射率将被校准为倾斜范围上单位面积的反向散射。 这是默认设置。</para>
			/// </summary>
			[GPValue("BETA_NOUGHT")]
			[Description("Beta nought")]
			Beta_nought,

			/// <summary>
			/// <para>Sigma nought—返回的反向散射将从地面上的单位区域校准到天线，该平面与椭圆体局部相切。 这被称为雷达横截面。Sigma nought 值因入射角、波长、极化、地形和表面散射属性而有所不同。</para>
			/// </summary>
			[GPValue("SIGMA_NOUGHT")]
			[Description("Sigma nought")]
			Sigma_nought,

			/// <summary>
			/// <para>Gamma nought—返回的反向散射将从与垂直于倾斜范围的平面对齐的单位区域校准到天线。 这将使用相对于椭球体的入射角来归一化 gamma nought。Gamma nought 值因波长、极化、地形和表面散射属性而有所不同。</para>
			/// </summary>
			[GPValue("GAMMA_NOUGHT")]
			[Description("Gamma nought")]
			Gamma_nought,

		}

#endregion
	}
}
