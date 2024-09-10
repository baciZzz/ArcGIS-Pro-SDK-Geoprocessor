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
	/// <para>Create LRS From Existing Dataset</para>
	/// <para>Creates a linear referencing system (LRS) in the specified workspace using existing datasets.</para>
	/// </summary>
	public class CreateLRSFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>The name of the LRS to create. The name for the LRS cannot already exist in the geodatabase.</para>
		/// </param>
		/// <param name="CenterlineFeatureClass">
		/// <para>Centerline - Feature Class</para>
		/// <para>The feature class to be used as the centerline in the LRS.</para>
		/// </param>
		/// <param name="CenterlineCenterlineIdField">
		/// <para>Centerline - Centerline ID Field</para>
		/// <para>The GUID field containing the centerline ID. The field type must match the centerlineID field type in the centerline sequence table.</para>
		/// </param>
		/// <param name="CenterlineSequenceTable">
		/// <para>Centerline Sequence - Table</para>
		/// <para>The table to be used as the centerline sequence in the LRS.</para>
		/// </param>
		/// <param name="CenterlineSequenceCenterlineIdField">
		/// <para>Centerline Sequence - Centerline ID Field</para>
		/// <para>The GUID field containing the centerline sequence ID. The field type must match the centerlineID field type and length in the centerline feature class.</para>
		/// </param>
		/// <param name="CenterlineSequenceRouteIdField">
		/// <para>Centerline Sequence - Route ID Field</para>
		/// <para>The GUID or text field containing the centerline sequence route ID. The field type must match the routeID field type and length in the calibration point and redline feature classes.</para>
		/// </param>
		/// <param name="CenterlineSequenceFromDateField">
		/// <para>Centerline Sequence - From Date Field</para>
		/// <para>A date field containing the centerline sequence from date.</para>
		/// </param>
		/// <param name="CenterlineSequenceToDateField">
		/// <para>Centerline Sequence - To Date Field</para>
		/// <para>A date field containing the centerline sequence to date.</para>
		/// </param>
		/// <param name="CenterlineSequenceNetworkIdField">
		/// <para>Centerline Sequence - Network ID Field</para>
		/// <para>The field containing the centerline sequence network ID. The short integer field type is supported.</para>
		/// </param>
		/// <param name="CalibrationPointFeatureClass">
		/// <para>Calibration Point - Feature Class</para>
		/// <para>The feature class to be used as the calibration point in the LRS.</para>
		/// </param>
		/// <param name="CalibrationPointMeasureField">
		/// <para>Calibration Point - Measure Field</para>
		/// <para>The field containing the calibration point measure. The double field type is supported.</para>
		/// </param>
		/// <param name="CalibrationPointFromDateField">
		/// <para>Calibration Point - From Date Field</para>
		/// <para>A date field containing the calibration point from date.</para>
		/// </param>
		/// <param name="CalibrationPointToDateField">
		/// <para>Calibration Point - To Date Field</para>
		/// <para>A date field containing the calibration point to date.</para>
		/// </param>
		/// <param name="CalibrationPointRouteIdField">
		/// <para>Calibration Point - Route ID Field</para>
		/// <para>The field containing the calibration point route ID. GUID and text field types are supported. The field type must match the routeID field type and length in the centerline sequence table and Redline feature class.</para>
		/// </param>
		/// <param name="CalibrationPointNetworkIdField">
		/// <para>Calibration Point - Network ID Field</para>
		/// <para>The field containing the calibration point network ID. The short integer field type is supported.</para>
		/// </param>
		/// <param name="RedlineFeatureClass">
		/// <para>Redline - Feature Class</para>
		/// <para>The feature class to be used as the redline in the LRS.</para>
		/// </param>
		/// <param name="RedlineFromMeasureField">
		/// <para>Redline - From Measure Field</para>
		/// <para>The field containing the redline from measure. The double field type is supported.</para>
		/// </param>
		/// <param name="RedlineToMeasureField">
		/// <para>Redline - To Measure Field</para>
		/// <para>The field containing the redline to measure. The double field type is supported.</para>
		/// </param>
		/// <param name="RedlineRouteIdField">
		/// <para>Redline - Route ID Field</para>
		/// <para>The field containing the redline route ID. GUID and text field types are supported. The field type must match the routeID field type and length in the calibration point feature class and centerline sequence table.</para>
		/// </param>
		/// <param name="RedlineRouteNameField">
		/// <para>Redline - Route Name Field</para>
		/// <para>A text field containing the redline route name.</para>
		/// </param>
		/// <param name="RedlineEffectiveDateField">
		/// <para>Redline - Effective Date Field</para>
		/// <para>A date field containing the redline effective date.</para>
		/// </param>
		/// <param name="RedlineActivityTypeField">
		/// <para>Redline - Activity Type Field</para>
		/// <para>The field containing the redline activity type. The short integer field type is supported.</para>
		/// </param>
		/// <param name="RedlineNetworkIdField">
		/// <para>Redline - Network ID Field</para>
		/// <para>The field containing the redline network ID. The short integer field type is supported.</para>
		/// </param>
		public CreateLRSFromExistingDataset(object LrsName, object CenterlineFeatureClass, object CenterlineCenterlineIdField, object CenterlineSequenceTable, object CenterlineSequenceCenterlineIdField, object CenterlineSequenceRouteIdField, object CenterlineSequenceFromDateField, object CenterlineSequenceToDateField, object CenterlineSequenceNetworkIdField, object CalibrationPointFeatureClass, object CalibrationPointMeasureField, object CalibrationPointFromDateField, object CalibrationPointToDateField, object CalibrationPointRouteIdField, object CalibrationPointNetworkIdField, object RedlineFeatureClass, object RedlineFromMeasureField, object RedlineToMeasureField, object RedlineRouteIdField, object RedlineRouteNameField, object RedlineEffectiveDateField, object RedlineActivityTypeField, object RedlineNetworkIdField)
		{
			this.LrsName = LrsName;
			this.CenterlineFeatureClass = CenterlineFeatureClass;
			this.CenterlineCenterlineIdField = CenterlineCenterlineIdField;
			this.CenterlineSequenceTable = CenterlineSequenceTable;
			this.CenterlineSequenceCenterlineIdField = CenterlineSequenceCenterlineIdField;
			this.CenterlineSequenceRouteIdField = CenterlineSequenceRouteIdField;
			this.CenterlineSequenceFromDateField = CenterlineSequenceFromDateField;
			this.CenterlineSequenceToDateField = CenterlineSequenceToDateField;
			this.CenterlineSequenceNetworkIdField = CenterlineSequenceNetworkIdField;
			this.CalibrationPointFeatureClass = CalibrationPointFeatureClass;
			this.CalibrationPointMeasureField = CalibrationPointMeasureField;
			this.CalibrationPointFromDateField = CalibrationPointFromDateField;
			this.CalibrationPointToDateField = CalibrationPointToDateField;
			this.CalibrationPointRouteIdField = CalibrationPointRouteIdField;
			this.CalibrationPointNetworkIdField = CalibrationPointNetworkIdField;
			this.RedlineFeatureClass = RedlineFeatureClass;
			this.RedlineFromMeasureField = RedlineFromMeasureField;
			this.RedlineToMeasureField = RedlineToMeasureField;
			this.RedlineRouteIdField = RedlineRouteIdField;
			this.RedlineRouteNameField = RedlineRouteNameField;
			this.RedlineEffectiveDateField = RedlineEffectiveDateField;
			this.RedlineActivityTypeField = RedlineActivityTypeField;
			this.RedlineNetworkIdField = RedlineNetworkIdField;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS From Existing Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create LRS From Existing Dataset";

		/// <summary>
		/// <para>Tool Name : CreateLRSFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSFromExistingDataset";

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
		public override object[] Parameters() => new object[] { LrsName, CenterlineFeatureClass, CenterlineCenterlineIdField, CenterlineSequenceTable, CenterlineSequenceCenterlineIdField, CenterlineSequenceRouteIdField, CenterlineSequenceFromDateField, CenterlineSequenceToDateField, CenterlineSequenceNetworkIdField, CalibrationPointFeatureClass, CalibrationPointMeasureField, CalibrationPointFromDateField, CalibrationPointToDateField, CalibrationPointRouteIdField, CalibrationPointNetworkIdField, RedlineFeatureClass, RedlineFromMeasureField, RedlineToMeasureField, RedlineRouteIdField, RedlineRouteNameField, RedlineEffectiveDateField, RedlineActivityTypeField, RedlineNetworkIdField, OutPath };

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>The name of the LRS to create. The name for the LRS cannot already exist in the geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>Centerline - Feature Class</para>
		/// <para>The feature class to be used as the centerline in the LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Centerline")]
		public object CenterlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Centerline - Centerline ID Field</para>
		/// <para>The GUID field containing the centerline ID. The field type must match the centerlineID field type in the centerline sequence table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline")]
		public object CenterlineCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Table</para>
		/// <para>The table to be used as the centerline sequence in the LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceTable { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Centerline ID Field</para>
		/// <para>The GUID field containing the centerline sequence ID. The field type must match the centerlineID field type and length in the centerline feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Route ID Field</para>
		/// <para>The GUID or text field containing the centerline sequence route ID. The field type must match the routeID field type and length in the calibration point and redline feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceRouteIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - From Date Field</para>
		/// <para>A date field containing the centerline sequence from date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceFromDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - To Date Field</para>
		/// <para>A date field containing the centerline sequence to date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceToDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Network ID Field</para>
		/// <para>The field containing the centerline sequence network ID. The short integer field type is supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceNetworkIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Feature Class</para>
		/// <para>The feature class to be used as the calibration point in the LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[Category("Calibration Point")]
		public object CalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibration Point - Measure Field</para>
		/// <para>The field containing the calibration point measure. The double field type is supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Calibration Point")]
		public object CalibrationPointMeasureField { get; set; }

		/// <summary>
		/// <para>Calibration Point - From Date Field</para>
		/// <para>A date field containing the calibration point from date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object CalibrationPointFromDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - To Date Field</para>
		/// <para>A date field containing the calibration point to date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object CalibrationPointToDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Route ID Field</para>
		/// <para>The field containing the calibration point route ID. GUID and text field types are supported. The field type must match the routeID field type and length in the centerline sequence table and Redline feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Calibration Point")]
		public object CalibrationPointRouteIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Network ID Field</para>
		/// <para>The field containing the calibration point network ID. The short integer field type is supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Calibration Point")]
		public object CalibrationPointNetworkIdField { get; set; }

		/// <summary>
		/// <para>Redline - Feature Class</para>
		/// <para>The feature class to be used as the redline in the LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Redline")]
		public object RedlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Redline - From Measure Field</para>
		/// <para>The field containing the redline from measure. The double field type is supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object RedlineFromMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - To Measure Field</para>
		/// <para>The field containing the redline to measure. The double field type is supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object RedlineToMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - Route ID Field</para>
		/// <para>The field containing the redline route ID. GUID and text field types are supported. The field type must match the routeID field type and length in the calibration point feature class and centerline sequence table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Redline")]
		public object RedlineRouteIdField { get; set; }

		/// <summary>
		/// <para>Redline - Route Name Field</para>
		/// <para>A text field containing the redline route name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		[Category("Redline")]
		public object RedlineRouteNameField { get; set; }

		/// <summary>
		/// <para>Redline - Effective Date Field</para>
		/// <para>A date field containing the redline effective date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Redline")]
		public object RedlineEffectiveDateField { get; set; }

		/// <summary>
		/// <para>Redline - Activity Type Field</para>
		/// <para>The field containing the redline activity type. The short integer field type is supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object RedlineActivityTypeField { get; set; }

		/// <summary>
		/// <para>Redline - Network ID Field</para>
		/// <para>The field containing the redline network ID. The short integer field type is supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object RedlineNetworkIdField { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRSFromExistingDataset SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
