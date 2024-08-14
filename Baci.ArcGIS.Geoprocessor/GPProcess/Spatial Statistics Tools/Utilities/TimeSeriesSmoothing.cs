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
	/// <para>Time Series Smoothing</para>
	/// <para>Smooths a numeric variable of one or more time series using centered, forward, and backward moving averages, as well as an adaptive method based on local linear regression. After smoothing short-term fluctuations, longer-term trends or cycles often become apparent.</para>
	/// </summary>
	public class TimeSeriesSmoothing : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features or Table</para>
		/// <para>The features or table containing the time series data and the field to smooth.</para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>The field containing the time of each record.</para>
		/// </param>
		/// <param name="AnalysisField">
		/// <para>Analysis Field</para>
		/// <para>The field containing the values that will be smoothed.</para>
		/// </param>
		public TimeSeriesSmoothing(object InFeatures, object TimeField, object AnalysisField)
		{
			this.InFeatures = InFeatures;
			this.TimeField = TimeField;
			this.AnalysisField = AnalysisField;
		}

		/// <summary>
		/// <para>Tool Display Name : Time Series Smoothing</para>
		/// </summary>
		public override string DisplayName => "Time Series Smoothing";

		/// <summary>
		/// <para>Tool Name : TimeSeriesSmoothing</para>
		/// </summary>
		public override string ToolName => "TimeSeriesSmoothing";

		/// <summary>
		/// <para>Tool Excute Name : stats.TimeSeriesSmoothing</para>
		/// </summary>
		public override string ExcuteName => "stats.TimeSeriesSmoothing";

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
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, TimeField, AnalysisField, GroupMethod!, Method!, TimeWindow!, AppendToInput!, OutputFeatures!, IdField!, ApplyShorterWindow!, EnableTimeSeriesPopups!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input Features or Table</para>
		/// <para>The features or table containing the time series data and the field to smooth.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>The field containing the time of each record.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Analysis Field</para>
		/// <para>The field containing the values that will be smoothed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object AnalysisField { get; set; }

		/// <summary>
		/// <para>Grouping Method</para>
		/// <para>Specifies the method that will be used to group records into different time series. Smoothing is performed independently for each time series.</para>
		/// <para>By location—Features at the same location will be grouped in the same time series. This is the default.</para>
		/// <para>By ID field—Records with the same value of the ID field will be grouped in the same time series.</para>
		/// <para>None—All records will be in the same time series.</para>
		/// <para><see cref="GroupMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GroupMethod { get; set; } = "LOCATION";

		/// <summary>
		/// <para>Smoothing Method</para>
		/// <para>Specifies the smoothing method that will be used.</para>
		/// <para>Backward moving average—The smoothed value is the average of the record and the values within the time window before it. This is the default.</para>
		/// <para>Centered moving average—The smoothed value is the average of the record and the values before and after it. Half of the time window is used before the time of the record, and half is used after.</para>
		/// <para>Forward moving average—The smoothed value is the average of the record and the values within the time window after it.</para>
		/// <para>Adaptive bandwidth local linear regression—The smoothed value is the result of a local linear regression centered at the record. The size of the time window is optimized for each record.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "BACKWARD";

		/// <summary>
		/// <para>Time Window</para>
		/// <para>The length of the time window. The value can be provided in seconds, minutes, hours, days, weeks, months, or years. For backward, forward, and centered moving averages, the value and unit must be provided. For adaptive bandwidth local linear regression, the value can be left empty and a time window will be estimated independently for each value. Values that fall on the border of the time window are included within the window. For example, if you have daily data and you use a backward moving average with a time window of four days, five values will be included in the window when smoothing a record: the value of the record and the values of the four previous days.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeWindow { get; set; }

		/// <summary>
		/// <para>Append fields to input data</para>
		/// <para>Specifies whether output fields will be appended to the input dataset or saved as a new output table or feature class. If you choose to append the fields to the input, the output coordinate system environment will be ignored.</para>
		/// <para>Checked—The output fields will be appended to the input features. This option modifies the input data.</para>
		/// <para>Unchecked—The output fields will not be appended to the input. An output table or a feature class will be created containing the output fields. This is the default.</para>
		/// <para><see cref="AppendToInputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendToInput { get; set; } = "false";

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output features containing the smoothed values as well as fields for the time window and number of neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? OutputFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>The integer or text field containing a unique ID for each time series. All records with the same value of this field are part of the same time series.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? IdField { get; set; }

		/// <summary>
		/// <para>Apply shorter time window at start and end</para>
		/// <para>Specifies whether the time window will be shortened at the start and end of each time series.</para>
		/// <para>Checked—The time window will be shortened at the start and end of the time series so that the time window does not extend before the start or after the end of the time series.</para>
		/// <para>Unchecked—The time window will not be shortened. If the time window extends before the start or after the end of the time series, the smoothed value will be null. This is the default.</para>
		/// <para><see cref="ApplyShorterWindowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ApplyShorterWindow { get; set; } = "false";

		/// <summary>
		/// <para>Enable time series pop-ups</para>
		/// <para>Specifies whether the output features or table will include pop-up charts showing the original and smoothed values of the time series.</para>
		/// <para>Checked—The output will include pop-up charts. This is the default.</para>
		/// <para>Unchecked—The output will not include pop-up charts.</para>
		/// <para><see cref="EnableTimeSeriesPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnableTimeSeriesPopups { get; set; } = "true";

		/// <summary>
		/// <para>Updated Features or Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TimeSeriesSmoothing SetEnviroment(object? outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Grouping Method</para>
		/// </summary>
		public enum GroupMethodEnum 
		{
			/// <summary>
			/// <para>By location—Features at the same location will be grouped in the same time series. This is the default.</para>
			/// </summary>
			[GPValue("LOCATION")]
			[Description("By location")]
			By_location,

			/// <summary>
			/// <para>By ID field—Records with the same value of the ID field will be grouped in the same time series.</para>
			/// </summary>
			[GPValue("ID_FIELD")]
			[Description("By ID field")]
			By_ID_field,

			/// <summary>
			/// <para>None—All records will be in the same time series.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Smoothing Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Backward moving average—The smoothed value is the average of the record and the values within the time window before it. This is the default.</para>
			/// </summary>
			[GPValue("BACKWARD")]
			[Description("Backward moving average")]
			Backward_moving_average,

			/// <summary>
			/// <para>Centered moving average—The smoothed value is the average of the record and the values before and after it. Half of the time window is used before the time of the record, and half is used after.</para>
			/// </summary>
			[GPValue("CENTERED")]
			[Description("Centered moving average")]
			Centered_moving_average,

			/// <summary>
			/// <para>Forward moving average—The smoothed value is the average of the record and the values within the time window after it.</para>
			/// </summary>
			[GPValue("FORWARD")]
			[Description("Forward moving average")]
			Forward_moving_average,

			/// <summary>
			/// <para>Adaptive bandwidth local linear regression—The smoothed value is the result of a local linear regression centered at the record. The size of the time window is optimized for each record.</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("Adaptive bandwidth local linear regression")]
			Adaptive_bandwidth_local_linear_regression,

		}

		/// <summary>
		/// <para>Append fields to input data</para>
		/// </summary>
		public enum AppendToInputEnum 
		{
			/// <summary>
			/// <para>Checked—The output fields will be appended to the input features. This option modifies the input data.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND_TO_INPUT")]
			APPEND_TO_INPUT,

			/// <summary>
			/// <para>Unchecked—The output fields will not be appended to the input. An output table or a feature class will be created containing the output fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NEW_OUTPUT")]
			NEW_OUTPUT,

		}

		/// <summary>
		/// <para>Apply shorter time window at start and end</para>
		/// </summary>
		public enum ApplyShorterWindowEnum 
		{
			/// <summary>
			/// <para>Checked—The time window will be shortened at the start and end of the time series so that the time window does not extend before the start or after the end of the time series.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_SHORTER_WINDOW")]
			APPLY_SHORTER_WINDOW,

			/// <summary>
			/// <para>Unchecked—The time window will not be shortened. If the time window extends before the start or after the end of the time series, the smoothed value will be null. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_APPLY_SHORTER_WINDOW")]
			NOT_APPLY_SHORTER_WINDOW,

		}

		/// <summary>
		/// <para>Enable time series pop-ups</para>
		/// </summary>
		public enum EnableTimeSeriesPopupsEnum 
		{
			/// <summary>
			/// <para>Checked—The output will include pop-up charts. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_POPUP")]
			CREATE_POPUP,

			/// <summary>
			/// <para>Unchecked—The output will not include pop-up charts.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POPUP")]
			NO_POPUP,

		}

#endregion
	}
}
