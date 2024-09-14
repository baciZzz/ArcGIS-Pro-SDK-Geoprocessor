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
	/// <para>Raster Calculator</para>
	/// <para>Raster Calculator</para>
	/// <para>Builds and executes a single Map Algebra expression using Python syntax.</para>
	/// </summary>
	public class RasterCalculator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Expression">
		/// <para>Map Algebra expression</para>
		/// <para>The Map Algebra expression you want to run.</para>
		/// <para>The expression is composed by specifying the inputs, values, operators, and tools to use. You can type in the expression directly or use the controls to help you create it.</para>
		/// <para>The Rasters list identifies the datasets available to use in the Map Algebra expression.</para>
		/// <para>The Tools list provides a selection of commonly used tools to choose from.</para>
		/// </param>
		/// <param name="OutputRaster">
		/// <para>Output raster</para>
		/// <para>The output raster resulting from the Map Algebra expression.</para>
		/// </param>
		public RasterCalculator(object Expression, object OutputRaster)
		{
			this.Expression = Expression;
			this.OutputRaster = OutputRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster Calculator</para>
		/// </summary>
		public override string DisplayName() => "Raster Calculator";

		/// <summary>
		/// <para>Tool Name : RasterCalculator</para>
		/// </summary>
		public override string ToolName() => "RasterCalculator";

		/// <summary>
		/// <para>Tool Excute Name : sa.RasterCalculator</para>
		/// </summary>
		public override string ExcuteName() => "sa.RasterCalculator";

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
		public override object[] Parameters() => new object[] { Expression, OutputRaster };

		/// <summary>
		/// <para>Map Algebra expression</para>
		/// <para>The Map Algebra expression you want to run.</para>
		/// <para>The expression is composed by specifying the inputs, values, operators, and tools to use. You can type in the expression directly or use the controls to help you create it.</para>
		/// <para>The Rasters list identifies the datasets available to use in the Map Algebra expression.</para>
		/// <para>The Tools list provides a selection of commonly used tools to choose from.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterCalculatorExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster resulting from the Map Algebra expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutputRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterCalculator SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
