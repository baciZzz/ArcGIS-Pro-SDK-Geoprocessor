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
	/// <para>Build Boundary</para>
	/// <para>Build Boundary</para>
	/// <para>Updates the extent of the boundary when adding new raster datasets to a mosaic dataset that extend beyond its previous coverage.</para>
	/// </summary>
	public class BuildBoundary : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>Select the mosaic dataset where you want to recompute the boundary.</para>
		/// </param>
		public BuildBoundary(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Boundary</para>
		/// </summary>
		public override string DisplayName() => "Build Boundary";

		/// <summary>
		/// <para>Tool Name : BuildBoundary</para>
		/// </summary>
		public override string ToolName() => "BuildBoundary";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildBoundary</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildBoundary";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, AppendToExisting, SimplificationMethod, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>Select the mosaic dataset where you want to recompute the boundary.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL query to compute a boundary for select raster datasets. Use this option in conjunction with the Append to Existing Boundary option to save time when adding new raster datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Append To Existing Boundary</para>
		/// <para>Use this option when adding new raster datasets to an existing mosaic dataset. Instead of calculating the entire boundary, it will merge the boundary of the new raster datasets with the existing boundary.</para>
		/// <para>Checked—Append the perimeter of footprints to the existing boundary. This can save time when adding additional raster data to the mosaic dataset, as the entire boundary will not be recalculated. If there are rasters selected, the boundary will be recalculated to include only the selected footprints. This is the default.</para>
		/// <para>Unchecked—Recompute the boundary in its entirety.</para>
		/// <para><see cref="AppendToExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object AppendToExisting { get; set; } = "false";

		/// <summary>
		/// <para>Simplification Method</para>
		/// <para>The simplification method reduces the number of vertices, since a dense boundary can affect performance.</para>
		/// <para>Choose which simplification method to use to simplify the boundary.</para>
		/// <para>None—No simplification method will be implemented. This is the default.</para>
		/// <para>Convex hull—The minimum bounding geometry of the mosaic dataset will be used to simplify the boundary. If there are any footprints that are disconnected, a minimum bounding geometry for each continuous group of footprints will be used to simplify the boundary.</para>
		/// <para>Envelope—The envelope of the mosaic dataset will provide a simplified boundary. If there are any footprints that are disconnected, an envelope for each continuous group of footprints will be used to simplify the boundary.</para>
		/// <para><see cref="SimplificationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object SimplificationMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Updated Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildBoundary SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append To Existing Boundary</para>
		/// </summary>
		public enum AppendToExistingEnum 
		{
			/// <summary>
			/// <para>Checked—Append the perimeter of footprints to the existing boundary. This can save time when adding additional raster data to the mosaic dataset, as the entire boundary will not be recalculated. If there are rasters selected, the boundary will be recalculated to include only the selected footprints. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—Recompute the boundary in its entirety.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE")]
			OVERWRITE,

		}

		/// <summary>
		/// <para>Simplification Method</para>
		/// </summary>
		public enum SimplificationMethodEnum 
		{
			/// <summary>
			/// <para>None—No simplification method will be implemented. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Convex hull—The minimum bounding geometry of the mosaic dataset will be used to simplify the boundary. If there are any footprints that are disconnected, a minimum bounding geometry for each continuous group of footprints will be used to simplify the boundary.</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("Convex hull")]
			Convex_hull,

			/// <summary>
			/// <para>Envelope—The envelope of the mosaic dataset will provide a simplified boundary. If there are any footprints that are disconnected, an envelope for each continuous group of footprints will be used to simplify the boundary.</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("Envelope")]
			Envelope,

		}

#endregion
	}
}
