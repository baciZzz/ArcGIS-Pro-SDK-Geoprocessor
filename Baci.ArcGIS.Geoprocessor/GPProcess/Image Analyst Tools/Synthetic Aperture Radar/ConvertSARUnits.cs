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
	/// <para>Convert SAR Units</para>
	/// <para>Convert SAR Units</para>
	/// <para>Converts the scaling of the input synthetic aperture radar (SAR) data between amplitude and power and between  linear and decibels (dB).</para>
	/// </summary>
	public class ConvertSARUnits : AbstractGPProcess
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
		/// <para>The converted radar dataset.</para>
		/// </param>
		public ConvertSARUnits(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert SAR Units</para>
		/// </summary>
		public override string DisplayName() => "Convert SAR Units";

		/// <summary>
		/// <para>Tool Name : ConvertSARUnits</para>
		/// </summary>
		public override string ToolName() => "ConvertSARUnits";

		/// <summary>
		/// <para>Tool Excute Name : ia.ConvertSARUnits</para>
		/// </summary>
		public override string ExcuteName() => "ia.ConvertSARUnits";

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
		public override object[] Parameters() => new object[] { InRadarData, OutRadarData, ConversionType! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>The converted radar dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>Conversion Type</para>
		/// <para>Specifies the type of backscatter conversion that will be applied.</para>
		/// <para>Linear to dB—The unitless value will be converted to decibels (dB) values. This is the default.</para>
		/// <para>dB to linear—The dB values will be converted to unitless values.</para>
		/// <para>Amplitude to power—The amplitude values will be converted to power values by squaring the amplitude.</para>
		/// <para>Power to amplitude—The power values will converted to amplitude values by applying the square root to the power.</para>
		/// <para><see cref="ConversionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConversionType { get; set; } = "LINEAR_TO_DB";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertSARUnits SetEnviroment(object? cellAlignment = null , object? cellSize = null , object? compression = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conversion Type</para>
		/// </summary>
		public enum ConversionTypeEnum 
		{
			/// <summary>
			/// <para>Linear to dB—The unitless value will be converted to decibels (dB) values. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR_TO_DB")]
			[Description("Linear to dB")]
			Linear_to_dB,

			/// <summary>
			/// <para>dB to linear—The dB values will be converted to unitless values.</para>
			/// </summary>
			[GPValue("DB_TO_LINEAR")]
			[Description("dB to linear")]
			dB_to_linear,

			/// <summary>
			/// <para>Amplitude to power—The amplitude values will be converted to power values by squaring the amplitude.</para>
			/// </summary>
			[GPValue("AMPLITUDE_TO_POWER")]
			[Description("Amplitude to power")]
			Amplitude_to_power,

			/// <summary>
			/// <para>Power to amplitude—The power values will converted to amplitude values by applying the square root to the power.</para>
			/// </summary>
			[GPValue("POWER_TO_AMPLITUDE")]
			[Description("Power to amplitude")]
			Power_to_amplitude,

		}

#endregion
	}
}
