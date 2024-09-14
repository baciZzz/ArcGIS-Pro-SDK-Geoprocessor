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
	/// <para>启用室内定位</para>
	/// <para>用于创建在现有地理数据库中存储 ArcGIS IPS 数据所需的要素类和表。</para>
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
		/// <para>将在其中创建 ArcGIS IPS 表和要素类的地理数据库。 这可以是文件或企业级地理数据库。</para>
		/// </param>
		public EnableIndoorPositioning(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用室内定位</para>
		/// </summary>
		public override string DisplayName() => "启用室内定位";

		/// <summary>
		/// <para>Tool Name : EnableIndoorPositioning</para>
		/// </summary>
		public override string ToolName() => "EnableIndoorPositioning";

		/// <summary>
		/// <para>Tool Excute Name : indoorpositioning.EnableIndoorPositioning</para>
		/// </summary>
		public override string ExcuteName() => "indoorpositioning.EnableIndoorPositioning";

		/// <summary>
		/// <para>Toolbox Display Name : Indoor Positioning Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoor Positioning Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoorpositioning</para>
		/// </summary>
		public override string ToolboxAlise() => "indoorpositioning";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, OutIpsRecordings!, OutIpsPositioning!, OutWorkspace!, OutBeaconFeatures! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>将在其中创建 ArcGIS IPS 表和要素类的地理数据库。 这可以是文件或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
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
		public EnableIndoorPositioning SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
