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
	/// <para>Write To Reviewer Table</para>
	/// <para>Writes a feature class, feature layer,  table, or table view to the Reviewer workspace.</para>
	/// </summary>
	public class WriteToReviewerTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InReviewerWorkspace">
		/// <para>Reviewer Workspace</para>
		/// <para>The path to the Reviewer workspace where the features or table records will be written.</para>
		/// </param>
		/// <param name="InSession">
		/// <para>Session</para>
		/// <para>The Reviewer session ID in which the features or table records will be written. Use the full session ID format: Session 1 : Session 1.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features or table records to write to the Reviewer workspace.</para>
		/// </param>
		/// <param name="InField">
		/// <para>ID Field</para>
		/// <para>The field that contains identifiers for the features. The value from this field populates the ID field in the Reviewer Results pane. The field you choose must have a data type of Long.</para>
		/// </param>
		/// <param name="InOriginTableName">
		/// <para>Origin Table Name (Value or Field)</para>
		/// <para>The string or field value that will be used to populate the Source field in the Reviewer Results pane for each record that is written. This is typically the name of the feature class or table.</para>
		/// <para>String—The name of the feature layer is defined as a text string.</para>
		/// <para>Field—The value for the feature layer name is derived from a field on the feature layer or table.</para>
		/// </param>
		/// <param name="InReviewStatus">
		/// <para>Review Status</para>
		/// <para>A status string to associate with the group of records written to the Reviewer workspace. The default value is Write GP Results to Reviewer Table.If the default value is deleted or left blank, the value Write GP Results to Reviewer Table will be used as the status string.</para>
		/// <para>String—You can type the value in the String text box.</para>
		/// <para>Field—You can choose the Review Status field from the feature layer.</para>
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
		/// <para>Tool Display Name : Write To Reviewer Table</para>
		/// </summary>
		public override string DisplayName() => "Write To Reviewer Table";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InReviewerWorkspace, InSession, InFeatures, InField, InOriginTableName, InReviewStatus, InSubtype!, InNotes!, InSeverity!, REVTABLEMAINView!, InCheckTitle! };

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>The path to the Reviewer workspace where the features or table records will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Session</para>
		/// <para>The Reviewer session ID in which the features or table records will be written. Use the full session ID format: Session 1 : Session 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InSession { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features or table records to write to the Reviewer workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>The field that contains identifiers for the features. The value from this field populates the ID field in the Reviewer Results pane. The field you choose must have a data type of Long.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Short", "Long", "OID")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Origin Table Name (Value or Field)</para>
		/// <para>The string or field value that will be used to populate the Source field in the Reviewer Results pane for each record that is written. This is typically the name of the feature class or table.</para>
		/// <para>String—The name of the feature layer is defined as a text string.</para>
		/// <para>Field—The value for the feature layer name is derived from a field on the feature layer or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InOriginTableName { get; set; }

		/// <summary>
		/// <para>Review Status</para>
		/// <para>A status string to associate with the group of records written to the Reviewer workspace. The default value is Write GP Results to Reviewer Table.If the default value is deleted or left blank, the value Write GP Results to Reviewer Table will be used as the status string.</para>
		/// <para>String—You can type the value in the String text box.</para>
		/// <para>Field—You can choose the Review Status field from the feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InReviewStatus { get; set; } = "Write GP Results to Reviewer Table";

		/// <summary>
		/// <para>Subtype</para>
		/// <para>The feature class subtype to which the features belong. This can be derived from a specified value or a field on the feature class. The value from this parameter populates the SUBTYPE field in the Reviewer Results pane.</para>
		/// <para>String—You can type the value in the String text box.</para>
		/// <para>Field—You can choose the Subtype value from a field on the feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? InSubtype { get; set; }

		/// <summary>
		/// <para>Notes</para>
		/// <para>Text that populates the Notes field in the Reviewer table. The notes are used to provide a more specific description of the feature or table record.</para>
		/// <para>String—You can type the value in the String text box.</para>
		/// <para>Field—You can choose the Notes value from a field on the feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? InNotes { get; set; }

		/// <summary>
		/// <para>Severity</para>
		/// <para>A numeric value that represents the significance of the features or table records that have been written to the Reviewer workspace. The values range from 5 (low importance) to 1 (high priority). This value populates the Severity field in the Reviewer Results pane.</para>
		/// <para>String—You can type the value in the String text box.</para>
		/// <para>Field—You can choose the Severity value from a field on the feature layer.</para>
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
		/// <para>Text that populates the Check Title field found in the Reviewer Results pane. Check Title is used to describe the error condition detected on the feature or table record.</para>
		/// <para>String—You can type the value in the String text box.</para>
		/// <para>Field—You can choose the Check Title value from a field on the feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? InCheckTitle { get; set; } = "Write GP Results to Reviewer Table";

	}
}
