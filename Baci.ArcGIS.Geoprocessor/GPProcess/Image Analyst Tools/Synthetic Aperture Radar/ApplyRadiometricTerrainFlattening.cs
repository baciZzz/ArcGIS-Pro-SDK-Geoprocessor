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
	/// <para>Apply Radiometric Terrain Flattening</para>
	/// <para>Corrects the input synthetic aperture radar (SAR) data for radiometric distortions due to topography.</para>
	/// </summary>
	public class ApplyRadiometricTerrainFlattening : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// <para>The data must be radiometrically calibrated to beta nought.</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>The radiometrically terrain-flattened radar data.</para>
		/// </param>
		/// <param name="InDemRaster">
		/// <para>DEM Raster</para>
		/// <para>The input DEM.</para>
		/// <para>The DEM will be used to estimate the local illuminated area and the local incidence angle.</para>
		/// </param>
		public ApplyRadiometricTerrainFlattening(object InRadarData, object OutRadarData, object InDemRaster)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
			this.InDemRaster = InDemRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Radiometric Terrain Flattening</para>
		/// </summary>
		public override string DisplayName() => "Apply Radiometric Terrain Flattening";

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
		/// <para>The input radar data.</para>
		/// <para>The data must be radiometrically calibrated to beta nought.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>The radiometrically terrain-flattened radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>DEM Raster</para>
		/// <para>The input DEM.</para>
		/// <para>The DEM will be used to estimate the local illuminated area and the local incidence angle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDemRaster { get; set; }

		/// <summary>
		/// <para>Apply geoid correction</para>
		/// <para>Specifies whether the vertical reference system of the input DEM will be transformed to ellipsoidal height. Most elevation datasets are referenced to sea level orthometric height, so a correction is required in these cases to convert to ellipsoidal height.</para>
		/// <para>Checked—A geoid correction will be made to convert orthometric height to ellipsoidal height (based on EGM96 geoid). This is the default.</para>
		/// <para>Unchecked—No geoid correction will be made. Use this option only if the DEM is expressed in ellipsoidal height.</para>
		/// <para><see cref="GeoidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Geoid { get; set; } = "true";

		/// <summary>
		/// <para>Polarization Bands</para>
		/// <para>The polarization bands that will be radiometrically terrain flattened.</para>
		/// <para>The first band is selected by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? PolarizationBands { get; set; }

		/// <summary>
		/// <para>Calibration Type</para>
		/// <para>Specifies whether the output will be terrain flattened using sigma nought or gamma nought.</para>
		/// <para>Gamma nought— The beta nought backscatter will be corrected using an accurate computation of an area using a DEM. This is the default.</para>
		/// <para>Sigma nought— The beta nought backscatter will be corrected using the unit area of a plane that is locally tangent to the DEM.</para>
		/// <para><see cref="CalibrationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationType { get; set; } = "GAMMA_NOUGHT";

		/// <summary>
		/// <para>Out Scattering Area</para>
		/// <para>The scattering area radar dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Supplemental Radar Products")]
		public object? OutScatteringArea { get; set; }

		/// <summary>
		/// <para>Out Geometric Distortion</para>
		/// <para>The 4-band geometric distortion radar dataset. The first band is the terrain slope, the second band is look angle, the third band is the foreshortening ratio, and the fourth band is the local incidence angle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Supplemental Radar Products")]
		public object? OutGeometricDistortion { get; set; }

		/// <summary>
		/// <para>Out Geometric Distortion Mask</para>
		/// <para>The 1-band geometric distortion mask radar dataset. The pixels are classified using six unique values, one for each distortion type:</para>
		/// <para>Undetermined —Value of 0</para>
		/// <para>Foreshortening —Value of 1</para>
		/// <para>Lengthening —Value of 2</para>
		/// <para>Shadow —Value of 3</para>
		/// <para>Layover —Value of 4</para>
		/// <para>Layover and shadow —Value of 5</para>
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
			/// <para>Checked—A geoid correction will be made to convert orthometric height to ellipsoidal height (based on EGM96 geoid). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOID")]
			GEOID,

			/// <summary>
			/// <para>Unchecked—No geoid correction will be made. Use this option only if the DEM is expressed in ellipsoidal height.</para>
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
			/// <para>Sigma nought— The beta nought backscatter will be corrected using the unit area of a plane that is locally tangent to the DEM.</para>
			/// </summary>
			[GPValue("SIGMA_NOUGHT")]
			[Description("Sigma nought")]
			Sigma_nought,

			/// <summary>
			/// <para>Gamma nought— The beta nought backscatter will be corrected using an accurate computation of an area using a DEM. This is the default.</para>
			/// </summary>
			[GPValue("GAMMA_NOUGHT")]
			[Description("Gamma nought")]
			Gamma_nought,

		}

#endregion
	}
}
