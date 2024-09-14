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
	/// <para>Enable Editor Tracking</para>
	/// <para>Enable Editor Tracking</para>
	/// <para>Enables editor tracking for a feature class, table, feature dataset, or relationship class in a geodatabase.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableEditorTracking : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The feature class, table, feature dataset, or relationship class in which editor tracking will be enabled.</para>
		/// </param>
		public EnableEditorTracking(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Editor Tracking</para>
		/// </summary>
		public override string DisplayName() => "Enable Editor Tracking";

		/// <summary>
		/// <para>Tool Name : EnableEditorTracking</para>
		/// </summary>
		public override string ToolName() => "EnableEditorTracking";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableEditorTracking</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableEditorTracking";

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
		public override object[] Parameters() => new object[] { InDataset, CreatorField!, CreationDateField!, LastEditorField!, LastEditDateField!, AddFields!, RecordDatesIn!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The feature class, table, feature dataset, or relationship class in which editor tracking will be enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Creator Field</para>
		/// <para>The name of the field that will store the names of users who create features or records. If this field already exists, it must be a string field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? CreatorField { get; set; }

		/// <summary>
		/// <para>Creation Date Field</para>
		/// <para>The name of the field that will store the date that features or records are created. If this field already exists, it must be a date field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? CreationDateField { get; set; }

		/// <summary>
		/// <para>Last Editor Field</para>
		/// <para>The name of the field that will store the names of users who last edited features or records. If this field already exists, it must be a string field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LastEditorField { get; set; }

		/// <summary>
		/// <para>Last Edit Date Field</para>
		/// <para>The name of the field that will store the date that features or records were last edited. If this field already exists, it must be a date field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LastEditDateField { get; set; }

		/// <summary>
		/// <para>Add fields</para>
		/// <para>Specifies whether fields will be added if they don&apos;t exist.</para>
		/// <para>Unchecked—Fields will not be added. Fields specified must already exist in the Input Dataset parameter value. This is the default.</para>
		/// <para>Checked—Fields will be added if they do not exist. You must specify the names of the fields to add in the Creator Field, Creation Date Field, Last Editor Field, and Last Edit Date Field parameters.</para>
		/// <para><see cref="AddFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddFields { get; set; } = "false";

		/// <summary>
		/// <para>Record Dates in</para>
		/// <para>Specifies the time format in which the created date and last edited date will be recorded.</para>
		/// <para>UTC (Coordinated Universal Time)—Dates will be recorded in UTC. This is the default.</para>
		/// <para>Time zone of database—Dates will be recorded in the time zone in which the database is located.</para>
		/// <para><see cref="RecordDatesInEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RecordDatesIn { get; set; } = "UTC";

		/// <summary>
		/// <para>Modified Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEDatasetType()]
		public object? OutDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Add fields</para>
		/// </summary>
		public enum AddFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Fields will be added if they do not exist. You must specify the names of the fields to add in the Creator Field, Creation Date Field, Last Editor Field, and Last Edit Date Field parameters.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_FIELDS")]
			ADD_FIELDS,

			/// <summary>
			/// <para>Unchecked—Fields will not be added. Fields specified must already exist in the Input Dataset parameter value. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ADD_FIELDS")]
			NO_ADD_FIELDS,

		}

		/// <summary>
		/// <para>Record Dates in</para>
		/// </summary>
		public enum RecordDatesInEnum 
		{
			/// <summary>
			/// <para>UTC (Coordinated Universal Time)—Dates will be recorded in UTC. This is the default.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC (Coordinated Universal Time)")]
			UTC,

			/// <summary>
			/// <para>Time zone of database—Dates will be recorded in the time zone in which the database is located.</para>
			/// </summary>
			[GPValue("DATABASE_TIME")]
			[Description("Time zone of database")]
			Time_zone_of_database,

		}

#endregion
	}
}
