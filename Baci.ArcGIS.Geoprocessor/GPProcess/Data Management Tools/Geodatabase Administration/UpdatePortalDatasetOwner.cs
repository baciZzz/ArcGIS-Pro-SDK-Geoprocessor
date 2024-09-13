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
	/// <para>Update Portal Dataset Owner</para>
	/// <para>Updates the portal owner of a dataset to another user.</para>
	/// </summary>
	public class UpdatePortalDatasetOwner : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The input dataset for which the portal owner will be updated.</para>
		/// </param>
		/// <param name="TargetOwner">
		/// <para>Target Owner</para>
		/// <para>The name of the portal user who will be the new portal owner of the dataset.</para>
		/// </param>
		public UpdatePortalDatasetOwner(object InDataset, object TargetOwner)
		{
			this.InDataset = InDataset;
			this.TargetOwner = TargetOwner;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Portal Dataset Owner</para>
		/// </summary>
		public override string DisplayName() => "Update Portal Dataset Owner";

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
		/// <para>The input dataset for which the portal owner will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Target Owner</para>
		/// <para>The name of the portal user who will be the new portal owner of the dataset.</para>
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
		public UpdatePortalDatasetOwner SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
