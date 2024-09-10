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
	/// <para>ASin</para>
	/// <para>Calculates the inverse sine of cells in a raster.</para>
	/// </summary>
	public class ASin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterOrConstant">
		/// <para>Input raster or constant value</para>
		/// <para>The input for which to calculate the inverse sine values.</para>
		/// <para>To use a number as an input for this parameter, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The values are the inverse sine of the input values.</para>
		/// </param>
		public ASin(object InRasterOrConstant, object OutRaster)
		{
			this.InRasterOrConstant = InRasterOrConstant;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : ASin</para>
		/// </summary>
		public override string DisplayName() => "ASin";

		/// <summary>
		/// <para>Tool Name : ASin</para>
		/// </summary>
		public override string ToolName() => "ASin";

		/// <summary>
		/// <para>Tool Excute Name : ia.ASin</para>
		/// </summary>
		public override string ExcuteName() => "ia.ASin";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterOrConstant, OutRaster };

		/// <summary>
		/// <para>Input raster or constant value</para>
		/// <para>The input for which to calculate the inverse sine values.</para>
		/// <para>To use a number as an input for this parameter, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The values are the inverse sine of the input values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ASin SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
