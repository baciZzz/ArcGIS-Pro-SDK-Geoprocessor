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
	/// <para>Interpolate From Point Cloud</para>
	/// <para>基于点云进行插值</para>
	/// <para>从点云对数字地形模型 (DTM) 或数字表面模型 (DSM) 进行插值。</para>
	/// </summary>
	public class InterpolateFromPointCloud : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InContainer">
		/// <para>Input LAS Folder or Point Table</para>
		/// <para>文件、文件夹或要素图层的路径和名称。 输入可以是 LAS 文件的文件夹或正射映射工具的解决方案点表。</para>
		/// <para>LAS 文件可以是生成点云工具的输出，其中 LAS 点分为地面点和地上点两种类型。 解决方案点表为计算区域网平差工具或计算照相机模型工具的输出。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出栅格数据集的位置、名称和文件扩展名。</para>
		/// <para>可以以大多数可写栅格格式（例如 TIFF、CRF 或 IMG）创建输出。</para>
		/// </param>
		/// <param name="CellSize">
		/// <para>Cellsize</para>
		/// <para>输出栅格数据集的像元大小。</para>
		/// </param>
		/// <param name="InterpolationMethod">
		/// <para>Interpolation Method</para>
		/// <para>指定将用于从点云对输出栅格数据集进行插值的方法。</para>
		/// <para>TIN 线性插值法—将使用三角测量方法。 亦称作不规则三角网 (TIN) 线性插值法，适用于不规则分布的稀疏点，例如从区域网平差计算中得到的解决方案点。</para>
		/// <para>TIN 自然邻域插值法—将使用自然邻域法。 其与三角测量类似，但是生成的表面更为平滑且运算量更大。</para>
		/// <para>反距离权重平均插值法—将使用反距离权重 (IDW) 平均方法。 此方法适用于规则分布的密集点，例如通过生成点云工具得到的点云 LAS 文件。 IDW 搜索半径将根据平均点密度自动进行计算。</para>
		/// <para><see cref="InterpolationMethodEnum"/></para>
		/// </param>
		/// <param name="SmoothMethod">
		/// <para>Smoothing Method</para>
		/// <para>指定将用于平滑输出栅格数据集的滤波器。</para>
		/// <para>高斯 3 x 3—将使用具有 3 x 3 窗口的高斯滤波器。</para>
		/// <para>高斯 5 x 5—将使用具有 5 x 5 窗口的高斯滤波器。</para>
		/// <para>高斯 7 x 7—将使用具有 7 x 7 窗口的高斯滤波器。</para>
		/// <para>高斯 9 x 9—将使用具有 9 x 9 窗口的高斯滤波器。</para>
		/// <para>无平滑—将使用平滑滤波器。</para>
		/// <para><see cref="SmoothMethodEnum"/></para>
		/// </param>
		public InterpolateFromPointCloud(object InContainer, object OutRaster, object CellSize, object InterpolationMethod, object SmoothMethod)
		{
			this.InContainer = InContainer;
			this.OutRaster = OutRaster;
			this.CellSize = CellSize;
			this.InterpolationMethod = InterpolationMethod;
			this.SmoothMethod = SmoothMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于点云进行插值</para>
		/// </summary>
		public override string DisplayName() => "基于点云进行插值";

		/// <summary>
		/// <para>Tool Name : InterpolateFromPointCloud</para>
		/// </summary>
		public override string ToolName() => "InterpolateFromPointCloud";

		/// <summary>
		/// <para>Tool Excute Name : management.InterpolateFromPointCloud</para>
		/// </summary>
		public override string ExcuteName() => "management.InterpolateFromPointCloud";

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
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InContainer, OutRaster, CellSize, InterpolationMethod, SmoothMethod, SurfaceType!, FillDem! };

		/// <summary>
		/// <para>Input LAS Folder or Point Table</para>
		/// <para>文件、文件夹或要素图层的路径和名称。 输入可以是 LAS 文件的文件夹或正射映射工具的解决方案点表。</para>
		/// <para>LAS 文件可以是生成点云工具的输出，其中 LAS 点分为地面点和地上点两种类型。 解决方案点表为计算区域网平差工具或计算照相机模型工具的输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InContainer { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出栅格数据集的位置、名称和文件扩展名。</para>
		/// <para>可以以大多数可写栅格格式（例如 TIFF、CRF 或 IMG）创建输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>输出栅格数据集的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Interpolation Method</para>
		/// <para>指定将用于从点云对输出栅格数据集进行插值的方法。</para>
		/// <para>TIN 线性插值法—将使用三角测量方法。 亦称作不规则三角网 (TIN) 线性插值法，适用于不规则分布的稀疏点，例如从区域网平差计算中得到的解决方案点。</para>
		/// <para>TIN 自然邻域插值法—将使用自然邻域法。 其与三角测量类似，但是生成的表面更为平滑且运算量更大。</para>
		/// <para>反距离权重平均插值法—将使用反距离权重 (IDW) 平均方法。 此方法适用于规则分布的密集点，例如通过生成点云工具得到的点云 LAS 文件。 IDW 搜索半径将根据平均点密度自动进行计算。</para>
		/// <para><see cref="InterpolationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InterpolationMethod { get; set; } = "TRIANGULATION";

		/// <summary>
		/// <para>Smoothing Method</para>
		/// <para>指定将用于平滑输出栅格数据集的滤波器。</para>
		/// <para>高斯 3 x 3—将使用具有 3 x 3 窗口的高斯滤波器。</para>
		/// <para>高斯 5 x 5—将使用具有 5 x 5 窗口的高斯滤波器。</para>
		/// <para>高斯 7 x 7—将使用具有 7 x 7 窗口的高斯滤波器。</para>
		/// <para>高斯 9 x 9—将使用具有 9 x 9 窗口的高斯滤波器。</para>
		/// <para>无平滑—将使用平滑滤波器。</para>
		/// <para><see cref="SmoothMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SmoothMethod { get; set; } = "GAUSS5x5";

		/// <summary>
		/// <para>Surface Type</para>
		/// <para>指定是否创建数字地形模型或数字表面模型。</para>
		/// <para>数字地形模型—将通过仅插入地面点创建数字地形模型。</para>
		/// <para>数字表面模型—将通过插入所有点创建数字表面模型。</para>
		/// <para><see cref="SurfaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SurfaceType { get; set; } = "DTM";

		/// <summary>
		/// <para>Input Fill DEM</para>
		/// <para>用于填充 NoData 区域的 DEM 栅格输入。 NoData 区域可以存在于像素未从输入获得足够生成值所需信息的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? FillDem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolateFromPointCloud SetEnviroment(object? cellAlignment = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(cellAlignment: cellAlignment, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation Method</para>
		/// </summary>
		public enum InterpolationMethodEnum 
		{
			/// <summary>
			/// <para>TIN 线性插值法—将使用三角测量方法。 亦称作不规则三角网 (TIN) 线性插值法，适用于不规则分布的稀疏点，例如从区域网平差计算中得到的解决方案点。</para>
			/// </summary>
			[GPValue("TRIANGULATION")]
			[Description("TIN 线性插值法")]
			TIN_linear_interpolation,

			/// <summary>
			/// <para>TIN 自然邻域插值法—将使用自然邻域法。 其与三角测量类似，但是生成的表面更为平滑且运算量更大。</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBOR")]
			[Description("TIN 自然邻域插值法")]
			TIN_natural_neighbor_interpolation,

			/// <summary>
			/// <para>反距离权重平均插值法—将使用反距离权重 (IDW) 平均方法。 此方法适用于规则分布的密集点，例如通过生成点云工具得到的点云 LAS 文件。 IDW 搜索半径将根据平均点密度自动进行计算。</para>
			/// </summary>
			[GPValue("IDW")]
			[Description("反距离权重平均插值法")]
			Inverse_distance_weighted_average_interpolation,

		}

		/// <summary>
		/// <para>Smoothing Method</para>
		/// </summary>
		public enum SmoothMethodEnum 
		{
			/// <summary>
			/// <para>高斯 3 x 3—将使用具有 3 x 3 窗口的高斯滤波器。</para>
			/// </summary>
			[GPValue("GAUSS3x3")]
			[Description("高斯 3 x 3")]
			Gaussian_3_by_3,

			/// <summary>
			/// <para>高斯 5 x 5—将使用具有 5 x 5 窗口的高斯滤波器。</para>
			/// </summary>
			[GPValue("GAUSS5x5")]
			[Description("高斯 5 x 5")]
			Gaussian_5_by_5,

			/// <summary>
			/// <para>高斯 7 x 7—将使用具有 7 x 7 窗口的高斯滤波器。</para>
			/// </summary>
			[GPValue("GAUSS7x7")]
			[Description("高斯 7 x 7")]
			Gaussian_7_by_7,

			/// <summary>
			/// <para>高斯 9 x 9—将使用具有 9 x 9 窗口的高斯滤波器。</para>
			/// </summary>
			[GPValue("GAUSS9x9")]
			[Description("高斯 9 x 9")]
			Gaussian_9_by_9,

			/// <summary>
			/// <para>无平滑—将使用平滑滤波器。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无平滑")]
			No_smoothing,

		}

		/// <summary>
		/// <para>Surface Type</para>
		/// </summary>
		public enum SurfaceTypeEnum 
		{
			/// <summary>
			/// <para>数字地形模型—将通过仅插入地面点创建数字地形模型。</para>
			/// </summary>
			[GPValue("DTM")]
			[Description("数字地形模型")]
			Digital_terrain_model,

			/// <summary>
			/// <para>数字表面模型—将通过插入所有点创建数字表面模型。</para>
			/// </summary>
			[GPValue("DSM")]
			[Description("数字表面模型")]
			Digital_surface_model,

		}

#endregion
	}
}
