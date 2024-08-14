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
	/// <para>Corrects systematic errors in the input synthetic aperture radar (SAR) data  and transforms radar reflectivity into radar backscatter on a reference plane.</para>
	/// </summary>
	public class ApplyRadiometricCalibration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>The calibrated radar data.</para>
		/// </param>
		public ApplyRadiometricCalibration(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Radiometric Calibration</para>
		/// </summary>
		public override string DisplayName => "Apply Radiometric Calibration";

		/// <summary>
		/// <para>Tool Name : ApplyRadiometricCalibration</para>
		/// </summary>
		public override string ToolName => "ApplyRadiometricCalibration";

		/// <summary>
		/// <para>Tool Excute Name : ia.ApplyRadiometricCalibration</para>
		/// </summary>
		public override string ExcuteName => "ia.ApplyRadiometricCalibration";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRadarData, OutRadarData, PolarizationBands!, CalibrationType! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>The calibrated radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>Polarization Bands</para>
		/// <para>The polarization bands to be corrected.</para>
		/// <para>The first band is selected by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? PolarizationBands { get; set; }

		/// <summary>
		/// <para>Calibration Type</para>
		/// <para>Specifies the type of calibration that will be applied.</para>
		/// <para>Beta nought—The radar reflectivity will be calibrated to backscatter for a unit area on the slant range. This is the default.</para>
		/// <para>Sigma nought— The backscatter returned will be calibrated to the antenna from a unit area on the ground with the plane locally tangent to the ellipsoid. This is known as the radar cross section. Sigma nought values vary due to incidence angle, wavelength, polarization, terrain, and surface scattering properties.</para>
		/// <para>Gamma nought—The backscatter returned will be calibrated to the antenna from a unit area aligned with the plane perpendicular to the slant range. This normalizes gamma nought using the incidence angle relative to the ellipsoid.Gamma nought values vary due to wavelength, polarization, terrain, and surface scattering properties.</para>
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
			/// <para>Beta nought—The radar reflectivity will be calibrated to backscatter for a unit area on the slant range. This is the default.</para>
			/// </summary>
			[GPValue("BETA_NOUGHT")]
			[Description("Beta nought")]
			Beta_nought,

			/// <summary>
			/// <para>Sigma nought— The backscatter returned will be calibrated to the antenna from a unit area on the ground with the plane locally tangent to the ellipsoid. This is known as the radar cross section. Sigma nought values vary due to incidence angle, wavelength, polarization, terrain, and surface scattering properties.</para>
			/// </summary>
			[GPValue("SIGMA_NOUGHT")]
			[Description("Sigma nought")]
			Sigma_nought,

			/// <summary>
			/// <para>Gamma nought—The backscatter returned will be calibrated to the antenna from a unit area aligned with the plane perpendicular to the slant range. This normalizes gamma nought using the incidence angle relative to the ellipsoid.Gamma nought values vary due to wavelength, polarization, terrain, and surface scattering properties.</para>
			/// </summary>
			[GPValue("GAMMA_NOUGHT")]
			[Description("Gamma nought")]
			Gamma_nought,

		}

#endregion
	}
}
