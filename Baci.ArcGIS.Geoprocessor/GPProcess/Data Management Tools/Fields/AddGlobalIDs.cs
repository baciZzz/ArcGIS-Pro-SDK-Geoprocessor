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
	/// <para>添加全局 ID</para>
	/// <para>向地理数据库要素类、表和要素数据集的列表添加全局 ID。</para>
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
		/// <para>要添加全局 ID 的地理数据库要素类、表和要素数据集的列表。</para>
		/// </param>
		public AddGlobalIDs(object InDatasets)
		{
			this.InDatasets = InDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加全局 ID</para>
		/// </summary>
		public override string DisplayName() => "添加全局 ID";

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
		/// <para>要添加全局 ID 的地理数据库要素类、表和要素数据集的列表。</para>
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
