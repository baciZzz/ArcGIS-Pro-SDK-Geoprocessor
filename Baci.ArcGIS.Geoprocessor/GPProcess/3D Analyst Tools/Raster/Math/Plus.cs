using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Plus</para>
	/// <para>Adds (sums) the values of two rasters on a cell-by-cell basis.</para>
	/// </summary>
	public class Plus : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterOrConstant1">
		/// <para>Input raster or constant value 1</para>
		/// <para>The input whose values will be added to.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="InRasterOrConstant2">
		/// <para>Input raster or constant value 2</para>
		/// <para>The input whose values will be added to the first input.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The cell values are the sum of the first input added to the second.</para>
		/// </param>
		public Plus(object InRasterOrConstant1, object InRasterOrConstant2, object OutRaster)
		{
			this.InRasterOrConstant1 = InRasterOrConstant1;
			this.InRasterOrConstant2 = InRasterOrConstant2;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Plus</para>
		/// </summary>
		public override string DisplayName => "Plus";

		/// <summary>
		/// <para>Tool Name : Plus</para>
		/// </summary>
		public override string ToolName => "Plus";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Plus</para>
		/// </summary>
		public override string ExcuteName => "3d.Plus";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasterOrConstant1, InRasterOrConstant2, OutRaster };

		/// <summary>
		/// <para>Input raster or constant value 1</para>
		/// <para>The input whose values will be added to.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRasterOrConstant1 { get; set; }

		/// <summary>
		/// <para>Input raster or constant value 2</para>
		/// <para>The input whose values will be added to the first input.</para>
		/// <para>A number can be used as an input for this parameter, provided a raster is specified for the other parameter. To specify a number for both inputs, the cell size and extent must first be set in the environment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRasterOrConstant2 { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The cell values are the sum of the first input added to the second.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Plus SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
