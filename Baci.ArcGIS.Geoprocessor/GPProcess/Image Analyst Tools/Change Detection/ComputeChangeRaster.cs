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
	/// <para>Compute Change Raster</para>
	/// <para>计算变化栅格</para>
	/// <para>计算两个栅格数据集之间的绝对、相对或分类差异。</para>
	/// </summary>
	public class ComputeChangeRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FromRaster">
		/// <para>From Raster</para>
		/// <para>待分析的初始栅格或较早栅格。</para>
		/// </param>
		/// <param name="ToRaster">
		/// <para>To Raster</para>
		/// <para>待分析的最终栅格或较晚栅格。将要与初始栅格进行比较的栅格。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster</para>
		/// <para>输出更改栅格数据集。</para>
		/// </param>
		public ComputeChangeRaster(object FromRaster, object ToRaster, object OutRasterDataset)
		{
			this.FromRaster = FromRaster;
			this.ToRaster = ToRaster;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算变化栅格</para>
		/// </summary>
		public override string DisplayName() => "计算变化栅格";

		/// <summary>
		/// <para>Tool Name : ComputeChangeRaster</para>
		/// </summary>
		public override string ToolName() => "ComputeChangeRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.ComputeChangeRaster</para>
		/// </summary>
		public override string ExcuteName() => "ia.ComputeChangeRaster";

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
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { FromRaster, ToRaster, OutRasterDataset, ComputeChangeMethod, FromClasses, ToClasses, FilterMethod, DefineTransitionColors };

		/// <summary>
		/// <para>From Raster</para>
		/// <para>待分析的初始栅格或较早栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object FromRaster { get; set; }

		/// <summary>
		/// <para>To Raster</para>
		/// <para>待分析的最终栅格或较晚栅格。将要与初始栅格进行比较的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object ToRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出更改栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Compute Change Method</para>
		/// <para>指定要在两个栅格之间执行的计算类型。</para>
		/// <para>差异—将计算栅格中像素值之间的数学差或减法。这是默认设置。</para>
		/// <para>对差异—将在考虑比较值数量的同时，计算像素值的差异。</para>
		/// <para>类别差异—将计算两个类别或主题栅格之间的差异，其输出包含在两个栅格之间发生的类过渡。</para>
		/// <para><see cref="ComputeChangeMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ComputeChangeMethod { get; set; } = "DIFFERENCE";

		/// <summary>
		/// <para>From Classes</para>
		/// <para>将包括在计算中的起始栅格参数中的类名称列表。如果未提供任何类，将包括所有类。</para>
		/// <para>当计算变化方法参数设置为类别差异时，此参数处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object FromClasses { get; set; }

		/// <summary>
		/// <para>To Classes</para>
		/// <para>将包括在计算中的目标栅格参数中的类名称列表。如果未提供任何类，将包括所有类。</para>
		/// <para>当计算变化方法参数设置为类别差异时，此参数处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ToClasses { get; set; }

		/// <summary>
		/// <para>Filter Method</para>
		/// <para>指定要在输出栅格中分类的像素。当计算变化方法参数设置为类别差异时，此参数处于活动状态。</para>
		/// <para>仅变化像素—仅类别更改的像素在输出中分类。所有类别未更改的像素被归类为名为“其他”的类中。</para>
		/// <para>仅不变像素—仅类别未更改的像素在输出中分类。所有类别更改的像素被归类为名为“其他”的类中。</para>
		/// <para>所有像素—所有像素将在输出中分类。这是默认设置。</para>
		/// <para><see cref="FilterMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FilterMethod { get; set; } = "CHANGED_PIXELS_ONLY";

		/// <summary>
		/// <para>Transition Class Colors</para>
		/// <para>指定用于符号化输出类的颜色。当像素从一种类类型更改为另一种类类型时，输出像素颜色代表初始类类型、最终类类型或两者的混合。</para>
		/// <para>当计算变化方法参数设置为类别差异时，此参数处于活动状态。</para>
		/// <para><see cref="DefineTransitionColorsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DefineTransitionColors { get; set; } = "AVERAGE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeChangeRaster SetEnviroment(object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute Change Method</para>
		/// </summary>
		public enum ComputeChangeMethodEnum 
		{
			/// <summary>
			/// <para>差异—将计算栅格中像素值之间的数学差或减法。这是默认设置。</para>
			/// </summary>
			[GPValue("DIFFERENCE")]
			[Description("差异")]
			Difference,

			/// <summary>
			/// <para>对差异—将在考虑比较值数量的同时，计算像素值的差异。</para>
			/// </summary>
			[GPValue("RELATIVE_DIFFERENCE")]
			[Description("对差异")]
			Relative_difference,

			/// <summary>
			/// <para>类别差异—将计算两个类别或主题栅格之间的差异，其输出包含在两个栅格之间发生的类过渡。</para>
			/// </summary>
			[GPValue("CATEGORICAL_DIFFERENCE")]
			[Description("类别差异")]
			Categorical_difference,

		}

		/// <summary>
		/// <para>Filter Method</para>
		/// </summary>
		public enum FilterMethodEnum 
		{
			/// <summary>
			/// <para>所有像素—所有像素将在输出中分类。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有像素")]
			All_pixels,

			/// <summary>
			/// <para>仅变化像素—仅类别更改的像素在输出中分类。所有类别未更改的像素被归类为名为“其他”的类中。</para>
			/// </summary>
			[GPValue("CHANGED_PIXELS_ONLY")]
			[Description("仅变化像素")]
			Changed_pixels_only,

			/// <summary>
			/// <para>仅不变像素—仅类别未更改的像素在输出中分类。所有类别更改的像素被归类为名为“其他”的类中。</para>
			/// </summary>
			[GPValue("UNCHANGED_PIXELS_ONLY")]
			[Description("仅不变像素")]
			Unchanged_pixels_only,

		}

		/// <summary>
		/// <para>Transition Class Colors</para>
		/// </summary>
		public enum DefineTransitionColorsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("AVERAGE")]
			[Description("起始和目标颜色平均值")]
			Average_From_and_To_colors,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FROM_COLOR")]
			[Description("自颜色")]
			From_color,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TO_COLOR")]
			[Description("至颜色")]
			To_color,

		}

#endregion
	}
}
