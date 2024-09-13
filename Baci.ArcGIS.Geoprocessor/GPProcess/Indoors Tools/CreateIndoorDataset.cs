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
	/// <para>Create Indoor Dataset</para>
	/// <para>创建 Indoor 数据集</para>
	/// <para>创建包含必要的要素类的室内数据集，这些要素类可使用符合 ArcGIS Indoors 信息模型的简化方案维护地面规划数据。</para>
	/// </summary>
	public class CreateIndoorDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>包含输出 Indoor 数据集的目标文件地理数据库或企业级地理数据库。</para>
		/// </param>
		/// <param name="IndoorDatasetName">
		/// <para>Indoor Dataset Name</para>
		/// <para>输出 Indoor 数据集的唯一名称。 默认为 Indoor。</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Coordinate System</para>
		/// <para>输出室内数据集的水平和垂直坐标系。</para>
		/// </param>
		public CreateIndoorDataset(object TargetGdb, object IndoorDatasetName, object SpatialReference)
		{
			this.TargetGdb = TargetGdb;
			this.IndoorDatasetName = IndoorDatasetName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 Indoor 数据集</para>
		/// </summary>
		public override string DisplayName() => "创建 Indoor 数据集";

		/// <summary>
		/// <para>Tool Name : CreateIndoorDataset</para>
		/// </summary>
		public override string ToolName() => "CreateIndoorDataset";

		/// <summary>
		/// <para>Tool Excute Name : indoors.CreateIndoorDataset</para>
		/// </summary>
		public override string ExcuteName() => "indoors.CreateIndoorDataset";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetGdb, IndoorDatasetName, SpatialReference, OutputDataset!, CreateAttributeRules! };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>包含输出 Indoor 数据集的目标文件地理数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Indoor Dataset Name</para>
		/// <para>输出 Indoor 数据集的唯一名称。 默认为 Indoor。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object IndoorDatasetName { get; set; } = "Indoor";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出室内数据集的水平和垂直坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutputDataset { get; set; }

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
		public CreateIndoorDataset SetEnviroment(object? configKeyword = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

		#region InnerClass

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
