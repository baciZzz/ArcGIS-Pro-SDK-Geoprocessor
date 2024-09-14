using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Generate Table From Raster Function</para>
	/// <para>Generate Table From Raster Function</para>
	/// <para>Converts a raster function dataset to a table or feature class.  The input raster function should be a raster function designed to output a table or feature class.</para>
	/// </summary>
	public class GenerateTableFromRasterFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="RasterFunction">
		/// <para>Input Raster Function</para>
		/// <para>The function template or function JSON object that outputs a table or feature class.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The path, file name, and type (extension) of the output table or feature class.</para>
		/// </param>
		public GenerateTableFromRasterFunction(object RasterFunction, object OutTable)
		{
			this.RasterFunction = RasterFunction;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Table From Raster Function</para>
		/// </summary>
		public override string DisplayName() => "Generate Table From Raster Function";

		/// <summary>
		/// <para>Tool Name : GenerateTableFromRasterFunction</para>
		/// </summary>
		public override string ToolName() => "GenerateTableFromRasterFunction";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateTableFromRasterFunction</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateTableFromRasterFunction";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "gpuID", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { RasterFunction, OutTable, RasterFunctionArguments! };

		/// <summary>
		/// <para>Input Raster Function</para>
		/// <para>The function template or function JSON object that outputs a table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object RasterFunction { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The path, file name, and type (extension) of the output table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Raster Function Arguments</para>
		/// <para>The function arguments and their values to be set. Each raster function has its own arguments and values, which are listed in the dialog of the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? RasterFunctionArguments { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTableFromRasterFunction SetEnviroment(object? cellSize = null, object? extent = null, object? parallelProcessingFactor = null, object? processorType = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
