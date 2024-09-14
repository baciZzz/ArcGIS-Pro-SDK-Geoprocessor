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
	/// <para>Standardize Field</para>
	/// <para>Standardize Field</para>
	/// <para>Standardizes values in fields by converting them to values that follow a specified scale. Standardization methods include z-score, minimum-maximum, absolute maximum, and robust standardization.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class StandardizeField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the field with the values to be standardized.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field to Standardize</para>
		/// <para>The fields containing the values to be standardized. For each field, an output field name can be specified. If an output field name is not provided, the tool will create an output field name using the field name and selected method.</para>
		/// </param>
		public StandardizeField(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Standardize Field</para>
		/// </summary>
		public override string DisplayName() => "Standardize Field";

		/// <summary>
		/// <para>Tool Name : StandardizeField</para>
		/// </summary>
		public override string ToolName() => "StandardizeField";

		/// <summary>
		/// <para>Tool Excute Name : management.StandardizeField</para>
		/// </summary>
		public override string ExcuteName() => "management.StandardizeField";

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
		public override object[] Parameters() => new object[] { InTable, Fields, Method!, MinValue!, MaxValue!, UpdatedTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the field with the values to be standardized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Standardize</para>
		/// <para>The fields containing the values to be standardized. For each field, an output field name can be specified. If an output field name is not provided, the tool will create an output field name using the field name and selected method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Standardization Method</para>
		/// <para>Specifies the method to use to standardize the values contained in the specified fields.</para>
		/// <para>Z-Score—The standard score, which is the number of standard deviations above or below the mean, is used. The calculation is the Z-Score formula, which calculates the difference between the value and the mean of the values in the column, divided by the standard deviation of the values in the column. This is the default.</para>
		/// <para>Minimum-maximum—The values are converted to a scale between the user-specified minimum and maximum values.</para>
		/// <para>Absolute maximum—Each value in the column is divided by the maximum absolute value in the column.</para>
		/// <para>Robust standardization— A robust variant of the Z-Score formula is used to standardize the values in the specified fields. This variant uses median and interquartile range in place of mean and standard deviation.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "Z-SCORE";

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>The value used by the Minimum-maximum method of the Standardization Method parameter to specify the minimum value in the scale of the provided output values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinValue { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>The value used by the Minimum-maximum method of the Standardization Method parameter to specify the maximum value in the scale of the provided output values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxValue { get; set; } = "1";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StandardizeField SetEnviroment(object? extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Standardization Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Z-Score—The standard score, which is the number of standard deviations above or below the mean, is used. The calculation is the Z-Score formula, which calculates the difference between the value and the mean of the values in the column, divided by the standard deviation of the values in the column. This is the default.</para>
			/// </summary>
			[GPValue("Z-SCORE")]
			[Description("Z-Score")]
			Z_SCORE,

			/// <summary>
			/// <para>Minimum-maximum—The values are converted to a scale between the user-specified minimum and maximum values.</para>
			/// </summary>
			[GPValue("MIN-MAX")]
			[Description("Minimum-maximum")]
			MIN_MAX,

			/// <summary>
			/// <para>Absolute maximum—Each value in the column is divided by the maximum absolute value in the column.</para>
			/// </summary>
			[GPValue("MAXABS")]
			[Description("Absolute maximum")]
			Absolute_maximum,

			/// <summary>
			/// <para>Robust standardization— A robust variant of the Z-Score formula is used to standardize the values in the specified fields. This variant uses median and interquartile range in place of mean and standard deviation.</para>
			/// </summary>
			[GPValue("ROBUST")]
			[Description("Robust standardization")]
			Robust_standardization,

		}

#endregion
	}
}
