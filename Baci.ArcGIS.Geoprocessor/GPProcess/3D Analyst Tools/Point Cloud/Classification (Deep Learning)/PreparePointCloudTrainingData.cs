using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Prepare Point Cloud Training Data</para>
	/// <para>Prepare Point Cloud Training Data</para>
	/// <para>Generates the data that will be used to train and validate a PointCNN model for point cloud classification.</para>
	/// </summary>
	public class PreparePointCloudTrainingData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Input Point Cloud</para>
		/// <para>The point cloud that will be used to create the training data and, potentially, the validation data if no validation point cloud is specified. In this case, both the training boundary and the validation boundary must be defined.</para>
		/// </param>
		/// <param name="BlockSize">
		/// <para>Block Size</para>
		/// <para>The diameter size of each circular HDF5 tile created from the input point cloud. As a general rule, the block size should be large enough to capture the objects of interest and their surrounding context.</para>
		/// </param>
		/// <param name="OutTrainingData">
		/// <para>Output Training Data</para>
		/// <para>The location and name of the output training data (*.pctd).</para>
		/// </param>
		public PreparePointCloudTrainingData(object InPointCloud, object BlockSize, object OutTrainingData)
		{
			this.InPointCloud = InPointCloud;
			this.BlockSize = BlockSize;
			this.OutTrainingData = OutTrainingData;
		}

		/// <summary>
		/// <para>Tool Display Name : Prepare Point Cloud Training Data</para>
		/// </summary>
		public override string DisplayName() => "Prepare Point Cloud Training Data";

		/// <summary>
		/// <para>Tool Name : PreparePointCloudTrainingData</para>
		/// </summary>
		public override string ToolName() => "PreparePointCloudTrainingData";

		/// <summary>
		/// <para>Tool Excute Name : 3d.PreparePointCloudTrainingData</para>
		/// </summary>
		public override string ExcuteName() => "3d.PreparePointCloudTrainingData";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointCloud, BlockSize, OutTrainingData, TrainingBoundary!, ValidationPointCloud!, ValidationBoundary!, ClassCodesOfInterest!, BlockPointLimit!, ReferenceHeight!, ExcludedClassCodes! };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>The point cloud that will be used to create the training data and, potentially, the validation data if no validation point cloud is specified. In this case, both the training boundary and the validation boundary must be defined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Block Size</para>
		/// <para>The diameter size of each circular HDF5 tile created from the input point cloud. As a general rule, the block size should be large enough to capture the objects of interest and their surrounding context.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BlockSize { get; set; }

		/// <summary>
		/// <para>Output Training Data</para>
		/// <para>The location and name of the output training data (*.pctd).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pctd")]
		public object OutTrainingData { get; set; }

		/// <summary>
		/// <para>Training Boundary Features</para>
		/// <para>The boundary polygons that will delineate the subset of points from the input point cloud that will be used to train the deep learning model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? TrainingBoundary { get; set; }

		/// <summary>
		/// <para>Validation Point Cloud</para>
		/// <para>The point cloud that will be used to validate the deep learning model during the training process. This dataset must reference a different set of points than the input point cloud to ensure the quality of the trained model. If a validation point cloud is not specified, the input point cloud can be used to define the training and validation datasets by providing polygon feature classes for the Training Boundary Features and Validation Boundary Features parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? ValidationPointCloud { get; set; }

		/// <summary>
		/// <para>Validation Boundary Features</para>
		/// <para>The polygon features that will delineate the subset of points to be used for evaluating the model during the training process. If a validation point cloud is not specified, the points will be sourced from the input point cloud.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? ValidationBoundary { get; set; }

		/// <summary>
		/// <para>Filter Blocks By Class Code</para>
		/// <para>The class codes that will be used to limit the exported training data blocks. All points in the blocks that contain at least one of the values listed for this parameter will be exported, except the classes specified in the Excluded Class Codes parameter or the points that are flagged as Withheld. Any value in the range of 0 to 255 can be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ClassCodesOfInterest { get; set; }

		/// <summary>
		/// <para>Block Point Limit</para>
		/// <para>The maximum number of points that will be allowed in each block of the training data. When a block contains points in excess of this value, multiple blocks will be created for the same location to ensure that all of the points are used when training.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? BlockPointLimit { get; set; } = "8192";

		/// <summary>
		/// <para>Reference Surface</para>
		/// <para>The raster surface that will be used to provide relative height values for each point in the point cloud data. Points that do not overlap with the raster will be omitted from the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ReferenceHeight { get; set; }

		/// <summary>
		/// <para>Excluded Class Codes</para>
		/// <para>The class codes that will be excluded from the training data. Any value in the range of 0 to 255 can be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPRangeDomain(Min = 0, Max = 255)]
		public object? ExcludedClassCodes { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PreparePointCloudTrainingData SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
