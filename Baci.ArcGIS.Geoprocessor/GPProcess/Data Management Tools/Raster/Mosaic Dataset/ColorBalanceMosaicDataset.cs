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
	/// <para>Color Balance Mosaic Dataset</para>
	/// <para>平衡镶嵌数据集色彩</para>
	/// <para>使图像与相邻图像之间的过渡无缝显示。</para>
	/// </summary>
	public class ColorBalanceMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>想要进行色彩平衡的镶嵌数据集。</para>
		/// </param>
		public ColorBalanceMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 平衡镶嵌数据集色彩</para>
		/// </summary>
		public override string DisplayName() => "平衡镶嵌数据集色彩";

		/// <summary>
		/// <para>Tool Name : ColorBalanceMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "ColorBalanceMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.ColorBalanceMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.ColorBalanceMosaicDataset";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, BalancingMethod!, ColorSurfaceType!, TargetRaster!, ExcludeRaster!, StretchType!, Gamma!, BlockField!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>想要进行色彩平衡的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Balance Method</para>
		/// <para>要使用的平衡算法。</para>
		/// <para>匀光—将每个像素的值更改为目标颜色。使用该技术也必须选择目标颜色表面的类型，该类型将对目标颜色产生影响。多数情况下，匀光会取得最佳的效果。</para>
		/// <para>直方图—根据每个像素值与目标直方图的关系更改像素值。从所有的栅格中均可获得目标直方图，也可以指定栅格以从中获得目标直方图。当所有栅格的直方图形状都相似时，该技术会取得较好的效果。</para>
		/// <para>标准差—根据像素值与其目标栅格直方图的关系，在标准方差的范围内更改每个像素的值。标准差可由所有镶嵌数据集的栅格计算获得，也可指定目标栅格来计算标准差。当所有栅格均为正态分布时，该技术取得的效果最佳。</para>
		/// <para><see cref="BalancingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BalancingMethod { get; set; } = "DODGING";

		/// <summary>
		/// <para>Color Surface Type</para>
		/// <para>使用匀光平衡方法时，每个像素都需要一个目标颜色，而目标颜色是根据表面类型而确定的。</para>
		/// <para>单色—在栅格数据集数量少且地面物体种类少时使用。如果存在过多的栅格数据集或过多类型的地表，则输出颜色可能会变得模糊。所有像素均基于一个单色点 - 即所有像素的平均值进行更改。</para>
		/// <para>颜色格网— 在栅格数据集数量很多或区域内的地面物体种类很多时使用。像素根据多目标颜色进行改变，这些目标颜色分布在镶嵌数据集中。</para>
		/// <para>一阶— 与颜色格网表面相比，该技术所创建的颜色改变更为平滑，而且使用的辅助表存储空间更少，但可能需要花费更长时间进行处理。所有像素都根据从二维多项式倾斜平面获取的多个点进行更改。</para>
		/// <para>二阶— 与颜色格网表面相比，该技术所创建的颜色改变更为平滑，而且使用的辅助表存储空间更少，但可能需要花费更长时间进行处理。所有输入像素都根据从二维多项式抛物线表面获取的一组多点进行更改。</para>
		/// <para>三阶— 与颜色格网表面相比，该技术所创建的颜色改变更为平滑，而且使用的辅助表存储空间更少，但可能需要花费更长时间进行处理。所有输入像素都根据从三次表面获取的多个点进行更改。</para>
		/// <para><see cref="ColorSurfaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ColorSurfaceType { get; set; } = "COLOR_GRID";

		/// <summary>
		/// <para>Target Raster</para>
		/// <para>想要用于对其他图像进行色彩平衡的栅格。如果适用，将从该图像中获取平衡方法和颜色表面类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? TargetRaster { get; set; }

		/// <summary>
		/// <para>Exclude Area Raster</para>
		/// <para>对镶嵌数据集进行色彩平衡之前应用掩膜。使用生成排除区域工具创建掩膜。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Pre-processing Options")]
		public object? ExcludeRaster { get; set; }

		/// <summary>
		/// <para>Stretch Type</para>
		/// <para>进行色彩平衡前，拉伸值的范围。选择以下选项之一:</para>
		/// <para>无— 使用原始像素值。这是默认设置。</para>
		/// <para>自适应— 将在执行任何处理之前应用自适应预拉伸。</para>
		/// <para>最小最大值— 在实际最小值和最大值之间拉伸值。</para>
		/// <para>标准差— 在默认标准差数之间拉抻值。</para>
		/// <para><see cref="StretchTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pre-processing Options")]
		public object? StretchType { get; set; } = "NONE";

		/// <summary>
		/// <para>Gamma</para>
		/// <para>调整图像的整体亮度。值越小，显示越暗，中等值之间的对比度越低。值越大，显示越亮，对比度越高。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Pre-processing Options")]
		public object? Gamma { get; set; } = "1";

		/// <summary>
		/// <para>Block Field</para>
		/// <para>镶嵌数据集属性表中的字段名称，用于标识在执行某些计算和操作时应被视为单一项目的多个项目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? BlockField { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ColorBalanceMosaicDataset SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Balance Method</para>
		/// </summary>
		public enum BalancingMethodEnum 
		{
			/// <summary>
			/// <para>匀光—将每个像素的值更改为目标颜色。使用该技术也必须选择目标颜色表面的类型，该类型将对目标颜色产生影响。多数情况下，匀光会取得最佳的效果。</para>
			/// </summary>
			[GPValue("DODGING")]
			[Description("匀光")]
			Dodging,

			/// <summary>
			/// <para>直方图—根据每个像素值与目标直方图的关系更改像素值。从所有的栅格中均可获得目标直方图，也可以指定栅格以从中获得目标直方图。当所有栅格的直方图形状都相似时，该技术会取得较好的效果。</para>
			/// </summary>
			[GPValue("HISTOGRAM")]
			[Description("直方图")]
			Histogram,

			/// <summary>
			/// <para>标准差—根据像素值与其目标栅格直方图的关系，在标准方差的范围内更改每个像素的值。标准差可由所有镶嵌数据集的栅格计算获得，也可指定目标栅格来计算标准差。当所有栅格均为正态分布时，该技术取得的效果最佳。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("标准差")]
			Standard_deviation,

		}

		/// <summary>
		/// <para>Color Surface Type</para>
		/// </summary>
		public enum ColorSurfaceTypeEnum 
		{
			/// <summary>
			/// <para>单色—在栅格数据集数量少且地面物体种类少时使用。如果存在过多的栅格数据集或过多类型的地表，则输出颜色可能会变得模糊。所有像素均基于一个单色点 - 即所有像素的平均值进行更改。</para>
			/// </summary>
			[GPValue("SINGLE_COLOR")]
			[Description("单色")]
			Single_color,

			/// <summary>
			/// <para>颜色格网— 在栅格数据集数量很多或区域内的地面物体种类很多时使用。像素根据多目标颜色进行改变，这些目标颜色分布在镶嵌数据集中。</para>
			/// </summary>
			[GPValue("COLOR_GRID")]
			[Description("颜色格网")]
			Color_grid,

			/// <summary>
			/// <para>一阶— 与颜色格网表面相比，该技术所创建的颜色改变更为平滑，而且使用的辅助表存储空间更少，但可能需要花费更长时间进行处理。所有像素都根据从二维多项式倾斜平面获取的多个点进行更改。</para>
			/// </summary>
			[GPValue("FIRST_ORDER")]
			[Description("一阶")]
			First_order,

			/// <summary>
			/// <para>二阶— 与颜色格网表面相比，该技术所创建的颜色改变更为平滑，而且使用的辅助表存储空间更少，但可能需要花费更长时间进行处理。所有输入像素都根据从二维多项式抛物线表面获取的一组多点进行更改。</para>
			/// </summary>
			[GPValue("SECOND_ORDER")]
			[Description("二阶")]
			Second_order,

			/// <summary>
			/// <para>三阶— 与颜色格网表面相比，该技术所创建的颜色改变更为平滑，而且使用的辅助表存储空间更少，但可能需要花费更长时间进行处理。所有输入像素都根据从三次表面获取的多个点进行更改。</para>
			/// </summary>
			[GPValue("THIRD_ORDER")]
			[Description("三阶")]
			Third_order,

		}

		/// <summary>
		/// <para>Stretch Type</para>
		/// </summary>
		public enum StretchTypeEnum 
		{
			/// <summary>
			/// <para>无— 使用原始像素值。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>标准差— 在默认标准差数之间拉抻值。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>最小最大值— 在实际最小值和最大值之间拉伸值。</para>
			/// </summary>
			[GPValue("MINIMUM_MAXIMUM")]
			[Description("最小最大值")]
			Minimum_Maximum,

			/// <summary>
			/// <para>自适应— 将在执行任何处理之前应用自适应预拉伸。</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("自适应")]
			Adaptive,

		}

#endregion
	}
}
