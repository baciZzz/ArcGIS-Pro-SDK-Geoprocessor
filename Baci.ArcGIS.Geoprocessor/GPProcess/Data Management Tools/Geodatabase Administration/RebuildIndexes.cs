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
	/// <para>Rebuild Indexes</para>
	/// <para>Rebuild Indexes</para>
	/// <para>Rebuild existing attribute or spatial indexes in enterprise geodatabases.  Indexes  can also be rebuilt on  states and state_lineage geodatabase system tables and the delta tables of datasets that are registered to participate in traditional versioning. Out-of-date indexes can lead to poor query performance.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RebuildIndexes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The connection (.sde file) to the database or geodatabase that contains the data for which you want to rebuild indexes.</para>
		/// </param>
		/// <param name="IncludeSystem">
		/// <para>Include System Tables</para>
		/// <para>Indicates whether indexes will be rebuilt on the states and state lineages tables.</para>
		/// <para>You must connect as the geodatabase administrator for this option to be activated.</para>
		/// <para>This option only applies to geodatabases. If you connect to a database, this option is disabled.</para>
		/// <para>Unchecked—Indexes will not be rebuilt on the states and state lineages table. This is the default.</para>
		/// <para>Checked—Indexes will be rebuilt on the states and state lineages tables.</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </param>
		public RebuildIndexes(object InputDatabase, object IncludeSystem)
		{
			this.InputDatabase = InputDatabase;
			this.IncludeSystem = IncludeSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : Rebuild Indexes</para>
		/// </summary>
		public override string DisplayName() => "Rebuild Indexes";

		/// <summary>
		/// <para>Tool Name : RebuildIndexes</para>
		/// </summary>
		public override string ToolName() => "RebuildIndexes";

		/// <summary>
		/// <para>Tool Excute Name : management.RebuildIndexes</para>
		/// </summary>
		public override string ExcuteName() => "management.RebuildIndexes";

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
		public override object[] Parameters() => new object[] { InputDatabase, IncludeSystem, InDatasets!, DeltaOnly!, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The connection (.sde file) to the database or geodatabase that contains the data for which you want to rebuild indexes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Include System Tables</para>
		/// <para>Indicates whether indexes will be rebuilt on the states and state lineages tables.</para>
		/// <para>You must connect as the geodatabase administrator for this option to be activated.</para>
		/// <para>This option only applies to geodatabases. If you connect to a database, this option is disabled.</para>
		/// <para>Unchecked—Indexes will not be rebuilt on the states and state lineages table. This is the default.</para>
		/// <para>Checked—Indexes will be rebuilt on the states and state lineages tables.</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSystem { get; set; } = "false";

		/// <summary>
		/// <para>Datasets to Rebuild Indexes For</para>
		/// <para>Names of the datasets that will have their indexes rebuilt. Only datasets that are owned by the connected user are displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InDatasets { get; set; }

		/// <summary>
		/// <para>Rebuild Delta Tables Only</para>
		/// <para>Indicates whether indexes will be rebuilt only on the delta tables of the selected datasets. This option will be unavailable if there are no datasets selected in the list of input datasets.</para>
		/// <para>This option only applies to geodatabases. If you connect to a database, this option is disabled.</para>
		/// <para>Checked—Indexes will only be rebuilt for the delta tables of the selected datasets. This option can be used for cases where the business tables for the selected datasets are not updated often and there are a high volume of edits in the delta tables. This is the default.</para>
		/// <para>Unchecked—Indexes will be rebuilt on all indexes for the selected datasets. This includes spatial indexes as well as user-created attribute indexes and any geodatabase-maintained indexes for the dataset.</para>
		/// <para><see cref="DeltaOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeltaOnly { get; set; } = "true";

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RebuildIndexes SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include System Tables</para>
		/// </summary>
		public enum IncludeSystemEnum 
		{
			/// <summary>
			/// <para>Checked—Indexes will be rebuilt on the states and state lineages tables.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SYSTEM")]
			SYSTEM,

			/// <summary>
			/// <para>Unchecked—Indexes will not be rebuilt on the states and state lineages table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SYSTEM")]
			NO_SYSTEM,

		}

		/// <summary>
		/// <para>Rebuild Delta Tables Only</para>
		/// </summary>
		public enum DeltaOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Indexes will only be rebuilt for the delta tables of the selected datasets. This option can be used for cases where the business tables for the selected datasets are not updated often and there are a high volume of edits in the delta tables. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_DELTAS")]
			ONLY_DELTAS,

			/// <summary>
			/// <para>Unchecked—Indexes will be rebuilt on all indexes for the selected datasets. This includes spatial indexes as well as user-created attribute indexes and any geodatabase-maintained indexes for the dataset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

#endregion
	}
}
