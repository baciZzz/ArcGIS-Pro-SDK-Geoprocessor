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
	/// <para>Replaces missing (null) values with estimated values based on spatial neighbors, space-time neighbors, time-series, or global statistic values.</para>
	/// </summary>
	public class FillMissingValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features or Table</para>
		/// <para>The point or polygon feature class or stand-alone table containing the null values to be filled.</para>
		/// <para>If the Related Table parameter value is provided, the null values to be filled will be contained in the related table. The input features will be matched to the rows in the related table to specify the space-time neighborhood.</para>
		/// </param>
		/// <param name="FieldsToFill">
		/// <para>Fields to Fill</para>
		/// <para>The numeric fields containing missing data (null values).</para>
		/// </param>
		/// <param name="FillMethod">
		/// <para>Fill Method</para>
		/// <para>Specifies the type of calculation that will be applied. The Temporal Trend option is only available if the Location ID and Time Field parameter values are provided.</para>
		/// <para>Average—Null values will be replaced with the mean (average) value of the feature&apos;s neighbors or the mean value of the field to be filled for stand-alone tables.</para>
		/// <para>Minimum—Null values will be replaced with the minimum (smallest) value of the feature&apos;s neighbors or the minimum value of the field to be filled for stand-alone tables.</para>
		/// <para>Maximum—Null values will be replaced with the maximum (largest) value of the feature&apos;s neighbors or the maximum value of the field to be filled for stand-alone tables.</para>
		/// <para>Median—Null values will be replaced with the median (sorted middle value) of the feature&apos;s neighbors or the median of the field to be filled for stand-alone tables.</para>
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
		public override string DisplayName => "Fill Missing Values";

		/// <summary>
		/// <para>Tool Name : FillMissingValues</para>
		/// </summary>
		public override string ToolName => "FillMissingValues";

		/// <summary>
		/// <para>Tool Excute Name : stpm.FillMissingValues</para>
		/// </summary>
		public override string ExcuteName => "stpm.FillMissingValues";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatures!, FieldsToFill, FillMethod, ConceptualizationOfSpatialRelationships!, DistanceBand!, TemporalNeighborhood!, TimeField!, NumberOfSpatialNeighbors!, LocationId!, RelatedTable!, RelatedLocationId!, WeightsMatrixFile!, UniqueId!, NullValue!, OutTable!, AppendToInput!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input Features or Table</para>
		/// <para>The point or polygon feature class or stand-alone table containing the null values to be filled.</para>
		/// <para>If the Related Table parameter value is provided, the null values to be filled will be contained in the related table. The input features will be matched to the rows in the related table to specify the space-time neighborhood.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features or Table</para>
		/// <para>The output features or stand-alone table that will include the filled (estimated) values.</para>
		/// <para>If the Related Table parameter value is provided, the output of this parameter will contain the number of estimated values at each location, and the Output Table parameter value will contain the filled (estimated) values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Fields to Fill</para>
		/// <para>The numeric fields containing missing data (null values).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object FieldsToFill { get; set; }

		/// <summary>
		/// <para>Fill Method</para>
		/// <para>Specifies the type of calculation that will be applied. The Temporal Trend option is only available if the Location ID and Time Field parameter values are provided.</para>
		/// <para>Average—Null values will be replaced with the mean (average) value of the feature&apos;s neighbors or the mean value of the field to be filled for stand-alone tables.</para>
		/// <para>Minimum—Null values will be replaced with the minimum (smallest) value of the feature&apos;s neighbors or the minimum value of the field to be filled for stand-alone tables.</para>
		/// <para>Maximum—Null values will be replaced with the maximum (largest) value of the feature&apos;s neighbors or the maximum value of the field to be filled for stand-alone tables.</para>
		/// <para>Median—Null values will be replaced with the median (sorted middle value) of the feature&apos;s neighbors or the median of the field to be filled for stand-alone tables.</para>
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
		public object? ConceptualizationOfSpatialRelationships { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>The cutoff distance for the Conceptualization of Spatial Relationships parameter's Fixed distance option. Features outside the specified cutoff for a target feature will be ignored in calculations for that feature. This parameter is not available for the Contiguity edges only or Contiguity edges corners options.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? DistanceBand { get; set; }

		/// <summary>
		/// <para>Temporal Neighborhood</para>
		/// <para>An interval forward and backward in time that determines the features that will be used in calculations for the target feature. Features that are not within this interval of the target feature will be ignored in calculations for that feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TemporalNeighborhood { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>The field containing the time stamp for each record in the dataset. This field must be of type Date.</para>
		/// <para>For feature input, the time field will define temporal neighbors while filling missing values. A value must be provided if a related table is provided.</para>
		/// <para>For feature and table input, the time field will be used when filling missing values using temporal trend at the location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? TimeField { get; set; }

		/// <summary>
		/// <para>Number of Spatial Neighbors</para>
		/// <para>The number of nearest neighbors that will be included in calculations.</para>
		/// <para>If the Conceptualization of Spatial Relationships parameter&apos;s Fixed distance, Contiguity edges only, or Contiguity edges corners option is chosen, this number is the minimum number of neighbors to include in calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfSpatialNeighbors { get; set; }

		/// <summary>
		/// <para>Location ID</para>
		/// <para>An integer or text field containing a unique ID for each location.</para>
		/// <para>If a related table is provided, this field is used to match each input feature to rows in the related table; the values of this field must be unique for every input feature. If a related table is not provided, this field is used to specify each unique location in the input features to determine temporal neighbors. In this case, the values of this field must be unique to every location but do not need to be unique for each feature (because more than one feature can have the same location).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? LocationId { get; set; }

		/// <summary>
		/// <para>Related Table</para>
		/// <para>The table or table view containing the temporal data for each feature of the Input Features or Table parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? RelatedTable { get; set; }

		/// <summary>
		/// <para>Related Location ID</para>
		/// <para>An integer or text field in the Related Table parameter that contains the Location ID parameter value on which the relate will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? RelatedLocationId { get; set; }

		/// <summary>
		/// <para>Spatial Weights Matrix File</para>
		/// <para>The path to a file containing weights that define spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Unique ID</para>
		/// <para>An integer field containing a different value for every record in the Input Features or Table parameter value. This field can be used to join the results back to the original dataset.</para>
		/// <para>If you don&apos;t have a Unique ID field, you can create one by adding an integer field to the input feature&apos;s attribute table and calculating the field values equal to the FID or OBJECTID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? UniqueId { get; set; }

		/// <summary>
		/// <para>Null Value</para>
		/// <para>The value that represents null (missing) values. If no value is provided, <Null> is assumed for geodatabase feature classes and tables. If a value is provided, both the value and all <Null> values will be filled. If the input or output is a shapefile or dBASE table, a numeric value of the null placeholder is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? NullValue { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing the filled (estimated) values.</para>
		/// <para>The output table is required if a related table is provided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Append Fields to Input Data</para>
		/// <para>Specifies whether the filled value fields will be appended to the input data or an output feature class or table will be created with the filled value fields. If you append the fields, you cannot provide a related table and the output coordinate system environment will be ignored.</para>
		/// <para>Checked—The fields containing the filled values will be appended to the input data. This option modifies the input data.</para>
		/// <para>Unchecked—An output feature class or table will be created containing the filled value fields. This is the default.</para>
		/// <para><see cref="AppendToInputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendToInput { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features or Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FillMissingValues SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null )
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
			/// <para>Minimum—Null values will be replaced with the minimum (smallest) value of the feature&apos;s neighbors or the minimum value of the field to be filled for stand-alone tables.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Average—Null values will be replaced with the mean (average) value of the feature&apos;s neighbors or the mean value of the field to be filled for stand-alone tables.</para>
			/// </summary>
			[GPValue("AVERAGE")]
			[Description("Average")]
			Average,

			/// <summary>
			/// <para>Median—Null values will be replaced with the median (sorted middle value) of the feature&apos;s neighbors or the median of the field to be filled for stand-alone tables.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Maximum—Null values will be replaced with the maximum (largest) value of the feature&apos;s neighbors or the maximum value of the field to be filled for stand-alone tables.</para>
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
		/// <para>Append Fields to Input Data</para>
		/// </summary>
		public enum AppendToInputEnum 
		{
			/// <summary>
			/// <para>Checked—The fields containing the filled values will be appended to the input data. This option modifies the input data.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND_TO_INPUT")]
			APPEND_TO_INPUT,

			/// <summary>
			/// <para>Unchecked—An output feature class or table will be created containing the filled value fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NEW_FEATURES")]
			NEW_FEATURES,

		}

#endregion
	}
}
