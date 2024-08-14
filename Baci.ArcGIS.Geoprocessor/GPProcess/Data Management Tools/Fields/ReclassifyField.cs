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
	/// <para>Reclassify Field</para>
	/// <para>Reclassifies values in a numerical or text field into classes based on bounds defined manually or using a reclassification method.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ReclassifyField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table or feature class containing the field to be reclassified.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field to Reclassify</para>
		/// <para>The field to be reclassified. The field must be numeric or text.</para>
		/// </param>
		public ReclassifyField(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Reclassify Field</para>
		/// </summary>
		public override string DisplayName => "Reclassify Field";

		/// <summary>
		/// <para>Tool Name : ReclassifyField</para>
		/// </summary>
		public override string ToolName => "ReclassifyField";

		/// <summary>
		/// <para>Tool Excute Name : management.ReclassifyField</para>
		/// </summary>
		public override string ExcuteName => "management.ReclassifyField";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, Field, Method, Classes, Interval, StandardDeviations, ReclassTable, ReverseValues, OutputFieldName, UpdatedTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table or feature class containing the field to be reclassified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Reclassify</para>
		/// <para>The field to be reclassified. The field must be numeric or text.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Reclassification Method</para>
		/// <para>Specifies how the values contained in the field specified in the Field to Reclassify parameter.</para>
		/// <para>Defined interval— Creates classes with the same class range over the span of the values of the field to reclassify.</para>
		/// <para>Equal interval—Creates classes with equal class ranges divided into a specified number of classes. This is the default.</para>
		/// <para>Geometric interval—Creates classes with geometrically increasing or decreasing class ranges into a specified number of classes.</para>
		/// <para>Manual interval— Class breaks and reclassed values are manually specified.</para>
		/// <para>Natural breaks (Jenks)— Creates classes of natural groupings in the data using the Jenks natural breaks algorithm.</para>
		/// <para>Quantile— Creates classes where each class includes an equal number of values.</para>
		/// <para>Standard deviation— Creates classes by adding and subtracting a fraction of the standard deviation above and below the average value.</para>
		/// <para>Unique values—Creates classes where each unique value of the field becomes a class.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "EQUAL_INTERVAL";

		/// <summary>
		/// <para>Number of Classes</para>
		/// <para>The target number of classes in the reclassified field. The maximum number of classes is 256.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object Classes { get; set; }

		/// <summary>
		/// <para>Interval Size</para>
		/// <para>The class interval size for the reclassified field. The provided value must result in at least 3 classes and not more than 1000 classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Interval { get; set; }

		/// <summary>
		/// <para>Number of Standard Deviations</para>
		/// <para>Specifies the number of standard deviations for the reclassified field. Class breaks and categories are created with equal interval ranges that are a proportion of the standard deviation from the mean.</para>
		/// <para>One standard deviation—Intervals are created using one standard deviation. This is the default.</para>
		/// <para>One half of a standard deviation—Intervals are created using half of one standard deviation.</para>
		/// <para>One third of a standard deviation—Intervals are created using a third of one standard deviation.</para>
		/// <para>One quarter of a standard deviation—Intervals are created using a quarter of one standard deviation.</para>
		/// <para><see cref="StandardDeviationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StandardDeviations { get; set; } = "ONE";

		/// <summary>
		/// <para>Reclassification Table</para>
		/// <para>The upper bound and reclassed value for the manual reclassification method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ReclassTable { get; set; }

		/// <summary>
		/// <para>Reverse Values (Descending)</para>
		/// <para>Specifies how the reclassified values are ordered.</para>
		/// <para>Checked—Classes are assigned values in descending order; the class with the highest values is assigned 1, the next highest class is assigned 2, and so on.</para>
		/// <para>Unchecked—Classes are assigned values in ascending order; the class with the lowest values is assigned 1, the next lowest class is assigned 2, and so on. This is the default.</para>
		/// <para><see cref="ReverseValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReverseValues { get; set; } = "false";

		/// <summary>
		/// <para>Output Field Name</para>
		/// <para>The name or prefix of the output field. If the field to reclassify is a numerical field, two fields will be created, and this name will prefix the field names. If the field to reclassify is a text field, one new field will be created with this name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutputFieldName { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReclassifyField SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reclassification Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Defined interval— Creates classes with the same class range over the span of the values of the field to reclassify.</para>
			/// </summary>
			[GPValue("DEFINED_INTERVAL")]
			[Description("Defined interval")]
			Defined_interval,

			/// <summary>
			/// <para>Equal interval—Creates classes with equal class ranges divided into a specified number of classes. This is the default.</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("Equal interval")]
			Equal_interval,

			/// <summary>
			/// <para>Geometric interval—Creates classes with geometrically increasing or decreasing class ranges into a specified number of classes.</para>
			/// </summary>
			[GPValue("GEOMETRIC_INTERVAL")]
			[Description("Geometric interval")]
			Geometric_interval,

			/// <summary>
			/// <para>Manual interval— Class breaks and reclassed values are manually specified.</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("Manual interval")]
			Manual_interval,

			/// <summary>
			/// <para>Natural breaks (Jenks)— Creates classes of natural groupings in the data using the Jenks natural breaks algorithm.</para>
			/// </summary>
			[GPValue("NATURAL_BREAKS")]
			[Description("Natural breaks (Jenks)")]
			NATURAL_BREAKS,

			/// <summary>
			/// <para>Quantile— Creates classes where each class includes an equal number of values.</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

			/// <summary>
			/// <para>Standard deviation— Creates classes by adding and subtracting a fraction of the standard deviation above and below the average value.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Unique values—Creates classes where each unique value of the field becomes a class.</para>
			/// </summary>
			[GPValue("UNIQUE_VALUES")]
			[Description("Unique values")]
			Unique_values,

		}

		/// <summary>
		/// <para>Number of Standard Deviations</para>
		/// </summary>
		public enum StandardDeviationsEnum 
		{
			/// <summary>
			/// <para>One standard deviation—Intervals are created using one standard deviation. This is the default.</para>
			/// </summary>
			[GPValue("ONE")]
			[Description("One standard deviation")]
			One_standard_deviation,

			/// <summary>
			/// <para>One half of a standard deviation—Intervals are created using half of one standard deviation.</para>
			/// </summary>
			[GPValue("HALF")]
			[Description("One half of a standard deviation")]
			One_half_of_a_standard_deviation,

			/// <summary>
			/// <para>One third of a standard deviation—Intervals are created using a third of one standard deviation.</para>
			/// </summary>
			[GPValue("THIRD")]
			[Description("One third of a standard deviation")]
			One_third_of_a_standard_deviation,

			/// <summary>
			/// <para>One quarter of a standard deviation—Intervals are created using a quarter of one standard deviation.</para>
			/// </summary>
			[GPValue("QUARTER")]
			[Description("One quarter of a standard deviation")]
			One_quarter_of_a_standard_deviation,

		}

		/// <summary>
		/// <para>Reverse Values (Descending)</para>
		/// </summary>
		public enum ReverseValuesEnum 
		{
			/// <summary>
			/// <para>Checked—Classes are assigned values in descending order; the class with the highest values is assigned 1, the next highest class is assigned 2, and so on.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DESC")]
			DESC,

			/// <summary>
			/// <para>Unchecked—Classes are assigned values in ascending order; the class with the lowest values is assigned 1, the next lowest class is assigned 2, and so on. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ASC")]
			ASC,

		}

#endregion
	}
}
