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
	/// <para>Import BIM To Indoor Dataset</para>
	/// <para>Import BIM To Indoor Dataset</para>
	/// <para>Imports features from a BIM file into an indoor dataset that conforms to the ArcGIS Indoors Information Model. The output of this tool can be used to create floor-aware maps and scenes for use in floor-aware apps, as well as to generate an indoor network for routing.</para>
	/// </summary>
	public class ImportBIMToIndoorDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBimFloorplanLayer">
		/// <para>Input BIM Floorplan Polygon Layer</para>
		/// <para>The Floorplan_Polygon feature layer from the source BIM file that has been added to the current map.</para>
		/// </param>
		/// <param name="TargetUnitFeatures">
		/// <para>Target Unit Features</para>
		/// <para>The target Units feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Levels, and Details features.</para>
		/// </param>
		/// <param name="TargetDetailFeatures">
		/// <para>Target Detail Features</para>
		/// <para>The target Details feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Levels, and Units features.</para>
		/// </param>
		/// <param name="TargetLevelFeatures">
		/// <para>Target Level Features</para>
		/// <para>The target Levels feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Units, and Details features.</para>
		/// </param>
		/// <param name="TargetFacilityFeatures">
		/// <para>Target Facility Features</para>
		/// <para>The target Facilities feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Levels, Units, and Details features.</para>
		/// </param>
		/// <param name="FacilityId">
		/// <para>Facility ID</para>
		/// <para>The unique facility ID that will be assigned to the output Indoors features. The facility ID cannot contain spaces.</para>
		/// </param>
		/// <param name="FacilityName">
		/// <para>Facility Name</para>
		/// <para>The common name of the building.</para>
		/// </param>
		/// <param name="GroundFloorName">
		/// <para>Ground Floor Name</para>
		/// <para>The ground floor of the building. The vertical order of the levels is derived from this input. Any levels with an elevation that is less than the specified ground floor will be assigned a negative vertical order.</para>
		/// </param>
		public ImportBIMToIndoorDataset(object InBimFloorplanLayer, object TargetUnitFeatures, object TargetDetailFeatures, object TargetLevelFeatures, object TargetFacilityFeatures, object FacilityId, object FacilityName, object GroundFloorName)
		{
			this.InBimFloorplanLayer = InBimFloorplanLayer;
			this.TargetUnitFeatures = TargetUnitFeatures;
			this.TargetDetailFeatures = TargetDetailFeatures;
			this.TargetLevelFeatures = TargetLevelFeatures;
			this.TargetFacilityFeatures = TargetFacilityFeatures;
			this.FacilityId = FacilityId;
			this.FacilityName = FacilityName;
			this.GroundFloorName = GroundFloorName;
		}

		/// <summary>
		/// <para>Tool Display Name : Import BIM To Indoor Dataset</para>
		/// </summary>
		public override string DisplayName() => "Import BIM To Indoor Dataset";

		/// <summary>
		/// <para>Tool Name : ImportBIMToIndoorDataset</para>
		/// </summary>
		public override string ToolName() => "ImportBIMToIndoorDataset";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ImportBIMToIndoorDataset</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ImportBIMToIndoorDataset";

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
		public override object[] Parameters() => new object[] { InBimFloorplanLayer, TargetUnitFeatures, TargetDetailFeatures, TargetLevelFeatures, TargetFacilityFeatures, FacilityId, FacilityName, GroundFloorName, FloorplanPolygonUseTypeField!, FloorsToImport!, AreaUnitOfMeasure!, InBimRoomsLayer!, RoomPropertiesMapping!, AllowInsertNewFacility!, UpdatedUnits! };

		/// <summary>
		/// <para>Input BIM Floorplan Polygon Layer</para>
		/// <para>The Floorplan_Polygon feature layer from the source BIM file that has been added to the current map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InBimFloorplanLayer { get; set; }

		/// <summary>
		/// <para>Target Unit Features</para>
		/// <para>The target Units feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Levels, and Details features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object TargetUnitFeatures { get; set; }

		/// <summary>
		/// <para>Target Detail Features</para>
		/// <para>The target Details feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Levels, and Units features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object TargetDetailFeatures { get; set; }

		/// <summary>
		/// <para>Target Level Features</para>
		/// <para>The target Levels feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Units, and Details features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object TargetLevelFeatures { get; set; }

		/// <summary>
		/// <para>Target Facility Features</para>
		/// <para>The target Facilities feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Levels, Units, and Details features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object TargetFacilityFeatures { get; set; }

		/// <summary>
		/// <para>Facility ID</para>
		/// <para>The unique facility ID that will be assigned to the output Indoors features. The facility ID cannot contain spaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FacilityId { get; set; }

		/// <summary>
		/// <para>Facility Name</para>
		/// <para>The common name of the building.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FacilityName { get; set; }

		/// <summary>
		/// <para>Ground Floor Name</para>
		/// <para>The ground floor of the building. The vertical order of the levels is derived from this input. Any levels with an elevation that is less than the specified ground floor will be assigned a negative vertical order.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GroundFloorName { get; set; }

		/// <summary>
		/// <para>Floorplan Polygon Use Type Field</para>
		/// <para>The field from the Floorplan_Polygon feature layer that will be used to populate the USE_TYPE field for the target unit features. If no field is provided, the RoomName field value from the Floorplan_Polygon layer will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FloorplanPolygonUseTypeField { get; set; }

		/// <summary>
		/// <para>Floors To Import</para>
		/// <para>The floors in the input BIM file that will be imported to the target features. If no floors are provided, all floors will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? FloorsToImport { get; set; }

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// <para>Specifies the unit of measure that will be used for the area fields in the Levels and Units feature classes.</para>
		/// <para>Square Meters—The area unit will be square meters.</para>
		/// <para>Square Feet—The area unit will be square feet. This is the default.</para>
		/// <para><see cref="AreaUnitOfMeasureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnitOfMeasure { get; set; } = "SQUARE_FEET";

		/// <summary>
		/// <para>Input BIM Rooms Layer</para>
		/// <para>The Rooms layer from the Architectural dataset in the input BIM file. This layer will be used to obtain extended field values that can be mapped to existing fields in the Units feature class using the Room Properties Mapping parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object? InBimRoomsLayer { get; set; }

		/// <summary>
		/// <para>Room Properties Mapping</para>
		/// <para>Controls which attribute fields in the Units feature class will be populated with field values from the input BIM Rooms layer. The fields must exist before running the tool. It is recommended that you map fields from the input BIM Rooms layer to fields from the Units feature class that have the same field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? RoomPropertiesMapping { get; set; }

		/// <summary>
		/// <para>Allow insert of new overlapping facility</para>
		/// <para>Specifies whether a building from the input BIM file will be imported if an intersection is detected between that building&apos;s floor plan and an existing Facilities feature in the target facility features.</para>
		/// <para>Unchecked—The tool tests whether the input BIM floorplan polygon intersects any existing facility polygon in the target features. If an intersection is detected, the tool checks whether the specified Facility ID and Facility Name parameter values match the FACILITY_ID and NAME field values of the intersecting Facilities feature. If the values match, the tool updates the existing facility. If the values do not match, the tool issues a message and stops running. This is the default.</para>
		/// <para>Checked—The tool does not test whether the input BIM floorplan polygon intersects any existing facility polygon in the target facility features. You can use this option to import a building that overlaps or touches an existing facility.</para>
		/// <para><see cref="AllowInsertNewFacilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowInsertNewFacility { get; set; } = "false";

		/// <summary>
		/// <para>Updated Units</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedUnits { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportBIMToIndoorDataset SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// </summary>
		public enum AreaUnitOfMeasureEnum 
		{
			/// <summary>
			/// <para>Square Meters—The area unit will be square meters.</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("Square Meters")]
			Square_Meters,

			/// <summary>
			/// <para>Square Feet—The area unit will be square feet. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("Square Feet")]
			Square_Feet,

		}

		/// <summary>
		/// <para>Allow insert of new overlapping facility</para>
		/// </summary>
		public enum AllowInsertNewFacilityEnum 
		{
			/// <summary>
			/// <para>Unchecked—The tool tests whether the input BIM floorplan polygon intersects any existing facility polygon in the target features. If an intersection is detected, the tool checks whether the specified Facility ID and Facility Name parameter values match the FACILITY_ID and NAME field values of the intersecting Facilities feature. If the values match, the tool updates the existing facility. If the values do not match, the tool issues a message and stops running. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ALLOW_INSERT_NEW_FACILITY")]
			NO_ALLOW_INSERT_NEW_FACILITY,

			/// <summary>
			/// <para>Checked—The tool does not test whether the input BIM floorplan polygon intersects any existing facility polygon in the target facility features. You can use this option to import a building that overlaps or touches an existing facility.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOW_INSERT_NEW_FACILITY")]
			ALLOW_INSERT_NEW_FACILITY,

		}

#endregion
	}
}
