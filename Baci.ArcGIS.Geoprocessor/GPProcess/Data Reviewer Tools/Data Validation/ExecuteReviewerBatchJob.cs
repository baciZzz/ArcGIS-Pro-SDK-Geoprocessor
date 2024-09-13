using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataReviewerTools
{
	/// <summary>
	/// <para>Execute Reviewer Batch Job</para>
	/// <para>执行 Reviewer 批处理作业</para>
	/// <para>运行工作空间中的 Reviewer 批处理作业并将结果写入 Reviewer 会话中。Reviewer 批处理作业包含多组 Reviewer 校验。检查根据条件、规则和空间关系验证数据。检查还指定要验证的多组要素或行及其源工作空间。Reviewer 会话存储 Reviewer 校验执行的验证任务的相关信息。此信息存储在 Reviewer 工作空间的表和数据集中。</para>
	/// </summary>
	public class ExecuteReviewerBatchJob : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>Reviewer 批处理作业结果将写入的工作空间。</para>
		/// </param>
		/// <param name="Session">
		/// <para>Session</para>
		/// <para>Reviewer 会话的标识符和名称。会话必须存在于 Reviewer 工作空间中。</para>
		/// </param>
		/// <param name="BatchJobFile">
		/// <para>Batch Job File</para>
		/// <para>将要执行的 Reviewer 批处理作业文件的路径。</para>
		/// </param>
		public ExecuteReviewerBatchJob(object ReviewerWorkspace, object Session, object BatchJobFile)
		{
			this.ReviewerWorkspace = ReviewerWorkspace;
			this.Session = Session;
			this.BatchJobFile = BatchJobFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 执行 Reviewer 批处理作业</para>
		/// </summary>
		public override string DisplayName() => "执行 Reviewer 批处理作业";

		/// <summary>
		/// <para>Tool Name : ExecuteReviewerBatchJob</para>
		/// </summary>
		public override string ToolName() => "ExecuteReviewerBatchJob";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.ExecuteReviewerBatchJob</para>
		/// </summary>
		public override string ExcuteName() => "Reviewer.ExecuteReviewerBatchJob";

		/// <summary>
		/// <para>Toolbox Display Name : Data Reviewer Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Reviewer Tools";

		/// <summary>
		/// <para>Toolbox Alise : Reviewer</para>
		/// </summary>
		public override string ToolboxAlise() => "Reviewer";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ReviewerWorkspace, Session, BatchJobFile, ProductionWorkspace, AnalysisArea, ChangedFeatures, Tableview, ProductionWorkspaceversion };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>Reviewer 批处理作业结果将写入的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object ReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session</para>
		/// <para>Reviewer 会话的标识符和名称。会话必须存在于 Reviewer 工作空间中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Session { get; set; }

		/// <summary>
		/// <para>Batch Job File</para>
		/// <para>将要执行的 Reviewer 批处理作业文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rbj")]
		public object BatchJobFile { get; set; }

		/// <summary>
		/// <para>Production Workspace</para>
		/// <para>包含要验证的要素的企业级或文件地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object ProductionWorkspace { get; set; }

		/// <summary>
		/// <para>Analysis Area</para>
		/// <para>定义区域的面要素或范围值，该区域将用于构建验证处理区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object AnalysisArea { get; set; }

		/// <summary>
		/// <para>Changed Features Only</para>
		/// <para>指定在生产工作空间引用企业级地理数据库中的数据时要进行验证的要素类型（无论是否更改）。</para>
		/// <para>选中 - 将仅验证从父版本更改为子版本的要素。</para>
		/// <para>未选中 - 将验证批处理作业引用的数据中的所有要素。这是默认设置。</para>
		/// <para><see cref="ChangedFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ChangedFeatures { get; set; }

		/// <summary>
		/// <para>BATCHRUNTABLE_View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object Tableview { get; set; }

		/// <summary>
		/// <para>Production Workspace Version</para>
		/// <para>将由批处理作业验证的生产工作空间的版本。仅当生产工作空间为企业级地理数据库时适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ProductionWorkspaceversion { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExecuteReviewerBatchJob SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Changed Features Only</para>
		/// </summary>
		public enum ChangedFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CHANGED_FEATURES")]
			CHANGED_FEATURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL_FEATURES")]
			ALL_FEATURES,

		}

#endregion
	}
}
