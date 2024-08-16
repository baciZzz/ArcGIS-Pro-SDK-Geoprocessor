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
	/// <para>Multi-Distance Spatial Cluster Analysis (Ripley's K Function)</para>
	/// <para>Determines whether features, or the values associated with features, exhibit statistically significant clustering or dispersion over a range of distances.</para>
	/// </summary>
	public class MultiDistanceSpatialClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class upon which the analysis will be performed.</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>The table to which the results of the analysis will be written.</para>
		/// </param>
		/// <param name="NumberOfDistanceBands">
		/// <para>Number of Distance Bands</para>
		/// <para>The number of times to increment the neighborhood size and analyze the dataset for clustering. The starting point and size of the increment are specified in the Beginning Distance and Distance Increment parameters, respectively.</para>
		/// </param>
		public MultiDistanceSpatialClustering(object InputFeatureClass, object OutputTable, object NumberOfDistanceBands)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputTable = OutputTable;
			this.NumberOfDistanceBands = NumberOfDistanceBands;
		}

		/// <summary>
		/// <para>Tool Display Name : Multi-Distance Spatial Cluster Analysis (Ripley's K Function)</para>
		/// </summary>
		public override string DisplayName => "Multi-Distance Spatial Cluster Analysis (Ripley's K Function)";

		/// <summary>
		/// <para>Tool Name : MultiDistanceSpatialClustering</para>
		/// </summary>
		public override string ToolName => "MultiDistanceSpatialClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.MultiDistanceSpatialClustering</para>
		/// </summary>
		public override string ExcuteName => "stats.MultiDistanceSpatialClustering";

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
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatureClass, OutputTable, NumberOfDistanceBands, ComputeConfidenceEnvelope, DisplayResultsGraphically, WeightField, BeginningDistance, DistanceIncrement, BoundaryCorrectionMethod, StudyAreaMethod, StudyAreaFeatureClass, ResultImage };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class upon which the analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table to which the results of the analysis will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Number of Distance Bands</para>
		/// <para>The number of times to increment the neighborhood size and analyze the dataset for clustering. The starting point and size of the increment are specified in the Beginning Distance and Distance Increment parameters, respectively.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		public object NumberOfDistanceBands { get; set; } = "10";

		/// <summary>
		/// <para>Compute Confidence Envelope</para>
		/// <para>The confidence envelope is calculated by randomly placing feature points (or feature values) in the study area. The number of points/values randomly placed is equal to the number of points in the feature class. Each set of random placements is called a permutation and the confidence envelope is created from these permutations. This parameter allows you to select how many permutations you want to use to create the confidence envelope.</para>
		/// <para>0 permutations - no confidence envelope—Confidence envelopes are not created.</para>
		/// <para>9 permutations—Nine sets of points/values are randomly placed.</para>
		/// <para>99 permutations—99 sets of points/values are randomly placed.</para>
		/// <para>999 permutations—999 sets of points/values are randomly placed.</para>
		/// <para><see cref="ComputeConfidenceEnvelopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ComputeConfidenceEnvelope { get; set; } = "0_PERMUTATIONS_-_NO_CONFIDENCE_ENVELOPE";

		/// <summary>
		/// <para>Display Results Graphically</para>
		/// <para>This parameter has no effect; it remains to support backward compatibility.</para>
		/// <para><see cref="DisplayResultsGraphicallyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DisplayResultsGraphically { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>A numeric field with weights representing the number of features/events at each location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Beginning Distance</para>
		/// <para>The distance at which to start the cluster analysis and the distance from which to increment. The value entered for this parameter should be in the units of the Output Coordinate System.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 9999999)]
		public object BeginningDistance { get; set; }

		/// <summary>
		/// <para>Distance Increment</para>
		/// <para>The distance to increment during each iteration. The distance used in the analysis starts at the Beginning Distance and increments by the amount specified in the Distance Increment. The value entered for this parameter should be in the units of the Output Coordinate System environment setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 9999999)]
		public object DistanceIncrement { get; set; }

		/// <summary>
		/// <para>Boundary Correction Method</para>
		/// <para>Method to use to correct for underestimates in the number of neighbors for features near the edges of the study area.</para>
		/// <para>None—No edge correction is applied. However, if the input feature class already has points that fall outside the study area boundaries, these will be used in neighborhood counts for features near boundaries.</para>
		/// <para>Simulate outer boundary values—This method simulates points outside the study area so that the number of neighbors near edges is not underestimated. The simulated points are the &quot;mirrors&quot; of points near edges within the study area boundary.</para>
		/// <para>Reduce analysis area—This method shrinks the study area such that some points are found outside of the study area boundary. Points found outside the study area are used to calculate neighbor counts but are not used in the cluster analysis itself.</para>
		/// <para>Ripley&apos;s edge correction formula—For all the points (j) in the neighborhood of point i, this method checks to see if the edge of the study area is closer to i, or if j is closer to i. If j is closer, extra weight is given to the point j. This edge correction method is only appropriate for square or rectangular shaped study areas.</para>
		/// <para><see cref="BoundaryCorrectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BoundaryCorrectionMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Study Area Method</para>
		/// <para>Specifies the region to use for the study area. The K Function is sensitive to changes in study area size so careful selection of this value is important.</para>
		/// <para>Minimum enclosing rectangle—Indicates that the smallest possible rectangle enclosing all of the points will be used.</para>
		/// <para>User provided study area feature class—Indicates that a feature class defining the study area will be provided in the Study Area Feature Class parameter.</para>
		/// <para><see cref="StudyAreaMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StudyAreaMethod { get; set; } = "MINIMUM_ENCLOSING_RECTANGLE";

		/// <summary>
		/// <para>Study Area Feature Class</para>
		/// <para>Feature class that delineates the area over which the input feature class should be analyzed. Only to be specified if User provided study area feature class is selected for the Study Area Method parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object StudyAreaFeatureClass { get; set; }

		/// <summary>
		/// <para>Result Graph</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGraph()]
		public object ResultImage { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultiDistanceSpatialClustering SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object randomGenerator = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute Confidence Envelope</para>
		/// </summary>
		public enum ComputeConfidenceEnvelopeEnum 
		{
			/// <summary>
			/// <para>0 permutations - no confidence envelope—Confidence envelopes are not created.</para>
			/// </summary>
			[GPValue("0_PERMUTATIONS_-_NO_CONFIDENCE_ENVELOPE")]
			[Description("0 permutations - no confidence envelope")]
			_0_PERMUTATIONS___NO_CONFIDENCE_ENVELOPE,

			/// <summary>
			/// <para>9 permutations—Nine sets of points/values are randomly placed.</para>
			/// </summary>
			[GPValue("9_PERMUTATIONS")]
			[Description("9 permutations")]
			_9_permutations,

			/// <summary>
			/// <para>99 permutations—99 sets of points/values are randomly placed.</para>
			/// </summary>
			[GPValue("99_PERMUTATIONS")]
			[Description("99 permutations")]
			_99_permutations,

			/// <summary>
			/// <para>999 permutations—999 sets of points/values are randomly placed.</para>
			/// </summary>
			[GPValue("999_PERMUTATIONS")]
			[Description("999 permutations")]
			_999_permutations,

		}

		/// <summary>
		/// <para>Display Results Graphically</para>
		/// </summary>
		public enum DisplayResultsGraphicallyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISPLAY_IT")]
			DISPLAY_IT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISPLAY")]
			NO_DISPLAY,

		}

		/// <summary>
		/// <para>Boundary Correction Method</para>
		/// </summary>
		public enum BoundaryCorrectionMethodEnum 
		{
			/// <summary>
			/// <para>None—No edge correction is applied. However, if the input feature class already has points that fall outside the study area boundaries, these will be used in neighborhood counts for features near boundaries.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Simulate outer boundary values—This method simulates points outside the study area so that the number of neighbors near edges is not underestimated. The simulated points are the &quot;mirrors&quot; of points near edges within the study area boundary.</para>
			/// </summary>
			[GPValue("SIMULATE_OUTER_BOUNDARY_VALUES")]
			[Description("Simulate outer boundary values")]
			Simulate_outer_boundary_values,

			/// <summary>
			/// <para>Reduce analysis area—This method shrinks the study area such that some points are found outside of the study area boundary. Points found outside the study area are used to calculate neighbor counts but are not used in the cluster analysis itself.</para>
			/// </summary>
			[GPValue("REDUCE_ANALYSIS_AREA")]
			[Description("Reduce analysis area")]
			Reduce_analysis_area,

			/// <summary>
			/// <para>Ripley&apos;s edge correction formula—For all the points (j) in the neighborhood of point i, this method checks to see if the edge of the study area is closer to i, or if j is closer to i. If j is closer, extra weight is given to the point j. This edge correction method is only appropriate for square or rectangular shaped study areas.</para>
			/// </summary>
			[GPValue("RIPLEY_EDGE_CORRECTION_FORMULA")]
			[Description("Ripley's edge correction formula")]
			RIPLEY_EDGE_CORRECTION_FORMULA,

		}

		/// <summary>
		/// <para>Study Area Method</para>
		/// </summary>
		public enum StudyAreaMethodEnum 
		{
			/// <summary>
			/// <para>Minimum enclosing rectangle—Indicates that the smallest possible rectangle enclosing all of the points will be used.</para>
			/// </summary>
			[GPValue("MINIMUM_ENCLOSING_RECTANGLE")]
			[Description("Minimum enclosing rectangle")]
			Minimum_enclosing_rectangle,

			/// <summary>
			/// <para>User provided study area feature class—Indicates that a feature class defining the study area will be provided in the Study Area Feature Class parameter.</para>
			/// </summary>
			[GPValue("USER_PROVIDED_STUDY_AREA_FEATURE_CLASS")]
			[Description("User provided study area feature class")]
			User_provided_study_area_feature_class,

		}

#endregion
	}
}
