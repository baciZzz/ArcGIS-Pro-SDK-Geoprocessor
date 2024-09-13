using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Compute Segment Attributes</para>
	/// <para>计算分割影像属性</para>
	/// <para>计算一组与分割影像相关的属性。 输入栅格可以是单波段或 3 波段的8 位分割影像。</para>
	/// </summary>
	public class ComputeSegmentAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSegmentedRaster">
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>输入分割栅格数据集中所有属于某个分割的像素均具有相同的聚合 RGB 颜色。通常是 8 位，3 波段的 RGB 栅格，但也可以是 1 波段的灰度栅格。</para>
		/// </param>
		/// <param name="OutIndexRasterDataset">
		/// <para>Output Segment Index Raster</para>
		/// <para>输出分割索引栅格中各个分割影像的属性均记录在相关属性表中。</para>
		/// </param>
		public ComputeSegmentAttributes(object InSegmentedRaster, object OutIndexRasterDataset)
		{
			this.InSegmentedRaster = InSegmentedRaster;
			this.OutIndexRasterDataset = OutIndexRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算分割影像属性</para>
		/// </summary>
		public override string DisplayName() => "计算分割影像属性";

		/// <summary>
		/// <para>Tool Name : ComputeSegmentAttributes</para>
		/// </summary>
		public override string ToolName() => "ComputeSegmentAttributes";

		/// <summary>
		/// <para>Tool Excute Name : ia.ComputeSegmentAttributes</para>
		/// </summary>
		public override string ExcuteName() => "ia.ComputeSegmentAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSegmentedRaster, OutIndexRasterDataset, InAdditionalRaster!, UsedAttributes! };

		/// <summary>
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>输入分割栅格数据集中所有属于某个分割的像素均具有相同的聚合 RGB 颜色。通常是 8 位，3 波段的 RGB 栅格，但也可以是 1 波段的灰度栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSegmentedRaster { get; set; }

		/// <summary>
		/// <para>Output Segment Index Raster</para>
		/// <para>输出分割索引栅格中各个分割影像的属性均记录在相关属性表中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutIndexRasterDataset { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>将对其他栅格数据集（如多光谱影像或 DEM）进行整合，从而为分类器生成属性和其他所需信息。 计算平均值或标准差等属性时需要使用此栅格。 设置此参数属于可选操作。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// <para>指定要包括在与输出栅格相关联的属性表中的属性。</para>
		/// <para>聚合颜色—RGB 颜色值将基于每个分割从输入栅格获取。 这也称为平均色度。</para>
		/// <para>平均数字值—基于每个分割，将从可选像素图像中获取的平均数字值 (DN)。</para>
		/// <para>标准差—基于每个分割，将从可选像素影像中获取的标准差。</para>
		/// <para>像素计数—基于每个分割，构成分割的像素数。</para>
		/// <para>紧密度—基于每个分割，决定分割为紧凑型还是圆形的度数。 值的范围从 0 到 1，1 表示圆形。</para>
		/// <para>垂直度—基于每个分割，决定分割为矩形的度数。 值的范围从 0 到 1，1 表示矩形。</para>
		/// <para>如果该工具中的唯一输入是分割影像，则默认属性为平均色度、像素计数、紧密度和垂直度。如果还将附加输入栅格作为输入与分割影像一起添加进来，则平均数字值和标准差选项也将可用。</para>
		/// <para>&lt;para/&gt;</para>
		/// <para><see cref="UsedAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Segment Attributes")]
		public object? UsedAttributes { get; set; } = "COLOR;MEAN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeSegmentAttributes SetEnviroment(object? compression = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// </summary>
		public enum UsedAttributesEnum 
		{
			/// <summary>
			/// <para>聚合颜色—RGB 颜色值将基于每个分割从输入栅格获取。 这也称为平均色度。</para>
			/// </summary>
			[GPValue("COLOR")]
			[Description("聚合颜色")]
			Converged_color,

			/// <summary>
			/// <para>平均数字值—基于每个分割，将从可选像素图像中获取的平均数字值 (DN)。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均数字值")]
			Mean_digital_number,

			/// <summary>
			/// <para>标准差—基于每个分割，将从可选像素影像中获取的标准差。</para>
			/// </summary>
			[GPValue("STD")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>像素计数—基于每个分割，构成分割的像素数。</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("像素计数")]
			Count_of_pixels,

			/// <summary>
			/// <para>紧密度—基于每个分割，决定分割为紧凑型还是圆形的度数。 值的范围从 0 到 1，1 表示圆形。</para>
			/// </summary>
			[GPValue("COMPACTNESS")]
			[Description("紧密度")]
			Compactness,

			/// <summary>
			/// <para>垂直度—基于每个分割，决定分割为矩形的度数。 值的范围从 0 到 1，1 表示矩形。</para>
			/// </summary>
			[GPValue("RECTANGULARITY")]
			[Description("垂直度")]
			Rectangularity,

		}

#endregion
	}
}
