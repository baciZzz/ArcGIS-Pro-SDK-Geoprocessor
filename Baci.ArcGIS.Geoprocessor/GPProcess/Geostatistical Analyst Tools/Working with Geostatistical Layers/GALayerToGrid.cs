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
	/// <para>GA Layer To Grid</para>
	/// <para>Exports a Geostatistical layer to a raster.</para>
	/// </summary>
	public class GALayerToGrid : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </param>
		/// <param name="OutSurfaceGrid">
		/// <para>Output surface raster</para>
		/// <para>The raster to be created.</para>
		/// </param>
		public GALayerToGrid(object InGeostatLayer, object OutSurfaceGrid)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.OutSurfaceGrid = OutSurfaceGrid;
		}

		/// <summary>
		/// <para>Tool Display Name : GA Layer To Grid</para>
		/// </summary>
		public override string DisplayName() => "GA Layer To Grid";

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
		public override object[] Parameters() => new object[] { InGeostatLayer, OutSurfaceGrid, CellSize!, PointsPerBlockHorz!, PointsPerBlockVert! };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>The raster to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceGrid { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size at which the output raster will be created.</para>
		/// <para>This value can be explicitly set in the Environments by the Cell Size parameter.</para>
		/// <para>If not set, it is the shorter of the width or the height of the extent of the input point features, in the input spatial reference, divided by 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Number of points in the cell (horizontal)</para>
		/// <para>The number of predictions for each cell in the horizontal direction for block interpolation. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		public object? PointsPerBlockHorz { get; set; } = "1";

		/// <summary>
		/// <para>Number of points in the cell (vertical)</para>
		/// <para>The number of predictions for each cell in the vertical direction for block interpolation. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		public object? PointsPerBlockVert { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToGrid SetEnviroment(object? cellSize = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
