using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>LAS Dataset To Raster</para>
	/// <para>LAS 数据集转栅格</para>
	/// <para>使用存储在 LAS 数据集所引用的激光雷达点中的高程、强度或 RGB 值创建栅格。</para>
	/// </summary>
	public class LasDatasetToRaster : AbstractGPProcess
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
		public LasDatasetToRaster(object InLasDataset, object OutRaster)
		{
			this.InLasDataset = InLasDataset;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS 数据集转栅格</para>
		/// </summary>
		public override string DisplayName() => "LAS 数据集转栅格";

		/// <summary>
		/// <para>Tool Name : LasDatasetToRaster</para>
		/// </summary>
		public override string ToolName() => "LasDatasetToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.LasDatasetToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.LasDatasetToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutRaster, ValueField!, InterpolationType!, DataType!, SamplingType!, SamplingValue!, ZFactor! };

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
		/// <para>Value Field</para>
		/// <para>将用于生成栅格输出的激光雷达数据。</para>
		/// <para>高程—激光雷达文件的高程将用于创建栅格。这是默认设置。</para>
		/// <para>强度—激光雷达文件的强度信息将用于创建栅格。</para>
		/// <para>RGB—激光雷达点的 RGB 值将用于创建 3 波段影像。</para>
		/// <para><see cref="ValueFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ValueField { get; set; } = "ELEVATION";

		/// <summary>
		/// <para>Interpolation Type</para>
		/// <para>插值法将用于确定输出栅格的像元值。</para>
		/// <para>分组方法提供了使用落入其范围内的点来确定每个输出像元的像元分配方法，还提供了空填充方法来确定不包含任何 LAS 点的像元值。</para>
		/// <para>&lt;bold&gt;像元分配方法&lt;/bold&gt;</para>
		/// <para>AVERAGE - 分配像元中所有点的平均值。这是默认设置。</para>
		/// <para>MINIMUM - 分配在像元内的点中找到的最小值。</para>
		/// <para>MAXIMUM - 分配在像元内的点中找到的最大值。</para>
		/// <para>IDW - 使用反距离权重插值确定像元值。</para>
		/// <para>NEAREST - 使用最邻近分配法确定像元值。</para>
		/// <para>&lt;bold&gt;空填充方法&lt;/bold&gt;</para>
		/// <para>NONE - 将 NoData 分配到像元。</para>
		/// <para>SIMPLE - 立即求出 NoData 像元周围数据像元的平均值以消除较小的空区域。</para>
		/// <para>LINEAR - 三角测量横跨空区域，并使用三角测量值的线性插值确定像元值。这是默认设置。</para>
		/// <para>NATURAL_NEIGHBOR - 使用自然邻域法插值确定像元值。</para>
		/// <para>三角测量插值方法使用基于 TIN 的方法获得像元值，同时还将使用窗口大小技术通过细化 LAS 数据采样的方法加快处理时间。</para>
		/// <para>&lt;bold&gt;三角测量方法&lt;/bold&gt;</para>
		/// <para>Linear - 使用线性插值确定像元值。</para>
		/// <para>Natural Neighbors - 使用自然邻域法插值确定像元值。</para>
		/// <para>&lt;bold&gt;窗口大小选择方法&lt;/bold&gt;</para>
		/// <para>Maximum - 保持具有每个窗口大小中最高值的点。这是默认设置。</para>
		/// <para>Minimum - 保持具有每个窗口大小中最低值的点。</para>
		/// <para>Closest To Mean - 保持其值最接近窗口大小中所有点的平均值的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GP3DAInterpolate()]
		public object? InterpolationType { get; set; } = "BINNING AVERAGE LINEAR";

		/// <summary>
		/// <para>Output Data Type</para>
		/// <para>指定输出栅格中所存储数值的类型。</para>
		/// <para>浮点型—输出栅格将使用 32 位浮点型，支持介于 -3.402823466e+38 到 3.402823466e+38 之间的值。 这是默认设置。</para>
		/// <para>整型—输出栅格将使用合适的整型位深度。 该选项可将 z 值四舍五入为最接近的整数值，并将该整数写入每个栅格像元值。</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; } = "FLOAT";

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
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasDatasetToRaster SetEnviroment(int? autoCommit = null, object? cellSize = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? pyramid = null, object? rasterStatistics = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Value Field</para>
		/// </summary>
		public enum ValueFieldEnum 
		{
			/// <summary>
			/// <para>高程—激光雷达文件的高程将用于创建栅格。这是默认设置。</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("高程")]
			Elevation,

			/// <summary>
			/// <para>强度—激光雷达文件的强度信息将用于创建栅格。</para>
			/// </summary>
			[GPValue("INTENSITY")]
			[Description("强度")]
			Intensity,

			/// <summary>
			/// <para>RGB—激光雷达点的 RGB 值将用于创建 3 波段影像。</para>
			/// </summary>
			[GPValue("RGB")]
			[Description("RGB")]
			RGB,

		}

		/// <summary>
		/// <para>Output Data Type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>浮点型—输出栅格将使用 32 位浮点型，支持介于 -3.402823466e+38 到 3.402823466e+38 之间的值。 这是默认设置。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型")]
			Floating_Point,

			/// <summary>
			/// <para>整型—输出栅格将使用合适的整型位深度。 该选项可将 z 值四舍五入为最接近的整数值，并将该整数写入每个栅格像元值。</para>
			/// </summary>
			[GPValue("INT")]
			[Description("整型")]
			Integer,

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
