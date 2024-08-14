using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Find Frequented Locations</para>
	/// <para>Identifies areas where a movement track has dwelled for multiple time periods and aggregates those locations based on a track identifier.</para>
	/// </summary>
	public class FindFrequentedLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input movement track points that will be analyzed for possible frequented locations. The layer must be time enabled.</para>
		/// </param>
		/// <param name="TrackIdField">
		/// <para>Track ID Field</para>
		/// <para>The field containing the unique identifiers that will organize the source data into movement tracks.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the possible frequented locations.</para>
		/// </param>
		public FindFrequentedLocations(object InFeatures, object TrackIdField, object OutFeatureclass)
		{
			this.InFeatures = InFeatures;
			this.TrackIdField = TrackIdField;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Frequented Locations</para>
		/// </summary>
		public override string DisplayName => "Find Frequented Locations";

		/// <summary>
		/// <para>Tool Name : FindFrequentedLocations</para>
		/// </summary>
		public override string ToolName => "FindFrequentedLocations";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindFrequentedLocations</para>
		/// </summary>
		public override string ExcuteName => "intelligence.FindFrequentedLocations";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, TrackIdField, OutFeatureclass, Expression!, SearchDistance!, MinimumLoiterTime!, TimeBoundary!, MinimumDwells!, NormalizeDailyDistribution!, SummaryFields! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input movement track points that will be analyzed for possible frequented locations. The layer must be time enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Track ID Field</para>
		/// <para>The field containing the unique identifiers that will organize the source data into movement tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object TrackIdField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the possible frequented locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The maximum distance a movement track point can loiter before it is no longer considered part of a frequented location. The default is 100 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Minimum Loiter Time</para>
		/// <para>The minimum amount of time a movement track point can loiter in an area before it is considered to be dwelling.</para>
		/// <para>This value helps identify possible frequented locations where multiple unique movement tracks are dwelling in the same time and space. The default is 10 minutes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? MinimumLoiterTime { get; set; } = "10 Minutes";

		/// <summary>
		/// <para>Time Boundary</para>
		/// <para>The time span that will be used to split the Input Features parameter value. For example, if you use a time boundary of 1 day, tracks will be split at the beginning of every day.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeBoundary { get; set; } = "1 Days";

		/// <summary>
		/// <para>Minimum Dwells Per Location</para>
		/// <para>The minimum number of overlapping individual dwells that will need to occur to be defined as a frequented location. By default, all locations that meet the criteria for a dwell will be returned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinimumDwells { get; set; } = "1";

		/// <summary>
		/// <para>Normalize Daily Distribution</para>
		/// <para>Specifies whether the daily distribution of dwell locations will be normalized. Normalized values represent a percentage of total time that a dwell location occurred on the particular day, while the real values represent the total number of dwells that occurred on the given day.</para>
		/// <para>Checked—The daily distribution of dwell locations values will be normalized.</para>
		/// <para>Unchecked—The daily distribution of dwell locations values will not be normalized. This is the default.</para>
		/// <para><see cref="NormalizeDailyDistributionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NormalizeDailyDistribution { get; set; } = "false";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>Specifies the statistics that will be calculated.</para>
		/// <para>Statistics can be calculated for the following variables:</para>
		/// <para>Start Time—The time in hours that the individual dwell location was first detected. The time is rounded to the nearest hour.</para>
		/// <para>End Time—The time in hours that the individual dwell location was last detected. The time is rounded to the nearest hour.</para>
		/// <para>Dwell Duration—The time in seconds that the individual dwell location was active.</para>
		/// <para>The following statistics are supported:</para>
		/// <para>Mean—The mean of numeric values.</para>
		/// <para>Min—The minimum value of a numeric field.</para>
		/// <para>Max—The maximum value of a numeric field.</para>
		/// <para>Standard Deviation—The standard deviation of a numeric field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindFrequentedLocations SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Normalize Daily Distribution</para>
		/// </summary>
		public enum NormalizeDailyDistributionEnum 
		{
			/// <summary>
			/// <para>Checked—The daily distribution of dwell locations values will be normalized.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NORMALIZED")]
			NORMALIZED,

			/// <summary>
			/// <para>Unchecked—The daily distribution of dwell locations values will not be normalized. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("REAL")]
			REAL,

		}

#endregion
	}
}
