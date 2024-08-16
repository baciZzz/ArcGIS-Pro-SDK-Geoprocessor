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
	/// <para>Imports features from a BIM file into an indoor dataset.</para>
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
		/// <param name="TargetIndoorDataset">
		/// <para>Target Indoor Dataset</para>
		/// <para>The target indoor dataset that conforms to the ArcGIS Indoors Information Model and contains Facilities, Levels, Units, and Details feature classes.</para>
		/// </param>
		/// <param name="GroundFloorName">
		/// <para>Ground Floor Name</para>
		/// <para>The ground floor of the building. The vertical order of the levels is derived from this input. Any levels with an elevation that is less than the specified ground floor will be assigned a negative vertical order.</para>
		/// </param>
		public ImportBIMToIndoorDataset(object InBimFloorplanLayer, object TargetIndoorDataset, object GroundFloorName)
		{
			this.InBimFloorplanLayer = InBimFloorplanLayer;
			this.TargetIndoorDataset = TargetIndoorDataset;
			this.GroundFloorName = GroundFloorName;
		}

		/// <summary>
		/// <para>Tool Display Name : Import BIM To Indoor Dataset</para>
		/// </summary>
		public override string DisplayName => "Import BIM To Indoor Dataset";

		/// <summary>
		/// <para>Tool Name : ImportBIMToIndoorDataset</para>
		/// </summary>
		public override string ToolName => "ImportBIMToIndoorDataset";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ImportBIMToIndoorDataset</para>
		/// </summary>
		public override string ExcuteName => "indoors.ImportBIMToIndoorDataset";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InBimFloorplanLayer, TargetIndoorDataset, GroundFloorName, BuildingName, RoomCategoryField, FloorsToImport, AreaUnitOfMeasure, UpdatedIndoorDataset };

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
		/// <para>Target Indoor Dataset</para>
		/// <para>The target indoor dataset that conforms to the ArcGIS Indoors Information Model and contains Facilities, Levels, Units, and Details feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetIndoorDataset { get; set; }

		/// <summary>
		/// <para>Ground Floor Name</para>
		/// <para>The ground floor of the building. The vertical order of the levels is derived from this input. Any levels with an elevation that is less than the specified ground floor will be assigned a negative vertical order.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GroundFloorName { get; set; }

		/// <summary>
		/// <para>Building Name</para>
		/// <para>The unique building name that will be assigned to the output Indoors features. The default value is the Bldg_Name field value from the input BIM file. If the field is null or empty, this parameter will be populated with the name of the input source file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BuildingName { get; set; }

		/// <summary>
		/// <para>Room Category Field</para>
		/// <para>The field from the Floorplan_Polygon feature layer that will be used to populate the USE_TYPE field for the Units feature class in the target indoor dataset. If no field is provided, the RoomName field value from the Floorplan_Polygon layer will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object RoomCategoryField { get; set; }

		/// <summary>
		/// <para>Floors To Import</para>
		/// <para>The floors in the input BIM file that will be imported to the target indoor dataset. If no floors are provided, all floors will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object FloorsToImport { get; set; }

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
		public object AreaUnitOfMeasure { get; set; } = "SQUARE_FEET";

		/// <summary>
		/// <para>Updated Indoor Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object UpdatedIndoorDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportBIMToIndoorDataset SetEnviroment(object workspace = null )
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

#endregion
	}
}
