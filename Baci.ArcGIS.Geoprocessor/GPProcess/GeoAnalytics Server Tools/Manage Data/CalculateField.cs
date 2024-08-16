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
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>The name of the field that will have values calculated. This can be an existing field or a new field name.</para>
		/// </param>
		/// <param name="FieldType">
		/// <para>Field Type</para>
		/// <para>Specifies the field type for the calculated field.</para>
		/// <para>String—Any string of characters</para>
		/// <para>Integer—Whole numbers</para>
		/// <para>Double— Fractional numbers</para>
		/// <para>Date— Date</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </param>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>Calculates values in the field. Expressions are written in Arcade and can include [+ - * / ] operators and multiple fields. Calculated values are applied in the units of the spatial reference of the input unless you are using a geographic coordinate system, in which case they will be in meters.</para>
		/// </param>
		public CalculateField(object InputLayer, object OutputName, object FieldName, object FieldType, object Expression)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.FieldName = FieldName;
			this.FieldType = FieldType;
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
		/// <para>Tool Excute Name : geoanalytics.CalculateField</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.CalculateField";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, OutputName, FieldName, FieldType, Expression, TrackAware, TrackFields, DataStore, OutputTable, TimeBoundarySplit, TimeBoundaryReference };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input features that will have a field calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The name of the field that will have values calculated. This can be an existing field or a new field name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>Specifies the field type for the calculated field.</para>
		/// <para>String—Any string of characters</para>
		/// <para>Integer—Whole numbers</para>
		/// <para>Double— Fractional numbers</para>
		/// <para>Date— Date</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>Calculates values in the field. Expressions are written in Arcade and can include [+ - * / ] operators and multiple fields. Calculated values are applied in the units of the spatial reference of the input unless you are using a geographic coordinate system, in which case they will be in meters.</para>
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
		public object TrackAware { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object TrackFields { get; set; }

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
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, starting on January 1, 1980, tracks will be split at the beginning of every day. This parameter is only available with ArcGIS Enterprise 10.7 and later.</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used. This parameter is only available with ArcGIS Enterprise 10.7 and later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateField SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

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

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// </summary>
		public enum TimeBoundarySplitEnum 
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

#endregion
	}
}
