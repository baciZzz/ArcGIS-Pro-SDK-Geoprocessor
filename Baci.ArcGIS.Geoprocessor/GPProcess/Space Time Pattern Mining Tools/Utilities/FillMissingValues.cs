using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Fill Missing Values</para>
	/// <para>Replaces missing (null) values with estimated values based on spatial neighbors, space-time neighbors, or time-series values.</para>
	/// </summary>
	public class FillMissingValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class containing the null values to be filled.</para>
		/// </param>
		/// <param name="FieldsToFill">
		/// <para>Fields to Fill</para>
		/// <para>The numeric fields containing missing data (null values).</para>
		/// </param>
		/// <param name="FillMethod">
		/// <para>Fill Method</para>
		/// <para>Specifies the type of calculation that will be applied. The Temporal Trend option is only available if the Location ID and Time Field parameter values are specified.</para>
		/// <para>Average—Null values will be replaced with the mean (average) value of the feature&apos;s neighbors.</para>
		/// <para>Minimum—Null values will be replaced with the minimum (smallest) value of the feature&apos;s neighbors.</para>
		/// <para>Maximum—Null values will be replaced with the maximum (largest) value of the feature&apos;s neighbors.</para>
		/// <para>Median—Null values will be replaced with the median (sorted middle value) of the feature&apos;s neighbors.</para>
		/// <para>Temporal Trend—Null values will be replaced based on the trend at that unique location.</para>
		/// <para><see cref="FillMethodEnum"/></para>
		/// </param>
		public FillMissingValues(object InFeatures, object FieldsToFill, object FillMethod)
		{
			this.InFeatures = InFeatures;
			this.FieldsToFill = FieldsToFill;
			this.FillMethod = FillMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Fill Missing Values</para>
		/// </summary>
		public override string DisplayName() => "Fill Missing Values";

		/// <summary>
		/// <para>Tool Name : FillMissingValues</para>
		/// </summary>
		public override string ToolName() => "FillMissingValues";

		/// <summary>
		/// <para>Tool Excute Name : stpm.FillMissingValues</para>
		/// </summary>
		public override string ExcuteName() => "stpm.FillMissingValues";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures, FieldsToFill, FillMethod, ConceptualizationOfSpatialRelationships, DistanceBand, TemporalNeighborhood, TimeField, NumberOfSpatialNeighbors, LocationId, RelatedTable, RelatedLocationId, WeightsMatrixFile, UniqueId, NullValue, OutTable, AppendToInput, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class containing the null values to be filled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output that will include the filled (estimated) values.</para>
		/// <para>If the Related Table parameter value is specified, Output Features will contain the number of estimated values at each location, and Output Table will contain the filled (estimated) values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Fields to Fill</para>
		/// <para>The numeric fields containing missing data (null values).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object FieldsToFill { get; set; }

		/// <summary>
		/// <para>Fill Method</para>
		/// <para>Specifies the type of calculation that will be applied. The Temporal Trend option is only available if the Location ID and Time Field parameter values are specified.</para>
		/// <para>Average—Null values will be replaced with the mean (average) value of the feature&apos;s neighbors.</para>
		/// <para>Minimum—Null values will be replaced with the minimum (smallest) value of the feature&apos;s neighbors.</para>
		/// <para>Maximum—Null values will be replaced with the maximum (largest) value of the feature&apos;s neighbors.</para>
		/// <para>Median—Null values will be replaced with the median (sorted middle value) of the feature&apos;s neighbors.</para>
		/// <para>Temporal Trend—Null values will be replaced based on the trend at that unique location.</para>
		/// <para><see cref="FillMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FillMethod { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features will be defined.</para>
		/// <para>Fixed distance—Neighboring features within a specified critical distance (the Distance Band parameter value) of each feature will be included in the calculations; everything outside the critical distance will be excluded.</para>
		/// <para>K nearest neighbors— The closest k features will be included in the calculations; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only— Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
		/// <para>Contiguity edges corners— Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
		/// <para>Get spatial weights from file—Spatial relationships will be defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>The cutoff distance for the Conceptualization of Spatial Relationships parameter's Fixed distance option. Features outside the specified cutoff for a target feature will be ignored in calculations for that feature. This parameter is not available for the Contiguity edges only or Contiguity edges corners options.</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Temporal Neighborhood</para>
		/// <para>An interval forward and backward in time that determines which features will be used in calculations for the target feature. Features that are not within this interval of the target feature will be ignored in calculations for that feature.</para>
		/// <para><see cref="TemporalNeighborhoodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TemporalNeighborhood { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>The field containing the time stamp for each record in the dataset. This field must be of type Date.</para>
		/// <para>This parameter is required if the Location ID parameter value is provided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Number of Spatial Neighbors</para>
		/// <para>The number of nearest neighbors that will be included in calculations.</para>
		/// <para>If the Conceptualization of Spatial Relationships parameter&apos;s Fixed distance, Contiguity edges only, or Contiguity edges corners option is chosen, this number is the minimum number of neighbors to include in calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfSpatialNeighbors { get; set; }

		/// <summary>
		/// <para>Location ID</para>
		/// <para>An integer field containing a unique ID number for each location.</para>
		/// <para>This parameter is used to match features from the Input Features parameter to rows in the Related Table parameter or to specify a unique location ID for determining temporal neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object LocationId { get; set; }

		/// <summary>
		/// <para>Related Table</para>
		/// <para>The table or table view containing the temporal data for each feature of the Input Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object RelatedTable { get; set; }

		/// <summary>
		/// <para>Related Location ID</para>
		/// <para>An integer field in the Related Table parameter that contains the Location ID parameter value on which the relate will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object RelatedLocationId { get; set; }

		/// <summary>
		/// <para>Spatial Weights Matrix File</para>
		/// <para>The path to a file containing weights that define spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Unique ID</para>
		/// <para>An integer field containing a different value for every record in the Input Features parameter. This field can be used to join the results back to the original dataset.</para>
		/// <para>If you don&apos;t have a Unique ID field, you can create one by adding an integer field to the input feature&apos;s attribute table and calculating the field values equal to the FID or OBJECTID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object UniqueId { get; set; }

		/// <summary>
		/// <para>Null Value</para>
		/// <para>The value that represents null (missing) values. If no value is specified, &lt;Null&gt; is assumed for geodatabase feature classes. For shapefile input, a numeric value of the null placeholder is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object NullValue { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing the filled (estimated) values.</para>
		/// <para>The output table is required if a related table is provided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Append Fields to Input Features</para>
		/// <para>Specifies whether the filled value fields will be appended to the input features or an output feature class will be created with the filled value fields. If you append the fields, you cannot provide a related table and the output coordinate system environment will be ignored.</para>
		/// <para>Checked—The fields containing the filled values will be appended to the input features. This option modifies the input data.</para>
		/// <para>Unchecked—An output feature class will be created containing the filled value fields. This is the default.</para>
		/// <para><see cref="AppendToInputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToInput { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FillMissingValues SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fill Method</para>
		/// </summary>
		public enum FillMethodEnum 
		{
			/// <summary>
			/// <para>Minimum—Null values will be replaced with the minimum (smallest) value of the feature&apos;s neighbors.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Average—Null values will be replaced with the mean (average) value of the feature&apos;s neighbors.</para>
			/// </summary>
			[GPValue("AVERAGE")]
			[Description("Average")]
			Average,

			/// <summary>
			/// <para>Median—Null values will be replaced with the median (sorted middle value) of the feature&apos;s neighbors.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Maximum—Null values will be replaced with the maximum (largest) value of the feature&apos;s neighbors.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Temporal Trend—Null values will be replaced based on the trend at that unique location.</para>
			/// </summary>
			[GPValue("TEMPORAL_TREND")]
			[Description("Temporal Trend")]
			Temporal_Trend,

		}

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>Fixed distance—Neighboring features within a specified critical distance (the Distance Band parameter value) of each feature will be included in the calculations; everything outside the critical distance will be excluded.</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE")]
			[Description("Fixed distance")]
			Fixed_distance,

			/// <summary>
			/// <para>K nearest neighbors— The closest k features will be included in the calculations; k is a specified numeric parameter.</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K nearest neighbors")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>Contiguity edges only— Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners— Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Get spatial weights from file—Spatial relationships will be defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("Get spatial weights from file")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Temporal Neighborhood</para>
		/// </summary>
		public enum TemporalNeighborhoodEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Append Fields to Input Features</para>
		/// </summary>
		public enum AppendToInputEnum 
		{
			/// <summary>
			/// <para>Checked—The fields containing the filled values will be appended to the input features. This option modifies the input data.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND_TO_INPUT")]
			APPEND_TO_INPUT,

			/// <summary>
			/// <para>Unchecked—An output feature class will be created containing the filled value fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NEW_FEATURES")]
			NEW_FEATURES,

		}

#endregion
	}
}
