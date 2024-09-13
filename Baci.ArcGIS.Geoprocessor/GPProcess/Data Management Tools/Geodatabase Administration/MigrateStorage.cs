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
	/// <para>Migrate Storage</para>
	/// <para>迁移存储</para>
	/// <para>将数据从一种数据类型的二进制、空间或空间属性列移动到 Oracle 和 SQL Server 地理数据库中的其他数据类型的新列。迁移时指定的配置关键字可决定用于新列的数据类型。</para>
	/// </summary>
	public class MigrateStorage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDatasets">
		/// <para>Input Datasets</para>
		/// <para>要迁移的数据集。您用于访问数据集的连接必须以数据集所有者的身份连接。</para>
		/// </param>
		/// <param name="ConfigKeyword">
		/// <para>Configuration Keyword</para>
		/// <para>包含适用于该迁移操作的参数值的配置关键字。参数值由地理数据库管理员设置。如果不确定要使用的配置关键字，请与地理数据库管理员联系。</para>
		/// </param>
		public MigrateStorage(object InDatasets, object ConfigKeyword)
		{
			this.InDatasets = InDatasets;
			this.ConfigKeyword = ConfigKeyword;
		}

		/// <summary>
		/// <para>Tool Display Name : 迁移存储</para>
		/// </summary>
		public override string DisplayName() => "迁移存储";

		/// <summary>
		/// <para>Tool Name : MigrateStorage</para>
		/// </summary>
		public override string ToolName() => "MigrateStorage";

		/// <summary>
		/// <para>Tool Excute Name : management.MigrateStorage</para>
		/// </summary>
		public override string ExcuteName() => "management.MigrateStorage";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDatasets, ConfigKeyword, OutDatasetss };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>要迁移的数据集。您用于访问数据集的连接必须以数据集所有者的身份连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>包含适用于该迁移操作的参数值的配置关键字。参数值由地理数据库管理员设置。如果不确定要使用的配置关键字，请与地理数据库管理员联系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Updated Input Datasets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutDatasetss { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MigrateStorage SetEnviroment(object configKeyword = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
