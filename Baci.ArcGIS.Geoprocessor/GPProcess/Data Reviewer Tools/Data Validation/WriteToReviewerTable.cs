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
	/// <para>Write To Reviewer Table</para>
	/// <para>写入 Reviewer 表</para>
	/// <para>将要素类、要素图层、表或表视图写入 Reviewer 工作空间。</para>
	/// </summary>
	public class WriteToReviewerTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>要素或表记录将写入其中的 Reviewer 工作空间的路径。</para>
		/// </param>
		/// <param name="InSession">
		/// <para>Session</para>
		/// <para>要素或表记录将写入其中的 Reviewer 会话 ID。使用完整的会话 ID 格式：会话 1：会话 1。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将写入 Reviewer 工作空间的要素或表记录。</para>
		/// </param>
		/// <param name="InField">
		/// <para>ID Field</para>
		/// <para>包含要素标识符的字段。该字段值填充 Reviewer 结果窗格中的 ID 字段。所选择的字段的数据类型必须为 Long。</para>
		/// </param>
		/// <param name="InOriginTableName">
		/// <para>Origin Table Name (Value or Field)</para>
		/// <para>该字符串或字段值将用于每条写入 Reviewer 结果窗格的记录，填充其中的源字段。它通常是要素类或表的名称。</para>
		/// <para>字符串 - 要素图层名称定义为文本字符串。</para>
		/// <para>字段 - 要素图层名称的值由要素图层或表中的字段派生而来。</para>
		/// </param>
		/// <param name="InReviewStatus">
		/// <para>Review Status</para>
		/// <para>与写入 Reviewer 工作空间的记录组关联的状态字符串。默认值为将 GP 结果写入 Reviewer 表。如果默认值被删除或留空，则 Write GP Results to Reviewer Table 值将被用作状态字符串。</para>
		/// <para>字符串 - 可在字符串文本框中输入值。</para>
		/// <para>字段 - 可在要素图层中选择 Review Status 字段。</para>
		/// </param>
		public WriteToReviewerTable(object InReviewerWorkspace, object InSession, object InFeatures, object InField, object InOriginTableName, object InReviewStatus)
		{
			this.InReviewerWorkspace = InReviewerWorkspace;
			this.InSession = InSession;
			this.InFeatures = InFeatures;
			this.InField = InField;
			this.InOriginTableName = InOriginTableName;
			this.InReviewStatus = InReviewStatus;
		}

		/// <summary>
		/// <para>Tool Display Name : 写入 Reviewer 表</para>
		/// </summary>
		public override string DisplayName() => "写入 Reviewer 表";

		/// <summary>
		/// <para>Tool Name : WriteToReviewerTable</para>
		/// </summary>
		public override string ToolName() => "WriteToReviewerTable";

		/// <summary>
		/// <para>Tool Excute Name : Reviewer.WriteToReviewerTable</para>
		/// </summary>
		public override string ExcuteName() => "Reviewer.WriteToReviewerTable";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InReviewerWorkspace, InSession, InFeatures, InField, InOriginTableName, InReviewStatus, InSubtype!, InNotes!, InSeverity!, REVTABLEMAINView!, InCheckTitle! };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>要素或表记录将写入其中的 Reviewer 工作空间的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session</para>
		/// <para>要素或表记录将写入其中的 Reviewer 会话 ID。使用完整的会话 ID 格式：会话 1：会话 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InSession { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将写入 Reviewer 工作空间的要素或表记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>包含要素标识符的字段。该字段值填充 Reviewer 结果窗格中的 ID 字段。所选择的字段的数据类型必须为 Long。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Short", "Long", "OID")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Origin Table Name (Value or Field)</para>
		/// <para>该字符串或字段值将用于每条写入 Reviewer 结果窗格的记录，填充其中的源字段。它通常是要素类或表的名称。</para>
		/// <para>字符串 - 要素图层名称定义为文本字符串。</para>
		/// <para>字段 - 要素图层名称的值由要素图层或表中的字段派生而来。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InOriginTableName { get; set; }

		/// <summary>
		/// <para>Review Status</para>
		/// <para>与写入 Reviewer 工作空间的记录组关联的状态字符串。默认值为将 GP 结果写入 Reviewer 表。如果默认值被删除或留空，则 Write GP Results to Reviewer Table 值将被用作状态字符串。</para>
		/// <para>字符串 - 可在字符串文本框中输入值。</para>
		/// <para>字段 - 可在要素图层中选择 Review Status 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InReviewStatus { get; set; } = "Write GP Results to Reviewer Table";

		/// <summary>
		/// <para>Subtype</para>
		/// <para>要素所属的要素类子类型。它可由指定值或要素类的字段派生而来。该参数值填充 Reviewer 结果窗格中的 SUBTYPE 字段。</para>
		/// <para>字符串 - 可在字符串文本框中输入值。</para>
		/// <para>字段 - 可在要素图层的字段中选择 Subtype 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? InSubtype { get; set; }

		/// <summary>
		/// <para>Notes</para>
		/// <para>填充 Reviewer 表中 Notes 字段的文本。注释更为详细地说明了要素或表记录。</para>
		/// <para>字符串 - 可在字符串文本框中输入值。</para>
		/// <para>字段 - 可在要素图层的字段中选择 Notes 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? InNotes { get; set; }

		/// <summary>
		/// <para>Severity</para>
		/// <para>该数值表示写入 Reviewer 工作空间中的要素或表记录的显著性。这些值在 5（低重要性）和 1（高优先级）之间。该值填充 Reviewer 结果窗格中的 Severity 字段。</para>
		/// <para>字符串 - 可在字符串文本框中输入值。</para>
		/// <para>字段 - 可在要素图层的字段中选择 Severity 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? InSeverity { get; set; } = "5";

		/// <summary>
		/// <para>REVTABLEMAIN</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? REVTABLEMAINView { get; set; }

		/// <summary>
		/// <para>Check Title</para>
		/// <para>填充 Reviewer 结果窗格中 Check Title 字段的文本。Check Title 字段用于描述在要素或表记录中检测到的错误条件。</para>
		/// <para>字符串 - 可在字符串文本框中输入值。</para>
		/// <para>字段 - 可在要素图层的字段中选择 Check Title 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? InCheckTitle { get; set; } = "Write GP Results to Reviewer Table";

	}
}
