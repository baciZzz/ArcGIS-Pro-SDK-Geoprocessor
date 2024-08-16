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
	/// <para>Watershed</para>
	/// <para>Determines the contributing area above a set of cells in a raster.</para>
	/// </summary>
	public class Watershed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input D8 flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool, run using the default flow direction type D8.</para>
		/// </param>
		/// <param name="InPourPointData">
		/// <para>Input raster or feature pour point data</para>
		/// <para>The input pour point locations.</para>
		/// <para>For a raster, this represents cells above which the contributing area, or catchment, will be determined. All cells that are not NoData will be used as source cells.</para>
		/// <para>For a point feature dataset, this represents locations above which the contributing area, or catchment, will be determined.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster that shows the contributing area.</para>
		/// <para>This output is of integer type.</para>
		/// </param>
		public Watershed(object InFlowDirectionRaster, object InPourPointData, object OutRaster)
		{
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.InPourPointData = InPourPointData;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Watershed</para>
		/// </summary>
		public override string DisplayName => "Watershed";

		/// <summary>
		/// <para>Tool Name : Watershed</para>
		/// </summary>
		public override string ToolName => "Watershed";

		/// <summary>
		/// <para>Tool Excute Name : sa.Watershed</para>
		/// </summary>
		public override string ExcuteName => "sa.Watershed";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFlowDirectionRaster, InPourPointData, OutRaster, PourPointField };

		/// <summary>
		/// <para>Input D8 flow direction raster</para>
		/// <para>The input raster that shows the direction of flow out of each cell.</para>
		/// <para>The flow direction raster can be created using the Flow Direction tool, run using the default flow direction type D8.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Input raster or feature pour point data</para>
		/// <para>The input pour point locations.</para>
		/// <para>For a raster, this represents cells above which the contributing area, or catchment, will be determined. All cells that are not NoData will be used as source cells.</para>
		/// <para>For a point feature dataset, this represents locations above which the contributing area, or catchment, will be determined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polyline", "Multipoint")]
		public object InPourPointData { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster that shows the contributing area.</para>
		/// <para>This output is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Pour point field</para>
		/// <para>The field used to assign values to the pour point locations.</para>
		/// <para>If the pour point dataset is a raster, use Value.</para>
		/// <para>If the pour point dataset is a feature, use a numeric field. If the field contains floating-point values, they will be truncated into integers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double")]
		public object PourPointField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Watershed SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
