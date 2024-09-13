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
	/// <para>Upgrade Attachments</para>
	/// <para>升级附件</para>
	/// <para>升级数据上的附件功能。</para>
	/// </summary>
	public class UpgradeAttachments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>启用了附件的要素类。</para>
		/// </param>
		public UpgradeAttachments(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 升级附件</para>
		/// </summary>
		public override string DisplayName() => "升级附件";

		/// <summary>
		/// <para>Tool Name : UpgradeAttachments</para>
		/// </summary>
		public override string ToolName() => "UpgradeAttachments";

		/// <summary>
		/// <para>Tool Excute Name : management.UpgradeAttachments</para>
		/// </summary>
		public override string ExcuteName() => "management.UpgradeAttachments";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>启用了附件的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutDataset { get; set; }

	}
}
