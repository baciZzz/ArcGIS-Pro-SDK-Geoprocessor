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
	/// <para>从栅格函数生成表</para>
	/// <para>用于将栅格函数数据集转换为表或要素类。输入栅格函数应该为用于输出表或要素类的栅格函数。</para>
	/// </summary>
	public class GenerateTableFromRasterFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="RasterFunction">
		/// <para>Input Raster Function</para>
		/// <para>输出表或要素类的函数模板或函数 JSON 对象。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>输出表或要素类的路径、文件名和类型（扩展名）。</para>
		/// </param>
		public GenerateTableFromRasterFunction(object RasterFunction, object OutTable)
		{
			this.RasterFunction = RasterFunction;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 从栅格函数生成表</para>
		/// </summary>
		public override string DisplayName() => "从栅格函数生成表";

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
		public override object[] Parameters() => new object[] { RasterFunction, OutTable, RasterFunctionArguments };

		/// <summary>
		/// <para>Input Raster Function</para>
		/// <para>输出表或要素类的函数模板或函数 JSON 对象。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object RasterFunction { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表或要素类的路径、文件名和类型（扩展名）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Raster Function Arguments</para>
		/// <para>函数参数及其要进行设置的值。每个栅格函数都有自己的参数和值，这些参数和值将在工具的对话框中列出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object RasterFunctionArguments { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTableFromRasterFunction SetEnviroment(object cellSize = null, object extent = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
