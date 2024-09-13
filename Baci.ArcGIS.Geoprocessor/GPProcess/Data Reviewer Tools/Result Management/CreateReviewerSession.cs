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
	/// <para>Create Reviewer Session</para>
	/// <para>创建 Reviewer 会话</para>
	/// <para>在指定的工作空间中创建新 Reviewer 会话。</para>
	/// </summary>
	public class CreateReviewerSession : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>将创建新 Reviewer 会话的工作空间。</para>
		/// </param>
		/// <param name="SessionName">
		/// <para>Session Name</para>
		/// <para>将在 Reviewer 工作空间中创建的会话名称。</para>
		/// </param>
		public CreateReviewerSession(object ReviewerWorkspace, object SessionName)
		{
			this.ReviewerWorkspace = ReviewerWorkspace;
			this.SessionName = SessionName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 Reviewer 会话</para>
		/// </summary>
		public override string DisplayName() => "创建 Reviewer 会话";

		/// <summary>
		/// <para>Tool Name : CreateReviewerSession</para>
		/// </summary>
		public override string ToolName() => "CreateReviewerSession";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.CreateReviewerSession</para>
		/// </summary>
		public override string ExcuteName() => "Reviewer.CreateReviewerSession";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ReviewerWorkspace, SessionName, SessionTemplate, Session, DuplicateChecking, StoreGeometry, Username, Version };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>将创建新 Reviewer 会话的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object ReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session Name</para>
		/// <para>将在 Reviewer 工作空间中创建的会话名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SessionName { get; set; }

		/// <summary>
		/// <para>Session Template</para>
		/// <para>属性将复制到新会话中的现有 Reviewer 会话。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SessionTemplate { get; set; }

		/// <summary>
		/// <para>Reviewer Session</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Session { get; set; }

		/// <summary>
		/// <para>Check For Duplicates</para>
		/// <para>指定在会话中对重复验证结果的处理方法。</para>
		/// <para>无—不搜索重复验证结果。这将改善将验证结果写入数据库时的性能。这是默认设置。</para>
		/// <para>会话—在会话内搜索重复验证结果。</para>
		/// <para>数据库—在整个数据库内搜索重复验证结果。</para>
		/// <para><see cref="DuplicateCheckingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DuplicateChecking { get; set; } = "NONE";

		/// <summary>
		/// <para>Do Not Store Geometry</para>
		/// <para>指定结果是否包含关联几何。</para>
		/// <para>已选中 - 结果将仅会包括属性信息。这将改善将验证结果写入地理数据库时的性能。</para>
		/// <para>未选中 - 结果将同时包括几何与属性信息。这是默认设置。</para>
		/// <para><see cref="StoreGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object StoreGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Session User Name</para>
		/// <para>创建 Reviewer 会话的人员的用户名。默认为当前登录的 Windows 用户。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Username { get; set; } = "bldgis";

		/// <summary>
		/// <para>Session Version</para>
		/// <para>将要与会话相关联的企业级地理数据库版本。只有在选择的 Reviewer 工作空间存储于企业级地理数据库时，才会启用该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateReviewerSession SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Check For Duplicates</para>
		/// </summary>
		public enum DuplicateCheckingEnum 
		{
			/// <summary>
			/// <para>数据库—在整个数据库内搜索重复验证结果。</para>
			/// </summary>
			[GPValue("DATABASE")]
			[Description("数据库")]
			Database,

			/// <summary>
			/// <para>会话—在会话内搜索重复验证结果。</para>
			/// </summary>
			[GPValue("SESSION")]
			[Description("会话")]
			Session,

			/// <summary>
			/// <para>无—不搜索重复验证结果。这将改善将验证结果写入数据库时的性能。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Do Not Store Geometry</para>
		/// </summary>
		public enum StoreGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("STORE_GEOMETRY")]
			STORE_GEOMETRY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DO_NOT_STORE_GEOMETRY")]
			DO_NOT_STORE_GEOMETRY,

		}

#endregion
	}
}
