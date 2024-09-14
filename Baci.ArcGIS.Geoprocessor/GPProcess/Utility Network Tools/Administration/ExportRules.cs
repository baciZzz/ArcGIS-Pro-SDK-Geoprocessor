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
	/// <para>Export Rules</para>
	/// <para>导出规则</para>
	/// <para>用于将公共设施网络中的连通性、结构附件和包含规则导出为逗号分隔值文件。</para>
	/// </summary>
	public class ExportRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>要从中导出规则的公共设施网络。</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>要导出的规则类型。</para>
		/// <para>所有—将导出公共设施网络中的所有规则。</para>
		/// <para>交汇点-交汇点连通性—将导出交汇点-交汇点连通性关联规则。</para>
		/// <para>交汇点-边连通性—将导出交汇点-边连通性关联规则。</para>
		/// <para>包含—将导出包含关联规则。</para>
		/// <para>结构附件—将导出结构附件关联规则。</para>
		/// <para>边-交汇点-边连通性—将导出边-交汇点-边连通性关联规则。</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output File</para>
		/// <para>待创建的 .csv 文件的文件夹位置和名称。</para>
		/// </param>
		public ExportRules(object InUtilityNetwork, object RuleType, object OutCsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出规则</para>
		/// </summary>
		public override string DisplayName() => "导出规则";

		/// <summary>
		/// <para>Tool Name : ExportRules</para>
		/// </summary>
		public override string ToolName() => "ExportRules";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportRules</para>
		/// </summary>
		public override string ExcuteName() => "un.ExportRules";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, OutCsvFile };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>要从中导出规则的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>要导出的规则类型。</para>
		/// <para>所有—将导出公共设施网络中的所有规则。</para>
		/// <para>交汇点-交汇点连通性—将导出交汇点-交汇点连通性关联规则。</para>
		/// <para>交汇点-边连通性—将导出交汇点-边连通性关联规则。</para>
		/// <para>包含—将导出包含关联规则。</para>
		/// <para>结构附件—将导出结构附件关联规则。</para>
		/// <para>边-交汇点-边连通性—将导出边-交汇点-边连通性关联规则。</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>待创建的 .csv 文件的文件夹位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>所有—将导出公共设施网络中的所有规则。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>交汇点-交汇点连通性—将导出交汇点-交汇点连通性关联规则。</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("交汇点-交汇点连通性")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通性—将导出交汇点-边连通性关联规则。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("交汇点-边连通性")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>包含—将导出包含关联规则。</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("包含")]
			Containment,

			/// <summary>
			/// <para>结构附件—将导出结构附件关联规则。</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("结构附件")]
			Structural_attachment,

			/// <summary>
			/// <para>边-交汇点-边连通性—将导出边-交汇点-边连通性关联规则。</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("边-交汇点-边连通性")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
