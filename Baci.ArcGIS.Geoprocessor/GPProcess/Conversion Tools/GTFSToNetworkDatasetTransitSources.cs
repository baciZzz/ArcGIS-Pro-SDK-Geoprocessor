using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>GTFS To Network Dataset Transit Sources</para>
	/// <para>Converts one or more General Transit Feed Specification (GTFS) public transit datasets to a set of feature classes and tables that can be used when creating a network dataset. The output feature classes and tables represent the transit stops, lines, and schedules in the format defined by the Network Analyst public transit data model, which can be interpreted by the Public Transit evaluator in a network dataset.</para>
	/// </summary>
	[Obsolete()]
	public class GTFSToNetworkDatasetTransitSources : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsFolders">
		/// <para>Input GTFS Folders</para>
		/// <para>One or more folders containing valid GTFS data. Each folder must contain the GTFS stops.txt, routes.txt, trips.txt, and stop_times.txt files and either the calendar.txt or calendar_dates.txt file, or both.</para>
		/// </param>
		/// <param name="TargetFeatureDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset where the transit-enabled network dataset will be created. The Stops and LineVariantElements feature classes created by this tool will be placed in this feature dataset, and the output tables created by this tool will be placed in this feature dataset&apos;s parent geodatabase.</para>
		/// <para>The feature dataset can be in a file geodatabase or an enterprise geodatabase and can have any spatial reference. If the target feature dataset is in an enterprise geodatabase, it must not be versioned. Do not include the target feature dataset in a geodatabase with an existing feature dataset containing public transit data model feature classes.</para>
		/// </param>
		public GTFSToNetworkDatasetTransitSources(object InGtfsFolders, object TargetFeatureDataset)
		{
			this.InGtfsFolders = InGtfsFolders;
			this.TargetFeatureDataset = TargetFeatureDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : GTFS To Network Dataset Transit Sources</para>
		/// </summary>
		public override string DisplayName => "GTFS To Network Dataset Transit Sources";

		/// <summary>
		/// <para>Tool Name : GTFSToNetworkDatasetTransitSources</para>
		/// </summary>
		public override string ToolName => "GTFSToNetworkDatasetTransitSources";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GTFSToNetworkDatasetTransitSources</para>
		/// </summary>
		public override string ExcuteName => "conversion.GTFSToNetworkDatasetTransitSources";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InGtfsFolders, TargetFeatureDataset, UpdatedTargetFeatureDataset!, OutputStops!, OutputLineVariantElements!, OutputCalendars!, OutputCalendarExceptions!, OutputLines!, OutputLineVariants!, OutputRuns!, OutputScheduleElements!, OutputSchedules!, Interpolate!, Append! };

		/// <summary>
		/// <para>Input GTFS Folders</para>
		/// <para>One or more folders containing valid GTFS data. Each folder must contain the GTFS stops.txt, routes.txt, trips.txt, and stop_times.txt files and either the calendar.txt or calendar_dates.txt file, or both.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InGtfsFolders { get; set; }

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset where the transit-enabled network dataset will be created. The Stops and LineVariantElements feature classes created by this tool will be placed in this feature dataset, and the output tables created by this tool will be placed in this feature dataset&apos;s parent geodatabase.</para>
		/// <para>The feature dataset can be in a file geodatabase or an enterprise geodatabase and can have any spatial reference. If the target feature dataset is in an enterprise geodatabase, it must not be versioned. Do not include the target feature dataset in a geodatabase with an existing feature dataset containing public transit data model feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Updated Target Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? UpdatedTargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutputStops { get; set; }

		/// <summary>
		/// <para>Output Line Variant Elements</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutputLineVariantElements { get; set; }

		/// <summary>
		/// <para>Output Calendars</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutputCalendars { get; set; }

		/// <summary>
		/// <para>Output Calendar Exceptions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutputCalendarExceptions { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutputLines { get; set; }

		/// <summary>
		/// <para>Output Line Variants</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutputLineVariants { get; set; }

		/// <summary>
		/// <para>Output Runs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutputRuns { get; set; }

		/// <summary>
		/// <para>Output Schedule Elements</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutputScheduleElements { get; set; }

		/// <summary>
		/// <para>Output Schedules</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutputSchedules { get; set; }

		/// <summary>
		/// <para>Interpolate blank stop times</para>
		/// <para>Specifies whether blank values from the arrival_time and departure_time fields in the GTFS stop_times.txt file will be interpolated when creating the public transit data model tables.</para>
		/// <para>Checked—Blank values will be interpolated using simple linear interpolation. The original GTFS data will not be altered. If there are no blank values in the original data, no interpolation will occur.</para>
		/// <para>Unchecked—Blank values will not be interpolated. If blank values are found in the input GTFS data, the tool will issue a warning and will not process the GTFS dataset. This is the default.</para>
		/// <para><see cref="InterpolateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Interpolate { get; set; } = "false";

		/// <summary>
		/// <para>Append to existing tables</para>
		/// <para>Specifies whether the input GTFS datasets will be appended to existing public transit data model feature classes and tables in the target feature dataset and its parent geodatabase.</para>
		/// <para>This parameter will be hidden if the target feature dataset and its parent geodatabase do not contain existing public transit data model feature classes and tables.</para>
		/// <para>Checked—Data will be appended to the existing feature classes and tables.</para>
		/// <para>Unchecked—Existing feature classes and tables will be overwritten. This is the default.</para>
		/// <para><see cref="AppendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Append { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Interpolate blank stop times</para>
		/// </summary>
		public enum InterpolateEnum 
		{
			/// <summary>
			/// <para>Checked—Blank values will be interpolated using simple linear interpolation. The original GTFS data will not be altered. If there are no blank values in the original data, no interpolation will occur.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INTERPOLATE")]
			INTERPOLATE,

			/// <summary>
			/// <para>Unchecked—Blank values will not be interpolated. If blank values are found in the input GTFS data, the tool will issue a warning and will not process the GTFS dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INTERPOLATE")]
			NO_INTERPOLATE,

		}

		/// <summary>
		/// <para>Append to existing tables</para>
		/// </summary>
		public enum AppendEnum 
		{
			/// <summary>
			/// <para>Checked—Data will be appended to the existing feature classes and tables.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—Existing feature classes and tables will be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPEND")]
			NO_APPEND,

		}

#endregion
	}
}
