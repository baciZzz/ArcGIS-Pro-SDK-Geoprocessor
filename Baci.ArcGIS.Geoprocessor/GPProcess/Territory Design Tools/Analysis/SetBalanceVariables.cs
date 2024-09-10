using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TerritoryDesignTools
{
	/// <summary>
	/// <para>Set Balance Variables</para>
	/// <para>Configures variables to be used in the balancing process.</para>
	/// </summary>
	public class SetBalanceVariables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The name of the input territory solution.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The name of the level to which the calculated field will be added.</para>
		/// </param>
		public SetBalanceVariables(object InTerritorySolution, object Level)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Balance Variables</para>
		/// </summary>
		public override string DisplayName() => "Set Balance Variables";

		/// <summary>
		/// <para>Tool Name : SetBalanceVariables</para>
		/// </summary>
		public override string ToolName() => "SetBalanceVariables";

		/// <summary>
		/// <para>Tool Excute Name : td.SetBalanceVariables</para>
		/// </summary>
		public override string ExcuteName() => "td.SetBalanceVariables";

		/// <summary>
		/// <para>Toolbox Display Name : Territory Design Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Territory Design Tools";

		/// <summary>
		/// <para>Toolbox Alise : td</para>
		/// </summary>
		public override string ToolboxAlise() => "td";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, Variables, OutTerritorySolution };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The name of the input territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The name of the level to which the calculated field will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Balance Variables</para>
		/// <para>The variables that will be used in the balance process.</para>
		/// <para>Variable—The defined input.</para>
		/// <para>Weight—The amount of influence a given variable has in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutTerritorySolution { get; set; }

	}
}
