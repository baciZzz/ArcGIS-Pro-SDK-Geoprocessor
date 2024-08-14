using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorPositioningTools
{
	/// <summary>
	/// <para>Enable Indoor Positioning</para>
	/// <para>Creates the feature classes and table necessary for storing ArcGIS IPS data in an existing geodatabase.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableIndoorPositioning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The geodatabase where the ArcGIS IPS table and feature classes will be created. This can be a file or enterprise geodatabase.</para>
		/// </param>
		public EnableIndoorPositioning(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Indoor Positioning</para>
		/// </summary>
		public override string DisplayName => "Enable Indoor Positioning";

		/// <summary>
		/// <para>Tool Name : EnableIndoorPositioning</para>
		/// </summary>
		public override string ToolName => "EnableIndoorPositioning";

		/// <summary>
		/// <para>Tool Excute Name : indoorpositioning.EnableIndoorPositioning</para>
		/// </summary>
		public override string ExcuteName => "indoorpositioning.EnableIndoorPositioning";

		/// <summary>
		/// <para>Toolbox Display Name : Indoor Positioning Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Indoor Positioning Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoorpositioning</para>
		/// </summary>
		public override string ToolboxAlise => "indoorpositioning";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, OutIpsRecordings!, OutIpsPositioning!, OutWorkspace!, OutBeaconFeatures! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The geodatabase where the ArcGIS IPS table and feature classes will be created. This can be a file or enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Out IPS Recordings Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutIpsRecordings { get; set; }

		/// <summary>
		/// <para>Out IPS Positioning Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutIpsPositioning { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Out Beacon Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutBeaconFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnableIndoorPositioning SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
