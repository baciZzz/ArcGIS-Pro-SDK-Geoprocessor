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
	/// <para>Remove Attachments</para>
	/// <para>Removes attachments from geodatabase feature class or table records.</para>
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
		/// <para>A geodatabase table or feature class from which attachments will be removed. Attachments are not removed directly from this table; they are removed from the related attachment table that stores the attachments. The dataset must have attachments enabled.</para>
		/// </param>
		/// <param name="InJoinField">
		/// <para>Input Join Field</para>
		/// <para>A field from the Input Dataset parameter value that contains values that match the values in the Match Join Field parameter value. Records that have join field values that match the Input Dataset parameter value and the Match Table parameter value will have attachments removed. This field can be an Object ID field or any other identifying attribute.</para>
		/// </param>
		/// <param name="InMatchTable">
		/// <para>Match Table</para>
		/// <para>A table that identifies which input records will have attachments removed.</para>
		/// </param>
		/// <param name="InMatchJoinField">
		/// <para>Match Join Field</para>
		/// <para>A field from the match table that indicates which records in the Input Dataset parameter value will have specified attachments removed. This field can have values that match the Input Dataset Object ID field or some other identifying attribute.</para>
		/// </param>
		public RemoveAttachments(object InDataset, object InJoinField, object InMatchTable, object InMatchJoinField)
		{
			this.InDataset = InDataset;
			this.InJoinField = InJoinField;
			this.InMatchTable = InMatchTable;
			this.InMatchJoinField = InMatchJoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Attachments</para>
		/// </summary>
		public override string DisplayName() => "Remove Attachments";

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
		public override object[] Parameters() => new object[] { InDataset, InJoinField, InMatchTable, InMatchJoinField, InMatchNameField!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>A geodatabase table or feature class from which attachments will be removed. Attachments are not removed directly from this table; they are removed from the related attachment table that stores the attachments. The dataset must have attachments enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>A field from the Input Dataset parameter value that contains values that match the values in the Match Join Field parameter value. Records that have join field values that match the Input Dataset parameter value and the Match Table parameter value will have attachments removed. This field can be an Object ID field or any other identifying attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InJoinField { get; set; }

		/// <summary>
		/// <para>Match Table</para>
		/// <para>A table that identifies which input records will have attachments removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InMatchTable { get; set; }

		/// <summary>
		/// <para>Match Join Field</para>
		/// <para>A field from the match table that indicates which records in the Input Dataset parameter value will have specified attachments removed. This field can have values that match the Input Dataset Object ID field or some other identifying attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InMatchJoinField { get; set; }

		/// <summary>
		/// <para>Match Name Field</para>
		/// <para>A field from the match table that has the names of the attachments that will be removed from the Input Dataset parameter value's records. If no name field is specified, all attachments will be removed from each record specified in the Match Join Field parameter value. If a name field is specified but a record has a null or empty value in the name field, all attachments will be removed from that record. This field's values should be the short names of the attachments to remove, not the full paths to the files used to make the original attachments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object? InMatchNameField { get; set; }

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveAttachments SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
