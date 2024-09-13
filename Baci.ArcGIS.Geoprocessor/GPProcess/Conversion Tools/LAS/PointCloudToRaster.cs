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
	/// <para>Point Cloud To Raster</para>
	/// <para>点云转栅格</para>
	/// <para>根据点云场景图层包文件 (*.slpk) 中的高度值创建栅格表面。</para>
	/// </summary>
	public class PointCloudToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Input Point Cloud</para>
		/// <para>将处理的点云场景图层包文件 (*.slpk)。</para>
		/// </param>
		/// <param name="CellSize">
		/// <para>Cell Size</para>
		/// <para>输出栅格中每个像元的长度和宽度。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出栅格的位置和名称。 将栅格数据集存储到地理数据库或文件夹（例如 Esri GRID）时，请勿向栅格数据集的名称添加文件扩展名。 在将栅格存储到文件夹中时，可提供文件扩展名以定义栅格的格式，例如 .tif（生成 GeoTIFF）或 .img（生成 ERDAS IMAGINE 格式文件）。</para>
		/// <para>如果栅格存储为 TIFF 文件或存储在地理数据库中，可使用地理处理环境设置指定其栅格压缩类型和质量。</para>
		/// </param>
		public PointCloudToRaster(object InPointCloud, object CellSize, object OutRaster)
		{
			this.InPointCloud = InPointCloud;
			this.CellSize = CellSize;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 点云转栅格</para>
		/// </summary>
		public override string DisplayName() => "点云转栅格";

		/// <summary>
		/// <para>Tool Name : PointCloudToRaster</para>
		/// </summary>
		public override string ToolName() => "PointCloudToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.PointCloudToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.PointCloudToRaster";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointCloud, CellSize, OutRaster, CellAssignment!, VoidFill!, ZFactor! };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>将处理的点云场景图层包文件 (*.slpk)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>输出栅格中每个像元的长度和宽度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出栅格的位置和名称。 将栅格数据集存储到地理数据库或文件夹（例如 Esri GRID）时，请勿向栅格数据集的名称添加文件扩展名。 在将栅格存储到文件夹中时，可提供文件扩展名以定义栅格的格式，例如 .tif（生成 GeoTIFF）或 .img（生成 ERDAS IMAGINE 格式文件）。</para>
		/// <para>如果栅格存储为 TIFF 文件或存储在地理数据库中，可使用地理处理环境设置指定其栅格压缩类型和质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Cell Assignment Type</para>
		/// <para>指定用于将值分配给包含点的像元的方法。</para>
		/// <para>平均高度—像元值将由像元中所有点的 z 值的平均值定义。 这是默认设置。</para>
		/// <para>最小高度—像元值将由像元中各点的最低 z 值定义。</para>
		/// <para>最大高度—像元值将由像元中各点的最高 z 值定义。</para>
		/// <para>反距离权重法—将使用反距离权重插值法在像元中心对像元值进行插值，该方法根据给定像元与像元中心的距离对其邻域中的每个 LAS 点应用线性权重。</para>
		/// <para>最邻近法—像元值将基于与像元中心最近点的高度进行分配。</para>
		/// <para><see cref="CellAssignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CellAssignment { get; set; } = "AVERAGE";

		/// <summary>
		/// <para>Void Fill Method</para>
		/// <para>指定将用于在不包含点的插值区域内进行像元值插值的方法。</para>
		/// <para>无—不会为不包含点的栅格像元分配任何值。</para>
		/// <para>简单—对于紧邻空像元的像元中的点，其 z 值将被平均以消除小空白。</para>
		/// <para>线性—空白区域将分割为三角形，然后将使用线性插值法分配像元值。 这是默认设置。</para>
		/// <para>自然邻域法—将使用自然邻域法插值确定像元值。</para>
		/// <para><see cref="VoidFillEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? VoidFill { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时 z 值保持不变。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointCloudToRaster SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? pyramid = null , object? rasterStatistics = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell Assignment Type</para>
		/// </summary>
		public enum CellAssignmentEnum 
		{
			/// <summary>
			/// <para>平均高度—像元值将由像元中所有点的 z 值的平均值定义。 这是默认设置。</para>
			/// </summary>
			[GPValue("AVERAGE")]
			[Description("平均高度")]
			Average_Height,

			/// <summary>
			/// <para>最小高度—像元值将由像元中各点的最低 z 值定义。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小高度")]
			Minimum_Height,

			/// <summary>
			/// <para>最大高度—像元值将由像元中各点的最高 z 值定义。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大高度")]
			Maximum_Height,

			/// <summary>
			/// <para>最邻近法—像元值将基于与像元中心最近点的高度进行分配。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近法")]
			Nearest_Neighbor,

		}

		/// <summary>
		/// <para>Void Fill Method</para>
		/// </summary>
		public enum VoidFillEnum 
		{
			/// <summary>
			/// <para>无—不会为不包含点的栅格像元分配任何值。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>简单—对于紧邻空像元的像元中的点，其 z 值将被平均以消除小空白。</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("简单")]
			Simple,

			/// <summary>
			/// <para>线性—空白区域将分割为三角形，然后将使用线性插值法分配像元值。 这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>自然邻域法—将使用自然邻域法插值确定像元值。</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBOR")]
			[Description("自然邻域法")]
			Natural_Neighbor,

		}

#endregion
	}
}
