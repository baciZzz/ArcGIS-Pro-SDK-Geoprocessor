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
	/// <para>Select Movement Tracks</para>
	/// <para>Select Movement Tracks</para>
	/// <para>Selects movement tracks based on an  area of interest.</para>
	/// </summary>
	public class SelectMovementTracks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features that will be compared with the Area Of Interest parameter value to identify unique tracks and select the relevant tracks.</para>
		/// </param>
		/// <param name="TrackIdField">
		/// <para>Track ID Field</para>
		/// <para>The field containing the unique identifiers for the movement track points. The field can be either a number or a string.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area Of Interest</para>
		/// <para>The feature or features that will be compared with the Input Features value to determine the tracks to select.</para>
		/// </param>
		public SelectMovementTracks(object InFeatures, object TrackIdField, object AreaOfInterest)
		{
			this.InFeatures = InFeatures;
			this.TrackIdField = TrackIdField;
			this.AreaOfInterest = AreaOfInterest;
		}

		/// <summary>
		/// <para>Tool Display Name : Select Movement Tracks</para>
		/// </summary>
		public override string DisplayName() => "Select Movement Tracks";

		/// <summary>
		/// <para>Tool Name : SelectMovementTracks</para>
		/// </summary>
		public override string ToolName() => "SelectMovementTracks";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.SelectMovementTracks</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.SelectMovementTracks";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, TrackIdField, AreaOfInterest, TimeRelationship!, SelectionTime!, UpdatedFeatureclass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features that will be compared with the Area Of Interest parameter value to identify unique tracks and select the relevant tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Track ID Field</para>
		/// <para>The field containing the unique identifiers for the movement track points. The field can be either a number or a string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object TrackIdField { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>The feature or features that will be compared with the Input Features value to determine the tracks to select.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Time Relationship</para>
		/// <para>Specifies the time relationship between the Input Features and Area Of Interest parameter values. If the Before, After, or Before and after option is specified, only features that are present in the Area Of Interest value within the specified time window will be included in the output selection.</para>
		/// <para>Before and after—When a feature&apos;s time is before the first time identified and after the last time identified for the Area Of Interest value but within the specified range of time from the first identified time and the last identified time, the time relationship will be before and after the selection time.</para>
		/// <para>Before—When a feature&apos;s time is before the first time identified for the Area Of Interest value but within the specified range of time from the first identified time, the time relationship will be before the selection time.</para>
		/// <para>After—When a feature&apos;s time is after the last time identified for the Area Of Interest value but within the specified range of time from the last identified time, the time relationship will be after the selection time.</para>
		/// <para>None—All tracks associated with the unique identifier specified in Track ID Field that are present in the Area Of Interest value will be returned.</para>
		/// <para><see cref="TimeRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeRelationship { get; set; } = "NONE";

		/// <summary>
		/// <para>Selection Time</para>
		/// <para>The time frame that will be used to select features if Before, After, or Before and after is specified for the Time Relationship parameter.</para>
		/// <para>If Before or Before and after is specified, the earliest time selected will be the first identified time of the features selected from the initial selection generated from the Input Features and Area Of Interest parameters, subtracting the time value specified. If After or Before and after is specified, the selection time will be added to the latest time from the initial selection to determine the selected features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object? SelectionTime { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedFeatureclass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Time Relationship</para>
		/// </summary>
		public enum TimeRelationshipEnum 
		{
			/// <summary>
			/// <para>Before and after—When a feature&apos;s time is before the first time identified and after the last time identified for the Area Of Interest value but within the specified range of time from the first identified time and the last identified time, the time relationship will be before and after the selection time.</para>
			/// </summary>
			[GPValue("BEFORE_AFTER")]
			[Description("Before and after")]
			Before_and_after,

			/// <summary>
			/// <para>Before and after—When a feature&apos;s time is before the first time identified and after the last time identified for the Area Of Interest value but within the specified range of time from the first identified time and the last identified time, the time relationship will be before and after the selection time.</para>
			/// </summary>
			[GPValue("BEFORE")]
			[Description("Before")]
			Before,

			/// <summary>
			/// <para>After—When a feature&apos;s time is after the last time identified for the Area Of Interest value but within the specified range of time from the last identified time, the time relationship will be after the selection time.</para>
			/// </summary>
			[GPValue("AFTER")]
			[Description("After")]
			After,

			/// <summary>
			/// <para>None—All tracks associated with the unique identifier specified in Track ID Field that are present in the Area Of Interest value will be returned.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

#endregion
	}
}
