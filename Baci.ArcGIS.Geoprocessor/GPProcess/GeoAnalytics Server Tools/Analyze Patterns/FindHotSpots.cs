using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Find Hot Spots</para>
	/// <para>Find Hot Spots</para>
	/// <para>Given a set of features, identifies statistically significant hot spots and cold spots using the Getis-Ord Gi* statistic.</para>
	/// </summary>
	public class FindHotSpots : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PointLayer">
		/// <para>Point Layer</para>
		/// <para>The point feature class for which hot spot analysis will be performed.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output layer with the z-score and p-value results.</para>
		/// </param>
		public FindHotSpots(object PointLayer, object OutputName)
		{
			this.PointLayer = PointLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Hot Spots</para>
		/// </summary>
		public override string DisplayName() => "Find Hot Spots";

		/// <summary>
		/// <para>Tool Name : FindHotSpots</para>
		/// </summary>
		public override string ToolName() => "FindHotSpots";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.FindHotSpots</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.FindHotSpots";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { PointLayer, OutputName, BinSize, NeighborhoodSize, TimeStepInterval, TimeStepAlignment, TimeStepReference, Output, DataStore };

		/// <summary>
		/// <para>Point Layer</para>
		/// <para>The point feature class for which hot spot analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object PointLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer with the z-score and p-value results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>The distance interval that represents the bin size and units into which the Point Layer will be aggregated. The distance interval must be a linear unit.</para>
		/// <para><see cref="BinSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object BinSize { get; set; }

		/// <summary>
		/// <para>Neighborhood Size</para>
		/// <para>The spatial extent of the analysis neighborhood. This value determines which features are analyzed together to assess local clustering.</para>
		/// <para><see cref="NeighborhoodSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object NeighborhoodSize { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>The interval that will be used for the time step. This parameter is only used if time is enabled for Point Layer.</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>Specifies how time steps will be aligned. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// <para>End time—Time steps will align to the last time event and aggregate back in time.</para>
		/// <para>Start time—Time steps will align to the first time event and aggregate forward in time. This is the default.</para>
		/// <para>Reference time—Time steps will align to a specified date or time. If all points in the input features have a time stamp larger than the specified reference time (or it falls exactly on the start time of the input features), the time-step interval will begin with that reference time and aggregate forward in time (as occurs with the Start time alignment). If all points in the input features have a time stamp smaller than the specified reference time (or it falls exactly on the end time of the input features), the time-step interval will end with that reference time and aggregate backward in time (as occurs with the End time alignment). If the specified reference time is in the middle of the time extent of the data, a time-step interval will be created ending with the reference time provided (as occurs with the End time alignment); additional intervals will be created both before and after the reference time until the full time extent of the data is covered.</para>
		/// <para><see cref="TimeStepAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeStepAlignment { get; set; } = "START_TIME";

		/// <summary>
		/// <para>Time Step Reference</para>
		/// <para>The time that will be used to align the time steps and time intervals. This parameter is only used if time is enabled for Point Layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeStepReference { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindHotSpots SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bin Size</para>
		/// </summary>
		public enum BinSizeEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

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

		}

		/// <summary>
		/// <para>Neighborhood Size</para>
		/// </summary>
		public enum NeighborhoodSizeEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

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

		}

		/// <summary>
		/// <para>Time Step Interval</para>
		/// </summary>
		public enum TimeStepIntervalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

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
		/// <para>Time Step Alignment</para>
		/// </summary>
		public enum TimeStepAlignmentEnum 
		{
			/// <summary>
			/// <para>Start time—Time steps will align to the first time event and aggregate forward in time. This is the default.</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("Start time")]
			Start_time,

			/// <summary>
			/// <para>End time—Time steps will align to the last time event and aggregate back in time.</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("End time")]
			End_time,

			/// <summary>
			/// <para>Reference time—Time steps will align to a specified date or time. If all points in the input features have a time stamp larger than the specified reference time (or it falls exactly on the start time of the input features), the time-step interval will begin with that reference time and aggregate forward in time (as occurs with the Start time alignment). If all points in the input features have a time stamp smaller than the specified reference time (or it falls exactly on the end time of the input features), the time-step interval will end with that reference time and aggregate backward in time (as occurs with the End time alignment). If the specified reference time is in the middle of the time extent of the data, a time-step interval will be created ending with the reference time provided (as occurs with the End time alignment); additional intervals will be created both before and after the reference time until the full time extent of the data is covered.</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("Reference time")]
			Reference_time,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

#endregion
	}
}
