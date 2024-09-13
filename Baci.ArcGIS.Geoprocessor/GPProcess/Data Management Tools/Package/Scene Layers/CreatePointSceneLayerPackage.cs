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
	/// <para>Create Point Scene Layer Content</para>
	/// <para>创建点场景图层内容</para>
	/// <para>从点要素图层创建点场景图层包 (.slpk) 或场景图层内容 (.i3sREST)。</para>
	/// </summary>
	public class CreatePointSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>输入点要素图层。</para>
		/// </param>
		public CreatePointSceneLayerPackage(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建点场景图层内容</para>
		/// </summary>
		public override string DisplayName() => "创建点场景图层内容";

		/// <summary>
		/// <para>Tool Name : CreatePointSceneLayerPackage</para>
		/// </summary>
		public override string ToolName() => "CreatePointSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreatePointSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreatePointSceneLayerPackage";

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
		public override object[] Parameters() => new object[] { InDataset, OutSlpk!, OutCoorSystem!, TransformMethod!, TargetCloudConnection! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>输入点要素图层。</para>
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
		/// <para>此基准面变换方法适用于输入图层坐标系所使用的基准面不同于输出坐标系的情况。 所有变换均为双向，而不管其名称隐含的方向如何。 例如，即使基准面变换为从 WGS 1984 到 NAD 1927，NAD_1927_to_WGS_1984_3 仍可正常运行。</para>
		/// <para>在椭圆体和重力相关的基准面以及两个与重力相关的基准面之间进行垂直基准面变换时，需要使用 ArcGIS 坐标系数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TransformMethod { get; set; }

		/// <summary>
		/// <para>Target Cloud Connection</para>
		/// <para>将输出场景图层内容 (.i3sREST) 的目标云连接文件 (.acs)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? TargetCloudConnection { get; set; }

	}
}
