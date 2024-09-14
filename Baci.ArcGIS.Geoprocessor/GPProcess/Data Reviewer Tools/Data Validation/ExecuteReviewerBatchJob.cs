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
	/// <para>Execute Reviewer Batch Job</para>
	/// <para>Runs a Reviewer batch job on a workspace and writes the results to a Reviewer session. A Reviewer batch job contains groups of Reviewer checks. Checks validate data based on conditions, rules, and spatial relationships. Checks also specify sets of features or rows to validate and their source workspace. A Reviewer session stores information about validation tasks performed by Reviewer checks. This information is stored in a table and a dataset in the Reviewer workspace.</para>
	/// </summary>
	public class ExecuteReviewerBatchJob : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>The workspace where the Reviewer batch job results will be written.</para>
		/// </param>
		/// <param name="Session">
		/// <para>Session</para>
		/// <para>The identifier and name for a Reviewer session. The session must exist in the Reviewer workspace.</para>
		/// </param>
		/// <param name="BatchJobFile">
		/// <para>Batch Job File</para>
		/// <para>The path to the Reviewer batch job file to be executed.</para>
		/// </param>
		public ExecuteReviewerBatchJob(object ReviewerWorkspace, object Session, object BatchJobFile)
		{
			this.ReviewerWorkspace = ReviewerWorkspace;
			this.Session = Session;
			this.BatchJobFile = BatchJobFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Execute Reviewer Batch Job</para>
		/// </summary>
		public override string DisplayName() => "Execute Reviewer Batch Job";

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
		public override object[] Parameters() => new object[] { ReviewerWorkspace, Session, BatchJobFile, ProductionWorkspace!, AnalysisArea!, ChangedFeatures!, Tableview!, ProductionWorkspaceversion! };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>The workspace where the Reviewer batch job results will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object ReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session</para>
		/// <para>The identifier and name for a Reviewer session. The session must exist in the Reviewer workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Session { get; set; }

		/// <summary>
		/// <para>Batch Job File</para>
		/// <para>The path to the Reviewer batch job file to be executed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rbj")]
		public object BatchJobFile { get; set; }

		/// <summary>
		/// <para>Production Workspace</para>
		/// <para>The enterprise or file geodatabase that contains the features to be validated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object? ProductionWorkspace { get; set; }

		/// <summary>
		/// <para>Analysis Area</para>
		/// <para>Polygon features or extent values that define the area that will be used to build a validation processing area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? AnalysisArea { get; set; }

		/// <summary>
		/// <para>Changed Features Only</para>
		/// <para>Specifies the type of features, changed or unchanged, that will be validated when the production workspace references data in an enterprise geodatabase.</para>
		/// <para>Checked—Only features that changed from the parent to the child version will be validated.</para>
		/// <para>Unchecked—All features in the data referenced by the batch job will be validated. This is the default.</para>
		/// <para><see cref="ChangedFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ChangedFeatures { get; set; }

		/// <summary>
		/// <para>BATCHRUNTABLE_View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? Tableview { get; set; }

		/// <summary>
		/// <para>Production Workspace Version</para>
		/// <para>The version of the production workspace to be validated by the batch job. This is only applicable when the production workspace is an enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ProductionWorkspaceversion { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExecuteReviewerBatchJob SetEnviroment(object? extent = null, object? workspace = null)
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
			/// <para>Checked—Only features that changed from the parent to the child version will be validated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CHANGED_FEATURES")]
			CHANGED_FEATURES,

			/// <summary>
			/// <para>Unchecked—All features in the data referenced by the batch job will be validated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL_FEATURES")]
			ALL_FEATURES,

		}

#endregion
	}
}
