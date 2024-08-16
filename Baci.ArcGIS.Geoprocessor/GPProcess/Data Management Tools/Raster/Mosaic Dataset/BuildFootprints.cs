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
	/// <para>Build Footprints</para>
	/// <para>Computes the extent of every raster in a mosaic dataset. This tool is used when you have added or removed raster datasets from a mosaic dataset and want to recompute the footprints.</para>
	/// </summary>
	public class BuildFootprints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that contains the raster datasets whose footprints you want to compute.</para>
		/// </param>
		public BuildFootprints(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Footprints</para>
		/// </summary>
		public override string DisplayName => "Build Footprints";

		/// <summary>
		/// <para>Tool Name : BuildFootprints</para>
		/// </summary>
		public override string ToolName => "BuildFootprints";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildFootprints</para>
		/// </summary>
		public override string ExcuteName => "management.BuildFootprints";

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
		public override string[] ValidEnvironments => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, WhereClause, ResetFootprint, MinDataValue, MaxDataValue, ApproxNumVertices, ShrinkDistance, MaintainEdges, SkipDerivedImages, UpdateBoundary, RequestSize, MinRegionSize, SimplificationMethod, EdgeTolerance, MaxSliverSize, MinThinnessRatio, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that contains the raster datasets whose footprints you want to compute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select specific raster datasets within the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Computation Method</para>
		/// <para>Refine the footprints using one of the following methods:</para>
		/// <para>Radiometry— Exclude pixels with a value outside of a defined range. This option is generally used to exclude border areas, which do not contain valid data. This is the default.</para>
		/// <para>Geometry— Restore the footprint to its original geometry.</para>
		/// <para>Copy to sibling— Replace the panchromatic footprint with the multispectral footprint when using a pan-sharpened raster type. This can occur when the panchromatic and multispectral images do not have identical geometries.</para>
		/// <para>None—Do not redefine the footprints.</para>
		/// <para><para/></para>
		/// <para><see cref="ResetFootprintEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCodedValueDomain()]
		public object ResetFootprint { get; set; } = "RADIOMETRY";

		/// <summary>
		/// <para>Minimum Data Value</para>
		/// <para>Exclude pixels with a value less than this number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinDataValue { get; set; } = "1";

		/// <summary>
		/// <para>Maximum Data Value</para>
		/// <para>Exclude pixels with a value greater than this number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxDataValue { get; set; } = "254";

		/// <summary>
		/// <para>Approximate number of vertices</para>
		/// <para>Choose between 4 and 10,000. More vertices will improve accuracy but can extend processing time. A value of -1 will calculate all vertices. More vertices will increase accuracy but also the processing time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = -1, Max = 10000)]
		public object ApproxNumVertices { get; set; } = "80";

		/// <summary>
		/// <para>Shrink distance</para>
		/// <para>Clip the footprint by this distance. This can eliminate artifacts from using lossy compression, which causes the edges of the image to overlap into NoData areas.</para>
		/// <para>Shrinking of the polygon is used to counteract effects of lossy compression, which causes edges of the image to overlap into NoData areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ShrinkDistance { get; set; } = "0";

		/// <summary>
		/// <para>Maintain sheet edges</para>
		/// <para>Alter the footprints of raster datasets that have been tiled and are adjacent (line up along the seams with little to no overlap).</para>
		/// <para>Unchecked—Remove the sheet edges from all the footprints. This is the default.</para>
		/// <para>Checked—Maintain the footprints in their original state.</para>
		/// <para><see cref="MaintainEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MaintainEdges { get; set; } = "false";

		/// <summary>
		/// <para>Skip overviews</para>
		/// <para>Adjust the footprints of overviews.</para>
		/// <para>Checked—Do not adjust the footprints of overviews. This is the default.</para>
		/// <para>Unchecked—Adjust the footprints of overviews and associated raster datasets.</para>
		/// <para><see cref="SkipDerivedImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipDerivedImages { get; set; } = "true";

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>Update the boundary of the mosaic dataset if you have added or removed imagery that changes the extent.</para>
		/// <para>Checked—Update the boundary. This is the default.</para>
		/// <para>Unchecked—Do not update the boundary.</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Request Size</para>
		/// <para>Set the resampled extent (in columns and rows) for the raster when building footprints. Greater image resolution provides more detail in the raster dataset but increases the processing time. A value of -1 will compute the footprint at the original resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = -1, Max = 2147483647)]
		[Category("Advanced Options")]
		public object RequestSize { get; set; } = "2000";

		/// <summary>
		/// <para>Minimum Region Size</para>
		/// <para>Avoid small holes in your imagery when using pixel values to create a mask. For example, your imagery may have a range of values from 0 to 255, and to mask clouds, you've excluded values from 245 to 255, which may cause other, noncloud pixels to be masked as well. If those areas are smaller than the number of pixels specified here, they will not be masked out.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Advanced Options")]
		public object MinRegionSize { get; set; } = "100";

		/// <summary>
		/// <para>Simplification Method</para>
		/// <para>Reduce the number of vertices in the footprint to improve performance.</para>
		/// <para>None—Do not limit the number of vertices. This is the default.</para>
		/// <para>Convex hull—Use the minimum bounding box to simplify the footprint.</para>
		/// <para>Envelope—Use the envelope of each mosaic dataset item to simplify the footprint.</para>
		/// <para><see cref="SimplificationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SimplificationMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Edge tolerance</para>
		/// <para>Snap the footprint to the sheet edge if it is within this tolerance. Units are the same as those in the mosaic dataset coordinate system.</para>
		/// <para>By default, the value is empty for which the tolerance is computed based on the pixel size corresponding to the requested resampled raster.</para>
		/// <para>A value of -1 will compute the tolerance using the average pixel size of the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object EdgeTolerance { get; set; }

		/// <summary>
		/// <para>Maximum Sliver Size</para>
		/// <para>Identify all polygons that are smaller than the square of this value. The value is specified in pixels and is based on the Request Size, not the spatial resolution of the source raster.</para>
		/// <para>Regions less than the (Maximum Sliver Size)^2 and less than the Minimum Thinness Ratio are considered slivers and will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Sliver Removal Options")]
		public object MaxSliverSize { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Thinness Ratio</para>
		/// <para>Define the thinness of slivers on a scale from 0 to 1.0, where 1.0 represents a circle and 0.0 represents a polygon that approaches a straight line.</para>
		/// <para>Polygons that are below both the Maximum Sliver Size and Minimum Thinness Ratio will be removed from the footprint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Sliver Removal Options")]
		public object MinThinnessRatio { get; set; } = "0.05";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildFootprints SetEnviroment(object parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Computation Method</para>
		/// </summary>
		public enum ResetFootprintEnum 
		{
			/// <summary>
			/// <para>None—Do not redefine the footprints.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Geometry— Restore the footprint to its original geometry.</para>
			/// </summary>
			[GPValue("GEOMETRY")]
			[Description("Geometry")]
			Geometry,

			/// <summary>
			/// <para>Radiometry— Exclude pixels with a value outside of a defined range. This option is generally used to exclude border areas, which do not contain valid data. This is the default.</para>
			/// </summary>
			[GPValue("RADIOMETRY")]
			[Description("Radiometry")]
			Radiometry,

			/// <summary>
			/// <para>Copy to sibling— Replace the panchromatic footprint with the multispectral footprint when using a pan-sharpened raster type. This can occur when the panchromatic and multispectral images do not have identical geometries.</para>
			/// </summary>
			[GPValue("COPY_TO_SIBLING")]
			[Description("Copy to sibling")]
			Copy_to_sibling,

		}

		/// <summary>
		/// <para>Maintain sheet edges</para>
		/// </summary>
		public enum MaintainEdgesEnum 
		{
			/// <summary>
			/// <para>Checked—Maintain the footprints in their original state.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_EDGES")]
			MAINTAIN_EDGES,

			/// <summary>
			/// <para>Unchecked—Remove the sheet edges from all the footprints. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAINTAIN_EDGES")]
			NO_MAINTAIN_EDGES,

		}

		/// <summary>
		/// <para>Skip overviews</para>
		/// </summary>
		public enum SkipDerivedImagesEnum 
		{
			/// <summary>
			/// <para>Checked—Do not adjust the footprints of overviews. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_DERIVED_IMAGES")]
			SKIP_DERIVED_IMAGES,

			/// <summary>
			/// <para>Unchecked—Adjust the footprints of overviews and associated raster datasets.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SKIP_DERIVED_IMAGES")]
			NO_SKIP_DERIVED_IMAGES,

		}

		/// <summary>
		/// <para>Update Boundary</para>
		/// </summary>
		public enum UpdateBoundaryEnum 
		{
			/// <summary>
			/// <para>Checked—Update the boundary. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_BOUNDARY")]
			UPDATE_BOUNDARY,

			/// <summary>
			/// <para>Unchecked—Do not update the boundary.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOUNDARY")]
			NO_BOUNDARY,

		}

		/// <summary>
		/// <para>Simplification Method</para>
		/// </summary>
		public enum SimplificationMethodEnum 
		{
			/// <summary>
			/// <para>None—Do not limit the number of vertices. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Convex hull—Use the minimum bounding box to simplify the footprint.</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("Convex hull")]
			Convex_hull,

			/// <summary>
			/// <para>Envelope—Use the envelope of each mosaic dataset item to simplify the footprint.</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("Envelope")]
			Envelope,

		}

#endregion
	}
}
