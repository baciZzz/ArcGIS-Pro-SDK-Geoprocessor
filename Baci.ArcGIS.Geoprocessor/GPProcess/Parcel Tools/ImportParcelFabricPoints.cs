using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Import Parcel Fabric Points</para>
	/// <para>Import Parcel Fabric Points</para>
	/// <para>Imports point data from a source point feature class into the parcel fabric points feature class. Parcel fabric points that match or lie within a proximity tolerance of the source points will be updated with the imported point data. If the source points layer has a selection, only the selected point information will be imported.</para>
	/// </summary>
	public class ImportParcelFabricPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourcePoints">
		/// <para>Source Points</para>
		/// <para>The source point feature class that will be used to create or update points in the target parcel fabric.</para>
		/// </param>
		/// <param name="TargetParcelFabric">
		/// <para>Target Parcel Fabric</para>
		/// <para>The target parcel fabric in which points will be updated or created. The target parcel fabric can be from a file geodatabase, an enterprise geodatabase connected to the default version, a mobile geodatabase, or a feature service.</para>
		/// </param>
		/// <param name="MatchPointMethod">
		/// <para>Match Point Method</para>
		/// <para>Specifies the method that will be used to find existing parcel fabric points that match the source points.</para>
		/// <para>Proximity—Parcel fabric points that lie within the proximity tolerance of the source points will be matched to the source points and updated. This is the default.</para>
		/// <para>Name and proximity— Parcel fabric points that lie within the proximity tolerance and have the same name as the source points will be matched to the source points and updated.</para>
		/// <para>Global ID and proximity—Parcel fabric points that lie within the proximity tolerance and have the same Global ID as the source points will be matched to the source points and updated. Global IDs are stored in the Global ID field of the parcel fabric points feature class and in a specified Global ID field of the source feature class.</para>
		/// <para><see cref="MatchPointMethodEnum"/></para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance that will be used to search for parcel fabric points that lie within the proximity of the source points.</para>
		/// </param>
		/// <param name="UpdateType">
		/// <para>Update Type</para>
		/// <para>Specifies the type of update that will be applied to parcel fabric points that match source points.</para>
		/// <para>All—The geometry (x,y,z) and matching attribute fields of parcel fabric points will be updated. If the geometry of parcel fabric points is updated, coincident parcel features will be updated as well. This is the default.</para>
		/// <para>Geometry (x,y,z)— Only the geometry (x,y,z) of the parcel fabric points will be updated. Coincident parcel features will be updated as well.</para>
		/// <para>Retire and replace—Source points will be imported as new parcel fabric points. Any matching parcel fabric points will be retired as historic. The Retired By Record field of each matching parcel fabric point will be populated with the Global ID of the record specified in the Record Name parameter.</para>
		/// <para><see cref="UpdateTypeEnum"/></para>
		/// </param>
		public ImportParcelFabricPoints(object SourcePoints, object TargetParcelFabric, object MatchPointMethod, object SearchDistance, object UpdateType)
		{
			this.SourcePoints = SourcePoints;
			this.TargetParcelFabric = TargetParcelFabric;
			this.MatchPointMethod = MatchPointMethod;
			this.SearchDistance = SearchDistance;
			this.UpdateType = UpdateType;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Parcel Fabric Points</para>
		/// </summary>
		public override string DisplayName() => "Import Parcel Fabric Points";

		/// <summary>
		/// <para>Tool Name : ImportParcelFabricPoints</para>
		/// </summary>
		public override string ToolName() => "ImportParcelFabricPoints";

		/// <summary>
		/// <para>Tool Excute Name : parcel.ImportParcelFabricPoints</para>
		/// </summary>
		public override string ExcuteName() => "parcel.ImportParcelFabricPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SourcePoints, TargetParcelFabric, MatchPointMethod, SearchDistance, UpdateType, UpdatedParcelFabric!, RecordName!, MatchField!, ConflictsTable!, UpdateCreateOption! };

		/// <summary>
		/// <para>Source Points</para>
		/// <para>The source point feature class that will be used to create or update points in the target parcel fabric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object SourcePoints { get; set; }

		/// <summary>
		/// <para>Target Parcel Fabric</para>
		/// <para>The target parcel fabric in which points will be updated or created. The target parcel fabric can be from a file geodatabase, an enterprise geodatabase connected to the default version, a mobile geodatabase, or a feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object TargetParcelFabric { get; set; }

		/// <summary>
		/// <para>Match Point Method</para>
		/// <para>Specifies the method that will be used to find existing parcel fabric points that match the source points.</para>
		/// <para>Proximity—Parcel fabric points that lie within the proximity tolerance of the source points will be matched to the source points and updated. This is the default.</para>
		/// <para>Name and proximity— Parcel fabric points that lie within the proximity tolerance and have the same name as the source points will be matched to the source points and updated.</para>
		/// <para>Global ID and proximity—Parcel fabric points that lie within the proximity tolerance and have the same Global ID as the source points will be matched to the source points and updated. Global IDs are stored in the Global ID field of the parcel fabric points feature class and in a specified Global ID field of the source feature class.</para>
		/// <para><see cref="MatchPointMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MatchPointMethod { get; set; } = "PROXIMITY";

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance that will be used to search for parcel fabric points that lie within the proximity of the source points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "0.1 Meters";

		/// <summary>
		/// <para>Update Type</para>
		/// <para>Specifies the type of update that will be applied to parcel fabric points that match source points.</para>
		/// <para>All—The geometry (x,y,z) and matching attribute fields of parcel fabric points will be updated. If the geometry of parcel fabric points is updated, coincident parcel features will be updated as well. This is the default.</para>
		/// <para>Geometry (x,y,z)— Only the geometry (x,y,z) of the parcel fabric points will be updated. Coincident parcel features will be updated as well.</para>
		/// <para>Retire and replace—Source points will be imported as new parcel fabric points. Any matching parcel fabric points will be retired as historic. The Retired By Record field of each matching parcel fabric point will be populated with the Global ID of the record specified in the Record Name parameter.</para>
		/// <para><see cref="UpdateTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateType { get; set; } = "ALL";

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPParcelLayer()]
		public object? UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Record Name</para>
		/// <para>The name of the record that will be associated with the new imported points.</para>
		/// <para>If the record exists in the target parcel fabric, the new points will be associated with the record. If the record does not exist, a record will be created. If new points replace existing points, and Update Type is set to Retire and replace, the record will be used to retire the points as historic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RecordName { get; set; }

		/// <summary>
		/// <para>Match Field</para>
		/// <para>The field that will be used to match source points to parcel fabric points when Name and proximity or Global ID and proximity is used for the Match Point Method parameter. When searching by name, the field in the source point feature class should be of type Text. When searching by Global ID, the field in the source point feature class should be of type GUID.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GlobalID", "GUID")]
		public object? MatchField { get; set; }

		/// <summary>
		/// <para>Conflicts Table</para>
		/// <para>The path and name of the output table that will store conflicts. If more than one parcel fabric point is found within the search tolerance of a source point, the Object IDs of the source points and parcel fabric points will be reported in the conflicts table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? ConflictsTable { get; set; }

		/// <summary>
		/// <para>Update And Create Options</para>
		/// <para>Specifies whether points will be updated, created, or both.</para>
		/// <para>Update matched and create unmatched—Points will be created if no matching points are found using the search criteria. If matching points are found using the search criteria, they will be updated. This is the default.</para>
		/// <para>Only create unmatched—Points will be created only if no matching points are found using the search criteria. If matching points are found using the search criteria, they will remain unchanged and no points will be created.</para>
		/// <para>Only update matched—Points will be updated if matching points are found using the search criteria. If no matching points are found, points will not be created.</para>
		/// <para><see cref="UpdateCreateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? UpdateCreateOption { get; set; } = "UPDATE_AND_CREATE";

		#region InnerClass

		/// <summary>
		/// <para>Match Point Method</para>
		/// </summary>
		public enum MatchPointMethodEnum 
		{
			/// <summary>
			/// <para>Proximity—Parcel fabric points that lie within the proximity tolerance of the source points will be matched to the source points and updated. This is the default.</para>
			/// </summary>
			[GPValue("PROXIMITY")]
			[Description("Proximity")]
			Proximity,

			/// <summary>
			/// <para>Name and proximity— Parcel fabric points that lie within the proximity tolerance and have the same name as the source points will be matched to the source points and updated.</para>
			/// </summary>
			[GPValue("NAME_AND_PROXIMITY")]
			[Description("Name and proximity")]
			Name_and_proximity,

			/// <summary>
			/// <para>Global ID and proximity—Parcel fabric points that lie within the proximity tolerance and have the same Global ID as the source points will be matched to the source points and updated. Global IDs are stored in the Global ID field of the parcel fabric points feature class and in a specified Global ID field of the source feature class.</para>
			/// </summary>
			[GPValue("GLOBALID_AND_PROXIMITY")]
			[Description("Global ID and proximity")]
			Global_ID_and_proximity,

		}

		/// <summary>
		/// <para>Update Type</para>
		/// </summary>
		public enum UpdateTypeEnum 
		{
			/// <summary>
			/// <para>All—The geometry (x,y,z) and matching attribute fields of parcel fabric points will be updated. If the geometry of parcel fabric points is updated, coincident parcel features will be updated as well. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Geometry (x,y,z)— Only the geometry (x,y,z) of the parcel fabric points will be updated. Coincident parcel features will be updated as well.</para>
			/// </summary>
			[GPValue("GEOMETRY_XYZ")]
			[Description("Geometry (x,y,z)")]
			GEOMETRY_XYZ,

			/// <summary>
			/// <para>Retire and replace—Source points will be imported as new parcel fabric points. Any matching parcel fabric points will be retired as historic. The Retired By Record field of each matching parcel fabric point will be populated with the Global ID of the record specified in the Record Name parameter.</para>
			/// </summary>
			[GPValue("RETIRE_AND_REPLACE")]
			[Description("Retire and replace")]
			Retire_and_replace,

		}

		/// <summary>
		/// <para>Update And Create Options</para>
		/// </summary>
		public enum UpdateCreateOptionEnum 
		{
			/// <summary>
			/// <para>Update matched and create unmatched—Points will be created if no matching points are found using the search criteria. If matching points are found using the search criteria, they will be updated. This is the default.</para>
			/// </summary>
			[GPValue("UPDATE_AND_CREATE")]
			[Description("Update matched and create unmatched")]
			Update_matched_and_create_unmatched,

			/// <summary>
			/// <para>Only create unmatched—Points will be created only if no matching points are found using the search criteria. If matching points are found using the search criteria, they will remain unchanged and no points will be created.</para>
			/// </summary>
			[GPValue("CREATE_ONLY")]
			[Description("Only create unmatched")]
			Only_create_unmatched,

			/// <summary>
			/// <para>Only update matched—Points will be updated if matching points are found using the search criteria. If no matching points are found, points will not be created.</para>
			/// </summary>
			[GPValue("UPDATE_ONLY")]
			[Description("Only update matched")]
			Only_update_matched,

		}

#endregion
	}
}
