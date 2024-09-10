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
	/// <para>Adds file attachments to the records of a geodatabase feature class or table. The attachments are stored internally in the geodatabase in a separate attachment table that maintains linkage to the target dataset. Attachments are added to the target dataset using a match table that dictates for each input record (or an attribute group of records) the path to a file to add as an attachment to that record.</para>
	/// </summary>
	public class AddAttachments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>Geodatabase table or feature class to add attachments to. Attachments are not added directly to this table, but rather to a related attachment table that maintains linkage to the input dataset.</para>
		/// <para>The input dataset must be stored in a version 10.0 or later geodatabase, and the table must have attachments enabled.</para>
		/// </param>
		/// <param name="InJoinField">
		/// <para>Input Join Field</para>
		/// <para>Field from the Input Dataset that has values that match the values in the Match Join Field. Records that have join field values that match between the Input Dataset and the Match Table will have attachments added. This field can be an Object ID field or any other identifying attribute.</para>
		/// </param>
		/// <param name="InMatchTable">
		/// <para>Match Table</para>
		/// <para>Table that identifies which input records will have attachments added and the paths to those attachments.</para>
		/// </param>
		/// <param name="InMatchJoinField">
		/// <para>Match Join Field</para>
		/// <para>Field from the match table that indicates which records in the Input Dataset will have specified attachments added. This field can have values that match Input Dataset Object IDs or some other identifying attribute.</para>
		/// </param>
		/// <param name="InMatchPathField">
		/// <para>Match Path Field</para>
		/// <para>Field from the match table that contains paths to the attachments to add to Input Dataset records.</para>
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
		/// <para>Tool Display Name : Add Attachments</para>
		/// </summary>
		public override string DisplayName() => "Add Attachments";

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
		/// <para>Geodatabase table or feature class to add attachments to. Attachments are not added directly to this table, but rather to a related attachment table that maintains linkage to the input dataset.</para>
		/// <para>The input dataset must be stored in a version 10.0 or later geodatabase, and the table must have attachments enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>Field from the Input Dataset that has values that match the values in the Match Join Field. Records that have join field values that match between the Input Dataset and the Match Table will have attachments added. This field can be an Object ID field or any other identifying attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InJoinField { get; set; }

		/// <summary>
		/// <para>Match Table</para>
		/// <para>Table that identifies which input records will have attachments added and the paths to those attachments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InMatchTable { get; set; }

		/// <summary>
		/// <para>Match Join Field</para>
		/// <para>Field from the match table that indicates which records in the Input Dataset will have specified attachments added. This field can have values that match Input Dataset Object IDs or some other identifying attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InMatchJoinField { get; set; }

		/// <summary>
		/// <para>Match Path Field</para>
		/// <para>Field from the match table that contains paths to the attachments to add to Input Dataset records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InMatchPathField { get; set; }

		/// <summary>
		/// <para>Working Folder</para>
		/// <para>Folder or workspace where attachment files are centralized. By specifying a working folder, the paths in the Match Path Field can be the short names of files relative to the working folder.</para>
		/// <para>For example, if loading attachments with paths like C:\MyPictures\image1.jpg, C:\MyPictures\image2.jpg, set the Working Folder to C:\MyPictures, then paths in the Match Path Field can be the short names such as image1.jpg and image2.jpg, instead of the longer full paths.</para>
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
		public AddAttachments SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
