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
	/// <para>Calculate Cell Size Ranges</para>
	/// <para>Calculate Cell Size Ranges</para>
	/// <para>Computes the visibility levels of raster datasets in a mosaic dataset based on the spatial resolution.</para>
	/// </summary>
	public class CalculateCellSizeRanges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset to calculate the visibility levels for.</para>
		/// </param>
		public CalculateCellSizeRanges(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Cell Size Ranges</para>
		/// </summary>
		public override string DisplayName() => "Calculate Cell Size Ranges";

		/// <summary>
		/// <para>Tool Name : CalculateCellSizeRanges</para>
		/// </summary>
		public override string ToolName() => "CalculateCellSizeRanges";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateCellSizeRanges</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateCellSizeRanges";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, DoComputeMin, DoComputeMax, MaxRangeFactor, CellSizeToleranceFactor, UpdateMissingOnly, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset to calculate the visibility levels for.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select specific rasters in the mosaic dataset on which to calculate visibility levels. If no query is specified, all the mosaic dataset items will have their cell size ranges calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Compute Minimum Cell Sizes</para>
		/// <para>Compute the minimum pixel size for each selected raster dataset in the mosaic dataset.</para>
		/// <para>Checked—Compute the minimum pixel size. This is the default.</para>
		/// <para>Unchecked—Do not compute the minimum pixel size.</para>
		/// <para><see cref="DoComputeMinEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object DoComputeMin { get; set; } = "true";

		/// <summary>
		/// <para>Compute Maximum Cell Sizes</para>
		/// <para>Compute the maximum pixel size for each selected raster in the mosaic dataset.</para>
		/// <para>Checked—Compute the maximum pixel size. This is the default.</para>
		/// <para>Unchecked—Do not compute the maximum pixel size.</para>
		/// <para><see cref="DoComputeMaxEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object DoComputeMax { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Cell Size Range Factor</para>
		/// <para>Set a multiplication factor to apply to the native resolution. The default is 10, meaning that an image with a resolution of 30 meters will be visible at a scale appropriate for 300 meters. The relationship between cell size and scale is as follows:</para>
		/// <para>Cell Size = Scale * 0.0254 / 96</para>
		/// <para>Scale = Cell Size * 96 / 0.0254</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object MaxRangeFactor { get; set; } = "10";

		/// <summary>
		/// <para>Cell Size Tolerance Factor</para>
		/// <para>Use this to group images with similar resolutions as having the same nominal resolution. For example 1 m imagery and 0.9 m imagery can be grouped together by setting this factor to 0.1, because they are within 10% of each other.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object CellSizeToleranceFactor { get; set; } = "0.8";

		/// <summary>
		/// <para>Update Missing Values Only</para>
		/// <para>Calculate only the missing cell size range values.</para>
		/// <para>Unchecked—Calculate cell size minimum and maximum values for selected rasters within the mosaic dataset. This is the default.</para>
		/// <para>Checked—Calculate cell size minimum and maximum values only if they do not exist.</para>
		/// <para><see cref="UpdateMissingOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object UpdateMissingOnly { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateCellSizeRanges SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute Minimum Cell Sizes</para>
		/// </summary>
		public enum DoComputeMinEnum 
		{
			/// <summary>
			/// <para>Checked—Compute the minimum pixel size. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MIN_CELL_SIZES")]
			MIN_CELL_SIZES,

			/// <summary>
			/// <para>Unchecked—Do not compute the minimum pixel size.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_CELL_SIZES")]
			NO_MIN_CELL_SIZES,

		}

		/// <summary>
		/// <para>Compute Maximum Cell Sizes</para>
		/// </summary>
		public enum DoComputeMaxEnum 
		{
			/// <summary>
			/// <para>Checked—Compute the maximum pixel size. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MAX_CELL_SIZES")]
			MAX_CELL_SIZES,

			/// <summary>
			/// <para>Unchecked—Do not compute the maximum pixel size.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAX_CELL_SIZES")]
			NO_MAX_CELL_SIZES,

		}

		/// <summary>
		/// <para>Update Missing Values Only</para>
		/// </summary>
		public enum UpdateMissingOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Calculate cell size minimum and maximum values only if they do not exist.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_MISSING_ONLY")]
			UPDATE_MISSING_ONLY,

			/// <summary>
			/// <para>Unchecked—Calculate cell size minimum and maximum values for selected rasters within the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("UPDATE_ALL")]
			UPDATE_ALL,

		}

#endregion
	}
}
