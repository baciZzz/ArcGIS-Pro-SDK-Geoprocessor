using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Increase Maximum Edges</para>
	/// <para>Increase Maximum Edges</para>
	/// <para>Increases the maximum number of edges per turn in a turn feature class.</para>
	/// </summary>
	public class IncreaseMaximumEdges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTurnFeatures">
		/// <para>Input Turn Feature Class</para>
		/// <para>The turn feature class that is having its maximum number of edges raised.</para>
		/// </param>
		/// <param name="MaximumEdges">
		/// <para>Maximum Edges</para>
		/// <para>The new maximum number of edges in the input turn feature class. The value must be at least one higher than the existing maximum number of edges and cannot be greater than 50.</para>
		/// </param>
		public IncreaseMaximumEdges(object InTurnFeatures, object MaximumEdges)
		{
			this.InTurnFeatures = InTurnFeatures;
			this.MaximumEdges = MaximumEdges;
		}

		/// <summary>
		/// <para>Tool Display Name : Increase Maximum Edges</para>
		/// </summary>
		public override string DisplayName() => "Increase Maximum Edges";

		/// <summary>
		/// <para>Tool Name : IncreaseMaximumEdges</para>
		/// </summary>
		public override string ToolName() => "IncreaseMaximumEdges";

		/// <summary>
		/// <para>Tool Excute Name : na.IncreaseMaximumEdges</para>
		/// </summary>
		public override string ExcuteName() => "na.IncreaseMaximumEdges";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTurnFeatures, MaximumEdges, OutTurnFeatures! };

		/// <summary>
		/// <para>Input Turn Feature Class</para>
		/// <para>The turn feature class that is having its maximum number of edges raised.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InTurnFeatures { get; set; }

		/// <summary>
		/// <para>Maximum Edges</para>
		/// <para>The new maximum number of edges in the input turn feature class. The value must be at least one higher than the existing maximum number of edges and cannot be greater than 50.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object MaximumEdges { get; set; }

		/// <summary>
		/// <para>Updated Input Turn Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutTurnFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IncreaseMaximumEdges SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
