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
	/// <para>Train Random Trees Regression Model</para>
	/// <para>训练随机树回归模型</para>
	/// <para>对解释变量（自变量）和目标数据集（因变量）之间的关系进行建模。</para>
	/// </summary>
	public class TrainRandomTreesRegressionModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input Rasters</para>
		/// <para>包含解释变量的单波段、多维或多波段栅格数据集或镶嵌数据集。</para>
		/// </param>
		/// <param name="InTargetData">
		/// <para>Target Raster or Points</para>
		/// <para>包含将使用解释变量建模的数据的点要素类。</para>
		/// </param>
		/// <param name="OutRegressionDefinition">
		/// <para>Output Regression Definition File</para>
		/// <para>包含属性信息、统计数据和分类器其他信息的具有 .ecd 扩展名的 JSON 格式文件。</para>
		/// </param>
		public TrainRandomTreesRegressionModel(object InRasters, object InTargetData, object OutRegressionDefinition)
		{
			this.InRasters = InRasters;
			this.InTargetData = InTargetData;
			this.OutRegressionDefinition = OutRegressionDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 训练随机树回归模型</para>
		/// </summary>
		public override string DisplayName() => "训练随机树回归模型";

		/// <summary>
		/// <para>Tool Name : TrainRandomTreesRegressionModel</para>
		/// </summary>
		public override string ToolName() => "TrainRandomTreesRegressionModel";

		/// <summary>
		/// <para>Tool Excute Name : ia.TrainRandomTreesRegressionModel</para>
		/// </summary>
		public override string ExcuteName() => "ia.TrainRandomTreesRegressionModel";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, InTargetData, OutRegressionDefinition, TargetValueField, TargetDimensionField, RasterDimension, OutImportanceTable, MaxNumTrees, MaxTreeDepth, MaxSamples, AveragePointsPerCell };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>包含解释变量的单波段、多维或多波段栅格数据集或镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Target Raster or Points</para>
		/// <para>包含将使用解释变量建模的数据的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTargetData { get; set; }

		/// <summary>
		/// <para>Output Regression Definition File</para>
		/// <para>包含属性信息、统计数据和分类器其他信息的具有 .ecd 扩展名的 JSON 格式文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutRegressionDefinition { get; set; }

		/// <summary>
		/// <para>Target Value Field</para>
		/// <para>目标点要素类或栅格数据集中要建模信息的字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object TargetValueField { get; set; }

		/// <summary>
		/// <para>Target Dimension Field</para>
		/// <para>输入点要素类中定义维度值的日期字段或数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object TargetDimensionField { get; set; }

		/// <summary>
		/// <para>Raster Dimension</para>
		/// <para>链接到目标数据中的维度的输入多维栅格（解释变量）的维度名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object RasterDimension { get; set; }

		/// <summary>
		/// <para>Output Importance Table</para>
		/// <para>包含模型中使用的每个解释变量重要性的描述信息的表格。 数字越大，说明相应变量与预测变量的相关性越大，在预测中的贡献也越大。 值的范围介于 0 到 1 之间，所有值的总和等于 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutImportanceTable { get; set; }

		/// <summary>
		/// <para>Max Number of Trees</para>
		/// <para>森林中的最多树数。 增加树的数量将提高精确度，尽管此改进会逐渐减缓。 树的数量将线性增加处理时间。 默认值为 50。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxNumTrees { get; set; } = "50";

		/// <summary>
		/// <para>Max Tree Depth</para>
		/// <para>森林中的每个树的最大深度。 深度决定每个树为生成决策可以创建的规则数。 树的深度不会超过此设置。 默认值为 30。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxTreeDepth { get; set; } = "30";

		/// <summary>
		/// <para>Max Number of Samples</para>
		/// <para>用于回归分析的最大样本数。 值小于或等于 0 表示系统将使用所有输入目标栅格或点要素类的样本训练回归模型。 默认值为 10,000。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxSamples { get; set; } = "100000";

		/// <summary>
		/// <para>Average Points Per Cell</para>
		/// <para>指定当多个训练点属于一个像元时，是否会计算平均值。 仅当输入目标为点要素类时，此参数才适用。</para>
		/// <para>未选中 - 当多个训练点属于单个像元时，将使用所有点。 这是默认设置。</para>
		/// <para>选中 - 将计算像元内训练点的平均值。</para>
		/// <para>保留所有点—当多个训练点属于单个像元时，将使用所有点。 这是默认设置。</para>
		/// <para>每个像元的平均点—将计算像元内训练点的平均值。</para>
		/// <para><see cref="AveragePointsPerCellEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AveragePointsPerCell { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainRandomTreesRegressionModel SetEnviroment(object cellSize = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Average Points Per Cell</para>
		/// </summary>
		public enum AveragePointsPerCellEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AVERAGE_POINTS_PER_CELL")]
			AVERAGE_POINTS_PER_CELL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_POINTS")]
			KEEP_ALL_POINTS,

		}

#endregion
	}
}
