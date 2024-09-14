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
	/// <para>Generate Attachment Match Table</para>
	/// <para>生成附件匹配表</para>
	/// <para>用于创建匹配表，以与添加附件和移除附件工具配合使用。</para>
	/// </summary>
	public class GenerateAttachmentMatchTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>其中包含要附加文件的记录的输入数据集。</para>
		/// </param>
		/// <param name="InFolder">
		/// <para>Input Folder</para>
		/// <para>其中包含要附加的文件的文件夹。</para>
		/// </param>
		/// <param name="OutMatchTable">
		/// <para>Output Match Table</para>
		/// <para>将生成的包含以下两列的表：MATCHID 和 FILENAME。</para>
		/// </param>
		/// <param name="InKeyField">
		/// <para>Key Field</para>
		/// <para>此字段中的值将与输入文件夹中的文件名匹配。匹配行为将忽略文件扩展名，从而使文件扩展名不同的多个文件与输入数据集中的一条记录相匹配。</para>
		/// <para>例如，如果输入“关键字段”值为 lot5986，则磁盘上名为 lot5986.jpg 的文件将与此条记录匹配。</para>
		/// </param>
		public GenerateAttachmentMatchTable(object InDataset, object InFolder, object OutMatchTable, object InKeyField)
		{
			this.InDataset = InDataset;
			this.InFolder = InFolder;
			this.OutMatchTable = OutMatchTable;
			this.InKeyField = InKeyField;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成附件匹配表</para>
		/// </summary>
		public override string DisplayName() => "生成附件匹配表";

		/// <summary>
		/// <para>Tool Name : GenerateAttachmentMatchTable</para>
		/// </summary>
		public override string ToolName() => "GenerateAttachmentMatchTable";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateAttachmentMatchTable</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateAttachmentMatchTable";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, InFolder, OutMatchTable, InKeyField, InFileFilter, InUseRelativePaths };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>其中包含要附加文件的记录的输入数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>其中包含要附加的文件的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>将生成的包含以下两列的表：MATCHID 和 FILENAME。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutMatchTable { get; set; }

		/// <summary>
		/// <para>Key Field</para>
		/// <para>此字段中的值将与输入文件夹中的文件名匹配。匹配行为将忽略文件扩展名，从而使文件扩展名不同的多个文件与输入数据集中的一条记录相匹配。</para>
		/// <para>例如，如果输入“关键字段”值为 lot5986，则磁盘上名为 lot5986.jpg 的文件将与此条记录匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InKeyField { get; set; }

		/// <summary>
		/// <para>Input Data Filter</para>
		/// <para>此参数用于限制工具认为匹配的文件。如果文件名不符合文件过滤器参数中的条件，则不会被处理，因此文件也不会显示在输出匹配表中。可在此参数中使用通配符 (*) 来获得更灵活的过滤选项。也可以使用多个以分号分隔的过滤器。</para>
		/// <para>以包含以下文件的目录为例：parcel.tif、parcel.doc、parcel.jpg、houses.jpg 和 report.pdf。</para>
		/// <para>要将此列表中的可能匹配项限制为 .jpg 文件，则使用 *.jpg。</para>
		/// <para>要将此列表中的可能匹配项限制为 .pdf 文件和 .doc 文件，则使用 *.pdf; *.doc。</para>
		/// <para>要将此列表中的可能匹配项限制为以 parcel 开头的文件，则使用 parcel*。</para>
		/// <para>要将此列表中的可能匹配项限制为包含文本 arc 的文件，则使用 *arc*。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object InFileFilter { get; set; }

		/// <summary>
		/// <para>Store Relative Path</para>
		/// <para>确定输出匹配表字段 FILENAME 是包含数据集的完整路径，还是仅为文件名。</para>
		/// <para>选中 - 输出 FILENAME 字段将包含相对路径。这是默认设置。</para>
		/// <para>未选中 - 输出 FILENAME 字段将包含数据的完整路径。</para>
		/// <para><see cref="InUseRelativePathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InUseRelativePaths { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Store Relative Path</para>
		/// </summary>
		public enum InUseRelativePathsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RELATIVE")]
			RELATIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE")]
			ABSOLUTE,

		}

#endregion
	}
}
