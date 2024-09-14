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
	/// <para>Update Portal Dataset Owner</para>
	/// <para>更新门户数据集所有者</para>
	/// <para>用于将数据集的门户所有者更新为其他用户。</para>
	/// </summary>
	public class UpdatePortalDatasetOwner : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>将更新门户所有者的输入数据集。</para>
		/// </param>
		/// <param name="TargetOwner">
		/// <para>Target Owner</para>
		/// <para>将成为数据集的新门户所有者的门户用户的名称。</para>
		/// </param>
		public UpdatePortalDatasetOwner(object InDataset, object TargetOwner)
		{
			this.InDataset = InDataset;
			this.TargetOwner = TargetOwner;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新门户数据集所有者</para>
		/// </summary>
		public override string DisplayName() => "更新门户数据集所有者";

		/// <summary>
		/// <para>Tool Name : UpdatePortalDatasetOwner</para>
		/// </summary>
		public override string ToolName() => "UpdatePortalDatasetOwner";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdatePortalDatasetOwner</para>
		/// </summary>
		public override string ExcuteName() => "management.UpdatePortalDatasetOwner";

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
		public override object[] Parameters() => new object[] { InDataset, TargetOwner, UpdatedDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>将更新门户所有者的输入数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Target Owner</para>
		/// <para>将成为数据集的新门户所有者的门户用户的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TargetOwner { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPUtilityNetworkLayer()]
		public object? UpdatedDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdatePortalDatasetOwner SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
