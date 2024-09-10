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
	/// <para>Upgrades the schema of a mosaic dataset, network dataset, annotation dataset, dimension dataset, parcel fabric, parcel fabric for ArcMap, trace network, or utility network to the current ArcGIS release. Upgrading the dataset allows the dataset to use new functionality in the current software release.</para>
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
		/// <para>The dataset that will be upgraded to the current ArcGIS client release.</para>
		/// </param>
		public UpgradeDataset(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Upgrade Dataset</para>
		/// </summary>
		public override string DisplayName() => "Upgrade Dataset";

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
		/// <para>The dataset that will be upgraded to the current ArcGIS client release.</para>
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
