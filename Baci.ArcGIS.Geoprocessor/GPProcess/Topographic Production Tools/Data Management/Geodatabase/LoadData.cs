using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Load Data</para>
	/// <para>Moves features from one schema to another by loading data from a source to a target workspace.   Data mapping rules described in a cross-reference database are applied during loading.</para>
	/// </summary>
	public class LoadData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCrossReference">
		/// <para>Input Cross-reference Database</para>
		/// <para>The path to a cross-reference database.</para>
		/// </param>
		/// <param name="InSources">
		/// <para>Input Sources</para>
		/// <para>A list of workspaces that contain the source features to load into the target workspace.</para>
		/// </param>
		/// <param name="InTarget">
		/// <para>Input Target Workspace</para>
		/// <para>The target workspace that contains the schema referenced in the cross-reference database. Source features are loaded into this workspace.</para>
		/// </param>
		public LoadData(object InCrossReference, object InSources, object InTarget)
		{
			this.InCrossReference = InCrossReference;
			this.InSources = InSources;
			this.InTarget = InTarget;
		}

		/// <summary>
		/// <para>Tool Display Name : Load Data</para>
		/// </summary>
		public override string DisplayName => "Load Data";

		/// <summary>
		/// <para>Tool Name : LoadData</para>
		/// </summary>
		public override string ToolName => "LoadData";

		/// <summary>
		/// <para>Tool Excute Name : topographic.LoadData</para>
		/// </summary>
		public override string ExcuteName => "topographic.LoadData";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InCrossReference, InSources, InTarget, InDatasetMapDefs, RowLevelErrors, OutTarget };

		/// <summary>
		/// <para>Input Cross-reference Database</para>
		/// <para>The path to a cross-reference database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object InCrossReference { get; set; }

		/// <summary>
		/// <para>Input Sources</para>
		/// <para>A list of workspaces that contain the source features to load into the target workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InSources { get; set; }

		/// <summary>
		/// <para>Input Target Workspace</para>
		/// <para>The target workspace that contains the schema referenced in the cross-reference database. Source features are loaded into this workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InTarget { get; set; }

		/// <summary>
		/// <para>Dataset Mapping Definitions</para>
		/// <para>The source to target feature class mapping list. The format of this string is id | SourceDataset | TargetDataset | WhereClause | Subtype.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Advanced")]
		public object InDatasetMapDefs { get; set; }

		/// <summary>
		/// <para>Log row level errors</para>
		/// <para>Specifies whether the tool will log errors that occur while inserting new rows into feature classes and tables in the Input Target Workspace parameter.</para>
		/// <para>Checked—Errors that occur during individual row-level inserts will be logged. This is the default.</para>
		/// <para>Unchecked—Errors that occur during individual row-level inserts will not be logged.</para>
		/// <para><see cref="RowLevelErrorsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RowLevelErrors { get; set; } = "true";

		/// <summary>
		/// <para>Output Target Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutTarget { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LoadData SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Log row level errors</para>
		/// </summary>
		public enum RowLevelErrorsEnum 
		{
			/// <summary>
			/// <para>Checked—Errors that occur during individual row-level inserts will be logged. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_LEVEL_ERROR_LOGGING")]
			ROW_LEVEL_ERROR_LOGGING,

			/// <summary>
			/// <para>Unchecked—Errors that occur during individual row-level inserts will not be logged.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ROW_LEVEL_ERROR_LOGGING")]
			NO_ROW_LEVEL_ERROR_LOGGING,

		}

#endregion
	}
}
