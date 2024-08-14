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
	/// <para>Solve Territories</para>
	/// <para>Creates and balances territories on the specified territory level provided that the balancing variables are set.</para>
	/// </summary>
	public class SolveTerritories : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The territory solution that will be used to solve territories.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The level that will be used to solve territories.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Number of Territories Method</para>
		/// <para>Specifies the method that will be used to calculate the number of territories.</para>
		/// <para>User Defined—The number of territories will be provided by the user. This is the default.</para>
		/// <para>Optimal—The number of territories will be calculated automatically.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public SolveTerritories(object InTerritorySolution, object Level, object Method)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : Solve Territories</para>
		/// </summary>
		public override string DisplayName => "Solve Territories";

		/// <summary>
		/// <para>Tool Name : SolveTerritories</para>
		/// </summary>
		public override string ToolName => "SolveTerritories";

		/// <summary>
		/// <para>Tool Excute Name : td.SolveTerritories</para>
		/// </summary>
		public override string ExcuteName => "td.SolveTerritories";

		/// <summary>
		/// <para>Toolbox Display Name : Territory Design Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Territory Design Tools";

		/// <summary>
		/// <para>Toolbox Alise : td</para>
		/// </summary>
		public override string ToolboxAlise => "td";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTerritorySolution, Level, Method, NumberTerritories, OutTerritorySolution, Quality };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The territory solution that will be used to solve territories.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The level that will be used to solve territories.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Number of Territories Method</para>
		/// <para>Specifies the method that will be used to calculate the number of territories.</para>
		/// <para>User Defined—The number of territories will be provided by the user. This is the default.</para>
		/// <para>Optimal—The number of territories will be calculated automatically.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; }

		/// <summary>
		/// <para>Number of Territories</para>
		/// <para>The number of territories to be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberTerritories { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Quality (%)</para>
		/// <para>An integer between 1 and 200 that determines the performance of a solve operation. A lower value will provide better performance but quality may be affected. The default value is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Advanced Options")]
		public object Quality { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SolveTerritories SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of Territories Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>User Defined—The number of territories will be provided by the user. This is the default.</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("User Defined")]
			User_Defined,

			/// <summary>
			/// <para>Optimal—The number of territories will be calculated automatically.</para>
			/// </summary>
			[GPValue("OPTIMAL")]
			[Description("Optimal")]
			Optimal,

		}

#endregion
	}
}
