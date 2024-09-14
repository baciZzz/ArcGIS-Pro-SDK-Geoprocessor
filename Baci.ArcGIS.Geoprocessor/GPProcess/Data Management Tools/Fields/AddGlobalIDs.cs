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
	/// <para>Add Global IDs</para>
	/// <para>Add Global IDs</para>
	/// <para>Adds global IDs to a list of geodatabase feature classes, tables, and feature datasets.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddGlobalIDs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDatasets">
		/// <para>Input Datasets</para>
		/// <para>A list of geodatabase classes, tables, and feature datasets to which global IDs will be added.</para>
		/// </param>
		public AddGlobalIDs(object InDatasets)
		{
			this.InDatasets = InDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Global IDs</para>
		/// </summary>
		public override string DisplayName() => "Add Global IDs";

		/// <summary>
		/// <para>Tool Name : AddGlobalIDs</para>
		/// </summary>
		public override string ToolName() => "AddGlobalIDs";

		/// <summary>
		/// <para>Tool Excute Name : management.AddGlobalIDs</para>
		/// </summary>
		public override string ExcuteName() => "management.AddGlobalIDs";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDatasets, OutDatasets! };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>A list of geodatabase classes, tables, and feature datasets to which global IDs will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Updated Datasets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutDatasets { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddGlobalIDs SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
