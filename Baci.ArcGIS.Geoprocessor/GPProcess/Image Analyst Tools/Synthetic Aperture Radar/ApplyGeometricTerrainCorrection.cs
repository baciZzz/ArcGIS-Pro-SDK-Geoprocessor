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
	/// <para>Apply Geometric Terrain Correction</para>
	/// <para>Orthorectifies the input synthetic aperture radar (SAR) data using a range-Doppler backgeocoding algorithm.</para>
	/// </summary>
	public class ApplyGeometricTerrainCorrection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar  Data</para>
		/// <para>The input radar data.</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>The corrected geometric terrain radar data.</para>
		/// </param>
		public ApplyGeometricTerrainCorrection(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Geometric Terrain Correction</para>
		/// </summary>
		public override string DisplayName() => "Apply Geometric Terrain Correction";

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
		/// <para>The input radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>The corrected geometric terrain radar data.</para>
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
		/// <para>DEM Raster</para>
		/// <para>The input DEM.</para>
		/// <para>If no DEM is specified or in areas that are not covered by a specified DEM, an approximated DEM, interpolated from metadata tie points, will be created.</para>
		/// <para>Use the tie-point approach for full ocean radar scenes only; specify a DEM whenever land features are included in the radar scene.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InDemRaster { get; set; }

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

#endregion
	}
}
