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
	/// <para>Field Statistics To Table</para>
	/// <para>Field Statistics To Table</para>
	/// <para>Creates a table of descriptive statistics for one or more input fields in a table or feature class.</para>
	/// </summary>
	public class FieldStatisticsToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table containing the fields that will be used to create the statistics table.</para>
		/// </param>
		/// <param name="InFields">
		/// <para>Input Fields</para>
		/// <para>The fields containing the values that will be used to calculate the statistics.</para>
		/// </param>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>The location where the output tables will be created. The location can be a geodatabase, folder, or feature dataset.</para>
		/// </param>
		/// <param name="OutTables">
		/// <para>Output Tables</para>
		/// <para>The output tables containing the statistics. The Field Types column specifies the field types that will be included in each output table, and the name of each output table is provided in the Output Name column. For example, you can create a single table with summaries of all field types, or you can create separate tables for summaries of Numeric, Text, and Date field types.</para>
		/// <para>The following choices are available for the Field Types column:</para>
		/// <para>Numeric—A table summarizing numeric fields of the input (Short, Long, Float, and Double types) will be created.</para>
		/// <para>Text—A table summarizing text fields of the input (Text type) will be created.</para>
		/// <para>Date—A table summarizing date fields of the input (Date type) will be created.</para>
		/// <para>All—A table summarizing all numeric, text, and date fields of the input will be created. Output fields containing statistics that apply to multiple field types will be saved as type Text. Output statistics that do not apply to Text and Date type fields will be empty.</para>
		/// </param>
		public FieldStatisticsToTable(object InTable, object InFields, object OutLocation, object OutTables)
		{
			this.InTable = InTable;
			this.InFields = InFields;
			this.OutLocation = OutLocation;
			this.OutTables = OutTables;
		}

		/// <summary>
		/// <para>Tool Display Name : Field Statistics To Table</para>
		/// </summary>
		public override string DisplayName() => "Field Statistics To Table";

		/// <summary>
		/// <para>Tool Name : FieldStatisticsToTable</para>
		/// </summary>
		public override string ToolName() => "FieldStatisticsToTable";

		/// <summary>
		/// <para>Tool Excute Name : management.FieldStatisticsToTable</para>
		/// </summary>
		public override string ExcuteName() => "management.FieldStatisticsToTable";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, InFields, OutLocation, OutTables, GroupByField!, OutStatistics!, OutNumeric!, OutText!, OutDate!, OutAll! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table containing the fields that will be used to create the statistics table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Fields</para>
		/// <para>The fields containing the values that will be used to calculate the statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Float", "Double", "Text", "Long", "Date")]
		public object InFields { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The location where the output tables will be created. The location can be a geodatabase, folder, or feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output Tables</para>
		/// <para>The output tables containing the statistics. The Field Types column specifies the field types that will be included in each output table, and the name of each output table is provided in the Output Name column. For example, you can create a single table with summaries of all field types, or you can create separate tables for summaries of Numeric, Text, and Date field types.</para>
		/// <para>The following choices are available for the Field Types column:</para>
		/// <para>Numeric—A table summarizing numeric fields of the input (Short, Long, Float, and Double types) will be created.</para>
		/// <para>Text—A table summarizing text fields of the input (Text type) will be created.</para>
		/// <para>Date—A table summarizing date fields of the input (Date type) will be created.</para>
		/// <para>All—A table summarizing all numeric, text, and date fields of the input will be created. Output fields containing statistics that apply to multiple field types will be saved as type Text. Output statistics that do not apply to Text and Date type fields will be empty.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object OutTables { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>The field that will be used to group rows into categories. If a group by field is provided, each field of the input will appear as a row in the output table once per unique value in the group by field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Text", "Long", "Date")]
		public object? GroupByField { get; set; }

		/// <summary>
		/// <para>Output Statistics</para>
		/// <para>Specifies the statistics that will be summarized and the names of the output fields containing the statistics. The statistic is provided in the Statistic column, and the name of the output field is provided in the Output Field Name column. If no values are provided, all applicable statistics will be calculated for all input fields.</para>
		/// <para>The following choices are available for the Statistic column (only statistics applicable to the input fields will be available):</para>
		/// <para>Field name—The name of the field.</para>
		/// <para>Alias—The alias of the field.</para>
		/// <para>Field type—The field type of the field (Short, Long, Double, Float, Text, or Date).</para>
		/// <para>Nulls—The number of records containing null values of the field.</para>
		/// <para>Minimum—The smallest value in the field.</para>
		/// <para>Maximum—The largest value in the field.</para>
		/// <para>Mean—The mean (sum divided by total count) of all values in the field. To calculate the mean date for date fields, each date is converted to a number by calculating the difference between the date and a reference date (for example, 1900-01-01), calculated in milliseconds.</para>
		/// <para>Standard deviation—The standard deviation of the values in the field. It is calculated as the square root of the variance, in which the variance is the average squared difference of each value from the mean of the field.</para>
		/// <para>Median—The median for all values in the field. The median is the middle value in the sorted list of values. If there is an even number of values, the median is the mean of the two middle values in the distribution.</para>
		/// <para>Count—The number of nonnull values in the field.</para>
		/// <para>Number of unique values—The number of unique values in the field.</para>
		/// <para>Mode—The most frequently occurring value in the field.</para>
		/// <para>Least common—The least common value in the field.</para>
		/// <para>Outliers—The number of records with outlier values in the field. Outliers are values that are more than 1.5 times the interquartile range above the third quartile or below the first quartile of the values of the field.</para>
		/// <para>Sum—The sum of all values in the field.</para>
		/// <para>Range—The difference between the largest and smallest values in the field.</para>
		/// <para>Interquartile range—The range between the first quartile and the third quartile of the values in the field. This represents the range of the middle half of the data.</para>
		/// <para>First quartile—The value of the first quartile of the field. Quartiles divide the sorted list of values into four groups containing equal numbers of values. The first quartile is the upper limit of the first group in ascending order.</para>
		/// <para>Third quartile—The value of the third quartile of the field. Quartiles divide the sorted list of values into four groups containing equal numbers of values. The third quartile is the upper limit of the third group in ascending order.</para>
		/// <para>Coefficient of variation—The coefficient of variation of the values in the field. The coefficient of variation is a measure of the relative spread of the values. It is calculated as the standard deviation divided by the mean of the field.</para>
		/// <para>Skewness—The skewness of the values in the field. Skewness measures the symmetry of the distribution. The skewness is calculated as the third moment (the average of the cubed data values) divided by the cubed standard deviation.</para>
		/// <para>Kurtosis—The kurtosis of the values in the field. Kurtosis describes the heaviness of the tails of a distribution compared to the normal distribution, helping identify the frequency of extreme values. The kurtosis is calculated as the fourth moment (the average of the data values taken to the fourth power) divided by the fourth power of the standard deviation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? OutStatistics { get; set; }

		/// <summary>
		/// <para>Output Table for Numeric Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutNumeric { get; set; }

		/// <summary>
		/// <para>Output Table for Text Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutText { get; set; }

		/// <summary>
		/// <para>Output Table for Date Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutDate { get; set; }

		/// <summary>
		/// <para>Output Table for All Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutAll { get; set; }

	}
}
