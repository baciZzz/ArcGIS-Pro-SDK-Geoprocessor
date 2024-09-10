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
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, IgnoreInvalids, TerminateOnSolveError, SimplificationTolerance, OutputLayer, SolveSucceeded, Overrides };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer on which the analysis will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// <para>Specifies whether invalid input locations will be ignored.</para>
		/// <para>Checked—The solver will skip over network locations that are unlocated and solve the analysis layer from valid network locations only. It will also continue solving if locations are on nontraversable elements or have other errors. This is useful if you know your network locations are not all correct, but you want to solve with the network locations that are valid. This is the default.</para>
		/// <para>Unchecked—Do not solve if there are invalid locations. You can then correct these and rerun the analysis.</para>
		/// <para><see cref="IgnoreInvalidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreInvalids { get; set; } = "true";

		/// <summary>
		/// <para>Terminate on Solve Error</para>
		/// <para>Specifies whether tool execution should terminate if an error is encountered during the solve.</para>
		/// <para>Checked—The tool will fail to execute when the solver encounters an error. This is the default.</para>
		/// <para>Unchecked—The tool will not fail and continue execution even when the solver encounters an error. All of the error messages returned by the solver will be converted to warning messages. You should use this option when background processing is enabled in your application.</para>
		/// <para><see cref="TerminateOnSolveErrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TerminateOnSolveError { get; set; } = "true";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>The tolerance that determines the degree of simplification for the output geometry. If a tolerance is specified, it must be greater than zero. You can choose a preferred unit; the default unit is decimal degrees.</para>
		/// <para>Specifying a simplification tolerance tends to reduce the time it takes to render routes or service areas. The drawback, however, is that simplifying geometry removes vertices, which may lessen the spatial accuracy of the output at larger scales.</para>
		/// <para>Because a line with only two vertices cannot be simplified any further, this parameter has no effect on drawing times for single-segment output, such as straight-line routes, OD cost matrix lines, and location-allocation lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object SolveSucceeded { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>Specify additional settings that can influence the behavior of the solver when finding solutions for the network analysis problems.</para>
		/// <para>The value for this parameter needs to be specified in JavaScript Object Notation (JSON). For example, a valid value is of the following form {&quot;overrideSetting1&quot; : &quot;value1&quot;, &quot;overrideSetting2&quot; : &quot;value2&quot;}. The override setting name is always enclosed in double quotation marks. The values can be either a number, Boolean, or a string.</para>
		/// <para>The default value for this parameter is no value, which indicates not to override any solver settings.</para>
		/// <para>Overrides are advanced settings that should be used only after careful analysis of the results obtained before and after applying the settings. A list of supported override settings for each solver and their acceptable values can be obtained by contacting Esri Technical Support.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Overrides { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Solve SetEnviroment(object workspace = null )
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
			/// <para>Checked—The solver will skip over network locations that are unlocated and solve the analysis layer from valid network locations only. It will also continue solving if locations are on nontraversable elements or have other errors. This is useful if you know your network locations are not all correct, but you want to solve with the network locations that are valid. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para>Unchecked—Do not solve if there are invalid locations. You can then correct these and rerun the analysis.</para>
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
			/// <para>Checked—The tool will fail to execute when the solver encounters an error. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TERMINATE")]
			TERMINATE,

			/// <summary>
			/// <para>Unchecked—The tool will not fail and continue execution even when the solver encounters an error. All of the error messages returned by the solver will be converted to warning messages. You should use this option when background processing is enabled in your application.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CONTINUE")]
			CONTINUE,

		}

#endregion
	}
}
