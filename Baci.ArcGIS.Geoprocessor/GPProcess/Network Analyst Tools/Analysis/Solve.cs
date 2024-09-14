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
	/// <para>Solve</para>
	/// <para>Solve</para>
	/// <para>Solves the network analysis layer problem based on its network locations and properties.</para>
	/// </summary>
	[Obsolete()]
	public class Solve : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer on which the analysis will be computed.</para>
		/// </param>
		public Solve(object InNetworkAnalysisLayer)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Solve</para>
		/// </summary>
		public override string DisplayName() => "Solve";

		/// <summary>
		/// <para>Tool Name : Solve</para>
		/// </summary>
		public override string ToolName() => "Solve";

		/// <summary>
		/// <para>Tool Excute Name : na.Solve</para>
		/// </summary>
		public override string ExcuteName() => "na.Solve";

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
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, IgnoreInvalids!, TerminateOnSolveError!, SimplificationTolerance!, OutputLayer!, SolveSucceeded!, Overrides! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer on which the analysis will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// <para>Specifies whether invalid input locations will be ignored. Typically, locations are invalid if they cannot be located on the network. When invalid locations are ignored, the solver will skip them and attempt to perform the analysis using the remaining locations.</para>
		/// <para>Checked—Invalid input locations will be ignored and only valid locations will be used.</para>
		/// <para>Unchecked—All input locations will be used. Any invalid locations will cause the solve to fail.</para>
		/// <para>The default value will match the Ignore Invalid Locations at Solve Time setting on the designated Input Network Analysis Layer value.</para>
		/// <para><see cref="IgnoreInvalidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreInvalids { get; set; } = "true";

		/// <summary>
		/// <para>Terminate on Solve Error</para>
		/// <para>Specifies whether the tool will stop running and terminate if an error is encountered during the solve.</para>
		/// <para>Checked—The tool will stop running and terminate when the solver encounters an error. This is the default.</para>
		/// <para>Unchecked—The tool will not fail and will continue to run when the solver encounters an error. All error messages returned by the solver will be converted to warning messages. Use this option when background processing is enabled in the application.</para>
		/// <para><see cref="TerminateOnSolveErrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TerminateOnSolveError { get; set; } = "true";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>The tolerance that determines the degree of simplification for the output geometry. If a tolerance is specified, it must be greater than zero. You can choose a preferred unit; the default unit is decimal degrees.</para>
		/// <para>Specifying a simplification tolerance tends to reduce the time it takes to render routes or service areas. The drawback, however, is that simplifying geometry removes vertices, which may lessen the spatial accuracy of the output at larger scales.</para>
		/// <para>Because a line with only two vertices cannot be simplified any further, this parameter has no effect on drawing times for single-segment output, such as straight-line routes, OD cost matrix lines, and location-allocation lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? SolveSucceeded { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>This parameter is for internal use only.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Overrides { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Solve SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// </summary>
		public enum IgnoreInvalidsEnum 
		{
			/// <summary>
			/// <para>Checked—Invalid input locations will be ignored and only valid locations will be used.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para>Unchecked—All input locations will be used. Any invalid locations will cause the solve to fail.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

		/// <summary>
		/// <para>Terminate on Solve Error</para>
		/// </summary>
		public enum TerminateOnSolveErrorEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will stop running and terminate when the solver encounters an error. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TERMINATE")]
			TERMINATE,

			/// <summary>
			/// <para>Unchecked—The tool will not fail and will continue to run when the solver encounters an error. All error messages returned by the solver will be converted to warning messages. Use this option when background processing is enabled in the application.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CONTINUE")]
			CONTINUE,

		}

#endregion
	}
}
