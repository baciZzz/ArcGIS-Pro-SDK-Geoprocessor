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
	/// <para>Time Series Clustering</para>
	/// <para>Time Series Clustering</para>
	/// <para>Partitions a collection of time series, stored in a space-time cube, based on the similarity of time series characteristics. Time series can be clustered based on three criteria: having similar values across time, tending to increase and decrease at the same time, and having similar repeating patterns. The output of this tool is a 2D map displaying each location in the cube symbolized by cluster membership and messages. The output also includes charts containing information about the representative time series signature for each cluster.</para>
	/// </summary>
	public class TimeSeriesClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube to be analyzed. This file must have an .nc extension and must have been created using the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Features, or Create Space Time Cube From Multidimensional Raster Layer tool.</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file, changing over time, that will be used to distinguish one cluster from another.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The new output feature class containing all locations in the space-time cube and a field indicating cluster membership. This feature class will be a two-dimensional representation of the clusters in your data.</para>
		/// </param>
		/// <param name="CharacteristicOfInterest">
		/// <para>Characteristic of Interest</para>
		/// <para>Specifies the characteristic of the time series that will be used to determine which locations should be clustered together.</para>
		/// <para>Value— Locations with similar values across time will be clustered together.</para>
		/// <para>Profile (Correlation)—Locations with values that tend to increase and decrease proportionally at the same times will be clustered together.</para>
		/// <para>Profile (Fourier)—Locations with values that have similar smooth, periodic patterns will be clustered together.</para>
		/// <para><see cref="CharacteristicOfInterestEnum"/></para>
		/// </param>
		public TimeSeriesClustering(object InCube, object AnalysisVariable, object OutputFeatures, object CharacteristicOfInterest)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
			this.CharacteristicOfInterest = CharacteristicOfInterest;
		}

		/// <summary>
		/// <para>Tool Display Name : Time Series Clustering</para>
		/// </summary>
		public override string DisplayName() => "Time Series Clustering";

		/// <summary>
		/// <para>Tool Name : TimeSeriesClustering</para>
		/// </summary>
		public override string ToolName() => "TimeSeriesClustering";

		/// <summary>
		/// <para>Tool Excute Name : stpm.TimeSeriesClustering</para>
		/// </summary>
		public override string ExcuteName() => "stpm.TimeSeriesClustering";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, CharacteristicOfInterest, ClusterCount, OutputTableForCharts, ShapeCharacteristicToIgnore, EnableTimeSeriesPopups };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube to be analyzed. This file must have an .nc extension and must have been created using the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Features, or Create Space Time Cube From Multidimensional Raster Layer tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file, changing over time, that will be used to distinguish one cluster from another.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The new output feature class containing all locations in the space-time cube and a field indicating cluster membership. This feature class will be a two-dimensional representation of the clusters in your data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Characteristic of Interest</para>
		/// <para>Specifies the characteristic of the time series that will be used to determine which locations should be clustered together.</para>
		/// <para>Value— Locations with similar values across time will be clustered together.</para>
		/// <para>Profile (Correlation)—Locations with values that tend to increase and decrease proportionally at the same times will be clustered together.</para>
		/// <para>Profile (Fourier)—Locations with values that have similar smooth, periodic patterns will be clustered together.</para>
		/// <para><see cref="CharacteristicOfInterestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CharacteristicOfInterest { get; set; }

		/// <summary>
		/// <para>Number of Clusters</para>
		/// <para>The number of clusters to create. When left empty, the tool will evaluate the optimal number of clusters using a pseudo-F statistic. The optimal number of clusters will be reported in the messages window.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ClusterCount { get; set; }

		/// <summary>
		/// <para>Output Table for Charts</para>
		/// <para>If specified, this table contains the representative time series for each cluster based on both the average for each time series cluster and the medoid time series. Charts created from this table can be accessed in the Standalone Tables section.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutputTableForCharts { get; set; }

		/// <summary>
		/// <para>Time Series Characteristics to Ignore</para>
		/// <para>Specifies characteristics that will be ignored when determining the similarity between two time series.</para>
		/// <para>Time lag— The starting time of each period, including time lags, will be ignored. For example, if two time series have similar periodic patterns, but the values of one are three days behind the other, the time series will be considered similar.</para>
		/// <para>Range—The magnitude of the values in each period will be ignored. For example, if two time series begin and end their periods at the same times, they will be considered similar, even if the actual values are very different.</para>
		/// <para>If both characteristics are ignored, two time series will be considered similar if the durations of the periods are similar, even if they start at different times and have different values within the periods.</para>
		/// <para><see cref="ShapeCharacteristicToIgnoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ShapeCharacteristicToIgnore { get; set; }

		/// <summary>
		/// <para>Enable Time Series Pop-ups</para>
		/// <para>Specifies whether time series charts will be created in the pop-ups of each output feature showing the time series of the feature and the average time series of all features in the same cluster as the feature.</para>
		/// <para>Checked—Time series charts will be created for the output features.</para>
		/// <para>Unchecked—Time series charts will not be created. This is the default.</para>
		/// <para><see cref="EnableTimeSeriesPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnableTimeSeriesPopups { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TimeSeriesClustering SetEnviroment(object parallelProcessingFactor = null, object randomGenerator = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Characteristic of Interest</para>
		/// </summary>
		public enum CharacteristicOfInterestEnum 
		{
			/// <summary>
			/// <para>Value— Locations with similar values across time will be clustered together.</para>
			/// </summary>
			[GPValue("VALUE")]
			[Description("Value")]
			Value,

			/// <summary>
			/// <para>Profile (Correlation)—Locations with values that tend to increase and decrease proportionally at the same times will be clustered together.</para>
			/// </summary>
			[GPValue("PROFILE")]
			[Description("Profile (Correlation)")]
			PROFILE,

			/// <summary>
			/// <para>Profile (Fourier)—Locations with values that have similar smooth, periodic patterns will be clustered together.</para>
			/// </summary>
			[GPValue("PROFILE_FOURIER")]
			[Description("Profile (Fourier)")]
			PROFILE_FOURIER,

		}

		/// <summary>
		/// <para>Time Series Characteristics to Ignore</para>
		/// </summary>
		public enum ShapeCharacteristicToIgnoreEnum 
		{
			/// <summary>
			/// <para>Time lag— The starting time of each period, including time lags, will be ignored. For example, if two time series have similar periodic patterns, but the values of one are three days behind the other, the time series will be considered similar.</para>
			/// </summary>
			[GPValue("TIME_LAG")]
			[Description("Time lag")]
			Time_lag,

			/// <summary>
			/// <para>Range—The magnitude of the values in each period will be ignored. For example, if two time series begin and end their periods at the same times, they will be considered similar, even if the actual values are very different.</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("Range")]
			Range,

		}

		/// <summary>
		/// <para>Enable Time Series Pop-ups</para>
		/// </summary>
		public enum EnableTimeSeriesPopupsEnum 
		{
			/// <summary>
			/// <para>Checked—Time series charts will be created for the output features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_POPUP")]
			CREATE_POPUP,

			/// <summary>
			/// <para>Unchecked—Time series charts will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POPUP")]
			NO_POPUP,

		}

#endregion
	}
}
