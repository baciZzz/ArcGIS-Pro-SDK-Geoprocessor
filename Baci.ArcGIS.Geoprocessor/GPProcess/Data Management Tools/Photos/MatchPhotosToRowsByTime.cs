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
	/// <para>Match Photos To Rows By Time</para>
	/// <para>Matches photo files to table or feature class rows according to the photo and row time stamps. The row with the time stamp closest to the capture time of a photo will be matched to that photo. Creates a new table containing the ObjectIDs from the input rows and their matching photo paths. Optionally adds matching photo files to the rows of the input table as geodatabase attachments.</para>
	/// </summary>
	public class MatchPhotosToRowsByTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFolder">
		/// <para>Input Folder</para>
		/// <para>The folder where photo files are located. This folder is scanned recursively for photo files; any photos in the base level of the folder, as well as in any subfolders, will be added to the output.</para>
		/// </param>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>The table or feature class whose rows will be matched with photo files. The input table will typically be a point feature class representing GPS recordings.</para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>The date/time field from the input table that indicates when each row was captured or created. Must be a date field; cannot be a string or numeric field.</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>The output table containing the OBJECTIDs from the input table that match a photo, and the matching photo path. Only OBJECTIDs from the input table that are found to match a photo are included in the output table.</para>
		/// </param>
		public MatchPhotosToRowsByTime(object InputFolder, object InputTable, object TimeField, object OutputTable)
		{
			this.InputFolder = InputFolder;
			this.InputTable = InputTable;
			this.TimeField = TimeField;
			this.OutputTable = OutputTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Match Photos To Rows By Time</para>
		/// </summary>
		public override string DisplayName => "Match Photos To Rows By Time";

		/// <summary>
		/// <para>Tool Name : MatchPhotosToRowsByTime</para>
		/// </summary>
		public override string ToolName => "MatchPhotosToRowsByTime";

		/// <summary>
		/// <para>Tool Excute Name : management.MatchPhotosToRowsByTime</para>
		/// </summary>
		public override string ExcuteName => "management.MatchPhotosToRowsByTime";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFolder, InputTable, TimeField, OutputTable, UnmatchedPhotosTable, AddPhotosAsAttachments, TimeTolerance, ClockOffset };

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>The folder where photo files are located. This folder is scanned recursively for photo files; any photos in the base level of the folder, as well as in any subfolders, will be added to the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InputFolder { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table or feature class whose rows will be matched with photo files. The input table will typically be a point feature class representing GPS recordings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>The date/time field from the input table that indicates when each row was captured or created. Must be a date field; cannot be a string or numeric field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing the OBJECTIDs from the input table that match a photo, and the matching photo path. Only OBJECTIDs from the input table that are found to match a photo are included in the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Unmatched Photos Table</para>
		/// <para>The optional output table that will list any photo files in the input folder with an invalid time stamp or any photos that cannot be matched because there is no input row within the time tolerance.</para>
		/// <para>If no path is specified, this table will not be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object UnmatchedPhotosTable { get; set; }

		/// <summary>
		/// <para>Add Photos As Attachments</para>
		/// <para>Specifies if photo files will be added to the rows of the input table as geodatabase attachments. The input table must be stored in a version 10 or later geodatabase for photo files to be added as attachments.</para>
		/// <para>Checked—Photo files will be added to the rows of the input table as geodatabase attachments. Geodatabase attachments are copied internally to the geodatabase. This is the default.</para>
		/// <para>Unchecked—Photo files will not be added to the rows of the input table as geodatabase attachments.</para>
		/// <para><see cref="AddPhotosAsAttachmentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddPhotosAsAttachments { get; set; } = "true";

		/// <summary>
		/// <para>Time Tolerance</para>
		/// <para>The maximum difference (in seconds) between the date/time of an input row and a photo file that will be matched. If an input row and a photo file have time stamps that are different by more than this tolerance, no match will occur. To match a photo file to a row with the closest time stamp, regardless of how large the date/time difference might be, set the tolerance to 0. The sign of this value (- or +) is irrelevant; the absolute value of the number specified will be used.</para>
		/// <para>Do not use this parameter to adjust for consistent shifts or offsets between the times recorded by the GPS and the digital camera. Use the Clock Offset parameter, or the Convert Time Zone tool to shift the time stamps of the input rows to match those of the photos.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object TimeTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Clock Offset</para>
		/// <para>The difference (in seconds) between the internal clock of the digital camera used to capture the photos and the GPS unit. If the clock of the digital camera is behind the clock of the GPS unit, use a positive value; if the clock of the digital camera is ahead of the clock of the GPS unit, use a negative value.</para>
		/// <para>For example, if a photo with a time stamp of 11:35:17 should match a row with a time stamp of 11:35:32, use a Clock Offset of 15.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ClockOffset { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MatchPhotosToRowsByTime SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add Photos As Attachments</para>
		/// </summary>
		public enum AddPhotosAsAttachmentsEnum 
		{
			/// <summary>
			/// <para>Checked—Photo files will be added to the rows of the input table as geodatabase attachments. Geodatabase attachments are copied internally to the geodatabase. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_ATTACHMENTS")]
			ADD_ATTACHMENTS,

			/// <summary>
			/// <para>Unchecked—Photo files will not be added to the rows of the input table as geodatabase attachments.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ATTACHMENTS")]
			NO_ATTACHMENTS,

		}

#endregion
	}
}
