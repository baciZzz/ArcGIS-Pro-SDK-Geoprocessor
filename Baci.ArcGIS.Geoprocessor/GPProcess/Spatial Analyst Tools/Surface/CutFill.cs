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
	/// <para>Cut Fill</para>
	/// <para>Cut Fill</para>
	/// <para>Calculates the volume change between two surfaces. This is typically used for cut and fill operations.</para>
	/// </summary>
	public class CutFill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBeforeSurface">
		/// <para>Input before raster surface</para>
		/// <para>The input representing the surface before the cut or fill operation.</para>
		/// </param>
		/// <param name="InAfterSurface">
		/// <para>Input after raster surface</para>
		/// <para>The input representing the surface after the cut or fill operation.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster defining regions of cut and of fill.</para>
		/// <para>The values show the locations and amounts where the surface has been added to or removed from.</para>
		/// </param>
		public CutFill(object InBeforeSurface, object InAfterSurface, object OutRaster)
		{
			this.InBeforeSurface = InBeforeSurface;
			this.InAfterSurface = InAfterSurface;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Cut Fill</para>
		/// </summary>
		public override string DisplayName() => "Cut Fill";

		/// <summary>
		/// <para>Tool Name : CutFill</para>
		/// </summary>
		public override string ToolName() => "CutFill";

		/// <summary>
		/// <para>Tool Excute Name : sa.CutFill</para>
		/// </summary>
		public override string ExcuteName() => "sa.CutFill";

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
		public override object[] Parameters() => new object[] { InBeforeSurface, InAfterSurface, OutRaster, ZFactor! };

		/// <summary>
		/// <para>Input before raster surface</para>
		/// <para>The input representing the surface before the cut or fill operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "DETin")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InBeforeSurface { get; set; }

		/// <summary>
		/// <para>Input after raster surface</para>
		/// <para>The input representing the surface after the cut or fill operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "DETin")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InAfterSurface { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster defining regions of cut and of fill.</para>
		/// <para>The values show the locations and amounts where the surface has been added to or removed from.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Z factor</para>
		/// <para>The number of ground x,y units in one surface z-unit.</para>
		/// <para>The z-factor adjusts the units of measure for the z-units when they are different from the x,y units of the input surface. The z-values of the input surface are multiplied by the z-factor when calculating the final output surface.</para>
		/// <para>If the x,y units and z-units are in the same units of measure, the z-factor is 1. This is the default.</para>
		/// <para>If the x,y units and z-units are in different units of measure, the z-factor must be set to the appropriate factor or the results will be incorrect. For example, if the z-units are feet and the x,y units are meters, you would use a z-factor of 0.3048 to convert the z-units from feet to meters (1 foot = 0.3048 meter).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CutFill SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
