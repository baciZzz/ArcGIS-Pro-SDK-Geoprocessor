using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Generate Network Spatial Weights</para>
	/// <para>Generate Network Spatial Weights</para>
	/// <para>Constructs a spatial weights matrix file (.swm) using a network dataset, defining spatial relationships in terms of the underlying network structure.</para>
	/// </summary>
	public class GenerateNetworkSWM : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The point feature class representing locations on the network. For each feature, neighbors and weights are calculated and stored in the output spatial weights matrix file.</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a unique value for each feature in the input feature class. If you don't have a field with unique ID values, you can create one by adding an integer field to your feature class table and calculating the field values to equal the FID or OBJECTID field.</para>
		/// </param>
		/// <param name="OutputSpatialWeightsMatrixFile">
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>The output network spatial weights matrix file (.swm) that will store the neighbors and weights for each input feature.</para>
		/// </param>
		/// <param name="InputNetworkDataSource">
		/// <para>Input Network Data Source</para>
		/// <para>The network dataset used to find neighbors of each input feature. Network datasets usually represent street networks but can also represent other kinds of transportation networks such as railroads or walking paths. The network dataset must include at least one attribute related to distance, travel time, or cost.</para>
		/// </param>
		/// <param name="TravelMode">
		/// <para>Travel Mode</para>
		/// <para>The mode of transportation for the analysis. A travel mode defines how a pedestrian, car, truck, or other medium of transportation moves through the network and represents a collection of network settings, such as travel restrictions and U-turn policies.</para>
		/// </param>
		public GenerateNetworkSWM(object InputFeatureClass, object UniqueIDField, object OutputSpatialWeightsMatrixFile, object InputNetworkDataSource, object TravelMode)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.UniqueIDField = UniqueIDField;
			this.OutputSpatialWeightsMatrixFile = OutputSpatialWeightsMatrixFile;
			this.InputNetworkDataSource = InputNetworkDataSource;
			this.TravelMode = TravelMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Network Spatial Weights</para>
		/// </summary>
		public override string DisplayName() => "Generate Network Spatial Weights";

		/// <summary>
		/// <para>Tool Name : GenerateNetworkSWM</para>
		/// </summary>
		public override string ToolName() => "GenerateNetworkSWM";

		/// <summary>
		/// <para>Tool Excute Name : stats.GenerateNetworkSWM</para>
		/// </summary>
		public override string ExcuteName() => "stats.GenerateNetworkSWM";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputSpatialWeightsMatrixFile, InputNetworkDataSource, TravelMode, ImpedanceDistanceCutoff!, ImpedanceTemporalCutoff!, ImpedanceCostCutoff!, MaximumNumberOfNeighbors!, TimeOfDay!, TimeZone!, Barriers!, SearchTolerance!, ConceptualizationOfSpatialRelationships!, Exponent!, RowStandardization! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The point feature class representing locations on the network. For each feature, neighbors and weights are calculated and stored in the output spatial weights matrix file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a unique value for each feature in the input feature class. If you don't have a field with unique ID values, you can create one by adding an integer field to your feature class table and calculating the field values to equal the FID or OBJECTID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>The output network spatial weights matrix file (.swm) that will store the neighbors and weights for each input feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object OutputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Input Network Data Source</para>
		/// <para>The network dataset used to find neighbors of each input feature. Network datasets usually represent street networks but can also represent other kinds of transportation networks such as railroads or walking paths. The network dataset must include at least one attribute related to distance, travel time, or cost.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDataSource()]
		public object InputNetworkDataSource { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The mode of transportation for the analysis. A travel mode defines how a pedestrian, car, truck, or other medium of transportation moves through the network and represents a collection of network settings, such as travel restrictions and U-turn policies.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Impedance Distance Cutoff</para>
		/// <para>The maximum impedance distance allowed for neighbors of a feature. Any feature whose distance is farther than this value will not be used as a neighbor. By default, no distance cutoff is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		[Category("Network Analysis Options")]
		public object? ImpedanceDistanceCutoff { get; set; }

		/// <summary>
		/// <para>Impedance Temporal Cutoff</para>
		/// <para>The maximum impedance travel time allowed for neighbors of a feature. Any feature whose travel time is longer than this value will not be used as a neighbor. By default, no temporal cutoff is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		[Category("Network Analysis Options")]
		public object? ImpedanceTemporalCutoff { get; set; }

		/// <summary>
		/// <para>Impedance Cost Cutoff</para>
		/// <para>The maximum impedance cost allowed for neighbors of a feature. Any feature whose cost of travel is larger than this value will not be used as a neighbor. By default, no cost cutoff is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Network Analysis Options")]
		public object? ImpedanceCostCutoff { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>An integer reflecting the maximum number of neighbors for each feature. The actual number of neighbors used for each feature may be smaller due to impedance cutoffs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Network Analysis Options")]
		public object? MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time of day traffic conditions will be considered in the analysis. Traffic conditions can impact the distance that can be traveled over a given time. If no date or time is provided, the analysis will not consider the impact of traffic.</para>
		/// <para>Instead of using a particular date, you can specify a day of the week using the following dates:</para>
		/// <para>Today-12/30/1899</para>
		/// <para>Sunday-12/31/1899</para>
		/// <para>Monday-1/1/1900</para>
		/// <para>Tuesday-1/2/1900</para>
		/// <para>Wednesday-1/3/1900</para>
		/// <para>Thursday-1/4/1900</para>
		/// <para>Friday-1/5/1900</para>
		/// <para>Saturday-1/6/1900</para>
		/// <para>For example, to specify that travel should begin at 5:00 p.m. on Tuesday, specify the parameter value as 1/2/1900 5:00 PM.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Analysis Options")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone for the Time of Day parameter.</para>
		/// <para>Local time at locations—The time zone in which the Input Feature Class is located will be used. This is the default.</para>
		/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Analysis Options")]
		public object? TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Barriers</para>
		/// <para>The features that represent blocked intersections, road closures, accident sites, or other locations where travel is blocked along the network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		[Category("Network Analysis Options")]
		public object? Barriers { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The maximum distance used to assign each input feature to a location on the network. If any of the input points do not fall exactly on a line of the network, they will be assigned to the closest location on the network for the analysis. However, if the feature is farther than the search tolerance value from any location on the network, it will not be assigned to the network and will not be included in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		[Category("Network Analysis Options")]
		public object? SearchTolerance { get; set; } = "5000 Meters";

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how weights will be defined for each neighbor.</para>
		/// <para>Inverse—Features farther in distance, time, or cost will have a smaller weight than features nearby. The weights decrease by their inverse to an exponent.</para>
		/// <para>Fixed—All neighbors will be given equal weight. This is the default.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object? ConceptualizationOfSpatialRelationships { get; set; } = "FIXED";

		/// <summary>
		/// <para>Exponent</para>
		/// <para>The exponent used when Inverse is specified for the Conceptualization of Spatial Relationships parameter. The weights assigned to each neighbor are calculated by taking the inverse distance, time, or cost to the power of the exponent. The default value is 1, and the value must be between 0.01 and 4. Weights drop off more rapidly as the exponent increases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.10000000000000001, Max = 4)]
		[Category("Weights Options")]
		public object? Exponent { get; set; } = "1";

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>Specifies whether row standardization will be applied. Row standardization is recommended when the locations of the input points are potentially biased due to sampling design or an imposed aggregation scheme. It is also recommended that you standardize rows when weighting neighbors based on inverse distance, time, or cost.</para>
		/// <para>Checked—Spatial weights will be standardized by row. Each weight is divided by its row sum. This is the default.</para>
		/// <para>Unchecked—No standardization of spatial weights will be applied.</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object? RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateNetworkSWM SetEnviroment(object? extent = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>Local time at locations—The time zone in which the Input Feature Class is located will be used. This is the default.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

			/// <summary>
			/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>Fixed—All neighbors will be given equal weight. This is the default.</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("Fixed")]
			Fixed,

			/// <summary>
			/// <para>Inverse—Features farther in distance, time, or cost will have a smaller weight than features nearby. The weights decrease by their inverse to an exponent.</para>
			/// </summary>
			[GPValue("INVERSE")]
			[Description("Inverse")]
			Inverse,

		}

		/// <summary>
		/// <para>Row Standardization</para>
		/// </summary>
		public enum RowStandardizationEnum 
		{
			/// <summary>
			/// <para>Checked—Spatial weights will be standardized by row. Each weight is divided by its row sum. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_STANDARDIZATION")]
			ROW_STANDARDIZATION,

			/// <summary>
			/// <para>Unchecked—No standardization of spatial weights will be applied.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STANDARDIZATION")]
			NO_STANDARDIZATION,

		}

#endregion
	}
}
