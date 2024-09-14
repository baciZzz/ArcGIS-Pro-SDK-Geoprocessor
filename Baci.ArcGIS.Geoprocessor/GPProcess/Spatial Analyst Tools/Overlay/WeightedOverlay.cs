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
	/// <para>Weighted Overlay</para>
	/// <para>加权叠加</para>
	/// <para>使用常用测量比例叠加多个栅格数据，并根据各栅格数据的重要性分配权重。</para>
	/// </summary>
	public class WeightedOverlay : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWeightedOverlayTable">
		/// <para>Weighted overlay table</para>
		/// <para>使用加权叠加表可执行多个栅格数据之间的多条件分析计算。</para>
		/// <para>输入栅格：</para>
		/// <para>栅格 - 进行加权的输入条件栅格列表。使用此选项浏览栅格数据集或将地图图层添加到输入列表。</para>
		/// <para>% - 以百分比形式表示输入栅格相对于其他条件栅格的影响力百分比。影响力仅通过整数值进行指定。十进制值将向下舍入为最近的整数。影响力总和必须等于 100。使用设置等效影响选项（等号按钮）对所有栅格的影响力百分比进行平衡设置并且要保证总和为 100。</para>
		/// <para>重映射表：</para>
		/// <para>字段 - 要进行加权处理的输入条件字段。</para>
		/// <para>值 - 输入字段值。</para>
		/// <para>级别 - 根据级别设置指定的内容，为条件设定的输出级别值。更改这些值将更改输入栅格中的值。您可以直接输入值或者从下拉列表中选择一个值。除了数值以外，还可以使用以下选项：</para>
		/// <para>Restricted - 无论其他输入栅格是否具有为该像元设置的其他等级值，都将受限制的值（设置的评估等级最小值为负 1）分配至输出像元中。</para>
		/// <para>NoData - 无论其他输入栅格是否为该像元设置了其他等级值，都将 NoData 分配至输出中的像元。</para>
		/// <para>等级 - 用于定义重映射值的评估等级。从预定义的评估等级列表中进行选择。您还可通过将参数连字符或空格输入到分隔值来定义您自己的评估等级控件。负值前面必须使用空格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出加权栅格。</para>
		/// </param>
		public WeightedOverlay(object InWeightedOverlayTable, object OutRaster)
		{
			this.InWeightedOverlayTable = InWeightedOverlayTable;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 加权叠加</para>
		/// </summary>
		public override string DisplayName() => "加权叠加";

		/// <summary>
		/// <para>Tool Name : WeightedOverlay</para>
		/// </summary>
		public override string ToolName() => "WeightedOverlay";

		/// <summary>
		/// <para>Tool Excute Name : sa.WeightedOverlay</para>
		/// </summary>
		public override string ExcuteName() => "sa.WeightedOverlay";

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
		public override object[] Parameters() => new object[] { InWeightedOverlayTable, OutRaster };

		/// <summary>
		/// <para>Weighted overlay table</para>
		/// <para>使用加权叠加表可执行多个栅格数据之间的多条件分析计算。</para>
		/// <para>输入栅格：</para>
		/// <para>栅格 - 进行加权的输入条件栅格列表。使用此选项浏览栅格数据集或将地图图层添加到输入列表。</para>
		/// <para>% - 以百分比形式表示输入栅格相对于其他条件栅格的影响力百分比。影响力仅通过整数值进行指定。十进制值将向下舍入为最近的整数。影响力总和必须等于 100。使用设置等效影响选项（等号按钮）对所有栅格的影响力百分比进行平衡设置并且要保证总和为 100。</para>
		/// <para>重映射表：</para>
		/// <para>字段 - 要进行加权处理的输入条件字段。</para>
		/// <para>值 - 输入字段值。</para>
		/// <para>级别 - 根据级别设置指定的内容，为条件设定的输出级别值。更改这些值将更改输入栅格中的值。您可以直接输入值或者从下拉列表中选择一个值。除了数值以外，还可以使用以下选项：</para>
		/// <para>Restricted - 无论其他输入栅格是否具有为该像元设置的其他等级值，都将受限制的值（设置的评估等级最小值为负 1）分配至输出像元中。</para>
		/// <para>NoData - 无论其他输入栅格是否为该像元设置了其他等级值，都将 NoData 分配至输出中的像元。</para>
		/// <para>等级 - 用于定义重映射值的评估等级。从预定义的评估等级列表中进行选择。您还可通过将参数连字符或空格输入到分隔值来定义您自己的评估等级控件。负值前面必须使用空格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAWeightedOverlayTable()]
		[GPCompositeDomain()]
		public object InWeightedOverlayTable { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出加权栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public WeightedOverlay SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
