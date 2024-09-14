using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Encode Field</para>
	/// <para>Encode Field</para>
	/// <para>Converts categorical values (string, integer, or date) into multiple numerical fields, each representing a category. The encoded numerical fields can be used in most data science and statistical workflows including regression models.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EncodeField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table or feature class containing the field to be encoded. Fields will be added to the existing input table and will not create a new output table.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field to Encode</para>
		/// <para>The field containing the categorical or temporal values to be encoded.</para>
		/// </param>
		public EncodeField(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Encode Field</para>
		/// </summary>
		public override string DisplayName() => "Encode Field";

		/// <summary>
		/// <para>Tool Name : EncodeField</para>
		/// </summary>
		public override string ToolName() => "EncodeField";

		/// <summary>
		/// <para>Tool Excute Name : management.EncodeField</para>
		/// </summary>
		public override string ExcuteName() => "management.EncodeField";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Field, Method!, TimeStepInterval!, TimeStepAlignment!, ReferenceTime!, UpdatedTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table or feature class containing the field to be encoded. Fields will be added to the existing input table and will not create a new output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Encode</para>
		/// <para>The field containing the categorical or temporal values to be encoded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Text", "Long", "Date")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Encoding Method</para>
		/// <para>Specifies the method to use to encode the values contained in the Field to Encode parameter.</para>
		/// <para>One-hot—Each categorical value will be converted to a new field and the values 0 and 1 will be assigned, where 1 represents the presence of that categorical value. This is the default.</para>
		/// <para>One-cold— Each categorical value will be converted to a new field and the values 0 and 1 will be assigned, where 0 represents the presence of that categorical value.</para>
		/// <para>Temporal—Each temporal value in the Field to Encode parameter will be converted to an integer based on the time step interval, time step alignment, and reference time specified.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "ONEHOT";

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>The number of seconds, minutes, hours, days, weeks, or years that will represent a single time step. The temporal value will be aggregated into a certain time step it is within. If no value is provided, the default time step interval is based on two algorithms that are used to determine the optimal number and width of the time step intervals. The smaller of the two results is used as the time step interval.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>Specifies how aggregation will occur based on the Time Step Interval parameter value.</para>
		/// <para>End time— Time steps will align to the last time event and aggregate back in time. This is the default.</para>
		/// <para>Start time— Time steps will align to the first time event and aggregate forward in time.</para>
		/// <para>Reference time— Time steps will align to the date and time specified in the Reference Time parameter. Aggregation is performed forward and backward in time from the reference time until reaching the first and last temporal values.</para>
		/// <para><see cref="TimeStepAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeStepAlignment { get; set; } = "END_TIME";

		/// <summary>
		/// <para>Reference Time</para>
		/// <para>The date and time to which the time-step intervals will align. For example, to bin your data weekly from Monday to Sunday, set a reference time of Sunday at midnight to ensure that the time steps break between Sunday and Monday at midnight.</para>
		/// <para>The value can be a date and time or solely a date; it cannot be solely a time. The expected format is determined by the computer&apos;s regional time settings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ReferenceTime { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EncodeField SetEnviroment(object? extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Encoding Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>One-hot—Each categorical value will be converted to a new field and the values 0 and 1 will be assigned, where 1 represents the presence of that categorical value. This is the default.</para>
			/// </summary>
			[GPValue("ONEHOT")]
			[Description("One-hot")]
			ONEHOT,

			/// <summary>
			/// <para>One-cold— Each categorical value will be converted to a new field and the values 0 and 1 will be assigned, where 0 represents the presence of that categorical value.</para>
			/// </summary>
			[GPValue("ONECOLD")]
			[Description("One-cold")]
			ONECOLD,

			/// <summary>
			/// <para>Temporal—Each temporal value in the Field to Encode parameter will be converted to an integer based on the time step interval, time step alignment, and reference time specified.</para>
			/// </summary>
			[GPValue("TEMPORAL")]
			[Description("Temporal")]
			Temporal,

		}

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// </summary>
		public enum TimeStepAlignmentEnum 
		{
			/// <summary>
			/// <para>End time— Time steps will align to the last time event and aggregate back in time. This is the default.</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("End time")]
			End_time,

			/// <summary>
			/// <para>Start time— Time steps will align to the first time event and aggregate forward in time.</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("Start time")]
			Start_time,

			/// <summary>
			/// <para>Reference time— Time steps will align to the date and time specified in the Reference Time parameter. Aggregation is performed forward and backward in time from the reference time until reaching the first and last temporal values.</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("Reference time")]
			Reference_time,

		}

#endregion
	}
}
