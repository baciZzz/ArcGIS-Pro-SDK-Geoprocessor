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
	/// <para>Moves the data from a binary, spatial, or spatial attribute column of one data type to a new column of a different data type in geodatabases in Oracle and SQL Server. The configuration keyword you specify when migrating determines the data type used for the new column.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class MigrateStorage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDatasets">
		/// <para>Input Datasets</para>
		/// <para>Datasets to be migrated. The connection you use to access the datasets must be connecting as the dataset owner.</para>
		/// </param>
		/// <param name="ConfigKeyword">
		/// <para>Configuration Keyword</para>
		/// <para>Configuration keyword containing the appropriate parameter values for the migration. Parameter values are set by the geodatabase administrator. Contact your geodatabase administrator if you are unsure which configuration keyword to use.</para>
		/// </param>
		public MigrateStorage(object InDatasets, object ConfigKeyword)
		{
			this.InDatasets = InDatasets;
			this.ConfigKeyword = ConfigKeyword;
		}

		/// <summary>
		/// <para>Tool Display Name : Migrate Storage</para>
		/// </summary>
		public override string DisplayName => "Migrate Storage";

		/// <summary>
		/// <para>Tool Name : MigrateStorage</para>
		/// </summary>
		public override string ToolName => "MigrateStorage";

		/// <summary>
		/// <para>Tool Excute Name : management.MigrateStorage</para>
		/// </summary>
		public override string ExcuteName => "management.MigrateStorage";

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
		public override string[] ValidEnvironments => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDatasets, ConfigKeyword, OutDatasetss! };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>Datasets to be migrated. The connection you use to access the datasets must be connecting as the dataset owner.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>Configuration keyword containing the appropriate parameter values for the migration. Parameter values are set by the geodatabase administrator. Contact your geodatabase administrator if you are unsure which configuration keyword to use.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Updated Input Datasets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutDatasetss { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MigrateStorage SetEnviroment(object? configKeyword = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
