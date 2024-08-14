using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Add Terminal Configuration</para>
	/// <para>Adds a terminal configuration to an existing utility network.</para>
	/// </summary>
	public class AddTerminalConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The input utility network to which the terminal configuration will be added.</para>
		/// </param>
		/// <param name="TerminalConfigurationName">
		/// <para>Name</para>
		/// <para>The name of the terminal configuration.</para>
		/// </param>
		/// <param name="TraversabilityModel">
		/// <para>Directionality</para>
		/// <para>Specifies the directionality of the terminal configuration. A directional traversability model means the flow for the terminal will only go in one direction. A bidirectional traversability model means the terminal allows flow in both directions.</para>
		/// <para>Directional—Only one flow direction is permitted.</para>
		/// <para>Bidirectional—Both flow directions are permitted.</para>
		/// <para><see cref="TraversabilityModelEnum"/></para>
		/// </param>
		public AddTerminalConfiguration(object InUtilityNetwork, object TerminalConfigurationName, object TraversabilityModel)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TerminalConfigurationName = TerminalConfigurationName;
			this.TraversabilityModel = TraversabilityModel;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Terminal Configuration</para>
		/// </summary>
		public override string DisplayName => "Add Terminal Configuration";

		/// <summary>
		/// <para>Tool Name : AddTerminalConfiguration</para>
		/// </summary>
		public override string ToolName => "AddTerminalConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTerminalConfiguration</para>
		/// </summary>
		public override string ExcuteName => "un.AddTerminalConfiguration";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, TerminalConfigurationName, TraversabilityModel, TerminalsDirectional!, TerminalsBidirectional!, ValidPaths!, DefaultPath!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The input utility network to which the terminal configuration will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the terminal configuration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TerminalConfigurationName { get; set; }

		/// <summary>
		/// <para>Directionality</para>
		/// <para>Specifies the directionality of the terminal configuration. A directional traversability model means the flow for the terminal will only go in one direction. A bidirectional traversability model means the terminal allows flow in both directions.</para>
		/// <para>Directional—Only one flow direction is permitted.</para>
		/// <para>Bidirectional—Both flow directions are permitted.</para>
		/// <para><see cref="TraversabilityModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TraversabilityModel { get; set; } = "DIRECTIONAL";

		/// <summary>
		/// <para>Terminals</para>
		/// <para>The name and directional flow of each directional terminal. A minimum of two terminals must be specified, and a maximum of eight can be specified. The name of each terminal cannot exceed 32 characters. This parameter is required if the Directionality parameter value is Directional.</para>
		/// <para>Name—Provide the name of the terminal.</para>
		/// <para>Upstream—Indicate whether the terminal is upstream or downstream.</para>
		/// <para>Checked—The terminal is upstream.</para>
		/// <para>Unchecked—The terminal is downstream.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? TerminalsDirectional { get; set; }

		/// <summary>
		/// <para>Terminals</para>
		/// <para>The name of each bidirectional terminal. A minimum of two terminals must be specified, and a maximum of eight can be specified. The name of each terminal cannot exceed 32 characters. This parameter is required if the Directionality parameter value is Bidirectional (traversability_model = "BIDIRECTIONAL" in Python).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? TerminalsBidirectional { get; set; }

		/// <summary>
		/// <para>Valid Path(s)</para>
		/// <para>The name or names and valid path or paths for the terminal configuration. For bidirectional traversability, this parameter is required if you have three or four terminals. If you are using directional traversability, one of the terminals must be upstream to have valid configurations. Valid paths must be created to indicate which path or paths in a device or junction object are valid for a resource to travel through. Provide a name for each valid path as well as a value.</para>
		/// <para>Name—The name of the valid path.</para>
		/// <para>Value—The value of the valid path.</para>
		/// <para>All—Enter a value of All to create an option that indicates all paths are valid.</para>
		/// <para>None—Enter a value of None to create an option that indicates that no paths are valid.</para>
		/// <para>Terminal pair(s)—Enter a single or collection of terminal pairs. Enter a single terminal pair by specifying the path from one terminal to another separated by a hyphen, for example, A-B. Enter a collection of terminal pairs separated by a comma, for example, A-B, A-C.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ValidPaths { get; set; }

		/// <summary>
		/// <para>Default Path</para>
		/// <para>The default path of the valid configurations. This will be assigned to new features that have this terminal configuration assigned to their asset type. If no valid paths have been specified, the default path All will be used.</para>
		/// <para>All—All paths are valid. This is the default.</para>
		/// <para>None—No paths are valid.</para>
		/// <para>Valid path—A valid path specified in the Valid Path(s) parameter.</para>
		/// <para><see cref="DefaultPathEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DefaultPath { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Directionality</para>
		/// </summary>
		public enum TraversabilityModelEnum 
		{
			/// <summary>
			/// <para>Directionality</para>
			/// </summary>
			[GPValue("DIRECTIONAL")]
			[Description("Directional")]
			Directional,

			/// <summary>
			/// <para>Bidirectional—Both flow directions are permitted.</para>
			/// </summary>
			[GPValue("BIDIRECTIONAL")]
			[Description("Bidirectional")]
			Bidirectional,

		}

		/// <summary>
		/// <para>Default Path</para>
		/// </summary>
		public enum DefaultPathEnum 
		{
			/// <summary>
			/// <para>All—All paths are valid. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>None—No paths are valid.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

#endregion
	}
}
