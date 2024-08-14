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
	/// <para>Constructs a spatial weights matrix file (.swm) using a Network dataset, defining feature spatial relationships in terms of the underlying network structure.</para>
	/// </summary>
	[Obsolete()]
	public class GenerateNetworkSpatialWeights : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The point feature class for which network spatial relationships among features will be assessed.</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a different value for every feature in the input feature class. If you don't have a Unique ID field, you can create one by adding an integer field to your feature class table and calculating the field values to equal the FID or OBJECTID field.</para>
		/// </param>
		/// <param name="OutputSpatialWeightsMatrixFile">
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>The output network spatial weights matrix (.swm) file.</para>
		/// </param>
		/// <param name="InputNetwork">
		/// <para>Input Network</para>
		/// <para>The network dataset for which spatial relationships among features in the input feature class will be defined. Network datasets most often represent street networks but may represent other kinds of transportation networks as well. The network dataset needs at least one time-based and one distance-based cost attribute.</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>The type of cost units to use as impedance in the analysis.</para>
		/// </param>
		public GenerateNetworkSpatialWeights(object InputFeatureClass, object UniqueIDField, object OutputSpatialWeightsMatrixFile, object InputNetwork, object ImpedanceAttribute)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.UniqueIDField = UniqueIDField;
			this.OutputSpatialWeightsMatrixFile = OutputSpatialWeightsMatrixFile;
			this.InputNetwork = InputNetwork;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Network Spatial Weights</para>
		/// </summary>
		public override string DisplayName => "Generate Network Spatial Weights";

		/// <summary>
		/// <para>Tool Name : GenerateNetworkSpatialWeights</para>
		/// </summary>
		public override string ToolName => "GenerateNetworkSpatialWeights";

		/// <summary>
		/// <para>Tool Excute Name : stats.GenerateNetworkSpatialWeights</para>
		/// </summary>
		public override string ExcuteName => "stats.GenerateNetworkSpatialWeights";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatureClass, UniqueIDField, OutputSpatialWeightsMatrixFile, InputNetwork, ImpedanceAttribute, ImpedanceCutoff, MaximumNumberOfNeighbors, Barriers, UTurnPolicy, Restrictions, UseHierarchyInAnalysis, SearchTolerance, ConceptualizationOfSpatialRelationships, Exponent, RowStandardization, TravelMode, TimeOfDay };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The point feature class for which network spatial relationships among features will be assessed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a different value for every feature in the input feature class. If you don't have a Unique ID field, you can create one by adding an integer field to your feature class table and calculating the field values to equal the FID or OBJECTID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>The output network spatial weights matrix (.swm) file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The network dataset for which spatial relationships among features in the input feature class will be defined. Network datasets most often represent street networks but may represent other kinds of transportation networks as well. The network dataset needs at least one time-based and one distance-based cost attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InputNetwork { get; set; }

		/// <summary>
		/// <para>Impedance Attribute</para>
		/// <para>The type of cost units to use as impedance in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object ImpedanceAttribute { get; set; }

		/// <summary>
		/// <para>Impedance Cutoff</para>
		/// <para>Specifies a cutoff value for Inverse and Fixed conceptualizations of spatial relationships. Enter this value using the units specified by the Impedance Attribute parameter.</para>
		/// <para>A value of zero indicates that no threshold is applied. When this parameter is left blank, a default threshold value is computed based on input feature class extent and the number of features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Network Analysis Options")]
		public object ImpedanceCutoff { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>An integer reflecting the maximum number of neighbors to find for each feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Network Analysis Options")]
		public object MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Barriers</para>
		/// <para>The name of a point feature class with features representing blocked intersections, road closures, accident sites, or other locations where travel is blocked along the network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[Category("Network Analysis Options")]
		public object Barriers { get; set; }

		/// <summary>
		/// <para>U-turn Policy</para>
		/// <para>Specifies optional U-turn restrictions.</para>
		/// <para>Allow U-turns—U-turns will be allowed anywhere. This is the default.</para>
		/// <para>No U-turns—No U-turns will be allowed during navigation.</para>
		/// <para>Allow U-turns at dead ends only—U-turns will be allowed only at dead ends (that is, single-valent junctions).</para>
		/// <para>Allow U-turns at dead ends and intersections only—U-turns will be allowed only at dead ends and intersections.</para>
		/// <para><see cref="UTurnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object UTurnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>A list of restrictions. Check the restrictions to be honored in spatial relationship computations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object Restrictions { get; set; }

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>Specifies whether to use a hierarchy in the analysis.</para>
		/// <para>Checked—The network dataset&apos;s hierarchy attribute will be used in a heuristic path algorithm to speed analysis.</para>
		/// <para>Unchecked—An exact path algorithm will be used instead. If there is no hierarchy attribute, this option does not affect analysis.</para>
		/// <para><see cref="UseHierarchyInAnalysisEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object UseHierarchyInAnalysis { get; set; } = "false";

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The search threshold used to locate features in the Input Feature Class onto the network dataset. This parameter includes a search value and the units for the tolerance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Analysis Options")]
		public object SearchTolerance { get; set; } = "5000 Meters";

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how the weighting associated with each spatial relationship is specified.</para>
		/// <para>Inverse—Features farther away have a smaller weight than features nearby.</para>
		/// <para>Fixed—Features within the Impedance Cutoff are neighbors (weight of 1); features outside the Impedance Cutoff are not weighted (weight of 0).</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object ConceptualizationOfSpatialRelationships { get; set; } = "INVERSE";

		/// <summary>
		/// <para>Exponent</para>
		/// <para>Parameter for the Inverse Conceptualization of Spatial Relationships calculation. Typical values are 1 or 2. Weights drop off quicker with distance as this exponent value increases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Weights Options")]
		public object Exponent { get; set; } = "1";

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>Specifies whether row standardization is applied. Row standardization is recommended whenever feature distribution is potentially biased due to sampling design or to an imposed aggregation scheme.</para>
		/// <para>Checked—Spatial weights are standardized by row. Each weight is divided by its row sum.</para>
		/// <para>Unchecked—No standardization of spatial weights is applied.</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The mode of transportation for the analysis. Custom is always a choice. For other travel modes to appear, they must be present in the network dataset specified in the Network Dataset parameter.</para>
		/// <para>A travel mode is defined on a network dataset and provides override values for parameters that model car, truck, pedestrian, or other modes of travel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>Specifies whether travel times should consider traffic conditions. Especially in urbanized areas, traffic conditions can significantly impact the area covered within a specified travel time. If no date or time is specified, the distance covered during a specified travel time will not be impacted by traffic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Analysis Options")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateNetworkSpatialWeights SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>U-turn Policy</para>
		/// </summary>
		public enum UTurnPolicyEnum 
		{
			/// <summary>
			/// <para>Allow U-turns—U-turns will be allowed anywhere. This is the default.</para>
			/// </summary>
			[GPValue("ALLOW_UTURNS")]
			[Description("Allow U-turns")]
			ALLOW_UTURNS,

			/// <summary>
			/// <para>No U-turns—No U-turns will be allowed during navigation.</para>
			/// </summary>
			[GPValue("NO_UTURNS")]
			[Description("No U-turns")]
			NO_UTURNS,

			/// <summary>
			/// <para>Allow U-turns at dead ends only—U-turns will be allowed only at dead ends (that is, single-valent junctions).</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_ONLY")]
			[Description("Allow U-turns at dead ends only")]
			ALLOW_DEAD_ENDS_ONLY,

			/// <summary>
			/// <para>Allow U-turns at dead ends and intersections only—U-turns will be allowed only at dead ends and intersections.</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			[Description("Allow U-turns at dead ends and intersections only")]
			ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY,

		}

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// </summary>
		public enum UseHierarchyInAnalysisEnum 
		{
			/// <summary>
			/// <para>Checked—The network dataset&apos;s hierarchy attribute will be used in a heuristic path algorithm to speed analysis.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_HIERARCHY")]
			USE_HIERARCHY,

			/// <summary>
			/// <para>Unchecked—An exact path algorithm will be used instead. If there is no hierarchy attribute, this option does not affect analysis.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HIERARCHY")]
			NO_HIERARCHY,

		}

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>Inverse—Features farther away have a smaller weight than features nearby.</para>
			/// </summary>
			[GPValue("INVERSE")]
			[Description("Inverse")]
			Inverse,

			/// <summary>
			/// <para>Fixed—Features within the Impedance Cutoff are neighbors (weight of 1); features outside the Impedance Cutoff are not weighted (weight of 0).</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("Fixed")]
			Fixed,

		}

		/// <summary>
		/// <para>Row Standardization</para>
		/// </summary>
		public enum RowStandardizationEnum 
		{
			/// <summary>
			/// <para>Checked—Spatial weights are standardized by row. Each weight is divided by its row sum.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_STANDARDIZATION")]
			ROW_STANDARDIZATION,

			/// <summary>
			/// <para>Unchecked—No standardization of spatial weights is applied.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STANDARDIZATION")]
			NO_STANDARDIZATION,

		}

#endregion
	}
}
