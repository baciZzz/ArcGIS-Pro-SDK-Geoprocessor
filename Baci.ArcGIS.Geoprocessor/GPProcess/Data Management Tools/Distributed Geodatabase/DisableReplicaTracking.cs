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
	/// <para>Disable Replica Tracking</para>
	/// <para>Disable Replica Tracking</para>
	/// <para>Disables replica tracking on data.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DisableReplicaTracking : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The enterprise geodatabase table, feature class, feature dataset, attributed relationship class, or many-to-many relationship class on which to disable replica tracking.</para>
		/// </param>
		public DisableReplicaTracking(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Disable Replica Tracking</para>
		/// </summary>
		public override string DisplayName() => "Disable Replica Tracking";

		/// <summary>
		/// <para>Tool Name : DisableReplicaTracking</para>
		/// </summary>
		public override string ToolName() => "DisableReplicaTracking";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableReplicaTracking</para>
		/// </summary>
		public override string ExcuteName() => "management.DisableReplicaTracking";

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
		public override object[] Parameters() => new object[] { InDataset, UpdatedDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The enterprise geodatabase table, feature class, feature dataset, attributed relationship class, or many-to-many relationship class on which to disable replica tracking.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedDataset { get; set; }

	}
}
