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
	/// <para>GA Layer To Grid</para>
	/// <para>GA 图层转格网</para>
	/// <para>将地统计图层导出为栅格。</para>
	/// </summary>
	public class GALayerToGrid : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </param>
		/// <param name="OutSurfaceGrid">
		/// <para>Output surface raster</para>
		/// <para>要创建的栅格。</para>
		/// </param>
		public GALayerToGrid(object InGeostatLayer, object OutSurfaceGrid)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.OutSurfaceGrid = OutSurfaceGrid;
		}

		/// <summary>
		/// <para>Tool Display Name : GA 图层转格网</para>
		/// </summary>
		public override string DisplayName() => "GA 图层转格网";

		/// <summary>
		/// <para>Tool Name : GALayerToGrid</para>
		/// </summary>
		public override string ToolName() => "GALayerToGrid";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayerToGrid</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayerToGrid";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, OutSurfaceGrid, CellSize, PointsPerBlockHorz, PointsPerBlockVert };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>要创建的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceGrid { get; set; }

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
		/// <para>Number of points in the cell (horizontal)</para>
		/// <para>针对水平方向上的各像元用于分块内插的预测数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		public object PointsPerBlockHorz { get; set; } = "1";

		/// <summary>
		/// <para>Number of points in the cell (vertical)</para>
		/// <para>针对垂直方向上的各像元用于分块内插的预测数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		public object PointsPerBlockVert { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToGrid SetEnviroment(object cellSize = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
