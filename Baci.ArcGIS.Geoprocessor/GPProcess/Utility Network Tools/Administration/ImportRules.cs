using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Import Rules</para>
	/// <para>导入规则</para>
	/// <para>用于将逗号分隔值文件中的连通性、结构附件和包含规则导入到现有公共设施网络。</para>
	/// </summary>
	public class ImportRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>指定要导入规则的公共设施网络。</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>指定要导入规则的类型。</para>
		/// <para>所有—一种或多种规则类型</para>
		/// <para>交汇点-交汇点连通性—交汇点-交汇点连通性关联规则</para>
		/// <para>交汇点-边连通性—交汇点-边连通性规则</para>
		/// <para>包含—包含关联规则</para>
		/// <para>结构附件—结构附件关联规则</para>
		/// <para>边-交汇点-边连通性— 边-交汇点-边关联规则</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		/// <param name="CsvFile">
		/// <para>Input  File</para>
		/// <para>指定包含待导入规则的 .csv 文件。</para>
		/// </param>
		public ImportRules(object InUtilityNetwork, object RuleType, object CsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
			this.CsvFile = CsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入规则</para>
		/// </summary>
		public override string DisplayName() => "导入规则";

		/// <summary>
		/// <para>Tool Name : ImportRules</para>
		/// </summary>
		public override string ToolName() => "ImportRules";

		/// <summary>
		/// <para>Tool Excute Name : un.ImportRules</para>
		/// </summary>
		public override string ExcuteName() => "un.ImportRules";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, CsvFile, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>指定要导入规则的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>指定要导入规则的类型。</para>
		/// <para>所有—一种或多种规则类型</para>
		/// <para>交汇点-交汇点连通性—交汇点-交汇点连通性关联规则</para>
		/// <para>交汇点-边连通性—交汇点-边连通性规则</para>
		/// <para>包含—包含关联规则</para>
		/// <para>结构附件—结构附件关联规则</para>
		/// <para>边-交汇点-边连通性— 边-交汇点-边关联规则</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>Input  File</para>
		/// <para>指定包含待导入规则的 .csv 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object CsvFile { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportRules SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>所有—一种或多种规则类型</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>交汇点-交汇点连通性—交汇点-交汇点连通性关联规则</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("交汇点-交汇点连通性")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通性—交汇点-边连通性规则</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("交汇点-边连通性")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>包含—包含关联规则</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("包含")]
			Containment,

			/// <summary>
			/// <para>结构附件—结构附件关联规则</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("结构附件")]
			Structural_attachment,

			/// <summary>
			/// <para>边-交汇点-边连通性— 边-交汇点-边关联规则</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("边-交汇点-边连通性")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
