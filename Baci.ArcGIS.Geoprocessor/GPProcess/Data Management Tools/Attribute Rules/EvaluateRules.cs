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
	/// <para>Evaluate Rules</para>
	/// <para>评估规则</para>
	/// <para>评估地理数据库规则和功能。</para>
	/// </summary>
	public class EvaluateRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>文件地理数据库或要素服务 URL。 下面是要素服务 URL 的示例：https://myserver/server/rest/services/myservicename/FeatureServer。</para>
		/// </param>
		/// <param name="EvaluationTypes">
		/// <para>Evaluation Types</para>
		/// <para>指定要使用的评估类型。</para>
		/// <para>计算规则—将评估批处理计算属性规则。</para>
		/// <para>验证规则—将评估验证属性规则。</para>
		/// <para><see cref="EvaluationTypesEnum"/></para>
		/// </param>
		public EvaluateRules(object InWorkspace, object EvaluationTypes)
		{
			this.InWorkspace = InWorkspace;
			this.EvaluationTypes = EvaluationTypes;
		}

		/// <summary>
		/// <para>Tool Display Name : 评估规则</para>
		/// </summary>
		public override string DisplayName() => "评估规则";

		/// <summary>
		/// <para>Tool Name : EvaluateRules</para>
		/// </summary>
		public override string ToolName() => "EvaluateRules";

		/// <summary>
		/// <para>Tool Excute Name : management.EvaluateRules</para>
		/// </summary>
		public override string ExcuteName() => "management.EvaluateRules";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, EvaluationTypes, Extent, RunAsync, UpdatedWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>文件地理数据库或要素服务 URL。 下面是要素服务 URL 的示例：https://myserver/server/rest/services/myservicename/FeatureServer。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Local Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Evaluation Types</para>
		/// <para>指定要使用的评估类型。</para>
		/// <para>计算规则—将评估批处理计算属性规则。</para>
		/// <para>验证规则—将评估验证属性规则。</para>
		/// <para><see cref="EvaluationTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object EvaluationTypes { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>要评估的范围。 如果在地图中进行了选择，则将仅评估指定范围内的选定要素。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Async</para>
		/// <para>指定同步还是异步运行评估。 仅当输入工作空间为要素服务时，才支持此参数。</para>
		/// <para>选中 - 将异步运行评估。 服务器资源可通过该选项来运行超时时间较长的评估。 当评估包含许多需要计算或验证的要素的大型数据集时，建议使用异步运行。 这是默认设置。</para>
		/// <para>未选中 - 将同步运行评估。 此选项超时时间较短，特别适用于评估需要计算或验证的要素数量较少的范围。</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RunAsync { get; set; } = "true";

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedWorkspace { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Evaluation Types</para>
		/// </summary>
		public enum EvaluationTypesEnum 
		{
			/// <summary>
			/// <para>计算规则—将评估批处理计算属性规则。</para>
			/// </summary>
			[GPValue("CALCULATION_RULES")]
			[Description("计算规则")]
			Calculation_rules,

			/// <summary>
			/// <para>验证规则—将评估验证属性规则。</para>
			/// </summary>
			[GPValue("VALIDATION_RULES")]
			[Description("验证规则")]
			Validation_rules,

		}

		/// <summary>
		/// <para>Async</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ASYNC")]
			ASYNC,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SYNC")]
			SYNC,

		}

#endregion
	}
}
