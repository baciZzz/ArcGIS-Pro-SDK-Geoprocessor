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
	/// <para>Build Footprints</para>
	/// <para>构建轮廓线</para>
	/// <para>计算镶嵌数据集中每个栅格的范围。从镶嵌数据集添加或移除栅格数据集并想要重新计算轮廓线时使用此工具。</para>
	/// </summary>
	public class BuildFootprints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>该镶嵌数据集包含要计算轮廓线的栅格数据集。</para>
		/// </param>
		public BuildFootprints(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建轮廓线</para>
		/// </summary>
		public override string DisplayName() => "构建轮廓线";

		/// <summary>
		/// <para>Tool Name : BuildFootprints</para>
		/// </summary>
		public override string ToolName() => "BuildFootprints";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildFootprints</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildFootprints";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, ResetFootprint, MinDataValue, MaxDataValue, ApproxNumVertices, ShrinkDistance, MaintainEdges, SkipDerivedImages, UpdateBoundary, RequestSize, MinRegionSize, SimplificationMethod, EdgeTolerance, MaxSliverSize, MinThinnessRatio, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>该镶嵌数据集包含要计算轮廓线的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于在镶嵌数据集内选择特定栅格数据集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Computation Method</para>
		/// <para>用以下方法之一优化轮廓线：</para>
		/// <para>辐射测量— 排除值超出定义范围的像素。此选项通常用于排除未包含有效数据的边界区域。这是默认设置。</para>
		/// <para>Geometry— 将轮廓线恢复为其原始几何形状。</para>
		/// <para>复制到同级— 使用全色锐化栅格类型时，用多光谱轮廓线替换全色轮廓线。当全色图像和多光谱图像没有相同的几何形状时，就会发生这种情况。</para>
		/// <para>无—不重新定义轮廓线。</para>
		/// <para>&lt;para/&gt;</para>
		/// <para><see cref="ResetFootprintEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCodedValueDomain()]
		public object ResetFootprint { get; set; } = "RADIOMETRY";

		/// <summary>
		/// <para>Minimum Data Value</para>
		/// <para>排除值小于此数字的像素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinDataValue { get; set; } = "1";

		/// <summary>
		/// <para>Maximum Data Value</para>
		/// <para>排除值大于此数字的像素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxDataValue { get; set; } = "254";

		/// <summary>
		/// <para>Approximate number of vertices</para>
		/// <para>在 4 和 10,000 之间选择。折点越多，精度越高，但处理时间也更长。值为 -1 时将计算所有折点。折点越多，精度越高，但处理时间也更长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = -1, Max = 10000)]
		public object ApproxNumVertices { get; set; } = "80";

		/// <summary>
		/// <para>Shrink distance</para>
		/// <para>按此距离裁剪轮廓线。可以消除使用有损压缩的伪影，即有损压缩导致的图像边缘与 NoData 区域重叠。</para>
		/// <para>面的收缩用于抵消有损压缩的影响，此影响会导致图像边缘与 NoData 区域重叠。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ShrinkDistance { get; set; } = "0";

		/// <summary>
		/// <para>Maintain sheet edges</para>
		/// <para>更改已分块且相邻（沿着接边对齐且基本没有重叠）的栅格数据集的轮廓线。</para>
		/// <para>取消选中 - 从所有轮廓线移除页边缘。这是默认设置。</para>
		/// <para>选中 - 保持轮廓线的原始状态。</para>
		/// <para><see cref="MaintainEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MaintainEdges { get; set; } = "false";

		/// <summary>
		/// <para>Skip overviews</para>
		/// <para>调整概视图的轮廓线。</para>
		/// <para>选中 - 不调整概视图的轮廓线。这是默认设置。</para>
		/// <para>未选中 - 调整概视图及关联栅格数据集的轮廓线。</para>
		/// <para><see cref="SkipDerivedImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipDerivedImages { get; set; } = "true";

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>如果已添加或移除范围会更改的影像，则更新镶嵌数据集的边界。</para>
		/// <para>选中 - 更新边界。这是默认设置。</para>
		/// <para>未选中 - 不更新边界。</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Request Size</para>
		/// <para>构建轮廓线时为栅格设置重采样范围（用列数和行数表示）。图像分辨率越高，提供的栅格数据集信息越详细，但同时也增加了处理时间。值为 -1 时将计算原始分辨率的轮廓线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = -1, Max = 2147483647)]
		[Category("Advanced Options")]
		public object RequestSize { get; set; } = "2000";

		/// <summary>
		/// <para>Minimum Region Size</para>
		/// <para>使用像素值创建掩膜时避免影像中的小孔洞。例如，影像的值范围为 0 至 255，而为了掩膜云，您已排除 245 至 255 的值，这样可能导致其他非云像素也被掩膜。如果那些区域小于此处指定的像素数量，则不会进行掩膜。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Advanced Options")]
		public object MinRegionSize { get; set; } = "100";

		/// <summary>
		/// <para>Simplification Method</para>
		/// <para>减少轮廓线中的折点数以提高性能。</para>
		/// <para>无—不限制折点的数量。这是默认设置。</para>
		/// <para>凸包—使用最小边界框来简化轮廓线。</para>
		/// <para>包络—使用每个镶嵌数据集项的包络矩形来简化轮廓线。</para>
		/// <para><see cref="SimplificationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SimplificationMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Edge tolerance</para>
		/// <para>如果在此容差内，则将轮廓线捕捉到页边缘。单位与镶嵌数据集坐标系中的单位相同。</para>
		/// <para>默认情况下，基于与请求的重采样栅格对应的像素大小计算出来的容差值为空。</para>
		/// <para>值为 -1 时，将使用镶嵌数据集的平均像素大小来计算容差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object EdgeTolerance { get; set; }

		/// <summary>
		/// <para>Maximum Sliver Size</para>
		/// <para>标识小于此值平方值的所有面。该值按像素指定，基于请求大小而不是源栅格的空间分辨率。</para>
		/// <para>小于（最大狭长大小）^2 且同时小于最小薄度比率的区域将视为狭长面，将被移除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Sliver Removal Options")]
		public object MaxSliverSize { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Thinness Ratio</para>
		/// <para>定义范围为 0 至 1.0 的狭长面薄度，其中 1.0 代表圆形，0.0 则代表接近于直线的面。</para>
		/// <para>小于最大狭长大小和最小薄度比率的面将从轮廓线中移除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Sliver Removal Options")]
		public object MinThinnessRatio { get; set; } = "0.05";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildFootprints SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Computation Method</para>
		/// </summary>
		public enum ResetFootprintEnum 
		{
			/// <summary>
			/// <para>无—不重新定义轮廓线。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>Geometry— 将轮廓线恢复为其原始几何形状。</para>
			/// </summary>
			[GPValue("GEOMETRY")]
			[Description("Geometry")]
			Geometry,

			/// <summary>
			/// <para>辐射测量— 排除值超出定义范围的像素。此选项通常用于排除未包含有效数据的边界区域。这是默认设置。</para>
			/// </summary>
			[GPValue("RADIOMETRY")]
			[Description("辐射测量")]
			Radiometry,

			/// <summary>
			/// <para>复制到同级— 使用全色锐化栅格类型时，用多光谱轮廓线替换全色轮廓线。当全色图像和多光谱图像没有相同的几何形状时，就会发生这种情况。</para>
			/// </summary>
			[GPValue("COPY_TO_SIBLING")]
			[Description("复制到同级")]
			Copy_to_sibling,

		}

		/// <summary>
		/// <para>Maintain sheet edges</para>
		/// </summary>
		public enum MaintainEdgesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_EDGES")]
			MAINTAIN_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAINTAIN_EDGES")]
			NO_MAINTAIN_EDGES,

		}

		/// <summary>
		/// <para>Skip overviews</para>
		/// </summary>
		public enum SkipDerivedImagesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_DERIVED_IMAGES")]
			SKIP_DERIVED_IMAGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SKIP_DERIVED_IMAGES")]
			NO_SKIP_DERIVED_IMAGES,

		}

		/// <summary>
		/// <para>Update Boundary</para>
		/// </summary>
		public enum UpdateBoundaryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_BOUNDARY")]
			UPDATE_BOUNDARY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOUNDARY")]
			NO_BOUNDARY,

		}

		/// <summary>
		/// <para>Simplification Method</para>
		/// </summary>
		public enum SimplificationMethodEnum 
		{
			/// <summary>
			/// <para>无—不限制折点的数量。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>凸包—使用最小边界框来简化轮廓线。</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("凸包")]
			Convex_hull,

			/// <summary>
			/// <para>包络—使用每个镶嵌数据集项的包络矩形来简化轮廓线。</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("包络")]
			Envelope,

		}

#endregion
	}
}
