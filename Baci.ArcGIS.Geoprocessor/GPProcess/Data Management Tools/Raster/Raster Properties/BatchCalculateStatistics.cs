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
	/// <para>Batch Calculate Statistics</para>
	/// <para>Calculates statistics for  multiple raster datasets.</para>
	/// </summary>
	public class BatchCalculateStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasterDatasets">
		/// <para>Input Raster Datasets</para>
		/// <para>The input raster datasets.</para>
		/// </param>
		public BatchCalculateStatistics(object InputRasterDatasets)
		{
			this.InputRasterDatasets = InputRasterDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : Batch Calculate Statistics</para>
		/// </summary>
		public override string DisplayName => "Batch Calculate Statistics";

		/// <summary>
		/// <para>Tool Name : BatchCalculateStatistics</para>
		/// </summary>
		public override string ToolName => "BatchCalculateStatistics";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchCalculateStatistics</para>
		/// </summary>
		public override string ExcuteName => "management.BatchCalculateStatistics";

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
		public override string[] ValidEnvironments => new string[] { "rasterStatistics", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputRasterDatasets, NumberOfColumnsToSkip!, NumberOfRowsToSkip!, IgnoreValues!, SkipExisting!, BatchCalculateStatisticsSucceeded! };

		/// <summary>
		/// <para>Input Raster Datasets</para>
		/// <para>The input raster datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasterDatasets { get; set; }

		/// <summary>
		/// <para>X Skip Factor</para>
		/// <para>The number of horizontal pixels between samples.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>The value must be greater than zero and less than or equal to the number of columns in the raster. The default is 1 or the last skip factor used.</para>
		/// <para>The skip factors for raster datasets stored in a file geodatabase or an enterprise geodatabase are different. First, if the x and y skip factors are different, the smaller skip factor will be used for both the x and y skip factors. Second, the skip factor is related to the pyramid level that most closely fits the skip factor chosen. If the skip factor value is not equal to the number of pixels in a pyramid layer, the number is rounded down to the next pyramid level, and those statistics are used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfColumnsToSkip { get; set; } = "1";

		/// <summary>
		/// <para>Y Skip Factor</para>
		/// <para>The number of vertical pixels between samples.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>The value must be greater than zero and less than or equal to the number of rows in the raster. The default is 1 or the last y skip factor used.</para>
		/// <para>The skip factors for raster datasets stored in a file geodatabase or an enterprise geodatabase are different. First, if the x and y skip factors are different, the smaller skip factor will be used for both the x and y skip factors. Second, the skip factor is related to the pyramid level that most closely fits the skip factor chosen. If the skip factor value is not equal to the number of pixels in a pyramid layer, the number is rounded down to the next pyramid level, and those statistics are used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfRowsToSkip { get; set; } = "1";

		/// <summary>
		/// <para>Ignore values</para>
		/// <para>The pixel values that are not to be included in the statistics calculation.</para>
		/// <para>The default is no value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? IgnoreValues { get; set; }

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>Specifies whether statistics will be calculated only where they are missing or will be regenerated even if they exist.</para>
		/// <para>Unchecked—Statistics will be calculated even if they already exist, and existing statistics will be overwritten. This is the default.</para>
		/// <para>Checked—Statistics will only be calculated if they do not already exist.</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SkipExisting { get; set; }

		/// <summary>
		/// <para>Batch Calculate Statistics Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? BatchCalculateStatisticsSucceeded { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BatchCalculateStatistics SetEnviroment(object? rasterStatistics = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum SkipExistingEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will only be calculated if they do not already exist.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para>Unchecked—Statistics will be calculated even if they already exist, and existing statistics will be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SKIP_EXISTING")]
			SKIP_EXISTING,

		}

#endregion
	}
}
