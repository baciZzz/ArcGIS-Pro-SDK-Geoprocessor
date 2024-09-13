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
	/// <para>启用复本追踪</para>
	/// <para>启用对数据的复本追踪，以使用离线地图。 复本追踪适用于配置有同步功能以及用于为每个下载的地图创建版本的选项的服务。</para>
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
		/// <para>启用复本追踪的企业级地理数据库表、要素类、要素数据集、属性关系类或多对多关系类。</para>
		/// </param>
		public EnableReplicaTracking(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用复本追踪</para>
		/// </summary>
		public override string DisplayName() => "启用复本追踪";

		/// <summary>
		/// <para>Tool Name : EnableReplicaTracking</para>
		/// </summary>
		public override string ToolName() => "EnableReplicaTracking";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableReplicaTracking</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableReplicaTracking";

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
		public override object[] Parameters() => new object[] { InDataset, UpdatedDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>启用复本追踪的企业级地理数据库表、要素类、要素数据集、属性关系类或多对多关系类。</para>
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
