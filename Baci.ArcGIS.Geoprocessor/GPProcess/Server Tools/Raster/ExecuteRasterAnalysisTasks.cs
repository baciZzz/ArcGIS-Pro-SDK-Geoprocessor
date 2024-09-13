using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Execute Raster Analysis Tasks</para>
	/// <para>Execute Raster Analysis Tasks</para>
	/// <para>Execute Raster Analysis Tasks</para>
	/// </summary>
	[Obsolete()]
	public class ExecuteRasterAnalysisTasks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTasks">
		/// <para>Input Raster Analysis Tasks</para>
		/// </param>
		public ExecuteRasterAnalysisTasks(object InTasks)
		{
			this.InTasks = InTasks;
		}

		/// <summary>
		/// <para>Tool Display Name : Execute Raster Analysis Tasks</para>
		/// </summary>
		public override string DisplayName() => "Execute Raster Analysis Tasks";

		/// <summary>
		/// <para>Tool Name : ExecuteRasterAnalysisTasks</para>
		/// </summary>
		public override string ToolName() => "ExecuteRasterAnalysisTasks";

		/// <summary>
		/// <para>Tool Excute Name : server.ExecuteRasterAnalysisTasks</para>
		/// </summary>
		public override string ExcuteName() => "server.ExecuteRasterAnalysisTasks";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTasks, OutResults! };

		/// <summary>
		/// <para>Input Raster Analysis Tasks</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InTasks { get; set; }

		/// <summary>
		/// <para>Output Raster Analysis Results</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutResults { get; set; }

	}
}
