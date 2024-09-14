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
	/// <para>启用 Data Reviewer</para>
	/// <para>为现有地理数据库成为 Reviewer 工作空间并存储 Data Reviewer 结果添加所需的要素数据集和表。ArcGIS Data Reviewer 需要 Reviewer 工作空间表来管理 Reviewer 会话。</para>
	/// </summary>
	public class EnableDataReviewer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Workspace">
		/// <para>Workspace</para>
		/// <para>要在其中创建 Data Reviewer 表和要素数据集的地理数据库。这可以是桌面地理数据库或企业级地理数据库。</para>
		/// </param>
		public EnableDataReviewer(object Workspace)
		{
			this.Workspace = Workspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用 Data Reviewer</para>
		/// </summary>
		public override string DisplayName() => "启用 Data Reviewer";

		/// <summary>
		/// <para>Tool Name : EnableDataReviewer</para>
		/// </summary>
		public override string ToolName() => "EnableDataReviewer";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.EnableDataReviewer</para>
		/// </summary>
		public override string ExcuteName() => "Reviewer.EnableDataReviewer";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Workspace, SpatialReference!, RegisterAsVersioned!, ConfigKeyword!, OutReviewerWorkspace! };

		/// <summary>
		/// <para>Workspace</para>
		/// <para>要在其中创建 Data Reviewer 表和要素数据集的地理数据库。这可以是桌面地理数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object Workspace { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>Reviewer 工作空间中要素类的地理坐标系或投影坐标系。如果未指定值，则默认为 GCS_WGS_1984。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Register as Versioned</para>
		/// <para>表示添加到工作空间的要素类和表是否要注册为版本。仅适用于企业级地理数据库。</para>
		/// <para>未选中 - 要素类和表在添加至地理数据库后将不会注册为版本。这是默认设置。</para>
		/// <para>选中 - 要素类和表在添加至地理数据库后将注册为版本。</para>
		/// <para><see cref="RegisterAsVersionedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RegisterAsVersioned { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>用于确定数据库表的存储参数的配置关键字。适用于文件地理数据库和企业级地理数据库。默认情况下，使用关键字 DEFAULTS。</para>
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
		public EnableDataReviewer SetEnviroment(object? configKeyword = null, object? workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONVERSIONED")]
			NONVERSIONED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VERSIONED")]
			VERSIONED,

		}

#endregion
	}
}
