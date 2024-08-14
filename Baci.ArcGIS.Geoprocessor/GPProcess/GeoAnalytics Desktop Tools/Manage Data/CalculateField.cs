using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Calculate Field</para>
	/// <para>Creates a layer with calculated field values.</para>
	/// </summary>
	public class CalculateField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The input features that will have a field calculated.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>A new dataset with calculated fields.</para>
		/// </param>
		/// <param name="FieldToCalculate">
		/// <para>Field to Calculate</para>
		/// <para>Specifies whether values will be calculated for a newly created field or an existing field.</para>
		/// <para>New field—Values will be calculated for a newly created field.</para>
		/// <para>Existing field—Values will be calculated for an existing field.</para>
		/// <para><see cref="FieldToCalculateEnum"/></para>
		/// </param>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>Calculates values in the field. Expressions are written in Arcade and can include [+ - * / ] operators and multiple fields. Calculated values are applied in the units of the spatial reference of the input unless you are using a geographic coordinate system, in which case they will be in meters.</para>
		/// <para>If the layer is added to the map, the Fields and Helpers filters can be used to build an expression.</para>
		/// </param>
		public CalculateField(object InputLayer, object Output, object FieldToCalculate, object Expression)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
			this.FieldToCalculate = FieldToCalculate;
			this.Expression = Expression;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Field</para>
		/// </summary>
		public override string DisplayName => "Calculate Field";

		/// <summary>
		/// <para>Tool Name : CalculateField</para>
		/// </summary>
		public override string ToolName => "CalculateField";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CalculateField</para>
		/// </summary>
		public override string ExcuteName => "gapro.CalculateField";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, Output, FieldToCalculate, FieldName!, ExistingField!, FieldType!, Expression, TrackAware!, TrackFields!, TimeBoundarySplit!, TimeBoundaryReference! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input features that will have a field calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>A new dataset with calculated fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Field to Calculate</para>
		/// <para>Specifies whether values will be calculated for a newly created field or an existing field.</para>
		/// <para>New field—Values will be calculated for a newly created field.</para>
		/// <para>Existing field—Values will be calculated for an existing field.</para>
		/// <para><see cref="FieldToCalculateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldToCalculate { get; set; } = "NEW_FIELD";

		/// <summary>
		/// <para>New Field Name</para>
		/// <para>The new field that will have values calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FieldName { get; set; }

		/// <summary>
		/// <para>Existing Field</para>
		/// <para>The existing field that will have values calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? ExistingField { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>Specifies the field type for the calculated field.</para>
		/// <para>String—Any string of characters</para>
		/// <para>Integer—Whole numbers</para>
		/// <para>Double— Fractional numbers</para>
		/// <para>Date— Date</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FieldType { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>Calculates values in the field. Expressions are written in Arcade and can include [+ - * / ] operators and multiple fields. Calculated values are applied in the units of the spatial reference of the input unless you are using a geographic coordinate system, in which case they will be in meters.</para>
		/// <para>If the layer is added to the map, the Fields and Helpers filters can be used to build an expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Track Aware</para>
		/// <para>Specifies whether the expression will use a track-aware expression.</para>
		/// <para>Checked—The expression will use a track-aware expression, and a track field must be specified.</para>
		/// <para>Unchecked—The expression will not use a track-aware expression. This is the default.</para>
		/// <para><see cref="TrackAwareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TrackAware { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object? TrackFields { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, and set the time boundary reference to January 1, 1980, tracks will be split at the beginning of every day.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateField SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field to Calculate</para>
		/// </summary>
		public enum FieldToCalculateEnum 
		{
			/// <summary>
			/// <para>New field—Values will be calculated for a newly created field.</para>
			/// </summary>
			[GPValue("NEW_FIELD")]
			[Description("New field")]
			New_field,

			/// <summary>
			/// <para>Existing field—Values will be calculated for an existing field.</para>
			/// </summary>
			[GPValue("EXISTING_FIELD")]
			[Description("Existing field")]
			Existing_field,

		}

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>Date— Date</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

			/// <summary>
			/// <para>Double— Fractional numbers</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double")]
			Double,

			/// <summary>
			/// <para>Integer—Whole numbers</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("Integer")]
			Integer,

			/// <summary>
			/// <para>String—Any string of characters</para>
			/// </summary>
			[GPValue("STRING")]
			[Description("String")]
			String,

		}

		/// <summary>
		/// <para>Track Aware</para>
		/// </summary>
		public enum TrackAwareEnum 
		{
			/// <summary>
			/// <para>Checked—The expression will use a track-aware expression, and a track field must be specified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACK_AWARE")]
			TRACK_AWARE,

			/// <summary>
			/// <para>Unchecked—The expression will not use a track-aware expression. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_TRACK_AWARE")]
			NOT_TRACK_AWARE,

		}

#endregion
	}
}
