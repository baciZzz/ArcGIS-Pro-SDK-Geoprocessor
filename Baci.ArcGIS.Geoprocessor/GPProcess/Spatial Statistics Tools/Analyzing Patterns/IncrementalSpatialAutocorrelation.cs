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
	/// <para>Incremental Spatial Autocorrelation</para>
	/// <para>Measures spatial autocorrelation for a series of distances and optionally creates a line graph of those distances and their corresponding z-scores.  Z-scores reflect the intensity of spatial clustering, and statistically significant peak z-scores indicate distances where spatial processes promoting clustering are most pronounced.  These peak distances are often appropriate values to use for tools with a Distance Band or Distance Radius parameter.</para>
	/// </summary>
	public class IncrementalSpatialAutocorrelation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class for which spatial autocorrelation will be measured over a series of distances.</para>
		/// </param>
		/// <param name="InputField">
		/// <para>Input Field</para>
		/// <para>The numeric field used in assessing spatial autocorrelation.</para>
		/// </param>
		/// <param name="NumberOfDistanceBands">
		/// <para>Number of Distance Bands</para>
		/// <para>The number of times to increment the neighborhood size and analyze the dataset for spatial autocorrelation. The starting point and size of the increment are specified in the Beginning Distance and Distance Increment parameters, respectively.</para>
		/// </param>
		public IncrementalSpatialAutocorrelation(object InputFeatures, object InputField, object NumberOfDistanceBands)
		{
			this.InputFeatures = InputFeatures;
			this.InputField = InputField;
			this.NumberOfDistanceBands = NumberOfDistanceBands;
		}

		/// <summary>
		/// <para>Tool Display Name : Incremental Spatial Autocorrelation</para>
		/// </summary>
		public override string DisplayName => "Incremental Spatial Autocorrelation";

		/// <summary>
		/// <para>Tool Name : IncrementalSpatialAutocorrelation</para>
		/// </summary>
		public override string ToolName => "IncrementalSpatialAutocorrelation";

		/// <summary>
		/// <para>Tool Excute Name : stats.IncrementalSpatialAutocorrelation</para>
		/// </summary>
		public override string ExcuteName => "stats.IncrementalSpatialAutocorrelation";

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
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatures, InputField, NumberOfDistanceBands, BeginningDistance, DistanceIncrement, DistanceMethod, RowStandardization, OutputTable, OutputReportFile, FirstPeak, MaxPeak };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class for which spatial autocorrelation will be measured over a series of distances.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Input Field</para>
		/// <para>The numeric field used in assessing spatial autocorrelation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object InputField { get; set; }

		/// <summary>
		/// <para>Number of Distance Bands</para>
		/// <para>The number of times to increment the neighborhood size and analyze the dataset for spatial autocorrelation. The starting point and size of the increment are specified in the Beginning Distance and Distance Increment parameters, respectively.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 30)]
		public object NumberOfDistanceBands { get; set; } = "10";

		/// <summary>
		/// <para>Beginning Distance</para>
		/// <para>The distance at which to start the analysis of spatial autocorrelation and the distance from which to increment. The value entered for this parameter should be in the units of the Output Coordinate System environment setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999)]
		public object BeginningDistance { get; set; }

		/// <summary>
		/// <para>Distance Increment</para>
		/// <para>The distance to increase after each iteration. The distance used in the analysis starts at the Beginning Distance and increases by the amount specified in the Distance Increment. The value entered for this parameter should be in the units of the Output Coordinate System environment setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-09, Max = 999999999)]
		public object DistanceIncrement { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN";

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>Row standardization is recommended whenever the distribution of your features is potentially biased due to sampling design or an imposed aggregation scheme.</para>
		/// <para>Checked—Spatial weights will be standardized; each weight is divided by its row sum (the sum of the weights of all neighboring features).</para>
		/// <para>Unchecked—No standardization of spatial weights is applied.</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table to be created with each distance band and associated z-score result.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>The PDF file to be created containing a line graph summarizing results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object OutputReportFile { get; set; }

		/// <summary>
		/// <para>First Peak</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object FirstPeak { get; set; }

		/// <summary>
		/// <para>Maximum Peak</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MaxPeak { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IncrementalSpatialAutocorrelation SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
			/// </summary>
			[GPValue("EUCLIDEAN")]
			[Description("Euclidean")]
			Euclidean,

			/// <summary>
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
			/// </summary>
			[GPValue("MANHATTAN")]
			[Description("Manhattan")]
			Manhattan,

		}

		/// <summary>
		/// <para>Row Standardization</para>
		/// </summary>
		public enum RowStandardizationEnum 
		{
			/// <summary>
			/// <para>Checked—Spatial weights will be standardized; each weight is divided by its row sum (the sum of the weights of all neighboring features).</para>
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
