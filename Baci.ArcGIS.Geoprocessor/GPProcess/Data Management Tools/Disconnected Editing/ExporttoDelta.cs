using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Export To Delta</para>
	/// <para>Export To Delta</para>
	/// <para>Exports changes in a check-out replica geodatabase to a delta file.</para>
	/// </summary>
	[Obsolete()]
	public class ExporttoDelta : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Export from Check-out Workspace</para>
		/// </param>
		/// <param name="DestDeltaDatabase">
		/// <para>Export to Delta Database</para>
		/// </param>
		public ExporttoDelta(object InWorkspace, object DestDeltaDatabase)
		{
			this.InWorkspace = InWorkspace;
			this.DestDeltaDatabase = DestDeltaDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Export To Delta</para>
		/// </summary>
		public override string DisplayName() => "Export To Delta";

		/// <summary>
		/// <para>Tool Name : ExporttoDelta</para>
		/// </summary>
		public override string ToolName() => "ExporttoDelta";

		/// <summary>
		/// <para>Tool Excute Name : management.ExporttoDelta</para>
		/// </summary>
		public override string ExcuteName() => "management.ExporttoDelta";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, DestDeltaDatabase };

		/// <summary>
		/// <para>Export from Check-out Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Local Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Export to Delta Database</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("mdb", "xml")]
		public object DestDeltaDatabase { get; set; }

	}
}
