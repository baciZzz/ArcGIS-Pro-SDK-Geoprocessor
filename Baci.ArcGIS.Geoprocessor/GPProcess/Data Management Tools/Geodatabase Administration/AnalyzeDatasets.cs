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
	/// <para>Analyze Datasets</para>
	/// <para>Updates database statistics of base tables, delta tables, and archive tables, along with the statistics on the indexes of those tables. This tool is used in enterprise geodatabases to help get optimal performance from the RDBMS query optimizer. Stale statistics can affect geodatabase performance.</para>
	/// </summary>
	public class AnalyzeDatasets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The database that contains the data to be analyzed.</para>
		/// </param>
		/// <param name="IncludeSystem">
		/// <para>Include System Tables</para>
		/// <para>Specifies whether statistics will be gathered on the states and state lineages tables.</para>
		/// <para>Unchecked—Statistics will not be gathered on the states and state lineages tables. This is the default.</para>
		/// <para>Checked—Statistics will be gathered on the states and state lineages tables.You must be the geodatabase administrator for this option to be active.</para>
		/// <para>This option only applies to geodatabases. If the input workspace is a database, this option will be inactive.</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </param>
		public AnalyzeDatasets(object InputDatabase, object IncludeSystem)
		{
			this.InputDatabase = InputDatabase;
			this.IncludeSystem = IncludeSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Datasets</para>
		/// </summary>
		public override string DisplayName() => "Analyze Datasets";

		/// <summary>
		/// <para>Tool Name : AnalyzeDatasets</para>
		/// </summary>
		public override string ToolName() => "AnalyzeDatasets";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeDatasets</para>
		/// </summary>
		public override string ExcuteName() => "management.AnalyzeDatasets";

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
		public override object[] Parameters() => new object[] { InputDatabase, IncludeSystem, InDatasets, AnalyzeBase, AnalyzeDelta, AnalyzeArchive, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The database that contains the data to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Include System Tables</para>
		/// <para>Specifies whether statistics will be gathered on the states and state lineages tables.</para>
		/// <para>Unchecked—Statistics will not be gathered on the states and state lineages tables. This is the default.</para>
		/// <para>Checked—Statistics will be gathered on the states and state lineages tables.You must be the geodatabase administrator for this option to be active.</para>
		/// <para>This option only applies to geodatabases. If the input workspace is a database, this option will be inactive.</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSystem { get; set; } = "false";

		/// <summary>
		/// <para>Datasets to Analyze</para>
		/// <para>The names of the datasets that will be analyzed. Only datasets that are owned by the connected user will be displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Analyze Base Tables for Selected Dataset(s)</para>
		/// <para>Specifies whether the selected dataset base tables will be analyzed.</para>
		/// <para>This option only applies to geodatabases. If the input workspace is a database, this option will be inactive.</para>
		/// <para>Checked—Statistics will be gathered for the base tables for the selected datasets. This is the default.</para>
		/// <para>Unchecked—Statistics will not be gathered for the base tables for the selected datasets.</para>
		/// <para><see cref="AnalyzeBaseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AnalyzeBase { get; set; } = "true";

		/// <summary>
		/// <para>Analyze Delta Tables for Selected Dataset(s)</para>
		/// <para>Specifies whether the selected dataset delta tables will be analyzed.</para>
		/// <para>This option only applies to geodatabases that contain traditional versions. If the input workspace is a database, this option will be inactive.</para>
		/// <para>Checked—Statistics will be gathered for the delta tables for the selected datasets. This is the default.</para>
		/// <para>Unchecked—Statistics will not be gathered for the delta tables for the selected datasets.</para>
		/// <para><see cref="AnalyzeDeltaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AnalyzeDelta { get; set; } = "true";

		/// <summary>
		/// <para>Analyze Archive Tables for Selected Dataset(s)</para>
		/// <para>Specifies whether the selected dataset archive tables will be analyzed.</para>
		/// <para>This option only applies to geodatabases that contain archive-enabled datasets. If the input workspace is a database, this option will be inactive.</para>
		/// <para>Checked—Statistics will be gathered for the archive tables for the selected datasets. This is the default.</para>
		/// <para>Unchecked—Statistics will not be gathered for the archive tables for the selected datasets.</para>
		/// <para><see cref="AnalyzeArchiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AnalyzeArchive { get; set; } = "true";

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeDatasets SetEnviroment(object workspace = null )
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
			/// <para>Checked—Statistics will be gathered on the states and state lineages tables.You must be the geodatabase administrator for this option to be active.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SYSTEM")]
			SYSTEM,

			/// <summary>
			/// <para>Unchecked—Statistics will not be gathered on the states and state lineages tables. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SYSTEM")]
			NO_SYSTEM,

		}

		/// <summary>
		/// <para>Analyze Base Tables for Selected Dataset(s)</para>
		/// </summary>
		public enum AnalyzeBaseEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be gathered for the base tables for the selected datasets. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANALYZE_BASE")]
			ANALYZE_BASE,

			/// <summary>
			/// <para>Unchecked—Statistics will not be gathered for the base tables for the selected datasets.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANALYZE_BASE")]
			NO_ANALYZE_BASE,

		}

		/// <summary>
		/// <para>Analyze Delta Tables for Selected Dataset(s)</para>
		/// </summary>
		public enum AnalyzeDeltaEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be gathered for the delta tables for the selected datasets. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANALYZE_DELTA")]
			ANALYZE_DELTA,

			/// <summary>
			/// <para>Unchecked—Statistics will not be gathered for the delta tables for the selected datasets.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANALYZE_DELTA")]
			NO_ANALYZE_DELTA,

		}

		/// <summary>
		/// <para>Analyze Archive Tables for Selected Dataset(s)</para>
		/// </summary>
		public enum AnalyzeArchiveEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be gathered for the archive tables for the selected datasets. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANALYZE_ARCHIVE")]
			ANALYZE_ARCHIVE,

			/// <summary>
			/// <para>Unchecked—Statistics will not be gathered for the archive tables for the selected datasets.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANALYZE_ARCHIVE")]
			NO_ANALYZE_ARCHIVE,

		}

#endregion
	}
}
