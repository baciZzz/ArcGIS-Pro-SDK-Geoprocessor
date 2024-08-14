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
	/// <para>Calculate Statistics</para>
	/// <para>Calculates statistics for a raster dataset or a mosaic dataset.</para>
	/// </summary>
	public class CalculateStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterDataset">
		/// <para>Input Raster Dataset</para>
		/// <para>The input raster dataset or mosaic dataset.</para>
		/// </param>
		public CalculateStatistics(object InRasterDataset)
		{
			this.InRasterDataset = InRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Statistics</para>
		/// </summary>
		public override string DisplayName => "Calculate Statistics";

		/// <summary>
		/// <para>Tool Name : CalculateStatistics</para>
		/// </summary>
		public override string ToolName => "CalculateStatistics";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateStatistics</para>
		/// </summary>
		public override string ExcuteName => "management.CalculateStatistics";

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
		public override object[] Parameters => new object[] { InRasterDataset, XSkipFactor, YSkipFactor, IgnoreValues, SkipExisting, AreaOfInterest, OutRaster };

		/// <summary>
		/// <para>Input Raster Dataset</para>
		/// <para>The input raster dataset or mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRasterDataset { get; set; }

		/// <summary>
		/// <para>X Skip Factor</para>
		/// <para>The number of horizontal pixels between samples.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>The value must be greater than zero and less than or equal to the number of columns in the raster. The default is 1 or the last skip factor used.</para>
		/// <para>The skip factors for raster datasets stored in a file geodatabase or an enterprise geodatabase are different. First, if the x and y skip factors are different, the smaller skip factor will be used for both the x and y skip factors. Second, the skip factor is related to the pyramid level that most closely fits the skip factor chosen. If the skip factor value is not equal to the number of pixels in a pyramid layer, the number is rounded down to the next pyramid level, and those statistics are used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object XSkipFactor { get; set; }

		/// <summary>
		/// <para>Y Skip Factor</para>
		/// <para>The number of vertical pixels between samples.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>The value must be greater than zero and less than or equal to the number of rows in the raster. The default is 1 or the last y skip factor used.</para>
		/// <para>The skip factors for raster datasets stored in a file geodatabase or an enterprise geodatabase are different. First, if the x and y skip factors are different, the smaller skip factor will be used for both the x and y skip factors. Second, the skip factor is related to the pyramid level that most closely fits the skip factor chosen. If the skip factor value is not equal to the number of pixels in a pyramid layer, the number is rounded down to the next pyramid level, and those statistics are used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object YSkipFactor { get; set; }

		/// <summary>
		/// <para>Ignore Values</para>
		/// <para>The pixel values that are not to be included in the statistics calculation.</para>
		/// <para>The default is no value or the last ignore value used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object IgnoreValues { get; set; }

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>Specify whether to calculate statistics only where they are missing or regenerate them even if they exist.</para>
		/// <para>Unchecked—Statistics will be calculated even if they already exist; therefore, existing statistics will be overwritten. This is the default.</para>
		/// <para>Checked—Statistics will only be calculated if they do not already exist.</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipExisting { get; set; } = "false";

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The area in the dataset from where you want the statistics to be calculated, so they are not generated from the entire dataset. You can either browse to a feature class or create a polygon graphic on the display.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Updated Input Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateStatistics SetEnviroment(object rasterStatistics = null , object scratchWorkspace = null , object workspace = null )
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
			[Description("SKIP_EXISTING")]
			SKIP_EXISTING,

			/// <summary>
			/// <para>Unchecked—Statistics will be calculated even if they already exist; therefore, existing statistics will be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE")]
			OVERWRITE,

		}

#endregion
	}
}
