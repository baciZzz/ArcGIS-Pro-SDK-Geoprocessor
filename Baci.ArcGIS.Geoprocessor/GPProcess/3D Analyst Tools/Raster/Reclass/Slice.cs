using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Slice</para>
	/// <para>分割</para>
	/// <para>将输入像元值的范围分割或重分类为区域。 可用的数据分类方法包括相等间隔、相等面积（分位数）、自然间断、标准偏差（以平均值为中心）、标准偏差（平均值作为间断）、定义间隔和几何间隔。</para>
	/// </summary>
	public class Slice : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// <para>除了标准 ObjectID、Value 和 Count 字段之外，输出栅格的属性表还将有两个新字段。 该 Value 字段指示类值。 ZoneMin 和 ZoneMax 字段分别记录用于生成类的最小值和最大值。</para>
		/// </param>
		public Slice(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 分割</para>
		/// </summary>
		public override string DisplayName() => "分割";

		/// <summary>
		/// <para>Tool Name : 分割</para>
		/// </summary>
		public override string ToolName() => "分割";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Slice</para>
		/// </summary>
		public override string ExcuteName() => "3d.Slice";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberZones!, SliceType!, BaseOutputZone!, NodataToValue!, ClassIntervalSize! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// <para>除了标准 ObjectID、Value 和 Count 字段之外，输出栅格的属性表还将有两个新字段。 该 Value 字段指示类值。 ZoneMin 和 ZoneMax 字段分别记录用于生成类的最小值和最大值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of output zones</para>
		/// <para>输入栅格将被重新分类到的区域数。</para>
		/// <para>当分割方法参数值为等面积、等间隔、自然中断或几何间隔时，需要此参数。</para>
		/// <para>当分割方法参数值为定义间隔、标准差（以平均值为中心）或标准差（以平均值为间断）时，输出区域数参数将处于非活动状态。 输出区域的数量将由间隔大小参数值决定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? NumberZones { get; set; }

		/// <summary>
		/// <para>Slice method</para>
		/// <para>指定将输入栅格重新分类为区域的方式。</para>
		/// <para>相等间隔—输入值的范围将被平均划分为指定数量的输出区域以确定类间断。 这是默认设置。</para>
		/// <para>相等面积—输入像元的数量将被平均划分为指定数量的输出区域以确定类间断。 每个区域将具有相似数量的像元，表示相似的面积。</para>
		/// <para>自然间断点—以最小化分类内方差和最大化分类间方差的方式确定类间断。 中断通常设置在数据值中变化相对较大的位置。</para>
		/// <para>标准差（以平均值为中心）—类中断将以标准差为单位、以指定的间隔大小（例如 2、1 或 0.5）置于平均值的上方和下方，直到达到输入栅格的最小值和最大值。 平均值不用作中断，而是以两个类中断为中心。 一个中断在平均值之上的指定间隔大小的一半处，另一个中断在平均值之下的指定间隔大小的一半处。 使用 N-1 分母计算标准差，其中 N 是具有值的像素数量。</para>
		/// <para>标准差（以平均值为中断）—将平均值用作类中断。 其他类中断将以标准差为单位、以指定的间隔大小（例如 2、1 或 0.5）置于平均值的上方和下方，直到达到输入栅格的最小值和最大值。 使用 N-1 分母计算标准差，其中 N 是具有值的像素数量。</para>
		/// <para>定义的间隔—类中断将被设置为零和相对于零的指定间隔大小的倍数。 然后，它们将被裁剪到第一类和最后一类的输入数据的最小值和最大值。 对于包含零的值范围，将始终包含零作为中断点。</para>
		/// <para>几何间隔—将基于具有几何系列的类间隔创建类中断。 在此模式中，当前值等于前一值除以几何系数。 分类器中的几何系数可以更改一次（可更改为其倒数），以便优化类范围。 该算法创建这些几何间隔的原理是，使每个类的元素数的平方和最小。 此方法可确保每个类中所拥有的值的数量大致相同，且间隔之间的变化一致。</para>
		/// <para><see cref="SliceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SliceType { get; set; } = "EQUAL_INTERVAL";

		/// <summary>
		/// <para>Starting value for output</para>
		/// <para>将用于输出栅格数据集上区域（类）的起始值。</para>
		/// <para>将为类分配整数值，从起始值开始逐渐加 1。</para>
		/// <para>默认起始值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = false, Value = -2147483647)]
		[High(Allow = true, Value = 2147483647)]
		public object? BaseOutputZone { get; set; } = "1";

		/// <summary>
		/// <para>Change NoData to value for output</para>
		/// <para>将 NoData 替换为输出中的值。</para>
		/// <para>如果未设置此参数，则输出栅格中的 NoData 像元将继续保留为 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = false, Value = -2147483647)]
		[High(Allow = true, Value = 2147483647)]
		public object? NodataToValue { get; set; }

		/// <summary>
		/// <para>Interval size</para>
		/// <para>类之间间隔的大小。</para>
		/// <para>当分割方法参数被设置为定义间隔、标准差（以平均值为中心）或标准差（以平均值为中断）时，需要该参数。</para>
		/// <para>如果使用定义间隔，则间隔大小表示的是用于计算类中断的类的实际值范围。</para>
		/// <para>如果使用标准差（以平均值为中心）或标准差（以平均值为间断），则间隔大小表示的是用于计算类中断的标准差的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ClassIntervalSize { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Slice SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slice method</para>
		/// </summary>
		public enum SliceTypeEnum 
		{
			/// <summary>
			/// <para>相等间隔—输入值的范围将被平均划分为指定数量的输出区域以确定类间断。 这是默认设置。</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("相等间隔")]
			Equal_interval,

			/// <summary>
			/// <para>相等面积—输入像元的数量将被平均划分为指定数量的输出区域以确定类间断。 每个区域将具有相似数量的像元，表示相似的面积。</para>
			/// </summary>
			[GPValue("EQUAL_AREA")]
			[Description("相等面积")]
			Equal_area,

			/// <summary>
			/// <para>自然间断点—以最小化分类内方差和最大化分类间方差的方式确定类间断。 中断通常设置在数据值中变化相对较大的位置。</para>
			/// </summary>
			[GPValue("NATURAL_BREAKS")]
			[Description("自然间断点")]
			Natural_breaks,

			/// <summary>
			/// <para>标准差（以平均值为中心）—类中断将以标准差为单位、以指定的间隔大小（例如 2、1 或 0.5）置于平均值的上方和下方，直到达到输入栅格的最小值和最大值。 平均值不用作中断，而是以两个类中断为中心。 一个中断在平均值之上的指定间隔大小的一半处，另一个中断在平均值之下的指定间隔大小的一半处。 使用 N-1 分母计算标准差，其中 N 是具有值的像素数量。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION_MEAN_CENTERED")]
			[Description("标准差（以平均值为中心）")]
			STANDARD_DEVIATION_MEAN_CENTERED,

			/// <summary>
			/// <para>标准差（以平均值为中断）—将平均值用作类中断。 其他类中断将以标准差为单位、以指定的间隔大小（例如 2、1 或 0.5）置于平均值的上方和下方，直到达到输入栅格的最小值和最大值。 使用 N-1 分母计算标准差，其中 N 是具有值的像素数量。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION_MEAN_BREAK")]
			[Description("标准差（以平均值为中断）")]
			STANDARD_DEVIATION_MEAN_BREAK,

			/// <summary>
			/// <para>定义的间隔—类中断将被设置为零和相对于零的指定间隔大小的倍数。 然后，它们将被裁剪到第一类和最后一类的输入数据的最小值和最大值。 对于包含零的值范围，将始终包含零作为中断点。</para>
			/// </summary>
			[GPValue("DEFINED_INTERVAL")]
			[Description("定义的间隔")]
			Defined_interval,

			/// <summary>
			/// <para>几何间隔—将基于具有几何系列的类间隔创建类中断。 在此模式中，当前值等于前一值除以几何系数。 分类器中的几何系数可以更改一次（可更改为其倒数），以便优化类范围。 该算法创建这些几何间隔的原理是，使每个类的元素数的平方和最小。 此方法可确保每个类中所拥有的值的数量大致相同，且间隔之间的变化一致。</para>
			/// </summary>
			[GPValue("GEOMETRIC_INTERVAL")]
			[Description("几何间隔")]
			Geometric_interval,

		}

#endregion
	}
}
