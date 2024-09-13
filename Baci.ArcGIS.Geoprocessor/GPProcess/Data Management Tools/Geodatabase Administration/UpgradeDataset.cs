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
	/// <para>Upgrade Dataset</para>
	/// <para>升级数据集</para>
	/// <para>将镶嵌数据集、网络数据集、注记数据集、尺寸数据集、宗地结构、ArcMap 宗地结构、追踪网络或公共设施网络的方案升级到 ArcGIS 的当前版本。通过升级数据集，可使数据集能够使用当前软件版本中的新增功能。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpgradeDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Dataset to upgrade</para>
		/// <para>将升级到当前 ArcGIS 客户端版本的数据集。</para>
		/// </param>
		public UpgradeDataset(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 升级数据集</para>
		/// </summary>
		public override string DisplayName() => "升级数据集";

		/// <summary>
		/// <para>Tool Name : UpgradeDataset</para>
		/// </summary>
		public override string ToolName() => "UpgradeDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.UpgradeDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.UpgradeDataset";

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
		/// <para>Dataset to upgrade</para>
		/// <para>将升级到当前 ArcGIS 客户端版本的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Upgraded Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpgradeDataset SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
