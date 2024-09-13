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
	/// <para>LAS Point Statistics As Raster</para>
	/// <para>用作栅格的 LAS 点统计数据</para>
	/// <para>创建栅格，栅格的像元值反映的是 LAS 数据集所引用 LAS 文件的测量值的相关统计信息。</para>
	/// </summary>
	public class LasPointStatsAsRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出栅格的位置和名称。 将栅格数据集存储到地理数据库或文件夹（例如 Esri GRID）时，请勿向栅格数据集的名称添加文件扩展名。 在将栅格存储到文件夹中时，可提供文件扩展名以定义栅格的格式，例如 .tif（生成 GeoTIFF）或 .img（生成 ERDAS IMAGINE 格式文件）。</para>
		/// <para>如果栅格存储为 TIFF 文件或存储在地理数据库中，可使用地理处理环境设置指定其栅格压缩类型和质量。</para>
		/// </param>
		public LasPointStatsAsRaster(object InLasDataset, object OutRaster)
		{
			this.InLasDataset = InLasDataset;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 用作栅格的 LAS 点统计数据</para>
		/// </summary>
		public override string DisplayName() => "用作栅格的 LAS 点统计数据";

		/// <summary>
		/// <para>Tool Name : LasPointStatsAsRaster</para>
		/// </summary>
		public override string ToolName() => "LasPointStatsAsRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.LasPointStatsAsRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.LasPointStatsAsRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutRaster, Method!, SamplingType!, SamplingValue! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出栅格的位置和名称。 将栅格数据集存储到地理数据库或文件夹（例如 Esri GRID）时，请勿向栅格数据集的名称添加文件扩展名。 在将栅格存储到文件夹中时，可提供文件扩展名以定义栅格的格式，例如 .tif（生成 GeoTIFF）或 .img（生成 ERDAS IMAGINE 格式文件）。</para>
		/// <para>如果栅格存储为 TIFF 文件或存储在地理数据库中，可使用地理处理环境设置指定其栅格压缩类型和质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>对输出栅格每个像元内的 LAS 点所采集的统计数据的类型。</para>
		/// <para>脉冲计数—最后回波点的数量。</para>
		/// <para>点计数—所有回波中的点的数量。</para>
		/// <para>最常见的最后回波—最常见的最后回波值。</para>
		/// <para>最常见类代码—最常见的类代码。</para>
		/// <para>强度值范围—强度值范围。</para>
		/// <para>高程值范围—高程值范围。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PULSE_COUNT";

		/// <summary>
		/// <para>Sampling Type</para>
		/// <para>指定将用于解译采样值参数值以定义输出栅格分辨率的方法。</para>
		/// <para>观测—将使用分割 LAS 数据集范围的最长边的像元数。</para>
		/// <para>像元大小—将使用输出栅格的像元大小。 这是默认设置。</para>
		/// <para><see cref="SamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SamplingType { get; set; } = "CELLSIZE";

		/// <summary>
		/// <para>Sampling Value</para>
		/// <para>与采样类型结合使用以定义输出栅格分辨率的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SamplingValue { get; set; } = "10";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasPointStatsAsRaster SetEnviroment(int? autoCommit = null , object? cellSize = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? pyramid = null , object? rasterStatistics = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>脉冲计数—最后回波点的数量。</para>
			/// </summary>
			[GPValue("PULSE_COUNT")]
			[Description("脉冲计数")]
			Pulse_Count,

			/// <summary>
			/// <para>点计数—所有回波中的点的数量。</para>
			/// </summary>
			[GPValue("POINT_COUNT")]
			[Description("点计数")]
			Point_Count,

			/// <summary>
			/// <para>最常见的最后回波—最常见的最后回波值。</para>
			/// </summary>
			[GPValue("PREDOMINANT_LAST_RETURN")]
			[Description("最常见的最后回波")]
			Most_Frequent_Last_Return,

			/// <summary>
			/// <para>最常见类代码—最常见的类代码。</para>
			/// </summary>
			[GPValue("PREDOMINANT_CLASS")]
			[Description("最常见类代码")]
			Most_Frequent_Class_Code,

			/// <summary>
			/// <para>强度值范围—强度值范围。</para>
			/// </summary>
			[GPValue("INTENSITY_RANGE")]
			[Description("强度值范围")]
			Range_of_Intensity_Values,

			/// <summary>
			/// <para>高程值范围—高程值范围。</para>
			/// </summary>
			[GPValue("Z_RANGE")]
			[Description("高程值范围")]
			Range_of_Elevation_Values,

		}

		/// <summary>
		/// <para>Sampling Type</para>
		/// </summary>
		public enum SamplingTypeEnum 
		{
			/// <summary>
			/// <para>观测—将使用分割 LAS 数据集范围的最长边的像元数。</para>
			/// </summary>
			[GPValue("OBSERVATIONS")]
			[Description("观测")]
			Observations,

			/// <summary>
			/// <para>像元大小—将使用输出栅格的像元大小。 这是默认设置。</para>
			/// </summary>
			[GPValue("CELLSIZE")]
			[Description("像元大小")]
			Cell_Size,

		}

#endregion
	}
}
