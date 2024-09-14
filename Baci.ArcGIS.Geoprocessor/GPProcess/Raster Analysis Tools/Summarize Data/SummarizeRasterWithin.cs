using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Summarize Raster Within</para>
	/// <para>汇总范围内的栅格</para>
	/// <para>计算位于另一数据集区域内的栅格值的统计信息。</para>
	/// </summary>
	public class SummarizeRasterWithin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputzonelayer">
		/// <para>Input Zone Layer</para>
		/// <para>定义区域的输入。</para>
		/// <para>栅格和要素数据都可用于区域输入。</para>
		/// </param>
		/// <param name="Zonefield">
		/// <para>Zone Field</para>
		/// <para>定义各个区域的字段。</para>
		/// <para>该字段可以是区域数据集的整型字段或字符串型字段。</para>
		/// </param>
		/// <param name="Inputrasterlayertosummarize">
		/// <para>Input Raster Layer to Summarize</para>
		/// <para>含有要汇总统计数据的值的栅格。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>如果图像服务图层已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public SummarizeRasterWithin(object Inputzonelayer, object Zonefield, object Inputrasterlayertosummarize, object Outputname)
		{
			this.Inputzonelayer = Inputzonelayer;
			this.Zonefield = Zonefield;
			this.Inputrasterlayertosummarize = Inputrasterlayertosummarize;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 汇总范围内的栅格</para>
		/// </summary>
		public override string DisplayName() => "汇总范围内的栅格";

		/// <summary>
		/// <para>Tool Name : SummarizeRasterWithin</para>
		/// </summary>
		public override string ToolName() => "SummarizeRasterWithin";

		/// <summary>
		/// <para>Tool Excute Name : ra.SummarizeRasterWithin</para>
		/// </summary>
		public override string ExcuteName() => "ra.SummarizeRasterWithin";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputzonelayer, Zonefield, Inputrasterlayertosummarize, Outputname, Statistictype!, Ignoremissingvalues!, Outputraster!, Processasmultidimensional!, Percentilevalue!, Percentileinterpolationtype!, Circularcalculation!, Circularwrapvalue! };

		/// <summary>
		/// <para>Input Zone Layer</para>
		/// <para>定义区域的输入。</para>
		/// <para>栅格和要素数据都可用于区域输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputzonelayer { get; set; }

		/// <summary>
		/// <para>Zone Field</para>
		/// <para>定义各个区域的字段。</para>
		/// <para>该字段可以是区域数据集的整型字段或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Zonefield { get; set; }

		/// <summary>
		/// <para>Input Raster Layer to Summarize</para>
		/// <para>含有要汇总统计数据的值的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputrasterlayertosummarize { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>如果图像服务图层已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Statistic Type</para>
		/// <para>指定要计算的统计数据类型。</para>
		/// <para>如果要汇总的栅格为整型数据类型，则可用的选项包括平均值、众数、最大值、中值、最小值、少数、百分比数、范围、标准差、总和以及变异度。</para>
		/// <para>如果要汇总的栅格的数据类型为浮点型，则选项包括平均值、最大值、中值、最小值、百分位数、范围、标准差和总和。</para>
		/// <para>平均值—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的平均值。 这是默认设置。</para>
		/// <para>众数—计算待汇总栅格图层中与输出像元同属一个区域的所有像元中最常出现的值。</para>
		/// <para>最大值—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的最大值。</para>
		/// <para>中值—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的中值。</para>
		/// <para>最小值—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的最小值。</para>
		/// <para>少数—计算待汇总栅格图层中与输出像元同属一个区域的所有像元中出现次数最少的值。</para>
		/// <para>百分比数—将计算值栅格中与输出像元同属一个区域的所有像元的百分比值。 默认情况下将计算 90% 百分比数。 您可以使用百分比值参数来指定其他值（从 0 到 100）。</para>
		/// <para>范围—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的最大值与最小值之差。</para>
		/// <para>标准差—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的标准差。</para>
		/// <para>总和—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的总值。</para>
		/// <para>变异度—计算待汇总栅格图层中与输出像元同属一个区域的所有像元的唯一值的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Statistictype { get; set; } = "MEAN";

		/// <summary>
		/// <para>Ignore Missing Values</para>
		/// <para>指定待汇总栅格图层中的缺失值是否会在其落入区域的结果中被忽略。</para>
		/// <para>选中 - 在任意特定区域内，仅使用在正在汇总的栅格图层中拥有值的像元来确定该区域的输出值。 统计计算将忽略缺失的像元或 NoData 像元。 这是默认设置。</para>
		/// <para>未选中 - 在任何特定区域中，如果正在汇总的栅格图层中的任何像元没有值，它们不会被忽略，并且其存在表明没有足够的信息来对该区域中的所有像元执行统计计算。 因此，整个区域将在输出栅格上接收 NoData 值。</para>
		/// <para><see cref="IgnoremissingvaluesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Ignoremissingvalues { get; set; } = "true";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>用于指定多维输入栅格的处理方式。</para>
		/// <para>未选中 - 将计算输入多维数据集的当前剖切片中的统计数据。 这是默认设置。</para>
		/// <para>已选中 - 将计算多维输入栅格的所有剖切片中的所有维度（如时间或深度）的统计数据。</para>
		/// <para><see cref="ProcessasmultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Processasmultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Percentile Value</para>
		/// <para>将计算的百分比数。 默认值为 90，指示 90%。</para>
		/// <para>取值范围为 0 到 100。 0% 基本上等同于“最小值”统计数据，而 100% 则等同于“最大值”。 值 50 所生成的结果基本等同于“中值”统计数据的结果。</para>
		/// <para>此参数仅在计算百分位数时可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Percentilevalue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// <para>指定当百分位数值位于输入值栅格的两个像元值之间时要使用的插值方法。</para>
		/// <para>自动检测—如果输入值栅格的像素类型为整型，则将使用最近方法。 如果输入值栅格的像素类型为浮点型，则将使用线性方法。 这是默认设置。</para>
		/// <para>最邻近—将使用最接近所需的百分位数的可用值。 在这种情况下，输出像素类型与输入值栅格的像素类型相同。</para>
		/// <para>线性—将使用接近所需百分位数的两个值的加权平均值。 在这种情况下，输出像素类型为浮点型。</para>
		/// <para><see cref="PercentileinterpolationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Percentileinterpolationtype { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Calculate Circular Statistics</para>
		/// <para>指定统计数据类型的计算方式。</para>
		/// <para>未选中 - 将计算算术统计数据。 这是默认设置。</para>
		/// <para>选中 - 将计算适用于循环量的圆形统计数据，例如以度为单位的罗盘方向、日间和实数的小数部分。</para>
		/// <para><see cref="CircularcalculationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Circularcalculation { get; set; } = "false";

		/// <summary>
		/// <para>Circular Wrap Value</para>
		/// <para>循环数据中可能的最高值（上限）。 这是一个正数，默认值为 360。 该值还表示与可能的最低值（下限）相同的数量。</para>
		/// <para>此参数仅在计算圆形统计数据时适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Circularwrapvalue { get; set; } = "360";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeRasterWithin SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? pyramid = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore Missing Values</para>
		/// </summary>
		public enum IgnoremissingvaluesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// </summary>
		public enum ProcessasmultidimensionalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

		}

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// </summary>
		public enum PercentileinterpolationtypeEnum 
		{
			/// <summary>
			/// <para>自动检测—如果输入值栅格的像素类型为整型，则将使用最近方法。 如果输入值栅格的像素类型为浮点型，则将使用线性方法。 这是默认设置。</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("自动检测")]
			AUTO_DETECT,

			/// <summary>
			/// <para>最邻近—将使用最接近所需的百分位数的可用值。 在这种情况下，输出像素类型与输入值栅格的像素类型相同。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>线性—将使用接近所需百分位数的两个值的加权平均值。 在这种情况下，输出像素类型为浮点型。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

		}

		/// <summary>
		/// <para>Calculate Circular Statistics</para>
		/// </summary>
		public enum CircularcalculationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CIRCULAR")]
			CIRCULAR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ARITHMETIC")]
			ARITHMETIC,

		}

#endregion
	}
}
