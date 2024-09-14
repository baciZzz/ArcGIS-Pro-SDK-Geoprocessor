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
	/// <para>Create Integrated Mesh Scene Layer Package</para>
	/// <para>创建集成网格场景图层包</para>
	/// <para>可根据 OpenSceneGraph 二进制 (OSGB) 数据创建场景图层包。</para>
	/// </summary>
	public class CreateIntegratedMeshSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>OSGB 格式文件或包含 OSGB 格式文件的文件夹，将导入到集成网格场景图层包中。此参数允许选择多个 OSGB 格式文件或选择包含 OSGB 格式文件的多个文件夹。</para>
		/// </param>
		/// <param name="OutSlpk">
		/// <para>Output Scene Layer Package</para>
		/// <para>将创建的集成网格场景图层包。</para>
		/// </param>
		public CreateIntegratedMeshSceneLayerPackage(object InDataset, object OutSlpk)
		{
			this.InDataset = InDataset;
			this.OutSlpk = OutSlpk;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建集成网格场景图层包</para>
		/// </summary>
		public override string DisplayName() => "创建集成网格场景图层包";

		/// <summary>
		/// <para>Tool Name : CreateIntegratedMeshSceneLayerPackage</para>
		/// </summary>
		public override string ToolName() => "CreateIntegratedMeshSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateIntegratedMeshSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateIntegratedMeshSceneLayerPackage";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutSlpk, AnchorPoint, FileSuffix, OutCoorSystem, MaxTextureSize, TextureOptimization };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>OSGB 格式文件或包含 OSGB 格式文件的文件夹，将导入到集成网格场景图层包中。此参数允许选择多个 OSGB 格式文件或选择包含 OSGB 格式文件的多个文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>将创建的集成网格场景图层包。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("slpk")]
		public object OutSlpk { get; set; }

		/// <summary>
		/// <para>Anchor Point</para>
		/// <para>将用于定位 OSGB 模型中心的点要素、.3mx、.xml 或 .wld3 文件。如果要素类中存在多个点，则将仅使用第一个点对数据进行地理配准。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object AnchorPoint { get; set; }

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>指定将针对输入数据集进行处理的文件。</para>
		/// <para>所有受支持的文件—将对所有二进制文件（不考虑其扩展名）进行处理以确定其是否为 OSGB 格式。</para>
		/// <para>带有 * osgb 扩展名的文件—将仅处理具有 .osgb 扩展名的文件。</para>
		/// <para><see cref="FileSuffixEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FileSuffix { get; set; } = "osgb";

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>输出场景图层包的坐标系。它可以是任意投影坐标系或自定义坐标系。支持的地理坐标系包括 WGS 1984 和 China Geodetic Coordinate System 2000。WGS 1984 和 EGM96 大地水准面分别是默认的水平和垂直坐标系。可通过以下任一方式指定坐标系：</para>
		/// <para>指定 .prj 文件的路径。</para>
		/// <para>引用具有所需坐标系的数据集。</para>
		/// <para>使用 arcpy.SpatialReference 对象。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object OutCoorSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]];-400 -400 1000000000;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Maximum Texture Size</para>
		/// <para>每个场景图层节点的最大纹理大小（以像素为单位）。</para>
		/// <para><see cref="MaxTextureSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object MaxTextureSize { get; set; }

		/// <summary>
		/// <para>Texture Optimization</para>
		/// <para>指定根据使用场景图层包的目标平台优化的纹理。桌面平台包括 Windows、Linux 和 Mac 平台。</para>
		/// <para>桌面—纹理格式将进行优化，可用于桌面和 web 平台。纹理格式将为 JPEG 和 DXT。这是默认设置。</para>
		/// <para>无—纹理格式将进行优化，可用于桌面平台。纹理格式将为 JPEG。</para>
		/// <para><see cref="TextureOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TextureOptimization { get; set; } = "Desktop";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateIntegratedMeshSceneLayerPackage SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Suffix</para>
		/// </summary>
		public enum FileSuffixEnum 
		{
			/// <summary>
			/// <para>带有 * osgb 扩展名的文件—将仅处理具有 .osgb 扩展名的文件。</para>
			/// </summary>
			[GPValue("osgb")]
			[Description("带有 * osgb 扩展名的文件")]
			osgb,

			/// <summary>
			/// <para>所有受支持的文件—将对所有二进制文件（不考虑其扩展名）进行处理以确定其是否为 OSGB 格式。</para>
			/// </summary>
			[GPValue("*")]
			[Description("所有受支持的文件")]
			All_supported_files,

		}

		/// <summary>
		/// <para>Maximum Texture Size</para>
		/// </summary>
		public enum MaxTextureSizeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2048")]
			[Description("2048")]
			_2048,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("4096")]
			[Description("4096")]
			_4096,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("8192")]
			[Description("8192")]
			_8192,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("16384")]
			[Description("16384")]
			_16384,

		}

		/// <summary>
		/// <para>Texture Optimization</para>
		/// </summary>
		public enum TextureOptimizationEnum 
		{
			/// <summary>
			/// <para>桌面—纹理格式将进行优化，可用于桌面和 web 平台。纹理格式将为 JPEG 和 DXT。这是默认设置。</para>
			/// </summary>
			[GPValue("Desktop")]
			[Description("桌面")]
			Desktop,

			/// <summary>
			/// <para>无—纹理格式将进行优化，可用于桌面平台。纹理格式将为 JPEG。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

		}

#endregion
	}
}
