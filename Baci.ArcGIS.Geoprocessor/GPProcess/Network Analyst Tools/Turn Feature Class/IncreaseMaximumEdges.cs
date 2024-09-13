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
	/// <para>增加最大边数</para>
	/// <para>增加转弯要素类中每个转弯所允许的最大边数。</para>
	/// </summary>
	public class IncreaseMaximumEdges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTurnFeatures">
		/// <para>Input Turn Feature Class</para>
		/// <para>要增加最大边数的转弯要素类。</para>
		/// </param>
		/// <param name="MaximumEdges">
		/// <para>Maximum Edges</para>
		/// <para>输入转弯要素类中新的最大边数。该值至少应比现有最大边数大 1，但不能大于 50。</para>
		/// </param>
		public IncreaseMaximumEdges(object InTurnFeatures, object MaximumEdges)
		{
			this.InTurnFeatures = InTurnFeatures;
			this.MaximumEdges = MaximumEdges;
		}

		/// <summary>
		/// <para>Tool Display Name : 增加最大边数</para>
		/// </summary>
		public override string DisplayName() => "增加最大边数";

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
		/// <para>要增加最大边数的转弯要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InTurnFeatures { get; set; }

		/// <summary>
		/// <para>Maximum Edges</para>
		/// <para>输入转弯要素类中新的最大边数。该值至少应比现有最大边数大 1，但不能大于 50。</para>
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
		public IncreaseMaximumEdges SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
