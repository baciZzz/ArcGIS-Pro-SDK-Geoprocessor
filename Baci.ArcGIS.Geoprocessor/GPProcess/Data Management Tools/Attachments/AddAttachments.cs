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
	/// <para>Add Attachments</para>
	/// <para>添加附件</para>
	/// <para>向地理数据库要素类或表的记录中添加文件附件。附件以单独附件表的形式存储在地理数据库中，该表与目标数据集保持连接。使用匹配表将附件添加到目标数据集中，该表指定了针对每个输入记录（或记录的属性组）向该记录中添加的附件文件的路径。</para>
	/// </summary>
	public class AddAttachments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要添加附件的地理数据库表或要素类。附件不直接添加到该表中，而是添加到关联的附件表，该附件表保持与输入数据集的连接。</para>
		/// <para>输入数据集必须存储在 10.0 或更高版本的地理数据库中，而且表的附件必须已经启用。</para>
		/// </param>
		/// <param name="InJoinField">
		/// <para>Input Join Field</para>
		/// <para>输入数据集中的值与匹配连接字段中的值相匹配的字段。输入数据集和匹配表之间的连接字段值匹配的记录将添加附件。该字段可以是“Object ID”字段或其他任何标识属性。</para>
		/// </param>
		/// <param name="InMatchTable">
		/// <para>Match Table</para>
		/// <para>用于确定将为哪些输入记录添加附件并确定附件路径的表文件。</para>
		/// </param>
		/// <param name="InMatchJoinField">
		/// <para>Match Join Field</para>
		/// <para>匹配表中的字段，用来确定输入数据集中的哪些记录将添加指定附件。该字段的值可与输入数据集“Object ID”或某些其他标识属性相匹配。</para>
		/// </param>
		/// <param name="InMatchPathField">
		/// <para>Match Path Field</para>
		/// <para>匹配表中的字段，包含要添加到输入数据集记录中的附件的路径。</para>
		/// </param>
		public AddAttachments(object InDataset, object InJoinField, object InMatchTable, object InMatchJoinField, object InMatchPathField)
		{
			this.InDataset = InDataset;
			this.InJoinField = InJoinField;
			this.InMatchTable = InMatchTable;
			this.InMatchJoinField = InMatchJoinField;
			this.InMatchPathField = InMatchPathField;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加附件</para>
		/// </summary>
		public override string DisplayName() => "添加附件";

		/// <summary>
		/// <para>Tool Name : AddAttachments</para>
		/// </summary>
		public override string ToolName() => "AddAttachments";

		/// <summary>
		/// <para>Tool Excute Name : management.AddAttachments</para>
		/// </summary>
		public override string ExcuteName() => "management.AddAttachments";

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
		public override object[] Parameters() => new object[] { InDataset, InJoinField, InMatchTable, InMatchJoinField, InMatchPathField, InWorkingFolder, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要添加附件的地理数据库表或要素类。附件不直接添加到该表中，而是添加到关联的附件表，该附件表保持与输入数据集的连接。</para>
		/// <para>输入数据集必须存储在 10.0 或更高版本的地理数据库中，而且表的附件必须已经启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>输入数据集中的值与匹配连接字段中的值相匹配的字段。输入数据集和匹配表之间的连接字段值匹配的记录将添加附件。该字段可以是“Object ID”字段或其他任何标识属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InJoinField { get; set; }

		/// <summary>
		/// <para>Match Table</para>
		/// <para>用于确定将为哪些输入记录添加附件并确定附件路径的表文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InMatchTable { get; set; }

		/// <summary>
		/// <para>Match Join Field</para>
		/// <para>匹配表中的字段，用来确定输入数据集中的哪些记录将添加指定附件。该字段的值可与输入数据集“Object ID”或某些其他标识属性相匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InMatchJoinField { get; set; }

		/// <summary>
		/// <para>Match Path Field</para>
		/// <para>匹配表中的字段，包含要添加到输入数据集记录中的附件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InMatchPathField { get; set; }

		/// <summary>
		/// <para>Working Folder</para>
		/// <para>集中存放附件文件的文件夹或工作空间。通过指定工作文件夹，匹配路径字段中的路径可以是相对于工作文件夹的短文件名称。</para>
		/// <para>例如，如果加载路径为 C:\MyPictures\image1.jpg 和 C:\MyPictures\image2.jpg 的附件，将工作文件夹设置为 C:\MyPictures 后，匹配路径字段中的路径就可以使用 image1.jpg 和 image2.jpg 等短名称，而不必使用较长的完整路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object InWorkingFolder { get; set; }

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddAttachments SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
