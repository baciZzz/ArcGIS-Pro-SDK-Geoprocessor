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
	/// <para>LAS Dataset Statistics</para>
	/// <para>LAS Dataset Statistics</para>
	/// <para>Calculates or updates statistics for a LAS dataset and generates an optional statistics report.</para>
	/// </summary>
	public class LasDatasetStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		public LasDatasetStatistics(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS Dataset Statistics</para>
		/// </summary>
		public override string DisplayName() => "LAS Dataset Statistics";

		/// <summary>
		/// <para>Tool Name : LasDatasetStatistics</para>
		/// </summary>
		public override string ToolName() => "LasDatasetStatistics";

		/// <summary>
		/// <para>Tool Excute Name : management.LasDatasetStatistics</para>
		/// </summary>
		public override string ExcuteName() => "management.LasDatasetStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, CalculationType!, OutFile!, SummaryLevel!, Delimiter!, DecimalSeparator!, DerivedLasDataset! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>Specifies whether statistics will be calculated for all lidar files or only for those that do not have statistics:</para>
		/// <para>Checked—LAS files with up-to-date statistics will be skipped, and statistics will only be calculated for newly added LAS files or ones that were updated since the initial calculation. This is the default.</para>
		/// <para>Unchecked—Statistics will be calculated for all LAS files, including ones that have up-to-date statistics. This is useful if the LAS files were modified in an external application that went undetected by ArcGIS.</para>
		/// <para><see cref="CalculationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CalculationType { get; set; } = "true";

		/// <summary>
		/// <para>Output Statistics Report Text File</para>
		/// <para>The output text file that will contain the summary of the LAS dataset statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETextFile()]
		public object? OutFile { get; set; }

		/// <summary>
		/// <para>Summary Level</para>
		/// <para>Specify the type of summary contained in the report.</para>
		/// <para>Aggregate Statistics for All Files—The report will summarize statistics for the entire LAS dataset. This is the default.</para>
		/// <para>Statistics for Each LAS File—The report will summarize statistics for the LAS files referenced by the LAS dataset.</para>
		/// <para><see cref="SummaryLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SummaryLevel { get; set; } = "DATASET";

		/// <summary>
		/// <para>Delimiter</para>
		/// <para>The delimiter that will be used to indicate the separation of entries in the columns of the text file table.</para>
		/// <para>Space—A space will be used to delimit field values. This is the default.</para>
		/// <para>Comma—A comma will be used to delimit field values. This option is not applicable if the decimal separator is also a comma.</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Delimiter { get; set; } = "COMMA";

		/// <summary>
		/// <para>Decimal Separator</para>
		/// <para>The decimal character that will be used in the text file to differentiate the integer of a number from its fractional part.</para>
		/// <para>Point—A point will be used as the decimal character. This is the default.</para>
		/// <para>Comma—A comma will be used as the decimal character.</para>
		/// <para><see cref="DecimalSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Updated Input LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object? DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasDatasetStatistics SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum CalculationTypeEnum 
		{
			/// <summary>
			/// <para>Checked—LAS files with up-to-date statistics will be skipped, and statistics will only be calculated for newly added LAS files or ones that were updated since the initial calculation. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING_STATS")]
			SKIP_EXISTING_STATS,

			/// <summary>
			/// <para>Unchecked—Statistics will be calculated for all LAS files, including ones that have up-to-date statistics. This is useful if the LAS files were modified in an external application that went undetected by ArcGIS.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE_EXISTING_STATS")]
			OVERWRITE_EXISTING_STATS,

		}

		/// <summary>
		/// <para>Summary Level</para>
		/// </summary>
		public enum SummaryLevelEnum 
		{
			/// <summary>
			/// <para>Aggregate Statistics for All Files—The report will summarize statistics for the entire LAS dataset. This is the default.</para>
			/// </summary>
			[GPValue("DATASET")]
			[Description("Aggregate Statistics for All Files")]
			Aggregate_Statistics_for_All_Files,

			/// <summary>
			/// <para>Statistics for Each LAS File—The report will summarize statistics for the LAS files referenced by the LAS dataset.</para>
			/// </summary>
			[GPValue("LAS_FILES")]
			[Description("Statistics for Each LAS File")]
			Statistics_for_Each_LAS_File,

		}

		/// <summary>
		/// <para>Delimiter</para>
		/// </summary>
		public enum DelimiterEnum 
		{
			/// <summary>
			/// <para>Comma—A comma will be used to delimit field values. This option is not applicable if the decimal separator is also a comma.</para>
			/// </summary>
			[GPValue("COMMA")]
			[Description("Comma")]
			Comma,

			/// <summary>
			/// <para>Space—A space will be used to delimit field values. This is the default.</para>
			/// </summary>
			[GPValue("SPACE")]
			[Description("Space")]
			Space,

		}

		/// <summary>
		/// <para>Decimal Separator</para>
		/// </summary>
		public enum DecimalSeparatorEnum 
		{
			/// <summary>
			/// <para>Point—A point will be used as the decimal character. This is the default.</para>
			/// </summary>
			[GPValue("DECIMAL_POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Comma—A comma will be used as the decimal character.</para>
			/// </summary>
			[GPValue("DECIMAL_COMMA")]
			[Description("Comma")]
			Comma,

		}

#endregion
	}
}
