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
	/// <para>Import Floorplans To Indoors Geodatabase</para>
	/// <para>Import Floorplans To Indoors Geodatabase</para>
	/// <para>Imports floor plans from CAD files into an Indoors workspace that conforms to the ArcGIS Indoors Information Model. The output of this tool can be used to create floor-aware maps and scenes for use in floor-aware apps, as well as to generate an indoor network for routing.</para>
	/// </summary>
	public class ImportFloorplansToIndoorsGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
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
		/// <param name="InExcelTemplate">
		/// <para>Input Excel Template File</para>
		/// <para>An Excel spreadsheet (.xls or .xlsx file) that contains input and configuration parameters.</para>
		/// </param>
		/// <param name="UniqueidDelimiter">
		/// <para>Unique ID Delimiter</para>
		/// <para>Specifies the delimiter that will separate key values in the Indoors model hierarchy.</para>
		/// <para>Period—The ID will include key values separated by periods. This is default.</para>
		/// <para>Hyphen—The ID will include key values separated by hyphens.</para>
		/// <para>Underscore—The ID will include key values separated by underscores.</para>
		/// <para><see cref="UniqueidDelimiterEnum"/></para>
		/// </param>
		public ImportFloorplansToIndoorsGDB(object TargetUnitFeatures, object TargetDetailFeatures, object TargetLevelFeatures, object TargetFacilityFeatures, object InExcelTemplate, object UniqueidDelimiter)
		{
			this.TargetUnitFeatures = TargetUnitFeatures;
			this.TargetDetailFeatures = TargetDetailFeatures;
			this.TargetLevelFeatures = TargetLevelFeatures;
			this.TargetFacilityFeatures = TargetFacilityFeatures;
			this.InExcelTemplate = InExcelTemplate;
			this.UniqueidDelimiter = UniqueidDelimiter;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Floorplans To Indoors Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Import Floorplans To Indoors Geodatabase";

		/// <summary>
		/// <para>Tool Name : ImportFloorplansToIndoorsGDB</para>
		/// </summary>
		public override string ToolName() => "ImportFloorplansToIndoorsGDB";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ImportFloorplansToIndoorsGDB</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ImportFloorplansToIndoorsGDB";

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
		public override object[] Parameters() => new object[] { TargetUnitFeatures, TargetDetailFeatures, TargetLevelFeatures, TargetFacilityFeatures, InExcelTemplate, UniqueidDelimiter, SliverThreshold!, DoorCloseBuffer!, AreaUnitOfMeasure!, MeasurementMode!, TargetSectionFeatures!, TargetZoneFeatures!, UpdatedUnits! };

		/// <summary>
		/// <para>Target Unit Features</para>
		/// <para>The target Units feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Levels, and Details features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object TargetUnitFeatures { get; set; }

		/// <summary>
		/// <para>Target Detail Features</para>
		/// <para>The target Details feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Levels, and Units features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetDetailFeatures { get; set; }

		/// <summary>
		/// <para>Target Level Features</para>
		/// <para>The target Levels feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facilities, Units, and Details features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object TargetLevelFeatures { get; set; }

		/// <summary>
		/// <para>Target Facility Features</para>
		/// <para>The target Facilities feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Levels, Units, and Details features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object TargetFacilityFeatures { get; set; }

		/// <summary>
		/// <para>Input Excel Template File</para>
		/// <para>An Excel spreadsheet (.xls or .xlsx file) that contains input and configuration parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object InExcelTemplate { get; set; }

		/// <summary>
		/// <para>Unique ID Delimiter</para>
		/// <para>Specifies the delimiter that will separate key values in the Indoors model hierarchy.</para>
		/// <para>Period—The ID will include key values separated by periods. This is default.</para>
		/// <para>Hyphen—The ID will include key values separated by hyphens.</para>
		/// <para>Underscore—The ID will include key values separated by underscores.</para>
		/// <para><see cref="UniqueidDelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UniqueidDelimiter { get; set; } = "PERIOD";

		/// <summary>
		/// <para>Sliver Threshold</para>
		/// <para>The ratio of perimeter to area that defines a sliver polygon. It is used when importing Unit polygons to improve the quality of the imported data. Unit polygons that are determined to be slivers are placed in a review geodatabase located in the scratch folder of the ArcGIS Pro project. The default value is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? SliverThreshold { get; set; } = "2";

		/// <summary>
		/// <para>Door Close Buffer</para>
		/// <para>The distance, in inches, the tool will search from a door to find and snap to the nearest wall. This parameter is used when the CLOSE_DOORS column is set to Y in the input Excel template file. The default value is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object? DoorCloseBuffer { get; set; } = "0";

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// <para>Specifies the unit of measure that will be used to calculate area for the area fields when importing floor plans.</para>
		/// <para>Square Feet—Area will be defined in square feet. This is default.</para>
		/// <para>Square Meters—Area will be defined in square meters.</para>
		/// <para><see cref="AreaUnitOfMeasureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnitOfMeasure { get; set; } = "SQUARE_FEET";

		/// <summary>
		/// <para>Measurement Mode</para>
		/// <para>Specifies the measurement mode that will be used to calculate the area fields when importing floor plans.</para>
		/// <para>Geodesic—Area will be calculated using geodesic distance. Geodesic distance is calculated in a 3D spherical space as the distance across the curved surface of the world. This is default.</para>
		/// <para>Planar—Area will be calculated using planar distance. Planar distance is straight-line Euclidean distance calculated in a 2D Cartesian coordinate system.</para>
		/// <para><see cref="MeasurementModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MeasurementMode { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Target Section Features</para>
		/// <para>The target Sections feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facility, Level, Unit, and Detail features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? TargetSectionFeatures { get; set; }

		/// <summary>
		/// <para>Target Zone Features</para>
		/// <para>The target Zones feature layer, feature class, or feature service that conforms to the ArcGIS Indoors Information Model and resides in the same workspace as the target Facility, Level, Unit, and Detail features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? TargetZoneFeatures { get; set; }

		/// <summary>
		/// <para>Updated Units</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedUnits { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportFloorplansToIndoorsGDB SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Unique ID Delimiter</para>
		/// </summary>
		public enum UniqueidDelimiterEnum 
		{
			/// <summary>
			/// <para>Period—The ID will include key values separated by periods. This is default.</para>
			/// </summary>
			[GPValue("PERIOD")]
			[Description("Period")]
			Period,

			/// <summary>
			/// <para>Hyphen—The ID will include key values separated by hyphens.</para>
			/// </summary>
			[GPValue("HYPHEN")]
			[Description("Hyphen")]
			Hyphen,

			/// <summary>
			/// <para>Underscore—The ID will include key values separated by underscores.</para>
			/// </summary>
			[GPValue("UNDERSCORE")]
			[Description("Underscore")]
			Underscore,

		}

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// </summary>
		public enum AreaUnitOfMeasureEnum 
		{
			/// <summary>
			/// <para>Square Feet—Area will be defined in square feet. This is default.</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("Square Feet")]
			Square_Feet,

			/// <summary>
			/// <para>Square Meters—Area will be defined in square meters.</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("Square Meters")]
			Square_Meters,

		}

		/// <summary>
		/// <para>Measurement Mode</para>
		/// </summary>
		public enum MeasurementModeEnum 
		{
			/// <summary>
			/// <para>Geodesic—Area will be calculated using geodesic distance. Geodesic distance is calculated in a 3D spherical space as the distance across the curved surface of the world. This is default.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

			/// <summary>
			/// <para>Planar—Area will be calculated using planar distance. Planar distance is straight-line Euclidean distance calculated in a 2D Cartesian coordinate system.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

		}

#endregion
	}
}
