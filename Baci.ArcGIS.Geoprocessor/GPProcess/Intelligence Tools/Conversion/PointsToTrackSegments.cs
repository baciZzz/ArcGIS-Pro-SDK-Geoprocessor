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
	/// <para>Points To Track Segments</para>
	/// <para>Points To Track Segments</para>
	/// <para>Converts time-enabled sequences of input point data, such as GPS points, to a series of output paths.</para>
	/// </summary>
	public class PointsToTrackSegments : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>Point features as point positions along the tracks to be created.</para>
		/// </param>
		/// <param name="DateField">
		/// <para>Date Field</para>
		/// <para>The date field that will be used to order the Input Features points.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output track line features.</para>
		/// </param>
		public PointsToTrackSegments(object InFeatures, object DateField, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.DateField = DateField;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Points To Track Segments</para>
		/// </summary>
		public override string DisplayName() => "Points To Track Segments";

		/// <summary>
		/// <para>Tool Name : PointsToTrackSegments</para>
		/// </summary>
		public override string ToolName() => "PointsToTrackSegments";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.PointsToTrackSegments</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.PointsToTrackSegments";

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
		public override object[] Parameters() => new object[] { InFeatures, DateField, OutFeatureClass, GroupField!, IncludeVelocity!, OutPointFeatureClass!, ErrorOnDuplicateTimestamps!, KeepInputFields! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>Point features as point positions along the tracks to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>The date field that will be used to order the Input Features points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output track line features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; } = "out_tracks";

		/// <summary>
		/// <para>Group Field</para>
		/// <para>A field from the Input Features parameter that will be used to group the input points. Each unique group will create a separate track.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Include Velocity Fields</para>
		/// <para>Specifies whether velocity fields (speed_mps, speed_mph, speed_kph, and speed_knt) will be included in the Output Feature Class parameter value.</para>
		/// <para>Checked—Output velocity fields will be included in the output. This is the default.</para>
		/// <para>Unchecked—Output velocity fields will not be included in the output.</para>
		/// <para><see cref="IncludeVelocityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeVelocity { get; set; } = "true";

		/// <summary>
		/// <para>Output Sequence Points</para>
		/// <para>The output point features. The output will include a SEQUENCE field that contains the order that will be used for the path created in the Output Feature Class parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Error On Duplicate Timestamps</para>
		/// <para>Specifies whether duplicate time stamps in the Date Field parameter value or within each group in the Group Field parameter value will be accepted or cause the tool to fail.</para>
		/// <para>Checked—Duplicate time stamps will cause the tool to fail. This is the default.</para>
		/// <para>Unchecked—Duplicate time stamps will be accepted. The sequence of the duplicate time stamps is based on the ObjectID.</para>
		/// <para><see cref="ErrorOnDuplicateTimestampsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ErrorOnDuplicateTimestamps { get; set; } = "true";

		/// <summary>
		/// <para>Keep Input Fields</para>
		/// <para>Specifies whether fields will be transferred from the Input Features parameter value to the Output Sequence Points parameter value.</para>
		/// <para>Checked—Fields will be transferred from the Input Features parameter value to the Output Sequence Points parameter value.</para>
		/// <para>Unchecked—Fields will not be transferred from the Input Features parameter value to the Output Sequence Points parameter value. This is the default.</para>
		/// <para><see cref="KeepInputFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepInputFields { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Include Velocity Fields</para>
		/// </summary>
		public enum IncludeVelocityEnum 
		{
			/// <summary>
			/// <para>Checked—Output velocity fields will be included in the output. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_VELOCITY")]
			INCLUDE_VELOCITY,

			/// <summary>
			/// <para>Unchecked—Output velocity fields will not be included in the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_VELOCITY")]
			EXCLUDE_VELOCITY,

		}

		/// <summary>
		/// <para>Error On Duplicate Timestamps</para>
		/// </summary>
		public enum ErrorOnDuplicateTimestampsEnum 
		{
			/// <summary>
			/// <para>Checked—Duplicate time stamps will cause the tool to fail. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_DUPLICATE_TIMESTAMPS")]
			ERROR_DUPLICATE_TIMESTAMPS,

			/// <summary>
			/// <para>Unchecked—Duplicate time stamps will be accepted. The sequence of the duplicate time stamps is based on the ObjectID.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALLOW_DUPLICATE_TIMESTAMPS")]
			ALLOW_DUPLICATE_TIMESTAMPS,

		}

		/// <summary>
		/// <para>Keep Input Fields</para>
		/// </summary>
		public enum KeepInputFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Fields will be transferred from the Input Features parameter value to the Output Sequence Points parameter value.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_INPUT_FIELDS")]
			KEEP_INPUT_FIELDS,

			/// <summary>
			/// <para>Unchecked—Fields will not be transferred from the Input Features parameter value to the Output Sequence Points parameter value. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISCARD_INPUT_FIELDS")]
			DISCARD_INPUT_FIELDS,

		}

#endregion
	}
}
