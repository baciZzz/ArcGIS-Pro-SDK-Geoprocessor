using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Create Indoors Database</para>
	/// <para>创建 Indoors 数据库</para>
	/// <para>创建符合 ArcGIS Indoors 信息模型的 Indoors 地理数据库，并包含维护用于地面规划制图、路由、空间规划和工作空间预留的室内数据所需的要素类、字段和表。</para>
	/// </summary>
	public class CreateIndoorsDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>包含 ArcGIS Indoors 信息模型的地理数据库，用于管理室内 GIS 信息以在 Indoors 应用程序中使用。</para>
		/// </param>
		public CreateIndoorsDatabase(object TargetGdb)
		{
			this.TargetGdb = TargetGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 Indoors 数据库</para>
		/// </summary>
		public override string DisplayName() => "创建 Indoors 数据库";

		/// <summary>
		/// <para>Tool Name : CreateIndoorsDatabase</para>
		/// </summary>
		public override string ToolName() => "CreateIndoorsDatabase";

		/// <summary>
		/// <para>Tool Excute Name : indoors.CreateIndoorsDatabase</para>
		/// </summary>
		public override string ExcuteName() => "indoors.CreateIndoorsDatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetGdb, UpdatedGdb!, CreateNetwork!, SpatialReference!, CreateAttributeRules! };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>包含 ArcGIS Indoors 信息模型的地理数据库，用于管理室内 GIS 信息以在 Indoors 应用程序中使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? UpdatedGdb { get; set; }

		/// <summary>
		/// <para>Create Indoors Network</para>
		/// <para>指定是否在 Indoors 数据库中创建包含室内交通网络要素类（地标、路径和楼层过渡）的网络数据集。</para>
		/// <para>选中 - 将创建网络数据集和要素类。 这是默认设置。</para>
		/// <para>未选中 - 不会创建网络数据集和要素类。</para>
		/// <para><see cref="CreateNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateNetwork { get; set; } = "true";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出 Indoors 数据库的空间参考。 如果未设置空间参考，则输出 Indoors 数据库将使用 WGS84 Web 墨卡托（辅助球体）作为水平坐标系，WGS84 作为垂直坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Create Attribute Rules</para>
		/// <para>指定是否将在 Indoors 数据库中创建属性规则以及相关字段和错误数据集。 这些属性规则包括用于楼层平面图数据质量控制工作流的验证校验。 目标地理数据库必须是已配置为分支版本化的文件地理数据库或企业级地理数据库。</para>
		/// <para>选中 - 将创建属性规则。 这是默认设置。</para>
		/// <para>未选中 - 不会创建属性规则。</para>
		/// <para><see cref="CreateAttributeRulesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateAttributeRules { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateIndoorsDatabase SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Indoors Network</para>
		/// </summary>
		public enum CreateNetworkEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_NETWORK")]
			CREATE_NETWORK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_NETWORK")]
			NO_CREATE_NETWORK,

		}

		/// <summary>
		/// <para>Create Attribute Rules</para>
		/// </summary>
		public enum CreateAttributeRulesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_RULES")]
			CREATE_RULES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_RULES")]
			NO_CREATE_RULES,

		}

#endregion
	}
}
