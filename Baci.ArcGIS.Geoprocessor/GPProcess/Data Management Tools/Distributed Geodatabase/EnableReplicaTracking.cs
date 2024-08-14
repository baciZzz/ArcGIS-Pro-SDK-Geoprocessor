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
	/// <para>Enable Replica Tracking</para>
	/// <para>Enables replica tracking on data, allowing you to work with  offline maps. Replica tracking applies to services that are configured with the sync capability with the option of creating a version for each downloaded map.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableReplicaTracking : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The enterprise geodatabase table, feature class, feature dataset, attributed relationship class, or many-to-many relationship class on which to enable replica tracking.</para>
		/// </param>
		public EnableReplicaTracking(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Replica Tracking</para>
		/// </summary>
		public override string DisplayName => "Enable Replica Tracking";

		/// <summary>
		/// <para>Tool Name : EnableReplicaTracking</para>
		/// </summary>
		public override string ToolName => "EnableReplicaTracking";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableReplicaTracking</para>
		/// </summary>
		public override string ExcuteName => "management.EnableReplicaTracking";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, UpdatedDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The enterprise geodatabase table, feature class, feature dataset, attributed relationship class, or many-to-many relationship class on which to enable replica tracking.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedDataset { get; set; }

	}
}
