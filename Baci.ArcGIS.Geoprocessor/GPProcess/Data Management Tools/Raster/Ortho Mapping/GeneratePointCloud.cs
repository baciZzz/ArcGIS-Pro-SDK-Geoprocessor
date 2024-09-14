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
	/// <para>Generate Point Cloud</para>
	/// <para>Generate Point Cloud</para>
	/// <para>Computes 3D points from stereo pairs and outputs a point cloud as a set of LAS files.</para>
	/// </summary>
	public class GeneratePointCloud : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset, which must have completed the block adjustment process and have a stereo model.</para>
		/// <para>To block adjust the mosaic dataset, use the Apply Block Adjustment tool. To build a stereo model on the mosaic dataset, use the Build Stereo Model tool.</para>
		/// </param>
		/// <param name="MatchingMethod">
		/// <para>Matching Method</para>
		/// <para>The method used to generate 3D points.</para>
		/// <para>Extended terrain matching—A feature-based stereo matching in which the Harris operator is used in detecting feature points. Since less feature points are extracted, this method is fast and can be used for data with less terrain variations and detail.</para>
		/// <para>Semiglobal matching—Semi-Global Matching (SGM) produces points that are denser and have more detailed terrain information. It can be used for images of urban areas. This is more computational intensive than ETM.1</para>
		/// <para>Multi-view image matching—Multi-view image matching (MVM) is based on the SGM matching method followed by a fusion step in which the redundant depth estimations across a single stereo model are merged. It produces dense 3D points and is computationally efficient.2</para>
		/// <para>References:</para>
		/// <para>Heiko Hirschmuller et al., &quot;Memory Efficient Semi-Global Matching,&quot; ISPRS Annals of the Photogrammetry, Remote Sensing and Spatial Information Sciences, Volume 1–3, (2012): 371–376.</para>
		/// <para>Hirschmuller, H. &quot;Stereo Processing by Semiglobal Matching and Mutual Information.&quot; Pattern Analysis and Machine Intelligence, (2008).</para>
		/// <para><see cref="MatchingMethodEnum"/></para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output LAS Folder</para>
		/// <para>The folder used to store the output LAS files.</para>
		/// <para>If this tool is run multiple times with the same input parameters, the output may be slightly different due to random sampling.</para>
		/// </param>
		/// <param name="OutBaseName">
		/// <para>Output LAS Base Name</para>
		/// <para>A string used as a prefix to formulate the output LAS file names. For example, if name is used as the base, the output files will be named name1.las, name2.las, and so on.</para>
		/// </param>
		public GeneratePointCloud(object InMosaicDataset, object MatchingMethod, object OutFolder, object OutBaseName)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.MatchingMethod = MatchingMethod;
			this.OutFolder = OutFolder;
			this.OutBaseName = OutBaseName;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Point Cloud</para>
		/// </summary>
		public override string DisplayName() => "Generate Point Cloud";

		/// <summary>
		/// <para>Tool Name : GeneratePointCloud</para>
		/// </summary>
		public override string ToolName() => "GeneratePointCloud";

		/// <summary>
		/// <para>Tool Excute Name : management.GeneratePointCloud</para>
		/// </summary>
		public override string ExcuteName() => "management.GeneratePointCloud";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, MatchingMethod, OutFolder, OutBaseName, ObjectSize!, GroundSpacing!, MinimumPairs!, MinimumArea!, MinimumAdjustmentQuality!, MaximumDiffGsd!, MaximumDiffOP! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset, which must have completed the block adjustment process and have a stereo model.</para>
		/// <para>To block adjust the mosaic dataset, use the Apply Block Adjustment tool. To build a stereo model on the mosaic dataset, use the Build Stereo Model tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Matching Method</para>
		/// <para>The method used to generate 3D points.</para>
		/// <para>Extended terrain matching—A feature-based stereo matching in which the Harris operator is used in detecting feature points. Since less feature points are extracted, this method is fast and can be used for data with less terrain variations and detail.</para>
		/// <para>Semiglobal matching—Semi-Global Matching (SGM) produces points that are denser and have more detailed terrain information. It can be used for images of urban areas. This is more computational intensive than ETM.1</para>
		/// <para>Multi-view image matching—Multi-view image matching (MVM) is based on the SGM matching method followed by a fusion step in which the redundant depth estimations across a single stereo model are merged. It produces dense 3D points and is computationally efficient.2</para>
		/// <para>References:</para>
		/// <para>Heiko Hirschmuller et al., &quot;Memory Efficient Semi-Global Matching,&quot; ISPRS Annals of the Photogrammetry, Remote Sensing and Spatial Information Sciences, Volume 1–3, (2012): 371–376.</para>
		/// <para>Hirschmuller, H. &quot;Stereo Processing by Semiglobal Matching and Mutual Information.&quot; Pattern Analysis and Machine Intelligence, (2008).</para>
		/// <para><see cref="MatchingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MatchingMethod { get; set; } = "ETM";

		/// <summary>
		/// <para>Output LAS Folder</para>
		/// <para>The folder used to store the output LAS files.</para>
		/// <para>If this tool is run multiple times with the same input parameters, the output may be slightly different due to random sampling.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output LAS Base Name</para>
		/// <para>A string used as a prefix to formulate the output LAS file names. For example, if name is used as the base, the output files will be named name1.las, name2.las, and so on.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutBaseName { get; set; }

		/// <summary>
		/// <para>Maximum Object Size (in meter)</para>
		/// <para>A search radius within which surface objects, such as buildings or trees, will be identified. It is the linear size in map units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ObjectSize { get; set; } = "10";

		/// <summary>
		/// <para>DSM Ground Spacing (in meter)</para>
		/// <para>The ground spacing, in meters, at which the 3D points are generated.</para>
		/// <para>The default is five times the source image pixel size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? GroundSpacing { get; set; }

		/// <summary>
		/// <para>Number of Image Pairs</para>
		/// <para>The number of pairs used to generate 3D points. The default value is a minimum of 2 image pairs.</para>
		/// <para>Sometimes a location may be covered with many image pairs. In this case, the tool will order the pairs based on the various threshold parameters specified in this tool. The pairs with the highest scores will be used to generate the points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumPairs { get; set; } = "4";

		/// <summary>
		/// <para>Overlap Area Threshold</para>
		/// <para>Specify a minimum overlap threshold area that is acceptable, which is a percentage of overlap between a pair of images. Image pairs with overlap areas smaller than this threshold will receive a score of 0 for this criteria and will descend in the ordered list. The range of values for the threshold is from 0 to 1. The default threshold value is 0.6, which is equal to 60 percent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumArea { get; set; } = "0.6";

		/// <summary>
		/// <para>Adjustment Quality Threshold</para>
		/// <para>Specify the minimum adjustment quality that is acceptable. The threshold value will be compared to the adjustment quality value that is stored in the stereo model. Image pairs with an adjustment quality less than the specified threshold will receive a score of 0 for this criteria and will descend in the ordered list. The range of values for the threshold is from 0 to 1. The default value is 0.2, which is equal to 20 percent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumAdjustmentQuality { get; set; } = "0.2";

		/// <summary>
		/// <para>GSD Difference Threshold</para>
		/// <para>Specify the maximum allowable threshold for the ground sample distance (GSD) between two images in a pair. The resolution ratio between the two images will be compared to the threshold value. Image pairs with a ground sample ratio greater than this threshold will receive a score of 0 for this criteria and will descend in the ordered list. The default threshold ratio is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffGsd { get; set; } = "2";

		/// <summary>
		/// <para>Omega/Phi Difference Threshold</para>
		/// <para>Specify the maximum threshold for the Omega\Phi difference between the two image pairs. The Omega values and Phi values for the image pairs are compared. Image pairs with an Omega or a Phi difference greater than this threshold will receive a score of 0 for this criteria and will descend in the ordered list. The default threshold difference for each comparison is 8.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffOP { get; set; } = "8";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneratePointCloud SetEnviroment(object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Matching Method</para>
		/// </summary>
		public enum MatchingMethodEnum 
		{
			/// <summary>
			/// <para>Extended terrain matching—A feature-based stereo matching in which the Harris operator is used in detecting feature points. Since less feature points are extracted, this method is fast and can be used for data with less terrain variations and detail.</para>
			/// </summary>
			[GPValue("ETM")]
			[Description("Extended terrain matching")]
			Extended_terrain_matching,

			/// <summary>
			/// <para>Semiglobal matching—Semi-Global Matching (SGM) produces points that are denser and have more detailed terrain information. It can be used for images of urban areas. This is more computational intensive than ETM.1</para>
			/// </summary>
			[GPValue("SGM")]
			[Description("Semiglobal matching")]
			Semiglobal_matching,

			/// <summary>
			/// <para>Multi-view image matching—Multi-view image matching (MVM) is based on the SGM matching method followed by a fusion step in which the redundant depth estimations across a single stereo model are merged. It produces dense 3D points and is computationally efficient.2</para>
			/// </summary>
			[GPValue("MVM")]
			[Description("Multi-view image matching")]
			MVM,

		}

#endregion
	}
}
