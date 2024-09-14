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
	/// <para>Predict Using Regression Model</para>
	/// <para>使用回归模型预测</para>
	/// <para>使用训练随机树回归模型工具的输出来预测数据值。</para>
	/// </summary>
	public class PredictUsingRegressionModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input Rasters</para>
		/// <para>单波段、多维或多波段栅格数据集，或包含解释变量的镶嵌数据集。</para>
		/// </param>
		/// <param name="InRegressionDefinition">
		/// <para>Input Regression Definition File</para>
		/// <para>包含属性信息、统计数据和回归模型的其他信息的 JSON 格式文件。 文件的扩展名为 .ecd。 此文件为训练随机树回归模型工具的输出。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output predicted raster</para>
		/// <para>预测值的栅格。</para>
		/// </param>
		public PredictUsingRegressionModel(object InRasters, object InRegressionDefinition, object OutRasterDataset)
		{
			this.InRasters = InRasters;
			this.InRegressionDefinition = InRegressionDefinition;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用回归模型预测</para>
		/// </summary>
		public override string DisplayName() => "使用回归模型预测";

		/// <summary>
		/// <para>Tool Name : PredictUsingRegressionModel</para>
		/// </summary>
		public override string ToolName() => "PredictUsingRegressionModel";

		/// <summary>
		/// <para>Tool Excute Name : ia.PredictUsingRegressionModel</para>
		/// </summary>
		public override string ExcuteName() => "ia.PredictUsingRegressionModel";

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
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "gpuID", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, InRegressionDefinition, OutRasterDataset };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>单波段、多维或多波段栅格数据集，或包含解释变量的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Input Regression Definition File</para>
		/// <para>包含属性信息、统计数据和回归模型的其他信息的 JSON 格式文件。 文件的扩展名为 .ecd。 此文件为训练随机树回归模型工具的输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InRegressionDefinition { get; set; }

		/// <summary>
		/// <para>Output predicted raster</para>
		/// <para>预测值的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PredictUsingRegressionModel SetEnviroment(object? cellAlignment = null, object? cellSize = null, object? compression = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? processorType = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
