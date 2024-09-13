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
	/// <para>Create Point Cloud Scene Layer Content</para>
	/// <para>创建点云场景图层内容</para>
	/// <para>从 LAS、zLAS、LAZ 或 LAS 数据集输入在云中创建点云场景图层包 (.slpk) 或场景图层内容 (.i3sREST)。</para>
	/// </summary>
	public class CreatePointCloudSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>激光雷达数据（LAS、zLAS、LAZ 或 LAS 数据集），可用于创建场景图层包。 也可以通过选择包含文件的父文件夹来指定激光雷达数据。</para>
		/// </param>
		public CreatePointCloudSceneLayerPackage(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建点云场景图层内容</para>
		/// </summary>
		public override string DisplayName() => "创建点云场景图层内容";

		/// <summary>
		/// <para>Tool Name : CreatePointCloudSceneLayerPackage</para>
		/// </summary>
		public override string ToolName() => "CreatePointCloudSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreatePointCloudSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreatePointCloudSceneLayerPackage";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutSlpk!, OutCoorSystem!, TransformMethod!, Attributes!, PointSizeM!, XyMaxErrorM!, ZMaxErrorM!, InCoorSystem!, SceneLayerVersion!, TargetCloudConnection!, OutName! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>激光雷达数据（LAS、zLAS、LAZ 或 LAS 数据集），可用于创建场景图层包。 也可以通过选择包含文件的父文件夹来指定激光雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>输出场景图层包 (.slpk)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("slpk")]
		public object? OutSlpk { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>输出场景图层包的坐标系。 它可以是任意投影坐标系或自定义坐标系。 支持的地理坐标系包括 WGS 1984 和 China Geodetic Coordinate System 2000。 WGS 1984 和 EGM96 大地水准面分别是默认的水平和垂直坐标系。 可通过以下任一方式指定坐标系：</para>
		/// <para>指定 .prj 文件的路径。</para>
		/// <para>引用具有所需坐标系的数据集。</para>
		/// <para>使用 arcpy.SpatialReference 对象。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? OutCoorSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]],VERTCS[\"EGM96_Geoid\",VDATUM[\"EGM96_Geoid\"],PARAMETER[\"Vertical_Shift\",0.0],PARAMETER[\"Direction\",1.0],UNIT[\"Meter\",1.0]];-400 -400 1000000000;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>此基准面变换方法适用于输入图层坐标系所使用的基准面不同于输出坐标系的情况。 所有变换均为双向，而不管其名称隐含的方向如何。 例如，即使基准面变换为从 WGS 1984 到 NAD 1927，NAD_1927_to_WGS_1984_3 仍可正常运行。在椭圆体和重力相关的基准面以及两个与重力相关的基准面之间进行垂直基准面变换时，需要使用 ArcGIS 坐标系数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TransformMethod { get; set; }

		/// <summary>
		/// <para>Attributes to cache</para>
		/// <para>指定要包含在场景图层包中的源数据属性。 在其他查看器中使用内容时，可以访问这些值。 选择所需渲染和过滤选项需要的属性（例如，强度、回波、类代码、RGB）。 排除不需要的属性以降低存储。</para>
		/// <para>强度—将包含每个激光雷达点的激光脉冲的回波强度。</para>
		/// <para>RGB—将包含针对每个激光雷达点采集的 RGB 影像信息。</para>
		/// <para>LAS 标记—将包含分类和扫描方向标记。</para>
		/// <para>分类代码—将包含分类代码值。</para>
		/// <para>返回值—将包含激光雷达脉冲的离散回波编号</para>
		/// <para>用户数据—将包含可自定义属性的取值范围（0 到 255）。</para>
		/// <para>点源 ID—对于航空激光雷达，此值通常用于标识采集了给定激光雷达点的飞行路径，并将包含在内。</para>
		/// <para>GPS 时间—将包含从飞机发射激光点的 GPS 时间戳。 此时间以 GPS 一周的秒数表示，其中时间戳介于 0 和 604800 之间，并在星期日的午夜重置。</para>
		/// <para>扫描角度—将包含给定激光雷达点的激光扫描仪的角度方向。 值的范围从 -90 到 90。</para>
		/// <para>近红外—将包含针对每个激光雷达点采集的近红外记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Attributes { get; set; }

		/// <summary>
		/// <para>Point Size (m)</para>
		/// <para>激光雷达数据的点大小 对于机载激光雷达数据，默认值 0 或接近平均点间距的值通常为最佳。 对于地形激光雷达数据，点大小应与感兴趣区域所需的点间距匹配。 值以米为单位表示。 默认值 0 将自动确定输入数据集的最佳值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PointSizeM { get; set; } = "0";

		/// <summary>
		/// <para>XY Max Error (m)</para>
		/// <para>容许最大 x,y 误差。 容差越大，数据压缩越好，并且数据传输效率越高。 值以米为单位表示。 默认值为 0.001。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? XyMaxErrorM { get; set; } = "0.001";

		/// <summary>
		/// <para>Z Max Error (m)</para>
		/// <para>容许最大 z 误差。 容差越大，数据压缩越好，并且数据传输效率越高。 值以米为单位表示。 默认值为 0.001。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZMaxErrorM { get; set; } = "0.001";

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>输入 .laz 文件的坐标系。 此参数仅用于标头中不包含空间参考信息或在相同位置不具有 .prj 文件的 .laz 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InCoorSystem { get; set; }

		/// <summary>
		/// <para>Scene Layer Version</para>
		/// <para>生成的点云场景图层包的 Indexed 3D Scene Layer (I3S) 版本。 指定版本支持向后兼容，并允许与较早版本的 ArcGIS 共享场景图层包。</para>
		/// <para>1.x—所有 ArcGIS 客户端都将支持点云场景图层包。</para>
		/// <para>2.x—点云场景图层包将在 ArcGIS Pro 2.1.2 或更高版本中受支持，并且可以发布到 ArcGIS Online 和 ArcGIS 10.6.1 或更高版本。 这是默认设置。</para>
		/// <para><see cref="SceneLayerVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SceneLayerVersion { get; set; } = "2.x";

		/// <summary>
		/// <para>Target Cloud Connection</para>
		/// <para>将输出场景图层内容 (.i3sREST) 的目标云连接文件 (.acs)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? TargetCloudConnection { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出到云存储时场景图层内容的输出名称。 仅在已指定目标云连接参数值的情况下，此参数才适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Scene Layer Version</para>
		/// </summary>
		public enum SceneLayerVersionEnum 
		{
			/// <summary>
			/// <para>1.x—所有 ArcGIS 客户端都将支持点云场景图层包。</para>
			/// </summary>
			[GPValue("1.X")]
			[Description("1.x")]
			_1x,

			/// <summary>
			/// <para>2.x—点云场景图层包将在 ArcGIS Pro 2.1.2 或更高版本中受支持，并且可以发布到 ArcGIS Online 和 ArcGIS 10.6.1 或更高版本。 这是默认设置。</para>
			/// </summary>
			[GPValue("2.X")]
			[Description("2.x")]
			_2x,

		}

#endregion
	}
}
