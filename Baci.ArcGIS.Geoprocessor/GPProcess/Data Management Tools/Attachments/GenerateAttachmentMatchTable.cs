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
	/// <para>Generate Attachment Match Table</para>
	/// <para>Creates a match table to be used with the Add Attachments and Remove Attachments tools.</para>
	/// </summary>
	public class GenerateAttachmentMatchTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>Input dataset that contains records that will have files attached.</para>
		/// </param>
		/// <param name="InFolder">
		/// <para>Input Folder</para>
		/// <para>Folder that contains files to attach.</para>
		/// </param>
		/// <param name="OutMatchTable">
		/// <para>Output Match Table</para>
		/// <para>Table that will be generated which contains two columns: MATCHID and FILENAME.</para>
		/// </param>
		/// <param name="InKeyField">
		/// <para>Key Field</para>
		/// <para>The values in this field will match the names of the files in the input folder. The matching behavior will ignore file extensions, which allows multiple files with various file extensions to match with a single record in the input dataset.</para>
		/// <para>For example, if the input Key Field value is lot5986, a file on disk named lot5986.jpg would match with this record.</para>
		/// </param>
		public GenerateAttachmentMatchTable(object InDataset, object InFolder, object OutMatchTable, object InKeyField)
		{
			this.InDataset = InDataset;
			this.InFolder = InFolder;
			this.OutMatchTable = OutMatchTable;
			this.InKeyField = InKeyField;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Attachment Match Table</para>
		/// </summary>
		public override string DisplayName() => "Generate Attachment Match Table";

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
		public override object[] Parameters() => new object[] { InDataset, InFolder, OutMatchTable, InKeyField, InFileFilter!, InUseRelativePaths! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>Input dataset that contains records that will have files attached.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>Folder that contains files to attach.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>Table that will be generated which contains two columns: MATCHID and FILENAME.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutMatchTable { get; set; }

		/// <summary>
		/// <para>Key Field</para>
		/// <para>The values in this field will match the names of the files in the input folder. The matching behavior will ignore file extensions, which allows multiple files with various file extensions to match with a single record in the input dataset.</para>
		/// <para>For example, if the input Key Field value is lot5986, a file on disk named lot5986.jpg would match with this record.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InKeyField { get; set; }

		/// <summary>
		/// <para>Input Data Filter</para>
		/// <para>This parameter is used to limit the files the tool considers for matching. If the file name does not meet the criteria in the file filter parameter it will not be processed and therefore will not show up in the output match table. Wild cards (*) can be used in this parameter for more flexible filtering options. Multiple semicolon-delimited filters can be used as well.</para>
		/// <para>For example, consider a directory that contains the following files: parcel.tif, parcel.doc, parcel.jpg, houses.jpg, and report.pdf.</para>
		/// <para>To limit the possible matches in this list to .jpg files, use *.jpg.</para>
		/// <para>To limit the possible matches in this list to .pdf and .doc files, use *.pdf; *.doc.</para>
		/// <para>To limit the possible matches in this list to files beginning with parcel, use parcel*.</para>
		/// <para>To limit the possible matches in this list to files that contain the text arc, use *arc*.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InFileFilter { get; set; }

		/// <summary>
		/// <para>Store Relative Path</para>
		/// <para>Determines if the output match table field FILENAME will contain a full path to the dataset or only the file name.</para>
		/// <para>Checked—The output FILENAME field will contain relative paths. This is the default.</para>
		/// <para>Unchecked—The output FILENAME field will contain full paths to the data.</para>
		/// <para><see cref="InUseRelativePathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InUseRelativePaths { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Store Relative Path</para>
		/// </summary>
		public enum InUseRelativePathsEnum 
		{
			/// <summary>
			/// <para>Checked—The output FILENAME field will contain relative paths. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RELATIVE")]
			RELATIVE,

			/// <summary>
			/// <para>Unchecked—The output FILENAME field will contain full paths to the data.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE")]
			ABSOLUTE,

		}

#endregion
	}
}
