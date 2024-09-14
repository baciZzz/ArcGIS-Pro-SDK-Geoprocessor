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
	/// <para>Zonal Statistics</para>
	/// <para>分区统计</para>
	/// <para>用于汇总另一个数据集区域内的栅格数据值。</para>
	/// </summary>
	public class ZonalStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneData">
		/// <para>Input Raster or Feature Zone Data</para>
		/// <para>定义区域的数据集。</para>
		/// <para>可通过整型栅格或要素图层来定义区域。</para>
		/// </param>
		/// <param name="ZoneField">
		/// <para>Zone Field</para>
		/// <para>包含定义每个区域的值的字段。</para>
		/// <para>该字段可以是区域数据集的整型字段或字符串型字段。</para>
		/// </param>
		/// <param name="InValueRaster">
		/// <para>Input Value Raster</para>
		/// <para>含有要计算统计数据的值的栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出分区统计栅格。</para>
		/// </param>
		public ZonalStatistics(object InZoneData, object ZoneField, object InValueRaster, object OutRaster)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.InValueRaster = InValueRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 分区统计</para>
		/// </summary>
		public override string DisplayName() => "分区统计";

		/// <summary>
		/// <para>Tool Name : ZonalStatistics</para>
		/// </summary>
		public override string ToolName() => "ZonalStatistics";

		/// <summary>
		/// <para>Tool Excute Name : ia.ZonalStatistics</para>
		/// </summary>
		public override string ExcuteName() => "ia.ZonalStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InZoneData, ZoneField, InValueRaster, OutRaster, StatisticsType!, IgnoreNodata!, ProcessAsMultidimensional!, PercentileValue!, PercentileInterpolationType!, CircularCalculation!, CircularWrapValue! };

		/// <summary>
		/// <para>Input Raster or Feature Zone Data</para>
		/// <para>定义区域的数据集。</para>
		/// <para>可通过整型栅格或要素图层来定义区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InZoneData { get; set; }

		/// <summary>
		/// <para>Zone Field</para>
		/// <para>包含定义每个区域的值的字段。</para>
		/// <para>该字段可以是区域数据集的整型字段或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Input Value Raster</para>
		/// <para>含有要计算统计数据的值的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InValueRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出分区统计栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Statistics Type</para>
		/// <para>指定要计算的统计数据类型。</para>
		/// <para>平均值—将计算值栅格中与输出像元同属一个区域的所有像元的平均值。 这是默认设置。</para>
		/// <para>众数—将计算值栅格中与输出像元同属一个区域的所有像元中最常出现的值。</para>
		/// <para>最大值—将计算值栅格中与输出像元同属一个区域的所有像元的最大值。</para>
		/// <para>中值—将计算值栅格中与输出像元同属一个区域的所有像元的中值。</para>
		/// <para>最小值—将计算值栅格中与输出像元同属一个区域的所有像元的最小值。</para>
		/// <para>少数—将计算值栅格中与输出像元同属一个区域的所有像元中出现次数最少的值。</para>
		/// <para>百分比数—将计算值栅格中与输出像元同属一个区域的所有像元的百分比值。 默认情况下将计算 90% 百分比数。 您可以使用百分比值参数来指定其他值（从 0 到 100）。</para>
		/// <para>范围—将计算值栅格中与输出像元同属一个区域的所有像元的最大值与最小值之差。</para>
		/// <para>标准差—将计算值栅格中与输出像元同属一个区域的所有像元的标准偏差。</para>
		/// <para>总和—将计算值栅格中与输出像元同属一个区域的所有像元的合计值。</para>
		/// <para>变异度—将计算值栅格中与输出像元同属一个区域的所有像元中唯一值的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Ignore NoData in Calculations</para>
		/// <para>指定值输入中的 NoData 值是否会在其所落入区域的结果中被忽略。</para>
		/// <para>选中 - 在任意特定区域内，仅使用在输入值栅格中拥有值的像元来确定该区域的输出值。 在统计计算过程中，值栅格内的 NoData 像元将被忽略。 这是默认设置。</para>
		/// <para>未选中 - 在任何特定区域中，如果 NoData 像元存在于值栅格中，则它们不会被忽略，并且 NoData 像元的存在表明没有足够的信息来对该区域中的所有像元执行统计计算。 因此，整个区域将在输出栅格上接收 NoData 值。</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>指定在输入栅格为多维栅格时，如何进行计算。</para>
		/// <para>未选中 - 将计算输入多维数据集的当前剖切片中的统计数据。 这是默认设置。</para>
		/// <para>已选中 - 将计算输入多维数据集的所有维度的统计数据。</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Percentile Value</para>
		/// <para>要计算的百分比数。 默认值为 90，指示 90%。</para>
		/// <para>取值范围为 0 到 100。 0% 基本上等同于“最小值”统计数据，而 100% 则等同于“最大值”。 值 50 所生成的结果基本等同于“中值”统计数据的结果。</para>
		/// <para>仅当统计类型参数设置为百分位数时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// <para>指定当百分位数值位于输入值栅格的两个像元值之间时要使用的插值方法。</para>
		/// <para>自动检测—如果输入值栅格的像素类型为整型，则将使用最近方法。 如果输入值栅格的像素类型为浮点型，则将使用线性方法。 这是默认设置。</para>
		/// <para>最邻近—将使用最接近所需的百分位数的可用值。 在这种情况下，输出像素类型与输入值栅格的像素类型相同。</para>
		/// <para>线性—将使用接近所需百分位数的两个值的加权平均值。 在这种情况下，输出像素类型为浮点型。</para>
		/// <para><see cref="PercentileInterpolationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PercentileInterpolationType { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Calculate Circular Statistics</para>
		/// <para>指定如何处理圆形数据的输入栅格。</para>
		/// <para>未选中 - 将计算普通线性统计数据。 这是默认设置。</para>
		/// <para>选中 - 将计算角度或其他循环量的统计数据，例如以度为单位的罗盘方向、日间或实数的小数部分。</para>
		/// <para><see cref="CircularCalculationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CircularCalculation { get; set; } = "false";

		/// <summary>
		/// <para>Circular Wrap Value</para>
		/// <para>将用于将线性值四舍五入到给定圆形统计数据范围的值。 其值必须是正整数或浮点值。 默认值为 360 度。</para>
		/// <para>仅当选中计算圆形统计数据参数时，才支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? CircularWrapValue { get; set; } = "360";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalStatistics SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore NoData in Calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
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
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

		}

		/// <summary>
		/// <para>Percentile Interpolation Type</para>
		/// </summary>
		public enum PercentileInterpolationTypeEnum 
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
		public enum CircularCalculationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ARITHMETIC")]
			ARITHMETIC,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CIRCULAR")]
			CIRCULAR,

		}

#endregion
	}
}
