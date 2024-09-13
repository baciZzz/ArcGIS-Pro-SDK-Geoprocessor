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
	/// <para>Moving Window Kriging</para>
	/// <para>移动窗口克里金法</para>
	/// <para>基于较小的邻域，经过所有位置点重新计算变程、块金和偏基台半变异函数参数。</para>
	/// </summary>
	public class GAMovingWindowKriging : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGaModelSource">
		/// <para>Input geostatistical model source</para>
		/// <para>要分析的地统计模型源。</para>
		/// </param>
		/// <param name="InDatasets">
		/// <para>Input dataset(s)</para>
		/// <para>用于创建输出图层的输入数据集的名称和字段名称。</para>
		/// </param>
		/// <param name="InLocations">
		/// <para>Input point observation locations</para>
		/// <para>将执行预测的点位置。</para>
		/// </param>
		/// <param name="NeighborsMax">
		/// <para>Maximum neighbors to include</para>
		/// <para>要在移动窗口中使用的相邻要素的数目。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output feature class</para>
		/// <para>存储结果的要素类。</para>
		/// </param>
		public GAMovingWindowKriging(object InGaModelSource, object InDatasets, object InLocations, object NeighborsMax, object OutFeatureclass)
		{
			this.InGaModelSource = InGaModelSource;
			this.InDatasets = InDatasets;
			this.InLocations = InLocations;
			this.NeighborsMax = NeighborsMax;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : 移动窗口克里金法</para>
		/// </summary>
		public override string DisplayName() => "移动窗口克里金法";

		/// <summary>
		/// <para>Tool Name : GAMovingWindowKriging</para>
		/// </summary>
		public override string ToolName() => "GAMovingWindowKriging";

		/// <summary>
		/// <para>Tool Excute Name : ga.GAMovingWindowKriging</para>
		/// </summary>
		public override string ExcuteName() => "ga.GAMovingWindowKriging";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGaModelSource, InDatasets, InLocations, NeighborsMax, OutFeatureclass, CellSize!, OutSurfaceGrid! };

		/// <summary>
		/// <para>Input geostatistical model source</para>
		/// <para>要分析的地统计模型源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGaModelSource { get; set; }

		/// <summary>
		/// <para>Input dataset(s)</para>
		/// <para>用于创建输出图层的输入数据集的名称和字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGAValueTable()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Input point observation locations</para>
		/// <para>将执行预测的点位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InLocations { get; set; }

		/// <summary>
		/// <para>Maximum neighbors to include</para>
		/// <para>要在移动窗口中使用的相邻要素的数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 10, Max = 2147483647)]
		public object NeighborsMax { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>存储结果的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

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
		[Category("Output raster (optional)")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>使用局部多项式插值法将输出要素类中的预测值插到栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Output raster (optional)")]
		public object? OutSurfaceGrid { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GAMovingWindowKriging SetEnviroment(object? cellSize = null , object? coincidentPoints = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
