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
	/// <para>Highest Position</para>
	/// <para>Determines on a cell-by-cell basis the position of the raster with the maximum value in a set of rasters.</para>
	/// </summary>
	public class HighestPosition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRastersOrConstants">
		/// <para>Input rasters or constant values</para>
		/// <para>The list of input rasters for which the position of the input with the highest value will be determined.</para>
		/// <para>A number can be used as an input; however, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For each cell in the output raster, the value represents the position of the raster with the highest value.</para>
		/// </param>
		public HighestPosition(object InRastersOrConstants, object OutRaster)
		{
			this.InRastersOrConstants = InRastersOrConstants;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Highest Position</para>
		/// </summary>
		public override string DisplayName() => "Highest Position";

		/// <summary>
		/// <para>Tool Name : HighestPosition</para>
		/// </summary>
		public override string ToolName() => "HighestPosition";

		/// <summary>
		/// <para>Tool Excute Name : sa.HighestPosition</para>
		/// </summary>
		public override string ExcuteName() => "sa.HighestPosition";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRastersOrConstants, OutRaster };

		/// <summary>
		/// <para>Input rasters or constant values</para>
		/// <para>The list of input rasters for which the position of the input with the highest value will be determined.</para>
		/// <para>A number can be used as an input; however, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRastersOrConstants { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>For each cell in the output raster, the value represents the position of the raster with the highest value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HighestPosition SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
