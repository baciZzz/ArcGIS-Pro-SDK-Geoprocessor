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
	/// <para>Remove Attachments</para>
	/// <para>移除附件</para>
	/// <para>从地理数据库要素类或表记录中移除附件。由于附件实际并未存储在输入数据集中，因此不会对该要素类或表进行任何更改，但是会对存储附件和保持与输入数据集的连接的关联地理数据库表进行更改。匹配表用于标识哪些输入记录（或记录的属性组）将移除附件。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveAttachments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要从中移除附件的地理数据库表或要素类。不会直接从此表中移除附件，而是从存储附件的关联附件表中移除。输入数据集必须存储在 10.0 或更高版本的地理数据库中，而且表的附件必须已经启用。</para>
		/// </param>
		/// <param name="InJoinField">
		/// <para>Input Join Field</para>
		/// <para>“输入数据集”中的字段，其值与匹配连接字段中的值相匹配。输入数据集和匹配表之间的连接字段值匹配的记录将移除附件。该字段可以是“Object ID”字段或其他任何标识属性。</para>
		/// </param>
		/// <param name="InMatchTable">
		/// <para>Match Table</para>
		/// <para>确定哪些输入记录将移除附件的表。</para>
		/// </param>
		/// <param name="InMatchJoinField">
		/// <para>Match Join Field</para>
		/// <para>匹配表中的字段，指示输入数据集中的哪些记录将移除指定附件。该字段的值可与输入数据集“Object ID”或某些其他标识属性相匹配。</para>
		/// </param>
		public RemoveAttachments(object InDataset, object InJoinField, object InMatchTable, object InMatchJoinField)
		{
			this.InDataset = InDataset;
			this.InJoinField = InJoinField;
			this.InMatchTable = InMatchTable;
			this.InMatchJoinField = InMatchJoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除附件</para>
		/// </summary>
		public override string DisplayName() => "移除附件";

		/// <summary>
		/// <para>Tool Name : RemoveAttachments</para>
		/// </summary>
		public override string ToolName() => "RemoveAttachments";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveAttachments</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveAttachments";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, InJoinField, InMatchTable, InMatchJoinField, InMatchNameField, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要从中移除附件的地理数据库表或要素类。不会直接从此表中移除附件，而是从存储附件的关联附件表中移除。输入数据集必须存储在 10.0 或更高版本的地理数据库中，而且表的附件必须已经启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>“输入数据集”中的字段，其值与匹配连接字段中的值相匹配。输入数据集和匹配表之间的连接字段值匹配的记录将移除附件。该字段可以是“Object ID”字段或其他任何标识属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InJoinField { get; set; }

		/// <summary>
		/// <para>Match Table</para>
		/// <para>确定哪些输入记录将移除附件的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InMatchTable { get; set; }

		/// <summary>
		/// <para>Match Join Field</para>
		/// <para>匹配表中的字段，指示输入数据集中的哪些记录将移除指定附件。该字段的值可与输入数据集“Object ID”或某些其他标识属性相匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InMatchJoinField { get; set; }

		/// <summary>
		/// <para>Match Name Field</para>
		/// <para>匹配表中的字段，包含要从输入数据集记录中移除的附件的名称。如果未指定名称字段，则会从匹配连接字段指定的每条记录中移除所有附件。如果指定了名称字段，但是记录的名称字段值为 null 或为空，则将从该记录中移除所有附件。此字段的值应该为要移除的附件的名称缩写，而不是用于创建原始附件的文件的完整路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InMatchNameField { get; set; }

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveAttachments SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
