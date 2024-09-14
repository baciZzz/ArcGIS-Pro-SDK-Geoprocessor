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
	/// <para>Compute Tie Points</para>
	/// <para>Compute Tie Points</para>
	/// <para>Computes the tie points between overlapped mosaic dataset items. The tie points can then be used to compute the block adjustments for the mosaic dataset.</para>
	/// </summary>
	public class ComputeTiePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset that will be used to create tie points.</para>
		/// </param>
		/// <param name="OutControlPoints">
		/// <para>Output Control Points</para>
		/// <para>The output control point table. The table will contain the tie points created by this tool.</para>
		/// </param>
		public ComputeTiePoints(object InMosaicDataset, object OutControlPoints)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutControlPoints = OutControlPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Tie Points</para>
		/// </summary>
		public override string DisplayName() => "Compute Tie Points";

		/// <summary>
		/// <para>Tool Name : ComputeTiePoints</para>
		/// </summary>
		public override string ToolName() => "ComputeTiePoints";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeTiePoints</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeTiePoints";

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
		public override string[] ValidEnvironments() => new string[] { "gpuID", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutControlPoints, Similarity!, InMaskDataset!, OutImageFeatures!, Density!, Distribution!, LocationAccuracy!, Options! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset that will be used to create tie points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Control Points</para>
		/// <para>The output control point table. The table will contain the tie points created by this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutControlPoints { get; set; }

		/// <summary>
		/// <para>Similarity</para>
		/// <para>Specifies the similarity level that will be used for matching tie points.</para>
		/// <para>Low similarity—The similarity criteria for the two matching points will be low. This option will produce the most matching points, but some of the matches may have a higher level of error.</para>
		/// <para>Medium similarity—The similarity criteria for the matching points will be medium.</para>
		/// <para>High similarity—The similarity criteria for the matching points will be high. This option will produce the fewest matching points, but each match will have a lower level of error.</para>
		/// <para><see cref="SimilarityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Similarity { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Input Mask</para>
		/// <para>A polygon feature class used to exclude areas that will not be included in the computation of control points.</para>
		/// <para>A field with a name of mask can control the inclusion or exclusion of areas. A value of 1 indicates that the areas defined by the polygons (inside) will be excluded from the computation. A value of 2 indicates the defined polygons (inside) will be included in the computation while areas outside of the polygons will be excluded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InMaskDataset { get; set; }

		/// <summary>
		/// <para>Output Image Features</para>
		/// <para>The output image feature points table. This will be saved as a polygon feature class. This output can be quite large.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutImageFeatures { get; set; }

		/// <summary>
		/// <para>Point Density</para>
		/// <para>Specifies the number of tie points to be created.</para>
		/// <para>Low point density—The density of points will be low, creating the fewest number of tie points.</para>
		/// <para>Medium point density—The density of points will be medium, creating a moderate number of points.</para>
		/// <para>High point density—The density of points will be high, creating the highest number of points.</para>
		/// <para><see cref="DensityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Density { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Point Distribution</para>
		/// <para>Specifies whether the points will have regular or random distribution.</para>
		/// <para>Random point distribution—Points will be generated randomly. Randomly generated points are better for overlapping areas with irregular shapes.</para>
		/// <para>Regular point distribution—Points will be generated based on a fixed pattern. Points based on a fixed pattern use the point density to determine how frequently to create points.</para>
		/// <para><see cref="DistributionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Distribution { get; set; } = "RANDOM";

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// <para>Specifies the keyword that describes the accuracy of the imagery.</para>
		/// <para>Low image location accuracy—Images have a large shift and a large rotation (&gt; 5 degrees).The SIFT algorithm will be used in the point-matching computation.</para>
		/// <para>Medium image location accuracy—Images have a medium shift and a small rotation (&lt;5 degrees).The Harris algorithm will be used in the point-matching computation.</para>
		/// <para>High image location accuracy—Images have a small shift and a small rotation.The Harris algorithm will be used in the point-matching computation.</para>
		/// <para><see cref="LocationAccuracyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocationAccuracy { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Additional Options</para>
		/// <para>Additional options for the adjustment engine. The options are only used by third-party adjustment engines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Options { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeTiePoints SetEnviroment(object? parallelProcessingFactor = null, object? processorType = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Similarity</para>
		/// </summary>
		public enum SimilarityEnum 
		{
			/// <summary>
			/// <para>Low similarity—The similarity criteria for the two matching points will be low. This option will produce the most matching points, but some of the matches may have a higher level of error.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low similarity")]
			Low_similarity,

			/// <summary>
			/// <para>Medium similarity—The similarity criteria for the matching points will be medium.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium similarity")]
			Medium_similarity,

			/// <summary>
			/// <para>High similarity—The similarity criteria for the matching points will be high. This option will produce the fewest matching points, but each match will have a lower level of error.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High similarity")]
			High_similarity,

		}

		/// <summary>
		/// <para>Point Density</para>
		/// </summary>
		public enum DensityEnum 
		{
			/// <summary>
			/// <para>Low point density—The density of points will be low, creating the fewest number of tie points.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low point density")]
			Low_point_density,

			/// <summary>
			/// <para>Medium point density—The density of points will be medium, creating a moderate number of points.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium point density")]
			Medium_point_density,

			/// <summary>
			/// <para>High point density—The density of points will be high, creating the highest number of points.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High point density")]
			High_point_density,

		}

		/// <summary>
		/// <para>Point Distribution</para>
		/// </summary>
		public enum DistributionEnum 
		{
			/// <summary>
			/// <para>Random point distribution—Points will be generated randomly. Randomly generated points are better for overlapping areas with irregular shapes.</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("Random point distribution")]
			Random_point_distribution,

			/// <summary>
			/// <para>Regular point distribution—Points will be generated based on a fixed pattern. Points based on a fixed pattern use the point density to determine how frequently to create points.</para>
			/// </summary>
			[GPValue("REGULAR")]
			[Description("Regular point distribution")]
			Regular_point_distribution,

		}

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// </summary>
		public enum LocationAccuracyEnum 
		{
			/// <summary>
			/// <para>Low image location accuracy—Images have a large shift and a large rotation (&gt; 5 degrees).The SIFT algorithm will be used in the point-matching computation.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low image location accuracy")]
			Low_image_location_accuracy,

			/// <summary>
			/// <para>Medium image location accuracy—Images have a medium shift and a small rotation (&lt;5 degrees).The Harris algorithm will be used in the point-matching computation.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium image location accuracy")]
			Medium_image_location_accuracy,

			/// <summary>
			/// <para>High image location accuracy—Images have a small shift and a small rotation.The Harris algorithm will be used in the point-matching computation.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High image location accuracy")]
			High_image_location_accuracy,

		}

#endregion
	}
}
