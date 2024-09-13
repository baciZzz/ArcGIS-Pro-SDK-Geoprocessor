using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Gaussian Geostatistical Simulations</para>
	/// <para>高斯地统计模拟</para>
	/// <para>基于简单克里金模型执行条件或非条件地统计模拟。可将模拟栅格视为与克里金模型具有同等可能性的实现。</para>
	/// </summary>
	public class GaussianGeostatisticalSimulations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>输入由简单克里金模型生成的地统计图层。</para>
		/// </param>
		/// <param name="NumberOfRealizations">
		/// <para>Number of realizations</para>
		/// <para>要执行的模拟数量。</para>
		/// </param>
		/// <param name="OutputWorkspace">
		/// <para>Output workspace</para>
		/// <para>存储所有模拟结果。该工作空间可以是文件夹或地理数据库。</para>
		/// </param>
		/// <param name="OutputSimulationPrefix">
		/// <para>Output simulation prefix</para>
		/// <para>自动添加到输出数据集名称中的字母数字前缀（包含 1 至 3 个字符）。</para>
		/// </param>
		public GaussianGeostatisticalSimulations(object InGeostatLayer, object NumberOfRealizations, object OutputWorkspace, object OutputSimulationPrefix)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.NumberOfRealizations = NumberOfRealizations;
			this.OutputWorkspace = OutputWorkspace;
			this.OutputSimulationPrefix = OutputSimulationPrefix;
		}

		/// <summary>
		/// <para>Tool Display Name : 高斯地统计模拟</para>
		/// </summary>
		public override string DisplayName() => "高斯地统计模拟";

		/// <summary>
		/// <para>Tool Name : GaussianGeostatisticalSimulations</para>
		/// </summary>
		public override string ToolName() => "GaussianGeostatisticalSimulations";

		/// <summary>
		/// <para>Tool Excute Name : ga.GaussianGeostatisticalSimulations</para>
		/// </summary>
		public override string ExcuteName() => "ga.GaussianGeostatisticalSimulations";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, NumberOfRealizations, OutputWorkspace, OutputSimulationPrefix, InConditioningFeatures, ConditioningField, CellSize, InBoundingDataset, SaveSimulatedRasters, Quantile, Threshold, InStatsPolygons, RasterStatType, ConditioningMeasurementErrorField, OutWorkspace, OutPolygonStat, OutRasterSimulation, OutRasterStat, OutConvergenceValue };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>输入由简单克里金模型生成的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Number of realizations</para>
		/// <para>要执行的模拟数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 4500)]
		public object NumberOfRealizations { get; set; } = "10";

		/// <summary>
		/// <para>Output workspace</para>
		/// <para>存储所有模拟结果。该工作空间可以是文件夹或地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Output simulation prefix</para>
		/// <para>自动添加到输出数据集名称中的字母数字前缀（包含 1 至 3 个字符）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputSimulationPrefix { get; set; }

		/// <summary>
		/// <para>Input conditioning features</para>
		/// <para>用作实现条件的要素。如果留空，将生成无条件实现。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		public object InConditioningFeatures { get; set; }

		/// <summary>
		/// <para>Conditioning field</para>
		/// <para>用作实现条件的字段。如果留空，将生成无条件实现。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ConditioningField { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>要创建的输出栅格的像元大小。</para>
		/// <para>可以通过像元大小参数在环境中明确设置该值。</para>
		/// <para>如果未设置，则该值为输入空间参考中输入点要素范围的宽度与高度中的较小值除以 250。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Input bounding features</para>
		/// <para>将分析限制在这些要素的边界面的范围之内。如果输入为点要素，则会自动创建凸包面。然后将在该面内执行实现。如果提供边界要素，那么将忽略“掩膜”环境中提供的任何要素或栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		public object InBoundingDataset { get; set; }

		/// <summary>
		/// <para>Save simulated rasters</para>
		/// <para>指定是否将模拟栅格保存到磁盘中。</para>
		/// <para>选中 - 表示会将模拟栅格保存到磁盘中。</para>
		/// <para>未选中 - 表示不会将模拟栅格保存到磁盘中。</para>
		/// <para><see cref="SaveSimulatedRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SaveSimulatedRasters { get; set; } = "false";

		/// <summary>
		/// <para>Quantile</para>
		/// <para>用于生成输出栅格的分位数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2204460492503131e-16, Max = 0.99999999999999978)]
		public object Quantile { get; set; }

		/// <summary>
		/// <para>Threshold</para>
		/// <para>用于生成输出栅格的阈值，输出栅格为基于每个像元超出所设阈值次数的百分比。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Threshold { get; set; }

		/// <summary>
		/// <para>Input statistical polygons</para>
		/// <para>这些面表示要计算汇总统计数据的感兴趣区域。</para>
		/// <para>如果提供了统计面，则输出面要素类会保存在输出工作空间中，并且与输入面具有相同的名称，但其名称前会加上输出模拟前缀。例如，如果输入统计面的名称为 myPolys，并且您输入了 aaa 作为输出前缀，则输出面将被命名为 aaamyPolys，同时保存在指定的输出工作空间中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InStatsPolygons { get; set; }

		/// <summary>
		/// <para>Raster statistics type</para>
		/// <para>基于每个像元对模拟栅格进行后处理，计算每个所选统计类型并在输出栅格中报告结果。</para>
		/// <para>最小值—计算最小值。</para>
		/// <para>最大值—计算最大值。</para>
		/// <para>平均值—计算平均值。</para>
		/// <para>标准差—计算标准差。</para>
		/// <para>第一四分位数—计算 25 分位数。</para>
		/// <para>中值—计算中值。</para>
		/// <para>第三四分位数—计算 75 分位数。</para>
		/// <para>分位数—计算用户指定的分位数 (0 &lt; Q &lt; 1)。</para>
		/// <para>概率阈值—计算模拟结果像元值超出用户指定阈值的百分比。</para>
		/// <para><see cref="RasterStatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object RasterStatType { get; set; }

		/// <summary>
		/// <para>Conditioning measurement error field</para>
		/// <para>指定条件要素中每个输入点测量误差的字段。对于每个条件要素，此字段的值都应对应一个要素测量值的标准差。如果每个采样位置的测量误差值不同，请使用此字段。</para>
		/// <para>产生不稳定测量误差的常见原因是测量数据时所用的设备不同。一个设备可能比另一个精确，即其测量误差更小。例如，一个温度计舍入到最接近的度，而另一个温度计舍到最接近的度的十分之一。通常，测量误差范围由测量设备的制造商会提供，或通过实践经验获得。</para>
		/// <para>如果没有测量误差值或测量误差值未知，请将此参数留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ConditioningMeasurementErrorField { get; set; }

		/// <summary>
		/// <para>Output workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Output statistical polygons</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPolygonStat { get; set; }

		/// <summary>
		/// <para>Output simulation rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutRasterSimulation { get; set; }

		/// <summary>
		/// <para>Output statistical rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutRasterStat { get; set; }

		/// <summary>
		/// <para>Convergence</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutConvergenceValue { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GaussianGeostatisticalSimulations SetEnviroment(object cellSize = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object randomGenerator = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Save simulated rasters</para>
		/// </summary>
		public enum SaveSimulatedRastersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_SIMULATIONS")]
			SAVE_SIMULATIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SAVE_SIMULATIONS")]
			DO_NOT_SAVE_SIMULATIONS,

		}

		/// <summary>
		/// <para>Raster statistics type</para>
		/// </summary>
		public enum RasterStatTypeEnum 
		{
			/// <summary>
			/// <para>最小值—计算最小值。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—计算最大值。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>平均值—计算平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>标准差—计算标准差。</para>
			/// </summary>
			[GPValue("STDDEV")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>第一四分位数—计算 25 分位数。</para>
			/// </summary>
			[GPValue("QUARTILE1")]
			[Description("第一四分位数")]
			First_quartile,

			/// <summary>
			/// <para>中值—计算中值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>第三四分位数—计算 75 分位数。</para>
			/// </summary>
			[GPValue("QUARTILE3")]
			[Description("第三四分位数")]
			Third_quartile,

			/// <summary>
			/// <para>分位数—计算用户指定的分位数 (0 &lt; Q &lt; 1)。</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("分位数")]
			Quantile,

			/// <summary>
			/// <para>概率阈值—计算模拟结果像元值超出用户指定阈值的百分比。</para>
			/// </summary>
			[GPValue("P_THRSHLD")]
			[Description("概率阈值")]
			Probability_threshold,

		}

#endregion
	}
}
