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
	/// <para>Export Associations</para>
	/// <para>导出关联</para>
	/// <para>将公共设施网络中的关联导出至逗号分隔值文件 (.csv)。此工具可以与导入关联工具一起使用。</para>
	/// </summary>
	public class ExportAssociations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含要导出关联的公共设施网络。</para>
		/// </param>
		/// <param name="AssociationType">
		/// <para>Association Type</para>
		/// <para>指定要导出的关联类型。</para>
		/// <para>所有—公共设施网络中的所有关联类型均导出至 .csv 文件。</para>
		/// <para>交汇点-交汇点连通性—允许两个交汇点子类型通过连通性关联连接（要素发生几何偏移）的连通性关联将导出至 .csv 文件。</para>
		/// <para>包含—包含关联类型将导出至 .csv 文件。</para>
		/// <para>附件—结构附件关联类型将导出至 .csv 文件。</para>
		/// <para>交汇点-边连通性（自边的一侧）—交汇点-边（自边的一侧）连通性关联类型将导出至 .csv 文件。</para>
		/// <para>交汇点-边连通规则（中跨）—交汇点-边（中跨）连通性关联类型将导出至 .csv 文件。</para>
		/// <para>交汇点-边连通性（至边的一侧）—交汇点-边（至边的一侧）连通性关联类型将导出至 .csv 文件。</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output  File</para>
		/// <para>将生成的 .csv 文件的名称和位置。</para>
		/// </param>
		public ExportAssociations(object InUtilityNetwork, object AssociationType, object OutCsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.AssociationType = AssociationType;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出关联</para>
		/// </summary>
		public override string DisplayName() => "导出关联";

		/// <summary>
		/// <para>Tool Name : ExportAssociations</para>
		/// </summary>
		public override string ToolName() => "ExportAssociations";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportAssociations</para>
		/// </summary>
		public override string ExcuteName() => "un.ExportAssociations";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, AssociationType, OutCsvFile };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含要导出关联的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Association Type</para>
		/// <para>指定要导出的关联类型。</para>
		/// <para>所有—公共设施网络中的所有关联类型均导出至 .csv 文件。</para>
		/// <para>交汇点-交汇点连通性—允许两个交汇点子类型通过连通性关联连接（要素发生几何偏移）的连通性关联将导出至 .csv 文件。</para>
		/// <para>包含—包含关联类型将导出至 .csv 文件。</para>
		/// <para>附件—结构附件关联类型将导出至 .csv 文件。</para>
		/// <para>交汇点-边连通性（自边的一侧）—交汇点-边（自边的一侧）连通性关联类型将导出至 .csv 文件。</para>
		/// <para>交汇点-边连通规则（中跨）—交汇点-边（中跨）连通性关联类型将导出至 .csv 文件。</para>
		/// <para>交汇点-边连通性（至边的一侧）—交汇点-边（至边的一侧）连通性关联类型将导出至 .csv 文件。</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationType { get; set; }

		/// <summary>
		/// <para>Output  File</para>
		/// <para>将生成的 .csv 文件的名称和位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Association Type</para>
		/// </summary>
		public enum AssociationTypeEnum 
		{
			/// <summary>
			/// <para>所有—公共设施网络中的所有关联类型均导出至 .csv 文件。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>交汇点-交汇点连通性—允许两个交汇点子类型通过连通性关联连接（要素发生几何偏移）的连通性关联将导出至 .csv 文件。</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("交汇点-交汇点连通性")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>包含—包含关联类型将导出至 .csv 文件。</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("包含")]
			Containment,

			/// <summary>
			/// <para>附件—结构附件关联类型将导出至 .csv 文件。</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("附件")]
			Attachment,

			/// <summary>
			/// <para>交汇点-边连通性（自边的一侧）—交汇点-边（自边的一侧）连通性关联类型将导出至 .csv 文件。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_FROM_CONNECTIVITY")]
			[Description("交汇点-边连通性（自边的一侧）")]
			JUNCTION_EDGE_FROM_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通规则（中跨）—交汇点-边（中跨）连通性关联类型将导出至 .csv 文件。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_MIDSPAN_CONNECTIVITY")]
			[Description("交汇点-边连通规则（中跨）")]
			JUNCTION_EDGE_MIDSPAN_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通性（至边的一侧）—交汇点-边（至边的一侧）连通性关联类型将导出至 .csv 文件。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_TO_CONNECTIVITY")]
			[Description("交汇点-边连通性（至边的一侧）")]
			JUNCTION_EDGE_TO_CONNECTIVITY,

		}

#endregion
	}
}
