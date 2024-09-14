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
	/// <para>Terrain To Raster</para>
	/// <para>Terrain 转栅格</para>
	/// <para>使用 z 值将 terrain 数据集插值成栅格。</para>
	/// </summary>
	public class TerrainToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出栅格的位置和名称。 将栅格数据集存储到地理数据库或文件夹（例如 Esri GRID）时，请勿向栅格数据集的名称添加文件扩展名。 在将栅格存储到文件夹中时，可提供文件扩展名以定义栅格的格式，例如 .tif（生成 GeoTIFF）或 .img（生成 ERDAS IMAGINE 格式文件）。</para>
		/// <para>如果栅格存储为 TIFF 文件或存储在地理数据库中，可使用地理处理环境设置指定其栅格压缩类型和质量。</para>
		/// </param>
		public TerrainToRaster(object InTerrain, object OutRaster)
		{
			this.InTerrain = InTerrain;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Terrain 转栅格</para>
		/// </summary>
		public override string DisplayName() => "Terrain 转栅格";

		/// <summary>
		/// <para>Tool Name : TerrainToRaster</para>
		/// </summary>
		public override string ToolName() => "TerrainToRaster";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TerrainToRaster</para>
		/// </summary>
		public override string ExcuteName() => "3d.TerrainToRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "compression", "configKeyword", "extent", "outputCoordinateSystem", "pyramid", "rasterStatistics", "snapRaster", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, OutRaster, DataType, Method, SampleDistance, PyramidLevelResolution, SampleValue };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

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
		public object DataType { get; set; } = "FLOAT";

		/// <summary>
		/// <para>Method</para>
		/// <para>插值方法将用于计算像元值。</para>
		/// <para>线性—将基于距离的权重应用于包含给定像元中心的三角形中各结点的 Z 值，然后计算加权值的总和以对像元值进行分配。这是默认设置。</para>
		/// <para>自然邻域法—应用使用泰森多边形的基于区域的权重方案确定像元值。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

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
		public object SampleDistance { get; set; } = "OBSERVATIONS";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Sampling Value</para>
		/// <para>用于指定输出栅格像元大小的采样距离对应的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SampleValue { get; set; } = "250";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TerrainToRaster SetEnviroment(int? autoCommit = null, object compression = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object pyramid = null, object rasterStatistics = null, object snapRaster = null, object terrainMemoryUsage = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, snapRaster: snapRaster, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
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
			/// <para>线性—将基于距离的权重应用于包含给定像元中心的三角形中各结点的 Z 值，然后计算加权值的总和以对像元值进行分配。这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>自然邻域法—应用使用泰森多边形的基于区域的权重方案确定像元值。</para>
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
