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
	/// <para>Estimate Raster Analysis Cost</para>
	/// <para>Estimate Raster Analysis Cost</para>
	/// </summary>
	[Obsolete()]
	public class EstimateRasterAnalysisCost : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTask">
		/// <para>Input Raster Analysis Task</para>
		/// </param>
		public EstimateRasterAnalysisCost(object InTask)
		{
			this.InTask = InTask;
		}

		/// <summary>
		/// <para>Tool Display Name : Estimate Raster Analysis Cost</para>
		/// </summary>
		public override string DisplayName => "Estimate Raster Analysis Cost";

		/// <summary>
		/// <para>Tool Name : EstimateRasterAnalysisCost</para>
		/// </summary>
		public override string ToolName => "EstimateRasterAnalysisCost";

		/// <summary>
		/// <para>Tool Excute Name : server.EstimateRasterAnalysisCost</para>
		/// </summary>
		public override string ExcuteName => "server.EstimateRasterAnalysisCost";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTask, OutCost };

		/// <summary>
		/// <para>Input Raster Analysis Task</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InTask { get; set; }

		/// <summary>
		/// <para>Output Cost</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutCost { get; set; }

	}
}
