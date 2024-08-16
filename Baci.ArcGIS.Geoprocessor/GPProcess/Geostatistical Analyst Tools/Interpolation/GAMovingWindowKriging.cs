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
	/// <para>Recalculates the Range, Nugget, and Partial Sill semivariogram parameters based on a smaller neighborhood, moving through all location points.</para>
	/// </summary>
	public class GAMovingWindowKriging : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGaModelSource">
		/// <para>Input geostatistical model source</para>
		/// <para>The geostatistical model source to be analyzed.</para>
		/// </param>
		/// <param name="InDatasets">
		/// <para>Input dataset(s)</para>
		/// <para>The name of the input datasets and field names used in the creation of the output layer.</para>
		/// </param>
		/// <param name="InLocations">
		/// <para>Input point observation locations</para>
		/// <para>Point locations where predictions will be performed.</para>
		/// </param>
		/// <param name="NeighborsMax">
		/// <para>Maximum neighbors to include</para>
		/// <para>Number of neighbors to use in the moving window.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output feature class</para>
		/// <para>Feature class storing the results.</para>
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
		/// <para>Tool Display Name : Moving Window Kriging</para>
		/// </summary>
		public override string DisplayName => "Moving Window Kriging";

		/// <summary>
		/// <para>Tool Name : GAMovingWindowKriging</para>
		/// </summary>
		public override string ToolName => "GAMovingWindowKriging";

		/// <summary>
		/// <para>Tool Excute Name : ga.GAMovingWindowKriging</para>
		/// </summary>
		public override string ExcuteName => "ga.GAMovingWindowKriging";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InGaModelSource, InDatasets, InLocations, NeighborsMax, OutFeatureclass, CellSize, OutSurfaceGrid };

		/// <summary>
		/// <para>Input geostatistical model source</para>
		/// <para>The geostatistical model source to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGaModelSource { get; set; }

		/// <summary>
		/// <para>Input dataset(s)</para>
		/// <para>The name of the input datasets and field names used in the creation of the output layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGAValueTable()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Input point observation locations</para>
		/// <para>Point locations where predictions will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InLocations { get; set; }

		/// <summary>
		/// <para>Maximum neighbors to include</para>
		/// <para>Number of neighbors to use in the moving window.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 10, Max = 2147483647)]
		public object NeighborsMax { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>Feature class storing the results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

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
		[Category("Output raster (optional)")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>The prediction values in the output feature class are interpolated onto a raster using the Local polynomial interpolation method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Output raster (optional)")]
		public object OutSurfaceGrid { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GAMovingWindowKriging SetEnviroment(object cellSize = null , object coincidentPoints = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
