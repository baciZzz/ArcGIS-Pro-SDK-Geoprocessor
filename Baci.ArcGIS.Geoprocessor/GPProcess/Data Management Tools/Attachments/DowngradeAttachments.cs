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
	/// <para>Downgrade Attachments</para>
	/// <para>降级附件</para>
	/// <para>降级要素类或表的附件功能。</para>
	/// </summary>
	public class DowngradeAttachments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>将降级其附件功能的要素类或表。</para>
		/// </param>
		public DowngradeAttachments(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 降级附件</para>
		/// </summary>
		public override string DisplayName() => "降级附件";

		/// <summary>
		/// <para>Tool Name : DowngradeAttachments</para>
		/// </summary>
		public override string ToolName() => "DowngradeAttachments";

		/// <summary>
		/// <para>Tool Excute Name : management.DowngradeAttachments</para>
		/// </summary>
		public override string ExcuteName() => "management.DowngradeAttachments";

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
		/// <para>将降级其附件功能的要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutDataset { get; set; }

	}
}
