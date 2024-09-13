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
	/// <para>Rescale by Function</para>
	/// <para>按函数重设等级</para>
	/// <para>重设输入栅格值的等级，方法为应用所选变换函数，然后将结果值变换为指定的连续评估等级。</para>
	/// </summary>
	public class RescaleByFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要重设等级的输入栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出的已重设等级的栅格。</para>
		/// <para>将输出浮点型栅格，其值的范围为自等级评估值到至等级评估值（或在两者之内）。</para>
		/// </param>
		public RescaleByFunction(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 按函数重设等级</para>
		/// </summary>
		public override string DisplayName() => "按函数重设等级";

		/// <summary>
		/// <para>Tool Name : RescaleByFunction</para>
		/// </summary>
		public override string ToolName() => "RescaleByFunction";

		/// <summary>
		/// <para>Tool Excute Name : sa.RescaleByFunction</para>
		/// </summary>
		public override string ExcuteName() => "sa.RescaleByFunction";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, TransformationFunction, FromScale, ToScale };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要重设等级的输入栅格。</para>
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
		/// <para>输出的已重设等级的栅格。</para>
		/// <para>将输出浮点型栅格，其值的范围为自等级评估值到至等级评估值（或在两者之内）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Transformation function</para>
		/// <para>指定连续函数以变换输入栅格中的值。</para>
		/// <para>变换函数用于指定重设输入数据等级的函数。下表中详细列出了各个函数的常规描述和默认值。</para>
		/// <para>Exponential—使用指数函数重设输入值的等级。适用情况：优先级随输入值的增加而增加，并且优先级的增加速度因输入值增大而加快。</para>
		/// <para>输入平移 - 默认值从输入栅格中获取。</para>
		/// <para>基础系数 - 默认值从输入栅格中获取。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>Gaussian—使用高斯函数重设输入值的等级。正态分布的中点将定义优先级最高的值，该中点通常指定为至等级。由于最低和最高输入值通常会指定为自等级，因此优先级的值将随着输入值逐渐远离中点而降低，最终达到最低优先级。</para>
		/// <para>中点 - 默认值从输入栅格中获取。</para>
		/// <para>散度 - 默认值从输入栅格中获取。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>Large—用于指示输入栅格值越大优先级越高。中点确定交叉点，大于中点的输入值的优先级将逐渐增高，而小于中点的输入值的优先级将逐渐降低。</para>
		/// <para>中点 - 默认值从输入栅格中获取。</para>
		/// <para>散度 - 默认值是 5。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>Linear—使用线性函数重设输入值的等级。如果最小值小于最大值，则值越大优先级越高。</para>
		/// <para>最小值 - 默认值为输入栅格的最小值。</para>
		/// <para>最大值 - 默认值为输入栅格的最大值。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>Logarithm—使用对数函数重设输入数据的等级。适用于较低输入值的优先级快速增高的情况。随着输入值的增加，其优先级会提高，而提高速度将随着输入值的进一步增加而放缓。</para>
		/// <para>输入平移 - 默认值从输入栅格中获取。</para>
		/// <para>系数 - 默认值从输入栅格中获取。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>LogisticDecay—使用逻辑衰减函数重设输入数据的等级。适用情况：小输入值的优先级最高，并且 随着输入值的增加，其优先级将快速降低，降低速度会在达到较大输入值时放缓。</para>
		/// <para>最小值 - 默认值为输入栅格的最小值。</para>
		/// <para>最大值 - 默认值为输入栅格的最大值。</para>
		/// <para>Y 截距百分比 - 默认值为 99.0。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>LogisticGrowth—使用逻辑增长函数重设输入数据的等级。适用于小输入值具有最低优先级的情况。随着输入值的增加，其优先级将快速提高，提高速度在达到较大输入值时放缓。</para>
		/// <para>最小值 - 默认值为输入栅格的最小值。</para>
		/// <para>最大值 - 默认值为输入栅格的最大值。</para>
		/// <para>Y 截距百分比 - 默认值为 1.0。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>MSLarge—在输入栅格值越大优先级越高的情况下，基于平均值和标准差重设输入数据的等级。计算结果可能与“大值”函数类似，具体取决于如何定义平均值和标准差的乘数。</para>
		/// <para>平均值乘数 - 默认值是 1。</para>
		/// <para>标准差乘数 - 默认值是 1。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>MSSmall—在输入栅格值越小优先级越高的情况下，基于平均值和标准差重设输入数据的等级。计算结果可能与“小值”函数类似，具体取决于如何定义平均值和标准差的乘数。</para>
		/// <para>平均值乘数 - 默认值是 1。</para>
		/// <para>标准差乘数 - 默认值是 1。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>Near—适用情况：输入值非常接近中点时优先级较高。邻近函数与高斯函数类似，但是降低速度更快。</para>
		/// <para>中点 - 默认值从输入栅格中获取。</para>
		/// <para>散度 - 默认值从输入栅格中获取。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>Power—通过使用指定指数的幂函数重设输入数据的等级。适用情况：输入值的优先级随输入值的增加而快速增加。</para>
		/// <para>输入平移 - 默认值从输入栅格中获取。</para>
		/// <para>指数 - 默认值从输入栅格中获取。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>Small—用于指示较小的输入栅格值具有较高优先级。中点确定交叉点，小于中点的输入值的优先级将逐渐增高，而大于中点的输入值的优先级将逐渐降低。</para>
		/// <para>中点 - 默认值从输入栅格中获取。</para>
		/// <para>散度 - 默认值是 5。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>SymmetricLinear—通过在最小值和最大值的中点周围对线性函数进行镜像处理来重设输入数据的等级。适用情况：某个特定输入值的优先级最高，且优先级随着输入值远离该点而以线性方式降低。</para>
		/// <para>最小值 - 默认值为输入栅格的最小值。</para>
		/// <para>最大值 - 默认值为输入栅格的最大值。</para>
		/// <para>阈值下限 - 默认值为输入栅格的最小值。</para>
		/// <para>小于阈值的值 - 默认值为自比例值。</para>
		/// <para>阈值上限 - 默认值为输入栅格的最大值。</para>
		/// <para>大于阈值的值 - 默认值为至比例值。</para>
		/// <para>默认变换为 MS 小值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSATransformationFunction()]
		public object TransformationFunction { get; set; } = "MSSMALL # # # # # #";

		/// <summary>
		/// <para>From scale</para>
		/// <para>输出评估等级的起始值。</para>
		/// <para>自等级的值不能等于至等级的值。自等级的值可以低于或高于至等级的值（例如，等级范围可以从 1 至 10 或从 10 至 1）。</para>
		/// <para>该值必须为正，且可以是整型值或双精度值。</para>
		/// <para>默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object FromScale { get; set; } = "1";

		/// <summary>
		/// <para>To scale</para>
		/// <para>输出评估等级的结束值。</para>
		/// <para>至等级的值不能等于自等级的值。至等级的值可以低于或高于自等级的值（例如，等级范围可以从 1 至 10 或从 10 至 1）。</para>
		/// <para>该值必须为正，且可以是整型值或双精度值。</para>
		/// <para>默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object ToScale { get; set; } = "10";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RescaleByFunction SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
