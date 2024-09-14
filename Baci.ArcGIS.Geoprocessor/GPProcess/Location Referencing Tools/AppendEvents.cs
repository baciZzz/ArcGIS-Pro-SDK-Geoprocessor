using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Append Events</para>
	/// <para>Append Events</para>
	/// <para>Appends event records from a table, layer, or feature class to an existing ArcGIS Location Referencing event feature class.</para>
	/// </summary>
	public class AppendEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Event</para>
		/// <para>The source event records to append.</para>
		/// </param>
		/// <param name="InTargetEvent">
		/// <para>Target Event</para>
		/// <para>The Location Referencing event layer or feature class into which the source event records will be appended.</para>
		/// </param>
		/// <param name="FieldMapping">
		/// <para>Field Map</para>
		/// <para>Controls how the attribute information in fields of the Input Event is transferred to the Target Event.</para>
		/// <para>Because the data of the Input Event is appended into an existing event that has a predefined schema (field definitions), fields cannot be added or removed from the target dataset. While you can set merge rules for each output field, the tool ignores those rules.</para>
		/// </param>
		public AppendEvents(object InDataset, object InTargetEvent, object FieldMapping)
		{
			this.InDataset = InDataset;
			this.InTargetEvent = InTargetEvent;
			this.FieldMapping = FieldMapping;
		}

		/// <summary>
		/// <para>Tool Display Name : Append Events</para>
		/// </summary>
		public override string DisplayName() => "Append Events";

		/// <summary>
		/// <para>Tool Name : AppendEvents</para>
		/// </summary>
		public override string ToolName() => "AppendEvents";

		/// <summary>
		/// <para>Tool Excute Name : locref.AppendEvents</para>
		/// </summary>
		public override string ExcuteName() => "locref.AppendEvents";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, InTargetEvent, FieldMapping, LoadType, GenerateEventIds, GenerateShapes, OutTargetEvent, OutDetailsFile };

		/// <summary>
		/// <para>Input Event</para>
		/// <para>The source event records to append.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Target Event</para>
		/// <para>The Location Referencing event layer or feature class into which the source event records will be appended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InTargetEvent { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>Controls how the attribute information in fields of the Input Event is transferred to the Target Event.</para>
		/// <para>Because the data of the Input Event is appended into an existing event that has a predefined schema (field definitions), fields cannot be added or removed from the target dataset. While you can set merge rules for each output field, the tool ignores those rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldMapping()]
		public object FieldMapping { get; set; }

		/// <summary>
		/// <para>Load Type</para>
		/// <para>Specifies how appended events with measure or temporality overlaps with identical Event IDs as Target Event records will be loaded into the event feature class.</para>
		/// <para>Add—Appends the Input Event records to the Target Event. No changes are made to Target Event records.</para>
		/// <para>Retire overlaps—Appends the Input Event records to the Target Event and retires any records in the Target Event with measure or temporality overlaps as the appended events. If the appended event eclipses the Target Event, the Target Event will be deleted. This option should only be used for linear events.</para>
		/// <para>Retire by event ID—Appends the Input Event records to the Target Event and retires any records in the Target Event with the same Event ID and temporality overlaps as the appended events. If the appended event eclipses a Target Event with the same Event ID, the Target Event will be deleted.</para>
		/// <para>Replace by event ID—Appends the Input Event records to the Target Event and deletes any records in the Target Event with the same Event ID as the appended events.</para>
		/// <para><see cref="LoadTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LoadType { get; set; } = "ADD";

		/// <summary>
		/// <para>Generate Event ID GUIDs for loaded events</para>
		/// <para>Specifies whether event IDs will be generated for Input Event records being appended. Generation of event IDs will only be applied to Input Event records with a Null value for the Event ID field.</para>
		/// <para>Checked—Generates event IDs for the Input Event records being appended.</para>
		/// <para>Unchecked—Does not generate event IDs for the Input Event records being appended. This is the default.</para>
		/// <para><see cref="GenerateEventIdsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateEventIds { get; set; } = "false";

		/// <summary>
		/// <para>Generate Shapes</para>
		/// <para>Specifies whether the shapes of the records being appended will be regenerated. This parameter is only active when the Input Event is a feature layer or feature class.</para>
		/// <para>Checked—The shapes of the input event features will be regenerated. This is the default.</para>
		/// <para>Unchecked—The shapes of the input event features will not be regenerated.</para>
		/// <para><see cref="GenerateShapesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateShapes { get; set; } = "true";

		/// <summary>
		/// <para>Output Target Event</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutTargetEvent { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendEvents SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Load Type</para>
		/// </summary>
		public enum LoadTypeEnum 
		{
			/// <summary>
			/// <para>Add—Appends the Input Event records to the Target Event. No changes are made to Target Event records.</para>
			/// </summary>
			[GPValue("ADD")]
			[Description("Add")]
			Add,

			/// <summary>
			/// <para>Retire overlaps—Appends the Input Event records to the Target Event and retires any records in the Target Event with measure or temporality overlaps as the appended events. If the appended event eclipses the Target Event, the Target Event will be deleted. This option should only be used for linear events.</para>
			/// </summary>
			[GPValue("RETIRE_OVERLAPS")]
			[Description("Retire overlaps")]
			Retire_overlaps,

			/// <summary>
			/// <para>Retire by event ID—Appends the Input Event records to the Target Event and retires any records in the Target Event with the same Event ID and temporality overlaps as the appended events. If the appended event eclipses a Target Event with the same Event ID, the Target Event will be deleted.</para>
			/// </summary>
			[GPValue("RETIRE_BY_EVENT_ID")]
			[Description("Retire by event ID")]
			Retire_by_event_ID,

			/// <summary>
			/// <para>Replace by event ID—Appends the Input Event records to the Target Event and deletes any records in the Target Event with the same Event ID as the appended events.</para>
			/// </summary>
			[GPValue("REPLACE_BY_EVENT_ID")]
			[Description("Replace by event ID")]
			Replace_by_event_ID,

		}

		/// <summary>
		/// <para>Generate Event ID GUIDs for loaded events</para>
		/// </summary>
		public enum GenerateEventIdsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Does not generate event IDs for the Input Event records being appended. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERATE_EVENT_IDS")]
			NO_GENERATE_EVENT_IDS,

			/// <summary>
			/// <para>Checked—Generates event IDs for the Input Event records being appended.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_EVENT_IDS")]
			GENERATE_EVENT_IDS,

		}

		/// <summary>
		/// <para>Generate Shapes</para>
		/// </summary>
		public enum GenerateShapesEnum 
		{
			/// <summary>
			/// <para>Checked—The shapes of the input event features will be regenerated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_SHAPES")]
			GENERATE_SHAPES,

			/// <summary>
			/// <para>Unchecked—The shapes of the input event features will not be regenerated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPES")]
			NO_SHAPES,

		}

#endregion
	}
}
