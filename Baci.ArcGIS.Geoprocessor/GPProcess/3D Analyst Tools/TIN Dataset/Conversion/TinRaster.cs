using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>TIN To Raster</para>
	/// <para>TIN 转栅格</para>
	/// <para>使用 z 值将输入 TIN 插值成栅格。</para>
	/// </summary>
	public class TinRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出栅格的位置和名称。 将栅格数据集存储到地理数据库或文件夹（例如 Esri GRID）时，请勿向栅格数据集的名称添加文件扩展名。 在将栅格存储到文件夹中时，可提供文件扩展名以定义栅格的格式，例如 .tif（生成 GeoTIFF）或 .img（生成 ERDAS IMAGINE 格式文件）。</para>
		/// <para>如果栅格存储为 TIFF 文件或存储在地理数据库中，可使用地理处理环境设置指定其栅格压缩类型和质量。</para>
		/// </param>
		public TinRaster(object InTin, object OutRaster)
		{
			this.InTin = InTin;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN 转栅格</para>
		/// </summary>
		public override string DisplayName() => "TIN 转栅格";

		/// <summary>
		/// <para>Tool Name : TinRaster</para>
		/// </summary>
		public override string ToolName() => "TinRaster";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinRaster</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinRaster";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutRaster, DataType!, Method!, SampleDistance!, ZFactor!, SampleValue! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出栅格的位置和名称。 将栅格数据集存储到地理数据库或文件夹（例如 Esri GRID）时，请勿向栅格数据集的名称添加文件扩展名。 在将栅格存储到文件夹中时，可提供文件扩展名以定义栅格的格式，例如 .tif（生成 GeoTIFF）或 .img（生成 ERDAS IMAGINE 格式文件）。</para>
		/// <para>如果栅格存储为 TIFF 文件或存储在地理数据库中，可使用地理处理环境设置指定其栅格压缩类型和质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

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
		/// <para>Method</para>
		/// <para>该插值方法用于创建栅格。</para>
		/// <para>线性—通过向 TIN 三角形应用线性插值法来计算像元值。这是默认设置。</para>
		/// <para>自然邻域法—通过使用 TIN 三角形的自然邻域插值法计算像元值</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>用于定义输出栅格的像元大小的采样方法和距离。</para>
		/// <para>观测—定义分割输出栅格最长边上的像元数。默认方法使用的值为 250。</para>
		/// <para>像元大小—定义输出栅格的像元大小。</para>
		/// <para><see cref="SampleDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SampleDistance { get; set; } = "OBSERVATIONS";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Sampling Value</para>
		/// <para>用于指定输出栅格像元大小的采样距离对应的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SampleValue { get; set; } = "250";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinRaster SetEnviroment(int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? pyramid = null, object? rasterStatistics = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

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
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>线性—通过向 TIN 三角形应用线性插值法来计算像元值。这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>自然邻域法—通过使用 TIN 三角形的自然邻域插值法计算像元值</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("自然邻域法")]
			Natural_Neighbors,

		}

		/// <summary>
		/// <para>Sampling Distance</para>
		/// </summary>
		public enum SampleDistanceEnum 
		{
			/// <summary>
			/// <para>观测—定义分割输出栅格最长边上的像元数。默认方法使用的值为 250。</para>
			/// </summary>
			[GPValue("OBSERVATIONS")]
			[Description("观测")]
			Observations,

			/// <summary>
			/// <para>像元大小—定义输出栅格的像元大小。</para>
			/// </summary>
			[GPValue("CELLSIZE")]
			[Description("像元大小")]
			Cell_Size,

		}

#endregion
	}
}
