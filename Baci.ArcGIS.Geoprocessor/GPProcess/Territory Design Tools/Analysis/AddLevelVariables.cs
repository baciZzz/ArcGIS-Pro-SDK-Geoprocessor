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
	/// <para>Add Level Variables</para>
	/// <para>Add Level Variables</para>
	/// <para>Adds a new field at the specified level.</para>
	/// </summary>
	public class AddLevelVariables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The level to which the calculated field will be added.</para>
		/// </param>
		/// <param name="BaseLevel">
		/// <para>Base Level</para>
		/// <para>The level below the territory level from which the attribute value will be added.</para>
		/// </param>
		/// <param name="Variables">
		/// <para>Variables</para>
		/// <para>The variables that will be added to the level.</para>
		/// <para>Statistic Field—Field for the statistical calculation.</para>
		/// <para>Statistic—Type of statistical calculation.</para>
		/// <para>Count—Employs count in the derivation of the statistical calculation.</para>
		/// <para>Sum—Employs summation in the derivation of the statistical calculation.</para>
		/// <para>Maximum—Employs the maximum value in the derivation of the statistical calculation.</para>
		/// <para>Minimum—Employs the minimum value in the derivation of the statistical calculation.</para>
		/// <para>Average—Employs average in the derivation of the statistical calculation.</para>
		/// <para>Median—Employs the use of median techniques in the derivation of the statistical calculation.</para>
		/// <para>Standard Deviation—Employs standard deviation in the derivation of the statistical calculation.</para>
		/// <para>Percent of Total—Employs percentage techniques in the derivation of the statistical calculation.</para>
		/// <para>Field Name—Valid name of the field on the level where calculated data will be stored.</para>
		/// <para>Field Alias Name—Readable and understandable name of the calculated field.</para>
		/// </param>
		public AddLevelVariables(object InTerritorySolution, object Level, object BaseLevel, object Variables)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
			this.BaseLevel = BaseLevel;
			this.Variables = Variables;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Level Variables</para>
		/// </summary>
		public override string DisplayName() => "Add Level Variables";

		/// <summary>
		/// <para>Tool Name : AddLevelVariables</para>
		/// </summary>
		public override string ToolName() => "AddLevelVariables";

		/// <summary>
		/// <para>Tool Excute Name : td.AddLevelVariables</para>
		/// </summary>
		public override string ExcuteName() => "td.AddLevelVariables";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, BaseLevel, Variables, OutTerritorySolution! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The level to which the calculated field will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Base Level</para>
		/// <para>The level below the territory level from which the attribute value will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BaseLevel { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>The variables that will be added to the level.</para>
		/// <para>Statistic Field—Field for the statistical calculation.</para>
		/// <para>Statistic—Type of statistical calculation.</para>
		/// <para>Count—Employs count in the derivation of the statistical calculation.</para>
		/// <para>Sum—Employs summation in the derivation of the statistical calculation.</para>
		/// <para>Maximum—Employs the maximum value in the derivation of the statistical calculation.</para>
		/// <para>Minimum—Employs the minimum value in the derivation of the statistical calculation.</para>
		/// <para>Average—Employs average in the derivation of the statistical calculation.</para>
		/// <para>Median—Employs the use of median techniques in the derivation of the statistical calculation.</para>
		/// <para>Standard Deviation—Employs standard deviation in the derivation of the statistical calculation.</para>
		/// <para>Percent of Total—Employs percentage techniques in the derivation of the statistical calculation.</para>
		/// <para>Field Name—Valid name of the field on the level where calculated data will be stored.</para>
		/// <para>Field Alias Name—Readable and understandable name of the calculated field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddLevelVariables SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
