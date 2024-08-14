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
	/// <para>Enable Data Reviewer</para>
	/// <para>Adds a feature dataset and tables necessary for an existing geodatabase to be considered a Reviewer workspace and store Data Reviewer results. The Reviewer workspace tables are required by ArcGIS Data Reviewer to manage Reviewer sessions.</para>
	/// </summary>
	public class EnableDataReviewer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Workspace">
		/// <para>Workspace</para>
		/// <para>The geodatabase where the Data Reviewer tables and feature dataset will be created. This can be a desktop or enterprise geodatabase.</para>
		/// </param>
		public EnableDataReviewer(object Workspace)
		{
			this.Workspace = Workspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Data Reviewer</para>
		/// </summary>
		public override string DisplayName => "Enable Data Reviewer";

		/// <summary>
		/// <para>Tool Name : EnableDataReviewer</para>
		/// </summary>
		public override string ToolName => "EnableDataReviewer";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.EnableDataReviewer</para>
		/// </summary>
		public override string ExcuteName => "Reviewer.EnableDataReviewer";

		/// <summary>
		/// <para>Toolbox Display Name : Data Reviewer Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Reviewer Tools";

		/// <summary>
		/// <para>Toolbox Alise : Reviewer</para>
		/// </summary>
		public override string ToolboxAlise => "Reviewer";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Workspace, SpatialReference!, RegisterAsVersioned!, ConfigKeyword!, OutReviewerWorkspace! };

		/// <summary>
		/// <para>Workspace</para>
		/// <para>The geodatabase where the Data Reviewer tables and feature dataset will be created. This can be a desktop or enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object Workspace { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The geographic or projected coordinate system of the feature classes in the Reviewer workspace. The default is GCS_WGS_1984 if no value is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Register as Versioned</para>
		/// <para>Indicates whether the feature classes and tables added to the workspace will be registered as versioned. This only applies to enterprise databases.</para>
		/// <para>Unchecked—The feature classes and tables will not be registered as versioned after they are added to the geodatabase. This is the default.</para>
		/// <para>Checked—The feature classes and tables will be registered as versioned after they are added to the geodatabase.</para>
		/// <para><see cref="RegisterAsVersionedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RegisterAsVersioned { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>The configuration keyword that determines the storage parameters of the database tables. This applies to file and enterprise geodatabases. The DEFAULTS keyword is used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Reviewer Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnableDataReviewer SetEnviroment(object? configKeyword = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Register as Versioned</para>
		/// </summary>
		public enum RegisterAsVersionedEnum 
		{
			/// <summary>
			/// <para>Unchecked—The feature classes and tables will not be registered as versioned after they are added to the geodatabase. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONVERSIONED")]
			NONVERSIONED,

			/// <summary>
			/// <para>Checked—The feature classes and tables will be registered as versioned after they are added to the geodatabase.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VERSIONED")]
			VERSIONED,

		}

#endregion
	}
}
