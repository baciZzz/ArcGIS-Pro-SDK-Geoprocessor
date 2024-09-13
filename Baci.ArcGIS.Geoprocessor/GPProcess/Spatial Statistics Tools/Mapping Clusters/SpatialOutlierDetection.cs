using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Spatial Outlier Detection</para>
	/// <para>空间异常值检测</para>
	/// <para>通过计算每个要素的局部异常值因子 (LOF) 来标识点要素中的空间异常值。空间异常值是异常隔离的位置中的要素，LOF 是一种测量，用于描述某个位置与其局部相邻要素之间的隔离程度。LOF 值越高，表示隔离程度越高。该工具还可用于生成栅格预测曲面，该曲面可用于估计在给定数据空间分布的情况下，是否将新要素分类为异常值。</para>
	/// </summary>
	public class SpatialOutlierDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>用于构建空间异常值检测模型的点要素。将根据每个点的局部异常值因子将其分类为异常值或正常值。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类，其中包含每个输入要素的局部异常值因子以及该点是否为空间异常值的指示符。</para>
		/// </param>
		public SpatialOutlierDetection(object InFeatures, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 空间异常值检测</para>
		/// </summary>
		public override string DisplayName() => "空间异常值检测";

		/// <summary>
		/// <para>Tool Name : SpatialOutlierDetection</para>
		/// </summary>
		public override string ToolName() => "SpatialOutlierDetection";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatialOutlierDetection</para>
		/// </summary>
		public override string ExcuteName() => "stats.SpatialOutlierDetection";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, NNeighbors, PercentOutlier, OutputRaster };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于构建空间异常值检测模型的点要素。将根据每个点的局部异常值因子将其分类为异常值或正常值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类，其中包含每个输入要素的局部异常值因子以及该点是否为空间异常值的指示符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>在计算局部异常值因子时要包含的相邻要素的数目。与输入点距离最近的要素将用作相邻要素。默认值为 20。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100000000)]
		public object NNeighbors { get; set; } = "20";

		/// <summary>
		/// <para>Percent of Locations Considered Outliers</para>
		/// <para>通过定义局部异常值因子的阈值，要标识为空间异常值的位置的百分比。如果未指定任何值，则将在运行时估计一个值，并将其显示为地理处理消息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 49)]
		public object PercentOutlier { get; set; }

		/// <summary>
		/// <para>Output Prediction Raster</para>
		/// <para>输出栅格，其中包含每个像元处的局部异常值因子，将基于输入要素的空间分布进行计算。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutputRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialOutlierDetection SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

	}
}
