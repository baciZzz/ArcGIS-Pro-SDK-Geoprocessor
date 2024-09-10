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
	/// <para>Enable Attachments</para>
	/// <para>Enables attachments on a geodatabase feature class or table. The tool creates the necessary attachment relationship class and attachment table that will store attachment files internally.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableAttachments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The geodatabase table or feature class for which attachments will be enabled. The input must be in a version 10 or later geodatabase.</para>
		/// </param>
		public EnableAttachments(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Attachments</para>
		/// </summary>
		public override string DisplayName() => "Enable Attachments";

		/// <summary>
		/// <para>Tool Name : EnableAttachments</para>
		/// </summary>
		public override string ToolName() => "EnableAttachments";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableAttachments</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableAttachments";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The geodatabase table or feature class for which attachments will be enabled. The input must be in a version 10 or later geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnableAttachments SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
