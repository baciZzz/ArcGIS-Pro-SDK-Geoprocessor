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
	/// <para>Generates the data that will be used to train and validate </para>
	/// <para>a PointCNN model for classifying a point cloud.</para>
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
		/// <para>The two-dimensional width and height of each HDF5 tile created from the input point cloud. As a general rule, the block size should be large enough to capture the objects of interest and their surrounding context.</para>
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
		public override string DisplayName => "Prepare Point Cloud Training Data";

		/// <summary>
		/// <para>Tool Name : PreparePointCloudTrainingData</para>
		/// </summary>
		public override string ToolName => "PreparePointCloudTrainingData";

		/// <summary>
		/// <para>Tool Excute Name : 3d.PreparePointCloudTrainingData</para>
		/// </summary>
		public override string ExcuteName => "3d.PreparePointCloudTrainingData";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPointCloud, BlockSize, OutTrainingData, TrainingBoundary, ValidationPointCloud, ValidationBoundary, ClassCodesOfInterest, BlockPointLimit };

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
		/// <para>The two-dimensional width and height of each HDF5 tile created from the input point cloud. As a general rule, the block size should be large enough to capture the objects of interest and their surrounding context.</para>
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
		public object OutTrainingData { get; set; }

		/// <summary>
		/// <para>Training Boundary Features</para>
		/// <para>The boundary polygons that will delineate the subset of points from the input point cloud that will be used to train the deep learning model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TrainingBoundary { get; set; }

		/// <summary>
		/// <para>Validation Point Cloud</para>
		/// <para>The source of the point cloud that will be used to validate the deep learning model. This dataset must reference a different set of points than the input point cloud in order to ensure the quality of the trained model . If the validation point cloud is not specified, both the Training Boundary Features and Validation Boundary Features parameter values must be provided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object ValidationPointCloud { get; set; }

		/// <summary>
		/// <para>Validation Boundary Features</para>
		/// <para>The polygon features that will delineate the subset of points to be used for validating the trained model. If a validation point cloud is not specified, the points will be sourced from the input point cloud.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object ValidationBoundary { get; set; }

		/// <summary>
		/// <para>Class Codes of Interest</para>
		/// <para>The class codes that will limit the exported training data blocks to only those that contain the specified values. All points in the block will be exported for any block which contains at least one of the class codes listed in this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ClassCodesOfInterest { get; set; }

		/// <summary>
		/// <para>Block Point Limit</para>
		/// <para>The maximum number of points allowed in each block of the training data. When a block contains points in excess of this value, multiple blocks will be created for the same location to ensure that all of the points are used when training.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object BlockPointLimit { get; set; } = "8192";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PreparePointCloudTrainingData SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
