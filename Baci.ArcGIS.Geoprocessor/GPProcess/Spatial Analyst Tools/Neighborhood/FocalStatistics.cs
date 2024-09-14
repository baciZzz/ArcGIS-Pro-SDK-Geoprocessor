using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Focal Statistics</para>
	/// <para>焦点统计</para>
	/// <para>为每个输入像元位置计算其周围指定邻域内的值的统计数据。</para>
	/// </summary>
	public class FocalStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>系统将为其计算每个输入像元的焦点统计数据的栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出焦点统计栅格。</para>
		/// </param>
		public FocalStatistics(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 焦点统计</para>
		/// </summary>
		public override string DisplayName() => "焦点统计";

		/// <summary>
		/// <para>Tool Name : FocalStatistics</para>
		/// </summary>
		public override string ToolName() => "FocalStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.FocalStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.FocalStatistics";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Neighborhood!, StatisticsType!, IgnoreNodata!, PercentileValue! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>系统将为其计算每个输入像元的焦点统计数据的栅格。</para>
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
		/// <para>输出焦点统计栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Neighborhood</para>
		/// <para>统计计算中将使用的处理像元周围的像元。 有多种预定义邻域类型可供选择，也可以定义自定义核。</para>
		/// <para>选择邻域类型后，可设置其他参数来完全定义形状、大小和测量单位。 默认邻域是宽和高为三个像元的方矩形。</para>
		/// <para>以下为可用邻域类型的形式：</para>
		/// <para>环形，内半径，外半径，单位类型由内半径或外半径定义的环形（圆环形）邻域。 默认环形具有一个像元的内半径以及三个像元的外半径。</para>
		/// <para>圆，半径，单位类型具有给定半径的圆形邻域。 默认半径为三个像元。</para>
		/// <para>矩形，高度，宽度，单位类型由高度和宽度定义的矩形邻域。 默认设置是高和宽为三个像元的正方形。</para>
		/// <para>楔形，半径，起始角度，终止角度，单位类型由半径、起始角度和终止角度定义的楔形邻域。 楔形按逆时针方向从起始角延伸到终止角。 角度以度为单位进行指定，0 或 360 的值表示东方。 也可使用负角度。 默认楔形起始角度为 0 度，终止角度为 90 度，半径为三个像元。</para>
		/// <para>不规则，核文件带有通过已识别核文本文件设置的规范的自定义邻域。</para>
		/// <para>权重，核文件带有通过已识别核文本文件设置的规范的自定义邻域，可将权重应用于邻域的成员。</para>
		/// <para>对于环形、圆形、矩形和楔形邻域类型，参数的距离单位能够以像元单位或地图单位进行指定。 默认设置为“像元”单位。</para>
		/// <para>对于核邻域，核文件中的第一行将以像元数来定义邻域的宽度和高度。 后续各行将指示如何处理与核中该位置相对应的输入值。 核文件中不规则邻域或权重邻域类型的值为 0 表示相应位置将不包括在计算中。 对于不规则邻域，核文件中的值为 1 表示相应的输入像元将包含在运算中。 对于权重邻域，每个位置的值均表示需要与对应输入像元值相乘的值。 可以使用正值、负值和小数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSANeighborhood()]
		[GPSANeighborhoodDomain()]
		[NeighbourType("Rectangle", "Circle", "Annulus", "Wedge", "Irregular", "Weight")]
		public object? Neighborhood { get; set; } = "Rectangle 3 3 CELL";

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>指定要计算的统计数据类型。</para>
		/// <para>平均值—将计算邻域内像元的平均值。</para>
		/// <para>众数—将识别邻域内像元的众数（出现次数最多的值）。</para>
		/// <para>最大值—将识别邻域内像元的最大值。</para>
		/// <para>中值—将计算邻域内像元的中值。 中位数相当于第 50 个百分点。</para>
		/// <para>最小值—将识别邻域内像元的最小值。</para>
		/// <para>少数—将识别邻域内像元的少数（出现次数最少的值）。</para>
		/// <para>百分比数—将计算邻域内像元的百分比数。 默认情况下将计算 90% 百分比数。 您可以使用百分数值参数来指定其他值（从 0 到 100）。</para>
		/// <para>范围—将计算邻域内像元的范围（最大值和最小值之差）。</para>
		/// <para>标准差—将计算邻域内像元的标准差。</para>
		/// <para>总和—将计算邻域内像元的总和。</para>
		/// <para>变异度—将计算邻域内像元的变异度（唯一值的数量）。</para>
		/// <para>默认统计类型为平均值。</para>
		/// <para>如果输入栅格为整型，则所有统计类型均可用。 如果输入栅格为浮点型，则只有平均值、最大值、中值、最小值、百分比数、范围、标准差和总和统计类型可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>指定在进行统计计算时是否将忽略 NoData 值。</para>
		/// <para>选中 - 当邻域中存在 NoData 值时，将忽略此 NoData 值。 将仅使用邻域内具有数据值的像元来确定输出值。 如果处理像元本身为 NoData，则处理像元即可在输出栅格中接收值，前提是该邻域内至少有一个像元具有有效值。 这是默认设置。</para>
		/// <para>未选中 - 如果邻域内有任意像元的值是 NoData（包括处理像元），则处理像元的输出将为 NoData。 存在 NoData 值表明确定邻域的统计值所需要的信息不足。</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Percentile value</para>
		/// <para>将计算百分数值。 对于 90%，其默认值为 90。</para>
		/// <para>值范围可以介于 0 到 100 之间。 0% 基本上等同于“最小值”统计数据，而 100% 则等同于“最大值”统计数据。 值 50 所生成的结果基本等同于“中值”统计数据的结果。</para>
		/// <para>此选项仅在将统计类型参数设置为百分比数后受支持。 如果指定任何其他统计类型，则将忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 100)]
		public object? PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FocalStatistics SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
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

#endregion
	}
}
