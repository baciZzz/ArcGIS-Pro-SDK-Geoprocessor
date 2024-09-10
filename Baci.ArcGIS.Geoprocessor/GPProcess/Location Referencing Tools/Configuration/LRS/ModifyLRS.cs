using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Modify LRS</para>
	/// <para>Modifies an existing linear referencing system (LRS) in the specified workspace.</para>
	/// </summary>
	public class ModifyLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The LRS workspace.</para>
		/// </param>
		/// <param name="CurrentLrsName">
		/// <para>Current LRS Name</para>
		/// <para>The name of the current LRS.</para>
		/// </param>
		public ModifyLRS(object InWorkspace, object CurrentLrsName)
		{
			this.InWorkspace = InWorkspace;
			this.CurrentLrsName = CurrentLrsName;
		}

		/// <summary>
		/// <para>Tool Display Name : Modify LRS</para>
		/// </summary>
		public override string DisplayName() => "Modify LRS";

		/// <summary>
		/// <para>Tool Name : ModifyLRS</para>
		/// </summary>
		public override string ToolName() => "ModifyLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRS";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, CurrentLrsName, NewLrsName, CenterlineFeatureClass, CenterlineCenterlineIdField, CenterlineSequenceTable, CenterlineSequenceCenterlineIdField, CenterlineSequenceRouteIdField, CenterlineSequenceFromDateField, CenterlineSequenceToDateField, CenterlineSequenceNetworkIdField, CalibrationPointFeatureClass, CalibrationPointMeasureField, CalibrationPointFromDateField, CalibrationPointToDateField, CalibrationPointRouteIdField, CalibrationPointNetworkIdField, RedlineFeatureClass, RedlineFromMeasureField, RedlineToMeasureField, RedlineRouteIdField, RedlineRouteNameField, RedlineEffectiveDateField, RedlineActivityTypeField, RedlineNetworkIdField, OutWorkspace, ConflictPrevention };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The LRS workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Current LRS Name</para>
		/// <para>The name of the current LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CurrentLrsName { get; set; }

		/// <summary>
		/// <para>New LRS Name</para>
		/// <para>The new name of the current LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewLrsName { get; set; }

		/// <summary>
		/// <para>Centerline - Feature Class</para>
		/// <para>An existing centerline feature class for the minimum schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Centerline")]
		public object CenterlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Centerline - Centerline ID Field</para>
		/// <para>The name of the centerline ID field from the existing centerline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline")]
		public object CenterlineCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Table</para>
		/// <para>An existing centerline sequence table for the minimum schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceTable { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Centerline ID Field</para>
		/// <para>The name of the centerline ID field from the existing centerline sequence table that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Route ID Field</para>
		/// <para>The name of the route ID field from the existing centerline sequence table that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceRouteIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - From Date Field</para>
		/// <para>The name of the from date field from the existing centerline sequence table that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceFromDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - To Date Field</para>
		/// <para>The name of the to date field from the existing centerline sequence table that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceToDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Network ID Field</para>
		/// <para>The name of the network ID field from the existing centerline sequence table that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceNetworkIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Feature Class</para>
		/// <para>An existing calibration point feature class for the minimum schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[Category("Calibration Point")]
		public object CalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibration Point - Measure Field</para>
		/// <para>The name of the measure field from the existing calibration point feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Calibration Point")]
		public object CalibrationPointMeasureField { get; set; }

		/// <summary>
		/// <para>Calibration Point - From Date Field</para>
		/// <para>The name of the from date field from the existing calibration point feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object CalibrationPointFromDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - To Date Field</para>
		/// <para>The name of the to date field from the existing calibration point feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object CalibrationPointToDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Route ID Field</para>
		/// <para>The name of the route ID field from the existing calibration point feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Calibration Point")]
		public object CalibrationPointRouteIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Network ID Field</para>
		/// <para>The name of the network ID field from the existing calibration point feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Calibration Point")]
		public object CalibrationPointNetworkIdField { get; set; }

		/// <summary>
		/// <para>Redline - Feature Class</para>
		/// <para>An existing redline feature class for the minimum schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Redline")]
		public object RedlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Redline - From Measure Field</para>
		/// <para>The name of the from measure field from the existing redline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object RedlineFromMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - To  Measure Field</para>
		/// <para>The name of the to measure field from the existing redline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object RedlineToMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - Route ID Field</para>
		/// <para>The name of the route ID field from the existing redline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Redline")]
		public object RedlineRouteIdField { get; set; }

		/// <summary>
		/// <para>Redline - Route Name Field</para>
		/// <para>The name of the route name field from the existing redline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		[Category("Redline")]
		public object RedlineRouteNameField { get; set; }

		/// <summary>
		/// <para>Redline - Effective Date Field</para>
		/// <para>The name of the effective date field from the existing redline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Redline")]
		public object RedlineEffectiveDateField { get; set; }

		/// <summary>
		/// <para>Redline - Activity Type Field</para>
		/// <para>The name of the activity type field from the existing redline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object RedlineActivityTypeField { get; set; }

		/// <summary>
		/// <para>Redline - Network ID Field</para>
		/// <para>The name of the network ID field from the existing redline feature class that was chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object RedlineNetworkIdField { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Conflict Prevention</para>
		/// <para>Specifies whether conflict prevention will be enabled for the input LRS. Conflict prevention is only available when editing or performing geoprocessing on branch versioned data that is published as a feature service.</para>
		/// <para>As is—The current conflict prevention setting will be used. This is the default.</para>
		/// <para>Enable—Conflict prevention will be enabled for the input LRS.</para>
		/// <para>Disable—Conflict prevention will be disabled for the input LRS.</para>
		/// <para><see cref="ConflictPreventionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictPrevention { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyLRS SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conflict Prevention</para>
		/// </summary>
		public enum ConflictPreventionEnum 
		{
			/// <summary>
			/// <para>As is—The current conflict prevention setting will be used. This is the default.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para>Enable—Conflict prevention will be enabled for the input LRS.</para>
			/// </summary>
			[GPValue("ENABLE")]
			[Description("Enable")]
			Enable,

			/// <summary>
			/// <para>Disable—Conflict prevention will be disabled for the input LRS.</para>
			/// </summary>
			[GPValue("DISABLE")]
			[Description("Disable")]
			Disable,

		}

#endregion
	}
}
