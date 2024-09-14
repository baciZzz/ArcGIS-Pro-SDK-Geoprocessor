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
	/// <para>Reconstruct Surface</para>
	/// <para>重新构建表面</para>
	/// <para>根据调整后的影像生成 DSM 正射影像、2.5D 网格、3D 网格和点云。</para>
	/// </summary>
	public class ReconstructSurface : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>调整的输入镶嵌数据集。</para>
		/// </param>
		/// <param name="ReconFolder">
		/// <para>Reconstruction Folder</para>
		/// <para>输出数据集文件夹。</para>
		/// </param>
		public ReconstructSurface(object InMosaicDataset, object ReconFolder)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.ReconFolder = ReconFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 重新构建表面</para>
		/// </summary>
		public override string DisplayName() => "重新构建表面";

		/// <summary>
		/// <para>Tool Name : ReconstructSurface</para>
		/// </summary>
		public override string ToolName() => "ReconstructSurface";

		/// <summary>
		/// <para>Tool Excute Name : management.ReconstructSurface</para>
		/// </summary>
		public override string ExcuteName() => "management.ReconstructSurface";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, ReconFolder, ReconOptions!, Scenario!, FwdOverlap!, SwdOverlap!, Quality!, Products!, CellSize!, Aoi!, WaterbodyFeatures!, CorrectionFeatures!, DerivedReconFolder! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>调整的输入镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Reconstruction Folder</para>
		/// <para>输出数据集文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object ReconFolder { get; set; }

		/// <summary>
		/// <para>Reconstruction Options</para>
		/// <para>用于指定工具参数值的 .json 文件或 JSON 字符串。</para>
		/// <para>如果指定了此参数，则 .json 文件或 JSON 字符串的属性将为其余可选参数设置默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? ReconOptions { get; set; }

		/// <summary>
		/// <para>Scenario</para>
		/// <para>指定将用于生成输出产品的影像类型。</para>
		/// <para>默认值—输入影像将被定义为使用无人机或地面照相机获取。</para>
		/// <para>航空像底点—输入影像将被定义为使用大型摄影测量照相机系统获取。</para>
		/// <para>航空倾斜—输入影像将被定义为使用倾斜照相机系统获取。</para>
		/// <para><see cref="ScenarioEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Scenario { get; set; }

		/// <summary>
		/// <para>Forward Overlap</para>
		/// <para>将在图像之间使用的向前（条带内）重叠百分比。 默认值为 60。</para>
		/// <para>在将方案参数设置为航空像底点时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 60, Max = 99)]
		public object? FwdOverlap { get; set; }

		/// <summary>
		/// <para>Sideward Overlap</para>
		/// <para>将在图像之间使用的侧方（跨条带）重叠百分比。 默认值为 30。</para>
		/// <para>在将方案参数设置为航空像底点时才启用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 99)]
		public object? SwdOverlap { get; set; }

		/// <summary>
		/// <para>Quality</para>
		/// <para>指定最终产品的质量。</para>
		/// <para>超级—输入图像将以其原始（全）分辨率使用。</para>
		/// <para>高—输入图像将被降采样 2 倍。</para>
		/// <para>中—输入图像将被降采样 4 倍。</para>
		/// <para>低—输入图像将被降采样 8 倍。</para>
		/// <para><see cref="QualityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Quality { get; set; }

		/// <summary>
		/// <para>Products</para>
		/// <para>指定将要生成的产品。</para>
		/// <para>DSM—将生成数字表面模型 (DSM)。 默认情况下，当方案参数设置为航空像底点时，将选择该产品。</para>
		/// <para>真正射—将对此影像进行正射校正。 默认情况下，当方案参数设置为航空像底点时，将选择该产品。</para>
		/// <para>DSM 网格—将生成 DSM 网格。 默认情况下，当方案参数设置为航空像底点时，将选择该产品。</para>
		/// <para>点云—将生成图像点云。 默认情况下，当方案参数设置为默认值或航空像底点时，将选择该产品。</para>
		/// <para>网格—将生成 3D 网格。 默认情况下，当方案参数设置为默认值或航空像底点时，将选择该产品。</para>
		/// <para><see cref="ProductsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Products { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>输出产品的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>将用于选择要处理的图像的感兴趣区域。 感兴趣区域可以自动计算或使用输入 shapefile 定义。</para>
		/// <para>如果该值包含 3D 几何，则将忽略 z 分量。 如果该值包括重叠要素，则将计算这些要素的并集。</para>
		/// <para>无—所有影像都将用于处理。</para>
		/// <para>自动—将自动计算处理范围。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? Aoi { get; set; }

		/// <summary>
		/// <para>Waterbody Features</para>
		/// <para>将用于定义大型水体范围的面。 要获得最佳效果，请使用 3D shapefile。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? WaterbodyFeatures { get; set; }

		/// <summary>
		/// <para>Correction Features</para>
		/// <para>将用于定义所有非水体表面的范围的面。 该值必须为 3D shapefile。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? CorrectionFeatures { get; set; }

		/// <summary>
		/// <para>Updated Reconstruction Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedReconFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReconstructSurface SetEnviroment(object? extent = null, object? processorType = null)
		{
			base.SetEnv(extent: extent, processorType: processorType);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Scenario</para>
		/// </summary>
		public enum ScenarioEnum 
		{
			/// <summary>
			/// <para>默认值—输入影像将被定义为使用无人机或地面照相机获取。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("默认值")]
			Default,

			/// <summary>
			/// <para>航空像底点—输入影像将被定义为使用大型摄影测量照相机系统获取。</para>
			/// </summary>
			[GPValue("AERIAL_NADIR")]
			[Description("航空像底点")]
			Aerial_Nadir,

			/// <summary>
			/// <para>航空倾斜—输入影像将被定义为使用倾斜照相机系统获取。</para>
			/// </summary>
			[GPValue("AERIAL_OBLIQUE")]
			[Description("航空倾斜")]
			Aerial_Oblique,

		}

		/// <summary>
		/// <para>Quality</para>
		/// </summary>
		public enum QualityEnum 
		{
			/// <summary>
			/// <para>超级—输入图像将以其原始（全）分辨率使用。</para>
			/// </summary>
			[GPValue("ULTRA")]
			[Description("超级")]
			Ultra,

			/// <summary>
			/// <para>高—输入图像将被降采样 2 倍。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高")]
			High,

			/// <summary>
			/// <para>中—输入图像将被降采样 4 倍。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中")]
			Medium,

			/// <summary>
			/// <para>低—输入图像将被降采样 8 倍。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低")]
			Low,

		}

		/// <summary>
		/// <para>Products</para>
		/// </summary>
		public enum ProductsEnum 
		{
			/// <summary>
			/// <para>DSM—将生成数字表面模型 (DSM)。 默认情况下，当方案参数设置为航空像底点时，将选择该产品。</para>
			/// </summary>
			[GPValue("DSM")]
			[Description("DSM")]
			DSM,

			/// <summary>
			/// <para>真正射—将对此影像进行正射校正。 默认情况下，当方案参数设置为航空像底点时，将选择该产品。</para>
			/// </summary>
			[GPValue("TRUE_ORTHO")]
			[Description("真正射")]
			True_Ortho,

			/// <summary>
			/// <para>DSM 网格—将生成 DSM 网格。 默认情况下，当方案参数设置为航空像底点时，将选择该产品。</para>
			/// </summary>
			[GPValue("DSM_MESH")]
			[Description("DSM 网格")]
			DSM_Mesh,

			/// <summary>
			/// <para>点云—将生成图像点云。 默认情况下，当方案参数设置为默认值或航空像底点时，将选择该产品。</para>
			/// </summary>
			[GPValue("POINT_CLOUD")]
			[Description("点云")]
			Point_Cloud,

			/// <summary>
			/// <para>网格—将生成 3D 网格。 默认情况下，当方案参数设置为默认值或航空像底点时，将选择该产品。</para>
			/// </summary>
			[GPValue("MESH")]
			[Description("网格")]
			Mesh,

		}

#endregion
	}
}
