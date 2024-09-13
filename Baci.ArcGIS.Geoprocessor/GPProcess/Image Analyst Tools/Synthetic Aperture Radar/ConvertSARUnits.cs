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
	/// <para>转换 SAR 单位</para>
	/// <para>在振幅和功率之间以及线性和分贝 (dB) 之间转换输入合成孔径雷达 (SAR) 数据的比例。</para>
	/// </summary>
	public class ConvertSARUnits : AbstractGPProcess
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
		/// <para>转换的雷达数据集。</para>
		/// </param>
		public ConvertSARUnits(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换 SAR 单位</para>
		/// </summary>
		public override string DisplayName() => "转换 SAR 单位";

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
		/// <para>输入雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>转换的雷达数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>Conversion Type</para>
		/// <para>指定将应用的反向散射转换类型。</para>
		/// <para>线性转 dB—无单位值将转换为分贝 (dB) 值。 这是默认设置。</para>
		/// <para>dB 转线性—dB 值将转换为无单位值。</para>
		/// <para>振幅转功率—通过计算振幅的平方，将振幅值将转换为功率值。</para>
		/// <para>功率转振幅—通过计算功率的平方根，将功率值转换为振幅值。</para>
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
			/// <para>线性转 dB—无单位值将转换为分贝 (dB) 值。 这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR_TO_DB")]
			[Description("线性转 dB")]
			Linear_to_dB,

			/// <summary>
			/// <para>dB 转线性—dB 值将转换为无单位值。</para>
			/// </summary>
			[GPValue("DB_TO_LINEAR")]
			[Description("dB 转线性")]
			dB_to_linear,

			/// <summary>
			/// <para>振幅转功率—通过计算振幅的平方，将振幅值将转换为功率值。</para>
			/// </summary>
			[GPValue("AMPLITUDE_TO_POWER")]
			[Description("振幅转功率")]
			Amplitude_to_power,

			/// <summary>
			/// <para>功率转振幅—通过计算功率的平方根，将功率值转换为振幅值。</para>
			/// </summary>
			[GPValue("POWER_TO_AMPLITUDE")]
			[Description("功率转振幅")]
			Power_to_amplitude,

		}

#endregion
	}
}
