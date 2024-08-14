using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Compute Segment Attributes</para>
	/// <para>Computes a set of attributes associated with the segmented image. The input raster can be a single-band or 3-band, 8-bit segmented image.</para>
	/// </summary>
	public class ComputeSegmentAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSegmentedRaster">
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>The input segmented raster dataset, where all the pixels belonging to a segment have the same converged RGB color. Usually, it is an 8-bit, 3-band RGB raster, but it can also be a 1-band grayscale raster.</para>
		/// </param>
		/// <param name="OutIndexRasterDataset">
		/// <para>Output Segment Index Raster</para>
		/// <para>The output segment index raster, where the attributes for each segment are recorded in the associated attribute table.</para>
		/// </param>
		public ComputeSegmentAttributes(object InSegmentedRaster, object OutIndexRasterDataset)
		{
			this.InSegmentedRaster = InSegmentedRaster;
			this.OutIndexRasterDataset = OutIndexRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Segment Attributes</para>
		/// </summary>
		public override string DisplayName => "Compute Segment Attributes";

		/// <summary>
		/// <para>Tool Name : ComputeSegmentAttributes</para>
		/// </summary>
		public override string ToolName => "ComputeSegmentAttributes";

		/// <summary>
		/// <para>Tool Excute Name : ia.ComputeSegmentAttributes</para>
		/// </summary>
		public override string ExcuteName => "ia.ComputeSegmentAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSegmentedRaster, OutIndexRasterDataset, InAdditionalRaster!, UsedAttributes! };

		/// <summary>
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>The input segmented raster dataset, where all the pixels belonging to a segment have the same converged RGB color. Usually, it is an 8-bit, 3-band RGB raster, but it can also be a 1-band grayscale raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSegmentedRaster { get; set; }

		/// <summary>
		/// <para>Output Segment Index Raster</para>
		/// <para>The output segment index raster, where the attributes for each segment are recorded in the associated attribute table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutIndexRasterDataset { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>Ancillary raster datasets, such as a multispectral image or a DEM, will be incorporated to generate attributes and other required information for the classifier. This raster is necessary when calculating attributes such as mean or standard deviation. This parameter is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// <para>Specifies the attributes that will be included in the attribute table associated with the output raster.</para>
		/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis. This is also known as average chromaticity color.</para>
		/// <para>Mean digital number—The average digital number (DN) will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Standard deviation—The standard deviation will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Count of pixels—The number of pixels composing the segment, on a per-segment basis.</para>
		/// <para>Compactness—The degree to which a segment is compact or circular, on a per-segment basis. The values range from 0 to 1, in which 1 is a circle.</para>
		/// <para>Rectangularity—The degree to which the segment is rectangular, on a per-segment basis. The values range from 0 to 1, in which 1 is a rectangle.</para>
		/// <para>If the only input into the tool is a segmented image, the default attributes are Average chromaticity color, Count of pixels, Compactness, and Rectangularity. If an Additional Input Raster is also included as an input along with a segmented image, then Mean digital number and Standard deviation are available as options.</para>
		/// <para><para/></para>
		/// <para><see cref="UsedAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Segment Attributes")]
		public object? UsedAttributes { get; set; } = "COLOR;MEAN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeSegmentAttributes SetEnviroment(object? compression = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// </summary>
		public enum UsedAttributesEnum 
		{
			/// <summary>
			/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis. This is also known as average chromaticity color.</para>
			/// </summary>
			[GPValue("COLOR")]
			[Description("Converged color")]
			Converged_color,

			/// <summary>
			/// <para>Mean digital number—The average digital number (DN) will be derived from the optional pixel image on a per-segment basis.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean digital number")]
			Mean_digital_number,

			/// <summary>
			/// <para>Standard deviation—The standard deviation will be derived from the optional pixel image on a per-segment basis.</para>
			/// </summary>
			[GPValue("STD")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Count of pixels—The number of pixels composing the segment, on a per-segment basis.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count of pixels")]
			Count_of_pixels,

			/// <summary>
			/// <para>Compactness—The degree to which a segment is compact or circular, on a per-segment basis. The values range from 0 to 1, in which 1 is a circle.</para>
			/// </summary>
			[GPValue("COMPACTNESS")]
			[Description("Compactness")]
			Compactness,

			/// <summary>
			/// <para>Rectangularity—The degree to which the segment is rectangular, on a per-segment basis. The values range from 0 to 1, in which 1 is a rectangle.</para>
			/// </summary>
			[GPValue("RECTANGULARITY")]
			[Description("Rectangularity")]
			Rectangularity,

		}

#endregion
	}
}
