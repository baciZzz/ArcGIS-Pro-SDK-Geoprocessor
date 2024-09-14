using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Update Occupant Features</para>
	/// <para>Update Occupant Features</para>
	/// <para>Updates the Occupants feature class that conforms to the ArcGIS Indoors Information Model.</para>
	/// </summary>
	public class UpdateOccupantFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetOccupantFeatures">
		/// <para>Target Occupant Features</para>
		/// <para>The target feature layer, feature class, or feature service to which occupant records will be added, updated, or deleted. The input must contain unique values that identify each occupant and must conform to the Occupants feature class in the Indoors model.</para>
		/// </param>
		public UpdateOccupantFeatures(object TargetOccupantFeatures)
		{
			this.TargetOccupantFeatures = TargetOccupantFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Occupant Features</para>
		/// </summary>
		public override string DisplayName() => "Update Occupant Features";

		/// <summary>
		/// <para>Tool Name : UpdateOccupantFeatures</para>
		/// </summary>
		public override string ToolName() => "UpdateOccupantFeatures";

		/// <summary>
		/// <para>Tool Excute Name : indoors.UpdateOccupantFeatures</para>
		/// </summary>
		public override string ExcuteName() => "indoors.UpdateOccupantFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetOccupantFeatures, InUnitFeatures!, InOccupantTable!, OccupantIdFromTargetOccupantFeatures!, OccupantIdFromInputTable!, UnitIdFromUnitsFeatures!, UnitIdFromInputTable!, OccupantAttributesMapping!, AllowInsert!, AllowDelete!, UpdatedOccupantFeatures! };

		/// <summary>
		/// <para>Target Occupant Features</para>
		/// <para>The target feature layer, feature class, or feature service to which occupant records will be added, updated, or deleted. The input must contain unique values that identify each occupant and must conform to the Occupants feature class in the Indoors model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object TargetOccupantFeatures { get; set; }

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing building spaces that may be occupied. In the ArcGIS Indoors Information Model, this is the Units layer. The centroid of each space will be used as the point location of the occupant or occupants.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Input Occupant Table</para>
		/// <para>The input table that contains information about building occupants.</para>
		/// <para>The information can be stored in a geodatabase table, a sheet in an Excel workbook (.xls or .xlsx file), or a .csv file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InOccupantTable { get; set; }

		/// <summary>
		/// <para>Occupant Identifier (Target Occupant Features)</para>
		/// <para>The field in the Target Occupant Features parameter value that will be used as the primary key to associate occupants with the Input Occupant Table parameter values. The field values must be unique.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID", "Double")]
		public object? OccupantIdFromTargetOccupantFeatures { get; set; }

		/// <summary>
		/// <para>Occupant Identifier (Input Occupant Table)</para>
		/// <para>The field in the Input Occupant Table parameter value that will be used as the primary key to associate occupants with the Target Occupant Features parameter values. The field values must be unique.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID", "Double")]
		public object? OccupantIdFromInputTable { get; set; }

		/// <summary>
		/// <para>Unit Identifier (Input Units Features)</para>
		/// <para>The field in the Input Unit Features parameter value that stores the unique space identification information that will match the unit identifier from the Input Occupant Table parameter value. The field values must be unique.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID")]
		public object? UnitIdFromUnitsFeatures { get; set; }

		/// <summary>
		/// <para>Unit Identifier (Input Occupant Table)</para>
		/// <para>The field in the Input Occupant Table parameter value that will be used as the primary key to associate occupant space assignment with the Input Unit Features parameter values. If a field value is empty, the occupant will be loaded as unassigned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID")]
		public object? UnitIdFromInputTable { get; set; }

		/// <summary>
		/// <para>Occupant Attributes Mapping</para>
		/// <para>The attribute fields in the Target Occupant Features parameter that will be populated with field values from the Input Occupant Table parameter value. The fields must exist in the Target Occupant Features parameter value before running the tool. It is recommended that you map fields from the Input Occupant Table parameter value to fields from the Target Occupant Features parameter value that have the same field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? OccupantAttributesMapping { get; set; }

		/// <summary>
		/// <para>Insert new occupants</para>
		/// <para>Specifies whether unique occupant records for the Input Occupant Table parameter value will be added to the target occupant features layer.</para>
		/// <para>Checked—Unmatched occupant records will be added to the target occupant features layer. This is the default.</para>
		/// <para>Unchecked—Unmatched occupant records will not be added to the target occupant features layer.</para>
		/// <para><see cref="AllowInsertEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowInsert { get; set; } = "true";

		/// <summary>
		/// <para>Delete occupants not included in the Input Occupant Table</para>
		/// <para>Specifies whether unique occupant records for the Input Occupant Table parameter value will be deleted from the target occupant features layer.</para>
		/// <para>Checked—Unmatched occupant records will be deleted from the target occupant features layer. This is the default.</para>
		/// <para>Unchecked—Unmatched occupant records will not be deleted from the target occupant features layer.</para>
		/// <para><see cref="AllowDeleteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowDelete { get; set; } = "true";

		/// <summary>
		/// <para>Updated Occupant Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedOccupantFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateOccupantFeatures SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Insert new occupants</para>
		/// </summary>
		public enum AllowInsertEnum 
		{
			/// <summary>
			/// <para>Checked—Unmatched occupant records will be added to the target occupant features layer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INSERT_OCCUPANTS")]
			INSERT_OCCUPANTS,

			/// <summary>
			/// <para>Unchecked—Unmatched occupant records will not be added to the target occupant features layer.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INSERT_OCCUPANTS")]
			NO_INSERT_OCCUPANTS,

		}

		/// <summary>
		/// <para>Delete occupants not included in the Input Occupant Table</para>
		/// </summary>
		public enum AllowDeleteEnum 
		{
			/// <summary>
			/// <para>Checked—Unmatched occupant records will be deleted from the target occupant features layer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_OCCUPANTS")]
			DELETE_OCCUPANTS,

			/// <summary>
			/// <para>Unchecked—Unmatched occupant records will not be deleted from the target occupant features layer.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_OCCUPANTS")]
			NO_DELETE_OCCUPANTS,

		}

#endregion
	}
}
