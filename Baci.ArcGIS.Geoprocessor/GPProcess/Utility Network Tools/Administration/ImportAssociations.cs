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
	/// <para>Import Associations</para>
	/// <para>导入关联</para>
	/// <para>从逗号分隔值文件导入关联 (.csv) 到现有公共设施网络。 此工具可以与导出关联工具配合使用。</para>
	/// </summary>
	public class ImportAssociations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将导入关联的公共设施网络。</para>
		/// </param>
		/// <param name="AssociationType">
		/// <para>Association Type</para>
		/// <para>指定要导入的关联类型。</para>
		/// <para>全部—将导入所有关联类型。</para>
		/// <para>交汇点-交汇点连通性—将导入交汇点-交汇点连通性关联类型。</para>
		/// <para>包含—将导入包含关联类型。</para>
		/// <para>附件—将导入结构附件关联类型。</para>
		/// <para>交汇点-边连通性（自边的一侧）—将导入交汇点-边连通性（自边的一侧）关联类型。</para>
		/// <para>交汇点-边连通规则（中跨）—将导入交汇点-边连通性（中跨）关联类型。</para>
		/// <para>交汇点-边连通性（至边的一侧）—将导入交汇点-边连通性（至边的一侧）关联类型。</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </param>
		/// <param name="CsvFile">
		/// <para>Input File</para>
		/// <para>将从中导入关联的 .csv 文件。</para>
		/// </param>
		public ImportAssociations(object InUtilityNetwork, object AssociationType, object CsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.AssociationType = AssociationType;
			this.CsvFile = CsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入关联</para>
		/// </summary>
		public override string DisplayName() => "导入关联";

		/// <summary>
		/// <para>Tool Name : ImportAssociations</para>
		/// </summary>
		public override string ToolName() => "ImportAssociations";

		/// <summary>
		/// <para>Tool Excute Name : un.ImportAssociations</para>
		/// </summary>
		public override string ExcuteName() => "un.ImportAssociations";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, AssociationType, CsvFile, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将导入关联的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Association Type</para>
		/// <para>指定要导入的关联类型。</para>
		/// <para>全部—将导入所有关联类型。</para>
		/// <para>交汇点-交汇点连通性—将导入交汇点-交汇点连通性关联类型。</para>
		/// <para>包含—将导入包含关联类型。</para>
		/// <para>附件—将导入结构附件关联类型。</para>
		/// <para>交汇点-边连通性（自边的一侧）—将导入交汇点-边连通性（自边的一侧）关联类型。</para>
		/// <para>交汇点-边连通规则（中跨）—将导入交汇点-边连通性（中跨）关联类型。</para>
		/// <para>交汇点-边连通性（至边的一侧）—将导入交汇点-边连通性（至边的一侧）关联类型。</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationType { get; set; }

		/// <summary>
		/// <para>Input File</para>
		/// <para>将从中导入关联的 .csv 文件。</para>
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
		public ImportAssociations SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Association Type</para>
		/// </summary>
		public enum AssociationTypeEnum 
		{
			/// <summary>
			/// <para>全部—将导入所有关联类型。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>交汇点-交汇点连通性—将导入交汇点-交汇点连通性关联类型。</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("交汇点-交汇点连通性")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>包含—将导入包含关联类型。</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("包含")]
			Containment,

			/// <summary>
			/// <para>附件—将导入结构附件关联类型。</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("附件")]
			Attachment,

			/// <summary>
			/// <para>交汇点-边连通性（自边的一侧）—将导入交汇点-边连通性（自边的一侧）关联类型。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_FROM_CONNECTIVITY")]
			[Description("交汇点-边连通性（自边的一侧）")]
			JUNCTION_EDGE_FROM_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通规则（中跨）—将导入交汇点-边连通性（中跨）关联类型。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_MIDSPAN_CONNECTIVITY")]
			[Description("交汇点-边连通规则（中跨）")]
			JUNCTION_EDGE_MIDSPAN_CONNECTIVITY,

			/// <summary>
			/// <para>交汇点-边连通性（至边的一侧）—将导入交汇点-边连通性（至边的一侧）关联类型。</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_TO_CONNECTIVITY")]
			[Description("交汇点-边连通性（至边的一侧）")]
			JUNCTION_EDGE_TO_CONNECTIVITY,

		}

#endregion
	}
}
