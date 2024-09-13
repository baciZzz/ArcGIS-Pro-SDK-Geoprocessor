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
	/// <para>分析数据集</para>
	/// <para>更新基表、增量表和存档表的数据库统计数据，以及这些表的索引的统计数据。 此工具用于企业级地理数据库，以便 RDBMS 查询优化程序获得最佳性能。 过时的统计数据可能会影响地理数据库的性能。</para>
	/// </summary>
	public class AnalyzeDatasets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>包含待分析数据的数据库。</para>
		/// </param>
		/// <param name="IncludeSystem">
		/// <para>Include System Tables</para>
		/// <para>指定是否收集状态和状态谱系表中的统计数据。</para>
		/// <para>未选中 - 不收集状态和状态谱系表中的统计数据。 这是默认设置。</para>
		/// <para>选中 - 收集状态和状态谱系表中的统计数据。要激活此选项，您必须具有地理数据库管理员身份。</para>
		/// <para>此选项仅适用于地理数据库。 如果输入工作空间为数据库，则此选项将处于非活动状态。</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </param>
		public AnalyzeDatasets(object InputDatabase, object IncludeSystem)
		{
			this.InputDatabase = InputDatabase;
			this.IncludeSystem = IncludeSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 分析数据集</para>
		/// </summary>
		public override string DisplayName() => "分析数据集";

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
		/// <para>包含待分析数据的数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Include System Tables</para>
		/// <para>指定是否收集状态和状态谱系表中的统计数据。</para>
		/// <para>未选中 - 不收集状态和状态谱系表中的统计数据。 这是默认设置。</para>
		/// <para>选中 - 收集状态和状态谱系表中的统计数据。要激活此选项，您必须具有地理数据库管理员身份。</para>
		/// <para>此选项仅适用于地理数据库。 如果输入工作空间为数据库，则此选项将处于非活动状态。</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSystem { get; set; } = "false";

		/// <summary>
		/// <para>Datasets to Analyze</para>
		/// <para>待分析数据集的名称。 仅显示已连接用户所有的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Analyze Base Tables for Selected Dataset(s)</para>
		/// <para>指定是否分析所选数据集的基表。</para>
		/// <para>此选项仅适用于地理数据库。 如果输入工作空间为数据库，则此选项将处于非活动状态。</para>
		/// <para>选中 - 收集所选数据集基表的统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不收集所选数据集基表的统计数据。</para>
		/// <para><see cref="AnalyzeBaseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AnalyzeBase { get; set; } = "true";

		/// <summary>
		/// <para>Analyze Delta Tables for Selected Dataset(s)</para>
		/// <para>指定是否分析所选数据集的增量表。</para>
		/// <para>此选项仅适用于包含传统版本的地理数据库。 如果输入工作空间为数据库，则此选项将处于非活动状态。</para>
		/// <para>选中 - 收集所选数据集增量表的统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不收集所选数据集增量表的统计数据。</para>
		/// <para><see cref="AnalyzeDeltaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AnalyzeDelta { get; set; } = "true";

		/// <summary>
		/// <para>Analyze Archive Tables for Selected Dataset(s)</para>
		/// <para>指定是否分析所选数据集的存档表。</para>
		/// <para>此选项仅适用于包含启用了存档的数据集的地理数据库。 如果输入工作空间为数据库，则此选项将处于非活动状态。</para>
		/// <para>选中 - 收集所选数据集存档表的统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不收集所选数据集存档表的统计数据。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SYSTEM")]
			SYSTEM,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANALYZE_BASE")]
			ANALYZE_BASE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANALYZE_DELTA")]
			ANALYZE_DELTA,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANALYZE_ARCHIVE")]
			ANALYZE_ARCHIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANALYZE_ARCHIVE")]
			NO_ANALYZE_ARCHIVE,

		}

#endregion
	}
}
